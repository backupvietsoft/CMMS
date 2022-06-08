
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data
Public Class FrmLichSuThietBi
    Public MS_MAY As String = ""
    Private Shared SqlText As String = String.Empty

    Private Sub FrmLichSuThietBi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Commons.Modules.ObjSystems.XoaTable("BO_PHAN" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable("rptTieuDe_PT_BT")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDe_VT_BT")
    End Sub

    Private Sub FrmLichSuThietBi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTuNgay1.Value = DateTime.Now.AddMonths(-6)
        dtpDenNgay1.Value = DateTime.Now
        If MS_MAY = "" Then
            tvHistory.Nodes.Clear()
        Else
            Me.Cursor = Cursors.WaitCursor
            ShowTreeRoot1(tvHistory, MS_MAY)
            Me.Cursor = Cursors.Default
        End If
        AddHandler dtpTuNgay1.ValueChanged, AddressOf dtpTuNgay1_ValueChanged
        AddHandler dtpDenNgay1.ValueChanged, AddressOf dtpDenNgay1_ValueChanged
    End Sub
    Sub ShowTreeRoot1(ByVal tvHistory1 As TreeView, ByVal sMS_MAY As String)

        'tvwCautrucTB.CheckBoxes = True
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        tvHistory1.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = tvHistory1.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String

        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA=N'" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If
        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode1(sMS_MAY, sMaBP, oChildNode)

        Next
        tvHistory1.ExpandAll()
        tvHistory1.Focus()
        Try
            tvHistory1.SelectedNode = tvHistory1.Nodes(0)
        Catch ex As Exception

        End Try


        ' RefeshLanguage2()
    End Sub
    Sub ShowTreeNode1(ByVal SMS_MAY As String, ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        'Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "'"

        'Tăng sửa 27/04/2007
        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY=N'" & SMS_MAY & "'"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If
        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode1(SMS_MAY, sMaBP, oChildNode)

        Next
        'RefeshLanguage2()
    End Sub

    Private Sub btLichSuCauTrucTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLichSuCauTrucTB.Click
        If tvHistory.Nodes.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CreateInLichSuCauTrucTB()
        Me.Cursor = Cursors.Default
    End Sub
    Sub CreateInLichSuCauTrucTB()
        'printClickNode()
        exportToExcel2()
    End Sub
    Private Sub exportToExcel2()
        Dim str As String = ""
        If txtMayTT.Text = "" Then
            txtMayTT.Text = MS_MAY
        End If

        Try
            SqlText = "DROP TABLE EXPORT_TO_EXCEL"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay1.Value.ToString()).Day.ToString()
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay1.Value.ToString()).Month.ToString()
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay1.Value.ToString()).Year.ToString()
        Dim _date_TN As String = thang_TN & "/" & ngay_TN & "/" & nam_TN
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay1.Value.ToString()).Day.ToString()
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay1.Value.ToString()).Month.ToString()
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay1.Value.ToString()).Year.ToString()
        Dim _date_DN As String = thang_DN & "/" & ngay_DN & "/" & nam_DN
        Dim PBT_KHO As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 PBT_KHO FROM THONG_TIN_CHUNG")
        If Convert.ToBoolean(PBT_KHO) Then
            SqlText = " SELECT  DISTINCT   dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, dbo.CONG_VIEC.MO_TA_CV, dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN, " & _
                          " dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, IC_PHU_TUNG_1.TEN_PT, " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " & _
                          " dbo.IC_PHU_TUNG.TEN_PT AS Expr1, CASE WHEN dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL THEN  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT ELSE  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END AS SL_TT , " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, " & _
                          " case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end as GHI_CHU" & _
                          " FROM         dbo.CONG_VIEC INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " & _
                          " dbo.CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " & _
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT INNER JOIN " & _
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " & _
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " & _
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " & _
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " & _
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " & _
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN " & _
                          " WHERE PHIEU_BAO_TRI.TINH_TRANG_PBT >= 3 AND PHIEU_BAO_TRI.MS_MAY=N'" & MS_MAY & "' AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ") " & _
                          " ORDER BY dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH DESC"
        Else
            SqlText = " SELECT  DISTINCT   dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, dbo.CONG_VIEC.MO_TA_CV, dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN, " & _
                          " dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, IC_PHU_TUNG_1.TEN_PT, " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " & _
                          " dbo.IC_PHU_TUNG.TEN_PT AS Expr1, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, " & _
                          " case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end as GHI_CHU " & _
                          " FROM         dbo.CONG_VIEC INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " & _
                          " dbo.CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " & _
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT INNER JOIN " & _
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " & _
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " & _
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " & _
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " & _
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " & _
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN " & _
                          " WHERE PHIEU_BAO_TRI.TINH_TRANG_PBT >= 3 AND PHIEU_BAO_TRI.MS_MAY=N'" & MS_MAY & "' AND  " & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ") " & _
                          " ORDER BY dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH DESC"
        End If

        Dim dt, dtFirst As New DataTable()
        dtFirst.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        If dtFirst.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        dt.TableName = "rptTIEU_DE_LICH_SU_TB"
        dt.Columns.Add("TIEU_DE")
        dt.Columns.Add("NGAY_HT")
        dt.Columns.Add("MO_TA_CV")
        dt.Columns.Add("TEN_BO_PHAN")
        dt.Columns.Add("MS_PHIEU_BAO_TRI")
        dt.Columns.Add("MS_PT")
        dt.Columns.Add("TEN_PT")
        dt.Columns.Add("MS_VI_TRI_PT")
        dt.Columns.Add("MS_PTTT")
        dt.Columns.Add("TEN_PTTT")
        dt.Columns.Add("SL_TT")
        dt.Columns.Add("MS_DH_NHAP_PT")
        dt.Columns.Add("XUAT_XU")
        dt.Columns.Add("GHI_CHU")
        dt.Columns.Add("MS_MAY")
        dt.Columns.Add("TEN_MAY")
        dt.Columns.Add("BO_PHAN")
        Dim rDt As DataRow = dt.NewRow()

        rDt("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage)
        rDt("NGAY_HT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "NGAY_HT", Commons.Modules.TypeLanguage)
        rDt("MO_TA_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MO_TA_CV", Commons.Modules.TypeLanguage)
        rDt("TEN_BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        rDt("MS_PHIEU_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
        rDt("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PT", Commons.Modules.TypeLanguage)
        rDt("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_PT", Commons.Modules.TypeLanguage)
        rDt("MS_VI_TRI_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
        rDt("MS_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PTTT", Commons.Modules.TypeLanguage)
        rDt("TEN_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_PTTT", Commons.Modules.TypeLanguage)
        rDt("SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "SL_TT", Commons.Modules.TypeLanguage)
        rDt("MS_DH_NHAP_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        rDt("XUAT_XU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "XUAT_XU", Commons.Modules.TypeLanguage)
        rDt("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "GHI_CHU", Commons.Modules.TypeLanguage)

        rDt("MS_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_MAY", Commons.Modules.TypeLanguage) & "  " & MS_MAY
        Dim Ten As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TEN_MAY FROM dbo.MAY WHERE MS_MAY = N'" & MS_MAY & "'")
        Dim TEN_MAY As String = ""
        If (Not Ten Is Nothing) Then
            TEN_MAY = Ten.ToString()
        End If
        rDt("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_MAY", Commons.Modules.TypeLanguage) & "  " & TEN_MAY
        If MS_MAY.Trim() = tvHistory.SelectedNode.Name.Trim() Then
            rDt("BO_PHAN") = ""
        Else
            rDt("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "BO_PHAN", Commons.Modules.TypeLanguage) & "  " & tvHistory.SelectedNode.Text
        End If

        dt.Rows.Add(rDt)

        dtFirst.TableName = "rptLICH_SU_THIET_BI"
        Dim frmLichsuTB As frmShowXMLReport = New frmShowXMLReport()
        frmLichsuTB.AddDataTableSource(dt)
        frmLichsuTB.AddDataTableSource(dtFirst)
        frmLichsuTB.rptName = "rptLICH_SU_THIET_BI"
        frmLichsuTB.ShowDialog()


    End Sub

    Private Sub BtnXemPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemPBT.Click
        If grdLichsuthietbi.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        ShowReport()
    End Sub
    Sub ShowReport()
        Me.Cursor = Cursors.WaitCursor
        CreaterptTieuDePhieuBaoTri()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptCONG_VIEC_BAO_TRI", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptNHAN_CONG", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDICH_VU_THUE_NGOAI", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptPHU_TUNG_BAO_TRI", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value, Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptPHIEU_BAO_TRI1", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value, Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDI_CHUYEN_BO_PHAN_BAO_TRI", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "getPhieuBaoTriVatTu", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "getPhieuBaoTriPhuTung", grdLichsuthietbi.Rows(intRowLS).Cells("MS_PHIEU_BAO_TRI").Value)

        Commons.mdShowReport.ReportPreview("reports/rptPHIEU_BAO_TRI.rpt")
        Dim str As String = ""

        Me.Cursor = Cursors.Default
    End Sub
    Sub CreaterptTieuDePhieuBaoTri()
        Dim str As String = ""
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TieuDe", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ThietBi", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim HinhThucBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "HinhThucBT", Commons.Modules.TypeLanguage)
        Dim LoaiBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "LoaiBt", Commons.Modules.TypeLanguage)
        Dim DiaDiem As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DiaDiem", Commons.Modules.TypeLanguage)
        Dim NgayBD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayBD", Commons.Modules.TypeLanguage)
        Dim NgayKT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayKT", Commons.Modules.TypeLanguage)
        Dim BoPhanCP As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhanCP", Commons.Modules.TypeLanguage)
        Dim NgayNT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayNT", Commons.Modules.TypeLanguage)
        Dim NguoiNT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiNT", Commons.Modules.TypeLanguage)
        Dim KetQuaBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KetQuaBT", Commons.Modules.TypeLanguage)
        Dim ChiPhiPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiPhutung", Commons.Modules.TypeLanguage)
        Dim ChiPhiVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiVatTu", Commons.Modules.TypeLanguage)
        Dim chiPhiNhanCong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiNhanCong", Commons.Modules.TypeLanguage)
        Dim ChiPhiDichVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiDichVu", Commons.Modules.TypeLanguage)
        Dim ChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiKhac", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "STT", Commons.Modules.TypeLanguage)
        Dim NoiDung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiDung", Commons.Modules.TypeLanguage)
        Dim ChiPhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhi", Commons.Modules.TypeLanguage)
        Dim TongChiPhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TongChiPhi", Commons.Modules.TypeLanguage)
        Dim KetQuaBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KetQuaBaoTri", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "Tong", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MoTa", Commons.Modules.TypeLanguage)
        Dim KeHoachThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KeHoachThucHien", Commons.Modules.TypeLanguage)
        Dim DanhSachCongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KeHoachCongViec", Commons.Modules.TypeLanguage)
        Dim DanhSachNhanVien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachNhanVien", Commons.Modules.TypeLanguage)
        Dim DanhSachDichVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachDichVu", Commons.Modules.TypeLanguage)
        Dim DanhSachPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachPhuTung", Commons.Modules.TypeLanguage)
        Dim DiChuyenBoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DiChuyenBoPhan", Commons.Modules.TypeLanguage)
        Dim TinhTrangPBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TinhTrangPBT", Commons.Modules.TypeLanguage)

        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim PheDuyet1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet1", Commons.Modules.TypeLanguage)
        Dim PheDuyet2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet2", Commons.Modules.TypeLanguage)
        Dim PheDuyet3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet3", Commons.Modules.TypeLanguage)
        Dim LY_DO_BT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "LY_DO_BT", Commons.Modules.TypeLanguage)

        Try
            str = "Drop table rptTieuDePhieuBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "Create table dbo.rptTieuDePhieuBaoTri(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255),ThietBi nvarchar(50)," & _
        " PhieuBaoTri nvarchar(60),NgayLap nvarchar(50),NguoiLap nvarchar(60),HinhThucBT nvarchar(100), LoaiBT nvarchar(80),DiaDiem nvarchar(50), " & _
        " NgayBD nvarchar(80),NgayKT nvarchar(80),BoPhanCP nvarchar(50),NgayNT nvarchar(60),NguoiNT nvarchar(80),KetQuaBT nvarchar(80),ChiPhiPhuTung nvarchar(100), " & _
        " ChiPhiVatTu nvarchar(100),ChiPhuNhanCong nvarchar(100),ChiPhiDichVu nvarchar(100),ChiPhiKhac nvarchar(100),STT nvarchar(5),NoiDung nvarchar(50), " & _
        " ChiPhi nvarchar(50),TongChiPhi nvarchar(70),KetQuaBaoTri nvarchar(80),Tong nvarchar(20),MoTa nvarchar(50),KeHoachThuchien nvarchar(80), " & _
        " DanhSachCongViec nvarchar(255),DanhSachNhanVien nvarchar(255),DanhSachDichVu nvarchar(80),DanhSachPhuTung nvarchar(80),DiChuyenBoPhan nvarchar(80),TinhTrangPBT nvarchar(50),TenThietBi nvarchar(50),PheDuyet1 nvarchar(50),PheDuyet2 nvarchar(50),PheDuyet3 nvarchar(50),LY_DO_BT NVARCHAR (256)) " & _
        " Insert into rptTieuDePhieuBaoTri values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & ThietBi & "',N'" & PhieuBaoTri & _
        "',N'" & NgayLap & "',N'" & NguoiLap & "',N'" & HinhThucBT & "',N'" & LoaiBT & "',N'" & DiaDiem & "',N'" & NgayBD & "',N'" & NgayKT & "',N'" & BoPhanCP & _
        "',N'" & NgayNT & "',N'" & NguoiNT & "',N'" & KetQuaBT & "',N'" & ChiPhiPhuTung & "',N'" & ChiPhiVatTu & "',N'" & chiPhiNhanCong & "',N'" & ChiPhiDichVu & _
        "',N'" & ChiPhiKhac & "',N'" & STT & "',N'" & NoiDung & "',N'" & ChiPhi & "',N'" & TongChiPhi & "',N'" & KetQuaBaoTri & "',N'" & Tong & "',N'" & MoTa & "',N'" & _
        KeHoachThucHien & "',N'" & DanhSachCongViec & "',N'" & DanhSachNhanVien & "',N'" & DanhSachDichVu & "',N'" & DanhSachPhuTung & "',N'" & DiChuyenBoPhan & "',N'" & TinhTrangPBT & _
        "',N'" & TenThietBi & "',N'" & PheDuyet1 & "',N'" & PheDuyet2 & "',N'" & PheDuyet3 & "',N'" & LY_DO_BT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeCongViecBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "CongViec", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhan", Commons.Modules.TypeLanguage)
        Dim SoGioKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SoGioKH", Commons.Modules.TypeLanguage)
        Dim NgayHoanThanh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayHoanThanh", Commons.Modules.TypeLanguage)
        Dim NoiNgoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiNgoai", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeCongViecBaoTri(TieuDe nvarchar(100),CongViec nvarchar(50),BoPhan nvarchar(50),SoGioKH nvarchar(50),NgayHoanThanh nvarchar(80),NoiNgoai nvarchar(50))" & _
        " Insert into rptTieuDeCongViecBaoTri values(N'" & DanhSachCongViec & "',N'" & CongViec & "',N'" & BoPhan & "',N'" & SoGioKH & "',N'" & NgayHoanThanh & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeNhanCongBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim HoTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "HoTen", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DenNgay", Commons.Modules.TypeLanguage)
        Dim ChinhPhu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChinhPhu", Commons.Modules.TypeLanguage)
        Dim BanTo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BanTo", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeNhanCongBaoTri(TieuDe nvarchar(100),HoTen Nvarchar(50),BanTo nvarchar(50),TuNgay nvarchar(50),Dengay Nvarchar(50),ChinhPhu nvarchar(50))" & _
        " Insert into rptTieuDeNhanCongBaoTri values(N'" & DanhSachNhanVien & "',N'" & HoTen & "',N'" & BanTo & "',N'" & TuNgay & "',N'" & DenNgay & "',N'" & ChinhPhu & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDedichvuThueNgoaiBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim NoidungService As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiDungService", Commons.Modules.TypeLanguage)
        Dim TenCongTy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenCongTy", Commons.Modules.TypeLanguage)
        Dim NguoiDaiDien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiDaiDien", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SoLuong", Commons.Modules.TypeLanguage)
        Dim DonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DonGia", Commons.Modules.TypeLanguage)
        Dim TyGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TyGia", Commons.Modules.TypeLanguage)
        Dim ThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ThanhTien", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDedichvuThueNgoaiBaoTri(TieuDe nvarchar(100),NoiDungService nvarchar(80),TenCongTy nvarchar(50),NguoiDaiDien nvarchar(80),SoLuong nvarchar(40),Dongia nvarchar(50),TyGia nvarchar(30),ThanhTien nvarchar(40)) " & _
        " Insert into rptTieuDedichvuThueNgoaiBaoTri values(N'" & DanhSachDichVu & "',N'" & NoidungService & "',N'" & TenCongTy & "',N'" & NguoiDaiDien & "',N'" & SoLuong & "',N'" & DonGia & "',N'" & TyGia & "',N'" & ThanhTien & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDePhuTungBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim MaVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MaVatTu", Commons.Modules.TypeLanguage)
        Dim TenVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenVatTu", Commons.Modules.TypeLanguage)
        Dim SLKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH", Commons.Modules.TypeLanguage)
        Dim SLTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT", Commons.Modules.TypeLanguage)
        Dim DonVi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DonVi", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDePhuTungBaoTri(TieuDe nvarchar(100),MaVatTu nvarchar(50), TenVatTu nvarchar(50),SLKH nvarchar(60),SLTT nvarchar(60),DonVi nvarchar(10),NoiNgoai nvarchar(30))" & _
        " Insert into rptTieuDePhuTungBaoTri values(N'" & DanhSachPhuTung & "',N'" & MaVatTu & "',N'" & TenVatTu & "',N'" & SLKH & "',N'" & SLTT & "',N'" & DonVi & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        ' tao tieu de Report cho Phu Tung
        Try
            str = "Drop table rptTieuDe_PT_BT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TIEU_DE_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TIEU_DE_PT", Commons.Modules.TypeLanguage)
        Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MS_PT", Commons.Modules.TypeLanguage)
        Dim TEN_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TEN_PT", Commons.Modules.TypeLanguage)
        Dim SLKH_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH_PT", Commons.Modules.TypeLanguage)
        Dim SLTT_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT_PT", Commons.Modules.TypeLanguage)
        Dim DVT_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DVT_PT", Commons.Modules.TypeLanguage)

        str = "Create table dbo.rptTieuDe_PT_BT(TIEU_DE_PT nvarchar(100),MS_PT nvarchar(50), TEN_PT nvarchar(50),SLKH_PT nvarchar(60),SLTT_PT nvarchar(60),DVT_PT nvarchar(10),NoiNgoai nvarchar(30))" & _
        " Insert into rptTieuDe_PT_BT values(N'" & TIEU_DE_PT & "',N'" & MS_PT & "',N'" & TEN_PT & "',N'" & SLKH_PT & "',N'" & SLTT_PT & "',N'" & DVT_PT & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        ' tao tieu de Report cho Vat Tu

        Try
            str = "Drop table rptTieuDe_VT_BT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TIEU_DE_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TIEU_DE_VT", Commons.Modules.TypeLanguage)
        Dim MS_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MS_VT", Commons.Modules.TypeLanguage)
        Dim TEN_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TEN_VT", Commons.Modules.TypeLanguage)
        Dim SLKH_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH_VT", Commons.Modules.TypeLanguage)
        Dim SLTT_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT_VT", Commons.Modules.TypeLanguage)
        Dim DVT_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DVT_VT", Commons.Modules.TypeLanguage)

        str = "Create table dbo.rptTieuDe_VT_BT(TIEU_DE_VT nvarchar(100),MS_VT nvarchar(50), TEN_VT nvarchar(50),SLKH_VT nvarchar(60),SLTT_VT nvarchar(60),DVT_VT nvarchar(10),NoiNgoai nvarchar(30))" & _
        " Insert into rptTieuDe_VT_BT values(N'" & TIEU_DE_VT & "',N'" & MS_VT & "',N'" & TEN_VT & "',N'" & SLKH_VT & "',N'" & SLTT_VT & "',N'" & DVT_VT & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)



        Try
            str = "Drop table rptTieuDeDiChuyenBoPhanBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TenBoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenBoPhan", Commons.Modules.TypeLanguage)
        Dim MayThayThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MayThayThe", Commons.Modules.TypeLanguage)
        Dim BoPhanTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhanTT", Commons.Modules.TypeLanguage)
        Dim NguoiChoPhep As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiChoPhep", Commons.Modules.TypeLanguage)
        Dim NgayThay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayThay", Commons.Modules.TypeLanguage)
        Dim NgayTra As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayTra", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeDiChuyenBoPhanBaoTri(TieuDe nvarchar(100),TenBoPhan nvarchar(50),MayThayThe nvarchar(80),BoPhanTT nvarchar(90),NguoichoPhep nvarchar(80),NgayThay nvarchar(50),NgayTra nvarchar(50)) " & _
        " Insert into rptTieuDeDiChuyenBoPhanBaoTri values(N'" & DiChuyenBoPhan & "',N'" & TenBoPhan & "',N'" & MayThayThe & "',N'" & BoPhanTT & "',N'" & NguoiChoPhep & "',N'" & NgayThay & "',N'" & NgayTra & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub BtnThoat6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat6.Click
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdChontheoma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdChontheoma.CheckedChanged
        txtGiatri.Text = ""
        txtGiatri.Focus()
    End Sub
    Dim intRowLS As Integer
    Private Sub grdLichsuthietbi_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLichsuthietbi.RowEnter
        intRowLS = e.RowIndex
        Dim str As String = ""
        Dim PBT_KHO As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 PBT_KHO FROM THONG_TIN_CHUNG")
        If Convert.ToBoolean(PBT_KHO) Then
            str = "SELECT  A.MS_PT,A.MS_VI_TRI_PT,CONG_NHAN.HO+''+CONG_NHAN.TEN AS NGUOI_THAY_THE,A.NGAY_THAY_THE, A.VICT_NHA_THAU, A.SL_TT, A.GHI_CHU FROM (" & _
             " Select " & _
             "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, " & _
              "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.VICT_NHA_THAU, " & _
               "       dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE NTT, CONVERT(NVARCHAR(10), " & _
                "      dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, 103) AS NGAY_THAY_THE, " & _
                 "     dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT, dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, "
            If grdLichsuthietbi.Rows(e.RowIndex).Cells("NHA_THAU").Value Then
                str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU "
            Else
                str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU "
            End If
            str = str & " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " & _
  "                    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON  " & _
   "                   dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " & _
    "                  dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT RIGHT OUTER JOIN " & _
     "                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " & _
      "                dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " & _
       "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " & _
        "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  " & _
         "             dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " & _
          "            dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " & _
           "           dbo.PHIEU_BAO_TRI_CONG_VIEC ON " & _
            "          dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND " & _
             "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV AND " & _
              "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN ON " & _
            " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " & _
             "          AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " & _
            " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " & _
              "         AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " & _
            "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT " & _
