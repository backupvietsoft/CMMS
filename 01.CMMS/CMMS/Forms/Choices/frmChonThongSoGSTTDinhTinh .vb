
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors

Public Class frmChonThongSoGSTTDinhTinh
    Dim BT As String
    Public tDinhTinh As New DataTable
    Private _STT As Integer
    Private _LOAI As Integer
    Private _SelectIndex As Integer
    Private bKhoitao As Boolean = True, bChon As Boolean = False
    Private _sMsPBT As String = "-1"
    Private _sMsMay As String = "-1"
    Private _MS_MAY As String = "-1"
    Private _sMsBoPhan As String = "-1"
    Public sBTGSTT As String = "-1"
    Dim nodenext As TreeNode
    Dim nodetmp As TreeNode
    Dim strLast As String = ""

    Public Property sMsPBT() As String
        Get
            Return _sMsPBT
        End Get
        Set(ByVal value As String)
            _sMsPBT = value
        End Set
    End Property

    Public Property sMsMay() As String
        Get
            Return _sMsMay
        End Get
        Set(ByVal value As String)
            _sMsMay = value
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

    Public Property sMsBoPhan() As String
        Get
            Return _sMsBoPhan
        End Get
        Set(ByVal value As String)
            _sMsBoPhan = value
        End Set
    End Property

    Public Property STT() As Integer
        Get
            Return _STT
        End Get
        Set(ByVal value As Integer)
            _STT = value
        End Set
    End Property

    Public Property LOAI() As Integer
        Get
            Return _LOAI
        End Get
        Set(ByVal value As Integer)
            _LOAI = value
        End Set
    End Property

    Public Property SelectIndex() As Integer
        Get
            Return _SelectIndex
        End Get
        Set(ByVal value As Integer)
            _SelectIndex = value
        End Set
    End Property
    Private _BThem As Integer
    Public Property BThem() As Integer
        Get
            Return _BThem
        End Get
        Set(ByVal value As Integer)
            _BThem = value
        End Set
    End Property

    Private Sub frmChonThongSoGSTTDinhTinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sMsMay = "-1" Then BT = sBTGSTT Else BT = "GSTT_PBT" & Commons.Modules.UserName
        dtNgay.DateTime = Now
        If sMsMay <> "-1" Then
            chkTheoDayChuyen.Visible = False
            cboDayChuyen.Visible = False
            cboLoaithietbi.Visible = False
            cboThietbi.Visible = False
        End If
        chkTheoDayChuyen.Checked = False
        Dim str As String = ""
        Try
            str = "drop PROCEDURE Insert" & BT
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "drop PROCEDURE Delete" & BT
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE PROCEDURE [dbo].[Delete" & BT & "]  " &
               " @MS_MAY NVARCHAR(30),@MS_TS_GSTT NVARCHAR(100),@STT INT " &
               " AS DELETE FROM " & BT & " WHERE MS_MAY=@MS_MAY AND MS_TS_GSTT=@MS_TS_GSTT AND STT=@STT "
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Catch ex As Exception

        End Try
        str = "CREATE PROCEDURE [dbo].[Insert" & BT & "] " &
                           " @MS_MAY NVARCHAR(30),@TEN_GIA_TRI NVARCHAR(50),@GHI_CHU NVARCHAR(255),@MS_TS_GSTT NVARCHAR(100),@TEN_TS_GSTT NVARCHAR(100),@MS_BO_PHAN NVARCHAR(50),@TEN_BO_PHAN NVARCHAR(100),@STT INT " & '--, @CACH_THUC_HIEN NVARCHAR(2000), --@THOI_GIAN FLOAT
                           " AS INSERT INTO " & BT & "(MS_MAY,TEN_GIA_TRI,GHI_CHU,MS_TS_GSTT,TEN_TS_GSTT,MS_BO_PHAN,TEN_BO_PHAN,STT) " & '--, CACH_THUC_HIEN, THOI_GIAN )
                           " VALUES (@MS_MAY ,@TEN_GIA_TRI,@GHI_CHU ,@MS_TS_GSTT ,@TEN_TS_GSTT ,@MS_BO_PHAN ,@TEN_BO_PHAN ,@STT )  " '--, @CACH_THUC_HIEN, @THOI_GIAN )
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Catch ex As Exception

        End Try
        For i As Integer = 0 To tDinhTinh.Rows.Count - 1
            Dim TBGiaTri As New DataTable()
            TBGiaTri = New clsGIAM_SAT_TINH_TRANG_HINHController().GetGIAM_SAT_TINH_TRANG_TS_DT(STT, tDinhTinh.Rows(i).Item("MS_MAY"), tDinhTinh.Rows(i).Item("MS_TS_GSTT"), tDinhTinh.Rows(i).Item("MS_BO_PHAN"), LOAI)
            For j As Integer = 0 To TBGiaTri.Rows.Count - 1
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, tDinhTinh.Rows(i).Item("MS_MAY"), TBGiaTri.Rows(j).Item("TEN_GIA_TRI"), TBGiaTri.Rows(j).Item("GHI_CHU"), tDinhTinh.Rows(i).Item("MS_TS_GSTT"), tDinhTinh.Rows(i).Item("TEN_TS_GSTT"), tDinhTinh.Rows(i).Item("MS_BO_PHAN"), tDinhTinh.Rows(i).Item("TEN_BO_PHAN"), TBGiaTri.Rows(j).Item("STT_GT"))
            Next
        Next

        Try
            str = "DROP TABLE TMP" & BT
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "SELECT DISTINCT * INTO TMP" & BT & " FROM " & BT
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE " & BT
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "SELECT DISTINCT * , CONVERT(NVARCHAR,'1') AS MOI_CU INTO " & BT & " FROM TMP" & BT
        Try
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
            str = "SELECT DISTINCT *  INTO " & BT & " FROM TMP" & BT
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End Try

        str = "UPDATE " & BT & " SET MOI_CU = 1"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE TMP" & BT
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

        LoadcboLoaithietbi()
        LoadcboDayChuyen()
        LoadcboThietbi()
        Binddata(chkHangmucdenhangGS.Checked)
        RefeshLanguage()
        btDatDayChuyen.Visible = False

        If (_sMsBoPhan <> "-1") Then
            TableLayoutPanel2.Enabled = False
            btnAllOK.Visible = False
        Else
            TableLayoutPanel2.Enabled = True

        End If
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

