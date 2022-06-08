Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data

Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraTreeList.Nodes
Imports System.Text
Imports System.Text.RegularExpressions
Imports Commons
Imports System.Linq
Imports DevExpress.XtraEditors

Public Class frmChonCongViecChoPBT_ThueNgoai
    Private _MS_PHIEU_BAO_TRI As String = ""
    Private _MS_MAY As String = ""
    Private _STT_EOR As Integer = -1
    Private _CONG_VIEC_DV_THUE_NGOAI As Boolean = False

    Private bCoTab1 As Boolean = False, bCoTab2 As Boolean = False, bCoTab21 As Boolean = False, bCoTab3 As Boolean = False
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
    Public Property STT_EOR() As Integer
        Get
            Return _STT_EOR
        End Get
        Set(ByVal value As Integer)
            _STT_EOR = value
        End Set
    End Property
    Public Property CONG_VIEC_DV_THUE_NGOAI() As Boolean
        Get
            Return _CONG_VIEC_DV_THUE_NGOAI
        End Get
        Set(ByVal value As Boolean)
            _CONG_VIEC_DV_THUE_NGOAI = value
        End Set
    End Property
    Dim flagLoad = False
    Sub New()
        flagLoad = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmChonCongViecChoPBT_ThueNgoai_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmChonCongViecChoPBT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        flagLoad = True


        dtTuNgay.DateTime = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 28)
        dtDenNgay.DateTime = dtTuNgay.DateTime.AddMonths(1)


        BindData1()
        BindData2()
        flagLoad = False

        Dim str As String = ""
        Try
            str = "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [dbo].[InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & "]" &
       " @MS_PHIEU_BAO_TRI NVARCHAR(30),@MS_CV INT,@MS_BO_PHAN NVARCHAR(50),@MS_PT NVARCHAR(255),@TEN_PT NVARCHAR(255),@SL_KH FLOAT,@MS_PT_CHA NVARCHAR(50),@MS_PT_NCC NVARCHAR(255),@MS_PT_CTY NVARCHAR(255),@SL_CUM FLOAT,@MS_VI_TRI_PT NVARCHAR(50) " &
       " AS INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,SL_CUM,MS_VI_TRI_PT) " &
       " VALUES(@MS_PHIEU_BAO_TRI,@MS_CV,@MS_BO_PHAN,@MS_PT,@TEN_PT,@SL_KH,@MS_PT_CHA,@MS_PT_NCC,@MS_PT_CTY,@SL_CUM,@MS_VI_TRI_PT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        txtGiatri.Focus()

        If _CONG_VIEC_DV_THUE_NGOAI = True Then TabControl1.TabPages.Remove(tabChonTuKeHoachTongThe)
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        CreateMenuCV(grdCV)
        flagLoad = False
        grvHangMuc_FocusedRowChanged(Nothing, Nothing)

    End Sub
    Sub BindData1()
        If (flagLoad = True) Then Exit Sub
        Try
            grdHangMuc.DataSource = Nothing
            grvHangMuc.Columns.Clear()
        Catch ex As Exception
        End Try
        Try

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHangMuc, grvHangMuc, New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_DACH_KE_HOACH_THONG_THEs_THUE_NGOAI(MS_MAY, Format(dtTuNgay.DateTime, "Short date"), Format(dtDenNgay.DateTime, "Short date"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI), False, True, True, True, True, "")
            grvHangMuc.Columns("HANG_MUC_ID").Visible = False
            grvHangMuc.Columns("GHI_CHU").Visible = False
            If grvHangMuc.RowCount = 0 Then
                grdDSCongViec.DataSource = Nothing
                grdDSCongViec.DataSource = Nothing
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub btnThoat_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_1.Click
        Me.Close()
    End Sub

    Private Sub btnThoat_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub ShoKHCV(ByVal row As Integer)

        If grdHangMuc.DataSource = Nothing Then Exit Sub

        Try
            grdDSCongViec.DataSource = Nothing
            grvDSCongViec.Columns.Clear()
        Catch ex As Exception

        End Try
        flagLoad = True
        Dim dt As New DataTable
        Try

            dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_THUE_NGOAI(MS_MAY, grvHangMuc.GetFocusedDataRow()("HANG_MUC_ID"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
            dt.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCongViec, grvDSCongViec, dt, True, False, False, False, True, "")

            flagLoad = False



            grvDSCongViec.Columns("MS_MAY").Visible = False
            grvDSCongViec.Columns("HANG_MUC_ID").Visible = False
            grvDSCongViec.Columns("MS_CV").Visible = False
            grvDSCongViec.Columns("MS_BO_PHAN").Visible = False
            grvDSCongViec.Columns("MA_CV").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_BO_PHAN").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_CHUYEN_MON").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("TEN_BAC_THO").OptionsColumn.ReadOnly = True
            grvDSCongViec.Columns("MA_CV").Width = 150
            grvDSCongViec.Columns("TEN_BO_PHAN").Width = 150
            grvDSCongViec.Columns("TEN_CHUYEN_MON").Width = 117
            grvDSCongViec.Columns("TEN_BAC_THO").Width = 100
            grvDSCongViec.Columns("CHON").Width = 50
            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            For i As Integer = 0 To tb.Rows.Count - 1
                For j As Integer = 0 To grvDSCongViec.RowCount - 1
                    If tb.Rows(i).Item("MS_CV") = grvDSCongViec.GetDataRow("MS_CV") And tb.Rows(i).Item("MS_BO_PHAN") = grvDSCongViec.GetDataRow("MS_BO_PHAN") Then
                        grvDSCongViec.SetRowCellValue(j, "CHON", True)
                        Exit For
                    End If
                Next
            Next


        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
        End Try

    End Sub
    Sub BindData2()
        ShowTreeRoot(MS_MAY)
    End Sub
    Sub ShowTreeRoot(ByVal sMS_MAY As String)

        Dim SqlText1 As String
        Try

            SqlText1 = "SELECT MS_BO_PHAN, MS_BO_PHAN_CHA, (MS_BO_PHAN + ': ' + TEN_BO_PHAN) AS TEN_BO_PHAN  FROM CAU_TRUC_THIET_BI WHERE MS_MAY = N'" + MS_MAY + "' ORDER BY ISNULL(STT,999), MS_BO_PHAN"

            tvwCautrucTB.KeyFieldName = "MS_BO_PHAN"
            tvwCautrucTB.ParentFieldName = "MS_BO_PHAN_CHA"
            Dim dtTmp As New DataTable



            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText1))
            tvwCautrucTB.DataSource = dtTmp



            tvwCautrucTB.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpDanhsachcautruc", Commons.Modules.TypeLanguage) + ": " + MS_MAY
            tvwCautrucTB.ExpandAll()


        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
        End Try

    End Sub

    Dim intRowHM As Integer = 0


    Private Sub btnThuchien_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThuchien_2.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Sub ShowKHCVPT(ByVal row As Integer)
        If grdDSCongViec.DataSource = Nothing Then Exit Sub

        Try
            grdDSPhuTung.DataSource = Nothing
            grvDSPhuTung.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim dt As New DataTable
        Try

            dt = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs(MS_MAY, grvDSCongViec.GetFocusedDataRow()("HANG_MUC_ID"), grvDSCongViec.GetFocusedDataRow()("MS_CV"), grvDSCongViec.GetFocusedDataRow()("MS_BO_PHAN"), Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
            dt.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPhuTung, grvDSPhuTung, dt, True, True, True, True, True, "")

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
            grvDSPhuTung.Columns("TEN_PT").Width = 150
            grvDSPhuTung.Columns("SL_KH").Width = 50
            grvDSPhuTung.Columns("MS_PT_NCC").Width = 120
            grvDSPhuTung.Columns("MS_PT_CTY").Width = 110
            grvDSPhuTung.Columns("TEN_1").Width = 83
            grvDSPhuTung.Columns("CHON").Width = 50

            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE  MS_CV='" & grvDSCongViec.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN='" & grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN") & "' "
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
            XtraMessageBox.Show(ex.Message.ToString)
        End Try


    End Sub
    Dim row As Integer = 0



    Private Sub btnThoat_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub
    Sub ShowDanhmucCV(ByVal MS_BO_PHAN As String)
        If (flagLoad = True) Then Exit Sub

        Try
            grdCV.DataSource = Nothing
            grvCV.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim dt As New DataTable

        dt = New Commons.clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_CAU_TRUC_THIET_BI_CONG_VIECs(MS_MAY, MS_BO_PHAN, Commons.Modules.UserName, MS_PHIEU_BAO_TRI)
        dt.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dt, True, False, False, False, True, "")

        grvCV.Columns("MS_MAY").Visible = False
        grvCV.Columns("MS_BO_PHAN").Visible = False
        grvCV.Columns("MS_CV").Visible = False
        grvCV.Columns("MA_CV").OptionsColumn.ReadOnly = True
        grvCV.Columns("TEN_CHUYEN_MON").OptionsColumn.ReadOnly = True
        grvCV.Columns("TEN_BAC_THO").OptionsColumn.ReadOnly = True
        grvCV.Columns("MA_CV").Width = 200
        grvCV.Columns("TEN_CHUYEN_MON").Width = 150
        grvCV.Columns("TEN_BAC_THO").Width = 150
        grvCV.Columns("CHON").Width = 55

        Dim str As String = ""
        Dim tb As New DataTable
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb.Rows.Count - 1
            For j As Integer = 0 To grvCV.RowCount - 1
                If tb.Rows(i).Item("MS_CV") = grvCV.GetDataRow(j)("MS_CV") And tb.Rows(i).Item("MS_BO_PHAN") = grvCV.GetDataRow(j)("MS_BO_PHAN") Then
                    grvCV.SetRowCellValue(j, "CHON", True)
                    grvCV.UpdateCurrentRow()
                    Exit For
                End If
            Next
        Next
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

    Private arrMaNode As New List(Of String)
    Private arrTenNode As New List(Of String)
    Private Sub txtGiatri_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiatri.KeyDown
        Try
            If (e.KeyCode = 13) Then
                TimkiemCauTrucThietBi(txtGiatri.Text, tvwCautrucTB)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private arrThietBiNode As New List(Of String)

    Private nodes As TreeListNodes = Nothing
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

    Private Sub grvCV_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvCV.CellValueChanged
        If e.Column.FieldName = "CHON" Then
            Dim str As String = ""
            If grvCV.GetFocusedRowCellValue("CHON") Then
                Dim sSql As String
                sSql = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH,HANG_MUC_ID, BAC_THO,THUC_KIEM,GHI_CHU, THAO_TAC, TIEU_CHUAN_KT, STT_EOR) SELECT '" & MS_PHIEU_BAO_TRI & "' ," & grvCV.GetFocusedRowCellValue("MS_CV") & " ,N'" & grvCV.GetFocusedRowCellValue("MA_CV") & "' ,'" & grvCV.GetFocusedRowCellValue("MS_BO_PHAN") & "', N' " & tvwCautrucTB.FocusedNode("TEN_BO_PHAN").ToString() & "'," & IIf(grvCV.GetFocusedRowCellValue("THOI_GIAN_DU_KIEN").ToString = "", "NULL", grvCV.GetFocusedRowCellValue("THOI_GIAN_DU_KIEN")) & ", " & IIf(grvCV.GetFocusedRowCellValue("DINH_MUC").ToString = "", "NULL", grvCV.GetFocusedRowCellValue("DINH_MUC")) & ", " & IIf(grvCV.GetFocusedRowCellValue("MS_BAC_THO").ToString = "", "NULL", grvCV.GetFocusedRowCellValue("MS_BAC_THO")) & ", NULL, NULL, N'" & IIf(grvCV.GetFocusedRowCellValue("THAO_TAC").ToString = "", "''", grvCV.GetFocusedRowCellValue("THAO_TAC")) & "', N'" & IIf(grvCV.GetFocusedRowCellValue("TIEU_CHUAN_KT").ToString = "", "''", grvCV.GetFocusedRowCellValue("TIEU_CHUAN_KT")) & "', " & STT_EOR & " WHERE NOT EXISTS (SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " B WHERE B.MS_CV = '" & grvCV.GetFocusedRowCellValue("MS_CV") & "' AND B.MS_BO_PHAN = '" & grvCV.GetFocusedRowCellValue("MS_BO_PHAN") & "' AND B.MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "' AND B.STT_EOR = " & STT_EOR & ") "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                'Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                'While objRead.Read
                '    objRead.Close()
                '    Exit Sub
                'End While
                'objRead.Close()
                'With grvCV
                '    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertTAM181" & Commons.Modules.UserName,
                '    MS_PHIEU_BAO_TRI,
                '    IIf(grvCV.GetFocusedRowCellValue("MS_CV").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("MS_CV")),
                '    IIf(grvCV.GetFocusedRowCellValue("MA_CV").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("MA_CV")),
                '    IIf(grvCV.GetFocusedRowCellValue("MS_BO_PHAN").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("MS_BO_PHAN")),
                '    tvwCautrucTB.FocusedNode("TEN_BO_PHAN").ToString().Split(":")(1).Trim(),
                '    IIf(grvCV.GetFocusedRowCellValue("THOI_GIAN_DU_KIEN").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("THOI_GIAN_DU_KIEN")),
                '    IIf(grvCV.GetFocusedRowCellValue("DINH_MUC").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("DINH_MUC")),
                '    Nothing, Nothing, Nothing, Nothing,
                '    IIf(grvCV.GetFocusedRowCellValue("MS_BAC_THO").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("MS_BAC_THO")),
                '    Nothing, Nothing, STT_EOR, Nothing, IIf(grvCV.GetFocusedRowCellValue("THAO_TAC").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("THAO_TAC")),
                '    IIf(grvCV.GetFocusedRowCellValue("TIEU_CHUAN_KT").ToString = "", Nothing, grvCV.GetFocusedRowCellValue("TIEU_CHUAN_KT")))
                'End With
            ElseIf Not grvCV.GetFocusedRowCellValue("CHON") Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvCV.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvCV.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvCV.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvCV.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvCV.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvCV.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub dtTuNgay_EditValueChanged(sender As Object, e As EventArgs) Handles dtTuNgay.EditValueChanged, dtDenNgay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        BindData1()
    End Sub

    Private Sub grvDSCongViec_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSCongViec.CellValueChanged
        If e.Column.FieldName = "CHON" Then
            Dim str As String = ""
            If grvDSCongViec.GetFocusedRowCellValue("CHON") Then
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " WHERE MS_CV=" & grvDSCongViec.GetFocusedRowCellValue("MS_CV") & " AND MS_BO_PHAN='" & grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    objRead.Close()
                    Exit Sub
                End While
                objRead.Close()
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertTAM181" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, grvDSCongViec.GetFocusedRowCellValue("MS_CV"), grvDSCongViec.GetFocusedRowCellValue("MA_CV"),
                 grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN"), grvDSCongViec.GetFocusedRowCellValue("TEN_BO_PHAN"), Nothing,
                 dgrDanhMucHangMuc.Rows(intRowHM).Cells("HANG_MUC_ID"), dgrDanhMucHangMuc.Rows(intRowHM).Cells("TEN_HANG_MUC"), Nothing,
                 grvDSCongViec.GetFocusedRowCellValue("TEN_CHUYEN_MON"), grvDSCongViec.GetFocusedRowCellValue("TEN_BAC_THO"),
                grvDSCongViec.GetFocusedRowCellValue("THUC_KIEM"), Nothing, Nothing)

            ElseIf Not grvDSCongViec.GetFocusedRowCellValue("CHON") Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSCongViec.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSCongViec.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSCongViec.GetFocusedRowCellValue("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
            tmp = False
        End If
    End Sub

    Private Sub grvDSCongViec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDSCongViec.FocusedRowChanged
        If (flagLoad = True) Then Exit Sub
        ShowKHCVPT(grvDSCongViec.FocusedRowHandle)
    End Sub

    Private Sub grvHangMuc_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvHangMuc.FocusedRowChanged
        If (flagLoad = True) Then Exit Sub
        ShoKHCV(grvHangMuc.FocusedRowHandle)
        grvDSCongViec_FocusedRowChanged(Nothing, Nothing)
        txtSearch.Text = ""
    End Sub

    Private Sub grvDSPhuTung_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvDSPhuTung.CellValueChanged
        tmp = True
        If e.Column.FieldName = "CHON" Then
            Dim str As String = ""
            If grvDSPhuTung.GetFocusedRowCellValue("CHON") Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, grvDSPhuTung.GetFocusedRowCellValue("MS_CV"), grvDSPhuTung.GetFocusedRowCellValue("MS_BO_PHAN"),
                 grvDSPhuTung.GetFocusedRowCellValue("MS_PT"), grvDSPhuTung.GetFocusedRowCellValue("TEN_PT"),
                  grvDSPhuTung.GetFocusedRowCellValue("SL_KH"), grvDSPhuTung.GetFocusedRowCellValue("MS_PT_CHA"), grvDSPhuTung.GetFocusedRowCellValue("MS_PT_NCC"), grvDSPhuTung.GetFocusedRowCellValue("MS_PT_CTY"),
                  grvDSPhuTung.GetFocusedRowCellValue("SL_KH"), Nothing)
            ElseIf Not grvDSPhuTung.GetFocusedRowCellValue("CHON") Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & grvDSPhuTung.GetFocusedRowCellValue("MS_CV") & "' AND MS_BO_PHAN ='" & grvDSPhuTung.GetFocusedRowCellValue("MS_BO_PHAN") & "' AND MS_PT ='" & grvDSPhuTung.GetFocusedRowCellValue("MS_PT") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If

        End If
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


    Private Sub tvwCautrucTB_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvwCautrucTB.FocusedNodeChanged
        Try
            nodes = Nothing
            txtDuongdan.Text = GetFullPath(tvwCautrucTB.FocusedNode, "\")
            If e.Node.GetValue("MS_BO_PHAN").ToString() = MS_MAY Then Exit Sub
            ShowDanhmucCV(tvwCautrucTB.FocusedNode("MS_BO_PHAN").ToString())
        Catch ex As Exception
        End Try
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
                    ShowDanhmucCV(tvwCautrucTB.FocusedNode("MS_BO_PHAN").ToString())
            End Select
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class