" WHERE     (PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = '" & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "') AND (PHIEU_BAO_TRI_CONG_VIEC.MS_CV = " & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_CV").Value & ") AND (PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = '" & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "')" & _
            ") AS A LEFT JOIN CONG_NHAN ON A.NTT = CONG_NHAN.MS_CONG_NHAN"
        Else
            str = "SELECT DISTINCT C.MS_PT,C.MS_VI_TRI_PT, CONVERT(NVARCHAR(10), A.NGAY_HOAN_THANH,103) AS NGAY_THAY_THE, C.SL_TT, dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN  AS NGUOI_THAY_THE, C.VICT_NHA_THAU,  D.MS_PTTT AS MS_PT1  ,  dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU,C.GHI_CHU " & _
            " FROM         dbo.CONG_NHAN RIGHT OUTER JOIN" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC A INNER JOIN" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI AND A.MS_CV = B.MS_CV AND " & _
                          " A.MS_BO_PHAN = B.MS_BO_PHAN INNER JOIN" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET C ON B.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI AND B.MS_CV = C.MS_CV AND " & _
                          " B.MS_PT = C.MS_PT AND B.MS_BO_PHAN = C.MS_BO_PHAN ON dbo.CONG_NHAN.MS_CONG_NHAN = C.NGUOI_THAY_THE LEFT OUTER JOIN" & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN" & _
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO D ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = D.MS_DH_NHAP_PT AND" & _
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = D.MS_PTTT ON C.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI AND C.MS_CV = D.MS_CV AND " & _
                          " C.MS_BO_PHAN = D.MS_BO_PHAN And C.MS_PT = D.MS_PT " & _
            " WHERE ((D.SL_TT IS NOT NULL AND D.SL_TT >0 ) OR C.GHI_CHU IS NOT NULL ) AND A.MS_PHIEU_BAO_TRI='" & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "' AND A.MS_CV=" & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_CV").Value & " AND A.MS_BO_PHAN='" & grdLichsuthietbi.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' "
        End If
        grdLichsuPTThayThe.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        RefreshHistoryPTThayThe()
    End Sub

    Private Sub tvHistory_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvHistory.AfterSelect
        'GetLichSuMay
        If (tvHistory.Nodes.Count < 0) Then
            Exit Sub
        End If
        Dim str As String = ""
        Dim strBoPhan As String = ""
        txtMayTT.Text = ""
        txtBoPhanTT.Text = ""

        Try
            grdLichsuthietbi.Columns.Clear()
            grdLichsuPTThayThe.Columns.Clear()
        Catch ex1 As Exception
        End Try
        Try
            str = "drop table BO_PHAN" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.BO_PHAN" & Commons.Modules.UserName & " (MS_BO_PHAN NVARCHAR(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        If tvHistory.SelectedNode.Name <> MS_MAY Then
            str = "insert into dbo.BO_PHAN" & Commons.Modules.UserName & " VALUES(N'" & tvHistory.SelectedNode.Name & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
        TaoTable(MS_MAY, tvHistory.SelectedNode.Name)
        HienThiDuLieuLichSuThietBi()
        RefreshHistory()
        Try
            Me.grdLichsuthietbi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdLichsuthietbi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
    End Sub
    Sub RefreshHistoryPTThayThe()
        Try
            With grdLichsuPTThayThe
                .Columns("VICT_NHA_THAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VICT_NHA_THAY", Commons.Modules.TypeLanguage)
                .Columns("VICT_NHA_THAU").Width = 100
                .Columns("NGUOI_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("NGUOI_THAY_THE").Width = 150
                .Columns("NGAY_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("NGAY_THAY_THE").Width = 100
                .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MAY_TT", Commons.Modules.TypeLanguage)
                .Columns("MS_PT").Width = 100
                .Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT1", Commons.Modules.TypeLanguage)
                .Columns("MS_VI_TRI_PT").Width = 80
                '.Columns("MS_PT1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT1", commons.Modules.TypeLanguage)
                '.Columns("MS_PT1").Width = 200
                .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
                .Columns("SL_TT").Width = 80
                '.Columns("NGAY_THAY_THE").Visible = False
                '.Columns("VICT_NHA_THAU").Visible = False
                .Columns("MS_VI_TRI_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                .Columns("GHI_CHU").MinimumWidth = 150
                '.Columns("XUAT_XU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "XUAT_XU", commons.Modules.TypeLanguage)
                '.Columns("XUAT_XU").MinimumWidth = 150
                .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            End With
        Catch ex As Exception

        End Try

    End Sub
    Sub TaoTable(ByVal MS_MAY As String, ByVal MS_BO_PHAN As String)
        Dim str As String = ""
        Dim tmp As New DataTable()
        str = "SELECT MS_BO_PHAN FROM CAU_TRUC_THIET_BI WHERE  MS_MAY=N'" & MS_MAY & "' AND MS_BO_PHAN_CHA=N'" & MS_BO_PHAN & "'"
        tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tmp.Rows.Count - 1
            str = "insert into dbo.BO_PHAN" & Commons.Modules.UserName & " VALUES(N'" & tmp.Rows(i).Item("MS_BO_PHAN") & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            TaoTable(MS_MAY, tmp.Rows(i).Item("MS_BO_PHAN"))
        Next
    End Sub
    Sub HienThiDuLieuLichSuThietBi()
        Dim str As String = ""
        str = "SELECT DISTINCT LICH_SU_TB.* FROM (" & _
        "SELECT  PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH,PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,PHIEU_BAO_TRI.TT_SAU_BT, dbo.MAY.MS_MAY AS MAY_TH,PHIEU_BAO_TRI_CONG_VIEC.MS_CV,PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN AS TEN_BP_TH,MS_MAY_THAY_THE,TEN_BO_PHAN_THAY_THE, dbo.CONG_VIEC.MO_TA_CV, LOAI_BAO_TRI.TEN_LOAI_BT,CONVERT(BIT,CASE ISNULL(PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE,-1) WHEN -1 THEN 0 ELSE 1 END) AS NHA_THAU,PHIEU_BAO_TRI_CONG_VIEC.GHI_CHU " & _
        " FROM dbo.PHIEU_BAO_TRI_CONG_VIEC INNER JOIN  " & _
        " dbo.PHIEU_BAO_TRI ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
        " INNER JOIN dbo.MAY ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY  " & _
        " INNER JOIN dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " & _
        " dbo.CONG_VIEC ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.CONG_VIEC.MS_CV INNER JOIN " & _
        " dbo.CAU_TRUC_THIET_BI ON dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND  " & _
        " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN INNER JOIN " & _
        " (select DISTINCT  MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,TEN_BO_PHAN_THAY_THE " & _
        " from PHIEU_BAO_TRI_DI_CHUYEN_BP inner join PHIEU_BAO_TRI ON    " & _
        " PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
        " WHERE  PHIEU_BAO_TRI.MS_MAY=N'" & MS_MAY & "' AND (NGAY_TRA_TT IS NULL OR CONVERT(DATETIME,NGAY_TRA_TT,103)>CONVERT(DATETIME,NGAY_NGHIEM_THU,103)) " & _
        " AND PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_BO_PHAN IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ") " & _
        " UNION SELECT MS_MAY ,MS_BO_PHAN,Replace(TEN_BO_PHAN,'   ','') AS TEN_BO_PHAN_THAY_THE FROM CAU_TRUC_THIET_BI " & _
        " WHERE MS_MAY=N'" & MS_MAY & "' AND MS_BO_PHAN IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & " WHERE MS_BO_PHAN not in " & _
        " (select distinct  MS_BO_PHAN from PHIEU_BAO_TRI_DI_CHUYEN_BP inner join PHIEU_BAO_TRI ON   " & _
        " PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
        " WHERE  PHIEU_BAO_TRI.MS_MAY=N'" & MS_MAY & "'  AND (NGAY_TRA_TT IS NULL OR CONVERT(DATETIME,NGAY_TRA_TT,103)>CONVERT(DATETIME,NGAY_NGHIEM_THU,103)) " & _
        " AND PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_BO_PHAN IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ")))) AS P1 " & _
        " ON PHIEU_BAO_TRI_CONG_VIEC.MS_MAY_TT=P1.MS_MAY_THAY_THE AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN_TT=P1.MS_BO_PHAN_THAY_THE " & _
        " WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT = 3 OR PHIEU_BAO_TRI.TINH_TRANG_PBT = 4) AND PHIEU_BAO_TRI.MS_MAY=N'" & MS_MAY & "' " & _
        " AND dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN cONVERT(DATETIME,'" & Format(dtpTuNgay1.Value, "Short date") & "',103)  AND DateAdd(day,1, CONVERT(DATETIME,'" & Format(dtpDenNgay1.Value, "Short date") & "',103))) LICH_SU_TB ORDER BY NGAY_HOAN_THANH DESC"

        grdLichsuthietbi.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grdLichsuthietbi.Columns("MS_CV").Visible = False
        grdLichsuthietbi.Columns("MS_BO_PHAN").Visible = False
        grdLichsuthietbi.Columns("MAY_TH").Visible = False
        grdLichsuthietbi.Columns("MS_BO_PHAN").Visible = False
        grdLichsuthietbi.Columns("MS_MAY_THAY_THE").Visible = False
        grdLichsuthietbi.Columns("TEN_BO_PHAN_THAY_THE").Visible = False
    End Sub
    Sub RefreshHistory()
        Try
            With grdLichsuthietbi
                .Columns("NGAY_HOAN_THANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
                .Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
                .Columns("MS_PHIEU_BAO_TRI").Width = 100
                .Columns("TT_SAU_BT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TT_SAU_BT", Commons.Modules.TypeLanguage)
                .Columns("TT_SAU_BT").Width = 80
                .Columns("MS_MAY_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("MS_MAY_THAY_THE").Width = 100
                .Columns("TEN_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("TEN_BO_PHAN_THAY_THE").Width = 100
                .Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
                .Columns("MO_TA_CV").Width = 80
                .Columns("MAY_TH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MAY_TH", Commons.Modules.TypeLanguage)
                .Columns("MAY_TH").Width = 100
                .Columns("TEN_BP_TH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BP_TH", Commons.Modules.TypeLanguage)
                .Columns("TEN_BP_TH").Width = 200
                .Columns("TEN_LOAI_BT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_LOAI_BT", Commons.Modules.TypeLanguage)
                .Columns("TEN_LOAI_BT").Width = 120
                .Columns("NHA_THAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_THAU", Commons.Modules.TypeLanguage)
                .Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
                .Columns("MO_TA_CV").Width = 200
                .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                .Columns("GHI_CHU").Width = 150
                'nhoc

            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtpTuNgay1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HienThiDuLieuLichSuThietBi()
    End Sub
    Private Sub dtpDenNgay1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HienThiDuLieuLichSuThietBi()
    End Sub
End Class