#Region "Private "
    'Sub LoadcboDiadiem()
    '    cboDiadiem.Value = "MS_N_XUONG"
    '    cboDiadiem.Display = "TEN_N_XUONG"
    '    cboDiadiem.StoreName = "GetDIA_DIEM_DINH_TINHs"
    '    cboDiadiem.Param = Commons.Modules.UserName
    '    cboDiadiem.BindDataSource()
    'End Sub

    Sub LoadcboLoaithietbi()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaithietbi, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1),
                                                   "MS_LOAI_MAY", "TEN_LOAI_MAY", "")


        Dim dtTmp As New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " Select T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 On " +
                " T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 On T2.GROUP_ID = T3.GROUP_ID " +
                " WHERE USERNAME = '" + Commons.Modules.UserName + "' " +
                " UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "sDN", Commons.Modules.TypeLanguage) + "' " +
                " ORDER BY TEN_LOAI_CV"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "")



    End Sub
    Sub LoadcboDayChuyen()
        Dim dtTmp As New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDayChuyen, dtTmp, "MS_HE_THONG", "TEN_HE_THONG", "")
    End Sub

    Sub LoadcboThietbi()
        Try
            Dim dt As New DataTable()
            If (Not chkTheoDayChuyen.Checked) Then
                If cboLoaithietbi.Text = "" Then
                    Exit Sub
                End If
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAY_DINH_TINHs", cboLoaithietbi.EditValue, Commons.Modules.UserName))
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbi, dt, "MS_MAY", "TEN_MAY", "")
            Else
                If (cboDayChuyen.Text = "") Then
                    Exit Sub
                End If
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThietBi_DayChuyen", cboDayChuyen.EditValue, Commons.Modules.UserName))
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbi, dt, "MS_MAY", "TEN_MAY", "")

            End If
        Catch
        End Try



    End Sub

    Sub HienThi()
        Dim str As String = ""
        tDinhTinh = New DataTable()
        str = " SELECT * FROM " & BT
        tDinhTinh = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For j As Integer = 0 To grdDanhsachTSGSTT.Rows.Count - 1
            For i As Integer = 0 To tDinhTinh.Rows.Count - 1
                If tDinhTinh.Rows(i).Item("MS_MAY") = grdDanhsachTSGSTT.Rows(j).Cells("MS_MAY").Value And
                    tDinhTinh.Rows(i).Item("MS_TS_GSTT") = grdDanhsachTSGSTT.Rows(j).Cells("MS_TS_GSTT").Value And
                    tDinhTinh.Rows(i).Item("STT") = grdDanhsachTSGSTT.Rows(j).Cells("STT").Value And
                    tDinhTinh.Rows(i).Item("TEN_GIA_TRI") = grdDanhsachTSGSTT.Rows(j).Cells("TEN_GIA_TRI").Value And
                    tDinhTinh.Rows(i).Item("MS_BO_PHAN") = grdDanhsachTSGSTT.Rows(j).Cells("MS_BO_PHAN").Value Then
                    grdDanhsachTSGSTT.Rows(j).Cells("CHON").Value = True
                    Exit For
                End If
            Next
        Next
    End Sub
    Sub CreatechkGiatri()
        Dim chkGiatri As New DataGridViewCheckBoxColumn()
        chkGiatri.Name = "CHON"
        grdDanhsachTSGSTT.Columns.Insert(6, chkGiatri)
    End Sub
    Dim nodeFirst As TreeNode
    Dim nodeLast As TreeNode
    Sub Binddata(ByVal HangMucDenHanGSTT As Boolean)

        BindData1("-1", -1, "-1")
        If cboThietbi.Text = "" Then
            tvGiamsat.Nodes.Clear()
            cboThietbi.Text = ""
            Exit Sub
        End If

        Dim tb As New DataTable()
        Dim MsMay As String
        If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay

        If MS_MAY <> "-1" Then MsMay = MS_MAY

        If HangMucDenHanGSTT = False Then
            'tb = New clsChonthongsoGSTTdinhluongController().GetCAU_TRUC_THIET_BI_TS_GSTT(MsMay)
            tb = New DataTable
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCTTBThongSoGSTT", MsMay, cboLoaiCV.EditValue))
        Else
            tb = LocGSTTDenHan(MsMay)
        End If

        tvGiamsat.Nodes.Clear()
        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = tvGiamsat.Nodes.Add(MsMay, MsMay)
        nodeFirst = oNode
        If tb.Rows.Count = 0 Then
            Try
                txtDuongdan.Text = MsMay
            Catch ex As Exception
                txtDuongdan.Text = ""
            End Try

            Exit Sub
        End If
        For Each drRoot As DataRow In tb.Rows
            If _MS_MAY <> "-1" Then
                ' If _sMsBoPhan.Equals(drRoot("MS_BO_PHAN").ToString()) Then
                Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
                Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
                Dim oChildNode As TreeNode = New TreeNode(sMaBP)
                oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

                Call ShowTreeNode(sMaBP, oChildNode)

                'End If
            Else
                Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
                Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
                Dim oChildNode As TreeNode = New TreeNode(sMaBP)
                oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

                Call ShowTreeNode(sMaBP, oChildNode)
            End If

        Next
        tvGiamsat.ExpandAll()
        tvGiamsat.Parent.Name = oNode.Name
        tvGiamsat.Focus()
        Try
            tvGiamsat.SelectedNode = nodeFirst
            nodeFirst = tvGiamsat.TopNode.FirstNode
            nodetmp = tvGiamsat.SelectedNode.FirstNode
            tvGiamsat.SelectedNode = nodeFirst
            nodeLast = tvGiamsat.TopNode.LastNode

        Catch ex As Exception

        End Try

    End Sub

    Private Function LocGSTTDenHan(ByVal MS_MAY As String) As DataTable
        Dim dtTmp As DataTable = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(
            Commons.IConnections.ConnectionString, "GetCTTBThongSoGSTTDenNgay", dtNgay.DateTime, MS_MAY, cboLoaiCV.EditValue))

        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,
                "HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName, dtTmp, "")
        Return dtTmp
    End Function

    Sub ShowTreeNode(ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If
        If cboThietbi.Text = "" Then Exit Sub
        Dim MsMay As String
        If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
        If MS_MAY <> "-1" Then MsMay = MS_MAY
        Dim dtNode As New DataTable()
        dtNode.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI_TS_GSTT_GS", MsMay, sMS_BP, chkHangmucdenhangGS.Checked, Commons.Modules.UserName))
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_TS_GSTT").ToString()
            Dim sTenBP As String = drNode("TEN_TS_GSTT").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
        Next
    End Sub
    Sub BindData1(ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String)
        Try

            grdDanhsachTSGSTT.DataSource = New clsChonthongsoGSTTdinhluongController().GetGIA_TRI_DINH_TINHs(intMS_TS_GSTT, strMS_MAY, strMS_BO_PHAN, STT)
            Me.grdDanhsachTSGSTT.Columns("MS_MAY").Visible = False
            Me.grdDanhsachTSGSTT.Columns("TEN_TS_GSTT").Visible = False
            Me.grdDanhsachTSGSTT.Columns("TEN_NHOM_MAY").Visible = False
            Me.grdDanhsachTSGSTT.Columns("MS_TS_GSTT").Visible = False
            Me.grdDanhsachTSGSTT.Columns("STT").Visible = False
            Me.grdDanhsachTSGSTT.Columns("MS_BO_PHAN").Visible = False
            Me.grdDanhsachTSGSTT.Columns("TEN_GIA_TRI").ReadOnly = True
            Me.grdDanhsachTSGSTT.Columns("DAT").ReadOnly = True
            Me.grdDanhsachTSGSTT.Columns("KQ").Visible = False
            Me.grdDanhsachTSGSTT.Columns("MS_TT").Visible = False
            If bKhoitao Then
                CreatechkGiatri()
                bKhoitao = False
            End If

            HienThi()
            RefeshLanguage1()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RefeshLanguage1()
        Try

            Me.grdDanhsachTSGSTT.Columns("TEN_GIA_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_GIA_TRI", Commons.Modules.TypeLanguage)
            Me.grdDanhsachTSGSTT.Columns("TEN_GIA_TRI").Width = 200
            Me.grdDanhsachTSGSTT.Columns("DAT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAT", Commons.Modules.TypeLanguage)
            Me.grdDanhsachTSGSTT.Columns("DAT").Width = 280
            Me.grdDanhsachTSGSTT.Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
            Me.grdDanhsachTSGSTT.Columns("CHON").Width = 50
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.lblLoaithietbi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblLoaithietbi.Name, Commons.Modules.TypeLanguage)
        Me.lblThietbi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblThietbi.Name, Commons.Modules.TypeLanguage)
        Me.chkTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, chkTatCa.Name, Commons.Modules.TypeLanguage)
        Me.chkHangmucdenhangGS.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, chkHangmucdenhangGS.Name, Commons.Modules.TypeLanguage)
        Me.lblTenBoPhan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTenBoPhan.Name, Commons.Modules.TypeLanguage)
        Me.lblMaBoPhan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblMaBoPhan.Name, Commons.Modules.TypeLanguage)


        Me.grpDanhsachgiatriTSGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpDanhsachgiatriTSGSTT.Name, Commons.Modules.TypeLanguage)

        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.btnAllOK.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnAllOK.Name, Commons.Modules.TypeLanguage)
    End Sub
