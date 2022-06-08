Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports DevExpress.XtraEditors

Public Class FrmChonPTChoKHTT
    Dim dtTableTam, dtTableOne As DataTable
    Dim sql As String
    Dim _sMS_MAY, _sMS_BO_PHAN As String
    Dim _sHANG_MUC_ID, _sMS_CV, _sIndex As Integer
    Dim _formName As String = "frmKehoachtongthe_odd"
    Private txtKeyPress As TextBox
    Dim _KHType As Integer = -1
    Dim _KHNam As Integer = -1
    Dim _KHThang As Integer = -1

    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property

    Public Property HANG_MUC_ID() As Integer
        Get
            Return _sHANG_MUC_ID
        End Get
        Set(ByVal value As Integer)
            _sHANG_MUC_ID = value
        End Set
    End Property

    Public Property INDEX() As Integer
        Get
            Return _sIndex
        End Get
        Set(ByVal value As Integer)
            _sIndex = value
        End Set
    End Property

    Public Property MS_BO_PHAN() As String
        Get
            Return _sMS_BO_PHAN
        End Get
        Set(ByVal value As String)
            _sMS_BO_PHAN = value
        End Set
    End Property

    Public Property MS_CV() As Integer
        Get
            Return _sMS_CV
        End Get
        Set(ByVal value As Integer)
            _sMS_CV = value
        End Set
    End Property

    Public Property FormKHBTName() As String
        Get
            Return _formName
        End Get
        Set(ByVal value As String)
            _formName = value
        End Set
    End Property

    Public Property KH_TYPE() As Integer
        Get
            Return _KHType
        End Get
        Set(ByVal value As Integer)
            _KHType = value
        End Set
    End Property
    Public Property KH_NAM() As Integer
        Get
            Return _KHNam
        End Get
        Set(ByVal value As Integer)
            _KHNam = value
        End Set
    End Property
    Public Property KH_THANG() As Integer
        Get
            Return _KHThang
        End Get
        Set(ByVal value As Integer)
            _KHThang = value
        End Set
    End Property



    Private Sub FrmChonPTChoKHTT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Commons.Modules.SQLString = "DROP TABLE dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If _formName = "frmKehoachtongtheNew" Then
                Commons.Modules.SQLString = "INSERT INTO KHTCVPT_TMP" & Commons.Modules.UserName & " SELECT '" & _KHType & "' as KH_TYPE , '" & _KHNam & "' as KH_NAM , '" & _KHThang & "' as KH_THANG , NULL AS KH_TUAN,  A.MS_MAY," & _sHANG_MUC_ID & _
             ",A.MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,NULL,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " & _
             " FROM dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " A " & _
             " WHERE MS_PT NOT IN (SELECT DISTINCT MS_PT FROM KHTCVPT_TMP" & Commons.Modules.UserName & " B  WHERE A.MS_MAY = B.MS_MAY " & _
             " AND HANG_MUC_ID = " & _sHANG_MUC_ID & " AND A.MS_BO_PHAN = B.MS_BO_PHAN AND A.MS_CV = B.MS_CV  ) " & _
             " AND MS_MAY = '" & _sMS_MAY & "' "
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Else
                'AND SO_LUONG > 0 
                Commons.Modules.SQLString = "INSERT INTO KHTCVPT_TMP" & Commons.Modules.UserName & " SELECT A.MS_MAY," & _sHANG_MUC_ID & _
                    ",A.MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,NULL,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " & _
                    " FROM dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " A " & _
                    " WHERE MS_PT NOT IN (SELECT DISTINCT MS_PT FROM KHTCVPT_TMP" & Commons.Modules.UserName & " B  WHERE A.MS_MAY = B.MS_MAY " & _
                    " AND HANG_MUC_ID = " & _sHANG_MUC_ID & " AND A.MS_BO_PHAN = B.MS_BO_PHAN AND A.MS_CV = B.MS_CV  ) " & _
                    " AND MS_MAY = '" & _sMS_MAY & "' "
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            End If

            Commons.Modules.SQLString = " UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET KHTCVPT_TMP" & Commons.Modules.UserName & ".SO_LUONG = A.SO_LUONG  " & _
                " FROM PT_KHTT_TMP" & Commons.Modules.UserName & " A INNER JOIN KHTCVPT_TMP" & Commons.Modules.UserName & " B ON A.MS_BO_PHAN = B.MS_BO_PHAN  " & _
                " AND A.MS_CV = B.MS_CV AND A.MS_MAY = B.MS_MAY AND A.MS_PT = B.MS_PT " & _
                " WHERE HANG_MUC_ID = " & _sHANG_MUC_ID & " AND A.MS_MAY = '" & _sMS_MAY & "' "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = " DELETE A FROM KHTCVPT_TMP" & Commons.Modules.UserName & " A WHERE MS_PT NOT IN ( " & _
                " SELECT DISTINCT MS_PT FROM PT_KHTT_TMP" & Commons.Modules.UserName & " B   " & _
                " WHERE A.MS_MAY = B.MS_MAY AND HANG_MUC_ID = " & _sHANG_MUC_ID & " AND A.MS_BO_PHAN = B.MS_BO_PHAN AND A.MS_CV = B.MS_CV  ) " & _
                " AND MS_MAY = '" & _sMS_MAY & "'  AND HANG_MUC_ID = " & _sHANG_MUC_ID & " "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Catch ex As Exception

        End Try


        GrdDSCV.DataSource = DBNull.Value
        grdDSPT.DataSource = DBNull.Value

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub LoadDSVTPTAll()
        Try
            If MS_CV_CHON = GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString() And MS_BO_PHAN_CHON = GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString() Then
                Exit Sub
            Else
                MS_CV_CHON = GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString()
                MS_BO_PHAN_CHON = GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString()
            End If


            Dim sBTVT As String = "VT_" & Commons.Modules.UserName
            Dim sBTPT As String = "PT_" & Commons.Modules.UserName
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhuTungTheoMayBoPhan", _
                Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value, _
                GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value))
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTPT, dtTmp, "")

            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVatTuTheoMayBoPhan", _
                Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value, _
                GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value))
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVT, dtTmp, "")


            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_DATA_LIST_VTPT_ALL_FOR_KHBT", Commons.Modules.UserName, sBTVT, sBTPT))
            dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("MS_PT")}


            Commons.Modules.ObjSystems.XoaTable(sBTVT)
            Commons.Modules.ObjSystems.XoaTable(sBTPT)

            grdVTPT.ReadOnly = False
            dtTmp.Columns("chkChon").ReadOnly = False
            dtTmp.Columns("SL_KH").ReadOnly = False
            Me.grdVTPT.DataSource = dtTmp

            Dim Str As String = "SELECT DISTINCT MS_CV,MS_BO_PHAN,MS_PT, SO_LUONG FROM PT_KHTT_TMP" & Commons.Modules.UserName & _
            " WHERE  MS_CV='" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value & "' AND MS_BO_PHAN='" & _
            GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "' AND ISNULL(MS_PT ,'') <> '' "

            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))
            Dim dtTable As New DataTable
            dtTable = CType(grdVTPT.DataSource, DataTable)
            For Each row As DataRow In dtTmp.Rows
                Dim index As Integer = dtTable.Rows.IndexOf(dtTable.Rows.Find(row("MS_PT").ToString()))
                If index >= 0 Then
                    dtTable.Rows(index)("chkChon") = True
                    dtTable.Rows(index)("SL_KH") = row("SO_LUONG").ToString()
                End If
            Next


        Catch ex As Exception
        End Try
    End Sub

    Private Sub CboLoaiVT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowVTPT()
    End Sub

    Private Sub RefeshLanguage()
        Try

            With GrdDSCV
                .Columns("clCVMO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmChonPTChoKHTT", "MO_TA_CV", Commons.Modules.TypeLanguage)
                .Columns("clCVTEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmChonPTChoKHTT", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            End With

            grdDSVT.Columns("clVTTEN_LOAI_VT_TV").Visible = False
            grdDSVT.Columns("clVTMS_PT_CHA").Visible = False
            grdDSVT.Columns("clVTTEN_PT").ReadOnly = True
            grdDSVT.Columns("clVTTEN_PT_VIET").ReadOnly = True
            grdDSVT.Columns("clVTMS_PT_NCC").ReadOnly = True
            grdDSVT.Columns("clVTMS_PT_CTY").ReadOnly = True
            grdDSVT.Columns("clVTTEN_1").ReadOnly = True
            grdDSVT.Columns("clVTSL_KH").ReadOnly = True
            grdDSVT.Columns("clVTQUY_CACH").ReadOnly = True

            grdDSVT.Columns("clVTSL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdDSVT.Columns("clVTchkChon").Width = 50
            With grdDSVT
                .Columns("clVTMS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_VT", Commons.Modules.TypeLanguage)
                .Columns("clVTTEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_VT", Commons.Modules.TypeLanguage)
                .Columns("clVTTEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_PT_VIET", Commons.Modules.TypeLanguage)
                .Columns("clVTMS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_NCC", Commons.Modules.TypeLanguage)
                .Columns("clVTMS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_CTY", Commons.Modules.TypeLanguage)
                .Columns("clVTchkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "chkChon", Commons.Modules.TypeLanguage)
                .Columns("clVTTEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_1", Commons.Modules.TypeLanguage)
                .Columns("clVTSL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "SL_KH", Commons.Modules.TypeLanguage)
                .Columns("clVTQUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "QUY_CACH", Commons.Modules.TypeLanguage)
            End With

            Try
                Me.grdDSVT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDSVT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try

            grdDSPT.Columns("clPTTEN_LOAI_VT_TV").Visible = False
            grdDSPT.Columns("clPTMS_PT_CHA").Visible = False
            grdDSPT.Columns("clPTTEN_PT").ReadOnly = True
            grdDSPT.Columns("clPTTEN_PT_VIET").ReadOnly = True
            grdDSPT.Columns("clPTMS_PT_NCC").ReadOnly = True
            grdDSPT.Columns("clPTMS_PT_CTY").ReadOnly = True
            grdDSPT.Columns("clPTTEN_1").ReadOnly = True
            grdDSPT.Columns("clPTSL_KH").ReadOnly = True
            grdDSPT.Columns("clPTQUY_CACH").ReadOnly = True

            grdDSPT.Columns("clPTSL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdDSPT.Columns("clPTchkChon").Width = 50
            With grdDSPT
                .Columns("clPTMS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_VT", Commons.Modules.TypeLanguage)
                .Columns("clPTTEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_VT", Commons.Modules.TypeLanguage)
                .Columns("clPTTEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_PT_VIET", Commons.Modules.TypeLanguage)
                .Columns("clPTMS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_NCC", Commons.Modules.TypeLanguage)
                .Columns("clPTMS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_CTY", Commons.Modules.TypeLanguage)
                .Columns("clPTchkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "chkChon", Commons.Modules.TypeLanguage)
                .Columns("clPTTEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_1", Commons.Modules.TypeLanguage)
                .Columns("clPTSL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "SL_KH", Commons.Modules.TypeLanguage)
                .Columns("clPTQUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "QUY_CACH", Commons.Modules.TypeLanguage)
            End With
            Try
                Me.grdDSPT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDSPT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try

            Try
                grdVTPT.Columns("clVTPTTEN_LOAI_VT_TV").Visible = False
                grdVTPT.Columns("clVTPTMS_PT_CHA").Visible = False
                grdVTPT.Columns("clVTPTTEN_PT").ReadOnly = True
                'grdVTPT.Columns("TEN_PT_VIET").ReadOnly = True
                grdVTPT.Columns("clVTPTMS_PT_NCC").ReadOnly = True
                'grdVTPT.Columns("MS_PT_CTY").ReadOnly = True
                'grdVTPT.Columns("TEN_1").ReadOnly = True
                grdVTPT.Columns("clVTPTQUY_CACH").ReadOnly = True
                grdVTPT.Columns("clVTPTSL_KH").Visible = False

                grdVTPT.Columns("clVTPTSL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdVTPT.Columns("clVTPTchkChon").Width = 100

                With grdVTPT
                    .Columns("clVTPTMS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_VT", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTTEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_VT", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTTEN_PT").Width = 300
                    .Columns("clVTPTMS_PT").Width = 150
                    '.Columns("TEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_PT_VIET", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTMS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_NCC", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTMS_PT_NCC").Width = 150
                    '.Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_CTY", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTchkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "chkChon", Commons.Modules.TypeLanguage)
                    '.Columns("TEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_1", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTSL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "SL_KH", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTQUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "QUY_CACH", Commons.Modules.TypeLanguage)
                    .Columns("clVTPTQUY_CACH").Width = 260


                    .Columns("TEN_PT_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_PT_VIET", Commons.Modules.TypeLanguage)
                    .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "MS_PT_CTY", Commons.Modules.TypeLanguage)
                    .Columns("TEN_DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPhuTungcho_PBT", "TEN_DVT", Commons.Modules.TypeLanguage)
                    .Columns("TEN_PT_VIET").Width = 260

                End With
                Try
                    Me.grdVTPT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                    Me.grdVTPT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
                Catch ex As Exception
                End Try
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString())
            End Try
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
        End Try
    End Sub

    Sub ShowVTPT()
        Try
            If GrdDSCV.RowCount = 0 Then Exit Sub

            Dim dtTable As New DataTable
            Dim sBTVT As String = "VT_" & Commons.Modules.UserName
            Dim sBTPT As String = "PT_" & Commons.Modules.UserName

            Commons.Modules.ObjSystems.XoaTable(sBTVT)
            Commons.Modules.ObjSystems.XoaTable(sBTPT)

            'Try
            '    grdDSPT.Columns.Clear()
            'Catch ex As Exception

            'End Try


            Dim dtTmp As New DataTable
            'grdDSPT.Columns.Clear()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhuTungTheoMayBoPhan", _
                Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value, _
                GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value))
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTPT, dtTmp, "")
            grdDSPT.AutoGenerateColumns = False
            dtTmp.Columns("chkChon").ReadOnly = False
            Me.grdDSPT.DataSource = dtTmp

            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVatTuTheoMayBoPhan", _
                Commons.Modules.TypeLanguage, Commons.Modules.UserName, MS_MAY, GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value, _
                GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value))

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVT, dtTmp, "")
            dtTmp.Columns("chkChon").ReadOnly = False
            If GrdDSCV.RowCount = 0 Then Exit Sub

            If FormKHBTName = "frmKehoachtongtheNew" Then
                If frmKehoachtongtheNew.gvCVTT.RowCount = 0 Then Exit Sub
            Else
                If frmKehoachtongthe_odd.gvCVTT.RowCount = 0 Then Exit Sub
            End If


            Dim Str As String = "SELECT DISTINCT MS_CV,MS_BO_PHAN,MS_PT, SO_LUONG FROM PT_KHTT_TMP" & Commons.Modules.UserName & _
            " WHERE  MS_CV='" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value & "' AND MS_BO_PHAN='" & _
            GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "' AND ISNULL(MS_PT ,'') <> '' "

            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))

            For Each row As DataRow In dtTmp.Rows
                For Each rowPT As DataGridViewRow In grdDSPT.Rows
                    If row("MS_PT").ToString() = rowPT.Cells("clPTMS_PT").Value.ToString() Then
                        rowPT.Cells("clPTchkChon").Value = True
                        'Dim chk As DataGridViewCheckBoxCell
                        'chk = rowPT.Cells(0)
                        'chk.Selected = True
                        GoTo 1
                    End If
                Next
                For Each rowVT As DataGridViewRow In grdDSVT.Rows
                    If row("MS_PT").ToString() = rowVT.Cells("clVTMS_PT").Value.ToString() Then
                        rowVT.Cells("clVTchkChon").Value = True
                        GoTo 1
                    End If
                Next
