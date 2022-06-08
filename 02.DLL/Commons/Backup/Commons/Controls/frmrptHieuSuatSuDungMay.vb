Imports Excel
Imports System.Drawing
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptHieuSuatSuDungMay
    Private _Nam As DateTime
    Private _NhaXuong As String

    Private Sub frmrptHieuSuatSuDungMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadNam()
        _Nam = New DateTime(cbxNam.SelectedValue, 1, 1)
        LoadNhaxuong(_Nam)
        LoadLoaiMay(cbxNhaXuong.SelectedValue)
        AddHandler cbxNam.SelectedIndexChanged, AddressOf cbxNam_SelectedIndexChanged
        AddHandler cbxNhaXuong.SelectedIndexChanged, AddressOf cbxNhaXuong_SelectedIndexChanged
    End Sub

    Sub loadNam()
        cbxNam.Value = "NAM"
        cbxNam.Display = "NAM"
        cbxNam.StoreName = "H_GET_NAM_THOI_GIAN_NGUNG_MAY"
        cbxNam.Param = Commons.Modules.UserName
        cbxNam.BindDataSource()
    End Sub

    Sub LoadLoaiMay(ByVal _Nhaxuong As String)
        Try
            cbxLoaiMay.Value = "MS_LOAI_MAY"
            cbxLoaiMay.Display = "TEN_LOAI_MAY"
            cbxLoaiMay.StoreName = "H_GET_LOAI_MAY_NX_TGNM"
            cbxLoaiMay.Param = _Nhaxuong
            cbxLoaiMay.BindDataSource()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadNhaxuong(ByVal _nam As DateTime)
        Try
            cbxNhaXuong.Value = "MS_N_XUONG"
            cbxNhaXuong.Display = "TEN_N_XUONG"
            cbxNhaXuong.StoreName = "H_GET_NHA_XUONG_NAM_TGNM"
            cbxNhaXuong.Param = _nam
            cbxNhaXuong.BindDataSource()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbxNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxNam.SelectedIndexChanged
        Try
            _Nam = New DateTime(cbxNam.SelectedValue, 1, 1)
            LoadNhaxuong(_Nam)
            LoadLoaiMay(cbxNhaXuong.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbxNhaXuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles cbxNhaXuong.SelectedIndexChanged
        Try
            LoadLoaiMay(cbxNhaXuong.SelectedValue)
        Catch ex As Exception
        End Try

    End Sub

    Private ExcelApp As Excel.Application

    Private Sub XuatTieuDeThang(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer)
        With Exelsheet

            .Range("A" & vRowEx, "A" & (vRowEx + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).Font.Bold = True
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).Merge(True)
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).MergeCells = True
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A" & vRowEx, "A" & (vRowEx + 1)).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "LOAI_MAY", Commons.Modules.TypeLanguage)

            .Range("B" & vRowEx, "B" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("B" & vRowEx, "B" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("B" & vRowEx, "B" & vRowEx + 1).Font.Bold = True
            .Range("B" & vRowEx, "B" & vRowEx + 1).Merge(True)
            .Range("B" & vRowEx, "B" & vRowEx + 1).MergeCells = True
            .Range("B" & vRowEx, "B" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("B" & vRowEx, "B" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "THIET_BI", Commons.Modules.TypeLanguage)


            .Range("C" & vRowEx, "D" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("C" & vRowEx, "D" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("C" & vRowEx, "D" & vRowEx + 1).Font.Bold = True
            .Range("C" & vRowEx, "D" & vRowEx + 1).Merge(True)
            .Range("C" & vRowEx, "D" & vRowEx + 1).MergeCells = True
            .Range("C" & vRowEx, "D" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C" & vRowEx, "D" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "DIEN_GIAI", Commons.Modules.TypeLanguage)

            .Range("E" & vRowEx, "Q" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx, "Q" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("E" & vRowEx, "Q" & vRowEx).Font.Bold = True
            .Range("E" & vRowEx, "Q" & vRowEx).Merge(True)
            .Range("E" & vRowEx, "Q" & vRowEx).MergeCells = True
            .Range("E" & vRowEx, "Q" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx, "Q" & vRowEx).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MO_TA", Commons.Modules.TypeLanguage)

            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).Font.Bold = True
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JAN", Commons.Modules.TypeLanguage)

            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).Font.Bold = True
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "FEB", Commons.Modules.TypeLanguage)

            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).Font.Bold = True
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAR", Commons.Modules.TypeLanguage)

            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).Font.Bold = True
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "APR", Commons.Modules.TypeLanguage)

            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).Font.Bold = True
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAY", Commons.Modules.TypeLanguage)

            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).Font.Bold = True
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JUN", Commons.Modules.TypeLanguage)

            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).Font.Bold = True
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JUL", Commons.Modules.TypeLanguage)

            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).Font.Bold = True
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "AUG", Commons.Modules.TypeLanguage)

            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).Font.Bold = True
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SEP", Commons.Modules.TypeLanguage)

            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).Font.Bold = True
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "OCT", Commons.Modules.TypeLanguage)

            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).Font.Bold = True
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NOV", Commons.Modules.TypeLanguage)

            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).Font.Bold = True
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "DEC", Commons.Modules.TypeLanguage)

            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).Font.Bold = True
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "LUYKE", Commons.Modules.TypeLanguage)

        End With
    End Sub


