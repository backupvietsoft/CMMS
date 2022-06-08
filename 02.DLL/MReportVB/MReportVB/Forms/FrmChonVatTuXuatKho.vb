Imports System.Linq
Imports Commons.VS.Classes.Catalogue
Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Data.DataSetExtensions
Imports Commons.QL.Common.Data
Imports System.Data.SqlClient
Public Class FrmChonVatTuXuatKho
    Public MS_DH_XUAT_PT As String
    Public MS_PBT As String
    Public MS_KHO As Integer
    Public NGAY_XUA As Date
    Public tb As Hashtable
    Public lstVITRI_KHO_VATTU_Filter As New List(Of VI_TRI_KHO_VAT_TU_Info)
    Public lstDonHangXuatVT As List(Of IC_DON_HANG_XUAT_VAT_TU_Info) = New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
    Public lstCTVTXuat As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
    Public dangxuat As Integer = 0
    Private objDonHangXuatController As New IC_DON_HANG_XUAT_Controller
    Private Sub FrmChonVatTuXuatKho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnablebtnPBT()
        If lstDonHangXuatVT.Count > 0 Then
            chkGoodsReceive.Enabled = False
        Else
            chkGoodsReceive.Enabled = True
        End If
        Commons.Modules.SQLString = "0Load"
        Load_DDH()
        Commons.Modules.SQLString = ""
        Load_Vat_Tu(CreatateQueryNotIn(), "-1")
        Load_Vat_Tu_Chon_Xuat("-1")
        Try
            If grvDS_PHU_TUNG_CHON.RowCount > 0 Then
                LOAD_DON_HANG_XUAT_VAT()
            End If
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Private Sub EnablebtnPBT()
        Try
            btnChonVTTuPBT.Enabled = IIf(MS_PBT.Trim = "", False, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreatateQueryNotIn() As String
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
        Return CreateQuery() + temp
    End Function

    Function CreateQuery() As String
        Dim sql As String = ""
        If chkGoodsReceive.Checked = False Then
            sql = "SELECT DISTINCT PT.MS_PT, PT.TEN_PT, PT.MS_PT_CTY, PT.MS_PT_NCC,DV.TEN_1 AS DVT,ISNULL(KY_PB,0) AS  KY_PB"
        Else
            sql = "SELECT DISTINCT PT.MS_PT, PT.TEN_PT, PT.MS_PT_CTY, PT.MS_PT_NCC,DV.TEN_1 AS DVT,ISNULL(KY_PB,0) AS  KY_PB,DHN.MS_DH_NHAP_PT"
        End If
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
        'strPickList = sql
        Return sql
    End Function

    'load grid vật tư
    Sub Load_Vat_Tu(ByVal sSql As String, ByVal mspt As String)
        grdDS_PHU_TUNG.DataSource = Nothing
        Dim tempt As New DataTable
        tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql + "  ORDER BY PT.MS_PT, PT.TEN_PT"))
        Try
            tempt.PrimaryKey = New DataColumn() {tempt.Columns("MS_PT")}
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDS_PHU_TUNG, grvDS_PHU_TUNG, tempt, False, True, False, True, True, Me.Name)
        txt_TK.ResetText()
        If mspt <> "-1" Then
            Try
                Dim index As Integer = tempt.Rows.IndexOf(tempt.Rows.Find(mspt))
                grvDS_PHU_TUNG.FocusedRowHandle = grvDS_PHU_TUNG.GetRowHandle(index)
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString())
            End Try
        End If
        'grvDS_PHU_TUNG.Columns("MS_DH_NHAP_PT").Visible = False
    End Sub

    'Load grid chọn vật tư
    Sub Load_Vat_Tu_Chon_Xuat(ByVal MS_PT As String)
        If lstDonHangXuatVT.Count = 0 Then
            grdDS_PHU_TUNG_CHON.DataSource = Nothing
            Return
        End If
        grdDS_PHU_TUNG_CHON.DataSource = Nothing
        grdDS_PHU_TUNG_CHON.DataSource = lstDonHangXuatVT
        If MS_PT <> "-1" Then
            grvDS_PHU_TUNG_CHON.FocusedRowHandle = lstDonHangXuatVT.Count - 1
        End If
    End Sub
    'Load grid chi tiết vật tư
    Sub Load_Chi_Tiet_Vat_Tu(ByVal ms_pt As String)
        If lstCTVTXuat.Count = 0 Then
            grdCT_VT_XUAT.DataSource = Nothing
            Return
        End If
        grdCT_VT_XUAT.DataSource = Nothing
        grdCT_VT_XUAT.DataSource = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(ms_pt)).ToList()
    End Sub

    Sub LOAD_DON_HANG_XUAT_VAT()
        For Each item As IC_DON_HANG_XUAT_VAT_TU_Info In lstDonHangXuatVT
            Add_CT_VT(item.MS_PT)
        Next
    End Sub

    'add chi tiết tồn kho vật tư theo ms_pt
    Sub Add_CT_VT(ByVal MS_PT As String)
        Dim lst As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
        If cbDDH.EditValue = "-1" Then
            lst = QLBusinessDataController.FillCollection(Of CHI_TIET_VAT_TU_XUAT_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_SO_LUONG_TON_KHO_VAT_TU", MS_PT, MS_KHO, NGAY_XUA, chkGoodsReceive.Checked, DBNull.Value))
        Else
            lst = QLBusinessDataController.FillCollection(Of CHI_TIET_VAT_TU_XUAT_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_SO_LUONG_TON_KHO_VAT_TU", MS_PT, MS_KHO, NGAY_XUA, chkGoodsReceive.Checked, cbDDH.EditValue))
        End If
        lst = lst.Where(Function(s) Not lstCTVTXuat.Where(Function(es) es.MS_DH_NHAP_PT = s.MS_DH_NHAP_PT And es.MS_VI_TRI = s.MS_VI_TRI And es.ID_XUAT = s.ID_XUAT And es.MS_PT = s.MS_PT).Any()).Select(Function(s) s).ToList()
        lstCTVTXuat.AddRange(lst)
    End Sub
    'xoa chi tiet vat tu
    Sub Remove_CT_VT(ByVal MS_PT As String)
        Dim row As CHI_TIET_VAT_TU_XUAT_Info = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(MS_PT)).FirstOrDefault()
        lstCTVTXuat.Remove(row)
        Dim mspt As String = ""
        Try
            mspt = grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT")
        Catch ex As Exception
            mspt = ""
        End Try
        Load_Chi_Tiet_Vat_Tu(mspt)
    End Sub

    Sub Load_DDH()
        Try
            Dim tbDDH As DataTable = New DataTable()
            Dim Sql As String
            Sql = "SELECT DISTINCT A.MS_DON_DAT_HANG, A.MS_DON_DAT_HANG AS DDH " &
                        " FROM dbo.DON_DAT_HANG AS A INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP AS B ON A.MS_DON_DAT_HANG = B.MS_DDH INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU AS C ON B.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS D ON C.MS_DH_NHAP_PT = D.MS_DH_NHAP_PT AND C.MS_PT = D.MS_PT AND  " &
                        " C.ID = D.ID INNER JOIN " &
                        " dbo.VI_TRI_KHO_VAT_TU AS E ON D.MS_DH_NHAP_PT = E.MS_DH_NHAP_PT AND D.MS_PT = E.MS_PT AND D.ID = E.ID AND  " &
                        " D.MS_VI_TRI = E.MS_VI_TRI And B.MS_KHO = E.MS_KHO " &
                        " WHERE (A.TRANG_THAI >= 3) AND (CONVERT(DATETIME, CONVERT(NVARCHAR(2), DAY(B.NGAY)) + '/' + CONVERT(NVARCHAR(2), MONTH(B.NGAY))  " &
                        " + '/' + CONVERT(NVARCHAR(4), YEAR(B.NGAY)) + ' ' + CONVERT(NVARCHAR(2), DATEPART(hour, B.GIO)) + ':' + CONVERT(NVARCHAR(2),  " &
                        " DATEPART(MINUTE, B.GIO)), 103) <= '" & NGAY_XUA.ToString("MM/dd/yyyy HH:mm:ss") & "') " &
                        " AND E.MS_KHO = " + MS_KHO.ToString() + " AND E.SL_VT > 0 ORDER BY A.MS_DON_DAT_HANG DESC"
            tbDDH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
            Dim dtRow As DataRow
            dtRow = tbDDH.NewRow
            dtRow(0) = -1
            dtRow(1) = " < ALL > "
            tbDDH.Rows.InsertAt(dtRow, 0)
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbDDH, tbDDH, "MS_DON_DAT_HANG", "DDH", "")
            cbDDH.Properties.ShowHeader = False
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

    'chọn vật tư từ phiếu bảo trì
    Private Sub btnChonVTTuPBT_Click(sender As Object, e As EventArgs) Handles btnChonVTTuPBT.Click
        Try
            If Me.grvDS_PHU_TUNG.RowCount < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                If MS_PBT = "" Or MS_PBT = "-1" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PBT_NULL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                Dim str As String = "", sBT As String = "CHON_VTX" & Commons.Modules.UserName
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
                Dim table_PT As DataTable = CType(grdDS_PHU_TUNG.DataSource, DataTable)
                Dim tb As New DataTable
                tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spChonPhuTungXuat", MS_PBT, sBT))
                If tb.Rows.Count > 0 Then
                    For Each item As DataRow In tb.Rows
                        'lấy item của phụ tùng theo mã phụ tùng
                        Dim rowpt = table_PT.AsEnumerable().Where(Function(x) x.Field(Of String)("MS_PT").Equals(item("MS_PT"))).FirstOrDefault()
                        If rowpt Is Nothing Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAD_VAT_TU_NULL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        Dim row As New IC_DON_HANG_XUAT_VAT_TU_Info
                        Try
                            row.MS_PT = rowpt("MS_PT")
                            row.TEN_PT = rowpt("TEN_PT")
                            Try
                                row.SO_LUONG_CTU = Convert.ToDouble(item("SL_KH"))
                                row.SO_LUONG_THUC_XUAT = Convert.ToDouble(item("SL_KH"))
                            Catch ex As Exception
                                row.SO_LUONG_CTU = 0
                                row.SO_LUONG_THUC_XUAT = 0
                            End Try
                            row.DVT = rowpt("DVT")
                            'row.MS_DH_XUAT_PT = MS_DH_XUAT_PT
                            row.MS_DH_XUAT_PT = Nothing
                            row.TG_PB = Convert.ToInt32(rowpt("KY_PB"))
                            row.GHI_CHU = rowpt("GHI_CHU")
                            row.ITEM_CODE = rowpt("MS_PT_CTY")
                            row.PART_NO = rowpt("MS_PT_NCC")
                        Catch ex As Exception
                        End Try
                        'insert row vừa tạo vào list chọn
                        lstDonHangXuatVT.Add(row)
                        'add vào list chi tiết theo mã phụ tùng
                        Add_CT_VT(row.MS_PT)
                        bCoVT = True
                        sVT = row.MS_PT
                    Next
                    'xóa phụ tùng này ra khỏi lưới
                    Load_Vat_Tu(CreatateQueryNotIn(), "-1")
                    'load lại lưới vật tư
                    Load_Vat_Tu_Chon_Xuat("-1")
                    Load_Chi_Tiet_Vat_Tu(sVT)
                    chkGoodsReceive.Checked = False
                End If
                If bCoVT = False Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAD_VAT_TU_NULL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If sVT = "" Then XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCacPhuTungSauKhongCoSoLuongTon", Commons.Modules.TypeLanguage) + vbCrLf + sVT)
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Xuat_tu_Dong_VT(ByVal item As IC_DON_HANG_XUAT_VAT_TU_Info)
        Dim lst As List(Of CHI_TIET_VAT_TU_XUAT_Info) = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(item.MS_PT)).ToList().OrderBy(Function(x) x.NGAY).ToList()
        Dim index As Integer = 0
        Dim SL As Double = item.SO_LUONG_THUC_XUAT
        While index < lst.Count
            If SL <= lst(index).SL_VT Then
                lst(index).SL_XUAT = SL
            Else
                lst(index).SL_XUAT = lst(index).SL_VT
            End If
            SL = IIf(SL - lst(index).SL_VT < 0, 0, SL - lst(index).SL_VT)
            index += 1
        End While
    End Sub
    'xuất tự động
    Private Sub btnXuat_Tu_Dong_Click(sender As Object, e As EventArgs) Handles btnXuat_Tu_Dong.Click
        For Each item As IC_DON_HANG_XUAT_VAT_TU_Info In lstDonHangXuatVT
            Xuat_tu_Dong_VT(item)
        Next
        Load_Chi_Tiet_Vat_Tu(grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT"))
    End Sub
    'thực hiện
    Private Sub btnThuc_Hien_Click(sender As Object, e As EventArgs) Handles btnThuc_Hien.Click
        'kiểm tra số lượng thực xuất được nhập lstDonHangXuatVT
        Dim cou As Integer = lstDonHangXuatVT.Where(Function(x) x.SO_LUONG_THUC_XUAT = 0).Count()
        If cou > 0 Then
            Dim row As IC_DON_HANG_XUAT_VAT_TU_Info = lstDonHangXuatVT.Where(Function(x) x.SO_LUONG_THUC_XUAT = 0).FirstOrDefault()
            XtraMessageBox.Show(row.MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_SO_LUONG_THUC_XUAT", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        'kiem tra số lượng thực xuất có giống nhâu chưa
        For Each item As IC_DON_HANG_XUAT_VAT_TU_Info In lstDonHangXuatVT
            Dim SUM As Double = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(item.MS_PT)).Sum(Function(x) x.SL_XUAT)
            If SUM <> Convert.ToDouble(item.SO_LUONG_THUC_XUAT) Then
                XtraMessageBox.Show(item.MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuacandoiSL", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
        Next
        'bắc đầu thực hiện
        Try
            DialogResult = DialogResult.OK
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message.ToString(), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    'thoát
    Private Sub btnTHOAT_Click(sender As Object, e As EventArgs) Handles btnTHOAT.Click
        lstDonHangXuatVT.Clear()
        lstCTVTXuat.Clear()
        DialogResult = DialogResult.No
        Me.Close()
    End Sub
    Private Sub chkGoodsReceive_CheckedChanged(sender As Object, e As EventArgs) Handles chkGoodsReceive.CheckedChanged
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

    Private Sub cbDDH_EditValueChanged(sender As Object, e As EventArgs) Handles cbDDH.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Load_Vat_Tu(CreatateQueryNotIn(), "-1")
        Dim dtTmp = New DataTable
        dtTmp = CType(grdDS_PHU_TUNG.DataSource, DataTable)
        Try
            If cbDDH.EditValue.ToString() <> "-1" Then
                dtTmp.DefaultView.RowFilter = " MS_DH_NHAP_PT like '%" + cbDDH.EditValue + "%'"
                dtTmp = dtTmp.DefaultView.ToTable()
            Else
                dtTmp.DefaultView.RowFilter = ""
                dtTmp = dtTmp.DefaultView.ToTable()
            End If
        Catch ex As Exception
            'dtTmp.DefaultView.RowFilter = ""
            'dtTmp = dtTmp.DefaultView.ToTable()
        End Try
        Try
            If cbDDH.EditValue = "-1" Or cbDDH.EditValue = Nothing Then
                NONN.Enabled = False
            Else
                NONN.Enabled = True
            End If
        Catch ex As Exception
            NONN.Enabled = False
        End Try
    End Sub

    Private Sub txt_TK_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TK.EditValueChanged
        Dim dtTmp = New DataTable
        Try
            dtTmp = CType(grdDS_PHU_TUNG.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = " MS_PT like '%" + txt_TK.Text + "%' OR TEN_PT like '%" + txt_TK.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    'chọn vât từ phụ tùng cần lấy
    Private Sub NONNbtnAVT_Click(sender As Object, e As EventArgs) Handles NONNbtnAVT.Click
        If Me.grvDS_PHU_TUNG.RowCount < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        Else
            'If Me.grvDS_PHU_TUNG.SelectedRows.Count < 1 Then
            '    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSELECT_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return
            'Else
            'tạo ra một row
            Dim row As New IC_DON_HANG_XUAT_VAT_TU_Info
            Try
                row.MS_PT = grvDS_PHU_TUNG.GetFocusedRowCellValue("MS_PT")
                row.TEN_PT = grvDS_PHU_TUNG.GetFocusedRowCellValue("TEN_PT")
                row.SO_LUONG_CTU = 0
                row.SO_LUONG_THUC_XUAT = 0
                row.DVT = grvDS_PHU_TUNG.GetFocusedRowCellValue("DVT")
                'row.MS_DH_XUAT_PT = MS_DH_XUAT_PT
                row.MS_DH_XUAT_PT = Nothing
                row.TG_PB = Convert.ToInt32(grvDS_PHU_TUNG.GetFocusedRowCellValue("KY_PB"))
                row.GHI_CHU = grvDS_PHU_TUNG.GetFocusedRowCellValue("GHI_CHU")
                row.ITEM_CODE = grvDS_PHU_TUNG.GetFocusedRowCellValue("MS_PT_CTY")
                row.PART_NO = grvDS_PHU_TUNG.GetFocusedRowCellValue("MS_PT_NCC")
            Catch ex As Exception
            End Try
            'insert row vừa tạo vào list
            lstDonHangXuatVT.Add(row)
            'xóa phụ tùng này ra khỏi lưới
            Load_Vat_Tu(CreatateQueryNotIn(), "-1")
            'load lại lưới vật tư
            Load_Vat_Tu_Chon_Xuat(row.MS_PT)
            'chkGoodsReceive.Checked = False
            Add_CT_VT(row.MS_PT)
            Load_Chi_Tiet_Vat_Tu(row.MS_PT)
            If cbDDH.EditValue <> "-1" Then
                cbDDH_EditValueChanged(Nothing, Nothing)
            End If
        End If
    End Sub
    'bỏ vật tư phụ tùng
    Private Sub NONNbtnMVT_Click(sender As Object, e As EventArgs) Handles NONNbtnMVT.Click
        Try
            'kiểm tra tồn tại trong cơ sở dữ liệu rồi thì hông cho chuyển ngược lại
            Dim vMS_DHX As String = ""
            Try
                vMS_DHX = grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_DH_XUAT_PT")
            Catch ex As Exception
            End Try
            If Not vMS_DHX Is Nothing Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoChuyenVT_PT", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Me.grvDS_PHU_TUNG_CHON.RowCount < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG_CHON", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                'If grdDS_PHU_TUNG_CHON.SelectedRows.Count < 0 Then
                '    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSELECT_PHU_TUNG_CHON", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Return
                'Else
                Dim item As IC_DON_HANG_XUAT_VAT_TU_Info = lstDonHangXuatVT.Where(Function(x) x.MS_PT.Equals(grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT"))).FirstOrDefault()
                lstDonHangXuatVT.Remove(item)
                Load_Vat_Tu(CreatateQueryNotIn(), item.MS_PT)
                'load lại lưới vật tư
                Load_Vat_Tu_Chon_Xuat("-1")
                Remove_CT_VT(item.MS_PT)
                'chkGoodsReceive.Checked = False
                If lstDonHangXuatVT.Count > 0 Then
                    chkGoodsReceive.Enabled = False
                Else
                    chkGoodsReceive.Enabled = True
                End If
                If cbDDH.EditValue <> "-1" Then
                    cbDDH_EditValueChanged(Nothing, Nothing)
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    'chọn hết vật tư phụ tùng theo phiếu nhập
    Private Sub NONN_Click(sender As Object, e As EventArgs) Handles NONN.Click
        If Me.grvDS_PHU_TUNG.RowCount < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLOAD_DS_PHU_TUNG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        Else
            Dim tb As New DataTable
            'thêm vào bảng chọn
            Try
                Dim tempt As DataTable = CType(grdDS_PHU_TUNG.DataSource, DataTable)
                tb = tempt.AsEnumerable().Where(Function(x) x.Field(Of String)("MS_DH_NHAP_PT").Equals(cbDDH.EditValue.ToString())).CopyToDataTable()
            Catch ex As Exception

            End Try
            For Each item As DataRow In tb.Rows
                Dim row As New IC_DON_HANG_XUAT_VAT_TU_Info
                Try
                    row.MS_PT = item("MS_PT")
                    row.TEN_PT = item("TEN_PT")
                    row.SO_LUONG_CTU = 0
                    row.SO_LUONG_THUC_XUAT = 0
                    row.DVT = item("DVT")
                    'row.MS_DH_XUAT_PT = MS_DH_XUAT_PT
                    row.MS_DH_XUAT_PT = Nothing
                    row.TG_PB = Convert.ToInt32(item("KY_PB"))
                    row.GHI_CHU = item("GHI_CHU")
                    row.ITEM_CODE = item("MS_PT_CTY")
                    row.PART_NO = item("MS_PT_NCC")
                Catch ex As Exception
                End Try
                lstDonHangXuatVT.Add(row)
                Add_CT_VT(row.MS_PT)
            Next
            'xóa phụ tùng này ra khỏi lưới
            Load_Vat_Tu(CreatateQueryNotIn(), "-1")
            'load lại lưới vật tư
            Load_Vat_Tu_Chon_Xuat("-1")
            'load chi tiết vật tư
            Dim mspt As String = ""
            Try
                mspt = grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT")
            Catch ex As Exception
                mspt = ""
            End Try
            Load_Chi_Tiet_Vat_Tu(mspt)
            chkGoodsReceive.Checked = False
            If cbDDH.EditValue <> "-1" Then
                cbDDH_EditValueChanged(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub grvDS_PHU_TUNG_CHON_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDS_PHU_TUNG_CHON.FocusedRowChanged
        Load_Chi_Tiet_Vat_Tu(grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT"))
    End Sub
    'tự động nhập số lượng thực xuất
    Private Sub grvDS_PHU_TUNG_CHON_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvDS_PHU_TUNG_CHON.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.ClearColumnErrors()
        If view.FocusedColumn.FieldName.ToUpper() = "SO_LUONG_CTU" Or view.FocusedColumn.FieldName.ToUpper() = "SO_LUONG_THUC_XUAT" Then
            If grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("SO_LUONG_CTU") < 0 Then
                'e.Valid = False
                view.SetColumnError(view.Columns("SO_LUONG_CTU"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgSLchungtu_am", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLchungtu_am", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                Dim Tong As Double = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT").ToString())).Sum(Function(x) x.SL_VT)
                If grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("SO_LUONG_CTU") > Tong Then

                    'e.Valid = False
                    view.SetColumnError(view.Columns("SO_LUONG_CTU"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage))
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage) + " : " + Tong.ToString, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                    grvDS_PHU_TUNG_CHON.SetRowCellValue(e.RowHandle, "SO_LUONG_THUC_XUAT", grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("SO_LUONG_CTU"))
                    grvDS_PHU_TUNG_CHON.UpdateCurrentRow()
                End If
            End If
            'If view.FocusedColumn.FieldName.ToUpper() = "SO_LUONG_THUC_XUAT" Then
            If grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("SO_LUONG_THUC_XUAT") < 0 Then
                'e.Valid = False
                view.SetColumnError(view.Columns("SO_LUONG_THUC_XUAT"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgSLthucxuat_am", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLchungtu_am", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                Dim Tong As Double = lstCTVTXuat.Where(Function(x) x.MS_PT.Equals(grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("MS_PT").ToString())).Sum(Function(x) x.SL_VT)
                If grvDS_PHU_TUNG_CHON.GetFocusedRowCellValue("SO_LUONG_THUC_XUAT") > Tong Then
                    'e.Valid = False
                    view.SetColumnError(view.Columns("SO_LUONG_THUC_XUAT"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage))
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage) + " : " + Tong.ToString, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
        End If
    End Sub
    'Private Sub grvDS_PHU_TUNG_CHON_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvDS_PHU_TUNG_CHON.InvalidRowException
    '    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    'End Sub
    Private Sub grvCT_VT_XUAT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvCT_VT_XUAT.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.ClearColumnErrors()
        If view.FocusedColumn.FieldName.ToUpper() = "SL_XUAT" Then
            If grvCT_VT_XUAT.GetFocusedRowCellValue("SL_XUAT") < 0 Then
                e.Valid = False
                view.SetColumnError(view.Columns("SL_XUAT"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgSLchungtu_am", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSLchungtu_am", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                If grvCT_VT_XUAT.GetFocusedRowCellValue("SL_XUAT") > grvCT_VT_XUAT.GetFocusedRowCellValue("SL_VT") Then
                    e.Valid = False
                    view.SetColumnError(view.Columns("SL_XUAT"), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Text, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage))
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThucxuatlonhontonkho", Commons.Modules.TypeLanguage) + " : " + grvCT_VT_XUAT.GetFocusedRowCellValue("SL_VT").ToString, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                End If
            End If
        End If
    End Sub

    Private Sub grvDS_PHU_TUNG_DoubleClick(sender As Object, e As EventArgs) Handles grvDS_PHU_TUNG.DoubleClick
        NONNbtnAVT_Click(Nothing, Nothing)
    End Sub

    Private Sub grvDS_PHU_TUNG_CHON_DoubleClick(sender As Object, e As EventArgs) Handles grvDS_PHU_TUNG_CHON.DoubleClick
        NONNbtnMVT_Click(Nothing, Nothing)
    End Sub
    'Private Sub grvCT_VT_XUAT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvCT_VT_XUAT.InvalidRowException
    '    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    'End Sub
End Class