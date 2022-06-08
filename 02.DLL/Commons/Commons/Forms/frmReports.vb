Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports System.Data
Imports Commons.VS.Classes.Admin
Public Class frmReports

#Region "Members"
    Private SqlText As String = String.Empty
    Dim TU_NGAY As String = String.Empty
    Dim DEN_NGAY As String = String.Empty
    Public Shared strNam As String
    Public Shared bolQuy As Boolean
    Public Shared baocao As Integer
    Public Shared tu As String
    Public Shared den As String
    Dim intRow0 As Integer = -1, intRow1 As Integer = -1, intRow2 As Integer = -1, intRow3 As Integer = -1, intRow4 As Integer = -1, intRow5 As Integer = -1, intRow6 As Integer = -1, intRow8 As Integer = -1

    Public Shared loaibaocao As Integer
#End Region

    Private Sub frmReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Commons.Modules.ObjSystems.XoaTable("rptChuKyHieuChuanKeTiep")
        Commons.Modules.ObjSystems.XoaTable("rptSubChuKyHieuChuan")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeChuKyHC")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeSubChuKyHC")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeChuKyHCNoiNgoai")
        Commons.Modules.ObjSystems.XoaTable("rptChuKyHieuChuanKeTiepNoi_Ngoai")
        Commons.Modules.ObjSystems.XoaTable("MAY_NHA_XUONG_TMP" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable("DANH_SACH_TB_CON_KHAU_HAO_TMP")
        Commons.Modules.ObjSystems.XoaTable("rptBaocaocongnhan")
        Commons.Modules.ObjSystems.XoaTable("rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP")
        Commons.Modules.ObjSystems.XoaTable("rptDanhSachDHDDaHC")
        Commons.Modules.ObjSystems.XoaTable("rptDanhSachThietBiDaHC")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeDanhSachThietBiDaHC")
        Commons.Modules.ObjSystems.XoaTable("rptTHONG_TIN_CHUNG_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "THOI_GIAN_NGUNG_MAY_DO_HU_HONG_THEO_MAY_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_HU_HONG")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTieuDeThoiGianHuHong")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_HU_HONG_THEO_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDSTBTNLDHienTai_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTieuDeDSThietBiTheoNoiLapDatHT")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_NGUNG_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_THANG")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_THOI_GIAN_NGUNG_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_TON_KHO_THEO_VI_TRI")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTieuDeThoiGianHuHongTheoThietBi")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "THOI_GIAN_NGUNG_MAY_DO_HU_HONG_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "TON_KHO_KHONG_THEO_VI_TRI_TMP")


    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        txtTungay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 30)
        dtpTuNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 30)

        LoadcboDiaDiem()
        cboNhaxuong.Value = "MS_N_XUONG"
        cboNhaxuong.Display = "Ten_N_XUONG"
        cboNhaxuong.DropDownWidth = 200
        cboNhaxuong.Param = "SELECT NHA_XUONG.* FROM NHA_XUONG INNER JOIN NHOM_NHA_XUONG ON NHA_XUONG.MS_N_XUONG = NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN USERS ON NHOM_NHA_XUONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        cboNhaxuong.StoreName = "QL_SEARCH"
        cboNhaxuong.BindDataSource()

        cboNhaXuongPBT.Value = "MS_N_XUONG"
        cboNhaXuongPBT.Display = "Ten_N_XUONG"
        cboNhaXuongPBT.DropDownWidth = 200
        cboNhaXuongPBT.Param = "SELECT NHA_XUONG.* FROM NHA_XUONG INNER JOIN NHOM_NHA_XUONG ON NHA_XUONG.MS_N_XUONG = NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN USERS ON NHOM_NHA_XUONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        cboNhaXuongPBT.StoreName = "QL_SEARCH"
        cboNhaXuongPBT.BindDataSource()

        cboLoaiThietBi.Value = "MS_LOAI_MAY"
        cboLoaiThietBi.Display = "TEN_LOAI_MAY"
        cboLoaiThietBi.DropDownWidth = 200
        cboLoaiThietBi.Param = "SELECT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY LOAI_MAY.TEN_LOAI_MAY"
        cboLoaiThietBi.StoreName = "QL_SEARCH"
        cboLoaiThietBi.BindDataSource()

        cboTG_LoaiTB.Value = "MS_LOAI_MAY"
        cboTG_LoaiTB.Display = "TEN_LOAI_MAY"
        cboTG_LoaiTB.DropDownWidth = 200
        cboTG_LoaiTB.Param = "SELECT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY LOAI_MAY.TEN_LOAI_MAY"
        cboTG_LoaiTB.StoreName = "QL_SEARCH"
        cboTG_LoaiTB.BindDataSource()

        cboThietBi.Value = "MS_MAY"
        cboThietBi.Display = "MSMAY"
        cboThietBi.DropDownWidth = 200
        cboThietBi.Param = "SELECT MAY.MS_MAY, MAY.MS_MAY AS MSMAY FROM NHOM_LOAI_MAY INNER JOIN LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        cboThietBi.StoreName = "QL_SEARCH"
        cboThietBi.BindDataSource()

        cboPhuTung.Value = "MS_PT"
        cboPhuTung.Display = "TEN_PT"
        cboPhuTung.DropDownWidth = 270
        cboPhuTung.StoreName = "GetIC_PHU_TUNG_NCCs"
        cboPhuTung.BindDataSource()

        cboDayChuyen.Value = "MS_HE_THONG"
        cboDayChuyen.Display = "TEN_HE_THONG"
        cboDayChuyen.DropDownWidth = 200
        cboDayChuyen.Param = "SELECT DISTINCT HE_THONG.* FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY HE_THONG.TEN_HE_THONG"
        cboDayChuyen.StoreName = "QL_SEARCH" ' GetHE_THONGs"
        cboDayChuyen.BindDataSource()

        cboDayChuyenCuoiTuan.Value = "MS_HE_THONG"
        cboDayChuyenCuoiTuan.Display = "TEN_HE_THONG"
        cboDayChuyenCuoiTuan.DropDownWidth = 200
        cboDayChuyenCuoiTuan.Param = "SELECT  HE_THONG.* FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY HE_THONG.TEN_HE_THONG"
        cboDayChuyenCuoiTuan.StoreName = "QL_SEARCH" ' GetHE_THONGs"
        cboDayChuyenCuoiTuan.BindDataSource()

        Try

            Dim vtbClass As New DataTable
            vtbClass.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_CLASS"))

            Dim vrAll As DataRow = vtbClass.NewRow()
            vrAll("MS_CLASS") = 0
            vrAll("TEN_CLASS") = " < ALL > "
            vtbClass.Rows.InsertAt(vrAll, 0)

            Dim vrNull As DataRow = vtbClass.NewRow()
            vrNull("MS_CLASS") = -1
            vrNull("TEN_CLASS") = ""
            vtbClass.Rows.InsertAt(vrNull, 0)

            cbxClass.DataSource = vtbClass
            cbxClass.ValueMember = "MS_CLASS"
            cbxClass.DisplayMember = "TEN_CLASS"

        Catch ex As Exception
        End Try


        Bind_cboLoaiTB()
        Bind_cboNoisudung()
        Bind_cboLoaiCV()

        Bind_cboLoaithietbi2()
        Bind_cboNhomthietbi()
        Bind_cbothietbi2()

        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()

        LoadComboChiPhi()
        dtpTu.Value = CDate("1/1/" & Year(Now))
        dtpDen.Value = CDate("31/12/" & Year(Now))
        dtpTuNam_TKCP.Value = CDate("1/1/" & Year(Now))
        dtpDenNam_TKCP.Value = CDate("31/12/" & Year(Now))
        dtpTuNgay5.Value = dtpTu.Value
        dtpDenNgay5.Value = dtpDen.Value
        loadCboNam()
        LoadDOnvi()
        Me.cbodonvi.SelectedIndex = 1
        Me.Loadban()
        Try
            loadCboTuan(cboNam.SelectedValue.ToString())
        Catch ex As Exception

        End Try

        ' tblPRT_TG_CHAY_MAY()
        'tblPRT_TG_NGUNG_MAY_DT()
        'tblPRT_TG_NGUNG_MAY_PMR()
        Try
            setTextNGAY(cboNam.SelectedValue.ToString(), cboTuan.SelectedValue.ToString())
        Catch ex As Exception

        End Try

        loadLstDSBC3()
        'thời gian ngừng máy''

        LoadcboNguyenNhanNgungMay()
        LoadcbiLoaiMay()
        LoadcboNhomMay()
        LoadcboThietBiLoc()
        LoadcboThietBi_NM()
        'thời gian ngừng máy

        AddHandler cboLoaithietbi2.SelectedIndexChanged, AddressOf Me.cboLoaithietbi2_SelectedIndexChanged
        AddHandler cboNhomthietbi.SelectedIndexChanged, AddressOf Me.cboNhomthietbi_SelectedIndexChanged

        AddHandler cboLoaithietbi3.SelectedIndexChanged, AddressOf Me.cboLoaithietbi3_SelectedIndexChanged
        AddHandler cboNhomthietbi3.SelectedIndexChanged, AddressOf Me.cboNhomthietbi3_SelectedIndexChanged
        AddHandler cboNam.SelectedIndexChanged, AddressOf Me.cboNam_SelectedIndexChanged

        Bind_lstDanhsachbaocao0()
        Bind_lstDanhsachbaocao1()
        Bind_lstDanhsachbaocao2()
        Bind_lstDanhsachbaocao3()

        dtTuNgay_Kho.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 20)

        Bind_cboNCC()
        Bind_cboVattu()
        Bind_cboKho()
        Bind_cboThang()

        'EnableCombox()
        Bind_lstDanhsachbaocao4()
        Bind_lstDanhsachbaocao5()
        Bind_rptHIEU_CHUAN_VA_KIEM_DINH()
        Bind_THONG_KE_THOI_GIAN_NGUNG_MAY()
        Bind_THONG_KE_CHI_PHI()
        RefeshLanguage()

        'AddHandler lstDanhsachbaocao3.SelectedIndexChanged, AddressOf Me.lstDanhsachbaocao3_SelectedIndexChanged


        loadCboDiaDiem1()
        loadCboLoaiBT()
        loadCboLoaiTB()
        loadCboCongNhan()
        LoadTuan()
        cboInTheo.SelectedIndex = 0
        Lbtuthang.Visible = True
        lbdenthang.Visible = True
        txtttuthang.Visible = True
        txtdenthang1.Visible = True
        dtTuNgay_Kho.Value = CDate("1/1/" & Year(Now))
        dtDenNgay_Kho.Value = CDate("31/12/" & Year(Now))
        dtpTuNgayCuoiTuan.Value = CDate("1/" & Now.Month.ToString & "/" & Now.Year.ToString)
        dtpDenNgayCuoiTuan.Value = DateSerial(Year(Format(dtpTuNgayCuoiTuan.Value(), "short date")), Month(Format(dtpTuNgayCuoiTuan.Value(), "short date")), Day(Format(dtpTuNgayCuoiTuan.Value(), "short date")) + 30)
        Me.Cursor = Windows.Forms.Cursors.Default


    End Sub

    Private Sub LoadComboChiPhi()
        cboLoaiTB_CP.Display = "TEN_LOAI_MAY"
        cboLoaiTB_CP.Value = "MS_LOAI_MAY"
        cboLoaiTB_CP.DropDownWidth = 220
        cboLoaiTB_CP.Param = Commons.Modules.UserName
        cboLoaiTB_CP.StoreName = "PermisionLOAI_MAY"
        cboLoaiTB_CP.BindDataSource()

        cboNhomTB_CP.Display = "TEN_NHOM_MAY"
        cboNhomTB_CP.Value = "MS_NHOM_MAY"
        cboNhomTB_CP.DropDownWidth = 220
        cboNhomTB_CP.Param = "SELECT * FROM NHOM_MAY ORDER BY TEN_NHOM_MAY"
        cboNhomTB_CP.StoreName = "QL_SEARCH"
        cboNhomTB_CP.BindDataSource()

        cboLoaiBT_CP.Display = "TEN_LOAI_BT"
        cboLoaiBT_CP.Value = "MS_LOAI_BT"
        cboLoaiBT_CP.Param = "SELECT * FROM LOAI_BAO_TRI ORDER BY TEN_LOAI_BT"
        cboLoaiBT_CP.StoreName = "QL_SEARCH"
        cboLoaiBT_CP.BindDataSource()

        cboDayChuyenSXTB_CP.Display = "TEN_HE_THONG"
        cboDayChuyenSXTB_CP.Value = "MS_HE_THONG"
        cboDayChuyenSXTB_CP.DropDownWidth = 200
        cboDayChuyenSXTB_CP.Param = "SELECT * FROM HE_THONG ORDER BY TEN_HE_THONG"
        cboDayChuyenSXTB_CP.StoreName = "QL_SEARCH"
        cboDayChuyenSXTB_CP.BindDataSource()
    End Sub

    Public Sub LoadDOnvi()
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        dt = obj.Getdonvibaocao
        Me.cbodonvi.DataSource = dt
        cbodonvi.ValueMember = "ms_don_vi"
        cbodonvi.DisplayMember = "ten_don_vi"
    End Sub

    Public Sub Loadban()
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        dt = obj.Gettophongbanbaocao(Me.cbodonvi.SelectedValue)
        Me.cboban.DataSource = dt
        cboban.ValueMember = "ms_to"
        cboban.DisplayMember = "ten_to"
    End Sub