1:
                For Each rowPTVT As DataGridViewRow In grdVTPT.Rows
                    If row("MS_PT").ToString() = rowPTVT.Cells("clVTPTMS_PT").Value.ToString() Then
                        rowPTVT.Cells("clVTPTchkChon").Value = True
                        rowPTVT.Cells("clVTPTSL_KH").Value = row("SO_LUONG").ToString()
                    End If
                Next

            Next

            'RefeshLanguage()
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private MS_CV_CHON As String = ""
    Private MS_BO_PHAN_CHON As String = ""

    Private Sub GrdDSCV_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try

            If tabDMVT.SelectedTabPage.Name = "tabVTDM" Then
                If MS_CV_CHON <> GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString() Or MS_BO_PHAN_CHON <> GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString() Then
                    LoadDSVTPTAll()
                End If
            Else
                ShowVTPT()
            End If
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdDSPT_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSPT.CellEndEdit
        Try

            If e.ColumnIndex = 0 Then
                If Not IsNumeric(Me.grdDSPT.CurrentRow.Cells(4).Value) Then
                    MsgBox("Bạn nhập sai kiểu dữ liệu ")
                    grdDSPT.Rows(e.RowIndex).Cells(5).Value = 0
                    Exit Sub
                End If
                If grdDSPT.Rows(e.RowIndex).Cells(4).Value <= 0 Then
                    grdDSPT.Rows(e.RowIndex).Cells(4).Value = 0
                    Exit Sub
                End If
                If grdDSPT.Rows(e.RowIndex).Cells(0).Value = True Then
                    GoTo 1
                Else
                    Commons.Modules.SQLString = " DELETE FROM PT_KHTT_TMP" & Commons.Modules.UserName & _
                        " WHERE MS_MAY = '" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "' " & _
                        " AND MS_BO_PHAN = '" & GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString & "' " & _
                        " AND  MS_CV = '" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString & "' " & _
                        " AND MS_PT = '" & grdDSPT.CurrentRow.Cells("clPTMS_PT").Value & "' "
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If

                Exit Sub
            End If

            If e.ColumnIndex = 4 Then
                If grdDSPT.Rows(e.RowIndex).Cells(0).Value = 0 Then grdDSPT.Rows(e.RowIndex).Cells(0).Value = 1
