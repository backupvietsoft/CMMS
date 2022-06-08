Imports DevExpress.XtraEditors.Controls
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class frmNhomquyen
    Private dtNNgu As DataTable
    Private tbGroup As DataTable
    Private tbUser As DataTable
    Private clNewRowUser As Collection
    Private RowEdit As Integer = -1
    Private isLock As Boolean = False
    Private isLoad As Boolean = False
    Private isLoadMenu As Boolean = False
    Private isLoadForm As Boolean = False
    Private isLoadDulieu As Boolean = False
    Private isLoadDiadiem As Boolean = False
    Private isLoadLoaiTBBPCP As Boolean = False
    Private isLoadLoaiCVVTPT As Boolean = False
    Private isLoadKhoPhongBan As Boolean = False
    Private isLoadReport As Boolean = False
    Private selGroupID As Integer = -1
#Region "Dung chung"
    Private Function GetNN(ByVal dtNN As DataTable, ByVal sKeyWord As String) As String
        If dtNN Is Nothing Then
            Return ""
            Exit Function
        End If

        Dim sNN As String = ""
        Try
            If CInt(dtNN.Rows(0)(2).ToString) <> Commons.Modules.TypeLanguage Then LoadNN()
            sNN = CType(dtNN.Select("KEYWORD = '" & sKeyWord & "'"), DataRow())(0)(1).ToString()


        Catch ex As Exception
            sNN = ""
        End Try

        If sNN = "" Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, (" INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE]," &
                    " [FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR]) " &
                    " VALUES(N'" + Commons.Modules.ModuleName + "',N'" + Me.Name + "',N'" + sKeyWord + "',N'@" + sKeyWord + "@',N'@" + sKeyWord + "@',N'@" + sKeyWord + "@'," &
                    " 0,N'@" + sKeyWord + "@',N'@" + sKeyWord + "@',N'@" + sKeyWord + "@')"))
            sNN = "@" + sKeyWord + "@"
        End If

        Return sNN

    End Function
    Private Sub LoadNN()
        LoadDataNN()
    End Sub
    Private Sub LoadDataNN()
        dtNNgu = New DataTable
        dtNNgu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT KEYWORD , CASE " & Commons.Modules.TypeLanguage &
                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN , CONVERT(INT," & Commons.Modules.TypeLanguage.ToString & ") AS NNGU " &
                " FROM LANGUAGES WHERE FORM = N'" & Me.Name & "' "))

    End Sub

    Private Sub LoadUserDN()
        Dim sSql As String
        Dim dtTmp As New DataTable
        sSql = "SELECT B.USERNAME, B.FULL_NAME, B.MS_CONG_NHAN, " &
                    " dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS HO_TEN, A.TIME_LOGIN " &
                    " FROM         dbo.LOGIN AS A INNER JOIN " &
                    " dbo.USERS AS B ON A.USER_LOGIN = B.USERNAME LEFT OUTER JOIN " &
                    " dbo.CONG_NHAN ON B.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN " &
                    " ORDER BY A.TIME_LOGIN DESC ,A.USER_LOGIN"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        ''DISTINCT ROW_NUMBER() OVER (ORDER BY A.TIME_LOGIN DESC ,A.USER_LOGIN) AS [STT],  A.USER_LOGIN,'
        'grdUser.DataSource = dtTmp
        'grdUser.ReadOnly = True
    End Sub

#End Region
#Region "Xu ly Tab nhom"
    Private Function IsExistsUser(ByVal GROUP_ID As String, ByVal UserName As String)
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con
                sqlcom.Parameters.AddWithValue("ACTION", "CHECK_EXISTS_USERS")
                sqlcom.Parameters.AddWithValue("USERNAME", UserName)
                sqlcom.Parameters.AddWithValue("GROUP_ID", GROUP_ID)
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                Dim da As New SqlDataAdapter(sqlcom)
                da.Fill(dtTmp)
                If dtTmp.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
#Region "KHAI BAO BIEN"
    Private is_ADD As Boolean = False
    Private is_EDIT As Boolean = False
    Private clSelAdd As Collection
#End Region
#Region "Load Form"

    Private Sub frmNhomquyen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        clSelAdd = New Collection()


        txtGroupName.Text = ""
        txtGroupMoTa.Text = ""



        SetNNMenu()
        VisibleButton(True)

        FillComboLicense()
        FillComboDepartment()
        FillComboNhanVien()
        Commons.Modules.SQLString = "0Load"
        LoadListGroup()
        Commons.Modules.SQLString = ""
        grdListOfGroup_FocusedRowChanged(grdListOfGroup, New Views.Base.FocusedRowChangedEventArgs(0, 0))
        LoadComboLoaiBaoCao()
        is_ADD = False
        is_EDIT = False


        SetFormPermission(Me.Name, Commons.Modules.UserName)


    End Sub

#End Region
#Region "Fill data"



    Private Sub FillComboLicense()

        Dim dtTmp As New DataTable


        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLicType", Commons.Modules.TypeLanguage))

        Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboStatus.NullText = ""
        cboStatus.ValueMember = "TYPE_LIC"
        cboStatus.DisplayMember = "TEN_LIC"
        cboStatus.DataSource = dtTmp

        cboStatus.Columns.Clear()

        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE_LIC"))
        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LIC"))

        cboStatus.PopupWidth = 200
        cboStatus.Columns("TYPE_LIC").Width = 50
        cboStatus.Columns("TEN_LIC").Width = 150
        If Commons.Modules.TypeLanguage = 1 Then
            cboStatus.Columns("TYPE_LIC").Caption = "ID"
            cboStatus.Columns("TEN_LIC").Caption = "License Name"
        Else
            cboStatus.Columns("TYPE_LIC").Caption = "Mã"
            cboStatus.Columns("TEN_LIC").Caption = "Tên License"
        End If



        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("TYPE_LIC").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("TEN_LIC").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.ShowFooter = False
        grdListOfGroup.Columns("TYPE_LIC").ColumnEdit = cboStatus

    End Sub
    Private Sub FillComboDepartment()

        Dim dtTmp As New DataTable


        Try
            Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                Dim sqlcom As SqlCommand = con.CreateCommand()
                Try
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    sqlcom.Connection = con

                    sqlcom.Parameters.AddWithValue("ACTION", "LOAD_TO")
                    sqlcom.CommandType = CommandType.StoredProcedure
                    sqlcom.CommandText = "SP_NHOM"
                    Dim da As New SqlDataAdapter(sqlcom)
                    da.Fill(dtTmp)
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
            End Using
        Catch ex As Exception
        End Try

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDepartment, dtTmp, "MS_TO", "TEN_TO", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TO", Commons.Modules.TypeLanguage))

        cmbDepartment.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center
        cmbDepartment.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = VertAlignment.Center
        cmbDepartment.Properties.NullText = ""
        '   cmbDepartment.Properties.ValueMember = "MS_TO"
        '  cmbDepartment.Properties.DisplayMember = "TEN_TO"
        '   cmbDepartment.Properties.PopulateColumns()
        '   cmbDepartment.Properties.DataSource = dtTmp
        ' cmbDepartment.Properties.Columns("MS_TO").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_TO", Commons.Modules.TypeLanguage)
        ' cmbDepartment.Properties.Columns("TEN_TO").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TO", Commons.Modules.TypeLanguage)
        cmbDepartment.Properties.ShowFooter = False

        Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboStatus.NullText = ""
        cboStatus.ValueMember = "MS_TO"
        cboStatus.DisplayMember = "TEN_TO"
        cboStatus.DataSource = dtTmp




        cboStatus.Columns.Clear()

        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_TO"))
        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_TO"))

        cboStatus.PopupWidth = 300
        cboStatus.Columns("MS_TO").Width = 80
        cboStatus.Columns("TEN_TO").Width = 220
        If Commons.Modules.TypeLanguage = 1 Then
            cboStatus.Columns("MS_TO").Caption = "Code"
            cboStatus.Columns("TEN_TO").Caption = "Name"
        Else
            cboStatus.Columns("MS_TO").Caption = "Mã"
            cboStatus.Columns("TEN_TO").Caption = "Tên"
        End If



        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("MS_TO").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("TEN_TO").Alignment = DevExpress.Utils.HorzAlignment.Near
        cboStatus.ShowFooter = False
        grdDanhsachuser.Columns("MS_TO").ColumnEdit = cboStatus
        grdDanhsachusers.Columns("MS_TO").ColumnEdit = cboStatus
    End Sub

    Private Sub FillComboNhanVien()

        Dim dtTmp As New DataTable


        Try
            Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                Dim sqlcom As SqlCommand = con.CreateCommand()
                Try
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    sqlcom.Connection = con

                    sqlcom.Parameters.AddWithValue("ACTION", "LOAD_CONG_NHAN")
                    sqlcom.CommandType = CommandType.StoredProcedure
                    sqlcom.CommandText = "SP_NHOM"
                    Dim da As New SqlDataAdapter(sqlcom)
                    da.Fill(dtTmp)
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
            End Using
        Catch ex As Exception
        End Try


        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCNhan, dtTmp, "MS_CONG_NHAN", "FULL_NAME", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "FULL_NAME", Commons.Modules.TypeLanguage))


        cmbCNhan.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center
        cmbCNhan.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = VertAlignment.Center
        cmbCNhan.Properties.NullText = ""
        'cmbCNhan.Properties.ValueMember = "MS_CONG_NHAN"
        'cmbCNhan.Properties.DisplayMember = "FULL_NAME"
        'cmbCNhan.Properties.DataSource = dtTmp
        cmbCNhan.Properties.ShowFooter = False



        Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboStatus.NullText = ""
        cboStatus.ValueMember = "MS_CONG_NHAN"
        cboStatus.DisplayMember = "FULL_NAME"
        cboStatus.DataSource = dtTmp





        cboStatus.Columns.Clear()

        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_CONG_NHAN"))
        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FULL_NAME"))

        cboStatus.PopupWidth = 300
        cboStatus.Columns("MS_CONG_NHAN").Width = 80
        cboStatus.Columns("FULL_NAME").Width = 220
        If Commons.Modules.TypeLanguage = 1 Then
            cboStatus.Columns("MS_CONG_NHAN").Caption = "ID"
            cboStatus.Columns("FULL_NAME").Caption = "Name"
        Else
            cboStatus.Columns("MS_CONG_NHAN").Caption = "Mã"
            cboStatus.Columns("FULL_NAME").Caption = "Tên"
        End If



        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("MS_CONG_NHAN").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("FULL_NAME").Alignment = DevExpress.Utils.HorzAlignment.Near
        cboStatus.ShowFooter = False
        grdDanhsachuser.Columns("MS_CONG_NHAN").ColumnEdit = cboStatus
        grdDanhsachusers.Columns("MS_CONG_NHAN").ColumnEdit = cboStatus

    End Sub

    Sub LoadListGroup(Optional ByVal iNhom As String = "-1")
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                Dim sqlcom As SqlCommand = con.CreateCommand()
                Try
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    sqlcom.Connection = con
                    sqlcom.Parameters.AddWithValue("ACTION", "LOAD")
                    sqlcom.Parameters.AddWithValue("@NNgu", Commons.Modules.TypeLanguage)
                    sqlcom.CommandType = CommandType.StoredProcedure
                    sqlcom.CommandText = "SP_NHOM"
                    Dim da As New SqlDataAdapter(sqlcom)
                    da.Fill(dt)
                    tbGroup = dt.Copy()
                Catch ex As Exception

                Finally
                    con.Close()
                End Try
            End Using

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, grdListOfGroup, dt, False, False, True, True, True, Name)

            grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdListOfGroup.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            If (iNhom <> "-1") Then
                grdListOfGroup.FocusedRowHandle = iNhom
            End If
            LockGrid(grdListOfGroup, True)
        Catch ex As Exception
        End Try

    End Sub


    Sub LoadListUserOfGroup(ByVal intGroupID As Integer)
        Try


            Dim dtTmp As New DataTable


            Try
                Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                    Dim sqlcom As SqlCommand = con.CreateCommand()
                    Try
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        sqlcom.Connection = con

                        sqlcom.Parameters.AddWithValue("ACTION", "LOAD_USERS")
                        sqlcom.Parameters.AddWithValue("GROUP_ID", intGroupID)
                        sqlcom.CommandType = CommandType.StoredProcedure
                        sqlcom.CommandText = "SP_NHOM"
                        Dim da As New SqlDataAdapter(sqlcom)
                        da.Fill(dtTmp)
                        Dim primaryKey(1) As DataColumn
                        primaryKey(0) = dtTmp.Columns("USERNAME_OLD")
                        dtTmp.PrimaryKey = primaryKey
                        If tbUser Is Nothing Then
                            tbUser = New DataTable()
                            tbUser = dtTmp.Clone()
                            Dim pKey(1) As DataColumn
                            pKey(0) = tbUser.Columns("USERNAME_OLD")
                            tbUser.PrimaryKey = pKey
                        End If

                    Catch ex As Exception

                    Finally
                        con.Close()
                    End Try
                End Using
            Catch ex As Exception
            End Try

            For Each dr As DataRow In tbUser.Rows
                If dr("GROUP_ID") = grdListOfGroup.GetFocusedRowCellValue("GROUP_ID") Then

                    If dtTmp.Rows.Contains(dr("USERNAME_OLD")) Then
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("USERNAME") = dr("USERNAME")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("FULL_NAME") = dr("FULL_NAME")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("DESCRIPTION") = dr("DESCRIPTION")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("MS_TO") = dr("MS_TO")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("USER_MAIL") = dr("USER_MAIL")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("MS_CONG_NHAN") = dr("MS_CONG_NHAN")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("ACTIVE") = dr("ACTIVE")
                        dtTmp.Rows.Find(dr("USERNAME_OLD"))("IS_UPDATE") = dr("IS_UPDATE")
                        dtTmp.AcceptChanges()
                    Else
                        dtTmp.ImportRow(dr)
                        dtTmp.AcceptChanges()
                    End If

                End If

            Next

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl2, grdDanhsachuser, dtTmp, False, False, True, True, True, Name)

            grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdDanhsachuser.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

            LockGrid(grdDanhsachuser, True)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadListUser()
        Dim sSql As String
        Dim dtTmp As New DataTable

        sSql = " SELECT A.USERNAME, A.FULL_NAME, B.GROUP_NAME, B.DESCRIPTION , A.GROUP_ID, A.GROUP_ID,HO + ' ' + TEN AS HO_TEN " &
                " FROM dbo.USERS AS A INNER JOIN dbo.NHOM AS B ON A.GROUP_ID = B.GROUP_ID  " &
                " LEFT JOIN CONG_NHAN C ON A.MS_CONG_NHAN = C.MS_CONG_NHAN " &
                " ORDER BY B.GROUP_NAME, A.USERNAME "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        GridControl2.DataSource = dtTmp
        'grdListUser.Columns("GROUP_ID").Visible = False

    End Sub