#Region "Events"
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click

        Me.Close()
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

                .Cells(4, 1) = "DANH SÁCH NHÂN VIÊN"

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

                .Cells(hang, 1) = "STT"
                .Cells(hang, 1).Font.Bold = True
                .Range(.Cells(hang, 1), .Cells(hang, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 1), .Cells(hang, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 2) = "Mã NV"
                .Cells(hang, 2).Font.Bold = True
                .Range(.Cells(hang, 2), .Cells(hang, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 2), .Cells(hang, 2)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 3) = "Họ và tên "
                .Cells(hang, 3).Font.Bold = True
                .Range(.Cells(hang, 3), .Cells(hang, 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 3), .Cells(hang, 3)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 4) = "Ngày sinh "
                .Cells(hang, 4).Font.Bold = True
                .Range(.Cells(hang, 4), .Cells(hang, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 4), .Cells(hang, 4)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 5) = "Nơi sinh "
                .Cells(hang, 5).Font.Bold = True
                .Range(.Cells(hang, 5), .Cells(hang, 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 5), .Cells(hang, 5)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 6) = "Địa chỉ "
                .Cells(hang, 6).Font.Bold = True
                .Range(.Cells(hang, 6), .Cells(hang, 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 6), .Cells(hang, 6)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 7) = "SO CMND"
                .Cells(hang, 7).Font.Bold = True
                .Range(.Cells(hang, 7), .Cells(hang, 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 7), .Cells(hang, 7)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 8) = "Ngày cấp"
                .Cells(hang, 8).Font.Bold = True
                .Range(.Cells(hang, 8), .Cells(hang, 8)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 8), .Cells(hang, 8)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 9) = "Nơi cấp"
                .Cells(hang, 9).Font.Bold = True
                .Range(.Cells(hang, 9), .Cells(hang, 9)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 9), .Cells(hang, 9)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 10) = "DTDĐ"
                .Cells(hang, 10).Font.Bold = True
                .Range(.Cells(hang, 10), .Cells(hang, 10)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 10), .Cells(hang, 10)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 11) = "ĐT nhà"
                .Cells(hang, 11).Font.Bold = True
                .Range(.Cells(hang, 11), .Cells(hang, 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 11), .Cells(hang, 11)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 12) = "Trình độ"
                .Cells(hang, 12).Font.Bold = True
                .Range(.Cells(hang, 12), .Cells(hang, 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 12), .Cells(hang, 11)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 13) = "Bằng cấp"
                .Cells(hang, 13).Font.Bold = True
                .Range(.Cells(hang, 13), .Cells(hang, 13)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 13), .Cells(hang, 13)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 14) = "Chuyên môn"
                .Cells(hang, 14).Font.Bold = True
                .Range(.Cells(hang, 14), .Cells(hang, 14)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 14), .Cells(hang, 14)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 15) = "Bậc thợ"
                .Cells(hang, 15).Font.Bold = True
                .Range(.Cells(hang, 15), .Cells(hang, 15)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 15), .Cells(hang, 15)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 16) = "Ngày vào làm"
                .Cells(hang, 16).Font.Bold = True
                .Range(.Cells(hang, 16), .Cells(hang, 15)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 16), .Cells(hang, 15)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 17) = "Chức vụ"
                .Cells(hang, 17).Font.Bold = True
                .Range(.Cells(hang, 17), .Cells(hang, 17)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 17), .Cells(hang, 17)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 18) = "Lương CB"
                .Cells(hang, 18).Font.Bold = True
                .Range(.Cells(hang, 18), .Cells(hang, 18)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 18), .Cells(hang, 18)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 19) = "Người thân"
                .Cells(hang, 19).Font.Bold = True
                .Range(.Cells(hang, 19), .Cells(hang, 19)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 19), .Cells(hang, 19)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 20) = "Quan hệ"
                .Cells(hang, 20).Font.Bold = True
                .Range(.Cells(hang, 20), .Cells(hang, 20)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 20), .Cells(hang, 20)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 21) = "Nghỉ việc"
                .Cells(hang, 21).Font.Bold = True
                .Range(.Cells(hang, 21), .Cells(hang, 21)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 21), .Cells(hang, 21)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 22) = "Lý do nghỉ"
                .Cells(hang, 22).Font.Bold = True
                .Range(.Cells(hang, 22), .Cells(hang, 22)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 22), .Cells(hang, 22)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 23) = "Tai nạn"
                .Cells(hang, 23).Font.Bold = True
                .Range(.Cells(hang, 23), .Cells(hang, 23)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 23), .Cells(hang, 23)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 24) = "Ghi chú"
                .Cells(hang, 24).Font.Bold = True
                .Range(.Cells(hang, 24), .Cells(hang, 24)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 24), .Cells(hang, 24)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                For i = 0 To dtdonvi.Rows.Count - 1
                    rowdv = dtdonvi.Rows(i)
                    .Cells(hang - 1, 1) = "Đơn vị " & "   " & rowdv("ten_don_vi").ToString
                    .Cells(hang - 1, 1).Font.Bold = True
                    .Cells(hang - 1, 1).Font.Color = RGB(200, 1, 1)

                    dtban = obj.GetbaocaoToban(rowdv("ms_don_vi"))
                    hang = hang + 1
                    For j = 0 To dtban.Rows.Count - 1
                        rowban = dtban.Rows(j)
                        hang1 = hang + 1

                        Dim dtnhanvien As New DataTable
                        Dim rownhanvien As DataRow = Nothing
                        dtnhanvien = obj.Getnhanvienbaocao(rowban("ms_to").ToString)
                        ExcelSheets.Cells(hang1, 1).value = "Bộ phận " & " " & rowban("ten_to").ToString
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


                'ExcelApp.ActiveCell.Worksheet.SaveAs("D:\DanhSachNhanVien.xls")
                'End If

                'ExcelBooks.Close()
                'ExcelApp.Quit()

            End With
        Catch
            'ExcelApp.Quit()
            '' ExcelSheets = Nothing
            ' ExcelBooks = Nothing

        End Try
    End Sub
    Private Sub btnIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIN.Click
        Select Case tabBaocao.SelectedTab.Name '  Me.tabBaocao.SelectedIndex
            Case "tabKhoitao"
                Select Case Me.grdDanhsachbaocao0.Rows(intRow0).Cells("REPORT_NAME").Value
                    Case "rptDanhsach_NCC"
                        Commons.clsXuLy.CreateTitleReport()
                        Call Print_preview1()
                    Case "rptDanhsach_VTPT"
                        'clsXuLy.CreateTitleReport()
                        'Call Print_preview2()
                        PrintDanhMucPhuTung()
                    Case "rptDanhsach_CV"
                        'clsXuLy.CreateTitleReport()
                        ' Call Print_preview3()
                        PrintCongViec()
                End Select
            Case "tabThongtinthietbi"
                Select Case Me.grdDanhsachbaocao1.Rows(intRow1).Cells("REPORT_NAME").Value
                    Case "rptDanhSach_ThietBi"
                        Commons.clsXuLy.CreateTitleReport()
                        Call Printpreview1()
                    Case "rptDanhSachHetHanBaoHanh"
                        Commons.clsXuLy.CreateTitleReport()
                        If txtDenngay.Value < txtTungay.Value Then
                            If commons.Modules.TypeLanguage = 0 Then
                                MsgBox("Chọn ngày không hợp lệ")
                            ElseIf commons.Modules.TypeLanguage = 0 Then
                                MsgBox("Date is valid")
                            End If
                        Else
                            Call CreateData2()
                            Call Printpreview2()
                        End If
                    Case "rptDanhSachThietBiConKhauHao"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData3()
                        Call Printpreview3()
                    Case "rptDanhSachThietBiHetKhauHao"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData4()
                        Call Printpreview4()

                    Case "rptDanhSachNoiLapDatVaBPCPCuaThietBi"
                        Call CreateData6()
                        Call Printpreview6()

                    Case "rptDanhSachThietBiSuDungPhuTung"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData7()
                        Call Printpreview7()

                    Case "rptDSTBTNLDHienTai"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData11()
                        Call Printpreview11()
                    Case "rptDSBPChiuPhi"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData12()
                        Call Printpreview12()
                    Case "rptDanhsachTB_TheoDayChuyen"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateDataTB_TheoDC()
                        Call PrintpreviewTB_TheoDC()
                        'Case "rptDSTBAnToan"
                        '    Dim frmDSTBAnToan As frmChonDSTBAnToan = New frmChonDSTBAnToan()
                        '    frmDSTBAnToan.ShowDialog(Me)
                        'Case "rptDanhSachConHanBaoHanh"
                        '    Dim frm As frmChonConHanBaoHanh = New frmChonConHanBaoHanh()
                        '    frm.ShowDialog(Me)
                        'Case "rptDANH_SACH_THIET_BI_GIA_KHI_MUA"
                        '    Dim frm As FrmDanhSachThietBiGiaTriKhiMua = New FrmDanhSachThietBiGiaTriKhiMua()
                        '    frm.ShowDialog(Me)
                        'Case "rptDanhsachphutungtheoXuong_KKTL"
                        '    Dim DanhsachphutungtheoXuong_KKTL As WareHouse.frmRptDanhsachphutungtheoXuong_KKTL = New WareHouse.frmRptDanhsachphutungtheoXuong_KKTL()
                        '    DanhsachphutungtheoXuong_KKTL.ShowDialog(Me)
                        'Case "rptDanhsachphutungtheoDONVI_KKTL"
                        '    Dim DanhsachphutungtheoDONVI_KKTL As WareHouse.frmRptDanhsachphutungtheoDONVI_KKTL = New WareHouse.frmRptDanhsachphutungtheoDONVI_KKTL()
                        '    DanhsachphutungtheoDONVI_KKTL.ShowDialog(Me)
                        'Case "rptDanhsachphutungdacbiet_KKTL"
                        '    Dim Danhsachphutungdacbiet_KKTL As WareHouse.frmRptDanhsachphutungdacbiet_KKTL = New WareHouse.frmRptDanhsachphutungdacbiet_KKTL()
                        '    Danhsachphutungdacbiet_KKTL.ShowDialog(Me)
                        'Case "rptTinhHinhSuaChuaThietBi_KKTL"
                        '    Dim TinhHinhSuaChuaThietBi_KKTL As WareHouse.frmTinhHinhSuaChuaThietBi_KKTL = New WareHouse.frmTinhHinhSuaChuaThietBi_KKTL()
                        '    TinhHinhSuaChuaThietBi_KKTL.ShowDialog(Me)

                End Select
            Case "tabSudung"
                'Select Case Me.grdDanhsachbaocao2.Rows(intRow2).Cells("REPORT_NAME").Value
                '    Case "rptThoigianchaymay"
                '        print_reportThoigianchaymay()
                'End Select
            Case "tabTGNgungMay"
                Select Case Me.grdDanhsachbaocao4.Rows(intRow4).Cells("REPORT_NAME").Value
                    Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
                        If DateDiff(DateInterval.Day, dtpTu.Value, dtpDen.Value) < 0 Then
                            MsgBox("Khoảng thời gian cần in báo cáo không hợp lệ !" & vbCrLf & "Vui lòng kiểm tra lại khoảng thời gian chọn in báo cáo.", MsgBoxStyle.Exclamation)
                            dtpTu.Focus()
                            Exit Sub
                        End If
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateTG_NgungMayTheoNam()
                        Call PrintpreviewTG_NgungMayTheoNam()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY"
                        If DateDiff(DateInterval.Day, dtpTu.Value, dtpDen.Value) < 0 Then
                            MsgBox("Khoảng thời gian cần in báo cáo không hợp lệ !" & vbCrLf & "Vui lòng kiểm tra lại khoảng thời gian chọn in báo cáo.", MsgBoxStyle.Exclamation)
                            dtpTu.Focus()
                            Exit Sub
                        End If
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        Call ShowrptThoiGianHuHongTheoThietBi()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
                        '    Dim frm As frmInTGNMNN = New frmInTGNMNN
                        '    frm.ShowDialog()
                        '    Exit Sub
                        '    'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    clsXuLy.CreateTitleReport()
                        '    Call CreateTG_NgungMayTheoNguyenNhan()
                        '    Call PrintpreviewTG_NgungMayTheoNguyenNhan()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptBreakdownTime"
                        If DateDiff(DateInterval.Day, dtpTu.Value, dtpDen.Value) < 0 Then
                            MsgBox("Khoảng thời gian cần in báo cáo không hợp lệ !" & vbCrLf & "Vui lòng kiểm tra lại khoảng thời gian chọn in báo cáo.", MsgBoxStyle.Exclamation)
                            dtpTu.Focus()
                            Exit Sub
                        End If
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        Call ShowrptThoiGianHuHong()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptThongKeThoiGianNgungMay"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    FrmTGDMAY.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptThongKeTanSuatNgungMay"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    FrmTSDMAY.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptThongKeTanSuatNgungMay_NEW"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    FrmTSDMAY_NEW.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptKHA_NANG_SAN_SANG_THEO_THIET_BI"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    Frmkhanangsansangtheomay.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptKHA_NANG_SAN_SANG_THEO_THIET_BI_BREAKDOWN"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    Frmkhanangsansangtheomay_breakdown.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptHIEU_SUAT_SU_DUNG_MAY"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    Frmhieusuatsudungmay.ShowDialog()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptBIEU_DO_THOI_GIAN_NGUNG_MAY"
                        '    Dim frm As FrmBieuDoThoiGianNgungMay = New FrmBieuDoThoiGianNgungMay()
                        '    frm.ShowDialog(Me)
                        'Case "rptHieuSuatSuDungMay"
                        '    Dim frm As frmChonHieuSuatSuDungMay = New frmChonHieuSuatSuDungMay()
                        '    frm.ShowDialog(Me)

                        'Case "rptThongKeThoiGianNgungMayTheoNguyenNhan"
                        '    Dim frm As FrmChonTKTGNMTheoNN = New FrmChonTKTGNMTheoNN()
                        '    frm.ShowDialog(Me)

                        'Case "rptBieuDoTGNMTheoNNHours"
                        '    Dim frm As FrmChonBieuDoTGNMTheoNN = New FrmChonBieuDoTGNMTheoNN()
                        '    frm.ShowDialog(Me)

                        'Case "rptBieuDoTGNMTheoNNPercent"
                        '    Dim frm As FrmChonBieuDoTGNMTheoNN_PERCENT = New FrmChonBieuDoTGNMTheoNN_PERCENT()
                        '    frm.ShowDialog(Me)

                        'Case "rptBieuDoKPI"
                        '    Dim frm As FrmChonMachineDowntimeKPI = New FrmChonMachineDowntimeKPI()
                        '    frm.ShowDialog(Me)
                        'Case "rptBieuDoKhaNangSanSangLine"
                        '    Dim frm As FrmChonBieuDoKhaNangSanSangTheoLine = New FrmChonBieuDoKhaNangSanSangTheoLine()
                        '    frm.ShowDialog(Me)
                        'Case "rptBieuDohieuSuatLine"
                        '    Dim frm As FrmChonHieuSuatSuDungLine = New FrmChonHieuSuatSuDungLine()
                        '    frm.ShowDialog(Me)

                        'Case "rptMAINTENANCT_REPORT_MONTHLY"
                        '    Dim frm As frmChonMAINTENANCT_REPORT_MONTHLY = New frmChonMAINTENANCT_REPORT_MONTHLY()
                        '    frm.ShowDialog(Me)

                        'Case "rptBieudoMTBF_MTTR"
                        '    Dim frm As frmBieudoMTBF_MTTR = New frmBieudoMTBF_MTTR()
                        '    frm.ShowDialog(Me)

                        'Case "rptBieudoTopTGNM"
                        '    Dim frm As frmBieudoTopTGNM = New frmBieudoTopTGNM()
                        '    frm.ShowDialog(Me)

                End Select
            Case "tabTKChiPhi"
                If DateDiff(DateInterval.Day, dtpTuNam_TKCP.Value, dtpDenNam_TKCP.Value) < 0 Then
                    MsgBox("Khoảng thời gian cần in báo cáo không hợp lệ !" & vbCrLf & "Vui lòng kiểm tra lại khoảng thời gian chọn in báo cáo.", MsgBoxStyle.Exclamation)
                    dtpTuNam_TKCP.Focus()
                    Exit Sub
                End If
                Select Case Me.grdDanhsachbaocao5.Rows(intRow5).Cells("REPORT_NAME").Value
                    Case "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptCHI_PHI_BAO_TRI_THEO_LOAI_TB()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptCHI_PHI_BAO_TRI_THEO_NHOM_TB()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptCHI_PHI_THEO_DAY_CHUYEN"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptChiPhiBaoTri"
                        '    FrmCP.ShowDialog()

                        'Case "rptBoPhanChiPhiReport"
                        '    Dim frm As FrmBoPhanChiPhiReport = New FrmBoPhanChiPhiReport()
                        '    frm.ShowDialog(Me)
                        'Case "rptCHI_PHI_DICH_VU_THUE_NGOAI"
                        '    Dim frm As FrmChiPhiDichVuThueNgoai = New FrmChiPhiDichVuThueNgoai()
                        '    frm.ShowDialog(Me)
                        'Case "rptCHI_PHI_BAO_TRI_THEO_BPCP"
                        '    Dim frm As FrmChiPhiBaoTriTheoBPCP = New FrmChiPhiBaoTriTheoBPCP()
                        '    frm.ShowDialog(Me)
                        'Case "rptBIEU_DO_CHI_PHI_BAO_TRI"
                        '    Dim frm As FrmBieuDoChiPhiBaoTri = New FrmBieuDoChiPhiBaoTri()
                        '    frm.ShowDialog(Me)

                        'Case "rptBIEU_DO_CHI_PHI_MAINT_COST"
                        '    Dim frm As frmBieuDoMaintCost = New frmBieuDoMaintCost()
                        '    frm.ShowDialog(Me)
                        'Case "rptBIEU_DO_MAIN_HOUR"
                        '    Dim frm As frmBieuDoMaintHour = New frmBieuDoMaintHour()
                        '    frm.ShowDialog(Me)
                        'Case "rptPhanTichChiPhi"
                        '    Dim frm As FrmPhanTichChiPhi = New FrmPhanTichChiPhi()
                        '    frm.MdiParent = frmMain
                        '    frm.WindowState = FormWindowState.Maximized
                        '    frm.Show()
                        'Case "rptPhanTichChiPhi_DUYTAN"
                        '    Dim frm As FrmPhanTichChiPhi_DUYTAN = New FrmPhanTichChiPhi_DUYTAN()
                        '    frm.MdiParent = frmMain
                        '    frm.Name = "FrmPhanTichChiPhi_DUYTAN"
                        '    frm.WindowState = FormWindowState.Maximized
                        '    frm.Show()

                        'Case "rptSparePartDailyBudgetCheckList"
                        '    Dim frm As FrmSparePartDaylyBudget = New FrmSparePartDaylyBudget()
                        '    frm.ShowDialog(Me)

                        'Case "rptMaterialsSewingDailyReport"
                        '    Dim frm As FrmChonMaterialsSewingDailyReport = New FrmChonMaterialsSewingDailyReport()
                        '    frm.ShowDialog(Me)

                End Select
            Case "tabBaoTri"
                Select Case Me.grdDanhsachbaocao7.Rows(intRow3).Cells("REPORT_NAME").Value

                    Case "rptThongso_GSTT_DHKT"
                        print_reportThongso_GSTT_DHKT()
                    Case "rptWEP_REPORT"
                        Call CreateData9()
                    Case "rptChuKyHieuChuanKeTiep"
                        ShowrptChuKyHieuChuanKeTiep()
                    Case "rptDSPBTDaNghiemThuTLBT"
                        Call CreateData13()
                        Call Printpreview13()
                    Case "rptDSCPBTTLoaiMay_LoaiTB"
                        Commons.clsXuLy.CreateTitleReport()
                        If rdLoaiMay_DD.Checked Then
                            Call CreateData15()
                            Call Printpreview15()
                        Else
                            Call CreateData14()
                            Call Printpreview14()
                        End If
                    Case "rptDSCYCBTDaNghiemThuTheoNV"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData16()
                        Call Printpreview16()
                    Case "rptDSCYCBTChuaNghiemThuTheoNV"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData17()
                        Call Printpreview17()
                    Case "rptDSPBTChuaNghiemThuTLBT"
                        Commons.clsXuLy.CreateTitleReport()
                        Call CreateData18()
                        Call Printpreview18()
                    Case "rptDAILY_EQUIPMENT_EUEL"
                        Call CreateData10()
                        'Call Printpreview10()
                        'Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
                        '    ShowrptTHOI_GIAN_NGUNG_MAY_THEO_NAM()
                        'Case "rptTHOI_GIAN_NGUNG_MAY_THEO_THANG"
                        '    ShowrptTHOI_GIAN_NGUNG_MAY_THEO_THANG()
                        'Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
                        '    ShowrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN()
                        'Case "rptTHOI_GIAN_NGUNG_MAY_CHART"
                        '    ShowrptThoiGianNgungMayChart()
                        'Case "rptBreakdownTime"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    ShowrptThoiGianHuHong()
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptKeHoachBaoTriTrongTuan"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptKeHoachBaoTriTrongTuan()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptDANH_GIA_DICH_VU_KH"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptBangDanhGia_DVKH()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptKE_HOACH_BT_TUAN"
                        '    Dim frmKHT As FRM_KE_HOACH_BAO_TRI_TUAN = New FRM_KE_HOACH_BAO_TRI_TUAN()
                        '    frmKHT.ShowDialog()
                        'Case "rptKeHoachPhanCongBT"
                        '    Dim frmPC As frmChonKeHoachPhanCongBT = New frmChonKeHoachPhanCongBT()
                        '    frmPC.ShowDialog(Me)
                        'Case "rptBaoTriDinhKyThang"
                        '    Dim frmBTDK As frmChonBaoTriDinhKyThang = New frmChonBaoTriDinhKyThang()
                        '    frmBTDK.ShowDialog(Me)
                        'Case "rptDailyReport"
                        '    Dim frmBTNGAY As frmChonCSWind = New frmChonCSWind()
                        '    frmBTNGAY.ShowDialog(Me)

                        'Case "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI"
                        '    Dim frmListBT As FrmChonDanhSachPhieuBaoTriTheoNgayCuoi = New FrmChonDanhSachPhieuBaoTriTheoNgayCuoi()
                        '    frmListBT.ShowDialog(Me)
                        'Case "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM"
                        '    Dim frmListBT As FrmDanhSachPhieuBaoTriTheoKhuVuc = New FrmDanhSachPhieuBaoTriTheoKhuVuc()
                        '    frmListBT.ShowDialog(Me)

                        'Case "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB"
                        '    Dim frm As FrmDanhSachVatTuBaoTri = New FrmDanhSachVatTuBaoTri()
                        '    frm.ShowDialog(Me)

                        'Case "rptPHIEU_CONG_VIEC"
                        '    Dim frm As FrmChonBCPhieuCongViec = New FrmChonBCPhieuCongViec()
                        '    frm.ShowDialog(Me)
                        'Case "rptKehoachbaotriduphong"
                        '    Dim frm As frmKehoachbaotriduphong = New frmKehoachbaotriduphong()
                        '    frm.ShowDialog(Me)
                        'Case "rptKeHoachSuaChuaThietBi_KKTL"
                        '    Dim frm As frmKehoachsuachuathietbi = New frmKehoachsuachuathietbi()
                        '    frm.ShowDialog(Me)

                End Select
            Case "tabKho"
                Select Case Me.grdDanhsachbaocao8.Rows(intRow8).Cells("REPORT_NAME").Value
                    Case "rptCTY_DA_CUNG_CAP_VAT_TU"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptCTY_DA_CUNG_CAP_VAT_TU()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptDANH_GIA_NCC"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptDANH_GIA_NCC()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptTON_KHO_KHONG_THEO_VI_TRI"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptTON_KHONG_THEO_VI_TRI()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptTON_KHO_THEO_VI_TRI"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptTON_THEO_VI_TRI()
                        Me.Cursor = Windows.Forms.Cursors.Default


                    Case "rptTON_KHO_THEO_VI_TRI_BAYER"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptTON_THEO_VI_TRI_BAYER()
                        Me.Cursor = Windows.Forms.Cursors.Default


                    Case "rptTON_KHO_THEO_PHIEU_NHAP"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptTON_KHO_THEO_PHIEU_NHAP()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptDDH"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        If radChuaTH.Checked = True Then
                            CreateData22()
                            Printpreview22()
                        Else
                            CreateData21()
                            Printpreview21()
                        End If
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptDE_XUAT_MUA_HANG"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        If radChuaTH.Checked = True Then
                            CreateData20()
                            Printpreview20()
                        Else
                            CreateData19()
                            Printpreview19()
                        End If
                        Me.Cursor = Windows.Forms.Cursors.Default
                        'Case "rptDanhSachPhieuNhap"
                        '    Dim frm As frmInPhieuNhapKho = New frmInPhieuNhapKho()
                        '    frm.ShowDialog()
                        'Case "rptDanhSachPhieuXuatKho"
                        '    Dim frm As frmInPhieuXuatKho = New frmInPhieuXuatKho()
                        '    frm.ShowDialog()
                        'Case "rptTheKho"
                        '    Dim frmThekho As frmChonTheKho = New frmChonTheKho()
                        '    frmThekho.ShowDialog(Me)
                        'Case "rptThongKeXuatVatTu"
                        '    Dim frm As frmThongKeVT = New frmThongKeVT()
                        '    frm.ShowDialog(Me)
                        'Case "rptKiemKeVT_PT"
                        '    Dim frm As FrmChonKhoKiemKe = New FrmChonKhoKiemKe()
                        '    frm.ShowDialog(Me)
                        'Case "rptTonKhoTheoDayChuyen"
                        '    Dim frm As frmTonkhotheoline = New frmTonkhotheoline()
                        '    frm.ShowDialog(Me)

                        'Case "rptPhanTichGiaTriTonKho"
                        '    Dim frm As frmChonPhanTichHangTonKho = New frmChonPhanTichHangTonKho()
                        '    frm.ShowDialog(Me)
                        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        'ShowPhanTichGiaTriTonKho()
                        'Me.Cursor = Windows.Forms.Cursors.Default

                        'Case "rptVAT_TU_XUAT_KHO"
                        '    Dim frm As frmChonVTPTXuatkho = New frmChonVTPTXuatkho()
                        '    frm.ShowDialog(Me)

                        'Case "rptMONTHLY_CONSUMPTION_INPUT_LIST"
                        '    Dim frm As WareHouse.frmMonthlyConsumptionInputList = New WareHouse.frmMonthlyConsumptionInputList()
                        '    frm.ShowDialog(Me)
                        'Case "rptMONTHLY_PO_APPROVED"
                        '    Dim frm As WareHouse.frmMonthlyPOApproved = New WareHouse.frmMonthlyPOApproved()
                        '    frm.ShowDialog(Me)
                        'Case "rptVENDOR_REPORT_PURCHASING_ORDER"
                        '    Dim frm As WareHouse.frmVendorReportPurchasingOrder = New WareHouse.frmVendorReportPurchasingOrder()
                        '    frm.ShowDialog(Me)

                        'Case "rptVENDOR_REPORT_GOOD_RECEIPT"
                        '    Dim frm As WareHouse.frmVendorReportGoodReceipt = New WareHouse.frmVendorReportGoodReceipt()
                        '    frm.ShowDialog(Me)
                        'Case "rptMONTHLY_MATERIAL_OUTPUT_LIST"
                        '    Dim frm As WareHouse.frmMonthlyMaterialOutputList = New WareHouse.frmMonthlyMaterialOutputList()
                        '    frm.ShowDialog(Me)
                        'Case "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT"
                        '    Dim frm As WareHouse.frmMonthlyMaintanceMaterialReport = New WareHouse.frmMonthlyMaintanceMaterialReport()
                        '    frm.ShowDialog(Me)

                End Select
            Case "tabHieuChuanKiemDinh"
                Select Case grdDanhsachbaocao6.Rows(intRow6).Cells("REPORT_NAME").Value
                    Case "rptChuKyHieuChuanNoi_Ngoai"
                        If txtNam.Text = "" Then
                            MsgBox("Bạn vui lòng nhập năm cần xem ", MsgBoxStyle.Information, "Thông báo ")
                            txtNam.Focus()
                            Exit Sub
                        End If
                        If txtNam.Text.Length < 4 Then
                            MsgBox("Bạn nhập sai kiểu năm, vui lòng nhập lại ! ", MsgBoxStyle.Information, "Thông báo ")
                            txtNam.Focus()
                            Exit Sub
                        End If
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Commons.clsXuLy.CreateTitleReport()
                        ShowrptDanhSachDHDDaHC()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Case "rptDanhSachThietBiDaHC"
                        If txtNam.Text <> "" And txtNam.Text.Length = 4 Then
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            Commons.clsXuLy.CreateTitleReport()
                            ShowrptDanhSachThietBiDaHC()
                            Me.Cursor = Windows.Forms.Cursors.Default
                        Else
                            MsgBox("Năm cần in báo cáo không hợp lệ !", MsgBoxStyle.Critical, "Thông báo")
                            txtNam.Focus()
                        End If
                        'Case "rptKeHoachGiamSatTinhTrang"
                        '    Dim frmGSTT As frmChonGiamSatTinhtrang = New frmChonGiamSatTinhtrang()
                        '    frmGSTT.ShowDialog(Me)
                        'Case "rptKeHoachGiamSatTinhTrang_BDL"
                        '    Dim frmGSTT As frmChonGiamSatTinhTrang_BDL = New frmChonGiamSatTinhTrang_BDL()
                        '    frmGSTT.ShowDialog(Me)
                End Select

            Case "tabNhanVien"
                '                XuatExcel()
                printnhanvien()

        End Select
    End Sub

    Sub ShowPhanTichGiaTriTonKho()
        Dim vtbData As New DataTable
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHAN_TICH_GIA_TRI_HANG_TON_KHO"))
        Dim frm As frmXMLReport = New frmXMLReport
        frm.rptName = "rptPhanTichGiaTriTonKho"
        frm.AddDataTableSource(RefeshLanguaPhanTichGiaiTriTK())
        frm.AddDataTableSource(vtbData)
        frm.ShowDialog()

    End Sub

    Function RefeshLanguaPhanTichGiaiTriTK() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 11
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TONG_GT"
        vtbTitle.Columns(2).ColumnName = "STT"
        vtbTitle.Columns(3).ColumnName = "MS_PT"
        vtbTitle.Columns(4).ColumnName = "TEN_PT"
        vtbTitle.Columns(5).ColumnName = "PART_NO"
        vtbTitle.Columns(6).ColumnName = "QUY_CACH"
        vtbTitle.Columns(7).ColumnName = "SO_LUONG"
        vtbTitle.Columns(8).ColumnName = "GIA_TRI"
        vtbTitle.Columns(9).ColumnName = "KHO"
        vtbTitle.Columns(10).ColumnName = "LOAI_VT"
        vtbTitle.Columns(11).ColumnName = "TMP1"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("TONG_GT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TONG_GT", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "STT", commons.Modules.TypeLanguage)
        vRowTitle("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "MS_PT", commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TEN_PT", commons.Modules.TypeLanguage)
        vRowTitle("PART_NO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "PART_NO", commons.Modules.TypeLanguage)
        vRowTitle("QUY_CACH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "QUY_CACH", commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "SO_LUONG", commons.Modules.TypeLanguage)
        vRowTitle("GIA_TRI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "GIA_TRI", commons.Modules.TypeLanguage)
        vRowTitle("KHO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "KHO", commons.Modules.TypeLanguage)
        vRowTitle("LOAI_VT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "LOAI_VT", commons.Modules.TypeLanguage)
        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TMP1", commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle

    End Function


    Sub ShowrptTON_THEO_VI_TRI_BAYER()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI_BAYER", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, commons.Modules.TypeLanguage, cbxClass.SelectedValue)
            CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_THEO_VI_TRI_BAYER.rpt")
        Catch ex As Exception

        End Try
    End Sub

    Sub CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_VI_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_THEO_VI_TRI(TypeLanguage int , Trangin nvarchar(120), NgayIn nvarchar(120),TieuDe nvarchar(255),MaKho nvarchar(120)," & _
                "TenKho nvarchar(130),MaPT nvarchar(120),TenPT nvarchar(130),QuyCach nvarchar(130),TenViTri nvarchar(130),sDVT nvarchar(120),TonDK nvarchar(120),sNhap nvarchar(120),sXuat nvarchar(120)," & _
                "ChuyenDi nvarchar(120),ChuyenDen nvarchar(120), TonCK nvarchar(120),Tong nvarchar(120),STT nvarchar(15),ThoiGian nvarchar(200),PART_NO NVARCHAR (256),GIA_TRI NVARCHAR (256),TON_MIN NVARCHAR (256), TEN_CLASS NVARCHAR (256),T1 NVARCHAR (256),T2 NVARCHAR (256),T3 NVARCHAR (256),T4 NVARCHAR (256),T5 NVARCHAR (256),T6 NVARCHAR (256),T7 NVARCHAR (256))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TieuDe4", commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "STT", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TrangIn", commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaKho", commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenKho", commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaPT", commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenPT", commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "QuyCach", commons.Modules.TypeLanguage)
        Dim sTenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenViTri", commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sDVT", commons.Modules.TypeLanguage)
        Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonDK", commons.Modules.TypeLanguage)
        Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sNhap", commons.Modules.TypeLanguage)
        Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sXuat", commons.Modules.TypeLanguage)
        Dim sChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "DI_CHUYEN", commons.Modules.TypeLanguage)
        Dim sChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "CL_KK", commons.Modules.TypeLanguage)
        Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonCK", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Tong", commons.Modules.TypeLanguage) '
        Dim ThoiGian As String = lblTuNgay_Kho.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenNgay_Kho.Text & " " & Format(dtDenNgay_Kho.Value, "short date") 'cboThang.SelectedValue"
        Dim Part_no As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Part_No", commons.Modules.TypeLanguage)
        Dim Gia_Tri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Gia_Tri", commons.Modules.TypeLanguage)
        Dim Ton_Min As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ton_Min", commons.Modules.TypeLanguage)
        Dim Ten_Class As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ten_Class", commons.Modules.TypeLanguage)
        Dim T1 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T1", commons.Modules.TypeLanguage)
        Dim T2 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T2", commons.Modules.TypeLanguage)
        Dim T3 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T3", commons.Modules.TypeLanguage)
        Dim T4 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T4", commons.Modules.TypeLanguage)
        Dim T5 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T5", commons.Modules.TypeLanguage)
        Dim T6 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T6", commons.Modules.TypeLanguage)
        Dim T7 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T7", commons.Modules.TypeLanguage)
        str = "INSERT INTO [DBO].rptTIEU_DE_TON_KHO_THEO_VI_TRI(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "MaKho,TenKho,MaPT,TenPT,QuyCach,TenViTri,sDVT,TonDK,sNhap,sXuat,ChuyenDi,ChuyenDen,TonCK,Tong,STT,ThoiGian ,Part_No,Gia_Tri,Ton_Min,Ten_Class,T1,T2,T3,T4,T5,T6,T7)" & _
                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sMaKho & "',N'" & sTenKho & "',N'" & sMaPT & "',N'" & sTenPT & "',N'" & sQuyCach & "',N'" & sTenViTri & "',N'" & sDVT & "',N'" & sTonDK & "',N'" & sNhap & "'," & _
            "N'" & sXuat & "',N'" & sChuyenDi & "',N'" & sChuyenDen & "',N'" & sTonCK & "',N'" & sTong & "',N'" & sSTT & "',N'" & ThoiGian & "'" & ",N'" & Part_no & "'" & ",N'" & Gia_Tri & "'" & ",N'" & Ton_Min & "'" & ",N'" & Ten_Class & "'" & ",N'" & T1 & "'" & ",N'" & T2 & "'" & ",N'" & T3 & "'" & ",N'" & T4 & "'" & ",N'" & T5 & "'" & ",N'" & T6 & "'" & ",N'" & T7 & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


    End Sub

    Sub ShowrptCHI_PHI_BAO_TRI_THEO_LOAI_TB()
        Dim str As String = "", strLoai_TB As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_LOAI_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")

        If cboLoaiTB_CP.SelectedValue.ToString <> "-1" Then strLoai_TB = " AND (dbo.NHOM_MAY.MS_LOAI_MAY = '" & cboLoaiTB_CP.SelectedValue & "') "

        str = "SELECT TEN_LOAI_MAY, MS_NHOM_MAY, TEN_NHOM_MAY, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
              "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_LOAI_TB " & _
              "FROM (SELECT  dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, 0 AS CHI_PHI_HANG_NGAY " & _
                    "FROM    dbo.MAY INNER JOIN " & _
                            "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                            "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
                            " WHERE dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >=3 AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "' AND dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')"
        '"WHERE  (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strLoai_TB.Length > 0 Then str = str & strLoai_TB & " "

        str = str & "UNION " & _
                    "SELECT dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, '' ,0,0,0,0,0, " & _
                            "ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC,0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0) AS CHI_PHI_HANG_NGAY " & _
                    "FROM dbo.MAY INNER JOIN " & _
                         "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                         "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV " & _
                         " WHERE  (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"  '(dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "
        '"WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strLoai_TB.Length > 0 Then str = str & strLoai_TB

        str = str & ") TMP GROUP BY TEN_LOAI_MAY, MS_NHOM_MAY, TEN_NHOM_MAY"


        'str = "SELECT MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY,SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DV, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '      "INTO rptCHI_PHI_BAO_TRI_THEO_LOAI_TB " & _
        '      "FROM(SELECT dbo.MAY.MS_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY,dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
        '                  "dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI,dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG," & _
        '                  "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU,dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV," & _
        '                  "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC,(ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC, 0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0)) AS CHI_PHI_HANG_NGAY " & _
        '           "FROM dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
        '                  "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON " & _
        '                  "dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV RIGHT OUTER JOIN " & _
        '                  "dbo.MAY INNER JOIN " & _
        '                  "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '                  "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '                  "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '                  "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI ON " & _
        '                  "dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY = dbo.MAY.MS_MAY " & _
        '           "WHERE dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "' "
        ''"WHERE (dbo.NHOM_MAY.MS_LOAI_MAY = 'AAAA') AND (dbo.MAY.MS_NHOM_MAY = 'SSSSSS')"

        'If cboLoaiTB_CP.SelectedValue.ToString <> "-1" Then str = str & " AND (dbo.NHOM_MAY.MS_LOAI_MAY = '" & cboLoaiTB_CP.SelectedValue & "') "

        'str = str & ") TMP GROUP BY MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_BAO_TRI_THEO_LOAI_TB")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB()
        ReportPreview("reports/rptCHI_PHI_BAO_TRI_THEO_LOAI_TB.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_LOAI_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tieude", commons.Modules.TypeLanguage)
        Dim sMaLoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "MaLoaiMay", commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", commons.Modules.TypeLanguage)
        Dim PhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "PhieuBT", commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDenNam_TKCP.Text & " " & dtpDenNam_TKCP.Value

        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaLoaiMay nvarchar(20)," & _
              "TenNhomMay nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),PhieuBT nvarchar(30),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_LOAI_TB(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
              "MaLoaiMay,TenNhomMay,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,PhieuBT,DKLoc)" & _
              "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaLoaiMay & "',N'" & sTenNhomMay & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & PhieuBT & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptCHI_PHI_BAO_TRI_THEO_NHOM_TB()
        Dim str As String = "", strNhom_TB As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")

        If cboNhomTB_CP.SelectedValue.ToString <> "-1" Then strNhom_TB = " AND (dbo.NHOM_MAY.MS_NHOM_MAY = '" & cboNhomTB_CP.SelectedValue & "') "

        str = "SELECT MS_MAY, TEN_NHOM_MAY, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
              "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_NHOM_TB " & _
              "FROM (SELECT  dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, 0 AS CHI_PHI_HANG_NGAY " & _
                    "FROM    dbo.MAY INNER JOIN " & _
                            "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                            "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
                            " WHERE dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >=3 AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "' AND dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')"
        '"WHERE  (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strNhom_TB.Length > 0 Then str = str & strNhom_TB & " "

        str = str & "UNION " & _
                    "SELECT dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, '' ,0,0,0,0,0, " & _
                            "ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC,0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0) AS CHI_PHI_HANG_NGAY " & _
                    "FROM dbo.MAY INNER JOIN " & _
                         "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                         "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV " & _
                         " WHERE  (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"  '(dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "
        '"WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strNhom_TB.Length > 0 Then str = str & strNhom_TB

        str = str & ") TMP GROUP BY MS_MAY, TEN_NHOM_MAY"

        'str = "SELECT MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY,SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DV, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '      "INTO rptCHI_PHI_BAO_TRI_THEO_NHOM_TB " & _
        '      "FROM(SELECT dbo.MAY.MS_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, " & _
        '                   "(ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC,0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0)) AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY INNER JOIN " & _
        '                   "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '                   "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI LEFT OUTER JOIN " & _
        '                   "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY " & _
        '           "WHERE  dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "' "

        ''"WHERE (dbo.NHOM_MAY.MS_LOAI_MAY = 'AAAA') AND (dbo.MAY.MS_NHOM_MAY = 'SSSSSS')"

        'If cboNhomTB_CP.SelectedValue.ToString <> "-1" Then str = str & "AND (dbo.NHOM_MAY.MS_NHOM_MAY = '" & cboNhomTB_CP.SelectedValue & "')"
        'str = str & ") TMP GROUP BY MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_BAO_TRI_THEO_NHOM_TB")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB()
        ReportPreview("reports/rptCHI_PHI_BAO_TRI_THEO_NHOM_TB.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_NHOM_TB", "Tieude", commons.Modules.TypeLanguage)
        Dim sMaSoMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "MaSoMay", commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", commons.Modules.TypeLanguage)
        Dim sDKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDennam.Text & " " & dtpDenNam_TKCP.Value

        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaSoMay nvarchar(20)," & _
              "TenNhomMay nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
              "MaSoMay,TenNhomMay,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,DKLoc)" & _
              "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaSoMay & "',N'" & sTenNhomMay & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & sDKLoc & " ')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI()
        Dim str As String = "", strLoai_BT As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        If cboLoaiBT_CP.SelectedValue.ToString <> "-1" And cboLoaiTB_CP.SelectedValue.ToString <> "-1" Then
            strLoai_BT = strLoai_BT & "AND (dbo.PHIEU_BAO_TRI.MS_LOAI_BT = " & cboLoaiBT_CP.SelectedValue & " AND dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB_CP.SelectedValue & "')"
        ElseIf cboLoaiBT_CP.SelectedValue.ToString = "-1" And cboLoaiTB_CP.SelectedValue.ToString <> "-1" Then
            strLoai_BT = strLoai_BT & "AND (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB_CP.SelectedValue & "')"
        ElseIf cboLoaiTB_CP.SelectedValue.ToString = "-1" And cboLoaiBT_CP.SelectedValue.ToString <> "-1" Then
            strLoai_BT = strLoai_BT & "AND (dbo.PHIEU_BAO_TRI.MS_LOAI_BT = '" & cboLoaiBT_CP.SelectedValue & "')"
        End If

        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")

        '' '' '' KHÔNG XÓA CODE NÀY

        'TÍNH BÁO CÁO BẢO TRÌ  HIỂN THỊ THEO NGÀY SỬ DỤNG REPORT rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI_CHI_TIẾT
        str = "SELECT MS_MAY, TEN_LOAI_BT, NGAY_LAP, TEN_NHOM_MAY, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, " & _
                      "SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, " & _
                      "SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
              "INTO [dbo].rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI " & _
              "FROM (SELECT dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_LAP, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
                           "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
                           "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, 0 AS CHI_PHI_HANG_NGAY " & _
              "FROM dbo.MAY INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI INNER JOIN " & _
                    "dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
                    "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                    "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY " & _
                    " WHERE dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >=3 AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "' AND dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')"
        '"WHERE (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strLoai_BT.Length > 0 Then str = str & strLoai_BT & " "
        str = str & "GROUP BY dbo.MAY.MS_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
                             "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
                             "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_LAP, dbo.NHOM_MAY.TEN_NHOM_MAY "
        ' "UNION " & _
        ' "SELECT dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_LAP, dbo.NHOM_MAY.TEN_NHOM_MAY, 0, 0, 0, 0, 0, ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC, 0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT, 0) AS CHI_PHI_HANG_NGAY " & _
        ' "FROM   dbo.MAY INNER JOIN " & _
        '        "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '        "dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
        '        "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '        "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '        "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
        '        "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN " & _
        '        "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
        '"WHERE  (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"  '(dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        'If strLoai_BT.Length > 0 Then str = str & strLoai_BT & " "
        str = str & ") TMP GROUP BY MS_MAY, TEN_LOAI_BT, NGAY_LAP, TEN_NHOM_MAY"

        'TÍNH BÁO CÁO BẢO TRÌ KHÔNG HIỂN THỊ THEO NGÀY SỬ DỤNG REPORT rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI
        '' '' ''str = "SELECT MS_MAY, TEN_LOAI_BT, TEN_NHOM_MAY, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, " & _
        '' '' ''              "SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, " & _
        '' '' ''              "SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '' '' ''      "INTO rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI " & _
        '' '' ''      "FROM (SELECT dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
        '' '' ''                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
        '' '' ''                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, 0 AS CHI_PHI_HANG_NGAY " & _
        '' '' ''      "FROM dbo.MAY INNER JOIN " & _
        '' '' ''            "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '' '' ''            "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI INNER JOIN " & _
        '' '' ''            "dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
        '' '' ''            "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '' '' ''            "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY " & _
        '' '' ''      "WHERE (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        '' '' ''If strLoai_BT.Length > 0 Then str = str & strLoai_BT & " "
        '' '' ''str = str & "GROUP BY dbo.MAY.MS_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
        '' '' ''                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
        '' '' ''                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHOM_MAY.TEN_NHOM_MAY " & _
        '' '' ''      "UNION " & _
        '' '' ''      "SELECT dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHOM_MAY.TEN_NHOM_MAY, '', 0, 0, 0, 0, ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC, 0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT, 0) AS CHI_PHI_HANG_NGAY " & _
        '' '' ''      "FROM   dbo.MAY INNER JOIN " & _
        '' '' ''             "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '' '' ''             "dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
        '' '' ''             "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '' '' ''             "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '' '' ''             "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
        '' '' ''             "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN " & _
        '' '' ''             "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
        '' '' ''     "WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        '' '' ''If strLoai_BT.Length > 0 Then str = str & strLoai_BT & " "
        '' '' ''str = str & ") TMP GROUP BY MS_MAY, TEN_LOAI_BT, TEN_NHOM_MAY"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI()
        '        ReportPreview("reports/rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI.rpt")
        ReportPreview("reports/rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI_CHI_TIET.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI", "TieuDe", commons.Modules.TypeLanguage)
        Dim sMaSoMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "MaSoMay", commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", commons.Modules.TypeLanguage)
        Dim sTenLoaiBT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI", "LoaiBT", commons.Modules.TypeLanguage)
        Dim sPhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI", "PhieuBT", commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDenNam_TKCP.Text & " " & dtpDenNam_TKCP.Value
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", commons.Modules.TypeLanguage)
        Dim Ngaylap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayLap", commons.Modules.TypeLanguage)
        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaSoMay nvarchar(20)," & _
              "TenNhomMay nvarchar(30),NgayLap nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),LoaiBT nvarchar(30),PhieuBT nvarchar(30),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
              "MaSoMay,TenNhomMay,NgayLap,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,LoaiBT,PhieuBT,DKLoc)" & _
              "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaSoMay & "',N'" & sTenNhomMay & "',N'" & Ngaylap & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & sTenLoaiBT & "',N'" & sPhieuBT & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        Dim str As String = "", strDayChuyen As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        If cboDayChuyenSXTB_CP.SelectedValue.ToString <> "-1" Then strDayChuyen = " AND (dbo.MAY_HE_THONG.MS_HE_THONG = '" & cboDayChuyenSXTB_CP.SelectedValue & "') "

        'str = "SELECT MS_MAY, TEN_HE_THONG, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '      "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN " & _
        '      "FROM (SELECT dbo.MAY.MS_MAY, dbo.HE_THONG.TEN_HE_THONG, MAX(dbo.MAY_HE_THONG.NGAY_NHAP) AS NGAY_NHAP, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC,0 AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY_HE_THONG INNER JOIN " & _
        '                   "dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
        '                   "dbo.MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI ON " & _
        '                   "dbo.MAY_HE_THONG.MS_MAY = dbo.MAY.MS_MAY " & _
        '            "WHERE (dbo.MAY_HE_THONG.NGAY_NHAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        'If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "

        'str = str & "GROUP BY dbo.HE_THONG.TEN_HE_THONG, dbo.MAY.MS_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, " & _
        '                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC " & _
        '            "UNION SELECT dbo.MAY_HE_THONG.MS_MAY, '' as TEN_HE_THONG, '', 0, 0, 0, 0, 0, ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC, 0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT, 0) AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY_HE_THONG INNER JOIN " & _
        '                 "dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
        '                 "dbo.MAY INNER JOIN " & _
        '                 "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
        '                 "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV ON " & _
        '                 "dbo.MAY_HE_THONG.MS_MAY = dbo.MAY.MS_MAY " & _
        '            "WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        'If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "

        'str = str & ") TMP GROUP BY MS_MAY, TEN_HE_THONG"
        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")



        str = "  SELECT MS_MAY ,MS_HE_THONG, TEN_HE_THONG ,CASE WHEN SUM ( CHI_PHI_PHU_TUNG) IS NULL THEN 0 ELSE SUM ( CHI_PHI_PHU_TUNG) END AS CHI_PHI_PHU_TUNG  , CASE WHEN SUM ( CHI_PHI_VAT_TU ) IS NULL THEN 0 ELSE SUM ( CHI_PHI_VAT_TU ) END AS CHI_PHI_VAT_TU , " & _
                " CASE WHEN SUM (CHI_PHI_NHAN_CONG) IS NULL THEN 0 ELSE SUM (CHI_PHI_NHAN_CONG) END AS CHI_PHI_NHAN_CONG , CASE WHEN SUM (CHI_PHI_DV ) IS NULL THEN 0 ELSE SUM (CHI_PHI_DV ) END AS CHI_PHI_DV , CASE WHEN SUM (CHI_PHI_KHAC ) IS NULL THEN 0 ELSE SUM (CHI_PHI_KHAC ) END AS CHI_PHI_KHAC , CASE WHEN SUM (CHI_PHI_HANG_NGAY) IS NULL THEN 0 ELSE SUM (CHI_PHI_HANG_NGAY)END AS CHI_PHI_HANG_NGAY " & _
                "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN " & _
                " FROM ( SELECT     dbo.PHIEU_BAO_TRI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, " & _
                " SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU) " & _
                " AS CHI_PHI_VAT_TU, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, " & _
                "  SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV) AS CHI_PHI_DV, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC) AS CHI_PHI_KHAC , 0 AS CHI_PHI_HANG_NGAY " & _
                " FROM         dbo.PHIEU_BAO_TRI INNER JOIN " & _
                " dbo.MAY_HE_THONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                " dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
                " INNER Join " & _
                " (Select dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, Max(dbo.MAY_HE_THONG.NGAY_NHAP) as NGAY " & _
                " From dbo.PHIEU_BAO_TRI " & _
                " INNER JOIN dbo.MAY_HE_THONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY " & _
                " WHERE dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= dbo.MAY_HE_THONG.NGAY_NHAP "
        If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "
        str = str & " Group by dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_BD_KH)A " & _
                " ON PHIEU_BAO_TRI.MS_MAY = A.MS_MAY AND PHIEU_BAO_TRI.NGAY_BD_KH = A.NGAY_BD_KH AND MAY_HE_THONG.NGAY_NHAP = A.NGAY " & _
                " GROUP BY dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, dbo.MAY_HE_THONG.NGAY_NHAP, " & _
                " dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, dbo.HE_THONG.MS_HE_THONG, dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT " & _
                "HAVING      (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >= 3) AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "') AND " & _
                " (dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')" & _
                "UNION SELECT     dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, 0 as CHI_PHI_PHU_TUNG , 0 AS CHI_PHI_VT  , 0 AS CHI_PHI_NC , " & _
                " 0 AS CHI_PHI_DV , 0 AS CHI_PHI_KHAC , SUM ( CASE WHEN dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT IS NULL THEN 0 ELSE dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT END + CASE WHEN dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC IS NULL THEN 0 ELSE dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC END) AS CHI_PHI_HANG_NGAY " & _
                " FROM         dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV INNER JOIN " & _
                " dbo.MAY_HE_THONG INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY " & _
                " INNER JOIN ( " & _
                " SELECT     dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY,dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, MAX (dbo.MAY_HE_THONG.NGAY_NHAP) AS NGAY_NHAP " & _
                " FROM         dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV INNER JOIN " & _
                " dbo.MAY_HE_THONG INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY  " & _
                " WHERE dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= dbo.MAY_HE_THONG.NGAY_NHAP AND (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"
        If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "
        str = str & " GROUP BY dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY,dbo.CONG_VIEC_HANG_NGAY.NGAY_TH ) A " & _
                " ON A.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY AND A.NGAY_TH =  dbo.CONG_VIEC_HANG_NGAY.NGAY_TH AND A.NGAY_NHAP = dbo.MAY_HE_THONG.NGAY_NHAP " & _
                " group by dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG  )TMP " & _
                " GROUP BY TMP.MS_MAY, MS_HE_THONG, TMP.TEN_HE_THONG "

        '" WHERE MS_HE_THONG = '" + cboDayChuyenSXTB_CP.SelectedValue "'"& _
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        ReportPreview("reports/rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "Tieude", commons.Modules.TypeLanguage)
        Dim sMaSoMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "MaSoMay", commons.Modules.TypeLanguage)
        Dim sTenLoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "TenLoaiMay", commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", commons.Modules.TypeLanguage)
        Dim sTenHeThong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "TenHeThong", commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDenNam_TKCP.Text & " " & dtpDenNam_TKCP.Value

        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaSoMay nvarchar(30)," & _
              "TenLoaiMay nvarchar(30),TenNhomMay nvarchar(30),TenHeThong nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),PhieuBT nvarchar(30),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe,MaSoMay, " & _
              "TenLoaiMay,TenNhomMay,TenHeThong,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,DKLoc)" & _
              "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaSoMay & "',N'" & sTenLoaiMay & "',N'" & sTenNhomMay & "',N'" & sTenHeThong & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Public Sub printnhanvien()
        Dim obj As New Commons.clsprintnhanvien
        Dim obj1 As New commons.OSystems
        Dim dt As New DataTable
        obj1.XoaTable("dbo.rptBaocaocongnhan")
        If Me.cbodonvi.SelectedValue = "-1" Then
            dt = obj.Getbaocaonhanvien(Me.cbodonvi.SelectedValue, Me.cboban.SelectedValue, 1)
        Else
            dt = obj.Getbaocaonhanvien(Me.cbodonvi.SelectedValue, Me.cboban.SelectedValue, 0)
        End If
        XuatExcel()

    End Sub

    Private Sub RefeshLanguageReport22()
        Dim TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TIEU_DE", commons.Modules.TypeLanguage)
        SO_DDH = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_DDH", commons.Modules.TypeLanguage)
        SO_PR = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_PR", commons.Modules.TypeLanguage)
        LAP_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "LAP_NGAY", commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "STT", commons.Modules.TypeLanguage)
        MA_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "MA_HANG", commons.Modules.TypeLanguage)
        TEN_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TEN_HANG", commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "DVT", commons.Modules.TypeLanguage)
        SO_LUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_LUONG", commons.Modules.TypeLanguage)
        DON_GIA = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "DON_GIA", commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TONG_CONG", commons.Modules.TypeLanguage)
        TG_GIAO_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TG_GIAO_HANG", commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TRANG", commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl(commons.Modules.TypeLanguage_ nvarchar(50), TIEU_DE_ nvarchar(50),SO_DDH_ nvarchar(50),SO_PR_ nvarchar(50),LAP_NGAY_ nvarchar(50),STT_ nvarchar(50),MA_HANG_ nvarchar(50),TEN_HANG_ nvarchar(50),DVT_ nvarchar(50),SO_LUONG_ nvarchar(50), DON_GIA_ nvarchar(50), TONG_CONG_ nvarchar(50), TG_GIAO_HANG_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procInsertRptDDH_DA_HT", commons.Modules.TypeLanguage, TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG)

    End Sub

    Sub CreateData22()

        RefeshHeaderReport()
        RefeshLanguageReport22()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procRptDON_DAT_HANG_CHUA_HT", commons.Modules.TypeLanguage)

    End Sub

    Sub Printpreview22()

        Dim dt As New DataTable
        commons.Modules.SQLString = "SELECT * FROM dbo.rptDON_DAT_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Windows.Forms.Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDonDatHangDaHT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT")
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT_lbl")

    End Sub


    Private Sub RefeshLanguageReport21()
        Dim TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "TIEU_DE", commons.Modules.TypeLanguage)
        SO_DDH = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_DDH", commons.Modules.TypeLanguage)
        SO_PR = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_PR", commons.Modules.TypeLanguage)
        LAP_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "LAP_NGAY", commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "STT", commons.Modules.TypeLanguage)
        MA_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "MA_HANG", commons.Modules.TypeLanguage)
        TEN_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "TEN_HANG", commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "DVT", commons.Modules.TypeLanguage)
        SO_LUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_LUONG", commons.Modules.TypeLanguage)
        DON_GIA = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "DON_GIA", commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "TONG_CONG", commons.Modules.TypeLanguage)
        TG_GIAO_HANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "TG_GIAO_HANG", commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDDH_DA_HT", "TRANG", commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE [dbo].rptDON_DAT_HANG_DA_HT_lbl(commons.Modules.TypeLanguage_ nvarchar(50),TIEU_DE_ nvarchar(50),SO_DDH_ nvarchar(50),SO_PR_ nvarchar(50),LAP_NGAY_ nvarchar(50),STT_ nvarchar(50),MA_HANG_ nvarchar(50),TEN_HANG_ nvarchar(50),DVT_ nvarchar(50),SO_LUONG_ nvarchar(50), DON_GIA_ nvarchar(50), TONG_CONG_ nvarchar(50), TG_GIAO_HANG_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procInsertRptDDH_DA_HT", commons.Modules.TypeLanguage, TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG)

    End Sub

    Sub CreateData21()

        RefeshHeaderReport()
        RefeshLanguageReport21()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procRptDON_DAT_HANG_DA_HT", commons.Modules.TypeLanguage)

    End Sub

    Sub Printpreview21()

        Dim dt As New DataTable
        commons.Modules.SQLString = "SELECT * FROM dbo.rptDON_DAT_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Windows.Forms.Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDonDatHangDaHT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT")
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT_lbl")

    End Sub


    Sub CreateData20()

        'RefeshHeaderReport()
        'RefeshLanguageReport18()
        commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

        SqlText = "SELECT     DE_XUAT_MUA_HANG.SO_DE_XUAT, DON_VI.TEN_DON_VI, DE_XUAT_MUA_HANG.NGAY, DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, " & _
        "IC_PHU_TUNG.TEN_PT, DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG, DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU " & _
        "INTO [dbo].rptDE_XUAT_MUA_HANG_DA_HT " & _
        "FROM         DE_XUAT_MUA_HANG INNER JOIN " & _
        "DE_XUAT_MUA_HANG_CHI_TIET ON DE_XUAT_MUA_HANG.SO_DE_XUAT = DE_XUAT_MUA_HANG_CHI_TIET.SO_DE_XUAT INNER JOIN " & _
        "IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
        "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
        "DON_VI ON DE_XUAT_MUA_HANG.MS_DON_VI = DON_VI.MS_DON_VI " & _
        "WHERE DUYET=0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub Printpreview20()

        Dim dt As New DataTable
        commons.Modules.SQLString = "SELECT * FROM dbo.rptDE_XUAT_MUA_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Windows.Forms.Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDeXuatMuaHangChuaHT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

    End Sub


    Sub CreateData19()

        'RefeshHeaderReport()
        'RefeshLanguageReport18()
        commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

        SqlText = "SELECT     DE_XUAT_MUA_HANG.SO_DE_XUAT, DON_VI.TEN_DON_VI, DE_XUAT_MUA_HANG.NGAY, DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, " & _
        "IC_PHU_TUNG.TEN_PT, DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG, DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU " & _
        "INTO [dbo].rptDE_XUAT_MUA_HANG_DA_HT " & _
        "FROM         DE_XUAT_MUA_HANG INNER JOIN " & _
        "DE_XUAT_MUA_HANG_CHI_TIET ON DE_XUAT_MUA_HANG.SO_DE_XUAT = DE_XUAT_MUA_HANG_CHI_TIET.SO_DE_XUAT INNER JOIN " & _
        "IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
        "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
        "DON_VI ON DE_XUAT_MUA_HANG.MS_DON_VI = DON_VI.MS_DON_VI " & _
        "WHERE DUYET=1"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub Printpreview19()

        Dim dt As New DataTable
        commons.Modules.SQLString = "SELECT * FROM dbo.rptDE_XUAT_MUA_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            'Cursor = Windows.Forms.Cursors.Default
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDeXuatMuaHangDaHT.rpt")
        'Cursor = Windows.Forms.Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

    End Sub

    Private Sub RefeshLanguageReport18()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TIEU_DE", commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TU_NGAY", commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DEN_NGAY", commons.Modules.TypeLanguage)
        LOAI_BAO_TRI = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "LOAI_BAO_TRI", commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DIA_DIEM", commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "STT", commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "YEU_CAU", commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "MS_TB", commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TEN_TB", commons.Modules.TypeLanguage)
        HINH_THUC_BT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "HINH_THUC_BT", commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "NGAY_BD", commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", " NGAY_KT", commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_TRUOC_BT", commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_SAU_BT", commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TRANG", commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP(TIEU_DE_ nvarchar(50),TU_NGAY_ nvarchar(50),DEN_NGAY_ nvarchar(50),LOAI_BAO_TRI_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50),HINH_THUC_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSPBTDaNghiemThuTLBT", TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData18()

        RefeshHeaderReport()
        RefeshLanguageReport18()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)


        SqlText = "SELECT  dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HINH_THUC_BAO_TRI.TEN_HT_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, '" & Format(dtpTuNgay.Value.Date, "dd/MM/yyyy") & "' AS TU_NGAY, '" & Format(dtpDenNgay.Value.Date, "dd/MM/yyyy") & "' AS DEN_NGAY    INTO [dbo].rptDSPBTChuaNghiemThuTLBT_TMP       FROM dbo.NHA_XUONG INNER JOIN dbo.V_MAY_NHA_XUONG_MAX ON dbo.NHA_XUONG.MS_N_XUONG = dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG INNER JOIN dbo.LOAI_BAO_TRI INNER JOIN dbo.HINH_THUC_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_HT_BT = dbo.HINH_THUC_BAO_TRI.MS_HT_BT INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1, '" & date_DN & "')) AND (dbo.LOAI_BAO_TRI.TEN_LOAI_BT = N'" & cboLoaiBT.SelectedValue.ToString() & "') order by NGAY_BD_KH desc"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub
    Sub Printpreview18()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSPBTChuaNghiemThuTLBT_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDSPBTChuaNghiemThuTLBT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport17()
        Dim NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG As String
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_IN", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "DEN_NGAY", Commons.Modules.TypeLanguage)
        NHAN_VIEN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NHAN_VIEN", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "STT", Commons.Modules.TypeLanguage)
        PHIEU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "PHIEU_BT", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TEN_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_KT", Commons.Modules.TypeLanguage)
        TINH_TRANG_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TINH_TRANG_TRUOC_BT", Commons.Modules.TypeLanguage)
        TINH_TRANG_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TINH_TRANG_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(50), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), NHAN_VIEN_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),PHIEU_BT_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TINH_TRANG_TRUOC_BT_ nvarchar(50), TINH_TRANG_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCYCBTChuaNghiemThuTheoNV", NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG)

    End Sub

    Sub CreateData17()

        RefeshHeaderReport()
        RefeshLanguageReport17()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        'Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        'Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        'Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String ' = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        'Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        'Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        'Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String '= (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        If rdNV_LuaChon.Checked = True Then
            SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY          into [dbo].rptDSCYCBTChuaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT<3) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "'))   AND (dbo.CONG_NHAN.MS_CONG_NHAN = '" & cboNVien.SelectedValue & "') order by NGAY_BD_KH desc"
        Else
            SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY          into [dbo].rptDSCYCBTChuaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT<3) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) order by NGAY_BD_KH desc"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview17()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCYCBTChuaNghiemThuTheoNV_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports\rptDSCYCBTChuaNghiemThuTheoNV.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RefeshLanguageReport16()
        Dim NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG As String
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_IN", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "DEN_NGAY", Commons.Modules.TypeLanguage)
        NHAN_VIEN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NHAN_VIEN", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "STT", Commons.Modules.TypeLanguage)
        PHIEU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "PHIEU_BT", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TEN_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_KT", Commons.Modules.TypeLanguage)
        TINH_TRANG_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TINH_TRANG_TRUOC_BT", Commons.Modules.TypeLanguage)
        TINH_TRANG_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TINH_TRANG_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), NHAN_VIEN_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),PHIEU_BT_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TINH_TRANG_TRUOC_BT_ nvarchar(50), TINH_TRANG_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCYCBTDaNghiemThuTheoNV", NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG)

    End Sub


    Sub CreateData16()

        RefeshHeaderReport()
        RefeshLanguageReport16()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        'Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        'Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        'Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String '= (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        'Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        'Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        'Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String '= (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        If rdNV_LuaChon.Checked = True Then
            SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY          into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NOT NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "')   AND (dbo.CONG_NHAN.MS_CONG_NHAN = '" & cboNVien.SelectedValue & "') order by NGAY_BD_KH"
        Else
            SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY          into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NOT NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') order by NGAY_BD_KH"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview16()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCYCBTDaNghiemThuTheoNV_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDSCYCBTDaNghiemThuTheoNV.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RefeshLanguageReport15()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DEN_NGAY", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DIA_DIEM", Commons.Modules.TypeLanguage)
        NHOM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NHOM_TB", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "MS_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP(TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), DIA_DIEM_ nvarchar(50),NHOM_TB_ nvarchar(50),TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50),TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCPBTTLoaiMay_DiaDiem", TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData15()

        RefeshHeaderReport()
        RefeshLanguageReport15()

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        If rdLMDaNghiemThu.Checked Then
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT > 2)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE    (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "') AND  (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT > 2) order by NGAY_BD_KH desc"
            End If
        Else
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT < 3)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "') AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT < 3) order by NGAY_BD_KH desc"
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub Printpreview15()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCPBTTLoaiMay_DiaDiem_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Cursor = Windows.Forms.Cursors.WaitCursor

        Call ReportPreview("reports\rptDSCPBTTLoaiMay_DiaDiem.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RefeshLanguageReport14()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "DEN_NGAY", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "DIA_DIEM", Commons.Modules.TypeLanguage)
        NHOM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NHOM_TB", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "MS_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP(TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), DIA_DIEM_ nvarchar(50),NHOM_TB_ nvarchar(50),TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50),TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCPBTTLoaiMay_LoaiTB", TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData14()

        RefeshHeaderReport()
        RefeshLanguageReport14()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        If rdLMDaNghiemThu.Checked Then
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT CAST('" & date_TN & "' AS DATETIME(8)) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME(8)) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS not  NULL)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT CAST('" & date_TN & "' AS DATETIME(8)) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME(8)) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "')AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS not NULL) order by NGAY_BD_KH desc"
            End If
        Else
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT DISTINCT CAST('" & date_TN & "' AS DATETIME(8)) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME(8)) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS  NULL)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT  DISTINCT CAST('" & date_TN & "' AS DATETIME(8)) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME(8)) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "')AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS  NULL) order by NGAY_BD_KH desc"
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview14()
        Try
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCPBTTLoaiMay_LoaiTB_TMP")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()
        Catch ex As Exception
        End Try
        Call ReportPreview("reports\rptDSCPBTTLoaiMay_LoaiTB.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RefeshLanguageReport13()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TIEU_DE1", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + dtpTuNgay.Text
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + dtpDenNgay.Text
        LOAI_BAO_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "LOAI_BAO_TRI", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TEN_TB", Commons.Modules.TypeLanguage)
        HINH_THUC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "HINH_THUC_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", " NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP(TIEU_DE_ nvarchar(250),TU_NGAY_ nvarchar(50),DEN_NGAY_ nvarchar(50),LOAI_BAO_TRI_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50),HINH_THUC_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSPBTDaNghiemThuTLBT", TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData13()

        RefeshHeaderReport()
        RefeshLanguageReport13()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        SqlText = "SELECT  dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HINH_THUC_BAO_TRI.TEN_HT_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, '" & date_TN & "' AS TU_NGAY, '" & date_DN & "' AS DEN_NGAY       INTO [dbo].rptDSPBTDaNghiemThuTLBT_TMP     FROM dbo.NHA_XUONG INNER JOIN dbo.V_MAY_NHA_XUONG_MAX ON dbo.NHA_XUONG.MS_N_XUONG = dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG INNER JOIN dbo.LOAI_BAO_TRI INNER JOIN dbo.HINH_THUC_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_HT_BT = dbo.HINH_THUC_BAO_TRI.MS_HT_BT INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NOT NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd( day,1,'" & date_DN & "')) AND (dbo.LOAI_BAO_TRI.TEN_LOAI_BT = N'" & cboLoaiBT.SelectedValue.ToString() & "') order by NGAY_BD_KH DESC"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub
    Sub Printpreview13()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSPBTDaNghiemThuTLBT_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()


        Call ReportPreview("reports\rptDSPBTDaNghiemThuTLBT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Sub CreateData12()

        RefeshLanguageReport12()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSBPChiuPhi_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        'SqlText = "SELECT dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.NGAY_NHAP, dbo.BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI INTO  [dbo].rptDSBPChiuPhi_TMP FROM dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN    dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN   dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.MS_MAY INNER JOIN   dbo.BO_PHAN_CHIU_PHI ON dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.MS_BP_CHIU_PHI = dbo.BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI"

        SqlText = "SELECT dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.NGAY_NHAP, " & _
                          "dbo.BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI, dbo.NHA_XUONG.Ten_N_XUONG " & _
                  "INTO  [dbo].rptDSBPChiuPhi_TMP FROM dbo.MAY INNER JOIN " & _
                          "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                          "dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " & _
                          "dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.MS_MAY INNER JOIN " & _
                          "dbo.BO_PHAN_CHIU_PHI ON dbo.V_MAY_BO_PHAN_CHIU_PHI_MAX.MS_BP_CHIU_PHI = dbo.BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI INNER JOIN " & _
                          "(SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY) TAM ON TAM.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                          "dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY AND TAM.NGAY_NHAP = dbo.MAY_NHA_XUONG.NGAY_NHAP INNER JOIN " & _
                          "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG"

        If cboNhaxuong.SelectedValue.ToString <> "-1" Then SqlText = SqlText & " WHERE NHA_XUONG.TEN_N_XUONG=N'" & cboNhaxuong.Text & "'"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub
    Sub Printpreview12()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSBPChiuPhi_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDSBPChiuPhi.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSBPChiuPhi_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeDSBPChiuPhi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreateDataTB_TheoDC()
        RefeshLanguageReportTB_TheoDC()
        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE dbo.rptDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT dbo.MAY.MS_MAY,dbo.MAY.TEN_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, V_MAY_HE_THONG_MAX.NGAY_NHAP, " & _
                          "dbo.NHA_XUONG.Ten_N_XUONG, dbo.HE_THONG.TEN_HE_THONG " & _
                  "INTO   [dbo].rptDanhsachTB_TheoDayChuyen FROM dbo.MAY INNER JOIN " & _
                          "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                          "dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " & _
                          "(SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP " & _
                          "FROM MAY_NHA_XUONG " & _
                          "GROUP BY MS_MAY) TAM ON TAM.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                          "dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY AND " & _
                          "TAM.NGAY_NHAP = dbo.MAY_NHA_XUONG.NGAY_NHAP INNER JOIN " & _
                          "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " & _
                          "V_MAY_HE_THONG_MAX ON dbo.MAY.MS_MAY = V_MAY_HE_THONG_MAX.MS_MAY INNER JOIN " & _
                          "dbo.HE_THONG ON V_MAY_HE_THONG_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG "

        If cboDayChuyen.SelectedValue <> -1 Then SqlText = SqlText & "WHERE TEN_HE_THONG=N'" & cboDayChuyen.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub PrintpreviewTB_TheoDC()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDanhsachTB_TheoDayChuyen")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDSTB_TheoDayChuyen.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreateTG_NgungMayTheoNam()
        Try
            SqlText = "DROP TABLE dbo.rptTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT DISTINCT dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY," & _
                         "dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU, dbo.NHA_XUONG.Ten_N_XUONG, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, " & _
                         "dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO " & _
                  "INTO [dbo].rptTG_NgungMayTheoNam FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                       "dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                       "dbo.MAY_NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN " & _
                       "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " & _
                       "dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                       "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                       "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY "
        '        If Len(txtTG_TuNam.Text = 4) And Len(txtTG_DenNam.Text) = 4 Then
        'SqlText = SqlText & "WHERE YEAR(dbo.THOI_GIAN_NGUNG_MAY.NGAY) BETWEEN '" & txtTG_TuNam.Text & "' AND '" & txtTG_DenNam.Text & "'"
        'End If
        SqlText = SqlText & "WHERE dbo.THOI_GIAN_NGUNG_MAY.NGAY BETWEEN '" & Format(dtpTu.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDen.Value, "MM/dd/yyyy") & "'"

        '"SELECT dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, V_MAY_HE_THONG_MAX.NGAY_NHAP, " & _
        '                          "dbo.NHA_XUONG.Ten_N_XUONG, dbo.HE_THONG.TEN_HE_THONG " & _
        '                  "INTO   dbo.rptDanhsachTB_TheoDayChuyen FROM dbo.MAY INNER JOIN " & _
        '                          "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '                          "dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " & _
        '                          "(SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP " & _
        '                          "FROM MAY_NHA_XUONG " & _
        '                          "GROUP BY MS_MAY) TAM ON TAM.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
        '                          "dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY AND " & _
        '                          "TAM.NGAY_NHAP = dbo.MAY_NHA_XUONG.NGAY_NHAP INNER JOIN " & _
        '                          "dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN " & _
        '                          "V_MAY_HE_THONG_MAX ON dbo.MAY.MS_MAY = V_MAY_HE_THONG_MAX.MS_MAY INNER JOIN " & _
        '                          "dbo.HE_THONG ON V_MAY_HE_THONG_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG "

        'If cboDayChuyen.SelectedValue <> -1 Then SqlText = SqlText & "WHERE TEN_HE_THONG=N'" & cboDayChuyen.Text & "'"

        If cboTG_LoaiTB.SelectedValue.ToString <> "-1" Then SqlText += " AND dbo.LOAI_MAY.MS_LOAI_MAY='" & cboTG_LoaiTB.SelectedValue.ToString & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub PrintpreviewTG_NgungMayTheoNam()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTG_NgungMayTheoNam")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        RefeshLanguageReportTG_NgungMayTheoNam()
        Call ReportPreview("reports\rptTHOI_GIAN_NGUNG_MAY_THEO_NHIEU_NAM.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreateTG_NgungMayTheoNguyenNhan()
        Try
            SqlText = "DROP TABLE rptTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT THOI_GIAN_NGUNG_MAY.MS_MAY,dbo.MAY.TEN_MAY, NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN, NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.NGAY, " & _
                         "THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_NGAY, THOI_GIAN_NGUNG_MAY.DEN_GIO, " & _
                         "THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, THOI_GIAN_NGUNG_MAY.MS_HE_THONG, HE_THONG.TEN_HE_THONG, " & _
                         "NHA_XUONG.Ten_N_XUONG, THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
                 "INTO [dbo].rptTG_NgungMayTheoNguyenNhan FROM   dbo.MAY INNER JOIN" & _
                     " dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                     " dbo.NGUYEN_NHAN_DUNG_MAY ON " & _
                     " dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " & _
                     " dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                     " dbo.MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN " & _
                     " dbo.NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " & _
                     " WHERE THOI_GIAN_NGUNG_MAY.NGAY>='" & Format(dtpTuNgay5.Value.Date, "dd/MMM/yyyy") & "' AND THOI_GIAN_NGUNG_MAY.DEN_NGAY <'" & Format(dtpDenNgay5.Value.Date, "dd/MMM/yyyy") & "' "

        If cboNguyenNhanNM.SelectedValue.ToString <> "-1" Then SqlText = SqlText & "AND NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN=" & cboNguyenNhanNM.SelectedValue
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub PrintpreviewTG_NgungMayTheoNguyenNhan()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTG_NgungMayTheoNguyenNhan")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        RefeshLanguageReportTG_NgungMayTheoNguyenNhan()
        Call ReportPreview("reports\rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReportTG_NgungMayTheoNam()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeTG_NgungMayTheoNam"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrangIn", Commons.Modules.TypeLanguage)
        Dim DKLoc As String
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TenNhaXuong", Commons.Modules.TypeLanguage)
        Dim TGSuaChua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGSuaChua", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "GhiChu", Commons.Modules.TypeLanguage)
        Dim TuNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuNam", Commons.Modules.TypeLanguage)
        Dim DenNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenNam", Commons.Modules.TypeLanguage)
        Dim TrongNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrongNam", Commons.Modules.TypeLanguage)
        Dim TuKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuKhi", Commons.Modules.TypeLanguage)
        Dim DenKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenKhi", Commons.Modules.TypeLanguage)
        Dim TGNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGNgungMay", Commons.Modules.TypeLanguage)

        'If txtTG_TuNam.Text <> txtTG_DenNam.Text Then
        '    DKLoc = TuNam & " " & txtTG_TuNam.Text & " " & DenNam & " " & txtTG_DenNam.Text
        'ElseIf txtTG_TuNam.Text = txtTG_DenNam.Text Then
        '    DKLoc = TrongNam & " " & txtTG_TuNam.Text
        'End If
        DKLoc = lblTG_TuNam.Text & " " & Format(dtpTu.Value, "dd/MM/yyyy") & "   -   " & lblTG_DenNam.Text & " " & Format(dtpDen.Value, "dd/MM/yyyy")
        str = "Create Table [dbo].rptTieuDeTG_NgungMayTheoNam(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),HeThong nvarchar(30),TenNhaXuong nvarchar(30),TGNgungMay nvarchar(50),TGSuaChua nvarchar(30),GhiChu nvarchar(30),TuNam nvarchar(30),DenNam nvarchar(30),TrongNam nvarchar(30),TuKhi nvarchar(30),DenKhi nvarchar(30),DKLoc nvarchar(255)) " & _
        "Insert into [dbo].rptTieuDeTG_NgungMayTheoNam values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & TGNgungMay & "',N'" & TGSuaChua & "',N'" & GhiChu & "',N'" & TuNam & "',N'" & DenNam & "',N'" & TrongNam & "',N'" & TuKhi & "',N'" & DenKhi & "',N'" & DKLoc & " ')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub RefeshLanguageReportTG_NgungMayTheoNguyenNhan()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeTG_NgungMayTheoNguyenNhan"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "ThietBi", Commons.Modules.TypeLanguage)
        Dim NguyenNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNguyenNhan", "NguyenNhan", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TenNhaXuong", Commons.Modules.TypeLanguage)
        Dim TGSuaChua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TGSuaChua", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "GhiChu", Commons.Modules.TypeLanguage)
        Dim TuKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TuKhi", Commons.Modules.TypeLanguage)
        Dim DenKhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "DenKhi", Commons.Modules.TypeLanguage)
        Dim TG_NgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TG_NgungMay", Commons.Modules.TypeLanguage)
        Dim sDKLoc As String = lblTungay5.Text & " " & Format(dtpTuNgay5.Value.Date, "dd/MM/yyyy") & "  -  " & lblDenngay5.Text & " " & Format(dtpDenNgay5.Value.Date, "dd/MM/yyyy")
        Dim tentb As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTG_NgungMayTheoNam", "TEN_MAY", Commons.Modules.TypeLanguage)

        str = "Create Table [dbo].rptTieuDeTG_NgungMayTheoNguyenNhan(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "ThietBi nvarchar(50),NguyenNhan nvarchar(30),HeThong nvarchar(30),TenNhaXuong nvarchar(30),TGSuaChua nvarchar(30),GhiChu nvarchar(30),TuKhi nvarchar(30),DenKhi nvarchar(30),TG_NgungMay nvarchar(30), DKLoc nvarchar(255),TEN_MAY NVARCHAR(200) ) " & _
        "Insert into [dbo].rptTieuDeTG_NgungMayTheoNguyenNhan values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        ThietBi & "',N'" & NguyenNhan & "',N'" & HeThong & "',N'" & TenNhaXuong & "',N'" & TGSuaChua & "',N'" & GhiChu & "',N'" & TuKhi & "',N'" & DenKhi & "',N'" & TG_NgungMay & "',N'" & sDKLoc & "',N'" & tentb & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    'Private Sub RefeshLanguageReport11()
    '    Dim str As String = ""
    '    Try
    '        str = "Drop table rptTieuDeDSThietBiTheoNoiLapDatHT"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '    Catch ex As Exception
    '    End Try
    '    Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TieuDe", commons.Modules.TypeLanguage)
    '    Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayIn", commons.Modules.TypeLanguage)
    '    Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TrangIn", commons.Modules.TypeLanguage)
    '    Dim NoiLapDat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NoiLapDat", commons.Modules.TypeLanguage)
    '    Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "STT", commons.Modules.TypeLanguage)
    '    Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "ThietBi", commons.Modules.TypeLanguage)
    '    Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "SoThe", commons.Modules.TypeLanguage)
    '    Dim NhomThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NhomThietBi", commons.Modules.TypeLanguage)
    '    Dim HienTrang As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "HienTrang", commons.Modules.TypeLanguage)
    '    Dim NuocSX As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NuocSX", commons.Modules.TypeLanguage)
    '    Dim TyLe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TyLe", commons.Modules.TypeLanguage)
    '    Dim NgayLD As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayLD", commons.Modules.TypeLanguage)
    '    str = "Create table dbo.rptTieuDeDSThietBiTheoNoiLapDatHT(TypeLanguage int, NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
    '    "NoiLapDat nvarchar(50), STT nvarchar(5),ThietBi nvarchar(50), SoThe nvarchar(30),NhomThietBi nvarchar(50),HienTrang nvarchar(80), " & _
    '    "NuocSX nvarchar(60),TyLe nvarchar(90),NgayLD nvarchar(80)) "
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '    str = "Insert into [dbo].rptTieuDeDSThietBiTheoNoiLapDatHT values(" & commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
    '    NoiLapDat & "',N'" & STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & NhomThietBi & "',N'" & HienTrang & "',N'" & NuocSX & "',N'" & TyLe & "',N'" & NgayLD & "')"
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    'End Sub
    Private Sub RefeshLanguageReport12()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeDSBPChiuPhi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "Ngay", Commons.Modules.TypeLanguage)
        Dim BoPhanCP As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "BoPhanCP", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TenNhaXuong", Commons.Modules.TypeLanguage)

        str = "Create Table [dbo].rptTieuDeDSBPChiuPhi(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "STT nvarchar(5),ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),NgayLap nvarchar(30),BoPhanCP nvarchar(50),TenNhaXuong nvarchar(100)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeDSBPChiuPhi values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & NgayLap & "',N'" & BoPhanCP & "',N'" & TenNhaXuong & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Private Sub RefeshLanguageReportTB_TheoDC()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeDanhsachTB_TheoDayChuyen"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "ThietBi", Commons.Modules.TypeLanguage)
        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "Ngay", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsachTB_TheoDayChuyen", "TenNhaXuong", Commons.Modules.TypeLanguage)

        str = "Create Table [dbo].rptTieuDeDanhsachTB_TheoDayChuyen(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "STT nvarchar(5),ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),NgayLap nvarchar(30),HeThong nvarchar(50),TenNhaXuong nvarchar(100) , TenThietBi NVARCHAR (256)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeDanhsachTB_TheoDayChuyen values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & NgayLap & "',N'" & HeThong & "',N'" & TenNhaXuong & "' , N'" & TenThietBi & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub Printpreview11()

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSTBTNLDHienTai_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Dim vtb As DataTable = New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from THONG_TIN_CHUNG"))
        Try
            If vtb.Rows(0)("PRIVATE") = "DHG" Then

                CreateData11_DHG()
                Call ReportPreview("reports\rptDSTBTNLDHienTai_DHG.rpt")
                Cursor = Windows.Forms.Cursors.Default
            Else
                Call ReportPreview("reports\rptDSTBTNLDHienTai.rpt")
                Cursor = Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            Call ReportPreview("reports\rptDSTBTNLDHienTai.rpt")
            Cursor = Windows.Forms.Cursors.Default
        End Try