1:
                Try
                    Commons.Modules.SQLString = "INSERT INTO PT_KHTT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG) VALUES(N'" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "','" & grdDSPT.CurrentRow.Cells("clPTMS_PT").Value & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value & "'," & grdDSPT.CurrentRow.Cells("clPTSL_KH").Value & ")"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Catch EX As Exception
                    Commons.Modules.SQLString = ""
                    Commons.Modules.SQLString = "UPDATE dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & _
                        grdDSPT.CurrentRow.Cells("clsPTSL_KH").Value & " WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdDSPT.CurrentRow.Cells("clPTMS_BO_PHAN").Value & "' AND MS_PT='" & grdDSPT.CurrentRow.Cells("clPTMS_PT").Value & "' AND MS_CV=" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End Try

            End If
        Catch ex As Exception
            'XtraMessageBox.Show(ex.ToString)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, frmKehoachtongthe_odd.Name, "DuLieuSai", _
                    Commons.Modules.TypeLanguage) + vbCrLf + ex.ToString)
        End Try

    End Sub

    Private Sub grdDSPT_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDSPT.EditingControlShowing, grdDSVT.EditingControlShowing
        Try
            'If Me.grdDSPT.CurrentCellAddress.X = 4 Then
            If grdDSPT.CurrentCell.OwningColumn.Name = "SO_LUONG" Then
                txtKeyPress = e.Control
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
                AddHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            Else
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDSVT_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSVT.CellEndEdit
        Try
            If e.ColumnIndex = 0 Then
                If Not IsNumeric(Me.grdDSVT.CurrentRow.Cells(4).Value) Then
                    MsgBox("Bạn nhập sai kiểu dữ liệu ")
                    grdDSVT.Rows(e.RowIndex).Cells(5).Value = 0
                    Exit Sub
                End If
                If grdDSVT.Rows(e.RowIndex).Cells(4).Value <= 0 Then
                    grdDSVT.Rows(e.RowIndex).Cells(4).Value = 0
                    Exit Sub
                End If
                If grdDSVT.Rows(e.RowIndex).Cells(0).Value = True Then
                    GoTo 1
                Else
                    Commons.Modules.SQLString = " DELETE FROM PT_KHTT_TMP" & Commons.Modules.UserName & _
                        " WHERE MS_MAY = '" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "' " & _
                        " AND MS_BO_PHAN = '" & GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString & "' " & _
                        " AND  MS_CV = '" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString & "' " & _
                        " AND MS_PT = '" & grdDSVT.CurrentRow.Cells("clVTMS_PT").Value & "' "
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If

                Exit Sub
            End If

            If e.ColumnIndex = 4 Then
                If grdDSVT.Rows(e.RowIndex).Cells(0).Value = 0 Then grdDSVT.Rows(e.RowIndex).Cells(0).Value = 1