#End Region
#Region "Event Click Button"
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        is_ADD = True
        isLoadMenu = False
        isLoadForm = False
        isLoadDulieu = False
        isLoadDiadiem = False
        isLoadLoaiTBBPCP = False
        isLoadLoaiCVVTPT = False
        isLoadKhoPhongBan = False
        isLoadReport = False


        VisibleButton(False)
        grdListOfGroup.OptionsBehavior.Editable = True

        grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        grdListOfGroup.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grdListOfGroup.NewItemRowText = ""
        grdListOfGroup.SetRowCellValue(grdListOfGroup.RowCount, "GROUP_ID", -grdListOfGroup.RowCount)
        grdListOfGroup.MoveLastVisible()






        LockGrid(grdListOfGroup, False)
        LockGrid(grdDanhsachuser, False)
        txtGroupName.Text = ""
        txtGroupID.Text = ""
        txtGroupMoTa.Text = ""

        LockTab(True)
    End Sub
    Private Sub LockTab(ByVal TT As Boolean)
        For i As Integer = 0 To XtraTabControl1.TabPages.Count - 1
            If i <> XtraTabControl1.SelectedTabPageIndex Then
                XtraTabControl1.TabPages(i).PageEnabled = Not TT
            End If
        Next
        For i As Integer = 0 To XtraTabControl2.TabPages.Count - 1
            If i <> XtraTabControl2.SelectedTabPageIndex Then
                XtraTabControl2.TabPages(i).PageEnabled = Not TT
            End If
        Next
        For i As Integer = 0 To XtraTabControl3.TabPages.Count - 1
            If i <> XtraTabControl3.SelectedTabPageIndex Then
                XtraTabControl3.TabPages(i).PageEnabled = Not TT
            End If
        Next
    End Sub
    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        is_EDIT = True
        VisibleButton(False)
        LockGrid(grdListOfGroup, False)
        LockGrid(grdDanhsachuser, False)
        grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdListOfGroup.OptionsBehavior.Editable = True

        grdDanhsachuser.OptionsBehavior.Editable = True
        grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        grdDanhsachuser.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grdDanhsachuser.NewItemRowText = ""

        grdDanhsachuser.MoveLastVisible()
        LockTab(True)
    End Sub
    Private Sub btnKhongluu_Click(sender As Object, e As EventArgs) Handles btnKhong.Click
        'Xu ly Khong luu du lieu

        VisibleButton(True)
        is_ADD = False
        is_EDIT = False

        tbUser = New DataTable()
        clNewRowUser = New Collection()
        LoadListGroup(grdListOfGroup.FocusedRowHandle)
        LockTab(False)
        LoadListUserOfGroup(txtGroupID.Text)
    End Sub
    Private Sub grdDanhsachuser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDanhsachuser.KeyDown
        Try
            If is_ADD = True Or is_EDIT = True Then
                If (e.KeyCode = Keys.Delete) Then
                    'If (XtraMessageBox.Show("Delete row?", "Confirmation",
                    '  MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
                    Dim view As GridView = CType(sender, GridView)

                    If CheckUserDaSuDung(view.GetRowCellValue(view.FocusedRowHandle, "USERNAME").ToString().Trim) = False Then
                        If DeleteUser(txtGroupID.Text, view.GetRowCellValue(view.FocusedRowHandle, "USERNAME").ToString().Trim) Then
                            view.DeleteRow(view.FocusedRowHandle)
                        End If
                        If txtGroupID.Text = "" Then
                            view.DeleteRow(view.FocusedRowHandle)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        grdListOfGroup.UpdateCurrentRow()
        'Xu ly Luu du lieu
        Dim dataView As DataView
        If is_ADD = True Then
            dataView = New DataView(DirectCast(GridControl1.DataSource, DataTable), "IS_UPDATE ='True' AND GROUP_ID < 0", "", DataViewRowState.CurrentRows)
        Else
            dataView = New DataView(DirectCast(GridControl1.DataSource, DataTable), "IS_UPDATE ='True' AND GROUP_ID >= 0", "", DataViewRowState.CurrentRows)
        End If
        tbGroup = New System.Data.DataTable()
        tbGroup = dataView.ToTable(True, "GROUP_ID", "GROUP_NAME", "DESCRIPTION", "TYPE_LIC", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl2.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        tbUser = New System.Data.DataTable()
        tbUser = dataView.ToTable(True, "USERNAME_OLD", "USERNAME", "GROUP_ID", "FULL_NAME", "PASS", "DESCRIPTION", "MS_TO", "USER_MAIL", "MS_CONG_NHAN", "ACTIVE", "IS_UPDATE")

        If CheckValidData() = False Then
            Exit Sub
        End If
        'If isValidData() Then
        If Save(tbGroup, tbUser) Then

            grdDanhsachuser.ClearColumnErrors()
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try
            VisibleButton(True)


            If is_ADD = True Then
                LoadListGroup()
                'grdListOfGroup.MoveFirst()
                If grdListOfGroup.RowCount > 0 Then
                    Dim groupid As Integer = grdListOfGroup.GetDataRow(0)("GROUP_ID")
                    LoadListUserOfGroup(groupid)
                End If
            End If
            is_ADD = False
            is_EDIT = False
            tbUser = New DataTable()
            clNewRowUser = New Collection()
            LockGrid(grdListOfGroup, True)
            LockGrid(grdDanhsachuser, True)

            grdListOfGroup.OptionsBehavior.Editable = False
            grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdDanhsachuser.OptionsBehavior.Editable = False
            grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            LockTab(False)

        End If
        'End If
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Private Function CheckUserDaSuDung(ByVal Username As String)
        If Commons.Modules.ObjGroups.CheckUSER_CHUCNANG(Username) Then
            MsgBox(Username & " - " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKTUserDaSuDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return True
        End If
        Return False
    End Function
    Private Function CheckDeleteUser()
        For i As Integer = 0 To grdDanhsachuser.RowCount - 1
            If Commons.Modules.ObjGroups.CheckUSER_CHUCNANG(grdDanhsachuser.GetDataRow(i)("USERNAME")) Then
                MsgBox(grdDanhsachuser.GetDataRow(i)("USERNAME") & " - " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKTUserDaSuDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function
    Private Function CheckUpdateUser(ByVal UserName As String)
        If Commons.Modules.ObjGroups.CheckUSER_CHUCNANG(UserName) Then
            'MsgBox(UserName & " - " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKTUserDaSuDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If grdListOfGroup.FocusedRowHandle <> -1 Then
            If Commons.Modules.ObjGroups.CheckExistGROUP_ID(grdListOfGroup.GetFocusedRowCellValue("GROUP_ID").ToString()) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKTNhomDaSuDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaNhom", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                If CheckDeleteUser() Then
                    Commons.Modules.ObjGroups.DeleteNHOMs(txtGroupID.Text)
                    VisibleButton(True)
                    is_ADD = False
                    LoadListGroup()
                    grdListOfGroup.MoveFirst()
                    If grdListOfGroup.RowCount > 0 Then
                        Dim groupid As Integer = grdListOfGroup.GetDataRow(0)("GROUP_ID")
                        LoadListUserOfGroup(groupid)
                    End If
                    'If Delete() Then
                    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG", grdListOfGroup.GetFocusedRowCellValue("GROUP_ID").ToString(), Me.Name, Commons.Modules.UserName, 3)
                    '    VisibleButton(True)
                    '    is_ADD = False
                    '    LoadListGroup()
                    '    grdListOfGroup.MoveFirst()
                    '    If grdListOfGroup.RowCount > 0 Then
                    '        Dim groupid As Integer = grdListOfGroup.GetDataRow(0)("GROUP_ID")
                    '        LoadListUserOfGroup(groupid)
                    '    End If

                    'End If
                End If
            End If
        End If

    End Sub
#End Region
#Region "Xu ly an/hien"
    Private Sub VisibleButton(ByVal TT As Boolean)
        btnKhong.Visible = Not TT
        btnSave.Visible = Not TT
        btnThoat.Visible = TT
        btnThem.Visible = TT
        btnSua.Visible = TT
        btnXoa.Visible = TT
    End Sub

    Private Sub LockGrid(ByVal grid As GridView, ByVal TT As Boolean)
        For i As Integer = 0 To grid.Columns.Count - 1
            grid.Columns(i).OptionsColumn.AllowEdit = Not TT
            grid.Columns(i).OptionsColumn.ReadOnly = TT
        Next

    End Sub

#End Region
#Region "Xu ly Luu/Xoa"


    Private Function isValidData()

        Dim dataView As New DataView(DirectCast(GridControl1.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        tbGroup = New System.Data.DataTable()
        tbGroup = dataView.ToTable(True, "GROUP_ID", "GROUP_NAME", "DESCRIPTION", "TYPE_LIC", "IS_UPDATE")


        For Each dr As DataRow In tbGroup.Rows
            If dr("GROUP_NAME").ToString() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraNULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)

                Return False
            End If
            If dr("TYPE_LIC").ToString() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaNhapLoaiLic", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)

                Return False
                'Else
                '    If DirectCast(dr("TYPE_LIC"), Integer) = 0 Then
                '        MsgBox(GetNN(dtNNgu, "ChuaNhapLoaiLic"), MsgBoxStyle.Exclamation)
                '        Return False
                '    End If
            End If

            If Commons.Modules.ObjGroups.CheckExistTEN_NHOM(dr("GROUP_ID"), dr("GROUP_NAME").ToString().Trim).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function
    Public Function Save(ByVal tb As DataTable, ByVal tbUser As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE")
                If (tb IsNot Nothing) Then
                    If tb.Columns.Contains("TEN_LIC") Then
                        tb.Columns.Remove("TEN_LIC")
                    End If
                    sqlcom.Parameters.AddWithValue("@TBN", tb)
                End If
                If (tbUser IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBU", tbUser)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function Delete() As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE")
                sqlcom.Parameters.AddWithValue("GROUP_ID", grdListOfGroup.GetFocusedRowCellValue("GROUP_ID").ToString())

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function DeleteUser(ByVal GROUP_ID As String, ByVal USERNAME As String) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE_USER")
                sqlcom.Parameters.AddWithValue("USERNAME", USERNAME)
                sqlcom.Parameters.AddWithValue("GROUP_ID", GROUP_ID)
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Private Sub grdListOfGroup_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdListOfGroup.CellValueChanged
        Try
            If (btnSave.Visible = True) Then
                If e.Column.Name.ToString() <> "IS_UPDATE" Then
                    If grdListOfGroup.GetFocusedRowCellValue("GROUP_ID").ToString() = "" Then
                        grdListOfGroup.SetFocusedRowCellValue("GROUP_ID", -grdListOfGroup.RowCount)
                    End If
                    grdListOfGroup.SetFocusedRowCellValue("IS_UPDATE", True)

                End If
                If e.Column.Name.ToString() = "GROUP_NAME" Then
                    txtGroupName.Text = grdListOfGroup.GetFocusedRowCellValue("GROUP_NAME").ToString()
                    txtGroupMoTa.Text = grdListOfGroup.GetFocusedRowCellValue("DESCRIPTION").ToString()
                    grdDanhsachuser.OptionsBehavior.Editable = True
                    grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
                    grdDanhsachuser.MoveLastVisible()
                    grdDanhsachuser.SetRowCellValue(grdDanhsachuser.RowCount, "GROUP_ID", grdListOfGroup.GetFocusedRowCellValue("GROUP_ID"))
                    grdDanhsachuser.SetRowCellValue(grdDanhsachuser.RowCount, "USERNAME_OLD", "XXXYYYZZ" & grdDanhsachuser.RowCount.ToString())
                End If
                If e.Column.Name.ToString() = "DESCRIPTION" Then
                    txtGroupName.Text = grdListOfGroup.GetFocusedRowCellValue("GROUP_NAME").ToString()
                    txtGroupMoTa.Text = grdListOfGroup.GetFocusedRowCellValue("DESCRIPTION").ToString()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdListOfGroup_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grdListOfGroup.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grdListOfGroup_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grdListOfGroup.ValidateRow
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim sMaNhom As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("GROUP_ID")
        Dim sTenNhom As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("GROUP_NAME")
        Dim sLoaiLicense As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TYPE_LIC")

        If View.GetRowCellValue(e.RowHandle, sTenNhom).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sTenNhom, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            If Commons.Modules.ObjGroups.CheckExistTEN_NHOM(View.GetRowCellValue(e.RowHandle, sMaNhom).ToString(), View.GetRowCellValue(e.RowHandle, sTenNhom).ToString().Trim).Read Then
                e.Valid = False
                View.SetColumnError(sTenNhom, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If


    End Sub

    Private Sub grdDanhsachuser_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdDanhsachuser.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "UIS_UPDATE" Then
                If (grdListOfGroup.GetFocusedRowCellValue("GROUP_ID").ToString() = "") Then Exit Sub

                If grdDanhsachuser.GetFocusedRowCellValue("GROUP_ID").ToString() = "" Then
                    grdDanhsachuser.SetFocusedRowCellValue("GROUP_ID", grdListOfGroup.GetFocusedRowCellValue("GROUP_ID"))
                End If
                If grdDanhsachuser.GetFocusedRowCellValue("USERNAME_OLD").ToString() = "" Then
                    grdDanhsachuser.SetFocusedRowCellValue("USERNAME_OLD", "XXXYYYZZ" & grdDanhsachuser.RowCount.ToString())
                End If
                If grdDanhsachuser.GetFocusedRowCellValue("USERNAME").ToString().ToUpper = "ADMINISTRATOR" Then
                    If grdDanhsachuser.GetFocusedRowCellValue("ACTIVE").ToString() = "False" Then
                        grdDanhsachuser.SetFocusedRowCellValue("ACTIVE", True)
                    End If
                End If

                grdDanhsachuser.SetFocusedRowCellValue("IS_UPDATE", True)

            End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub grdListOfGroup_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdListOfGroup.FocusedRowChanged
    '    BindingData()
    'End Sub
    Private Sub BindingData()
        Try
            clNewRowUser = New Collection()

            If is_ADD = False And is_EDIT = False Then
                LoadListUserOfGroup(grdListOfGroup.GetFocusedRowCellValue("GROUP_ID"))
                txtGroupName.Text = grdListOfGroup.GetFocusedRowCellValue("GROUP_NAME")
                txtGroupMoTa.Text = grdListOfGroup.GetFocusedRowCellValue("DESCRIPTION")
                LockGrid(grdListOfGroup, True)
                LockGrid(grdDanhsachuser, True)
                grdListOfGroup.OptionsBehavior.Editable = False
                grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                grdDanhsachuser.OptionsBehavior.Editable = False
                grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            ElseIf is_ADD = True Then
                Dim dt As DataTable = DirectCast(GridControl2.DataSource, DataTable).Clone()
                GridControl2.DataSource = dt
                GridControl2.RefreshDataSource()

                LockGrid(grdDanhsachuser, False)
                'grdDanhsachuser.OptionsBehavior.Editable = True
                'grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            ElseIf is_EDIT = True Then
                LockGrid(grdDanhsachuser, False)
                grdDanhsachuser.OptionsBehavior.Editable = True
                grdDanhsachuser.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub grdListOfGroup_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdListOfGroup.ShowingEditor
        If is_ADD = True Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Try
                If Not (DirectCast(view.GetRowCellValue(view.FocusedRowHandle, "GROUP_ID"), Integer) < -1) Then
                    e.Cancel = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub grdListOfGroup_RowClick(sender As Object, e As RowClickEventArgs) Handles grdListOfGroup.RowClick
        If (btnSave.Visible = True) Then Exit Sub
        GetUpdateUserTemp()
        BindingData()
        RowEdit = e.RowHandle
        txtGroupID.Text = grdListOfGroup.GetDataRow(e.RowHandle)("GROUP_ID")
        isLoadMenu = True
        isLoadForm = True
        isLoadDulieu = True
        isLoadDiadiem = True
        isLoadLoaiTBBPCP = True
        isLoadLoaiCVVTPT = True
        isLoadKhoPhongBan = True
        isLoadReport = True
        selGroupID = -1
    End Sub
    Private Sub GetUpdateUserTemp()
        If Not GridControl2.DataSource Is Nothing Then
            Dim dataView As New DataView(DirectCast(GridControl2.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
            Dim tbU As DataTable = New System.Data.DataTable()
            tbU = dataView.ToTable(True, "USERNAME_OLD", "USERNAME", "GROUP_ID", "FULL_NAME", "PASS", "DESCRIPTION", "MS_TO", "USER_MAIL", "MS_CONG_NHAN", "ACTIVE", "IS_UPDATE")

            If tbUser.PrimaryKey.Length = 0 Then
                Dim pKey(1) As DataColumn
                pKey(0) = tbUser.Columns("USERNAME_OLD")
                tbUser.PrimaryKey = pKey
            End If
            For Each dr As DataRow In tbU.Rows
                If tbUser.Columns.Count > 0 Then
                    If Not tbUser.Rows.Contains(dr("USERNAME_OLD")) Then
                        tbUser.ImportRow(dr)
                    Else
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("USERNAME") = dr("USERNAME")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("FULL_NAME") = dr("FULL_NAME")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("DESCRIPTION") = dr("DESCRIPTION")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("MS_TO") = dr("MS_TO")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("USER_MAIL") = dr("USER_MAIL")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("MS_CONG_NHAN") = dr("MS_CONG_NHAN")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("ACTIVE") = dr("ACTIVE")
                        tbUser.Rows.Find(dr("USERNAME_OLD"))("IS_UPDATE") = dr("IS_UPDATE")
                        tbUser.AcceptChanges()
                    End If
                End If


            Next
        End If
    End Sub
    Private Sub grdListOfGroup_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdListOfGroup.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        GetUpdateUserTemp()
        BindingData()
        Try
            txtGroupID.Text = grdListOfGroup.GetDataRow(e.FocusedRowHandle)("GROUP_ID").ToString()
            isLoadMenu = True
            isLoadForm = True
            isLoadDulieu = True
            isLoadDiadiem = True
            isLoadLoaiTBBPCP = True
            isLoadLoaiCVVTPT = True
            isLoadKhoPhongBan = True
            isLoadReport = True
            selGroupID = -1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DropDownButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdListOfGroup_MouseDown(sender As Object, e As MouseEventArgs) Handles grdListOfGroup.MouseDown
        Dim info As GridHitInfo = grdListOfGroup.CalcHitInfo(e.Location)
        If is_ADD = True Then
            Try
                If info.RowHandle < 0 Then
                    Exit Sub
                End If
                If DirectCast(grdListOfGroup.GetDataRow(info.RowHandle)("GROUP_ID"), Integer) < 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                DirectCast(e, DXMouseEventArgs).Handled = True
            End Try
            DirectCast(e, DXMouseEventArgs).Handled = True

        End If
        If is_EDIT = True Then
            If info.RowHandle < 0 Then
                Exit Sub
            End If
            If txtGroupName.Text = grdListOfGroup.GetDataRow(info.RowHandle)("GROUP_NAME") Then

                Exit Sub
            End If

            DirectCast(e, DXMouseEventArgs).Handled = True

        End If
    End Sub





    Private Sub grdListOfGroup_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles grdListOfGroup.InitNewRow
        grdListOfGroup.SetFocusedRowCellValue("GROUP_ID", -grdListOfGroup.RowCount)
        grdListOfGroup.OptionsBehavior.AllowAddRows = DefaultBoolean.False
        grdListOfGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None
    End Sub

    Private Sub grdDanhsachuser_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles grdDanhsachuser.InitNewRow
        grdDanhsachuser.SetFocusedRowCellValue("GROUP_ID", grdListOfGroup.GetFocusedRowCellValue("GROUP_ID"))
        If Not clNewRowUser.Contains(grdDanhsachuser.FocusedRowHandle) Then
            clNewRowUser.Add(New String() {(grdDanhsachuser.RowCount - 1).ToString()}, (grdDanhsachuser.FocusedRowHandle).ToString())
        End If
        grdDanhsachuser.SetFocusedRowCellValue("PASS", Commons.clsXuLy.MaHoaDL("1234"))

    End Sub

    Private Sub grdDanhsachuser_MouseDown(sender As Object, e As MouseEventArgs) Handles grdDanhsachuser.MouseDown
        Try
            If is_ADD = True Or is_EDIT = True Then
                Dim info As GridHitInfo = grdDanhsachuser.CalcHitInfo(e.Location)
                Try


                    If txtGroupName.Text = "" Then
                        DirectCast(e, DXMouseEventArgs).Handled = True
                    Else
                        DirectCast(e, DXMouseEventArgs).Handled = False
                    End If

                    If info.RowHandle < 0 Then
                        Exit Sub
                    End If
                    If DirectCast(grdDanhsachuser.GetDataRow(info.RowHandle)("GROUP_ID"), Integer) < 0 Then
                        Exit Sub
                    End If
                    'If grdDanhsachuser.GetRowCellValue(info.RowHandle, "USERNAME").ToString().Trim = "" Then
                    '    Exit Sub
                    'End If
                    'If grdDanhsachuser.GetRowCellValue(info.RowHandle, "USERNAME").ToString().Trim <> "" Then
                    '    If CheckUpdateUser(grdDanhsachuser.GetRowCellValue(info.RowHandle, "USERNAME").ToString().Trim) = True Then
                    '        Exit Sub
                    '    End If
                    'End If
                    If (info.Column.Name = "ACTIVE") Then
                        If grdDanhsachuser.GetRowCellValue(info.RowHandle, "USERNAME_OLD").ToString().ToUpper = "ADMINISTRATOR" Then
                            DirectCast(e, DXMouseEventArgs).Handled = True
                        End If
                    End If

                Catch ex As Exception

                    DirectCast(e, DXMouseEventArgs).Handled = True

                End Try
                If Not clNewRowUser.Contains(info.RowHandle) Then
                    If (info.Column.Name = "USERNAME") Then
                        DirectCast(e, DXMouseEventArgs).Handled = True
                    End If
                    'If (info.Column.Name = "FULL_NAME") Then
                    '    DirectCast(e, DXMouseEventArgs).Handled = True
                    'End If
                    'If (info.Column.Name = "ACTIVE") Then
                    '    DirectCast(e, DXMouseEventArgs).Handled = True
                    'End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdDanhsachuser_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grdDanhsachuser.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Function CheckValidData()
        For i As Integer = 0 To grdDanhsachuser.RowCount - 2
            If IsDuplicateUser(grdDanhsachuser.GetRowCellValue(i, "USERNAME").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        Return True
    End Function
    Private Function IsDuplicateUser(ByVal Username As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To grdDanhsachuser.RowCount - 2
                If grdDanhsachuser.GetRowCellValue(i, "USERNAME").ToString().Trim = Username Then
                    dem += 1
                    If dem > 1 Then
                        Return True
                    End If
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub grdDanhsachuser_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grdDanhsachuser.ValidateRow
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim sMaNhom As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("GROUP_ID")
        Dim sTenUser As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("USERNAME")
        Dim sFullName As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("FULL_NAME")

        If View.GetRowCellValue(e.RowHandle, sTenUser).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sTenUser, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenUserNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenUserNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If IsExistsUser(View.GetRowCellValue(e.RowHandle, sMaNhom).ToString().Trim, View.GetRowCellValue(e.RowHandle, sTenUser).ToString().Trim) Then
                e.Valid = False
                View.SetColumnError(sTenUser, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDatontainguoidung", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDatontainguoidung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'If Not Commons.Modules.ObjGroups.CheckExistUserName(View.GetRowCellValue(e.RowHandle, sTenUser).ToString().Trim) Then
            '    e.Valid = False
            '    View.SetColumnError(sTenUser, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrung", Commons.Modules.TypeLanguage))
            '    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        End If
        If View.GetRowCellValue(e.RowHandle, sFullName).ToString() = "" Then

            e.Valid = False
            View.SetColumnError(sFullName, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraFullNameNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraFullNameNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub





    'Private Sub grdListOfGroup_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grdListOfGroup.BeforeLeaveRow
    '    If grdListOfGroup.GetRowCellValue(grdListOfGroup.FocusedRowHandle, "GROUP_ID") <> -1 Then
    '        If is_ADD = True Or is_EDIT = True Then
    '            e.Allow = False
    '        End If
    '    End If
    'End Sub



#End Region
#End Region


#Region "Xu ly Tab Menu"

    Sub CreatechkGiatri11()
        'Dim chkGiatri As New DataGridViewCheckBoxColumn()
        'chkGiatri.Name = "CHON"
        'grdQuyentrenmenu.Columns.Insert(3, chkGiatri)
    End Sub
    Sub HienThi11()
        For i As Integer = 0 To grdQuyentrenmenu.RowCount - 1
            If grdQuyentrenmenu.GetDataRow(i)("GROUP_ID") <> "" Then
                grdQuyentrenmenu.SetRowCellValue(i, "CHON", True)
            End If
        Next
    End Sub
    Sub GiaiMaTable(ByVal sBTamLic As String, ByVal BTam As String, ByVal sCot As String, ByVal GROUP_ID As Integer)
        Dim dtTmpLic As New DataTable
        Dim sTypeLic As String


        sTypeLic = Commons.clsXuLy.MaHoaDL(CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT ISNULL(TYPE_LIC,0) FROM NHOM WHERE GROUP_ID = " & GROUP_ID), Integer).ToString())


        dtTmpLic = New DataTable
        dtTmpLic.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT * FROM " + BTam + " WHERE TYPE_LIC = N'" + sTypeLic + "' "))

        For Each row As DataRow In dtTmpLic.Rows
            row("TYPE_LIC") = Commons.clsXuLy.GiaiMaDL(row("TYPE_LIC").ToString())
            row(sCot) = Commons.clsXuLy.GiaiMaDL(row(sCot).ToString())
        Next

        Commons.Modules.ObjSystems.XoaTable(sBTamLic)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTamLic, dtTmpLic, "")

    End Sub
    Private isAdd_Menu As Boolean = False
    Sub LoadGroupMenu(ByVal GroupID As Integer)
        If isLoadMenu = True Then


            Dim dtTmp As New DataTable

            'If isAdd_Menu = False Then
            '    Try

            '        dtTmp = New Commons.OGroups().GetNHOM_MENU(GroupID, Commons.Modules.TypeLanguage)
            '        dtTmp.Columns("CHON").ReadOnly = False
            '        dtTmp.Columns("IS_UPDATE").ReadOnly = False
            '        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl3, grdQuyentrenmenu, dtTmp, False, False, True, True, True, Name)
            '        grdQuyentrenmenu.Columns("CHON").Width = 80
            '    Catch ex As Exception
            '    End Try
            'Else
            '    Try
            '        dtTmp = New Commons.OGroups().GetMENU_QUYEN(GroupID, Commons.Modules.TypeLanguage)
            '        dtTmp.Columns("CHON").ReadOnly = False
            '        dtTmp.Columns("IS_UPDATE").ReadOnly = False
            '        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl3, grdQuyentrenmenu, dtTmp, True, False, True, True, True, Name)
            '        grdQuyentrenmenu.Columns("CHON").Width = 80
            '    Catch ex As Exception
            '    End Try

            'End If
            dtTmp = New Commons.OGroups().GetMENU_QUYEN(GroupID, Commons.Modules.TypeLanguage)
            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl3, grdQuyentrenmenu, dtTmp, True, False, True, True, True, Name)
            grdQuyentrenmenu.Columns("CHON").Width = 80
            LockGridMenu(True)
            grdQuyentrenmenu.ActiveFilterString = "CHON =1"
            BtnChonAll.Visible = False
            isLoadMenu = False
            grdQuyentrenmenu.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub BtnChonAll_Click(sender As Object, e As EventArgs) Handles BtnChonAll.Click
        For i As Integer = 0 To grdQuyentrenmenu.RowCount - 1
            grdQuyentrenmenu.SetRowCellValue(i, "CHON", True)
            grdQuyentrenmenu.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyentrenmenu.UpdateCurrentRow()

        Next
        GridControl3.Update()
    End Sub

    Private Sub BtnKhongChonAll_Click(sender As Object, e As EventArgs) Handles BtnKhongChonAll.Click
        For i As Integer = 0 To grdQuyentrenmenu.RowCount - 1
            grdQuyentrenmenu.SetRowCellValue(i, "CHON", False)
            grdQuyentrenmenu.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyentrenmenu.UpdateCurrentRow()
        Next
        GridControl3.Update()
        'Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grdQuyentrenmenu)
        'Commons.Modules.ObjSystems.MChooseGrid(True, "IS_UPDATE", grdQuyentrenmenu)

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        CopyPhanQuyen(1, txtGroupID.Text)
        isAdd_Menu = False
        LoadGroupMenu(txtGroupID.Text)
    End Sub
    Private Sub CopyPhanQuyen(ByVal iLoai As Integer, ByVal sDataGoc As String)
        Dim frm = New ReportMain.frmCopyPhanQuyen
        frm.iLoai = iLoai
        frm.sDataGoc = sDataGoc
        frm.ShowDialog()

    End Sub
    Private Sub grdListOfGroup_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grdListOfGroup.RowCellClick
        Try
            txtGroupID.Text = grdListOfGroup.GetDataRow(e.RowHandle)("GROUP_ID")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelectGroup()
        If selGroupID <> -1 Then
            For i As Integer = 0 To grdListOfGroup.RowCount
                If grdListOfGroup.GetRowCellValue(i, "GROUP_ID") = selGroupID Then

                    grdListOfGroup.SelectRow(i)
                    grdListOfGroup.FocusedRowHandle = i
                    'grdListOfGroup.SetFocusedRowModified()
                    Exit Sub
                End If
            Next
        End If
    End Sub
    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Try

            If XtraTabControl1.SelectedTabPage.Name = "TabDSNguoidung" Then
                Commons.Modules.SQLString = "0Load"
                txtFindUser.Text = ""
                LoadListAllUser()
                Commons.Modules.SQLString = ""

                selGroupID = -1
            End If
            If XtraTabControl1.SelectedTabPage.Name = "TabUsergroups" Then
                SelectGroup()
                BindingData()
            End If
            If XtraTabControl1.SelectedTabPage.Name = "TabMenu" Then
                LoadGroupMenu(txtGroupID.Text)
            End If
            If XtraTabControl1.SelectedTabPage.Name = "TabForm" Then
                If XtraTabControl3.SelectedTabPage.Name = "Tab_Form" Then
                    LoadGroupForm(txtGroupID.Text)
                End If
                If XtraTabControl3.SelectedTabPage.Name = "Tab_Report" Then
                    LoadGroupReport(txtGroupID.Text)
                End If
            End If
            If XtraTabControl1.SelectedTabPage.Name = "TabDulieu" Then
                If XtraTabControl2.SelectedTabPage.Name = "TabDiadiemDC" Then
                    LoadDiaDiemDayChuyen(txtGroupID.Text)
                End If
                If XtraTabControl2.SelectedTabPage.Name = "TabLoaiTBBPCP" Then
                    LoadLoaiTB_BPCP(txtGroupID.Text)
                End If
                If XtraTabControl2.SelectedTabPage.Name = "TabLCVVTPT" Then
                    LoadLoaiCV_VTPT(txtGroupID.Text)
                End If
                If XtraTabControl2.SelectedTabPage.Name = "TabKhoPB" Then
                    LoadKho_PhongBan(txtGroupID.Text)
                End If
            End If
            If XtraTabControl1.SelectedTabPage.Name = "TabNguoidung" Then
                Commons.Modules.SQLString = "0Load"
                txtFindUS.Text = ""
                LoadListNguoiDung(txtGroupID.Text)
                ShowThongTinNguoiDung()
                Commons.Modules.SQLString = ""

            End If
            BestFixColumnGrid()
            Commons.Modules.SQLString = ""
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString)
        End Try

    End Sub
    Private Sub VisibleButtonMenu(ByVal TT As Boolean)
        btnKhongM.Visible = Not TT
        btnSaveM.Visible = Not TT
        BtnChonAll.Visible = Not TT
        BtnKhongChonAll.Visible = Not TT
        btnThoatM.Visible = TT
        btnThemSua.Visible = TT

        btnCopy.Visible = TT
    End Sub




    Private Sub LockGridMenu(ByVal TT As Boolean)
        For i As Integer = 0 To grdQuyentrenmenu.Columns.Count - 1
            grdQuyentrenmenu.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdQuyentrenmenu.Columns("MENU_NAME").OptionsColumn.AllowEdit = False
    End Sub
    Private Sub LockGridDiaDiemDC(ByVal TT As Boolean)
        For i As Integer = 0 To grdQuyenTrenKhuVuc.Columns.Count - 1
            grdQuyenTrenKhuVuc.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        For i As Integer = 0 To grdQuyenTrenDayTruyen.Columns.Count - 1
            grdQuyenTrenDayTruyen.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdQuyenTrenKhuVuc.Columns("Ten_N_XUONG").OptionsColumn.AllowEdit = False
        grdQuyenTrenDayTruyen.Columns("TEN_HE_THONG").OptionsColumn.AllowEdit = False
    End Sub
    Private Sub LockGridLTBBPCP(ByVal TT As Boolean)
        For i As Integer = 0 To grdQuyenTrenLoaiMay.Columns.Count - 1
            grdQuyenTrenLoaiMay.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        For i As Integer = 0 To grdDanhsachBPCP.Columns.Count - 1
            grdDanhsachBPCP.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdQuyenTrenLoaiMay.Columns("TEN_LOAI_MAY").OptionsColumn.AllowEdit = False
        grdDanhsachBPCP.Columns("TEN_BP_CHIU_PHI").OptionsColumn.AllowEdit = False
        grdDanhsachBPCP.Columns("TEN_DON_VI").OptionsColumn.AllowEdit = False
    End Sub
    Private Sub LockGridLCVVTPT(ByVal TT As Boolean)
        For i As Integer = 0 To grdQuyenTrenLoaiCongViec.Columns.Count - 1
            grdQuyenTrenLoaiCongViec.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        For i As Integer = 0 To grdQuyenTrennoiSuDungVatTu.Columns.Count - 1
            grdQuyenTrennoiSuDungVatTu.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdQuyenTrenLoaiCongViec.Columns("TEN_LOAI_CV").OptionsColumn.AllowEdit = False
        grdQuyenTrennoiSuDungVatTu.Columns("TEN_LOAI_PT").OptionsColumn.AllowEdit = False

    End Sub

    Private Sub LockGridKhoPB(ByVal TT As Boolean)
        For i As Integer = 0 To grdDanhsachkho.Columns.Count - 1
            grdDanhsachkho.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        For i As Integer = 0 To grdDanhsachNhomPB.Columns.Count - 1
            grdDanhsachNhomPB.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdDanhsachkho.Columns("TEN_KHO").OptionsColumn.AllowEdit = False
        grdDanhsachNhomPB.Columns("TEN_TO").OptionsColumn.AllowEdit = False
        grdDanhsachNhomPB.Columns("TEN_DON_VI").OptionsColumn.AllowEdit = False
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles btnThemSua.Click
        grdQuyentrenmenu.ActiveFilter.Clear()

        isAdd_Menu = True
        'LoadGroupMenu(txtGroupID.Text)
        grdQuyentrenmenu.OptionsBehavior.Editable = True
        grdQuyentrenmenu.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyentrenmenu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonMenu(False)
        LockGridMenu(False)
        grdQuyentrenmenu.Columns("CHON").Visible = True
        LockTab(True)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnKhongM_Click(sender As Object, e As EventArgs) Handles btnKhongM.Click
        isAdd_Menu = False
        isLoadMenu = True
        LoadGroupMenu(txtGroupID.Text)
        grdQuyentrenmenu.OptionsBehavior.Editable = False
        grdQuyentrenmenu.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyentrenmenu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonMenu(True)
        LockGridMenu(True)
        LockTab(False)

        LoadGroupMenu(txtGroupID.Text)

        grdQuyentrenmenu.Columns("CHON").Visible = False
    End Sub

    Private Sub btnThoatM_Click(sender As Object, e As EventArgs) Handles btnThoatM.Click
        Me.Close()
    End Sub

    Private Sub btnSaveM_Click(sender As Object, e As EventArgs) Handles btnSaveM.Click


        Dim dataView As New DataView(DirectCast(GridControl3.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        Dim tbMenu As DataTable = New System.Data.DataTable()
        tbMenu = dataView.ToTable(True, "MENU_ID", "MENU_NAME", "GROUP_ID", "CHON", "IS_UPDATE")

        If SaveMenu(tbMenu) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try
            isAdd_Menu = False
            VisibleButtonMenu(True)

            LoadGroupMenu(txtGroupID.Text)
            grdQuyentrenmenu.ActiveFilterString = "CHON =1"
            LockGridMenu(True)
            LockTab(False)
            grdQuyentrenmenu.Columns("CHON").Visible = False

            SetFormPermission(Me.Name, Commons.Modules.UserName)
        End If
    End Sub
    Public Function SaveMenu(ByVal tbNM As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_MENU")
                If (tbNM IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBNM", tbNM)
                End If

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Private Sub grdQuyentrenmenu_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyentrenmenu.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "MIS_UPDATE" Then

                grdQuyentrenmenu.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Xu ly Tab Form"

    Private Sub LoadGroupForm(ByVal GroupID As Integer)
        If isLoadForm = True Then
            LoadComboQuyen()
            Dim dtTmp As DataTable = New Commons.OGroups().GetCHI_TIET_FORM_QUYEN(GroupID, Commons.Modules.TypeLanguage)
            dtTmp.Columns("QUYEN").ReadOnly = False
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl4, grdDanhsachform, dtTmp, False, False, True, True, True, Name)
            btnDenyAll.Visible = False
            btnReadOnlyAll.Visible = False
            btnFullAccessAll.Visible = False
            isLoadForm = False
        End If
    End Sub
    Public Sub LoadComboQuyen()
        Try

            Dim dt As New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            Dim r As DataRow
            r = dt.NewRow()
            r("ID") = "Read only"
            r("Name") = "Read only"
            dt.Rows.Add(r)
            r = dt.NewRow()
            r("ID") = "No access"
            r("Name") = "No access"
            dt.Rows.Add(r)
            r = dt.NewRow()
            r("ID") = "Full access"
            r("Name") = "Full access"
            dt.Rows.Add(r)

            Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboStatus.NullText = ""
            cboStatus.ValueMember = "ID"
            cboStatus.DisplayMember = "Name"
            cboStatus.DataSource = dt

            cboStatus.Columns.Clear()
            'cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID"))
            cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))

            cboStatus.PopupWidth = 100
            'cboStatus.Columns("ID").Width = 60
            cboStatus.Columns("Name").Width = 180
            cboStatus.DropDownRows = 5
            cboStatus.ShowFooter = False
            cboStatus.ShowHeader = False
            cboStatus.PopupWidth = 100
            grdDanhsachform.Columns("QUYEN").ColumnEdit = cboStatus
        Catch generatedExceptionName As Exception

        Finally
            'GlobalVariables.SqlConnect.Close()
        End Try
    End Sub

    Private Sub btnThemSuaF_Click(sender As Object, e As EventArgs) Handles btnThemSuaF.Click
        grdDanhsachform.OptionsBehavior.Editable = True
        grdDanhsachform.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachform.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonForm(False)
        LockGridForm(False)
        LockTab(True)
    End Sub
    Private Sub VisibleButtonForm(ByVal TT As Boolean)
        btnDenyAll.Visible = Not TT
        btnReadOnlyAll.Visible = Not TT
        btnFullAccessAll.Visible = Not TT
        btnKhongF.Visible = Not TT
        btnSaveF.Visible = Not TT
        btnThoatF.Visible = TT
        btnThemSuaF.Visible = TT
        btnCopyF.Visible = TT
    End Sub
    Private Sub LockGridForm(ByVal TT As Boolean)
        For i As Integer = 0 To grdDanhsachform.Columns.Count - 1
            grdDanhsachform.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdDanhsachform.Columns(1).OptionsColumn.AllowEdit = False
        grdDanhsachform.Columns(1).OptionsColumn.ReadOnly = True
    End Sub

    Private Sub grdDanhsachform_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdDanhsachform.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "FIS_UPDATE" Then

                grdDanhsachform.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReadOnlyAll_Click(sender As Object, e As EventArgs) Handles btnReadOnlyAll.Click
        For i As Integer = 0 To grdDanhsachform.RowCount - 1
            grdDanhsachform.SetRowCellValue(i, "QUYEN", "Read only")
            grdDanhsachform.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachform.UpdateCurrentRow()
        Next
    End Sub

    Private Sub btnDenyAll_Click(sender As Object, e As EventArgs) Handles btnDenyAll.Click
        For i As Integer = 0 To grdDanhsachform.RowCount - 1
            grdDanhsachform.SetRowCellValue(i, "QUYEN", "No access")
            grdDanhsachform.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachform.UpdateCurrentRow()
        Next
    End Sub

    Private Sub btnFullAccessAll_Click(sender As Object, e As EventArgs) Handles btnFullAccessAll.Click
        For i As Integer = 0 To grdDanhsachform.RowCount - 1

            grdDanhsachform.SetRowCellValue(i, "QUYEN", "Full access")
            grdDanhsachform.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachform.UpdateCurrentRow()
        Next
    End Sub

    Private Sub btnKhongF_Click(sender As Object, e As EventArgs) Handles btnKhongF.Click
        isLoadForm = True
        LoadGroupForm(txtGroupID.Text)
        grdDanhsachform.OptionsBehavior.Editable = False
        grdDanhsachform.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachform.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonForm(True)
        LockGridForm(True)
        LockTab(False)
    End Sub

    Private Sub btnSaveF_Click(sender As Object, e As EventArgs) Handles btnSaveF.Click
        GridControl4.Update()
        'Dim dt As New DataTable
        'dt = CType(GridControl4.DataSource, DataTable).Copy
        'dt.DefaultView.RowFilter = "IS_UPDATE =1"
        'dt = dt.DefaultView.ToTable

        Dim dataView As New DataView(DirectCast(GridControl4.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)

        Dim tbForm As DataTable = New System.Data.DataTable()
        tbForm = dataView.ToTable(True, "FORM_NAME", "TEN_FORM", "QUYEN", "IS_UPDATE", "GROUP_ID")

        If SaveGroupForm(tbForm) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonForm(True)
            LoadGroupForm(txtGroupID.Text)
            LockGridForm(True)
            LockTab(False)
            SetFormPermission(Me.Name, Commons.Modules.UserName)
        End If
    End Sub
    Public Function SaveGroupForm(ByVal tbNF As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_FORM")
                If (tbNF IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBNF", tbNF)
                End If

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Private Sub btnThoatF_Click(sender As Object, e As EventArgs) Handles btnThoatF.Click
        Me.Close()
    End Sub

    Private Sub btnCopyF_Click(sender As Object, e As EventArgs) Handles btnCopyF.Click
        CopyPhanQuyen(2, txtGroupID.Text)

    End Sub



#End Region


#Region "Xu ly Tab Report"

    Private Sub XtraTabControl3_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl3.SelectedPageChanged
        If XtraTabControl1.SelectedTabPage.Name = "TabForm" Then
            If XtraTabControl3.SelectedTabPage.Name = "Tab_Form" Then
                LoadGroupForm(txtGroupID.Text)
            End If
            If XtraTabControl3.SelectedTabPage.Name = "Tab_Report" Then
                LoadGroupReport(txtGroupID.Text)
            End If
        End If
    End Sub

    Private Sub cboLoaiBaoCao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLoaiBaoCao.SelectedIndexChanged
        isLoadReport = True
        LoadGroupReport(txtGroupID.Text)
    End Sub

    Private Sub LoadComboLoaiBaoCao()
        Try
            cboLoaiBaoCao.Properties.Items.Clear()
            If Commons.Modules.TypeLanguage = 0 Then
                cboLoaiBaoCao.Properties.Items.Add("<Tất cả>")
                cboLoaiBaoCao.Properties.Items.Add("Thông tin thiết bị")
                cboLoaiBaoCao.Properties.Items.Add("Sử dụng")
                cboLoaiBaoCao.Properties.Items.Add("Bảo trì")
                cboLoaiBaoCao.Properties.Items.Add("Kho")
            Else

                cboLoaiBaoCao.Properties.Items.Add("<" & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Tatca", Commons.Modules.TypeLanguage) & ">")
                cboLoaiBaoCao.Properties.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thongtinthietbi", Commons.Modules.TypeLanguage))
                cboLoaiBaoCao.Properties.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Sudung", Commons.Modules.TypeLanguage))
                cboLoaiBaoCao.Properties.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Baotri", Commons.Modules.TypeLanguage))
                cboLoaiBaoCao.Properties.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Kho", Commons.Modules.TypeLanguage))
            End If
            cboLoaiBaoCao.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadGroupReport(ByVal GroupID As Integer)
        If isLoadReport = True Then
            LoadComboQuyenReport()
            Dim dtTmp As New DataTable
            dtTmp = Commons.Modules.ObjGroups.Get_Danhsachbaocao(Commons.Modules.UserName, txtGroupID.Text, cboLoaiBaoCao.SelectedIndex, Commons.Modules.TypeLanguage)
            dtTmp.Columns("TEN_REPORT").ReadOnly = True
            dtTmp.Columns("QUYEN").ReadOnly = False
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl15, grdListofReport, dtTmp, False, False, True, True, True, Name)
            If cboLoaiBaoCao.SelectedIndex = 0 Then
                If cboLoaiBaoCao.Width = 152 And grdListofReport.RowCount >= 25 Then
                    cboLoaiBaoCao.Left = cboLoaiBaoCao.Left - 18
                    cboLoaiBaoCao.Width = cboLoaiBaoCao.Width + 18
                ElseIf cboLoaiBaoCao.Width > 152 And grdListofReport.RowCount < 25 Then
                    cboLoaiBaoCao.Left = cboLoaiBaoCao.Left + 18
                    cboLoaiBaoCao.Width = cboLoaiBaoCao.Width - 18
                End If
            Else
                If cboLoaiBaoCao.Width > 152 And grdListofReport.RowCount < 25 Then
                    cboLoaiBaoCao.Left = cboLoaiBaoCao.Left + 18
                    cboLoaiBaoCao.Width = cboLoaiBaoCao.Width - 18
                End If
            End If

            btnDenyAllR.Visible = False
            btnFullAccessAllR.Visible = False
            isLoadReport = False
        End If
    End Sub
    Public Sub LoadComboQuyenReport()
        Try

            Dim dt As New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            Dim r As DataRow
            r = dt.NewRow()
            r("ID") = "No access"
            r("Name") = "No access"
            dt.Rows.Add(r)
            r = dt.NewRow()
            r("ID") = "Access"
            r("Name") = "Access"
            dt.Rows.Add(r)

            Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboStatus.NullText = ""
            cboStatus.ValueMember = "ID"
            cboStatus.DisplayMember = "Name"
            cboStatus.DataSource = dt

            cboStatus.Columns.Clear()
            'cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID"))
            cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))

            cboStatus.PopupWidth = 100
            'cboStatus.Columns("ID").Width = 60
            cboStatus.Columns("Name").Width = 180
            cboStatus.DropDownRows = 5
            cboStatus.ShowFooter = False
            cboStatus.ShowHeader = False
            cboStatus.PopupWidth = 100
            grdListofReport.Columns("QUYEN").ColumnEdit = cboStatus
        Catch generatedExceptionName As Exception

        Finally
            'GlobalVariables.SqlConnect.Close()
        End Try
    End Sub

    Private Sub btnThemSuaR_Click(sender As Object, e As EventArgs) Handles btnThemSuaR.Click
        grdListofReport.OptionsBehavior.Editable = True
        grdListofReport.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdListofReport.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonReport(False)
        LockGridReport(False)
        LockTab(True)
        cboLoaiBaoCao.Visible = False
    End Sub
    Private Sub VisibleButtonReport(ByVal TT As Boolean)
        btnDenyAllR.Visible = Not TT
        btnFullAccessAllR.Visible = Not TT
        btnKhongR.Visible = Not TT
        btnSaveR.Visible = Not TT
        btnThoatR.Visible = TT
        btnThemSuaR.Visible = TT
        btnCopyR.Visible = TT
    End Sub
    Private Sub LockGridReport(ByVal TT As Boolean)
        For i As Integer = 0 To grdListofReport.Columns.Count - 1
            grdListofReport.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdListofReport.Columns(1).OptionsColumn.AllowEdit = False

    End Sub

    Private Sub grdListofReport_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdListofReport.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "RIS_UPDATE" Then

                grdListofReport.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnDenyAllR_Click(sender As Object, e As EventArgs) Handles btnDenyAllR.Click
        For i As Integer = 0 To grdListofReport.RowCount - 1
            grdListofReport.SetRowCellValue(i, "QUYEN", "No access")
            grdListofReport.SetRowCellValue(i, "IS_UPDATE", True)
            grdListofReport.UpdateCurrentRow()
        Next
    End Sub

    Private Sub btnFullAccessAllR_Click(sender As Object, e As EventArgs) Handles btnFullAccessAllR.Click
        For i As Integer = 0 To grdListofReport.RowCount - 1

            grdListofReport.SetRowCellValue(i, "QUYEN", "Access")
            grdListofReport.SetRowCellValue(i, "IS_UPDATE", True)
            grdListofReport.UpdateCurrentRow()
        Next
    End Sub

    Private Sub btnKhongR_Click(sender As Object, e As EventArgs) Handles btnKhongR.Click
        isLoadReport = True
        LoadGroupReport(txtGroupID.Text)
        grdListofReport.OptionsBehavior.Editable = False
        grdListofReport.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdListofReport.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonReport(True)
        LockGridReport(True)
        LockTab(False)
        cboLoaiBaoCao.Visible = True
    End Sub

    Private Sub btnSaveR_Click(sender As Object, e As EventArgs) Handles btnSaveR.Click
        GridControl15.Update()
        'Dim dt As New DataTable
        'dt = CType(GridControl4.DataSource, DataTable).Copy
        'dt.DefaultView.RowFilter = "IS_UPDATE =1"
        'dt = dt.DefaultView.ToTable

        Dim dataView As New DataView(DirectCast(GridControl15.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)

        Dim tbForm As DataTable = New System.Data.DataTable()
        tbForm = dataView.ToTable(True, "REPORT_NAME", "TEN_REPORT", "QUYEN", "GROUP_ID", "IS_UPDATE")

        If SaveGroupReport(tbForm) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonReport(True)
            LoadGroupReport(txtGroupID.Text)
            LockGridReport(True)
            LockTab(False)
            cboLoaiBaoCao.Visible = True
        End If
    End Sub
    Public Function SaveGroupReport(ByVal tbNF As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_REPORT")
                If (tbNF IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBNRP", tbNF)
                End If

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Private Sub btnThoatR_Click(sender As Object, e As EventArgs) Handles btnThoatR.Click
        Me.Close()
    End Sub

    Private Sub btnCopyR_Click(sender As Object, e As EventArgs) Handles btnCopyR.Click
        CopyPhanQuyen(11, txtGroupID.Text)
    End Sub



#End Region



#Region "Xu ly form du lieu"


    Private Sub VisibleButtonDiaDiemDC(ByVal TT As Boolean)
        btnCTDC.Visible = Not TT
        btnCTNX.Visible = Not TT
        btnBTDC.Visible = Not TT
        btnBTNX.Visible = Not TT
        btnKhongluuDC.Visible = Not TT
        btnSaveDC.Visible = Not TT
        btnThoatDC.Visible = TT
        btnThemSuaDC.Visible = TT
        btnCopyDC.Visible = TT
        btnCopyNX.Visible = TT
    End Sub
    Private Sub VisibleButtonLTBBPCP(ByVal TT As Boolean)
        btnCTLTB.Visible = Not TT
        btnCTBPCP.Visible = Not TT
        btnBTLTB.Visible = Not TT
        btnBTBPCP.Visible = Not TT
        btnKhongLTBBPCP.Visible = Not TT
        btnSaveLTBBPCP.Visible = Not TT
        btnThoatLTBBPCP.Visible = TT
        btnThemSuaLTBBPCP.Visible = TT
        btnCopyLTB.Visible = TT
        btnCopyBPCP.Visible = TT
    End Sub
    Private Sub VisibleButtonLCVVTPT(ByVal TT As Boolean)
        btnCTLCV.Visible = Not TT
        btnCTVTPT.Visible = Not TT
        btnBTLCV.Visible = Not TT
        btnBTVTPT.Visible = Not TT
        btnKhongLCVVTPT.Visible = Not TT
        btnSaveLCVVTPT.Visible = Not TT
        btnThoatLCVVTPT.Visible = TT
        btnThemSuaLCVVTPT.Visible = TT
        btnCopyLCV.Visible = TT
        btnCopyVTPT.Visible = TT
    End Sub
    Private Sub VisibleButtonKhoPB(ByVal TT As Boolean)
        btnCTKho.Visible = Not TT
        btnCTPB.Visible = Not TT
        btnBTKho.Visible = Not TT
        btnBTPB.Visible = Not TT
        btnKhongKhoPB.Visible = Not TT
        btnSaveKhoPB.Visible = Not TT
        btnThoatKhoPB.Visible = TT
        btnThemSuaKhoPB.Visible = TT
        btnCopyKho.Visible = TT
        btnCopyPB.Visible = TT
    End Sub
    Private Sub LoadDiaDiemDayChuyen(ByVal GroupID As Integer)
        If isLoadDiadiem = True Then
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_NHA_XUONG", GroupID))
            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("MS_N_XUONG").ReadOnly = True
            dtTmp.Columns("TEN_N_XUONG").ReadOnly = True
            dtTmp.Columns("TINH").ReadOnly = True
            dtTmp.Columns("QUAN").ReadOnly = True
            dtTmp.Columns("DIA_CHI").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl5, grdQuyenTrenKhuVuc, dtTmp, False, False, True, True, True, Name)


            Dim sql As String = "SELECT PRIVATE FROM THONG_TIN_CHUNG"
            sql = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            If sql <> "KIDO" Then
                Try
                    grdQuyenTrenKhuVuc.Columns("MS_N_XUONG").Visible = False
                    grdQuyenTrenKhuVuc.Columns("TINH").Visible = False
                    grdQuyenTrenKhuVuc.Columns("QUAN").Visible = False
                    grdQuyenTrenKhuVuc.Columns("DIA_CHI").Visible = False
                Catch ex As Exception

                End Try
            End If


            dtTmp = New Commons.OGroups().GetNHOM_HE_THONG(txtGroupID.Text)
            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_HE_THONG").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl6, grdQuyenTrenDayTruyen, dtTmp, False, False, True, True, True, Name)



            btnCTDC.Visible = False
            btnCTNX.Visible = False
            btnBTDC.Visible = False
            btnBTNX.Visible = False
            isLoadDiadiem = False

            grdQuyenTrenKhuVuc.ActiveFilterString = "CHON =1"
            grdQuyenTrenDayTruyen.ActiveFilterString = "CHON =1"

            grdQuyenTrenKhuVuc.Columns("CHON").Visible = False
            grdQuyenTrenDayTruyen.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub LoadLoaiTB_BPCP(ByVal GroupID As Integer)
        If isLoadLoaiTBBPCP = True Then
            Dim dtTmp As DataTable
            dtTmp = New Commons.OGroups().GetLOAI_MAY_QUYEN(GroupID)

            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_LOAI_MAY").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl7, grdQuyenTrenLoaiMay, dtTmp, False, False, True, True, True, Name)



            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_BO_PHAN_CHIU_PHI_QUYEN", GroupID))
            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_BP_CHIU_PHI").ReadOnly = True
            dtTmp.Columns("TEN_DON_VI").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl8, grdDanhsachBPCP, dtTmp, False, False, True, True, True, Name)



            btnCTBPCP.Visible = False
            btnCTLTB.Visible = False
            btnBTLTB.Visible = False
            btnBTBPCP.Visible = False

            isLoadLoaiTBBPCP = False

            grdQuyenTrenLoaiMay.ActiveFilterString = "CHON =1"
            grdDanhsachBPCP.ActiveFilterString = "CHON =1"

            grdQuyenTrenLoaiMay.Columns("CHON").Visible = False
            grdDanhsachBPCP.Columns("CHON").Visible = False

        End If
    End Sub

    Private Sub LoadLoaiCV_VTPT(ByVal GroupID As Integer)
        If isLoadLoaiCVVTPT = True Then
            Dim dtTmp As DataTable
            dtTmp = New Commons.OGroups().GetLOAI_CONG_VIEC_QUYEN(GroupID)

            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_LOAI_CV").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl9, grdQuyenTrenLoaiCongViec, dtTmp, False, False, True, True, True, Name)



            dtTmp = New Commons.OGroups().GetLOAI_PHU_TUNG_QUYEN(GroupID)

            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_LOAI_PT").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl10, grdQuyenTrennoiSuDungVatTu, dtTmp, False, False, True, True, True, Name)



            btnCTLCV.Visible = False
            btnCTVTPT.Visible = False
            btnBTLCV.Visible = False
            btnBTVTPT.Visible = False

            isLoadLoaiCVVTPT = False

            grdQuyenTrenLoaiCongViec.ActiveFilterString = "CHON =1"
            grdQuyenTrennoiSuDungVatTu.ActiveFilterString = "CHON =1"

            grdQuyenTrenLoaiCongViec.Columns("CHON").Visible = False
            grdQuyenTrennoiSuDungVatTu.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub LoadKho_PhongBan(ByVal GroupID As Integer)
        If isLoadKhoPhongBan = True Then
            Dim dtTmp As DataTable
            dtTmp = New Commons.OGroups().GetLOAI_IC_KHO_QUYEN(GroupID)

            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_KHO").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl11, grdDanhsachkho, dtTmp, False, False, True, True, True, Name)



            dtTmp = New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_TO_PHONG_BAN_QUYEN", GroupID))

            dtTmp.Columns("CHON").ReadOnly = False
            dtTmp.Columns("TEN_TO").ReadOnly = True
            dtTmp.Columns("TEN_DON_VI").ReadOnly = True
            dtTmp.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl12, grdDanhsachNhomPB, dtTmp, False, False, True, True, True, Name)



            btnCTKho.Visible = False
            btnCTPB.Visible = False
            btnBTKho.Visible = False
            btnBTPB.Visible = False

            isLoadKhoPhongBan = False

            grdDanhsachkho.ActiveFilterString = "CHON =1"
            grdDanhsachNhomPB.ActiveFilterString = "CHON =1"
            grdDanhsachkho.Columns("CHON").Visible = False
            grdDanhsachNhomPB.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub XtraTabControl2_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl2.SelectedPageChanged
        If XtraTabControl2.SelectedTabPage.Name = "TabDiadiemDC" Then
            LoadDiaDiemDayChuyen(txtGroupID.Text)
        End If
        If XtraTabControl2.SelectedTabPage.Name = "TabLoaiTBBPCP" Then
            LoadLoaiTB_BPCP(txtGroupID.Text)
        End If
        If XtraTabControl2.SelectedTabPage.Name = "TabLCVVTPT" Then
            LoadLoaiCV_VTPT(txtGroupID.Text)
        End If
        If XtraTabControl2.SelectedTabPage.Name = "TabKhoPB" Then
            LoadKho_PhongBan(txtGroupID.Text)
        End If
    End Sub

    Private Sub btnThoatDC_Click(sender As Object, e As EventArgs) Handles btnThoatDC.Click
        Me.Close()
    End Sub

    Private Sub btnThemSuaDC_Click(sender As Object, e As EventArgs) Handles btnThemSuaDC.Click
        grdQuyenTrenKhuVuc.ActiveFilter.Clear()
        grdQuyenTrenDayTruyen.ActiveFilter.Clear()

        grdQuyenTrenKhuVuc.OptionsBehavior.Editable = True
        grdQuyenTrenKhuVuc.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenKhuVuc.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdQuyenTrenDayTruyen.OptionsBehavior.Editable = True
        grdQuyenTrenDayTruyen.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenDayTruyen.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdQuyenTrenKhuVuc.Columns("CHON").Visible = True
        grdQuyenTrenDayTruyen.Columns("CHON").Visible = True

        VisibleButtonDiaDiemDC(False)
        LockGridDiaDiemDC(False)
        LockTab(True)
    End Sub

    Public Function SaveDiaDiemDC(ByVal tbNX As DataTable, ByVal tbDC As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_NXDC")
                If (tbNX IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBNX", tbNX)
                End If
                If (tbDC IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBDC", tbDC)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function SaveLTBBPCP(ByVal tbLTB As DataTable, ByVal tbBPCP As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_LTB_BPCP")
                If (tbLTB IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBLTB", tbLTB)
                End If
                If (tbBPCP IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBBPCP", tbBPCP)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Public Function SaveLCVVTPT(ByVal tbLCV As DataTable, ByVal tbVTPT As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_LCV_VTPT")
                If (tbLCV IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBLCV", tbLCV)
                End If
                If (tbVTPT IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBVTPT", tbVTPT)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Public Function SaveKhoPB(ByVal TBNK As DataTable, ByVal TBPB As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_KHO_PB")
                If (TBNK IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBNK", TBNK)
                End If
                If (TBPB IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBPB", TBPB)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_NHOM"
                sqlcom.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Private Sub btnSaveDC_Click(sender As Object, e As EventArgs) Handles btnSaveDC.Click
        Dim dataView As New DataView(DirectCast(GridControl5.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        Dim tbNX As DataTable = New System.Data.DataTable()
        Dim tbDC As DataTable = New System.Data.DataTable()
        tbNX = dataView.ToTable(True, "MS_N_XUONG", "Ten_N_XUONG", "DIA_CHI", "QUAN", "TINH", "GROUP_ID", "CHON", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl6.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        tbDC = dataView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG", "GROUP_ID", "CHON", "IS_UPDATE")


        If SaveDiaDiemDC(tbNX, tbDC) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonDiaDiemDC(True)

            LoadDiaDiemDayChuyen(txtGroupID.Text)
            LockGridDiaDiemDC(True)
            LockTab(False)

            grdQuyenTrenKhuVuc.ActiveFilterString = "CHON =1"
            grdQuyenTrenDayTruyen.ActiveFilterString = "CHON =1"
            grdQuyenTrenKhuVuc.Columns("CHON").Visible = False
            grdQuyenTrenDayTruyen.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub btnCTNX_Click(sender As Object, e As EventArgs) Handles btnCTNX.Click
        For i As Integer = 0 To grdQuyenTrenKhuVuc.RowCount - 1
            grdQuyenTrenKhuVuc.SetRowCellValue(i, "CHON", True)
            grdQuyenTrenKhuVuc.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenKhuVuc.UpdateCurrentRow()

        Next
        GridControl5.Update()
    End Sub

    Private Sub btnBTNX_Click(sender As Object, e As EventArgs) Handles btnBTNX.Click
        For i As Integer = 0 To grdQuyenTrenKhuVuc.RowCount - 1
            grdQuyenTrenKhuVuc.SetRowCellValue(i, "CHON", False)
            grdQuyenTrenKhuVuc.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenKhuVuc.UpdateCurrentRow()

        Next
        GridControl5.Update()
    End Sub

    Private Sub btnCopyNX_Click(sender As Object, e As EventArgs) Handles btnCopyNX.Click
        CopyPhanQuyen(3, txtGroupID.Text)
    End Sub

    Private Sub btnCTDC_Click(sender As Object, e As EventArgs) Handles btnCTDC.Click
        For i As Integer = 0 To grdQuyenTrenDayTruyen.RowCount - 1
            grdQuyenTrenDayTruyen.SetRowCellValue(i, "CHON", True)
            grdQuyenTrenDayTruyen.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenDayTruyen.UpdateCurrentRow()

        Next
        GridControl6.Update()
    End Sub

    Private Sub btnBTDC_Click(sender As Object, e As EventArgs) Handles btnBTDC.Click
        For i As Integer = 0 To grdQuyenTrenDayTruyen.RowCount - 1
            grdQuyenTrenDayTruyen.SetRowCellValue(i, "CHON", False)
            grdQuyenTrenDayTruyen.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenDayTruyen.UpdateCurrentRow()

        Next
        GridControl6.Update()
    End Sub

    Private Sub btnKhongluuDC_Click(sender As Object, e As EventArgs) Handles btnKhongluuDC.Click
        grdQuyenTrenKhuVuc.OptionsBehavior.Editable = True
        grdQuyenTrenKhuVuc.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenKhuVuc.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdQuyenTrenDayTruyen.OptionsBehavior.Editable = True
        grdQuyenTrenDayTruyen.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenDayTruyen.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonDiaDiemDC(True)
        LockGridDiaDiemDC(True)
        LockTab(False)
        isLoadDiadiem = True
        LoadDiaDiemDayChuyen(txtGroupID.Text)
        grdQuyenTrenKhuVuc.ActiveFilterString = "CHON =1"
        grdQuyenTrenDayTruyen.ActiveFilterString = "CHON =1"
        grdQuyenTrenKhuVuc.Columns("CHON").Visible = False
        grdQuyenTrenDayTruyen.Columns("CHON").Visible = False
    End Sub

    Private Sub grdQuyenTrenKhuVuc_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyenTrenKhuVuc.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "NXIS_UPDATE" Then

                grdQuyenTrenKhuVuc.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdQuyenTrenDayTruyen_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyenTrenDayTruyen.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "DCIS_UPDATE" Then

                grdQuyenTrenDayTruyen.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCopyDC_Click(sender As Object, e As EventArgs) Handles btnCopyDC.Click
        CopyPhanQuyen(4, txtGroupID.Text)
    End Sub

    Private Sub btnKhongLTBBPCP_Click(sender As Object, e As EventArgs) Handles btnKhongLTBBPCP.Click
        grdQuyenTrenLoaiMay.OptionsBehavior.Editable = True
        grdQuyenTrenLoaiMay.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenLoaiMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdDanhsachBPCP.OptionsBehavior.Editable = True
        grdDanhsachBPCP.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachBPCP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonLTBBPCP(True)
        LockGridLTBBPCP(True)
        LockTab(False)
        isLoadLoaiTBBPCP = True
        LoadLoaiTB_BPCP(txtGroupID.Text)
        grdQuyenTrenLoaiMay.Columns("CHON").Visible = False
        grdDanhsachBPCP.Columns("CHON").Visible = False
    End Sub

    Private Sub btnThemSuaLTBBPCP_Click(sender As Object, e As EventArgs) Handles btnThemSuaLTBBPCP.Click
        grdQuyenTrenLoaiMay.ActiveFilter.Clear()
        grdDanhsachBPCP.ActiveFilter.Clear()

        grdQuyenTrenLoaiMay.OptionsBehavior.Editable = True
        grdQuyenTrenLoaiMay.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenLoaiMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdDanhsachBPCP.OptionsBehavior.Editable = True
        grdDanhsachBPCP.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachBPCP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonLTBBPCP(False)
        LockGridLTBBPCP(False)
        LockTab(True)
        grdQuyenTrenLoaiMay.Columns("CHON").Visible = True
        grdDanhsachBPCP.Columns("CHON").Visible = True
    End Sub

    Private Sub btnThoatLTBBPCP_Click(sender As Object, e As EventArgs) Handles btnThoatLTBBPCP.Click
        Me.Close()
    End Sub

    Private Sub btnCTLTB_Click(sender As Object, e As EventArgs) Handles btnCTLTB.Click
        For i As Integer = 0 To grdQuyenTrenLoaiMay.RowCount - 1
            grdQuyenTrenLoaiMay.SetRowCellValue(i, "CHON", True)
            grdQuyenTrenLoaiMay.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenLoaiMay.UpdateCurrentRow()

        Next
        GridControl7.Update()
    End Sub

    Private Sub btnBTLTB_Click(sender As Object, e As EventArgs) Handles btnBTLTB.Click
        For i As Integer = 0 To grdQuyenTrenLoaiMay.RowCount - 1
            grdQuyenTrenLoaiMay.SetRowCellValue(i, "CHON", False)
            grdQuyenTrenLoaiMay.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenLoaiMay.UpdateCurrentRow()

        Next
        GridControl7.Update()
    End Sub

    Private Sub btnCTBPCP_Click(sender As Object, e As EventArgs) Handles btnCTBPCP.Click
        For i As Integer = 0 To grdDanhsachBPCP.RowCount - 1
            grdDanhsachBPCP.SetRowCellValue(i, "CHON", True)
            grdDanhsachBPCP.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachBPCP.UpdateCurrentRow()

        Next
        GridControl8.Update()
    End Sub

    Private Sub btnBTBPCP_Click(sender As Object, e As EventArgs) Handles btnBTBPCP.Click
        For i As Integer = 0 To grdDanhsachBPCP.RowCount - 1
            grdDanhsachBPCP.SetRowCellValue(i, "CHON", False)
            grdDanhsachBPCP.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachBPCP.UpdateCurrentRow()

        Next
        GridControl8.Update()
    End Sub

    Private Sub btnSaveLTBBPCP_Click(sender As Object, e As EventArgs) Handles btnSaveLTBBPCP.Click
        Dim dataView As New DataView(DirectCast(GridControl7.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        Dim tbLTB As DataTable = New System.Data.DataTable()
        Dim tbBPCP As DataTable = New System.Data.DataTable()
        tbLTB = dataView.ToTable(True, "MS_LOAI_MAY", "TEN_LOAI_MAY", "GROUP_ID", "CHON", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl8.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        tbBPCP = dataView.ToTable(True, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "TEN_DON_VI", "GROUP_ID", "CHON", "IS_UPDATE")


        If SaveLTBBPCP(tbLTB, tbBPCP) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonLTBBPCP(True)

            LoadLoaiTB_BPCP(txtGroupID.Text)
            LockGridLTBBPCP(True)
            LockTab(False)

            grdQuyenTrenLoaiMay.ActiveFilterString = "CHON =1"
            grdDanhsachBPCP.ActiveFilterString = "CHON =1"
            grdQuyenTrenLoaiMay.Columns("CHON").Visible = False
            grdDanhsachBPCP.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub grdQuyenTrenLoaiMay_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyenTrenLoaiMay.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "LTBIS_UPDATE" Then

                grdQuyenTrenLoaiMay.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachBPCP_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdDanhsachBPCP.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "BPCPIS_UPDATE" Then

                grdDanhsachBPCP.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCopyLTB_Click(sender As Object, e As EventArgs) Handles btnCopyLTB.Click
        CopyPhanQuyen(5, txtGroupID.Text)
    End Sub

    Private Sub btnCopyBPCP_Click(sender As Object, e As EventArgs) Handles btnCopyBPCP.Click
        CopyPhanQuyen(13, txtGroupID.Text)
    End Sub

    Private Sub btnThemSuaLCVVTPT_Click(sender As Object, e As EventArgs) Handles btnThemSuaLCVVTPT.Click
        grdQuyenTrenLoaiCongViec.ActiveFilter.Clear()
        grdQuyenTrennoiSuDungVatTu.ActiveFilter.Clear()

        grdQuyenTrenLoaiCongViec.OptionsBehavior.Editable = True
        grdQuyenTrenLoaiCongViec.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenLoaiCongViec.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdQuyenTrennoiSuDungVatTu.OptionsBehavior.Editable = True
        grdQuyenTrennoiSuDungVatTu.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrennoiSuDungVatTu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonLCVVTPT(False)
        LockGridLCVVTPT(False)
        LockTab(True)
        grdQuyenTrenLoaiCongViec.Columns("CHON").Visible = True
        grdQuyenTrennoiSuDungVatTu.Columns("CHON").Visible = True
    End Sub

    Private Sub btnKhongLCVVTPT_Click(sender As Object, e As EventArgs) Handles btnKhongLCVVTPT.Click
        isLoadLoaiCVVTPT = True
        grdQuyenTrenLoaiCongViec.ActiveFilter.Clear()
        grdQuyenTrennoiSuDungVatTu.ActiveFilter.Clear()

        grdQuyenTrenLoaiCongViec.OptionsBehavior.Editable = True
        grdQuyenTrenLoaiCongViec.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrenLoaiCongViec.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdQuyenTrennoiSuDungVatTu.OptionsBehavior.Editable = True
        grdQuyenTrennoiSuDungVatTu.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdQuyenTrennoiSuDungVatTu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        LoadLoaiCV_VTPT(txtGroupID.Text)
        VisibleButtonLCVVTPT(True)
        LockGridLCVVTPT(True)
        LockTab(False)
        grdQuyenTrenLoaiCongViec.Columns("CHON").Visible = False
        grdQuyenTrennoiSuDungVatTu.Columns("CHON").Visible = False
    End Sub

    Private Sub btnThoatLCVVTPT_Click(sender As Object, e As EventArgs) Handles btnThoatLCVVTPT.Click
        Me.Close()
    End Sub

    Private Sub btnCTLCV_Click(sender As Object, e As EventArgs) Handles btnCTLCV.Click
        For i As Integer = 0 To grdQuyenTrenLoaiCongViec.RowCount - 1
            grdQuyenTrenLoaiCongViec.SetRowCellValue(i, "CHON", True)
            grdQuyenTrenLoaiCongViec.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenLoaiCongViec.UpdateCurrentRow()

        Next
        GridControl9.Update()
    End Sub

    Private Sub btnBTLCV_Click(sender As Object, e As EventArgs) Handles btnBTLCV.Click
        For i As Integer = 0 To grdQuyenTrenLoaiCongViec.RowCount - 1
            grdQuyenTrenLoaiCongViec.SetRowCellValue(i, "CHON", False)
            grdQuyenTrenLoaiCongViec.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrenLoaiCongViec.UpdateCurrentRow()

        Next
        GridControl9.Update()
    End Sub

    Private Sub btnCTVTPT_Click(sender As Object, e As EventArgs) Handles btnCTVTPT.Click
        For i As Integer = 0 To grdQuyenTrennoiSuDungVatTu.RowCount - 1
            grdQuyenTrennoiSuDungVatTu.SetRowCellValue(i, "CHON", True)
            grdQuyenTrennoiSuDungVatTu.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrennoiSuDungVatTu.UpdateCurrentRow()

        Next
        GridControl10.Update()
    End Sub

    Private Sub btnBTVTPT_Click(sender As Object, e As EventArgs) Handles btnBTVTPT.Click
        For i As Integer = 0 To grdQuyenTrennoiSuDungVatTu.RowCount - 1
            grdQuyenTrennoiSuDungVatTu.SetRowCellValue(i, "CHON", False)
            grdQuyenTrennoiSuDungVatTu.SetRowCellValue(i, "IS_UPDATE", True)
            grdQuyenTrennoiSuDungVatTu.UpdateCurrentRow()

        Next
        GridControl10.Update()
    End Sub

    Private Sub grdQuyenTrenLoaiCongViec_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyenTrenLoaiCongViec.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "LCVIS_UPDATE" Then

                grdQuyenTrenLoaiCongViec.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdQuyenTrennoiSuDungVatTu_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdQuyenTrennoiSuDungVatTu.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "VTPTIS_UPDATE" Then

                grdQuyenTrennoiSuDungVatTu.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveLCVVTPT_Click(sender As Object, e As EventArgs) Handles btnSaveLCVVTPT.Click
        Dim dataView As New DataView(DirectCast(GridControl9.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        Dim tbLCV As DataTable = New System.Data.DataTable()
        Dim tbVTPT As DataTable = New System.Data.DataTable()
        tbLCV = dataView.ToTable(True, "MS_LOAI_CV", "TEN_LOAI_CV", "GROUP_ID", "CHON", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl10.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        tbVTPT = dataView.ToTable(True, "MS_LOAI_PT", "TEN_LOAI_PT", "GROUP_ID", "CHON", "IS_UPDATE")


        If SaveLCVVTPT(tbLCV, tbVTPT) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonLCVVTPT(True)

            LoadLoaiCV_VTPT(txtGroupID.Text)
            LockGridLCVVTPT(True)
            LockTab(False)

            grdQuyenTrenLoaiCongViec.ActiveFilterString = "CHON =1"
            grdQuyenTrennoiSuDungVatTu.ActiveFilterString = "CHON =1"
            grdQuyenTrenLoaiCongViec.Columns("CHON").Visible = False
            grdQuyenTrennoiSuDungVatTu.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub btnCopyLCV_Click(sender As Object, e As EventArgs) Handles btnCopyLCV.Click
        CopyPhanQuyen(6, txtGroupID.Text)
    End Sub

    Private Sub btnCopyVTPT_Click(sender As Object, e As EventArgs) Handles btnCopyVTPT.Click
        CopyPhanQuyen(7, txtGroupID.Text)
    End Sub

#End Region
    Private Sub BestFixColumnGrid()
        grdQuyenTrenLoaiCongViec.BestFitColumns()
        grdQuyenTrennoiSuDungVatTu.BestFitColumns()
        grdQuyenTrenLoaiMay.BestFitColumns()
        grdDanhsachBPCP.BestFitColumns()

        grdQuyenTrenKhuVuc.BestFitColumns()
        grdQuyenTrenDayTruyen.BestFitColumns()
        grdDanhsachkho.BestFitColumns()
        grdDanhsachNhomPB.BestFitColumns()
    End Sub

    Private Sub XtraTabControl2_Click(sender As Object, e As EventArgs) Handles XtraTabControl2.Click

    End Sub

    Private Sub btnThemSuaKhoPB_Click(sender As Object, e As EventArgs) Handles btnThemSuaKhoPB.Click
        grdDanhsachkho.ActiveFilter.Clear()
        grdDanhsachNhomPB.ActiveFilter.Clear()

        grdDanhsachkho.OptionsBehavior.Editable = True
        grdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachkho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdDanhsachNhomPB.OptionsBehavior.Editable = True
        grdDanhsachNhomPB.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachNhomPB.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonKhoPB(False)
        LockGridKhoPB(False)
        LockTab(True)
        grdDanhsachkho.Columns("CHON").Visible = True
        grdDanhsachNhomPB.Columns("CHON").Visible = True
    End Sub

    Private Sub btnKhongKhoPB_Click(sender As Object, e As EventArgs) Handles btnKhongKhoPB.Click
        isLoadKhoPhongBan = True
        grdDanhsachkho.ActiveFilter.Clear()
        grdDanhsachNhomPB.ActiveFilter.Clear()

        grdDanhsachkho.OptionsBehavior.Editable = True
        grdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachkho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        grdDanhsachNhomPB.OptionsBehavior.Editable = True
        grdDanhsachNhomPB.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachNhomPB.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        LoadKho_PhongBan(txtGroupID.Text)
        VisibleButtonKhoPB(True)
        LockGridKhoPB(True)
        LockTab(False)
        grdDanhsachkho.Columns("CHON").Visible = False
        grdDanhsachNhomPB.Columns("CHON").Visible = False
    End Sub

    Private Sub btnCTKho_Click(sender As Object, e As EventArgs) Handles btnCTKho.Click
        For i As Integer = 0 To grdDanhsachkho.RowCount - 1
            grdDanhsachkho.SetRowCellValue(i, "CHON", True)
            grdDanhsachkho.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachkho.UpdateCurrentRow()
        Next
        GridControl11.Update()
    End Sub

    Private Sub btnBTKho_Click(sender As Object, e As EventArgs) Handles btnBTKho.Click
        For i As Integer = 0 To grdDanhsachkho.RowCount - 1
            grdDanhsachkho.SetRowCellValue(i, "CHON", False)
            grdDanhsachkho.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachkho.UpdateCurrentRow()
        Next
        GridControl11.Update()
    End Sub

    Private Sub btnCTPB_Click(sender As Object, e As EventArgs) Handles btnCTPB.Click
        For i As Integer = 0 To grdDanhsachNhomPB.RowCount - 1
            grdDanhsachNhomPB.SetRowCellValue(i, "CHON", True)
            grdDanhsachNhomPB.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachNhomPB.UpdateCurrentRow()
        Next
        GridControl12.Update()
    End Sub

    Private Sub btnBTPB_Click(sender As Object, e As EventArgs) Handles btnBTPB.Click
        For i As Integer = 0 To grdDanhsachNhomPB.RowCount - 1
            grdDanhsachNhomPB.SetRowCellValue(i, "CHON", False)
            grdDanhsachNhomPB.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachNhomPB.UpdateCurrentRow()
        Next
        GridControl12.Update()
    End Sub

    Private Sub btnCopyKho_Click(sender As Object, e As EventArgs) Handles btnCopyKho.Click
        CopyPhanQuyen(8, txtGroupID.Text)
    End Sub

    Private Sub btnCopyPB_Click(sender As Object, e As EventArgs) Handles btnCopyPB.Click
        CopyPhanQuyen(9, txtGroupID.Text)
    End Sub

    Private Sub btnThoatKhoPB_Click(sender As Object, e As EventArgs) Handles btnThoatKhoPB.Click
        Me.Close()
    End Sub

    Private Sub btnSaveKhoPB_Click(sender As Object, e As EventArgs) Handles btnSaveKhoPB.Click
        Dim dataView As New DataView(DirectCast(GridControl11.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        Dim tbKHO As DataTable = New System.Data.DataTable()
        Dim tbPB As DataTable = New System.Data.DataTable()
        tbKHO = dataView.ToTable(True, "MS_KHO", "TEN_KHO", "GROUP_ID", "CHON", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl12.DataSource, DataTable), "IS_UPDATE =1", "", DataViewRowState.CurrentRows)
        tbPB = dataView.ToTable(True, "MS_TO", "TEN_DON_VI", "TEN_TO", "GROUP_ID", "CHON", "IS_UPDATE")


        If SaveKhoPB(tbKHO, tbPB) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try

            VisibleButtonKhoPB(True)

            LoadKho_PhongBan(txtGroupID.Text)
            LockGridKhoPB(True)
            LockTab(False)

            grdDanhsachkho.ActiveFilterString = "CHON =1"
            grdDanhsachNhomPB.ActiveFilterString = "CHON =1"
            grdDanhsachkho.Columns("CHON").Visible = False
            grdDanhsachNhomPB.Columns("CHON").Visible = False
        End If
    End Sub

    Private Sub grdDanhsachkho_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdDanhsachkho.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "KHOIS_UPDATE" Then

                grdDanhsachkho.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachNhomPB_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdDanhsachNhomPB.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "PBIS_UPDATE" Then

                grdDanhsachNhomPB.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub
#Region "Xu ly Tab nguoi dung"

    Private Sub LookUpEdit_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCNhan.Popup, cmbDepartment.Popup

        'Dim lookUpEdit As LookUpEdit = TryCast(sender, LookUpEdit)
        'If lookUpEdit Is Nothing Then
        '    Return
        'End If
        'Dim columns As DevExpress.XtraEditors.Controls.LookUpColumnInfoCollection = lookUpEdit.Properties.Columns
        'ChangeColumnCaption(lookUpEdit.Name, columns)

    End Sub

    Private Sub ChangeColumnCaption(ByVal LookupName As String, ByVal columns As DevExpress.XtraEditors.Controls.LookUpColumnInfoCollection)

        If columns.Count < 0 Then
            Return
        End If
        'Change a required column's name
        If LookupName = "cmbDepartment" Then
            columns("MS_TO").Alignment = HorzAlignment.Center

            columns("MS_TO").Width = 80
            columns("TEN_TO").Width = 220
            If Commons.Modules.TypeLanguage = 1 Then
                columns("MS_TO").Caption = "Code"
                columns("TEN_TO").Caption = "Name"
            Else
                columns("MS_TO").Caption = "Mã"
                columns("TEN_TO").Caption = "Tên"
            End If
        End If
        If LookupName = "cmbCNhan" Then
            columns("MS_CONG_NHAN").Alignment = HorzAlignment.Center
            columns("MS_CONG_NHAN").Width = 80
            columns("FULL_NAME").Width = 220
            If Commons.Modules.TypeLanguage = 1 Then
                columns("MS_CONG_NHAN").Caption = "Code"
                columns("FULL_NAME").Caption = "Name"
            Else
                columns("MS_CONG_NHAN").Caption = "Mã"
                columns("FULL_NAME").Caption = "Tên"
            End If

        End If

    End Sub


    Sub LoadListNguoiDung(ByVal intGroupID As Integer)
        Try

            Dim dtTmp As New DataTable
            Try
                Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                    Dim sqlcom As SqlCommand = con.CreateCommand()
                    Try
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        sqlcom.Connection = con

                        sqlcom.Parameters.AddWithValue("ACTION", "LOAD_USERS")
                        sqlcom.Parameters.AddWithValue("GROUP_ID", intGroupID)
                        sqlcom.CommandType = CommandType.StoredProcedure
                        sqlcom.CommandText = "SP_NHOM"
                        Dim da As New SqlDataAdapter(sqlcom)
                        da.Fill(dtTmp)

                    Catch ex As Exception

                    Finally
                        con.Close()
                    End Try
                End Using
            Catch ex As Exception
            End Try
            Try
                grdDanhsachusers.Columns("USERNAME").FilterInfo = New ColumnFilterInfo("")
            Catch ex As Exception

            End Try
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl17, grdDanhsachusers, dtTmp, False, False, True, True, True, Name)
            grdDanhsachusers.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdDanhsachusers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            grdDanhsachusers.MoveFirst()
            LockGrid(grdDanhsachusers, True)
            grdDanhsachusers.BestFitColumns()
            btnCTChucnang.Visible = False
            btnBTChucnang.Visible = False

            grdDanhsachusers.OptionsView.ShowIndicator = True
            grdDanhsachusers.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedCell = False
            grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedRow = True
            grdDanhsachusers.OptionsSelection.EnableAppearanceHideSelection = True
        Catch ex As Exception

        End Try
    End Sub
    Sub ShowThongTinNguoiDung()


        If is_ADD = False And is_EDIT = False Then
            Try
                ClearScreen()

                txtTenUser.Text = grdDanhsachusers.GetFocusedRowCellValue("USERNAME").ToString()
                If txtTenUser.Text.ToUpper = "ADMINISTRATOR" Or txtTenUser.Text.ToUpper = "ADMIN" Then
                    If txtTenUser.Text.ToUpper <> "ADMINISTRATOR" And txtTenUser.Text.ToUpper <> "ADMIN" Then
                        ReadonlyControl(True)
                        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = False
                        btnCopyND.Visible = False
                        btnChuyennhom.Visible = False
                        btnThemND.Visible = False
                        btnSuaND.Visible = False
                        btnXoaND.Visible = False
                        chkActive.Checked = True

                    Else


                        ReadonlyControl(False)
                        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = True
                        btnCopyND.Visible = True
                        btnChuyennhom.Visible = True
                        btnThemND.Visible = True
                        btnSuaND.Visible = True
                        btnXoaND.Visible = True
                    End If
                End If
                Try
                    chkActive.Checked = grdDanhsachusers.GetFocusedRowCellValue("ACTIVE").ToString()
                Catch ex As Exception

                End Try

                txtFullName.Text = grdDanhsachusers.GetFocusedRowCellValue("FULL_NAME").ToString()
                txtDescription5.Text = grdDanhsachusers.GetFocusedRowCellValue("DESCRIPTION").ToString()
                txtMail.Text = grdDanhsachusers.GetFocusedRowCellValue("USER_MAIL").ToString()
                If grdDanhsachusers.GetFocusedRowCellValue("MS_TO").ToString() = "" Then
                    cmbDepartment.EditValue = Nothing
                Else
                    cmbDepartment.EditValue = grdDanhsachusers.GetFocusedRowCellValue("MS_TO")
                End If
                If grdDanhsachusers.GetFocusedRowCellValue("MS_CONG_NHAN").ToString() = "" Then
                    cmbCNhan.EditValue = Nothing
                Else
                    cmbCNhan.EditValue = grdDanhsachusers.GetFocusedRowCellValue("MS_CONG_NHAN")
                End If

                txtPassword.Text = Commons.clsXuLy.GiaiMaDL(grdDanhsachusers.GetFocusedRowCellValue("PASS").ToString())
                txtComfirmPassword.Text = Commons.clsXuLy.GiaiMaDL(grdDanhsachusers.GetFocusedRowCellValue("PASS").ToString())
                ReadonlyControl(True)
            Catch ex As Exception

            End Try

            LoadDanhSachUserQuyen(txtTenUser.Text)
        End If


    End Sub

    Private Sub LoadDanhSachUserQuyenDefault()
        Dim dtTmp As DataTable = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.StoredProcedure, "GetCHUC_NANG_QUYEN_DEFAULT", Nothing))
        dtTmp.Columns("CHON").ReadOnly = False
        dtTmp.Columns("IS_UPDATE").ReadOnly = False
        dtTmp.Columns("MT_CN").ReadOnly = True
        dtTmp.Columns("TEN_CHUC_NANG").ReadOnly = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl14, grdDanhsachQuyenxetduyet, dtTmp, False, False, True, True, True, Name)
        grdDanhsachQuyenxetduyet.BestFitColumns()
        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = True
        grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = True
        grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachQuyenxetduyet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
    End Sub
    Private Sub LoadDanhSachUserQuyen(ByVal username As String)
        Dim dtTmp As DataTable = New DataTable
        dtTmp = New Commons.OGroups().GetCHUC_NANG_QUYEN(username)
        dtTmp.Columns("CHON").ReadOnly = False
        dtTmp.Columns("IS_UPDATE").ReadOnly = False
        dtTmp.Columns("MT_CN").ReadOnly = True
        dtTmp.Columns("TEN_CHUC_NANG").ReadOnly = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl14, grdDanhsachQuyenxetduyet, dtTmp, False, False, True, True, True, Name)
        grdDanhsachQuyenxetduyet.BestFitColumns()
        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = False
        grdDanhsachQuyenxetduyet.ActiveFilterString = "CHON =1"
        'btnDenyAll.Visible = False
        'btnReadOnlyAll.Visible = False
        'btnFullAccessAll.Visible = False
    End Sub
    Private Sub grdDanhsachusers_RowClick(sender As Object, e As RowClickEventArgs) Handles grdDanhsachusers.RowClick
        ShowThongTinNguoiDung()
    End Sub

    Private Sub grdDanhsachusers_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles grdDanhsachusers.SelectionChanged
        ShowThongTinNguoiDung()
    End Sub

    Private Sub grdDanhsachusers_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles grdDanhsachusers.FocusedRowChanged
        ShowThongTinNguoiDung()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles btnCTChucnang.Click
        For i As Integer = 0 To grdDanhsachQuyenxetduyet.RowCount - 1
            grdDanhsachQuyenxetduyet.SetRowCellValue(i, "CHON", True)
            grdDanhsachQuyenxetduyet.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachQuyenxetduyet.UpdateCurrentRow()

        Next
        GridControl17.Update()
    End Sub
    Function CheckUserExist(ByVal USERNAME As String) As String
        Try
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUSERNAMEExist", USERNAME))
            If dt.Rows.Count > 0 Then
                If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return True
        End Try

    End Function
    Function fnCheckUserExist(ByVal USERNAME As String) As String
        Try
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM USERS WHERE USERNAME ='" & USERNAME & "'"))
            If dt.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub btnSuaND_Click(sender As Object, e As EventArgs) Handles btnSuaND.Click
        is_EDIT = True
        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = True
        grdDanhsachQuyenxetduyet.ActiveFilter.Clear()

        grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = True
        grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachQuyenxetduyet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonUserCN(False)
        LockGridFormND(False)
        LockTab(True)
        ReadonlyControl(False)
        txtTenUser.Properties.ReadOnly = True
        If CheckUserExist(txtTenUser.Text.Trim) = False Or Commons.Modules.ObjGroups.CheckUSER_CHUCNANG(txtTenUser.Text.Trim) Then
            txtTenUser.Properties.ReadOnly = True
            'txtFullName.Properties.ReadOnly = True
        End If
        If txtTenUser.Text.ToUpper = "ADMINISTRATOR" Or txtTenUser.Text.ToUpper = "ADMIN" Then
            chkActive.Checked = True
            chkActive.Properties.ReadOnly = True
        End If
        txtPassword.Properties.ReadOnly = True
        txtComfirmPassword.Properties.ReadOnly = True

    End Sub
    Private isAddUser As Boolean = False
    Private isEditUser As Boolean = False
    Private Sub btnSaveND_Click(sender As Object, e As EventArgs) Handles btnSaveND.Click
        If fnCheckValidUser() = False Then
            Exit Sub
        End If

        grdDanhsachQuyenxetduyet.UpdateCurrentRow()
        'Xu ly Luu du lieu
        Dim dataView As New DataView(DirectCast(GridControl14.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Dim tbUserCN = New System.Data.DataTable()
        tbUserCN = dataView.ToTable(True, "STT", "TEN_CHUC_NANG", "MT_CN", "USERNAME", "CHON", "IS_UPDATE")

        If CheckValidData() = False Then
            Exit Sub
        End If
        'If isValidData() Then
        Dim Action As String = ""
        If is_ADD = True Then
            Action = "ADD"
        Else
            Action = "UPDATE"
        End If
        If SaveUserCN(Action, tbUserCN) Then
            'Try
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOG",
            '    GROUP_ID, Me.Name, Commons.Modules.UserName, 1)
            'Catch ex As Exception
            'End Try
            If is_EDIT = True Then
                UpdateCurrentRow()
            End If
            VisibleButtonUserCN(True)
            If is_ADD = True Then
                LoadListNguoiDung(txtGroupID.Text)
                ShowThongTinNguoiDung()
            End If
            LockGrid(grdDanhsachQuyenxetduyet, True)
            grdDanhsachQuyenxetduyet.Columns("CHON").OptionsColumn.AllowEdit = True
            grdDanhsachQuyenxetduyet.Columns("CHON").OptionsColumn.ReadOnly = False
            grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = False
            grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = False
            grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            LockTab(False)
            is_ADD = False
            is_EDIT = False
            ReadonlyControl(True)
            ShowThongTinNguoiDung()
            grdDanhsachQuyenxetduyet.ActiveFilterString = "CHON =1"
            grdDanhsachQuyenxetduyet.Columns("CHON").Visible = False

        End If
    End Sub
    Private Function fnCheckValidUser()
        If txtTenUser.Text.Trim.ToString() = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenUserNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTenUser.Focus()
            Return False
        End If
        If is_ADD = True Then
            If fnCheckUserExist(txtTenUser.Text.Trim.ToString()) = True Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDatontainguoidung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTenUser.Focus()
                Return False
            End If
        Else
            If IsExistsUser(txtGroupID.Text, txtTenUser.Text.Trim.ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDatontainguoidung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTenUser.Focus()
                Return False
            End If
        End If
        If txtFullName.Text.Trim.ToString() = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraFullNameNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFullName.Focus()
            Return False
        End If
        If txtPassword.Text.Trim.ToString() = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraPasswordNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            Return False
        End If
        If txtComfirmPassword.Text.Trim.ToString() = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraConfirmPasswordNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtComfirmPassword.Focus()
            Return False
        End If
        If txtPassword.Text.Trim.ToString() <> txtComfirmPassword.Text.Trim.ToString() Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraXacNhanPassword", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtComfirmPassword.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub UpdateCurrentRow()
        With grdDanhsachusers
            .SetRowCellValue(.FocusedRowHandle, "USERNAME", txtTenUser.Text)
            .SetRowCellValue(.FocusedRowHandle, "FULL_NAME", txtFullName.Text)
            .SetRowCellValue(.FocusedRowHandle, "MS_TO", cmbDepartment.EditValue)
            .SetRowCellValue(.FocusedRowHandle, "MS_CONG_NHAN", cmbCNhan.EditValue)
            .SetRowCellValue(.FocusedRowHandle, "DESCRIPTION", txtDescription5.Text)
            .SetRowCellValue(.FocusedRowHandle, "USER_MAIL", txtMail.Text)
            .SetRowCellValue(.FocusedRowHandle, "ACTIVE", chkActive.Checked)
        End With
    End Sub
    Public Function SaveUserCN(ByVal Action As String, ByVal tbUserCN As DataTable) As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", Action)
                sqlcom.Parameters.AddWithValue("GROUP_ID", txtGroupID.Text)
                sqlcom.Parameters.AddWithValue("USERNAME", txtTenUser.Text)
                sqlcom.Parameters.AddWithValue("FULL_NAME", txtFullName.Text)
                sqlcom.Parameters.AddWithValue("DESCRIPTION", txtDescription5.Text)

                If cmbDepartment.EditValue Is Nothing Then
                    sqlcom.Parameters.AddWithValue("MS_TO", Nothing)
                Else
                    sqlcom.Parameters.AddWithValue("MS_TO", cmbDepartment.EditValue.ToString())
                End If

                sqlcom.Parameters.AddWithValue("USER_MAIL", txtMail.Text)
                If cmbCNhan.EditValue Is Nothing Then
                    sqlcom.Parameters.AddWithValue("MS_CONG_NHAN", Nothing)
                Else
                    sqlcom.Parameters.AddWithValue("MS_CONG_NHAN", cmbCNhan.EditValue.ToString())
                End If

                sqlcom.Parameters.AddWithValue("ACTIVE", chkActive.Checked)
                sqlcom.Parameters.AddWithValue("PASS", Commons.clsXuLy.MaHoaDL(txtPassword.Text))
                If (tbUserCN IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBUCN", tbUserCN)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_USER_CHUCNANG"
                sqlcom.ExecuteNonQuery()
                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function DeleteUserCN() As [Boolean]
        Dim dt As New DataTable()
        Dim transaction As SqlTransaction = Nothing
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                transaction = con.BeginTransaction("Transaction")
                sqlcom.Connection = con
                sqlcom.Transaction = transaction
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE")
                sqlcom.Parameters.AddWithValue("USERNAME", txtTenUser.Text)
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_USER_CHUCNANG"
                sqlcom.ExecuteNonQuery()
                transaction.Commit()
                Return True
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Private Sub VisibleButtonUserCN(ByVal TT As Boolean)
        btnCopyND.Visible = TT
        btnChuyennhom.Visible = TT
        btnCTChucnang.Visible = Not TT
        btnBTChucnang.Visible = Not TT
        btnKhongND.Visible = Not TT
        btnSaveND.Visible = Not TT
        btnThoatND.Visible = TT
        btnThemND.Visible = TT
        btnSuaND.Visible = TT
        btnXoaND.Visible = TT
    End Sub
    Private Sub ReadonlyControl(ByVal TT As Boolean)
        txtTenUser.Properties.ReadOnly = TT
        txtMail.Properties.ReadOnly = TT
        txtFullName.Properties.ReadOnly = TT
        txtDescription5.Properties.ReadOnly = TT
        txtPassword.Properties.ReadOnly = TT
        txtComfirmPassword.Properties.ReadOnly = TT
        chkActive.Properties.ReadOnly = TT
        cmbCNhan.Properties.ReadOnly = TT
        cmbDepartment.Properties.ReadOnly = TT

    End Sub
    Private Sub ClearScreen()
        txtTenUser.Text = ""
        txtMail.Text = ""
        txtFullName.Text = ""
        txtDescription5.Text = ""
        txtPassword.Text = ""
        txtComfirmPassword.Text = ""
        chkActive.Checked = False
        cmbCNhan.EditValue = Nothing
        cmbDepartment.EditValue = Nothing
    End Sub

    Private Sub LockGridFormND(ByVal TT As Boolean)
        For i As Integer = 0 To grdDanhsachQuyenxetduyet.Columns.Count - 1
            grdDanhsachQuyenxetduyet.Columns(i).OptionsColumn.AllowEdit = Not TT
        Next
        grdDanhsachQuyenxetduyet.Columns(1).OptionsColumn.AllowEdit = False
        grdDanhsachQuyenxetduyet.Columns(1).OptionsColumn.ReadOnly = True
    End Sub

    Private Sub btnThemND_Click(sender As Object, e As EventArgs) Handles btnThemND.Click
        is_ADD = True
        ClearScreen()

        grdDanhsachQuyenxetduyet.Columns("CHON").Visible = True
        grdDanhsachQuyenxetduyet.ActiveFilter.Clear()

        grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = True
        grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachQuyenxetduyet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonUserCN(False)
        LockGridFormND(False)
        LockTab(True)
        ReadonlyControl(False)

        grdDanhsachusers.OptionsView.ShowIndicator = False
        grdDanhsachusers.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedCell = False
        grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedRow = False
        grdDanhsachusers.OptionsSelection.EnableAppearanceHideSelection = False

        LoadDanhSachUserQuyenDefault()

        txtTenUser.Focus()
    End Sub

    Private Sub grdDanhsachusers_MouseDown(sender As Object, e As MouseEventArgs) Handles grdDanhsachusers.MouseDown
        Dim info As GridHitInfo = grdDanhsachusers.CalcHitInfo(e.Location)
        If is_ADD = True Then
            Try
                If info.RowHandle < 0 Then
                    Exit Sub
                End If

            Catch ex As Exception
                DirectCast(e, DXMouseEventArgs).Handled = True
            End Try
            DirectCast(e, DXMouseEventArgs).Handled = True

        End If
        If is_EDIT = True Then


            DirectCast(e, DXMouseEventArgs).Handled = True

        End If
    End Sub

    Private Sub btnKhongND_Click(sender As Object, e As EventArgs) Handles btnKhongND.Click
        is_ADD = False
        is_EDIT = False
        VisibleButtonUserCN(True)
        ReadonlyControl(True)

        grdDanhsachQuyenxetduyet.OptionsBehavior.Editable = True
        grdDanhsachQuyenxetduyet.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdDanhsachQuyenxetduyet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        VisibleButtonDiaDiemDC(True)
        LockGridFormND(True)
        LockTab(False)

        'LoadListNguoiDung(txtGroupID.Text)
        ShowThongTinNguoiDung()
        grdDanhsachQuyenxetduyet.ActiveFilterString = "CHON =1"

        grdDanhsachusers.OptionsView.ShowIndicator = True
        grdDanhsachusers.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedCell = False
        grdDanhsachusers.OptionsSelection.EnableAppearanceFocusedRow = True
        grdDanhsachusers.OptionsSelection.EnableAppearanceHideSelection = True
    End Sub

    Private Sub btnBTChucnang_Click(sender As Object, e As EventArgs) Handles btnBTChucnang.Click
        For i As Integer = 0 To grdDanhsachQuyenxetduyet.RowCount - 1
            grdDanhsachQuyenxetduyet.SetRowCellValue(i, "CHON", False)
            grdDanhsachQuyenxetduyet.SetRowCellValue(i, "IS_UPDATE", True)
            grdDanhsachQuyenxetduyet.UpdateCurrentRow()

        Next
        GridControl17.Update()
    End Sub

    Private Sub grdDanhsachQuyenxetduyet_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdDanhsachQuyenxetduyet.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "NIS_UPDATE" Then

                grdDanhsachQuyenxetduyet.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnXoaND_Click(sender As Object, e As EventArgs) Handles btnXoaND.Click
        If Commons.Modules.ObjGroups.CheckUSER_CHUCNANG(txtTenUser.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKTUserDaSuDung", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa51", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            If Traloi = vbYes Then

                Commons.Modules.ObjGroups.DeleteUSER_NHOM(txtGroupID.Text, txtTenUser.Text)
                LoadListNguoiDung(txtGroupID.Text)
                ShowThongTinNguoiDung()
            End If
        End If
    End Sub

    Private Sub btnChuyennhom_Click(sender As Object, e As EventArgs) Handles btnChuyennhom.Click
        If grdListOfGroup.RowCount < 2 Or txtTenUser.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoNhomDeChuyen", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        CopyPhanQuyen(12, txtTenUser.Text)
        LoadListNguoiDung(txtGroupID.Text)
        ShowThongTinNguoiDung()
    End Sub

    Private Sub btnCopyND_Click(sender As Object, e As EventArgs) Handles btnCopyND.Click
        If grdDanhsachusers.RowCount = 0 Or txtTenUser.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoUserCopy", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        CopyPhanQuyen(10, txtTenUser.Text)
    End Sub

    Private Sub btnThoatND_Click(sender As Object, e As EventArgs) Handles btnThoatND.Click
        Me.Close()
    End Sub

    Private Sub LoadListAllUser()
        If Commons.Modules.UserName.ToUpper() <> "ADMIN" And Commons.Modules.UserName.ToUpper() <> "ADMINISTRATOR" Then
            btnResetPass.Visible = False
        Else
            btnResetPass.Visible = True
        End If

        grdListUser.ClearSorting()
        grdListUser.ActiveFilter.Clear()
        Dim sSql As String
        Dim dtTmp As New DataTable

        sSql = " SELECT A.USERNAME, A.FULL_NAME, B.GROUP_NAME, B.DESCRIPTION , A.GROUP_ID, A.GROUP_ID,HO + ' ' + TEN AS HO_TEN , D.TIME_LOGIN" &
                " FROM dbo.USERS AS A INNER JOIN dbo.NHOM AS B ON A.GROUP_ID = B.GROUP_ID  " &
                " LEFT JOIN CONG_NHAN C ON A.MS_CONG_NHAN = C.MS_CONG_NHAN LEFT JOIN dbo.LOGIN D ON A.USERNAME = D.USER_LOGIN " &
                " ORDER BY D.TIME_LOGIN DESC,B.GROUP_NAME, A.USERNAME "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl13, grdListUser, dtTmp, False, False, True, True, True, Name)
        grdListUser.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdListUser.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grdListUser.MoveFirst()
        grdListUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        grdListUser.OptionsSelection.EnableAppearanceFocusedCell = False
        grdListUser.OptionsSelection.EnableAppearanceFocusedRow = True
        grdListUser.OptionsSelection.EnableAppearanceHideSelection = True
    End Sub

    Private Sub grdListUser_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdListUser.RowCellStyle
        Try

            Dim View As GridView = TryCast(sender, GridView)
            If grdListUser.GetRowCellValue(e.RowHandle, "TIME_LOGIN").ToString() <> "" Then
                e.Appearance.BackColor = Color.LimeGreen
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdListUser_MouseDown(sender As Object, e As MouseEventArgs) Handles grdListUser.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim view As GridView = DirectCast(sender, GridView)
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
            If hitInfo.InRow Then
                view.FocusedColumn = hitInfo.Column
                view.FocusedRowHandle = hitInfo.RowHandle
                If Commons.Modules.UserName.ToUpper() <> "ADMIN" And Commons.Modules.UserName.ToUpper() <> "ADMINISTRATOR" Then
                    ShutDownUserToolStripMenuItem.Visible = False
                    ResetPassToolStripMenuItem.Visible = False
                Else
                    ResetPassToolStripMenuItem.Visible = True
                    If view.GetRowCellValue(view.FocusedRowHandle, "TIME_LOGIN").ToString() = "" Then
                        ShutDownUserToolStripMenuItem.Visible = False
                    Else
                        ShutDownUserToolStripMenuItem.Visible = True
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub ShutDownUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutDownUserToolStripMenuItem.Click
        With grdListUser
            Dim sSql As String
            Dim tt As Integer = -1
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXacNhanThoatUser", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                sSql = "DELETE  dbo.LOGIN WHERE USER_LOGIN = '" & .GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString() & "'"
                tt = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                If tt <> -1 Then
                    If .GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString().Trim.ToUpper() = Commons.Modules.UserName.ToUpper() Then
                        Application.ExitThread()
                        Application.Exit()
                    Else
                        LoadListAllUser()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub ResetMậtKhẩuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPassToolStripMenuItem.Click
        With grdListUser
            Dim sSql As String
            Dim tt As Integer = -1
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXacNhanResetPassword", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim pass As String = ""
                sSql = "SELECT PASS FROM USERS WHERE USERNAME = '" & .GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString().Trim & "'"
                pass = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Dim frm As New frmPassword(.GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString().Trim, Commons.clsXuLy.GiaiMaDL(pass), True)
                frm.ShowDialog()
            End If
        End With
    End Sub

    Private Sub btnResetPass_Click(sender As Object, e As EventArgs) Handles btnResetPass.Click
        With grdListUser
            Dim sSql As String
            Dim tt As Integer = -1
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXacNhanResetPassword", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                'sSql = "UPDATE USERS SET PASS = N'" & Commons.clsXuLy.MaHoaDL(txtResetPass.Text) & "' WHERE USERNAME = '" & .GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString() & "'"
                'tt = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Dim pass As String = ""
                sSql = "SELECT PASS FROM USERS WHERE USERNAME = '" & .GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString().Trim & "'"
                pass = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Dim frm As New frmPassword(.GetRowCellValue(.FocusedRowHandle, "USERNAME").ToString().Trim, Commons.clsXuLy.GiaiMaDL(pass), True)
                frm.ShowDialog()
            End If
        End With
    End Sub

    Private Sub grdListUser_RowClick(sender As Object, e As RowClickEventArgs) Handles grdListUser.RowClick
        selGroupID = -1
        selGroupID = grdListUser.GetRowCellValue(e.RowHandle, "GROUP_ID").ToString().Trim()
    End Sub

    Private Sub grdListUser_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles grdListUser.SelectionChanged
        With grdListUser
            selGroupID = -1
            selGroupID = .GetRowCellValue(.FocusedRowHandle, "GROUP_ID").ToString().Trim()
        End With

    End Sub

    Private Sub grdListUser_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles grdListUser.FocusedRowChanged
        Try
            With grdListUser
                selGroupID = -1
                selGroupID = .GetRowCellValue(.FocusedRowHandle, "GROUP_ID").ToString().Trim()
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtFindUser_EditValueChanged(sender As Object, e As EventArgs) Handles txtFindUser.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        Dim sl As String = ""
        If txtFindUser.Text.Length > 0 Then
            sl = "[USERNAME] LIKE '%" & txtFindUser.Text & "%'"
        Else
            sl = "[USERNAME] LIKE '%'"
        End If
        grdListUser.Columns("USERNAME").FilterInfo = New ColumnFilterInfo(sl)
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles btnThoatDSND.Click
        Me.Close()
    End Sub
    Private Sub SetNNMenu()
        ShutDownUserToolStripMenuItem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ShutDownUser", Commons.Modules.TypeLanguage)
        ResetPassToolStripMenuItem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ResetPass", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub txtFindUS_EditValueChanged(sender As Object, e As EventArgs) Handles txtFindUS.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Dim sl As String = ""
        If txtFindUS.Text.Length > 0 Then
            sl = "[USERNAME] LIKE '%" & txtFindUS.Text & "%'"
        Else
            sl = "[USERNAME] LIKE '%'"
        End If
        grdDanhsachusers.Columns("USERNAME").FilterInfo = New ColumnFilterInfo(sl)
        ShowThongTinNguoiDung()
    End Sub

#End Region

    Private Sub SetFormPermission(ByVal FORM_NAME As String, ByVal USER_NAME As String)
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con

                sqlcom.Parameters.AddWithValue("USER_NAME", USER_NAME)
                sqlcom.Parameters.AddWithValue("FORM_NAME", FORM_NAME)
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "GET_PHAN_QUYEN_FORM"
                Dim tt As String = sqlcom.ExecuteScalar()
                If tt <> "" Then
                    'Readonly hoac No access
                    btnThem.Enabled = False
                    btnSua.Enabled = False
                    btnXoa.Enabled = False


                    btnThemSuaDC.Enabled = False
                    btnCopyDC.Enabled = False
                    btnCopyNX.Enabled = False


                    btnThemSuaF.Enabled = False
                    btnCopyF.Enabled = False


                    btnThemSuaKhoPB.Enabled = False
                    btnCopyKho.Enabled = False
                    btnCopyPB.Enabled = False

                    btnThemSuaLCVVTPT.Enabled = False
                    btnCopyLCV.Enabled = False
                    btnCopyVTPT.Enabled = False

                    btnThemSuaLTBBPCP.Enabled = False
                    btnCopyLTB.Enabled = False
                    btnCopyBPCP.Enabled = False

                    btnThemSua.Enabled = False
                    btnCopy.Enabled = False

                    btnThemSuaR.Enabled = False
                    btnCopyR.Enabled = False

                    btnThemND.Enabled = False
                    btnSuaND.Enabled = False
                    btnXoaND.Enabled = False
                    btnChuyennhom.Enabled = False
                    btnCopyND.Enabled = False
                Else
                    'Full access
                    btnThem.Enabled = True
                    btnSua.Enabled = True
                    btnXoa.Enabled = True


                    btnThemSuaDC.Enabled = True
                    btnCopyDC.Enabled = True
                    btnCopyNX.Enabled = True


                    btnThemSuaF.Enabled = True
                    btnCopyF.Enabled = True


                    btnThemSuaKhoPB.Enabled = True
                    btnCopyKho.Enabled = True
                    btnCopyPB.Enabled = True

                    btnThemSuaLCVVTPT.Enabled = True
                    btnCopyLCV.Enabled = True
                    btnCopyVTPT.Enabled = True

                    btnThemSuaLTBBPCP.Enabled = True
                    btnCopyLTB.Enabled = True
                    btnCopyBPCP.Enabled = True

                    btnThemSua.Enabled = True
                    btnCopy.Enabled = True

                    btnThemSuaR.Enabled = True
                    btnCopyR.Enabled = True

                    btnThemND.Enabled = True
                    btnSuaND.Enabled = True
                    btnXoaND.Enabled = True

                    btnChuyennhom.Enabled = True
                    btnCopyND.Enabled = True
                End If
            Catch ex As Exception

            Finally
                con.Close()
            End Try
        End Using
    End Sub

End Class