KetThuc:



        Try
            SqlText = "DROP TABLE dbo.rptDSTBTNLDHienTai_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = "Drop table rptTieuDeDSThietBiTheoNoiLapDatHT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport11()
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeDSThietBiTheoNoiLapDatHT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NoiLapDat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NoiLapDat", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "SoThe", Commons.Modules.TypeLanguage)
        Dim NhomThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NhomThietBi", Commons.Modules.TypeLanguage)
        Dim HienTrang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "HienTrang", Commons.Modules.TypeLanguage)
        Dim NuocSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NuocSX", Commons.Modules.TypeLanguage)
        Dim TyLe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "TyLe", Commons.Modules.TypeLanguage)
        Dim NgayLD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NgayLD", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "MoTa", Commons.Modules.TypeLanguage)
        Dim CongSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "CongSuat", Commons.Modules.TypeLanguage)
        Dim NangSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBTNLDHienTai", "NangSuat", Commons.Modules.TypeLanguage)

        str = "Create table dbo.rptTieuDeDSThietBiTheoNoiLapDatHT(TypeLanguage int, NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "NoiLapDat nvarchar(50), STT nvarchar(5),ThietBi nvarchar(50), SoThe nvarchar(30),NhomThietBi nvarchar(50),HienTrang nvarchar(80), " & _
        "NuocSX nvarchar(60),TyLe nvarchar(90),NgayLD nvarchar(80),MoTa nvarchar(80),CongSuat nvarchar(80),NangSuat nvarchar(80)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeDSThietBiTheoNoiLapDatHT values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        NoiLapDat & "',N'" & STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & NhomThietBi & "',N'" & HienTrang & "',N'" & NuocSX & "',N'" & TyLe & "',N'" & NgayLD & "',N'" & MoTa & "',N'" & CongSuat & "',N'" & NangSuat & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub CreateData11()
        RefeshLanguageReport11()
        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE dbo.rptDSTBTNLDHienTai_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "Drop table rptTieuDeDSBPChiuPhi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        'SqlText = "SELECT  dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG INTO [dbo].rptDSTBTNLDHienTai_TMP FROM  dbo.MAY INNER JOIN  dbo.V_MAY_NHA_XUONG_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN      dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG GROUP BY dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG"

        SqlText = "SELECT dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG,dbo.MAY.MO_TA " & _
          "INTO [dbo].rptDSTBTNLDHienTai_TMP FROM  dbo.MAY INNER JOIN  dbo.V_MAY_NHA_XUONG_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG "

        If cboNhaxuong.SelectedValue.ToString <> "-1" Then SqlText = SqlText & "WHERE NHA_XUONG.TEN_N_XUONG = N'" & cboNhaxuong.Text & "' "
        SqlText = SqlText & " GROUP BY dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG,dbo.MAY.MO_TA"
        SqlText = SqlText & " ORDER BY dbo.NHA_XUONG.Ten_N_XUONG, dbo.MAY.MS_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub


    Sub CreateData11_DHG()
        RefeshLanguageReport11()
        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE dbo.rptDSTBTNLDHienTai_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "Drop table rptTieuDeDSBPChiuPhi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_CongSuatNangSuat")
        Try
        Catch ex As Exception
        End Try

        'SqlText = "SELECT  dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG INTO [dbo].rptDSTBTNLDHienTai_TMP FROM  dbo.MAY INNER JOIN  dbo.V_MAY_NHA_XUONG_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN      dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG GROUP BY dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG"
        'SqlText = "SELECT dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG,dbo.MAY.MO_TA " & _
        '  "INTO [dbo].rptDSTBTNLDHienTai_TMP FROM  dbo.MAY INNER JOIN  dbo.V_MAY_NHA_XUONG_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG "
        SqlText = "SELECT     dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, " & _
                      " dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG, dbo.MAY.MO_TA, " & _
                     " dbo.MAY_THONG_SO_TMP.CONG_SUAT, dbo.MAY_THONG_SO_TMP.NANG_XUAT  INTO [dbo].rptDSTBTNLDHienTai_TMP" & _
                     " FROM  dbo.MAY INNER JOIN " & _
                      " dbo.V_MAY_NHA_XUONG_MAX ON dbo.MAY.MS_MAY = dbo.V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN " & _
                      " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                      " dbo.HIEN_TRANG_SU_DUNG_MAY ON dbo.MAY.MS_HIEN_TRANG = dbo.HIEN_TRANG_SU_DUNG_MAY.MS_HIEN_TRANG INNER JOIN " & _
                      " dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG LEFT OUTER JOIN " & _
                      " dbo.MAY_THONG_SO_TMP ON dbo.MAY.MS_MAY = dbo.MAY_THONG_SO_TMP.MS_MAY "

        If cboNhaxuong.SelectedValue.ToString <> "-1" Then SqlText = SqlText & "WHERE NHA_XUONG.TEN_N_XUONG = N'" & cboNhaxuong.Text & "' "
        SqlText = SqlText & " GROUP BY dbo.MAY.MS_MAY, dbo.MAY.SO_THE, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HIEN_TRANG_SU_DUNG_MAY.TEN_HIEN_TRANG, dbo.MAY.NUOC_SX, dbo.MAY.TY_LE_CON_LAI, dbo.V_MAY_NHA_XUONG_MAX.NGAY_NHAP, dbo.NHA_XUONG.Ten_N_XUONG,dbo.MAY.MO_TA,dbo.MAY_THONG_SO_TMP.CONG_SUAT, dbo.MAY_THONG_SO_TMP.NANG_XUAT "
        SqlText = SqlText & " ORDER BY dbo.NHA_XUONG.Ten_N_XUONG, dbo.MAY.MS_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Private Sub loadLstDSBC3()
        cboLoaithietbi3.Enabled = True
        'cboNhomthietbi3.Enabled = False
        cboThietbi3.Enabled = True
        lbTuNgay.Visible = True
        lbDenNgay.Visible = True
        dtpDenNgay.Visible = True
        dtpTuNgay.Visible = True
        grpThoiGian.Visible = False
        lblNgay.Visible = False
        dtpNgay.Visible = False
    End Sub

    Private Sub grdDanhsachbaocao1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao1.RowEnter
        intRow1 = e.RowIndex
        Select Case Me.grdDanhsachbaocao1.Rows(e.RowIndex).Cells("REPORT_NAME").Value
            Case "rptDanhSach_ThietBi"
                Me.cboNhaxuong.Enabled = False
                Me.cboLoaiThietBi.Enabled = True
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
                Me.cboDayChuyen.Enabled = False
            Case "rptDanhsachTB_TheoDayChuyen"
                Me.cboLoaiThietBi.Enabled = False
                Me.cboNhaxuong.Enabled = False
                Me.cboDayChuyen.Enabled = True
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
            Case "rptDanhSachHetHanBaoHanh"
                'Me.cboNhaxuong.Enabled = True
                Me.cboLoaiThietBi.Enabled = True
                Me.txtTungay.Enabled = True
                Me.txtDenngay.Enabled = True
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
            Case "rptDanhSachThietBiConKhauHao"
                Me.cboLoaiThietBi.Enabled = True
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
            Case "rptDanhSachThietBiHetKhauHao"
                Me.cboLoaiThietBi.Enabled = True
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
            Case "rptDanhSachNoiLapDatVaBPCPCuaThietBi"
                Me.cboLoaiThietBi.Enabled = False
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = True
                Me.cboPhuTung.Enabled = False
            Case "rptDanhSachThietBiSuDungPhuTung"
                Me.cboLoaiThietBi.Enabled = False
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = True
            Case "rptDSTBTNLDHienTai"
                Me.cboNhaxuong.Enabled = True
                Me.cboLoaiThietBi.Enabled = False
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
                Me.cboDayChuyen.Enabled = False
            Case Else
                Me.cboNhaxuong.Enabled = False
                Me.cboLoaiThietBi.Enabled = False
                Me.txtTungay.Enabled = False
                Me.txtDenngay.Enabled = False
                Me.cboThietBi.Enabled = False
                Me.cboPhuTung.Enabled = False
                Me.cboDayChuyen.Enabled = False
        End Select
    End Sub
    Private Sub cboLoaithietbi2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboLoaithietbi2.SelectedIndexChanged
        Bind_cboNhomthietbi()
        Bind_cbothietbi2()
    End Sub
    Private Sub cboNhomthietbi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboNhomthietbi.SelectedIndexChanged
        Bind_cbothietbi2()
    End Sub

    Private Sub cboLoaithietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboLoaithietbi3.SelectedIndexChanged
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
        LoadcboThietBi_NM()
    End Sub

    Private Sub cboNhomthietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboNhomthietbi3.SelectedIndexChanged
        Bind_cbothietbi3()
        LoadcboThietBi_NM()
    End Sub
#End Region

#Region "Chung"
    Sub RefeshLanguage()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Sub FormatList(ByVal list As Windows.Forms.ListBox)
        list.ValueMember = "REPORT_NAME"
        list.DisplayMember = "TEN_REPORT"
    End Sub

    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function

    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Try
            SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngayanh & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
    End Sub
#End Region ' End of Chung

