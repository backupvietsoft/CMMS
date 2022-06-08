Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue

Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic


Public Class frmKeHoachSanXuat

    Private Sub frmKeHoachSanXuat_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("LIST_BP_CP_TMP")
    End Sub

    Private Sub frmKeHoachSanXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        formatGvTheoLine()
        LoadThang()
        Try
            LoadData(DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture))
        Catch ex As Exception
        End Try
        AddHandler cbxChonThang.SelectedIndexChanged, AddressOf Me.cbxChonThang_SelectedIndexChanged
        LockControl()
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThem.Enabled = False
            btnSua.Enabled = False
            btnXoa.Enabled = False

            btnThemMay.Enabled = False
            btnSuaMay.Enabled = False
            btnXoaMay.Enabled = False
        End If
    End Sub

#Region "Ke Hoach San Xuat Theo Line"
    Private vIndexLine As Integer = 0
    Private vDataLine As New DataTable()
    Private vEventLine As String = "N"
    Private vThang As DateTime = DateTime.Now.Date

    'Dieu khien Control
    Sub LockControl()
        If vEventLine = "A" Or vEventLine = "E" Then
            If vEventLine = "A" Then
                cbxChonThang.Visible = False
                mtxtThang.Visible = True
            Else
                cbxChonThang.Visible = True
                mtxtThang.Visible = False
            End If
            btnThem.Visible = False
            btnXoa.Visible = False
            btnSua.Visible = False
            btnThoat.Visible = False
            btnGhi.Visible = True
            btnKhongGhi.Visible = True
        Else
            If vDataLine.Rows.Count > 0 Then
                btnThem.Visible = True
                btnXoa.Visible = True
                btnSua.Visible = True
                btnThoat.Visible = True
                btnGhi.Visible = False
                btnKhongGhi.Visible = False
            Else
                btnThem.Visible = True
                btnXoa.Visible = False
                btnSua.Visible = False
                btnThoat.Visible = True
                btnGhi.Visible = False
                btnKhongGhi.Visible = False
            End If
            cbxChonThang.Visible = True
            mtxtThang.Visible = False
            LockInput(True)
        End If
    End Sub
    Sub LockInput(ByVal flag As Boolean)
        gv_TheoLine.Columns("SO_GIO_KH").ReadOnly = flag
    End Sub
    Sub LoadData(ByVal vThang As DateTime)
        Try
            gv_TheoLine.AutoGenerateColumns = False
            vDataLine = New DataTable()
            vDataLine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_KE_HOACH_SAN_XUAT_THANG", vThang))
            vDataLine.Columns("SO_GIO_KH").AllowDBNull = True
            vDataLine.Columns("SO_GIO_KH").ReadOnly = False
            gv_TheoLine.DataSource = vDataLine
            gv_TheoLine.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
            gv_TheoLine.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
            gv_TheoLine.Columns("THANG").DataPropertyName = "THANG"
            gv_TheoLine.Columns("SO_GIO_KH").DataPropertyName = "SO_GIO_KH"
        Catch ex As Exception
        End Try
    End Sub
    'format Datagridview Theo Line 
    Sub formatGvTheoLine()

        Dim colMs_HT As New DataGridViewTextBoxColumn
        colMs_HT.Name = "MS_HE_THONG"
        colMs_HT.DataPropertyName = "MS_HE_THONG"
        colMs_HT.Visible = False
        gv_TheoLine.Columns.Add(colMs_HT)

        Dim colDayChuyen As New DataGridViewTextBoxColumn
        colDayChuyen.Name = "TEN_HE_THONG"
        colDayChuyen.DataPropertyName = "TEN_HE_THONG"
        colDayChuyen.ReadOnly = True
        colDayChuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDayChuyen.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
        gv_TheoLine.Columns.Add(colDayChuyen)


        Dim colThang As New DataGridViewTextBoxColumn
        colThang.Name = "THANG"
        colThang.DataPropertyName = "THANG"
        colThang.Width = 150
        colThang.MinimumWidth = 150
        colThang.ReadOnly = True
        colThang.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG", Commons.Modules.TypeLanguage)
        colThang.DefaultCellStyle.Format = "MM/yyyy"
        colThang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gv_TheoLine.Columns.Add(colThang)

        Dim colSoGio As New DataGridViewTextBoxColumn
        colSoGio.Name = "SO_GIO_KH"
        colSoGio.DataPropertyName = "SO_GIO_KH"
        colSoGio.Width = 150
        colSoGio.MinimumWidth = 150
        colSoGio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colSoGio.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO", Commons.Modules.TypeLanguage)
        'colSoGio.DefaultCellStyle.Format = "N2"
        gv_TheoLine.Columns.Add(colSoGio)

    End Sub
    Sub LoadThang()
        Dim vtbThang As New DataTable()
        vtbThang.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_THANG_KHSX"))
        cbxChonThang.DataSource = vtbThang
        cbxChonThang.DisplayMember = "THANG_NAM"
        cbxChonThang.ValueMember = "THANG"
    End Sub
    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        vEventLine = "A"
        mtxtThang.Text = DateTime.Now.ToString("MM/yyyy")
        LockControl()
        LoadDataNew(DateTime.Now.Date)
        LockInput(False)
    End Sub
    Sub LoadDataNew(ByVal _vThang As DateTime)

        Try
            gv_TheoLine.DataSource = Nothing
            gv_TheoLine.AutoGenerateColumns = False
            vDataLine = New DataTable()
            vDataLine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_NEW_KE_HOACH_SX_THANG", _vThang))
            vDataLine.Columns("SO_GIO_KH").AllowDBNull = True
            vDataLine.Columns("SO_GIO_KH").ReadOnly = False
            gv_TheoLine.Rows.Clear()
            gv_TheoLine.DataSource = vDataLine
            gv_TheoLine.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
            gv_TheoLine.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
            gv_TheoLine.Columns("THANG").DataPropertyName = "THANG"
            gv_TheoLine.Columns("SO_GIO_KH").DataPropertyName = "SO_GIO_KH"

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'H_INSERT_KE_HOACH_SAN_XUAT_THANG
        If vEventLine = "A" Then
            'Kiem tra trong thang da ton tai thang nay chua ?
            Dim vtbCheck As New DataTable()
            vtbCheck.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_KE_HOACH_SAN_XUAT_THANG", DateTime.ParseExact("01/" + mtxtThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)))
            If vtbCheck.Rows.Count > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DacoKH", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            sqlcon.Open()
            Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
            Try
                For Each gvRow As DataGridViewRow In gv_TheoLine.Rows
                    Dim vMsHT As Integer = 0
                    Dim sthang As DateTime
                    sthang = DateTime.ParseExact("01/" + mtxtThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                    Dim vSogio As Double
                    'Kiem tra ton tai
                    Dim T As Object = SqlHelper.ExecuteScalar(objTrans, "H_GET_TON_TAI_KHSX_MAY", gvRow.Cells("MS_HE_THONG").Value, sthang)
                    If CType(T, Integer) > 0 Then
                        Dim RS As MsgBoxResult = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DACO_KH_COMUONCAPNHATLAIKO" + " " + gvRow.Cells("TEN_HE_THONG").Value.ToString, Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
                        If RS = MsgBoxResult.Yes Then
                            If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                                '----
                                H_DELETE_KHSX_MAY_LINE_THANG_TONTAI(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang)
                                SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_MAY_LINE_THANG_TONTAI", gvRow.Cells("MS_HE_THONG").Value, sthang)
                                '------
                                H_INSERT_KE_HOACH_SAN_XUAT_THANG(objTrans, gvRow.Cells("MS_HE_THONG").Value, gvRow.Cells("SO_GIO_KH").Value, sthang)
                                SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_THANG", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                '------
                                H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                '------

                            End If
                        Else
                            If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                                vSogio = gvRow.Cells("SO_GIO_KH").Value

                                H_INSERT_KE_HOACH_SAN_XUAT_THANG(objTrans, gvRow.Cells("MS_HE_THONG").Value, gvRow.Cells("SO_GIO_KH").Value, sthang)
                                SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_THANG", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)

                            End If
                        End If
                    Else
                        If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                            vSogio = gvRow.Cells("SO_GIO_KH").Value
                            '----
                            H_INSERT_KE_HOACH_SAN_XUAT_THANG(objTrans, gvRow.Cells("MS_HE_THONG").Value, gvRow.Cells("SO_GIO_KH").Value, sthang)
                            SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_THANG", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)

                            '-----
                            H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                            SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                            '---
                        End If
                    End If
                Next
                objTrans.Commit()
                vEventLine = "N"
                LockControl()
                LockInput(True)
                LoadThang()
                LoadData(DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture))
            Catch ex As Exception
                objTrans.Rollback()
            Finally
                sqlcon.Close()
            End Try
        End If
        If vEventLine = "E" Then

            Dim sthang As DateTime
            sthang = DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            sqlcon.Open()
            Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
            Try
                'Xoa du lieu cu  
                For Each gvRow As DataGridViewRow In gv_TheoLine.Rows
                    If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                        Dim vtbLine As New DataTable()
                        vtbLine.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KHSX_LINE_BY_MONTH_LINE", cbxChonThang.SelectedValue, gvRow.Cells("MS_HE_THONG").Value))
                        If vtbLine.Rows.Count > 0 Then
                            If gvRow.Cells("SO_GIO_KH").Value <> vtbLine.Rows(0)("SO_GIO_KH") Then
                                Dim T As Object = SqlHelper.ExecuteScalar(objTrans, "H_GET_TON_TAI_KHSX_MAY", gvRow.Cells("MS_HE_THONG").Value, sthang)
                                If CType(T, Integer) > 0 Then
                                    Dim RS As MsgBoxResult = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DACO_KH_COMUONCAPNHATLAIKO" + " " + gvRow.Cells("TEN_HE_THONG").Value.ToString, Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
                                    If RS = MsgBoxResult.Yes Then
                                        If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                                            H_DELETE_KHSX_MAY_LINE_THANG_TONTAI(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang)
                                            SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_MAY_LINE_THANG_TONTAI", gvRow.Cells("MS_HE_THONG").Value, sthang)


                                            SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                            H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Dim T As Object = SqlHelper.ExecuteScalar(objTrans, "H_GET_TON_TAI_KHSX_MAY", gvRow.Cells("MS_HE_THONG").Value, sthang)
                            If CType(T, Integer) > 0 Then
                                Dim RS As MsgBoxResult = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DACO_KH_COMUONCAPNHATLAIKO" + " " + gvRow.Cells("TEN_HE_THONG").Value.ToString, Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
                                If RS = MsgBoxResult.Yes Then
                                    If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                                        H_DELETE_KHSX_MAY_LINE_THANG_TONTAI(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang)
                                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_MAY_LINE_THANG_TONTAI", gvRow.Cells("MS_HE_THONG").Value, sthang)
                                        '---------

                                        SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                        H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                    End If
                                Else
                                    If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then

                                        SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_THANG", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                        H_INSERT_KE_HOACH_SAN_XUAT_THANG(objTrans, gvRow.Cells("MS_HE_THONG").Value, gvRow.Cells("SO_GIO_KH").Value, sthang)
                                    End If
                                End If
                            Else
                                If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then

                                    SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                    H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(objTrans, gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                                End If
                            End If

                        End If
                    End If
                Next
                H_DELETE_KE_HOACH_SAN_XUAT_THANG_ALL(objTrans, sthang)
                SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KE_HOACH_SAN_XUAT_THANG_ALL", sthang)
                gv_TheoLine.EndEdit()
                Dim vtb As New DataTable()
                vtb = CType(gv_TheoLine.DataSource, DataTable).Copy()
                For Each gvRow As DataGridViewRow In gv_TheoLine.Rows
                    Dim vSogio As Double
                    If Not IsDBNull(gvRow.Cells("SO_GIO_KH").Value) Then
                        vSogio = gvRow.Cells("SO_GIO_KH").Value

                        SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SAN_XUAT_THANG", gvRow.Cells("MS_HE_THONG").Value, sthang, gvRow.Cells("SO_GIO_KH").Value)
                        H_INSERT_KE_HOACH_SAN_XUAT_THANG(objTrans, gvRow.Cells("MS_HE_THONG").Value, gvRow.Cells("SO_GIO_KH").Value, sthang)
                    End If
                Next
                objTrans.Commit()
                vEventLine = "N"
                LockControl()
                LockInput(True)
                LoadData(DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture))
            Catch ex As Exception
                objTrans.Rollback()
            Finally
                sqlcon.Close()
            End Try
        End If

    End Sub
    Private Sub H_DELETE_KHSX_MAY_LINE_THANG_TONTAI(ByVal objTrans As SqlTransaction, ByVal MS_HE_THONG As String, ByVal sthang As DateTime)
        Dim vtb As New DataTable
        Dim sql As String
        Try

            vtb.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KHSX_MAY_LINE_THANG_TONTAI", MS_HE_THONG, sthang))
            For Each VR As DataRow In vtb.Rows
                sql = "exec UPDATE_KE_HOACH_SX_MAY_LOG '" & VR("MS_MAY").ToString & "','" & Format(CDate(VR("THANG").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub H_DELETE_KE_HOACH_SX_MAY_THANG_LOAI_MAY(ByVal objTrans As SqlTransaction, ByVal MS_LOAI_MAY As String, ByVal sthang As DateTime)
        Dim vtb As New DataTable
        Dim sql As String
        Try

            vtb.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KE_HOACH_SX_MAY_THANG_LOAI_MAY", sthang, MS_LOAI_MAY))
            For Each VR As DataRow In vtb.Rows
                sql = "exec UPDATE_KE_HOACH_SX_MAY_LOG '" & VR("MS_MAY").ToString & "','" & Format(CDate(VR("THANG").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub H_INSERT_KE_HOACH_SAN_XUAT_THANG(ByVal objTrans As SqlTransaction, ByVal MS_HE_THONG As String, ByVal SO_GIO_KH As Double, ByVal sthang As DateTime)
        Dim sql As String
        sql = " exec UPDATE_KE_HOACH_SX_LINE_LOG '" & MS_HE_THONG & "','" & Format(CDate(sthang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
        Try
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub H_DELETE_KE_HOACH_SAN_XUAT_THANG_ALL(ByVal objTrans As SqlTransaction, ByVal sthang As DateTime)
        Try

            Dim vtbTam As New DataTable
            Dim sql As String
            vtbTam.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KE_HOACH_SAN_XUAT_THANG_ALL", sthang))
            For Each vr As DataRow In vtbTam.Rows
                sql = " exec UPDATE_KE_HOACH_SX_LINE_LOG '" & vr("MS_HE_THONG").ToString & "','" & Format(CDate(sthang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub H_DELETE_KHSX_LINE_BY_THANG(ByVal objTrans As SqlTransaction, ByVal sthang As DateTime, ByVal MS_HE_THONG As String)
        Try
            Dim sql As String
            Dim vtbTam As New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KHSX_LINE_BY_THANG", sthang, MS_HE_THONG))
            For Each vr As DataRow In vtbTam.Rows
                sql = " exec UPDATE_KE_HOACH_SX_LINE_LOG '" & vr("MS_HE_THONG").ToString & "','" & Format(CDate(sthang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub H_INSERT_KE_HOACH_SAN_XUAT_MAY_HT(ByVal objTrans As SqlTransaction, ByVal MS_HE_THONG As String, ByVal sthang As DateTime, ByVal SO_GIO_KH As Double)
        Try
            Dim vtbTam As New DataTable
            Dim sql As String
            vtbTam.Load(SqlHelper.ExecuteReader(objTrans, "H_GET_KE_HOACH_SAN_XUAT_MAY_HT", MS_HE_THONG, sthang, SO_GIO_KH))
            For Each vr As DataRow In vtbTam.Rows
                sql = "exec UPDATE_KE_HOACH_SX_MAY_LOG '" & vr("MS_MAY").ToString & "','" & Format(CDate(vr("THANG").ToString), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        vEventLine = "N"
        vDataLine.RejectChanges()
        LoadData(vThang)
        LockControl()
        LockInput(True)
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        vEventLine = "E"
        mtxtThang.Text = DateTime.Now.ToString("MM/yyyy")
        LockControl()
        LoadDataEdit(DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture))
        LockInput(False)
    End Sub

    Sub LoadDataEdit(ByVal _vThang As DateTime)
        Try
            gv_TheoLine.DataSource = Nothing
            gv_TheoLine.AutoGenerateColumns = False
            vDataLine = New DataTable()
            vDataLine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_EDIT_KE_HOACH_SAN_XUAT_THANG", _vThang))
            vDataLine.Columns("SO_GIO_KH").AllowDBNull = True
            vDataLine.Columns("SO_GIO_KH").ReadOnly = False
            gv_TheoLine.Rows.Clear()
            gv_TheoLine.DataSource = vDataLine
            gv_TheoLine.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
            gv_TheoLine.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
            gv_TheoLine.Columns("THANG").DataPropertyName = "THANG"
            gv_TheoLine.Columns("SO_GIO_KH").DataPropertyName = "SO_GIO_KH"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        Try
            Dim T As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TON_TAI_KHSX_MAY", gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value, cbxChonThang.SelectedValue)
            If CType(T, Integer) > 0 Then
                Dim RS As MsgBoxResult = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DACO_PS_CO_XOA_KHSX_MAY_KO", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNoCancel)
                If RS = MsgBoxResult.Yes Then
                    Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
                    sqlcon.Open()
                    Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
                    Try
                        H_DELETE_KHSX_MAY_LINE_THANG_TONTAI(objTrans, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value, cbxChonThang.SelectedValue)
                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_MAY_BY_LINE_OF_MONTH", gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value, cbxChonThang.SelectedValue)
                        H_DELETE_KHSX_LINE_BY_THANG(objTrans, cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_LINE_BY_THANG", cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        objTrans.Commit()
                        vEventMay = "N"
                        LoadThang()
                        LoadData(cbxChonThang.SelectedValue) 'NEU KO CON THI XOA 
                        LockControl()
                    Catch ex As Exception
                        objTrans.Rollback()
                    End Try
                ElseIf RS = MsgBoxResult.No Then
                    Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
                    sqlcon.Open()
                    Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
                    Try
                        H_DELETE_KHSX_LINE_BY_THANG(objTrans, cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_LINE_BY_THANG", cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        LoadThang()
                        LoadData(cbxChonThang.SelectedValue)
                        objTrans.Commit()
                    Catch ex As Exception
                        objTrans.Rollback()
                    End Try

                Else
                    Exit Sub
                End If
            Else


                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BancoChacMuonXoaKo", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
                    sqlcon.Open()
                    Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
                    Try
                        H_DELETE_KHSX_LINE_BY_THANG(objTrans, cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KHSX_LINE_BY_THANG", cbxChonThang.SelectedValue, gv_TheoLine.Rows(gv_TheoLine.CurrentRow.Index).Cells("MS_HE_THONG").Value)
                        LoadThang()
                        LoadData(cbxChonThang.SelectedValue)
                        objTrans.Commit()
                    Catch ex As Exception
                        objTrans.Rollback()
                    End Try

                End If
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_XOA_THANH_CONG", Commons.Modules.TypeLanguage))
        End Try
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Private Sub cbxChonThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxChonThang.SelectedIndexChanged
        LoadData(DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture))
        LockControl()
        LockInput(False)
        vThang = DateTime.ParseExact("01/" + cbxChonThang.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
    End Sub
    Private Sub mtxtThang_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtThang.Validating
        If btnKhongGhi.Focused Then
            Exit Sub
        End If
        Try
            Dim s As String = "01/" + mtxtThang.Text.Trim
            Dim vThangTMp As New DateTime()
            vThangTMp = DateTime.ParseExact(s, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            LoadDataNew(vThangTMp)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaDungDinhDang", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub
    Private Sub gv_TheoLine_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_TheoLine.CellValidating
        If btnGhi.Visible Then
            If btnKhongGhi.Focused Then
                Exit Sub
            End If
            gv_TheoLine.EndEdit()
            If gv_TheoLine.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
                If gv_TheoLine.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue.ToString.Trim = "" Then
                    Exit Sub
                End If

                If gv_TheoLine.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue = "0" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLonHonKo", Commons.Modules.TypeLanguage))
                    e.Cancel = True
                End If
                Try
                    Dim vso As Double

                    vso = Double.Parse(gv_TheoLine.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue)
                    If vso < 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLonHonKo", Commons.Modules.TypeLanguage))
                        e.Cancel = True
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub gv_TheoLine_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gv_TheoLine.DataError
        If gv_TheoLine.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLaSo", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "Ke hoach san xuat may"

    Private vEventMay As String
    Private vIndexMay As Integer

    Private Sub bcxThangMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles bcxThangMay.SelectedIndexChanged
        If vEventMay = "A" Or vEventMay = "E" Then
            LoadDataMayEdit(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
        Else
            LoadLoaiMay(bcxThangMay.SelectedValue)
            LoadDataMay(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
            LockControlMay()
        End If
    End Sub

    Private Sub cbxLoaiMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxLoaiMay.SelectedIndexChanged
        Try
            If vEventMay = "A" Or vEventMay = "E" Then
                If vEventMay = "A" Then
                    Dim _vtg As DateTime
                    _vtg = DateTime.ParseExact("01/" + mtxtThangMay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                    If cbxLoaiMay.SelectedValue.ToString = "-1" Then
                        vtDataViewMay.RowFilter = "MS_LOAI_MAY <> '" + cbxLoaiMay.SelectedValue.ToString + "'"
                        gv_May.DataSource = vtDataViewMay
                    Else
                        vtDataViewMay.RowFilter = "MS_LOAI_MAY = '" + cbxLoaiMay.SelectedValue.ToString + "'"
                        gv_May.DataSource = vtDataViewMay
                    End If
                Else
                    LoadDataMayEdit(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
                End If
            Else
                LoadDataMay(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGhiMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiMay.Click
        If vEventMay = "E" Then
            Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            sqlcon.Open()
            Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
            Try
                H_DELETE_KE_HOACH_SX_MAY_THANG_LOAI_MAY(objTrans, cbxLoaiMay.SelectedValue, bcxThangMay.SelectedValue)
                SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_KE_HOACH_SX_MAY_THANG_LOAI_MAY", bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
                gv_May.EndEdit()
                For Each vRowMay As DataGridViewRow In gv_May.Rows
                    Dim vSogio As Double
                    Dim MS_HE_THONG As String = ""
                    If Not IsDBNull(vRowMay.Cells("SO_GIO_KH").Value) Then
                        vSogio = vRowMay.Cells("SO_GIO_KH").Value
                        If Not IsDBNull(vRowMay.Cells("MS_HE_THONG").Value) Then
                            MS_HE_THONG = vRowMay.Cells("MS_HE_THONG").Value
                        End If

                        SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SX_MAY", vRowMay.Cells("MS_MAY").Value, bcxThangMay.SelectedValue, vRowMay.Cells("SO_GIO_KH").Value, vRowMay.Cells("MS_HE_THONG").Value)
                        H_INSERT_KE_HOACH_SX_MAY(objTrans, vRowMay.Cells("MS_MAY").Value, bcxThangMay.SelectedValue, vRowMay.Cells("SO_GIO_KH").Value, MS_HE_THONG)
                    End If
                Next
                objTrans.Commit()
                vEventMay = "N"
                LoadDataMay(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
                LockControlMay()
                LockInputmay(True)
            Catch ex As Exception
                objTrans.Rollback()
            End Try
        End If
        If vEventMay = "A" Then
            Dim _vthg As DateTime
            _vthg = DateTime.ParseExact("01/" + mtxtThangMay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            Dim T As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TON_TAI_KHSX_MAY_THANG", _vthg)
            If (CType(T, Integer) > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG_DA_TON_TAI", Commons.Modules.TypeLanguage))
                Exit Sub
            Else
                Dim sqlcon As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
                sqlcon.Open()
                Dim objTrans As SqlTransaction = sqlcon.BeginTransaction
                Try
                    Dim vtbt As New DataTable
                    vtbt = vtDataViewMay.Table
                    For Each vRowMay As DataRow In vtbt.Rows
                        Dim vSogio As Double
                        Dim MS_HE_THONG As String = ""
                        If Not IsDBNull(vRowMay("SO_GIO_KH")) Then
                            vSogio = vRowMay("SO_GIO_KH")
                            If vSogio > 0 Then
                                If Not IsDBNull(vRowMay("MS_HE_THONG")) Then
                                    MS_HE_THONG = vRowMay("MS_HE_THONG")
                                End If
                                H_INSERT_KE_HOACH_SX_MAY(objTrans, vRowMay("MS_MAY"), bcxThangMay.SelectedValue, vRowMay("SO_GIO_KH"), vRowMay("MS_HE_THONG"))
                                SqlHelper.ExecuteNonQuery(objTrans, "H_INSERT_KE_HOACH_SX_MAY", vRowMay("MS_MAY"), _vthg, vRowMay("SO_GIO_KH"), vRowMay("MS_HE_THONG"))
                            End If
                        End If
                    Next
                    objTrans.Commit()
                    vEventMay = "N"
                    LoadThangMay()
                    LoadDataMay(_vthg, "-1")
                    LockControlMay()
                    LockInputmay(True)
                Catch ex As Exception
                    objTrans.Rollback()
                End Try

            End If

        End If
    End Sub
    Private Sub H_INSERT_KE_HOACH_SX_MAY(ByVal objTrans As SqlTransaction, ByVal MS_MAY As String, ByVal THANG As DateTime, ByVal SO_GIO_KH As Double, ByVal MS_HE_THONG As String)
        Dim sql As String
        Try
            sql = "exec UPDATE_KE_HOACH_SX_MAY_LOG '" & MS_MAY & "','" & Format(CDate(THANG), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnKhongGhiMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhiMay.Click
        vEventMay = "N"
        LoadThangMay()
        LoadLoaiMay(bcxThangMay.SelectedValue)
        LockControlMay()
    End Sub

    Private Sub btnSuaMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuaMay.Click
        vEventMay = "E"
        LoadLoaiMayEdit()
        LockControlMay()
        LockInputmay(False)
    End Sub

    Private Sub btnXoaMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaMay.Click
        Dim sql As String
        Try
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BancoChacMuonXoaKHMayKo", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                sql = "exec UPDATE_KE_HOACH_SX_MAY_LOG '" & gv_May.Rows(gv_May.CurrentRow.Index).Cells("MS_MAY").Value & "','" & Format(CDate(bcxThangMay.SelectedValue), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DELETE_MAY_KHXS_MAY", gv_May.Rows(gv_May.CurrentRow.Index).Cells("MS_MAY").Value, bcxThangMay.SelectedValue)
                'LoadThang()
                LoadDataMay(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoatMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatMay.Click
        Me.Close()
    End Sub

    Private Sub btnThemMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemMay.Click
        RemoveHandler cbxLoaiMay.SelectedIndexChanged, AddressOf Me.cbxLoaiMay_SelectedIndexChanged
        vEventMay = "A"
        gv_May.DataSource = Nothing
        cbxLoaiMay.DataSource = Nothing
        mtxtThangMay.Text = ""
        LockControlMay()
        LockInputmay(False)
        AddHandler cbxLoaiMay.SelectedIndexChanged, AddressOf Me.cbxLoaiMay_SelectedIndexChanged
    End Sub

    Private Sub mtxtThangMay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtThangMay.Validating
        Try
            If mtxtThangMay.Text.Trim = "/" Then
                Exit Sub
            End If
            Dim _vthg As DateTime
            _vthg = DateTime.ParseExact("01/" + mtxtThangMay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            Dim T As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TON_TAI_KHSX_MAY_THANG", _vthg)
            If (CType(T, Integer) > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG_DA_TON_TAI", Commons.Modules.TypeLanguage))
                Exit Sub
            Else
                mtxtThangMay.Text = _vthg.ToString("MM/yyyy")
                LoadLoaiMayEdit()
                LoadDataNewMay(_vthg, "-1")
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DD", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub gv_May_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_May.CellValidating
        If btnGhiMay.Visible Then
            If btnKhongGhiMay.Focused Then
                Exit Sub
            End If
            gv_May.EndEdit()
            If gv_May.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
                If gv_May.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue = "0" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLonHonKo", Commons.Modules.TypeLanguage))
                    e.Cancel = True
                End If

                Try
                    Dim vso As Double
                    vso = Double.Parse(gv_May.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue)
                    If vso < 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLonHonKo", Commons.Modules.TypeLanguage))
                        e.Cancel = True
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub gv_May_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gv_May.DataError
        If gv_May.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SoGioPhaiLaSo", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End If
    End Sub

    Dim vtDataViewMay As New DataView()

    Sub LoadDataNewMay(ByVal _thang As DateTime, ByVal _loaimay As String)
        Dim vttb As New DataTable()
        vttb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_NEW_KHSX_MAY", _thang, _loaimay))
        vttb.Columns("SO_GIO_KH").ReadOnly = False
        vtDataViewMay = vttb.DefaultView
        gv_May.DataSource = vtDataViewMay

    End Sub
    Sub LockControlMay()
        If vEventMay = "A" Or vEventMay = "E" Then
            If vEventMay = "A" Then
                bcxThangMay.Visible = False
                mtxtThangMay.Visible = True
            Else
                bcxThangMay.Visible = True
                mtxtThangMay.Visible = False
                bcxThangMay.Enabled = False
            End If
            btnGhiMay.Visible = True
            btnKhongGhiMay.Visible = True
            btnSuaMay.Visible = False
            btnXoaMay.Visible = False
            btnThoatMay.Visible = False
            btnThemMay.Visible = False
        Else
            If gv_May.Rows.Count > 0 Then
                btnGhiMay.Visible = False
                btnKhongGhiMay.Visible = False
                btnSuaMay.Visible = True
                btnXoaMay.Visible = True
                btnThoatMay.Visible = True
                bcxThangMay.Visible = True
                mtxtThangMay.Visible = False
                bcxThangMay.Enabled = True
                btnThemMay.Visible = True
            Else
                btnGhiMay.Visible = False
                btnKhongGhiMay.Visible = False
                btnSuaMay.Visible = False
                btnXoaMay.Visible = False
                btnThoatMay.Visible = True
                bcxThangMay.Visible = True
                mtxtThangMay.Visible = False
                bcxThangMay.Enabled = True
                btnThemMay.Visible = True
            End If
        End If
    End Sub
    Sub LockInputmay(ByVal flag As Boolean)
        Try
            gv_May.Columns("SO_GIO_KH").ReadOnly = flag
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadThangMay()
        Try
            Dim vtbThangMay As New DataTable()
            vtbThangMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_THANG_KHSX_MAY"))
            bcxThangMay.DataSource = vtbThangMay
            bcxThangMay.DisplayMember = "THANG_NAM"
            bcxThangMay.ValueMember = "THANG"
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadLoaiMay(ByVal _vThang As DateTime)
        cbxLoaiMay.Display = "TEN_LOAI_MAY"
        cbxLoaiMay.Value = "MS_LOAI_MAY"
        cbxLoaiMay.StoreName = "H_GET_LOAI_MAY_KHSX_THANG"
        cbxLoaiMay.Param = _vThang
        cbxLoaiMay.BindDataSource()
    End Sub
    Sub LoadLoaiMayEdit()
        cbxLoaiMay.Display = "TEN_LOAI_MAY"
        cbxLoaiMay.Value = "MS_LOAI_MAY"
        cbxLoaiMay.StoreName = "H_GET_LOAI_MAY_KHSX_MAY_EDIT"
        cbxLoaiMay.BindDataSource()

    End Sub
    Sub FormatGV_May()
        gv_May.Columns.Clear()
        Dim colMS_MAY As New DataGridViewTextBoxColumn
        colMS_MAY.Name = "MS_MAY"
        colMS_MAY.DataPropertyName = "MS_MAY"
        colMS_MAY.Width = 150
        colMS_MAY.MinimumWidth = 150
        colMS_MAY.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
        colMS_MAY.ReadOnly = True
        gv_May.Columns.Add(colMS_MAY)

        Dim colTen_May As New DataGridViewTextBoxColumn
        colTen_May.Name = "TEN_MAY"
        colTen_May.DataPropertyName = "TEN_MAY"
        colTen_May.ReadOnly = True
        colTen_May.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colTen_May.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_MAY", Commons.Modules.TypeLanguage)
        gv_May.Columns.Add(colTen_May)

        Dim colTenHeThong As New DataGridViewTextBoxColumn
        colTenHeThong.Name = "TEN_HE_THONG"
        colTenHeThong.DataPropertyName = "TEN_HE_THONG"
        colTenHeThong.ReadOnly = True
        colTenHeThong.Width = 150
        colTenHeThong.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_HE_THONG", Commons.Modules.TypeLanguage)
        gv_May.Columns.Add(colTenHeThong)


        Dim colThang As New DataGridViewTextBoxColumn
        colThang.Name = "THANG"
        colThang.DataPropertyName = "THANG"
        colThang.Width = 150
        colThang.MinimumWidth = 150
        colThang.ReadOnly = True
        colThang.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG_MAY", Commons.Modules.TypeLanguage)
        colThang.DefaultCellStyle.Format = "MM/yyyy"
        colThang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gv_May.Columns.Add(colThang)

        Dim colSoGio As New DataGridViewTextBoxColumn
        colSoGio.Name = "SO_GIO_KH"
        colSoGio.DataPropertyName = "SO_GIO_KH"
        colSoGio.Width = 150
        colSoGio.MinimumWidth = 150
        colSoGio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colSoGio.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_MAY", Commons.Modules.TypeLanguage)
        'colSoGio.DefaultCellStyle.Format = "N2"
        gv_May.Columns.Add(colSoGio)

        Dim coLMS_HT As New DataGridViewTextBoxColumn
        coLMS_HT.Name = "MS_HE_THONG"
        coLMS_HT.DataPropertyName = "MS_HE_THONG"
        coLMS_HT.Visible = False
        gv_May.Columns.Add(coLMS_HT)

    End Sub
    Sub LoadDataMay(ByVal _vthang As DateTime, ByVal _vLoaiMay As String)
        'H_EDIT_KHSX_MAY_THANG
        Try
            Dim vtb As New DataTable()
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_KHSX_MAY_THANG", _vLoaiMay, _vthang))
            gv_May.AutoGenerateColumns = False
            gv_May.DataSource = vtb
            gv_May.Columns("MS_MAY").DataPropertyName = "MS_MAY"
            gv_May.Columns("TEN_MAY").DataPropertyName = "TEN_MAY"
            gv_May.Columns("THANG").DataPropertyName = "THANG"
            gv_May.Columns("SO_GIO_KH").DataPropertyName = "SO_GIO_KH"
            gv_May.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
            gv_May.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadDataMayEdit(ByVal _vthang As DateTime, ByVal _vLoaiMay As String)
        Try
            Dim vtb As New DataTable()
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_EDIT_KHSX_MAY_THANG", _vLoaiMay, _vthang))
            gv_May.AutoGenerateColumns = False
            gv_May.DataSource = vtb
            gv_May.Columns("MS_MAY").DataPropertyName = "MS_MAY"
            gv_May.Columns("TEN_MAY").DataPropertyName = "TEN_MAY"
            gv_May.Columns("THANG").DataPropertyName = "THANG"
            gv_May.Columns("SO_GIO_KH").DataPropertyName = "SO_GIO_KH"
            gv_May.Columns("MS_HE_THONG").DataPropertyName = "MS_HE_THONG"
            gv_May.Columns("TEN_HE_THONG").DataPropertyName = "TEN_HE_THONG"
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub tbl_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tbl.Selecting
        If btnGhi.Visible = True Or btnGhiMay.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If e.TabPage.Name = "tpagTheoMay" Then
            FormatGV_May()
            LoadThangMay()
            LoadLoaiMay(bcxThangMay.SelectedValue)
            LoadDataMay(bcxThangMay.SelectedValue, cbxLoaiMay.SelectedValue)
            LockControlMay()
            LockInputmay(True)
            AddHandler bcxThangMay.SelectedIndexChanged, AddressOf Me.bcxThangMay_SelectedIndexChanged
            AddHandler cbxLoaiMay.SelectedIndexChanged, AddressOf Me.cbxLoaiMay_SelectedIndexChanged
        End If

    End Sub

End Class