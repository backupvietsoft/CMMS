Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports Microsoft.ApplicationBlocks.Data

Public Class frmDonvido

    Private is_EDIT As Boolean = False
    Private isLoadDVT As Boolean = False
    Private isLoadDo As Boolean = False

    Private FullAccess_DVD As Boolean = True
    Private FullAccess_RT As Boolean = True
    Private FullAccess_DVT As Boolean = True

    Private Sub frmDonvido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListDonViDo()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        SetFormPermission()
    End Sub
    Sub LoadListDonViDo()
        If isLoadDo = False Then
            Dim ds As New DataSet
            Try
                Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                    Dim sqlcom As SqlCommand = con.CreateCommand()
                    Try
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        sqlcom.Connection = con
                        sqlcom.Parameters.AddWithValue("ACTION", "LOAD_DVD_RUNTIME")
                        sqlcom.CommandType = CommandType.StoredProcedure
                        sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
                        Dim da As New SqlDataAdapter(sqlcom)
                        da.Fill(ds)
                    Catch ex As Exception

                    Finally
                        con.Close()
                    End Try
                End Using

                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GrdDanhsachdonvido, ds.Tables(0), False, False, True, True, True, "")
                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl3, GrdDSDVRT, ds.Tables(1), False, False, True, True, True, "")
                GrdDanhsachdonvido.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                GrdDanhsachdonvido.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                GrdDSDVRT.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                GrdDSDVRT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                LockGrid(GrdDanhsachdonvido, True)
                LockGrid(GrdDSDVRT, True)
                isLoadDo = True
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub LoadListDonViTinh()
        If isLoadDVT = False Then
            Dim dt As New DataTable()
            Try
                Using con As New SqlConnection(Commons.IConnections.ConnectionString())
                    Dim sqlcom As SqlCommand = con.CreateCommand()
                    Try
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        sqlcom.Connection = con
                        sqlcom.Parameters.AddWithValue("ACTION", "LOAD_DVT")
                        sqlcom.CommandType = CommandType.StoredProcedure
                        sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
                        Dim da As New SqlDataAdapter(sqlcom)
                        da.Fill(dt)
                    Catch ex As Exception

                    Finally
                        con.Close()
                    End Try
                End Using

                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl2, GrdDSDVT, dt, False, False, True, True, True, "")

                GrdDSDVT.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                GrdDSDVT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

                LockGrid(GrdDSDVT, True)
                isLoadDVT = True
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub LockGrid(ByVal grid As GridView, ByVal TT As Boolean)
        For i As Integer = 0 To grid.Columns.Count - 1
            grid.Columns(i).OptionsColumn.AllowEdit = Not TT
            'grdListOfGroup.Columns(i).OptionsColumn.ReadOnly = TT
        Next
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPage.Name = "TabDVD_TGCM" Then
            If FullAccess_DVD = False And FullAccess_RT = False Then
                btnThemSua.Enabled = False
                btnXoa.Enabled = False
            Else
                btnThemSua.Enabled = True
                btnXoa.Enabled = True
            End If
            LoadListDonViDo()
        End If
        If XtraTabControl1.SelectedTabPage.Name = "TabDVT" Then
            LoadListDonViTinh()
        End If
    End Sub

    Private Sub VisibleButton(ByVal TT As Boolean)
        btnKhong.Visible = Not TT
        btnSave.Visible = Not TT
        btnThoat.Visible = TT
        btnThemSua.Visible = TT
        btnXoa.Visible = TT
        btnXoaDVD.Visible = False
        btnXoaDVTG.Visible = False
        btnBack.Visible = False
    End Sub
    Private Sub VisibleButtonDVT(ByVal TT As Boolean)
        btnKhongDVT.Visible = Not TT
        btnSaveDVT.Visible = Not TT
        btnThoatDVT.Visible = TT
        btnThemSuaDVT.Visible = TT
        btnXoaDVT.Visible = TT
    End Sub
    Private Sub LockTab(ByVal TT As Boolean)
        For i As Integer = 0 To XtraTabControl1.TabPages.Count - 1
            If i <> XtraTabControl1.SelectedTabPageIndex Then
                XtraTabControl1.TabPages(i).PageEnabled = Not TT
            End If
        Next
    End Sub


    Private Sub btnThemSua_Click(sender As Object, e As EventArgs) Handles btnThemSua.Click
        VisibleButton(False)
        LockGrid(GrdDanhsachdonvido, False)
        LockGrid(GrdDSDVRT, False)
        If FullAccess_DVD = True Then
            GrdDanhsachdonvido.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            GrdDanhsachdonvido.OptionsBehavior.Editable = True
            GrdDanhsachdonvido.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GrdDanhsachdonvido.NewItemRowText = ""
            GrdDanhsachdonvido.MoveLastVisible()
        Else
            GrdDanhsachdonvido.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            GrdDanhsachdonvido.OptionsBehavior.Editable = False
            GrdDanhsachdonvido.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            GrdDanhsachdonvido.NewItemRowText = ""
            GrdDanhsachdonvido.MoveLastVisible()
        End If

        If FullAccess_RT = True Then
            GrdDSDVRT.OptionsBehavior.Editable = True
            GrdDSDVRT.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            GrdDSDVRT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GrdDSDVRT.NewItemRowText = ""
            GrdDSDVRT.MoveLastVisible()
        Else
            GrdDSDVRT.OptionsBehavior.Editable = False
            GrdDSDVRT.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            GrdDSDVRT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            GrdDSDVRT.NewItemRowText = ""
            GrdDSDVRT.MoveLastVisible()
        End If
        LockTab(True)
    End Sub

    Private Sub GrdDanhsachdonvido_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GrdDanhsachdonvido.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "DVDIS_UPDATE" Then

                GrdDanhsachdonvido.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdDSDVRT_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GrdDSDVRT.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "RTIS_UPDATE" Then

                GrdDSDVRT.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdDSDVT_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GrdDSDVT.CellValueChanged
        Try
            If e.Column.Name.ToString() <> "DVTIS_UPDATE" Then

                GrdDSDVT.SetFocusedRowCellValue("IS_UPDATE", True)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdDanhsachdonvido_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GrdDanhsachdonvido.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub GrdDanhsachdonvido_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GrdDanhsachdonvido.ValidateRow
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim sTenDVD As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TEN_DV_DO")


        If View.GetRowCellValue(e.RowHandle, sTenDVD).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sTenDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDonViDoNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDonViDoNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub GrdDSDVRT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GrdDSDVRT.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub GrdDSDVRT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GrdDSDVRT.ValidateRow
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim sTenDVRT As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TEN_DVT_RT")


        If View.GetRowCellValue(e.RowHandle, sTenDVRT).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sTenDVRT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDVThoiGianRunTimeNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDVThoiGianRunTimeNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnKhong_Click(sender As Object, e As EventArgs) Handles btnKhong.Click
        isLoadDo = False

        VisibleButton(True)
        LockGrid(GrdDanhsachdonvido, True)
        LockGrid(GrdDSDVRT, True)
        GrdDanhsachdonvido.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        GrdDanhsachdonvido.OptionsBehavior.Editable = False

        GrdDSDVRT.OptionsBehavior.Editable = False
        GrdDSDVRT.OptionsView.NewItemRowPosition = NewItemRowPosition.None

        GrdDanhsachdonvido.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        GrdDanhsachdonvido.NewItemRowText = ""

        GrdDSDVRT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        GrdDSDVRT.NewItemRowText = ""
        LoadListDonViDo()
        LockTab(False)
    End Sub

    Public Function DeleteDonViTinh(ByVal MaDVT As String) As [Boolean]
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
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE_DVT")
                sqlcom.Parameters.AddWithValue("DVT", MaDVT)

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
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

    Public Function DeleteDonViDo(ByVal MaDVD As String) As [Boolean]
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
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE_DVD")
                sqlcom.Parameters.AddWithValue("MS_DV_DO", MaDVD)

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
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

    Public Function DeleteDonViTGRT(ByVal MS_DVT_RT As String) As [Boolean]
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
                sqlcom.Parameters.AddWithValue("ACTION", "DELETE_THOIGIAN")
                sqlcom.Parameters.AddWithValue("MS_DVT_RT", MS_DVT_RT)

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
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

    Public Function SaveDVT(ByVal tbDVT As DataTable) As [Boolean]
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
                sqlcom.Parameters.AddWithValue("ACTION", "SAVE_DVT")

                If (tbDVT IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBDVT", tbDVT)
                End If

                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
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


    Public Function Save(ByVal tbDVD As DataTable, ByVal tbDVTG As DataTable) As [Boolean]
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

                If (tbDVD IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBDVD", tbDVD)
                End If
                If (tbDVTG IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBDVTRT", tbDVTG)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "DON_VI_DO_THOI_GIAN_RUNTIME"
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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        GrdDanhsachdonvido.UpdateCurrentRow()
        GrdDSDVRT.UpdateCurrentRow()
        'Xu ly Luu du lieu
        Dim dataView As New DataView(DirectCast(GridControl1.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Dim tbDVD = New System.Data.DataTable()
        tbDVD = dataView.ToTable(True, "MS_DV_DO", "TEN_DV_DO", "IS_UPDATE")

        dataView = New DataView(DirectCast(GridControl3.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Dim tbRunTime = New System.Data.DataTable()
        tbRunTime = dataView.ToTable(True, "MS_DVT_RT", "TEN_DVT_RT", "IS_UPDATE")

        If CheckValidData() = False Then
            Exit Sub
        End If

        If Save(tbDVD, tbRunTime) Then
            isLoadDo = False
            GrdDanhsachdonvido.ClearColumnErrors()
            GrdDSDVRT.ClearColumnErrors()
            VisibleButton(True)
            LoadListDonViDo()
            LockGrid(GrdDanhsachdonvido, True)
            LockGrid(GrdDSDVRT, True)
            GrdDSDVRT.OptionsBehavior.Editable = False
            GrdDSDVRT.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            GrdDanhsachdonvido.OptionsBehavior.Editable = False
            GrdDanhsachdonvido.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            LockTab(False)
        End If
    End Sub
    Private Function CheckValidData()
        For i As Integer = 0 To GrdDanhsachdonvido.RowCount - 2
            If IsDuplicateDonViDo(GrdDanhsachdonvido.GetRowCellValue(i, "TEN_DV_DO").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungDonViDo", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        For i As Integer = 0 To GrdDSDVRT.RowCount - 2
            If IsDuplicateDonViThoiGianRunTime(GrdDSDVRT.GetRowCellValue(i, "TEN_DVT_RT").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungDonViDoThoiGianRunTime", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        Return True
    End Function

    Private Function CheckValidDataDonViTinh()
        For i As Integer = 0 To GrdDSDVT.RowCount - 2
            If IsDuplicateDonViTinh(GrdDSDVT.GetRowCellValue(i, "DVT").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungDonViTinh", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        Return True
    End Function
    Private Function IsDuplicateDonViTinh(ByVal tendv As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To GrdDSDVT.RowCount - 2
                If GrdDSDVT.GetRowCellValue(i, "DVT").ToString().Trim.ToUpper = tendv.ToUpper Then
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
    Private Function IsDuplicateDonViDo(ByVal tendv As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To GrdDanhsachdonvido.RowCount - 2
                If GrdDanhsachdonvido.GetRowCellValue(i, "TEN_DV_DO").ToString().Trim.ToUpper = tendv.ToUpper Then
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
    Private Function IsDuplicateDonViThoiGianRunTime(ByVal tendv As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To GrdDSDVRT.RowCount - 2
                If GrdDSDVRT.GetRowCellValue(i, "TEN_DVT_RT").ToString().Trim.ToUpper = tendv.ToUpper Then
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
    Private Sub VisibleButtonDelete(ByVal TT As Boolean)
        btnKhong.Visible = False
        btnSave.Visible = False
        btnThoat.Visible = TT
        btnThemSua.Visible = TT
        btnXoa.Visible = TT
        btnXoaDVD.Visible = Not TT
        btnXoaDVTG.Visible = Not TT
        If FullAccess_DVD = False Then
            btnXoaDVD.Enabled = False
        Else
            btnXoaDVD.Enabled = True
        End If
        If FullAccess_RT = False Then
            btnXoaDVTG.Enabled = False
        Else
            btnXoaDVTG.Enabled = True
        End If
        btnBack.Visible = Not TT
    End Sub
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        VisibleButtonDelete(False)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        VisibleButtonDelete(True)
    End Sub

    Private Function CheckDeleteDonViTinh(ByVal MaDVT As String)
        ' Kiểm tra đơn vị tính này có tồn tại trong bảng IC_PHU_TUNG không.
        Dim SQL_TMP = "SELECT * FROM IC_PHU_TUNG WHERE DVT = '" & MaDVT.Replace("'", "''") & "'"
        Dim dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End While
        Return True
    End Function
    Private Function CheckDeleteDonViDo(ByVal Madonvido As String)
        '  Kiểm tra đơn vị đo có đang được sử dụng trong bảng khác không.
        Dim SQL_TMP As String = "SELECT * FROM THONG_SO_GSTT WHERE MS_DV_DO = " & Madonvido
        Dim THONG_SO_GSTT_Reader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        Dim SQL_QUERY As String = "SELECT * FROM THONG_SO_MAY WHERE MS_DV_DO = " & Madonvido
        Dim THONG_SO_MAY_Reader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_QUERY)
        If THONG_SO_GSTT_Reader.Read Or THONG_SO_MAY_Reader.Read Then
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        ElseIf THONG_SO_GSTT_Reader.Read And THONG_SO_MAY_Reader.Read Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Function CheckDeleteDonViThoiGian(ByVal MaDVTG As String)
        '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY không.

        Dim SQL_TMP = "SELECT * FROM MAY WHERE MS_DVT_RT = '" & MaDVTG & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End While

        '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY_LOAI_BTPN_CHU_KY không.

        SQL_TMP = "SELECT * FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_DVT_RT = '" & MaDVTG & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End While

        '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng CAU_TRUC_THIET_BI không.

        SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_DVT_RT = '" & MaDVTG & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End While
        Return True
    End Function
    Private Sub btnXoaDVD_Click(sender As Object, e As EventArgs) Handles btnXoaDVD.Click
        Try

            Dim MaDV As String = GrdDanhsachdonvido.GetFocusedRowCellValue("MS_DV_DO").ToString()
            If MaDV.Length > 0 Then

                Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaDonViDo", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    If CheckDeleteDonViDo(MaDV) = True Then
                        If DeleteDonViDo(MaDV) Then
                            isLoadDo = False
                            LoadListDonViDo()
                            VisibleButtonDelete(True)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnXoaDVTG_Click(sender As Object, e As EventArgs) Handles btnXoaDVTG.Click
        Try

            Dim MaDV As String = GrdDSDVRT.GetFocusedRowCellValue("MS_DVT_RT").ToString()
            If MaDV.Length > 0 Then

                Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaDonViThoiGianRunTime", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    If CheckDeleteDonViThoiGian(MaDV) = True Then
                        If DeleteDonViTGRT(MaDV) Then
                            isLoadDo = False
                            LoadListDonViDo()
                            VisibleButtonDelete(True)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnThemSuaDVT_Click(sender As Object, e As EventArgs) Handles btnThemSuaDVT.Click
        is_EDIT = True
        VisibleButtonDVT(False)
        LockGrid(GrdDSDVT, False)
        GrdDSDVT.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        GrdDSDVT.OptionsBehavior.Editable = True
        GrdDSDVT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        GrdDSDVT.NewItemRowText = ""
        GrdDSDVT.MoveLastVisible()
        LockTab(True)
    End Sub

    Private Sub btnKhongDVT_Click(sender As Object, e As EventArgs) Handles btnKhongDVT.Click
        isLoadDVT = False
        VisibleButtonDVT(True)
        LockGrid(GrdDSDVT, True)
        GrdDSDVT.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        GrdDSDVT.OptionsBehavior.Editable = False
        GrdDSDVT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        GrdDSDVT.NewItemRowText = ""
        LoadListDonViTinh()
        LockTab(False)
        is_EDIT = False
    End Sub

    Private Sub GrdDSDVT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GrdDSDVT.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub GrdDSDVT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GrdDSDVT.ValidateRow
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim sDVD As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("DVT")
        Dim sTenVN As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TEN_1")

        If View.GetRowCellValue(e.RowHandle, sDVD).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraMaDonViTinhNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraMaDonViTinhNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If View.GetRowCellValue(e.RowHandle, sTenVN).ToString() = "" Then
            e.Valid = False
            View.SetColumnError(sTenVN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDonViTinhNULL", Commons.Modules.TypeLanguage))
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenDonViTinhNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSaveDVT_Click(sender As Object, e As EventArgs) Handles btnSaveDVT.Click
        GrdDSDVT.UpdateCurrentRow()

        'Xu ly Luu du lieu
        Dim dataView As New DataView(DirectCast(GridControl2.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Dim tbDVT = New System.Data.DataTable()
        tbDVT = dataView.ToTable(True, "DVT", "TEN_1", "TEN_2", "TEN_3", "GHI_CHU", "IS_UPDATE")


        If CheckValidDataDonViTinh() = False Then
            Exit Sub
        End If

        If SaveDVT(tbDVT) Then
            isLoadDVT = False
            GrdDSDVT.ClearColumnErrors()

            VisibleButtonDVT(True)
            LoadListDonViTinh()
            LockGrid(GrdDSDVT, True)

            GrdDSDVT.OptionsBehavior.Editable = False
            GrdDSDVT.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            LockTab(False)
            is_EDIT = False
        End If
    End Sub

    Private Sub btnXoaDVT_Click(sender As Object, e As EventArgs) Handles btnXoaDVT.Click
        Try

            Dim MaDV As String = GrdDSDVT.GetFocusedRowCellValue("DVT").ToString()
            If MaDV.Length > 0 Then

                Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaDonViTinh", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    If CheckDeleteDonViTinh(MaDV) = True Then
                        If DeleteDonViTinh(MaDV) Then
                            isLoadDVT = False
                            LoadListDonViTinh()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoatDVT_Click(sender As Object, e As EventArgs) Handles btnThoatDVT.Click
        Me.Close()
    End Sub

    Private Sub GrdDSDVT_MouseDown(sender As Object, e As MouseEventArgs) Handles GrdDSDVT.MouseDown
        Dim info As GridHitInfo = GrdDSDVT.CalcHitInfo(e.Location)
        If is_EDIT = True Then
            Try

                If (info.Column.Name = "DVT") Then
                    If GrdDSDVT.GetDataRow(info.RowHandle)("DVT").ToString().Trim <> "" Then
                        DirectCast(e, DXMouseEventArgs).Handled = True
                    Else
                        DirectCast(e, DXMouseEventArgs).Handled = False
                    End If
                End If
            Catch ex As Exception
                DirectCast(e, DXMouseEventArgs).Handled = False
            End Try
        End If
        'If is_ADD = True Then
        '    Try
        '        If info.RowHandle < 0 Then
        '            Exit Sub
        '        End If
        '        If DirectCast(GrdDSDVT.GetDataRow(info.RowHandle)("GROUP_ID"), Integer) < 0 Then
        '            Exit Sub
        '        End If
        '    Catch ex As Exception
        '        DirectCast(e, DXMouseEventArgs).Handled = True
        '    End Try
        '    DirectCast(e, DXMouseEventArgs).Handled = True

        'End If
        'If is_EDIT = True Then

        '    If txtGroupName.Text = grdListOfGroup.GetDataRow(info.RowHandle)("GROUP_NAME") Then

        '        Exit Sub
        '    End If

        '    DirectCast(e, DXMouseEventArgs).Handled = True

        'End If
    End Sub


    Private Sub SetFormPermissionDVD()
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con

                sqlcom.Parameters.AddWithValue("USER_NAME", Commons.Modules.UserName)
                sqlcom.Parameters.AddWithValue("FORM_NAME", "frmDonvido")
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "GET_PHAN_QUYEN_FORM"
                Dim tt As String = sqlcom.ExecuteScalar()
                If tt <> "" Then
                    'Readonly hoac No access

                    FullAccess_DVD = False
                Else
                    'Full access
                    FullAccess_DVD = True

                End If
            Catch ex As Exception

            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub SetFormPermissionRunTime()
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con

                sqlcom.Parameters.AddWithValue("USER_NAME", Commons.Modules.UserName)
                sqlcom.Parameters.AddWithValue("FORM_NAME", "frmDonvitinhRuntime")
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "GET_PHAN_QUYEN_FORM"
                Dim tt As String = sqlcom.ExecuteScalar()
                If tt <> "" Then
                    'Readonly hoac No access

                    FullAccess_RT = False
                Else
                    'Full access
                    FullAccess_RT = True

                End If
            Catch ex As Exception

            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub SetFormPermissionDVT()
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con

                sqlcom.Parameters.AddWithValue("USER_NAME", Commons.Modules.UserName)
                sqlcom.Parameters.AddWithValue("FORM_NAME", "frmDonvitinh")
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "GET_PHAN_QUYEN_FORM"
                Dim tt As String = sqlcom.ExecuteScalar()
                If tt <> "" Then
                    'Readonly hoac No access
                    btnThemSuaDVT.Enabled = False
                    btnXoaDVT.Enabled = False
                    FullAccess_DVT = False
                Else
                    'Full access
                    FullAccess_DVT = True
                    btnThemSuaDVT.Enabled = True
                    btnXoaDVT.Enabled = True
                End If
            Catch ex As Exception

            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub SetFormPermission()
        SetFormPermissionDVD()
        SetFormPermissionDVT()
        SetFormPermissionRunTime()
        If FullAccess_DVD = False And FullAccess_RT = False Then
            btnThemSua.Enabled = False
            btnXoa.Enabled = False
        Else
            btnThemSua.Enabled = True
            btnXoa.Enabled = True
        End If
    End Sub
End Class