#Region "Tinh tong"
    Sub TieuDeTong(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer)
        With Exelsheet

            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).Font.Bold = True
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx + 1, "E" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JAN", Commons.Modules.TypeLanguage)

            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).Font.Bold = True
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vRowEx + 1, "F" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "FEB", Commons.Modules.TypeLanguage)

            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).Font.Bold = True
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vRowEx + 1, "G" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAR", Commons.Modules.TypeLanguage)

            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).Font.Bold = True
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vRowEx + 1, "H" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "APR", Commons.Modules.TypeLanguage)

            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).Font.Bold = True
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I" & vRowEx + 1, "I" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAY", Commons.Modules.TypeLanguage)

            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).Font.Bold = True
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J" & vRowEx + 1, "J" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JUN", Commons.Modules.TypeLanguage)

            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).Font.Bold = True
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K" & vRowEx + 1, "K" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "JUL", Commons.Modules.TypeLanguage)

            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).Font.Bold = True
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L" & vRowEx + 1, "L" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "AUG", Commons.Modules.TypeLanguage)

            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).Font.Bold = True
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("M" & vRowEx + 1, "M" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SEP", Commons.Modules.TypeLanguage)

            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).Font.Bold = True
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N" & vRowEx + 1, "N" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "OCT", Commons.Modules.TypeLanguage)

            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).Font.Bold = True
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("O" & vRowEx + 1, "O" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NOV", Commons.Modules.TypeLanguage)

            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).Font.Bold = True
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("P" & vRowEx + 1, "P" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "DEC", Commons.Modules.TypeLanguage)

            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).Font.Bold = True
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("Q" & vRowEx + 1, "Q" & vRowEx + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "LUYKE", Commons.Modules.TypeLanguage)

        End With

    End Sub

    Sub TongGioMayTaoSanPhan(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vrFrom As Integer, ByVal vrTo As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            With Exelsheet
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "00.0%"
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= " & chChar & vrTo & "/" & chChar & vrFrom
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next
    End Sub

    Sub TongGioMayNgungChuQuan(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vrFrom As Integer, ByVal vrTo As Integer, ByVal vNN As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            With Exelsheet
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "00.0%"
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= SUM(" & chChar & (vrTo - 2 - vNN) & ":" & chChar & (vrTo - 3) & ")/" & chChar & vrFrom
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next
    End Sub

    Sub CreatChartColumnTong(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal stt As Integer, ByVal vWith As Integer, ByVal vChartName As String)

        Dim vLeft As Integer = 1000
        Dim vTop As Integer = 1000
        Dim vH As Integer = 250

        vH = (vWith + 4) * Exelsheet.Range("A7", "S7").Height
        vLeft = Exelsheet.Range("A7", "S7").Width + (vH * 2 * (stt - 1)) + ((stt - 1) * 30)
        vTop = (vRowEx - 1) * Exelsheet.Range("A7", "S7").Height

        Dim chartObjs As ChartObjects
        chartObjs = DirectCast(Exelsheet.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vH * 2, vH)
        Dim xlChart As Chart = chartObj.Chart

        Dim vstr As String = "(D$" & vRowEx & ":Q$" & vRowEx & ",D$" & (vRowEx + ((stt - 1) * 3) + 1) & ":Q$" & (vRowEx + ((stt - 1) * 3) + 3) & ")"

        Dim rgEqui As Excel.Range
        rgEqui = Exelsheet.Range("(D$" & vRowEx & ":Q$" & vRowEx & ",D$" & (vRowEx + ((stt - 1) * 3) + 1) & ":Q$" & (vRowEx + ((stt - 1) * 3) + 3) & ")")

        xlChart.SetSourceData(rgEqui, Type.Missing)
        xlChart.ChartType = XlChartType.xlColumnStacked100
        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = vChartName
        'xlChart.Legend.Delete()
        xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(255, 255, 255)
        xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom

        With xlChart
            Dim xlAxisCategory As Excel.Axes
            xlAxisCategory = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
            xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
            xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "THANG", Commons.Modules.TypeLanguage)
        End With
    End Sub


#End Region

#Region "Tinh tong Theo Loai may"
    Sub SoGioLamTrongThangTongLoaiMay(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vSoMay As Integer, ByVal vSoNN As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12

            Dim vDs As String = ""
            Dim rowList As Integer = 0
            Dim vList(30) As String
            Dim vk As Integer = 0
            For j As Integer = 1 To vSoMay
                If rowList < 30 Then
                    If vDs = "" Then
                        vDs = chChar & (vRowEx - ((vSoNN + 6) * j))
                    Else
                        vDs = vDs & "," & chChar & (vRowEx - ((vSoNN + 6) * j))
                    End If
                    rowList = rowList + 1
                Else
                    If vDs <> "" Then
                        vList(vk) = "SUM(" & vDs & ")"
                        vDs = ""
                        vk = vk + 1
                        rowList = 0
                    End If
                End If
                If vDs <> "" And j = vSoMay Then
                    vList(vk) = "SUM(" & vDs & ")"
                End If
            Next
            Dim vdsList As String = ""

            For k As Integer = 0 To vList.Length - 1
                If vList(k) <> "" Then
                    If vdsList = "" Then
                        If vList(k) <> "" Then
                            vdsList = vList(k)
                        End If
                    Else
                        If vList(k) <> "" Then
                            vdsList = vdsList & "," & vList(k)
                        End If
                    End If
                Else
                    Exit For
                End If
            Next


            With Exelsheet
                'Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                '.Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                '.Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= SUM(" & vdsList & ")"
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "##,#0"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next
        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=S" & vRowEx
        End With

    End Sub

    Sub SoGioNghiLeTongLoaiMay(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vSoMay As Integer, ByVal vSoNN As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            Dim vDs As String = ""
            Dim rowList As Integer = 0
            Dim vList(30) As String
            Dim vk As Integer = 0
            For j As Integer = 1 To vSoMay
                If rowList < 30 Then
                    If vDs = "" Then
                        vDs = chChar & (vRowEx - ((vSoNN + 6) * j))
                    Else
                        vDs = vDs & "," & chChar & (vRowEx - ((vSoNN + 6) * j))
                    End If
                    rowList = rowList + 1
                Else
                    If vDs <> "" Then
                        vList(vk) = "SUM(" & vDs & ")"
                        vDs = ""
                        vk = vk + 1
                        rowList = 0
                    End If
                End If
                If vDs <> "" And j = vSoMay Then
                    vList(vk) = "SUM(" & vDs & ")"
                End If
            Next
            Dim vdsList As String = ""

            For k As Integer = 0 To vList.Length - 1
                If vList(k) <> "" Then
                    If vdsList = "" Then
                        If vList(k) <> "" Then
                            vdsList = vList(k)
                        End If
                    Else
                        If vList(k) <> "" Then
                            vdsList = vdsList & "," & vList(k)
                        End If
                    End If
                Else
                    Exit For
                End If
            Next


            With Exelsheet
                'Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= SUM(" & vdsList & ")"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=S" & vRowEx
        End With

    End Sub

    Sub SoGioHoatDongTongLoaiMay(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vSoMay As Integer, ByVal vSoNN As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            Dim vDs As String = ""
            Dim rowList As Integer = 0
            Dim vList(30) As String
            Dim vk As Integer = 0
            For j As Integer = 1 To vSoMay
                If rowList < 30 Then
                    If vDs = "" Then
                        vDs = chChar & (vRowEx - ((vSoNN + 6) * j))
                    Else
                        vDs = vDs & "," & chChar & (vRowEx - ((vSoNN + 6) * j))
                    End If
                    rowList = rowList + 1
                Else
                    If vDs <> "" Then
                        vList(vk) = "SUM(" & vDs & ")"
                        vDs = ""
                        vk = vk + 1
                        rowList = 0
                    End If
                End If
                If vDs <> "" And j = vSoMay Then
                    vList(vk) = "SUM(" & vDs & ")"
                End If
            Next
            Dim vdsList As String = ""

            For k As Integer = 0 To vList.Length - 1
                If vList(k) <> "" Then
                    If vdsList = "" Then
                        If vList(k) <> "" Then
                            vdsList = vList(k)
                        End If
                    Else
                        If vList(k) <> "" Then
                            vdsList = vdsList & "," & vList(k)
                        End If
                    End If
                Else
                    Exit For
                End If
            Next

            With Exelsheet
                'Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                '.Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                '.Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= SUM(" & vdsList & ")"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=SUM(S" & vRowEx + 1 & ":S" & vRowEx + vSoNN & ")"
            .Range("W" & vRowEx, "W" & vRowEx).NumberFormat = "##,#0"

        End With

    End Sub

    Sub SoGioNNLoaiMay(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vSoMay As Integer, ByVal vSoNN As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12

            Dim vDs As String = ""
            Dim rowList As Integer = 0
            Dim vList(30) As String
            Dim vk As Integer = 0
            For j As Integer = 1 To vSoMay
                If rowList < 30 Then
                    If vDs = "" Then
                        vDs = chChar & (vRowEx - ((vSoNN + 6) * j))
                    Else
                        vDs = vDs & "," & chChar & (vRowEx - ((vSoNN + 6) * j))
                    End If
                    rowList = rowList + 1
                Else
                    If vDs <> "" Then
                        vList(vk) = "SUM(" & vDs & ")"
                        vDs = ""
                        vk = vk + 1
                        rowList = 0
                    End If
                End If
                If vDs <> "" And j = vSoMay Then
                    vList(vk) = "SUM(" & vDs & ")"
                End If
            Next
            Dim vdsList As String = ""

            For k As Integer = 0 To vList.Length - 1
                If vList(k) <> "" Then
                    If vdsList = "" Then
                        If vList(k) <> "" Then
                            vdsList = vList(k)
                        End If
                    Else
                        If vList(k) <> "" Then
                            vdsList = vdsList & "," & vList(k)
                        End If
                    End If
                Else
                    Exit For
                End If
            Next

            With Exelsheet
                'Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                '.Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                '.Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= SUM(" & vdsList & ")"
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "##,#0"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=S" & vRowEx
        End With

    End Sub
    'End Tinh Tong theo loai may
#End Region

    Sub CreaColumSeach(ByVal Exelsheet As Excel.Worksheet)
        Dim rgEqui As Excel.Range
        rgEqui = Exelsheet.Range("S8", "S8")
        With rgEqui.Validation
            .Add(Type:=XlDVType.xlValidateList, AlertStyle:=XlDVAlertStyle.xlValidAlertStop, Operator:=XlFormatConditionOperator.xlBetween, Formula1:="=" & "E8:Q8")
            .IgnoreBlank = False
            .InCellDropdown = True
            .ShowInput = True
            .ShowError = True
        End With
    End Sub

    Sub CreatChartPie(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vWith As Integer, ByVal vChartName As String)

        Dim vLeft As Integer = 1000
        Dim vTop As Integer = 1000
        Dim vH As Integer = 250

        vLeft = Exelsheet.Range("A7", "X7").Width
        vTop = (vRowEx - vWith - 6) * Exelsheet.Range("A7", "X7").Height

        vH = (vWith + 4) * Exelsheet.Range("A7", "X7").Height

        Dim chartObjs As ChartObjects = DirectCast(Exelsheet.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vH, vH)
        Dim xlChart As Chart = chartObj.Chart
        'Dim sr As Series = CType(xlChart.SeriesCollection(0), Series)
        'sr.FormulaR1C1 = "=Sheet1!$W$9:$W$11"

        Dim rgEqui As Excel.Range
        rgEqui = Exelsheet.Range("V" & vRowEx - vWith - 5, "W" & vRowEx - vWith - 3)

        xlChart.SetSourceData(rgEqui, Type.Missing)
        xlChart.ChartType = XlChartType.xlPie
        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = vChartName
        xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
        xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(255, 255, 255)
        xlChart.Legend.Border.Color = RGB(255, 255, 255)
    End Sub

    Sub CreatChartPie3D(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vWith As Integer, ByVal vChartName As String)

        Dim vLeft As Integer = 1000
        Dim vTop As Integer = 1000
        Dim vH As Integer = 250

        vH = (vWith + 4) * Exelsheet.Range("A7", "X7").Height
        vLeft = Exelsheet.Range("A7", "X7").Width + vH + 30
        vTop = (vRowEx - vWith - 6) * Exelsheet.Range("A7", "X7").Height

        Dim chartObjs As ChartObjects = DirectCast(Exelsheet.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vH * 2, vH)
        Dim xlChart As Chart = chartObj.Chart

        Dim rgEqui As Excel.Range
        rgEqui = Exelsheet.Range("V" & vRowEx - 3, "W" & vRowEx - vWith - 2)

        xlChart.SetSourceData(rgEqui, Type.Missing)
        xlChart.ChartType = XlChartType.xl3DPieExploded
        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = vChartName
        xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
        xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(255, 255, 255)
        xlChart.Legend.Border.Color = RGB(255, 255, 255)
    End Sub

    Sub CreatChartColumn(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vWith As Integer, ByVal vChartName As String)

        Dim vLeft As Integer = 1000
        Dim vTop As Integer = 1000
        Dim vH As Integer = 250

        vH = (vWith + 4) * Exelsheet.Range("A7", "X7").Height
        vLeft = Exelsheet.Range("A7", "X7").Width + (vH * 3) + 60
        vTop = (vRowEx - vWith - 6) * Exelsheet.Range("A7", "X7").Height

        Dim chartObjs As ChartObjects
        chartObjs = DirectCast(Exelsheet.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vH * 2, vH)
        Dim xlChart As Chart = chartObj.Chart

        Dim rgEqui As Excel.Range
        rgEqui = Exelsheet.Range("(E$8:Q$8" & ",E$" & (vRowEx - 1) & ":Q$" & (vRowEx - 1) & ")")

        xlChart.SetSourceData(rgEqui, Type.Missing)
        xlChart.ChartType = XlChartType.xlColumnStacked
        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = vChartName
        xlChart.Legend.Delete()
        xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(255, 255, 255)

        With xlChart
            Dim xlAxisCategory As Excel.Axes
            xlAxisCategory = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
            xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
            xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "THANG", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub FunctionSubCell(ByVal Exelsheet As Excel.Worksheet, ByVal vColor As Color, ByVal vRowEx As Integer, ByVal vRowExJum As Integer, ByVal vBold As Boolean)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            With Exelsheet
                Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "##,#0"
                .Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next
        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("V" & vRowEx, "V" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("v" & vRowEx, "V" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("v" & vRowEx, "V" & vRowEx).Font.Bold = vBold
            .Range("v" & vRowEx, "V" & vRowEx).Merge(True)
            .Range("v" & vRowEx, "V" & vRowEx).MergeCells = True
            .Range("v" & vRowEx, "V" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("v" & vRowEx, "V" & vRowEx).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGU_MAY_DO_YEU_TO_CHU_QUAN", Commons.Modules.TypeLanguage)

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=SUM(S" & vRowEx + 1 & ":S" & vRowEx + vRowExJum & ")"
            .Range("W" & vRowEx, "W" & vRowEx).NumberFormat = "##,#0"

        End With


    End Sub

    Sub FunctionmMulCell(ByVal Exelsheet As Excel.Worksheet, ByVal vColor As Color, ByVal vRowEx As Integer, ByVal vRowJum As Integer, ByVal vBold As Boolean)

        Dim chChar As Char = "E"

        For i As Integer = 0 To 12
            With Exelsheet
                Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                .Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= " & chChar & vRowJum & " - Sum(" & chChar & vRowJum + 1 & " : " & chChar & vRowEx - 1 & " )"
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "##,#0"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"
        End With
    End Sub

    Sub FunctionmPerCell(ByVal Exelsheet As Excel.Worksheet, ByVal vColor As Color, ByVal vRowEx As Integer, ByVal vRowJum As Integer, ByVal vBold As Boolean)

        Dim chChar As Char = "E"


        For i As Integer = 0 To 12
            With Exelsheet
                Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "00.0%"
                .Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                Dim sssgggg As String = "= IF ( SUM(" & chChar & vRowJum - 3 & "), Sum(" & chChar & vRowEx - 1 & " / " & chChar & vRowJum - 3 & " )," & Chr(34) & Chr(34) & ")"
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= IF( SUM(" & chChar & vRowJum - 3 & "), Sum(" & chChar & vRowEx - 1 & " / " & chChar & vRowJum - 3 & " )," & Chr(34) & Chr(34) & ")"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "00.0%"
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
        End With

    End Sub

    Sub FunctionmPerCell2(ByVal Exelsheet As Excel.Worksheet, ByVal vColor As Color, ByVal vRowEx As Integer, ByVal vRowJum As Integer, ByVal vBold As Boolean)

        Dim chChar As Char = "E"


        For i As Integer = 0 To 12
            With Exelsheet
                Dim sss As String = "= " & chChar & vRowEx - 2 & " - " & chChar & vRowEx - 1
                .Range(chChar & vRowEx, chChar & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(chChar & vRowEx, chChar & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range(chChar & vRowEx, chChar & vRowEx).Font.Bold = vBold
                .Range(chChar & vRowEx, chChar & vRowEx).NumberFormat = "00.0%"
                .Range(chChar & vRowEx, chChar & vRowEx).Interior.Color = RGB(Integer.Parse(vColor.R.ToString), Integer.Parse(vColor.G.ToString), Integer.Parse(vColor.B.ToString))
                .Range(chChar & vRowEx, chChar & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                Dim sssgggg As String = "= IF ( SUM(" & chChar & vRowJum - 3 & "), Sum(" & chChar & vRowEx - 1 & " / " & chChar & vRowJum - 3 & " )," & Chr(34) & Chr(34) & ")"
                .Range(chChar & vRowEx, chChar & vRowEx).Value = "= IF( SUM(" & chChar & vRowJum - 2 & "), Sum(" & chChar & vRowEx - 2 & " / " & chChar & vRowJum - 2 & " )," & Chr(34) & Chr(34) & ")"
            End With
            chChar = Chr(Asc(chChar) + 1)
        Next

        With Exelsheet
            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "00.0%"
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
        End With
    End Sub

    Sub TieuDeRow(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vColum1 As String, ByVal vColum2 As String, ByVal vNoiDung As String, ByVal vBold As Boolean)
        With Exelsheet
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Font.Bold = vBold
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Merge(True)
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).MergeCells = True
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Value = vNoiDung
        End With
    End Sub

    Sub TieuDeRowRight(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vColum1 As String, ByVal vColum2 As String, ByVal vNoiDung As String, ByVal vBold As Boolean)
        With Exelsheet
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Font.Bold = vBold
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Merge(True)
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).MergeCells = True
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range(vColum1 & vRowEx, vColum2 & vRowEx).Value = vNoiDung
        End With
    End Sub

    Sub TieuDeChuDoc(ByVal Exelsheet As Excel.Worksheet, ByVal vFromRow As Integer, ByVal vToRow As Integer, ByVal vColum1 As String, ByVal vColum2 As String, ByVal vNoiDung As String, ByVal vBold As Boolean)
        With Exelsheet
            .Range(vColum1 & vFromRow, vColum2 & vToRow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range(vColum1 & vFromRow, vColum2 & vToRow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Font.Bold = vBold
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Merge(True)
            .Range(vColum1 & vFromRow, vColum2 & vToRow).MergeCells = True
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Orientation = XlOrientation.xlUpward
            .Range(vColum1 & vFromRow, vColum2 & vToRow).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Value = vNoiDung
        End With
    End Sub

    Sub TieuDeChuWap(ByVal Exelsheet As Excel.Worksheet, ByVal vFromRow As Integer, ByVal vToRow As Integer, ByVal vColum1 As String, ByVal vColum2 As String, ByVal vNoiDung As String, ByVal vBold As Boolean)
        With Exelsheet
            .Range(vColum1 & vFromRow, vColum2 & vToRow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range(vColum1 & vFromRow, vColum2 & vToRow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Font.Bold = vBold
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Merge(True)
            .Range(vColum1 & vFromRow, vColum2 & vToRow).MergeCells = True
            .Range(vColum1 & vFromRow, vColum2 & vToRow).WrapText = True
            .Range(vColum1 & vFromRow, vColum2 & vToRow).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range(vColum1 & vFromRow, vColum2 & vToRow).Value = vNoiDung
        End With
    End Sub

    Sub CellExcelNam(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer, ByVal vJAN As Double, ByVal vFEB As Double, ByVal vMAR As Double, ByVal vAPR As Double, ByVal vMAY As Double, ByVal vJUN As Double, ByVal vJUL As Double, ByVal vAUG As Double, ByVal vSEP As Double, ByVal vOCT As Double, ByVal vNOV As Double, ByVal vDECE As Double, ByVal vLUYKE As Double)
        With Exelsheet
            .Range("E" & vRowEx, "E" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx, "E" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("E" & vRowEx, "E" & vRowEx).NumberFormat = "##,#0"
            .Range("E" & vRowEx, "E" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx, "E" & vRowEx).Value = vJAN

            .Range("F" & vRowEx, "F" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & vRowEx, "F" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("F" & vRowEx, "F" & vRowEx).NumberFormat = "##,#0"
            .Range("F" & vRowEx, "F" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vRowEx, "F" & vRowEx).Value = vFEB

            .Range("G" & vRowEx, "G" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & vRowEx, "G" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & vRowEx, "G" & vRowEx).NumberFormat = "##,#0"
            .Range("G" & vRowEx, "G" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vRowEx, "G" & vRowEx).Value = vMAR

            .Range("H" & vRowEx, "H" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H" & vRowEx, "H" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("H" & vRowEx, "H" & vRowEx).NumberFormat = "##,#0"
            .Range("H" & vRowEx, "H" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vRowEx, "H" & vRowEx).Value = vAPR

            .Range("I" & vRowEx, "I" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("I" & vRowEx, "I" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("I" & vRowEx, "I" & vRowEx).NumberFormat = "##,#0"
            .Range("I" & vRowEx, "I" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I" & vRowEx, "I" & vRowEx).Value = vMAY

            .Range("J" & vRowEx, "J" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("J" & vRowEx, "J" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("J" & vRowEx, "J" & vRowEx).NumberFormat = "##,#0"
            .Range("J" & vRowEx, "J" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J" & vRowEx, "J" & vRowEx).Value = vJUN

            .Range("K" & vRowEx, "K" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("K" & vRowEx, "K" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("K" & vRowEx, "K" & vRowEx).NumberFormat = "##,#0"
            .Range("K" & vRowEx, "K" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K" & vRowEx, "K" & vRowEx).Value = vJUL

            .Range("L" & vRowEx, "L" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("L" & vRowEx, "L" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("L" & vRowEx, "L" & vRowEx).NumberFormat = "##,#0"
            .Range("L" & vRowEx, "L" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L" & vRowEx, "L" & vRowEx).Value = vAUG

            .Range("M" & vRowEx, "M" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("M" & vRowEx, "M" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("M" & vRowEx, "M" & vRowEx).NumberFormat = "##,#0"
            .Range("M" & vRowEx, "M" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("M" & vRowEx, "M" & vRowEx).Value = vSEP

            .Range("N" & vRowEx, "N" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("N" & vRowEx, "N" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("N" & vRowEx, "N" & vRowEx).NumberFormat = "##,#0"
            .Range("N" & vRowEx, "N" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N" & vRowEx, "N" & vRowEx).Value = vOCT

            .Range("O" & vRowEx, "O" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("O" & vRowEx, "O" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("O" & vRowEx, "O" & vRowEx).NumberFormat = "##,#0"
            .Range("O" & vRowEx, "O" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("O" & vRowEx, "O" & vRowEx).Value = vNOV

            .Range("P" & vRowEx, "P" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("P" & vRowEx, "P" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("P" & vRowEx, "P" & vRowEx).NumberFormat = "##,#0"
            .Range("P" & vRowEx, "P" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("P" & vRowEx, "P" & vRowEx).Value = vDECE

            .Range("Q" & vRowEx, "Q" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("Q" & vRowEx, "Q" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("Q" & vRowEx, "Q" & vRowEx).NumberFormat = "##,#0"
            .Range("Q" & vRowEx, "Q" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("Q" & vRowEx, "Q" & vRowEx).Value = "= SUM(E" & vRowEx & ":P" & vRowEx & ")"

            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=S" & vRowEx
            .Range("W" & vRowEx, "W" & vRowEx).NumberFormat = "##,#0"

        End With

    End Sub

    Sub SoGioLamTrongThang(ByVal Exelsheet As Excel.Worksheet, ByVal vRowEx As Integer)
        Dim vDate As DateTime
        vDate = New DateTime(cbxNam.SelectedValue, 1, 1)
        With Exelsheet
            .Range("E" & vRowEx, "E" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx, "E" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("E" & vRowEx, "E" & vRowEx).NumberFormat = "##,#0"
            .Range("E" & vRowEx, "E" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx, "E" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 1)) * 24 * 60

            .Range("F" & vRowEx, "F" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & vRowEx, "F" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("F" & vRowEx, "F" & vRowEx).NumberFormat = "##,#0"
            .Range("F" & vRowEx, "F" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vRowEx, "F" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 2)) * 24 * 60

            .Range("G" & vRowEx, "G" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & vRowEx, "G" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & vRowEx, "G" & vRowEx).NumberFormat = "##,#0"
            .Range("G" & vRowEx, "G" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vRowEx, "G" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 3)) * 24 * 60

            .Range("H" & vRowEx, "H" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H" & vRowEx, "H" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("H" & vRowEx, "H" & vRowEx).NumberFormat = "##,#0"
            .Range("H" & vRowEx, "H" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vRowEx, "H" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 4)) * 24 * 60

            .Range("I" & vRowEx, "I" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("I" & vRowEx, "I" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("I" & vRowEx, "I" & vRowEx).NumberFormat = "##,#0"
            .Range("I" & vRowEx, "I" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I" & vRowEx, "I" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 5)) * 24 * 60

            .Range("J" & vRowEx, "J" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("J" & vRowEx, "J" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("J" & vRowEx, "J" & vRowEx).NumberFormat = "##,#0"
            .Range("J" & vRowEx, "J" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J" & vRowEx, "J" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 6)) * 24 * 60

            .Range("K" & vRowEx, "K" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("K" & vRowEx, "K" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("K" & vRowEx, "K" & vRowEx).NumberFormat = "##,#0"
            .Range("K" & vRowEx, "K" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K" & vRowEx, "K" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 7)) * 24 * 60

            .Range("L" & vRowEx, "L" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("L" & vRowEx, "L" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("L" & vRowEx, "L" & vRowEx).NumberFormat = "##,#0"
            .Range("L" & vRowEx, "L" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L" & vRowEx, "L" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 8)) * 24 * 60

            .Range("M" & vRowEx, "M" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("M" & vRowEx, "M" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            ' .Range("M" & vRowEx, "M" & vRowEx).NumberFormat = "##,#0"
            .Range("M" & vRowEx, "M" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("M" & vRowEx, "M" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 9)) * 24 * 60

            .Range("N" & vRowEx, "N" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("N" & vRowEx, "N" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("N" & vRowEx, "N" & vRowEx).NumberFormat = "##,#0"
            .Range("N" & vRowEx, "N" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N" & vRowEx, "N" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 10)) * 24 * 60

            .Range("O" & vRowEx, "O" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("O" & vRowEx, "O" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("O" & vRowEx, "O" & vRowEx).NumberFormat = "##,#0"
            .Range("O" & vRowEx, "O" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("O" & vRowEx, "O" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 11)) * 24 * 60

            .Range("P" & vRowEx, "P" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("P" & vRowEx, "P" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("P" & vRowEx, "P" & vRowEx).NumberFormat = "##,#0"
            .Range("P" & vRowEx, "P" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("P" & vRowEx, "P" & vRowEx).Value = (DateTime.DaysInMonth(vDate.Year, 12)) * 24 * 60

            .Range("Q" & vRowEx, "Q" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("Q" & vRowEx, "Q" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("Q" & vRowEx, "Q" & vRowEx).NumberFormat = "##,#0"
            .Range("Q" & vRowEx, "Q" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("Q" & vRowEx, "Q" & vRowEx).Value = "= SUM(E" & vRowEx & ":P" & vRowEx & ")"


            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"
            .Range("S" & vRowEx, "S" & vRowEx).NumberFormat = "##,#0"

            .Range("W" & vRowEx, "W" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("W" & vRowEx, "W" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("W" & vRowEx, "W" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("W" & vRowEx, "W" & vRowEx).Value = "=S" & vRowEx
            .Range("W" & vRowEx, "W" & vRowEx).NumberFormat = "##,#0"

        End With


    End Sub

    Sub CellExcelNamBackColor(ByVal Exelsheet As Excel.Worksheet, ByVal clColor As Color, ByVal vRowEx As Integer, ByVal vJAN As Double, ByVal vFEB As Double, ByVal vMAR As Double, ByVal vAPR As Double, ByVal vMAY As Double, ByVal vJUN As Double, ByVal vJUL As Double, ByVal vAUG As Double, ByVal vSEP As Double, ByVal vOCT As Double, ByVal vNOV As Double, ByVal vDECE As Double, ByVal vLUYKE As Double)
        With Exelsheet
            .Range("E" & vRowEx, "E" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & vRowEx, "E" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("E" & vRowEx, "E" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("E" & vRowEx, "E" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & vRowEx, "E" & vRowEx).Value = vJAN

            .Range("F" & vRowEx, "F" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & vRowEx, "F" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("F" & vRowEx, "F" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("F" & vRowEx, "F" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vRowEx, "F" & vRowEx).Value = vFEB

            .Range("G" & vRowEx, "G" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & vRowEx, "G" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & vRowEx, "G" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("G" & vRowEx, "G" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vRowEx, "G" & vRowEx).Value = vMAR

            .Range("H" & vRowEx, "H" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H" & vRowEx, "H" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("H" & vRowEx, "H" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("H" & vRowEx, "H" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vRowEx, "H" & vRowEx).Value = vAPR

            .Range("I" & vRowEx, "I" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("I" & vRowEx, "I" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("I" & vRowEx, "I" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("I" & vRowEx, "I" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I" & vRowEx, "I" & vRowEx).Value = vMAY

            .Range("J" & vRowEx, "J" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("J" & vRowEx, "J" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("J" & vRowEx, "J" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("J" & vRowEx, "J" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J" & vRowEx, "J" & vRowEx).Value = vJUN

            .Range("K" & vRowEx, "K" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("K" & vRowEx, "K" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("K" & vRowEx, "K" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("K" & vRowEx, "K" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K" & vRowEx, "K" & vRowEx).Value = vJUL

            .Range("L" & vRowEx, "L" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("L" & vRowEx, "L" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("L" & vRowEx, "L" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("L" & vRowEx, "L" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L" & vRowEx, "L" & vRowEx).Value = vAUG

            .Range("M" & vRowEx, "M" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("M" & vRowEx, "M" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("M" & vRowEx, "M" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("M" & vRowEx, "M" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("M" & vRowEx, "M" & vRowEx).Value = vSEP

            .Range("N" & vRowEx, "N" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("N" & vRowEx, "N" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("N" & vRowEx, "N" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("N" & vRowEx, "N" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N" & vRowEx, "N" & vRowEx).Value = vOCT

            .Range("O" & vRowEx, "O" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("O" & vRowEx, "O" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("O" & vRowEx, "O" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("O" & vRowEx, "O" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("O" & vRowEx, "O" & vRowEx).Value = vNOV

            .Range("P" & vRowEx, "P" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("P" & vRowEx, "P" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("P" & vRowEx, "P" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("P" & vRowEx, "P" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("P" & vRowEx, "P" & vRowEx).Value = vDECE

            .Range("Q" & vRowEx, "Q" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("Q" & vRowEx, "Q" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("Q" & vRowEx, "Q" & vRowEx).Interior.Color = RGB(Integer.Parse(clColor.R.ToString), Integer.Parse(clColor.G.ToString), Integer.Parse(clColor.B.ToString))
            .Range("Q" & vRowEx, "Q" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("Q" & vRowEx, "Q" & vRowEx).Value = "= SUM(E" & vRowEx & ":P" & vRowEx & ")"


            .Range("S" & vRowEx, "S" & vRowEx).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("S" & vRowEx, "S" & vRowEx).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("S" & vRowEx, "S" & vRowEx).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("S" & vRowEx, "S" & vRowEx).Value = "=SUMIF(E$8:Q$8,S$8,E" & vRowEx & ":R" & vRowEx & ")"



        End With

    End Sub

    Function SumDataView(ByVal vDtv As DataView) As System.Data.DataTable

        Dim vDt As New System.Data.DataTable()
        vDt.Columns.Add("JAN", Type.GetType("System.Double"))
        vDt.Columns.Add("FEB", Type.GetType("System.Double"))
        vDt.Columns.Add("MAR", Type.GetType("System.Double"))
        vDt.Columns.Add("APR", Type.GetType("System.Double"))
        vDt.Columns.Add("MAY", Type.GetType("System.Double"))
        vDt.Columns.Add("JUN", Type.GetType("System.Double"))
        vDt.Columns.Add("JUL", Type.GetType("System.Double"))
        vDt.Columns.Add("AUG", Type.GetType("System.Double"))
        vDt.Columns.Add("SEP", Type.GetType("System.Double"))
        vDt.Columns.Add("OCT", Type.GetType("System.Double"))
        vDt.Columns.Add("NOV", Type.GetType("System.Double"))
        vDt.Columns.Add("DECE", Type.GetType("System.Double"))
        vDt.Columns.Add("LUYKE", Type.GetType("System.Double"))

        Dim vJAN As Double = 0
        Dim vFEB As Double = 0
        Dim vMAR As Double = 0
        Dim vAPR As Double = 0
        Dim vMAY As Double = 0
        Dim vJUN As Double = 0
        Dim vJUL As Double = 0
        Dim vAUG As Double = 0
        Dim vSEP As Double = 0
        Dim vOCT As Double = 0
        Dim vNOV As Double = 0
        Dim vDECE As Double = 0
        Dim vLUYKE As Double = 0

        Dim i As Integer
        For i = 0 To vDtv.Count - 1
            vJAN = vJAN + Double.Parse(vDtv.Item(i)("JAN").ToString)
            vFEB = vFEB + Double.Parse(vDtv.Item(i)("FEB").ToString)
            vMAR = vMAR + Double.Parse(vDtv.Item(i)("MAR").ToString)
            vAPR = vAPR + Double.Parse(vDtv.Item(i)("APR").ToString)
            vMAY = vMAY + Double.Parse(vDtv.Item(i)("MAY").ToString)
            vJUN = vJUN + Double.Parse(vDtv.Item(i)("JUN").ToString)
            vJUL = vJUL + Double.Parse(vDtv.Item(i)("JUL").ToString)
            vAUG = vAUG + Double.Parse(vDtv.Item(i)("AUG").ToString)
            vSEP = vSEP + Double.Parse(vDtv.Item(i)("SEP").ToString)
            vOCT = vOCT + Double.Parse(vDtv.Item(i)("OCT").ToString)
            vNOV = vNOV + Double.Parse(vDtv.Item(i)("NOV").ToString)
            vDECE = vDECE + Double.Parse(vDtv.Item(i)("DECE").ToString)
            vLUYKE = vLUYKE + Double.Parse(vDtv.Item(i)("LUYKE").ToString)
        Next
        Dim vrow = vDt.NewRow()

        vrow("JAN") = vJAN
        vrow("FEB") = vFEB
        vrow("MAR") = vMAR
        vrow("APR") = vAPR
        vrow("MAY") = vMAY
        vrow("JUN") = vJUN
        vrow("JUL") = vJUL
        vrow("AUG") = vAUG
        vrow("SEP") = vSEP
        vrow("OCT") = vOCT
        vrow("NOV") = vNOV
        vrow("DECE") = vDECE
        vrow("LUYKE") = vLUYKE
        vDt.Rows.Add(vJAN, vFEB, vMAR, vAPR, vMAY, vJUN, vJUL, vAUG, vSEP, vOCT, vNOV, vDECE, vLUYKE)
        '  vDt.Rows.Add(vrow)

        Return vDt
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Shared Function SelectDistinct(ByVal SourceTable As System.Data.DataTable, ByVal ParamArray FieldNames() As String) As System.Data.DataTable
        Dim lastValues() As Object
        Dim newTable As System.Data.DataTable

        If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
            Throw New ArgumentNullException("FieldNames")
        End If

        lastValues = New Object(FieldNames.Length - 1) {}
        newTable = New System.Data.DataTable

        For Each field As String In FieldNames
            newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
        Next

        For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
            If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                setLastValues(lastValues, Row, FieldNames)
            End If
        Next

        Return newTable
    End Function

    Private Shared Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
        Dim areEqual As Boolean = True

        For i As Integer = 0 To fieldNames.Length - 1
            If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                areEqual = False
                Exit For
            End If
        Next

        Return areEqual
    End Function

    Private Shared Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
        For Each field As String In fieldNames
            newRow(field) = sourceRow(field)
        Next

        Return newRow
    End Function

    Private Shared Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
        For i As Integer = 0 To fieldNames.Length - 1
            lastValues(i) = sourceRow(fieldNames(i))
        Next
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try

            'H_GET_DATA_HIEU_SUAT_SU_DUNG_MAY
            Dim vtbData As New System.Data.DataTable()
            _Nam = New DateTime(cbxNam.SelectedValue, 1, 1)
            Dim vLoaiMay As String = cbxLoaiMay.SelectedValue.ToString
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_HIEU_SUAT_SU_DUNG_MAY", _Nam, cbxNhaXuong.SelectedValue, vLoaiMay))

            If vtbData.Rows.Count = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KoDuLieuDeIn", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            ExcelApp = New Excel.Application
            ExcelApp.Visible = False
            'Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            ExcelSheets.Range("A1", "IV" + ExcelSheets.Rows.Count.ToString).Font.Size = 8




 
            With ExcelSheets
                .Columns(1).ColumnWidth = 8
                .Columns(2).ColumnWidth = 8
                .Columns(3).ColumnWidth = 6
                .Columns(4).ColumnWidth = 20
                .Columns(5).ColumnWidth = 6
                .Columns(6).ColumnWidth = 6
                .Columns(7).ColumnWidth = 6
                .Columns(8).ColumnWidth = 6
                .Columns(9).ColumnWidth = 6
                .Columns(10).ColumnWidth = 6
                .Columns(11).ColumnWidth = 6
                .Columns(12).ColumnWidth = 6
                .Columns(13).ColumnWidth = 6
                .Columns(14).ColumnWidth = 6
                .Columns(15).ColumnWidth = 6
                .Columns(16).ColumnWidth = 6
                .Columns(17).ColumnWidth = 8
                .Columns(18).ColumnWidth = 5
                .Columns(19).ColumnWidth = 5
                .Columns(20).ColumnWidth = 5
                .Columns(21).ColumnWidth = 10
                .Columns(22).ColumnWidth = 20
                .Columns(23).ColumnWidth = 5
                .Columns(24).ColumnWidth = 5
                .Columns(25).ColumnWidth = 5

            End With




            'Xuat Tieu De 
            Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "TIEU_DE", Commons.Modules.TypeLanguage) & " " & cbxNam.Text
            Dim rgTieuDe As Excel.Range
            rgTieuDe = ExcelSheets.Range("D3", "M4")
            rgTieuDe.Merge(True)
            rgTieuDe.MergeCells() = True
            rgTieuDe.Font.Bold = True
            rgTieuDe.Font.Size = 16
            rgTieuDe.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            rgTieuDe.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            rgTieuDe.Value = TieuDe

            ' Bien xac dinh dong cot
            Dim vRowEx As Integer = 7
            Dim vColEx As Integer = 5
            Dim vRowMin As Integer = 12
            Dim vVitriBD As Integer = 500

            XuatTieuDeThang(ExcelSheets, vRowEx)
            Dim vSoNguyenNhan As Integer = 0
            'lOAI MAY
            'Dim vDvLoaiMay As DataView = New DataView(vtbData, "", "", DataViewRowState.CurrentRows)
            CreaColumSeach(ExcelSheets)
            vRowEx = vRowEx + 1

            Dim vtbLoaiMay As New System.Data.DataTable
            vtbLoaiMay = SelectDistinct(vtbData, "MS_LOAI_MAY", "TEN_LOAI_MAY")

            prbIN.Position = 0
            prbIN.Properties.Step = 1
            prbIN.Properties.PercentView = True
            prbIN.Properties.Maximum = 3 + (vtbLoaiMay.Rows.Count * 13)
            prbIN.Properties.Minimum = 0


            For Each vRow As DataRow In vtbLoaiMay.Rows

                Dim vDtMay As System.Data.DataTable = SelectDistinct(New DataView(vtbData, "MS_LOAI_MAY = '" & vRow("MS_LOAI_MAY") & "'", "MS_MAY", DataViewRowState.CurrentRows).ToTable, "MS_MAY", "TEN_MAY")
                prbIN.PerformStep()
                prbIN.Update()
                'May trong loai may  
                Dim vRowLoaiMay As Integer = vRowEx
                For Each vRowMay As DataRow In vDtMay.Rows
                    Dim vMayNN As System.Data.DataTable = SumDataView(New DataView(vtbData, "( MS_LOAI_MAY = '" & vRow("MS_LOAI_MAY") & "' AND MS_MAY = '" & vRowMay("MS_MAY") & "' AND BTDK = 1)", "MS_NGUYEN_NHAN", DataViewRowState.CurrentRows))
                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_LY_THUYET", Commons.Modules.TypeLanguage), True)
                    SoGioLamTrongThang(ExcelSheets, vRowEx)
                    TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAY_TAO_RA_SAN_PHAM", Commons.Modules.TypeLanguage), False)

                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_NGHI_LE", Commons.Modules.TypeLanguage), True)

                    Dim clNN As Color = System.Drawing.Color.FromArgb(CInt(CByte((192))), CInt(CByte((255))), CInt(CByte((255))))
                    Dim vMay As System.Data.DataTable = New DataView(vtbData, "MS_LOAI_MAY = '" & vRow("MS_LOAI_MAY") & "' AND MS_MAY = '" & vRowMay("MS_MAY") & "' AND BTDK = 0 ", "MS_NGUYEN_NHAN", DataViewRowState.CurrentRows).ToTable()
                    CellExcelNam(ExcelSheets, vRowEx, vMayNN.Rows(0)("JAN"), vMayNN.Rows(0)("FEB"), vMayNN.Rows(0)("MAR"), vMayNN.Rows(0)("APR"), vMayNN.Rows(0)("MAY"), vMayNN.Rows(0)("JUN"), vMayNN.Rows(0)("JUL"), vMayNN.Rows(0)("AUG"), vMayNN.Rows(0)("SEP"), vMayNN.Rows(0)("OCT"), vMayNN.Rows(0)("NOV"), vMayNN.Rows(0)("DECE"), vMayNN.Rows(0)("LUYKE"))
                    TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGHI_LE_KO_DON_HANG", Commons.Modules.TypeLanguage), False)

                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_KE_HOACH", Commons.Modules.TypeLanguage), True)
                    FunctionSubCell(ExcelSheets, clNN, vRowEx, vMay.Rows.Count, False)

                    For Each vrMay As DataRow In vMay.Rows
                        vRowEx = vRowEx + 1
                        TieuDeRow(ExcelSheets, vRowEx, "D", "D", vrMay("TEN_NGUYEN_NHAN"), False)
                        CellExcelNam(ExcelSheets, vRowEx, vrMay("JAN"), vrMay("FEB"), vrMay("MAR"), vrMay("APR"), vrMay("MAY"), vrMay("JUN"), vrMay("JUL"), vrMay("AUG"), vrMay("SEP"), vrMay("OCT"), vrMay("NOV"), vrMay("DECE"), vrMay("LUYKE"))
                        TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", vrMay("TEN_NGUYEN_NHAN"), False)
                    Next
                    TieuDeChuDoc(ExcelSheets, vRowEx - vMay.Rows.Count + 1, vRowEx, "C", "C", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KHAU_TRU_GIO_NGUNG_MAY", Commons.Modules.TypeLanguage), True)
                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_MAY_TAO_SP", Commons.Modules.TypeLanguage), True)
                    FunctionmMulCell(ExcelSheets, clNN, vRowEx, vRowEx - vMay.Rows.Count - 1, False)
                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KE_CA_DDH", Commons.Modules.TypeLanguage), False)
                    FunctionmPerCell(ExcelSheets, clNN, vRowEx, vRowEx - vMay.Rows.Count - 1, False)

                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KO_TINH_DDH", Commons.Modules.TypeLanguage), False)
                    FunctionmPerCell2(ExcelSheets, clNN, vRowEx, vRowEx - vMay.Rows.Count - 1, False)

                    TieuDeChuWap(ExcelSheets, vRowEx - 1, vRowEx, "C", "C", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT", Commons.Modules.TypeLanguage), True)

                    CreatChartPie(ExcelSheets, vRowEx, vMay.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT_SU_DUNG", Commons.Modules.TypeLanguage) & "  " & vRowMay("MS_MAY").ToString)
                    CreatChartPie3D(ExcelSheets, vRowEx, vMay.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "CO_CAU", Commons.Modules.TypeLanguage) & "  " & vRowMay("MS_MAY").ToString & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "LY_DO", Commons.Modules.TypeLanguage))
                    CreatChartColumn(ExcelSheets, vRowEx, vMay.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT_SD", Commons.Modules.TypeLanguage) & "  " & vRowMay("MS_MAY").ToString)
                    TieuDeChuDoc(ExcelSheets, vRowEx - vMay.Rows.Count - 5, vRowEx, "B", "B", vRowMay("MS_MAY").ToString, True)
                Next

                prbIN.PerformStep()
                prbIN.Update()


                TieuDeChuDoc(ExcelSheets, vRowLoaiMay + 1, vRowEx, "A", "A", vRow("TEN_LOAI_MAY").ToString, True)

                'Tinh Tong loai may
                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_LY_THUYET", Commons.Modules.TypeLanguage), True)
                Dim vDtNN As System.Data.DataTable = SelectDistinct(New DataView(vtbData, "MS_LOAI_MAY = '" & vRow("MS_LOAI_MAY") & "' AND BTDK = 0 ", "MS_NGUYEN_NHAN", DataViewRowState.CurrentRows).ToTable, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN")
                SoGioLamTrongThangTongLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)

                prbIN.PerformStep()
                prbIN.Update()

                TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAY_TAO_RA_SAN_PHAM", Commons.Modules.TypeLanguage), False)
                vSoNguyenNhan = vDtNN.Rows.Count ' Lay so nguyen Nhan

                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_NGHI_LE", Commons.Modules.TypeLanguage), True)
                SoGioNghiLeTongLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)
                prbIN.PerformStep()
                prbIN.Update()

                TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGHI_LE_KO_DON_HANG", Commons.Modules.TypeLanguage), False)
                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_KE_HOACH", Commons.Modules.TypeLanguage), True)
                SoGioHoatDongTongLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)
                prbIN.PerformStep()
                prbIN.Update()
                TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGU_MAY_DO_YEU_TO_CHU_QUAN", Commons.Modules.TypeLanguage), False)

                For Each vroNN As DataRow In vDtNN.Rows
                    vRowEx = vRowEx + 1
                    TieuDeRow(ExcelSheets, vRowEx, "D", "D", vroNN("TEN_NGUYEN_NHAN"), False)
                    SoGioNNLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)
                    TieuDeRowRight(ExcelSheets, vRowEx, "V", "V", vroNN("TEN_NGUYEN_NHAN"), False)
                Next
                prbIN.PerformStep()
                prbIN.Update()

                TieuDeChuDoc(ExcelSheets, vRowEx - vDtNN.Rows.Count + 1, vRowEx, "C", "C", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KHAU_TRU_GIO_NGUNG_MAY", Commons.Modules.TypeLanguage), True)
                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "C", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "SO_GIO_MAY_TAO_SP", Commons.Modules.TypeLanguage), True)
                SoGioNNLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)
                prbIN.PerformStep()
                prbIN.Update()

                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KE_CA_DDH", Commons.Modules.TypeLanguage), False)
                'SoGioNNLoaiMay(ExcelSheets, vRowEx, vDtMay.Rows.Count, vDtNN.Rows.Count)
                FunctionmPerCell(ExcelSheets, Color.AliceBlue, vRowEx, vRowEx - vDtNN.Rows.Count - 1, False)

                vRowEx = vRowEx + 1
                TieuDeRow(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "KO_TINH_DDH", Commons.Modules.TypeLanguage), False)
                FunctionmPerCell2(ExcelSheets, Color.AliceBlue, vRowEx, vRowEx - vDtNN.Rows.Count - 1, False)
                prbIN.PerformStep()
                prbIN.Update()

                TieuDeChuWap(ExcelSheets, vRowEx - 1, vRowEx, "C", "C", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT", Commons.Modules.TypeLanguage), True)

                CreatChartPie(ExcelSheets, vRowEx, vDtNN.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT_SU_DUNG_LOAI_MAY", Commons.Modules.TypeLanguage) & "  " & vRow("TEN_LOAI_MAY").ToString())
                prbIN.PerformStep()
                prbIN.Update()

                CreatChartPie3D(ExcelSheets, vRowEx, vDtNN.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "CO_CAU_LOAI_MAY", Commons.Modules.TypeLanguage) & "  " & vRow("TEN_LOAI_MAY").ToString() & "  " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "LY_DO", Commons.Modules.TypeLanguage))
                prbIN.PerformStep()
                prbIN.Update()
                CreatChartColumn(ExcelSheets, vRowEx, vDtNN.Rows.Count, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT_SD_LOAI_MAY", Commons.Modules.TypeLanguage) & "  " & vRow("TEN_LOAI_MAY").ToString())
                prbIN.PerformStep()
                prbIN.Update()
                TieuDeChuDoc(ExcelSheets, vRowEx - vDtNN.Rows.Count - 5, vRowEx, "B", "B", vDtMay.Rows.Count.ToString, True)
                prbIN.PerformStep()
                prbIN.Update()
                TieuDeChuDoc(ExcelSheets, vRowEx - vDtNN.Rows.Count - 5, vRowEx, "A", "A", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "TONG", Commons.Modules.TypeLanguage) & " " & vRow("TEN_LOAI_MAY").ToString(), True)
                prbIN.PerformStep()
                prbIN.Update()


            Next

            'Tinh Tong 
            vRowEx = vRowEx + 5
            TieuDeRowRight(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "THANG_TONG", Commons.Modules.TypeLanguage), False)
            TieuDeTong(ExcelSheets, vRowEx - 1)

            prbIN.PerformStep()
            prbIN.Update()

            Dim vRowStar As Integer = 8
            Dim vRowStarBieuDo As Integer = vRowEx


            For i As Integer = 1 To vtbLoaiMay.Rows.Count
                Dim vDtMay As System.Data.DataTable = SelectDistinct(New DataView(vtbData, "MS_LOAI_MAY = '" & vtbLoaiMay.Rows(i - 1)("MS_LOAI_MAY") & "'", "MS_MAY", DataViewRowState.CurrentRows).ToTable, "MS_MAY", "TEN_MAY")
                vRowEx = vRowEx + 1
                TieuDeRowRight(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "MAY_TAO_SP", Commons.Modules.TypeLanguage), False)

                Dim vRowSelect As Integer = ((vSoNguyenNhan + 6) * vDtMay.Rows.Count) + (vSoNguyenNhan + 6)
                vRowStar = vRowStar + vRowSelect
                TongGioMayTaoSanPhan(ExcelSheets, vRowEx, vRowStar - vSoNguyenNhan - 5, vRowStar - 2)


                vRowEx = vRowEx + 1
                TieuDeRowRight(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGUNG_NGHI_LE", Commons.Modules.TypeLanguage), False)
                TongGioMayTaoSanPhan(ExcelSheets, vRowEx, vRowStar - vSoNguyenNhan - 5, vRowStar - vSoNguyenNhan - 4)

                vRowEx = vRowEx + 1
                TieuDeRowRight(ExcelSheets, vRowEx, "D", "D", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "NGUNG_CHU_QUAN", Commons.Modules.TypeLanguage), False)
                TongGioMayNgungChuQuan(ExcelSheets, vRowEx, vRowStar - vSoNguyenNhan - 5, vRowStar, vSoNguyenNhan)
                TieuDeChuWap(ExcelSheets, vRowEx - 2, vRowEx, "B", "C", vtbLoaiMay.Rows(i - 1)("TEN_LOAI_MAY").ToString, True)
                CreatChartColumnTong(ExcelSheets, vRowStarBieuDo, i, vSoNguyenNhan, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHieuSuatSuDungMay", "HIEU_SUAT_SD_LOAI_MAY", Commons.Modules.TypeLanguage) & "  " & vtbLoaiMay.Rows(i - 1)("TEN_LOAI_MAY"))
            Next

            prbIN.PerformStep()
            prbIN.Update()

            ExcelApp.Visible = True
        Catch ex As Exception
            prbIN.Position = prbIN.Properties.Maximum
        End Try
        prbIN.Position = prbIN.Properties.Maximum
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.ParentForm.Close()
    'End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub btnThoat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