#Region "Khởi tạo"
    Sub Bind_lstDanhsachbaocao0()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao0.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 0, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao0.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao0.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'grdDanhsachbaocao0.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao0.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao0.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao0.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub Bind_cboLoaiTB()
        cboLoaiTB.Display = "TEN_LOAI_MAY"
        cboLoaiTB.Value = "MS_LOAI_MAY"
        cboLoaiTB.DropDownWidth = 200
        cboLoaiTB.Param = Commons.Modules.UserName
        cboLoaiTB.StoreName = "PermisionLOAI_MAY"
        cboLoaiTB.BindDataSource()
        If cboLoaiTB.Items.Count = 0 Then
            cboLoaiTB.Text = ""
        End If
    End Sub
    Sub Bind_cboNoisudung()
        cboNoisudung.Display = "TEN_LOAI_PT"
        cboNoisudung.Value = "MS_LOAI_PT"
        cboNoisudung.DropDownWidth = 200
        cboNoisudung.Param = Commons.Modules.UserName
        cboNoisudung.StoreName = "PermisionLOAI_PT"
        cboNoisudung.BindDataSource()
    End Sub
    Sub Bind_cboLoaiCV()
        cboLoaiCV.Display = "TEN_LOAI_CV"
        cboLoaiCV.Value = "MS_LOAI_CV"
        cboLoaiCV.DropDownWidth = 200
        cboLoaiCV.Param = Commons.Modules.UserName
        cboLoaiCV.StoreName = "PermisionLOAI_CV"
        cboLoaiCV.BindDataSource()

        cboLoai_CV.Display = "TEN_LOAI_CV"
        cboLoai_CV.Value = "MS_LOAI_CV"
        cboLoai_CV.DropDownWidth = 200
        cboLoai_CV.Param = Commons.Modules.UserName
        cboLoai_CV.StoreName = "PermisionLOAI_CV"
        cboLoai_CV.BindDataSource()

    End Sub

    Sub Print_preview1()
        RefeshHeaderReport()
        Refesh_LanguageReport1()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Call ReportPreview("reports\rptDanhsach_NCC.rpt")
        Cursor = Windows.Forms.Cursors.Default

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NCC_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Refesh_LanguageReport1()
        Dim tieude, stt, tenkhachhang, diachi, dienthoai, fax, nguoidaidien, trang, ngayin As String
        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "stt", Commons.Modules.TypeLanguage)
        tenkhachhang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "tenkhachhang", Commons.Modules.TypeLanguage)
        diachi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "diachi", Commons.Modules.TypeLanguage)
        dienthoai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "dienthoai", Commons.Modules.TypeLanguage)
        fax = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "fax", Commons.Modules.TypeLanguage)
        nguoidaidien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "nguoidaidien", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "trang", Commons.Modules.TypeLanguage)
        If Commons.Modules.TypeLanguage = 0 Then
            ngayin = "Ngày in: "
        Else
            ngayin = "Date print: "
        End If
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NCC_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_NCC_TMP (TIEUDE_  nvarchar(250), STT_ nvarchar(20)," & _
                "TEN_KHACH_HANG_ NVARCHAR(250),DIA_CHI_ NVARCHAR(250),DIEN_THOAI_ NVARCHAR(20)," & _
                "FAX_ NVARCHAR(20),NGUOI_DAI_DIEN_ NVARCHAR(50),TRANG_ nvarchar(20),NGAY_IN_ NVARCHAR(20))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDANH_SACH_NCC_TMP", tieude, stt, tenkhachhang, diachi, dienthoai, fax, nguoidaidien, trang, ngayin)
    End Sub

    Sub PrintDanhMucPhuTung()

        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            Dim vtbData As New DataTable()
            'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_CHI_PHI_THEO_BO_PHAN_CHIU_PHI", vTuNgay, vDenNgay))
            'vtbData.TableName = "DATA_INFO"
            vtbData = GetDataDMVTPT()
            vtbData.TableName = "rptrptDANH_SACH_VTPT"

            If vtbData.Rows.Count > 0 Then
                Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDanhsach_VTPT"
                frmRepot.AddDataTableSource(RefeshLanguageDMVTPT())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()

            Else
                Cursor = Windows.Forms.Cursors.Default
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Function RefeshLanguageDMVTPT() As DataTable
        Dim tieude, stt, Loaithietbi, noisudung, masovtpt, itemcode, partno, tenvattu, quycach, donvitinh, trang As String
        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "Loaithietbi", Commons.Modules.TypeLanguage)
        noisudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "noisudung", Commons.Modules.TypeLanguage)
        masovtpt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "masovtpt", Commons.Modules.TypeLanguage)
        itemcode = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "itemcode", Commons.Modules.TypeLanguage)
        partno = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "partno", Commons.Modules.TypeLanguage)
        tenvattu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tenvattu", Commons.Modules.TypeLanguage)
        quycach = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "quycach", Commons.Modules.TypeLanguage)
        donvitinh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "donvitinh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "trang", Commons.Modules.TypeLanguage)

        Dim vtb As New DataTable("rptDANH_SACH_VTPT_TMP")
        vtb.Columns.Add("TIEUDE_", Type.GetType("System.String"))
        vtb.Columns.Add("STT_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_TB_", Type.GetType("System.String"))
        vtb.Columns.Add("NOI_SD_", Type.GetType("System.String"))
        vtb.Columns.Add("MS_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("ITEM_CODE_", Type.GetType("System.String"))
        vtb.Columns.Add("PART_NO_", Type.GetType("System.String"))
        vtb.Columns.Add("TEN_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("QUY_CACH_", Type.GetType("System.String"))
        vtb.Columns.Add("DON_VI_TINH_", Type.GetType("System.String"))
        vtb.Columns.Add("TRANG_", Type.GetType("System.String"))
        vtb.Columns.Add("NGON_NGU_", Type.GetType("System.String"))

        Dim vrow As DataRow = vtb.NewRow()
        vrow("TIEUDE_") = tieude
        vrow("STT_") = stt
        vrow("LOAI_TB_") = Loaithietbi
        vrow("NOI_SD_") = noisudung
        vrow("MS_PT_") = masovtpt
        vrow("ITEM_CODE_") = itemcode
        vrow("PART_NO_") = partno
        vrow("TEN_PT_") = tenvattu
        vrow("QUY_CACH_") = quycach
        vrow("DON_VI_TINH_") = donvitinh
        vrow("TRANG_") = trang
        vrow("NGON_NGU_") = Commons.Modules.TypeLanguage.ToString()

        vtb.Rows.Add(vrow)
        Return vtb
    End Function

    Function GetDataDMVTPT() As DataTable
        Try
            Dim sql As String = "if exists (select * from dbo.sysobjects where [name] = 'rptrptDANH_SACH_VTPT') " & _
                "Drop table rptrptDANH_SACH_VTPT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception
        End Try

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        Else
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        End If
        SqlText += " ORDER BY IC_PHU_TUNG.MS_PT"
        Dim vtb As New DataTable()
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Return vtb
    End Function

    Sub Print_preview2()
        RefeshHeaderReport()
        Refesh_LanguageReport2()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM rptrptDANH_SACH_VTPT")
        While dtReader.Read
            If dtReader.Item(0) = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptrptDANH_SACH_VTPT", "KHONG_CO_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If
        End While
        dtReader.Close()

        Call ReportPreview("reports\rptDanhsach_VTPT.rpt")
        Cursor = Windows.Forms.Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_VTPT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptrptDANH_SACH_VTPT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_VTPT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Refesh_LanguageReport2()
        Dim tieude, stt, Loaithietbi, noisudung, masovtpt, itemcode, partno, tenvattu, quycach, donvitinh, trang As String

        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "Loaithietbi", Commons.Modules.TypeLanguage)
        noisudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "noisudung", Commons.Modules.TypeLanguage)
        masovtpt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "masovtpt", Commons.Modules.TypeLanguage)
        itemcode = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "itemcode", Commons.Modules.TypeLanguage)
        partno = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "partno", Commons.Modules.TypeLanguage)
        tenvattu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tenvattu", Commons.Modules.TypeLanguage)
        quycach = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "quycach", Commons.Modules.TypeLanguage)
        donvitinh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "donvitinh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "trang", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_VTPT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_VTPT_TMP (TIEUDE_  nvarchar(250), STT_ nvarchar(50)," & _
                "LOAI_TB_ NVARCHAR(50),NOI_SD_ NVARCHAR(50),MS_PT_ NVARCHAR(50)," & _
                "ITEM_CODE_ NVARCHAR(50),PART_NO_ NVARCHAR(50),TEN_PT_ NVARCHAR(50), " & _
                "QUY_CACH_ NVARCHAR(50),DON_VI_TINH_ NVARCHAR(50),TRANG_ nvarchar(50),NGON_NGU_ INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDANH_SACH_VTPT_TMP", tieude, stt, Loaithietbi, noisudung, masovtpt, itemcode, partno, tenvattu, quycach, donvitinh, trang, Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptrptDANH_SACH_VTPT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "INTO [dbo].rptrptDANH_SACH_VTPT " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "INTO [dbo].rptrptDANH_SACH_VTPT " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        Else
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "INTO [dbo].rptrptDANH_SACH_VTPT " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "INTO [dbo].rptrptDANH_SACH_VTPT " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        End If

        SqlText += " ORDER BY IC_PHU_TUNG.MS_PT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub Print_preview3()
        RefeshHeaderReport()
        Refesh_LanguageReport3()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Call ReportPreview("reports\rptDanhsach_CV.rpt")
        Cursor = Windows.Forms.Cursors.Default

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_CV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_CV"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Sub PrintCongViec()
        Try
            Dim vtbData As New DataTable()
            vtbData = GetDataCongViec()
            vtbData.TableName = "rptDANH_SACH_CV"

            If vtbData.Rows.Count > 0 Then
                Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDanhsach_CV"
                frmRepot.AddDataTableSource(RefeshLanguageCongViec())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try


        Cursor = Windows.Forms.Cursors.Default

    End Sub

    Function RefeshLanguageCongViec() As DataTable
        Dim tieude, stt, Loaithietbi, loaicongviec, motacv, chuyenmon, taynghe, thoigianchuan, trang As String

        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "Loaithietbi", Commons.Modules.TypeLanguage)
        loaicongviec = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "loaicongviec", Commons.Modules.TypeLanguage)
        motacv = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "motacv", Commons.Modules.TypeLanguage)
        chuyenmon = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "chuyenmon", Commons.Modules.TypeLanguage)
        taynghe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "taynghe", Commons.Modules.TypeLanguage)
        thoigianchuan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "thoigianchuan", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "trang", Commons.Modules.TypeLanguage)

        Dim vtb As New DataTable("rptDANH_SACH_CV_TMP")

        vtb.Columns.Add("TIEUDE_", Type.GetType("System.String"))
        vtb.Columns.Add("STT_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_TB_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_CV_", Type.GetType("System.String"))
        vtb.Columns.Add("MO_TA_CV_", Type.GetType("System.String"))
        vtb.Columns.Add("CHUYEN_MON_", Type.GetType("System.String"))
        vtb.Columns.Add("TAY_NGHE_", Type.GetType("System.String"))
        vtb.Columns.Add("THOI_GIAN_CHUAN_", Type.GetType("System.String"))
        vtb.Columns.Add("TRANG_", Type.GetType("System.String"))


        Dim vrow As DataRow = vtb.NewRow()
        vrow("TIEUDE_") = tieude
        vrow("STT_") = stt
        vrow("LOAI_TB_") = Loaithietbi
        vrow("LOAI_CV_") = loaicongviec
        vrow("MO_TA_CV_") = motacv
        vrow("CHUYEN_MON_") = chuyenmon
        vrow("TAY_NGHE_") = taynghe
        vrow("THOI_GIAN_CHUAN_") = thoigianchuan
        vrow("TRANG_") = trang

        vtb.Rows.Add(vrow)
        Return vtb

    End Function

    Function GetDataCongViec() As DataTable

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO "
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        Else
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        End If
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Dim vtb As New DataTable()
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Return vtb
    End Function

    Private Sub Refesh_LanguageReport3()
        Dim tieude, stt, Loaithietbi, loaicongviec, motacv, chuyenmon, taynghe, thoigianchuan, trang As String

        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "Loaithietbi", Commons.Modules.TypeLanguage)
        loaicongviec = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "loaicongviec", Commons.Modules.TypeLanguage)
        motacv = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "motacv", Commons.Modules.TypeLanguage)
        chuyenmon = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "chuyenmon", Commons.Modules.TypeLanguage)
        taynghe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "taynghe", Commons.Modules.TypeLanguage)
        thoigianchuan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "thoigianchuan", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_CV", "trang", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_CV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_CV_TMP (TIEUDE_  nvarchar(250), STT_ nvarchar(50)," & _
                "LOAI_TB_ NVARCHAR(50),LOAI_CV_ NVARCHAR(50),MO_TA_CV_ NVARCHAR(50)," & _
                "CHUYEN_MON_ NVARCHAR(50),TAY_NGHE_ NVARCHAR(50),THOI_GIAN_CHUAN_ NVARCHAR(50),TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDANH_SACH_CV_TMP", tieude, stt, Loaithietbi, loaicongviec, motacv, chuyenmon, taynghe, thoigianchuan, trang)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_CV"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "INTO [dbo].rptDANH_SACH_CV " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO "
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "INTO [dbo].rptDANH_SACH_CV " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        Else
            If cboLoaiCV.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "INTO [dbo].rptDANH_SACH_CV " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.TEN_LOAI_MAY, LOAI_CONG_VIEC.TEN_LOAI_CV, CONG_VIEC.MO_TA_CV," & _
                "CHUYEN_MON.TEN_CHUYEN_MON,BAC_THO.TEN_BAC_THO, CONG_VIEC.THOI_GIAN_DU_KIEN " & _
                "INTO [dbo].rptDANH_SACH_CV " & _
                "FROM CONG_VIEC INNER JOIN LOAI_CONG_VIEC ON CONG_VIEC.MS_LOAI_CV = LOAI_CONG_VIEC.MS_LOAI_CV " & _
                "INNER JOIN LOAI_MAY ON CONG_VIEC.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "LEFT OUTER JOIN CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON " & _
                "LEFT OUTER JOIN BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO " & _
                "WHERE CONG_VIEC.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND CONG_VIEC.MS_LOAI_CV = '" & cboLoaiCV.SelectedValue & "'"
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Private Sub grdDanhsachbaocao0_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao0.RowEnter
        intRow0 = e.RowIndex
        Select Case Me.grdDanhsachbaocao0.Rows(e.RowIndex).Cells("REPORT_NAME").Value
            Case "rptDanhsach_NCC"
                Me.cboNoisudung.Enabled = False
                Me.cboLoaiTB.Enabled = False
                Me.cboLoaiCV.Enabled = False
            Case "rptDanhsach_VTPT"
                Me.cboNoisudung.Enabled = True
                Me.cboLoaiTB.Enabled = True
                Me.cboLoaiCV.Enabled = False
            Case "rptDanhsach_CV"
                Me.cboNoisudung.Enabled = False
                Me.cboLoaiTB.Enabled = True
                Me.cboLoaiCV.Enabled = True
        End Select
    End Sub
#End Region

#Region "Thông tin thiết bị"
    Sub Bind_lstDanhsachbaocao1()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao1.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 1, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao1.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao1.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'grdDanhsachbaocao1.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao1.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao1.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao1.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    'Sub CreateData1()
    '    RefeshHeaderReport()
    '    Cursor = Windows.Forms.Cursors.WaitCursor
    '    Try
    '        SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    Catch ex As Exception
    '    End Try

    '    Try
    '        SqlText = "DROP TABLE DANH_SACH_THIET_BI_TMP"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    Catch ex As Exception
    '    End Try

    '    SqlText = "SELECT * INTO  [DBO].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
    '        SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO [dbo].DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT RIGHT JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    End If
    '    If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
    '        SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO [dbo].DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    End If
    '    If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
    '        SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO [dbo].DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    End If
    '    If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
    '        SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO [dbo].DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    End If
    '    RefeshLanguageReport1()
    '    Cursor = Windows.Forms.Cursors.Default
    'End Sub

    Function CreateData1() As DataTable
        Dim dtDuLieu As New DataTable

        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT * INTO  [DBO].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT RIGHT JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP "
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT RIGHT JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT RIGHT JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT RIGHT JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
        End If

        dtDuLieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        dtDuLieu.TableName = "rptDANH_SACH_THIET_BI_TMP"
        Cursor = Windows.Forms.Cursors.Default
        Return dtDuLieu
    End Function

    Sub Printpreview1()
        Dim dtDANH_SACH_THIET_BI_TMP As New DataTable
        Dim dtTIEU_DE_DANH_SACH_THIET_BI_TMP As New DataTable

        Cursor = Windows.Forms.Cursors.WaitCursor
        dtDANH_SACH_THIET_BI_TMP.Clear()
        dtTIEU_DE_DANH_SACH_THIET_BI_TMP.Clear()

        dtDANH_SACH_THIET_BI_TMP = CreateData1()
        dtTIEU_DE_DANH_SACH_THIET_BI_TMP = RefeshLanguageReport1()

        If dtDANH_SACH_THIET_BI_TMP.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If
        Dim frm As New frmXMLReport
        frm.rptName = "rptDanhSachThietBi"
        frm.RemoveDataTableSource()
        frm.AddDataTableSource(dtDANH_SACH_THIET_BI_TMP)
        frm.AddDataTableSource(dtTIEU_DE_DANH_SACH_THIET_BI_TMP)
        frm.Show()
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    'Private Sub RefeshLanguageReport1()
    '    Dim danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang As String
    '    danhsachthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "rptDanhSach_ThietBi  ", commons.Modules.TypeLanguage)
    '    'danhsachthietbi
    '    'CINT
    '    tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tennhaxuong", commons.Modules.TypeLanguage)
    '    '  Label1.Text = danhsachthietbi
    '    tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tenloaimay", commons.Modules.TypeLanguage)
    '    stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "stt", commons.Modules.TypeLanguage)
    '    maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "maso", commons.Modules.TypeLanguage)
    '    sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "sothe", commons.Modules.TypeLanguage)
    '    nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nhomthietbi", commons.Modules.TypeLanguage)
    '    chucnang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "chucnang", commons.Modules.TypeLanguage)
    '    hangsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "hangsx", commons.Modules.TypeLanguage)
    '    nuocsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nuocsx", commons.Modules.TypeLanguage)
    '    trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "trang", commons.Modules.TypeLanguage)

    '    Try
    '        SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_TMP"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    Catch ex As Exception
    '    End Try
    '    SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_TMP (   TIEUDE_  nvarchar(250),     TEN_NHA_XUONG_  nvarchar(250), TEN_LOAI_MAY_  nvarchar(250),STT_ nvarchar(250),MA_SO_  nvarchar(250),SO_THE_  nvarchar(250),NHOM_THIET_BI_ nvarchar(250),CHUC_NANG_ nvarchar(250),HANG_SX_ nvarchar(250),NUOC_SX_ nvarchar(250)  ,TRANG nvarchar(250)   )"
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDANH_SACH_THIET_BI", danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang)
    'End Sub

    Private Function RefeshLanguageReport1() As DataTable
        Dim dtTieuDe As New DataTable
        Dim danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang As String

        danhsachthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "rptDanhSach_ThietBi  ", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "sothe", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nhomthietbi", Commons.Modules.TypeLanguage)
        chucnang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "chucnang", Commons.Modules.TypeLanguage)
        hangsx = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "hangsx", Commons.Modules.TypeLanguage)
        nuocsx = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nuocsx", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "trang", Commons.Modules.TypeLanguage)

        Dim dtRow As DataRow, dtColumn As New DataColumn

        dtTieuDe.Columns.Clear()

        dtTieuDe.Columns.Add("_TIEU_DE_", GetType(String))
        dtTieuDe.Columns.Add("_TEN_NHA_XUONG_", GetType(String))
        dtTieuDe.Columns.Add("_TEN_LOAI_MAY_", GetType(String))
        dtTieuDe.Columns.Add("_STT_", GetType(String))
        dtTieuDe.Columns.Add("_MA_SO_", GetType(String))
        dtTieuDe.Columns.Add("_SO_THE_", GetType(String))
        dtTieuDe.Columns.Add("_NHOM_THIET_BI_", GetType(String))
        dtTieuDe.Columns.Add("_CHUC_NANG_", GetType(String))
        dtTieuDe.Columns.Add("_HANG_SX_", GetType(String))
        dtTieuDe.Columns.Add("_NUOC_SX_", GetType(String))
        dtTieuDe.Columns.Add("_TRANG_", GetType(String))

        dtRow = dtTieuDe.NewRow
        dtRow.Item("_TIEU_DE_") = danhsachthietbi
        dtRow.Item("_TEN_NHA_XUONG_") = tennhaxuong
        dtRow.Item("_TEN_LOAI_MAY_") = tenloaimay
        dtRow.Item("_STT_") = stt
        dtRow.Item("_MA_SO_") = maso
        dtRow.Item("_SO_THE_") = sothe
        dtRow.Item("_NHOM_THIET_BI_") = nhomthietbi
        dtRow.Item("_CHUC_NANG_") = chucnang
        dtRow.Item("_HANG_SX_") = hangsx
        dtRow.Item("_NUOC_SX_") = nuocsx
        dtRow.Item("_TRANG_") = trang
        dtTieuDe.Rows.Add(dtRow)

        dtTieuDe.TableName = "rptTIEU_DE_DANH_SACH_THIET_BI_TMP"
        Return dtTieuDe
    End Function

    Sub CreateData2()
        Cursor = Windows.Forms.Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport2()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE HET_HAN_BH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "SELECT * INTO  [DBO].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO [dbo].HET_HAN_BH_TMP  FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)>='" & TDateFormat(txtTungay.Text) & "' And DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)<='" & TDateFormat(txtDenngay.Text) & "' order by NGAY_BD_BAO_HANH"
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO [dbo].HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,LOAI_MAY.MS_LOAI_MAY HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)>='" & TDateFormat(txtTungay.Text) & "' And DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)<='" & TDateFormat(txtDenngay.Text) & "' order by NGAY_BD_BAO_HANH"
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO [dbo].HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NHA_XUONG.MS_N_XUONG HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)>='" & TDateFormat(txtTungay.Text) & "' And DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)<='" & TDateFormat(txtDenngay.Text) & "' order by NGAY_BD_BAO_HANH"
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & TDateFormat(txtTungay.Text) & "',DENNGAY='" & TDateFormat(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO [dbo].HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)>='" & TDateFormat(txtTungay.Text) & "' And DATEADD(MONTH,dbo.MAY.SO_THANG_BH,dbo.MAY.NGAY_BD_BAO_HANH)<='" & TDateFormat(txtDenngay.Text) & "' order by NGAY_BD_BAO_HANH"
        End If

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Sub Printpreview2()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM HET_HAN_BH_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDanhSachHetHanBaoHanh.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.HET_HAN_BH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport2()
        Dim danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso As String
        Dim sothe, tennhommay, sothangbh, ngayhethanbh, trang As String, DKLoc As String

        danhsachthietbihethanbaohanh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "danhsachthietbihethanbaohanh", Commons.Modules.TypeLanguage)
        tungay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tungay", Commons.Modules.TypeLanguage)
        denngay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "denngay", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothe", Commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " tennhommay", Commons.Modules.TypeLanguage)
        sothangbh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothangbh", Commons.Modules.TypeLanguage)
        ngayhethanbh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " ngayhethanbh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "trang", Commons.Modules.TypeLanguage)
        DKLoc = tungay & " " & Format(txtTungay.Value, "dd/MM/yyyy") & "    " & denngay & " " & Format(txtDenngay.Value, "dd/MM/yyyy")
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP (   DANH_SACH_HET_HAN_BH_  nvarchar(250),     TU_NGAY_ nvarchar(250),DEN_NGAY_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),SO_THANG_BH_ nvarchar(250),NGAY_HET_HAN_BH_ nvarchar(250),TRANG_  nvarchar(250),DK_LOC_ NVARCHAR(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDANHSACHTHIETBIHETHANBAOHANH", danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, sothangbh, ngayhethanbh, trang, DKLoc)
    End Sub

    Sub CreateData3()
        RefeshHeaderReport()
        RefeshLanguageReport3()
        Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "SELECT * INTO  [dbo].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,GIA_MUA ,SO_NAM_KHAU_HAO HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP ,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Sub Printpreview3()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM DANH_SACH_TB_CON_KHAU_HAO_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDanhSachThietBiConKhauHao.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:

    End Sub

    Private Sub RefeshLanguageReport3()
        Dim danhsachthietbiconkhauhao, tennhaxuong, tenloaimay, stt, maso, ngayhetkh As String
        Dim sothe, tennhommay, ngaysudung, sonamkhauhao, gtconlai, tiente, trang As String

        danhsachthietbiconkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "danhsachthietbiconkhauhao", Commons.Modules.TypeLanguage)
        ngaysudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "ngaysudung", Commons.Modules.TypeLanguage)
        sonamkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sonamkhauhao", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sothe", Commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhommay", Commons.Modules.TypeLanguage)
        gtconlai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " gtconlai", Commons.Modules.TypeLanguage)
        ngayhetkh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " ngayhetkh", Commons.Modules.TypeLanguage)

        tiente = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tiente", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "trang", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP (   DANH_SACH_THIET_BI_CON_KHAU_HAO_  nvarchar(250),     NGAY_SU_DUNG_ nvarchar(250),SO_NAM_KHAU_HAO_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),GT_CON_LAI_ nvarchar(250),TIEN_TE_ nvarchar(250),TRANG_ nvarchar(250),NGAY_HET_KH nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiConKhauHao", danhsachthietbiconkhauhao, ngaysudung, sonamkhauhao, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, gtconlai, tiente, trang, ngayhetkh)
    End Sub

    Sub CreateData4()
        Cursor = Windows.Forms.Cursors.WaitCursor

        RefeshHeaderReport()
        RefeshLanguageReport4()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "SELECT * INTO  [dbo].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,GIA_MUA ,SO_NAM_KHAU_HAO HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP ,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Sub Printpreview4()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM DANH_SACH_TB_CON_KHAU_HAO_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDanhSachThietBiHetKhauHao.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport4()
        Dim danhsachthietbihetkhauhao, tennhaxuong, tenloaimay, stt, maso As String
        Dim sothe, tennhommay, ngaysudung, sonamkhauhao, ngayhetkhauhao, trang As String

        danhsachthietbihetkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "danhsachthietbihetkhauhao", Commons.Modules.TypeLanguage)
        ngaysudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "ngaysudung", Commons.Modules.TypeLanguage)
        sonamkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "sonamkhauhao", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", " maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "sothe", Commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tennhommay", Commons.Modules.TypeLanguage)
        ngayhetkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "ngayhetkhauhao", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "trang", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP (   DANH_SACH_THIET_BI_HET_KHAU_HAO  nvarchar(250),     NGAY_SU_DUNG_ nvarchar(250),SO_NAM_KH_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),NGAY_HET_KHAU_HAO_ nvarchar(250),TRANG_ nvarchar(250))    "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiHetKhauHao", danhsachthietbihetkhauhao, ngaysudung, sonamkhauhao, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, ngayhetkhauhao, trang)
    End Sub

    Sub CreateData6()
        Cursor = Windows.Forms.Cursors.WaitCursor

        RefeshHeaderReport()
        RefeshLanguageReport6()
        Try
            SqlText = "DROP TABLE LD_CP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try

        SqlText = "SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI INTO [DBO].LD_CP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG ORDER BY MS_MAY , NGAY_NHAP"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO [DBO].LD_CP" & Commons.Modules.UserName & "(MS_MAY, NGAY_NHAP, MS_N_XUONG, MS_BP_CHIU_PHI)SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI FROM MAY_BO_PHAN_CHIU_PHI WHERE (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) NOT IN (SELECT (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) FROM LD_CP" & Commons.Modules.UserName & ")"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE [DBO].LD_CP" & Commons.Modules.UserName & " SET MS_N_XUONG = NHA_XUONG.Ten_N_XUONG FROM NHA_XUONG INNER JOIN(LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_NHA_XUONG ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_NHA_XUONG.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_NHA_XUONG.NGAY_NHAP)ON NHA_XUONG.MS_N_XUONG=MAY_NHA_XUONG.MS_N_XUONG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE [DBO].LD_CP" & Commons.Modules.UserName & " SET MS_BP_CHIU_PHI = BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN( LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_BO_PHAN_CHIU_PHI ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_BO_PHAN_CHIU_PHI.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_BO_PHAN_CHIU_PHI.NGAY_NHAP )ON BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI=MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE dbo.MAY_NHOM_LOAI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        SqlText = "SELECT MAY.MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO [dbo].MAY_NHOM_LOAI_TMP FROM (LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY) INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE dbo.MAY_LD_CP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.MAY_LD_CP_TMP(   STT  smallint      IDENTITY(1,1)     ,   MS_MAY       Nvarchar(50)     NOT NULL     ,   NGAY_NHAP      DATETIME     NOT NULL     ,   MS_N_XUONG      Nvarchar(50)     NOT NULL         ,   MS_BP_CHIU_PHI     Nvarchar(50)     NOT NULL)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboThietBi.SelectedIndex <> 0 Then
            SqlText = "INSERT dbo.MAY_LD_CP_TMP (MS_MAY,NGAY_NHAP,MS_N_XUONG,MS_BP_CHIU_PHI)select * from LD_CP" & Commons.Modules.UserName & " WHERE (((LD_CP" & Commons.Modules.UserName & ".MS_MAY)='" & cboThietBi.SelectedValue & "')) ORDER BY MS_MAY , NGAY_NHAP  "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        End If
        If cboThietBi.SelectedIndex = 0 Then
            SqlText = "INSERT dbo.MAY_LD_CP_TMP (MS_MAY,NGAY_NHAP,MS_N_XUONG,MS_BP_CHIU_PHI)select * from LD_CP" & Commons.Modules.UserName & " ORDER BY MS_MAY , NGAY_NHAP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        End If

        Dim tbl As New DataTable
        Dim tbl1 As New DataTable
        tbl.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LD_CP_TMP"))
        Dim i As Integer
        For i = 0 To tbl.Rows.Count - 1
            tbl1.Clear()
            tbl1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LD_CP_TMP"))
            If i <> 0 Then
                If tbl1.Rows(i - 1).Item("MS_N_XUONG") <> "" Then
                    If tbl1.Rows(i).Item("MS_N_XUONG") = "" Then
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_N_XUONG =N'" & tbl1.Rows(i - 1).Item("MS_N_XUONG") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If

                If tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") <> "" Then
                    If tbl1.Rows(i).Item("MS_BP_CHIU_PHI") = "" Then
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_BP_CHIU_PHI =N'" & tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If
            End If
        Next
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Sub Printpreview6()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM MAY_NHOM_LOAI_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDanhSachNoiLapDatVaBPCPCuaThietBi.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.MAY_LD_CP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE LD_CP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.MAY_NHOM_LOAI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport6()
        Dim danhsachnoilapdat, ngaynhap, bophanchiuphi As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, trang, sothe As String

        danhsachnoilapdat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "danhsachnoilapdat", Commons.Modules.TypeLanguage)
        ngaynhap = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "ngaynhap", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "sothe", Commons.Modules.TypeLanguage)
        bophanchiuphi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "bophanchiuphi", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "nhomthietbi", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "trang", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP(   DANH_SACH_NOI_LAP_DAT_  nvarchar(250),     NGAY_NHAP_ nvarchar(250),TEN_NHA_XUONG_  nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),BO_PHAN_CHIU_PHI_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),TRANG_ nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanh_SachThietBiTrongHeThong", danhsachnoilapdat, ngaynhap, tennhaxuong, tenloaimay, stt, maso, sothe, bophanchiuphi, nhomthietbi, trang)
    End Sub

    Sub CreateData7()
        Cursor = Windows.Forms.Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport7()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = " SELECT * INTO  [dbo].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Try
            SqlText = "DROP TABLE dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = " SELECT MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO [dbo].MAY_NHA_XUONG_LOAI_NHOM_TMP  FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN ((NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) INNER JOIN MAY ON MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE  dbo.MAY_PHU_TUNG_SO_LUONG_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 0 Then
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If
        If Commons.Modules.TypeLanguage = 1 Then
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Sub Printpreview7()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM MAY_PHU_TUNG_SO_LUONG_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDanhSachThietBiSuDungPhuTung.rpt") 'rptDanhSachTH_Trong_He_Thong.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE  dbo.MAY_PHU_TUNG_SO_LUONG_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefeshLanguageReport7()
        Dim danhsachthietbisungphutung, msphutung, tenphutung, partNo, msCongty, dvt As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, soluong, trang As String

        danhsachthietbisungphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "danhsachthietbisungphutung", Commons.Modules.TypeLanguage)
        msphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msphutung", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "maso", Commons.Modules.TypeLanguage)
        tenphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenphutung", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "nhomthietbi", Commons.Modules.TypeLanguage)
        partNo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "partNo", Commons.Modules.TypeLanguage)
        msCongty = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msCongty", Commons.Modules.TypeLanguage)
        dvt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "dvt", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "trang", Commons.Modules.TypeLanguage)
        soluong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "soluong", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP (   DANH_SACH_THIET_BI_SU_DUNG_PT_  nvarchar(250),     MS_PHU_TUNG_ nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),TEN_PHU_TUNG_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),PART_No_ nvarchar(250),MS_CTY_ nvarchar(250),DVT_ nvarchar(250),SO_LUONG_ nvarchar(250),TRANG_ nvarchar(250)    )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiSuDungPhuTung", danhsachthietbisungphutung, msphutung, tennhaxuong, tenloaimay, stt, maso, tenphutung, nhomthietbi, partNo, msCongty, dvt, soluong, trang)
    End Sub
#End Region ' End of Thông tin thiết bị

#Region "Sử dụng"
    Sub Bind_lstDanhsachbaocao2()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao2.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 2, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao2.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao2.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'grdDanhsachbaocao2.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao2.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try

            Me.grdDanhsachbaocao2.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao2.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub Bind_cboLoaithietbi2()
        cboLoaithietbi2.Display = "TEN_LOAI_MAY"
        cboLoaithietbi2.Value = "MS_LOAI_MAY"
        cboLoaithietbi2.Param = Commons.Modules.UserName
        cboLoaithietbi2.DropDownWidth = 200
        cboLoaithietbi2.StoreName = "PermisionLOAI_MAY"
        cboLoaithietbi2.BindDataSource()
        If cboLoaithietbi2.Items.Count = 0 Then
            cboLoaithietbi2.Text = ""
        End If
    End Sub

    Sub Bind_cboNhomthietbi()
        If cboLoaithietbi2.SelectedIndex = -1 Then
            cboNhomthietbi.Text = ""
            Exit Sub
        End If
        cboNhomthietbi.Display = "TEN_NHOM_MAY"
        cboNhomthietbi.Value = "MS_NHOM_MAY"
        'cboNhomthietbi.Param = cboLoaithietbi2.SelectedValue
        If cboLoaithietbi2.SelectedValue.ToString = "-1" Then
            cboNhomthietbi.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        Else
            cboNhomthietbi.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE NHOM_LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi2.SelectedValue & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        End If
        'cboNhomthietbi.StoreName = "Get_rptNhomThietBi"
        cboNhomthietbi.StoreName = "QL_SEARCH"
        cboNhomthietbi.BindDataSource()
        If cboNhomthietbi.Items.Count = 0 Then
            cboNhomthietbi.Text = ""
        End If
    End Sub

    Sub Bind_cbothietbi2()
        If cboNhomthietbi.SelectedIndex = -1 Then
            cbothietbi2.Text = ""
            Exit Sub
        End If
        cbothietbi2.Display = "MAY"
        cbothietbi2.Value = "MS_MAY"
        'cbothietbi2.Param = cboNhomthietbi.SelectedValue
        If cboNhomthietbi.SelectedValue.ToString = "-1" Then
            cbothietbi2.Param = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM USERS INNER JOIN NHOM_LOAI_MAY ON USERS.GROUP_ID = NHOM_LOAI_MAY.GROUP_ID INNER JOIN MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY MS_MAY"
        Else
            cbothietbi2.Param = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM USERS INNER JOIN NHOM_LOAI_MAY ON USERS.GROUP_ID = NHOM_LOAI_MAY.GROUP_ID INNER JOIN MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE  MS_NHOM_MAY='" & cboNhomthietbi.SelectedValue.ToString & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY MS_MAY"
        End If
        'cbothietbi2.StoreName = "Get_rptTHIET_BI"
        cbothietbi2.StoreName = "QL_SEARCH"
        cbothietbi2.BindDataSource()
        If cbothietbi2.Items.Count = 0 Then cbothietbi2.Text = ""
    End Sub

    Sub Create_TitleReport_TGCM(ByVal iLoaiBC As Byte, Optional ByVal bTheoLoaiMay As Boolean = True)
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE [dbo].rpt_Title_THOI_GIAN_CHAY_MAY(TypeLanguage int,TrangIn NVARCHAR(50)," & _
                "NgayIn NVARCHAR(50),DKLoc NVARCHAR(100),TieudeReport NVARCHAR(255),DayChuyen NVARCHAR(30),Loai_May NVARCHAR(50),Nhom_May NVARCHAR(50)," & _
                "May NVARCHAR(50),Don_vi_RT NVARCHAR(50),Ngay NVARCHAR(50),Chi_so_dong_ho NVARCHAR(50)," & _
                "Chi_so_chu_trinh_lv NVARCHAR(50), So_phieu_bao_tri NVARCHAR(50))"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim sTieudeReport As String

        If iLoaiBC = 1 Then     'thoi gian chay may
            If bTheoLoaiMay = True Then
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY1", "TieuDe", Commons.Modules.TypeLanguage)
            Else
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY_THEO_DC1", "TieuDe", Commons.Modules.TypeLanguage)
            End If
        Else        'thoi gian chay may vao ngay cuoi tuan
            If bTheoLoaiMay = True Then
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "TieuDe", Commons.Modules.TypeLanguage)
            Else
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY_THEO_DC", "TieuDe", Commons.Modules.TypeLanguage)
            End If
        End If

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Trangin", Commons.Modules.TypeLanguage)
        Dim sDayChuyenSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "DayChuyenSX", Commons.Modules.TypeLanguage)
        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Loai_May", Commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nhom_May", Commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim sDon_vi_RT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Don_vi_RT", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay", Commons.Modules.TypeLanguage)
        Dim sChi_so_dong_ho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Chi_so_dong_ho", Commons.Modules.TypeLanguage)
        Dim sChi_so_chu_trinh_lv As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Chi_so_chu_trinh_lv", Commons.Modules.TypeLanguage)
        Dim sSo_phieu_bao_tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "So_phieu_bao_tri", Commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTungayCuoiTuan.Text & "  " & Format(dtpTuNgayCuoiTuan.Value, "dd/MM/yyyy").ToString & "    " & lblDenngayCuoiTuan.Text & "  " & Format(dtpDenNgayCuoiTuan.Value, "dd/MM/yyyy").ToString
        SqlText = "INSERT INTO [DBO].rpt_Title_THOI_GIAN_CHAY_MAY(commons.Modules.TypeLanguage,TrangIn,NgayIn,DKLoc,TieudeReport,DayChuyen,Loai_May,Nhom_May,May,Don_vi_RT,Ngay,Chi_so_dong_ho,Chi_so_chu_trinh_lv,So_phieu_bao_tri) " & _
                        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
                        "N'" & DKLoc & "',N'" & sTieudeReport & "',N'" & sDayChuyenSX & "',N'" & sLoai_May & "',N'" & sNhom_May & _
                        "',N'" & sMay & "',N'" & sDon_vi_RT & "',N'" & sNgay & "',N'" & sChi_so_dong_ho & _
                        "',N'" & sChi_so_chu_trinh_lv & "',N'" & sSo_phieu_bao_tri & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub print_reportThoigianchaymay_theoloaimay()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = " CREATE TABLE [dbo].rpt_THOI_GIAN_CHAY_MAY(LOAI_MAY NVARCHAR(50),NHOM_MAY NVARCHAR(50)," & _
                "MAY NVARCHAR(50),DON_VI_TINH_RT NVARCHAR(50),NGAY DATETIME,CHI_SO_DONG_HO INT," & _
                "SO_MOVEMENT INT,MS_PBT NVARCHAR(30))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        If cboLoaithietbi2.SelectedValue = "-1" Then
            If cboNhomthietbi.SelectedValue = "-1" Then
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                End If
            End If
        Else
            If cboNhomthietbi.SelectedValue = "-1" Then
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
                End If
            End If
        End If

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptThoigianchaymay.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Sub print_reportThoigianchaymay_theodaychuyen()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        'SqlText = " CREATE TABLE rpt_THOI_GIAN_CHAY_MAY_THEO_DC(LOAI_MAY NVARCHAR(50),NHOM_MAY NVARCHAR(50)," & _
        '        "MAY NVARCHAR(50),DON_VI_TINH_RT NVARCHAR(50),NGAY DATETIME,CHI_SO_DONG_HO INT," & _
        '        "SO_MOVEMENT INT,MS_PBT NVARCHAR(30))"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "SELECT DISTINCT HE_THONG.MS_HE_THONG,HE_THONG.TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                  "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_THEO_DC " & _
                  "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY = TG.MS_MAY INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT = DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN " & _
                        "NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN MAY_HE_THONG ON TG.MS_MAY = MAY_HE_THONG.MS_MAY INNER JOIN " & _
                        "HE_THONG ON MAY_HE_THONG.MS_HE_THONG = HE_THONG.MS_HE_THONG " & _
                  "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') ORDER BY TG.MS_MAY,NGAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_THEO_DC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptThoiGianChayMayTheoDC.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachbaocao2_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao2.RowEnter
        intRow2 = e.RowIndex
        Select Case grdDanhsachbaocao2.Rows(e.RowIndex).Cells("REPORT_NAME").Value.ToString
            Case "rptThoiGianChayMayCuoiTuan"
                lblNhomthietbi.Visible = False
                cboNhomthietbi.Visible = False
                lblThietbi.Visible = False
                cbothietbi2.Visible = False
                btnIN.Visible = False
                'lblTungayCuoiTuan.Visible = True
                'lblDenngayCuoiTuan.Visible = True
                'lblDayChuyenCuoiTuan.Visible = True
                'cboDayChuyenCuoiTuan.Visible = True
                'dtpTuNgayCuoiTuan.Visible = True
                'dtpDenNgayCuoiTuan.Visible = True
                'btnTheoLoaiMay.Visible = True
                'btnTheoDayChuyen.Visible = True
            Case "rptThoigianchaymay"
                lblNhomthietbi.Visible = False
                cboNhomthietbi.Visible = False
                lblThietbi.Visible = True
                cbothietbi2.Visible = True
                btnIN.Visible = False
                'lblDayChuyenCuoiTuan.Visible = False
                'cboDayChuyenCuoiTuan.Visible = False
                'lblTungayCuoiTuan.Visible = False
                'lblDenngayCuoiTuan.Visible = False
                'dtpTuNgayCuoiTuan.Visible = False
                'dtpDenNgayCuoiTuan.Visible = False
                'btnTheoLoaiMay.Visible = False
                'btnTheoDayChuyen.Visible = False
        End Select

    End Sub
#End Region ' End of Sử dụng

