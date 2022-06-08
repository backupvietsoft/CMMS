Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class FrmChonCongViecChoBTPN
    Dim dtTableTam, dtTableOne As DataTable
    Dim sql As String
    Dim loaibts As Integer
    Private _ATTACHMENT As Boolean


    Public Property ATTACHMENT() As Boolean
        Get
            Return _ATTACHMENT
        End Get
        Set(ByVal value As Boolean)
            _ATTACHMENT = value
        End Set
    End Property

    Private Sub FrmChonCongViecChoBTPN_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Commons.Modules.ObjSystems.XoaTable("CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName)

    End Sub

    Private Sub FrmChonCongViecChoBTPN_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Commons.Modules.SQLString = "CREATE TABLE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(255),MS_BO_PHAN NVARCHAR(255), MS_CV INT, CHON BIT DEFAULT 0,ACTIVE BIT)"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "INSERT INTO dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_BO_PHAN,MS_CV,ACTIVE) SELECT MS_MAY,MS_BO_PHAN,MS_CV,ACTIVE FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "CREATE TABLE dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(255),MS_LOAI_BT INT,MS_CV INT,MS_BO_PHAN NVARCHAR(255),TEN_BO_PHAN NVARCHAR(MAX),MO_TA_CV NVARCHAR(255), KY_HIEU_CV NVARCHAR(255), DA_CHON BIT DEFAULT 0,COUNT_ROW INT)"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        loaibts = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        dtTableOne = New DataTable
        dtTableOne.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), loaibts))

        Dim row As Integer = frmThongtinthietbi.grvLoaiBTPN_CV.RowCount
        Dim I As Integer
        For I = 0 To row - 1
            Commons.Modules.SQLString = "INSERT INTO DBO.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV,
                DA_CHON,COUNT_ROW) VALUES ( N'" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("MS_MAY") & "','" &
                 frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("MS_LOAI_BT") & "','" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("MS_CV") &
                "',N'" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("MS_BO_PHAN") & "',N'" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("TEN_BO_PHAN") &
                "',N'" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("MO_TA_CV") & "','" & frmThongtinthietbi.grvLoaiBTPN_CV.GetDataRow(I)("KY_HIEU_CV") & "','" & 1 & "','" & row & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Next
        Commons.Modules.SQLString = "0LOAD"
        LoadLoaiCongViec()
        Commons.Modules.SQLString = ""
        If Not ATTACHMENT Then
            ShowTreeRoot(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString())
        Else
            ShowTreeRoot(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString())
        End If
    End Sub

    Sub LoadLoaiCongViec()
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName))


        Dim drRow As DataRow = dtTmp.NewRow
        drRow("MS_LOAI_CV") = "-1"
        drRow("TEN_LOAI_CV") = " < ALL > "
        dtTmp.Rows.Add(drRow)
        dtTmp.DefaultView.Sort = "TEN_LOAI_CV"
        dtTmp = dtTmp.DefaultView.ToTable()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLoaiCongViec, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "")


    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        Try

            While i < grvCV.RowCount
                grvCV.SetRowCellValue(i, "CHON", True)
                Commons.Modules.SQLString = "UPDATE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName &
                " SET CHON=1 WHERE MS_MAY = N'" & grvCV.GetRowCellValue(i, "MS_MAY").ToString & "' AND MS_BO_PHAN='" & grvCV.GetRowCellValue(i, "MS_BO_PHAN").ToString &
                "' AND MS_CV=" & grvCV.GetRowCellValue(i, "MS_CV").ToString
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                i = i + 1
            End While
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        Try

            While i < grvCV.RowCount
                grvCV.SetRowCellValue(i, "CHON", False)
                Commons.Modules.SQLString = "UPDATE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName &
                " SET CHON = 0 WHERE MS_MAY = N'" & grvCV.GetRowCellValue(i, "MS_MAY").ToString & "' AND MS_BO_PHAN='" & grvCV.GetRowCellValue(i, "MS_BO_PHAN").ToString &
                "' AND MS_CV=" & grvCV.GetRowCellValue(i, "MS_CV").ToString
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                i = i + 1
            End While
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Dim i As Integer
        Dim dtRow As DataRow
        Dim dtReader As SqlDataReader

        dtTableOne = New DataTable
        Dim str As String = ""
        If Not ATTACHMENT Then
            i = 0
            Commons.Modules.SQLString = "SELECT A.* ,A.MS_BO_PHAN + ' - ' + TEN_BO_PHAN AS TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV FROM dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName &
                        " AS A INNER JOIN CAU_TRUC_THIET_BI AS B ON A.MS_BO_PHAN=B.MS_BO_PHAN AND A.MS_MAY=B.MS_MAY INNER JOIN CONG_VIEC C ON A.MS_CV=C.MS_CV WHERE CHON = 1 "
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                str = "INSERT INTO dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV,DA_CHON) VALUES ( N'" &
                    dtReader.Item("MS_MAY") & "','" & loaibts & "'," & dtReader.Item("MS_CV") & ",N'" & dtReader.Item("MS_BO_PHAN") & "',N'" &
                    dtReader.Item("TEN_BO_PHAN") & "',N'" & dtReader.Item("MO_TA_CV") & "','" & dtReader.Item("KY_HIEU_CV") & "',0)"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                i += 1
            End While
            Commons.Modules.SQLString = "SELECT * FROM dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName
            dtTableOne.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))

            Commons.Modules.ObjSystems.MLoadXtraGrid(frmThongtinthietbi.grdLoaiBTPN_CV, frmThongtinthietbi.grvLoaiBTPN_CV, dtTableOne, False, True, True, True, True, "frmThongtinthietbi")

            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(0).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(1).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(2).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(3).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns("MS_BO_PHAN").Visible = False
            Try
                frmThongtinthietbi.grvLoaiBTPN_CV.Columns("KY_HIEU_CV").Visible = False
                frmThongtinthietbi.grvLoaiBTPN_CV.Columns("DA_CHON").Visible = False
                frmThongtinthietbi.grvLoaiBTPN_CV.Columns("COUNT_ROW").Visible = False
            Catch ex As Exception

            End Try

            grdCV.DataSource = System.DBNull.Value
        Else
            loaibts = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
            dtTableOne.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), loaibts))
            str = "DELETE MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName & " WHERE MS_LOAI_BT='" & loaibts & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Dim row As Integer = dtTableOne.Rows.Count
            For i = 0 To row - 1
                str = "INSERT INTO dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV,DA_CHON,COUNT_ROW) VALUES ( N'" &
                dtTableOne.Rows(i).Item("MS_MAY") & "','" & dtTableOne.Rows(i).Item("MS_LOAI_BT") & "','" & dtTableOne.Rows(i).Item("MS_CV") & "',N'" &
                dtTableOne.Rows(i).Item("MS_BO_PHAN") & "',N'" & dtTableOne.Rows(i).Item("TEN_BO_PHAN") & "',N'" & dtTableOne.Rows(i).Item("MO_TA_CV") & "','" &
                dtTableOne.Rows(i).Item("KY_HIEU_CV") & "','" & 1 & "','" & row & "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Next
            i = 0
            While i < grvCV.RowCount
                If Convert.ToBoolean(grvCV.GetRowCellValue(i, "CHON").ToString()) Then
                    dtRow = dtTableOne.NewRow
                    dtRow.Item(0) = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                    dtRow.Item(1) = loaibts
                    dtRow.Item(2) = grvCV.GetRowCellValue(i, "MS_CV").ToString()
                    dtRow.Item(3) = TVw.SelectedNode.Name
                    dtRow.Item(4) = TVw.SelectedNode.Text
                    sql = "SELECT MO_TA_CV FROM CONG_VIEC WHERE MS_CV=" & grvCV.GetRowCellValue(i, "MS_CV").ToString()
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    While dtReader.Read
                        dtRow.Item(5) = dtReader.Item(0)
                    End While
                    dtTableOne.Rows.Add(dtRow)
                    str = "INSERT INTO dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV) VALUES ( N'" &
                    frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "','" & loaibts & "','" & grvCV.GetRowCellValue(i, "MS_CV").Value & "',N'" & TVw.SelectedNode.Name & "',N'" &
                    TVw.SelectedNode.Text & "',N'" & dtRow.Item(5) & "','" & "')"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
                i = i + 1
            End While
            Commons.Modules.ObjSystems.MLoadXtraGrid(frmThongtinthietbi.grdLoaiBTPN_CV, frmThongtinthietbi.grvLoaiBTPN_CV, New Commons.VS.Classes.Catalogue.MAYController().GetMAY_LOAI_BTPN_CONG_VIEC(frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")), False, True, True, True, True, "frmThongtinthietbi")


            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(0).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(1).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(2).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns(3).Visible = False
            frmThongtinthietbi.grvLoaiBTPN_CV.Columns("MS_BO_PHAN").Visible = False

            grdCV.DataSource = System.DBNull.Value
        End If
        Me.Close()
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
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        'tvwCautrucTB.CheckBoxes = True
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVw.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVw.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA=N'" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("MS_BO_PHAN").ToString() + " - " + drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode)
        Next

        TVw.ExpandAll()
        TVw.Focus()
        Try
            TVw.SelectedNode = TVw.Nodes(0)
        Catch ex As Exception

        End Try


        'RefeshLanguage2()
    End Sub

    Sub ShowTreeNode(ByVal SMS_MAY As String, ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        'Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=" + "'" & sMS_BP & "'"

        'Tăng sửa 27/04/2007
        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = N'" & SMS_MAY & "'"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("MS_BO_PHAN").ToString() & " - " & drNode("TEN_BO_PHAN").ToString()

            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

            Call ShowTreeNode(SMS_MAY, sMaBP, oChildNode)
        Next
    End Sub
    Dim node As TreeNode
    Private Sub tvw_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TVw.AfterSelect
        Try
            node.BackColor = Color.White
        Catch ex As Exception

        End Try
        TVw.SelectedNode.BackColor = Color.LightGray
        node = TVw.SelectedNode

        If CboLoaiCongViec.Text = "" Then Exit Sub
        ShowCongviecBoPhan(CboLoaiCongViec.EditValue)
    End Sub

    Sub ShowCongviecBoPhan(ByVal intLoaiCV As Integer)
        Dim dtTable As New DataTable
        Dim a As String
        Try
            a = TVw.SelectedNode.Name
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If Not ATTACHMENT Then
                Commons.Modules.SQLString = "SELECT  A.CHON, B.MO_TA_CV, A.MS_MAY, A.MS_BO_PHAN, A.MS_CV, A.ACTIVE
                        FROM dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName & " AS A INNER JOIN CONG_VIEC AS B ON A.MS_CV=B.MS_CV WHERE MS_MAY=N'" &
                        frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND ACTIVE=1 AND MS_BO_PHAN='" & TVw.SelectedNode.Name & "'" & IIf(CboLoaiCongViec.EditValue.ToString <> "-1", "  
                        AND MS_LOAI_CV = " & intLoaiCV, "") & " AND A.MS_CV NOT IN (SELECT MS_CV FROM dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & " 
                        WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_LOAI_BT=" & frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") &
                        " AND MS_BO_PHAN='" & TVw.SelectedNode.Name & "'  )"
            Else
                Commons.Modules.SQLString = "SELECT  A.CHON, B.MO_TA_CV, A.MS_MAY, A.MS_BO_PHAN, A.MS_CV, A.ACTIVE
                        FROM dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName & " AS A INNER JOIN CONG_VIEC AS B ON A.MS_CV=B.MS_CV WHERE MS_MAY=N'" &
                        frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND ACTIVE=1 AND MS_BO_PHAN='" & TVw.SelectedNode.Name & "'" & IIf(CboLoaiCongViec.EditValue.ToString <> "-1", "   
                        AND MS_LOAI_CV=" & intLoaiCV, "") & " AND A.MS_CV NOT IN (SELECT MS_CV FROM dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName & " 
                        WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_LOAI_BT=" & frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") &
                        " AND MS_BO_PHAN='" & TVw.SelectedNode.Name & "')"
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            Exit Sub
        End Try

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        dtTable.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dtTable, True, True, True, True, True, Me.Name)
        grvCV.Columns("MS_MAY").Visible = False
        grvCV.Columns("ACTIVE").Visible = False
        grvCV.Columns("MS_BO_PHAN").Visible = False
        grvCV.Columns("MS_CV").Visible = False
        grvCV.Columns("CHON").Width = 70
    End Sub
#End Region

    Private arrTenNode As New List(Of String)
    Private Sub txtGiatri_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiatri.KeyDown
        If txtGiatri.Text = "" Then Exit Sub
        If IsDBNull(txtGiatri.Text) Then Exit Sub
        Dim oNode As TreeNode()
        Static t As Integer
        Static Dim strOldTenNode As String
        If e.KeyValue = 13 Then
            Dim ie As IEnumerator = TVw.Nodes.GetEnumerator
            If Trim(strOldTenNode) <> "" And Trim(strOldTenNode) = Trim(txtGiatri.Text) Then
                t += 1
                If arrTenNode.Count <= 0 Then Exit Sub
                If t >= arrTenNode.Count Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT32", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        t = 0
                    Else
                        Exit Sub
                    End If

                End If

                oNode = TVw.Nodes.Find(arrTenNode(t), True)
                If oNode.Length > 0 Then TVw.SelectedNode = oNode(0)
            Else
                If ie.MoveNext Then
                    t = 0
                    arrTenNode.Clear()
                    strOldTenNode = txtGiatri.Text
                    parseTenNode(ie.Current)
                    If arrTenNode.Count <= 0 Then

                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT33", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        strOldTenNode = ""
                        Exit Sub
                    End If

                    oNode = TVw.Nodes.Find(arrTenNode(0), True)
                    If oNode.Length > 0 Then TVw.SelectedNode = oNode(0)
                End If
            End If
        End If

    End Sub
    Sub parseTenNode(ByVal tn As TreeNode)
        Dim ie As IEnumerator = tn.Nodes.GetEnumerator
        Dim parentnode As String = ""

        parentnode = tn.Text
        While ie.MoveNext()
            Dim ctn As TreeNode = ie.Current

            If LCase(ctn.Text.ToLower).Contains(LCase(Me.txtGiatri.Text.ToLower)) Then
                arrTenNode.Add(ctn.Name)
            ElseIf LCase(ctn.Name.ToLower).Contains(LCase(Me.txtGiatri.Text.ToLower)) Then
                arrTenNode.Add(ctn.Name)
            End If

            If (ctn.GetNodeCount(True) > 0) Then
                parseTenNode(ctn)
            End If

        End While
    End Sub



    Private Sub CboLoaiCongViec_EditValueChanged(sender As Object, e As EventArgs) Handles CboLoaiCongViec.EditValueChanged
        If CboLoaiCongViec.Text = "" Then Exit Sub
        ShowCongviecBoPhan(CboLoaiCongViec.EditValue)
    End Sub

    Private Sub grvCV_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvCV.CellValueChanged
        If e.Column.Name.ToUpper = "COLCHON" Then
            Commons.Modules.SQLString = "UPDATE dbo.CAU_TRUC_THIET_BI_CONG_VIEC_TMP" & Commons.Modules.UserName &
                " SET CHON=" & IIf(Convert.ToBoolean(grvCV.GetFocusedDataRow("CHON").ToString) = True, 1, 0) & " WHERE MS_MAY=N'" & grvCV.GetFocusedDataRow("MS_MAY").ToString &
                "' AND MS_BO_PHAN='" & grvCV.GetFocusedDataRow("MS_BO_PHAN").ToString & "' AND MS_CV=" & grvCV.GetFocusedDataRow("MS_CV").ToString
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        End If
    End Sub
End Class