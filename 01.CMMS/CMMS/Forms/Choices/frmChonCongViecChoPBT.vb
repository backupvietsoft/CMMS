Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons
Imports System.Linq
Imports DevExpress.XtraTreeList.Nodes
Imports System.Text.RegularExpressions
Imports System.Text
Imports DevExpress.XtraEditors

Public Class frmChonCongViecChoPBT
    Private _MS_PHIEU_BAO_TRI As String = ""
    Private _MS_MAY As String = ""
    Private bCoTab1 As Boolean = False, bCoTab2 As Boolean = False, bCoTab21 As Boolean = False, bCoTab3 As Boolean = False
    Private khbtNew As String = ""

    Public Property MS_PHIEU_BAO_TRI() As String
        Get
            Return _MS_PHIEU_BAO_TRI
        End Get
        Set(ByVal value As String)
            _MS_PHIEU_BAO_TRI = value
        End Set
    End Property
    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

    Public Property KHBT_NEW() As String
        Get
            Return khbtNew
        End Get
        Set(ByVal value As String)
            khbtNew = value
        End Set
    End Property


    Private Sub frmChonCongViecChoPBT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName)
        Catch ex As Exception
        End Try
    End Sub
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmChonCongViecChoPBT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        dtTuNgay.DateTime = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 28)
        dtDenNgay.DateTime = dtTuNgay.DateTime.AddMonths(1)
        BindData1()
        BindData2()
        Dim str As String = ""
        Try
            str = "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [dbo].[InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "]" &
        " @MS_PHIEU_BAO_TRI NVARCHAR(30),@MS_CV INT,@MS_BO_PHAN NVARCHAR(50),@MS_PT NVARCHAR(255),@TEN_PT NVARCHAR(255),@SL_KH FLOAT,@NGAY_HOAN_THANH DATETIME,@MS_PT_CHA NVARCHAR(50),@MS_PT_NCC NVARCHAR(255),@MS_PT_CTY NVARCHAR(255) " &
        " AS INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,NGAY_HOAN_THANH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY) " &
        " VALUES(@MS_PHIEU_BAO_TRI,@MS_CV,@MS_BO_PHAN,@MS_PT,@TEN_PT,@SL_KH,@NGAY_HOAN_THANH,@MS_PT_CHA,@MS_PT_NCC,@MS_PT_CTY) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        CreateMenuCV(grdCV)
        Commons.Modules.SQLString = ""
        grvHangMuc_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Sub BindData1()
        Try
            grdHangMuc.DataSource = Nothing
            grvHangMuc.Columns.Clear()
        Catch ex As Exception

        End Try
        Try

            If khbtNew = "frmKehoachtongtheNew" Then

                'Commons.Modules.ObjSystems.MLoadXtraGrid(grdHangMuc, grvHangMuc, New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_DACH_KE_HOACH_THONG_THEs_KHBT(MS_MAY, Format(dtTuNgay.DateTime, "Short date"), Format(dtDenNgay.DateTime, "Short date"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI), False, True, True, True, True, "")
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdHangMuc, grvHangMuc, New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_DACH_KE_HOACH_THONG_THEs(MS_MAY, Format(dtTuNgay.DateTime, "Short date"), Format(dtDenNgay.DateTime, "Short date"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI), False, True, True, True, True, "")

            Else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdHangMuc, grvHangMuc, New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_DACH_KE_HOACH_THONG_THEs(MS_MAY, Format(dtTuNgay.DateTime, "Short date"), Format(dtDenNgay.DateTime, "Short date"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI), False, True, True, True, True, "")

            End If

            grvHangMuc.Columns("HANG_MUC_ID").Visible = False
            grvHangMuc.Columns("GHI_CHU").Visible = False

            If grvHangMuc.RowCount = 0 Then
                grdDSCongViec.DataSource = Nothing
                grdDSCongViec.DataSource = Nothing
            End If
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message.ToString + "1")
        End Try

    End Sub

    Private Sub btnThoat_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_1.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnThoat_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub ShoKHCV(ByVal row As Integer)
        Try

            Try
                grdDSCongViec.DataSource = Nothing
                grvDSCongViec.Columns.Clear()
            Catch ex As Exception

            End Try
            Commons.Modules.SQLString = "0Load"
            Dim dt As New DataTable
            Dim iHangMuc As Integer = -1


            Try
                iHangMuc = Integer.Parse(grvHangMuc.GetFocusedDataRow()("HANG_MUC_ID").ToString())
            Catch ex As Exception
                iHangMuc = -1
            End Try

            If khbtNew = "frmKehoachtongtheNew" Then
                'dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_KHBT(MS_MAY, iHangMuc, Commons.Modules.UserName, MS_PHIEU_BAO_TRI, grvHangMuc.GetFocusedDataRow()("KH_NAM"), grvHangMuc.GetFocusedDataRow("KH_THANG"))
                'dt.Columns("CHON").ReadOnly = False
                'Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCongViec, grvDSCongViec, dt, True, False, False, False, True, "")
                dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs(MS_MAY, grvHangMuc.GetFocusedDataRow()("HANG_MUC_ID").ToString(), Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
                dt.Columns("CHON").ReadOnly = False
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCongViec, grvDSCongViec, dt, True, False, False, False, True, "")
            Else
                dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs(MS_MAY, grvHangMuc.GetFocusedDataRow()("HANG_MUC_ID").ToString(), Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
                dt.Columns("CHON").ReadOnly = False
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCongViec, grvDSCongViec, dt, True, False, False, False, True, "")
            End If
            Commons.Modules.SQLString = ""
            If khbtNew = "frmKehoachtongtheNew" Then
                grvDSCongViec.Columns("ID").Visible = False
            End If
            grvDSCongViec.Columns("MS_MAY").Visible = False
            grvDSCongViec.Columns("HANG_MUC_ID").Visible = False
            grvDSCongViec.Columns("MS_CV").Visible = False
            grvDSCongViec.Columns("MS_BO_PHAN").Visible = False
            grvDSCongViec.Columns("MS_BAC_THO").Visible = False
            grvDSCongViec.Columns("MA_CV").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_BO_PHAN").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_CHUYEN_MON").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_BAC_THO").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("MA_CV").Width = 150
            grvDSCongViec.Columns("TEN_BO_PHAN").Width = 250
            grvDSCongViec.Columns("TEN_CHUYEN_MON").Width = 150
            grvDSCongViec.Columns("TEN_BAC_THO").Width = 150
            grvDSCongViec.Columns("THOI_GIAN_DU_KIEN").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("THOI_GIAN_DU_KIEN").Width = 80
            grvDSCongViec.Columns("THOI_GIAN_DU_KIEN").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            grvDSCongViec.Columns("THOI_GIAN_DU_KIEN").AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.HorzAlignment.Far
            grvDSCongViec.Columns("CHON").Width = 60

            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN, ISNULL(HANG_MUC_ID,-1) AS HANG_MUC_ID FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            For i As Integer = 0 To tb.Rows.Count - 1
                For j As Integer = 0 To grvDSCongViec.RowCount - 1
                    If tb.Rows(i).Item("HANG_MUC_ID") = grvDSCongViec.GetDataRow(j)("HANG_MUC_ID") And tb.Rows(i).Item("MS_CV") = grvDSCongViec.GetDataRow(j)("MS_CV") And tb.Rows(i).Item("MS_BO_PHAN") = grvDSCongViec.GetDataRow(j)("MS_BO_PHAN") Then
                        grvDSCongViec.SetRowCellValue(j, "CHON", True)
                        grvDSCongViec.UpdateCurrentRow()
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message.ToString + "3")
        End Try


    End Sub
    Sub BindData2()
        ShowTree()
    End Sub

    Sub ShowTree()

        Dim SqlText1 As String
        Try

            SqlText1 = "SELECT MS_BO_PHAN, MS_BO_PHAN_CHA, (MS_BO_PHAN + ': ' + TEN_BO_PHAN) AS TEN_BO_PHAN  FROM CAU_TRUC_THIET_BI WHERE MS_MAY = N'" + MS_MAY + "' ORDER BY ISNULL(STT,999), MS_BO_PHAN"

            trvCTruc.KeyFieldName = "MS_BO_PHAN"
            trvCTruc.ParentFieldName = "MS_BO_PHAN_CHA"
            Dim dtTmp As New DataTable



            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText1))
            trvCTruc.DataSource = dtTmp



            trvCTruc.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpDanhsachcautruc", Commons.Modules.TypeLanguage) + ": " + MS_MAY
            trvCTruc.ExpandAll()

        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message.ToString + "2")
        End Try

    End Sub
    Private Sub btnThuchien_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThuchien_2.Click
        DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Sub ShowKHCVPT(ByVal row As Integer)

        Try
            grdDSPhuTung.DataSource = Nothing
            grvDSPhuTung.Columns.Clear()
        Catch ex As Exception
        End Try
        Try

            Dim dt As New DataTable
            If khbtNew = "frmKehoachtongtheNew" Then
                dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs_KHBT(MS_MAY, grvDSCongViec.GetFocusedDataRow()("HANG_MUC_ID"), grvDSCongViec.GetFocusedDataRow()("MS_CV"), grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI, grvDSCongViec.GetFocusedDataRow()("KH_NAM"), grvDSCongViec.GetFocusedDataRow()("KH_THANG"))
                dt.Columns("CHON").ReadOnly = False
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPhuTung, grvDSPhuTung, dt, True, True, True, True, True, "")
            Else
                dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs(MS_MAY, grvDSCongViec.GetFocusedDataRow()("HANG_MUC_ID"), grvDSCongViec.GetFocusedDataRow()("MS_CV"), grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
                dt.Columns("CHON").ReadOnly = False
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPhuTung, grvDSPhuTung, dt, True, True, True, True, True, "")
            End If
            grvDSPhuTung.Columns("CHON").Width = 60
            grvDSPhuTung.Columns("MS_MAY").Visible = False
            grvDSPhuTung.Columns("HANG_MUC_ID").Visible = False
            grvDSPhuTung.Columns("MS_CV").Visible = False
            grvDSPhuTung.Columns("MS_BO_PHAN").Visible = False
            grvDSPhuTung.Columns("MS_PT").Visible = False
            grvDSPhuTung.Columns("MS_PT_CHA").Visible = False
            grvDSPhuTung.Columns("TEN_PT").OptionsColumn.ReadOnly = True
            grvDSPhuTung.Columns("MS_PT_NCC").OptionsColumn.ReadOnly = True
            grvDSPhuTung.Columns("MS_PT_CTY").OptionsColumn.ReadOnly = True
            grvDSPhuTung.Columns("SL_KH").OptionsColumn.ReadOnly = True
            grvDSPhuTung.Columns("TEN_1").OptionsColumn.ReadOnly = True
            grvDSPhuTung.Columns("TEN_PT").Width = 197
            grvDSPhuTung.Columns("SL_KH").Width = 50
            grvDSPhuTung.Columns("MS_PT_NCC").Width = 150
            grvDSPhuTung.Columns("MS_PT_CTY").Width = 110
            grvDSPhuTung.Columns("TEN_1").Width = 100


            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE  MS_CV='" & grvDSCongViec.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN='" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "' "
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            For i As Integer = 0 To tb.Rows.Count - 1
                For j As Integer = 0 To grvDSPhuTung.RowCount - 1
                    If tb.Rows(i).Item("MS_PT") = grvDSPhuTung.GetDataRow(j)("MS_PT") Then
                        grvDSPhuTung.SetRowCellValue(j, "CHON", True)
                        grvDSPhuTung.UpdateCurrentRow()
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message.ToString + "4")
        End Try

    End Sub
    Dim row As Integer = 0
    Private bCoCV_HM As Boolean


    Private Sub btnThoat_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat_2.Click
        Me.Close()
    End Sub
    Sub ShowDanhmucCV(ByVal MS_BO_PHAN As String)
        Try
            Try
                grdCV.DataSource = Nothing
                grvCV.Columns.Clear()
            Catch ex As Exception

            End Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_CONG_VIECs", MS_MAY, MS_BO_PHAN, Commons.Modules.UserName, MS_PHIEU_BAO_TRI))
            dtTmp.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dtTmp, True, True, True, True, True, "")



            For i As Integer = 1 To grvCV.Columns.Count - 1
                grvCV.Columns(i).OptionsColumn.ReadOnly = True
            Next
            grvCV.Columns("CHON").OptionsColumn.ReadOnly = False
            grvCV.Columns("MS_MAY").Visible = False
            grvCV.Columns("MS_BO_PHAN").Visible = False
            grvCV.Columns("MS_CV").Visible = False
            grvCV.Columns("THOI_GIAN_DU_KIEN").Visible = True
            grvCV.Columns("DINH_MUC").Visible = False
            grvCV.Columns("NGOAI_TE").Visible = False
            grvCV.Columns("MS_BAC_THO").Visible = False

            grvCV.Columns("TEN_CHUYEN_MON").Visible = False
            grvCV.Columns("TEN_BAC_THO").Visible = False


            grvCV.Columns("THAO_TAC").Visible = False
            grvCV.Columns("TIEU_CHUAN_KT").Visible = False
            grvCV.Columns("PATH_HD").Visible = False
            grvCV.Columns("YEU_CAU_NS").Visible = False

            grvCV.Columns("THOI_GIAN_DU_KIEN").Width = 60
            grvCV.Columns("SO_NGUOI").Width = 60
            grvCV.Columns("CHON").Width = 60
            grvCV.Columns("MA_CV").Width = 200
            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI, MS_CV, MA_CV, MS_BO_PHAN,  SO_GIO_KH,  DINH_MUC_PB, THUC_KIEM, GHI_CHU, THAO_TAC, TIEU_CHUAN_KT, PATH_HD, SO_NGUOI, YEU_CAU_DUNG_CU, YCSD, ISNULL(TON_TAI, 0) TON_TAI FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            Dim dtCV As DataTable = CType(grdCV.DataSource, DataTable)
            For i As Integer = 0 To tb.Rows.Count - 1
                Dim msBP = tb.Rows(i)("MS_BO_PHAN")
                Dim msCV = tb.Rows(i)("MS_CV")

                If dtCV.Select().AsEnumerable().Any(Function(x) x("MS_BO_PHAN") = msBP And msCV = x("MS_CV")) Then
                    Dim dr As DataRow = dtCV.Select().AsEnumerable().Where(Function(x) x("MS_BO_PHAN") = msBP And msCV = x("MS_CV")).SingleOrDefault()
                    dr("CHON") = True
                ElseIf dtCV.Select().AsEnumerable().Any(Function(x) x("MS_BO_PHAN") = msBP) = True And (tb.Rows(i)("TON_TAI") Is Nothing Or tb.Rows(i)("TON_TAI") <> True) Then
                    Dim dr As DataRow = dtCV.NewRow()
                    dr("MS_MAY") = MS_MAY
                    dr("MS_BO_PHAN") = tb.Rows(i)("MS_BO_PHAN")
                    dr("MS_CV") = tb.Rows(i)("MS_CV")
                    dr("THOI_GIAN_DU_KIEN") = tb.Rows(i)("SO_GIO_KH")
                    dr("DINH_MUC") = tb.Rows(i)("DINH_MUC_PB")
                    dr("THAO_TAC") = tb.Rows(i)("THAO_TAC")
                    dr("TIEU_CHUAN_KT") = tb.Rows(i)("TIEU_CHUAN_KT")
                    dr("PATH_HD") = tb.Rows(i)("PATH_HD")
                    dr("YEU_CAU_NS") = tb.Rows(i)("YCSD")
                    dr("SO_NGUOI") = tb.Rows(i)("SO_NGUOI")
                    dr("CHON") = True
                    dr("MA_CV") = tb.Rows(i)("MA_CV")
                    dtCV.Rows.Add(dr)
                End If
                dtCV.AcceptChanges()
                'For j As Integer = 0 To grvCV.RowCount - 1
                '    If tb.Rows(i).Item("MS_BO_PHAN") = grvCV.GetRowCellValue(j, "MS_BO_PHAN").ToString Then
                '        If (tb.Rows(i).Item("MS_CV") = grvCV.GetRowCellValue(j, "MS_CV").ToString) Then
                '            grvCV.SetRowCellValue(j, "CHON", True)
                '        ElseIf (tb.Rows(i)("TON_TAI") Is Nothing Or tb.Rows(i)("TON_TAI") <> True) Then

                '        End If

                '    End If
                'Next
            Next

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Dim node As TreeNode
    Private Sub btnThucHien_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private bCoCV_EOR As Boolean = False
    Private bCo_CVPT As Boolean
    Dim tmp As Boolean = False
    Private bCoPT As Boolean

    Private Sub BtnThuchien3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThuchien3.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private arrThietBiNode As New List(Of String)

    Private nodes As TreeListNodes = Nothing

    Private Sub txtGiatri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiatri.KeyDown
        Try
            If (e.KeyCode = 13) Then
                TimkiemCauTrucThietBi(txtGiatri.Text, trvCTruc)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function ConvertToUnsign3(str As String) As String
        Dim regex As New Regex("\p{IsCombiningDiacriticalMarks}+")
        Dim temp As String = str.Normalize(NormalizationForm.FormD)
        Return regex.Replace(temp, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
    End Function

    Private Sub TimkiemCauTrucThietBi(ByVal keyword As String, ByVal treeView As DevExpress.XtraTreeList.TreeList)
        Try
            If keyword = "" Then Exit Sub
            If IsDBNull(keyword) Then Exit Sub
            Static i As Integer
            Dim oNode As TreeListNode
            Static Dim strOldThietBiNode As String
            Dim ie As TreeListNodes = treeView.Nodes
            If Trim(strOldThietBiNode) <> "" And Trim(strOldThietBiNode) = Trim(keyword) Then
                i += 1
                If arrThietBiNode.Count <= 0 Then Exit Sub
                If i >= arrThietBiNode.Count Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT32", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        i = 0
                    Else
                        Exit Sub
                    End If
                End If

                oNode = treeView.FindNodeByFieldValue("MS_BO_PHAN", arrThietBiNode(i))
                treeView.FocusedNode = oNode
            Else
                i = 0
                arrThietBiNode.Clear()
                strOldThietBiNode = keyword
                parseThietBiNode(ie, keyword)
                If arrThietBiNode.Count <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT33", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    strOldThietBiNode = 0
                    Exit Sub
                End If
                oNode = treeView.FindNodeByFieldValue("MS_BO_PHAN", arrThietBiNode(i))
                treeView.FocusedNode = oNode

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub parseThietBiNode(ByVal tn As TreeListNodes, ByVal tenNode As String)


        For Each node As TreeListNode In tn
            If (node("MS_BO_PHAN").ToString().Contains(tenNode)) Then
                arrThietBiNode.Add(node("MS_BO_PHAN"))
            ElseIf (ConvertToUnsign3(node("TEN_BO_PHAN").ToString().ToLower()).Contains(ConvertToUnsign3(tenNode.ToLower()))) Then
                arrThietBiNode.Add(node("MS_BO_PHAN"))
            End If
            If (node.Nodes.Count > 0) Then
                parseThietBiNode(node.Nodes, tenNode)
            End If
        Next

    End Sub

    Private Sub rdChontheoma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtGiatri.Text = ""
        txtGiatri.Focus()
    End Sub




    Private Sub btnThemCV_Click(sender As Object, e As EventArgs) Handles btnThemCV.Click
        Try

            If trvCTruc.FocusedNode("MS_BO_PHAN").ToString() = MS_MAY Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "MsgQuyenKT26", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim frmChonCVChoBP As New FrmChonCongViecBoPhan()
            frmChonCVChoBP.SO_DONG = grvCV.RowCount
            frmChonCVChoBP.MS_BO_PHAN = trvCTruc.FocusedNode("MS_BO_PHAN").ToString()
            frmChonCVChoBP.MS_LOAI_MAY = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select MS_LOAI_MAY from NHOM_MAY WHERE MS_NHOM_MAY = (SELECT MS_NHOM_MAY FROM MAY WHERE MS_MAY = '" & MS_MAY & "')")
            frmChonCVChoBP.MS_MAY = MS_MAY
            frmChonCVChoBP.formName = "PhieuBaoTri"
            frmChonCVChoBP.dtTableTam = New DataTable()
            frmChonCVChoBP.ShowDialog()

            frmChonCVChoBP.dtTableTam.DefaultView.RowFilter = "CHON = TRUE"
            frmChonCVChoBP.dtTableTam = frmChonCVChoBP.dtTableTam.DefaultView.ToTable()


            Dim sSql As String = ""
            Dim dtTmp As DataTable = CType(grdCV.DataSource, DataTable)
            If (frmChonCVChoBP.dtTableTam.Rows.Count > 0) Then
                For Each cv As FrmChonCongViecBoPhan.CV_TMP In frmChonCVChoBP.lstMsCV
                    Try
                        If dtTmp.Select().Any(Function(x) x("MS_CV") = cv.MS_CV) Then Continue For
                        Dim dr = dtTmp.NewRow()
                        dr("MS_MAY") = MS_MAY
                        dr("MS_CV") = cv.MS_CV
                        dr("MS_BO_PHAN") = trvCTruc.FocusedNode("MS_BO_PHAN").ToString()
                        dr("MA_CV") = cv.MO_TA_CV
                        dr("THOI_GIAN_DU_KIEN") = cv.THOI_GIAN_DU_KIEN
                        dr("SO_NGUOI") = 0
                        dr("DINH_MUC") = 0
                        dr("THAO_TAC") = cv.THAO_TAC
                        dr("TIEU_CHUAN_KT") = cv.TIEU_CHUAN_KT
                        dr("YEU_CAU_DUNG_CU") = cv.YEU_CAU_DUNG_CU
                        dr("PATH_HD") = cv.PATH_HD
                        dr("CHON") = True
                        dtTmp.Rows.Add(dr)
                        dtTmp.AcceptChanges()

                        Dim str As String = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI, MS_CV, MA_CV, MS_BO_PHAN, TEN_BO_PHAN, SO_GIO_KH, NGAY_BDCV, NGAY_KTCV , SO_GIO_PB , DINH_MUC_PB , HANG_MUC_ID,TEN_HANG_MUC,EOR_ID, THUC_KIEM,GHI_CHU ,  THAO_TAC ,  TIEU_CHUAN_KT ,PATH_HD ,SO_NGUOI ,YEU_CAU_DUNG_CU ) SELECT '" & MS_PHIEU_BAO_TRI & "', " & cv.MS_CV & ", N'" & cv.MO_TA_CV & "','" & trvCTruc.FocusedNode("MS_BO_PHAN").ToString() & "', N'" & trvCTruc.FocusedNode("TEN_BO_PHAN").ToString().Split(":")(1).Trim() & "', " & cv.THOI_GIAN_DU_KIEN & ", NULL,NULL," & cv.THOI_GIAN_DU_KIEN & "," & 0 & ", NULL, NULL, NULL, NULL, NULL, N'" & cv.THAO_TAC & "', N'" & cv.TIEU_CHUAN_KT & "', N'" & cv.PATH_HD & "', " & 0 & ", N'" & cv.YEU_CAU_DUNG_CU & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)



                    Catch
                    End Try
                Next
            End If
        Catch
        End Try
    End Sub

    Public Function GetFullPath(ByVal node As TreeListNode, ByVal pathSeparator As String) As String
        If node Is Nothing Then
            Return ""
        End If
        Dim result As String = ""
        Do While node IsNot Nothing
            result = pathSeparator & node.GetDisplayText(0) & result
            node = node.ParentNode
        Loop
        Return MS_MAY + result
    End Function



    Private Sub grvCV_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvCV.ValidateRow
        Try
            Dim str As String = ""
            If Convert.ToBoolean(grvCV.GetFocusedRow("CHON").ToString) Then
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE MS_CV=" & grvCV.GetFocusedRow("MS_CV").ToString & " AND MS_BO_PHAN='" & grvCV.GetFocusedRow("MS_BO_PHAN").ToString & "'"
                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    objRead.Close()
                    Exit Sub
                End While
                objRead.Close()

                Dim iMSCv As Integer = Convert.ToInt32(grvCV.GetFocusedRow("MS_CV").ToString)
                Dim sMsCv As String = grvCV.GetFocusedRow("MA_CV").ToString
                Dim sMS_BO_PHAN As String = grvCV.GetFocusedRow("MS_BO_PHAN").ToString
                Dim dTGDK As Double = IIf(String.IsNullOrEmpty(grvCV.GetFocusedRow("THOI_GIAN_DU_KIEN").ToString), 0, Convert.ToDouble(grvCV.GetFocusedRow("THOI_GIAN_DU_KIEN").ToString))
                Dim dDinhMuc As Double = Nothing

                Try
                    dDinhMuc = Convert.ToDouble(grvCV.GetFocusedRow("DINH_MUC").ToString)
                Catch ex As Exception
                    dDinhMuc = Nothing
                End Try

                Dim dSoNguoi As Double = IIf(String.IsNullOrEmpty(grvCV.GetFocusedRow("SO_NGUOI").ToString), 0, Convert.ToInt32(grvCV.GetFocusedRow("SO_NGUOI").ToString))

                Dim sDMuc As String = grvCV.GetFocusedRow("DINH_MUC").ToString
                Dim sNGOAI_TE As String = grvCV.GetFocusedRow("NGOAI_TE").ToString
                Dim sTHAO_TAC As String = grvCV.GetFocusedRow("THAO_TAC").ToString
                Dim sTIEU_CHUAN_KT As String = grvCV.GetFocusedRow("TIEU_CHUAN_KT").ToString
                Dim sPATH_HD As String = grvCV.GetFocusedRow("PATH_HD").ToString
                Dim sYEU_CAU_DUNG_CU As String = grvCV.GetFocusedRow("YEU_CAU_DUNG_CU").ToString

                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI, MS_CV, MA_CV, MS_BO_PHAN, TEN_BO_PHAN, SO_GIO_KH, NGAY_BDCV, NGAY_KTCV , SO_GIO_PB , DINH_MUC_PB , HANG_MUC_ID,TEN_HANG_MUC,EOR_ID, THUC_KIEM,GHI_CHU ,  THAO_TAC ,  TIEU_CHUAN_KT ,PATH_HD ,SO_NGUOI ,YEU_CAU_DUNG_CU ) SELECT '" & MS_PHIEU_BAO_TRI & "', " & iMSCv & ", N'" & sMsCv & "','" & sMS_BO_PHAN & "', N'" & trvCTruc.FocusedNode("TEN_BO_PHAN").ToString().Split(":")(1).Trim() & "', " & dTGDK & ", NULL,NULL," & dTGDK & "," & dDinhMuc & ", NULL, NULL, NULL, NULL, NULL, N'" & sTHAO_TAC & "', N'" & sTIEU_CHUAN_KT & "', N'" & sPATH_HD & "', " & dSoNguoi & ", N'" & sYEU_CAU_DUNG_CU & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)


            ElseIf Not Convert.ToBoolean(grvCV.GetFocusedRow("CHON").ToString) Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV= N'" & grvCV.GetFocusedRow("MS_CV").ToString & "' AND MS_BO_PHAN = N'" & grvCV.GetFocusedRow("MS_BO_PHAN").ToString & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " WHERE MS_CV = N'" & grvCV.GetFocusedRow("MS_CV").ToString & "' AND MS_BO_PHAN = N'" & grvCV.GetFocusedRow("MS_BO_PHAN").ToString & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE MS_CV = N'" & grvCV.GetFocusedRow("MS_CV").ToString & "' AND MS_BO_PHAN = N'" & grvCV.GetFocusedRow("MS_BO_PHAN").ToString & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If

        Catch ex As Exception
            e.Valid = False
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub grvCV_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvCV.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvHangMuc_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvHangMuc.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        ShoKHCV(grvHangMuc.FocusedRowHandle)
        grvDSCongViec_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub dtTuNgay_EditValueChanged(sender As Object, e As EventArgs) Handles dtTuNgay.EditValueChanged, dtDenNgay.EditValueChanged
        Try
            If (Commons.Modules.SQLString = "0Load") Then Exit Sub
            BindData1()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grvDSCongViec_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSCongViec.CellValueChanged
        Try
            If e.Column.FieldName = "CHON" Then
                Dim str As String = ""
                If grvDSCongViec.GetFocusedDataRow()("CHON") Then
                    str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE MS_CV=" & grvDSCongViec.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                    Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objRead.Read
                        objRead.Close()
                        Exit Sub
                    End While
                    objRead.Close()
                    Dim msbactho As String = grvDSCongViec.GetFocusedDataRow()("MS_BAC_THO").ToString()

                    Dim sql1 As String = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI,MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH,NGAY_BDCV,NGAY_KTCV ,SO_GIO_PB ,DINH_MUC_PB , HANG_MUC_ID,TEN_HANG_MUC,EOR_ID,THUC_KIEM,GHI_CHU ,TON_TAI,  THAO_TAC , TIEU_CHUAN_KT ,PATH_HD ,SO_NGUOI,YEU_CAU_DUNG_CU , YCSD ) " & " values('" & MS_PHIEU_BAO_TRI & "' , " & grvDSCongViec.GetFocusedDataRow()("MS_CV") & " , N'" & grvDSCongViec.GetFocusedDataRow()("MA_CV") & "' , '" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "', N'" &
                    grvDSCongViec.GetFocusedDataRow()("TEN_BO_PHAN") & "'," & grvDSCongViec.GetFocusedDataRow()("THOI_GIAN_DU_KIEN") & ", " & " NULL,NULL," & grvDSCongViec.GetFocusedDataRow()("THOI_GIAN_DU_KIEN") & " ,NULL" & "," &
                     grvHangMuc.GetFocusedDataRow()("HANG_MUC_ID") & ", N'" & grvHangMuc.GetFocusedDataRow()("TEN_HANG_MUC") + "',N'" &
                    grvDSCongViec.GetFocusedDataRow()("TEN_CHUYEN_MON") & "'," & " NULL,NULL,NULL " & ",N'" & grvDSCongViec.GetFocusedDataRow()("THAO_TAC") + "',N'" + grvDSCongViec.GetFocusedDataRow()("TIEU_CHUAN_KT") & "',N'" & grvDSCongViec.GetFocusedDataRow()("PATH_HD") & "'," & grvDSCongViec.GetFocusedDataRow()("SO_NGUOI") & ",N'" & grvDSCongViec.GetFocusedDataRow()("YEU_CAU_DUNG_CU") & "'," & 0 & ")"




                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql1)

                    For j As Integer = 0 To grvDSPhuTung.RowCount - 1
                        Dim SL_KH As Double = 1
                        SL_KH = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text,
                                    "Select SUM (SO_LUONG) FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY = '" & MS_MAY & "' " &
                                    " AND MS_BO_PHAN = '" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "' " &
                                    " AND MS_PT = '" & grvDSPhuTung.GetDataRow(j)("MS_PT") & "' " &
                                    " GROUP BY MS_MAY, MS_BO_PHAN,MS_PT")

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,
                                "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI,
                                grvDSCongViec.GetFocusedDataRow()("MS_CV"),
                                grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN"),
                                grvDSPhuTung.GetDataRow(j)("MS_PT"), grvDSPhuTung.GetDataRow(j)("TEN_PT"),
                                SL_KH, Nothing, grvDSPhuTung.GetDataRow(j)("MS_PT_CHA"),
                                IIf(IsDBNull(grvDSPhuTung.GetDataRow(j)("MS_PT_NCC")), Nothing,
                                grvDSPhuTung.GetDataRow(j)("MS_PT_NCC")),
                                grvDSPhuTung.GetDataRow(j)("MS_PT_CTY"))
                    Next

                ElseIf Not grvDSCongViec.GetFocusedDataRow()("CHON") Then
                    str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSCongViec.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSCongViec.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                    For j As Integer = 0 To grvDSPhuTung.RowCount - 1
                        str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" &
                                grvDSCongViec.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN ='" &
                                grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT ='" &
                                grvDSPhuTung.GetDataRow(j)("MS_PT") & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Next
                End If
                tmp = False
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub grvDSCongViec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDSCongViec.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        ShowKHCVPT(grvDSCongViec.FocusedRowHandle)
    End Sub

    Private Sub grvDSPhuTung_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSPhuTung.CellValueChanged
        tmp = True
        If e.Column.FieldName = "CHON" Then
            Dim str As String = ""
            If grvDSPhuTung.GetFocusedDataRow()("CHON") Then

                If Not grvDSCongViec.GetFocusedDataRow()("CHON") Then
                    grvDSCongViec.SetFocusedRowCellValue("CHON", True)
                    grvDSCongViec.UpdateCurrentRow()
                End If



                Dim SL_KH As Double = 1
                SL_KH = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT SUM (SO_LUONG) FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY = '" & MS_MAY & "' AND MS_BO_PHAN = '" & grvDSPhuTung.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT = '" & grvDSPhuTung.GetFocusedDataRow()("MS_PT") & "' GROUP BY MS_MAY, MS_BO_PHAN,MS_PT")

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, grvDSPhuTung.GetFocusedDataRow()("MS_CV"), grvDSPhuTung.GetFocusedDataRow()("MS_BO_PHAN"),
                 grvDSPhuTung.GetFocusedDataRow()("MS_PT"), grvDSPhuTung.GetFocusedDataRow()("TEN_PT"),
                  SL_KH, Nothing, grvDSPhuTung.GetFocusedDataRow()("MS_PT_CHA"), IIf(IsDBNull(grvDSPhuTung.GetFocusedDataRow()("MS_PT_NCC")), Nothing, grvDSPhuTung.GetFocusedDataRow()("MS_PT_NCC")), grvDSPhuTung.GetFocusedDataRow()("MS_PT_CTY"))
            ElseIf Not grvDSPhuTung.GetFocusedDataRow()("CHON") Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSPhuTung.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSPhuTung.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT ='" & grvDSPhuTung.GetFocusedDataRow()("MS_PT") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub txtSearch_EditValueChanged(sender As Object, e As EventArgs) Handles txtSearch.EditValueChanged
        Try
            Dim dtTmp As New DataTable
            Dim sStmp As String = ""
            Try

                dtTmp = CType(grdDSCongViec.DataSource, DataTable)
                If txtSearch.Text <> "" Then
                    sStmp = sStmp & " (MA_CV LIKE '%" & txtSearch.Text & "%') "
                    sStmp = sStmp & " OR (THAO_TAC LIKE '%" & txtSearch.Text & "%') "
                End If
                If sStmp.Length > 1 Then
                    dtTmp.DefaultView.RowFilter = sStmp
                Else
                    dtTmp.DefaultView.RowFilter = ""
                End If
                dtTmp = dtTmp.DefaultView.ToTable()
            Catch ex As Exception
                dtTmp.DefaultView.RowFilter = ""
                dtTmp = dtTmp.DefaultView.ToTable()
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub grvCV_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvCV.CellValueChanged

    End Sub

    Private Sub trvCTruc_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles trvCTruc.FocusedNodeChanged
        nodes = Nothing
        txtDuongdan.Text = GetFullPath(trvCTruc.FocusedNode, "\")
        If e.Node.GetValue("MS_BO_PHAN").ToString() = MS_MAY Then Exit Sub
        ShowDanhmucCV(trvCTruc.FocusedNode("MS_BO_PHAN").ToString())
    End Sub

#Region "TaoMeNuCongViec"
    Private Sub CreateMenuCV(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)

        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkAddCV", Commons.Modules.TypeLanguage)
        Dim mnuAddCV As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuAddCV.Name = "mnuAddCV"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec})


        BarManager.EndUpdate()
    End Sub
    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return

        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim dt As New DataTable()
        Try
            Select Case e.Item.Name.ToUpper
                Case "mnuCongViec".ToUpper
                    Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuWork' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If (dt.Rows.Count = 0) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Dim frmDanhmuccongviec As New MVControl.frmDanhmuccongviec
                    Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmDanhmuccongviec.Name)

                    Dim sMaSo As String
                    sMaSo = grv.GetFocusedDataRow("MS_CV").ToString() 'sMaSo = grd.SelectedRows(0).Cells("MS_CV").ToString
                    frmDanhmuccongviec.MS_CVIEC = sMaSo
                    frmDanhmuccongviec.Size = New Size(900, 600)
                    frmDanhmuccongviec.ShowDialog()
                    ShowDanhmucCV(trvCTruc.FocusedNode("MS_BO_PHAN").ToString())
            End Select
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class