#Region "Bảo trì"
    Sub Bind_lstDanhsachbaocao3()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao7.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 3, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao7.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao7.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'grdDanhsachbaocao3.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao7.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try

            Me.grdDanhsachbaocao7.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao7.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub Bind_cboLoaithietbi3()
        Dim str As String = ""
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaithietbi3.Display = "TEN_LOAI_MAY"
        cboLoaithietbi3.Value = "MS_LOAI_MAY"
        cboLoaithietbi3.Param = str
        cboLoaithietbi3.StoreName = "QL_SEARCH"
        cboLoaithietbi3.BindDataSource()
        If cboLoaithietbi3.Items.Count = 0 Then
            cboLoaithietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cboNhomthietbi3()
        If cboLoaithietbi3.SelectedIndex = -1 Then
            cboNhomthietbi3.Text = ""
            Exit Sub
        End If
        cboNhomthietbi3.Display = "TEN_NHOM_MAY"
        cboNhomthietbi3.Value = "MS_NHOM_MAY"
        'cboNhomthietbi3.Param = cboLoaithietbi3.SelectedValue
        If cboLoaithietbi2.SelectedValue.ToString = "-1" Then
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        Else
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE NHOM_LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi2.SelectedValue & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        End If
        'cboNhomthietbi.StoreName = "Get_rptNhomThietBi"
        cboNhomthietbi3.StoreName = "QL_SEARCH"
        cboNhomthietbi3.BindDataSource()
        If cboNhomthietbi3.Items.Count = 0 Then
            cboNhomthietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cbothietbi3()
        If cboNhomthietbi3.SelectedIndex = -1 Then
            cboThietbi3.Text = ""
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID where USERNAME='" & Commons.Modules.UserName & "' AND MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        cboThietbi3.Display = "MAY"
        cboThietbi3.Value = "MS_MAY"
        cboThietbi3.Param = str
        cboThietbi3.StoreName = "QL_SEARCH"
        cboThietbi3.BindDataSource()
        If cboThietbi3.Items.Count = 0 Then
            cboThietbi3.Text = ""
        End If
    End Sub

    Sub Create_TitleReport_TSGSTT()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE [dbo].rpt_Title_THONG_SO_GSTT_DEN_HAN_KT(TypeLanguage int," & _
                "TrangIn NVARCHAR(50),NgayIn NVARCHAR(50),TieudeReport NVARCHAR(255)," & _
                "Ngay NVARCHAR(50),Loai_May NVARCHAR(50),Nhom_May NVARCHAR(50),May NVARCHAR(50)," & _
                "Thong_so NVARCHAR(50),Ngay_kiem_tra_cuoi NVARCHAR(50),Ngay_kiem_tra_ke_tiep NVARCHAR(50))"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TieudeReport_GSTT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Trangin", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay", Commons.Modules.TypeLanguage)

        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Loai_May", Commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nhom_May", Commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "May", Commons.Modules.TypeLanguage)

        Dim sThong_so As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thong_so", Commons.Modules.TypeLanguage)
        Dim sNgay_kiem_tra_cuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay_kiem_tra_cuoi", Commons.Modules.TypeLanguage)
        Dim sNgay_kiem_tra_ke_tiep As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay_kiem_tra_ke_tiep", Commons.Modules.TypeLanguage)

        'SqlText = "INSERT INTO rpt_Title_THONG_SO_GSTT_DEN_HAN_KT(commons.Modules.TypeLanguage,TrangIn,NgayIn,TieudeReport,Ngay,Loai_May,Nhom_May,May,Thong_so,Ngay_kiem_tra_cuoi,Ngay_kiem_tra_ke_tiep) " & _
        '                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
        '                "N'" & sTieudeReport & "',N'" & sNgay & "',N'" & sLoai_May & "',N'" & sNhom_May & _
        '                "',N'" & sMay & "',N'" & sThong_so & "',N'" & sNgay_kiem_tra_cuoi & _
        '                "',N'" & sNgay_kiem_tra_ke_tiep & "')"

        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub print_reportThongso_GSTT_DHKT()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = " CREATE TABLE [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT(LOAI_MAY NVARCHAR(20)," & _
                "NHOM_MAY NVARCHAR(20),MAY NVARCHAR(30),THONG_SO NVARCHAR(50),NGAY_KIEM_TRA_CUOI DATETIME," & _
                "MS_DV_TG INT, CHU_KY_DO INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        If cboLoaithietbi3.SelectedValue = "-1" Then
            If cboNhomthietbi3.SelectedValue = "-1" Then
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG "
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        Else
            If cboNhomthietbi.SelectedValue = "-1" Then
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THONG_SO_GSTT_DEN_HAN_KT")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()

        Create_TitleReport_TSGSTT()
        ReportPreview("reports/rptThongso_GSTT_DHKT.rpt")
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Sub Create_TitleReport_TSGSTT_Khongdat()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_KHONG_DAT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE [dbo].rpt_Title_THONG_SO_GSTT_KHONG_DAT(TypeLanguage int," & _
                "TrangIn NVARCHAR(50),NgayIn NVARCHAR(50),TieudeReport NVARCHAR(255)," & _
                "Ngay NVARCHAR(50),Loai_May NVARCHAR(50),Nhom_May NVARCHAR(50),May NVARCHAR(50)," & _
                "Ngay_kiem_tra NVARCHAR(50),Thong_so NVARCHAR(50),Gia_tri_do_duoc NVARCHAR(50))"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TieudeReport_GSTT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Trangin", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay", Commons.Modules.TypeLanguage)

        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Loai_May", Commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nhom_May", Commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "May", Commons.Modules.TypeLanguage)

        Dim sThong_so As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thong_so", Commons.Modules.TypeLanguage)
        Dim sNgay_kiem_tra As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngay_kiem_tra", Commons.Modules.TypeLanguage)
        Dim sGia_tri_do_duoc As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Gia_tri_do_duoc", Commons.Modules.TypeLanguage)

        SqlText = "INSERT INTO [BDO].rpt_Title_THONG_SO_GSTT_KHONG_DAT(commons.Modules.TypeLanguage,TrangIn,NgayIn,TieudeReport,Ngay,Loai_May,Nhom_May,May,Ngay_kiem_tra,Thong_so,Gia_tri_do_duoc) " & _
                        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
                        "N'" & sTieudeReport & "',N'" & sNgay & "',N'" & sLoai_May & "',N'" & sNhom_May & _
                        "',N'" & sMay & "',N'" & sNgay_kiem_tra & "',N'" & sThong_so & _
                        "',N'" & sGia_tri_do_duoc & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub print_reportThongso_GSTT_Khongdat()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_KHONG_DAT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = " CREATE TABLE [dbo].rpt_THONG_SO_GSTT_KHONG_DAT(LOAI_MAY NVARCHAR(20)," & _
                "NHOM_MAY NVARCHAR(20),MAY NVARCHAR(30),NGAY_KIEM_TRA DATETIME,THONG_SO NVARCHAR(50)," & _
                "GIA_TRI_DO_DUOC INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        If cboLoaithietbi3.SelectedValue = "-1" Then
            If cboNhomthietbi3.SelectedValue = "-1" Then
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_KHONG_DAT  "
                Else
                    SqlText = " " & _
                            "WHERE GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = " " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = " " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        Else
            If cboNhomthietbi.SelectedValue = "-1" Then
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = " " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & "'"
                Else
                    SqlText = " " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cbothietbi2.SelectedValue = "-1" Then
                    SqlText = " " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = " " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Create_TitleReport_TSGSTT()
        ReportPreview("reports/rptThongso_GSTT_Khongdat.rpt")
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_KHONG_DAT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefeshLanguageReport9()
        Dim str As String = ""
        Try
            str = " drop table rptTieuDeWeeklyEuip"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "NgayIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThietBi", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim ThoiGianChayMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianChayMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianBaoTri", Commons.Modules.TypeLanguage)
        Dim AV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "AV", Commons.Modules.TypeLanguage)
        Dim Gio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Gio", Commons.Modules.TypeLanguage)
        Dim Remark As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Remark", Commons.Modules.TypeLanguage)
        Dim Reviewed As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Reviewed", Commons.Modules.TypeLanguage)
        Dim CraneSection As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "CraneSection", Commons.Modules.TypeLanguage)
        Dim RTGSection As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "RTGSection", Commons.Modules.TypeLanguage)
        Dim VEHLeader As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "VEHLeader", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        If Commons.Modules.TypeLanguage = 0 Then
            DieuKienLoc = "Từ ngày " & Format(CDate(TU_NGAY), "dd/MM/yyyy") & " đến ngày " & Format(CDate(DEN_NGAY), "dd/MM/yyyy")
        Else
            DieuKienLoc = "From date " & Format(CDate(TU_NGAY), "dd/MM/yyyy") & " to date " & Format(CDate(DEN_NGAY), "dd/MM/yyyy")
        End If
        str = "Create table dbo.rptTieuDeWeeklyEuip(TypeLanguage int,NgayIn nvarchar(50),TrangIn nvarchar(50),TieuDe nvarchar(255)," & _
        " DieuKienLoc nvarchar(255),STT nvarchar(5), ThietBi nvarchar(50),ThoiGianChayMay nvarchar(100),ThoiGianNgungMay nvarchar(100)," & _
        " ThoiGianBaoTri nvarchar(100),AV nvarchar(100),Gio nvarchar(10),ThoiGian nvarchar(150),Remark nvarchar(30), " & _
        " Reviewed nvarchar(100),CraneSection nvarchar(100),RTGSection nvarchar(100),VEHLeader nvarchar(100))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeWeeklyEuip values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        DieuKienLoc & "',N'" & STT & "',N'" & ThietBi & "',N'" & ThoiGianChayMay & "',N'" & ThoiGianNgungMay & "',N'" & ThoiGianBaoTri & "',N'" & _
        AV & "',N'" & Gio & "',N'" & ThoiGian & "',N'" & Remark & "',N'" & Reviewed & "',N'" & CraneSection & "',N'" & RTGSection & "',N'" & VEHLeader & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub


    Sub CreateData9()
        If cboThietbi3.Text = "" Then
            Exit Sub
        End If
        setTextNGAY(cboNam.SelectedValue, cboTuan.SelectedValue)
        RefeshLanguageReport9()
        Cursor = Windows.Forms.Cursors.WaitCursor
        Dim str As String = ""
        Try
            str = "drop table rptWEEKLY_EQUIP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT PP.MS_MAY, " & _
        " ISNULL((SELECT DISTINCT MAX(CHI_SO_DONG_HO)-MIN(CHI_SO_DONG_HO) FROM THOI_GIAN_CHAY_MAY " & _
        " WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND MS_MAY=PP.MS_MAY),0)AS OP, " & _
        " ISNULL((select CONVERT(FLOAT,SUM(DATEDIFF (minute,TU_GIO,DEN_GIO)))/60  from thoi_gian_ngung_may " & _
        " WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND MS_MAY=PP.MS_MAY),0)AS DT, " & _
        " (SELECT    ISNULL(CONVERT(FLOAT,SUM(DATEDIFF (minute,TU_GIO,DEN_GIO)))/60,0)  " & _
        " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET P3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU P2 ON   " & _
        " P3.MS_PHIEU_BAO_TRI = P2.MS_PHIEU_BAO_TRI AND P3.MS_CV = P2.MS_CV AND  P3.MS_BO_PHAN = P2.MS_BO_PHAN AND  " & _
        " P3.MS_CONG_NHAN = P2.MS_CONG_NHAN INNER JOIN PHIEU_BAO_TRI_CONG_VIEC P1 ON P2.MS_PHIEU_BAO_TRI = P1.MS_PHIEU_BAO_TRI  " & _
        " AND  P2.MS_CV = P1.MS_CV AND P2.MS_BO_PHAN = P1.MS_BO_PHAN INNER JOIN  PHIEU_BAO_TRI P ON  " & _
        " P1.MS_PHIEU_BAO_TRI = P.MS_PHIEU_BAO_TRI WHERE     (TINH_TRANG_PBT=3 OR TINH_TRANG_PBT = 4) " & _
        " AND NGAY_LAP BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND P.MS_MAY=PP.MS_MAY) AS PMR " & _
        " INTO [DBO].rptWEEKLY_EQUIP " & _
        " FROM (SELECT  MS_MAY FROM THOI_GIAN_CHAY_MAY WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103)) UNION " & _
        " SELECT MS_MAY FROM THOI_GIAN_NGUNG_MAY WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103)) UNION " & _
        " SELECT MS_MAY FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET PP3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU PP2 ON  " & _
        " PP3.MS_PHIEU_BAO_TRI = PP2.MS_PHIEU_BAO_TRI AND PP3.MS_CV = PP2.MS_CV AND  " & _
        " PP3.MS_BO_PHAN = PP2.MS_BO_PHAN AND PP3.MS_CONG_NHAN = PP2.MS_CONG_NHAN INNER JOIN " & _
        " PHIEU_BAO_TRI_CONG_VIEC PP1 ON PP2.MS_PHIEU_BAO_TRI = PP1.MS_PHIEU_BAO_TRI AND  " & _
        " PP2.MS_CV = PP1.MS_CV AND PP2.MS_BO_PHAN = PP1.MS_BO_PHAN INNER JOIN " & _
        " PHIEU_BAO_TRI ON PP1.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
        " WHERE(TINH_TRANG_PBT = 3 Or TINH_TRANG_PBT = 4) " & _
        " AND NGAY_LAP BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DATEADD(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))) AS PP " & _
        " INNER JOIN MAY ON PP.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY=PP.MS_MAY) " & _
        " INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID=NHOM.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID  WHERE USERNAME='" & Commons.Modules.UserName & "' AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        If cboThietbi3.SelectedValue <> "-1" Then
            str = str + " and PP.MS_MAY=N'" & cboThietbi3.SelectedValue & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Printpreview9()
    End Sub


    Sub Printpreview9()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptWEEKLY_EQUIP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptWEP_REPORT.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.rptWEEKLY_EQUIP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.rptTieuDeWeeklyEuip"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

    End Sub



    Private Sub RefeshLanguageReport10()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "STT", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "Ngay", Commons.Modules.TypeLanguage)
        Dim PhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "PhuTung", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "SoLuong", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "ThietBi", Commons.Modules.TypeLanguage)
        Dim NguoiThuchien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "NguoiThuchien", Commons.Modules.TypeLanguage)
        Dim NguyenNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "NguyenNhan", Commons.Modules.TypeLanguage)
        Dim Comment As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "Comment", Commons.Modules.TypeLanguage)
        Dim Reported As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "Reported", Commons.Modules.TypeLanguage)
        Dim NgayThang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_EQUIPMENT_EUEL", "NgayThang", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblTungay.Text + " " + Format(dtpTuNgay.Value, "Short date") + " " + lblDenngay.Text + " " + Format(dtpDenNgay.Value, "Short date")
        Try
            SqlText = "DROP TABLE dbo.rptTieuDeDailyEquipFuel"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = " Create table dbo.rptTieuDeDailyEquipFuel(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        " DieuKienLoc nvarchar(255),STT nvarchar(5),NgayLap nvarchar(50),PhuTung nvarchar(50),SoLuong nvarchar(30),ThietBi nvarchar(50), " & _
        " NguoiThucHien nvarchar(90),NguyenNhan nvarchar(50),Comment nvarchar(255),Reported nvarchar(30),NgayThang nvarchar(255))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlText = "INSERT INTO [dbo].rptTieuDeDailyEquipFuel VALUES(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        DieuKienLoc & "',N'" & STT & "',N'" & Ngay & "',N'" & PhuTung & "',N'" & SoLuong & "',N'" & ThietBi & "',N'" & _
        NguoiThuchien & "',N'" & NguyenNhan & "',N'" & Comment & "',N'" & Reported & "',N'" & NgayThang & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub CreateData10()
        If cboThietbi3.Text = "" Then
            Exit Sub
        End If
        RefeshHeaderReport()
        RefeshLanguageReport10()
        Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDAILY_EQUIPMENT_EUEL_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Dim date_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month.ToString() + "/" + Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day.ToString() + "/" + Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year.ToString()
        Dim date_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month.ToString() + "/" + Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day.ToString() + "/" + Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year.ToString()

        'Try
        'If cboLoaithietbi3.SelectedValue.ToString() = "-1" And cboThietbi3.SelectedValue.ToString() = "-1" Then
        '    SqlText = "SELECT  CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) AS TU_NGAY, CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "Short date") & "',103) AS DEN_NGAY, dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, (dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN) AS HO_TEN, dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT,      dbo.CONG_VIEC_HANG_NGAY_VT.SO_LUONG, dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.LOAI_MAY.MS_LOAI_MAY, dbo.CONG_VIEC_HANG_NGAY.GHI_CHU         INTO [DBO].rptDAILY_EQUIPMENT_EUEL_TMP   FROM  dbo.NHOM_MAY INNER JOIN   dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN      dbo.CONG_VIEC_HANG_NGAY_THIET_BI INNER JOIN             dbo.CONG_VIEC_HANG_NGAY_NV INNER JOIN             dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_NV.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_VIEC_HANG_NGAY_VT ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_VT.STT_CV ON       dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_NHAN ON dbo.CONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN ON      dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   WHERE     (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & date_TN & "' AND '" & date_DN & "') order by NGAY_TH DESC"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        'End If

        'If cboLoaithietbi3.SelectedValue.ToString() <> "-1" And cboThietbi3.SelectedValue.ToString() <> "-1" Then
        '    SqlText = "SELECT  CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) AS TU_NGAY, CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "Short date") & "',103)  AS DEN_NGAY, dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, (dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN) AS HO_TEN, dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT,      dbo.CONG_VIEC_HANG_NGAY_VT.SO_LUONG, dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.LOAI_MAY.MS_LOAI_MAY, dbo.CONG_VIEC_HANG_NGAY.GHI_CHU         INTO [DBO].rptDAILY_EQUIPMENT_EUEL_TMP   FROM  dbo.NHOM_MAY INNER JOIN   dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN      dbo.CONG_VIEC_HANG_NGAY_THIET_BI INNER JOIN             dbo.CONG_VIEC_HANG_NGAY_NV INNER JOIN             dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_NV.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_VIEC_HANG_NGAY_VT ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_VT.STT_CV ON       dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_NHAN ON dbo.CONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN ON      dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue.ToString() & "') AND (dbo.MAY.MS_MAY = '" & cboThietbi3.SelectedValue.ToString() & "') AND (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & date_TN & "' AND '" & date_DN & "') order by NGAY_TH DESC "
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'End If

        'If cboLoaithietbi3.SelectedValue.ToString() = "-1" And cboThietbi3.SelectedValue.ToString() <> "-1" Then
        '    SqlText = "SELECT  CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) AS TU_NGAY, CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "Short date") & "',103)  AS DEN_NGAY, dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, (dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN) AS HO_TEN, dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT,      dbo.CONG_VIEC_HANG_NGAY_VT.SO_LUONG, dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.LOAI_MAY.MS_LOAI_MAY, dbo.CONG_VIEC_HANG_NGAY.GHI_CHU         INTO [DBO].rptDAILY_EQUIPMENT_EUEL_TMP   FROM  dbo.NHOM_MAY INNER JOIN   dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN      dbo.CONG_VIEC_HANG_NGAY_THIET_BI INNER JOIN             dbo.CONG_VIEC_HANG_NGAY_NV INNER JOIN             dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_NV.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_VIEC_HANG_NGAY_VT ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_VT.STT_CV ON       dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_NHAN ON dbo.CONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN ON      dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   WHERE     (dbo.MAY.MS_MAY = '" & cboThietbi3.SelectedValue.ToString() & "') AND (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & date_TN & "' AND '" & date_DN & "') order by NGAY_TH DESC"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'End If
        SqlText = "SELECT distinct CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) AS TU_NGAY, CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "Short date") & "',103) AS DEN_NGAY, " & _
        " dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, (dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN) AS HO_TEN,  " & _
        " dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT,      dbo.CONG_VIEC_HANG_NGAY_VT.SO_LUONG, dbo.CONG_VIEC_HANG_NGAY.MS_MAY,  " & _
        " dbo.LOAI_MAY.MS_LOAI_MAY, dbo.CONG_VIEC_HANG_NGAY.GHI_CHU INTO [DBO].rptDAILY_EQUIPMENT_EUEL_TMP " & _
        " FROM CONG_VIEC_HANG_NGAY INNER JOIN CONG_VIEC_HANG_NGAY_NV ON CONG_VIEC_HANG_NGAY.STT_CV = CONG_VIEC_HANG_NGAY_NV.STT_CV INNER JOIN " & _
        " CONG_VIEC_HANG_NGAY_VT ON CONG_VIEC_HANG_NGAY.STT_CV = CONG_VIEC_HANG_NGAY_VT.STT_CV " & _
        " INNER JOIN  dbo.CONG_NHAN ON dbo.CONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN MAY    " & _
        " ON MAY.MS_MAY=CONG_VIEC_HANG_NGAY.MS_MAY INNER JOIN MAY_NHA_XUONG ON  " & _
        " MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP)  " & _
        " FROM MAY_NHA_XUONG A WHERE A.MS_MAY=CONG_VIEC_HANG_NGAY.MS_MAY) " & _
        " INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
        " INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON " & _
        " NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_MAY.GROUP_ID " & _
        " INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID=NHOM.GROUP_ID  " & _
        " WHERE    USERNAME='Administrator' and  (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "Short date") & "',103)) " & _
        " and NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' "
        If cboLoaithietbi3.SelectedValue <> "-1" And Not cboLoaithietbi3.SelectedValue Is Nothing Then
            SqlText = SqlText + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" And Not cboNhomthietbi3.SelectedValue Is Nothing Then
            SqlText = SqlText + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        If cboThietbi3.SelectedValue <> "-1" And Not cboThietbi3.SelectedValue Is Nothing Then
            SqlText = SqlText + " AND CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY=N'" & cboThietbi3.SelectedValue & "'"
        End If
        SqlText = SqlText + " order by NGAY_TH DESC"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'If cboLoaithietbi3.SelectedValue.ToString() <> "-1" And cboThietbi3.SelectedValue.ToString() = "-1" Then
        '    SqlText = "SELECT  CAST('01/01/1900' AS DATETIME(8)) AS TU_NGAY, CAST('01/01/1900' AS DATETIME(8)) AS DEN_NGAY, dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, (dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN) AS HO_TEN, dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT,      dbo.CONG_VIEC_HANG_NGAY_VT.SO_LUONG, dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.LOAI_MAY.MS_LOAI_MAY, dbo.CONG_VIEC_HANG_NGAY.GHI_CHU         INTO [DBO].rptDAILY_EQUIPMENT_EUEL_TMP   FROM  dbo.NHOM_MAY INNER JOIN   dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN      dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN      dbo.CONG_VIEC_HANG_NGAY_THIET_BI INNER JOIN             dbo.CONG_VIEC_HANG_NGAY_NV INNER JOIN             dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_NV.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_VIEC_HANG_NGAY_VT ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_VT.STT_CV ON       dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV INNER JOIN            dbo.CONG_NHAN ON dbo.CONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN ON      dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue.ToString() & "')  AND (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & date_TN & "' AND '" & date_DN & "')"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'End If
        Printpreview10()


    End Sub
    Sub Printpreview10()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDAILY_EQUIPMENT_EUEL_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Me.Cursor = Windows.Forms.Cursors.Default
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDAILY_EQUIPMENT_EUEL.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDAILY_EQUIPMENT_EUEL_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.insert_rptDAILY_EQUIPMENT_EUEL_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTieuDeDailyEquipFuel"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

    End Sub




    Private Sub loadCboNam()
        Dim dt As New DataTable
        Dim str As String = "SELECT DISTINCT YEAR(NGAY) AS NAM_NGUNG FROM  dbo.THOI_GIAN_NGUNG_MAY ORDER BY YEAR(NGAY) DESC"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        cboNam.DataSource = dt
        cboNam.ValueMember = "NAM_NGUNG"
        cboNam.DisplayMember = "NAM_NGUNG"
    End Sub


    Private Function dtTUAN(ByVal year As String) As DataTable
        Dim date_TN As Date = "01/01/" + year
        Dim date_DN As Date = "07/01/" + year
        Dim week As Integer = 1
        Dim dt, dtRowFull As New DataTable
        Dim drFirst, drNext, drFull As DataRow
        dt.Columns.Add("TU_NGAY")
        dt.Columns.Add("DEN_NGAY")
        dt.Columns.Add("TUAN")
        drFirst = dt.NewRow()
        drFirst("TU_NGAY") = date_TN.ToShortDateString()
        drFirst("DEN_NGAY") = date_DN.ToShortDateString()
        drFirst("TUAN") = week
        dt.Rows.Add(drFirst)
        While (1)
            Dim count As Integer = 6
            count = count + 1
            date_TN = DateSerial(Convert.ToDateTime(date_TN).Year, Convert.ToDateTime(date_TN).Month, Convert.ToDateTime(date_TN).Day + count).Date
            Dim count1 As Integer = 6
            count1 = count1 + 1
            date_DN = DateSerial(Convert.ToDateTime(date_DN).Year, Convert.ToDateTime(date_DN).Month, Convert.ToDateTime(date_DN).Day + count1).Date
            If date_DN > CDate("31/12/" + year) Then
                Exit While
            End If
            drNext = dt.NewRow()
            drNext("TU_NGAY") = date_TN.ToShortDateString()
            drNext("DEN_NGAY") = date_DN.ToShortDateString()
            week = week + 1
            drNext("TUAN") = week
            dt.Rows.Add(drNext)
        End While

        dtRowFull.Columns.Add("TU_NGAY")
        dtRowFull.Columns.Add("DEN_NGAY")
        dtRowFull.Columns.Add("TUAN")
        dtRowFull.Columns.Add("TN_DN_TUAN")
        For Each row As DataRow In dt.Rows
            drFull = dtRowFull.NewRow()
            drFull("TU_NGAY") = row("TU_NGAY").ToString()
            drFull("DEN_NGAY") = row("DEN_NGAY").ToString()
            drFull("TUAN") = row("TUAN").ToString()
            drFull("TN_DN_TUAN") = "Tuần " & row("TUAN").ToString() & " (" & row("TU_NGAY").ToString() & " đến " & row("DEN_NGAY").ToString() & ")"
            dtRowFull.Rows.Add(drFull)
        Next
        Return dtRowFull
    End Function


    Private Sub loadCboTuan(ByVal year As String)
        cboTuan.DataSource = dtTUAN(year)
        cboTuan.DisplayMember = "TN_DN_TUAN"
        cboTuan.ValueMember = "TUAN"
        Dim date_TN As Date = "01/01/" + year
        Dim date_DN As Date = Now().Day.ToString + "/" + Now().Month.ToString + "/" + year
        Dim tuan As Integer = 1
        tuan = Math.Round((DateDiff(DateInterval.Day, date_TN, date_DN) / 7) + 1)
        Try
            cboTuan.SelectedValue = tuan.ToString
        Catch ex As Exception
        End Try
    End Sub


    Private Sub setTextNGAY(ByVal year As String, ByVal tuan As String)
        For Each row As DataRow In dtTUAN(year).Rows
            If row("TUAN").ToString() = tuan Then
                txtTuan_TN.Text = (Convert.ToDateTime(row("TU_NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("TU_NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("TU_NGAY").ToString()).Year.ToString())
                txtTuan_DN.Text = (Convert.ToDateTime(row("DEN_NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("DEN_NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("DEN_NGAY").ToString()).Year.ToString())
                TU_NGAY = row("TU_NGAY").ToString()
                DEN_NGAY = row("DEN_NGAY").ToString()
            End If
        Next

    End Sub


    Private Sub cboNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles cboNam.SelectedIndexChanged
        If cboNam.Items.Count > 0 Then loadCboTuan(cboNam.SelectedValue.ToString())
    End Sub

    Private Sub cboTuan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTuan.SelectedIndexChanged
        setTextNGAY(cboNam.SelectedValue.ToString(), cboTuan.SelectedValue.ToString())
    End Sub


    Private Sub tblPRT_TG_CHAY_MAY()
        Dim dtFisrt, dtLast As New DataTable
        Dim str As String = "SELECT  MS_MAY, NGAY, CHI_SO_DONG_HO FROM THOI_GIAN_CHAY_MAY"
        Dim drLast As DataRow
        'Dim dcFirst, dcLast As DataColumn
        Dim TG_CHAY_MAY As Integer
        dtFisrt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        dtLast.Columns.Add("MS_MAY")
        dtLast.Columns.Add("NGAY")
        dtLast.Columns.Add("CHI_SO_DONG_HO")
        dtLast.Columns.Add("TG_CHAY_MAY")
        dtLast.Columns.Add("PHAN_TRAM")
        'dtLast.Columns.Add("TUAN")
        'dtLast.Columns.Add("TU_NGAY")
        'dtLast.Columns.Add("DEN_NGAY")
        For i As Integer = 0 To dtFisrt.Rows.Count - 1
            Try
                If dtFisrt.Rows(i + 1)("MS_MAY").ToString() <> dtFisrt.Rows(i)("MS_MAY").ToString() Then
                    'Them record cho TH bắt đầu sang một MS_MAY mới
                    drLast = dtLast.NewRow()
                    drLast("MS_MAY") = dtFisrt.Rows(i)("MS_MAY").ToString()
                    drLast("NGAY") = dtFisrt.Rows(i)("NGAY").ToString()
                    drLast("CHI_SO_DONG_HO") = dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()
                    drLast("TG_CHAY_MAY") = Convert.ToInt32(dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY
                    drLast("PHAN_TRAM") = (Convert.ToInt32(dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY) / 168 * 100
                    dtLast.Rows.Add(drLast)

                    TG_CHAY_MAY = 0
                Else

                    drLast = dtLast.NewRow()
                    drLast("MS_MAY") = dtFisrt.Rows(i)("MS_MAY").ToString()
                    drLast("NGAY") = dtFisrt.Rows(i)("NGAY").ToString()
                    drLast("CHI_SO_DONG_HO") = dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()
                    drLast("TG_CHAY_MAY") = Convert.ToInt32(dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY
                    drLast("PHAN_TRAM") = (Convert.ToInt32(dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY) / 168 * 100
                    dtLast.Rows.Add(drLast)

                    TG_CHAY_MAY = Convert.ToInt32(dtFisrt.Rows(i)("CHI_SO_DONG_HO").ToString())
                End If
            Catch ex As Exception
            End Try
        Next
        'Them record cuối vì xét đk If bỏ qua
        drLast = dtLast.NewRow()
        Try


            drLast("MS_MAY") = dtFisrt.Rows(dtFisrt.Rows.Count - 1)("MS_MAY").ToString()
            drLast("NGAY") = dtFisrt.Rows(dtFisrt.Rows.Count - 1)("NGAY").ToString()
            drLast("CHI_SO_DONG_HO") = dtFisrt.Rows(dtFisrt.Rows.Count - 1)("CHI_SO_DONG_HO").ToString()
            drLast("TG_CHAY_MAY") = Convert.ToInt32(dtFisrt.Rows(dtFisrt.Rows.Count - 1)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY
            drLast("PHAN_TRAM") = (Convert.ToInt32(dtFisrt.Rows(dtFisrt.Rows.Count - 1)("CHI_SO_DONG_HO").ToString()) - TG_CHAY_MAY) / 168 * 100
            dtLast.Rows.Add(drLast)
        Catch ex As Exception

        End Try
        'wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
        'DataGridView1.DataSource = dtLast
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.RPT_TG_CHAY_MAY")
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.RPT_TG_CHAY_MAY(MS_MAY NVARCHAR(20), NGAY DATETIME, CHI_SO_DONG_HO INT, TG_CHAY_MAY FLOAT, PHAN_TRAM FLOAT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        For Each row As DataRow In dtLast.Rows
            Dim ngay As String = Convert.ToDateTime(row("NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Year.ToString()
            str = "INSERT INTO [dbo].RPT_TG_CHAY_MAY(MS_MAY, NGAY, CHI_SO_DONG_HO, TG_CHAY_MAY, PHAN_TRAM) VALUES(N'" & row("MS_MAY").ToString() & "','" & ngay & "'," & row("CHI_SO_DONG_HO").ToString() & "," & row("TG_CHAY_MAY").ToString() & "," & row("PHAN_TRAM").ToString() & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
    End Sub


    Private Sub tblPRT_TG_NGUNG_MAY_DT()
        Dim dtFirst, dtLast As New DataTable
        Dim drFirst, drLast As DataRow
        Dim str As String
        dtFirst.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  MS_MAY, NGAY, TU_GIO, DEN_GIO, MS_PHIEU_BAO_TRI, GHI_CHU FROM  dbo.THOI_GIAN_NGUNG_MAY WHERE  (MS_PHIEU_BAO_TRI IS NULL)"))
        dtLast.Columns.Add("MS_MAY")
        dtLast.Columns.Add("NGAY")
        dtLast.Columns.Add("TU_GIO")
        dtLast.Columns.Add("DEN_GIO")
        dtLast.Columns.Add("TG_NGUNG_MAY")
        dtLast.Columns.Add("MS_PHIEU_BAO_TRI")
        dtLast.Columns.Add("GHI_CHU")
        dtLast.Columns.Add("PHAN_TRAM")

        For Each drFirst In dtFirst.Rows
            drLast = dtLast.NewRow()
            drLast("MS_MAY") = drFirst("MS_MAY").ToString()
            drLast("NGAY") = drFirst("NGAY").ToString()
            drLast("TU_GIO") = drFirst("TU_GIO").ToString()
            drLast("DEN_GIO") = drFirst("DEN_GIO").ToString()
            drLast("TG_NGUNG_MAY") = Convert.ToDateTime(drFirst("DEN_GIO").ToString()).Subtract(Convert.ToDateTime(drFirst("TU_GIO").ToString())).TotalHours
            drLast("MS_PHIEU_BAO_TRI") = drFirst("MS_PHIEU_BAO_TRI").ToString()
            drLast("GHI_CHU") = drFirst("GHI_CHU").ToString()
            drLast("PHAN_TRAM") = (Convert.ToDateTime(drFirst("DEN_GIO").ToString()).Subtract(Convert.ToDateTime(drFirst("TU_GIO").ToString())).TotalHours) / 168 * 100
            dtLast.Rows.Add(drLast)
        Next
        'DataGridView1.DataSource = dtLast

        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.PRT_TG_NGUNG_MAY_DT")
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.PRT_TG_NGUNG_MAY_DT(MS_MAY NVARCHAR(20), NGAY DATETIME, TG_NGUNG_MAY FLOAT, MS_PHIEU_BAO_TRI NVARCHAR(20), GHI_CHU NVARCHAR(150), PHAN_TRAM FLOAT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        For Each row As DataRow In dtLast.Rows
            Dim ngay As String = Convert.ToDateTime(row("NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Year.ToString()
            str = "INSERT INTO [dbo].PRT_TG_NGUNG_MAY_DT(MS_MAY, NGAY, TG_NGUNG_MAY, MS_PHIEU_BAO_TRI, GHI_CHU, PHAN_TRAM) VALUES(N'" & row("MS_MAY").ToString() & "','" & ngay & "'," & row("TG_NGUNG_MAY").ToString() & ",'" & row("MS_PHIEU_BAO_TRI").ToString() & "',N'" & row("GHI_CHU").ToString() & "'," & row("PHAN_TRAM").ToString() & ")"
            'MsgBox(str)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
    End Sub

    Private Sub tblPRT_TG_NGUNG_MAY_PMR()
        Dim dtFirst, dtLast As New DataTable
        Dim drFirst, drLast As DataRow
        Dim str As String
        dtFirst.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  MS_MAY, NGAY, TU_GIO, DEN_GIO, MS_PHIEU_BAO_TRI, GHI_CHU FROM  dbo.THOI_GIAN_NGUNG_MAY WHERE  (MS_PHIEU_BAO_TRI IS NOT NULL)"))
        dtLast.Columns.Add("MS_MAY")
        dtLast.Columns.Add("NGAY")
        dtLast.Columns.Add("TU_GIO")
        dtLast.Columns.Add("DEN_GIO")
        dtLast.Columns.Add("TG_NGUNG_MAY")
        dtLast.Columns.Add("MS_PHIEU_BAO_TRI")
        dtLast.Columns.Add("GHI_CHU")
        dtLast.Columns.Add("PHAN_TRAM")

        For Each drFirst In dtFirst.Rows
            drLast = dtLast.NewRow()
            drLast("MS_MAY") = drFirst("MS_MAY").ToString()
            drLast("NGAY") = drFirst("NGAY").ToString()
            drLast("TU_GIO") = drFirst("TU_GIO").ToString()
            drLast("DEN_GIO") = drFirst("DEN_GIO").ToString()
            drLast("TG_NGUNG_MAY") = Convert.ToDateTime(drFirst("DEN_GIO").ToString()).Subtract(Convert.ToDateTime(drFirst("TU_GIO").ToString())).TotalHours
            drLast("MS_PHIEU_BAO_TRI") = drFirst("MS_PHIEU_BAO_TRI").ToString()
            drLast("GHI_CHU") = drFirst("GHI_CHU").ToString()
            drLast("PHAN_TRAM") = (Convert.ToDateTime(drFirst("DEN_GIO").ToString()).Subtract(Convert.ToDateTime(drFirst("TU_GIO").ToString())).TotalHours) / 168 * 100
            dtLast.Rows.Add(drLast)
        Next
        'DataGridView1.DataSource = dtLast

        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.PRT_TG_NGUNG_MAY_PMR")
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.PRT_TG_NGUNG_MAY_PMR(MS_MAY NVARCHAR(20), NGAY DATETIME, TG_NGUNG_MAY FLOAT, MS_PHIEU_BAO_TRI NVARCHAR(20), GHI_CHU NVARCHAR(150), PHAN_TRAM FLOAT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        For Each row As DataRow In dtLast.Rows
            Dim ngay As String = Convert.ToDateTime(row("NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("NGAY").ToString()).Year.ToString()
            str = "INSERT INTO [dbo].PRT_TG_NGUNG_MAY_PMR(MS_MAY, NGAY, TG_NGUNG_MAY, MS_PHIEU_BAO_TRI, GHI_CHU, PHAN_TRAM) VALUES(N'" & row("MS_MAY").ToString() & "','" & ngay & "'," & row("TG_NGUNG_MAY").ToString() & ",'" & row("MS_PHIEU_BAO_TRI").ToString() & "',N'" & row("GHI_CHU").ToString() & "'," & row("PHAN_TRAM").ToString() & ")"
            'MsgBox(str)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
    End Sub

    Sub ShowrptThoiGianHuHong()
        Dim str As String = ""
        Dim objReader As SqlDataReader
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "CreateTHOI_GIAN_HU_HONG_DATA", dtpTu.Value, dtpDen.Value)
        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT THOI_GIAN_NGUNG_MAY.*,THOI_GIAN_NGUNG_MAY.DEN_GIO-THOI_GIAN_NGUNG_MAY.TU_GIO AS THOI_GIAN_NGUNG_MAY FROM THOI_GIAN_NGUNG_MAY INNER JOIN NGUYEN_NHAN_DUNG_MAY ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN WHERE NGUYEN_NHAN_DUNG_MAY.HU_HONG<>0")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG SET THOI_GIAN_NGUNG_MAY=THOI_GIAN_NGUNG_MAY+" & (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Hour * 60) + (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Minute) & " WHERE MS_HE_THONG=" & objReader.Item("MS_HE_THONG"))
        End While
        objReader.Close()

        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG,TEN_HE_THONG,COUNT(*) AS SO_LAN_HU_HONG,SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_HU_HONG FROM THOI_GIAN_NGUNG_MAY_DO_HU_HONG_TMP WHERE HU_HONG=1 GROUP BY MS_HE_THONG,TEN_HE_THONG")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG SET SO_LAN_HU_HONG=" & objReader.Item("SO_LAN_HU_HONG") & ",THOI_GIAN_HU_HONG=" & objReader.Item("THOI_GIAN_HU_HONG") & " WHERE MS_HE_THONG=" & objReader.Item("MS_HE_THONG"))
        End While
        objReader.Close()

        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_HU_HONG")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptThoiGianHuHong()
        ReportPreview("reports/rptBreakdownTime.rpt")
KetThuc:
        Try
            str = "drop table rptTHOI_GIAN_HU_HONG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTieuDeThoiGianHuHong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub ShowrptThoiGianHuHongTheoThietBi()
        Dim str As String = ""
        Dim objReader As SqlDataReader

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "THOI_GIAN_NGUNG_MAY_DO_HU_HONG_THEO_MAY_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_HU_HONG")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTieuDeThoiGianHuHong")

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "CreateTHOI_GIAN_HU_HONG_THEO_LOAI_MAY_DATA", dtpTu.Value, dtpDen.Value, cboTG_LoaiTB.SelectedValue.ToString)
        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY, DEN_NGAY-TU_NGAY AS THOI_GIAN_NGUNG_MAY FROM THOI_GIAN_NGUNG_MAY_DO_HU_HONG_THEO_MAY_TMP") ' "SELECT MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY, SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_NGUNG_MAY FROM THOI_GIAN_NGUNG_MAY_DO_HU_HONG_THEO_MAY_TMP GROUP BY MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG_THEO_MAY SET THOI_GIAN_NGUNG_MAY=THOI_GIAN_NGUNG_MAY+" & (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Hour * 60) + (CDate(objReader.Item("THOI_GIAN_NGUNG_MAY")).Minute) & " WHERE MS_LOAI_MAY='" & objReader.Item("MS_LOAI_MAY") & "' AND MS_MAY=N'" & objReader.Item("MS_MAY") & "'")
        End While
        objReader.Close()

        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY,COUNT(*) AS SO_LAN_HU_HONG,SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_HU_HONG FROM THOI_GIAN_NGUNG_MAY_DO_HU_HONG_THEO_MAY_TMP WHERE HU_HONG=1 GROUP BY MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "QL_SEARCH", "UPDATE rptTHOI_GIAN_HU_HONG_THEO_MAY SET SO_LAN_HU_HONG=" & objReader.Item("SO_LAN_HU_HONG") & ",THOI_GIAN_HU_HONG=" & objReader.Item("THOI_GIAN_HU_HONG") & " WHERE MS_LOAI_MAY='" & objReader.Item("MS_LOAI_MAY") & "' AND MS_MAY=N'" & objReader.Item("MS_MAY") & "'")
        End While
        objReader.Close()

        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_HU_HONG_THEO_MAY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptThoiGianHuHongTheoThietBi()
        ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_MAY.rpt")
KetThuc:
        Try
            str = "drop table rptTHOI_GIAN_HU_HONG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTieuDeThoiGianHuHong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptThoiGianHuHong()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTieuDeThoiGianHuHong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "NgayIn", Commons.Modules.TypeLanguage)
        Dim DayChuyen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "DayChuyen", Commons.Modules.TypeLanguage)
        Dim ThoiGianHH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianTBKhacPhucHH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianKhacPhucTB", Commons.Modules.TypeLanguage)
        Dim SoLanHuhong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "SoLanHuhong", Commons.Modules.TypeLanguage)
        Dim ThoiGianTBHuHong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianTBHuHong", Commons.Modules.TypeLanguage)
        Dim ThoiGianChayMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "ThoiGianChayMay", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "Tong", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBreakdownTime", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lbTuNgay.Text + " " + Format(dtpTu.Value, "Short date") + " " + lbDenNgay.Text + " " + Format(dtpDen.Value, "Short date")
        str = "Create table dbo.rptTieuDeThoiGianHuHong(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        "DieuKienLoc nvarchar(255),ThoiGian Nvarchar(150),DayChuyen nvarchar(100),ThoiGianHuhong nvarchar(255),ThoiGianKhacPhucTB nvarchar(255), " & _
        "SoLanHuhong nvarchar(255),ThoiGianTBHuHong nvarchar(255),ThoiGianChayMay nvarchar(255),Tong nvarchar(50),NguoiLap nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeThoiGianHuHong(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,DayChuyen,ThoiGianHuhong,ThoiGianKhacPhucTB,SoLanHuhong,ThoiGianTBHuHong,ThoiGianChayMay,Tong,NguoiLap) values(" & Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & _
        "',N'" & DayChuyen & "',N'" & ThoiGianHH & "',N'" & ThoiGianTBKhacPhucHH & "',N'" & SoLanHuhong & "',N'" & ThoiGianTBHuHong & "',N'" & ThoiGianChayMay & "',N'" & Tong & "',N'" & NguoiLap & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub CreaterptThoiGianHuHongTheoThietBi()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTieuDeThoiGianHuHongTheoThietBi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim SoLanHuhong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "SoLanHuhong", Commons.Modules.TypeLanguage)
        Dim ThoiGianNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianHuHong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "ThoiGianHuHong", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "Tong", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = lbTuNgay.Text + " " + Format(dtpTu.Value, "Short date") + "     " + lbDenNgay.Text + " " + Format(dtpDen.Value, "Short date")
        str = "Create table dbo.rptTieuDeThoiGianHuHongTheoThietBi(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        "DieuKienLoc nvarchar(255),ThoiGian Nvarchar(150),ThietBi nvarchar(30),LoaiThietBi nvarchar(50),SoLanHuhong nvarchar(30),ThoiGianNgungMay nvarchar(30)," & _
        "ThoiGianHuHong nvarchar(50),Tong nvarchar(50),NguoiLap nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeThoiGianHuHongTheoThietBi(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,ThietBi,LoaiThietBi,SoLanHuhong,ThoiGianNgungMay,ThoiGianHuHong,Tong,NguoiLap) values(" & Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & _
        "',N'" & ThietBi & "',N'" & LoaiThietBi & "',N'" & SoLanHuhong & "',N'" & ThoiGianNgungMay & "',N'" & ThoiGianHuHong & "',N'" & Tong & "',N'" & NguoiLap & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub CreaterptChuKyHieuChuanKeTiep()
        Dim str As String = ""
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeSubChuKyHC")
        Catch ex As Exception
        End Try
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeChuKyHC")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayIn", Commons.Modules.TypeLanguage)
        Dim LoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "LoaiMay", Commons.Modules.TypeLanguage)
        Dim NhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NhomMay", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ThietBi", Commons.Modules.TypeLanguage)
        Dim ChuKyHC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ChuKyHC", Commons.Modules.TypeLanguage)
        Dim NgayHCKT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayHCKT", Commons.Modules.TypeLanguage)
        Dim NgayHCCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayHCCuoi", Commons.Modules.TypeLanguage)
        Dim TenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TenViTri", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeChuKyHC(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255),LoaiMay nvarchar(50)," & _
        "NhomMay nvarchar(50),ThietBi nvarchar(50),ChuKyHC nvarchar(50),NgayHCKT nvarchar(50)) Insert into [DBO].rptTieuDeChuKyHC values(" & Commons.Modules.TypeLanguage & ",N'" & _
        NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & LoaiMay & "',N'" & NhomMay & "',N'" & ThietBi & "',N'" & ChuKyHC & "',N'" & NgayHCKT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TenPT", Commons.Modules.TypeLanguage)
        Dim ViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ViTri", Commons.Modules.TypeLanguage)
        Dim Noi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "Noi", Commons.Modules.TypeLanguage)
        Dim Ngoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "Ngoai", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeSubChuKyHC(TenPT nvarchar(50),ViTri nvarchar(50),ChuKyHieuChuan nvarchar(50),Noi nvarchar(60),Ngoai nvarchar(60),NgayHCKT nvarchar(100),NgayHCCuoi nvarchar(50),TenViTri nvarchar(50))" & _
        " Insert into [DBO].rptTieuDeSubChuKyHC values(N'" & TenPT & "',N'" & ViTri & "',N'" & ChuKyHC & "',N'" & Noi & "',N'" & Ngoai & "',N'" & NgayHCKT & "',N'" & NgayHCCuoi & "',N'" & TenViTri & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptChuKyHieuChuanKeTiep()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptChuKyHieuChuanKeTiep", cboLoaithietbi3.SelectedValue, cboNhomthietbi3.SelectedValue, cboThietbi3.SelectedValue)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select COUNT(*) AS Tong FROM rptChuKyHieuChuanKeTiep")
        While objReader.Read
            If objReader.Item("Tong") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptChuKyHieuChuanKeTiep()
        ReportPreview("reports\rptChuKyHieuChuanKeTiep.rpt")
    End Sub

    Sub ShowrptDanhSachThietBiDaHC()
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachThietBiDaHC")
        Catch ex As Exception
        End Try
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetDanhSachThietBiDaHC", txtNam.Text)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDanhSachThietBiDaHC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeDanhSachThietBiDaHC()
        ReportPreview("reports\rptDanhSachThietBiDaHC.rpt")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachThietBiDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachThietBiDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTHONG_TIN_CHUNG_TMP")
        Catch ex As Exception
        End Try
    End Sub

    Sub ShowrptDanhSachDHDDaHC()
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachDHDDaHC")
        Catch ex As Exception
        End Try
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetDanhSachDHDDaHC", txtNam.Text, rdNoiNgoai.Checked)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDanhSachDHDDaHC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeDanhSachDHDDaHC()
        ReportPreview("reports\rptDanhSachDHDDaHC.rpt")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachDHDDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachDHDDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTHONG_TIN_CHUNG_TMP")
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTieudeDanhSachThietBiDaHC()
        Dim str As String = ""
        Try
            RefeshHeaderReport()
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachThietBiDaHC")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TrangIn", Commons.Modules.TypeLanguage)
        Dim MSMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "MSMay", Commons.Modules.TypeLanguage)
        Dim NhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NhomMay", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "SoThe", Commons.Modules.TypeLanguage)
        Dim NgayHCCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayHCCuoi", Commons.Modules.TypeLanguage)
        Dim CKHieuChuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "CKHieuChuan", Commons.Modules.TypeLanguage)
        Dim NgayHCKe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayHCKe", Commons.Modules.TypeLanguage)
        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NhaXuong", Commons.Modules.TypeLanguage)

        str = "CREATE TABLE [dbo].rptTieuDeDanhSachThietBiDaHC(TypeLanguage int, TIEUDE NVARCHAR(100),NGAYIN NVARCHAR(30),TRANGIN NVARCHAR(30),MSMAY NVARCHAR(30),NHOMMAY NVARCHAR(30),SOTHE NVARCHAR(30),NGAYHCCUOI NVARCHAR(50),CKHIEUCHUAN NVARCHAR(50),NGAYHCKE NVARCHAR(50),NHAXUONG NVARCHAR(30)) " & _
              " INSERT INTO [dbo].rptTieuDeDanhSachThietBiDaHC(commons.Modules.TypeLanguage,TIEUDE,NGAYIN,TRANGIN,MSMAY,NHOMMAY,SOTHE,NGAYHCCUOI,CKHIEUCHUAN,NGAYHCKE,NHAXUONG) VALUES(" & _
              Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & MSMay & "',N'" & NhomMay & "',N'" & SoThe & "',N'" & NgayHCCuoi & "',N'" & CKHieuChuan & "',N'" & NgayHCKe & "',N'" & NhaXuong & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub CreaterptTieudeDanhSachDHDDaHC()
        Dim str As String = ""
        Try
            RefeshHeaderReport()
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachDHDDaHC")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TieuDe_", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        Dim LOAI_MAY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "LOAI_MAY_", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TrangIn_", Commons.Modules.TypeLanguage)
        Dim MSMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_MAY_", Commons.Modules.TypeLanguage)
        Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_PT_", Commons.Modules.TypeLanguage)
        Dim TEN_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TEN_PT_", Commons.Modules.TypeLanguage)
        Dim MS_VI_TRI As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_VI_TRI_", Commons.Modules.TypeLanguage)
        Dim NGAY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "NGAY_", Commons.Modules.TypeLanguage)
        Dim CHU_KY_HC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "CHU_KY_HC_", Commons.Modules.TypeLanguage)

        str = "CREATE TABLE [dbo].rptTieuDeDanhSachDHDDaHC(TypeLanguage int, TIEUDE NVARCHAR(100),LOAI_MAY NVARCHAR(30),TRANGIN NVARCHAR(30),MSMAY NVARCHAR(30),MS_PT NVARCHAR(30),TEN_PT NVARCHAR(100),MS_VI_TRI NVARCHAR(30),NGAY NVARCHAR (30),CKHIEUCHUAN NVARCHAR(50)) " & _
              " INSERT INTO [dbo].rptTieuDeDanhSachDHDDaHC(commons.Modules.TypeLanguage,TIEUDE,LOAI_MAY,TRANGIN,MSMAY,MS_PT,TEN_PT,MS_VI_TRI,NGAY,CKHIEUCHUAN) VALUES(" & _
              Commons.Modules.TypeLanguage & ",N'" & TieuDe & "', N'" & LOAI_MAY & "' , N'" & TrangIn & "',N'" & MSMay & "',N'" & MS_PT & "',N'" & TEN_PT & "',N'" & MS_VI_TRI & "',N'" & NGAY & "',N'" & CHU_KY_HC & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptChuKyHieuChuanNoi_Ngoai()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetChuKyHieuChuanNoi_Ngoai", IIf(rdNoiNgoai.Checked, 1, 0), txtNam.Text)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select COUNT(*) AS Tong FROM rptChuKyHieuChuanKeTiepNoi_Ngoai")
        While objReader.Read
            If objReader.Item("Tong") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeChuKyHCNoiNgoai()
        ReportPreview("reports\rptChuKyHieuChuanNoi_Ngoai.rpt")
    End Sub
    Sub CreaterptTieudeChuKyHCNoiNgoai()
        Dim str As String = ""
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeChuKyHCNoiNgoai")
        Catch ex As Exception
        End Try
        Dim TieuDe As String
        If rdNoiNgoai.Checked Then
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TieuDe", Commons.Modules.TypeLanguage)
        Else
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TieuDe1", Commons.Modules.TypeLanguage)
        End If
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayIn", Commons.Modules.TypeLanguage)
        Dim MaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "MaPT", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TenPT", Commons.Modules.TypeLanguage)
        Dim PartNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "PartNo", Commons.Modules.TypeLanguage)
        Dim ItemCode As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ItemCode", Commons.Modules.TypeLanguage)
        Dim DanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "DanhGia", Commons.Modules.TypeLanguage)
        Dim NoiSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NoiSD", Commons.Modules.TypeLanguage)
        Dim ChuKyHC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ChuKyHieuChuan", Commons.Modules.TypeLanguage)
        Dim NgayKiemDinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayKiemDinh", Commons.Modules.TypeLanguage)
        Dim NgayHetHan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayHetHan", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "STT", Commons.Modules.TypeLanguage)
        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NhaXuong", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ThietBi", Commons.Modules.TypeLanguage)
        TieuDe = TieuDe + " " + txtNam.Text
        str = "Create table [dbo].rptTieuDeChuKyHCNoiNgoai(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        " STT nvarchar(5),MaPT nvarchar(30),TenPT nvarchar(50),PartNo nvarchar(30),ItemCode nvarchar(30), " & _
        "DanhGia nvarchar(20),ChuKyHC nvarchar(30),NgayKiemDinh nvarchar(50),NgayHetHan nvarchar(50),NoiSD nvarchar(20),NhaXuong nvarchar(100),ThietBi nvarchar(100)) " & _
        " Insert into [DBO].rptTieuDeChuKyHCNoiNgoai values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        STT & "',N'" & MaPT & "',N'" & TenPT & "',N'" & PartNo & "',N'" & ItemCode & "',N'" & DanhGia & "',N'" & _
        ChuKyHC & "',N'" & NgayKiemDinh & "',N'" & NgayHetHan & "',N'" & NoiSD & "',N'" & NhaXuong & "',N'" & ThietBi & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    ''THỜI GIAN NGỪNG MÁY'''''''
    Sub LoadcboNguyenNhanNgungMay()
        cboNguyenNhan.Value = "MS_NGUYEN_NHAN"
        cboNguyenNhan.Display = "TEN_NGUYEN_NHAN"
        cboNguyenNhan.StoreName = "GetNGUYEN_NHAN_DUNG_MAY"
        cboNguyenNhan.BindDataSource()

        cboNguyenNhanNM.Value = "MS_NGUYEN_NHAN"
        cboNguyenNhanNM.Display = "TEN_NGUYEN_NHAN"
        cboNguyenNhanNM.StoreName = "GetNGUYEN_NHAN_DUNG_MAY"
        cboNguyenNhanNM.BindDataSource()
    End Sub
    Sub LoadcboDiaDiem()
        cboDiaDiem.Value = "MS_N_XUONG"
        cboDiaDiem.Display = "TEN_N_XUONG"
        cboDiaDiem.Param = Commons.Modules.UserName
        cboDiaDiem.StoreName = "PermisionNHA_XUONG"
        cboDiaDiem.BindDataSource()
    End Sub
    Sub LoadcbiLoaiMay()
        If cboDiaDiem.Text = "" Then
            Exit Sub
        Else
            Dim str As String = ""
            str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
            " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
            " NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
            " THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem.SelectedValue & "' AND USERS.USERNAME ='" & Commons.Modules.UserName & "'"
            cboLoaiTB_P.Display = "TEN_LOAI_MAY"
            cboLoaiTB_P.Value = "MS_LOAI_MAY"
            cboLoaiTB_P.StoreName = "QL_SEARCH"
            cboLoaiTB_P.Param = str
            cboLoaiTB_P.BindDataSource()
        End If
    End Sub
    Sub LoadcboNhomMay()
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        If cboLoaiTB_P.SelectedValue = "-1" Then
            str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN " & _
            " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
            " NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
            " THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID " & _
            " WHERE NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem.SelectedValue & "' AND USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        Else
            str = " SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN " & _
            " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
            " THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY WHERE  LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB_P.SelectedValue & "'"
        End If
        cboNhomMay.Display = "TEN_NHOM_MAY"
        cboNhomMay.Value = "MS_NHOM_MAY"
        cboNhomMay.StoreName = "QL_SEARCH"
        cboNhomMay.Param = str
        cboNhomMay.BindDataSource()
    End Sub
    Sub LoadcboThietBiLoc()
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT THOI_GIAN_NGUNG_MAY.MS_MAY, THOI_GIAN_NGUNG_MAY.MS_MAY AS TEN_MAY " & _
        " FROM  THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON THOI_GIAN_NGUNG_MAY.MS_MAY = MAY.MS_MAY INNER JOIN " & _
        " NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
        " NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'"
        If cboNhomMay.SelectedValue = "-1" Then
            If cboLoaiTB.SelectedValue = "-1" Then
                str = str + " AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
            Else
                str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB_P.SelectedValue & "'"
            End If
        Else
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
        End If
        cboThietbi_P.Display = "TEN_MAY"
        cboThietbi_P.Value = "MS_MAY"
        cboThietbi_P.StoreName = "QL_SEARCH"
        cboThietbi_P.Param = str
        cboThietbi_P.BindDataSource()
    End Sub
    Sub LoadcboThietBi_NM()
        If cboNhomthietbi3.SelectedIndex = -1 Then
            cboThietbi_NM.Text = ""
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID where USERNAME='" & Commons.Modules.UserName & "' AND MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        cboThietbi_NM.Display = "MAY"
        cboThietbi_NM.Value = "MS_MAY"
        cboThietbi_NM.Param = str
        cboThietbi_NM.StoreName = "QL_SEARCH"
        cboThietbi_NM.BindDataSource()
        If cboThietbi_NM.Items.Count = 0 Then
            cboThietbi_NM.Text = ""
        End If

    End Sub
    Sub CreaterPtTHOI_GIAN_NGUNG_MAY_THEO_NAM()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TieuDeNam", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim TenLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenLoai", Commons.Modules.TypeLanguage)
        Dim TenNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenNhom", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblDiaDiem.Text + " " + cboDiaDiem.Text + "  "

        DieuKienLoc = DieuKienLoc + lblTuNam.Text + " " + txtTunam.Text + "  " + lblDennam.Text + " " + txtDennam.Text
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_NAM"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [DBO].rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_NAM(TieuDe nvarchar(255),NgayIn nvarchar(30),TrangIn nvarchar(30)," & _
        " ThietBi nvarchar(50),TenLoai nvarchar(50),TenNhom nvarchar(50),DieuKienLoc nvarchar(255))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [DBO].rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_NAM(TieuDe,NgayIn,TrangIn,ThietBi,TenLoai,TenNhom,DieuKienLoc) values(N'" & _
         TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & ThietBi & "',N'" & TenLoai & "',N'" & TenNhom & "',N'" & DieuKienLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptTHOI_GIAN_NGUNG_MAY_THEO_NAM()
        If txtTunam.Text.Length < 4 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNamKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtTunam.Focus()
            Exit Sub
        End If
        If txtDennam.Text.Length < 4 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNamKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtTunam.Focus()
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        CreaterPtTHOI_GIAN_NGUNG_MAY_THEO_NAM()
        Dim str As String = ""
        Try
            str = "drop table rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT TEN_N_XUONG,NHOM_MAY.MS_NHOM_MAY,TEN_NHOM_MAY,LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY, " & _
        " THOI_GIAN_NGUNG_MAY.MS_MAY, THOI_GIAN_NGUNG_MAY.NGAY, THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_GIO, " & _
        " CONVERT(FLOAT,DATEDIFF(MI, TU_GIO,DEN_GIO))/60 AS THOI_GIAN ,NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
        " INTO [DBO].rptTHOI_GIAN_NGUNG_MAY_THEO_NAM  FROM  THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON THOI_GIAN_NGUNG_MAY.MS_MAY = MAY.MS_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY=THOI_GIAN_NGUNG_MAY.MS_MAY) " & _
        " INNER JOIN  NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY  " & _
        " INNER JOIN  NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM  " & _
        " ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN  NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID  " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID INNER JOIN NGUYEN_NHAN_DUNG_MAY  " & _
        " ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN=NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
        " INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=NHOM_NHA_XUONG.MS_N_XUONG " & _
        " WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
        " AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaiTB_P.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB_P.SelectedValue & "'"
        End If
        If cboNhomMay.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
        End If
        If cboThietbi_P.SelectedValue <> "-1" Then
            str = str + "AND THOI_GIAN_NGUNG_MAY.MS_MAY=N'" & cboThietbi_P.SelectedValue & "'"
        End If
        str = str + "and DATEDIFF(year, NGAY,GETDATE()) >= DATEDIFF(year, CONVERT(DATETIME,'" & "01/01/" + txtDennam.Text & "',103),GETDATE()) " & _
        " AND DATEDIFF(year, NGAY,GETDATE())<= DATEDIFF(year, CONVERT(DATETIME,'" & "01/01/" + txtTunam.Text & "',103),GETDATE())"
        str = str + " order by  THOI_GIAN_NGUNG_MAY.MS_MAY, NGAY  DESC,TU_GIO "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_NGUNG_MAY_THEO_NAM")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        If Commons.Modules.TypeLanguage = 0 Then
            ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_NAM.rpt")
        Else
            ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_NAM_1.rpt")
        End If
        Me.Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            str = "drop table rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_NAM"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try


    End Sub
    Sub CreaterPtTHOI_GIAN_NGUNG_MAY_THEO_THANG()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TieuDeThang", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim TenLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenLoai", Commons.Modules.TypeLanguage)
        Dim TenNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenNhom", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblDiaDiem.Text + " " + cboDiaDiem.Text + "  "

        DieuKienLoc = DieuKienLoc + lblTuthang.Text + " " + txtTuthang.Text + "  " + lblDenthang.Text + " " + txtDenthang.Text
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_THANG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_THANG(TieuDe nvarchar(255),NgayIn nvarchar(30),TrangIn nvarchar(30)," & _
        " ThietBi nvarchar(50),TenLoai nvarchar(50),TenNhom nvarchar(50),DieuKienLoc nvarchar(255))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [DBO].rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_THANG(TieuDe,NgayIn,TrangIn,ThietBi,TenLoai,TenNhom,DieuKienLoc) values(N'" & _
         TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & ThietBi & "',N'" & TenLoai & "',N'" & TenNhom & "',N'" & DieuKienLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptTHOI_GIAN_NGUNG_MAY_THEO_THANG()
        If txtTuthang.Text.Length < 7 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtTuthang.Focus()
            Exit Sub
        Else
            If Not IsDate("01/" & txtTuthang.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtTuthang.Focus()
                Exit Sub
            End If
        End If
        If txtDenthang.Text.Length < 7 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtDenthang.Focus()
            Exit Sub
        Else
            If Not IsDate("01/" & txtDenthang.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtDenthang.Focus()
                Exit Sub
            End If
        End If
        If txtTuthang.Text <> "  /" And txtDenthang.Text <> "  /" Then
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            CreaterPtTHOI_GIAN_NGUNG_MAY_THEO_THANG()
            Dim str As String = ""
            Try
                str = "drop table rptTHOI_GIAN_NGUNG_MAY_THEO_THANG"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "SELECT DISTINCT TEN_N_XUONG,NHOM_MAY.MS_NHOM_MAY,TEN_NHOM_MAY,LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY, " & _
            " THOI_GIAN_NGUNG_MAY.MS_MAY, THOI_GIAN_NGUNG_MAY.NGAY, THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_GIO, " & _
            " CONVERT(FLOAT,DATEDIFF(MI, TU_GIO,DEN_GIO))/60 AS THOI_GIAN ,NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
            " INTO [DBO].rptTHOI_GIAN_NGUNG_MAY_THEO_THANG  FROM  THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON THOI_GIAN_NGUNG_MAY.MS_MAY = MAY.MS_MAY " & _
            " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY=THOI_GIAN_NGUNG_MAY.MS_MAY) " & _
            " INNER JOIN  NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY  " & _
            " INNER JOIN  NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM  " & _
            " ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN  NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID  " & _
            " INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID INNER JOIN NGUYEN_NHAN_DUNG_MAY  " & _
            " ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN=NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
            " INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=NHOM_NHA_XUONG.MS_N_XUONG " & _
            " WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
            " AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
            If cboLoaiTB_P.SelectedValue <> "-1" Then
                str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB_P.SelectedValue & "'"
            End If
            If cboNhomMay.SelectedValue <> "-1" Then
                str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
            End If
            If cboThietbi_P.SelectedValue <> "-1" Then
                str = str + "AND THOI_GIAN_NGUNG_MAY.MS_MAY=N'" & cboThietbi_P.SelectedValue & "'"
            End If
            str = str + "and DATEDIFF(MONTH, NGAY,GETDATE()) >= DATEDIFF(MONTH, CONVERT(DATETIME,'" & "01/" + txtDenthang.Text & "',103),GETDATE()) " & _
            " AND DATEDIFF(MONTH, NGAY,GETDATE())<= DATEDIFF(MONTH, CONVERT(DATETIME,'" & "01/" + txtTuthang.Text & "',103),GETDATE())"
            str = str + " order by  THOI_GIAN_NGUNG_MAY.MS_MAY, NGAY  DESC,TU_GIO "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_NGUNG_MAY_THEO_THANG")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Windows.Forms.Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()

            If Commons.Modules.TypeLanguage = 0 Then
                ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_THANG.rpt")
            Else
                ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_THEO_THANG_1.rpt")
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
KetThuc:
            Try
                str = "drop table rptTHOI_GIAN_NGUNG_MAY_THEO_THANG"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY_THEO_THANG"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtTuthang.Focus()
        End If
    End Sub
    Sub CreaterptTieuDeThoiGianNgungMay()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TieuDeNguyenNhan", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "Ngay", Commons.Modules.TypeLanguage)
        Dim TuGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TuGio", Commons.Modules.TypeLanguage)
        Dim DenGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "DenGio", Commons.Modules.TypeLanguage)
        Dim NguyenNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NguyenNhan", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "GhiChu", Commons.Modules.TypeLanguage)
        Dim MaLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "MaLoai", Commons.Modules.TypeLanguage)
        Dim TenLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenLoai", Commons.Modules.TypeLanguage)
        Dim MaNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "MaNhom", Commons.Modules.TypeLanguage)
        Dim TenNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenNhom", Commons.Modules.TypeLanguage)
        Dim ThoiGianNghi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThoiGianNghi", Commons.Modules.TypeLanguage)
        Dim TongMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongMay", Commons.Modules.TypeLanguage)
        Dim TongNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongNhom", Commons.Modules.TypeLanguage)
        Dim TongLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongLoai", Commons.Modules.TypeLanguage)
        Dim TongKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongKho", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblDiaDiem.Text + " " + cboDiaDiem.Text + "  "
        DieuKienLoc = DieuKienLoc + lblNguyennhan_P.Text + ": "
        If cboNguyenNhan.SelectedValue = "-1" Then
            If Commons.Modules.TypeLanguage = 0 Then
                DieuKienLoc = DieuKienLoc + "tất cả"
            Else
                DieuKienLoc = DieuKienLoc + " < ALL > "
            End If
        Else
            DieuKienLoc = DieuKienLoc + " " + cboNguyenNhan.SelectedValue.ToString
        End If
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [DBO].rptTIEU_DE_THOI_GIAN_NGUNG_MAY(TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(30),TrangIn nvarchar(30),DieuKienLoc nvarchar(255)," & _
        " ThietBi nvarchar(50),sNgay nvarchar(20),TuGio nvarchar(20),DenGio nvarchar(20),NguyenNhan nvarchar(50),PhieuBaoTri nvarchar(50),GhiChu nvarchar(20), " & _
        " MaLoai nvarchar(50),TenLoai nvarchar(50),MaNhom nvarchar(50),TenNhom nvarchar(50),ThoiGianNghi nvarchar(50),TongMay nvarchar(50),TongNhom nvarchar(50),TongLoai nvarchar(50),TongKho nvarchar(50) )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [DBO].rptTIEU_DE_THOI_GIAN_NGUNG_MAY(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,ThietBi,sNgay,TuGio,DenGio,NguyenNhan,PhieuBaoTri, " & _
        " GhiChu,MaLoai,TenLoai,MaNhom,TenNhom,ThoiGianNghi,TongMay,TongNhom,TongLoai,TongKho) values(" & _
        Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & "',N'" & ThietBi & "',N'" & Ngay & "',N'" & TuGio & "',N'" & DenGio & "',N'" & NguyenNhan & "',N'" & PhieuBaoTri & "',N'" & GhiChu & _
        "',N'" & MaLoai & "',N'" & TenLoai & "',N'" & MaNhom & "',N'" & TenNhom & "',N'" & ThoiGianNghi & "',N'" & TongMay & "',N'" & TongNhom & "',N'" & TongLoai & "',N'" & TongKho & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        CreaterptTieuDeThoiGianNgungMay()
        Dim str As String = ""
        Try
            str = "drop table rptTHOI_GIAN_NGUNG_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT TEN_N_XUONG,NHOM_MAY.MS_NHOM_MAY,TEN_NHOM_MAY,LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY, " & _
        " THOI_GIAN_NGUNG_MAY.MS_MAY, THOI_GIAN_NGUNG_MAY.NGAY, THOI_GIAN_NGUNG_MAY.TU_GIO, THOI_GIAN_NGUNG_MAY.DEN_GIO, " & _
        " CONVERT(FLOAT,DATEDIFF(MI, TU_GIO,DEN_GIO))/60 AS THOI_GIAN ,NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
        " INTO [DBO].rptTHOI_GIAN_NGUNG_MAY  FROM  THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON THOI_GIAN_NGUNG_MAY.MS_MAY = MAY.MS_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY=THOI_GIAN_NGUNG_MAY.MS_MAY) " & _
        " INNER JOIN  NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY  " & _
        " INNER JOIN  NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM  " & _
        " ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN  NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID  " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID INNER JOIN NGUYEN_NHAN_DUNG_MAY  " & _
        " ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN=NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
        " INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=NHOM_NHA_XUONG.MS_N_XUONG " & _
        " WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
        " AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaiTB_P.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB_P.SelectedValue & "'"
        End If
        If cboNhomMay.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
        End If
        If cboThietbi_P.SelectedValue <> "-1" Then
            str = str + "AND THOI_GIAN_NGUNG_MAY.MS_MAY=N'" & cboThietbi_P.SelectedValue & "'"
        End If
        If cboNguyenNhan.SelectedValue <> "-1" Then
            str = str + " and THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN=" & cboNguyenNhan.SelectedValue
        End If
        str = str + " order by  THOI_GIAN_NGUNG_MAY.MS_MAY, NGAY  DESC,TU_GIO "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAN_NGUNG_MAY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY.rpt")
        Me.Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_NGUNG_MAY")
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_THOI_GIAN_NGUNG_MAY")
        Catch ex As Exception
        End Try

    End Sub

    Sub ShowrptThoiGianNgungMayChart()
        If cboThietbi_NM.Text = "" Then
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        CreateTieuDeThoiGianNgungMayChar()
        Dim str As String = ""
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetThoiGianNgungMayChart", cboThietbi_NM.SelectedValue, Format(dtpTuNgay.Value, "Short date"), Format(dtpDenNgay.Value, "Short date"))

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptTHOI_GIAM_NGUNG_MAY_CHART")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY_CHART.rpt")
KetThuc:
        Try
            str = "drop table rptTHOI_GIAM_NGUNG_MAY_CHART"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTieuDeThoiGianNgungMayChart"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Sub CreateTieuDeThoiGianNgungMayChar()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTieuDeThoiGianNgungMayChart"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_CHART", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_CHART", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY_CHART", "NgayIn", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblTungay.Text + " " + Format(dtpTuNgay.Value, "Short date") + " " + lblDenngay.Text + " " + Format(dtpDenNgay.Value, "Short date")
        str = "Create table [dbo].rptTieuDeThoiGianNgungMayChart(TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(50),TrangIn nvarchar(50),DieuKienLoc nvarchar(255))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeThoiGianNgungMayChart values(" & Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub CreaterptTieuDeKeHoachThuchienTuan()
        Dim str As String = String.Empty, str1, str2 As String
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeKeHoachBaoTriTrongTuan")
        Catch ex As Exception
        End Try
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TieuDe", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "ThietBi", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "CongViec", Commons.Modules.TypeLanguage)
        Dim DinhKy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "DinhKy", Commons.Modules.TypeLanguage)
        Dim NgayTrongTuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayTrongTuan", Commons.Modules.TypeLanguage)
        Dim NguoiThuchien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiThucHien", Commons.Modules.TypeLanguage)

        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NhaXuong", Commons.Modules.TypeLanguage) & " " & cboNhaXuongPBT.Text.Trim
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "HeThong", Commons.Modules.TypeLanguage)
        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiDuyet", Commons.Modules.TypeLanguage)
        Dim NguoiGS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiGS", Commons.Modules.TypeLanguage)
        Dim ketQua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "ketQua", Commons.Modules.TypeLanguage)

        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim NguoiKT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiKT", Commons.Modules.TypeLanguage)

        Dim DieuKienLoc As String = cboTuanNam.Text
        str = "Create table dbo.rptTieuDeKeHoachBaoTriTrongTuan(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        " DieuKienLoc nvarchar(255),STT nvarchar(5),ThietBi nvarchar(30),CongViec nvarchar(50),DinhKy nvarchar(30),NgayTrongTuan nvarchar(60), " & _
        " NguoiThucHien nvarchar(50),N1 INT,N2 INT,N3 INT,N4 INT,N5 INT,N6 INT,N7 INT, " & _
        " NhaXuong nvarchar(150),HeThong nvarchar(150),TenThietBi nvarchar(150),NguoiDuyet  nvarchar(150),NguoiGS nvarchar(150), ketQua  nvarchar(150), NguoiLap nvarchar(150) ,NguoiKT nvarchar(150) )"

        str1 = " Insert into rptTieuDeKeHoachBaoTriTrongTuan(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe,DieuKienLoc,STT,ThietBi,CongViec,DinhKy,NgayTrongTuan,NguoiThucHien , NhaXuong, HeThong, TenThietBi, NguoiDuyet, NguoiGS, ketQua,NguoiLap,NguoiKT"
        str2 = " values(" & Commons.Modules.TypeLanguage & ",'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & DieuKienLoc & "',N'" & _
        STT & "',N'" & ThietBi & "',N'" & CongViec & "',N'" & DinhKy & "',N'" & NgayTrongTuan & "',N'" & NguoiThuchien & "',N'" & _
        NhaXuong & "',N'" & HeThong & "',N'" & TenThietBi & "',N'" & NguoiDuyet & "',N'" & NguoiGS & "',N'" & ketQua & "',N'" & NguoiLap & "',N'" & NguoiKT & "'"

        Dim tmp As Integer = 1
        Dim sTuNgay As String
        sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)
        Dim ngay As New Date
        ngay = Date.Parse(Microsoft.VisualBasic.Left(sTuNgay, 10))
        While Date.Parse(ngay) <= Date.Parse(Microsoft.VisualBasic.Right(sTuNgay, 10))
            str1 = str1 + ",N" + tmp.ToString
            str2 = str2 + "," + ngay.Day.ToString
            ngay = DateAdd(DateInterval.Day, 1, ngay)
            tmp = tmp + 1
        End While
        str1 = str1 + ")"
        str2 = str2 + ")"
        str = str + str1 + str2
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptBangDanhGia_DVKH()

        Dim dtReader As SqlDataReader

        'xóa dl bảng tạm
        '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'rptDANH_GIA_DICH_VU_KH_TMP11') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table rptDANH_GIA_DICH_VU_KH_TMP11")

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)

        'chạy câu sql đổ dl vào bảng tạm
        Commons.Modules.SQLString = "SELECT dbo.KHACH_HANG.MS_KH, dbo.KHACH_HANG.TEN_CONG_TY, dbo.KHACH_HANG.TEN_RUT_GON, dbo.KHACH_HANG.DIA_CHI, " & _
                      "dbo.KHACH_HANG.TEL, dbo.KHACH_HANG.FAX, dbo.KHACH_HANG.EMAIL, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, " & _
                      "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR, dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_LAP, " & _
                      "dbo.DANH_GIA_SERVICE.ID,dbo.PHIEU_BAO_TRI_SERVICE.NOI_DUNG_SERVICE, dbo.DANH_GIA_SERVICE.NOI_DUNG, NULL AS GIA_CA, NULL AS THOI_GIAN, NULL AS CHAT_LUONG, NULL AS HAU_MAI " & _
                 "INTO rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " " & _
                 "FROM  dbo.PHIEU_BAO_TRI INNER JOIN dbo.DANH_GIA_SERVICE INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE ON dbo.DANH_GIA_SERVICE.ID = dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI_SERVICE ON dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR = dbo.PHIEU_BAO_TRI_SERVICE.STT AND " & _
                    "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT = dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI INNER JOIN " & _
                    "dbo.KHACH_HANG ON dbo.PHIEU_BAO_TRI_SERVICE.MS_KH = dbo.KHACH_HANG.MS_KH ON " & _
                    "dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT " & _
              "WHERE CONVERT(DATETIME,dbo.PHIEU_BAO_TRI.NGAY_LAP,103) BETWEEN CONVERT(DATETIME,'" & dtpTuNgay.Value.Date & "',103) AND CONVERT(DATETIME,'" & dtpDenNgay.Value.Date & "',103)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        'lấy những dl có điểm trong PHIEU_BAO_TRI_DANH_GIA_SERICE cập nhật ngược lại bảng tạm rptDANH_GIA_DICH_VU_KH_TMP11
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE")
        While dtReader.Read
            Select Case dtReader.Item("MS_DANH_GIA")
                Case 1  'GIÁ CẢ
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET GIA_CA=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,CHAT_LUONG=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 2  'THỜI GIAN
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET THOI_GIAN=" & dtReader.Item("DIEM") & " ,GIA_CA=NULL,CHAT_LUONG=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 3  'CHẤT LƯỢNG
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET CHAT_LUONG=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,GIA_CA=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 4  'HẬU MÃI
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET HAU_MAI=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,CHAT_LUONG=NULL,GIA_CA=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
            End Select
        End While
        objReader.Close()

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDANH_GIA_DICH_VU_KH_TMP")

        'TẠO DL CUỐI IN RA REPORT
        Commons.Modules.SQLString = "SELECT DISTINCT MS_KH, TEN_CONG_TY, TEN_RUT_GON, DIA_CHI, TEL, FAX, EMAIL, MS_PHIEU_BAO_TRI, STT_EOR, MS_MAY, NGAY_LAP, NOI_DUNG_SERVICE, NULL AS GIA_CA, NULL AS THOI_GIAN, NULL AS CHAT_LUONG, NULL AS HAU_MAI INTO rptDANH_GIA_DICH_VU_KH_TMP FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "SELECT * FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName
        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While objReader.Read
            Select Case objReader.Item("ID")
                Case 1  'GIÁ CẢ
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP SET GIA_CA=" & objReader.Item("GIA_CA") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 2  'THỜI GIAN
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP SET THOI_GIAN=" & objReader.Item("THOI_GIAN") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 3  'CHẤT LƯỢNG
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP SET CHAT_LUONG=" & objReader.Item("CHAT_LUONG") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 4  'HẬU MÃI
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP SET HAU_MAI=" & objReader.Item("HAU_MAI") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
            End Select
        End While

        CreateTitleReportrptTIEU_DE_DANH_GIA_DICH_VU_KH()
        ReportPreview("reports/rptDANH_GIA_DICH_VU_KH.rpt")
