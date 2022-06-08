Imports System.Data.SqlClient
Imports Commons.VS.Classes.IEStock
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports Microsoft.ApplicationBlocks.Data
Imports System.Linq
Imports System.Net

Public Class frmKho

    Private is_EDIT As Boolean = False
    Private isLoadDVT As Boolean = False
    Private isLoadDo As Boolean = False

    Private FullAccess_DVD As Boolean = True
    Private FullAccess_RT As Boolean = True
    Private FullAccess_DVT As Boolean = True
    Private tb_VitrikhoTmp As New DataTable

    Private Is_UpdateRow As Boolean = False
    Private cur_MSKHO As String
    Private cur_TENKHO As String
    Private ofdChonHinh As New OpenFileDialog
    Private Sub frmDonvido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl1.ForceInitialize()
        Try
            TableLayoutPanel27.ColumnStyles(0).Width = 0
            TableLayoutPanel27.ColumnStyles(4).Width = 0
        Catch ex As Exception
        End Try

        ofdChonHinh.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.ico) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.ico"
        FillComboThuKho()
        FillComboKhoChinh()
        FillComboDonVi()
        LoadListKho()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        SetFormPermission()
        Try
            tb_VitrikhoTmp = DirectCast(GridControl2.DataSource, DataTable).Clone()

        Catch ex As Exception
            tb_VitrikhoTmp = GetListData("GET_DS_VI_TRI_KHO", "SP_IC_KHO", -1)
        End Try


    End Sub
    Private Function CheckExistViTriKhoTemp(ByVal ms_kho As String)
        If tb_VitrikhoTmp.Rows.Count > 0 Then
            For Each row As DataRow In tb_VitrikhoTmp.Select(" MS_KHO = " & ms_kho)
                Return True
            Next
            Return False
        Else
            Return False
        End If
    End Function
    Sub LoadVitriKho(ByVal MS_KHO As Integer)
        If GrdDanhsachkho.RowCount > 0 Then
            Dim _dt As New DataTable

            If CheckExistViTriKhoTemp(MS_KHO) Then
                _dt = tb_VitrikhoTmp.Clone()
                For Each row As DataRow In tb_VitrikhoTmp.Select(" MS_KHO = " & MS_KHO)
                    _dt.ImportRow(row)
                Next
            Else
                _dt = GetListData("GET_DS_VI_TRI_KHO", "SP_IC_KHO", MS_KHO) 'New IC_KHOController().GetVI_TRI_KHO(MS_KHO)
            End If
            _dt.Columns("TEN_VI_TRI").ReadOnly = False
            _dt.Columns("GHI_CHU").ReadOnly = False
            _dt.Columns("MS_KHO").ReadOnly = False
            _dt.Columns("TEN_KHO").ReadOnly = False
            _dt.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl2, grdViTriKho, _dt, False, False, True, True, True, "")
            'grdViTriKho.Columns("MS_VI_TRI").Visible = False

            If btnSave.Visible = True Then
                grdViTriKho.OptionsBehavior.Editable = True
            End If
        Else

            Dim _dt As DataTable = tb_VitrikhoTmp.Clone()


            _dt.Columns("TEN_VI_TRI").ReadOnly = False
            _dt.Columns("GHI_CHU").ReadOnly = False
            _dt.Columns("MS_KHO").ReadOnly = False
            _dt.Columns("TEN_KHO").ReadOnly = False
            _dt.Columns("IS_UPDATE").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl2, grdViTriKho, _dt, False, False, False, True, True, "")
            If btnSave.Visible = True Then
                grdViTriKho.OptionsBehavior.Editable = True
            End If
        End If
    End Sub
    Private Function GetListData(ByVal Action As String, ByVal storename As String, Optional ms_kho As String = "") As DataTable
        Dim _dt As New DataTable

        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con
                sqlcom.Parameters.AddWithValue("ACTION", Action)
                If ms_kho <> "" Then
                    sqlcom.Parameters.AddWithValue("MS_KHO", ms_kho)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = storename
                Dim da As New SqlDataAdapter(sqlcom)
                da.Fill(_dt)
            Catch ex As Exception
                _dt = New DataTable()
            Finally
                con.Close()
            End Try
        End Using
        Return _dt
    End Function
    Sub LoadListKho(Optional iMsKho As Integer = -1)
        If isLoadDo = False Then

            Try
                If btnSave.Visible = False Then Commons.Modules.SQLString = "0Load" Else Commons.Modules.SQLString = ""
                Dim _dt As DataTable = GetListData("GET_DS_KHO", "SP_IC_KHO")
                _dt.PrimaryKey = New DataColumn() {_dt.Columns("MS_KHO")}


                _dt.Columns("MS_KHO_CHINH").ReadOnly = False
                '_dt.Columns("MS_KHO").ReadOnly = False
                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GrdDanhsachkho, _dt, False, False, False, True, True, "")


                GrdDanhsachkho.Columns("TEN_KHO").MinWidth = 140
                GrdDanhsachkho.Columns("DIA_CHI").MinWidth = 120
                GrdDanhsachkho.Columns("SO_DO").MinWidth = 140
                GrdDanhsachkho.Columns("MS_CONG_NHAN").MinWidth = 120
                GrdDanhsachkho.Columns("MS_DON_VI").MinWidth = 120
                GrdDanhsachkho.Columns("MS_KHO_CHINH").MinWidth = 120


                If iMsKho <> -1 Then
                    Dim index As Integer
                    index = _dt.Rows.IndexOf(_dt.Rows.Find(iMsKho))
                    GrdDanhsachkho.FocusedRowHandle = GrdDanhsachkho.GetRowHandle(index)
                End If

                'Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl2, grdViTriKho, ds.Tables(1), False, False, True, True, True, "")
                GrdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                GrdDanhsachkho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                grdViTriKho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                grdViTriKho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                LockGrid(GrdDanhsachkho, True)
                LockGrid(grdViTriKho, True)
                isLoadDo = True
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub FillComboThuKho()

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
            cboStatus.Columns("MS_CONG_NHAN").Caption = "Mã TK"
            cboStatus.Columns("FULL_NAME").Caption = "Tên thủ kho"
        End If

        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("MS_CONG_NHAN").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("FULL_NAME").Alignment = DevExpress.Utils.HorzAlignment.Near
        cboStatus.ShowFooter = False
        GrdDanhsachkho.Columns("MS_CONG_NHAN").ColumnEdit = cboStatus
    End Sub
    Private Sub FillComboKhoChinh()

        Dim dtTmp As New DataTable

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
            "SELECT CONVERT(NVARCHAR(10),MS_KHO) AS MS_KHO_CHINH, TEN_KHO FROM IC_KHO UNION SELECT NULL, '' ORDER BY TEN_KHO"))


        Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboStatus.NullText = ""
        cboStatus.ValueMember = "MS_KHO_CHINH"
        cboStatus.DisplayMember = "TEN_KHO"
        cboStatus.DataSource = dtTmp





        cboStatus.Columns.Clear()

        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_KHO_CHINH"))
        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_KHO"))

        cboStatus.PopupWidth = 300
        cboStatus.Columns("MS_KHO_CHINH").Width = 80
        cboStatus.Columns("TEN_KHO").Width = 220
        If Commons.Modules.TypeLanguage = 1 Then
            cboStatus.Columns("MS_KHO_CHINH").Caption = "ID"
            cboStatus.Columns("TEN_KHO").Caption = "Name"
        Else
            cboStatus.Columns("MS_KHO_CHINH").Caption = "Mã kho"
            cboStatus.Columns("TEN_KHO").Caption = "Tên kho"
        End If

        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("MS_KHO_CHINH").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("TEN_KHO").Alignment = DevExpress.Utils.HorzAlignment.Near
        cboStatus.ShowFooter = False
        GrdDanhsachkho.Columns("MS_KHO_CHINH").ColumnEdit = cboStatus


    End Sub

    Private Sub FillComboDonVi()

        Dim dtTmp As New DataTable

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
            "SELECT MS_DON_VI, TEN_DON_VI FROM DON_VI UNION SELECT NULL, '' ORDER BY TEN_DON_VI "))


        Dim cboStatus As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboStatus.NullText = ""
        cboStatus.ValueMember = "MS_DON_VI"
        cboStatus.DisplayMember = "TEN_DON_VI"
        cboStatus.DataSource = dtTmp





        cboStatus.Columns.Clear()

        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_DON_VI"))
        cboStatus.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DON_VI"))

        cboStatus.PopupWidth = 300
        cboStatus.Columns("MS_DON_VI").Width = 80
        cboStatus.Columns("TEN_DON_VI").Width = 220
        If Commons.Modules.TypeLanguage = 1 Then
            cboStatus.Columns("MS_DON_VI").Caption = "ID"
            cboStatus.Columns("TEN_DON_VI").Caption = "Name"
        Else
            cboStatus.Columns("MS_DON_VI").Caption = "Mã ĐV"
            cboStatus.Columns("TEN_DON_VI").Caption = "Tên đơn vị"
        End If

        cboStatus.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        cboStatus.Columns("MS_DON_VI").Alignment = DevExpress.Utils.HorzAlignment.Center
        cboStatus.Columns("TEN_DON_VI").Alignment = DevExpress.Utils.HorzAlignment.Near
        cboStatus.ShowFooter = False
        GrdDanhsachkho.Columns("MS_DON_VI").ColumnEdit = cboStatus


    End Sub
    Private Sub LockGrid(ByVal grid As GridView, ByVal TT As Boolean)
        For i As Integer = 1 To grid.Columns.Count - 1
            grid.Columns(i).OptionsColumn.AllowEdit = Not TT
            grid.Columns(i).OptionsColumn.ReadOnly = TT
        Next

    End Sub


    Private Sub VisibleButton(ByVal TT As Boolean)
        btnKhong.Visible = Not TT
        btnSave.Visible = Not TT
        btnThoat.Visible = TT
        btnThemSua.Visible = TT
        btnXoa.Visible = TT

        btnTroVe.Visible = False
    End Sub
    Private Sub VisibleButtonDelete(ByVal TT As Boolean)
        btnKhong.Visible = False
        btnSave.Visible = False
        btnThoat.Visible = TT
        btnThemSua.Visible = TT
        btnXoa.Visible = TT
        btnXOA_KHO.Visible = Not TT
        btnXOA_VI_TRI.Visible = Not TT
        If FullAccess_DVD = False Then
            btnXOA_KHO.Enabled = False
            btnXOA_VI_TRI.Enabled = False
        Else
            btnXOA_KHO.Enabled = True
            btnXOA_VI_TRI.Enabled = True
        End If
        btnTroVe.Visible = Not TT
    End Sub
    Private Sub GrdDanhsachdonvido_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs)
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
    Private Sub GrdDSDVRT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs)
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub


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

    Public Function Save(ByVal tbKho As DataTable, ByVal tbVTKho As DataTable) As [Boolean]
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

                If (tbKho IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBKHO", tbKho)
                End If
                If (tbVTKho IsNot Nothing) Then
                    sqlcom.Parameters.AddWithValue("@TBVTKHO", tbVTKho)
                End If
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "SP_IC_KHO"
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
    Private Function CheckValidData()
        For i As Integer = 0 To GrdDanhsachkho.RowCount - 2
            If IsDuplicateTenKho(GrdDanhsachkho.GetRowCellValue(i, "TEN_KHO").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenKho", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        For i As Integer = 0 To grdViTriKho.RowCount - 2
            If IsDuplicateTenViTri(grdViTriKho.GetRowCellValue(i, "TEN_VI_TRI").ToString().Trim) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenViTriKho", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Next
        Return True
    End Function


    Private Function IsDuplicateTenKho(ByVal tendv As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To GrdDanhsachkho.RowCount - 2
                If GrdDanhsachkho.GetRowCellValue(i, "TEN_KHO").ToString().Trim.ToUpper = tendv.ToUpper Then
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
    Private Function IsDuplicateTenViTri(ByVal tenVT As String)
        Try
            Dim dem As Integer = 0
            For i As Integer = 0 To grdViTriKho.RowCount - 2
                If grdViTriKho.GetRowCellValue(i, "TEN_VI_TRI").ToString().Trim.ToUpper = tenVT.ToUpper Then
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


    Private Function CheckDeleteDonViTinh(ByVal MaDVT As String)
        ' Kiểm tra đơn vị tính này có tồn tại trong bảng IC_PHU_TUNG không.
        Dim SQL_TMP = "SELECT * FROM IC_PHU_TUNG WHERE DVT = '" & MaDVT.Replace("'", "''") & "'"
        Dim dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa4", Me.Text)
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
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa3", Me.Text)
            Return False
        ElseIf THONG_SO_GSTT_Reader.Read And THONG_SO_MAY_Reader.Read Then
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa3", Me.Text)
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
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa3", Me.Text)
            Return False
        End While

        '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY_LOAI_BTPN_CHU_KY không.

        SQL_TMP = "SELECT * FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_DVT_RT = '" & MaDVTG & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa4", Me.Text)
            Return False
        End While

        '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng CAU_TRUC_THIET_BI không.

        SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_DVT_RT = '" & MaDVTG & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            Commons.MssBox.Show(Me.Name, "MsgQuyenXoa5", Me.Text)
            Return False
        End While
        Return True
    End Function

    Private Sub btnThoat_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub SetFormPermission()
        Dim dtTmp As New DataTable
        Using con As New SqlConnection(Commons.IConnections.ConnectionString())
            Dim sqlcom As SqlCommand = con.CreateCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sqlcom.Connection = con

                sqlcom.Parameters.AddWithValue("USER_NAME", Commons.Modules.UserName)
                sqlcom.Parameters.AddWithValue("FORM_NAME", "frmKho")
                sqlcom.CommandType = CommandType.StoredProcedure
                sqlcom.CommandText = "GET_PHAN_QUYEN_FORM"
                Dim tt As String = sqlcom.ExecuteScalar()
                If tt <> "" Then
                    'Readonly hoac No access

                    btnThemSua.Enabled = False
                    btnXoa.Enabled = False
                Else
                    'Full access
                    btnThemSua.Enabled = True
                    btnXoa.Enabled = True

                End If
            Catch ex As Exception

            Finally
                con.Close()
            End Try
        End Using
    End Sub



    Private Sub btnThemSua_Click(sender As Object, e As EventArgs) Handles btnThemSua.Click
        is_EDIT = True
        VisibleButton(False)
        LockGrid(GrdDanhsachkho, False)
        LockGrid(grdViTriKho, False)
        GrdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        GrdDanhsachkho.OptionsBehavior.Editable = True
        GrdDanhsachkho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        GrdDanhsachkho.NewItemRowText = ""

        grdViTriKho.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        grdViTriKho.OptionsBehavior.Editable = True
        grdViTriKho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grdViTriKho.NewItemRowText = ""
        GrdDanhsachkho.Columns("SO_DO").OptionsColumn.AllowEdit = False

    End Sub

    'Private Sub GrdDanhsachkho_RowClick(sender As Object, e As RowClickEventArgs) Handles GrdDanhsachkho.RowClick
    '    Try
    '        LoadVitriKho(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO"))
    '        InsertViTriKhoTemp()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub GrdDanhsachkho_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GrdDanhsachkho.FocusedRowChanged
        Try
            InsertViTriKhoTemp()
            LoadVitriKho(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO"))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteViTriKhoTemp(ByVal ms_kho As String)
        If tb_VitrikhoTmp.Rows.Count > 0 Then
            For Each row As DataRow In tb_VitrikhoTmp.Select(" MS_KHO = " & ms_kho)
                tb_VitrikhoTmp.Rows.Remove(row)
            Next
            tb_VitrikhoTmp.AcceptChanges()
        End If
    End Sub
    Private Sub InsertViTriKhoTemp()
        If Is_UpdateRow = True And btnSave.Visible = True And grdViTriKho.RowCount > 0 Then

            DeleteViTriKhoTemp(cur_MSKHO)
            For Each row As DataRow In DirectCast(GridControl2.DataSource, DataTable).Rows
                Try
                    tb_VitrikhoTmp.ImportRow(row)
                Catch ex As Exception

                End Try
            Next

            Is_UpdateRow = False
            With GrdDanhsachkho
                If .FocusedRowHandle < 0 Then
                    cur_MSKHO = .FocusedRowHandle.ToString()
                Else
                    cur_MSKHO = .GetDataRow(GrdDanhsachkho.FocusedRowHandle)("MS_KHO").ToString()
                End If
            End With
        End If
    End Sub


    Private Sub grdViTriKho_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdViTriKho.CellValueChanged
        If e.Column.Name <> "VTMS_KHO" And e.Column.Name <> "VTTEN_KHO" And e.Column.Name <> "VTIS_UPDATE" Then
            If grdViTriKho.GetFocusedRowCellValue("MS_VI_TRI").ToString() = "" Then
                grdViTriKho.SetFocusedRowCellValue("MS_VI_TRI", -grdViTriKho.RowCount)
            End If
            grdViTriKho.SetFocusedRowCellValue("MS_KHO", GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString())
            grdViTriKho.SetFocusedRowCellValue("TEN_KHO", GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString())
            grdViTriKho.SetFocusedRowCellValue("IS_UPDATE", True)
            Is_UpdateRow = True
            cur_MSKHO = GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()

        End If
    End Sub

    'Private Sub GrdDanhsachkho_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GrdDanhsachkho.CellValueChanged
    '    If btnSave.Visible = True Then
    '        With GrdDanhsachkho
    '            If .FocusedRowHandle < 0 Then
    '                grdViTriKho.OptionsBehavior.Editable = False
    '            ElseIf GrdDanhsachkho.GetDataRow(GrdDanhsachkho.FocusedRowHandle)("MS_KHO").ToString() <> "" Then
    '                grdViTriKho.OptionsBehavior.Editable = True
    '            End If
    '        End With
    '    End If
    'End Sub

    Private Sub GrdDanhsachkho_MouseLeave(sender As Object, e As EventArgs) Handles GrdDanhsachkho.MouseLeave
        If btnSave.Visible = True Then
            With GrdDanhsachkho
                If .FocusedRowHandle < 0 Then
                    grdViTriKho.OptionsBehavior.Editable = False
                ElseIf GrdDanhsachkho.GetDataRow(GrdDanhsachkho.FocusedRowHandle)("MS_KHO").ToString() <> "" Then
                    grdViTriKho.OptionsBehavior.Editable = True

                End If
            End With
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim iMsKho As Integer = -1
        Dim sTenKho As String = "-1"
        Try
            sTenKho = GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString
        Catch ex As Exception
        End Try

        GrdDanhsachkho.CloseEditor()
        grdViTriKho.CloseEditor()
        InsertViTriKhoTemp()
        GrdDanhsachkho.UpdateCurrentRow()
        grdViTriKho.UpdateCurrentRow()
        'Xu ly Luu du lieu
        Dim dataView As New DataView(DirectCast(GridControl1.DataSource, DataTable), "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Dim tbDSKHO = New System.Data.DataTable()
        tbDSKHO = dataView.ToTable(True, "MS_KHO", "TEN_KHO", "DIA_CHI", "SO_DO", "ISIT", "MS_CONG_NHAN", "NGAY_LOCK", "GIO_LOCK", "UNAME", "SN_CANH_BAO", "KHO_DD", "MS_KHO_CHINH", "MS_DON_VI", "IS_UPDATE")
        Try
            dataView = New DataView(tb_VitrikhoTmp, "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        Catch ex As Exception
            dataView = New DataView(tb_VitrikhoTmp, "IS_UPDATE ='True'", "", DataViewRowState.CurrentRows)
        End Try

        Dim tbVTKHO = New System.Data.DataTable()
        tbVTKHO = dataView.ToTable(True, "MS_VI_TRI", "TEN_VI_TRI", "GHI_CHU", "MS_KHO", "TEN_KHO", "IS_UPDATE")

        'If CheckValidData() = False Then
        '    Exit Sub
        'End If

        If Save(tbDSKHO, tbVTKHO) Then
            Try
                iMsKho = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 MS_KHO FROM IC_KHO WHERE  TEN_KHO = N'" & sTenKho & "' "))
            Catch ex As Exception
                iMsKho = -1
            End Try


            isLoadDo = False
            GrdDanhsachkho.ClearColumnErrors()
            grdViTriKho.ClearColumnErrors()
            VisibleButton(True)
            LoadListKho(iMsKho)
            LockGrid(GrdDanhsachkho, True)
            LockGrid(grdViTriKho, True)
            GrdDanhsachkho.OptionsBehavior.Editable = False
            GrdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            grdViTriKho.OptionsBehavior.Editable = False
            grdViTriKho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            tb_VitrikhoTmp.Clear()

            Is_UpdateRow = False
        End If
    End Sub

    Private Sub GrdDanhsachkho_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GrdDanhsachkho.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub GrdDanhsachkho_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GrdDanhsachkho.ValidateRow
        Try
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim sTenDVD As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TEN_KHO")
            Dim sKhoDD As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("KHO_DD")
            Dim sKhoChinh As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("MS_KHO_CHINH")

            If View.GetRowCellValue(e.RowHandle, sTenDVD).ToString() = "" Then
                e.Valid = False
                View.SetColumnError(sTenDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenKhoNULL", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenKhoNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If IsDuplicateTenKho(View.GetRowCellValue(e.RowHandle, sTenDVD).ToString()) Then
                e.Valid = False
                View.SetColumnError(sTenDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenKhoNULL", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenKhoNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Try
                If View.GetRowCellValue(e.RowHandle, sKhoDD) = True Then
                    If View.GetRowCellValue(e.RowHandle, sKhoChinh).ToString() = "" Then
                        e.Valid = False
                        View.SetColumnError(sKhoChinh, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhaiChonKhoChinh", Commons.Modules.TypeLanguage))
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhaiChonKhoChinh", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdViTriKho_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grdViTriKho.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grdViTriKho_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grdViTriKho.ValidateRow
        Try
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim sTenDVD As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("TEN_VI_TRI")


            If View.GetRowCellValue(e.RowHandle, sTenDVD).ToString() = "" Then
                e.Valid = False
                View.SetColumnError(sTenDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenViTriKhoNULL", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraTenViTriKhoNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If IsDuplicateTenViTri(View.GetRowCellValue(e.RowHandle, sTenDVD).ToString()) Then
                e.Valid = False
                View.SetColumnError(sTenDVD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenViTriKhoNULL", Commons.Modules.TypeLanguage))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenViTriKhoNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GrdDanhsachkho_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GrdDanhsachkho.CellValueChanged
        If e.Column.Name.ToString() <> "KIS_UPDATE" Then
            If GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString() = "" Then
                GrdDanhsachkho.SetFocusedRowCellValue("MS_KHO", -GrdDanhsachkho.RowCount)
            End If
            If e.Column.Name.ToString() = "TEN_KHO" Then
                UpdateTenKhoTemp()
            End If
            GrdDanhsachkho.SetFocusedRowCellValue("IS_UPDATE", True)

        End If
    End Sub

    Private Sub UpdateTenKhoTemp()
        Try

            cur_TENKHO = GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString()
            If grdViTriKho.RowCount > 0 Then
                For i As Integer = 0 To grdViTriKho.RowCount - 1
                    grdViTriKho.SetRowCellValue(i, "TEN_KHO", cur_TENKHO)
                    grdViTriKho.SetRowCellValue(i, "IS_UPDATE", True)
                    Is_UpdateRow = True
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoat_Click_1(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnKhong_Click(sender As Object, e As EventArgs) Handles btnKhong.Click
        Dim iMsKho As Integer = -1
        Try
            iMsKho = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 MS_KHO FROM IC_KHO WHERE  TEN_KHO = N'" & GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString & "' "))
        Catch ex As Exception
            iMsKho = -1
        End Try

        isLoadDo = False
        GrdDanhsachkho.ClearColumnErrors()
        grdViTriKho.ClearColumnErrors()
        VisibleButton(True)
        LoadListKho(iMsKho)
        LockGrid(GrdDanhsachkho, True)
        LockGrid(grdViTriKho, True)
        GrdDanhsachkho.OptionsBehavior.Editable = False
        GrdDanhsachkho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grdViTriKho.OptionsBehavior.Editable = False
        grdViTriKho.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        tb_VitrikhoTmp.Clear()
        Is_UpdateRow = False
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        VisibleButtonDelete(False)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnTroVe.Click
        VisibleButtonDelete(True)
    End Sub

    Private Sub btnXoaVTK_Click(sender As Object, e As EventArgs) Handles btnXOA_VI_TRI.Click
        Try
            If grdViTriKho.RowCount = 0 Then Exit Sub
            Dim objIC_KHOController As New IC_KHOController

            Dim MS_VT_tmp As Integer = grdViTriKho.GetFocusedRowCellValue("MS_VI_TRI").ToString()
            'kiem ke vi tri
            If objIC_KHOController.CheckUsedKIEM_KE_PT_VI_TRI(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_KK_PT", Me.Text)

                Exit Sub
            End If
            'di chuyen vat tu
            If objIC_KHOController.CheckUsedBO_TRI_NHAP_KHO_PT(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_NHAP_KHO", Me.Text)
                Exit Sub
            End If
            'don hang nhap vat tu chi tiet
            If objIC_KHOController.CheckUsedVITRI_KHO_XUAT_PT(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_XUAT_KHO1", Me.Text)
                Exit Sub
            End If
            'vi tri kho vat tu
            If objIC_KHOController.CheckUsedVI_TRI_KHO_VAT_TU(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_XUAT_KHO3", Me.Text)
                Exit Sub
            End If
            'nhap kho vat tu
            If objIC_KHOController.CheckUsedIC_DON_HANG_NHAP_VAT_TU_CHI_TIET(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_XUAT_KHO2", Me.Text)
                Exit Sub
            End If
            If objIC_KHOController.CheckUsedIC_VAT_TU_PT(MS_VT_tmp) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_IC", Me.Text)
                Exit Sub
            End If
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_VI_TRI FROM PICK_LIST_CHI_TIET WHERE MS_VI_TRI=" & MS_VT_tmp)
            While objReader.Read
                Commons.MssBox.Show(Me.Name, "MsgPickList", Me.Text)
                objReader.Close()
                Exit Sub
            End While
            objReader.Close()
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXOA_VI_TRI", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub
            objIC_KHOController.DeleteVI_TRI_KHO(MS_VT_tmp)
            LoadVitriKho(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnXoaKho_Click(sender As Object, e As EventArgs) Handles btnXOA_KHO.Click
        Try
            Dim objKhoController As New IC_KHOController()

            If GrdDanhsachkho.RowCount <= 0 Then Exit Sub
            If GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString() = 2 Then
                Commons.MssBox.Show(Me.Name, "MsgKhoMacDinhKhongTheXoa", Me.Text)
                Exit Sub
            End If
            If grdViTriKho.RowCount > 0 Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_KHO", Me.Text)
                Exit Sub
            End If

            If objKhoController.CheckUsedIC_KHO_DH_NHAP_PT(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgUSED_PT", Me.Text)
                Exit Sub
            End If

            If objKhoController.CheckUsedIC_KHO_DH_XUAT_PT(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgXoa4", Me.Text)
                Exit Sub
            End If
            'KIEM KE
            If objKhoController.CheckUsedIC_KHO_KK_PT(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgXoa7", Me.Text)
                Exit Sub
            End If
            'VI TRI KHO
            If objKhoController.CheckUsedIC_KHO_VT_KHO(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgXoa8", Me.Text)
                Exit Sub
            End If
            'VI TRI KHO VAT TU
            If objKhoController.CheckUsedVI_TRI_KHO_VAT_TU_MS_KHO(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgXoa9", Me.Text)
                Exit Sub
            End If
            'DI CHUYEN VI TRI
            If objKhoController.CheckUsedDI_CHUYEN_VI_TRI_TRONG_KHO_MS_KHO(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString()) Then
                Commons.MssBox.Show(Me.Name, "MsgXoa10", Me.Text)
                Exit Sub
            End If
            Dim str = "SELECT * FROM NHOM_KHO INNER JOIN USERS ON NHOM_KHO.GROUP_ID=USERS.GROUP_ID WHERE MS_KHO='" & GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString() & "' AND USERNAME<>'" & Commons.Modules.UserName & "'"
            Dim objDa As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objDa.Read
                Commons.MssBox.Show(Me.Name, "MsgXoa11", Me.Text)
                Exit Sub
                objDa.Close()
            End While
            objDa.Close()
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXacNhanXoaKho", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub

            objKhoController.DeleteNHOM_KHO_1(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString(), Commons.Modules.UserName)
            objKhoController.DeleteIC_KHO(GrdDanhsachkho.GetFocusedRowCellValue("MS_KHO").ToString())
            isLoadDo = False
            LoadListKho()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GrdDanhsachkho_DoubleClick(sender As Object, e As EventArgs) Handles GrdDanhsachkho.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick(view, pt)
    End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)

        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            If Not info.Column Is Nothing Then
                If info.Column.Name = "SO_DO" Then
                    If GrdDanhsachkho.RowCount <= 0 Then Exit Sub
                    If btnSave.Visible = True Then
                        If ofdChonHinh.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                        LayDuongDan()
                    Else
                        Try
                            If GrdDanhsachkho.GetFocusedRowCellValue("SO_DO").ToString() = "" Then Exit Sub
                            If CheckServerShareExist(GrdDanhsachkho.GetFocusedRowCellValue("SO_DO").ToString()) Then
                                System.Diagnostics.Process.Start(GrdDanhsachkho.GetFocusedRowCellValue("SO_DO").ToString())
                            End If
                        Catch ex As Exception
                            Commons.MssBox.Show(Me.Name, "MsgNO_MAP_PATH", Me.Text)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
    Sub LayDuongDan()
        Try
            Dim strHinhNguon = ""
            Try
                strHinhNguon = GrdDanhsachkho.GetFocusedRowCellValue("SO_DO").ToString()
            Catch ex As Exception
                strHinhNguon = ""
            End Try

            Dim strDuongDan = ofdChonHinh.FileName
            If GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString() <> "" Then
                Dim sv As String = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 DUONG_DAN_TL FROM THONG_TIN_CHUNG")
                If CheckServerShareExist(sv) Then
                    Dim strDuongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(True, GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString())
                    Try
                        If CheckServerShareExist(strDuongDanTmp & "\" & "KHO_" & GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString() & Commons.Modules.ObjSystems.LayDuoiFile(strDuongDan)) Then
                            System.IO.File.Copy(strDuongDan, strDuongDanTmp & "\" & "KHO_" & GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString() & Commons.Modules.ObjSystems.LayDuoiFile(strDuongDan), True)
                            GrdDanhsachkho.SetFocusedRowCellValue("SO_DO", strDuongDanTmp & "\" & "KHO_" & GrdDanhsachkho.GetFocusedRowCellValue("TEN_KHO").ToString() & Commons.Modules.ObjSystems.LayDuoiFile(strDuongDan))
                        End If

                    Catch ex As Exception
                        Commons.MssBox.Show(Me.Name, "MsgLoiCopyFile", Me.Text)
                    End Try
                Else
                    Commons.MssBox.Show(Me.Name, "MsgDuongDanTaiLieuKhongTonTai", Me.Text)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function CheckServerShareExist(ByVal svAddress As String) As Boolean
        Try
            svAddress = svAddress.Trim("\".ToCharArray())
            If svAddress.Contains("\") Then
                svAddress = svAddress.Remove(svAddress.IndexOf("\", StringComparison.Ordinal))
            End If
            Return IsServerOnline(GetIP(svAddress))
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function IsServerOnline(servername As String) As Boolean
        Try
            Dim ping As New System.Net.NetworkInformation.Ping()
            Dim pingReply As System.Net.NetworkInformation.PingReply = ping.Send(servername)

            If pingReply.Status = System.Net.NetworkInformation.IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function
    Private Shared Function GetIP(servername As String) As String
        Dim ip As IPAddress = Dns.GetHostEntry(servername).AddressList.Where(Function(o) o.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork).First()
        Return ip.ToString()
    End Function
End Class