
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Imports DevExpress.XtraEditors

Public Class frmDowntime_BAYER
    Private rowCount As Integer
    Private intRow As Integer

    Private bThem As Boolean = False
    Dim tb As New DataTable()
    Private cbochonmay As System.Windows.Forms.ComboBox
    Private cbohethong As New System.Windows.Forms.ComboBox
    Private hang As Integer
    Private hethong As Integer
    Private txtKeypress As TextBox

    Private Sub frmDowntime_BAYER_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_NGUNG_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_THOI_GIAN_NGUNG_MAY")
    End Sub

    Private Sub frmDowntime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        'dtTungay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 60)
        'dtNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 60)
        dtTungay.Value = DateAdd(DateInterval.Month, -2, CDate(Format(Now(), "short date"))) 'Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 60)
        dtNgay.Value = DateAdd(DateInterval.Month, 0, CDate(Format(Now(), "short date"))) '(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 60)
        If Commons.Modules.PermisString.Equals("Read only") Then
            LoadcboLoaiMay()
            VisibleButton(True)
            VisibleButtonGhi(False)
            VisibleButtonXoa(False)
            Binddata()
            LoadcboThietBi1()
            BindData1()
            EnableControl(False)
        Else
            LoadcboLoaiMay()
            VisibleButton(True)
            VisibleButtonGhi(False)
            VisibleButtonXoa(False)
            Binddata()
            'LoadcboThietBi1()
            LoadcboDiaDiem()
            LoadcbiLoaiMay()
            LoadcboNhomMay()
            LoadcboThietBiLoc()
            BindData1()
            EnableControl(True)
        End If

    End Sub

    Sub LoadcboDiaDiem()
        cboDiaDiem.Value = "MS_N_XUONG"
        cboDiaDiem.Display = "TEN_N_XUONG"
        cboDiaDiem.Param = Commons.Modules.UserName
        cboDiaDiem.StoreName = "PermisionNHA_XUONG"
        cboDiaDiem.BindDataSource()
    End Sub
    Sub LoadcbiLoaiMay()
        cboLoaiTB.DataSource = Nothing
        cboNhomMay.DataSource = Nothing
        cboThietbi.DataSource = Nothing
        If cboDiaDiem.Text = "" Then
            Exit Sub
        Else
            Dim str As String = ""
            str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY  FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY " & _
            " ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN  NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID " & _
            " INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN  NHOM_MAY  " & _
            " ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY  " & _
            " INNER JOIN  THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY  " & _
            " INNER JOIN MAY_NHA_XUONG ON MAY.MS_MAY=MAY_NHA_XUONG.MS_MAY and (MAY_NHA_XUONG.NGAY_NHAP = " & _
            " (SELECT     ISNULL(MAX(D.NGAY_NHAP), 0) FROM  MAY_NHA_XUONG D WHERE     D.MS_MAY = MAY.MS_MAY)) " & _
            " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID " & _
            " WHERE NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem.SelectedValue & "'AND USERS.USERNAME ='" & Commons.Modules.UserName & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
            cboLoaiTB.Display = "TEN_LOAI_MAY"
            cboLoaiTB.Value = "MS_LOAI_MAY"
            cboLoaiTB.StoreName = "QL_SEARCH"
            cboLoaiTB.Param = str
            cboLoaiTB.BindDataSource()
        End If
    End Sub
    Sub LoadcboNhomMay()
        cboNhomMay.DataSource = Nothing
        cboThietbi.DataSource = Nothing
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY,TEN_NHOM_MAY " & _
        " FROM THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON MAY.MS_MAY=THOI_GIAN_NGUNG_MAY.MS_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY " & _
        " and MAY_NHA_XUONG.NGAY_NHAP =(SELECT    MAX(D.NGAY_NHAP)  FROM  MAY_NHA_XUONG D WHERE D.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY) " & _
        " INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
        " INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_MAY.GROUP_ID " & _
        " INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID=NHOM.GROUP_ID " & _
        " INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID  WHERE USERS.USERNAME='" & Commons.Modules.UserName & "'"
        If cboLoaiTB.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue & "'"
        End If
        If cboDiaDiem.SelectedValue <> "-1" Then
            str = str + " and MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        End If

        'If cboLoaiTB.SelectedValue = "-1" Then
        '    str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN " & _
        '    " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '    " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
        '    " NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
        '    " THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID " & _
        '    " WHERE NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem.SelectedValue & "' AND USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        'Else
        '    str = " SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN " & _
        '    " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
        '    " THOI_GIAN_NGUNG_MAY ON MAY.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY WHERE  LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue & "'"
        'End If
        cboNhomMay.Display = "TEN_NHOM_MAY"
        cboNhomMay.Value = "MS_NHOM_MAY"
        cboNhomMay.StoreName = "QL_SEARCH"
        cboNhomMay.Param = str
        cboNhomMay.BindDataSource()
    End Sub
    Sub LoadcboThietBiLoc()
        cboThietbi.DataSource = Nothing
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT  DISTINCT THOI_GIAN_NGUNG_MAY.MS_MAY, THOI_GIAN_NGUNG_MAY.MS_MAY AS TEN_MAY " & _
        " FROM THOI_GIAN_NGUNG_MAY INNER JOIN MAY ON MAY.MS_MAY=THOI_GIAN_NGUNG_MAY.MS_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY " & _
        " and MAY_NHA_XUONG.NGAY_NHAP =(SELECT    MAX(D.NGAY_NHAP)  FROM  MAY_NHA_XUONG D WHERE D.MS_MAY = THOI_GIAN_NGUNG_MAY.MS_MAY) " & _
        " INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
        " INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_MAY.GROUP_ID " & _
        " INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID=NHOM.GROUP_ID " & _
        " INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID  WHERE USERS.USERNAME='" & Commons.Modules.UserName & "'"
        If cboLoaiTB.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue & "'"
        End If
        If cboDiaDiem.SelectedValue <> "-1" Then
            str = str + " and MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        End If
        If cboNhomMay.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
        End If

        cboThietbi.Display = "TEN_MAY"
        cboThietbi.Value = "MS_MAY"
        cboThietbi.StoreName = "QL_SEARCH"
        cboThietbi.Param = str
        cboThietbi.BindDataSource()
    End Sub
    Sub Binddata()
        Try
            grdNhapthoigianngungmay.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            grdNhapthoigianngungmay.DataSource = Nothing
        Catch ex As Exception
        End Try
        Try
            grdNhapthoigianngungmay.Rows.Clear()
        Catch ex As Exception
        End Try
        Dim str As String = ""
        'Dim dt As New DataTable
        'dt = New clsTHOI_GIAN_NHUNG_MAYController().GetTHOI_GIAN_NGUNG_MAYs(Format(dtNgay.Value, "Short date"), Format(dtDenNgay1.Value, "Short date"), Commons.Modules.UserName, cboLoaiMay.SelectedValue)
        tb = New clsTHOI_GIAN_NHUNG_MAYController().GetTHOI_GIAN_NGUNG_MAYs_BAYER(Format(dtNgay.Value, "Short date"), Format(dtDenNgay1.Value, "Short date"), Commons.Modules.UserName, cboLoaiMay.SelectedValue)
        Dim priCol(5) As DataColumn
        priCol(0) = tb.Columns("MS_MAY")
        priCol(1) = tb.Columns("NGAY")
        priCol(2) = tb.Columns("TU_GIO")
        priCol(3) = tb.Columns("DEN_NGAY")
        priCol(4) = tb.Columns("DEN_GIO")
        'priCol(5) = tb.Columns("DEN_NGAY")
        'priCol(6) = tb.Columns("DEN_GIO")

        tb.PrimaryKey = priCol

        grdNhapthoigianngungmay.AutoGenerateColumns = False
        grdNhapthoigianngungmay.DataSource = tb

        LoadcboThietbi()
        Dim col As New Commons.QLGridMaskedTextBoxColumn
        col.Name = "cboTuNgay"
        col.DataPropertyName = "NGAY"
        col.Mask = "00/00/0000"
        col.DefaultCellStyle.Format = Nothing
        grdNhapthoigianngungmay.Columns.Insert(1, col)

        Dim col2 As New Commons.QLGridMaskedTextBoxColumn
        col2.Name = "cboTuGio"
        col2.DataPropertyName = "TU_GIO"
        col2.Mask = "90:00"
        col2.DefaultCellStyle.Format = "HH:mm"
        col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdNhapthoigianngungmay.Columns.Insert(2, col2)

        Dim col11 As New Commons.QLGridMaskedTextBoxColumn
        col11.Name = "cboNgaySua"
        col11.DataPropertyName = "NGAY_SUA"
        col11.Mask = "00/00/0000"
        col11.DefaultCellStyle.Format = Nothing
        grdNhapthoigianngungmay.Columns.Insert(3, col11)

        Dim col12 As New Commons.QLGridMaskedTextBoxColumn
        col12.Name = "cboGioSua"
        col12.DataPropertyName = "GIO_SUA"
        col12.Mask = "90:00"
        col12.DefaultCellStyle.Format = "HH:mm"
        col12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdNhapthoigianngungmay.Columns.Insert(4, col12)

        Dim col1 As New Commons.QLGridMaskedTextBoxColumn
        col1.Name = "cboDenNgay"
        col1.DataPropertyName = "DEN_NGAY"
        col1.Mask = "00/00/0000"
        col1.DefaultCellStyle.Format = Nothing
        grdNhapthoigianngungmay.Columns.Insert(5, col1)

        Dim col3 As New Commons.QLGridMaskedTextBoxColumn
        col3.Name = "cboDenGio"
        col3.DataPropertyName = "DEN_GIO"
        col3.Mask = "90:00"
        col3.DefaultCellStyle.Format = "HH:mm"
        col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdNhapthoigianngungmay.Columns.Insert(6, col3)


        Dim col21 As New DataGridViewTextBoxColumn
        col21.Name = "TEN_N_XUONG"
        col21.DataPropertyName = "TEN_N_XUONG"
        col21.ReadOnly = True
        col21.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdNhapthoigianngungmay.Columns.Insert(7, col21)

        Dim col211 As New DataGridViewTextBoxColumn
        col211.Name = "MS_N_XUONG"
        col211.DataPropertyName = "MS_N_XUONG"
        col211.ReadOnly = True
        col211.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdNhapthoigianngungmay.Columns.Insert(8, col211)


        ComboHeThong_GridNhapThoiGian()
        LoadcboNguyenNhan()
        txtTHOI_GIAN_SUA_CHUA()
        LoadcboNguyenNhanHuHong()

        Dim col22 As New DataGridViewTextBoxColumn
        col22.Name = "GHI_CHU"
        col22.DataPropertyName = "GHI_CHU"
        'col22.ReadOnly = True
        col22.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdNhapthoigianngungmay.Columns.Insert(13, col22)

        LoadcbonNguoiGiaiQuyet()
        'LoadcboPhieuBaoTri()

        Dim col212 As New DataGridViewTextBoxColumn
        col212.Name = "NGUOI_DUNG_MAY"
        col212.DataPropertyName = "NGUOI_GIAI_QUYET"
        col212.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdNhapthoigianngungmay.Columns.Insert(15, col212)



        grdNhapthoigianngungmay.Columns("MS_N_XUONG").Visible = False
        'grdNhapthoigianngungmay.Columns("TEN_N_XUONG").DisplayIndex = 5
        'grdNhapthoigianngungmay.Columns(7).ReadOnly = True
        'grdNhapthoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").Visible = False

        'grdNhapthoigianngungmay.Columns("MS_MAY").Visible = False
        'grdNhapthoigianngungmay.Columns("STT").Visible = False
        'grdNhapthoigianngungmay.Columns("MS_NGUYEN_NHAN").Visible = False
        'grdNhapthoigianngungmay.Columns("MS_PHIEU_BAO_TRI").Visible = False
        'grdNhapthoigianngungmay.Columns("TU_GIO").Visible = False
        'grdNhapthoigianngungmay.Columns("DEN_GIO").Visible = False
        'grdNhapthoigianngungmay.Columns("NGAY_SUA").Visible = False
        'grdNhapthoigianngungmay.Columns("GIO_SUA").Visible = False

        'grdNhapthoigianngungmay.Columns("NGAY").Visible = False
        'grdNhapthoigianngungmay.Columns("DEN_NGAY").Visible = False

        grdNhapthoigianngungmay.Columns("cboThietBi").Width = 250
        grdNhapthoigianngungmay.Columns("TEN_N_XUONG").Width = 160
        grdNhapthoigianngungmay.Columns("cboTuGio").Width = 60
        grdNhapthoigianngungmay.Columns("cboDenGio").Width = 60

        'grdNhapthoigianngungmay.Columns("cboNgaySua").Width = 60
        grdNhapthoigianngungmay.Columns("cboGioSua").Width = 60

        grdNhapthoigianngungmay.Columns("cboNguyenNhan").Width = 150
        grdNhapthoigianngungmay.Columns("cboNguyenNhanHuHong").Width = 170
        grdNhapthoigianngungmay.Columns("cboHE_THONG").Width = 150
        'grdNhapthoigianngungmay.Columns("cboHE_THONG").Visible = True
        'grdNhapthoigianngungmay.Columns("cboPhieuBaoTri").Width = 130
        grdNhapthoigianngungmay.Columns("GHI_CHU").Width = 266
        grdNhapthoigianngungmay.Columns("NGUOI_DUNG_MAY").Width = 200
        'grdNhapthoigianngungmay.Columns("NGUOI_GIAI_QUYET").Visible = False
        'grdNhapthoigianngungmay.Columns("MS_CONG_NHAN").Visible = False
        'grdNhapthoigianngungmay.Columns("TEN_CONG_NHAN").Visible = False

        'grdNhapthoigianngungmay.Columns("MS_HE_THONG").Visible = False
        grdNhapthoigianngungmay.Columns("txtTHOI_GIAN_SUA_CHUA").Width = 100
        grdNhapthoigianngungmay.Columns("txtTHOI_GIAN_SUA_CHUA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grdNhapthoigianngungmay.Columns("DUNG").Visible = False

        'rowCount = tb.Rows.Count - 1
        'Try
        '    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(0).Cells("cboThietBi")
        '    grdNhapthoigianngungmay.Focus()
        'Catch ex As Exception

        'End Try
        Try
            Me.grdNhapthoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdNhapthoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        RefeshLanguage()
    End Sub

    Sub RefeshLanguage()
        Me.grdNhapthoigianngungmay.Columns("cboTuNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboDenNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboThietBi").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboTuGio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboDenGio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboTuNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboDenNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)

        Me.grdNhapthoigianngungmay.Columns("cboNgaySua").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_SUA", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboGioSua").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_SUA", Commons.Modules.TypeLanguage)


        Me.grdNhapthoigianngungmay.Columns("cboNguyenNhan").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboNguyenNhanHuHong").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN_HU_HONG", Commons.Modules.TypeLanguage)
        ' Me.grdNhapthoigianngungmay.Columns("cboPhieuBaoTri").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", commons.Modules.TypeLanguage)
        'Me.grdNhapthoigianngungmay.Columns("cboPhieuBaoTri").Visible = False
        Me.grdNhapthoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboNguoiGiaiQuyet").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        'Me.grdNhapthoigianngungmay.Columns("DUNG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DUNG", commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboHE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboHE_THONG", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("txtTHOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("TEN_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_N_XUONG", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("txtTHOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "txtTHOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("cboNguoiGiaiQuyet").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        Me.grdNhapthoigianngungmay.Columns("NGUOI_DUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_DUNG_MAY", Commons.Modules.TypeLanguage)

    End Sub
    Sub RefeshLanguage1()

        Me.grdDanhsachthoigianngungmay.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("DEN_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("TEN_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("TEN_NGUYEN_NHAN_HU_HONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN_HU_HONG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("cboHE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboHE_THONG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("TEN_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboHE_THONG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("TEN_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_N_XUONG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("MS_PHIEU_BAO_TRI").Visible = False
        Me.grdDanhsachthoigianngungmay.Columns("TEN_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("NGAY_SUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_SUA", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("GIO_SUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_SUA", Commons.Modules.TypeLanguage)
        Me.grdDanhsachthoigianngungmay.Columns("NGUOI_DUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_DUNG_MAY", Commons.Modules.TypeLanguage)


    End Sub
    Sub BindData1()
        'Dim objThoigianNgungMayController As New clsTHOI_GIAN_NHUNG_MAYController()
        'grdDanhsachthoigianngungmay.DataSource = objThoigianNgungMayController.GetTHOI_GIAN_NGUNG_MAY(Commons.Modules.UserName, cboThietbi.SelectedValue, Format(dtTungay.Value, "Short date"), Format(dtDengnay.Value, "Short date"))
        Try
            If grdDanhsachthoigianngungmay.Columns.Count > 0 Then grdDanhsachthoigianngungmay.Columns.Clear()
        Catch
        End Try

        Dim str As String = ""
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If

        'str = "SELECT dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO," & _
        '              "dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO, dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG," & _
        '              "dbo.HE_THONG.TEN_HE_THONG,dbo.NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA," & _
        '              "dbo.THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
        '      "FROM   dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
        '              "dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
        '              "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '              "dbo.MAY_NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_MAY = dbo.MAY.MS_MAY AND dbo.MAY_NHA_XUONG.NGAY_NHAP = " & _
        '                    "(SELECT MAX(NGAY_NHAP) AS Expr1 " & _
        '                    "FROM dbo.MAY_NHA_XUONG AS D " & _
        '                    "WHERE (MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY)) INNER JOIN " & _
        '              "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '              "dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '              "dbo.NHOM ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " & _
        '              "dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        '              "dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID INNER JOIN " & _
        '              "dbo.NGUYEN_NHAN_DUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN LEFT OUTER JOIN " & _
        '              "dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " & _
        '    " WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
        '        " AND NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDengnay.Value, "Short date") & "',103)" & _
        '        " AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"


        'str = "SELECT  dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, " & _
        '              "dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO, dbo.MAY_NHA_XUONG.MS_N_XUONG, dbo.NHA_XUONG.Ten_N_XUONG, dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG, " & _
        '              "dbo.HE_THONG.TEN_HE_THONG, dbo.NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA, " & _
        '              "dbo.THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU " & _
        '      "FROM    dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
        '              "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '              "dbo.MAY_NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_MAY = dbo.MAY.MS_MAY AND dbo.MAY_NHA_XUONG.NGAY_NHAP = " & _
        '                  "(SELECT     MAX(NGAY_NHAP) FROM dbo.MAY_NHA_XUONG AS D WHERE (MS_MAY = dbo.THOI_GIAN_NGUNG_MAY.MS_MAY)) INNER JOIN " & _
        '              "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '              "dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '              "dbo.NHOM ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " & _
        '              "dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        '              "dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY ON " & _
        '              "dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " & _
        '              "dbo.NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG AND " & _
        '              "dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG AND " & _
        '              "dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG LEFT OUTER JOIN " & _
        '              "dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " & _
        '      "WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
        '              "AND NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDengnay.Value, "Short date") & "',103)" & _
        '              "AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"

        str = "SELECT dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, " & _
                      " dbo.THOI_GIAN_NGUNG_MAY.NGAY_SUA, dbo.THOI_GIAN_NGUNG_MAY.GIO_SUA,dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO, dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG, " & _
                      "dbo.NHA_XUONG.Ten_N_XUONG, dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, " & _
                      "dbo.NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA,NGUYEN_NHAN_HU_HONG.TEN_NGUYEN_NHAN AS TEN_NGUYEN_NHAN_HU_HONG, " & _
                      " dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU,dbo.THOI_GIAN_NGUNG_MAY.MS_PHIEU_BAO_TRI, ( dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN ) AS TEN_CONG_NHAN ,dbo.THOI_GIAN_NGUNG_MAY.NGUOI_GIAI_QUYET as NGUOI_DUNG_MAY " & _
              "FROM   dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                     "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                     "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                     "dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                     "dbo.NHOM ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " & _
                     "dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
                     "dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY ON " & _
                     "dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " & _
                     "dbo.NHA_XUONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG AND " & _
                     "dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN" & _
                     " dbo.NGUYEN_NHAN_HU_HONG ON dbo.THOI_GIAN_NGUNG_MAY.STT = dbo.NGUYEN_NHAN_HU_HONG.STT LEFT OUTER JOIN " & _
                     "dbo.HE_THONG ON dbo.THOI_GIAN_NGUNG_MAY.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG Left JOIN" & _
                     " dbo.CONG_NHAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN " & _
                "WHERE (dbo.USERS.USERNAME = '" & Commons.Modules.UserName & "') AND (dbo.THOI_GIAN_NGUNG_MAY.NGAY BETWEEN  CONVERT(DATETIME,'" & Format(dtTungay.Value, "Short date") & "',103) " & _
                      "AND CONVERT(DATETIME,'" & Format(dtDengnay.Value, "Short date") & "',103)) AND (dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & cboDiaDiem.SelectedValue & "') "

        'str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue.ToString & "'"
        'str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue.ToString & "'"
        'str = str + "AND THOI_GIAN_NGUNG_MAY.MS_MAY=N'" & cboThietbi.SelectedValue.ToString & "'"

        If cboLoaiTB.SelectedIndex <> -1 Then
            If cboLoaiTB.SelectedValue.ToString <> "-1" And cboLoaiTB.Items.Count > 0 Then str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue & "'"
        End If
        If cboNhomMay.SelectedIndex <> -1 Then
            If cboNhomMay.SelectedValue.ToString <> "-1" And cboNhomMay.Items.Count > 0 Then str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomMay.SelectedValue & "'"
        End If
        If cboThietbi.SelectedIndex <> -1 Then
            If cboThietbi.SelectedValue.ToString <> "-1" And cboThietbi.Items.Count > 0 Then str = str + "AND THOI_GIAN_NGUNG_MAY.MS_MAY=N'" & cboThietbi.SelectedValue & "'"
        End If
        str = str + "ORDER BY dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY DESC, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO"
        grdDanhsachthoigianngungmay.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)

        grdDanhsachthoigianngungmay.Columns("NGAY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdDanhsachthoigianngungmay.Columns("NGAY").Width = 80
        grdDanhsachthoigianngungmay.Columns("TU_GIO").DefaultCellStyle.Format = "HH:mm"
        grdDanhsachthoigianngungmay.Columns("TU_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdDanhsachthoigianngungmay.Columns("GIO_SUA").DefaultCellStyle.Format = "HH:mm"
        grdDanhsachthoigianngungmay.Columns("GIO_SUA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        grdDanhsachthoigianngungmay.Columns("DEN_GIO").DefaultCellStyle.Format = "HH:mm"
        grdDanhsachthoigianngungmay.Columns("DEN_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' grdDanhsachthoigianngungmay.Columns("TU_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' grdNhapthoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'HIEU 14/06/08
        ComboHeThong_GridDanhSach()

        grdDanhsachthoigianngungmay.Columns("TU_GIO").Width = 80
        grdDanhsachthoigianngungmay.Columns("MS_MAY").Width = 150
        grdDanhsachthoigianngungmay.Columns("GIO_SUA").Width = 80
        grdDanhsachthoigianngungmay.Columns("DEN_GIO").Width = 80
        grdDanhsachthoigianngungmay.Columns("GHI_CHU").Width = 200
        grdDanhsachthoigianngungmay.Columns("TEN_NGUYEN_NHAN").Width = 150
        grdDanhsachthoigianngungmay.Columns("TEN_NGUYEN_NHAN_HU_HONG").Width = 150
        grdDanhsachthoigianngungmay.Columns("cboHE_THONG").Width = 150
        grdDanhsachthoigianngungmay.Columns("TEN_HE_THONG").Width = 150
        grdDanhsachthoigianngungmay.Columns("TEN_CONG_NHAN").Width = 150
        grdDanhsachthoigianngungmay.Columns("NGUOI_DUNG_MAY").Width = 150

        grdDanhsachthoigianngungmay.Columns("MS_N_XUONG").Visible = False
        grdDanhsachthoigianngungmay.Columns("cboHE_THONG").Visible = False
        grdDanhsachthoigianngungmay.Columns("MS_HE_THONG").Visible = False
        grdDanhsachthoigianngungmay.Columns("MS_PHIEU_BAO_TRI").Visible = False
        grdDanhsachthoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Try
            Me.grdDanhsachthoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachthoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        RefeshLanguage1()
    End Sub
    Sub LoadcboThietbi()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboThietBi"
        comboBoxColumn.ValueMember = "MS_MAY"
        comboBoxColumn.DisplayMember = "MSMAY"
        comboBoxColumn.DataPropertyName = "MS_MAY"
        comboBoxColumn.Width = 250
        If cboLoaiMay.SelectedValue <> "-1" Then
            comboBoxColumn.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetMAY_LOAI_MAY", cboLoaiMay.SelectedValue).Tables(0)
        Else
            comboBoxColumn.DataSource = New MAYController().GetMAY_PQ(Commons.Modules.UserName)
        End If

        grdNhapthoigianngungmay.Columns.Insert(0, comboBoxColumn)
    End Sub
    Sub LoadcbonNguoiGiaiQuyet()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboNguoiGiaiQuyet"
        comboBoxColumn.ValueMember = "MS_CONG_NHAN"
        comboBoxColumn.DisplayMember = "TEN_CONG_NHAN"
        comboBoxColumn.DataPropertyName = "MS_CONG_NHAN"
        comboBoxColumn.Width = 250
        'If cboLoaiMay.SelectedValue <> "-1" Then
        '    comboBoxColumn.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetMAY_LOAI_MAY", cboLoaiMay.SelectedValue).Tables(0)
        'Else
        '    comboBoxColumn.DataSource = New MAYController().GetMAY_PQ(Commons.Modules.UserName)
        'End If

        ' If cboLoaiMay.SelectedValue <> "-1" Then
        Dim vtb As New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT dbo.CONG_NHAN.MS_CONG_NHAN, ( dbo.CONG_NHAN.HO + dbo.CONG_NHAN.TEN ) AS TEN_CONG_NHAN FROM dbo.CONG_NHAN "))
        comboBoxColumn.DataSource = vtb
        'Else
        'comboBoxColumn.DataSource = New MAYController().GetMAY_PQ(Commons.Modules.UserName)
        'End If


        grdNhapthoigianngungmay.Columns.Insert(14, comboBoxColumn)
    End Sub


    Sub LoadcboNguyenNhan()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboNguyenNhan"
        comboBoxColumn.ValueMember = "MS_NGUYEN_NHAN"
        comboBoxColumn.DisplayMember = "TEN_NGUYEN_NHAN"
        comboBoxColumn.DataPropertyName = "MS_NGUYEN_NHAN"
        Dim tb As New DataTable
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY").Tables(0)
        comboBoxColumn.DataSource = tb
        grdNhapthoigianngungmay.Columns.Insert(10, comboBoxColumn)
    End Sub
    Sub LoadcboNguyenNhanHuHong()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboNguyenNhanHuHong"
        comboBoxColumn.ValueMember = "STT"
        comboBoxColumn.DisplayMember = "TEN_NGUYEN_NHAN"
        comboBoxColumn.DataPropertyName = "STT"
        Dim tb As New DataTable
        Dim strs As String = Nothing
        Select Case Commons.Modules.TypeLanguage
            Case 0
                strs = "SELECT STT , TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_HU_HONG"
            Case 1
                strs = "SELECT STT , TEN_NGUYEN_NHAN_ANH AS TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_HU_HONG"
        End Select
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, strs).Tables(0)
        comboBoxColumn.DataSource = tb
        grdNhapthoigianngungmay.Columns.Insert(12, comboBoxColumn)
    End Sub
    Sub LoadcboPhieuBaoTri()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboPhieuBaoTri"
        comboBoxColumn.ValueMember = "MS_PHIEU_BAO_TRI"
        comboBoxColumn.DisplayMember = "MS_PHIEU_BAO_TRI"
        comboBoxColumn.DataPropertyName = "MS_PHIEU_BAO_TRI"
        Dim tb As New DataTable()
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI ").Tables(0)
        Dim dr As DataRow
        dr = tb.NewRow
        dr.Item("MS_PHIEU_BAO_TRI") = System.DBNull.Value
        tb.Rows.InsertAt(dr, 0)
        comboBoxColumn.DataSource = tb
        grdNhapthoigianngungmay.Columns.Insert(11, comboBoxColumn)
    End Sub


    'HIEU THEM 14/06/2008
    Sub ComboHeThong_GridNhapThoiGian()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG  UNION SELECT '0', ''"))
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Name = "cboHE_THONG"
        comboBoxColumn.ValueMember = "MS_HE_THONG"
        comboBoxColumn.DisplayMember = "TEN_HE_THONG"
        comboBoxColumn.DataPropertyName = "MS_HE_THONG"

        comboBoxColumn.DataSource = dt

        grdNhapthoigianngungmay.Columns.Insert(9, comboBoxColumn)

    End Sub

    Sub ComboHeThong_GridDanhSach()

        Dim dt As New DataTable
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboHE_THONG"
        comboBoxColumn.ValueMember = "MS_HE_THONG"
        comboBoxColumn.DisplayMember = "TEN_HE_THONG"
        comboBoxColumn.DataPropertyName = "MS_HE_THONG"

        'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG"))
        dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG  UNION SELECT '0', ''").Tables(0)
        comboBoxColumn.DataSource = dt
        grdDanhsachthoigianngungmay.Columns.Insert(8, comboBoxColumn)

    End Sub

    Sub EnableControl(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
    End Sub
    Sub VisibleButton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnXoa.Visible = chon
        BtnThoat.Visible = chon
    End Sub
    Sub VisibleButtonGhi(ByVal chon As Boolean)
        BtnGhi.Visible = chon
        BtnKhongghi.Visible = chon
        grdNhapthoigianngungmay.ReadOnly = Not chon
        cboLoaiMay.Enabled = Not chon
        dtNgay.Enabled = Not chon
        grdNhapthoigianngungmay.AllowUserToAddRows = chon
    End Sub
    Sub VisibleButtonXoa(ByVal chon As Boolean)
        BtnXoaAll.Visible = chon
        BtnXoaCT.Visible = chon
        BtnTroVe.Visible = chon
    End Sub
    Sub LoadcboLoaiMay()
        cboLoaiMay.StoreName = "GetLOAI_MAY_SEC" ' "GetLOAI_MAYs_PQ"
        cboLoaiMay.Display = "TEN_LOAI_MAY"
        cboLoaiMay.Value = "MS_LOAI_MAY"
        cboLoaiMay.Param = Commons.Modules.UserName
        cboLoaiMay.BindDataSource()
    End Sub
    Sub LoadcboThietBi1()
        cboThietbi.Display = "MSMAY"
        cboThietbi.Value = "MS_MAY"
        cboThietbi.StoreName = "GetMAY_PQ"
        cboThietbi.Param = Commons.Modules.UserName
        cboThietbi.BindDataSource()
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub
    Private Sub dtNgay_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtNgay.CloseUp
        Binddata()
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click

        Dim str As String = ""
        If Date.Parse(dtNgay.Value) > Now() Then
            'XtraMessageBox.Show("ngày lờn hơn ngày hiện tại")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLonHonHienTai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Binddata()
        VisibleButton(False)
        VisibleButtonGhi(True)
        VisibleButtonXoa(False)
        bThem = True
        Try
            str = "DROP TABLE tmpDOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.tmpDOWNTIME" & Commons.Modules.UserName & " (MS_MAY NVARCHAR(30),TU_GIO NVARCHAR(12),DEN_GIO NVARCHAR(12))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        AddHandler grdNhapthoigianngungmay.CellBeginEdit, AddressOf Me.grdNhapthoigianngungmay_CellBeginEdit
        AddHandler grdNhapthoigianngungmay.CellClick, AddressOf Me.grdNhapthoigianngungmay_CellClick
        AddHandler grdNhapthoigianngungmay.CellValidated, AddressOf Me.grdNhapthoigianngungmay_CellValidated
        AddHandler grdNhapthoigianngungmay.CellValidating, AddressOf Me.grdNhapthoigianngungmay_CellValidating
        AddHandler grdNhapthoigianngungmay.DataError, AddressOf Me.grdNhapthoigianngungmay_DataError
        AddHandler grdNhapthoigianngungmay.KeyDown, AddressOf Me.grdNhapthoigianngungmay_KeyDown
        AddHandler grdNhapthoigianngungmay.RowValidating, AddressOf Me.grdNhapthoigianngungmay_RowValidating
        'RemoveHandler cbochonmay.SelectionChangeCommitted, AddressOf cbochonmay_SelectionChangeCommitted
        ' AddHandler cbochonmay.SelectionChangeCommitted, AddressOf cbochonmay_SelectionChangeCommitted

        AddHandler grdNhapthoigianngungmay.EditingControlShowing, AddressOf Me.grdNhapthoigianngungmay_EditingControlShowing
        'AddHandler grdNhapthoigianngungmay.DataSourceChanged, AddressOf Me.grdNhapthoigianngungmay_DataSourceChanged
        'AddHandler grdNhapthoigianngungmay.CellValueChanged, AddressOf Me.grdNhapthoigianngungmay_CellValueChanged

        Try
            grdNhapthoigianngungmay.Rows(0).Cells("cboThietBi").Selected = True
        Catch ex As Exception

        End Try

        grdNhapthoigianngungmay.Focus()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If bThem Then
            TabControl1.SelectedIndex = 0
            Exit Sub
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        RemoveHandler grdNhapthoigianngungmay.CellBeginEdit, AddressOf Me.grdNhapthoigianngungmay_CellBeginEdit
        RemoveHandler grdNhapthoigianngungmay.CellClick, AddressOf Me.grdNhapthoigianngungmay_CellClick
        RemoveHandler grdNhapthoigianngungmay.CellValidated, AddressOf Me.grdNhapthoigianngungmay_CellValidated
        RemoveHandler grdNhapthoigianngungmay.CellValidating, AddressOf Me.grdNhapthoigianngungmay_CellValidating
        RemoveHandler grdNhapthoigianngungmay.DataError, AddressOf Me.grdNhapthoigianngungmay_DataError
        RemoveHandler grdNhapthoigianngungmay.KeyDown, AddressOf Me.grdNhapthoigianngungmay_KeyDown
        RemoveHandler grdNhapthoigianngungmay.RowValidating, AddressOf Me.grdNhapthoigianngungmay_RowValidating
        RemoveHandler grdNhapthoigianngungmay.EditingControlShowing, AddressOf Me.grdNhapthoigianngungmay_EditingControlShowing
        RemoveHandler grdNhapthoigianngungmay.DataSourceChanged, AddressOf Me.grdNhapthoigianngungmay_DataSourceChanged
        RemoveHandler grdNhapthoigianngungmay.CellValueChanged, AddressOf Me.grdNhapthoigianngungmay_CellValueChanged
        bThem = False
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        Binddata()
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpDOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE DOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grdNhapthoigianngungmay_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) 'Handles grdNhapthoigianngungmay.CellBeginEdit
        If grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboPhieuBaoTri" Then
            Dim tb As New DataTable()
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value & "'").Tables(0)
            Dim dr As DataRow
            dr = tb.NewRow
            dr.Item("MS_PHIEU_BAO_TRI") = System.DBNull.Value
            tb.Rows.InsertAt(dr, 0)
            If tb.Rows.Count > 0 Then
                grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = tb.Rows(0).Item(0)
                Dim cell1 As New DataGridViewComboBoxCell()
                cell1.DataSource = tb
                cell1.DisplayMember = "MS_PHIEU_BAO_TRI"
                cell1.ValueMember = "MS_PHIEU_BAO_TRI"
                grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboPhieuBaoTri").DataGridView("cboPhieuBaoTri", e.RowIndex) = cell1
            End If
        End If
    End Sub

    Private Sub grdNhapthoigianngungmay_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles grdNhapthoigianngungmay.CellClick
        Try
            If grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboTuGio" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboNguyenNhan" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboDenGio" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboPhieuBaoTri" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString = "" Then
                    grdNhapthoigianngungmay.ReadOnly = True
                Else
                    grdNhapthoigianngungmay.ReadOnly = False

                End If
            Else
                grdNhapthoigianngungmay.ReadOnly = False
            End If
        Catch ex As Exception
            grdNhapthoigianngungmay.ReadOnly = True
        End Try
    End Sub


    Private Sub grdNhapthoigianngungmay_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles grdNhapthoigianngungmay.CellValidated

        Dim sss As String = grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name
        If grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboTuNgay" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboDenNgay" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboTuGio" Or grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboDenGio" Then
            Try
                If (IsDBNull(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("txtTHOI_GIAN_SUA_CHUA").Value) Or grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("txtTHOI_GIAN_SUA_CHUA").Value.ToString().Trim().Equals("")) Then
                    Dim TuNgay As System.DateTime = Convert.ToDateTime(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value & " " & grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value)
                    Dim DenNgay As System.DateTime = Convert.ToDateTime(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value & " " & grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("txtTHOI_GIAN_SUA_CHUA").Value = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                Else
                    ' If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_SUA_CHUA").Value.ToString().Trim().Equals("1") Then
                    Dim TuNgay As System.DateTime = Convert.ToDateTime(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value & " " & grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value)
                    Dim DenNgay As System.DateTime = Convert.ToDateTime(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value & " " & grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("txtTHOI_GIAN_SUA_CHUA").Value = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                    grdNhapthoigianngungmay.EndEdit()
                    grdNhapthoigianngungmay.Refresh()
                End If
                'End If
            Catch ex As Exception
            End Try
        End If

        If BtnKhongghi.Focused() Then
            Exit Sub
        Else
            If grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboThietBi" Then
                If IsDBNull(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNhapthoigianngungmay.Focus()
                    Exit Sub
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboNguyenNhan" Then
                If IsDBNull(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNhapthoigianngungmay.Focus()
                    Exit Sub
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboPhieuBaoTri" Then
                If IsDBNull(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNhapthoigianngungmay.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grdNhapthoigianngungmay_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles grdNhapthoigianngungmay.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        Try
            If grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboThietBi" Then
                If e.FormattedValue <> "" Then
                    Dim tb As New DataTable()
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & e.FormattedValue & "'").Tables(0)
                    Dim dr As DataRow
                    dr = tb.NewRow
                    dr.Item("MS_PHIEU_BAO_TRI") = System.DBNull.Value
                    tb.Rows.InsertAt(dr, 0)
                    If tb.Rows.Count > 0 Then
                        grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboPhieuBaoTri").Value = tb.Rows(0).Item("MS_PHIEU_BAO_TRI")
                    Else
                        grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboPhieuBaoTri").Value = System.DBNull.Value
                    End If
                Else
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboPhieuBaoTri").Value = System.DBNull.Value
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboTuNgay" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Or e.FormattedValue = "  /  /" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTuNgayNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTuNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboNgaySua" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Or e.FormattedValue = "  /  /" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaySuaNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaySuaHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboDenNgay" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Or e.FormattedValue = "  /  /" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboTuGio" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Or e.FormattedValue = "  :" Then
                    'XtraMessageBox.Show("TU GIO KHONG DUOC NULL")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTuGioNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not IsDate(e.FormattedValue) Then
                        'XtraMessageBox.Show("TU GIO không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTuGioKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    Else
                        'If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value.ToString <> "" Then
                        '    If Date.Parse(e.FormattedValue) > Date.Parse(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value) Then
                        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuGioLonHonDenGio", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        '        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        '        e.Cancel = True
                        '        Exit Sub
                        '    End If
                        'End If
                    End If
                End If

            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboGioSua" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Or e.FormattedValue = "  :" Then
                    'XtraMessageBox.Show("TU GIO KHONG DUOC NULL")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioSuaNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If Not IsDate(e.FormattedValue) Then
                        'XtraMessageBox.Show("TU GIO không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioSuaKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    Else
                        'If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value.ToString <> "" Then
                        '    If Date.Parse(e.FormattedValue) > Date.Parse(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value) Then
                        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuGioLonHonDenGio", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        '        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        '        e.Cancel = True
                        '        Exit Sub
                        '    End If
                        'End If
                    End If
                End If

            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboDenGio" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue <> "  :" And e.FormattedValue <> "" Then
                    If Not IsDate(e.FormattedValue) Then
                        'XtraMessageBox.Show("TU GIO không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    Else
                        'If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value.ToString <> "" Then
                        '    If Date.Parse(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value) > Date.Parse(e.FormattedValue) Then
                        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuGioLonHonDenGio", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        '        grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                        '        e.Cancel = True
                        '        Exit Sub
                        '    End If
                        'End If
                    End If
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNhapthoigianngungmay.Columns(e.ColumnIndex).Name = "cboNguyenNhan" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" Then
                If e.FormattedValue = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNguyenNhanNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = ""

        Catch ex As Exception

        End Try
    End Sub
    Private Sub grdNhapthoigianngungmay_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) 'Handles grdNhapthoigianngungmay.DataError
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If e.RowIndex < grdNhapthoigianngungmay.Rows.Count - 1 Then
            If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Value.ToString <> "" And grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value.ToString <> "" Then
                If e.Context = DataGridViewDataErrorContexts.Commit Then
                    If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNguyenNhan").Value.ToString <> "" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOI_NHAP_LIEU", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    End If

                    'grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboThietBi").Selected = True
                    'grdNhapthoigianngungmay.Focus()
                    e.Cancel = False
                    Exit Sub

                End If
                'ElseIf grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value.ToString = "" Then
                '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTuGioNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                '    grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                '    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Selected = True
                '    grdNhapthoigianngungmay.Focus()
                '    e.Cancel = True
                '    Exit Sub
            End If
            If e.RowIndex = grdNhapthoigianngungmay.NewRowIndex And (grdNhapthoigianngungmay.CurrentRow.Cells("MS_MAY").Value.ToString = "" Or grdNhapthoigianngungmay.CurrentRow.Cells("MS_N_XUONG").Value.ToString = "") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DL_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            End If
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim objThoiGianNgungMayController As New clsTHOI_GIAN_NHUNG_MAYController()
        Dim str As String = ""
        Try
            str = "Drop table DOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.DOWNTIME" & Commons.Modules.UserName & " (MS_MAY NVARCHAR(30), TU_NGAY NVARCHAR(10),TU_GIO NVARCHAR(5),NGAY_SUA NVARCHAR(10), GIO_SUA NVARCHAR(5),DEN_NGAY NVARCHAR(10),DEN_GIO NVARCHAR(5),DONG INT, MS_HE_THONG INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        For i As Integer = 0 To grdNhapthoigianngungmay.RowCount - 2
            str = "InSert into DOWNTIME" & Commons.Modules.UserName & " (MS_MAY,TU_NGAY,TU_GIO,NGAY_SUA,GIO_SUA,DEN_NGAY,DEN_GIO,DONG) VALUES(N'" & grdNhapthoigianngungmay.Rows(i).Cells("cboThietBi").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboTuNgay").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboTuGio").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboNgaySua").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboGioSua").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboDenNgay").Value & "','" & grdNhapthoigianngungmay.Rows(i).Cells("cboDenGio").Value & "'," & i & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        'str = "INSERT INTO DOWNTIME" & Commons.Modules.UserName & "(MS_MAY,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO)" & _
        '" SELECT MS_MAY,CONVERT(NVARCHAR(10),NGAY,103),CONVERT(NVARCHAR(5),TU_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY,103),CONVERT(NVARCHAR(5),DEN_GIO,114)  " & _
        '" from(select * FROM THOI_GIAN_NGUNG_MAY  " & _
        '" WHERE NGAY BETWEEN (select MIN( CONVERT(DATETIME,TU_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & ") AND (select MAX( CONVERT(DATETIME,TU_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & ")) AS P1 " & _
        '" where NGAY<CONVERT(DATETIME,'" & Format(dtNgay.Value, "Short date") & "',103) OR NGAY>CONVERT(DATETIME,'" & Format(dtDenNgay1.Value, "Short date") & "',103) "

        str = "INSERT INTO DOWNTIME" & Commons.Modules.UserName & "(MS_MAY,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO)" & _
               " SELECT distinct MS_MAY,CONVERT(NVARCHAR(10),NGAY,103),CONVERT(NVARCHAR(5),TU_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY,103),CONVERT(NVARCHAR(5),DEN_GIO,114)  " & _
               " from(select * FROM THOI_GIAN_NGUNG_MAY  " & _
               " WHERE NGAY BETWEEN (select MIN( CONVERT(DATETIME,TU_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & ") AND (select MAX( CONVERT(DATETIME,DEN_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & ") " & _
               "OR (( NGAY < (select MIN( CONVERT(DATETIME,TU_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & " ))" & _
            " AND DEN_NGAY > (select MIN( CONVERT(DATETIME,TU_NGAY,103)) FROM DOWNTIME" & Commons.Modules.UserName & " ))) AS P1 " & _
               " where NGAY<CONVERT(DATETIME,'" & Format(dtNgay.Value, "Short date") & "',103) OR NGAY>CONVERT(DATETIME,'" & Format(dtDenNgay1.Value, "Short date") & "',103) "


        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "select MS_MAY,CONVERT(DATETIME,TU_NGAY,103) AS TU_NGAY,CONVERT(DATETIME,TU_GIO,114) AS TU_GIO, " & _
        " CONVERT(DATETIME,DEN_NGAY,103) AS DEN_NGAY,CONVERT(DATETIME,DEN_GIO,114) AS DEN_GIO,DONG " & _
        " from DOWNTIME" & Commons.Modules.UserName & " ORDER BY MS_MAY,TU_NGAY,TU_GIO  "
        Dim tmp As New DataTable()
        tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tmp.Rows.Count - 1
            For j As Integer = i + 1 To tmp.Rows.Count - 1
                If tmp.Rows(i).Item("MS_MAY") = tmp.Rows(j).Item("MS_MAY") Then
                    If Date.Parse(Format(tmp.Rows(j).Item("TU_NGAY"), "Short date") + " " + Format(tmp.Rows(j).Item("TU_GIO"), "Long time")) < Date.Parse(Format(tmp.Rows(i).Item("DEN_NGAY"), "Short date") + " " + Format(tmp.Rows(i).Item("DEN_GIO"), "Long time")) Then

                        Dim smay As String = tmp.Rows(i).Item("MS_MAY")
                        Dim vtn As DateTime = Date.Parse(Format(tmp.Rows(j).Item("TU_NGAY"), "Short date") + " " + Format(tmp.Rows(j).Item("TU_GIO"), "Long time"))
                        Dim vdn As DateTime = Date.Parse(Format(tmp.Rows(i).Item("DEN_NGAY"), "Short date") + " " + Format(tmp.Rows(i).Item("DEN_GIO"), "Long time"))

                        'XtraMessageBox.Show(Date.Parse(Format(tmp.Rows(j).Item("TU_NGAY"), "Short date") + " " + Format(tmp.Rows(j).Item("TU_GIO"), "Long time")))
                        'XtraMessageBox.Show(Date.Parse(Format(tmp.Rows(i).Item("DEN_NGAY"), "Short date") + " " + Format(tmp.Rows(i).Item("DEN_GIO"), "Long time")))

                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGian", Commons.Modules.TypeLanguage) & " : " & tmp.Rows(i).Item("MS_MAY").ToString & vbCrLf & vtn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & vdn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture), MsgBoxStyle.Exclamation)

                        'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgThoiGian", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.CurrentCell().Selected = False
                        grdNhapthoigianngungmay.Rows(IIf(tmp.Rows(j).Item("DONG").ToString = "", tmp.Rows(i).Item("DONG"), tmp.Rows(j).Item("DONG"))).Cells("cboTuNgay").Selected = True
                        grdNhapthoigianngungmay.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Next
        If kiemtranguyenhan() = False Then
            Exit Sub
        End If

        Try
            objThoiGianNgungMayController.AddTHOI_GIAN_NGUNG_MAY_BAYER(tb, Format(dtNgay.Value, "Short date"), Format(dtDenNgay1.Value, "Short date"), cboLoaiMay.SelectedValue)
        Catch ex As Exception
        End Try
        RemoveHandler grdNhapthoigianngungmay.CellBeginEdit, AddressOf Me.grdNhapthoigianngungmay_CellBeginEdit
        RemoveHandler grdNhapthoigianngungmay.CellClick, AddressOf Me.grdNhapthoigianngungmay_CellClick
        RemoveHandler grdNhapthoigianngungmay.CellValidated, AddressOf Me.grdNhapthoigianngungmay_CellValidated
        RemoveHandler grdNhapthoigianngungmay.CellValidating, AddressOf Me.grdNhapthoigianngungmay_CellValidating
        RemoveHandler grdNhapthoigianngungmay.DataError, AddressOf Me.grdNhapthoigianngungmay_DataError
        RemoveHandler grdNhapthoigianngungmay.KeyDown, AddressOf Me.grdNhapthoigianngungmay_KeyDown
        RemoveHandler grdNhapthoigianngungmay.RowValidating, AddressOf Me.grdNhapthoigianngungmay_RowValidating
        RemoveHandler grdNhapthoigianngungmay.EditingControlShowing, AddressOf Me.grdNhapthoigianngungmay_EditingControlShowing
        RemoveHandler grdNhapthoigianngungmay.DataSourceChanged, AddressOf Me.grdNhapthoigianngungmay_DataSourceChanged
        RemoveHandler grdNhapthoigianngungmay.CellValueChanged, AddressOf Me.grdNhapthoigianngungmay_CellValueChanged
        bThem = False
        Binddata()
        Try
            grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(0).Cells("cboThietBi")
            grdNhapthoigianngungmay.Focus()
        Catch ex As Exception

        End Try
        BindData1()
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        'Dim str As String = ""
        Try
            str = "DROP TABLE tmpDOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE DOWNTIME" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grdNhapthoigianngungmay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 'Handles grdNhapthoigianngungmay.KeyDown
        If e.KeyCode = Keys.Escape Then
            If grdNhapthoigianngungmay.RowCount > 1 Then
                If grdNhapthoigianngungmay.RowCount - 1 > rowCount + 1 And Not grdNhapthoigianngungmay.CurrentRow.IsNewRow Then
                    grdNhapthoigianngungmay.Rows.RemoveAt(Me.grdNhapthoigianngungmay.CurrentRow.Index)
                    e.Handled = True
                End If
            Else
                Binddata()
            End If
        End If
    End Sub

    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
    End Sub

    Private Sub BtnXoaAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaAll.Click
        If grdNhapthoigianngungmay.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDLXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Dim traloi As String
            traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaAll", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
            If traloi = vbYes Then
                Dim objThoiGianNgungMayController As New clsTHOI_GIAN_NHUNG_MAYController()
                objThoiGianNgungMayController.DeleteTHOI_GIAN_NGUNG_MAY_ALL(Format(dtNgay.Value, "Short date"), Commons.Modules.UserName, cboLoaiMay.SelectedValue)
                Binddata()
                BindData1()
            End If
        End If
    End Sub

    Private Sub BtnXoaCT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaCT.Click
        If grdNhapthoigianngungmay.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDLXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Dim traloi As String
            traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
            If traloi = vbYes Then
                Dim objThoiGianNgungMayController As New clsTHOI_GIAN_NHUNG_MAYController()
                Dim tmp As Integer = intRow
                objThoiGianNgungMayController.DeleteTHOI_GIAN_NGUNG_MAY(grdNhapthoigianngungmay.Rows(intRow).Cells("NGAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("TU_GIO").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("MS_MAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("DEN_NGAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("DEN_GIO").Value)
                Binddata()
                BindData1()
                If grdNhapthoigianngungmay.Rows.Count > 0 Then
                    If grdNhapthoigianngungmay.Rows.Count = tmp Then
                        grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(tmp - 1).Cells("cboThietBi")
                        grdNhapthoigianngungmay.Focus()
                    Else
                        grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(tmp).Cells("cboThietBi")
                        grdNhapthoigianngungmay.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdNhapthoigianngungmay_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapthoigianngungmay.CellClick
        If e.RowIndex >= 0 Then
            hang = e.RowIndex
        End If
    End Sub


    Private Sub grdNhapthoigianngungmay_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdNhapthoigianngungmay.DefaultValuesNeeded
        With e.Row
            Dim strTmp As String = DateAdd(DateInterval.Minute, 1, Now)
            .Cells("cboTuNgay").Value = Format(Date.Now(), "Short date")
            .Cells("cboDenNgay").Value = Format(Date.Now(), "Short date")
            .Cells("cboTuGio").Value = Date.Now.TimeOfDay.ToString.Substring(0, 5)
            .Cells("cboDenGio").Value = strTmp.Substring(strTmp.Length - 8, 5) '  Date.Now.TimeOfDay.ToString.Substring(0, 5)

            .Cells("cboNgaySua").Value = Format(Date.Now(), "Short date")
            .Cells("cboGioSua").Value = Date.Now.TimeOfDay.ToString.Substring(0, 5)

        End With
    End Sub
    Private Sub grdNhapthoigianngungmay_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapthoigianngungmay.RowEnter
        Try
            intRow = e.RowIndex
            grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("TEN_N_XUONG").ReadOnly = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        'VisibleButton(False)
        'VisibleButtonGhi(False)
        'VisibleButtonXoa(True)
        If grdNhapthoigianngungmay.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDLXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Dim traloi As String
            traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
            If traloi = vbYes Then
                Dim objThoiGianNgungMayController As New clsTHOI_GIAN_NHUNG_MAYController()
                objThoiGianNgungMayController.DeleteTHOI_GIAN_NGUNG_MAY(grdNhapthoigianngungmay.Rows(intRow).Cells("NGAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("TU_GIO").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("MS_MAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("DEN_NGAY").Value, grdNhapthoigianngungmay.Rows(intRow).Cells("DEN_GIO").Value)
                Binddata()
                BindData1()
            End If
        End If
    End Sub

    Private Sub BtnThoat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat1.Click
        Me.Close()
    End Sub

    Private Sub dtTungay_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtTungay.CloseUp
        BindData1()
    End Sub

    Private Sub dtDengnay_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDengnay.CloseUp
        BindData1()
    End Sub

    Private Sub cboThietbi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThietbi.SelectionChangeCommitted
        BindData1()
    End Sub
    Sub CreaterptTieuDeThoiGianNgungMay()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "Ngay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "sDenNgay", Commons.Modules.TypeLanguage)
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

        Dim NGUOI_GIAI_QUYET As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        Dim LOAI As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "LOAI", Commons.Modules.TypeLanguage)

        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblDiaDiem.Text + " " + cboDiaDiem.Text + "  "
        DieuKienLoc = DieuKienLoc + lblTungay.Text + " " + Format(dtTungay.Value, "Short date") + "  " + lblDenngay.Text + " " + Format(dtDengnay.Value, "Short date")
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_THOI_GIAN_NGUNG_MAY(TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(30),TrangIn nvarchar(30),DieuKienLoc nvarchar(255)," & _
        " ThietBi nvarchar(50),sNgay nvarchar(20),sDenNgay nvarchar(20),TuGio nvarchar(20),DenGio nvarchar(20),NguyenNhan nvarchar(50),PhieuBaoTri nvarchar(50),GhiChu nvarchar(20), " & _
        " MaLoai nvarchar(50),TenLoai nvarchar(50),MaNhom nvarchar(50),TenNhom nvarchar(50),ThoiGianNghi nvarchar(50),TongMay nvarchar(50),TongNhom nvarchar(50),TongLoai nvarchar(50),TongKho nvarchar(50),NGUOI_GIAI_QUYET nvarchar(100) ,LOAI nvarchar(100) )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into rptTIEU_DE_THOI_GIAN_NGUNG_MAY(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,ThietBi,sNgay,sDenNgay,TuGio,DenGio,NguyenNhan,PhieuBaoTri, " & _
        " GhiChu,MaLoai,TenLoai,MaNhom,TenNhom,ThoiGianNghi,TongMay,TongNhom,TongLoai,TongKho,NGUOI_GIAI_QUYET,LOAI) values(" & _
        Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & "',N'" & ThietBi & "',N'" & Ngay & "',N'" & DenNgay & "',N'" & TuGio & "',N'" & DenGio & "',N'" & NguyenNhan & "',N'" & PhieuBaoTri & "',N'" & GhiChu & _
        "',N'" & MaLoai & "',N'" & TenLoai & "',N'" & MaNhom & "',N'" & TenNhom & "',N'" & ThoiGianNghi & "',N'" & TongMay & "',N'" & TongNhom & "',N'" & TongLoai & "',N'" & TongKho & "',N'" & NGUOI_GIAI_QUYET & "',N'" & LOAI & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click

        Dim frm As New Report1.FrmChonThoiGianNgungMay
        frm.ShowDialog()
    End Sub
    Private Sub cboLoaiMay_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiMay.SelectionChangeCommitted
        Binddata()
    End Sub
    'sdaf
    'sadfsad
    Private Sub grdNhapthoigianngungmay_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) 'Handles grdNhapthoigianngungmay.RowValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If e.RowIndex < grdNhapthoigianngungmay.Rows.Count - 1 Then
            Try
                If grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTuGioNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio") '.Selected = True
                    grdNhapthoigianngungmay.Focus()
                    e.Cancel = True
                    Exit Sub
                ElseIf grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio")
                    grdNhapthoigianngungmay.Focus()
                    e.Cancel = True
                    Exit Sub
                ElseIf grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNguyenNhan").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNguyenNhanNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    'grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNguyenNhan").Selected = True
                    grdNhapthoigianngungmay.Focus()
                    e.Cancel = True
                    Exit Sub
                ElseIf grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNgaySua").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaySuaNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNgaySua")
                    grdNhapthoigianngungmay.Focus()
                    e.Cancel = True
                    Exit Sub
                ElseIf grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboGioSua").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioSuaNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboGioSua")
                    grdNhapthoigianngungmay.Focus()
                    e.Cancel = True
                    Exit Sub

                End If
                'If Date.Parse(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value + " " + grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value) >= Date.Parse(grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value + " " + grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value) Then
                '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgThoiGian", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                '    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio")
                '    e.Cancel = True
                '    Exit Sub
                'End If


                If DateDiff(DateInterval.Day, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value) < 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_NGAY_KHONG_HOP_LE", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay")
                    e.Cancel = True
                    Exit Sub
                ElseIf DateDiff(DateInterval.Day, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value) = 0 Then
                    If DateDiff(DateInterval.Minute, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value, grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value) < 0 Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_GIO_KHONG_HOP_LE", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio")
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

                Dim vtungay As New DateTime
                Dim vtugio As New DateTime
                Dim vdenngay As New DateTime
                Dim vdengio As New DateTime
                Dim vngaysua As New DateTime
                Dim vgiosua As New DateTime

                vtungay = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuNgay").Value
                vdenngay = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenNgay").Value
                vtugio = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboTuGio").Value
                vdengio = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio").Value
                vngaysua = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNgaySua").Value
                vgiosua = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboGioSua").Value

                vtungay = New DateTime(vtungay.Year, vtungay.Month, vtungay.Day, vtugio.Hour, vtugio.Minute, vtugio.Second)
                vdenngay = New DateTime(vdenngay.Year, vdenngay.Month, vdenngay.Day, vdengio.Hour, vdengio.Minute, vdengio.Second)
                vngaysua = New DateTime(vngaysua.Year, vngaysua.Month, vngaysua.Day, vgiosua.Hour, vgiosua.Minute, vgiosua.Second)

                If DateTime.Compare(vtungay, vngaysua) > 0 Or DateTime.Compare(vngaysua, vdenngay) > 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_SUA_NAM_TRONG_KHOANG_TN_DN", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If vtungay.Day <> vngaysua.Day Then
                        grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboNgaySua")
                    Else
                        grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboGioSua")
                    End If
                    e.Cancel = True
                    Exit Sub
                End If

                Dim dtTable As New DataTable
                'Dim str As String = "SELECT DISTINCT TMP.MS_MAY, MAX(TMP.NGAY_NHAP) AS NGAY_NHAP, TMP.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG " & _
                '                    "FROM (SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP, MS_N_XUONG " & _
                '                          "FROM MAY_NHA_XUONG " & _
                '                          "WHERE MS_MAY=N'0 TEST' AND NGAY_NHAP BETWEEN '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboDenNgay").Value), "dd/MMM/yyyy") & "' " & _
                '                          "GROUP BY MS_MAY, MS_N_XUONG " & _
                '                          "UNION " & _
                '                          "SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP, MS_N_XUONG FROM MAY_NHA_XUONG " & _
                '                          "WHERE MS_MAY=N'" & grdNhapthoigianngungmay.CurrentRow.Cells("cboThietBi").Value.ToString & "' AND NGAY_NHAP <= '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' " & _
                '                          "GROUP BY MS_MAY, MS_N_XUONG " & _
                '                          ") TMP  INNER JOIN NHA_XUONG ON TMP.MS_N_XUONG = NHA_XUONG.MS_N_XUONG GROUP BY TMP.MS_MAY, TMP.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG"

                Dim str As String = "SELECT DISTINCT TMP.MS_MAY, MAX(TMP.NGAY_NHAP) AS NGAY_NHAP, TMP.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG " & _
                   " FROM (SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP, MS_N_XUONG FROM MAY_NHA_XUONG " & _
                   " WHERE MS_MAY=N'0 TEST' AND NGAY_NHAP BETWEEN '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboDenNgay").Value), "dd/MMM/yyyy") & "' GROUP BY MS_MAY, MS_N_XUONG " & _
                   " UNION SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP, MS_N_XUONG " & _
                   "  FROM MAY_NHA_XUONG " & _
                   " WHERE MS_MAY=N'" & grdNhapthoigianngungmay.CurrentRow.Cells("cboThietBi").Value.ToString & "' AND NGAY_NHAP <= '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' " & _
                   "  GROUP BY MS_MAY, MS_N_XUONG ) TMP  " & _
                   " INNER JOIN NHA_XUONG ON TMP.MS_N_XUONG = NHA_XUONG.MS_N_XUONG  " & _
                   " WHERE TMP.NGAY_NHAP IN ( SELECT * FROM ( SELECT  MAX(NGAY_NHAP) AS NGAY_NHAP " & _
                "FROM MAY_NHA_XUONG  " & _
                  "  WHERE MS_MAY=N'0 TEST' AND NGAY_NHAP BETWEEN '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboDenNgay").Value), "dd/MMM/yyyy") & "' AND  NGAY_NHAP IS NOT NULL " & _
               " UNION " & _
                  "  SELECT  MAX(NGAY_NHAP) AS NGAY_NHAP " & _
                "FROM MAY_NHA_XUONG " & _
                 "   WHERE MS_MAY=N'" & grdNhapthoigianngungmay.CurrentRow.Cells("cboThietBi").Value.ToString & "' AND NGAY_NHAP <= '" & Format(CDate(grdNhapthoigianngungmay.CurrentRow.Cells("cboTuNgay").Value), "dd/MMM/yyyy") & "' AND NGAY_NHAP IS NOT NULL )TMP_NGAY " & _
                  "  WHERE TMP_NGAY.NGAY_NHAP IS NOT NULL) " & _
                  "  GROUP BY TMP.MS_MAY, TMP.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG "
                dtTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)

                If dtTable.Rows.Count > 0 Then
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("MS_N_XUONG").Value = dtTable.Rows(0).Item("MS_N_XUONG")
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("TEN_N_XUONG").Value = dtTable.Rows(0).Item("TEN_N_XUONG")
                Else
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("MS_N_XUONG").Value = System.DBNull.Value
                    grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("TEN_N_XUONG").Value = System.DBNull.Value
                End If
            Catch ex As Exception
            End Try

            'Dim str As String = ""
            'str = "DELETE FROM tmpDOWNTIME" & Commons.Modules.UserName
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            'For i As Integer = 0 To grdNhapthoigianngungmay.Rows.Count - 2
            '    If Not grdNhapthoigianngungmay.Rows(i).Cells("cboThietBi").Value Is Nothing Then
            '        str = "INSERT INTO tmpDOWNTIME" & Commons.Modules.UserName & " (MS_MAY,TU_GIO,DEN_GIO) VALUES(N'" & _
            '        grdNhapthoigianngungmay.Rows(i).Cells("cboThietBi").Value & "',N'" & grdNhapthoigianngungmay.Rows(i).Cells("cboTuGio").Value & "',N'" & _
            '        grdNhapthoigianngungmay.Rows(i).Cells("cboDenGio").Value & "')"
            '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            '    End If
            'Next
            'Dim tb As New DataTable()
            'str = "SELECT MS_MAY,CONVERT(DATETIME,TU_GIO,114)AS TU_GIO,CONVERT (DATETIME,DEN_GIO,114)AS DEN_GIO FROM  tmpDOWNTIME" & Commons.Modules.UserName & " ORDER BY TU_GIO"
            'tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            'For i As Integer = 0 To tb.Rows.Count - 2
            '    For j As Integer = i + 1 To tb.Rows.Count - 1
            '        If tb.Rows(i).Item("MS_MAY") = tb.Rows(j).Item("MS_MAY") Then
            '            If Date.Parse(Format(tb.Rows(j).Item("TU_GIO"), "Long time")) < Date.Parse(Format(tb.Rows(i).Item("DEN_GIO"), "Long time")) Then
            '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgThoiGian", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            '                grdNhapthoigianngungmay.CurrentCell() = grdNhapthoigianngungmay.Rows(e.RowIndex).Cells("cboDenGio")
            '                e.Cancel = True
            '                Exit Sub
            '            End If
            '        End If
            '    Next
            'Next
        End If
        'grdNhapthoigianngungmay.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub cboDiaDiem_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiaDiem.SelectionChangeCommitted
        LoadcbiLoaiMay()
        LoadcboNhomMay()
        LoadcboThietBiLoc()
        BindData1()
    End Sub

    Private Sub cboLoaiTB_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiTB.SelectionChangeCommitted
        LoadcboNhomMay()
        LoadcboThietBiLoc()
        BindData1()
    End Sub

    Private Sub cboNhomMay_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNhomMay.SelectionChangeCommitted
        LoadcboThietBiLoc()
        BindData1()
    End Sub

    Private Sub BtnNguyenNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNguyenNhan.Click
        Dim frmNguyenNhanDungMay As Report1.frmNguyenNhanDungMay = New Report1.frmNguyenNhanDungMay()
        frmNguyenNhanDungMay.ShowDialog()
    End Sub

    Private Sub dtNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtNgay.Validating
        Binddata()
    End Sub
    Dim autoCompleteSource As New AutoCompleteStringCollection()
    Private Sub grdNhapthoigianngungmay_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdNhapthoigianngungmay.EditingControlShowing
        Dim dgv As DataGridView = CType(sender, DataGridView)

        Try
            txtKeypress = e.Control
            If grdNhapthoigianngungmay.CurrentCell.OwningColumn.Name = "txtTHOI_GIAN_SUA_CHUA" Then
                RemoveHandler txtKeypress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
                AddHandler txtKeypress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            Else
                RemoveHandler txtKeypress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try

        If TypeOf e.Control Is System.Windows.Forms.ComboBox Then
            Dim tb As System.Windows.Forms.ComboBox = CType(e.Control, System.Windows.Forms.ComboBox)
            If dgv.CurrentCell.OwningColumn.Name = "cboThietBi" Or dgv.CurrentCell.OwningColumn.Name = "cboNguyenNhan" Or dgv.CurrentCell.OwningColumn.Name = "cboPhieuBaoTri" Then
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                tb.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
                tb.AutoCompleteCustomSource = Me.autoCompleteSource
                tb.DropDownStyle = ComboBoxStyle.DropDownList '  ComboBoxStyle.DropDown
            Else
                tb.AutoCompleteMode = AutoCompleteMode.None
            End If
        End If
        If dgv.CurrentCell.OwningColumn.Name = "cboThietBi" Then
            cbochonmay = e.Control
            ' flag = 1
            grdNhapthoigianngungmay.Refresh()
            RemoveHandler cbochonmay.SelectionChangeCommitted, AddressOf cbochonmay_SelectionChangeCommitted
            AddHandler cbochonmay.SelectionChangeCommitted, AddressOf cbochonmay_SelectionChangeCommitted
        End If
        'If Me.grdNhapthoigianngungmay.CurrentCellAddress.X = 5 Then
        '    cbohethong = e.Control
        '    ' flag = 1
        '    '   RemoveHandler cbohethong.SelectionChangeCommitted, AddressOf cbohethong_SelectedIndexChanged
        '    ' AddHandler cbohethong.SelectionChangeCommitted, AddressOf cbohethong_SelectedIndexChanged
        'End If
    End Sub

    Private Sub cbochonmay_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(cbochonmay.Text) Then Exit Sub
        If cbochonmay.Text = "" Then Exit Sub
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        Dim row As DataRow
        Dim dt1 As New DataTable
        Dim row1 As DataRow
        'grdNhapthoigianngungmay.Refresh()
        Dim ngaymax As DateTime
        dt = obj.GETMAXNGAYNHAP(cbochonmay.SelectedValue)
        If dt.Rows.Count > 0 Then
            row = dt.Rows(0)
            If IsDBNull(row("ngaynhap")) = False Then
                ngaymax = row("ngaynhap")
                dt1 = obj.GETHETHONG(cbochonmay.SelectedValue, ngaymax)
                If dt1.Rows.Count > 0 Then
                    row1 = dt1.Rows(0)
                    'intRow
                    'Me.cbohethong.SelectedValue = row1("ms_he_thong")
                    Me.hethong = Convert.ToInt64(row1("ms_he_thong"))
                    Me.grdNhapthoigianngungmay.Rows(grdNhapthoigianngungmay.CurrentRow.Index).Cells("cboHE_THONG").Value = row1("ms_he_thong")
                    '(dgvDanhMucBCDKT.Rows(dgvDanhMucBCDKT.CurrentRow.Index).Cells("code").Value
                Else
                    Me.grdNhapthoigianngungmay.Rows(grdNhapthoigianngungmay.CurrentRow.Index).Cells("cboHE_THONG").Value = 0

                End If

            End If
        End If
        grdNhapthoigianngungmay.Refresh()


    End Sub
    Private Sub cbohethong_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If IsDBNull(cbochonmay.Text) Then Exit Sub
        'If cbochonmay.Text = "" Then Exit Sub

        '    XtraMessageBox.Show(cbochonmay.SelectedValue)
        ' Me.dgvChiTietBCDKT.Rows(dgvChiTietBCDKT.Rows.Count - 1).Cells("Congtru").Value = Cbotu.Text
        'Dim objDonHangNhapPTController As New IC_DON_HANG_NHAP_Controller
        'Me.QlGrid1.CurrentRow.Cells("TY_GIA").Value = objDonHangNhapPTController.Load_Ty_Gia_Theo_Ngoai_Te(cbNgoaiTe.SelectedValue)

        'Me.QlGrid1.CurrentRow.Cells("TY_GIA_USD").Value = objDonHangNhapPTController.Load_Ty_Gia_USD_Theo_Ngoai_Te(cbNgoaiTe.SelectedValue)


        ' Catch ex As Exception

        '  End Try

    End Sub
    Private Sub grdNhapthoigianngungmay_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNhapthoigianngungmay.DataSourceChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Me.autoCompleteSource.Clear()
            Dim r As DataGridViewRow
            If dgv.CurrentCell.OwningColumn.Name = "cboNguyenNhan" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboNguyenNhan").Value
                    If Not String.IsNullOrEmpty(val) AndAlso _
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r
            ElseIf dgv.CurrentCell.OwningColumn.Name = "cboThietBi" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboThietBi").Value
                    If Not String.IsNullOrEmpty(val) AndAlso _
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r
            ElseIf dgv.CurrentCell.OwningColumn.Name = "cboPhieuBaoTri" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboPhieuBaoTri").Value
                    If Not String.IsNullOrEmpty(val) AndAlso _
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub grdNhapthoigianngungmay_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapthoigianngungmay.CellValueChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If dgv.Columns(e.ColumnIndex).Name = "cboThietBi" Or dgv.CurrentCell.OwningColumn.Name = "cboNguyenNhan" Or dgv.CurrentCell.OwningColumn.Name = "cboPhieuBaoTri" Then
                Dim val As String = dgv(e.ColumnIndex, e.RowIndex).Value
                If Not String.IsNullOrEmpty(val) AndAlso _
                     Not Me.autoCompleteSource.Contains(val) Then
                    autoCompleteSource.Add(val)
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtDenNgay1_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDenNgay1.CloseUp
        Binddata()
    End Sub

    Private Sub dtDenNgay1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtDenNgay1.Validating
        Binddata()
    End Sub


    Sub txtTHOI_GIAN_SUA_CHUA()

        Dim textTHOI_GIAN_SUA_CHUA As New DataGridViewTextBoxColumn()
        textTHOI_GIAN_SUA_CHUA.Name = "txtTHOI_GIAN_SUA_CHUA"
        textTHOI_GIAN_SUA_CHUA.DataPropertyName = "THOI_GIAN_SUA_CHUA"
        grdNhapthoigianngungmay.Columns.Insert(11, textTHOI_GIAN_SUA_CHUA)

    End Sub

    Private Sub cboLoaiMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiMay.SelectedIndexChanged
        Dim dt As New DataTable
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboHE_THONG"
        comboBoxColumn.ValueMember = "MS_HE_THONG"
        comboBoxColumn.DisplayMember = "TEN_HE_THONG"
        comboBoxColumn.DataPropertyName = "Hahaha"

    End Sub

    Private Sub lbtTieuDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtTieuDe.Click

    End Sub

    Private Sub grdNhapthoigianngungmay_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapthoigianngungmay.CellContentClick

    End Sub

    Private Sub grdNhapthoigianngungmay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNhapthoigianngungmay.LostFocus
        '  Me.grdNhapthoigianngungmay.Rows(grdNhapthoigianngungmay.CurrentRow.Index).Cells("MS_HE_THONG").Value = Me.hethong
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MS_NGUYEN_NHAN
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Function kiemtranguyenhan() As Boolean
        kiemtranguyenhan = True
        Dim i As Integer
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        For i = 0 To grdNhapthoigianngungmay.RowCount - 1
            If i < grdNhapthoigianngungmay.NewRowIndex Then
                If IsDBNull(grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA").Value) Or grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA").Value Is Nothing Or Val(grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA").Value.ToString) = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgboxtgsc", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell = grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA")
                    kiemtranguyenhan = False
                    Exit For
                End If
                If IsDBNull(grdNhapthoigianngungmay.Rows(i).Cells("cboNguyenNhanHuHong").Value) Or grdNhapthoigianngungmay.Rows(i).Cells("cboNguyenNhanHuHong").Value Is Nothing Or Val(grdNhapthoigianngungmay.Rows(i).Cells("cboNguyenNhanHuHong").Value.ToString) = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgboxthh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdNhapthoigianngungmay.CurrentCell = grdNhapthoigianngungmay.Rows(i).Cells("cboNguyenNhanHuHong")
                    kiemtranguyenhan = False
                    Exit For
                End If
                dt = obj.Getnguyennhanhuhong(Me.grdNhapthoigianngungmay.Rows(i).Cells("cboNguyenNhan").Value)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA").Value) = False Then
                        If Me.grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA").Value <= 0 Then
                            'Me.grdNhapthoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", commons.Modules.TypeLanguage)
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgboxtgsc", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            kiemtranguyenhan = False
                            Exit For
                        End If
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgboxtgsc", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdNhapthoigianngungmay.CurrentCell = grdNhapthoigianngungmay.Rows(i).Cells("txtTHOI_GIAN_SUA_CHUA")
                        kiemtranguyenhan = False
                        Exit For
                    End If
                End If
            End If
        Next
    End Function


End Class