KetThuc:
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptDANH_GIA_DICH_VU_KH_TMP")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptTIEU_DE_DANH_GIA_DICH_VU_KH")
        Catch ex As Exception

        End Try
    End Sub

    Sub CreateTitleReportrptTIEU_DE_DANH_GIA_DICH_VU_KH()
        Dim str As String = String.Empty
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTIEU_DE_DANH_GIA_DICH_VU_KH")
        Catch ex As Exception
        End Try
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "TieuDe", Commons.Modules.TypeLanguage)
        Dim KhachHang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "KhachHang", Commons.Modules.TypeLanguage)
        Dim DienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "DienThoai", Commons.Modules.TypeLanguage)
        Dim Website As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "Website", Commons.Modules.TypeLanguage)
        Dim DiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "DiaChi", Commons.Modules.TypeLanguage)
        Dim Fax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "Fax", Commons.Modules.TypeLanguage)
        Dim PhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "PhieuBT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NoiDungService As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NoiDungService", Commons.Modules.TypeLanguage)
        Dim GiaCa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "GiaCa", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim ChatLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ChatLuong", Commons.Modules.TypeLanguage)
        Dim HauMai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "HauMai", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = lblTungay.Text & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "    " & lblDenngay.Text & Format(dtpDenNgay.Value, "dd/MM/yyyy")


        'xóa dl bảng tạm
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptTIEU_DE_DANH_GIA_DICH_VU_KH]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[rptTIEU_DE_DANH_GIA_DICH_VU_KH]")

        str = "Create table [dbo].rptTIEU_DE_DANH_GIA_DICH_VU_KH(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "KhachHang nvarchar(50), DienThoai nvarchar(30),Website nvarchar(30),DiaChi nvarchar(50),Fax nvarchar(20),PhieuBT nvarchar(30),ThietBi nvarchar(30)," & _
        "NgayLap nvarchar(30),NoiDungService nvarchar(50),GiaCa nvarchar(30),ThoiGian nvarchar(30),ChatLuong nvarchar(30),HauMai nvarchar(30),DieuKienLoc nvarchar(255)) " & _
        " Insert into [DBO].rptTIEU_DE_DANH_GIA_DICH_VU_KH(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe,KhachHang,DienThoai,Website,DiaChi,Fax,PhieuBT,ThietBi, " & _
        "NgayLap,NoiDungService,Giaca,ThoiGian,ChatLuong,HauMai,DieuKienLoc) " & _
        " values(" & Commons.Modules.TypeLanguage & ",'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & KhachHang & "',N'" & DienThoai & "',N'" & Website & "',N'" & DiaChi & "',N'" & Fax & "',N'" & PhieuBT & "',N'" & ThietBi & _
        "',N'" & NgayLap & "',N'" & NoiDungService & "',N'" & GiaCa & "',N'" & ThoiGian & "',N'" & ChatLuong & "',N'" & HauMai & "',N'" & DieuKienLoc & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptKeHoachBaoTriTrongTuan()

        Dim vtb As New DataTable

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  PRIVATE FROM dbo.THONG_TIN_CHUNG "))

        If vtb.Rows(0)("PRIVATE") = "BDL" Then
            Dim sTuNgay As String
            sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptKeHoachBaoTriTrongTuan_BDL", Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.SelectedValue.ToString, cboNhaXuongPBT.SelectedValue.ToString, Commons.Modules.UserName, cboLoai_CV.SelectedValue.ToString)
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select  count(*) as TONG FROM rptKE_HOACH_BAO_TRI_TRONG_TUAN")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Windows.Forms.Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()
            CreaterptTieuDeKeHoachThuchienTuan()
            ReportPreview("reports/rptKeHoachBaoTriTrongTuan_BDL.rpt")
