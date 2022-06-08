Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue
Imports DevExpress.XtraEditors

Public Class frmKeHoachSX
    Private dtTheoLine As New DataTable
    Private bSua As Boolean = False
    Private itabIndex As Integer = -1

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ReadOnlyGridView(ByVal flag As Boolean)
        Try
            grdKH_SX_LINE.Columns("MS_HE_THONG").ReadOnly = True
            grdKH_SX_LINE.Columns("THANG").ReadOnly = True
            grdKH_SX_LINE.Columns("SO_GIO_KH").ReadOnly = True
        Catch
        End Try

    End Sub


    Private Sub frmKeHoachSX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindDataTheoLine()
        grdKH_SX_LINE.AllowUserToAddRows = False
        ReadOnlyGridView(True)
        ' BindDataTheoMay()
        RefeshLanguage()
    End Sub
    ' Xet ngon ngu cho form 

    Private Sub RefeshLanguage()
        Me.lblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieuDe.Name, Commons.Modules.TypeLanguage)
        Me.lblTieuDeDayChuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieuDeDayChuyen.Name, Commons.Modules.TypeLanguage)
        Me.lblDayChuyenSX.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblDayChuyenSX.Name, Commons.Modules.TypeLanguage)
        Me.lblLoaiMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblLoaiMay.Name, Commons.Modules.TypeLanguage)
        Me.lblTieuDeMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieuDeMay.Name, Commons.Modules.TypeLanguage)
        Me.tabTheoLine.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, tabTheoLine.Name, Commons.Modules.TypeLanguage)
        Me.tabTheoMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, tabTheoMay.Name, Commons.Modules.TypeLanguage)


        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnGhi.Name, Commons.Modules.TypeLanguage)
        Me.btnKhongGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnKhongGhi.Name, Commons.Modules.TypeLanguage)
        Me.btnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnSua.Name, Commons.Modules.TypeLanguage)
        Me.btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnThem.Name, Commons.Modules.TypeLanguage)
        Me.btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnThoat.Name, Commons.Modules.TypeLanguage)
        Me.btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnXoa.Name, Commons.Modules.TypeLanguage)

        grdKH_SX_LINE.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_HE_THONG", Commons.Modules.TypeLanguage)
        grdKH_SX_LINE.Columns("THANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG", Commons.Modules.TypeLanguage)
        grdKH_SX_LINE.Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
        grdKH_SX_LINE.Columns("DAY_CHUYEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
        grdKH_SX_LINE.Columns("dtpThang").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "dtpThang", Commons.Modules.TypeLanguage)


        'grdKH_SX_MAY.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_HE_THONG", commons.Modules.TypeLanguage)
        'grdKH_SX_MAY.Columns("THANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANG", commons.Modules.TypeLanguage)
        'grdKH_SX_MAY.Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", commons.Modules.TypeLanguage)
        'grdKH_SX_MAY.Columns(" MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, " MS_MAY", commons.Modules.TypeLanguage)

    End Sub

    Private Sub LoadcboDayChuyen()
        Dim cboDayChuyen As New DataGridViewComboBoxColumn
        cboDayChuyen.DisplayMember = "TEN_HE_THONG"
        cboDayChuyen.ValueMember = "MS_HE_THONG"
        cboDayChuyen.DataPropertyName = "MS_HE_THONG"
        cboDayChuyen.DropDownWidth = 180
        cboDayChuyen.Name = "DAY_CHUYEN"
        grdKH_SX_LINE.Columns.Insert(1, cboDayChuyen)
        grdKH_SX_LINE.Columns("DAY_CHUYEN").ReadOnly = True
        cboDayChuyen.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT HE_THONG.MS_HE_THONG, HE_THONG.TEN_HE_THONG FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')").Tables(0)
    End Sub

    Private Sub LoadcboMay()
        Dim cboMay As New DataGridViewComboBoxColumn

        cboMay.DisplayMember = "MS_MAY"
        cboMay.ValueMember = "TEN_MAY"
        cboMay.DataPropertyName = "MS_MAY"
        cboMay.DropDownWidth = 180
        cboMay.Name = "MAY"
        grdKH_SX_LINE.Columns.Insert(1, cboMay)
        grdKH_SX_LINE.Columns("DAY_CHUYEN").ReadOnly = True
        cboMay.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT HE_THONG.MS_HE_THONG, HE_THONG.TEN_HE_THONG FROM HE_THONG INNER JOIN NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')").Tables(0)
    End Sub

    Private Sub LoadThang()
        Dim col As New Commons.QLGridMaskedTextBoxColumn
        col.Name = "dtpThang"
        col.DataPropertyName = "THANG"
        col.Mask = "##/####"
        col.DefaultCellStyle.Format = Nothing
        grdKH_SX_LINE.Columns.Insert(3, col)
    End Sub

    Private Sub BindDataTheoLine()
        Dim str As String = "SELECT *,CONVERT(NVARCHAR(10),MS_HE_THONG) AS MS_HE_THONG_CU,CONVERT(NVARCHAR(20),THANG,103) AS THANG_CU, SO_GIO_KH AS SO_GIO_KH_CU FROM KE_HOACH_SX_LINE"
        Dim dt As New DataTable

        grdKH_SX_LINE.Columns.Clear()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        grdKH_SX_LINE.DataSource = dt
        LoadcboDayChuyen()
        LoadThang()
        RefreshLaguageGrid_Line()
        'grdKH_SX_LINE.Focus()
    End Sub

    Private Sub BindDataTheoMay()
        If cboLoaiMay.SelectedValue Is Nothing Or IsDBNull(cboLoaiMay.SelectedValue) Then
            bSua = False
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        'Dim str As String = "SELECT KE_HOACH_SX_MAY.*,CONVERT(NVARCHAR(10),KE_HOACH_SX_MAY.MS_MAY) AS MS_MAY_CU,CONVERT(NVARCHAR(20),THANG,103) AS THANG_CU, SO_GIO_KH AS SO_GIO_KH_CU " & _
        '                    "FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '                    "KE_HOACH_SX_MAY ON MAY.MS_MAY = KE_HOACH_SX_MAY.MS_MAY INNER JOIN NHOM_LOAI_MAY INNER JOIN " & _
        '                    "USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '                    "LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
        '                    "WHERE USERS.USERNAME = '" & Commons.Modules.UserName & "' AND (LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiMay.SelectedValue.ToString & "')"

        Dim str = "SELECT DISTINCT  KE_HOACH_SX_MAY.MS_MAY, KE_HOACH_SX_MAY.THANG, " & _
                " KE_HOACH_SX_MAY.SO_GIO_KH " & _
                " FROM  KE_HOACH_SX_MAY INNER JOIN " & _
                " HE_THONG ON KE_HOACH_SX_MAY.MS_HE_THONG = HE_THONG.MS_HE_THONG INNER JOIN " & _
                " KE_HOACH_SX_LINE ON HE_THONG.MS_HE_THONG = KE_HOACH_SX_LINE.MS_HE_THONG INNER JOIN " & _
                " MAY ON KE_HOACH_SX_MAY.MS_MAY = MAY.MS_MAY INNER JOIN " & _
                " NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                " NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                " USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID " & _
                " WHERE KE_HOACH_SX_LINE.MS_HE_THONG = " & cboDayChuyenSX.SelectedValue & " AND USERS.USERNAME = '" & Commons.Modules.UserName & "' AND NHOM_MAY.MS_NHOM_MAY = '" & cboLoaiMay.SelectedValue & "'"

        Dim dt As New DataTable

        grdKH_SX_MAY.DataSource = Nothing
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        grdKH_SX_MAY.DataSource = dt

        Dim col As New Commons.QLGridMaskedTextBoxColumn
        col.Name = "dtpThang"
        col.DataPropertyName = "THANG"
        col.Mask = "##/####"
        col.DefaultCellStyle.Format = Nothing
        grdKH_SX_MAY.Columns.Insert(2, col)

        RefreshGrid_May()
        grdKH_SX_MAY.Focus()

        grdKH_SX_MAY.ReadOnly = btnThem.Visible
        grdKH_SX_MAY.AllowUserToAddRows = False ' Not btnThem.Visible
    End Sub

    Private Sub RefreshLaguageGrid_Line()
        Try
            grdKH_SX_LINE.Columns("MS_HE_THONG").Visible = False
            grdKH_SX_LINE.Columns("THANG").Visible = False
            grdKH_SX_LINE.Columns("MS_HE_THONG_CU").Visible = False
            grdKH_SX_LINE.Columns("THANG_CU").Visible = False
            grdKH_SX_LINE.Columns("SO_GIO_KH_CU").Visible = False
            grdKH_SX_LINE.Columns("DAY_CHUYEN").Width = 180
            grdKH_SX_LINE.Columns("dtpTHANG").DefaultCellStyle.Format = "MM/yyyy"
            grdKH_SX_LINE.Columns("dtpTHANG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grdKH_SX_LINE.Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdKH_SX_LINE.Columns("DAY_CHUYEN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshGrid_May()
        Try
            'grdKH_SX_MAY.Columns("MS_HE_THONG").Visible = False
            grdKH_SX_MAY.Columns("THANG").Visible = False
            ' grdKH_SX_MAY.Columns("MS_MAY_CU").Visible = False
            'grdKH_SX_MAY.Columns("THANG_CU").Visible = False
            'grdKH_SX_MAY.Columns("SO_GIO_KH_CU").Visible = False
            grdKH_SX_MAY.Columns("dtpTHANG").DefaultCellStyle.Format = "MM/yyyy"

            grdKH_SX_MAY.Columns("dtpTHANG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grdKH_SX_MAY.Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdKH_SX_MAY.Columns("MS_MAY").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        bSua = True

        itabIndex = tabKHSX.SelectedIndex
        ReadOnlyGridView(False)
        If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
            BindDataTheoLine()
        Else
            BindDataTheoMay()
        End If
        VisibleControls(False)
        Try
            grdKH_SX_LINE.AllowUserToAddRows = True
            For i As Integer = 0 To grdKH_SX_LINE.Columns.Count - 1
                grdKH_SX_LINE.Columns(i).ReadOnly = False
            Next

        Catch
        End Try

    End Sub

    Private Sub VisibleControls(ByVal bBool As Boolean)
        btnThem.Visible = bBool
        btnSua.Visible = bBool
        btnXoa.Visible = bBool
        btnThoat.Visible = bBool
        btnGhi.Visible = Not bBool
        btnKhongGhi.Visible = Not bBool
        'btnThem.Visible = IIf(tabKHSX.SelectedTab.Name.ToString = "tabTheoMay", False, True)
    End Sub

    Private Function CheckReCord(ByVal vMa_hethong As String, ByVal vThang As DateTime, ByVal vSoGio As Double) As Boolean
        Commons.Modules.SQLString = "SELECT COUNT(MS_HE_THONG) AS SL FROM KE_HOACH_SX_MAY WHERE MS_HE_THONG= '" & vMa_hethong & "' AND THANG='" & vThang & "'"
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        dtReader.Read()
        Return IIf(dtReader.Item("SL") = 0, False, True)
    End Function

    Private Function CheckMayonHTMAY(ByVal VMa_HeThong As String, ByVal vThang As DateTime, ByVal vSoGio As Double, ByVal vMaMay As String) As Boolean
        Commons.Modules.SQLString = "SELECT COUNT(MS_HE_THONG) AS SL FROM KE_HOACH_SX_MAY WHERE MS_HE_THONG= '" & VMa_HeThong & "' AND THANG='" & vThang & "' AND MS_MAY = N'" & vMaMay & "'"
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        dtReader.Read()
        Return IIf(dtReader.Item("SL") = 0, False, True)
    End Function

    Private Function CheckLineOnHTL(ByVal vMa_hethong As String, ByVal vThang As DateTime, ByVal vSoGio As Double) As Boolean
        Commons.Modules.SQLString = "SELECT COUNT(MS_HE_THONG) AS SL FROM KE_HOACH_SX_LINE WHERE MS_HE_THONG= '" & vMa_hethong & "' AND THANG='" & vThang & "'"
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        dtReader.Read()
        Return IIf(dtReader.Item("SL") = 0, False, True)
    End Function

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        bSua = False
        If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
            dtTheoLine = Nothing
            dtTheoLine = grdKH_SX_LINE.DataSource
            cboDayChuyenSX.DataSource = Nothing
            Try
                For i As Integer = 0 To dtTheoLine.Rows.Count - 1
                    If grdKH_SX_LINE.Rows(i).Cells("SO_GIO_KH").Value = 0 Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH_0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        grdKH_SX_LINE.CurrentCell = grdKH_SX_LINE.Rows(i).Cells("SO_GIO_KH")
                        Exit Sub
                    End If
                    'XtraMessageBox.Show(dtTheoLine.Rows(i)("MS_HE_THONG_CU").ToString & dtTheoLine.Rows(i)("THANG_CU").ToString & dtTheoLine.Rows(i)("SO_GIO_KH_CU").ToString)
                    If dtTheoLine.Rows(i)("MS_HE_THONG_CU").ToString = "-1" And dtTheoLine.Rows(i)("THANG_CU").ToString = "-1" And dtTheoLine.Rows(i)("SO_GIO_KH_CU").ToString = "-1" Then GoTo INSERT
                    If dtTheoLine.Rows(i)("MS_HE_THONG") <> dtTheoLine.Rows(i)("MS_HE_THONG_CU") Or dtTheoLine.Rows(i)("THANG") <> CDate(dtTheoLine.Rows(i)("THANG_CU")) Or dtTheoLine.Rows(i)("SO_GIO_KH") <> dtTheoLine.Rows(i)("SO_GIO_KH_CU") Then
                        If IsDBNull(dtTheoLine.Rows(i)("MS_HE_THONG_CU")) And IsDBNull(dtTheoLine.Rows(i)("THANG_CU")) Then
INSERT:
                            'Dim str As String = "INSERT INTO KE_HOACH_SX_MAY SELECT MAY.MS_MAY,'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "' AS THANG," & dtTheoLine.Rows(i)("SO_GIO_KH") & " AS SO_GIO_KH " & _
                            '                                                "FROM NHOM_LOAI_MAY INNER JOIN NHOM_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN " & _
                            '                                                "USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN " & _
                            '                                                "MAY_HE_THONG ON MAY.MS_MAY = MAY_HE_THONG.MS_MAY WHERE (MAY_HE_THONG.MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG") & ") AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
                            If CheckLineOnHTL(dtTheoLine.Rows(i)("MS_HE_THONG").ToString, Format(CDate(dtTheoLine.Rows(i)("THANG")), "MM/dd/yyyy"), dtTheoLine.Rows(i)("SO_GIO_KH").ToString) Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRUNG_KHOA_0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If

                            ' kiem tra MS_HE_THONG, MÃ THÁNG,  TRONG TABLE KE_HOACH_SX_MAY

                            If CheckReCord(dtTheoLine.Rows(i)("MS_HE_THONG").ToString, Format(CDate(dtTheoLine.Rows(i)("THANG")), "MM/dd/yyyy"), dtTheoLine.Rows(i)("SO_GIO_KH").ToString) Then
                                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DA_TON_TAI_0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) = Windows.Forms.DialogResult.OK) Then
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO KE_HOACH_SX_LINE VALUES(" & dtTheoLine.Rows(i)("MS_HE_THONG") & ",'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "'," & dtTheoLine.Rows(i)("SO_GIO_KH") & ")")
                                    Dim s As String = "UPDATE KE_HOACH_SX_MAY SET MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "', SO_GIO_KH= " & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "MM/dd/yyyy") & "'"
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, s)
                                    Exit For
                                Else
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO KE_HOACH_SX_LINE VALUES(" & dtTheoLine.Rows(i)("MS_HE_THONG") & ",'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "'," & dtTheoLine.Rows(i)("SO_GIO_KH") & ")")
                                End If
                            Else
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO KE_HOACH_SX_LINE VALUES(" & dtTheoLine.Rows(i)("MS_HE_THONG") & ",'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "'," & dtTheoLine.Rows(i)("SO_GIO_KH") & ")")
                                Dim s As String = "INSERT INTO KE_HOACH_SX_MAY SELECT '" & dtTheoLine.Rows(i)("MS_HE_THONG") & "' AS MS_HE_THONG, MS_MAY,'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "' AS THANG," & dtTheoLine.Rows(i)("SO_GIO_KH") & " AS SO_GIO_KH FROM MAY_HE_THONG WHERE MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG")

                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO KE_HOACH_SX_MAY SELECT '" & dtTheoLine.Rows(i)("MS_HE_THONG") & "' AS MS_HE_THONG, MS_MAY,'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "' AS THANG," & dtTheoLine.Rows(i)("SO_GIO_KH") & " AS SO_GIO_KH FROM MAY_HE_THONG WHERE MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG"))
                            End If

                        Else    'UPDATE                            
                            If (CheckReCord(dtTheoLine.Rows(i)("MS_HE_THONG").ToString, Format(CDate(dtTheoLine.Rows(i)("THANG")), "MM/dd/yyyy"), dtTheoLine.Rows(i)("SO_GIO_KH").ToString)) Then

                                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UPDATE_0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes) Then

                                    Dim str = "SELECT DISTINCT HE_THONG.MS_HE_THONG, HE_THONG.TEN_HE_THONG, MAY_HE_THONG.MS_MAY " & _
                                            " FROM         HE_THONG INNER JOIN " & _
                                            " MAY_HE_THONG ON HE_THONG.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG " & _
                                            " WHERE  HE_THONG.MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG").ToString()
                                    Dim dt As New DataTable
                                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                                    Dim strMay = "SELECT DISTINCT MS_HE_THONG, THANG, MS_MAY, SO_GIO_KH " & _
                                                 " FROM KE_HOACH_SX_MAY " & _
                                                 " WHERE  MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG").ToString & " AND THANG = '" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "MM/dd/yyyy")
                                    Dim dtMay As New DataTable
                                    dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))


                                    For Each vrow As DataRow In dt.Rows
                                        For Each Mrow As DataRow In dtMay.Select("MS_MAY = '" & vrow("MS_MAY") & "'")
                                            Dim ss As String = Mrow("MS_MAY")

                                            If ss = "" Then
                                                Show(Mrow("MS_MAY"))
                                            End If
                                        Next


                                    Next

                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE KE_HOACH_SX_LINE SET MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "', SO_GIO_KH=" & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "dd/MMM/yyyy") & "'")
                                    Dim s As String = "UPDATE KE_HOACH_SX_MAY SET MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "', SO_GIO_KH= " & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "MM/dd/yyyy") & "'"
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, s) '"UPDATE KE_HOACH_SX_MAY SET MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "MM/dd/yyyy") & "', SO_GIO_KH=" & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "MM/dd/yyyy") & "'")
                                Else
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE KE_HOACH_SX_LINE SET MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "', SO_GIO_KH=" & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "dd/MMM/yyyy") & "'")
                                End If
                            Else
                                Dim s As String = "UPDATE KE_HOACH_SX_MAY SET MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG") & ", THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "', SO_GIO_KH= " & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG= " & dtTheoLine.Rows(i)("MS_HE_THONG_CU") & " AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "MM/dd/yyyy") & "'"
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, s)
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO KE_HOACH_SX_MAY SELECT DISTINCT '" & dtTheoLine.Rows(i)("MS_HE_THONG") & "' AS MS_HE_THONG, MS_MAY,'" & Format(CDate(dtTheoLine.Rows(i)("THANG")), "dd/MMM/yyyy") & "' AS THANG," & dtTheoLine.Rows(i)("SO_GIO_KH") & " AS SO_GIO_KH FROM MAY_HE_THONG WHERE MS_HE_THONG = " & dtTheoLine.Rows(i)("MS_HE_THONG"))

                            End If
                        End If
                    End If

                Next
                objTrans.Commit()

            Catch ex As Exception
                objTrans.Rollback()
            Finally
                objTrans.Dispose()
                objConnection.Close()
            End Try
        Else
            dtTheoLine = Nothing
            dtTheoLine = grdKH_SX_MAY.DataSource
            Try
                For i As Integer = 0 To dtTheoLine.Rows.Count - 1
                    If grdKH_SX_MAY.Rows(i).Cells("SO_GIO_KH").Value = 0 Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH_0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        grdKH_SX_MAY.CurrentCell = grdKH_SX_MAY.Rows(i).Cells("SO_GIO_KH")
                        Exit Sub
                    End If

                    If dtTheoLine.Rows(i)("MS_MAY") <> dtTheoLine.Rows(i)("MS_MAY_CU") Or dtTheoLine.Rows(i)("THANG") <> CDate(dtTheoLine.Rows(i)("THANG_CU")) Or dtTheoLine.Rows(i)("SO_GIO_KH") <> dtTheoLine.Rows(i)("SO_GIO_KH_CU") Then
                        If IsDBNull(dtTheoLine.Rows(i)("MS_MAY_CU")) And IsDBNull(dtTheoLine.Rows(i)("THANG_CU")) Then
                        Else    'UPDATE
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE KE_HOACH_SX_MAY SET SO_GIO_KH=" & dtTheoLine.Rows(i)("SO_GIO_KH") & " WHERE MS_HE_THONG=" & dtTheoLine.Rows(i)("MS_HE_THONG") & " AND MS_MAY=N'" & dtTheoLine.Rows(i)("MS_MAY_CU") & "' AND THANG='" & Format(CDate(dtTheoLine.Rows(i)("THANG_CU")), "dd/MMM/yyyy") & "'")
                        End If
                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
            Finally
                objTrans.Dispose()
                objConnection.Close()
            End Try
        End If

        VisibleControls(True)
        btnThem.Visible = IIf(tabKHSX.SelectedTab.Name.ToString = "tabTheoMay", False, True)

        If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
            Try
                grdKH_SX_LINE.AllowUserToAddRows = False
                For i As Integer = 0 To grdKH_SX_LINE.Columns.Count - 1
                    grdKH_SX_LINE.Columns(i).ReadOnly = True
                Next
                BindDataTheoLine()
            Catch
            End Try
        Else
            BindData()
        End If
        ReadOnlyGridView(True)
    End Sub

    Private Function CheckDataLine(ByVal MS_HE_THONG As Integer, ByVal THANG As Date) As Boolean
        Commons.Modules.SQLString = "SELECT ISNULL(COUNT(*),0) AS SL FROM KE_HOACH_SX_LINE WHERE MS_HE_THONG=" & MS_HE_THONG & " AND DATEDIFF(MONTH,THANG,'" & Format(CDate(THANG), "dd/MMM/yyyy") & "')=0"
        Dim dtReader As SqlDataReader

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        dtReader.Read()
        Return IIf(dtReader.Item("SL") = 0, False, True)
    End Function

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click

        bSua = False
        If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
            BindDataTheoLine()
        Else
            BindDataTheoMay()
        End If
        VisibleControls(True)
        btnThem.Visible = IIf(tabKHSX.SelectedTab.Name.ToString = "tabTheoMay", False, True)
        grdKH_SX_LINE.AllowUserToAddRows = False
        grdKH_SX_MAY.AllowUserToAddRows = False
        ReadOnlyGridView(True)
        RemoveHandler grdKH_SX_LINE.DataError, AddressOf grdKH_SX_LINE_DataError
    End Sub

    Private Sub grdKH_SX_LINE_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdKH_SX_LINE.DataError
        If grdKH_SX_LINE.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_NHAP_GIO", commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        ElseIf grdKH_SX_LINE.Columns(e.ColumnIndex).Name = "THANG" Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_NHAP_THANG", commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub grdKH_SX_LINE_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdKH_SX_LINE.DefaultValuesNeeded
        Try
            e.Row.Cells("THANG").Value = CDate(Now.Month & "/" & Now.Year)
            e.Row.Cells("MS_HE_THONG_CU").Value = -1
            e.Row.Cells("THANG_CU").Value = -1
            e.Row.Cells("SO_GIO_KH_CU").Value = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'VisibleControls(False)+
        ReadOnlyGridView(True)
        If tabKHSX.SelectedIndex = 0 Then
            If grdKH_SX_LINE.Rows.Count > 0 Then
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XOA_DL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE KE_HOACH_SX_MAY.MS_MAY, KE_HOACH_SX_MAY.THANG, KE_HOACH_SX_MAY.SO_GIO_KH FROM NHOM_LOAI_MAY INNER JOIN LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN MAY INNER JOIN MAY_HE_THONG ON MAY.MS_MAY = MAY_HE_THONG.MS_MAY INNER JOIN KE_HOACH_SX_MAY ON MAY.MS_MAY = KE_HOACH_SX_MAY.MS_MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') AND (MAY_HE_THONG.MS_HE_THONG = " & grdKH_SX_LINE.CurrentRow.Cells("MS_HE_THONG").Value & ")")
                    ' SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM KE_HOACH_SX_MAY WHERE MS_HE_THONG = " & grdKH_SX_LINE.CurrentRow.Cells("MS_HE_THONG").Value & " AND THANG='" & Format(grdKH_SX_LINE.CurrentRow.Cells("THANG").Value, "dd/MMM/yyyy") & "'")
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM KE_HOACH_SX_LINE WHERE MS_HE_THONG=" & grdKH_SX_LINE.CurrentRow.Cells("MS_HE_THONG").Value & " AND THANG='" & Format(grdKH_SX_LINE.CurrentRow.Cells("THANG").Value, "dd/MMM/yyyy") & "'")
                    '                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM KE_HOACH_SX_MAY WHERE MS_HE_THONG=" & grdKH_SX_LINE.CurrentRow.Cells("MS_HE_THONG").Value & " AND THANG='" & Format(grdKH_SX_LINE.CurrentRow.Cells("THANG").Value, "dd/MMM/yyyy") & "'")

                    If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
                        BindDataTheoLine()
                    Else
                        BindDataTheoMay()
                    End If
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            End If
        ElseIf tabKHSX.SelectedIndex = 1 Then
            If grdKH_SX_LINE.Rows.Count > 0 Then
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XOA_DL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM KE_HOACH_SX_MAY WHERE MS_MAY=N'" & grdKH_SX_MAY.CurrentRow.Cells("MS_MAY").Value & "' AND THANG='" & Format(grdKH_SX_MAY.CurrentRow.Cells("THANG").Value, "dd/MMM/yyyy") & "'")
                    If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
                        BindDataTheoLine()
                    Else
                        BindDataTheoMay()
                    End If
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                End If
            End If
        End If
    End Sub

    Private Sub grdKH_SX_LINE_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKH_SX_LINE.RowEnter
        If e.RowIndex >= grdKH_SX_LINE.NewRowIndex Then Exit Sub
        If Convert.ToString(grdKH_SX_LINE.Rows(e.RowIndex).Cells("MS_HE_THONG_CU").Value) = "-1" And Convert.ToString(grdKH_SX_LINE.Rows(e.RowIndex).Cells("THANG_CU").Value) = "-1" And Convert.ToString(grdKH_SX_LINE.Rows(e.RowIndex).Cells("SO_GIO_KH_CU").Value) = "-1" Then
            grdKH_SX_LINE.Columns("MS_HE_THONG").ReadOnly = False
            grdKH_SX_LINE.Columns("THANG").ReadOnly = False
            grdKH_SX_LINE.Columns("SO_GIO_KH").ReadOnly = False
        Else
            grdKH_SX_LINE.Columns("MS_HE_THONG").ReadOnly = True
            grdKH_SX_LINE.Columns("THANG").ReadOnly = True
            grdKH_SX_LINE.Columns("SO_GIO_KH").ReadOnly = True
        End If
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        bSua = True
        ReadOnlyGridView(False)
        itabIndex = tabKHSX.SelectedIndex
        If tabKHSX.SelectedTab.Name = "tabTheoLine" Then
            BindDataTheoLine()
            Try
                For i As Integer = 0 To grdKH_SX_LINE.Columns.Count - 1
                    If Not grdKH_SX_LINE.Columns(i).Name.Equals("DAY_CHUYEN") Then grdKH_SX_LINE.Columns(i).ReadOnly = False
                Next
            Catch
            End Try
            AddHandler grdKH_SX_LINE.DataError, AddressOf grdKH_SX_LINE_DataError
            VisibleControls(False)
        Else
            BindDataTheoMay()
            If Not cboLoaiMay.SelectedValue Is Nothing Then
                Try
                    grdKH_SX_MAY.ReadOnly = False
                    For i As Integer = 0 To grdKH_SX_MAY.Columns.Count - 1
                        grdKH_SX_MAY.Columns(i).ReadOnly = False
                    Next
                Catch
                End Try
                AddHandler grdKH_SX_MAY.DataError, AddressOf grdKH_SX_MAY_DataError
                VisibleControls(False)
            End If
        End If
    End Sub

    Private Sub tabKHSX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabKHSX.SelectedIndexChanged
        btnThem.Visible = IIf(tabKHSX.SelectedTab.Name.ToString = "tabTheoMay", False, True)
        If tabKHSX.SelectedIndex <> itabIndex And bSua = True Then
            tabKHSX.SelectedIndex = itabIndex
            btnThem.Visible = False
            Exit Sub
        End If
        cboDayChuyenSX.DataSource = Nothing
        BindData()
        Dim iiii As Integer = grdKH_SX_MAY.Columns.Count
        Dim s As String = grdKH_SX_MAY.Columns(1).Name
        Dim s2 As String = grdKH_SX_MAY.Columns(2).Name
        Dim s3 As String = grdKH_SX_MAY.Columns(3).Name
        Dim s4 As String = grdKH_SX_MAY.Columns(0).Name

        grdKH_SX_MAY.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
        grdKH_SX_MAY.Columns("THANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG", Commons.Modules.TypeLanguage)
        grdKH_SX_MAY.Columns("dtpThang").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "dtpThang", Commons.Modules.TypeLanguage)
        grdKH_SX_MAY.Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)

    End Sub

    Private Sub cboDayChuyenSX_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDayChuyenSX.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub BindData()
        Dim str As String
        If tabKHSX.SelectedTab.Name.ToString = "tabTheoMay" Then
            If cboDayChuyenSX.DataSource Is Nothing Then
                str = "SELECT DISTINCT KE_HOACH_SX_LINE.MS_HE_THONG, HE_THONG.TEN_HE_THONG " & _
                      "FROM HE_THONG INNER JOIN KE_HOACH_SX_LINE ON HE_THONG.MS_HE_THONG = KE_HOACH_SX_LINE.MS_HE_THONG INNER JOIN " & _
                           "NHOM_HE_THONG ON HE_THONG.MS_HE_THONG = NHOM_HE_THONG.MS_HE_THONG INNER JOIN USERS ON dbo.NHOM_HE_THONG.GROUP_ID = USERS.GROUP_ID " & _
                      "WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"

                cboDayChuyenSX.Value = "MS_HE_THONG"
                cboDayChuyenSX.Display = "TEN_HE_THONG"

                cboDayChuyenSX.Param = str
                cboDayChuyenSX.StoreName = "QL_SEARCH"
                cboDayChuyenSX.BindDataSource()


            End If

            cboLoaiMay.DataSource = Nothing
            grdKH_SX_MAY.DataSource = Nothing

            str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
                  "FROM KE_HOACH_SX_LINE INNER JOIN MAY_HE_THONG ON KE_HOACH_SX_LINE.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG INNER JOIN " & _
                       "LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN " & _
                       "MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY ON MAY_HE_THONG.MS_MAY = MAY.MS_MAY INNER JOIN " & _
                       "NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID"

            'str = "SELECT DISTINCT  KE_HOACH_SX_MAY.MS_MAY, KE_HOACH_SX_MAY.THANG, " & _
            '        " KE_HOACH_SX_MAY.SO_GIO_KH, KE_HOACH_SX_LINE.MS_HE_THONG, " & _
            '        " HE_THONG.TEN_HE_THONG, MAY.TEN_MAY, NHOM_MAY.TEN_NHOM_MAY,  " & _
            '        " NHOM_MAY.MS_NHOM_MAY, USERS.USERNAME " & _
            '        " FROM  KE_HOACH_SX_MAY INNER JOIN " & _
            '        " HE_THONG ON KE_HOACH_SX_MAY.MS_HE_THONG = HE_THONG.MS_HE_THONG INNER JOIN " & _
            '        " KE_HOACH_SX_LINE ON HE_THONG.MS_HE_THONG = KE_HOACH_SX_LINE.MS_HE_THONG INNER JOIN " & _
            '        " MAY ON KE_HOACH_SX_MAY.MS_MAY = MAY.MS_MAY INNER JOIN " & _
            '        " NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
            '        " NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            '        " USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID " & _
            '        " WHERE KE_HOACH_SX_LINE.MS_HE_THONG = " & cboDayChuyenSX.SelectedValue & " AND USERS.USERNAME = '" & Commons.Modules.UserName & "'" ' AND (NHOM_MAY.MS_NHOM_MAY = ?)


            If cboDayChuyenSX.Items.Count > 0 Then
                If cboDayChuyenSX.SelectedIndex = -1 Then cboDayChuyenSX.SelectedIndex = 0
                str += " WHERE MAY_HE_THONG.MS_HE_THONG = " & cboDayChuyenSX.SelectedValue & " AND USERS.USERNAME = '" & Commons.Modules.UserName & "'"
            End If

            cboLoaiMay.Value = "MS_LOAI_MAY"
            cboLoaiMay.Display = "TEN_LOAI_MAY"
            cboLoaiMay.Param = str
            cboLoaiMay.StoreName = "QL_SEARCH"
            cboLoaiMay.BindDataSource()

            If cboLoaiMay.Items.Count > 0 Then BindDataTheoMay()
        End If
    End Sub

    Private Sub cboLoaiMay_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiMay.SelectionChangeCommitted
        If cboLoaiMay.Items.Count > 0 Then BindDataTheoMay()
    End Sub

    Private Sub grdKH_SX_MAY_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdKH_SX_MAY.DataError
        If grdKH_SX_MAY.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_NHAP_GIO", commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        ElseIf grdKH_SX_MAY.Columns(e.ColumnIndex).Name = "THANG" Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_NHAP_THANG", commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub grdKH_SX_MAY_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdKH_SX_MAY.DefaultValuesNeeded
        Try
            e.Row.Cells("THANG").Value = CDate(Now.Month & "/" & Now.Year)
            e.Row.Cells("MS_HE_THONG_CU").Value = -1
            e.Row.Cells("THANG_CU").Value = -1
            e.Row.Cells("SO_GIO_KH_CU").Value = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdKH_SX_MAY_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKH_SX_MAY.RowEnter
        'If e.RowIndex >= grdKH_SX_MAY.NewRowIndex Then Exit Sub
        grdKH_SX_MAY.Columns("MS_MAY").ReadOnly = True
        grdKH_SX_MAY.Columns("SO_GIO_KH").ReadOnly = Not bSua
        Try
            grdKH_SX_MAY.Columns("dtpTHANG").ReadOnly = True
        Catch
        End Try
    End Sub


    Private Sub grdKH_SX_LINE_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdKH_SX_LINE.CellValidating



    End Sub

End Class