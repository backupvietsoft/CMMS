Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin

Public Class FrmChonTSGSTT
    Dim dtTableTam, dtTableOne As DataTable
    Dim sql As String


    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        LoadLoaiCongViec()
        ShowTreeRoot(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString())
    End Sub

    Sub LoadLoaiCongViec()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < grdChonTSGSTT.RowCount
            grdChonTSGSTT.Rows(i).Cells("chkChon").Value = True
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < grdChonTSGSTT.RowCount
            grdChonTSGSTT.Rows(i).Cells("chkChon").Value = False
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        UpdateDataTable()
    End Sub

    Function CheckStatus() As Boolean
        Dim lFlag As Boolean = False
        Dim i As Integer
        For i = 0 To grdChonTSGSTT.Rows.Count - 1
            If grdChonTSGSTT.Rows(i).Cells(4).Value = True Then
                lFlag = True
                Exit For
            End If
        Next
        Return lFlag
    End Function

    Function UpdateDataTable() As DataTable
        If Not CheckStatus() Then
            ' Vui lòng chọn thông số giám sát !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        '
        Dim i As Integer
        Dim drNew As DataRow
        Dim dtNew As New DataTable
        Dim SQL As String = "SELECT MAY_THONG_SO_GSTT.MS_TS_GSTT,THONG_SO_GSTT.TEN_TS_GSTT,GIA_TRI_TREN,GIA_TRI_DUOI,TEN_DV_DO,CHU_KY_DO,MS_DV_TG,MAY_THONG_SO_GSTT.GHI_CHU FROM MAY_THONG_SO_GSTT INNER JOIN THONG_SO_GSTT ON MAY_THONG_SO_GSTT.MS_TS_GSTT=THONG_SO_GSTT.MS_TS_GSTT LEFT JOIN DON_VI_DO ON THONG_SO_GSTT.MS_DV_DO=DON_VI_DO.MS_DV_DO"

        dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
        For i = 0 To grdChonTSGSTT.Rows.Count - 1
            If grdChonTSGSTT.Rows(i).Cells("chkChon").Value = True Then
                drNew = dtNew.NewRow

                drNew.Item(0) = grdChonTSGSTT.Rows(i).Cells("MS_TS_GSTT").Value
                drNew.Item(1) = grdChonTSGSTT.Rows(i).Cells("TEN_TS_GSTT").Value
                drNew.Item(4) = grdChonTSGSTT.Rows(i).Cells("TEN_DV_DO").Value
                dtNew.Rows.Add(drNew)
            End If
        Next
        DialogResult = Windows.Forms.DialogResult.OK
        Return dtNew
    End Function

    Private Sub CboLoaiCongViec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ShowCongviecBoPhan(CboLoaiCongViec.SelectedValue)
    End Sub

    Private Sub RefeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnBoChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnBoChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.BtnChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        LblTieudechukyBTPN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudechukyBTPN.Name, commons.Modules.TypeLanguage)
        Me.grdChonTSGSTT.Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MO_TA_CV", commons.Modules.TypeLanguage)
        Me.grdChonTSGSTT.Columns(3).HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
    End Sub

#Region "BoPhan"

    Dim OldNode As TreeNode                             'Lưu dữ giá trị của node hiện tại lúc không lưu dữ liệu
    Dim PrevOldNode As TreeNode                         'Lưu dữ giá trị của node trước trong trường hợp xóa
    Dim sTrangThaiTabThietbi As String = String.Empty   'Ghi nhận trạng thái là thêm hay sửa
    Dim sMA_BP_OLD As String = String.Empty
    Dim sTEN_BP_OLD As String = String.Empty
    ' <summary>
    ' Thủ tục nạp dữ liệu lên Treeview theo mã máy
    ' </summary>
    ' <remarks></remarks>
    Sub ShowTreeRoot(ByVal sMS_MAY As String)

        'tvwCautrucTB.CheckBoxes = True
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVw.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVw.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA='" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode)
        Next

        TVw.ExpandAll()
        TVw.Focus()

    End Sub

    Sub ShowTreeNode(ByVal sMS_MAY As String, ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = '" & sMS_MAY & "'"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("TEN_BO_PHAN").ToString()

            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode)
        Next
        'RefeshLanguage2()
    End Sub

    Private Sub tvw_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TVw.AfterSelect
        ShowTSGSTTBoPhan()
    End Sub

    Sub ShowTSGSTTBoPhan()
        Dim dtTable As New DataTable
        '" & FrmThongtinthietbi.txtMS_MAY.Name & "
        Try
            grdChonTSGSTT.Columns.Clear()
        Catch ex As Exception

        End Try


        Commons.Modules.SQLString = "SELECT CAU_TRUC_THIET_BI_TS_GSTT.*,TEN_TS_GSTT,TEN_DV_DO FROM CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT=THONG_SO_GSTT.MS_TS_GSTT LEFT JOIN DON_VI_DO ON THONG_SO_GSTT.MS_DV_DO=DON_VI_DO.MS_DV_DO WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN=N'" & TVw.SelectedNode.Name & "' AND CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT NOT IN (SELECT MS_TS_GSTT FROM MAY_THONG_SO_GSTT WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        Me.grdChonTSGSTT.DataSource = dtTable
        Dim column As New DataGridViewCheckBoxColumn

        With column
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With
        grdChonTSGSTT.Columns.Insert(4, column)
        Try
            grdChonTSGSTT.Columns("MS_MAY").Visible = False
            grdChonTSGSTT.Columns("MS_BO_PHAN").Visible = False
            grdChonTSGSTT.Columns("MS_TS_GSTT").Visible = False
            grdChonTSGSTT.Columns("TEN_DV_DO").Visible = False
            Me.grdChonTSGSTT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdChonTSGSTT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.grdChonTSGSTT.Columns("TEN_TS_GSTT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_TS_GSTT", commons.Modules.TypeLanguage)
            grdChonTSGSTT.Rows(0).Cells("TEN_TS_GSTT").Selected = True
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class