KetThuc:
            Try
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptKE_HOACH_BAO_TRI_TRONG_TUAN")
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptTieuDeKeHoachBaoTriTrongTuan")
            Catch ex As Exception

            End Try

        Else
            Dim sTuNgay As String
            sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptKeHoachBaoTriTrongTuan", Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.SelectedValue.ToString, cboNhaXuongPBT.SelectedValue.ToString, Commons.Modules.UserName)
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select  count(*) as TONG FROM rptKE_HOACH_BAO_TRI_TRONG_TUAN")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Windows.Forms.Cursors.Default
                    objReader.Close()
                    GoTo KetThuc1
                End If
            End While
            objReader.Close()
            CreaterptTieuDeKeHoachThuchienTuan()
            ReportPreview("reports/rptKeHoachBaoTriTrongTuan.rpt")
KetThuc1:
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptKE_HOACH_BAO_TRI_TRONG_TUAN")
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptTieuDeKeHoachBaoTriTrongTuan")
            Catch ex As Exception

            End Try
        End If

    End Sub
    ''THỜI GIAN NGỪNG MÁY'''''''
    Private Sub grdDanhsachbaocao3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao7.RowEnter
        intRow3 = e.RowIndex
        Try
            Select Case Me.grdDanhsachbaocao7.Rows(e.RowIndex).Cells("REPORT_NAME").Value
                Case "rptDANH_GIA_DICH_VU_KH"
                    cboDiaDiem.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    cboLoaithietbi3.Visible = False
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False

                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    'cboLoaiBT.Focus()
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptDAILY_EQUIPMENT_EUEL"
                    cboDiaDiem.Visible = True
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = True
                    lblNhomthietbi3.Visible = True
                    lblThietbi3.Visible = True
                    cboNhomthietbi3.Visible = True
                    cboThietbi3.Visible = True
                    cboLoaithietbi3.Visible = True
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = True
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    lbLoaiBT.Visible = False
                    cboLoaiBT.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptWEP_REPORT"
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = True
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblLoaithietbi3.Visible = True
                    lblNhomthietbi3.Visible = True
                    lblThietbi3.Visible = True
                    cboLoaithietbi3.Visible = True
                    cboNhomthietbi3.Visible = True
                    cboThietbi3.Visible = True

                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False

                    lblDiaDiem.Visible = True
                    cboDiaDiem.Visible = True
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    cboNguyenNhan.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'boThietbi3.Enabled = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboLoaithietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False

                    lblTuNam.Visible = True
                    txtTunam.Visible = True
                    lblDennam.Visible = True
                    txtDennam.Visible = True

                    lblDiaDiem.Visible = True
                    cboDiaDiem.Visible = True
                    lblLoaiTB_P.Visible = True
                    cboLoaiTB_P.Visible = True
                    lblNhomTB_P.Visible = True
                    cboNhomMay.Visible = True
                    lblThietbi_P.Visible = True
                    cboThietbi_P.Visible = True
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    'cboDiaDiem.Focus()
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptTHOI_GIAN_NGUNG_MAY_THEO_THANG"
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboLoaithietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblTuthang.Visible = True
                    txtTuthang.Visible = True
                    lblDenthang.Visible = True
                    txtDenthang.Visible = True

                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False

                    lblDiaDiem.Visible = True
                    cboDiaDiem.Visible = True
                    lblLoaiTB_P.Visible = True
                    cboLoaiTB_P.Visible = True
                    lblNhomTB_P.Visible = True
                    cboNhomMay.Visible = True
                    lblThietbi_P.Visible = True
                    cboThietbi_P.Visible = True
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    'cboDiaDiem.Focus()
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboLoaithietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False

                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False

                    lblDiaDiem.Visible = True
                    cboDiaDiem.Visible = True
                    lblLoaiTB_P.Visible = True
                    cboLoaiTB_P.Visible = True
                    lblNhomTB_P.Visible = True
                    cboNhomMay.Visible = True
                    lblThietbi_P.Visible = True
                    cboThietbi_P.Visible = True
                    lblNguyennhan_P.Visible = True
                    cboNguyenNhan.Visible = True
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    'cboDiaDiem.Focus()
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptDSPBTDaNghiemThuTLBT", "rptDSPBTChuaNghiemThuTLBT"
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = False
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = True
                    lbLoaiBT.Visible = True
                    'cboLoaiBT.Focus()
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptDSCPBTTLoaiMay_LoaiTB"
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = False
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    grLoaiMay.Visible = True
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptDSCYCBTDaNghiemThuTheoNV", "rptDSCYCBTChuaNghiemThuTheoNV"
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = False
                    cboLoaithietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = True
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptTHOI_GIAN_NGUNG_MAY_CHART"
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    lbLoaiBT.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboDiaDiem.Visible = True
                    cboLoaithietbi3.Visible = True
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = True
                    lblNhomthietbi3.Visible = True
                    lblThietbi3.Visible = True
                    cboNhomthietbi3.Visible = True
                    cboThietbi3.Visible = False
                    'cboThietbi3.IsAll = False
                    lblDiaDiem.Visible = True
                    cboThietbi_NM.Visible = True
                    cboLoaiBT.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptBreakdownTime"
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = False
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = True
                    lbDenNgay.Visible = True
                    dtpDenNgay.Visible = True
                    dtpTuNgay.Visible = True
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False

                    'grpDKCI_MTBF.Visible = False
                    grpDieukienchonin3.Visible = True
                    btnIN.Visible = True
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False

                Case "rptKeHoachBaoTriTrongTuan"


                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False

                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False

                    'grpDKCI_MTBF.Visible = False                    
                    btnIN.Visible = True
                    intRow3 = e.RowIndex

                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False

                    cboLoai_CV.Visible = True
                    lblLoai_CV.Visible = True
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = True
                    lblLoaithietbi3.Visible = True
                    cboNhaXuongPBT.Visible = True
                    lblNhaXuongPBT.Visible = True
                    lblTuanNam.Visible = True
                    cboTuanNam.Visible = True
                    grpDieukienchonin3.Visible = True
                Case Else
                    cboDiaDiem.Visible = False
                    cboLoaithietbi3.Visible = False
                    'cboLoaithietbi3.Enabled = False
                    'cboNhomthietbi3.Enabled = False
                    'cboThietbi3.Enabled = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    grpThoiGian.Visible = False
                    lblNgay.Visible = False
                    dtpNgay.Visible = False
                    lblLoaithietbi3.Visible = False
                    lblNhomthietbi3.Visible = False
                    lblThietbi3.Visible = False
                    cboNhomthietbi3.Visible = False
                    cboThietbi3.Visible = False
                    cboNhaXuongPBT.Visible = False
                    lblNhaXuongPBT.Visible = False
                    lblDiaDiem.Visible = False
                    lblLoaiTB_P.Visible = False
                    cboLoaiTB_P.Visible = False
                    lblNhomTB_P.Visible = False
                    cboNhomMay.Visible = False
                    lblThietbi_P.Visible = False
                    cboThietbi_P.Visible = False
                    lblNguyennhan_P.Visible = False
                    cboNguyenNhan.Visible = False
                    lblTuNam.Visible = False
                    txtTunam.Visible = False
                    lblDennam.Visible = False
                    txtDennam.Visible = False
                    lblTuthang.Visible = False
                    txtTuthang.Visible = False
                    lblDenthang.Visible = False
                    txtDenthang.Visible = False
                    cboLoaiBT.Visible = False
                    lbLoaiBT.Visible = False
                    grLoaiMay.Visible = False
                    grNhanVien.Visible = False
                    cboThietbi_NM.Visible = False
                    lblTuanNam.Visible = False
                    cboTuanNam.Visible = False
                    'rdNoiNgoai.Visible = False
                    'lblNam.Visible = False
                    'txtNam.Visible = False
                    lbTuNgay.Visible = False
                    lbDenNgay.Visible = False
                    dtpDenNgay.Visible = False
                    dtpTuNgay.Visible = False
                    cboLoai_CV.Visible = False
                    lblLoai_CV.Visible = False
            End Select
            grdDanhsachbaocao7.EndEdit()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub cboInTheo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case cboInTheo.SelectedIndex
            Case 0
                lblTuQuy.Visible = False
                lblDenQuy.Visible = False
                txtTuQuy.Visible = False
                txtDenQuy.Visible = False
                lblTuNam_MTBF.Visible = False
                lblDenNam_MTBF.Visible = False
                txtTuNam_MTBF.Visible = False
                txtDenNam_MTBF.Visible = False
                lbdenthang.Visible = True
                Me.Lbtuthang.Visible = True
                Me.txtttuthang.Visible = True
                Me.txtdenthang1.Visible = True
            Case 1
                lblTuQuy.Visible = True
                lblDenQuy.Visible = True
                txtTuQuy.Visible = True
                txtDenQuy.Visible = True
                lblTuNam_MTBF.Visible = False
                lblDenNam_MTBF.Visible = False
                txtTuNam_MTBF.Visible = False
                txtDenNam_MTBF.Visible = False
                lbdenthang.Visible = False
                Me.Lbtuthang.Visible = False
                Me.txtttuthang.Visible = False
                Me.txtdenthang1.Visible = False
            Case 2
                lblTuQuy.Visible = False
                lblDenQuy.Visible = False
                txtTuQuy.Visible = False
                txtDenQuy.Visible = False
                lblTuNam_MTBF.Visible = True
                lblDenNam_MTBF.Visible = True
                txtTuNam_MTBF.Visible = True
                txtDenNam_MTBF.Visible = True
                lbdenthang.Visible = False
                Me.Lbtuthang.Visible = False
                Me.txtttuthang.Visible = False
                Me.txtdenthang1.Visible = False


        End Select





    End Sub
#End Region ' End of Bảo trì 

#Region "Kho"

    Sub Bind_lstDanhsachbaocao4()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao8.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 4, commons.Modules.TypeLanguage)
        grdDanhsachbaocao8.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao8.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_REPORT", commons.Modules.TypeLanguage)
        'grdDanhsachbaocao5.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao8.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao8.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao8.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub Bind_lstDanhsachbaocao5()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao9.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 7, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao9.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao9.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'QLVnhanvien.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao9.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao9.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao9.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub Bind_rptHIEU_CHUAN_VA_KIEM_DINH()
        Dim objReport As New clsReportController
        Me.grdDanhsachbaocao6.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 8, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao6.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao6.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        'QLVnhanvien.Columns("TEN_REPORT").Width = 380
        grdDanhsachbaocao6.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao6.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao6.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub Bind_THONG_KE_THOI_GIAN_NGUNG_MAY()
        Dim objReport As New clsReportController
        grdDanhsachbaocao4.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 93, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao4.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao4.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        grdDanhsachbaocao4.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao4.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao4.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub Bind_THONG_KE_CHI_PHI()
        Dim objReport As New clsReportController
        grdDanhsachbaocao5.DataSource = objReport.Get_lstDanhsachbaocao(Commons.Modules.UserName, 9, Commons.Modules.TypeLanguage)
        grdDanhsachbaocao5.Columns("REPORT_NAME").Visible = False
        grdDanhsachbaocao5.Columns("TEN_REPORT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_REPORT", Commons.Modules.TypeLanguage)
        grdDanhsachbaocao5.Columns("TEN_REPORT").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdDanhsachbaocao5.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachbaocao5.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub EnableCombox()
        cboNCC.Enabled = False
        cboVattu.Enabled = False
        cboKho.Enabled = False
        cboThang.Enabled = False
    End Sub

    Sub Bind_cboNCC()
        cboNCC.Display = "TEN_CONG_TY"
        cboNCC.Value = "NGUOI_NHAP"
        cboNCC.DropDownWidth = 200
        cboNCC.StoreName = "GetNCC_Kho"
        cboNCC.BindDataSource()
    End Sub

    Sub Bind_cboVattu()
        cboVattu.Display = "TEN_PT"
        cboVattu.Value = "MS_PT"
        cboVattu.DropDownWidth = 200
        cboVattu.StoreName = "GetMS_PT_KHO"
        cboVattu.Param = Commons.Modules.UserName
        cboVattu.BindDataSource()
    End Sub
    Sub Bind_cboKho()
        cboKho.Display = "TEN_KHO"
        cboKho.Value = "MS_KHO"
        cboKho.DropDownWidth = 200
        cboKho.StoreName = "GetMS_KHO_KHO"
        cboKho.Param = Commons.Modules.UserName
        cboKho.BindDataSource()
    End Sub
    Sub Bind_cboThang()
        cboThang.Display = "THANG_NAM"
        cboThang.Value = "THANG_NAM"
        cboThang.DropDownWidth = 200
        cboThang.StoreName = "GetTHANG_NAMs"
        cboThang.BindDataSource()
    End Sub

    Sub ShowrptDANH_GIA_NCC()
        If cboNCC.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE rptDANH_GIA_NCC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        'str = "CREATE TABLE [DBO].rptDANH_GIA_NCC (TEN_CONG_TY NVARCHAR(255),DIA_CHI NVARCHAR(255),TEN_NDD NVARCHAR(50),TEL NVARCHAR(12), " & _
        '" FAX NVARCHAR(30),MS_DH_NHAP_PT NVARCHAR(30),MS_KH NVARCHAR(7), NGAY DATETIME,DANH_GIA NVARCHAR(255), DIEM INT) " & _
        '" INSERT INTO [DBO].rptDANH_GIA_NCC " & _
        '" SELECT KHACH_HANG.TEN_CONG_TY, KHACH_HANG.DIA_CHI, KHACH_HANG.TEN_NDD, KHACH_HANG.TEL, KHACH_HANG.FAX, " & _
        '" IC_DON_HANG_NHAP.MS_DH_NHAP_PT, KHACH_HANG.MS_KH, IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP.DANH_GIA, " & _
        '" IC_DON_HANG_NHAP.DIEM FROM IC_DON_HANG_NHAP INNER JOIN " & _
        '" KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH AND IC_DON_HANG_NHAP.NGUOI_NHAP='" & cboNCC.SelectedValue & "'" & _
        '" AND IC_DON_HANG_NHAP.NGAY BETWEEN convert(datetime,'" & dtTuNgay_Kho.Value & "',103) AND DateAdd(day,1,convert(datetime,'" & dtDenNgay_Kho.Value & "',103)) ORDER BY IC_DON_HANG_NHAP.NGAY DESC"

        str = " SELECT KHACH_HANG.TEN_CONG_TY, KHACH_HANG.DIA_CHI, KHACH_HANG.TEN_NDD, KHACH_HANG.TEL, KHACH_HANG.FAX, " & _
        " IC_DON_HANG_NHAP.MS_DH_NHAP_PT, KHACH_HANG.MS_KH, IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP.DANH_GIA,CASE WHEN IC_DON_HANG_NHAP.DIEM IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM END AS DIEM," & _
        " CASE WHEN IC_DON_HANG_NHAP.DIEM1 IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM1 END AS DIEM1," & _
        " CASE WHEN IC_DON_HANG_NHAP.DIEM2 IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM2 END AS DIEM2  " & _
        " INTO rptDANH_GIA_NCC " & _
        " FROM IC_DON_HANG_NHAP INNER JOIN KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH AND IC_DON_HANG_NHAP.NGUOI_NHAP='" & cboNCC.SelectedValue & "'" & _
        " AND IC_DON_HANG_NHAP.NGAY BETWEEN convert(datetime,'" & dtTuNgay_Kho.Value & "',103) AND DateAdd(day,1,convert(datetime,'" & dtDenNgay_Kho.Value & "',103)) ORDER BY IC_DON_HANG_NHAP.NGAY DESC"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDANH_GIA_NCC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Windows.Forms.Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreateTitleReportrptTIEU_DE_DANH_GIA_NHA_CUNG_CAP()
        ReportPreview("reports/rptDANH_GIA_NCC.rpt")
        Cursor = Windows.Forms.Cursors.Default
KetThuc:
        Try
            str = "DROP TABLE rptDANH_GIA_NCC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            SqlText = " DROP TABLE rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Sub CreateTitleReportrptTIEU_DE_DANH_GIA_NHA_CUNG_CAP()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TieuDe1", commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "STT", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TrangIn", commons.Modules.TypeLanguage)
        Dim sTenNDD As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TenNDD", commons.Modules.TypeLanguage)
        Dim sMaKH As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "MaKH", commons.Modules.TypeLanguage)
        Dim sTenCongTy As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TenCongTy", commons.Modules.TypeLanguage)
        Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DiaChi", commons.Modules.TypeLanguage)
        Dim stTel As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "stTel", commons.Modules.TypeLanguage)
        Dim stFax As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "stFax", commons.Modules.TypeLanguage)
        Dim sMaSoDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "MaPhieuNhapKho", commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "NgayNhap", commons.Modules.TypeLanguage)
        Dim sDanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DanhGia", commons.Modules.TypeLanguage)
        Dim sDiem As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem", commons.Modules.TypeLanguage)
        Dim sDiemTB As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DiemTB", commons.Modules.TypeLanguage)
        Dim TuGio As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TuGio", commons.Modules.TypeLanguage)
        Dim DenGio As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DenGio", commons.Modules.TypeLanguage)

        Dim sDiem1 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem1", commons.Modules.TypeLanguage)
        Dim sDiem2 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem2", commons.Modules.TypeLanguage)
        Dim sDiemTB1 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiemTB1", commons.Modules.TypeLanguage)


        Dim ThoiGian As String = ""
        ThoiGian = TuGio & " " & Format(dtTuNgay_Kho.Value, "Short date") & " " & DenGio & " " & Format(dtDenNgay_Kho.Value, "Short date")
        SqlText = "CREATE TABLE DBO.rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP(TypeLanguage int, TrangIn nvarchar(20), NgayIn nvarchar(30),TieuDe nvarchar(255)," & _
        "TenNDD nvarchar(50),MaKH nvarchar(30),TenCongTy nvarchar(70),DiaChi nvarchar(30),stTel nvarchar(20)," & _
        "stFax nvarchar(20),MaSoDHNhap nvarchar(30),NgayNhap nvarchar(20),DanhGia nvarchar(30)," & _
        "sDiem nvarchar(20),DiemTB nvarchar(30),STT nvarchar(10), ThoiGian nvarchar(255), sDiem1 nvarchar(255), sDiem2 nvarchar(255), sDiemTB1 nvarchar(255) )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO [DBO].rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe, " & _
        "TenNDD,MaKH,TenCongTy,DiaChi,stTel,stFax,MaSoDHNhap,NgayNhap,DanhGia,sDiem,DiemTB,STT,ThoiGian,sDiem1,sDiem2,sDiemTB1)" & _
        "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
        "N'" & sTieudeReport & "',N'" & sTenNDD & "',N'" & sMaKH & "',N'" & sTenCongTy & "',N'" & sDiaChi & "',N'" & stTel & "',N'" & stFax & "',N'" & sMaSoDHNhap & "',N'" & sNgayNhap & "'," & _
                "N'" & sDanhGia & "',N'" & sDiem & "',N'" & sDiemTB & "',N'" & sSTT & "',N'" & ThoiGian & "',N'" & sDiem1 & "',N'" & sDiem2 & "',N'" & sDiemTB1 & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub ShowrptCTY_DA_CUNG_CAP_VAT_TU()
        If cboNCC.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY(MS_PT  NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255),TEN_CONG_TY NVARCHAR(255)," & _
        " TEN_NDD NVARCHAR(250),DIA_CHI NVARCHAR(255),sFAX NVARCHAR(30),NGAY DATETIME,DON_GIA FLOAT, SO_LUONG FLOAT, sTEL nvarchar(15), NGOAI_TE NVARCHAR (6)) " & _
        " INSERT INTO [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY " & _
        " SELECT * FROM(SELECT DISTINCT   IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH,KHACH_HANG.TEN_CONG_TY,TEN_NDD,KHACH_HANG.DIA_CHI ,KHACH_HANG.FAX " & _
        " ,( select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)" & _
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS NGAY, " & _
        "(select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
       "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " & _
        " FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " & _
       " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " & _
       "  D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " & _
       " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS SO_LUONG ,KHACH_HANG.TEL,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE" & _
       " FROM         IC_DON_HANG_NHAP INNER JOIN " & _
                     " IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " & _
                     " KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH  INNER JOIN IC_PHU_TUNG " & _
       " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT AND KHACH_HANG.MS_KH='" & cboNCC.SelectedValue & "') TMP WHERE SO_LUONG>0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptTIEU_DE_CONG_TY_VAT_TU()
        ReportPreview("reports/rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub
    Sub ShowrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY()
        If cboVattu.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE rptCTY_DA_CUNG_CAP_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE [DBO].rptCTY_DA_CUNG_CAP_VAT_TU(TEN_CONG_TY NVARCHAR(255),DIA_CHI NVARCHAR(255),TEN_NDD NVARCHAR(50),FAX NVARCHAR(30),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255), " & _
           " NGAY DATETIME, DON_GIA FLOAT, SO_LUONG FLOAT,sTEL nvarchar(15),NGOAI_TE NVARCHAR (6)) " & _
           " INSERT INTO [DBO].rptCTY_DA_CUNG_CAP_VAT_TU " & _
           " SELECT * FROM(SELECT DISTINCT TEN_CONG_TY,DIA_CHI,TEN_NDD,FAX,dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH," & _
           " (select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS NGAY, " & _
            "( select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
           "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " & _
           "  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH  " & _
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " & _
           " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " & _
         "    D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " & _
          " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS SO_LUONG ,KHACH_HANG.TEL,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE " & _
           " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " & _
            "  dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT " & _
           "    INNER JOIN KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP=KHACH_HANG.MS_KH INNER JOIN IC_PHU_TUNG " & _
      " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT " & _
            " WHERE  IC_PHU_TUNG.MS_PT='" & cboVattu.SelectedValue & "') TMP WHERE SO_LUONG>0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCTY_DA_CUNG_CAP_VAT_TU")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CONG_TY_VAT_TU()
        ReportPreview("reports/rptCTY_DA_CUNG_CAP_VAT_TU.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCTY_DA_CUNG_CAP_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub
    Sub CreaterptTIEU_DE_CONG_TY_VAT_TU()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.rptTIEU_DE_CONG_TY_VAT_TU(TypeLanguage int, Ngayin nvarchar(20), TrangIn nvarchar(20), TieuDe nvarchar(255)," & _
            "NhaCungCap nvarchar(50), DiaChi nvarchar(20),NguoiDaiDien nvarchar(50),DienThoai nvarchar(30), stFax nvarchar(5), " & _
            "STT nvarchar(5),MaPhuTung nvarchar(30),TenPT nvarchar(50), QuyCach nvarchar(30), SoLuong nvarchar(30), DonGia nvarchar(20), " & _
            "NgayCuoi nvarchar(30),Tong nvarchar(20), ThoiGian nvarchar(70)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim sTieudeReport As String = ""
        If grdDanhsachbaocao8.Rows(intRow8).Cells("REPORT_NAME").Value = "rptCTY_DA_CUNG_CAP_VAT_TU" Then
            sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TieuDe2", commons.Modules.TypeLanguage)
        Else
            sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TieuDe3", commons.Modules.TypeLanguage)
        End If
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "STT", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TrangIn", commons.Modules.TypeLanguage)
        Dim sNhaCungCap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NhaCungCap", commons.Modules.TypeLanguage)
        Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DiaChi", commons.Modules.TypeLanguage)
        Dim sNguoiDaiDien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenNDD", commons.Modules.TypeLanguage)
        Dim sDienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stTel", commons.Modules.TypeLanguage)
        Dim stFax As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stFax", commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MaPT", commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "QuyCach", commons.Modules.TypeLanguage)
        Dim sSoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "SoLuong", commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DonGia", commons.Modules.TypeLanguage)
        Dim sNgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayCuoi", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "Tong", commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "ThoiGian", commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenPT", commons.Modules.TypeLanguage)

        SqlText = "INSERT INTO [DBO].rptTIEU_DE_CONG_TY_VAT_TU(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "NhaCungCap,DiaChi,NguoiDaiDien,DienThoai,stFax,MaPhuTung,TenPT,QuyCach,SoLuong,DonGia,NgayCuoi,Tong,ThoiGian,STT )" & _
                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sNhaCungCap & "',N'" & sDiaChi & "',N'" & sNguoiDaiDien & "',N'" & sDienThoai & "',N'" & stFax & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sSoLuong & "',N'" & sDonGia & "'," & _
                        "N'" & sNgayCuoi & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sSTT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Sub CreaterptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI(TypeLanguage int , Trangin nvarchar(120), NgayIn nvarchar(120),TieuDe1 nvarchar(255),MaKho nvarchar(120)," & _
            "TenKho nvarchar(120),MaPT nvarchar(120),TenPT nvarchar(120),QuyCach nvarchar(120),sDVT nvarchar(120),TonDK nvarchar(120),sNhap nvarchar(120),sXuat nvarchar(120)," & _
            "TonCK nvarchar(120),Tong nvarchar(120),STT nvarchar(120),ChuyenDi nvarchar(120),ChuyenDen nvarchar(120),ThoiGian nvarchar(120),NgayBaoCao nvarchar(120),NguoiLap nvarchar(120))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TieuDe5", commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "STT", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TrangIn", commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "MaKho", commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TenKho", commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "MaPT", commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TenPT", commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "QuyCach", commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sDVT", commons.Modules.TypeLanguage)
        Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TonDK", commons.Modules.TypeLanguage)
        Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sNhap", commons.Modules.TypeLanguage)
        Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sXuat", commons.Modules.TypeLanguage)
        Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TonCK", commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "Tong", commons.Modules.TypeLanguage)
        Dim ChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "Di_Chuyen", commons.Modules.TypeLanguage)
        Dim ChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "CL_KK", commons.Modules.TypeLanguage)
        Dim ThoiGian As String = lblTuNgay_Kho.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenNgay_Kho.Text & " " & Format(dtDenNgay_Kho.Value, "short date") '  cboThang.SelectedValue

        Dim NgayBaoCao As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NgayBaoCao", commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NguoiLap", commons.Modules.TypeLanguage)

        str = "INSERT INTO [DBO].rptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe1, " & _
                "MaKho,TenKho,MaPT,TenPT,QuyCach,sDVT,TonDK,sNhap,sXuat,TonCK,Tong,STT,ChuyenDi,ChuyenDen,ThoiGian,NgayBaoCao,NguoiLap )" & _
                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sMaKho & "',N'" & sTenKho & "',N'" & sMaPT & "',N'" & sTenPT & "',N'" & sQuyCach & "',N'" & sDVT & "',N'" & sTonDK & "',N'" & sNhap & "'," & _
                        "N'" & sXuat & "',N'" & sTonCK & "',N'" & sTong & "',N'" & sSTT & "',N'" & ChuyenDi & "',N'" & ChuyenDen & "',N'" & ThoiGian & "',N'" & NgayBaoCao & "',N'" & NguoiLap & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


    End Sub
    Sub CreaterptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP(TypeLanguage int, TrangIn nvarchar(20)," & _
            "NgayIn nvarchar(20),TieuDe nvarchar(255),MaKho nvarchar(20),TenKho nvarchar(20),MaPT nvarchar(30), " & _
            "TenPT nvarchar(30),MaPhieuNhapKho nvarchar(20),SoLuong nvarchar(20),DonGia nvarchar(20), " & _
            "NgoaiTe nvarchar(20), ThanhTien nvarchar(20),ThanhTienUSD nvarchar(30),QuyCach nvarchar(30)," & _
            "sDVT nvarchar(10),NguoiNhap nvarchar(20),TenNguoiNhan nvarchar(50),NgayNhap nvarchar(20)," & _
            "NgayBH nvarchar(20),TonKho nvarchar(30),TongPT nvarchar(30))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TieuDe6", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayIn", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TrangIn", commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaKho", commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenKho", commons.Modules.TypeLanguage)
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaPT", commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenPT", commons.Modules.TypeLanguage)
        Dim sMaPhieuNhapKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaPhieuNhapKho", commons.Modules.TypeLanguage)
        Dim sSoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "SoLuong", commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "DonGia", commons.Modules.TypeLanguage)
        Dim sNgoaiTe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgoaiTe", commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "ThanhTien", commons.Modules.TypeLanguage)
        Dim sThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "ThanhTienUSD", commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "QuyCach", commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "sDVT", commons.Modules.TypeLanguage)
        Dim sNguoiNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NguoiNhap", commons.Modules.TypeLanguage)
        Dim sTenNguoiNhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenNguoiNhan", commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayNhap", commons.Modules.TypeLanguage)
        Dim sNgayBH As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayBH", commons.Modules.TypeLanguage)
        Dim sTonKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TonKho", commons.Modules.TypeLanguage)
        Dim sTongPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TongPT", commons.Modules.TypeLanguage)
        SqlText = "INSERT INTO [DBO].rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "MaKho,TenKho,MaPT,TenPT,MaPhieuNhapKho,SoLuong,DonGia,NgoaiTe,ThanhTien,ThanhTienUSD,QuyCach,sDVT,NguoiNhap,TenNguoiNhan,NgayNhap,NgayBH,TonKho,TongPT )" & _
                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sMaKho & "',N'" & sTenKho & "',N'" & sMaPT & "',N'" & sTenPT & "',N'" & sMaPhieuNhapKho & "',N'" & sSoLuong & "',N'" & sDonGia & "',N'" & sNgoaiTe & "'," & _
                        "N'" & sThanhTien & "',N'" & sThanhTienUSD & "',N'" & sQuyCach & "',N'" & sDVT & "',N'" & sNguoiNhap & "'," & _
                "N'" & sTenNguoiNhan & "',N'" & sNgayNhap & "',N'" & sNgayBH & "',N'" & sTonKho & "',N'" & sTongPT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub ShowrptTON_THEO_VI_TRI()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, commons.Modules.TypeLanguage)
            CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_THEO_VI_TRI.rpt")
        Catch ex As Exception

        End Try

    End Sub

    Sub ShowrptTON_KHONG_THEO_VI_TRI()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_KHONG_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_KHONG_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, commons.Modules.TypeLanguage)
            CreaterptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_KHONG_THEO_VI_TRI.rpt")
        Catch ex As Exception

        End Try

    End Sub

    Sub ShowrptTON_KHO_THEO_PHIEU_NHAP()
        If cboKho.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE TON_KHO_THEO_PHIEU_NHAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

        str = "SELECT DISTINCT VI_TRI_KHO_VAT_TU.MS_KHO, VI_TRI_KHO_VAT_TU.MS_PT, IC_PHU_TUNG.TEN_PT,VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT, VI_TRI_KHO_VAT_TU.SL_VT, " & _
        " IC_DON_HANG_NHAP_VAT_TU.DON_GIA, IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE,  " & _
        " VI_TRI_KHO_VAT_TU.SL_VT * IC_DON_HANG_NHAP_VAT_TU.DON_GIA * IC_DON_HANG_NHAP_VAT_TU.TY_GIA AS THANH_TIEN,  " & _
        " VI_TRI_KHO_VAT_TU.SL_VT * IC_DON_HANG_NHAP_VAT_TU.DON_GIA * IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD AS THANH_TIEN_USD, " & _
        " IC_PHU_TUNG.QUY_CACH,(CASE " & commons.Modules.TypeLanguage & "  WHEN 0 THEN TEN_1  WHEN 1 THEN TEN_2  END)AS DVT, IC_KHO.TEN_KHO, IC_DON_HANG_NHAP.NGUOI_NHAP,  " & _
        " ISNULL((SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH = IC_DON_HANG_NHAP.NGUOI_NHAP),'')+ " & _
        " ISNULL((SELECT HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN WHERE MS_CONG_NHAN = IC_DON_HANG_NHAP.NGUOI_NHAP),'') AS TEN_NGUOI_NHAP, " & _
        " IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP_VAT_TU.BAO_HANH_DEN_NGAY,TEN_VI_TRI INTO TON_KHO_THEO_PHIEU_NHAP " & _
        " FROM VI_TRI_KHO_VAT_TU INNER JOIN  IC_DON_HANG_NHAP_VAT_TU_CHI_TIET ON  " & _
        " VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " & _
        " VI_TRI_KHO_VAT_TU.MS_PT = IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT AND  " & _
        " VI_TRI_KHO_VAT_TU.MS_VI_TRI = IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI INNER JOIN " & _
        " IC_PHU_TUNG ON VI_TRI_KHO_VAT_TU.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
        " IC_DON_HANG_NHAP_VAT_TU ON VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
        " VI_TRI_KHO_VAT_TU.MS_PT = IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
        " IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
        " IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
        " IC_PHU_TUNG.MS_PT = IC_DON_HANG_NHAP_VAT_TU.MS_PT INNER JOIN " & _
        " IC_DON_HANG_NHAP ON IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " & _
        " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT LEFT OUTER JOIN " & _
        " KHACH_HANG ON IC_PHU_TUNG.MS_KH = KHACH_HANG.MS_KH INNER JOIN " & _
        " IC_KHO ON VI_TRI_KHO_VAT_TU.MS_KHO = IC_KHO.MS_KHO " & _
        " INNER JOIN VI_TRI_KHO " & _
        " ON VI_TRI_KHO.MS_KHO=VI_TRI_KHO_VAT_TU.MS_KHO  AND VI_TRI_KHO.MS_VI_TRI =VI_TRI_KHO_VAT_TU.MS_VI_TRI " & _
        " WHERE VI_TRI_KHO_VAT_TU.MS_KHO= '" & cboKho.SelectedValue & "' AND VI_TRI_KHO_VAT_TU.SL_VT>0"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM TON_KHO_THEO_PHIEU_NHAP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP()
        ReportPreview("reports/rptTON_KHO_THEO_PHIEU_NHAP.rpt")