1:
                Try
                    Commons.Modules.SQLString = "INSERT INTO PT_KHTT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG) VALUES(N'" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "','" & grdDSVT.CurrentRow.Cells("clVTMS_PT").Value & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value & "'," & grdDSVT.CurrentRow.Cells("clVTSL_KH").Value & ")"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Catch EX As Exception
                    Commons.Modules.SQLString = ""
                    Commons.Modules.SQLString = "UPDATE dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & _
                        grdDSVT.CurrentRow.Cells("clVTSL_KH").Value & " WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "' AND MS_PT='" & grdDSVT.CurrentRow.Cells("clVTMS_PT").Value & "' AND MS_CV=" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End Try

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub FrmChonPTChoKHTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            RemoveHandler GrdDSCV.SelectionChanged, AddressOf GrdDSCV_SelectionChanged
            RemoveHandler txtTimPT.TextChanged, AddressOf txtTimPT_TextChanged
            Dim i As Integer
            'Try
            '    GrdDSCV.Columns.Clear()
            '    GrdDSCV.DataSource = System.DBNull.Value
            'Catch ex As Exception
            'End Try

            'Try
            '    grdDSPT.Columns.Clear()
            '    grdDSPT.DataSource = System.DBNull.Value
            'Catch ex As Exception
            'End Try
            Commons.Modules.ObjSystems.XoaTable("dbo.PT_KHTT_TMP" & Commons.Modules.UserName)

            Commons.Modules.SQLString = "CREATE TABLE dbo.PT_KHTT_TMP" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(50),MS_BO_PHAN NVARCHAR(50), " & _
                    " MS_PT NVARCHAR(50),MS_CV INT,SO_LUONG FLOAT , DON_GIA_KH numeric(18, 2) NULL, TIEN_TE_KH numeric(18, 2) NULL, " & _
                    " TY_GIA_KH numeric(18, 2) NULL, TY_GIA_USD_KH numeric(18, 2) NULL, DON_GIA_CUOI numeric(18, 2) NULL, NGAY_LAY_DG_KH datetime NULL )"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            i = 0

            If FormKHBTName = "frmKehoachtongtheNew" Then
                Commons.Modules.SQLString = "INSERT INTO PT_KHTT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH ) " & _
                        " SELECT MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " & _
                        " FROM KHTCVPT_TMP" & Commons.Modules.UserName & _
                        " WHERE HANG_MUC_ID = " & frmKehoachtongtheNew.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & _
                        " AND MS_MAY = '" & frmKehoachtongtheNew.gvKHTT.GetFocusedDataRow()("MS_MAY") & " ' "
            Else
                Commons.Modules.SQLString = "INSERT INTO PT_KHTT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH ) " & _
                        " SELECT MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG,DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " & _
                        " FROM KHTCVPT_TMP" & Commons.Modules.UserName & _
                        " WHERE HANG_MUC_ID = " & frmKehoachtongthe_odd.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & _
                        " AND MS_MAY = '" & frmKehoachtongthe_odd.gvKHTT.GetFocusedDataRow()("MS_MAY") & " ' "
            End If


            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Dim dtTable As New DataTable
            Dim dtTmp As New DataTable
            Try
                If FormKHBTName = "frmKehoachtongtheNew" Then
                    dtTmp = CType(frmKehoachtongtheNew.gdCVTT.DataSource, DataTable)

                Else
                    dtTmp = CType(frmKehoachtongthe_odd.gdCVTT.DataSource, DataTable)

                End If

                dtTable = dtTmp.DefaultView.ToTable(False, "MS_MAY", "MS_CV", "MO_TA_CV", "MS_BO_PHAN", "TEN_BO_PHAN")
            Catch ex As Exception

            End Try
            GrdDSCV.AutoGenerateColumns = False
            'GrdDSCV.Columns.Clear()
            'GrdDSCV.DataSource = System.DBNull.Value
            GrdDSCV.DataSource = dtTable
            'GrdDSCV.Columns("MS_CV").Visible = False
            'GrdDSCV.Columns("MS_MAY").Visible = False
            'GrdDSCV.Columns("MS_BO_PHAN").Visible = False
            'Try
            '    Me.GrdDSCV.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            '    Me.GrdDSCV.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            'Catch ex As Exception
            'End Try


            tabDMVT.SelectedTabPage = tabDMVT.TabPages(0)

            If tabDMVT.SelectedTabPage.Name = "tabVTDM" And grdVTPT.Rows.Count <= 0 Then
                LoadDSVTPTAll()
            End If

            Commons.Modules.ObjSystems.DinhDang()
            'Commons.Modules.ObjSystems.ThayDoiNN(Me)
            RefeshLanguage()
            tabDMVT.TabPages(0).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, frmKehoachtongthe_odd.Name, tabDMVT.TabPages(0).Name, Commons.Modules.TypeLanguage)
            tabDMVT.TabPages(1).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, frmKehoachtongthe_odd.Name, tabDMVT.TabPages(1).Name, Commons.Modules.TypeLanguage)

            ' AddHandler GrdDSCV.SelectionChanged, AddressOf GrdDSCV_SelectionChanged
            'grdVTPT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'grdLoaithietbi.Columns("TEN_LOAI_MAY").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub FrmChonPTChoKHTT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            AddHandler GrdDSCV.SelectionChanged, AddressOf GrdDSCV_SelectionChanged
            AddHandler txtTimPT.TextChanged, AddressOf txtTimPT_TextChanged
            Dim i As Integer

            If FormKHBTName = "frmKehoachtongtheNew" Then
                i = frmKehoachtongtheNew.gvCVTT.FocusedRowHandle
            Else
                i = frmKehoachtongthe_odd.gvCVTT.FocusedRowHandle
            End If
            GrdDSCV.Focus()
            GrdDSCV.CurrentCell = GrdDSCV.Rows(i).Cells("clCVMO_TA_CV")
            GrdDSCV.Rows(i).Selected = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdVTPT_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVTPT.CellEndEdit
        Try

            If e.ColumnIndex = 0 Then

                If grdVTPT.Rows(e.RowIndex).Cells(0).Value = True Then
                    GoTo 1
                Else
                    Commons.Modules.SQLString = " DELETE FROM PT_KHTT_TMP" & Commons.Modules.UserName & _
                        " WHERE MS_MAY = '" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "' " & _
                        " AND MS_BO_PHAN = '" & GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString & "' " & _
                        " AND  MS_CV = '" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString & "' " & _
                        " AND MS_PT = '" & grdVTPT.CurrentRow.Cells("clVTPTMS_PT").Value & "' "
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If

                Exit Sub
            End If

            If e.ColumnIndex = 4 Then
                If grdVTPT.Rows(e.RowIndex).Cells(0).Value = 0 Then grdVTPT.Rows(e.RowIndex).Cells(0).Value = 1
