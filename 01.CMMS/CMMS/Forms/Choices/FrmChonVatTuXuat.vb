Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Admin
Imports DevExpress.XtraEditors

Public Class FrmChonVatTuXuat

    Private callback As QLCallBackEvent
    Private MS_DH_XUAT_PT As String
    Private MS_PBT As String
    Private MS_KHO As Integer
    Private status As Boolean
    Private objDonHangXuatController As New IC_DON_HANG_XUAT_Controller
    Private lstDonHangXuatVT As List(Of IC_DON_HANG_XUAT_VAT_TU_Info) = New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
    Private lstVTKho As List(Of VAT_TU_Info) = New List(Of VAT_TU_Info)
    Private lstCTVTXuat As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
    Private lstVITRI_KHO_VATTU_Filter As New List(Of VI_TRI_KHO_VAT_TU_Info)
    Private rowIndexVT As Integer = -1
    Private rowIndexVTChon As Integer
    Private hasDataCTXuatVT As New Hashtable
    Private MS_PT As String = ""
    Public NGAY_XUA As Date
    Private strPickList As String = ""
    Private ID_XUAT As Double
    Dim StrPickNo As String = ""

    Public listVTPTXThem As New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
    Public hasDataCtXuatVTThem As New Hashtable

    Public dangxuat As Integer = 0

    Dim iSLImport As Double = 0
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByVal callback As QLCallBackEvent, ByVal MS_KHO As Integer, ByVal status As Boolean,
                   ByVal MS_DH_XUAT_PT As String, ByVal MS_PBT As String,
                   ByVal lstVITRI_KHO_VATTU_Filter As List(Of VI_TRI_KHO_VAT_TU_Info), ByVal ID_XUAT As Double)
        InitializeComponent()
        Me.callback = callback
        Me.MS_KHO = MS_KHO
        Me.MS_PBT = MS_PBT
        Me.status = status
        Me.MS_DH_XUAT_PT = MS_DH_XUAT_PT
        Me.lstVITRI_KHO_VATTU_Filter = lstVITRI_KHO_VATTU_Filter
        Me.ID_XUAT = ID_XUAT
    End Sub


    Private Sub FrmChonVatTuXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If status = False Then

            LOAD_DON_HANG_XUAT_VAT()
            If Me.lstDonHangXuatVT.Count > 0 Then
                Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                Me.FormatGridDS_Phu_Tung_Chon()
                Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
            End If
        Else
            'LOAD_DON_HANG_XUAT_VAT()
            ''''''''''''
            If listVTPTXThem.Count > 0 Then
                Me.lstDonHangXuatVT = Me.listVTPTXThem
                Me.hasDataCTXuatVT = hasDataCtXuatVTThem
                Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                Me.FormatGridDS_Phu_Tung_Chon()
                Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
            End If
        End If

        btnChonVTTuPBT.Enabled = IIf(MS_PBT.Trim = "", False, True)
        Me.Load_Vat_Tu()
        Me.Load_DDH()
        If grdDS_PHU_TUNG_CHON.Rows.Count > 0 Then

            Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Selected = True
            Me.lstCTVTXuat = CType(Me.hasDataCTXuatVT.Item(Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Value), List(Of CHI_TIET_VAT_TU_XUAT_Info))
            Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
            FormatGridCT_VT_Xuat()
            Try
                Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
            Catch ex As Exception
            End Try

        End If
        AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        If grdDS_PHU_TUNG_CHON.RowCount <> 0 Then
            chkGoodsReceive.Enabled = False
        Else
            chkGoodsReceive.Enabled = True
        End If
        If Commons.Modules.sPrivate = "PILMICO" And dangxuat = 3 Then
            btn.Text = "+"
            btn.Visible = True
        Else
            btn.Visible = False
        End If

    End Sub

    Sub FormatGridDS_Phu_Tung()
        Me.grdDS_PHU_TUNG.Columns.Clear()
        Dim column As New DataGridViewTextBoxColumn
        column.Name = "MS_PT"
        column.DataPropertyName = "MS_PT"
        column.SortMode = DataGridViewColumnSortMode.Automatic
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "TEN_PT"
        column.DataPropertyName = "TEN_PT"
        column.Width = 250
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG.Columns.Add(column)


        column = New DataGridViewTextBoxColumn
        column.Name = "MS_PT_CTY"
        column.DataPropertyName = "MS_PT_CTY"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_PT_NCC"
        column.DataPropertyName = "MS_PT_NCC"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG.Columns.Add(column)


        column = New DataGridViewTextBoxColumn
        column.Name = "DVT"
        column.DataPropertyName = "DVT"
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DVT", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG.Columns.Add(column)

    End Sub

    Sub FormatGridDS_Phu_Tung_Chon()
        Me.grdDS_PHU_TUNG_CHON.Columns.Clear()
        Dim column As New DataGridViewTextBoxColumn
        column.Name = "MS_DH_XUAT_PT"
        column.DataPropertyName = "MS_DH_XUAT_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_XUAT_PT", Commons.Modules.TypeLanguage)
        column.Visible = False
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_PT"
        column.DataPropertyName = "MS_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "TEN_PT"
        column.DataPropertyName = "TEN_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        'column.Width = 170
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.DefaultCellStyle.NullValue = ""
        column.Name = "SO_LUONG_CTU"
        column.DataPropertyName = "SO_LUONG_CTU"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG_CTU", Commons.Modules.TypeLanguage)
        column.ReadOnly = False
        column.Width = 80
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "SO_LUONG_THUC_XUAT"
        column.DataPropertyName = "SO_LUONG_THUC_XUAT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG_THUC_XUAT", Commons.Modules.TypeLanguage)
        column.ReadOnly = False
        column.Width = 80
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "DVT"
        column.DataPropertyName = "DVT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DVT", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        column.Width = 60
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "GHI_CHU"
        column.DataPropertyName = "GHI_CHU"
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)


        column = New DataGridViewTextBoxColumn
        column.Name = "ITEM_CODE"
        column.DataPropertyName = "ITEM_CODE"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDanhmucphutung", "MS_PT_CTY", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "PART_NO"
        column.DataPropertyName = "PART_NO"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDanhmucphutung", "MS_PT_NCC", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        Me.grdDS_PHU_TUNG_CHON.Columns.Add(column)
    End Sub

    Sub FormatGridCT_VT_Xuat()
        Me.grdCT_VT_XUAT.Columns.Clear()
        Dim column As New DataGridViewTextBoxColumn
        column.Name = "MS_DH_NHAP_PT"
        column.DataPropertyName = "MS_DH_NHAP_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        column.Width = 80
        column.ReadOnly = True
        Me.grdCT_VT_XUAT.Columns.Add(column)
        Dim dtColumn As New Commons.CalendarColumn
        dtColumn.Name = "NGAY"
        dtColumn.DataPropertyName = "NGAY"
        dtColumn.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
        dtColumn.ReadOnly = True
        dtColumn.Width = 70
        Me.grdCT_VT_XUAT.Columns.Add(dtColumn)
        column = New DataGridViewTextBoxColumn
        column.Name = "TEN_VI_TRI"
        column.DataPropertyName = "TEN_VI_TRI"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_VI_TRI", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        Me.grdCT_VT_XUAT.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_PT"
        column.DataPropertyName = "MS_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        column.Visible = False
        Me.grdCT_VT_XUAT.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "SL_VT"
        column.DataPropertyName = "SL_VT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TON", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        column.Width = 60
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCT_VT_XUAT.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "SL_XUAT"
        column.DataPropertyName = "SL_XUAT"
        column.Width = 60
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_XUAT", Commons.Modules.TypeLanguage)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCT_VT_XUAT.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "BAO_HANH_DEN_NGAY"
        column.DataPropertyName = "BAO_HANH_DEN_NGAY"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BAO_HANH_DEN_NGAY", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        column.Width = 70
        Me.grdCT_VT_XUAT.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_VI_TRI"
        column.DataPropertyName = "MS_VI_TRI"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI", Commons.Modules.TypeLanguage)
        column.Width = 500
        column.ReadOnly = True
        Me.grdCT_VT_XUAT.Columns.Add(column)
        ' TĂNG THÊM 26/06/2008
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_VT_NCC"
        column.DataPropertyName = "MS_VT_NCC"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VT_NCC", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        Me.grdCT_VT_XUAT.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "XUAT_XU"
        column.DataPropertyName = "XUAT_XU"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XUAT_XU", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        column.Width = 150
        Me.grdCT_VT_XUAT.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "ID_XUAT"
        column.DataPropertyName = "ID_XUAT"
        column.ReadOnly = True
        column.Visible = False
        Me.grdCT_VT_XUAT.Columns.Add(column)


        column = New DataGridViewTextBoxColumn
        column.Name = "DON_GIA"
        column.DataPropertyName = "DON_GIA"
        column.Width = 100
        column.ReadOnly = True
        column.DefaultCellStyle.Format = "##,#0.0#"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCT_VT_XUAT.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "TEN_NGOAI_TE"
        column.ReadOnly = True
        column.DataPropertyName = "TEN_NGOAI_TE"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGOAI_TE", Commons.Modules.TypeLanguage)
        column.Width = 70
        Me.grdCT_VT_XUAT.Columns.Add(column)
        Try
            Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Sub LOAD_DON_HANG_XUAT_VAT()
        Me.lstDonHangXuatVT = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_DON_HANG_XUAT_VAT_TU", MS_DH_XUAT_PT))

        For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
            Dim lstTemp As List(Of CHI_TIET_VAT_TU_XUAT_Info) = Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu_Chi_Tiet(MS_KHO, Me.MS_DH_XUAT_PT, Me.lstDonHangXuatVT.Item(i).MS_PT)
            Load_So_Luong_Ton_Kho_Vat_Tu(Me.lstDonHangXuatVT.Item(i).MS_PT)
            For j As Integer = 0 To lstTemp.Count - 1
                Dim Flag As Boolean = True
                For z As Integer = 0 To Me.lstCTVTXuat.Count - 1
                    If Me.lstCTVTXuat.Item(z).MS_VI_TRI = lstTemp.Item(j).MS_VI_TRI _
                        And Me.lstCTVTXuat.Item(z).MS_DH_NHAP_PT = lstTemp.Item(j).MS_DH_NHAP_PT _
                        And Me.lstCTVTXuat.Item(z).ID_XUAT = lstTemp.Item(j).ID_XUAT Then
                        Me.lstCTVTXuat.Item(z).SL_VT = lstTemp.Item(j).SL_VT
                        Me.lstCTVTXuat.Item(z).SL_XUAT = lstTemp.Item(j).SL_XUAT
                        Me.lstCTVTXuat.Item(z).GHI_CHU = lstTemp.Item(j).GHI_CHU
                        Flag = False
                        Exit For
                    End If
                Next
                If Flag = True Then
                    Me.lstCTVTXuat.Insert(0, lstTemp.Item(j))
                End If
            Next
            Me.hasDataCTXuatVT.Add(Me.lstDonHangXuatVT.Item(i).MS_PT, Me.lstCTVTXuat)
        Next
    End Sub

    Function CreateQuery()
        Dim sql = "SELECT DISTINCT PT.MS_PT, PT.MS_PT_CTY, PT.MS_PT_NCC, PT.TEN_PT,DV.TEN_1 AS DVT,ISNULL(KY_PB,0) AS  KY_PB "
        Dim from As String = " FROM  IC_DON_HANG_NHAP DHN INNER JOIN IC_DON_HANG_NHAP_VAT_TU NVT ON DHN.MS_DH_NHAP_PT=NVT.MS_DH_NHAP_PT " &
        " INNER JOIN IC_KHO KHO ON KHO.MS_KHO=DHN.MS_KHO INNER JOIN IC_PHU_TUNG PT ON PT.MS_PT=NVT.MS_PT INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG LPT ON PT.MS_PT = LPT.MS_PT " &
        " INNER JOIN LOAI_PHU_TUNG ON LPT.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN NHOM_LOAI_PHU_TUNG  " &
        " ON NHOM_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN USERS ON NHOM_LOAI_PHU_TUNG.GROUP_ID = USERS.GROUP_ID " &
        " INNER JOIN DON_VI_TINH DV ON DV.DVT=PT.DVT  INNER JOIN VI_TRI_KHO_VAT_TU VTKVT ON NVT.MS_DH_NHAP_PT=VTKVT.MS_DH_NHAP_PT AND NVT.MS_PT=VTKVT.MS_PT   INNER JOIN " &
        "  dbo.LOAI_VT ON PT.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT  "

        Dim condition As String = " WHERE ISNULL(ACTIVE_PT,0) = 1 AND CONVERT(DATETIME,CONVERT(NVARCHAR(2), DAY(NGAY))+'/'+ CONVERT(NVARCHAR(2),MONTH(NGAY))+'/'+ CONVERT(NVARCHAR(4),YEAR(NGAY))+ ' ' + CONVERT(NVARCHAR(2),DATEPART(hour, GIO))+':'+ CONVERT(NVARCHAR(2),DATEPART(MINUTE, GIO)),103) <= '" & NGAY_XUA.ToString("MM/dd/yyyy HH:mm:ss") & "' AND USERNAME = '" + Commons.Modules.UserName + "' AND DHN.LOCK=1 AND VTKVT.SL_VT>0 AND VTKVT.MS_KHO=" + MS_KHO.ToString
        Dim temp As String = ""
        If Me.lstVITRI_KHO_VATTU_Filter.Count > 0 Then
            temp = "  AND PT.MS_PT NOT IN ("
            For I As Integer = 0 To Me.lstVITRI_KHO_VATTU_Filter.Count - 1
                If I = 0 Then
                    temp += "'" + Me.lstVITRI_KHO_VATTU_Filter.Item(I).MS_PT + "'"
                Else
                    temp += ", '" + Me.lstVITRI_KHO_VATTU_Filter.Item(I).MS_PT + "'"
                End If
            Next
            temp += ")  "
        End If

        If dangxuat = 8 Then
            condition = condition + " AND dbo.LOAI_VT.VAT_TU = 1"
        End If

        sql = sql + from + condition + temp
        strPickList = sql
        Return sql
    End Function

    Sub Load_So_Luong_Ton_Kho_Vat_Tu(ByVal MS_PT As String)
        If cbDDH.EditValue = "-1" Then
            Me.lstCTVTXuat = QLBusinessDataController.FillCollection(Of CHI_TIET_VAT_TU_XUAT_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_SO_LUONG_TON_KHO_VAT_TU", MS_PT, MS_KHO, NGAY_XUA, chkGoodsReceive.Checked, DBNull.Value))
        Else
            Me.lstCTVTXuat = QLBusinessDataController.FillCollection(Of CHI_TIET_VAT_TU_XUAT_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_SO_LUONG_TON_KHO_VAT_TU", MS_PT, MS_KHO, NGAY_XUA, chkGoodsReceive.Checked, cbDDH.EditValue))
        End If
    End Sub

    Sub Load_DDH()
        Try
            '
            Dim tbDDH As DataTable = New DataTable()
            Dim Sql As String
            Sql = "SELECT DISTINCT A.MS_DON_DAT_HANG, A.MS_DON_DAT_HANG AS DDH " &
                        " FROM         dbo.DON_DAT_HANG AS A INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP AS B ON A.MS_DON_DAT_HANG = B.MS_DDH INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU AS C ON B.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS D ON C.MS_DH_NHAP_PT = D.MS_DH_NHAP_PT AND C.MS_PT = D.MS_PT AND  " &
                        " C.ID = D.ID INNER JOIN " &
                        " dbo.VI_TRI_KHO_VAT_TU AS E ON D.MS_DH_NHAP_PT = E.MS_DH_NHAP_PT AND D.MS_PT = E.MS_PT AND D.ID = E.ID AND  " &
                        " D.MS_VI_TRI = E.MS_VI_TRI And B.MS_KHO = E.MS_KHO " &
                        " WHERE     (A.TRANG_THAI >= 3) AND (CONVERT(DATETIME, CONVERT(NVARCHAR(2), DAY(B.NGAY)) + '/' + CONVERT(NVARCHAR(2), MONTH(B.NGAY))  " &
                        " + '/' + CONVERT(NVARCHAR(4), YEAR(B.NGAY)) + ' ' + CONVERT(NVARCHAR(2), DATEPART(hour, B.GIO)) + ':' + CONVERT(NVARCHAR(2),  " &
                        " DATEPART(MINUTE, B.GIO)), 103) <= '" & NGAY_XUA.ToString("MM/dd/yyyy HH:mm:ss") & "') " &
                        " AND E.MS_KHO = " + MS_KHO.ToString() + " AND E.SL_VT > 0 ORDER BY A.MS_DON_DAT_HANG DESC"
            'tbDDH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _
            '        "SELECT DISTINCT MS_DON_DAT_HANG,MS_DON_DAT_HANG as DDH FROM dbo.DON_DAT_HANG INNER JOIN dbo.IC_DON_HANG_NHAP ON dbo.DON_DAT_HANG.MS_DON_DAT_HANG = dbo.IC_DON_HANG_NHAP.MS_DDH WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(2), DAY(NGAY))+'/'+ CONVERT(NVARCHAR(2),MONTH(NGAY))+'/'+ CONVERT(NVARCHAR(4),YEAR(NGAY))+ ' ' + CONVERT(NVARCHAR(2),DATEPART(hour, GIO))+':'+ CONVERT(NVARCHAR(2),DATEPART(MINUTE, GIO)),103) <= '" & NGAY_XUA.ToString("MM/dd/yyyy HH:mm:ss") & "' AND TRANG_THAI >= 3 ORDER BY MS_DON_DAT_HANG DESC "))

            tbDDH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))

            Dim dtRow As DataRow
            dtRow = tbDDH.NewRow
            dtRow(0) = -1
            dtRow(1) = " < ALL > "
            tbDDH.Rows.InsertAt(dtRow, 0)
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbDDH, tbDDH, "MS_DON_DAT_HANG", "DDH", "")
            cbDDH.Properties.ShowHeader = False
            'cbDDH.DataSource = tbDDH
            'cbDDH.DisplayMember = "DDH"
            'cbDDH.ValueMember = "MS_DON_DAT_HANG"
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_DHNPT()
        Try
            Dim Sql As String
            Sql = "SELECT DISTINCT dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT,dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT as DHNPT " &
                    " FROM dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET ON  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU.ID = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID INNER JOIN " &
                    " dbo.VI_TRI_KHO_VAT_TU ON dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.VI_TRI_KHO_VAT_TU.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.VI_TRI_KHO_VAT_TU.ID AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI AND  " &
                    " dbo.IC_DON_HANG_NHAP.MS_KHO = dbo.VI_TRI_KHO_VAT_TU.MS_KHO " &
                    " WHERE LOCK = 1 AND CONVERT(DATETIME,CONVERT(NVARCHAR(2), DAY(NGAY))+'/'+ CONVERT(NVARCHAR(2),MONTH(NGAY))+'/'+ CONVERT(NVARCHAR(4),YEAR(NGAY))+ ' ' + CONVERT(NVARCHAR(2),DATEPART(hour, GIO))+':'+ CONVERT(NVARCHAR(2),DATEPART(MINUTE, GIO)),103) <= '" & NGAY_XUA.ToString("MM/dd/yyyy HH:mm:ss") & "' AND dbo.VI_TRI_KHO_VAT_TU.MS_KHO = " + MS_KHO.ToString() + " AND dbo.VI_TRI_KHO_VAT_TU.SL_VT > 0 ORDER BY dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT DESC "
            Dim tbDHN As DataTable = New DataTable()
            tbDHN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
            Dim dtRow As DataRow
            dtRow = tbDHN.NewRow
            dtRow(0) = -1
            dtRow(1) = " < ALL > "
            tbDHN.Rows.InsertAt(dtRow, 0)
            'cbDDH.DataSource = tbDHN
            'cbDDH.DisplayMember = "DHNPT"
            'cbDDH.ValueMember = "MS_DH_NHAP_PT"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbDDH, tbDHN, "MS_DH_NHAP_PT", "DHNPT", "")
            cbDDH.Properties.ShowHeader = False
        Catch ex As Exception
        End Try
    End Sub

    Sub Load_Vat_Tu()
        FormatGridDS_Phu_Tung()
        Dim temp As String = ""
        If Me.lstDonHangXuatVT.Count > 0 Then
            temp = "  AND PT.MS_PT NOT IN ("
            For I As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                If I = 0 Then
                    temp += "'" + Me.lstDonHangXuatVT.Item(I).MS_PT + "'"
                Else
                    temp += ", '" + Me.lstDonHangXuatVT.Item(I).MS_PT + "'"
                End If
            Next
            temp += ") "
        End If

        temp = temp + "  ORDER BY PT.MS_PT, PT.TEN_PT"
        Dim sss As String = Me.CreateQuery + temp
        Me.lstVTKho = QLBusinessDataController.FillCollection(Of VAT_TU_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_SEARCH", Me.CreateQuery + temp))



        Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho
        If Me.grdDS_PHU_TUNG.RowCount > 0 Then
            Me.grdDS_PHU_TUNG.Rows(0).Selected = True
            rowIndexVT = 0
        End If
    End Sub

    'Private Sub cbDDH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDDH.SelectedIndexChanged
    'End Sub

    Function Load_Phu_Tung(ByVal MS_PT As String) As IC_PHU_TUNG_Info
        Dim objPhuTung As IC_PHU_TUNG_Info = QLBusinessDataController.FillObject(Of IC_PHU_TUNG_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_PHU_TUNG", MS_PT))
        Return objPhuTung
    End Function

    Private Sub cboVTU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Vat_Tu()
    End Sub

    Private Sub cboLoaiTB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Vat_Tu()
    End Sub

    Private Sub btnXEM_HINH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.grdDS_PHU_TUNG.RowCount < 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VAT_TU_CAN_XEM_HINH", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            Dim objPTUNG As IC_PHU_TUNG_Info = Me.Load_Phu_Tung(Me.grdDS_PHU_TUNG.CurrentRow.Cells("MS_PT").Value.ToString)
            If objPTUNG.ANH_PT Is Nothing Or objPTUNG.ANH_PT = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CO_DUONG_DAN_HINH", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            System.Diagnostics.Process.Start(objPTUNG.ANH_PT)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgINVALID_PATH", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnXuat_Tu_Dong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuat_Tu_Dong.Click
        If Me.grdDS_PHU_TUNG_CHON.RowCount > 0 Then
            For K As Integer = 0 To Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                If Double.Parse(Me.grdDS_PHU_TUNG_CHON.Rows(K).Cells("SO_LUONG_THUC_XUAT").Value) <= 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLNHAP", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.grdDS_PHU_TUNG_CHON.Rows(K).Cells("SO_LUONG_THUC_XUAT").Selected = True
                    Exit Sub
                End If
            Next
            For m As Integer = 0 To Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                If Me.lstDonHangXuatVT.Item(m).SO_LUONG_THUC_XUAT > 0 Then
                    If Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(m).MS_PT) IsNot Nothing Then
                        Me.lstCTVTXuat = CType(Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(m).MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                    Else
                        Load_So_Luong_Ton_Kho_Vat_Tu(Me.lstDonHangXuatVT.Item(m).MS_PT)
                    End If

                    Dim SL_Xuat As Double = 0
                    For i As Integer = 0 To Me.lstCTVTXuat.Count - 1
                        If Me.lstCTVTXuat.Item(i).SL_VT + SL_Xuat <= Me.lstDonHangXuatVT.Item(m).SO_LUONG_THUC_XUAT Then
                            SL_Xuat += Me.lstCTVTXuat.Item(i).SL_VT
                            Me.lstCTVTXuat.Item(i).SL_XUAT = Me.lstCTVTXuat.Item(i).SL_VT.ToString
                        Else
                            If Me.lstDonHangXuatVT.Item(m).SO_LUONG_THUC_XUAT - SL_Xuat <> 0 Then
                                Me.lstCTVTXuat.Item(i).SL_XUAT = Me.lstDonHangXuatVT.Item(m).SO_LUONG_THUC_XUAT - SL_Xuat
                                SL_Xuat += Me.lstDonHangXuatVT.Item(m).SO_LUONG_THUC_XUAT - SL_Xuat
                            Else
                                Me.lstCTVTXuat.Item(i).SL_XUAT = ""
                            End If
                        End If
                    Next
                    Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                    Me.FormatGridCT_VT_Xuat()
                    Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
                Else
                    Dim traloi As String
                    traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNhapSLthuc", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If traloi = vbNo Then
                        Me.grdDS_PHU_TUNG_CHON.Rows(m).Cells("SO_LUONG_THUC_XUAT").Selected = True
                        Return
                    End If
                End If
            Next
            If grdDS_PHU_TUNG_CHON.Rows.Count > 0 Then
                Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Selected = True
                Me.lstCTVTXuat = CType(Me.hasDataCTXuatVT.Item(Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Value), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                FormatGridCT_VT_Xuat()
                Me.grdDS_PHU_TUNG_CHON.Rows(Me.grdDS_PHU_TUNG_CHON.RowCount - 1).Selected = True
            End If
        End If


        For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
            If Me.lstDonHangXuatVT.Item(i).SO_LUONG_THUC_XUAT = 0 Then
                XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_SO_LUONG_THUC_XUAT", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(i).MS_PT) Is Nothing Then
                XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_CHI_TIET_XUAT_VAT_TU", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                Dim SL_XUAT_CT As Double = 0
                Dim lstDHX_VTCT_Reulst As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
                Dim lstDHX_VTCT As List(Of CHI_TIET_VAT_TU_XUAT_Info) = CType(Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(i).MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                For j As Integer = 0 To lstDHX_VTCT.Count - 1
                    If lstDHX_VTCT.Item(j).SL_XUAT IsNot Nothing And lstDHX_VTCT.Item(j).SL_XUAT <> "" Then
                        SL_XUAT_CT += Double.Parse(lstDHX_VTCT.Item(j).SL_XUAT)
                        lstDHX_VTCT_Reulst.Add(lstDHX_VTCT.Item(j))
                    End If
                Next
                If Me.lstDonHangXuatVT.Item(i).SO_LUONG_THUC_XUAT <> SL_XUAT_CT Then
                    XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuacandoiSL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If

        Next
    End Sub

    Private Sub btnThuc_Hien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuc_Hien.Click
        Try

            Dim hasDataCTXuatVT_Result As New Hashtable
            For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                If Me.lstDonHangXuatVT.Item(i).SO_LUONG_THUC_XUAT = 0 Then
                    XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_SO_LUONG_THUC_XUAT", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(i).MS_PT) Is Nothing Then
                    XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_CHI_TIET_XUAT_VAT_TU", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Return
                Else
                    Dim SL_XUAT_CT As Double = 0
                    Dim lstDHX_VTCT_Reulst As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
                    Dim lstDHX_VTCT As List(Of CHI_TIET_VAT_TU_XUAT_Info) = CType(Me.hasDataCTXuatVT.Item(Me.lstDonHangXuatVT.Item(i).MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                    For j As Integer = 0 To lstDHX_VTCT.Count - 1
                        If lstDHX_VTCT.Item(j).SL_XUAT IsNot Nothing And lstDHX_VTCT.Item(j).SL_XUAT <> "" Then
                            SL_XUAT_CT += Double.Parse(lstDHX_VTCT.Item(j).SL_XUAT)
                            lstDHX_VTCT_Reulst.Add(lstDHX_VTCT.Item(j))
                        End If
                    Next
                    If Me.lstDonHangXuatVT.Item(i).SO_LUONG_THUC_XUAT <> SL_XUAT_CT Then
                        XtraMessageBox.Show(Me.lstDonHangXuatVT.Item(i).MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuacandoiSL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    hasDataCTXuatVT_Result.Add(Me.lstDonHangXuatVT.Item(i).MS_PT, lstDHX_VTCT_Reulst)
                End If

            Next
            Dim hasData As New Hashtable
            hasData.Add("DHXVT", CType(Me.grdDS_PHU_TUNG_CHON.DataSource, List(Of IC_DON_HANG_XUAT_VAT_TU_Info)))
            hasData.Add("DHXVTCHT", hasDataCTXuatVT_Result)
            If StrPickNo <> "" Then
                Commons.Modules.SQLString = "DELETE FROM PICK_LIST_CHI_TIET WHERE PICK_NO=" & StrPickNo & " AND MS_KHO='" & MS_KHO.ToString & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Commons.Modules.SQLString = "DELETE FROM PICK_LIST WHERE PICK_NO=" & StrPickNo
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            End If
            Me.callback.Called(hasData)
            Dispose()
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message.ToString(), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnTHOAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTHOAT.Click
        Dispose()
    End Sub
    Private Sub btnMoveVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONNbtnMVT.Click
        Try

            Dim vVT_PT_xoa As String = Me.lstDonHangXuatVT.Item(rowIndexVTChon).MS_PT
            Dim vMS_DHX As String = Me.lstDonHangXuatVT.Item(rowIndexVTChon).MS_DH_XUAT_PT
            If Not vMS_DHX Is Nothing Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoChuyenVT_PT", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Me.grdDS_PHU_TUNG_CHON.RowCount < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG_CHON", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                If grdDS_PHU_TUNG_CHON.SelectedRows.Count < 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSELECT_PHU_TUNG_CHON", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                    Dim sql As String = CreateQuery() + " AND PT.MS_PT='" + Me.lstDonHangXuatVT.Item(rowIndexVTChon).MS_PT + "'"
                    Dim objVatTu As VAT_TU_Info = QLBusinessDataController.FillObject(Of VAT_TU_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_SEARCH", sql))
                    Me.lstVTKho.Add(objVatTu)
                    Me.FormatGridDS_Phu_Tung()
                    Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho
                    Me.grdDS_PHU_TUNG.Rows(0).Selected = True

                    Me.lstDonHangXuatVT.RemoveAt(rowIndexVTChon)
                    Me.FormatGridDS_Phu_Tung_Chon()
                    Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                    Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                    'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False

                    Me.hasDataCTXuatVT.Remove(vVT_PT_xoa)
                    If grdDS_PHU_TUNG_CHON.RowCount > 0 Then
                        If rowIndexVTChon >= 0 Then
                            Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Selected = True
                            Me.lstCTVTXuat = CType(Me.hasDataCTXuatVT.Item(Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Value), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                            Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                            FormatGridCT_VT_Xuat()
                            Try
                                Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
                            Catch ex As Exception

                            End Try

                            MS_PT = Me.grdDS_PHU_TUNG_CHON.Rows(0).Cells("MS_PT").Value
                        End If

                    Else
                        Me.grdCT_VT_XUAT.Columns.Clear()
                        Me.grdCT_VT_XUAT.DataSource = System.DBNull.Value
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        If grdDS_PHU_TUNG_CHON.Rows.Count = 0 Then btnChonVTTuPBT.Enabled = True
        If grdDS_PHU_TUNG_CHON.RowCount <> 0 Then
            chkGoodsReceive.Enabled = False
        Else
            chkGoodsReceive.Enabled = True
        End If
    End Sub

    Private Sub btnAddVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONNbtnAVT.Click
        RemoveHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        If Me.grdDS_PHU_TUNG.RowCount < 1 Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
            Return
        Else
            If Me.grdDS_PHU_TUNG.SelectedRows.Count < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSELECT_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                Dim objDonHangXuatVT As New IC_DON_HANG_XUAT_VAT_TU_Info
                objDonHangXuatVT.MS_PT = Me.lstVTKho(rowIndexVT).MS_PT
                objDonHangXuatVT.TEN_PT = Me.lstVTKho(rowIndexVT).TEN_PT
                objDonHangXuatVT.DVT = Me.lstVTKho(rowIndexVT).DVT
                objDonHangXuatVT.ITEM_CODE = Me.lstVTKho(rowIndexVT).MS_PT_CTY
                objDonHangXuatVT.PART_NO = Me.lstVTKho(rowIndexVT).MS_PT_NCC
                objDonHangXuatVT.TG_PB = Me.lstVTKho(rowIndexVT).KY_PB
                If Commons.Modules.SQLString = "IMPORT" Then
                    objDonHangXuatVT.SO_LUONG_CTU = iSLImport
                    objDonHangXuatVT.SO_LUONG_THUC_XUAT = iSLImport
                End If


                Dim Flag As Boolean = True
                For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                    If Me.lstDonHangXuatVT.Item(i).MS_PT = objDonHangXuatVT.MS_PT Then
                        Flag = False
                        Exit For
                    End If
                Next
                If Flag = True Then
                    Me.lstDonHangXuatVT.Add(objDonHangXuatVT)
                End If


                MS_PT = objDonHangXuatVT.MS_PT
                Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                Me.FormatGridDS_Phu_Tung_Chon()
                Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
                If Me.grdDS_PHU_TUNG_CHON.Rows.Count >= 1 Then
                    Me.grdDS_PHU_TUNG_CHON.Rows(grdDS_PHU_TUNG_CHON.Rows.Count - 1).Cells("MS_PT").Selected = True
                End If
                '
                rowIndexVTChon = Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                Load_So_Luong_Ton_Kho_Vat_Tu(objDonHangXuatVT.MS_PT)
                MS_PT = objDonHangXuatVT.MS_PT
                Me.hasDataCTXuatVT.Remove(MS_PT)
                Me.hasDataCTXuatVT.Add(MS_PT, Me.lstCTVTXuat)

                Dim s As Integer = Me.hasDataCTXuatVT.Count

                Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                FormatGridCT_VT_Xuat()

                Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
                Me.grdCT_VT_XUAT.Columns("ID_XUAT").Visible = False

                Me.lstVTKho.RemoveAt(rowIndexVT)

                Me.FormatGridDS_Phu_Tung()
                Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho

                Try
                    grdDS_PHU_TUNG.CurrentCell() = Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Cells("MS_PT")
                    Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Selected = True
                Catch ex As Exception
                    If Me.grdDS_PHU_TUNG.RowCount > 0 Then
                        grdDS_PHU_TUNG.CurrentCell() = Me.grdDS_PHU_TUNG.Rows(rowIndexVT - 1).Cells("MS_PT")
                        Me.grdDS_PHU_TUNG.Rows(rowIndexVT - 1).Selected = True
                    End If
                End Try
            End If
        End If

        AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        If grdDS_PHU_TUNG_CHON.RowCount <> 0 Then
            chkGoodsReceive.Enabled = False

        Else
            chkGoodsReceive.Enabled = True
        End If

    End Sub

    Private Sub grdDS_PHU_TUNG_CHON_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDS_PHU_TUNG_CHON.CellClick
        Try
            If e.RowIndex >= 0 Then Me.grdDS_PHU_TUNG_CHON.Rows(e.RowIndex).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDS_PHU_TUNG_CHON_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDS_PHU_TUNG_CHON.DataError, grdCT_VT_XUAT.DataError
        e.Cancel = True
    End Sub

    Private Sub grdDS_PHU_TUNG_CHON_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDS_PHU_TUNG_CHON.CellValidating
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.ColumnIndex = -1 Then Exit Sub

            grdDS_PHU_TUNG_CHON.SelectionMode = DataGridViewSelectionMode.CellSelect ' DataGridViewSelectionMode.RowHeaderSelect
            If btnTHOAT.Focused Then
                Exit Sub
            End If
            Dim cell As DataGridViewCell = grdDS_PHU_TUNG_CHON.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                Dim ctr As Control = Me.grdDS_PHU_TUNG_CHON.EditingControl
                Select Case Me.grdDS_PHU_TUNG_CHON.Columns(e.ColumnIndex).Name
                    Case "SO_LUONG_CTU"
                        Try
                            Dim SL_Xuat_CTU As Double = Double.Parse(ctr.Text)
                            If SL_Xuat_CTU < 0 Then
                                ' Số lượng xuất chứng từ phải lớn hơn 0 !
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLchungtu_am", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                ctr.Text = 0
                                e.Cancel = True
                                Exit Sub
                            End If
                            Dim SL_TON_KHO As Double = 0
                            For I As Integer = 0 To Me.grdCT_VT_XUAT.RowCount - 1
                                If Me.grdCT_VT_XUAT.Rows(I).Cells("SL_VT").Value IsNot Nothing Then
                                    SL_TON_KHO += Double.Parse(Me.grdCT_VT_XUAT.Rows(I).Cells("SL_VT").Value.ToString)
                                End If
                            Next
                            If SL_Xuat_CTU > SL_TON_KHO Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLkhongcandoi", Commons.Modules.TypeLanguage) + " : " + SL_TON_KHO.ToString, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                ctr.Text = 0
                                e.Cancel = True
                                Exit Sub
                            End If

                            Me.grdDS_PHU_TUNG_CHON.Rows(e.RowIndex).Cells("SO_LUONG_THUC_XUAT").Value = SL_Xuat_CTU
                        Catch ex As Exception
                            ' Số lượng chứng từ phải là kiểu số !
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLchungtu_sai", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            ctr.Text = 0
                            e.Cancel = True
                            Exit Sub
                        End Try
                        Exit Select
                    Case "SO_LUONG_THUC_XUAT"
                        Try
                            Dim SL_Thuc_Xuat As Double = Double.Parse(ctr.Text)
                            If SL_Thuc_Xuat < 0 Then
                                ' Số lượng thực xuất phải lớn hơn 0 !
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLthucxuat_am", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                ctr.Text = 0
                                e.Cancel = True
                                Exit Sub
                            End If
                            Dim SL_Xuat_CTU As Double = Double.Parse(Me.grdDS_PHU_TUNG_CHON.Rows(e.RowIndex).Cells("SO_LUONG_CTU").Value.ToString)
                            If SL_Thuc_Xuat > SL_Xuat_CTU Then
                                ' Số lượng thực xuất lớn hơn số lượng chứng từ ! Bạn có muốn tiếp tục không ?
                                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNhapSLthuc", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    ctr.Text = 0
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                            Dim SL_TON_KHO As Double = 0
                            For I As Integer = 0 To Me.grdCT_VT_XUAT.RowCount - 1
                                If Me.grdCT_VT_XUAT.Rows(I).Cells("SL_VT").Value IsNot Nothing Then
                                    SL_TON_KHO += Double.Parse(Me.grdCT_VT_XUAT.Rows(I).Cells("SL_VT").Value.ToString)
                                End If
                            Next
                            If SL_Thuc_Xuat > SL_TON_KHO Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage) + " : " + SL_TON_KHO.ToString, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                ctr.Text = 0
                                e.Cancel = True
                                Exit Sub
                            End If
                        Catch ex As Exception
                            ' Số lượng thực xuất phải là kiểu số !
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLthucxuat_sai", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            ctr.Text = 0
                            e.Cancel = True
                            Exit Sub
                        End Try
                        Exit Select
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdCT_VT_XUAT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCT_VT_XUAT.CellValidating
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.ColumnIndex = -1 Then Exit Sub


            Dim cell As DataGridViewCell = Me.grdCT_VT_XUAT.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                Dim ctr As Control = Me.grdCT_VT_XUAT.EditingControl
                Select Case Me.grdCT_VT_XUAT.Columns(e.ColumnIndex).Name
                    Case "SL_XUAT"
                        Try
                            If ctr.Text <> "" Then
                                Dim SL_Xuat As Double = Double.Parse(ctr.Text)
                                If SL_Xuat < 0 Then
                                    ctr.Text = ""
                                    e.Cancel = True
                                End If
                                Dim SL_VT As Double = Double.Parse(Me.grdCT_VT_XUAT.Rows(e.RowIndex).Cells("SL_VT").Value.ToString)
                                If SL_Xuat > SL_VT Then
                                    ctr.Text = ""
                                    e.Cancel = True
                                End If
                                For I As Integer = 0 To Me.grdCT_VT_XUAT.RowCount - 1
                                    If Me.grdCT_VT_XUAT.Rows(I).Cells("SL_XUAT").Value IsNot Nothing And I <> e.RowIndex Then
                                        If grdCT_VT_XUAT.Rows(I).Cells("SL_XUAT").Value.ToString <> "" Then
                                            SL_Xuat += Double.Parse(Me.grdCT_VT_XUAT.Rows(I).Cells("SL_XUAT").Value.ToString)
                                        End If
                                    End If
                                Next
                                If Me.grdDS_PHU_TUNG_CHON.Rows(Me.rowIndexVTChon).Cells("SO_LUONG_THUC_XUAT").Value IsNot Nothing Then
                                    If SL_Xuat > Double.Parse(Me.grdDS_PHU_TUNG_CHON.Rows(Me.rowIndexVTChon).Cells("SO_LUONG_THUC_XUAT").Value.ToString) Then
                                        ctr.Text = ""
                                        e.Cancel = True
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            ctr.Text = ""
                            e.Cancel = True
                        End Try
                        Exit Select
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub
    Dim thutu As Integer = -1
    Dim GiaTri As String = ""


#Region "SUB CLASS"
    Class VAT_TU_Info
        Private _MS_PT As String
        Private _MS_PT_CTY As String
        Private _MS_PT_NCC As String
        Private _TEN_PT As String
        Private _DVT As String
        Private _KY_PB As Integer

        Public Sub New()

        End Sub
        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
            End Set
        End Property
        Public Property MS_PT_CTY() As String
            Get
                Return _MS_PT_CTY
            End Get
            Set(ByVal value As String)
                _MS_PT_CTY = value
            End Set
        End Property
        Public Property MS_PT_NCC() As String
            Get
                Return _MS_PT_NCC
            End Get
            Set(ByVal value As String)
                _MS_PT_NCC = value
            End Set
        End Property
        Public Property TEN_PT() As String
            Get
                Return _TEN_PT
            End Get
            Set(ByVal value As String)
                _TEN_PT = value
            End Set
        End Property
        Public Property DVT() As String
            Get
                Return _DVT
            End Get
            Set(ByVal value As String)
                _DVT = value
            End Set
        End Property
        Public Property KY_PB() As Integer
            Get
                Return _KY_PB
            End Get
            Set(ByVal value As Integer)
                _KY_PB = value
            End Set
        End Property

    End Class
#End Region

    Private Sub cboLoaiTB_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Load_Vat_Tu()
    End Sub

    Private Sub grdDS_PHU_TUNG_CHON_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If e.RowIndex >= 0 Then
                Me.grdDS_PHU_TUNG_CHON.Rows(e.RowIndex).Selected = True
                rowIndexVTChon = e.RowIndex
                MS_PT = Me.lstDonHangXuatVT.Item(e.RowIndex).MS_PT
                Me.lstCTVTXuat = CType(Me.hasDataCTXuatVT.Item(MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                Me.FormatGridCT_VT_Xuat()
                Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnChonTuPickList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTuPickList.Click
        Dim blnLost As Boolean = True
        FrmDanhSachPickList.SQLPickList = strPickList.ToString
        FrmDanhSachPickList.MS_KHO = MS_KHO.ToString
        If FrmDanhSachPickList.ShowDialog = Windows.Forms.DialogResult.OK Then
            If FrmDanhSachPickList.grdPickList.Rows.Count > 0 Then
                StrPickNo = FrmDanhSachPickList.grdPickList.CurrentRow.Cells("PICK_NO").Value
                Dim dtReader As SqlDataReader
                Dim i As Integer


                Commons.Modules.SQLString = "SELECT DISTINCT MS_PT FROM PICK_LIST_CHI_TIET WHERE PICK_NO=" & StrPickNo & " AND MS_KHO='" & MS_KHO.ToString & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                While dtReader.Read
                    For i = grdDS_PHU_TUNG.RowCount - 1 To 0 Step -1
                        If grdDS_PHU_TUNG.Rows(i).Cells("MS_PT").Value = dtReader.Item("MS_PT") Then
                            rowIndexVT = i
                            layPickList()
                            blnLost = False
                            Exit For
                        Else
                            blnLost = True
                        End If

                    Next
                End While
                dtReader.Close()
                AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
                If blnLost Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThongBao", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If
        End If
    End Sub
    Sub layPickList()
        RemoveHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        Dim objDonHangXuatVT As New IC_DON_HANG_XUAT_VAT_TU_Info
        Dim i As Integer
        objDonHangXuatVT.MS_PT = Me.lstVTKho(rowIndexVT).MS_PT
        objDonHangXuatVT.TEN_PT = Me.lstVTKho(rowIndexVT).TEN_PT
        objDonHangXuatVT.DVT = Me.lstVTKho(rowIndexVT).DVT
        objDonHangXuatVT.ITEM_CODE = Me.lstVTKho(rowIndexVT).MS_PT_CTY
        objDonHangXuatVT.PART_NO = Me.lstVTKho(rowIndexVT).MS_PT_NCC
        Dim Flag As Boolean = True
        For i = 0 To Me.lstDonHangXuatVT.Count - 1
            If Me.lstDonHangXuatVT.Item(i).MS_PT = objDonHangXuatVT.MS_PT Then
                Flag = False
                Exit For
            End If
        Next
        If Flag = True Then
            Me.lstDonHangXuatVT.Add(objDonHangXuatVT)
        End If

        MS_PT = objDonHangXuatVT.MS_PT
        Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
        Me.FormatGridDS_Phu_Tung_Chon()
        Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
        'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
        Me.grdDS_PHU_TUNG_CHON.Rows(Me.grdDS_PHU_TUNG_CHON.RowCount - 1).Selected = True

        rowIndexVTChon = Me.grdDS_PHU_TUNG_CHON.RowCount - 1
        Load_So_Luong_Ton_Kho_Vat_Tu(objDonHangXuatVT.MS_PT)
        MS_PT = objDonHangXuatVT.MS_PT
        Me.hasDataCTXuatVT.Remove(MS_PT)
        Me.hasDataCTXuatVT.Add(MS_PT, Me.lstCTVTXuat)

        Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
        FormatGridCT_VT_Xuat()
        Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
        Me.grdCT_VT_XUAT.Columns("MS_DH_NHAP_PT").Visible = False
        Me.lstVTKho.RemoveAt(rowIndexVT)

        Me.FormatGridDS_Phu_Tung()
        Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho

        Try
            Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Selected = True
        Catch ex As Exception
            If Me.grdDS_PHU_TUNG.RowCount > 0 Then
                Me.grdDS_PHU_TUNG.Rows(rowIndexVT - 1).Selected = True
            End If
        End Try
    End Sub
    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub
    Dim txtPhieuXuat As TextBox
    Private Sub grdDS_PHU_TUNG_CHON_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDS_PHU_TUNG_CHON.EditingControlShowing
        Try
            If Me.grdDS_PHU_TUNG_CHON.CurrentCellAddress.X = 3 Or Me.grdDS_PHU_TUNG_CHON.CurrentCellAddress.X = 4 Then
                txtPhieuXuat = e.Control

                RemoveHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdCT_VT_XUAT_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCT_VT_XUAT.EditingControlShowing
        Try
            If Me.grdCT_VT_XUAT.CurrentCellAddress.X = 5 Then
                txtPhieuXuat = e.Control

                RemoveHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtPhieuXuat.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnChonVTTuPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonVTTuPBT.Click
        RemoveHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        Try
            If Me.grdDS_PHU_TUNG.RowCount < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Return
            Else
                If MS_PBT = "" Or MS_PBT = "-1" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PBT_NULL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Exit Sub
                End If

                Dim str As String = "", objReader As SqlDataReader, sBT As String = "CHON_VTX" & Commons.Modules.UserName
                Dim bCoVT As Boolean = False
                Dim dtTmp As New DataTable
                'Them cot MS_PT_TT trong phieu bao tri cong viec, nen khi chon xuat kho them cac phu tung thay the vao
                Commons.Modules.ObjSystems.XoaTable(sBT)
                Try
                    str = " SELECT dbo.LOAI_VT.VAT_TU, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, SUM (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_KH,0)) AS SL_KH, SUM ( ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_TT,0)) AS SL_TT INTO " & sBT &
                          " FROM dbo.IC_PHU_TUNG INNER JOIN dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT INNER JOIN dbo.PHIEU_BAO_TRI INNER JOIN " &
                               "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI ON " &
                               "dbo.IC_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND " &
                               "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV AND " &
                               "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN " &
                          "WHERE dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = '-1' AND STT_SERVICE IS NULL" &
                          " GROUP BY dbo.LOAI_VT.VAT_TU, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)


                    str = " SELECT * FROM
                            (SELECT        MS_PT_TT, SUM(ISNULL(SL_KH, 0)) AS SL_KH, SUM(ISNULL(SL_TT, 0)) AS SL_TT
                             FROM            dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG
                            WHERE        (MS_PHIEU_BAO_TRI = '" & MS_PBT & "') AND (ISNULL(MS_PT_TT, N'') <> '')
                            GROUP BY MS_PT_TT
                            UNION
                            SELECT        MS_PT_TT, SUM(ISNULL(SL_KH, 0)) AS SL_KH, SUM(ISNULL(SL_TT, 0)) AS SL_TT
                            FROM            PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG
                            WHERE        (MS_PHIEU_BAO_TRI = '" & MS_PBT & "') AND (ISNULL(MS_PT_TT, N'') <> '')
                            GROUP BY MS_PT_TT) A "
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                    For Each drRow As DataRow In dtTmp.Rows
                        str = drRow("MS_PT_TT").ToString().Replace(",", "','")
                        str = " INSERT INTO " & sBT & " SELECT B.VAT_TU, A.MS_PT, ISNULL(" & drRow("SL_KH").ToString() & ",0) AS SL_KH, ISNULL(" & drRow("SL_TT").ToString() & ",0) AS SL_TT FROM dbo.IC_PHU_TUNG AS A INNER JOIN dbo.LOAI_VT AS B ON A.MS_LOAI_VT = B.MS_LOAI_VT WHERE MS_PT IN ('" & str & "') "
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

                    Next
                Catch ex As Exception

                End Try
                Dim sVT As String = ""
                objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spChonPhuTungXuat", MS_PBT, sBT)
                While objReader.Read
                    For i As Integer = 0 To Me.grdDS_PHU_TUNG.RowCount - 1
                        If Me.grdDS_PHU_TUNG.Rows(i).Cells("MS_PT").Value = objReader.Item("MS_PT") Then
                            grdDS_PHU_TUNG.Rows(i).Selected = True
                            rowIndexVT = i
                            btnChonVTTuPBT.Enabled = False
                            Commons.Modules.SQLString = "IMPORT"
                            iSLImport = objReader.Item("SL_KH")
                            btnAddVT_Click(sender, e)
                            iSLImport = Nothing
                            Commons.Modules.SQLString = ""
                            bCoVT = True
                            GoTo NEXT_WHILE
                        End If
                    Next
                    If sVT = "" Then sVT = objReader.Item("MS_PT").ToString.ToUpper Else sVT = sVT + vbCrLf + objReader.Item("MS_PT").ToString().ToUpper
NEXT_WHILE:
                    'For j As Integer = 0 To Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                    '    If Me.grdDS_PHU_TUNG_CHON.Rows(j).Cells("MS_PT").Value = objReader.Item("MS_PT") Then
                    '        grdDS_PHU_TUNG_CHON.Rows(j).Cells("SO_LUONG_CTU").Value = objReader.Item("SL_KH")
                    '        grdDS_PHU_TUNG_CHON.Rows(j).Cells("SO_LUONG_THUC_XUAT").Value = objReader.Item("SL_KH")
                    '        Exit For
                    '    End If
                    'Next

                End While


                If bCoVT = False Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAD_VAT_TU_NULL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If sVT <> "" Then XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCacPhuTungSauKhongCoSoLuongTon", Commons.Modules.TypeLanguage) + vbCrLf + sVT)
                End If


            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtNCC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNCC.KeyPress
        Try
            If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
                Try

                    For Each row As DataGridViewRow In grdDS_PHU_TUNG.Rows
                        If (row.Cells(0).Value.ToString().ToLower().Contains(txtNCC.Text.Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)
                            GoTo breakLoop
                        ElseIf (row.Cells(1).Value.ToString().ToLower().Contains(txtNCC.Text.Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)
                            GoTo breakLoop
                        ElseIf (row.Cells(2).Value.ToString().ToLower().Contains(txtNCC.Text.Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)
                            GoTo breakLoop
                        ElseIf (row.Cells(3).Value.ToString().ToLower().Contains(txtNCC.Text.Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)
                            GoTo breakLoop
                        ElseIf (row.Cells(4).Value.ToString().ToLower().Contains(txtNCC.Text.Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)
                            GoTo breakLoop
                        End If
                    Next
breakLoop:
                    Return

                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkGoodsReceive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGoodsReceive.CheckedChanged
        If (chkGoodsReceive.Checked) Then
            Load_DHNPT()
        Else
            Load_DDH()
        End If
        cbDDH.Enabled = Not cbDDH.Enabled

        If chkGoodsReceive.Checked Then
            Try
                If cbDDH.EditValue = "-1" Or cbDDH.EditValue = Nothing Then
                    NONN.Enabled = False
                Else
                    NONN.Enabled = True
                End If
            Catch ex As Exception
                NONN.Enabled = False
            End Try
        Else
            NONN.Enabled = False
        End If


    End Sub

    Private Sub btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONN.Click
        RemoveHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        If Me.grdDS_PHU_TUNG.RowCount < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
            Return
        Else
            While (grdDS_PHU_TUNG.RowCount > 0)
                rowIndexVT = 0
                Dim objDonHangXuatVT As New IC_DON_HANG_XUAT_VAT_TU_Info
                objDonHangXuatVT.MS_PT = Me.lstVTKho(rowIndexVT).MS_PT
                objDonHangXuatVT.TEN_PT = Me.lstVTKho(rowIndexVT).TEN_PT
                objDonHangXuatVT.DVT = Me.lstVTKho(rowIndexVT).DVT
                objDonHangXuatVT.ITEM_CODE = Me.lstVTKho(rowIndexVT).MS_PT_CTY
                objDonHangXuatVT.PART_NO = Me.lstVTKho(rowIndexVT).MS_PT_NCC
                objDonHangXuatVT.TG_PB = Me.lstVTKho(rowIndexVT).KY_PB
                Dim Flag As Boolean = True
                For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                    If Me.lstDonHangXuatVT.Item(i).MS_PT = objDonHangXuatVT.MS_PT Then
                        Flag = False
                        Exit For
                    End If
                Next
                If Flag = True Then
                    Me.lstDonHangXuatVT.Add(objDonHangXuatVT)
                End If


                MS_PT = objDonHangXuatVT.MS_PT
                Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                Me.FormatGridDS_Phu_Tung_Chon()
                Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
                If Me.grdDS_PHU_TUNG_CHON.Rows.Count >= 1 Then
                    Me.grdDS_PHU_TUNG_CHON.Rows(grdDS_PHU_TUNG_CHON.Rows.Count - 1).Cells("MS_PT").Selected = True
                End If
                '
                rowIndexVTChon = Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                Load_So_Luong_Ton_Kho_Vat_Tu(objDonHangXuatVT.MS_PT)
                MS_PT = objDonHangXuatVT.MS_PT
                Me.hasDataCTXuatVT.Remove(MS_PT)
                Me.hasDataCTXuatVT.Add(MS_PT, Me.lstCTVTXuat)

                Dim s As Integer = Me.hasDataCTXuatVT.Count

                Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                FormatGridCT_VT_Xuat()
                Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False

                Me.lstVTKho.RemoveAt(rowIndexVT)

                Me.FormatGridDS_Phu_Tung()
                Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho

                Try
                    grdDS_PHU_TUNG.CurrentCell() = Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Cells("MS_PT")
                    Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Selected = True
                Catch ex As Exception
                    If Me.grdDS_PHU_TUNG.RowCount > 0 Then
                        grdDS_PHU_TUNG.CurrentCell() = Me.grdDS_PHU_TUNG.Rows(rowIndexVT - 1).Cells("MS_PT")
                        Me.grdDS_PHU_TUNG.Rows(rowIndexVT - 1).Selected = True
                    End If
                End Try
            End While

        End If

        AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
        If grdDS_PHU_TUNG_CHON.RowCount <> 0 Then
            chkGoodsReceive.Enabled = False
        Else
            chkGoodsReceive.Enabled = True
        End If

    End Sub

    Private Sub grdDS_PHU_TUNG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDS_PHU_TUNG.CellClick
        Try
            If e.RowIndex >= 0 Then
                rowIndexVT = e.RowIndex
                Me.grdDS_PHU_TUNG.Rows(rowIndexVT).Selected = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdDS_PHU_TUNG_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDS_PHU_TUNG.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.ColumnIndex = -1 Then Exit Sub

            If (e.RowIndex >= 0 And e.ColumnIndex >= 0) Then

                Me.grdDS_PHU_TUNG.Rows(e.RowIndex).Selected = True

                RemoveHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
                If Me.grdDS_PHU_TUNG.RowCount < 1 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                    If Me.grdDS_PHU_TUNG.SelectedRows.Count < 1 Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSELECT_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    Else
                        Dim objDonHangXuatVT As New IC_DON_HANG_XUAT_VAT_TU_Info
                        objDonHangXuatVT.MS_PT = Me.lstVTKho(rowIndexVT).MS_PT
                        objDonHangXuatVT.TEN_PT = Me.lstVTKho(rowIndexVT).TEN_PT
                        objDonHangXuatVT.DVT = Me.lstVTKho(rowIndexVT).DVT
                        objDonHangXuatVT.ITEM_CODE = Me.lstVTKho(rowIndexVT).MS_PT_CTY
                        objDonHangXuatVT.PART_NO = Me.lstVTKho(rowIndexVT).MS_PT_NCC
                        Dim Flag As Boolean = True
                        For i As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                            If Me.lstDonHangXuatVT.Item(i).MS_PT = objDonHangXuatVT.MS_PT Then
                                Flag = False
                                Exit For
                            End If
                        Next
                        If Flag = True Then
                            Me.lstDonHangXuatVT.Add(objDonHangXuatVT)
                        End If


                        MS_PT = objDonHangXuatVT.MS_PT
                        'Me.FormatGridDS_Phu_Tung_Chon()
                        Me.grdDS_PHU_TUNG_CHON.DataSource = Me.lstDonHangXuatVT
                        Me.FormatGridDS_Phu_Tung_Chon()
                        Me.grdDS_PHU_TUNG_CHON.Columns("MS_DH_XUAT_PT").Visible = False
                        'Me.grdDS_PHU_TUNG_CHON.Columns("TEN_PT").Visible = False
                        Me.grdDS_PHU_TUNG_CHON.Rows(Me.grdDS_PHU_TUNG_CHON.RowCount - 1).Selected = True

                        rowIndexVTChon = Me.grdDS_PHU_TUNG_CHON.RowCount - 1
                        Load_So_Luong_Ton_Kho_Vat_Tu(objDonHangXuatVT.MS_PT)
                        MS_PT = objDonHangXuatVT.MS_PT
                        Me.hasDataCTXuatVT.Remove(MS_PT)
                        Me.hasDataCTXuatVT.Add(MS_PT, Me.lstCTVTXuat)

                        'FormatGridCT_VT_Xuat()
                        Me.grdCT_VT_XUAT.DataSource = Me.lstCTVTXuat
                        FormatGridCT_VT_Xuat()
                        Me.grdCT_VT_XUAT.Columns("MS_VI_TRI").Visible = False
                        'Me.grdCT_VT_XUAT.Columns("MS_DH_NHAP_PT").Visible = False
                        Me.lstVTKho.RemoveAt(rowIndexVT)

                        Me.FormatGridDS_Phu_Tung()
                        Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho
                        Try
                            Me.grdDS_PHU_TUNG.Rows(e.RowIndex).Selected = True

                        Catch ex As Exception
                            If Me.grdDS_PHU_TUNG.RowCount > 0 Then
                                Me.grdDS_PHU_TUNG.Rows(0).Selected = True
                            End If
                        End Try

                        If Me.rowIndexVT > 0 Then
                            Me.rowIndexVT = Me.rowIndexVT - 1
                        End If
                    End If
                End If
                AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub grdDS_PHU_TUNG_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDS_PHU_TUNG.RowEnter
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.ColumnIndex = -1 Then Exit Sub

            rowIndexVT = e.RowIndex
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbDDH_EditValueChanged(sender As Object, e As EventArgs) Handles cbDDH.EditValueChanged
        Try
            If cbDDH.EditValue = "-1" Or cbDDH.EditValue = Nothing Then
                NONN.Enabled = False
            Else
                NONN.Enabled = True
            End If
        Catch ex As Exception
            NONN.Enabled = False
        End Try

        If cbDDH.ItemIndex > 0 Then
            Dim tbDDH As DataTable = New DataTable()
            If (chkGoodsReceive.Checked) Then
                tbDDH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT VI_TRI_KHO_VAT_TU.MS_PT FROM VI_TRI_KHO_VAT_TU WHERE SL_VT>0 AND MS_DH_NHAP_PT = '" + cbDDH.EditValue + "' "))
            Else
                Dim sql As String
                sql = "SELECT     dbo.VI_TRI_KHO_VAT_TU.MS_PT FROM   dbo.VI_TRI_KHO_VAT_TU INNER JOIN dbo.IC_DON_HANG_NHAP ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT WHERE   dbo.IC_DON_HANG_NHAP.LOCK =1 AND dbo.VI_TRI_KHO_VAT_TU.SL_VT >0 AND dbo.IC_DON_HANG_NHAP.MS_DDH='" + cbDDH.EditValue + "' AND dbo.VI_TRI_KHO_VAT_TU.MS_KHO = " + MS_KHO.ToString() + ""

                tbDDH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT     dbo.VI_TRI_KHO_VAT_TU.MS_PT FROM   dbo.VI_TRI_KHO_VAT_TU INNER JOIN dbo.IC_DON_HANG_NHAP ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT WHERE   dbo.IC_DON_HANG_NHAP.LOCK =1 AND dbo.VI_TRI_KHO_VAT_TU.SL_VT >0 AND dbo.IC_DON_HANG_NHAP.MS_DDH='" + cbDDH.EditValue + "' AND dbo.VI_TRI_KHO_VAT_TU.MS_KHO = " + MS_KHO.ToString() + ""))
            End If
            FormatGridDS_Phu_Tung()
            Dim temp As String = ""
            If tbDDH.Rows.Count > 0 Then
                temp = "  AND PT.MS_PT IN ("
                For i As Integer = 0 To tbDDH.Rows.Count - 1
                    If i = 0 Then
                        temp += "'" + tbDDH.Rows(i)("MS_PT") + "'"
                    Else
                        temp += ", '" + tbDDH.Rows(i)("MS_PT") + "'"
                    End If
                Next
                temp += ") "
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongCoVatTuConTon", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbDDH.ItemIndex = 0
            End If
            If Me.lstDonHangXuatVT.Count > 0 Then
                temp += "  AND PT.MS_PT NOT IN ("
                For I As Integer = 0 To Me.lstDonHangXuatVT.Count - 1
                    If I = 0 Then
                        temp += "'" + Me.lstDonHangXuatVT.Item(I).MS_PT + "'"
                    Else
                        temp += ", '" + Me.lstDonHangXuatVT.Item(I).MS_PT + "'"
                    End If
                Next
                temp += ") "
            End If
            temp = temp + "   Order by PT.TEN_PT"
            Dim sss As String = Me.CreateQuery + temp
            Me.lstVTKho = QLBusinessDataController.FillCollection(Of VAT_TU_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_SEARCH", Me.CreateQuery + temp))
            Me.grdDS_PHU_TUNG.DataSource = Me.lstVTKho
            If Me.grdDS_PHU_TUNG.RowCount > 0 Then
                Me.grdDS_PHU_TUNG.Rows(0).Selected = True
                rowIndexVT = 0
            End If
        Else
            Load_Vat_Tu()
        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btn.Click
        Try
            If Me.grdDS_PHU_TUNG.RowCount < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                AddHandler grdDS_PHU_TUNG_CHON.RowEnter, AddressOf Me.grdDS_PHU_TUNG_CHON_RowEnter
                Return
            End If

            Dim sPath As String = ""
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm | All Files(*.*) | *.*"
            If ofd.ShowDialog = DialogResult.Cancel Then Return
            sPath = ofd.FileName
            If sPath = "" Then Return

            Me.Cursor = Cursors.WaitCursor

            Dim wb As New Spire.Xls.Workbook
            wb.LoadFromFile(sPath)
            Dim ws As Spire.Xls.Worksheet = wb.Worksheets(0)
            Dim dt As New DataTable
            dt = ws.ExportDataTable(ws.AllocatedRange, True, True)
            Dim sVT As String = ""
            Commons.Modules.SQLString = "IMPORT"
            iSLImport = 0
            For Each drRow As DataRow In dt.Rows
                Try
                    If drRow(0).ToString().Trim = "" Then GoTo breakLoop
                    iSLImport = 0
                    For Each row As DataGridViewRow In grdDS_PHU_TUNG.Rows
                        If (row.Cells(0).Value.ToString().Trim.ToLower().Contains(drRow(0).ToString().Trim().ToLower())) Then
                            row.Selected = True
                            grdDS_PHU_TUNG.CurrentCell = row.Cells(0)

                            If Me.grdDS_PHU_TUNG.SelectedRows.Count < 1 Then
                                GoTo breakLoop
                            End If


                            Double.TryParse(drRow(2).ToString(), iSLImport)
                            btnAddVT_Click(Nothing, Nothing)
                            GoTo breakLoop
                        End If
                    Next
                    If sVT = "" Then sVT = drRow(0).ToString.ToUpper() Else sVT = sVT & vbCrLf & drRow(0).ToString.ToUpper()
                Catch ex As Exception

                End Try
breakLoop:
            Next
            Commons.Modules.SQLString = ""
            If sVT <> "" Then XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCacPhuTungSauKhongCoSoLuongTon", Commons.Modules.TypeLanguage) + vbCrLf + sVT)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
            Commons.Modules.SQLString = ""
        End Try
        Commons.Modules.SQLString = ""
        Me.Cursor = Cursors.Default
    End Sub
End Class