KetThuc:
        Try
            str = "DROP TABLE TON_KHO_THEO_PHIEU_NHAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

    End Sub
#End Region ' End of Kho

    Private Sub loadCboLoaiBT()
        Dim dt As New DataTable
        Dim str As String = "SELECT * FROM LOAI_BAO_TRI ORDER BY TEN_LOAI_BT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        cboLoaiBT.DataSource = dt
        cboLoaiBT.ValueMember = "TEN_LOAI_BT"
        cboLoaiBT.DisplayMember = "TEN_LOAI_BT"
        cboLoaiBT.DropDownWidth = 200
    End Sub

    Private Sub cboDiaDiem_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiaDiem.SelectionChangeCommitted
        LoadcbiLoaiMay()
        LoadcboNhomMay()
        LoadcboThietBiLoc()
        LoadcboThietBi_NM()
        Bind_cboLoaithietbi3()
        'Bind_cboNhomthietbi3()
        'Bind_cbothietbi3()
    End Sub

    Private Sub cboLoaiTB_P_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiTB_P.SelectionChangeCommitted
        LoadcboNhomMay()
        LoadcboThietBiLoc()
        LoadcboThietBi_NM()
    End Sub

    Private Sub cboNhomMay_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNhomMay.SelectionChangeCommitted
        LoadcboThietBiLoc()
        LoadcboThietBi_NM()
    End Sub

    Private Sub txtTuthang_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTuthang.Validating
        If txtTuthang.Text <> "  /" Then
            If txtTuthang.Text.Length = 7 Then
                If Not IsDate(txtTuthang.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuThang", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTuthang.Focus()
                Else
                    If Date.Parse(txtTuthang.Text).Year < 1900 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuThangNam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        txtTuthang.Focus()
                    End If
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuThang", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtTuthang.Focus()
            End If

        End If
    End Sub

    Private Sub txtDenthang_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDenthang.Validating
        If txtDenthang.Text <> "  /" Then
            If txtDenthang.Text.Length = 7 Then
                If Not IsDate(txtDenthang.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenThang", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtDenthang.Focus()
                Else
                    If Date.Parse(txtDenthang.Text).Year < 1900 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenThangNam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        txtDenthang.Focus()
                    End If
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenThang", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtDenthang.Focus()
            End If
        End If
    End Sub

    Private Sub txtTunam_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTunam.Validating
        If txtTunam.Text <> "" Then
            If Integer.Parse(txtTunam.Text) < 1900 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuNam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtTunam.Focus()
            End If
        End If
    End Sub

    Private Sub txtDennam_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDennam.Validating
        If txtDennam.Text <> "" Then
            If Integer.Parse(txtDennam.Text) < 1900 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenNam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtDennam.Focus()
            End If
        End If
    End Sub
    Private Sub loadCboLoaiTB()
        Dim str As String = ""
        If cboDiaDiem1.Text = "" Then
            Exit Sub
        End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE MS_N_XUONG='" & cboDiaDiem1.SelectedValue & "' AND USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaiTB1.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB1.ValueMember = "MS_LOAI_MAY"
        cboLoaiTB1.DropDownWidth = 200
        cboLoaiTB1.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        If cboLoaiTB1.Items.Count = 0 Then
            cboLoaiTB1.Text = ""
        End If
    End Sub

    Private Sub loadCboDiaDiem1()
        cboDiaDiem1.ValueMember = "MS_N_XUONG"
        cboDiaDiem1.DisplayMember = "TEN_N_XUONG"
        cboDiaDiem1.DropDownWidth = 200
        cboDiaDiem1.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "PermisionNHA_XUONG", Commons.Modules.UserName).Tables(0)
    End Sub

    Private Function tblCNFullName() As DataTable
        Dim dtCN As New DataTable
        Dim str As String = "SELECT * FROM CONG_NHAN WHERE NGAY_NGHI_VIEC IS NULL"
        dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        'cboLoaiBT.DataSource = dt
        'cboLoaiBT.ValueMember = "TEN_LOAI_BT"
        'cboLoaiBT.DisplayMember = "TEN_LOAI_BT"
        Dim dtCNFullName As New DataTable
        dtCNFullName.Columns.Add("MS_CN")
        dtCNFullName.Columns.Add("HoTen")
        Dim rowFName, row As DataRow
        For Each row In dtCN.Rows
            rowFName = dtCNFullName.NewRow()
            rowFName("ms_cn") = row("MS_CONG_NHAN")
            rowFName("hoten") = row("ho").ToString() & " " & row("ten").ToString()
            dtCNFullName.Rows.Add(rowFName)
        Next
        Return dtCNFullName
    End Function

    Private Sub loadCboCongNhan()
        cboNVien.DataSource = tblCNFullName()
        cboNVien.ValueMember = "MS_CN"
        cboNVien.DisplayMember = "hoten"
        cboNVien.DropDownWidth = 200
    End Sub

    Sub LoadTuan()
        Dim tb As New DataTable()
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTUAN_TRONG_NAM", "01/01/" + Now.Year.ToString, "31/12/" + Now.Year.ToString, commons.Modules.TypeLanguage).Tables(0)
        cboTuanNam.DisplayMember = "TEN_TUAN"
        cboTuanNam.ValueMember = "TUAN"
        cboTuanNam.DropDownWidth = 250
        cboTuanNam.DataSource = tb
    End Sub


    Private Sub cbodonvi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodonvi.SelectedIndexChanged

    End Sub

    Private Sub cbodonvi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbodonvi.SelectionChangeCommitted
        Loadban()
    End Sub
    Private Function Kiemtranhap(ByVal so As Integer) As Boolean
        Try

            Kiemtranhap = True
            If so = 0 Then
                Dim intTuQuy, intDenQuy, nam, nam1 As Integer
                intTuQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtttuthang.Text, 2))
                intDenQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtdenthang1.Text, 2))
                nam = Convert.ToInt64(Microsoft.VisualBasic.Right(txtdenthang1.Text, 4))
                nam1 = Convert.ToInt64(Microsoft.VisualBasic.Right(txtttuthang.Text, 4))
                If intTuQuy > 12 Or intDenQuy > 12 Then
                    Kiemtranhap = False
                    Exit Function
                End If
                If nam1 > nam Then
                    Kiemtranhap = False
                    Exit Function
                Else
                    If nam1 = nam Then
                        If intTuQuy > intDenQuy Then
                            Kiemtranhap = False
                            Exit Function
                        End If
                    End If
                End If
            End If
            If so = 1 Then
                Dim intTuQuy, intDenQuy, nam, nam1 As Integer
                intTuQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtTuQuy.Text, 1))
                intDenQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtDenQuy.Text, 1))
                nam = Convert.ToInt64(Microsoft.VisualBasic.Right(txtDenQuy.Text, 4))
                nam1 = Convert.ToInt64(Microsoft.VisualBasic.Right(txtTuQuy.Text, 4))
                If intTuQuy > 4 Or intDenQuy > 4 Then
                    Kiemtranhap = False
                    Exit Function
                End If
                If nam1 > nam Then
                    Kiemtranhap = False
                    Exit Function
                Else
                    If nam1 = nam Then
                        If intTuQuy > intDenQuy Then
                            Kiemtranhap = False
                            Exit Function
                        End If
                    End If
                End If
                'If intTuQuy + nam1 > intDenQuy + nam Then
                '    Kiemtranhap = False
                'End If
            End If
            If so = 2 Then
                Dim intTuNam, intDenNam As Integer
                intTuNam = txtTuNam_MTBF.Text
                intDenNam = txtDenNam_MTBF.Text
                If intTuNam > intDenNam Then
                    Kiemtranhap = False
                    Exit Function
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub tabBaocao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabBaocao.SelectedIndexChanged
        Me.btnIN.Visible = IIf(tabBaocao.SelectedTab.Name = "tabSudung", False, True)
    End Sub

    Private Sub grdDanhsachbaocao4_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao4.RowEnter
        intRow4 = e.RowIndex
        AddHandler cboInTheo.SelectedIndexChanged, AddressOf Me.cboInTheo_SelectedIndexChanged
        Dim a As String = grdDanhsachbaocao4.Rows(e.RowIndex).Cells("REPORT_NAME").Value.ToString
        Select Case grdDanhsachbaocao4.Rows(e.RowIndex).Cells("REPORT_NAME").Value.ToString

            Case "rptMTBF"
                pnTGSuaChuaTB.Visible = True
                pnTheoNam.Visible = False
                pnNguyenNhan.Visible = False
                btnIN.Visible = False
                loaibaocao = 1
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
            Case "rptthoigiansuachuatrungbinhgiua2lanhuhong"
                pnTGSuaChuaTB.Visible = True
                pnTheoNam.Visible = False
                pnNguyenNhan.Visible = False
                btnIN.Visible = False
                loaibaocao = 2
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
            Case "rptthoigiansuachuatrungbinh"
                pnTGSuaChuaTB.Visible = True
                pnTheoNam.Visible = False
                pnNguyenNhan.Visible = False
                btnIN.Visible = False
                loaibaocao = 1
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
                '  cboInTheo_SelectedIndexChanged
            Case "rptthoigiansuachuatrungbinh_new"
                pnTGSuaChuaTB.Visible = True
                pnTheoNam.Visible = False
                pnNguyenNhan.Visible = False
                btnIN.Visible = False
                loaibaocao = 2
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
                '  cboInTheo_SelectedIndexChanged
            Case "rptBreakdownTime"
                pnTGSuaChuaTB.Visible = False
                pnTheoNam.Visible = True
                pnNguyenNhan.Visible = False
                btnIN.Visible = True
                cboTG_LoaiTB.Enabled = False
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
            Case "rptTHOI_GIAN_NGUNG_MAY_THEO_MAY"
                pnTGSuaChuaTB.Visible = False
                pnTheoNam.Visible = True
                pnNguyenNhan.Visible = False
                btnIN.Visible = True
                cboTG_LoaiTB.Enabled = True
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
                'Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NGUYEN_NHAN"
                '    pnTGSuaChuaTB.Visible = False
                '    pnTheoNam.Visible = False
                '    pnNguyenNhan.Visible = True
                '    btnIN.Visible = True
                '    lbaDayChuyen.Visible = True
                '    cbxDaychuyen.Visible = True
            Case "rptTHOI_GIAN_NGUNG_MAY_THEO_NAM"
                pnTGSuaChuaTB.Visible = False
                pnTheoNam.Visible = True
                pnNguyenNhan.Visible = False
                btnIN.Visible = True
                cboTG_LoaiTB.Enabled = True
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
            Case Else
                btnIN.Visible = True
                pnNguyenNhan.Visible = False
                pnTGSuaChuaTB.Visible = False
                pnTheoNam.Visible = False
                lbaDayChuyen.Visible = False
                cbxDaychuyen.Visible = False
        End Select
    End Sub



    Private Sub btnTheoDC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoDC.Click


        If cboInTheo.SelectedIndex = 1 And (txtTuQuy.Text.Trim = "" Or txtDenQuy.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Quý", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 0 And (txtttuthang.Text.Trim = "" Or txtdenthang1.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn tháng", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 2 And (txtTuNam_MTBF.Text.Trim = "" Or txtDenNam_MTBF.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Năm", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If Kiemtranhap(cboInTheo.SelectedIndex) = False Then
            Windows.Forms.MessageBox.Show("Nhập số liệu không chính xác", "Thông báo", Windows.Forms.MessageBoxButtons.OK)
            Exit Sub
        End If
        'If cboInTheo.SelectedIndex = 0 Then
        '    bolQuy = True
        'Else
        '    bolQuy = False
        'End If
        Select Case cboInTheo.SelectedIndex
            Case 0
                baocao = 0
            Case 1
                baocao = 1
            Case 2
                baocao = 2

        End Select

        Select Case loaibaocao
            Case 1 'old
                Select Case cboInTheo.SelectedIndex
                    Case 0 'thang
                        Dim tuquy As String
                        Dim denquy As String
                        tuquy = txtttuthang.Text
                        denquy = txtdenthang1.Text
                        tu = txtttuthang.Text
                        den = txtdenthang1.Text
                        Dim strNam1 As String
                        If tuquy.Length = 7 And denquy.Length = 7 Then

                            Dim dt As New DataTable
                            Dim intTuQuy, intDenQuy As Int16
                            intTuQuy = Microsoft.VisualBasic.Left(txtttuthang.Text, 2)
                            intDenQuy = Microsoft.VisualBasic.Left(txtdenthang1.Text, 2)
                            strNam = Microsoft.VisualBasic.Right(txtdenthang1.Text, 4).ToString
                            strNam1 = Microsoft.VisualBasic.Right(txtttuthang.Text, 4).ToString
                            commons.Modules.ObjSystems.XoaTable("dbo.NHOC_thang")
                            commons.Modules.SQLString = "CREATE TABLE dbo.NHOC_thang(thang NVARCHAR(7))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            If strNam = strNam1 Then
                                For i As Int16 = intTuQuy To intDenQuy
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                Next
                            Else
                                Dim i As Integer
                                Dim st As Integer
                                If (strNam - strNam1) > 1 Then
                                    st = (strNam - strNam1 - 1) * 12
                                    st = st + (intDenQuy) + (12 - intTuQuy)
                                Else
                                    If strNam1 = strNam Then
                                        st = intDenQuy - intTuQuy
                                    Else
                                        st = intDenQuy + (12 - intTuQuy)
                                    End If
                                End If
                                Dim x As Integer = intTuQuy - 1
                                Dim nam As Integer = strNam1
                                For i = intTuQuy To st + intTuQuy
                                    x = x + 1
                                    If x > 12 Then
                                        x = 1
                                        nam += 1
                                    End If
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                                Next
                                'Dim i As Integer
                                'For i = intTuQuy To 12
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                                'For i = 1 To intDenQuy
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                            End If
                        End If

                    Case 1 'quy
                        Dim tuquy As String
                        Dim denquy As String
                        tuquy = txtTuQuy.Text
                        denquy = txtDenQuy.Text

                        If tuquy.Length = 6 And denquy.Length = 6 Then

                            Dim dt As New DataTable
                            Dim intTuQuy, intDenQuy As Int16
                            Dim strNam1 As String
                            intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
                            intDenQuy = Microsoft.VisualBasic.Left(txtDenQuy.Text, 1)
                            tu = txtTuQuy.Text
                            den = txtDenQuy.Text
                            strNam = Microsoft.VisualBasic.Right(txtDenQuy.Text, 4).ToString
                            strNam1 = Microsoft.VisualBasic.Right(txtTuQuy.Text, 4).ToString
                            commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
                            commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_QUY(QUY NVARCHAR(7))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            If strNam = strNam1 Then
                                For i As Int16 = intTuQuy To intDenQuy
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                Next
                            Else
                                Dim i As Integer
                                Dim st As Integer
                                If (strNam - strNam1) > 1 Then
                                    st = (strNam - strNam1 - 1) * 4
                                    st = st + (intDenQuy) + (4 - intTuQuy)
                                Else
                                    If strNam1 = strNam Then
                                        st = intDenQuy - intTuQuy
                                    Else
                                        st = intDenQuy + (12 - intTuQuy)
                                    End If
                                End If
                                Dim x As Integer = intTuQuy - 1
                                Dim nam As Integer = strNam1
                                For i = intTuQuy To st + intTuQuy
                                    x = x + 1
                                    If x > 4 Then
                                        x = 1
                                        nam += 1
                                    End If
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                                Next

                                'Dim i As Integer
                                'For i = intTuQuy To 4
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                                'For i = 1 To intDenQuy
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                            End If

                        End If
                    Case 2 'nam
                        Dim tunam As String
                        Dim dennam As String
                        Dim dt As New DataTable
                        Dim intTuNam, intDenNam As Int16
                        tunam = txtTuNam_MTBF.Text
                        dennam = txtDenNam_MTBF.Text
                        tu = txtTuNam_MTBF.Text
                        den = txtDenNam_MTBF.Text
                        If tunam.Length = 4 And dennam.Length = 4 Then
                            intTuNam = txtTuNam_MTBF.Text
                            intDenNam = txtDenNam_MTBF.Text
                            commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
                            commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_NAM(NAM NVARCHAR(5))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            For i As Int16 = intTuNam To intDenNam
                                commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_NAM VALUES(N'" + i.ToString + "')"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            Next
                        End If
                End Select
                Dim frm As New frmMTBF_TheoDC
                frm.ShowDialog()
            Case 2 'new
                Select Case cboInTheo.SelectedIndex
                    Case 0 'thang
                        Dim tuquy As String
                        Dim denquy As String
                        tuquy = txtttuthang.Text
                        denquy = txtdenthang1.Text
                        tu = txtttuthang.Text
                        den = txtdenthang1.Text
                        Dim strNam1 As String
                        If tuquy.Length = 7 And denquy.Length = 7 Then

                            Dim dt As New DataTable
                            Dim intTuQuy, intDenQuy As Int16
                            intTuQuy = Microsoft.VisualBasic.Left(txtttuthang.Text, 2)
                            intDenQuy = Microsoft.VisualBasic.Left(txtdenthang1.Text, 2)
                            strNam = Microsoft.VisualBasic.Right(txtdenthang1.Text, 4).ToString
                            strNam1 = Microsoft.VisualBasic.Right(txtttuthang.Text, 4).ToString
                            commons.Modules.ObjSystems.XoaTable("dbo.NHOC_thang")
                            commons.Modules.SQLString = "CREATE TABLE dbo.NHOC_thang(thang NVARCHAR(7))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            If strNam = strNam1 Then
                                For i As Int16 = intTuQuy To intDenQuy
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                Next
                            Else
                                Dim i As Integer
                                Dim st As Integer
                                If (strNam - strNam1) > 1 Then
                                    st = (strNam - strNam1 - 1) * 12
                                    st = st + (intDenQuy) + (12 - intTuQuy)
                                Else
                                    If strNam1 = strNam Then
                                        st = intDenQuy - intTuQuy
                                    Else
                                        st = intDenQuy + (12 - intTuQuy)
                                    End If
                                End If
                                Dim x As Integer = intTuQuy - 1
                                Dim nam As Integer = strNam1
                                For i = intTuQuy To st + intTuQuy
                                    x = x + 1
                                    If x > 12 Then
                                        x = 1
                                        nam += 1
                                    End If
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                                Next
                                'For i = 1 To intDenQuy
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                            End If
                        End If

                    Case 1 'quy
                        Dim tuquy As String
                        Dim denquy As String
                        tuquy = txtTuQuy.Text
                        denquy = txtDenQuy.Text

                        If tuquy.Length = 6 And denquy.Length = 6 Then

                            Dim dt As New DataTable
                            Dim intTuQuy, intDenQuy As Int16
                            Dim strNam1 As String
                            intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
                            intDenQuy = Microsoft.VisualBasic.Left(txtDenQuy.Text, 1)
                            tu = txtTuQuy.Text
                            den = txtDenQuy.Text
                            strNam = Microsoft.VisualBasic.Right(txtDenQuy.Text, 4).ToString
                            strNam1 = Microsoft.VisualBasic.Right(txtTuQuy.Text, 4).ToString
                            commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
                            commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_QUY(QUY NVARCHAR(7))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            If strNam = strNam1 Then
                                For i As Int16 = intTuQuy To intDenQuy
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                Next
                            Else
                                Dim i As Integer
                                Dim st As Integer
                                If (strNam - strNam1) > 1 Then
                                    st = (strNam - strNam1 - 1) * 4
                                    st = st + (intDenQuy) + (4 - intTuQuy)
                                Else
                                    If strNam1 = strNam Then
                                        st = intDenQuy - intTuQuy
                                    Else
                                        st = intDenQuy + (12 - intTuQuy)
                                    End If
                                End If
                                Dim x As Integer = intTuQuy - 1
                                Dim nam As Integer = strNam1
                                For i = intTuQuy To st + intTuQuy
                                    x = x + 1
                                    If x > 4 Then
                                        x = 1
                                        nam += 1
                                    End If
                                    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                                Next
                                'Dim i As Integer
                                'For i = intTuQuy To 4
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                                'For i = 1 To intDenQuy
                                '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                                'Next
                            End If

                        End If
                    Case 2 'nam
                        Dim tunam As String
                        Dim dennam As String
                        Dim dt As New DataTable
                        Dim intTuNam, intDenNam As Int16
                        tunam = txtTuNam_MTBF.Text
                        dennam = txtDenNam_MTBF.Text
                        tu = txtTuNam_MTBF.Text
                        den = txtDenNam_MTBF.Text
                        If tunam.Length = 4 And dennam.Length = 4 Then
                            intTuNam = txtTuNam_MTBF.Text
                            intDenNam = txtDenNam_MTBF.Text
                            commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
                            commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_NAM(NAM NVARCHAR(5))"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            For i As Int16 = intTuNam To intDenNam
                                commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_NAM VALUES(N'" + i.ToString + "')"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            Next
                        End If
                End Select
                Dim frm As New frmTGSC_TheoDC
                frm.ShowDialog()
        End Select
    End Sub

    Private Sub btnTheoMay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoMay.Click
        'intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
        If cboInTheo.SelectedIndex = 1 And (txtTuQuy.Text.Trim = "/" Or txtDenQuy.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Quý", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 0 And (txtttuthang.Text.Trim = "/" Or txtdenthang1.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn tháng", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 2 And (txtTuNam_MTBF.Text.Trim = "/" Or txtDenNam_MTBF.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Năm", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If Kiemtranhap(cboInTheo.SelectedIndex) = False Then
            Windows.Forms.MessageBox.Show("Nhập số liệu không chính xác", "Thông báo", Windows.Forms.MessageBoxButtons.OK)
            Exit Sub
        End If
        'If cboInTheo.SelectedIndex = 0 Then
        '    bolQuy = True
        'Else
        '    bolQuy = False
        'End If
        Select Case cboInTheo.SelectedIndex
            Case 0
                baocao = 0
            Case 1
                baocao = 1
            Case 2
                baocao = 2
        End Select

        Select Case cboInTheo.SelectedIndex

            Case 0
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtttuthang.Text
                denquy = txtdenthang1.Text
                tu = txtttuthang.Text
                den = txtdenthang1.Text
                Dim strNam1 As String
                If tuquy.Length = 7 And denquy.Length = 7 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    intTuQuy = Microsoft.VisualBasic.Left(txtttuthang.Text, 2)
                    intDenQuy = Microsoft.VisualBasic.Left(txtdenthang1.Text, 2)
                    strNam = Microsoft.VisualBasic.Right(txtdenthang1.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtttuthang.Text, 4).ToString
                    commons.Modules.ObjSystems.XoaTable("NHOC_thang")
                    commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_thang(thang NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 12
                            st = st + (intDenQuy) + (12 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 12 Then
                                x = 1
                                nam += 1
                            End If
                            commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        Next
                    End If
                End If

            Case 1
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtTuQuy.Text
                denquy = txtDenQuy.Text

                If tuquy.Length = 6 And denquy.Length = 6 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    Dim strNam1 As String
                    intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
                    intDenQuy = Microsoft.VisualBasic.Left(txtDenQuy.Text, 1)
                    tu = txtTuQuy.Text
                    den = txtDenQuy.Text
                    strNam = Microsoft.VisualBasic.Right(txtDenQuy.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtTuQuy.Text, 4).ToString
                    commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
                    commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_QUY(QUY NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 4
                            st = st + (intDenQuy) + (4 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 4 Then
                                x = 1
                                nam += 1
                            End If
                            commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                        Next
                        'Dim i As Integer
                        'For i = intTuQuy To 4
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                        'For i = 1 To intDenQuy
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                    End If

                End If
            Case 2
                Dim tunam As String
                Dim dennam As String
                Dim dt As New DataTable
                Dim intTuNam, intDenNam As Int16
                tunam = txtTuNam_MTBF.Text
                dennam = txtDenNam_MTBF.Text
                tu = txtTuNam_MTBF.Text
                den = txtDenNam_MTBF.Text
                If tunam.Length = 4 And dennam.Length = 4 Then
                    intTuNam = txtTuNam_MTBF.Text
                    intDenNam = txtDenNam_MTBF.Text
                    commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
                    commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_NAM(NAM NVARCHAR(5))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                    For i As Int16 = intTuNam To intDenNam
                        commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_NAM VALUES(N'" + i.ToString + "')"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                    Next
                End If
        End Select
        Select Case loaibaocao
            Case 1 'old
                Dim frm As New frmMTBF_TheoMay
                frm.ShowDialog()
            Case 2 'new
                Dim frm As New frmTGSC_TheoMay
                frm.ShowDialog()
        End Select

    End Sub

    Private Sub grdDanhsachbaocao6_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao6.RowEnter
        intRow6 = e.RowIndex
        Select Case grdDanhsachbaocao6.Rows(e.RowIndex).Cells("REPORT_NAME").Value.ToString
            Case "rptChuKyHieuChuanNoi_Ngoai"
                rdNoiNgoai.Visible = True
                lblNam.Visible = True
                txtNam.Visible = True
            Case "rptDanhSachThietBiDaHC"
                rdNoiNgoai.Visible = False
                lblNam.Visible = True
                txtNam.Visible = True
            Case Else
                rdNoiNgoai.Visible = False
                lblNam.Visible = False
                txtNam.Visible = False
        End Select
        txtNam.Focus()
    End Sub

    Private Sub grdDanhsachbaocao8_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao8.RowEnter
        intRow8 = e.RowIndex
        Select Case Me.grdDanhsachbaocao8.Rows(e.RowIndex).Cells("REPORT_NAME").Value
            Case "rptCTY_DA_CUNG_CAP_VAT_TU"
                cboNCC.Visible = True
                cboVattu.Visible = False
                cboKho.Visible = False
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = True
                lblVatTu.Visible = False
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptDANH_GIA_NCC"
                cboNCC.Visible = True
                dtTuNgay_Kho.Visible = True
                dtDenNgay_Kho.Visible = True
                cboVattu.Visible = False
                cboKho.Visible = False
                cboThang.Visible = False
                lblNhaCungCap.Visible = True
                lblVatTu.Visible = False
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = True
                lblDenNgay_Kho.Visible = True
                lblThang.Visible = False
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
                cboNCC.Visible = False
                cboVattu.Visible = True
                cboKho.Visible = False
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = True
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptTON_KHO_KHONG_THEO_VI_TRI"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = True
                cboThang.Visible = False ' True
                dtTuNgay_Kho.Visible = True ' False
                dtDenNgay_Kho.Visible = True ' False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = True
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = True
                lblDenThangKHO.Visible = True
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = True
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptTON_KHO_THEO_VI_TRI"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = True
                cboThang.Visible = False ' True
                dtTuNgay_Kho.Visible = True ' False
                dtDenNgay_Kho.Visible = True ' False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = True
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = True
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = True
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptTON_KHO_THEO_VI_TRI_BAYER"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = True
                cboThang.Visible = False ' True
                dtTuNgay_Kho.Visible = True ' False
                dtDenNgay_Kho.Visible = True ' False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = True
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = True
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = True
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = True
                lbaClass.Visible = True

            Case "rptTON_KHO_THEO_PHIEU_NHAP"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = True
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = True
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = False
                radDaTH.Visible = False
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptDDH"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = False
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = True
                radDaTH.Visible = True
                radDaTH.Checked = True
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case "rptDE_XUAT_MUA_HANG"
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = False
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = True
                radDaTH.Visible = True
                radDaTH.Checked = True
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
            Case Else
                cboNCC.Visible = False
                cboVattu.Visible = False
                cboKho.Visible = False
                cboThang.Visible = False
                dtTuNgay_Kho.Visible = False
                dtDenNgay_Kho.Visible = False
                lblNhaCungCap.Visible = False
                lblVatTu.Visible = False
                lblKho.Visible = False
                lblTuNgay_Kho.Visible = False
                lblDenNgay_Kho.Visible = False
                lblThang.Visible = False
                radChuaTH.Visible = False
                radDaTH.Visible = False
                radDaTH.Checked = False
                lblDenThangKHO.Visible = False
                chkVTPTGiaoDich.Visible = False
                cbxClass.Visible = False
                lbaClass.Visible = False
        End Select
    End Sub

    Private Sub grdDanhsachbaocao5_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachbaocao5.RowEnter
        intRow5 = e.RowIndex
        cboLoaiTB_CP.Visible = True : lblLoaiTB_CP.Visible = True
        cboNhomTB_CP.Visible = True : lblNhomTB_CP.Visible = True
        lblLoaiBT_CP.Visible = True : cboLoaiBT_CP.Visible = True
        lblDayChuyenSXTB_CP.Visible = True : cboDayChuyenSXTB_CP.Visible = True
        lblThoiGianLoc.Visible = True : lblTuNam_TKCP.Visible = True
        dtpTuNam_TKCP.Visible = True : lblDenNam_TKCP.Visible = True
        dtpDenNam_TKCP.Visible = True

        Select Case Me.grdDanhsachbaocao5.Rows(e.RowIndex).Cells("REPORT_NAME").Value
            Case "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB"
                cboLoaiTB_CP.Enabled = True : lblLoaiTB_CP.Enabled = True
                cboNhomTB_CP.Enabled = False : lblNhomTB_CP.Enabled = False
                lblLoaiBT_CP.Enabled = False : cboLoaiBT_CP.Enabled = False
                lblDayChuyenSXTB_CP.Enabled = False : cboDayChuyenSXTB_CP.Enabled = False
            Case "rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
                cboLoaiTB_CP.Enabled = False : lblLoaiTB_CP.Enabled = False
                cboNhomTB_CP.Enabled = True : lblNhomTB_CP.Enabled = True
                lblLoaiBT_CP.Enabled = False : cboLoaiBT_CP.Enabled = False
                lblDayChuyenSXTB_CP.Enabled = False : cboDayChuyenSXTB_CP.Enabled = False
            Case "rptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
                cboLoaiTB_CP.Enabled = True : lblLoaiTB_CP.Enabled = True
                cboNhomTB_CP.Enabled = False : lblNhomTB_CP.Enabled = False
                lblLoaiBT_CP.Enabled = True : cboLoaiBT_CP.Enabled = True
                lblDayChuyenSXTB_CP.Enabled = False : cboDayChuyenSXTB_CP.Enabled = False
            Case "rptCHI_PHI_THEO_DAY_CHUYEN"
                cboLoaiTB_CP.Enabled = False : lblLoaiTB_CP.Enabled = False
                cboNhomTB_CP.Enabled = False : lblNhomTB_CP.Enabled = False
                lblLoaiBT_CP.Enabled = False : cboLoaiBT_CP.Enabled = False
                lblDayChuyenSXTB_CP.Enabled = True : cboDayChuyenSXTB_CP.Enabled = True
            Case Else
                cboLoaiTB_CP.Visible = False : lblLoaiTB_CP.Visible = False
                cboNhomTB_CP.Visible = False : lblNhomTB_CP.Visible = False
                lblLoaiBT_CP.Visible = False : cboLoaiBT_CP.Visible = False
                lblDayChuyenSXTB_CP.Visible = False : cboDayChuyenSXTB_CP.Visible = False
                lblThoiGianLoc.Visible = False : lblTuNam_TKCP.Visible = False
                dtpTuNam_TKCP.Visible = False : lblDenNam_TKCP.Visible = False
                dtpDenNam_TKCP.Visible = False
        End Select
    End Sub

    Private Sub btnTheoLoaiMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTheoLoaiMay.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim SqlText As String = ""

        Select Case grdDanhsachbaocao2.CurrentRow.Cells("REPORT_NAME").Value.ToString
            Case "rptThoigianchaymay"
                Create_TitleReport_TGCM(1, True)
                Commons.clsXuLy.CreateTitleReport()
                print_reportThoigianchaymay_theoloaimay()

            Case "rptThoiGianChayMayCuoiTuan"
                Commons.clsXuLy.CreateTitleReport()
                Try
                    SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                Catch ex As Exception
                End Try

                SqlText = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                  "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN " & _
                  "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                       "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                       "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                       "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                  "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') AND (DATENAME(WEEKDAY,NGAY)='Saturday' OR DATENAME(WEEKDAY,NGAY)='Sunday')"

                If cboLoaithietbi2.SelectedValue.ToString <> "-1" Then SqlText += " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi2.SelectedValue.ToString & "'"

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

                Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN")
                While objReader.Read
                    If objReader.Item("TONG") = 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        objReader.Close()
                        GoTo KetThuc
                    End If
                End While
                objReader.Close()
                Create_TitleReport_TGCM(2, True)
                ReportPreview("reports/rptTHOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_LOAI_MAY.rpt")
KetThuc:
                Try
                    SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                Catch ex As Exception

                End Try
        End Select
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnTheoDayChuyen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoDayChuyen.Click
        Dim SqlText As String = ""
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Select Case grdDanhsachbaocao2.CurrentRow.Cells("REPORT_NAME").Value.ToString
            Case "rptThoigianchaymay"
                Create_TitleReport_TGCM(1, False)
                print_reportThoigianchaymay_theodaychuyen()

            Case "rptThoiGianChayMayCuoiTuan"
                Commons.clsXuLy.CreateTitleReport()
                Try
                    SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                Catch ex As Exception
                End Try

                SqlText = "SELECT DISTINCT [dbo].MAY_HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, TG.MS_MAY, dbo.DON_VI_TINH_RUN_TIME.TEN_DVT_RT, TG.NGAY, TG.CHI_SO_DONG_HO, TG.SO_MOVEMENT, TG.MS_PBT " & _
                          "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC " & _
                          "FROM dbo.THOI_GIAN_CHAY_MAY TG INNER JOIN dbo.MAY ON dbo.MAY.MS_MAY = TG.MS_MAY INNER JOIN dbo.DON_VI_TINH_RUN_TIME ON dbo.MAY.MS_DVT_RT = dbo.DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN " & _
                               "dbo.MAY_HE_THONG ON TG.MS_MAY = dbo.MAY_HE_THONG.MS_MAY INNER JOIN dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " & _
                          "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') AND (DATENAME(WEEKDAY, TG.NGAY) = 'Saturday' OR DATENAME(WEEKDAY, TG.NGAY) = 'Sunday')"

                If cboDayChuyenCuoiTuan.SelectedValue.ToString <> "-1" Then SqlText += " AND MAY_HE_THONG.MS_HE_THONG = " & cboDayChuyenCuoiTuan.SelectedValue

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

                Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC")
                While objReader.Read
                    If objReader.Item("TONG") = 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        objReader.Close()
                        GoTo KetThuc
                    End If
                End While
                objReader.Close()
                Create_TitleReport_TGCM(2, False)
                ReportPreview("reports/rptTHOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC.rpt")
KetThuc:
                Try
                    SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                Catch ex As Exception

                End Try
        End Select
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub txtttuthang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtttuthang.Click
        txtttuthang.SelectAll()
    End Sub

    Private Sub txtdenthang1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdenthang1.Click
        txtdenthang1.SelectAll()
    End Sub

    Private Sub rdLoaiMay_DD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLoaiMay_DD.CheckedChanged
        cboDiaDiem1.Enabled = True
        cboLoaiTB1.Enabled = False
    End Sub

    Private Sub rdLoaiMay_LoaiTB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLoaiMay_LoaiTB.CheckedChanged
        cboDiaDiem1.Enabled = False
        cboLoaiTB1.Enabled = True
    End Sub

    Private Sub rdNV_LuaChon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNV_LuaChon.CheckedChanged
        cboNVien.Enabled = True
    End Sub

    Private Sub rdNV_TatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNV_TatCa.CheckedChanged
        cboNVien.Enabled = False
    End Sub

    Private Sub lblLoaiTB_P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLoaiTB_P.Click

    End Sub
End Class