#End Region

    Private Sub BtnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Dim str As String = ""
        Try
            str = "drop PROCEDURE Insert" & BT
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        CapNhapBT()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnDattatca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String = ""
        If cboThietbi.Text = "" Then Exit Sub
        Dim MsMay As String
        If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
        If MS_MAY <> "-1" Then MsMay = MS_MAY
        For i As Integer = 0 To grdDanhsachTSGSTT.Rows.Count - 1
            If grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value And Not grdDanhsachTSGSTT.Rows(i).Cells("DAT").Value Then
                grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value = False
                str = "DELETE FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "' AND STT='" & grdDanhsachTSGSTT.Rows(i).Cells("STT").Value & "' AND MS_BO_PHAN='" & grdDanhsachTSGSTT.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            ElseIf Not grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value And grdDanhsachTSGSTT.Rows(i).Cells("DAT").Value Then
                grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value = True
                str = "INSERT INTO " & BT & " (MS_MAY,TEN_GIA_TRI,MS_TS_GSTT,TEN_TS_GSTT,MS_BO_PHAN,TEN_BO_PHAN,STT ) VALUES(N'" & MsMay & "',N'" & grdDanhsachTSGSTT.Rows(i).Cells("TEN_NHOM_MAY").Value & "',N'" & grdDanhsachTSGSTT.Rows(i).Cells("TEN_GIA_TRI").Value & "',N'" & tvGiamsat.SelectedNode.Name & "',N'" & grdDanhsachTSGSTT.Rows(i).Cells("TEN_TS_GSTT").Value & "',N'" & tvGiamsat.SelectedNode.Parent.Name & "',N'" & tvGiamsat.SelectedNode.Parent.Text & "','" & grdDanhsachTSGSTT.Rows(i).Cells("STT").Value & "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        Next
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Dim str As String = ""
        Try
            str = "drop PROCEDURE Insert" & BT
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = " DELETE FROM " & BT & " WHERE ISNULL(MOI_CU ,'') = ''"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        CapNhapBT()
        Me.Close()


    End Sub

    Private Sub cboThongsogiamsat_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub
    Dim node As TreeNode
    Private Sub tvGiamsat_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvGiamsat.AfterSelect
        Try
            node.BackColor = Color.White
        Catch ex As Exception
        End Try
        If cboThietbi.Text = "" Then Exit Sub
        txtDuongdan.Text = tvGiamsat.SelectedNode.FullPath
        tvGiamsat.SelectedNode.BackColor = Color.LightGray
        node = tvGiamsat.SelectedNode
        Dim MsMay As String
        If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
        If MS_MAY <> "-1" Then MsMay = MS_MAY
        If tvGiamsat.SelectedNode.Name = MsMay Then
            Exit Sub
        Else
            If tvGiamsat.SelectedNode.Parent.Name = MsMay Then
                BindData1(MsMay, tvGiamsat.SelectedNode.Name, "")
                Exit Sub
            End If
        End If
        BindData1(MsMay, tvGiamsat.SelectedNode.Name, tvGiamsat.SelectedNode.Parent.Name)
    End Sub

    Private Sub grdDanhsachTSGSTT_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDanhsachTSGSTT.CellBeginEdit
        If IsDBNull(grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value) Then
            bChon = False
        Else
            bChon = grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value
        End If
    End Sub

    Private Sub grdDanhsachTSGSTT_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachTSGSTT.CellEndEdit
        Dim str As String = ""
        If cboThietbi.Text = "" Then Exit Sub
        Dim MsMay As String
        If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
        If MS_MAY <> "-1" Then MsMay = MS_MAY
        Dim obj As SqlDataReader
        If grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value Then
            If (_BThem = 1) Then
                str = "SELECT DAT FROM " & BT & " INNER JOIN GIA_TRI_TS_GSTT ON " & BT & ".MS_TS_GSTT=GIA_TRI_TS_GSTT.MS_TS_GSTT " &
                " AND GIA_TRI_TS_GSTT.STT=" & BT & ".STT WHERE DAT=1 AND " & BT & ".MS_MAY=N'" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_MAY").Value & "' AND GIA_TRI_TS_GSTT.MS_TS_GSTT='" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_TS_GSTT").Value & "' AND MS_BO_PHAN='" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                obj = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While obj.Read
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "MsgDat", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If Not grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("KQ").Value Then
                        grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value = False
                    End If
                    obj.Close()
                    Exit Sub
                End While
                obj.Close()
                If grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("KQ").Value Then
                    str = "SELECT distinct MS_MAY FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_BO_PHAN='" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "'"
                    obj = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While obj.Read
                        'Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongDat", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                        '

                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongDat",
                                Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbYes Then
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_BO_PHAN='" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "'")
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, MsMay, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_GIA_TRI").Value, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("DAT").Value, tvGiamsat.SelectedNode.Name, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_TS_GSTT").Value, tvGiamsat.SelectedNode.Parent.Name, tvGiamsat.SelectedNode.Parent.Text, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value)
                            For i As Integer = 0 To grdDanhsachTSGSTT.Rows.Count - 1
                                If Not grdDanhsachTSGSTT.Rows(i).Cells("KQ").Value Then
                                    grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value = False
                                End If
                            Next
                        Else
                            grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value = False
                        End If
                        obj.Close()
                        Exit Sub
                    End While
                    obj.Close()
                End If
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, MsMay, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_GIA_TRI").Value, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("DAT").Value, tvGiamsat.SelectedNode.Name, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_TS_GSTT").Value, tvGiamsat.SelectedNode.Parent.Name, tvGiamsat.SelectedNode.Parent.Text, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value)
            ElseIf (BThem = 2) Then

                str = "SELECT DAT FROM " & BT & " INNER JOIN GIA_TRI_TS_GSTT ON " & BT & ".MS_TS_GSTT=GIA_TRI_TS_GSTT.MS_TS_GSTT " &
                " AND GIA_TRI_TS_GSTT.STT=" & BT & ".STT WHERE DAT=1 AND " & BT & ".MS_MAY=N'" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_MAY").Value & "' AND GIA_TRI_TS_GSTT.MS_TS_GSTT='" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_TS_GSTT").Value & "' AND MS_BO_PHAN='" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                obj = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While obj.Read
                    If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_Dat",
                            Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbYes Then

                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, MsMay, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_GIA_TRI").Value, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("DAT").Value, tvGiamsat.SelectedNode.Name, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_TS_GSTT").Value, tvGiamsat.SelectedNode.Parent.Name, tvGiamsat.SelectedNode.Parent.Text, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value)
                        For i As Integer = 0 To grdDanhsachTSGSTT.Rows.Count - 1
                            If grdDanhsachTSGSTT.Rows(i).Cells("KQ").Value Then
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_BO_PHAN='" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "' AND STT = " & grdDanhsachTSGSTT.Rows(i).Cells("STT").Value)
                                grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value = False
                            End If
                        Next
                    Else
                        grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value = False
                    End If
                    obj.Close()
                    Exit Sub
                End While
                obj.Close()
                If grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("KQ").Value Then
                    str = "SELECT distinct MS_MAY FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_BO_PHAN='" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "'"
                    obj = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While obj.Read
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongDat1",
                            Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbYes Then
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, MsMay, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_GIA_TRI").Value, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("DAT").Value, tvGiamsat.SelectedNode.Name, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_TS_GSTT").Value, tvGiamsat.SelectedNode.Parent.Name, tvGiamsat.SelectedNode.Parent.Text, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value)
                            For i As Integer = 0 To grdDanhsachTSGSTT.Rows.Count - 1
                                If Not grdDanhsachTSGSTT.Rows(i).Cells("KQ").Value Then
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT & " WHERE MS_MAY=N'" & MsMay & "' AND MS_BO_PHAN='" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT='" & tvGiamsat.SelectedNode.Name & "' AND STT = " & grdDanhsachTSGSTT.Rows(i).Cells("STT").Value)
                                    grdDanhsachTSGSTT.Rows(i).Cells("CHON").Value = False
                                End If
                            Next
                        Else
                            grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("CHON").Value = False
                        End If
                        obj.Close()
                        Exit Sub
                    End While
                End If
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Insert" & BT, MsMay, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_GIA_TRI").Value, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("DAT").Value, tvGiamsat.SelectedNode.Name, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("TEN_TS_GSTT").Value, tvGiamsat.SelectedNode.Parent.Name, tvGiamsat.SelectedNode.Parent.Text, grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value)

            End If

        ElseIf bChon Then
            Dim tmp As String = "DELETE FROM " & BT & " WHERE MS_MAY='" & MsMay & "' AND MS_BO_PHAN = '" & tvGiamsat.SelectedNode.Parent.Name & "' AND MS_TS_GSTT= '" & tvGiamsat.SelectedNode.Name & "' AND STT = '" & grdDanhsachTSGSTT.Rows(e.RowIndex).Cells("STT").Value & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, tmp)
        End If
    End Sub

    Private Sub txtMaBoPhan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaBoPhan.KeyDown
        If e.KeyValue = 13 Then
            If cboThietbi.Text = "" Then Exit Sub

            Dim MsMay As String
            If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
            If MS_MAY <> "-1" Then MsMay = MS_MAY
            If strLast = txtMaBoPhan.Text Then
                If nodetmp.Name = MsMay Then
                    nodetmp = nodeFirst
                    tvGiamsat.SelectedNode = nodeFirst
                Else
                    If nodetmp.Name <> nodeLast.Name Then
                        tvGiamsat.SelectedNode = nodetmp
                        nodetmp = tvGiamsat.SelectedNode.NextNode
                    Else
                        nodetmp = nodeFirst
                        tvGiamsat.SelectedNode = nodeFirst
                    End If
                End If
            Else
                nodetmp = nodeFirst
                tvGiamsat.SelectedNode = nodeFirst
                strLast = txtMaBoPhan.Text
            End If

            While nodetmp.Name <> nodeLast.Name
                If LCase(nodetmp.Name).Contains(LCase(txtMaBoPhan.Text)) Then
                    tvGiamsat.SelectedNode = nodetmp
                    Exit Sub
                Else
                    nodetmp = tvGiamsat.SelectedNode.NextNode
                    tvGiamsat.SelectedNode = nodetmp
                End If
            End While
            If nodetmp.Name = nodeLast.Name Then
                If LCase(nodetmp.Name).Contains(LCase(txtMaBoPhan.Text)) Then
                    tvGiamsat.SelectedNode = nodetmp
                Else
                    nodetmp = tvGiamsat.SelectedNode.Parent
                    tvGiamsat.SelectedNode = nodetmp
                End If
            End If
        End If

    End Sub
    Dim strTen As String = ""
    Private Sub txtTenBoPhan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTenBoPhan.KeyDown
        If e.KeyValue = 13 Then
            If cboThietbi.Text = "" Then Exit Sub

            Dim MsMay As String
            If sMsMay = "-1" Then MsMay = cboThietbi.EditValue Else MsMay = sMsMay
            If MS_MAY <> "-1" Then MsMay = MS_MAY
            If strTen = txtTenBoPhan.Text Then
                If nodetmp.Name = MsMay Then
                    nodetmp = nodeFirst
                    tvGiamsat.SelectedNode = nodeFirst
                Else
                    If nodetmp.Name <> nodeLast.Name Then
                        tvGiamsat.SelectedNode = nodetmp
                        nodetmp = tvGiamsat.SelectedNode.NextNode
                    Else
                        nodetmp = nodeFirst
                        tvGiamsat.SelectedNode = nodeFirst
                    End If
                End If

            Else
                nodetmp = nodeFirst
                tvGiamsat.SelectedNode = nodeFirst
                strTen = txtTenBoPhan.Text
            End If

            While nodetmp.Name <> nodeLast.Name
                If LCase(nodetmp.Text).Contains(LCase(txtTenBoPhan.Text)) Then
                    tvGiamsat.SelectedNode = nodetmp
                    Exit Sub
                Else
                    nodetmp = tvGiamsat.SelectedNode.NextNode
                    tvGiamsat.SelectedNode = nodetmp
                End If
            End While

            If nodetmp.Name = nodeLast.Name Then
                If LCase(nodetmp.Text).Contains(LCase(txtTenBoPhan.Text)) Then
                    tvGiamsat.SelectedNode = nodetmp
                Else
                    nodetmp = tvGiamsat.SelectedNode.Parent
                    tvGiamsat.SelectedNode = nodetmp
                End If

            End If
        End If
    End Sub




    Private Sub btnAllOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOK.Click
        Try

            If chkHangmucdenhangGS.Checked = False Then
                Commons.Modules.SQLString = "INSERT INTO " & BT & " ( STT, MS_MAY, MS_TS_GSTT, TEN_TS_GSTT, MS_BO_PHAN, TEN_BO_PHAN, TEN_GIA_TRI, GHI_CHU ) " &
                        " SELECT GIA_TRI_TS_GSTT.STT, CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, THONG_SO_GSTT.TEN_TS_GSTT, " &
                        " CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, CAU_TRUC_THIET_BI.TEN_BO_PHAN, GIA_TRI_TS_GSTT.TEN_GIA_TRI, GIA_TRI_TS_GSTT.GHI_CHU " &
                        " FROM CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN MAY ON CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = MAY.MS_MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = THONG_SO_GSTT.MS_TS_GSTT INNER JOIN GIA_TRI_TS_GSTT ON THONG_SO_GSTT.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT INNER JOIN CAU_TRUC_THIET_BI ON CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY AND CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN AND MAY.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY " &
                        " WHERE (ISNULL(CAU_TRUC_THIET_BI_TS_GSTT.ACTIVE,0) = 1) AND (THONG_SO_GSTT.LOAI_TS = 1) AND (ISNULL(MS_LOAI_CV,-99) = " & cboLoaiCV.EditValue.ToString & " OR " & cboLoaiCV.EditValue.ToString & " = -1) " &
                        " AND (CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY=N'" & tvGiamsat.Parent.Name.ToString & "') " &
                        " AND (GIA_TRI_TS_GSTT.DAT = 1) AND NOT EXISTS " &
                        " (SELECT * FROM " & BT & " B WHERE CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = B.MS_MAY " &
                        " AND CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = B.MS_TS_GSTT " &
                        " AND CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = B.MS_BO_PHAN) "
            Else
                Commons.Modules.SQLString = "INSERT INTO " & BT & " ( STT, MS_MAY, MS_TS_GSTT, TEN_TS_GSTT, MS_BO_PHAN, TEN_BO_PHAN, TEN_GIA_TRI, GHI_CHU ) " &
                        "SELECT GIA_TRI_TS_GSTT.STT, CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, " &
                               "THONG_SO_GSTT.TEN_TS_GSTT, CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, CAU_TRUC_THIET_BI.TEN_BO_PHAN, " &
                               "GIA_TRI_TS_GSTT.TEN_GIA_TRI, GIA_TRI_TS_GSTT.GHI_CHU " &
                        "FROM CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN MAY ON CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = MAY.MS_MAY INNER JOIN " &
                             "NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = THONG_SO_GSTT.MS_TS_GSTT INNER JOIN " &
                             "GIA_TRI_TS_GSTT ON THONG_SO_GSTT.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT INNER JOIN CAU_TRUC_THIET_BI ON CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY AND " &
                             "CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN AND MAY.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY INNER JOIN " &
                             "HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & " ON  CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_BO_PHAN AND " &
                             "CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_TS_GSTT " &
                        " WHERE (ISNULL(CAU_TRUC_THIET_BI_TS_GSTT.ACTIVE,0) = 1) AND (THONG_SO_GSTT.LOAI_TS = 1) AND (ISNULL(MS_LOAI_CV,-99) = " & cboLoaiCV.EditValue.ToString & " OR " & cboLoaiCV.EditValue.ToString & " = -1) " &
                            " AND (CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY=N'" & tvGiamsat.Parent.Name.ToString & "') " &
                            " AND (GIA_TRI_TS_GSTT.DAT = 1)  AND NOT EXISTS " &
                            " (SELECT * FROM " & BT & "  B WHERE CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = B.MS_MAY " &
                            " AND CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = B.MS_TS_GSTT " &
                            " AND CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = B.MS_BO_PHAN) "

            End If
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            HienThi()
            RefeshLanguage1()
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End Try

    End Sub
    Private Sub chkLoaiMay_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoaiMay.CheckedChanged
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT)
        Catch EX As Exception
        End Try
        'If chkHangmucdenhangGS.
        dtNgay.Enabled = False
        btnDatLMay.Visible = True
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub
    Private Sub chkTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTatCa.CheckedChanged
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT)
        Catch EX As Exception
        End Try
        'If chkHangmucdenhangGS.
        dtNgay.Enabled = False
        btnDatLMay.Visible = False
        Binddata(chkHangmucdenhangGS.Checked)

    End Sub

    Sub BindDataGiamsattinhtrang(ByVal Chontatca As Boolean)
        grdDanhsachTSGSTT.DataSource = System.DBNull.Value
        If cboLoaithietbi.EditValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Dim sNgay As String = ""

        sNgay = "DATEADD(DAY, -CHU_KY_DO+1, '" & Format(Now.Date, "MM/dd/yyyy") & "')"
        str = "SELECT TMP1.*, GIA_TRI_TS_GSTT.TEN_GIA_TRI, GIA_TRI_TS_GSTT.DAT, CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY, CHU_KY_DO, TMP1.NGAY_KT) WHEN 2 THEN DATEADD(WEEK, CHU_KY_DO, TMP1.NGAY_KT) " &
                      "WHEN 3 THEN DATEADD(MONTH, CHU_KY_DO, TMP1.NGAY_KT) ELSE DATEADD(YEAR, CHU_KY_DO, TMP1.NGAY_KT) END AS NGAY " &
              "FROM (SELECT MS_MAY, NGAY_NHAP, MS_N_XUONG,TEN_N_XUONG,DIA_CHI,DIEN_TICH,KHOANG_CACH,GHI_CHU,MS_LOAI_MAY,MS_BO_PHAN,TEN_BO_PHAN,MS_TS_GSTT,TEN_TS_GSTT,CHU_KY, MAX(NGAY_KT) AS NGAY_KT " &
                    "FROM(SELECT DISTINCT MAY.MS_MAY, MAY_NHA_XUONG.NGAY_NHAP, MAY_NHA_XUONG.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG, " &
                                "NHA_XUONG.DIA_CHI, NHA_XUONG.DIEN_TICH, NHA_XUONG.KHOANG_CACH, NHA_XUONG.GHI_CHU, " &
                                "LOAI_MAY.MS_LOAI_MAY, CAU_TRUC_THIET_BI.MS_BO_PHAN, CAU_TRUC_THIET_BI.TEN_BO_PHAN, " &
                                "GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT, THONG_SO_GSTT.TEN_TS_GSTT, GIA_TRI_TS_GSTT.TEN_GIA_TRI, " &
                                "GIA_TRI_TS_GSTT.DAT, CAU_TRUC_THIET_BI_TS_GSTT.MS_DV_TG, CAU_TRUC_THIET_BI_TS_GSTT.CHU_KY_DO, Convert(NVARCHAR(10), CHU_KY_DO) " &
                                "+ ' ' + CASE 0 WHEN 0 THEN TEN_DV_TG WHEN 1 THEN TEN_DV_TG_ANH ELSE TEN_DV_TG_HOA END AS CHU_KY, GIAM_SAT_TINH_TRANG.NGAY_KT " &
                         "FROM GIAM_SAT_TINH_TRANG INNER JOIN " &
                              "GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT INNER JOIN " &
                              "GIAM_SAT_TINH_TRANG_TS_DT ON GIAM_SAT_TINH_TRANG_TS.STT = GIAM_SAT_TINH_TRANG_TS_DT.STT AND " &
                              "GIAM_SAT_TINH_TRANG_TS.MS_MAY = GIAM_SAT_TINH_TRANG_TS_DT.MS_MAY AND " &
                              "GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT = GIAM_SAT_TINH_TRANG_TS_DT.MS_TS_GSTT AND " &
                              "GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN = GIAM_SAT_TINH_TRANG_TS_DT.MS_BO_PHAN INNER JOIN " &
                              "CAU_TRUC_THIET_BI_TS_GSTT ON GIAM_SAT_TINH_TRANG_TS.MS_MAY = CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY AND " &
                              "GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN = CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN AND " &
                              "GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT = CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT INNER JOIN " &
                              "CAU_TRUC_THIET_BI ON CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY AND " &
                              "CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN INNER JOIN " &
                              "MAY ON CAU_TRUC_THIET_BI.MS_MAY = MAY.MS_MAY INNER JOIN " &
                              "MAY_NHA_XUONG INNER JOIN NHA_XUONG ON MAY_NHA_XUONG.MS_N_XUONG = NHA_XUONG.MS_N_XUONG ON " &
                              "MAY.MS_MAY = MAY_NHA_XUONG.MS_MAY INNER JOIN LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY ON " &
                              "MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " &
                        "THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = THONG_SO_GSTT.MS_TS_GSTT INNER JOIN " &
                        "GIA_TRI_TS_GSTT ON THONG_SO_GSTT.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT AND " &
                        "GIAM_SAT_TINH_TRANG_TS_DT.STT_GT = GIA_TRI_TS_GSTT.STT INNER JOIN " &
                        "DON_VI_THOI_GIAN ON CAU_TRUC_THIET_BI_TS_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " &
                    ") TMP GROUP BY MS_MAY, NGAY_NHAP, MS_N_XUONG,TEN_N_XUONG,DIA_CHI,DIEN_TICH,KHOANG_CACH,GHI_CHU,MS_LOAI_MAY,MS_BO_PHAN,TEN_BO_PHAN,MS_TS_GSTT,TEN_TS_GSTT,CHU_KY " &
                ") TMP1 INNER JOIN GIAM_SAT_TINH_TRANG_TS ON TMP1.MS_MAY = GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " &
                      "TMP1.MS_BO_PHAN = GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN AND TMP1.MS_TS_GSTT = GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT INNER JOIN " &
                      "GIAM_SAT_TINH_TRANG ON GIAM_SAT_TINH_TRANG_TS.STT = GIAM_SAT_TINH_TRANG.STT AND TMP1.NGAY_KT = GIAM_SAT_TINH_TRANG.NGAY_KT INNER JOIN " &
                      "CAU_TRUC_THIET_BI_TS_GSTT ON TMP1.MS_MAY = CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY AND TMP1.MS_BO_PHAN = CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN AND " &
                      "TMP1.MS_TS_GSTT = CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT INNER JOIN GIAM_SAT_TINH_TRANG_TS_DT ON GIAM_SAT_TINH_TRANG_TS.STT = GIAM_SAT_TINH_TRANG_TS_DT.STT AND " &
                      "GIAM_SAT_TINH_TRANG_TS.MS_MAY = GIAM_SAT_TINH_TRANG_TS_DT.MS_MAY AND GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT = GIAM_SAT_TINH_TRANG_TS_DT.MS_TS_GSTT AND " &
                      "GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN = GIAM_SAT_TINH_TRANG_TS_DT.MS_BO_PHAN INNER JOIN GIA_TRI_TS_GSTT ON GIAM_SAT_TINH_TRANG_TS_DT.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT AND " &
                      "GIAM_SAT_TINH_TRANG_TS_DT.STT_GT = GIA_TRI_TS_GSTT.STT " &
               "WHERE CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY, CHU_KY_DO, TMP1.NGAY_KT) " &
                      "WHEN 2 THEN DATEADD(WEEK, CHU_KY_DO, TMP1.NGAY_KT) WHEN 3 THEN DATEADD(MONTH, CHU_KY_DO, TMP1.NGAY_KT) " &
                      "ELSE DATEADD(YEAR, CHU_KY_DO, TMP1.NGAY_KT) END <= '" & Format(Now.Date, "dd/MMM/yyyy") & "'"

        'WHERE TMP1.NGAY_KT <='"  "' "

        If cboLoaithietbi.EditValue.ToString <> "-1" And Not cboLoaithietbi.EditValue Is Nothing Then    'BỘ PHẬN
            str = str + " AND TMP1.MS_LOAI_MAY='" & cboLoaithietbi.EditValue & "'"
        End If

        str = str + " ORDER BY TMP1.MS_MAY"

        'str = str + "AND NHOM_NHA_XUONG.MS_N_XUONG=(SELECT MS_N_XUONG FROM MAY_NHA_XUONG WHERE " & _
        '" MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP =(SELECT     MAX(NGAY_NHAP) " & _
        '" FROM MAY_NHA_XUONG WHERE      MAY_NHA_XUONG.MS_MAY =MAY.MS_MAY))"
        Dim tb As New DataTable()
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "QL_SEARCH", str).Tables(0)
        grdDanhsachTSGSTT.DataSource = tb
        grdDanhsachTSGSTT.Columns("MS_TS_GSTT").Visible = False
        grdDanhsachTSGSTT.Columns("MS_BO_PHAN").Visible = False
        'grdGiamsattinhtrang.Columns("STT_GT").Visible = False
        RefreshLanguageGiamsat()

    End Sub
    Sub RefreshLanguageGiamsat()
        Me.grdDanhsachTSGSTT.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("MS_MAY").Width = 100
        Me.grdDanhsachTSGSTT.Columns("TEN_TS_GSTT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TS_GSTT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("TEN_TS_GSTT").Width = 150
        Me.grdDanhsachTSGSTT.Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("TEN_BO_PHAN").Width = 150
        Me.grdDanhsachTSGSTT.Columns("Ten_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ten_N_XUONG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("Ten_N_XUONG").Width = 150
        Me.grdDanhsachTSGSTT.Columns("Ten_N_XUONG").Visible = False
        Me.grdDanhsachTSGSTT.Columns("TEN_GIA_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_GIA_TRI", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("TEN_GIA_TRI").Width = 150
        Me.grdDanhsachTSGSTT.Columns("NGAY_KT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_KT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("NGAY_KT").Width = 80
        Me.grdDanhsachTSGSTT.Columns("CHU_KY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHU_KY_HIEU_CHUAN", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("CHU_KY").Width = 80
        Me.grdDanhsachTSGSTT.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_KE_TIEP", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("NGAY").Width = 80
        Me.grdDanhsachTSGSTT.Columns("DAT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachTSGSTT.Columns("DAT").Width = 50
        Me.grdDanhsachTSGSTT.Columns("NGAY_NHAP").Visible = False
        Me.grdDanhsachTSGSTT.Columns("MS_N_XUONG").Visible = False
        Me.grdDanhsachTSGSTT.Columns("DIA_CHI").Visible = False
        Me.grdDanhsachTSGSTT.Columns("DIEN_TICH").Visible = False
        Me.grdDanhsachTSGSTT.Columns("KHOANG_CACH").Visible = False
        Me.grdDanhsachTSGSTT.Columns("GHI_CHU").Visible = False
        'Me.grdGiamsattinhtrang.Columns("MS_MAY1").Visible = False
        Me.grdDanhsachTSGSTT.Columns("MS_LOAI_MAY").Visible = False
        'Me.grdGiamsattinhtrang.Columns("TEN_N_XUONG1").Visible = False
        'Me.grdGiamsattinhtrang.Columns("MS_N_XUONG1").Visible = False
    End Sub

    Private Sub chkHangmucdenhangGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHangmucdenhangGS.CheckedChanged
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT)
        Catch EX As Exception
        End Try
        dtNgay.Enabled = True
        btnDatLMay.Visible = False
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub

    Private Sub btnDatLMay_Click(sender As Object, e As EventArgs) Handles btnDatLMay.Click
        If chkTheoDayChuyen.Checked Then Exit Sub
        If chkLoaiMay.Checked = False Then Exit Sub
        If chkLoaiMay.Enabled = False Then Exit Sub
        If cboLoaithietbi.EditValue = "-1" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "msgVuiLongChonLoaiThietBi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Commons.Modules.SQLString = "INSERT INTO " & BT & " SELECT     dbo.GIA_TRI_TS_GSTT.STT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, dbo.MAY.TEN_MAY, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, " &
                      " dbo.THONG_SO_GSTT.TEN_TS_GSTT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN,  " &
                      " dbo.GIA_TRI_TS_GSTT.TEN_GIA_TRI, dbo.GIA_TRI_TS_GSTT.GHI_CHU , dbo.MAY_HE_THONG.MS_HE_THONG AS MOI_CU " &
                      " FROM         dbo.CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN " &
                      " dbo.MAY ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" &
                      " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" &
                      " dbo.THONG_SO_GSTT ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = dbo.THONG_SO_GSTT.MS_TS_GSTT INNER JOIN" &
                      " dbo.GIA_TRI_TS_GSTT ON dbo.THONG_SO_GSTT.MS_TS_GSTT = dbo.GIA_TRI_TS_GSTT.MS_TS_GSTT INNER JOIN" &
                      " dbo.CAU_TRUC_THIET_BI ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                      " dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN AND " &
                      " dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY INNER JOIN" &
                      " dbo.MAY_HE_THONG ON dbo.MAY.MS_MAY = dbo.MAY_HE_THONG.MS_MAY" &
                      " WHERE (ISNULL(CAU_TRUC_THIET_BI_TS_GSTT.ACTIVE,0) = 1) AND (THONG_SO_GSTT.LOAI_TS = 1) AND (dbo.NHOM_MAY.MS_LOAI_MAY = N'" & cboLoaithietbi.EditValue & "') " &
                      " AND (ISNULL(THONG_SO_GSTT.MS_LOAI_CV,-99) = " & cboLoaiCV.EditValue.ToString & " OR " & cboLoaiCV.EditValue.ToString & " = -1) "

            If LOAI <> 0 Then
                Commons.Modules.SQLString = Commons.Modules.SQLString & " AND ( GIA_TRI_TS_GSTT.DAT = " & LOAI & ")"
            Else
                Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (GIA_TRI_TS_GSTT.DAT = 1) "
            End If
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        HienThi()
        RefeshLanguage1()
    End Sub
    Private Sub btDatDayChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDatDayChuyen.Click
        Try
            If chkHangmucdenhangGS.Checked = False Then
                Commons.Modules.SQLString = "INSERT INTO " & BT & " SELECT     dbo.GIA_TRI_TS_GSTT.STT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, dbo.MAY.TEN_MAY, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, " &
                          " dbo.THONG_SO_GSTT.TEN_TS_GSTT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN,  " &
                          " dbo.GIA_TRI_TS_GSTT.TEN_GIA_TRI, dbo.GIA_TRI_TS_GSTT.GHI_CHU , dbo.MAY_HE_THONG.MS_HE_THONG AS MOI_CU " &
                          " FROM         dbo.CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN " &
                          " dbo.MAY ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" &
                          " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" &
                          " dbo.THONG_SO_GSTT ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = dbo.THONG_SO_GSTT.MS_TS_GSTT INNER JOIN" &
                          " dbo.GIA_TRI_TS_GSTT ON dbo.THONG_SO_GSTT.MS_TS_GSTT = dbo.GIA_TRI_TS_GSTT.MS_TS_GSTT INNER JOIN" &
                          " dbo.CAU_TRUC_THIET_BI ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                          " dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN AND " &
                          " dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY INNER JOIN" &
                          " dbo.MAY_HE_THONG ON dbo.MAY.MS_MAY = dbo.MAY_HE_THONG.MS_MAY" &
                          " WHERE (ISNULL(CAU_TRUC_THIET_BI_TS_GSTT.ACTIVE,0) = 1) AND (THONG_SO_GSTT.LOAI_TS = 1) AND (dbo.MAY_HE_THONG.MS_HE_THONG = " & cboDayChuyen.EditValue & ") " &
                          " AND (ISNULL(THONG_SO_GSTT.MS_LOAI_CV,-99) = " & cboLoaiCV.EditValue.ToString & " OR " & cboLoaiCV.EditValue.ToString & " = -1) "
            Else
                Commons.Modules.SQLString = "INSERT INTO " & BT & " SELECT     dbo.GIA_TRI_TS_GSTT.STT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, dbo.MAY.TEN_MAY, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, " &
                      " dbo.THONG_SO_GSTT.TEN_TS_GSTT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN,  " &
                      " dbo.GIA_TRI_TS_GSTT.TEN_GIA_TRI, dbo.GIA_TRI_TS_GSTT.GHI_CHU, dbo.MAY_HE_THONG.MS_HE_THONG AS MOI_CU " &
                      " FROM         dbo.CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN " &
                      " dbo.MAY ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" &
                      " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" &
                      " dbo.THONG_SO_GSTT ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = dbo.THONG_SO_GSTT.MS_TS_GSTT INNER JOIN" &
                      " dbo.GIA_TRI_TS_GSTT ON dbo.THONG_SO_GSTT.MS_TS_GSTT = dbo.GIA_TRI_TS_GSTT.MS_TS_GSTT INNER JOIN" &
                      " dbo.CAU_TRUC_THIET_BI ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                      " dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN AND " &
                      " dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY INNER JOIN" &
                      " dbo.HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & " ON " &
                      " dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = dbo.HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_BO_PHAN AND " &
                      " dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = dbo.HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_TS_GSTT INNER JOIN" &
                      " dbo.MAY_HE_THONG ON dbo.MAY.MS_MAY = dbo.MAY_HE_THONG.MS_MAY" &
                      " WHERE (ISNULL(CAU_TRUC_THIET_BI_TS_GSTT.ACTIVE,0) = 1) AND (THONG_SO_GSTT.LOAI_TS = 1) AND (dbo.MAY_HE_THONG.MS_HE_THONG = " & cboDayChuyen.EditValue & ") " &
                      " AND (ISNULL(THONG_SO_GSTT.MS_LOAI_CV,-99) = " & cboLoaiCV.EditValue.ToString & " OR " & cboLoaiCV.EditValue.ToString & " = -1) "
            End If
            If LOAI <> 0 Then
                Commons.Modules.SQLString = Commons.Modules.SQLString & " AND ( GIA_TRI_TS_GSTT.DAT = " & LOAI & ")"
            Else
                Commons.Modules.SQLString = Commons.Modules.SQLString & " AND (GIA_TRI_TS_GSTT.DAT = 1) "
            End If
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                            "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End Try

        HienThi()
        RefeshLanguage1()

    End Sub

    Private Sub chkTheoDayChuyen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTheoDayChuyen.CheckedChanged
        If Not chkTheoDayChuyen.Checked Then
            lblLoaithietbi.Visible = True
            labDayChuyen.Visible = False
            cboLoaithietbi.Visible = True
            cboDayChuyen.Visible = False
            btDatDayChuyen.Visible = False
            chkLoaiMay.Enabled = True
            TableLayoutPanel2.SetRow(lblLoaithietbi, 0)
            TableLayoutPanel2.SetColumn(lblLoaithietbi, 2)
            TableLayoutPanel2.SetRow(cboLoaithietbi, 0)
            TableLayoutPanel2.SetColumn(cboLoaithietbi, 3)

            TableLayoutPanel2.SetRow(labDayChuyen, 1)
            TableLayoutPanel2.SetColumn(labDayChuyen, 4)
            TableLayoutPanel2.SetRow(cboDayChuyen, 1)
            TableLayoutPanel2.SetColumn(cboDayChuyen, 5)


        Else
            lblLoaithietbi.Visible = False
            labDayChuyen.Visible = True
            cboLoaithietbi.Visible = False
            cboDayChuyen.Visible = True
            btDatDayChuyen.Visible = True
            chkLoaiMay.Enabled = False
            If chkLoaiMay.Checked Then chkTatCa.Checked = True


            TableLayoutPanel2.SetRow(lblLoaithietbi, 0)
            TableLayoutPanel2.SetColumn(lblLoaithietbi, 0)
            TableLayoutPanel2.SetRow(cboLoaithietbi, 1)
            TableLayoutPanel2.SetColumn(cboLoaithietbi, 0)

            TableLayoutPanel2.SetRow(labDayChuyen, 0)
            TableLayoutPanel2.SetColumn(labDayChuyen, 2)
            TableLayoutPanel2.SetRow(cboDayChuyen, 0)
            TableLayoutPanel2.SetColumn(cboDayChuyen, 3)


        End If
        LoadcboThietbi()
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub
    Sub CapNhapBT()
        Dim str As String
        Try

            Try
                str = "DROP TABLE TMP" & BT
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try

            If sMsMay = "-1" Then
                str = "SELECT DISTINCT [STT],[MS_MAY],TEN_MAY,[MS_TS_GSTT],[TEN_TS_GSTT],[MS_BO_PHAN]," &
                        " [TEN_BO_PHAN],[TEN_GIA_TRI],[GHI_CHU] INTO TMP" & BT & " FROM " & BT
            Else
                str = "SELECT DISTINCT [STT],[MS_MAY],TEN_MAY,[MS_TS_GSTT],[TEN_TS_GSTT],[MS_BO_PHAN],[TEN_BO_PHAN],[STT_GT], " &
                        " [TEN_GIA_TRI], [GHI_CHU], [NGAY_KT], [GIO_KT], [MS_CONG_NHAN] INTO TMP" & BT & " FROM " & BT
            End If
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Try
                str = "DROP TABLE " & BT
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try

            str = "SELECT DISTINCT * INTO " & BT & " FROM TMP" & BT
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Try
                str = "DROP TABLE TMP" & BT
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboLoaithietbi_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaithietbi.EditValueChanged
        LoadcboThietbi()
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub

    Private Sub cboThietbi_EditValueChanged(sender As Object, e As EventArgs) Handles cboThietbi.EditValueChanged, cboLoaiCV.EditValueChanged
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub

    Private Sub dtNgay_EditValueChanged(sender As Object, e As EventArgs) Handles dtNgay.EditValueChanged
        If cboThietbi.Text = "" Then Exit Sub

        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM " & BT)
            dtNgay.Enabled = True
            Binddata(chkHangmucdenhangGS.Checked)
        Catch EX As Exception

        End Try
    End Sub

    Private Sub dtNgay_Validated(sender As Object, e As EventArgs) Handles dtNgay.Validated
        If dtNgay.Text = "" Then dtNgay.DateTime = Now
    End Sub



    Private Sub cboDayChuyen_EditValueChanged(sender As Object, e As EventArgs) Handles cboDayChuyen.EditValueChanged
        LoadcboThietbi()
        Binddata(chkHangmucdenhangGS.Checked)
    End Sub

End Class