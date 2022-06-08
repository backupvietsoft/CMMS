Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin

Public Class FrmChonPTchoBTPN
    Dim _sMS_MAY As String
    Dim _sMS_LOAI_BT As Integer
    Dim _sMS_CV As Integer
    Dim _sMS_LOAI_TB As String
    Dim _sMS_BO_PHAN As String


    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property

    Public Property MS_LOAI_BT() As Integer
        Get
            Return _sMS_LOAI_BT
        End Get
        Set(ByVal value As Integer)
            _sMS_LOAI_BT = value
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

    Public Property MS_LOAI_TB() As String
        Get
            Return _sMS_LOAI_TB
        End Get
        Set(ByVal value As String)
            _sMS_LOAI_TB = value
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

    Private Sub FrmChonPTchoBTPN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadLoaiPT()
            LoadLoaiVT()
            BindData()
            BindData_VatTu()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)

        Catch ex As Exception

        End Try

    End Sub

    Sub BindData()
        Try

            If cboLOAI_VT.Text = "" Then Exit Sub
            If CboLoaiPT.Text = "" Then Exit Sub

            Dim dtTableTam As DataTable = New DataTable()
            dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPTchoBTPN",
                MS_MAY, MS_BO_PHAN, cboLOAI_VT.EditValue, CboLoaiPT.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage))

            dtTableTam = dtTableTam.DefaultView.ToTable(True, "TEN_LOAI_VT", "MS_PT", "TEN_PT", "TEN_PT_VIET", "DVT", "QUY_CACH")
            Dim column As New DataColumn("CHON")
            column.DataType = GetType(Boolean)
            column.DefaultValue = "0"
            dtTableTam.Columns.Add(column)
            column.SetOrdinal(0)


            dtTableTam.Columns("CHON").ReadOnly = False
            dtTableTam.Columns("MS_PT").ReadOnly = True
            dtTableTam.Columns("TEN_PT").ReadOnly = True
            dtTableTam.Columns("TEN_PT_VIET").ReadOnly = True
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPT, grvPT, dtTableTam, True, True, False, True, True, Me.Name)
            grvPT.Columns("CHON").Width = 50

            grvPT.Columns("TEN_LOAI_VT").Visible = False
            grvPT.Columns("DVT").Visible = False
            Call FindCheck(dtTableTam)

            RefeshLanguage()
        Catch ex As Exception

        End Try

    End Sub

    Sub BindData_VatTu()
        Try

            If cboLOAI_VT.EditValue = "-1" Then
                Commons.Modules.SQLString = "SELECT DISTINCT CONVERT(BIT,0) AS CHON," & IIf(Commons.Modules.TypeLanguage = 0,
                    " LOAI_VT.TEN_LOAI_VT_TV", "LOAI_VT.TEN_LOAI_VT_TA") & " AS TEN_LOAI_VT,IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, " &
                    " IC_PHU_TUNG.TEN_PT_VIET,IC_PHU_TUNG.QUY_CACH,IC_PHU_TUNG.SL_DA_DAT_CHUA_MUA AS SO_LUONG, IC_PHU_TUNG.DVT, " &
                    "  dbo.IC_PHU_TUNG.MS_PT_NCC FROM IC_PHU_TUNG INNER JOIN LOAI_VT ON " &
                    " IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON " &
                    " IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT INNER JOIN NHOM_LOAI_PHU_TUNG ON " &
                    " IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = NHOM_LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN USERS ON " &
                    " NHOM_LOAI_PHU_TUNG.GROUP_ID = USERS.GROUP_ID WHERE USERS.USERNAME = '" & Commons.Modules.UserName & "' " &
                    " AND LOAI_VT.VAT_TU=1  AND ACTIVE_PT = 1  ORDER BY MS_PT, TEN_PT "
            Else
                Commons.Modules.SQLString = "SELECT DISTINCT CONVERT(BIT,0) AS CHON," & IIf(Commons.Modules.TypeLanguage = 0, "LOAI_VT.TEN_LOAI_VT_TV",
                    " LOAI_VT.TEN_LOAI_VT_TA") & " AS TEN_LOAI_VT,IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.TEN_PT_VIET," &
                    " IC_PHU_TUNG.QUY_CACH,IC_PHU_TUNG.SL_DA_DAT_CHUA_MUA AS SO_LUONG, IC_PHU_TUNG.DVT,  " &
                    " dbo.IC_PHU_TUNG.MS_PT_NCC FROM IC_PHU_TUNG INNER JOIN LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT " &
                    " INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " &
                    " INNER JOIN NHOM_LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = NHOM_LOAI_PHU_TUNG.MS_LOAI_PT " &
                    " INNER JOIN USERS ON NHOM_LOAI_PHU_TUNG.GROUP_ID = USERS.GROUP_ID " &
                    " WHERE  (USERS.USERNAME = '" & Commons.Modules.UserName & "') AND LOAI_VT.VAT_TU=1 AND " &
                    " IC_PHU_TUNG.MS_LOAI_VT = '" & cboLOAI_VT.EditValue & "'  AND ACTIVE_PT = 1  ORDER BY MS_PT, TEN_PT "
            End If


            Dim dtTableTam As DataTable = New DataTable()
            dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))

            dtTableTam.Columns("CHON").ReadOnly = False
            dtTableTam.Columns("MS_PT").ReadOnly = True
            dtTableTam.Columns("TEN_PT").ReadOnly = True
            dtTableTam.Columns("TEN_PT_VIET").ReadOnly = True


            Commons.Modules.ObjSystems.MLoadXtraGrid(grdVT, grvVT, dtTableTam, True, True, False, True, True, Me.Name)


            Try
                grvVT.Columns("TEN_LOAI_VT").Visible = False
                grvVT.Columns("MS_PT_NCC").Visible = False
                grvVT.Columns("SO_LUONG").Visible = False
                grvVT.Columns("DVT").Visible = False
                grvVT.Columns("CHON").Width = 50
            Catch ex As Exception
            End Try

            Try
                Call FindCheck_VatTu(dtTableTam)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Sub FindCheck(ByVal dtPhutung As DataTable)
        If dtPhutung.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim SqlText As String = "SELECT MS_PT FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & Me.MS_MAY & "'AND MS_LOAI_BT = '" &
            Me.MS_LOAI_BT & "' AND MS_CV = '" & Me.MS_CV & "' AND MS_BO_PHAN = '" & Me.MS_BO_PHAN & "' ORDER BY MS_PT"
        Dim dtCheck As New DataTable
        dtCheck.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        If dtCheck.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim i As Integer
        For i = 0 To dtCheck.Rows.Count - 1
            Dim sMS_PT As String = IIf(IsDBNull(dtCheck.Rows(i)("MS_PT")), String.Empty, dtCheck.Rows(i)("MS_PT").ToString())
            Dim j As Integer
            For j = 0 To grvPT.RowCount - 1
                Dim sMS_PT_SS As String = grvPT.GetRowCellValue(j, "MS_PT").ToString
                If sMS_PT = sMS_PT_SS Then
                    grvPT.DeleteRow(j)
                    Exit For
                End If
            Next j
        Next i
    End Sub

    Sub FindCheck_VatTu(ByVal dtVatTu As DataTable)
        Try

            If dtVatTu.Rows.Count <= 0 Then
                Exit Sub
            End If
            Dim SqlText As String = "SELECT MS_PT FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & Me.MS_MAY & "' 
                    AND MS_LOAI_BT = '" & Me.MS_LOAI_BT & "' AND MS_CV = '" & Me.MS_CV & "' AND MS_BO_PHAN = '" & Me.MS_BO_PHAN & "' ORDER BY MS_PT"
            Dim dtCheck As New DataTable
            dtCheck.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

            If dtCheck.Rows.Count <= 0 Then
                Exit Sub
            End If

            Dim i As Integer
            For i = 0 To dtCheck.Rows.Count - 1
                Dim sMS_PT As String = IIf(IsDBNull(dtCheck.Rows(i)("MS_PT")), String.Empty, dtCheck.Rows(i)("MS_PT").ToString())
                Dim j As Integer
                For j = 0 To grvVT.RowCount - 1
                    Dim sMS_PT_SS As String = grvVT.GetRowCellValue(j, "MS_PT").ToString
                    If sMS_PT = sMS_PT_SS Then
                        grvVT.DeleteRow(j)
                        Exit For
                    End If
                Next j
            Next i
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RefeshLanguage()
        LblChonPT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblChonPT.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.BtnBoChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnBoChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.lblLOAI_VT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblLOAI_VT.Name, commons.Modules.TypeLanguage)
        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, commons.Modules.TypeLanguage)
        GroupBox1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GroupBox1.Name, Commons.Modules.TypeLanguage)
        GroupBox2.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GroupBox2.Name, commons.Modules.TypeLanguage)
    End Sub

    Sub LoadLoaiVT()


        Dim str As String = "SELECT DISTINCT LOAI_VT.MS_LOAI_VT, " & IIf(Commons.Modules.TypeLanguage = 0, "LOAI_VT.TEN_LOAI_VT_TV", IIf(Commons.Modules.TypeLanguage = 1, "LOAI_VT.TEN_LOAI_VT_TA", "LOAI_VT.TEN_LOAI_VT_TH")) & " AS TEN_LOAI_VT " &
                            "FROM USERS INNER JOIN NHOM_LOAI_PHU_TUNG ON USERS.GROUP_ID = NHOM_LOAI_PHU_TUNG.GROUP_ID INNER JOIN " &
                                "LOAI_PHU_TUNG ON NHOM_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN " &
                                "LOAI_VT INNER JOIN IC_PHU_TUNG ON LOAI_VT.MS_LOAI_VT = IC_PHU_TUNG.MS_LOAI_VT INNER JOIN " &
                                "IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT ON " &
                                "LOAI_PHU_TUNG.MS_LOAI_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT " &
                            "WHERE (USERS.USERNAME ='" & Commons.Modules.UserName & "') UNION SELECT '-1' , ' < ALL > ' ORDER BY TEN_LOAI_VT"
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLOAI_VT, dtTmp, "MS_LOAI_VT", "TEN_LOAI_VT", "")


    End Sub

    Sub LoadLoaiPT()
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_PT", Commons.Modules.UserName))
        Dim drRow As DataRow = dtTmp.NewRow
        drRow("MS_LOAI_PT") = -1
        drRow("TEN_LOAI_PT") = " < ALL > "
        dtTmp.Rows.Add(drRow)
        dtTmp.DefaultView.Sort = "TEN_LOAI_PT"
        dtTmp = dtTmp.DefaultView.ToTable()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLoaiPT, dtTmp, "MS_LOAI_PT", "TEN_LOAI_PT", "")
    End Sub

    Function UpdateDataTable() As DataTable
        Dim dtTmp As New DataTable
        Try
            Dim iSL As Integer
            dtTmp = CType(grdPT.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = "CHON = 1"
            dtTmp = dtTmp.DefaultView.ToTable
            Try
                iSL = dtTmp.Rows.Count
            Catch ex As Exception
                iSL = 0
            End Try

            dtTmp = New DataTable
            dtTmp = CType(grdVT.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = "CHON = 1"
            dtTmp = dtTmp.DefaultView.ToTable
            If dtTmp.Rows.Count + iSL = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return Nothing
            End If

            Dim i As Integer
            Dim drNew As DataRow
            Dim dtNew As New DataTable
            Dim str As String = ""
            Dim dtReader_DVT As SqlDataReader

            dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG", MS_MAY, MS_LOAI_BT, MS_CV, Commons.Modules.TypeLanguage, MS_BO_PHAN))
            str = "DELETE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " WHERE MS_LOAI_BT='" & MS_LOAI_BT & "' AND MS_CV='" & MS_CV & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Dim row As Integer = dtNew.Rows.Count
            For i = 0 To dtNew.Rows.Count - 1
                str = "INSERT INTO MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName &
                    "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH,DA_CHON,COUNT_ROW) " &
                    " VALUES(N'" & MS_MAY & "', N'" & MS_LOAI_BT & "', N'" & MS_CV & "', N'" & MS_BO_PHAN & "', N'" & dtNew.Rows(i).Item("TEN_LOAI_VT") & "', " &
                    " N'" & dtNew.Rows(i).Item("MS_PT") & "', N'" & dtNew.Rows(i).Item("TEN_PT") & "', N'" & dtNew.Rows(i).Item("TEN_PT_VIET") & "', " &
                    " '" & dtNew.Rows(i).Item("SO_LUONG") & "', N'" & dtNew.Rows(i).Item("QUY_CACH") & "','" & 1 & "', N'" & row & "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Next
            For i = 0 To grvPT.RowCount - 1
                If Convert.ToBoolean(grvPT.GetRowCellValue(i, "CHON").ToString) = True Then
                    drNew = dtNew.NewRow

                    drNew.Item("TEN_LOAI_VT") = grvPT.GetRowCellValue(i, "TEN_LOAI_VT").ToString
                    drNew.Item("MS_PT") = grvPT.GetRowCellValue(i, "MS_PT").ToString
                    drNew.Item("TEN_PT") = grvPT.GetRowCellValue(i, "TEN_PT").ToString
                    drNew.Item("TEN_PT_VIET") = grvPT.GetRowCellValue(i, "TEN_PT_VIET").ToString
                    drNew.Item("SO_LUONG") = 1
                    drNew.Item("QUY_CACH") = grvPT.GetRowCellValue(i, "QUY_CACH").ToString

                    dtReader_DVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT " &
                        IIf(Commons.Modules.TypeLanguage = 0, "TEN_1", "TEN_2") & " FROM DON_VI_TINH WHERE DVT='" & grvPT.GetRowCellValue(i, "DVT").ToString & "'")
                    While dtReader_DVT.Read
                        drNew.Item("DVT") = dtReader_DVT(0)
                        Exit While
                    End While
                    dtReader_DVT.Close()

                    dtNew.Rows.Add(drNew)
                    str = "INSERT INTO MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH) VALUES(N'" &
                MS_MAY & "', N'" & MS_LOAI_BT & "', N'" & MS_CV & "', N'" & MS_BO_PHAN & "', N'" & drNew.Item("TEN_LOAI_VT") & "', N'" & drNew.Item("MS_PT") & "', N'" & drNew.Item("TEN_PT") & "', N'" & drNew.Item("TEN_PT_VIET") & "','" & drNew.Item("SO_LUONG") & "', N'" & drNew.Item("QUY_CACH") & "')"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            Next

            For i = 0 To grvVT.RowCount - 1
                If Convert.ToBoolean(grvVT.GetRowCellValue(i, "CHON").ToString) = True Then
                    drNew = dtNew.NewRow
                    drNew.Item("TEN_LOAI_VT") = grvVT.GetRowCellValue(i, "TEN_LOAI_VT").ToString
                    drNew.Item("MS_PT") = grvVT.GetRowCellValue(i, "MS_PT").ToString
                    drNew.Item("TEN_PT") = grvVT.GetRowCellValue(i, "TEN_PT").ToString
                    drNew.Item("TEN_PT_VIET") = grvVT.GetRowCellValue(i, "TEN_PT_VIET").ToString
                    drNew.Item("SO_LUONG") = IIf(grvVT.GetRowCellValue(i, "SO_LUONG").ToString = 0, 1, grvVT.GetRowCellValue(i, "SO_LUONG").ToString)
                    drNew.Item("QUY_CACH") = grvVT.GetRowCellValue(i, "QUY_CACH").ToString

                    dtReader_DVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT " &
                        IIf(Commons.Modules.TypeLanguage = 0, "TEN_1", "TEN_2") & " FROM DON_VI_TINH WHERE DVT='" & grvVT.GetRowCellValue(i, "DVT").ToString & "'")
                    While dtReader_DVT.Read
                        drNew.Item("DVT") = dtReader_DVT(0)
                        Exit While
                    End While
                    dtReader_DVT.Close()

                    dtNew.Rows.Add(drNew)
                    str = "INSERT INTO MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH) VALUES(N'" &
                MS_MAY & "', N'" & MS_LOAI_BT & "', N'" & MS_CV & "', N'" & MS_BO_PHAN & "',N'" & drNew.Item("TEN_LOAI_VT") & "', N'" & drNew.Item("MS_PT") & "',N'" & drNew.Item("TEN_PT") & "',N'" & drNew.Item("TEN_PT_VIET") & "','" & drNew.Item("SO_LUONG") & "', N'" & drNew.Item("QUY_CACH") & "')"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            Next

            DialogResult = Windows.Forms.DialogResult.OK
            Return dtNew
            Me.Close()
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click

        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < grvPT.RowCount
            grvPT.GetRowCellValue(i, "chkChon").Value = True
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < grvPT.RowCount
            grvPT.GetRowCellValue(i, "chkChon").Value = False
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Call UpdateDataTable()
    End Sub



    Private Sub txtTimVT_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTimVT.EditValueChanging
        Dim dtTmp As New DataTable
        Dim dtTmp1 As New DataTable
        Try
            dtTmp = DirectCast(grdVT.DataSource, DataTable)
            Dim str As String
            If txtTimVT.Text = "" Then str = "" Else str = " MS_PT_NCC like '%" + txtTimVT.Text + "%' OR QUY_CACH like '%" + txtTimVT.Text + "%' OR  MS_PT like '%" + txtTimVT.Text + "%' OR TEN_PT like '%" + txtTimVT.Text + "%'"
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try

        Try
            dtTmp1 = DirectCast(grdPT.DataSource, DataTable)
            Dim str As String
            If txtTimVT.Text = "" Then str = "" Else str = " QUY_CACH like '%" + txtTimVT.Text + "%' OR  MS_PT like '%" + txtTimVT.Text + "%' OR TEN_PT like '%" + txtTimVT.Text + "%'"
            dtTmp1.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp1.DefaultView.RowFilter = ""
        End Try


        dtTmp = dtTmp.DefaultView.ToTable()
        dtTmp1 = dtTmp1.DefaultView.ToTable()
    End Sub

    Private Sub cboLOAI_VT_EditValueChanged(sender As Object, e As EventArgs) Handles cboLOAI_VT.EditValueChanged, CboLoaiPT.EditValueChanged
        If cboLOAI_VT.Text = "" Then Exit Sub
        BindData()
        BindData_VatTu()
    End Sub
End Class