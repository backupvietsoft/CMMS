Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data

Imports Commons.VS.Classes.Admin
Imports Commons
Imports DevExpress.XtraEditors

Public Class frmChonPhuTungcho_PBT
    Private _MS_PHIEU_BAO_TRI As String
    Private _MS_MAY As String
    Private MS_BO_PHAN As String = ""
    Private MS_CV As Integer = 0
    Private _MS_CVBT As String = ""
    Private HANG_MUC_ID As Integer = 0
    Dim bCo1 As Boolean = False
    Dim bCoPT_Cha As Boolean = False
    Private bCo As Boolean = False
    Private bCo2 As Boolean = False
    Private bCo3 As Boolean = False
    Private bCoPT_VT As Boolean = False
    Private intRowCTTB As Integer = -1
    Private bCoPT_Con As Boolean = False
    Private bCoPT_KH As Boolean = False
    Private bisLoad As Boolean = True
    Private sClick As String
    Private sBTVTX As String = "PHU_TU_XK" & Commons.Modules.UserName

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

    Public Property MS_CVBT() As String
        Get
            Return _MS_CVBT
        End Get
        Set(ByVal value As String)
            _MS_CVBT = value
        End Set
    End Property

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmChonPhuTungcho_PBT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "drop PROC InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmChonPhuTungcho_PBT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnThoat_3.Visible = True
        TabControl1.TabPages.RemoveByKey("TabVattu_kehoachcongviecphutung")
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Dim str As String = ""
        Dim tb As New DataTable
        Try
            str = "drop PROC [dbo].InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [dbo].[InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "]" & _
        " @MS_PHIEU_BAO_TRI NVARCHAR(30),@MS_CV INT,@MS_BO_PHAN NVARCHAR(50),@MS_PT NVARCHAR(255),@TEN_PT NVARCHAR(255), " & _
        " @SL_KH FLOAT,@MS_PT_CHA NVARCHAR(50),@MS_PT_NCC NVARCHAR(255),@MS_PT_CTY NVARCHAR(255),@TU_XUAT INT, @VTPT BIT " & _
        " AS INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT, " & _
        " SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,TU_XUAT, VTPT) " & _
        " VALUES(@MS_PHIEU_BAO_TRI,@MS_CV,@MS_BO_PHAN,@MS_PT,@TEN_PT,@SL_KH,@MS_PT_CHA,@MS_PT_NCC,@MS_PT_CTY,@TU_XUAT,@VTPT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = "SELECT DISTINCT MS_CV,TEN_BO_PHAN,    MS_BO_PHAN,MA_CV,HANG_MUC_ID, " & _
                " CONVERT(NVARCHAR(250),MS_CV) +  CONVERT(NVARCHAR(250),MS_BO_PHAN) AS MSCVBT " & _
                " FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " ORDER BY TEN_BO_PHAN,MA_CV"
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        'dtQTCN.PrimaryKey = new DataColumn[] { dtQTCN.Columns["BUOC"] };
        tb.PrimaryKey = New DataColumn() {tb.Columns("MSCVBT")}
        Dim index As Integer = tb.Rows.IndexOf(tb.Rows.Find(MS_CVBT))




        grvDSCongViec.DataSource = tb

        grvDSCongViec.Columns("MS_CV").Visible = False
        grvDSCongViec.Columns("MS_BO_PHAN").Visible = False
        grvDSCongViec.Columns("HANG_MUC_ID").Visible = False
        grvDSCongViec.Columns("MSCVBT").Visible = False
        With grvDSCongViec
            .Columns("MA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_CV", Commons.Modules.TypeLanguage)
            .Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.grvDSCongViec.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grvDSCongViec.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            grvDSCongViec.Rows(index).Selected = True
            grvDSCongViec.CurrentCell = grvDSCongViec.Rows(index).Cells("MA_CV")
        Catch ex As Exception
        End Try


        bisLoad = False
        ShowData()

        Dim dtTmp As New DataTable
        Dim tb1 As New DataTable
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                " WHERE ISNULL(TU_XUAT,0) = 0"
        tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb1.Rows.Count - 1
            For j As Integer = 0 To dgrDanhSachVatTuPhuTung.Rows.Count - 1
                If tb1.Rows(i).Item("MS_PT") = dgrDanhSachVatTuPhuTung.Rows(j).Cells("MS_PT").Value Then
                    dgrDanhSachVatTuPhuTung.Rows(j).Cells("chkChon").Value = True
                    Exit For
                End If
            Next
        Next


        Try

            str = "SELECT     CHON, MS_PHIEU_BAO_TRI, MS_PT, TEN_PT, MS_PT_NCC, SL_VT, MS_DH_XUAT_PT, " & _
                        " MS_DH_NHAP_PT, TEN_VI_TRI, MS_BO_PHAN, MS_CV FROM " & sBTVTX & _
                        " ORDER BY MS_PT , TEN_PT"
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

            dtTmp.Columns("CHON").ReadOnly = False
            grdPTXuatKho.DataSource = dtTmp

            grdPTXuatKho.Columns("MS_PHIEU_BAO_TRI").Visible = False
            grdPTXuatKho.Columns("MS_BO_PHAN").Visible = False
            grdPTXuatKho.Columns("MS_CV").Visible = False
            With grdPTXuatKho
                .Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
                .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
                .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
                .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
                .Columns("SL_VT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_VT", Commons.Modules.TypeLanguage)
                .Columns("MS_DH_XUAT_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_XUAT_PT", Commons.Modules.TypeLanguage)
                .Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
                .Columns("TEN_VI_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_VI_TRI", Commons.Modules.TypeLanguage)
                Try
                    .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                    .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
                Catch ex As Exception
                End Try
            End With

            tb1 = New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                    " WHERE ISNULL(TU_XUAT,0) = 1"
            tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

            For i As Integer = 0 To tb1.Rows.Count - 1
                For j As Integer = 0 To grdPTXuatKho.Rows.Count - 1
                    If tb1.Rows(i).Item("MS_PT") = grdPTXuatKho.Rows(j).Cells("MS_PT").Value Then
                        grdPTXuatKho.Rows(j).Cells("CHON").Value = True
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message())
        End Try

        'Commons.Modules.ObjSystems.MLoadNNXtraGrid (grdDMVT,

    End Sub

    Private Sub btnThoat_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat_3.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub ShowData()
        If bisLoad Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If TabControl1.SelectedIndex = 0 Then
            LoadCauTrucThietBi()
            BindDataPhuTung(0)
            LoadVatTuPhuTung()

        End If
        If TabControl1.SelectedIndex = 1 Then
            LoadTuXuatKho()
        End If
        If TabControl1.SelectedIndex = 2 Then
            LoadDanhMucVatTu()
        End If
        TimPT()
        Me.Cursor = Cursors.Default
    End Sub

    Sub LoadVatTuPhuTung()

        Dim str As String = ""
        Dim tb1 As New DataTable

        Dim dtTmp As New DataTable
        dgrDanhSachVatTuPhuTung.Columns.Clear()
        dtTmp = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_VAT_TU_PHU_TUNGs(Commons.Modules.TypeLanguage, MS_MAY, Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN)
        Dim dgCol As New DataGridViewCheckBoxColumn
        With dgCol
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ThreeState = False
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .TrueValue = True
            .FalseValue = False
        End With

        dgrDanhSachVatTuPhuTung.Columns.Insert(0, dgCol)
        dgrDanhSachVatTuPhuTung.ReadOnly = False
        dgrDanhSachVatTuPhuTung.Columns("chkChon").ReadOnly = False
        dgrDanhSachVatTuPhuTung.Columns("chkChon").DataPropertyName = "chkChon"
        dtTmp.Columns("chkChon").ReadOnly = False
        Me.dgrDanhSachVatTuPhuTung.DataSource = dtTmp

        TimPT()

        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                " WHERE  MS_CV='" & MS_CV & "' AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND ISNULL(TU_XUAT,0) = 0"
        tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb1.Rows.Count - 1
            For j As Integer = 0 To dgrDanhSachVatTuPhuTung.Rows.Count - 1
                If tb1.Rows(i).Item("MS_PT") = dgrDanhSachVatTuPhuTung.Rows(j).Cells("MS_PT").Value Then
                    dgrDanhSachVatTuPhuTung.Rows(j).Cells("chkChon").Value = True
                    Exit For
                End If
            Next
        Next

        dgrDanhSachVatTuPhuTung.Columns("TEN_LOAI_VT_TV").Visible = False
        'dgrDanhSachVatTuPhuTung.Columns("MS_PT").Visible = False
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_CHA").Visible = False

        dgrDanhSachVatTuPhuTung.Columns("TEN_PT").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("TEN_PT_VIET").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_NCC").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_CTY").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("TEN_1").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("SL_KH").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("QUY_CACH").ReadOnly = True

        dgrDanhSachVatTuPhuTung.Columns("TEN_PT").Width = 150
        dgrDanhSachVatTuPhuTung.Columns("TEN_PT_VIET").Width = 150
        dgrDanhSachVatTuPhuTung.Columns("SL_KH").Width = 70
        dgrDanhSachVatTuPhuTung.Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_NCC").Width = 150
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_CTY").Width = 150
        dgrDanhSachVatTuPhuTung.Columns("TEN_1").Width = 100
        dgrDanhSachVatTuPhuTung.Columns("chkChon").Width = 50
        dgrDanhSachVatTuPhuTung.Columns("QUY_CACH").Width = 150
        With dgrDanhSachVatTuPhuTung
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_VT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT_VIET", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
            .Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "chkChon", Commons.Modules.TypeLanguage)
            .Columns("TEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_1", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("QUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "QUY_CACH", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.dgrDanhSachVatTuPhuTung.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSachVatTuPhuTung.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadDanhMucVatTu()
        Dim Str As String
        Dim dtTmp As New DataTable
        Dim sBTPT, sBTVT As String
        sBTPT = "BTPTPBT" & Commons.Modules.UserName
        sBTVT = "BTVTPBT" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(sBTPT)
        Commons.Modules.ObjSystems.XoaTable(sBTVT)
        dtTmp = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs(Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, MS_BO_PHAN, MS_PHIEU_BAO_TRI, MS_CV)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTPT, dtTmp, "")


        dtTmp = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_VAT_TU_PHU_TUNGs(Commons.Modules.TypeLanguage, MS_MAY, Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVT, dtTmp, "")

        Str = " SELECT DISTINCT CONVERT(BIT,0) AS CHON, A.MS_PT, A.TEN_PT,A.TEN_PT_VIET, 1 AS SL_KH, " & _
                    " CASE 0 WHEN 0 THEN B.TEN_LOAI_VT_TV WHEN 1 THEN B.TEN_LOAI_VT_TA ELSE B.TEN_LOAI_VT_TV END AS TEN_LOAI_VT_TV, " & _
                    " A.MS_PT_NCC,A.MS_PT_CTY,(CASE 0 WHEN 0 THEN C.TEN_1 WHEN 1 THEN C.TEN_2 ELSE C.TEN_3 END)AS TEN_1  ,'YN' AS MS_PT_CHA ,QUY_CACH, " & _
                    " '" & MS_CV & "' AS  MS_CV, '" & MS_BO_PHAN & "' AS MS_BO_PHAN , " & _
                    " CONVERT(NVARCHAR(250),'" & MS_CV & "') +  CONVERT(NVARCHAR(250),'" & MS_BO_PHAN & "') AS MSCVBT " & _
                    " FROM dbo.IC_PHU_TUNG AS A INNER JOIN dbo.LOAI_VT AS B ON A.MS_LOAI_VT = B.MS_LOAI_VT INNER JOIN " & _
                    " dbo.DON_VI_TINH AS C ON A.DVT = C.DVT " & _
                    " INNER JOIN dbo.IC_PHU_TUNG_LOAI_PHU_TUNG AS D ON A.MS_PT = D.MS_PT INNER JOIN " & _
                    " dbo.NHOM_LOAI_PHU_TUNG AS E ON D.MS_LOAI_PT = E.MS_LOAI_PT INNER JOIN " & _
                    " dbo.USERS AS F ON E.GROUP_ID = F.GROUP_ID " & _
                    " WHERE (USERNAME = '" & Commons.Modules.UserName & "') AND NOT EXISTS (   SELECT DISTINCT MS_PT FROM ( SELECT DISTINCT MS_PT FROM " & sBTPT & " UNION SELECT DISTINCT MS_PT FROM " & sBTVT & " )  B WHERE A.MS_PT = B.MS_PT  ) " & _
                    " AND (ACTIVE_PT = 1) ORDER BY A.MS_PT"
        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))
        Commons.Modules.ObjSystems.XoaTable(sBTPT)
        Commons.Modules.ObjSystems.XoaTable(sBTVT)
        grdDMVT.Columns.Clear()

        Dim dgCol As New DataGridViewCheckBoxColumn
        With dgCol
            .Name = "CHON"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ThreeState = False
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .TrueValue = True
            .FalseValue = False
        End With

        grdDMVT.Columns.Insert(0, dgCol)
        grdDMVT.ReadOnly = False
        grdDMVT.Columns("CHON").ReadOnly = False
        grdDMVT.Columns("CHON").DataPropertyName = "CHON"
        dtTmp.Columns("CHON").ReadOnly = False
        dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("MS_PT")}
        Me.grdDMVT.DataSource = dtTmp

        dtTmp = New DataTable

        Str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                    " WHERE ISNULL(TU_XUAT,0) = 0 AND MS_CV = '" & MS_CV & "' AND MS_BO_PHAN = '" & MS_BO_PHAN & "' "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))
        Dim dtTable As New DataTable
        dtTable = CType(grdDMVT.DataSource, DataTable)

        For i As Integer = 0 To dtTmp.Rows.Count - 1
            Dim index As Integer = dtTable.Rows.IndexOf(dtTable.Rows.Find(dtTmp.Rows(i).Item("MS_PT").ToString()))
            If index >= 0 Then dtTable.Rows(index)("CHON") = True


            'For j As Integer = 0 To grdDMVT.Rows.Count - 1
            '    If dtTmp.Rows(i).Item("MS_PT") = grdDMVT.Rows(j).Cells("MS_PT").Value Then
            '        grdDMVT.Rows(j).Cells("CHON").Value = True
            '        Exit For
            '    End If
            'Next
        Next
        'txtTimPT_TextChanged(sender, e)


        With grdDMVT
            If .Columns("MS_CV").Visible = False Then Exit Sub
            .Columns("MS_CV").Visible = False
            .Columns("MS_BO_PHAN").Visible = False
            .Columns("MSCVBT").Visible = False
            .Columns("MS_PT_CHA").Visible = False

            .Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "chkChon", Commons.Modules.TypeLanguage)
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_VT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT_VIET", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
            .Columns("TEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_1", Commons.Modules.TypeLanguage)
            .Columns("QUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "QUY_CACH", Commons.Modules.TypeLanguage)
            .Columns("TEN_LOAI_VT_TV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPT", "TEN_LOAI_VT_TV", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub LoadCauTrucThietBi()



    End Sub

    Sub LoadTuXuatKho()
        Try

            Dim dtTmp As New DataTable
            dtTmp = CType(grdPTXuatKho.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = " MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "' AND MS_BO_PHAN = '" & MS_BO_PHAN & "' AND  MS_CV = " & MS_CV
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub grvDSCongViec_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvDSCongViec.RowEnter
        MS_BO_PHAN = grvDSCongViec.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value
        MS_CV = grvDSCongViec.Rows(e.RowIndex).Cells("MS_CV").Value
        If IsDBNull(grvDSCongViec.Rows(e.RowIndex).Cells("HANG_MUC_ID").Value) Then
            HANG_MUC_ID = 0
        Else
            HANG_MUC_ID = grvDSCongViec.Rows(e.RowIndex).Cells("HANG_MUC_ID").Value
        End If
        If bisLoad Then Exit Sub
        ShowData()
    End Sub


    Private Sub btnThucHien_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien_3.Click
        Dim dtTmp As New DataTable
        dtTmp = CType(grdPTXuatKho.DataSource, DataTable)
        dtTmp.DefaultView.RowFilter = ""
        dtTmp = dtTmp.DefaultView.ToTable()

        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVTX, dtTmp, "")

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgrDanhSachVatTuPhuTung_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgrDanhSachVatTuPhuTung.CellBeginEdit
        If dgrDanhSachVatTuPhuTung.Columns(e.ColumnIndex).Name = "chkChon" Then
            If dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("chkChon").Value Then
                bCoPT_VT = True
            Else
                bCoPT_VT = False
            End If

            If KiemPTTonTaiNAV(dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value) = True Then
                e.Cancel = True
                Exit Sub
            End If

            Dim dtTmp As New DataTable
            dtTmp = CType(grdPTXuatKho.DataSource, DataTable)
            Dim sSql As String
            sSql = "PT_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "")

            If grdPTXuatKho.Columns(e.ColumnIndex).Name = "CHON" Then
                sSql = "SELECT * FROM " & sSql & " WHERE MS_PT = '" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND CHON = 1"
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    e.Cancel = True
                End If
            End If
            Commons.Modules.ObjSystems.XoaTable("PT_TMP" & Commons.Modules.UserName)

        End If
    End Sub

    Private Sub dgrDanhSachVatTuPhuTung_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachVatTuPhuTung.CellEndEdit
        Dim str As String = ""
        If dgrDanhSachVatTuPhuTung.Columns(e.ColumnIndex).Name = "chkChon" Then
            If dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And Not bCoPT_VT Then
                Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY) VALUES(N'" & _
                                       MS_PHIEU_BAO_TRI & "'," & MS_CV & ",'" & MS_BO_PHAN & "','" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "',N'" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("TEN_PT").Value & "'," & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("SL_KH").Value & ",'" & _
                                       dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_CHA").Value & "'," & IIf(IsDBNull(dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_NCC").Value) Or dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_NCC").Value.ToString.Trim = "", "NULL", "'" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_NCC").Value & "'") & ",'" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_CTY").Value & "')"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            ElseIf Not dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And bCoPT_VT Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub grdDanhsachphutungcha_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDanhsachphutungcha.CellBeginEdit
        If grdDanhsachphutungcha.Columns(e.ColumnIndex).Name = "chkChon" Then
            grdDanhsachphutungcha.Columns("chkChon").ReadOnly = False
            If grdDanhsachphutungcha.Rows(e.RowIndex).Cells("chkChon").Value Then
                bCoPT_Cha = True
            Else
                bCoPT_Cha = False
            End If
            If KiemPTTonTaiNAV(grdDanhsachphutungcha.Rows(e.RowIndex).Cells("MS_PT").Value) = True Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub grdDanhsachphutungcha_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphutungcha.CellEndEdit
        Dim str As String = ""
        If grdDanhsachphutungcha.Columns(e.ColumnIndex).Name = "chkChon" Then
            If grdDanhsachphutungcha.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And Not bCoPT_Cha Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, _
                  grdDanhsachphutungcha.Rows(e.RowIndex).Cells("MS_PT").Value, grdDanhsachphutungcha.Rows(e.RowIndex).Cells("TEN_PT").Value, _
                  grdDanhsachphutungcha.Rows(e.RowIndex).Cells("SL_KH").Value, "N", grdDanhsachphutungcha.Rows(e.RowIndex).Cells("MS_PT_NCC").Value, _
                  grdDanhsachphutungcha.Rows(e.RowIndex).Cells("MS_PT_CTY").Value, 0)
                BindDataPhuTung(e.RowIndex)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT_CHA='Y'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                grdDanhsachphutungcon.ReadOnly = True
            ElseIf bCoPT_Cha And Not grdDanhsachphutungcha.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdDanhsachphutungcha.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdDanhsachphutungcon.ReadOnly = False
            End If
        End If
    End Sub
    Sub BindDataPhuTung(ByVal intRow As Integer)
        sClick = ""
        Dim str As String = ""
        Dim dtTmp As New DataTable
        grdDanhsachphutungcon.Columns.Clear()
        dtTmp = New clsCHON_CONG_VIEC_CHO_PBTController().GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs(Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, MS_BO_PHAN, MS_PHIEU_BAO_TRI, MS_CV)


        Dim dgCol As New DataGridViewCheckBoxColumn
        With dgCol
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ThreeState = False
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .TrueValue = True
            .FalseValue = False
        End With

        grdDanhsachphutungcon.Columns.Insert(0, dgCol)
        grdDanhsachphutungcon.ReadOnly = False
        grdDanhsachphutungcon.Columns("chkChon").ReadOnly = False
        grdDanhsachphutungcon.Columns("chkChon").DataPropertyName = "chkChon"
        dtTmp.Columns("chkChon").ReadOnly = False

        Me.grdDanhsachphutungcon.DataSource = dtTmp


        Dim tb1 As New DataTable
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                " WHERE  MS_CV='" & MS_CV & "' AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND ISNULL(TU_XUAT,0) = 0"
        tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb1.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachphutungcon.Rows.Count - 1
                If tb1.Rows(i).Item("MS_PT") = grdDanhsachphutungcon.Rows(j).Cells("MS_PT").Value Then
                    grdDanhsachphutungcon.Rows(j).Cells("chkChon").Value = True
                    Exit For
                End If
            Next
        Next
        grdDanhsachphutungcon.Columns("MS_PT_CHA").Visible = False
        grdDanhsachphutungcon.Columns("TEN_LOAI_VT_TV").Visible = False

        grdDanhsachphutungcon.Columns("TEN_PT").ReadOnly = True
        grdDanhsachphutungcon.Columns("TEN_PT_VIET").ReadOnly = True
        grdDanhsachphutungcon.Columns("MS_PT_NCC").ReadOnly = True
        grdDanhsachphutungcon.Columns("MS_PT_CTY").ReadOnly = True
        grdDanhsachphutungcon.Columns("TEN_1").ReadOnly = True
        grdDanhsachphutungcon.Columns("SL_KH").ReadOnly = True
        grdDanhsachphutungcon.Columns("QUY_CACH").ReadOnly = True

        grdDanhsachphutungcon.Columns("TEN_PT").Width = 170
        grdDanhsachphutungcon.Columns("TEN_PT_VIET").Width = 170
        grdDanhsachphutungcon.Columns("SL_KH").Width = 70
        grdDanhsachphutungcon.Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachphutungcon.Columns("MS_PT_NCC").Width = 150
        grdDanhsachphutungcon.Columns("MS_PT_CTY").Width = 150
        grdDanhsachphutungcon.Columns("TEN_1").Width = 78
        grdDanhsachphutungcon.Columns("chkChon").Width = 50
        grdDanhsachphutungcon.Columns("QUY_CACH").Width = 150
        With grdDanhsachphutungcon
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT_VIET", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
            .Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "chkChon", Commons.Modules.TypeLanguage)
            .Columns("TEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_1", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("QUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "QUY_CACH", Commons.Modules.TypeLanguage)
        End With
        Try
            Dim objRead As SqlDataReader

            Commons.Modules.SQLString = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
            objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While objRead.Read
                If Not IsDBNull(objRead.Item("MS_PT")) Then
                    For k As Integer = 0 To grdDanhsachphutungcon.RowCount - 1
                        If grdDanhsachphutungcon.Rows(k).Cells("MS_PT").Value = objRead.Item("MS_PT") Then
                            grdDanhsachphutungcon.Rows(k).DefaultCellStyle.BackColor = Color.LightGreen
                            Exit For
                        End If
                    Next
                End If
            End While

            Me.grdDanhsachphutungcon.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachphutungcon.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDanhsachphutungcha_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphutungcha.RowEnter
        intRowCTTB = e.RowIndex
    End Sub

    Private Sub grdDanhsachphutungcon_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDanhsachphutungcon.CellBeginEdit
        If sClick = "CellContentClick" Then Exit Sub

        If grdDanhsachphutungcon.Columns(e.ColumnIndex).Name = "chkChon" And grdDanhsachphutungcha.Rows.Count > 0 Then
            If intRowCTTB <> -1 Then
                If grdDanhsachphutungcha.Rows(intRowCTTB).Cells("chkChon").Value Then
                    grdDanhsachphutungcon.Columns("chkChon").ReadOnly = True
                Else
                    grdDanhsachphutungcon.Columns("chkChon").ReadOnly = False
                End If
            End If
        End If


        If grdDanhsachphutungcon.Columns(e.ColumnIndex).Name = "chkChon" Then
            If grdDanhsachphutungcon.Rows(e.RowIndex).Cells("chkChon").Value Then
                bCoPT_Con = True
            Else
                bCoPT_Con = False
            End If
            Dim sSql As String
            Dim dtTmp As New DataTable



            dtTmp = CType(grdPTXuatKho.DataSource, DataTable)
            sSql = ""
            sSql = "PT_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "")
            Try
                If grdPTXuatKho.Columns(e.ColumnIndex).Name = "CHON" Then
                    sSql = "SELECT * FROM " & sSql & " WHERE MS_PT = '" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND CHON = 1"
                    dtTmp = New DataTable
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                    If dtTmp.Rows.Count > 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try

            Commons.Modules.ObjSystems.XoaTable("PT_TMP" & Commons.Modules.UserName)
        End If
    End Sub


    Function KiemPTTonTaiNAV(ByVal sMsPT As String) As Boolean
        ' Return True ton tai
        Dim sSql, sINTConnect As String
        Try
            If Commons.Modules.sPrivate <> "BARIA" Then Return False

            sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG"
            sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)))
            sSql = "SELECT ISNULL(SUM(SO_LUONG),0) AS SL FROM NAV_REQUEST WHERE MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "' AND MS_MAY = '" & MS_MAY & "' AND MS_PT = '" & sMsPT & "' "
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                If Double.Parse(dtTmp.Rows(0)(0)) > 0 Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDaChuyenDuLieuKhongTheXoa", Commons.Modules.TypeLanguage))
                    Return True
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Private Sub grdDanhsachphutungcon_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphutungcon.CellEndEdit
        If sClick = "CellContentClick" Then Exit Sub

        Dim str As String = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_"
        If grdDanhsachphutungcon.Columns(e.ColumnIndex).Name = "chkChon" Then
            If grdDanhsachphutungcon.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And Not bCoPT_Con Then
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' " & _
                            " AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value & "'"

                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    objRead.Close()
                    Exit Sub
                End While
                objRead.Close()

                Dim objReader As SqlDataReader
                Dim dtR As SqlDataReader


                Try
                    Commons.Modules.SQLString = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    While objReader.Read
                        Commons.Modules.SQLString = "SELECT COUNT(*) FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
                                        "dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT " & _
                                 "WHERE (dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV = '" & MS_CV & "') AND (dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = '" & MS_BO_PHAN & "') AND (dbo.LOAI_VT.VAT_TU = 0) "

                        'dtR = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'")
                        dtR = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        dtR.Read()
                        If dtR.Item(0) > 0 And UCase(objReader.Item("MS_PT").ToString) = UCase(grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value.ToString) Then
                            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CO_MUON_CHON_PT_CHA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                                grdDanhsachphutungcon.Rows(e.RowIndex).Cells("chkChon").Value = False
                                Exit Sub
                            End If
                        End If
                        For j As Integer = 0 To grdDanhsachphutungcon.RowCount - 1
                            If grdDanhsachphutungcon.Rows(j).Cells("MS_PT").Value = objReader.Item("MS_PT") Then
                                grdDanhsachphutungcon.Rows(j).DefaultCellStyle.BackColor = Color.LightGreen
                                Exit For
                            End If
                        Next
                    End While
                Catch
                End Try

                'KIEM TRA DA CO PT CHA CHUA, NEU CO ROI THI KHONG CHO CHON CAC PHU TUNG CON
                str = "SELECT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT,ISNULL(COUNT(*),0) AS TONG FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT IN (SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' ) " & _
                      "GROUP BY PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT  "
                ' "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
                objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

                While objRead.Read
                    If objRead.Item("TONG") > 0 And UCase(objRead.Item("MS_PT").ToString) <> UCase(grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value.ToString) Then    'DA CHON PT CHA ROI
                        'HUY CHON PT CON
                        grdDanhsachphutungcon.Rows(e.RowIndex).Cells("chkChon").Value = False
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DA_CHON_PT_CHA", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                        objRead.Close()
                        Exit Sub
                    End If
                End While
                objRead.Close()

                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY) " & _
                      "VALUES(N'" & MS_PHIEU_BAO_TRI & "'," & MS_CV & ",'" & MS_BO_PHAN & "','" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value & "',N'" & _
                       grdDanhsachphutungcon.Rows(e.RowIndex).Cells("TEN_PT").Value & "'," & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("SL_KH").Value & ",'Y'," & _
                       IIf(grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_NCC").Value.ToString = "", "NULL", "'" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_NCC").Value & "'") & _
                       ",'" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_CTY").Value & "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


                'NEU CHON PT CHA THI BO NHUNG PT CON
                ' "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
                'str = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT IN (SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "')"

                '       commons.Modules.SQLString = "SELECT COUNT(*) FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
                '       "dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT " & _
                '"WHERE (dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV = '" & MS_CV & "') AND (dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = '" & MS_BO_PHAN & "') AND (dbo.LOAI_VT.VAT_TU = 0)"


                objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    For j As Integer = 0 To grdDanhsachphutungcon.RowCount - 1
                        If grdDanhsachphutungcon.Rows(j).Cells("MS_PT").Value = objRead.Item("MS_PT") Then
                            grdDanhsachphutungcon.Rows(j).DefaultCellStyle.BackColor = Color.LightGreen
                            'str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & MS_PHIEU_BAO_TRI & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_PT='" & objRead.Item("MS_PT") & "'"
                            '   str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & MS_PHIEU_BAO_TRI & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_PT NOT IN(SELECT MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & MS_PHIEU_BAO_TRI & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_PT='" & objRead.Item("MS_PT") & "')"
                            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT IN " & _
                                        "(SELECT TMP.MS_PT FROM  (SELECT     MS_PT " & _
                                                                 "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " " & _
                                                                 "WHERE MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "' AND MS_CV = " & MS_CV & " AND MS_BO_PHAN = '" & MS_BO_PHAN & "' AND MS_PT NOT IN " & _
                                                                            "(SELECT MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " " & _
                                                                             "WHERE MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "' AND MS_CV = " & MS_CV & " AND MS_BO_PHAN = '" & MS_BO_PHAN & "' AND MS_PT = '" & objRead.Item("MS_PT") & "')) " & _
                                        "TMP INNER JOIN IC_PHU_TUNG ON TMP.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT " & _
                                 "WHERE(LOAI_VT.VAT_TU = 0))"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

                            For k As Integer = 0 To grdDanhsachphutungcon.RowCount - 1
                                If UCase(grdDanhsachphutungcon.Rows(k).Cells("MS_PT").Value) <> UCase(objRead.Item("MS_PT")) Then
                                    grdDanhsachphutungcon.Rows(k).Cells("chkChon").Value = False
                                End If
                            Next
                            Exit For
                        End If
                    Next
                End While
            ElseIf Not grdDanhsachphutungcon.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And bCoPT_Con Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_PT_CHA='Y'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub grdKehoachcongviecphutung_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdKehoachcongviecphutung.CellBeginEdit
        If grdKehoachcongviecphutung.Columns(e.ColumnIndex).Name = "chkChon" Then
            If grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("chkChon").Value Then
                bCoPT_KH = True
            Else
                bCoPT_KH = False
            End If
        End If
    End Sub

    Private Sub grdKehoachcongviecphutung_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKehoachcongviecphutung.CellEndEdit
        Dim str As String = ""
        If grdKehoachcongviecphutung.Columns(e.ColumnIndex).Name = "chkChon" Then
            If grdKehoachcongviecphutung.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And Not bCoPT_KH Then
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    objRead.Close()
                    Exit Sub
                End While
                objRead.Close()
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, _
                    grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT").Value, grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("TEN_PT").Value, _
                     grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("SL_KH").Value, grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT_CHA").Value, _
                     grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT_NCC").Value, grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT_CTY").Value)
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT_CHA='Y'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdDanhsachphutungcon.ReadOnly = True
            ElseIf Not grdKehoachcongviecphutung.Rows(e.RowIndex).Cells(e.ColumnIndex).Value And bCoPT_KH Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdKehoachcongviecphutung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
            LoadVatTuPhuTung()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ShowData()
    End Sub


    Private Sub grdDanhsachphutungcon_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachphutungcon.ColumnHeaderMouseClick
        Dim objRead As SqlDataReader

        Try
            Commons.Modules.SQLString = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & _MS_MAY & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "'"
            objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While objRead.Read
                If Not IsDBNull(objRead.Item("MS_PT")) Then
                    For j As Integer = 0 To grdDanhsachphutungcon.RowCount - 1
                        If grdDanhsachphutungcon.Rows(j).Cells("MS_PT").Value = objRead.Item("MS_PT") Then
                            grdDanhsachphutungcon.Rows(j).DefaultCellStyle.BackColor = Color.LightGreen
                            Exit For
                        End If
                    Next
                End If
            End While
        Catch
        End Try
    End Sub



    Private Sub grdPTXuatKho_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdPTXuatKho.CellBeginEdit
        Dim dtTmp As New DataTable
        Dim sSql As String
        If grdPTXuatKho.Columns(e.ColumnIndex).Name = "CHON" Then
            If KiemPTTonTaiNAV(grdPTXuatKho.Rows(e.RowIndex).Cells("MS_PT").Value) = True Then
                e.Cancel = True
                Exit Sub
            End If

            sSql = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & _
                    " WHERE ISNULL(TU_XUAT,0) = 0 AND  MS_PT = '" & grdPTXuatKho.Rows(e.RowIndex).Cells("MS_PT").Value & "' " & _
                    " AND MS_PHIEU_BAO_TRI = N'" & MS_PHIEU_BAO_TRI & "' AND MS_BO_PHAN = N'" & MS_BO_PHAN & "' AND MS_CV = " & MS_CV

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub TimPT()
        Try
            Dim sDK As String
            sDK = ""
            Dim dtTmp As New DataTable
            If TabControl1.SelectedIndex = 0 Then
                Try
                    dtTmp = CType(grdDanhsachphutungcon.DataSource, DataTable)
                    If txtTKiem.Text = "" Then
                        sDK = ""
                    Else
                        'Mã, tên, tên khác, quy cách, part no. ms_pt_cty, don vi tính, loại vật tư).
                        sDK = ""
                        For i As Integer = 1 To dtTmp.Columns.Count - 1
                            If dtTmp.Columns(i).DataType.Name.ToString() = "String" Then
                                sDK += dtTmp.Columns(i).ColumnName + " like '%" + txtTKiem.Text + "%' OR "
                            End If
                        Next
                    End If


                    sDK = sDK.Substring(0, sDK.Length() - 3)
                    dtTmp.DefaultView.RowFilter = sDK
                    dtTmp = dtTmp.DefaultView.ToTable()

                    dtTmp = New DataTable
                    dtTmp = CType(dgrDanhSachVatTuPhuTung.DataSource, DataTable)
                    dtTmp.DefaultView.RowFilter = sDK
                    dtTmp = dtTmp.DefaultView.ToTable()
                Catch ex As Exception

                End Try

            End If
            If TabControl1.SelectedIndex = 1 Then
                Try
                    dtTmp = New DataTable
                    dtTmp = CType(grdDanhsachphutungcha.DataSource, DataTable)
                    dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtTKiem.Text + "%' OR TEN_PT like '%" + txtTKiem.Text + "%'"
                    dtTmp = dtTmp.DefaultView.ToTable()
                Catch ex As Exception

                End Try
            End If
            If TabControl1.SelectedIndex = 2 Then
                Try
                    dtTmp = New DataTable
                    dtTmp = CType(grdDMVT.DataSource, DataTable)

                    If txtTKiem.Text = "" Then
                        sDK = ""
                        dtTmp.DefaultView.RowFilter = " MS_BO_PHAN = '" & MS_BO_PHAN & "' AND  MS_CV = " & MS_CV
                    Else
                        'sDK = " MS_PT like '%" + txtTKiem.Text + "%' OR TEN_PT like '%" + txtTKiem.Text + "%' OR TEN_PT_VIET like '%" + txtTKiem.Text + "%' OR QUY_CACH like '%" + txtTKiem.Text + "%' OR MS_PT_NCC like '%" + txtTKiem.Text + "%'"

                        'Mã, tên, tên khác, quy cách, part no. ms_pt_cty, don vi tính, loại vật tư).
                        sDK = ""
                        For i As Integer = 1 To dtTmp.Columns.Count - 4
                            If dtTmp.Columns(i).DataType.Name.ToString() = "String" Then
                                sDK += dtTmp.Columns(i).ColumnName + " like '%" + txtTKiem.Text + "%' OR "
                            End If
                        Next
                        sDK = sDK.Substring(0, sDK.Length() - 3)
                        dtTmp.DefaultView.RowFilter = " (MS_BO_PHAN = '" & MS_BO_PHAN & "' AND  MS_CV = " & MS_CV & ") AND (" & sDK & ") "
                    End If


                    dtTmp = dtTmp.DefaultView.ToTable()
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception


        End Try
    End Sub
    Private Sub grdDMVT_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDMVT.CellEndEdit
        Dim str As String = ""
        If grdDMVT.Columns(e.ColumnIndex).Name = "CHON" Then
            If grdDMVT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdDMVT.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    objRead.Close()
                    Exit Sub
                End While
                objRead.Close()
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & _
                    Commons.Modules.UserName, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, _
                    grdDMVT.Rows(e.RowIndex).Cells("MS_PT").Value, grdDMVT.Rows(e.RowIndex).Cells("TEN_PT").Value, _
                     grdDMVT.Rows(e.RowIndex).Cells("SL_KH").Value, grdDMVT.Rows(e.RowIndex).Cells("MS_PT_CHA").Value, _
                     grdDMVT.Rows(e.RowIndex).Cells("MS_PT_NCC").Value, grdDMVT.Rows(e.RowIndex).Cells("MS_PT_CTY").Value, 0, 1)


                grdDanhsachphutungcon.ReadOnly = True
            ElseIf Not grdDMVT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & MS_CV & "' AND MS_BO_PHAN ='" & MS_BO_PHAN & "' AND MS_PT ='" & grdDMVT.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
            'LoadVatTuPhuTung()
        End If
    End Sub

    Private Sub txtTKiem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTKiem.TextChanged
        TimPT()
    End Sub

    Private Sub grdDMVT_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDMVT.CellBeginEdit
        If grdDMVT.Columns(e.ColumnIndex).Name = "CHON" Then
            If KiemPTTonTaiNAV(grdDMVT.Rows(e.RowIndex).Cells("MS_PT").Value) = True Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub grdDanhsachphutungcon_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphutungcon.CellContentClick
        'sClick = "CellContentClick"
        'grdDanhsachphutungcon.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'sClick = ""
    End Sub

    Private Sub grdDanhsachphutungcon_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphutungcon.CellValueChanged
        If sClick <> "CellContentClick" Then Exit Sub
        If Commons.Modules.SQLString = "0KIEM" Then Exit Sub
        If e.RowIndex = -1 Then Exit Sub

        If grdDanhsachphutungcon.Columns(e.ColumnIndex).Name <> "chkChon" Then Exit Sub

        If (grdDanhsachphutungcon.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "0") Then
            If KiemPTTonTaiNAV(grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value) = True Then
                Commons.Modules.SQLString = "0RE"
                grdDanhsachphutungcon.Rows(e.RowIndex).Cells("chkChon").Value = True
                Try

                    Dim Str As String
                    Str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY) " & _
                              "VALUES(N'" & MS_PHIEU_BAO_TRI & "'," & MS_CV & ",'" & MS_BO_PHAN & "','" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT").Value & "',N'" & _
                               grdDanhsachphutungcon.Rows(e.RowIndex).Cells("TEN_PT").Value & "'," & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("SL_KH").Value & ",'Y'," & _
                               IIf(grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_NCC").Value.ToString = "", "NULL", "'" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_NCC").Value & "'") & _
                               ",'" & grdDanhsachphutungcon.Rows(e.RowIndex).Cells("MS_PT_CTY").Value & "')"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                Catch ex As Exception

                End Try
                grdDanhsachphutungcon.RefreshEdit()
                Commons.Modules.SQLString = ""
                Exit Sub
            End If
        End If




    End Sub

    Private Sub dgrDanhSachVatTuPhuTung_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachVatTuPhuTung.CellContentClick

    End Sub

    Private Sub dgrDanhSachVatTuPhuTung_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachVatTuPhuTung.CellValueChanged

    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class