1:
                Try
                    Commons.Modules.SQLString = "INSERT INTO PT_KHTT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY, MS_BO_PHAN, MS_PT, MS_CV, SO_LUONG) VALUES(N'" & GrdDSCV.CurrentRow.Cells("clCVMS_MAY").Value.ToString & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value & "','" & grdVTPT.CurrentRow.Cells("clVTPTMS_PT").Value & "','" & _
                        GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value & "'," & grdVTPT.CurrentRow.Cells("clVTPTSL_KH").Value & ")"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Catch EX As Exception
                    Commons.Modules.SQLString = ""
                    Commons.Modules.SQLString = "UPDATE dbo.PT_KHTT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & _
                        grdVTPT.CurrentRow.Cells("clVTPTSL_KH").Value & " WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdVTPT.CurrentRow.Cells("clVTPTMS_BO_PHAN").Value & "' AND MS_PT='" & grdVTPT.CurrentRow.Cells("clVTPTMS_PT").Value & "' AND MS_CV=" & GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End Try

            End If
        Catch ex As Exception
            'XtraMessageBox.Show(ex.ToString)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, frmKehoachtongthe_odd.Name, "DuLieuSai", _
                    Commons.Modules.TypeLanguage) + vbCrLf + ex.ToString)

        End Try
    End Sub

    Private Sub tabDMVT_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabDMVT.SelectedPageChanged
        If tabDMVT.SelectedTabPage.Name = "tabVTDM" Then
            If MS_CV_CHON <> GrdDSCV.CurrentRow.Cells("clCVMS_CV").Value.ToString() Or MS_BO_PHAN_CHON <> GrdDSCV.CurrentRow.Cells("clCVMS_BO_PHAN").Value.ToString() Then
                LoadDSVTPTAll()
            End If
        End If
    End Sub

    Private Sub txtTimPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimPT.TextChanged
        Dim dtTmp As New DataTable
        Try

            dtTmp = CType(grdDSVT.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtTimPT.Text + "%' OR TEN_PT like '%" + txtTimPT.Text + "%' OR TEN_PT_VIET like '%" + txtTimPT.Text + "%' OR QUY_CACH like '%" + txtTimPT.Text + "%' OR MS_PT_NCC like '%" + txtTimPT.Text + "%' OR MS_PT_CTY like '%" + txtTimPT.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception

        End Try
        Try
            dtTmp = New DataTable
            dtTmp = CType(grdDSPT.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtTimPT.Text + "%' OR TEN_PT like '%" + txtTimPT.Text + "%' OR TEN_PT_VIET like '%" + txtTimPT.Text + "%' OR QUY_CACH like '%" + txtTimPT.Text + "%' OR MS_PT_NCC like '%" + txtTimPT.Text + "%' OR MS_PT_CTY like '%" + txtTimPT.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception

        End Try

        Try
            dtTmp = New DataTable
            dtTmp = CType(grdVTPT.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtTimPT.Text + "%' OR TEN_PT like '%" + txtTimPT.Text + "%' OR TEN_PT_VIET like '%" + txtTimPT.Text + "%' OR QUY_CACH like '%" + txtTimPT.Text + "%' OR MS_PT_NCC like '%" + txtTimPT.Text + "%' OR MS_PT_CTY like '%" + txtTimPT.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception

        End Try
    End Sub

End Class