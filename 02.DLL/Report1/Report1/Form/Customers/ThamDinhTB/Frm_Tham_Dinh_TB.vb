
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class Frm_Tham_Dinh_TB    '   -------------
    Dim flag As Integer
    Dim flag_Check As Integer
    Dim rowSelect As Integer
    Dim strTimKiem As String = ""


    Public Function Create_DataTable() As DataTable
        Dim table As DataTable
        table = New DataTable
        table.Columns.Add(New DataColumn("Mã máy", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("MS_NHOM_MAY", Type.GetType("System.String")))
        Return table
    End Function
    Private Sub frm_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ShowDefaul_Control_FormLoad()
        ' lay du lieu len combobox tim kiem

        commons.Modules.SQLString = "Select MS_MAY as 'Mã máy' From May Group by MS_MAY"
        LoadList_TimKiem(commons.Modules.SQLString)
        ' Load len list Danh sach thiet bi 
        ShowList_DS_ThietBi(flag)
        ' Kiểm tra RadioButton check và gán dữ liệu tương ứng
        Check_RadioButton()
        ' Hiển thị dữ liệu mặc định
        Show_Form()
        If Commons.Modules.PermisString.Equals("Read only") Then
            bt_Them_ThamDinhHieuNang.Enabled = False
            bt_Xoa_ThamDinhHieuNang.Enabled = False

            bt_ThemThamDinhLapDat.Enabled = False
            bt_Xoa_ThamDinhLapDat.Enabled = False

            bt_Them_ThamDinhVanHanh.Enabled = False
            bt_Xoa_ThamDinhVanHanh.Enabled = False

            bt_Sua_ThietBi.Enabled = False
        End If
    End Sub
    ' Hiển thị defaul cho các control
    Public Sub ShowDefaul_Control_FormLoad()
        ' flag = 3
        ' lay du lieu len DS Thiet bi
        If (flag = Nothing) Then
            flag = 3
            rad_All.Checked = True
        End If
        ' hien thi defaul cho cac textbox
        txt_MaHS.Text = ""
        txt_TenHoSo.Text = ""

        lab_KQ_NhomTB.Text = ""
        lab_KQ_NoiLapDat.Text = ""
        lab_KQ_TenTB.Text = ""
        lab_KQ_ViTri.Text = ""
        bt_BoSua_TB.Visible = False
    End Sub

    Public Sub Check_RadioButton()
        Select Case (flag)
            Case 1 'Neu check Xem theo nơi lắp đặt được chọn
                'Show- Hide Control
                lab_LoaiThietBi.Text = "Nơi lắp đặt"
                lab_NhomThietBi.Text = ""
                cmb_NhomTB.Visible = False 'an di
                cmb_LapDat_LoaiTB.Visible = True 'hien
                rad_NoiLapDat.Checked = True
                ' Day du lieu vao combo cmb_LapDat_LoaiTB
                ' Load ten nha xuong vao combo
                LoadList_TenNhaXuong()
                Exit Select
            Case 2 ' Tap check Xem theo loại TB được chọn
                ' Show- Hiden control
                lab_LoaiThietBi.Text = "Loại thiết bị"
                lab_NhomThietBi.Text = "Nhóm TB"
                cmb_NhomTB.Visible = True
                cmb_LapDat_LoaiTB.Visible = True
                rad_LoaiThietBi.Checked = True
                ' Day du lieu vao 2 combo 
                LoadList_TenLoaiMay()
                'LoadList_TenNhomMay()
                LoadList_NhomThietBi()
                Exit Select
            Case 3 ' tap Xem tat ca duoc chon
                lab_LoaiThietBi.Text = ""
                cmb_LapDat_LoaiTB.Visible = False
                rad_All.Checked = True
                cmb_NhomTB.Visible = False
                'cmb_NhomTB.Visible = False
                lab_NhomThietBi.Text = ""
        End Select
    End Sub

    ' Lay Du lieu len DS Thiet bi
    Public Sub ShowList_DS_ThietBi(ByVal luaChon As Integer)

        commons.Modules.SQLString = Nothing
        Select Case (luaChon)
            Case 1 ' Xem theo noi lap dat. Chọn xem theo cobo o ben
                ' May_Nha_Xuong(MAY,NgayNhap,MS_N_XUONG)
                commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
                commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"

                commons.Modules.SQLString += " From MAY m, MAY_NHA_XUONG mn, NHA_XUONG nx"
                commons.Modules.SQLString += " Where m.MS_MAY = mn.MS_MAY and mn.MS_N_XUONG = nx.MS_N_XUONG "
                commons.Modules.SQLString += " And nx.TEN_N_XUONG like N'" + cmb_LapDat_LoaiTB.Text + "'"
                Exit Select
            Case 2
                commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
                commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
                commons.Modules.SQLString += " From LOAI_MAY l, NHOM_MAY n, MAY m "
                commons.Modules.SQLString += " Where l.MS_LOAI_MAY = n.MS_LOAI_MAY and n.MS_NHOM_MAY = m.MS_NHOM_MAY "
                commons.Modules.SQLString += " and l.TEN_LOAI_MAY like N'" + cmb_LapDat_LoaiTB.Text + "'"
                Exit Select
            Case 3
                commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
                commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
                commons.Modules.SQLString += " From May m"

                Exit Select
        End Select
        ' Lay dc cau select -> thuc hien 
        If (commons.Modules.SQLString Is Nothing) Then
        Else
            LoadList_DS_ThietBi(commons.Modules.SQLString)
        End If
    End Sub
    Public Sub LoadList_DS_ThietBi(ByVal SQLString As String)
        Dim provider As New cls_DataProvider
        Dim ds As New DataSet
        ds.Clear()
        ds = provider.OpentDataSet(SQLString)
        gv_DS_ThietBi.DataSource = ds.Tables(0)
        If (ch_TheoTen.Checked = False) Then
            gv_DS_ThietBi.Columns("Mã máy").Visible = True
            gv_DS_ThietBi.Columns("MS_NHOM_MAY").Visible = False
            gv_DS_ThietBi.Columns("MS_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("TEN_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("NGAY_HIEU_LUC_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("Tên máy").Visible = False
        Else
            gv_DS_ThietBi.Columns("Mã máy").Visible = False
            gv_DS_ThietBi.Columns("MS_NHOM_MAY").Visible = False
            gv_DS_ThietBi.Columns("MS_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("TEN_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("NGAY_HIEU_LUC_HO_SO").Visible = False
            gv_DS_ThietBi.Columns("Tên máy").Visible = True
        End If
        gv_DS_ThietBi.RowHeadersVisible = False
        gv_DS_ThietBi.AllowUserToAddRows = False
    End Sub

    ' Lay du lieu dua vao combo box tim kiem
    Public Sub LoadList_TimKiem(ByVal SQLString As String)

        Dim provider As New cls_DataProvider
        Dim ds As New DataSet
        Dim i As Integer
        ds.Clear()
        Try
            i = gv_DS_ThietBi.CurrentRow.Index
        Catch ex As Exception
        End Try
        If (ch_TheoTen.Checked = False) Then
            commons.Modules.SQLString = "Select MS_MAY  as 'Mã máy' From MAY "
            ds = provider.OpentDataSet(SQLString)
            Try
                cmb_TimKiem.DataSource = ds.Tables(0)
                cmb_TimKiem.DisplayMember = "Mã máy"
                cmb_TimKiem.ValueMember = "Mã máy"
                cmb_TimKiem.SelectedIndex = 0
            Catch ex As Exception
            End Try
        Else
            commons.Modules.SQLString = "Select TEN_MAY as 'Tên máy' From MAY "
            ds = provider.OpentDataSet(SQLString)
            Try
                cmb_TimKiem.DataSource = ds.Tables(0)
                cmb_TimKiem.DisplayMember = "Tên máy"
                cmb_TimKiem.ValueMember = "Tên máy"
                cmb_TimKiem.SelectedIndex = 0
            Catch ex As Exception

            End Try
        End If
        rowSelect = i
    End Sub


    ' Lay ten nha xuong dua vao combo cmb_LapDat_LoaiTB
    Public Sub LoadList_TenNhaXuong()
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select Ten_N_Xuong from Nha_Xuong Group by Ten_N_Xuong"
        Dim ds As New DataSet
        ds.Clear()
        ds = provider.OpentDataSet(commons.Modules.SQLString)
        'cmb_LapDat_LoaiTB.
        Try
            cmb_LapDat_LoaiTB.DataSource = ds.Tables(0)
            cmb_LapDat_LoaiTB.DisplayMember = "Ten_N_Xuong"
            cmb_LapDat_LoaiTB.ValueMember = "Ten_N_Xuong"
            cmb_LapDat_LoaiTB.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    ' Lay du lieu vao combo cmb_LapDat_LoaiTB 
    Public Sub LoadList_TenLoaiMay()
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select TEN_LOAI_MAY, STT_MAY from LOAI_MAY order by STT_MAY"
        Dim ds As New DataSet
        ds.Clear()
        ds = provider.OpentDataSet(commons.Modules.SQLString)
        cmb_LapDat_LoaiTB.Items.Remove(0)
        Try
            cmb_LapDat_LoaiTB.DataSource = ds.Tables(0)
            cmb_LapDat_LoaiTB.DisplayMember = "TEN_LOAI_MAY"
            cmb_LapDat_LoaiTB.ValueMember = "TEN_LOAI_MAY"
            cmb_LapDat_LoaiTB.SelectedIndex = 0
        Catch ex As Exception

        End Try


    End Sub
    ' Lay du lieu dua vao combobox cmb_Lapdat_LoaiTB
    ' Chi khi CheckBox Xem theo nơi lắp đặt được chọn
    Public Sub LoadList_cmb_LapDat_LoaiTB()
        ' Lay tu bang Nha_Xuong

        commons.Modules.SQLString = "Select TEN_NHA_XUONG From NHA_XUONG GROUP BY TEN_NHA_XUONG"
        Dim provider As New cls_DataProvider
        Dim ds As New DataSet
        ds.Clear()
        ds = provider.OpentDataSet(commons.Modules.SQLString)
        cmb_LapDat_LoaiTB.Visible = True
        Try
            cmb_LapDat_LoaiTB.Items.Clear()
            cmb_LapDat_LoaiTB.DisplayMember = "TEN_NHA_XUONG"
            cmb_LapDat_LoaiTB.DataSource = ds.Tables(0)
            cmb_LapDat_LoaiTB.SelectedIndex = 0
        Catch ex As Exception

        End Try


    End Sub


    ' Radibutton
    Private Sub rad_NoiLapDat_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rad_NoiLapDat.MouseClick
        flag = 1
        frm_Main_Load(sender, e)
    End Sub

    Private Sub rad_LoaiThietBi_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rad_LoaiThietBi.MouseClick
        flag = 2
        frm_Main_Load(sender, e)
    End Sub

    Private Sub rad_All_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rad_All.MouseClick
        flag = 3
        ' show lai form
        frm_Main_Load(sender, e)
    End Sub


    ' Hien thi du lieu tu gv_DS_ThietBi
    Private Sub gv_DS_ThietBi_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_DS_ThietBi.MouseClick
        Show_Form()
    End Sub


    Public Function Get_TenNhomMay(ByVal maMay As String) As String
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select TEN_NHOM_MAY From NHOM_MAY n, MAY m "
        commons.Modules.SQLString += " Where m.MS_NHOM_MAY = n.MS_NHOM_MAY and m.MS_MAY like N'" + maMay + "' ORDER BY TEN_NHOM_MAY"
        Dim kq As String
        kq = provider.executeScalar(commons.Modules.SQLString).ToString()
        Return kq
    End Function
    ' Chọn ngày lớn nhất
    ' Lấy ra ngày lớn nhất của MS_MAY trong MAY_NhA_XUONG theo MS_MAY
    Public Function Get_TenNhaXuong(ByVal maMay As String) As String
        Dim provider As New cls_DataProvider

        Dim sqlNgayMax As String
        Dim tenNX As String = Nothing
        sqlNgayMax = "Select MS_N_XUONG, NGAY_NHAP "
        sqlNgayMax += " From MAY_NHA_XUONG Where MS_MAY like N'" + maMay + "'"
        sqlNgayMax += " Order by NGAY_NHAP"
        Dim dtNgay As New DataTable
        Try
            dtNgay = provider.OpentDataTable(sqlNgayMax)
            Dim maNX As String
            maNX = dtNgay.Rows(0)("MS_N_XUONG").ToString
            ' Lay ten nha xuong theo ms nha xuong            
            maNX = dtNgay.Rows(0)("MS_N_XUONG").ToString
            commons.Modules.SQLString = "Select TEN_N_XUONG From NHA_XUONG Where MS_N_XUONG like '" + maNX + "'   ORDER BY TEN_N_XUONG "
            tenNX = provider.executeScalar(commons.Modules.SQLString).ToString
        Catch ex As Exception
        End Try
        Return tenNX
    End Function
    Public Function Get_ViTriLapDat(ByVal maMay As String) As String
        ' = "SELECT MS_MAY, MO_TA FROM MAY WHERE MS_MAY = N'" & maMay & "'"
        Dim vViTri As String = ""
        Try
            Dim vTb As DataTable = New DataTable()
            vTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY, MO_TA FROM MAY WHERE MS_MAY = N'" & maMay & "'"))
            vViTri = vTb.Rows(0)("MO_TA")
            Return vViTri
        Catch ex As Exception
            Return vViTri
        End Try

        'Dim provider As New cls_DataProvider
        '
        'Dim sqlNgayMax As String
        'Dim tenNX As String = Nothing
        'sqlNgayMax = "Select MO_TA"
        'sqlNgayMax += " From MAY Where MS_MAY = N'" + maMay + "'"
        'Dim dtNgay As New DataTable
        'Try
        '    dtNgay = provider.OpentDataTable(sqlNgayMax)
        '    Dim maNX As String
        '    maNX = dtNgay.Rows(0)("MS_N_XUONG").ToString
        '    ' Lay ten nha xuong theo ms nha xuong            
        '    maNX = dtNgay.Rows(0)("MS_N_XUONG").ToString
        '    commons.Modules.SQLString = "Select TEN_N_XUONG From NHA_XUONG Where MS_N_XUONG like '" + maNX + "'    "
        '    tenNX = provider.executeScalar(commons.Modules.SQLString).ToString
        'Catch ex As Exception
        'End Try
        'Return tenNX
    End Function

    Private Sub ch_TheoTen_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ch_TheoTen.MouseClick
        ' Thay doi grid DS_ThietBi
        If (ch_TheoTen.Checked = False) Then

            gv_DS_ThietBi.Columns("Mã máy").Visible = True
            gv_DS_ThietBi.Columns("Tên máy").Visible = False
            flag_Check = 0
        Else
            gv_DS_ThietBi.Columns("Mã máy").Visible = False
            gv_DS_ThietBi.Columns("Tên máy").Visible = True
            flag_Check = 1
        End If
        Try
            gv_DS_ThietBi.Rows(rowSelect).Selected = True
        Catch ex As Exception
        End Try
        ' Thay doi combo

    End Sub


    '------------------------------------------------------------------------
    ' Hien thi Du lieu len gv_ThamdinhLapDat
    Public Sub Show_gv_ThamDinhLapDat(ByVal maMay As String)
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select MS_MAY  , NGAY_THAM_DINH_LAP_DAT, NGUOI_THAM_DINH_LAP_DAT, GHI_CHU "
        commons.Modules.SQLString += " From MAY_THAM_DINH_LAP_DAT "
        commons.Modules.SQLString += " Where MS_MAY like N'" + maMay + "'"
        Dim ds As New DataSet
        ds.Clear()
        ''
        Dim clsLapDat As New cls_MayThamDinhLapDat
        Dim dt As New DataTable
        dt = clsLapDat.CreateDataTable()
        Try
            Dim myReader As SqlDataReader
            myReader = provider.executeQuery(commons.Modules.SQLString)
            While (myReader.Read)
                Dim myRow As DataRow
                myRow = dt.NewRow
                myRow("Mã máy") = myReader("MS_MAY").ToString
                myRow("Ngày thẩm định") = myReader("NGAY_THAM_DINH_LAP_DAT").ToString
                myRow("Người thẩm định") = myReader("NGUOI_THAM_DINH_LAP_DAT").ToString
                myRow("Ghi chú") = myReader("GHI_CHU").ToString
                dt.Rows.Add(myRow)
            End While
            myReader.Close()
            ' Bao source
            gv_ThamDinhLapDat.DataSource = Nothing
            gv_ThamDinhLapDat.DataSource = dt
            gv_ThamDinhLapDat.Columns("Mã máy").Visible = False
            '
            gv_ThamDinhLapDat.AllowUserToAddRows = False
        Catch ex As Exception

        End Try
        'gv_ThamDinhLapDat.Columns(0).DataPropertyName = "MS_MAY"
        'gv_ThamDinhLapDat.Columns(1).DataPropertyName = "NGAY_THAM_DINH_LAP_DAT"
        'gv_ThamDinhLapDat.Columns(2).DataPropertyName = "NGUOI_THAM_DINH_LAP_DAT"
        'gv_ThamDinhLapDat.Columns(3).DataPropertyName = "GHI_CHU"
        'gv_ThamDinhLapDat.DataMember.Visible = False
    End Sub
    ' Hien thi Du lieu len gv_ThamdinhVanHanh
    Public Sub Show_gv_ThamDinhVanHanh(ByVal maMay As String)
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select MS_MAY, NGAY_THAM_DINH_VAN_HANH, NGUOI_THAM_DINH_VAN_HANH, GHI_CHU "
        commons.Modules.SQLString += " From MAY_THAM_DINH_VAN_HANH "
        commons.Modules.SQLString += " Where MS_MAY like N'" + maMay + "'"
        Dim clsVanHanh As New cls_MayThamDinhVanHanh
        Dim dt As New DataTable

        dt = clsVanHanh.CreateDataTable()
        Try
            Dim myReader As SqlDataReader
            myReader = provider.executeQuery(commons.Modules.SQLString)
            While (myReader.Read)
                Dim myRow As DataRow
                myRow = dt.NewRow
                myRow("Mã máy") = myReader("MS_MAY").ToString
                myRow("Ngày thẩm định") = myReader("NGAY_THAM_DINH_VAN_HANH").ToString
                myRow("Người thẩm định") = myReader("NGUOI_THAM_DINH_VAN_HANH").ToString
                myRow("Ghi chú") = myReader("GHI_CHU").ToString
                dt.Rows.Add(myRow)
            End While
            myReader.Close()
        Catch ex As Exception

        End Try
        gv_ThamDinhVanHanh.DataSource = Nothing
        gv_ThamDinhVanHanh.DataSource = dt
        gv_ThamDinhVanHanh.Columns("Mã máy").Visible = False
        gv_ThamDinhVanHanh.AllowUserToAddRows = False

    End Sub

    ' Hien thi Du lieu len gv_ThamdinhHieuNang
    Public Sub Show_gv_ThamDinhHieuNang(ByVal maMay As String)
        Dim provider As New cls_DataProvider

        commons.Modules.SQLString = "Select MS_MAY, NGAY_THAM_DINH_HIEU_NANG , NGUOI_THAM_DINH_HIEU_NANG, SAN_PHAM_THAM_DINH_HIEU_NANG,LO, GHI_CHU "
        commons.Modules.SQLString += " From MAY_THAM_DINH_HIEU_NANG "
        commons.Modules.SQLString += " Where MS_MAY like N'" + maMay + "'"
        Dim clsHieuNang As New cls_MayThamDinhHieuNang
        Dim dt As New DataTable
        dt = clsHieuNang.CreateDataTable()
        Try
            Dim myReader As SqlDataReader
            myReader = provider.executeQuery(commons.Modules.SQLString)
            While (myReader.Read)
                Dim myRow As DataRow
                myRow = dt.NewRow()
                myRow("Mã máy") = myReader("MS_MAY").ToString
                myRow("Ngày thẩm định") = myReader("NGAY_THAM_DINH_HIEU_NANG").ToString
                myRow("Người thẩm định") = myReader("NGUOI_THAM_DINH_HIEU_NANG").ToString
                myRow("Sản phẩm thẩm định") = myReader("SAN_PHAM_THAM_DINH_HIEU_NANG").ToString
                myRow("Số lô") = myReader("LO").ToString
                myRow("Ghi chú") = myReader("GHI_CHU").ToString
                dt.Rows.Add(myRow)
            End While
            myReader.Close()
            gv_ThamDinhHieuNang.DataSource = Nothing

            gv_ThamDinhHieuNang.DataSource = dt
            gv_ThamDinhHieuNang.Columns("Mã máy").Visible = False
            gv_ThamDinhHieuNang.AllowUserToAddRows = False
            'gv_ThamDinhHieuNang.Columns(1).Visible = False
        Catch ex As Exception
        End Try
        'NGUOI_THAM_DINH_HIEU_NANG, SAN_PHAM_THAM_DINH_HIEU_NANG , GHI_CHU "
        'gv_ThamDinhHieuNang.Columns(0).DataPropertyName = "NGAY_THAM_DINH_HIEU_NANG"
        'gv_ThamDinhHieuNang.Columns(1).DataPropertyName = "NGUOI_THAM_DINH_HIEU_NANG"
        'gv_ThamDinhHieuNang.Columns(2).DataPropertyName = "SAN_PHAM_THAM_DINH_HIEU_NANG"
        'gv_ThamDinhHieuNang.Columns(3).DataPropertyName = "GHI_CHU"

    End Sub
    '---------------------------------------------------------------------
    ' Xử lý Group chọn xem theo loai nao
    Public Sub Load_ChonXemTheoNoiLapDat(ByVal flag As String)
        ' Neu tap 1 duoc chon 
        ' Xu ly show theo tap 1
        ShowInfo_XemTheoNoiLapDat(flag)

    End Sub

    ' Show thong tin theo tap Xem thoi noi lap dat
    Public Sub ShowInfo_XemTheoNoiLapDat(ByVal flag As Integer)
        ShowList_DS_ThietBi(flag)
    End Sub
    ' Show thong tin theo Xem theo loai thiet bi
    ' Day du lieu vao combo
    Public Sub ShowInfo_XemTheoLoaiThietBi()
        ' Day du lieu vao cbo Loaithietbi
        LoadList_TenLoaiMay()
        ' Day du lieu vao cbo nhom thiet bi
        'LoadList_TenNhomMay()
        LoadList_NhomThietBi()

    End Sub
    ' Lay MS_LOAI_MAY theo TEN_LOAI_MAY
    Public Function Get_MS_LOAI_MAY(ByVal tenLoaiMay As String) As String
        Dim provider As New cls_DataProvider
        Dim kq As String

        commons.Modules.SQLString = "Select MS_LOAI_MAY From LOAI_MAY Where TEN_LOAI_MAY like N'" + tenLoaiMay + "'"
        kq = provider.executeScalar(commons.Modules.SQLString).ToString
        Return kq
    End Function
    ' Lay MS_NHOM_MAY theo TEN_NHOM_MAY
    Public Function Get_MS_NHOM_MAY(ByVal tenNhomMay As String) As String
        Dim provider As New cls_DataProvider
        Dim kq As String

        commons.Modules.SQLString = "Select MS_NHOM_MAY From NHOM_MAY Where TEN_NHOM_MAY like N'" + tenNhomMay + "'"
        kq = provider.executeScalar(commons.Modules.SQLString).ToString
        Return kq
    End Function
    '-------------------------------------------------------

    Private Sub cmb_LapDat_LoaiTB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_LapDat_LoaiTB.SelectedIndexChanged
        Dim provider As New cls_DataProvider

        If (flag = 1) Then ' tap 1 dc chon
            commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
            commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
            commons.Modules.SQLString += " From MAY m, MAY_NHA_XUONG mn, NHA_XUONG n"
            commons.Modules.SQLString += " Where m.MS_MAY = mn.MS_MAY and mn.MS_N_XUONG = n.MS_N_XUONG and n.TEN_N_XUONG like N'%" + cmb_LapDat_LoaiTB.Text + "%' "
            Dim ds As New DataSet
            ds.Clear()
            ds = provider.OpentDataSet(commons.Modules.SQLString)
            gv_DS_ThietBi.DataSource = ds.Tables(0)
        ElseIf (flag = 2) Then ' tap 2 duoc chon
            ' Day du lieu moi vao cmb_NhomTB
            LoadList_NhomThietBi()
        End If
        Show_Form()

    End Sub

    Public Sub LoadList_NhomThietBi()
        Dim dt As New DataTable
        Dim provider As New cls_DataProvider

        dt.Clear()
        Dim str As String

        str = "Select TEN_NHOM_MAY From NHOM_MAY n, LOAI_MAY l"
        str += " Where n.MS_LOAI_MAY = l.MS_LOAI_MAY and l.TEN_LOAI_MAY like N'%" + cmb_LapDat_LoaiTB.Text + "%' ORDER BY TEN_NHOM_MAY"
        dt = provider.OpentDataTable(str)
        'cmb_NhomTB.Items.Remove(0)
        Try
            cmb_NhomTB.DisplayMember = "TEN_NHOM_MAY"
            cmb_NhomTB.ValueMember = "TEN_NHOM_MAY"
            cmb_NhomTB.DataSource = dt
            cmb_NhomTB.SelectedIndex = 0
        Catch ex As Exception

        End Try
        ' -------------------------------------------------------------------------------------------
        commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
        commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
        commons.Modules.SQLString += " From MAY m, NHOM_MAY n, LOAI_MAY l"
        commons.Modules.SQLString += " Where m.MS_NHOM_MAY = n.MS_NHOM_MAY and n.MS_LOAI_MAY = l.MS_LOAI_MAY"
        commons.Modules.SQLString += " and l.TEN_LOAI_MAY like N'" + cmb_LapDat_LoaiTB.Text + "' and n.TEN_NHOM_MAY like N'%" + cmb_NhomTB.Text + "%'"
        Dim ds As New DataSet
        ds.Clear()
        ds = provider.OpentDataSet(commons.Modules.SQLString)
        gv_DS_ThietBi.DataSource = ds.Tables(0)
    End Sub

    Private Sub cmb_NhomTB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_NhomTB.SelectedIndexChanged
        Dim provider As New cls_DataProvider

        Dim ds As New DataSet

        commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
        commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
        commons.Modules.SQLString += " From MAY m, NHOM_MAY n, LOAI_MAY l"
        commons.Modules.SQLString += " Where m.MS_NHOM_MAY = n.MS_NHOM_MAY and n.MS_LOAI_MAY = l.MS_LOAI_MAY"
        commons.Modules.SQLString += " and l.TEN_LOAI_MAY like N'%" + cmb_LapDat_LoaiTB.Text + "%' and n.TEN_NHOM_MAY like N'%" + cmb_NhomTB.Text + "%'"

        ds.Clear()
        ds = provider.OpentDataSet(commons.Modules.SQLString)
        gv_DS_ThietBi.DataSource = ds.Tables(0)
        Show_Form()
    End Sub
    Public Sub CapNhatControSua()
        bt_Sua_ThietBi.Text = "Ghi"
        bt_BoSua_TB.Visible = True
        bt_Them_ThamDinhHieuNang.Enabled = False
        bt_Xoa_ThamDinhHieuNang.Enabled = False
        bt_Them_ThamDinhVanHanh.Enabled = False
        bt_ThemThamDinhLapDat.Enabled = False
        bt_Xoa_ThamDinhLapDat.Enabled = False
        bt_Xoa_ThamDinhVanHanh.Enabled = False
        cmb_LapDat_LoaiTB.Enabled = False

        cmb_TimKiem.Enabled = False
        ' Groubox
        gr_ChonXem.Enabled = False
        ' GridView
        gv_DS_ThietBi.Enabled = False
    End Sub
    Public Sub CapNhatControlGhi()
        bt_Sua_ThietBi.Text = "Sửa"
        bt_BoSua_TB.Visible = False
        bt_Them_ThamDinhHieuNang.Enabled = True
        bt_Xoa_ThamDinhHieuNang.Enabled = True
        bt_Them_ThamDinhVanHanh.Enabled = True
        bt_ThemThamDinhLapDat.Enabled = True
        bt_Xoa_ThamDinhLapDat.Enabled = True
        bt_Xoa_ThamDinhVanHanh.Enabled = True
        txt_MaHS.ReadOnly = True
        txt_TenHoSo.ReadOnly = True
        txtNgayHieuLuc.ReadOnly = True
        cmb_LapDat_LoaiTB.Enabled = True
        cmb_NhomTB.Enabled = True
        cmb_TimKiem.Enabled = True
        ' Groubox
        gr_ChonXem.Enabled = True
        ' GridView
        gv_DS_ThietBi.Enabled = True
    End Sub
    Public Function KiemTraSuaHoSo() As Integer
        If (txt_MaHS.Text = "" And txt_TenHoSo.Text = "" And txtNgayHieuLuc.Text = Nothing) Then
            Return 0
        ElseIf (txt_MaHS.Text = "") Then
            Return 1
        ElseIf (txtNgayHieuLuc.Text.Length < 10) Then
            Return 2
        ElseIf (txt_TenHoSo.Text = "") Then
            Return 3

        End If
        Return 0
    End Function
    Public Sub EnableSuaHoSo(ByVal chon As Boolean)
        txt_MaHS.ReadOnly = chon
        txt_TenHoSo.ReadOnly = chon
        txtNgayHieuLuc.ReadOnly = chon
    End Sub
    ' Sửa mã HS, ten HS, ngày thẩm định
    Private Sub bt_Sua_ThietBi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Sua_ThietBi.Click
        ' Neu bat dau chon sua
        ' Enable_Control_MaHS()
        Dim kq As Integer
        Dim i As Integer
        If (bt_Sua_ThietBi.Text = "Ghi") Then
            kq = KiemTraSuaHoSo()
            Select Case kq
                Case 0 'Rong hoan toan
                    If (Sua_HoSo() = True) Then
                        CapNhatControlGhi()
                        EnableSuaHoSo(True)
                        bt_Thoat.Enabled = True
                    End If

                    Exit Select
                Case 1 ' ma hoso rong
                    i = MessageBox.Show("Chưa nhập Mã Hồ Sơ. Bạn có muốn nhập lại không", "Thông báo", MessageBoxButtons.YesNoCancel)
                    If (i = vbYes) Then ' chon nhap lai
                        txt_MaHS.Text = ""
                        txt_MaHS.Focus()
                    ElseIf (i = vbNo) Then
                        txt_TenHoSo.Text = ""
                        txtNgayHieuLuc.Text = Nothing
                        Sua_HoSo()
                        CapNhatControlGhi()
                    ElseIf (i = vbCancel) Then ' cancel
                        CapNhatControlGhi()
                        Show_Form()
                        EnableSuaHoSo(True)
                    End If
                    Exit Select
                Case 2 ' ngay hieu luc hs rong
                    i = MessageBox.Show("Ngày hiệu lực không được để trống. Bạn có muốn tiếp tục cập nhật không", "Thông báo", MessageBoxButtons.YesNo)
                    If (i = vbYes) Then ' yes
                        txtNgayHieuLuc.Focus()
                    ElseIf (i = vbNo) Then ' no. bo ghi
                        txtNgayHieuLuc.Text = Nothing
                        CapNhatControlGhi()
                        Show_Form()
                        EnableSuaHoSo(True)
                    End If

                    Exit Select
                Case 3 ' ten hs rong
                    i = MessageBox.Show("Chưa nhập Tên Hồ Sơ. Bạn có muốn nhập lại không", "Thông báo", MessageBoxButtons.YesNo)
                    If (i = vbYes) Then
                        txt_TenHoSo.Text = ""
                        txt_TenHoSo.Focus()
                    Else
                        Sua_HoSo()
                        CapNhatControlGhi()
                        'Show_Form()
                        EnableSuaHoSo(True)
                    End If
                    Exit Select

            End Select
        Else
            bt_Thoat.Enabled = False
            EnableSuaHoSo(False)
            CapNhatControSua()
        End If

    End Sub
    ' Khi người dùng nhấn nút sửa hồ sơ
    Public Function Sua_HoSo() As Boolean
        Dim provider As New cls_DataProvider
        Dim maMay As String
        Dim i As Integer
        Dim ngay As String

        Try
            i = gv_DS_ThietBi.CurrentRow.Index
            maMay = gv_DS_ThietBi.Rows(i).Cells("Mã máy").Value.ToString
            ngay = txtNgayHieuLuc.Text
            Dim dt As New DateTime

            Try
                Dim SQL As String
                SQL = "EXEC UpdateMAY_TD_LOG '" & maMay & "','" & Me.Name & "','" & Commons.Modules.UserName & "',2"
                provider.executeNonQuery(SQL)
                If (ngay.Length < 10) Then

                    Commons.Modules.SQLString = "Update MAY Set MS_HO_SO = '" + txt_MaHS.Text + "', TEN_HO_SO = N'" + txt_TenHoSo.Text + "'  "
                    Commons.Modules.SQLString += " , NGAY_HIEU_LUC_HO_SO = NULL "
                    Commons.Modules.SQLString += " Where MS_MAY like N'" + maMay + "'"
                Else
                    dt = DateTime.ParseExact(ngay, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
                    Commons.Modules.SQLString = "Update MAY Set MS_HO_SO = '" + txt_MaHS.Text + "', TEN_HO_SO = N'" + txt_TenHoSo.Text + "'  "
                    Commons.Modules.SQLString += " , NGAY_HIEU_LUC_HO_SO = '" + dt.ToString("MM/dd/yyyy") + "'  "
                    Commons.Modules.SQLString += " Where MS_MAY like N'" + maMay + "'"
                End If
                provider.executeNonQuery(Commons.Modules.SQLString)


                ShowList_DS_ThietBi(flag)
                gv_DS_ThietBi.Rows(i).Selected = True
                If (flag_Check = 0) Then
                    gv_DS_ThietBi.CurrentCell = gv_DS_ThietBi.Rows(i).Cells("Mã máy")
                Else
                    gv_DS_ThietBi.CurrentCell = gv_DS_ThietBi.Rows(i).Cells("Tên máy")
                End If
                gv_DS_ThietBi.BeginEdit(True)
                Show_Form()
            Catch ex As Exception
                i = MessageBox.Show("Ngày hiệu lực không đúng. Tiếp tục nhập lại", "Thông báo", MessageBoxButtons.YesNo)
                If (i = vbYes) Then
                    txtNgayHieuLuc.Focus()
                    Return False
                Else
                    CapNhatControlGhi()
                    Show_Form()
                End If
            End Try
            ' Cập nhật button, datagrid neu ghi thanh cong           
        Catch ex As Exception
            MessageBox.Show("Cập nhật thất bại", "Cập nhật", MessageBoxButtons.OK)
        End Try
        Return True
    End Function

    Private Sub bt_BoSua_TB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_BoSua_TB.Click
        bt_Sua_ThietBi.Text = "Sửa"
        bt_BoSua_TB.Visible = False
        bt_Them_ThamDinhHieuNang.Enabled = True
        bt_Xoa_ThamDinhHieuNang.Enabled = True
        bt_Them_ThamDinhVanHanh.Enabled = True
        bt_ThemThamDinhLapDat.Enabled = True
        bt_Xoa_ThamDinhLapDat.Enabled = True
        bt_Xoa_ThamDinhVanHanh.Enabled = True
        bt_Thoat.Enabled = True

        txtNgayHieuLuc.ReadOnly = True
        txt_MaHS.ReadOnly = True
        txt_TenHoSo.ReadOnly = True
        cmb_LapDat_LoaiTB.Enabled = True
        cmb_NhomTB.Enabled = True
        cmb_TimKiem.Enabled = True
        ' Groubox
        gr_ChonXem.Enabled = True
        ' GridView
        gv_DS_ThietBi.Enabled = True
        ' Show lại trạng thái cũ 
        Show_Form()
    End Sub
    '------------------------
    ' Thuc hien update cac data tren gridview
    Public Sub Update_ThamDinhLapDat()
        Dim provider As New cls_DataProvider
        Dim ds As New DataSet
        Try
            ds = gv_ThamDinhLapDat.DataSource
            provider.Update_Table(ds)
            MessageBox.Show("Update thành công")
        Catch ex As Exception
            MessageBox.Show("Update ko thành công")
        End Try


    End Sub
    Private Sub bt_Sua_ThamDinhLapDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Update_ThamDinhLapDat()
    End Sub


    ' Button Thêm thẩm định lắp đặt
    Private Sub bt_ThemThamDinhLapDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ThemThamDinhLapDat.Click
        ' Kiểm tra tên         
        ' Nếu đang là Thêm/Sửa : Mo enable gridView, đổi tên nhãn của 2 button
        If (bt_ThemThamDinhLapDat.Text = "Thêm/Sửa") Then '
            ' Xử lý gridView
            gv_ThamDinhLapDat.ReadOnly = False
            gv_DS_ThietBi.Enabled = False
            gr_ChonXem.Enabled = False
            ' Xử lý button
            bt_ThemThamDinhLapDat.Text = "Ghi"
            bt_Xoa_ThamDinhLapDat.Text = "Không ghi"
            bt_Them_ThamDinhHieuNang.Enabled = False
            bt_Them_ThamDinhVanHanh.Enabled = False
            bt_Sua_ThietBi.Enabled = False
            bt_Xoa_ThamDinhHieuNang.Enabled = False
            bt_Xoa_ThamDinhVanHanh.Enabled = False
            gv_ThamDinhLapDat.AllowUserToAddRows = True
            bt_Thoat.Enabled = False
            ' Xử lý group
            ' Nếu đang là ghi :thực hiện ghi
        ElseIf (bt_ThemThamDinhLapDat.Text = "Ghi") Then
            gv_ThamDinhLapDat.AllowUserToAddRows = False
            Them_ThamDinhLapDat()
            bt_Thoat.Enabled = True

        End If
    End Sub
    Public Sub VisibleThemThapDinhLapDat()
        bt_Xoa_ThamDinhLapDat.Text = "Xóa"
        bt_ThemThamDinhLapDat.Text = "Thêm/Sửa"

        bt_Sua_ThietBi.Enabled = True
        bt_Them_ThamDinhHieuNang.Enabled = True
        bt_Them_ThamDinhVanHanh.Enabled = True
        bt_Xoa_ThamDinhHieuNang.Enabled = True
        bt_Xoa_ThamDinhVanHanh.Enabled = True
        bt_Thoat.Enabled = False
        ' Enable các gridview
        gv_ThamDinhLapDat.ReadOnly = True
        gv_DS_ThietBi.Enabled = True
        gr_ChonXem.Enabled = True
        gv_ThamDinhLapDat.AllowUserToAddRows = False
    End Sub
    ' Thêm thẩm định lắp đặt
    Public Sub Them_ThamDinhLapDat()
        Dim rowCount As Integer
        rowCount = gv_ThamDinhLapDat.Rows.Count
        Dim vt, maMay As String
        Dim ngay As String
        Dim ngayThamDinh As New DateTime
        Dim nguoiThamDinh, ghiChu As String
        Dim provider As New cls_DataProvider
        Dim ICollection As New Collection

        Try
            vt = gv_ThamDinhLapDat.CurrentRow.Index
            maMay = gv_DS_ThietBi.Rows(gv_DS_ThietBi.CurrentRow.Index).Cells("Mã máy").Value.ToString
            Try
                For i As Integer = 0 To rowCount - 1
                    ngay = gv_ThamDinhLapDat.Rows(i).Cells(1).Value.ToString.Substring(0, 10)
                    ngayThamDinh = DateTime.ParseExact(ngay, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
                    'ngayThamDinh = gv_ThamDinhLapDat.Rows(i).Cells(1).Value.ToString
                    nguoiThamDinh = gv_ThamDinhLapDat.Rows(i).Cells(2).Value.ToString
                    ghiChu = gv_ThamDinhLapDat.Rows(i).Cells(3).Value.ToString
                    Dim sql As String
                    sql = "Insert into MAY_THAM_DINH_LAP_DAT(MS_MAY,NGAY_THAM_DINH_LAP_DAT,NGUOI_THAM_DINH_LAP_DAT,GHI_CHU ) "
                    sql += " VALUES(N'" + maMay + "','" + ngayThamDinh.ToString("MM/dd/yyyy") + "',N'" + nguoiThamDinh + "',N'" + ghiChu + "')"
                    ICollection.Add(sql)
                    sql = "exec UPDATE_MAY_THAM_DINH_LAP_DAT_LOG '" & maMay & "','" & ngayThamDinh.ToString("MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                    ICollection.Add(sql)
                Next
                ' Thuc hien cap nhat
                Dim sql_Delete As String
                Dim vtb As New DataTable
                sql_Delete = "select MS_MAY,NGAY_THAM_DINH_LAP_DAT from  MAY_THAM_DINH_LAP_DAT Where MS_MAY like N'" + maMay + "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_Delete))
                For Each vr As DataRow In vtb.Rows
                    sql_Delete = "exec UPDATE_MAY_THAM_DINH_LAP_DAT_LOG '" & maMay & "','" & Format(CDate(vr("NGAY_THAM_DINH_LAP_DAT").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    provider.executeNonQuery(sql_Delete)
                Next
                sql_Delete = "Delete MAY_THAM_DINH_LAP_DAT Where MS_MAY like N'" + maMay + "'"
                If (provider.Update(ICollection, sql_Delete) = True) Then
                    ' Đổi tên lại nhãn    
                    VisibleThemThapDinhLapDat()
                Else
                    gv_ThamDinhLapDat.AllowUserToAddRows = True
                End If
                gv_ThamDinhLapDat.Rows(vt).Selected = True
                gv_ThamDinhLapDat.CurrentCell = gv_ThamDinhLapDat.Rows(vt).Cells("Ngày thẩm định")
                gv_ThamDinhLapDat.BeginEdit(True)
                '             
            Catch ex As Exception
                ' Chua nhap ngay
                MessageBox.Show("Chưa nhập ngày thẩm định. Vui lòng nhập lại", "Thêm/Sửa Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Catch ex As Exception
            MessageBox.Show("Chưa chọn dữ liệu để thêm", "Lỗi thêm/sửa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub VisibleXoaThamDinhLapDat(ByVal chon As Boolean)
        'Button
        ' tra lai trang thai cu
        'tableThamDinhLapDat.RejectChanges()
        gv_ThamDinhLapDat.RefreshEdit()
        'gv_ThamDinhLapDat.Columns(1).DefaultCellStyle.Format = Nothing
        gv_ThamDinhLapDat.AllowUserToAddRows = False
        bt_Xoa_ThamDinhLapDat.Text = "Xóa"
        bt_ThemThamDinhLapDat.Text = "Thêm/Sửa"

        bt_Sua_ThietBi.Enabled = True
        bt_Them_ThamDinhHieuNang.Enabled = True
        bt_Them_ThamDinhVanHanh.Enabled = True
        bt_Xoa_ThamDinhHieuNang.Enabled = True
        bt_Thoat.Enabled = True
        bt_Xoa_ThamDinhVanHanh.Enabled = True
        ' Gridview
        gv_ThamDinhLapDat.ReadOnly = True
        gv_DS_ThietBi.Enabled = True
        ' Groub box
        gr_ChonXem.Enabled = True
    End Sub
    ' Button Xóa thẩm định lắp đặt
    Private Sub bt_Xoa_ThamDinhLapDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Xoa_ThamDinhLapDat.Click
        ' Kiểm tra tên nhãn.
        ' Nếu tên nhãn đang là không ghi
        If (bt_Xoa_ThamDinhLapDat.Text = "Không ghi") Then
            VisibleXoaThamDinhLapDat(True)
            Dim maMay As String = gv_DS_ThietBi.Rows(rowSelect).Cells("Mã máy").Value.ToString
            Show_gv_ThamDinhLapDat(maMay)
            'gv_ThamDinhLapDat.Re()
        Else ' nếu đang chọn xóa: Chuyển thành hủy xóa, đổi button thêm thành thực hiện
            If (bt_Xoa_ThamDinhLapDat.Text = "Xóa") Then
                'Buttong
                Dim row As Integer = gv_ThamDinhLapDat.Rows.Count
                If (row <= 0) Then
                    MessageBox.Show("Không có dữ liệu để xóa")
                Else
                    Dim vt As Integer
                    Try
                        vt = gv_ThamDinhLapDat.CurrentRow.Index
                        Dim i As Integer
                        i = MessageBox.Show("Bạn có chắc muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If (i = vbYes) Then
                            Xoa_ThamDinhLapDat()
                        Else
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK)
                    End Try
                End If
            End If

        End If

    End Sub
    ' Xóa thẩm định lắp đặt
    Public Sub Xoa_ThamDinhLapDat()
        Dim provider As New cls_DataProvider
        Dim i As Integer
        Try
            i = gv_ThamDinhLapDat.CurrentRow.Index
            If (i >= 0 And i < gv_ThamDinhLapDat.Rows.Count) Then
                Dim maMay As String
                maMay = gv_ThamDinhLapDat.Rows(i).Cells("Mã máy").Value.ToString
                Dim ngay As String
                Dim ngayThamDinh As DateTime
                ngayThamDinh = gv_ThamDinhLapDat.Rows(i).Cells("Ngày thẩm định").Value
                ngay = ngayThamDinh.Year.ToString + "/" + ngayThamDinh.Month.ToString + "/" + ngayThamDinh.Day.ToString

                commons.Modules.SQLString = "Delete MAY_THAM_DINH_LAP_DAT Where MS_MAY like N'" + maMay + "' and NGAY_THAM_DINH_LAP_DAT = '" + ngay + "'"
                Try
                    provider.executeNonQuery(commons.Modules.SQLString)
                    gv_ThamDinhLapDat.Refresh()
                    gv_ThamDinhLapDat.Rows.RemoveAt(i)
                    gv_ThamDinhLapDat.Rows(i - 1).Selected = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Chưa chọn dữ liệu để xóa", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub VisibleThemThamDinhVH()
        gv_ThamDinhVanHanh.ReadOnly = False
        gv_DS_ThietBi.Enabled = False
        ' Button
        bt_Them_ThamDinhVanHanh.Text = "Ghi"
        bt_Xoa_ThamDinhVanHanh.Text = "Không ghi"

        bt_Sua_ThietBi.Enabled = False
        bt_Them_ThamDinhHieuNang.Enabled = False
        bt_ThemThamDinhLapDat.Enabled = False
        bt_Xoa_ThamDinhHieuNang.Enabled = False
        bt_Xoa_ThamDinhLapDat.Enabled = False
        bt_Thoat.Enabled = False
        bt_Thoat.Enabled = False
        gv_ThamDinhVanHanh.AllowUserToAddRows = True
        ' Groub box
        gr_ChonXem.Enabled = False
    End Sub
    ' Thêm sửa thẩm định vận hành
    Private Sub bt_Them_ThamDinhVanHanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Them_ThamDinhVanHanh.Click
        ' Kiểm tra tên         
        ' Nếu đang là Thêm/Sửa : Mo enable gridView, đổi tên nhãn của 2 button
        If (bt_Them_ThamDinhVanHanh.Text = "Thêm/Sửa") Then '
            ' GridView
            VisibleThemThamDinhVH()
            ' Nếu đang là ghi :thực hiện ghi
        ElseIf (bt_Them_ThamDinhVanHanh.Text = "Ghi") Then
            gv_ThamDinhVanHanh.AllowUserToAddRows = False
            Them_ThamDinhVanHanh()
            bt_Thoat.Enabled = True

        End If
    End Sub
    Public Sub VisibleXoaThamDinhVH()
        bt_Them_ThamDinhVanHanh.Text = "Thêm/Sửa"
        bt_Xoa_ThamDinhVanHanh.Text = "Xóa"
        bt_Sua_ThietBi.Enabled = True
        bt_Them_ThamDinhHieuNang.Enabled = True
        bt_ThemThamDinhLapDat.Enabled = True
        bt_Xoa_ThamDinhHieuNang.Enabled = True
        bt_Xoa_ThamDinhLapDat.Enabled = True
        ' Groub box
        gr_ChonXem.Enabled = True
        ' Enable các gridview
        gv_ThamDinhVanHanh.ReadOnly = True
        gv_DS_ThietBi.Enabled = True
        gv_ThamDinhVanHanh.AllowUserToAddRows = False
    End Sub
    Public Sub Them_ThamDinhVanHanh()
        Dim rowCount As Integer
        Dim ngay_ThamDinhVH As New DateTime
        Dim nguoi_ThamDinhVH, ghiChu As String
        Dim ICollection As New Collection
        Dim vt As Integer
        Dim provider As New cls_DataProvider
        rowCount = gv_ThamDinhVanHanh.Rows.Count
        Try
            vt = gv_ThamDinhVanHanh.CurrentRow.Index

            Dim maMay As String

            ' Lấy mã máy
            maMay = gv_DS_ThietBi.Rows(gv_DS_ThietBi.CurrentRow.Index).Cells("Mã máy").Value.ToString
            Try
                For i As Integer = 0 To rowCount - 1
                    Dim ngay As String
                    ngay = gv_ThamDinhVanHanh.Rows(i).Cells(1).Value.ToString.Substring(0, 10)
                    ngay_ThamDinhVH = DateTime.ParseExact(ngay, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
                    nguoi_ThamDinhVH = gv_ThamDinhVanHanh.Rows(i).Cells(2).Value.ToString
                    ghiChu = gv_ThamDinhVanHanh.Rows(i).Cells(3).Value.ToString

                    Dim sql As String
                    sql = "Insert into MAY_THAM_DINH_VAN_HANH(MS_MAY,NGAY_THAM_DINH_VAN_HANH,NGUOI_THAM_DINH_VAN_HANH,GHI_CHU ) "
                    sql += " VALUES(N'" + maMay + "','" + ngay_ThamDinhVH.ToString("MM/dd/yyyy") + "',N'" + nguoi_ThamDinhVH + "',N'" + ghiChu + "')"
                    ICollection.Add(sql)
                    sql = "exec UPDATE_MAY_THAM_DINH_VAN_HANH_LOG '" & maMay & "','" & ngay_ThamDinhVH.ToString("MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                    ICollection.Add(sql)
                Next
                ' THực hiện thêm
                Dim sql_Delete As String
                Dim vtb As New DataTable
                sql_Delete = "select MS_MAY,NGAY_THAM_DINH_VAN_HANH from MAY_THAM_DINH_VAN_HANH Where MS_MAY like N'" + maMay + "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_Delete))
                For Each vr As DataRow In vtb.Rows
                    sql_Delete = "exec UPDATE_MAY_THAM_DINH_VAN_HANH_LOG '" & maMay & "','" & Format(CDate(vr("NGAY_THAM_DINH_VAN_HANH").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    provider.executeNonQuery(sql_Delete)
                Next
                sql_Delete = "Delete MAY_THAM_DINH_VAN_HANH Where MS_MAY like N'" + maMay + "'"
                If (provider.Update(ICollection, sql_Delete) = True) Then
                    ' Đổi tên lại nhãn 
                    VisibleXoaThamDinhVH()

                Else
                    gv_ThamDinhVanHanh.AllowUserToAddRows = True
                End If
                gv_ThamDinhVanHanh.Rows(vt).Selected = True
                gv_ThamDinhVanHanh.CurrentCell = gv_ThamDinhVanHanh.Rows(vt).Cells("Ngày thẩm định")
                gv_ThamDinhVanHanh.BeginEdit(True)

            Catch ex As Exception
                MessageBox.Show("Ngày thẩm định không được để trống", "Lỗi thêm", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Catch ex As Exception
            MessageBox.Show("Không có dữ liệu để thêm/sửa", "Lỗi thêm/sửa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    ' Xóa thẩm định vận hành
    Private Sub bt_Xoa_ThamDinhVanHanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Xoa_ThamDinhVanHanh.Click
        ' Kiểm tra tên nhãn.
        ' Nếu tên nhãn đang là không ghi
        If (bt_Xoa_ThamDinhVanHanh.Text = "Không ghi") Then
            'Button
            gv_ThamDinhVanHanh.AllowUserToAddRows = False
            bt_Xoa_ThamDinhVanHanh.Text = "Xóa"
            bt_Them_ThamDinhVanHanh.Text = "Thêm/Sửa"

            bt_Sua_ThietBi.Enabled = True
            bt_Them_ThamDinhHieuNang.Enabled = True
            bt_ThemThamDinhLapDat.Enabled = True
            bt_Xoa_ThamDinhHieuNang.Enabled = True
            bt_Xoa_ThamDinhLapDat.Enabled = True
            bt_Thoat.Enabled = True
            ' Groub box
            gr_ChonXem.Enabled = True
            ' GridView
            gv_ThamDinhVanHanh.ReadOnly = True
            gv_DS_ThietBi.Enabled = True
            Dim maMay As String = gv_DS_ThietBi.Rows(rowSelect).Cells("Mã máy").Value.ToString
            Show_gv_ThamDinhVanHanh(maMay)
        ElseIf (bt_Xoa_ThamDinhVanHanh.Text = "Xóa") Then
            Dim row As Integer = gv_ThamDinhVanHanh.Rows.Count
            If (row <= 0) Then
                MessageBox.Show("Không có dữ liệu để xóa")
            Else
                Dim vt As Integer
                Try
                    vt = gv_ThamDinhVanHanh.CurrentRow.Index
                    Dim i As Integer
                    i = MessageBox.Show("Bạn có chắc muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    If (i = 1) Then
                        Xoa_ThamDinhVanHanh()
                    Else
                    End If
                Catch ex As Exception
                    MessageBox.Show("Chua chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK)
                End Try
            End If
        End If
    End Sub
    Public Sub Xoa_ThamDinhVanHanh()
        Dim provider As New cls_DataProvider
        Dim i As Integer
        Try
            i = gv_ThamDinhVanHanh.CurrentRow.Index
            If (i >= 0 And i < gv_ThamDinhVanHanh.Rows.Count) Then
                Dim maMay As String
                maMay = gv_ThamDinhVanHanh.Rows(i).Cells("Mã máy").Value.ToString
                Dim ngay As String
                Dim ngayThamDinh As DateTime
                ngayThamDinh = gv_ThamDinhVanHanh.Rows(i).Cells("Ngày thẩm định").Value
                ngay = ngayThamDinh.Year.ToString + "/" + ngayThamDinh.Month.ToString + "/" + ngayThamDinh.Day.ToString

                commons.Modules.SQLString = "Delete MAY_THAM_DINH_VAN_HANH Where MS_MAY like N'" + maMay + "' and NGAY_THAM_DINH_VAN_HANH = '" + ngay + "'"
                Try
                    provider.executeNonQuery(commons.Modules.SQLString)
                    gv_ThamDinhVanHanh.Refresh()
                    gv_ThamDinhVanHanh.Rows.RemoveAt(i)
                    gv_ThamDinhVanHanh.Rows(i - 1).Selected = True
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Chưa chọn dữ liệu để xóa", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    ' Thêm thẩm định hiệu năng
    Private Sub bt_Them_ThamDinhHieuNang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Them_ThamDinhHieuNang.Click
        ' Kiểm tra tên         
        ' Nếu đang là Thêm/Sửa : Mo enable gridView, đổi tên nhãn của 2 button
        If (bt_Them_ThamDinhHieuNang.Text = "Thêm/Sửa") Then '
            ' GridView
            gv_ThamDinhHieuNang.ReadOnly = False
            gv_DS_ThietBi.Enabled = False
            'Button
            bt_Them_ThamDinhHieuNang.Text = "Ghi"
            bt_Xoa_ThamDinhHieuNang.Text = "Không ghi"
            bt_Thoat.Enabled = False
            bt_Sua_ThietBi.Enabled = False
            bt_Them_ThamDinhVanHanh.Enabled = False
            bt_ThemThamDinhLapDat.Enabled = False
            bt_Xoa_ThamDinhLapDat.Enabled = False
            bt_Xoa_ThamDinhVanHanh.Enabled = False
            bt_Thoat.Enabled = False
            gv_ThamDinhHieuNang.AllowUserToAddRows = True
            ' Groubox
            gr_ChonXem.Enabled = False
            ' Nếu đang là ghi :thực hiện ghi
        ElseIf (bt_Them_ThamDinhHieuNang.Text = "Ghi") Then
            gv_ThamDinhHieuNang.AllowUserToAddRows = False
            Them_ThamDinhHieuNang()
            bt_Thoat.Enabled = True
            ' button


        End If
    End Sub
    Public Sub Them_ThamDinhHieuNang()
        Dim rowCount As Integer
        Dim ngay_ThamDinhHieuNang As New DateTime
        Dim nguoi_ThamDinhHieuNang, sp_ThamDinhHieuNang, lo, ghiChu As String
        Dim provider As New cls_DataProvider
        Dim vt As Integer
        Dim ICollection As New Collection
        Dim maMay, ngay As String
        rowCount = gv_ThamDinhHieuNang.Rows.Count
        Try
            vt = gv_ThamDinhHieuNang.CurrentRow.Index
            maMay = gv_DS_ThietBi.Rows(gv_DS_ThietBi.CurrentRow.Index).Cells("Mã máy").Value.ToString
            Try
                For i As Integer = 0 To rowCount - 1
                    ngay = gv_ThamDinhHieuNang.Rows(i).Cells(1).Value.ToString.Substring(0, 10)
                    ngay_ThamDinhHieuNang = DateTime.ParseExact(ngay, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
                    nguoi_ThamDinhHieuNang = gv_ThamDinhHieuNang.Rows(i).Cells(2).Value.ToString
                    sp_ThamDinhHieuNang = gv_ThamDinhHieuNang.Rows(i).Cells(3).Value.ToString
                    lo = gv_ThamDinhHieuNang.Rows(i).Cells(4).Value.ToString
                    ghiChu = gv_ThamDinhHieuNang.Rows(i).Cells(5).Value.ToString
                    Dim sql As String
                    sql = "Insert into MAY_THAM_DINH_HIEU_NANG(MS_MAY,NGAY_THAM_DINH_HIEU_NANG,NGUOI_THAM_DINH_HIEU_NANG, SAN_PHAM_THAM_DINH_HIEU_NANG,LO,GHI_CHU ) "
                    sql += " VALUES(N'" + maMay + "','" + ngay_ThamDinhHieuNang.ToString("MM/dd/yyyy") + "',N'" + nguoi_ThamDinhHieuNang + "', N'" + sp_ThamDinhHieuNang + "', N'" + lo + "',N'" + ghiChu + "')"
                    ICollection.Add(sql)
                    sql = "exec UPDATE_MAY_THAM_DINH_HIEU_NANG_LOG '" & maMay & "','" & ngay_ThamDinhHieuNang.ToString("MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                    ICollection.Add(sql)
                Next
                ' Them du lieu
                Dim sql_Delete As String
                Dim vtb As New DataTable
                sql_Delete = "select  MS_MAY,NGAY_THAM_DINH_HIEU_NANG from MAY_THAM_DINH_HIEU_NANG Where MS_MAY like N'" + maMay + "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_Delete))
                For Each vr As DataRow In vtb.Rows
                    sql_Delete = "exec UPDATE_MAY_THAM_DINH_HIEU_NANG_LOG '" & maMay & "','" & Format(CDate(vr("NGAY_THAM_DINH_HIEU_NANG").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    provider.executeNonQuery(sql_Delete)
                Next

                sql_Delete = "Delete MAY_THAM_DINH_HIEU_NANG Where MS_MAY like N'" + maMay + "'"
                If (provider.Update(ICollection, sql_Delete) = True) Then
                    bt_Them_ThamDinhHieuNang.Text = "Thêm/Sửa"
                    bt_Xoa_ThamDinhHieuNang.Text = "Xóa"

                    bt_Sua_ThietBi.Enabled = True
                    bt_Them_ThamDinhVanHanh.Enabled = True
                    bt_ThemThamDinhLapDat.Enabled = True
                    bt_Xoa_ThamDinhLapDat.Enabled = True
                    bt_Xoa_ThamDinhVanHanh.Enabled = True
                    ' Groubox
                    gr_ChonXem.Enabled = True
                    ' Enable các gridview
                    gv_ThamDinhHieuNang.ReadOnly = True
                    gv_DS_ThietBi.Enabled = True
                    gv_ThamDinhHieuNang.AllowUserToAddRows = False
                Else
                    gv_ThamDinhHieuNang.AllowUserToAddRows = True
                End If
                gv_ThamDinhHieuNang.Rows(vt).Selected = True
                gv_ThamDinhHieuNang.CurrentCell = gv_ThamDinhHieuNang.Rows(vt).Cells("Ngày thẩm định")
                gv_ThamDinhHieuNang.BeginEdit(True)
            Catch ex As Exception
                MessageBox.Show("Ngày thẩm định không được để trống", "Lỗi thêm/sửa", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("Không có dữ liệu để thêm/sửa", "Lỗi thêm/sửa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Xóa thẩm định hiệu năng
    Public Sub Xoa_ThamDinhHieuNang()
        Dim provider As New cls_DataProvider
        Dim i As Integer
        Try
            i = gv_ThamDinhHieuNang.CurrentRow.Index
            If (i >= 0 And i < gv_ThamDinhHieuNang.Rows.Count) Then
                Dim maMay As String
                maMay = gv_ThamDinhHieuNang.Rows(i).Cells("Mã máy").Value.ToString
                Dim ngay As String
                Dim ngayThamDinh As DateTime
                ngayThamDinh = gv_ThamDinhHieuNang.Rows(i).Cells("Ngày thẩm định").Value
                ngay = ngayThamDinh.Year.ToString + "/" + ngayThamDinh.Month.ToString + "/" + ngayThamDinh.Day.ToString

                commons.Modules.SQLString = "Delete MAY_THAM_DINH_HIEU_NANG Where MS_MAY like N'" + maMay + "' and NGAY_THAM_DINH_HIEU_NANG = '" + ngay + "'"
                Try
                    provider.executeNonQuery(commons.Modules.SQLString)
                    gv_ThamDinhHieuNang.Refresh()
                    gv_ThamDinhHieuNang.Rows.RemoveAt(i)
                    gv_ThamDinhHieuNang.Rows(i - 1).Selected = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Chưa chọn dữ liệu để xóa", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub bt_Xoa_ThamDinhHieuNang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Xoa_ThamDinhHieuNang.Click
        ' Kiểm tra tên nhãn.
        ' Nếu tên nhãn đang là không ghi
        If (bt_Xoa_ThamDinhHieuNang.Text = "Không ghi") Then
            ' Button

            gv_ThamDinhHieuNang.AllowUserToAddRows = False
            bt_Xoa_ThamDinhHieuNang.Text = "Xóa"
            bt_Them_ThamDinhHieuNang.Text = "Thêm/Sửa"

            bt_Sua_ThietBi.Enabled = True
            bt_Them_ThamDinhVanHanh.Enabled = True
            bt_ThemThamDinhLapDat.Enabled = True
            bt_Xoa_ThamDinhLapDat.Enabled = True
            bt_Xoa_ThamDinhVanHanh.Enabled = True
            bt_Thoat.Enabled = True
            ' Groubox
            gr_ChonXem.Enabled = True
            ' GridView
            gv_DS_ThietBi.Enabled = True
            gv_ThamDinhHieuNang.ReadOnly = True
            Dim maMay As String = gv_DS_ThietBi.Rows(rowSelect).Cells("Mã máy").Value.ToString
            Show_gv_ThamDinhHieuNang(maMay)
        ElseIf (bt_Xoa_ThamDinhHieuNang.Text = "Xóa") Then
            Dim row As Integer = gv_ThamDinhHieuNang.Rows.Count
            If (row <= 0) Then
                MessageBox.Show("Không có dữ liệu để xóa")
            Else
                Dim vt As Integer
                Try
                    vt = gv_ThamDinhHieuNang.CurrentRow.Index
                    Dim i As Integer
                    i = MessageBox.Show("Bạn có chắc muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    If (i = 1) Then
                        Xoa_ThamDinhHieuNang()
                    Else
                    End If
                Catch ex As Exception
                    MessageBox.Show("Chua chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK)
                End Try
            End If
        End If

    End Sub

    '-----------------------------------------
    Private Sub cmb_TimKiem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_TimKiem.SelectedIndexChanged
        ' Kiem tra check theo ten

        If (ch_TheoTen.Checked = False) Then
            ' Tim theo ma
            commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
            commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
            commons.Modules.SQLString += " From May m Where m.MS_MAY like N'%" + cmb_TimKiem.Text + "%'"
        Else
            ' Tim theo ten
            commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
            commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
            commons.Modules.SQLString += " From May m Where m.TEN_MAY like N'%" + cmb_TimKiem.Text + "%'"
        End If
        LoadList_DS_ThietBi(commons.Modules.SQLString)
        Show_Form()
    End Sub
    ' Hiển thị giá trị formload cho tất cả các control
    Public Sub Show_Form()
        Dim i As Integer
        Dim maMay As String
        Try
            i = gv_DS_ThietBi.CurrentRow.Index
            rowSelect = i
            If (i >= 0 And i < gv_DS_ThietBi.Rows.Count) Then
                maMay = gv_DS_ThietBi.Rows(i).Cells("Mã máy").Value.ToString
                txt_MaHS.Text = gv_DS_ThietBi.Rows(i).Cells("MS_HO_SO").Value.ToString
                txt_TenHoSo.Text = gv_DS_ThietBi.Rows(i).Cells("TEN_HO_SO").Value.ToString
                Dim s As String = gv_DS_ThietBi.Rows(i).Cells("NGAY_HIEU_LUC_HO_SO").Value.ToString
                txtNgayHieuLuc.Text = gv_DS_ThietBi.Rows(i).Cells("NGAY_HIEU_LUC_HO_SO").Value.ToString
                lab_KQ_TenTB.Text = gv_DS_ThietBi.Rows(i).Cells("Tên máy").Value.ToString
                lab_KQ_NhomTB.Text = Get_TenNhomMay(maMay)
                ' lay Noi lap dat - Ten_N_Xuong
                lab_KQ_NoiLapDat.Text = Get_TenNhaXuong(maMay)
                ' show len gv
                lab_KQ_ViTri.Text = Get_ViTriLapDat(maMay)
                Show_gv_ThamDinhLapDat(maMay)
                Show_gv_ThamDinhHieuNang(maMay)
                Show_gv_ThamDinhVanHanh(maMay)
                'End If
            End If

        Catch ex As Exception

            Show_gv_ThamDinhLapDat(Nothing)
            Show_gv_ThamDinhHieuNang(Nothing)
            Show_gv_ThamDinhVanHanh(Nothing)

        End Try

    End Sub

    Private Sub bt_Thoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Thoat.Click
        Me.Close()
    End Sub

    ' Bắt lỗi ngày nhập trên lưới
    Private Sub gv_ThamDinhLapDat_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_ThamDinhLapDat.CellValidating
        Dim i As Integer = gv_ThamDinhLapDat.CurrentRow.Index

        Dim col As Integer = e.ColumnIndex
        Dim chuoi As String = ""
        If (col = 1) Then
            Try
                chuoi = e.FormattedValue.ToString
                Dim ss() As String
                ss = chuoi.Split("/")
                If (ss.Length = 3) Then
                    chuoi = ""
                    For Each s As String In ss
                        If (s.Length = 1) Then
                            chuoi += "0" + s + "/"
                        Else
                            chuoi += s + "/"
                        End If
                    Next
                    chuoi = chuoi.Substring(0, 10)
                Else
                    chuoi = chuoi.Substring(0, 2).ToString + "/" + chuoi.Substring(2, 2).ToString + "/" + chuoi.Substring(4, 4).ToString
                End If
                gv_ThamDinhLapDat.RefreshEdit()
                gv_ThamDinhLapDat.Columns(1).DefaultCellStyle.Format = ""
                Dim ngay As DateTime = Convert.ToDateTime(chuoi.ToString).ToShortDateString
                If (ngay > DateTime.Now) Then
                    MessageBox.Show("Ngày thẩm định không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.YesNo)
                Else
                    gv_ThamDinhLapDat.Rows(i).Cells(1).Value = ngay
                    gv_ThamDinhLapDat.AllowUserToAddRows = True
                End If
            Catch ex As Exception
                If (chuoi.Length > 0) Then
                    gv_ThamDinhLapDat.RefreshEdit()
                    MessageBox.Show("Nhập ngày thẩm định chưa đúng", "Lỗi nhập ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                Else
                End If

            End Try
        End If

    End Sub

    Private Sub gv_ThamDinhVanHanh_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_ThamDinhVanHanh.CellValidating
        Dim i As Integer = gv_ThamDinhVanHanh.CurrentRow.Index
        Dim col As Integer = e.ColumnIndex
        Dim chuoi As String = ""
        If (col = 1) Then
            Try
                chuoi = e.FormattedValue.ToString
                Dim ss() As String
                ss = chuoi.Split("/")
                If (ss.Length = 3) Then
                    chuoi = ""
                    For Each s As String In ss
                        If (s.Length = 1) Then
                            chuoi += "0" + s + "/"
                        Else
                            chuoi += s + "/"
                        End If
                    Next
                    chuoi = chuoi.Substring(0, 10)
                Else
                    chuoi = chuoi.Substring(0, 2).ToString + "/" + chuoi.Substring(2, 2).ToString + "/" + chuoi.Substring(4, 4).ToString
                End If
                Dim ngay As DateTime
                ngay = Convert.ToDateTime(chuoi.ToString).ToShortDateString
                gv_ThamDinhVanHanh.RefreshEdit()
                gv_ThamDinhVanHanh.Columns(1).DefaultCellStyle.Format = ""
                If (ngay > DateTime.Now) Then
                    MessageBox.Show("Ngày thẩm định không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.YesNo)
                Else
                    gv_ThamDinhVanHanh.Rows(i).Cells(1).Value = ngay
                    gv_ThamDinhVanHanh.AllowUserToAddRows = True
                End If

            Catch ex As Exception
                If (chuoi.Length > 0) Then
                    MessageBox.Show("Nhập ngày thẩm định chưa đúng", "Lỗi nhập ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                Else
                End If

            End Try
        End If
    End Sub

    Public Function KiemTraNgay(ByVal vt As Integer) As Integer

    End Function

    Private Sub gv_ThamDinhHieuNang_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_ThamDinhHieuNang.CellValidating
        Dim i As Integer = gv_ThamDinhHieuNang.CurrentRow.Index
        Dim col As Integer = e.ColumnIndex
        Dim chuoi As String = ""
        If (col = 1) Then
            Try
                chuoi = e.FormattedValue.ToString
                Dim ss() As String
                ss = chuoi.Split("/")
                If (ss.Length = 3) Then
                    chuoi = ""
                    For Each s As String In ss

                        If (s.Length = 1) Then
                            chuoi += "0" + s + "/"
                        Else
                            chuoi += s + "/"
                        End If
                    Next
                    chuoi = chuoi.Substring(0, 10)
                Else
                    chuoi = chuoi.Substring(0, 2).ToString + "/" + chuoi.Substring(2, 2).ToString + "/" + chuoi.Substring(4, 4).ToString
                End If
                gv_ThamDinhHieuNang.RefreshEdit()
                gv_ThamDinhHieuNang.Columns(1).DefaultCellStyle.Format = ""
                Dim ngay As DateTime = Convert.ToDateTime(chuoi.ToString).ToShortDateString
                If (ngay > Date.Now) Then
                    MessageBox.Show("Ngày thẩm định không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.YesNo)
                Else
                    gv_ThamDinhHieuNang.Rows(i).Cells(1).Value = ngay
                    gv_ThamDinhHieuNang.AllowUserToAddRows = True
                End If

            Catch ex As Exception
                If (chuoi.Length > 0) Then
                    MessageBox.Show("Nhập ngày thẩm định chưa đúng", "Lỗi nhập ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                Else
                End If

            End Try
        End If
    End Sub



    Private Sub ch_TheoTen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_TheoTen.CheckedChanged

        ' kiem tra dang check theo loai nao theo flag
        ' Lay vị tri dang chec theo ma/ten
        ' chuyen doi
        ' -------------------------------------
        'flag = 3
        'rad_All.Checked = True
        Dim i As Integer
        Try
            i = gv_DS_ThietBi.CurrentRow.Index
            rowSelect = i
        Catch ex As Exception
        End Try
        frm_Main_Load(sender, e)
        Try
            rowSelect = i
            If (ch_TheoTen.Checked = False) Then
                gv_DS_ThietBi.Rows(i).Selected = True
                gv_DS_ThietBi.CurrentCell = gv_DS_ThietBi.Rows(i).Cells("Mã máy")
            Else
                gv_DS_ThietBi.Rows(i).Selected = True
                gv_DS_ThietBi.CurrentCell = gv_DS_ThietBi.Rows(i).Cells("Tên máy")
            End If
            gv_DS_ThietBi.BeginEdit(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_TimKiem_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_TimKiem.KeyUp
        ' Nếu người dùng gõ enter
        ' Load lại list theo giá trị combo

        If (e.KeyData = Keys.Enter) Then

            If (ch_TheoTen.Checked = False) Then
                ' tim theo ma
                commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
                commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
                commons.Modules.SQLString += " From May m Where m.MS_MAY like N'%" + cmb_TimKiem.Text + "%'"
            Else
                commons.Modules.SQLString = "Select  m.MS_MAY as 'Mã máy', m.MS_NHOM_MAY, "
                commons.Modules.SQLString += " m.MS_HO_SO, m.TEN_HO_SO, m.NGAY_HIEU_LUC_HO_SO, m.Ten_MAY as 'Tên máy'"
                commons.Modules.SQLString += " From May m Where m.TEN_MAY like N'%" + cmb_TimKiem.Text + "%'"
            End If
            LoadList_DS_ThietBi(commons.Modules.SQLString)
            Show_Form()
            strTimKiem = ""
        Else
        End If
    End Sub

    Private Sub cmb_TimKiem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_TimKiem.KeyDown
        If (ch_TheoTen.Checked = False) Then
            If ((e.KeyData >= Keys.A And e.KeyData <= Keys.Z)) Then
                cmb_TimKiem.Text = ""
                strTimKiem += e.KeyData.ToString
                cmb_TimKiem.Text = strTimKiem
                cmb_TimKiem.SelectionStart = cmb_TimKiem.Text.Length
                e.SuppressKeyPress = True
            Else
                If (e.KeyData >= Keys.D0 And e.KeyData <= Keys.D9) Then
                    cmb_TimKiem.Text = ""
                    strTimKiem += e.KeyData.ToString.Substring(1, 1)
                    cmb_TimKiem.Text = strTimKiem
                    cmb_TimKiem.SelectionStart = cmb_TimKiem.Text.Length
                    e.SuppressKeyPress = True
                End If
                If (e.KeyData = Keys.Back) Then
                    cmb_TimKiem.Text = ""
                    Try
                        strTimKiem = strTimKiem.Substring(0, strTimKiem.Length - 1)
                        cmb_TimKiem.Text = strTimKiem
                        cmb_TimKiem.SelectionStart = cmb_TimKiem.Text.Length
                        e.SuppressKeyPress = True
                    Catch ex As Exception

                    End Try

                End If

            End If
        End If

    End Sub

    Private Sub gv_ThamDinhHieuNang_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gv_ThamDinhHieuNang.RowValidating
        Dim i As Integer = e.RowIndex
        If (gv_ThamDinhHieuNang.ReadOnly = False) Then
            Try
                Dim j As Integer = 0
                Dim n As Integer = gv_ThamDinhHieuNang.ColumnCount
                For j = 1 To n
                    If (Not gv_ThamDinhHieuNang.Rows(i).Cells(j).Value.ToString = Nothing) Then
                        Exit For
                    End If
                Next
                If (gv_ThamDinhHieuNang.Rows(i).Cells(1).Value.ToString = Nothing And j < n) Then
                    MessageBox.Show("Chưa nhập ngày thẩm định", "Thông báo", MessageBoxButtons.OK)
                    gv_ThamDinhHieuNang.AllowUserToAddRows = False
                Else
                    gv_ThamDinhHieuNang.AllowUserToAddRows = True
                End If
            Catch ex As Exception

            End Try
        Else
            gv_ThamDinhHieuNang.AllowUserToAddRows = False
        End If
    End Sub


    Private Sub gv_ThamDinhLapDat_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gv_ThamDinhLapDat.RowValidating
        Dim i As Integer = e.RowIndex
        If (gv_ThamDinhLapDat.ReadOnly = False) Then
            Try
                Dim j As Integer = 0
                Dim n As Integer = gv_ThamDinhLapDat.ColumnCount
                For j = 1 To n
                    If (Not gv_ThamDinhLapDat.Rows(i).Cells(j).Value.ToString = Nothing) Then
                        Exit For
                    End If
                Next
                If (gv_ThamDinhLapDat.Rows(i).Cells(1).Value.ToString = Nothing And j < n) Then
                    MessageBox.Show("Chưa nhập ngày thẩm định", "Thông báo", MessageBoxButtons.OK)
                    gv_ThamDinhLapDat.AllowUserToAddRows = False
                Else
                    gv_ThamDinhLapDat.AllowUserToAddRows = True
                End If
            Catch ex As Exception

            End Try
        Else
            gv_ThamDinhLapDat.AllowUserToAddRows = False
        End If

    End Sub

    Private Sub gv_ThamDinhVanHanh_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gv_ThamDinhVanHanh.RowValidating
        Dim i As Integer = e.RowIndex
        If (gv_ThamDinhVanHanh.ReadOnly = False) Then
            Try
                Dim j As Integer = 0
                Dim n As Integer = gv_ThamDinhVanHanh.ColumnCount
                For j = 1 To n
                    If (Not gv_ThamDinhVanHanh.Rows(i).Cells(j).Value.ToString = Nothing) Then
                        Exit For
                    End If
                Next
                If (gv_ThamDinhVanHanh.Rows(i).Cells(1).Value.ToString = Nothing And j < n) Then
                    MessageBox.Show("Chưa nhập ngày thẩm định", "Thông báo", MessageBoxButtons.OK)
                    gv_ThamDinhVanHanh.AllowUserToAddRows = False
                Else
                    gv_ThamDinhVanHanh.AllowUserToAddRows = True
                End If
            Catch ex As Exception
            End Try
        Else
            gv_ThamDinhVanHanh.AllowUserToAddRows = False
        End If

    End Sub
    Private Sub cmb_LapDat_LoaiTB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_LapDat_LoaiTB.KeyDown
        cmb_LapDat_LoaiTB.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub cmb_NhomTB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_NhomTB.KeyDown
        cmb_NhomTB.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        Dim frm As FrmChonThamDinhTB = New FrmChonThamDinhTB()
        frm.ShowDialog(Me)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
