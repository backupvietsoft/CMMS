
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraEditors

Public Class frmBangtygia

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL As String
    Private NGAY_TMP As Date
    Private NGOAI_TE_TMP As String
    Dim dtTableOne As New DataTable
    Dim dtTableTwo As New DataTable

    Private blnSua As Boolean = False
#End Region

#Region "Control Event"
    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            VisibleButton(True)
            LockData(True)
            EnableButton(False)
        Else
            EnableButton(True)
            BindData()
            VisibleButton(True)
            LockData(True)
        End If
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        btnThem.Enabled = chon
        btnXoa.Enabled = chon
        btnSua.Enabled = chon
        btnNgoaiTe.Enabled = chon
        btnNgoaiTe.Enabled = chon
    End Sub
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        Dim objTIGIAController As New TI_GIAController()
        If DTP.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenThem", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            DTP.Focus()
            Exit Sub
        ElseIf DTP.Value > Now() Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayhonhientai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            DTP.Focus()
            Exit Sub
        End If

        blnThem = True
        Dim tb As New DataTable
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTI_GIA_NGOAI_TE", Format(DTP.Text, "SHORT DATE")).Tables(0)
        If tb.Rows.Count = 0 Then
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTI_GIA_NGOAI_TEs", Format(DTP.Text, "SHORT DATE")).Tables(0)
        End If
        grdTiGia.DataSource = tb
        AddTI_GIA_NGOAI_TE()

        grdTiGia.DataSource = New TI_GIAController().GetTI_GIA_NT_LOC_NGAY(Day(DTP.Value), Month(DTP.Value), Year(DTP.Value))

        ' ''
        SQL = "SELECT * FROM NGOAI_TE ORDER BY NGOAI_TE"
        dtTableTwo = New DataTable
        dtTableTwo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))

        If dtTableTwo.Rows.Count = grvTiGia.RowCount Then
            btnThem.Enabled = False
        Else
            btnThem.Enabled = True
        End If
        ' ''

        If grvTiGia.RowCount > 0 Then
            btnSua.Enabled = True
            btnXoa.Enabled = True
            BtnSua_Click(sender, e)
        Else
            btnSua.Enabled = False
            btnXoa.Enabled = False
        End If

    End Sub
    Sub AddTI_GIA_NGOAI_TE()
        For I As Integer = 0 To grvTiGia.RowCount - 1
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTI_GIA_NT",
                                   DTP.Value, grvTiGia.GetRowCellValue(I, "NGOAI_TE"),
                                   grvTiGia.GetRowCellValue(I, "TI_GIA"), DTP.Value,
                                   grvTiGia.GetRowCellValue(I, "TI_GIA_USD"))
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TI_GIA_NT_LOG", DTP.Value, grvTiGia.GetRowCellValue(I, "NGOAI_TE"), Me.Name, Commons.Modules.UserName, 1)

        Next
    End Sub
    Sub UpdateTI_GIA_NGOAI_TE(ByVal dTiGiaUSD As Double)

        For I As Integer = 0 To grvTiGia.RowCount - 1
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TI_GIA_NT_LOG", DTP.Value, grvTiGia.GetRowCellValue(I, "NGOAI_TE"), Me.Name, Commons.Modules.UserName, 2)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTI_GIA_NT",
                DTP.Value, grvTiGia.GetRowCellValue(I, "NGOAI_TE"),
                grvTiGia.GetRowCellValue(I, "TI_GIA"), DTP.Value,
                grvTiGia.GetRowCellValue(I, "TI_GIA") / dTiGiaUSD)
        Next
    End Sub
    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If grvTiGia.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenSua", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        ElseIf DTP.Value > Now() Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayhonhientai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            DTP.Focus()
            Exit Sub
        End If
        dtTableOne.Clear()
        dtTableOne.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_NT_NGAY", DTP.Text))
        Me.grdTiGia.DataSource = dtTableOne

        'Me.GrdBangtygia.Columns("NGOAI_TE").ReadOnly = True
        VisibleButton(False)
        LockData(False)
        blnThem = False

    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        Dim objTIGIAController As New TI_GIAController()
        Dim traloi As String

        If grvTiGia.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCONFIRM", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, Me.Text)
        If traloi = vbNo Then Exit Sub
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TI_GIA_NT_LOG", DTP.Value, grvTiGia.GetFocusedRowCellValue("NGOAI_TE").ToString, Me.Name, Commons.Modules.UserName, 2)
        objTIGIAController.DeleteTI_GIA_NT(DTP.Text, grvTiGia.GetFocusedRowCellValue("NGOAI_TE").ToString())
        Refesh()
        If grvTiGia.RowCount > 1 Then
            grdTiGia.DataSource = New TI_GIAController().GetTI_GIA_NT_LOC_NGAY(Day(DTP.Value), Month(DTP.Value), Year(DTP.Value))
            btnThem.Enabled = True
        Else
            BindData()
        End If
    End Sub
    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'AddTiGia()
        Dim dTiGiaUSD As Double = 0
        For I As Integer = 0 To grvTiGia.RowCount - 1
            If grvTiGia.GetRowCellValue(I, "NGOAI_TE") = "USD" Then
                dTiGiaUSD = grvTiGia.GetRowCellValue(I, "TI_GIA")
                If dTiGiaUSD <= 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTiGiaUSDPhaiLonHon1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                Exit For
            End If
        Next

        If dTiGiaUSD <= 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTiGiaUSDPhaiLonHon1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If


        UpdateTI_GIA_NGOAI_TE(dTiGiaUSD)
        Dim tb As New DataTable()
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_NT_NGAY", DTP.Text))
        Me.grdTiGia.DataSource = tb
        Me.grvTiGia.Columns("NGOAI_TE").OptionsColumn.AllowEdit = False
        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub
    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        Me.btnGhi.Enabled = True
        Refesh()
        grdTiGia.DataSource = New TI_GIAController().GetTI_GIA_NT_LOC_NGAY(Day(DTP.Value), Month(DTP.Value), Year(DTP.Value))
        blnThem = False
        Me.grvTiGia.Columns("NGOAI_TE").OptionsColumn.AllowEdit = False
        VisibleButton(True)
        LockData(True)
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub
    Private Sub DTP_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP.ValueChanged
        Dim arrNGAY As String()
        Dim NGAY_LOC As String = DTP.Text.Trim
        arrNGAY = NGAY_LOC.Split("/")
        Me.grdTiGia.DataSource = New TI_GIAController().GetTI_GIA_NT_LOC_NGAY(arrNGAY(0), arrNGAY(1), arrNGAY(2))
        Me.grvTiGia.Columns("NGOAI_TE").OptionsColumn.AllowEdit = False
        SQL = "SELECT * FROM NGOAI_TE ORDER BY NGOAI_TE"
        dtTableTwo = New DataTable
        dtTableTwo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))

        If dtTableTwo.Rows.Count = grvTiGia.RowCount Then
            btnThem.Enabled = False
        Else
            btnThem.Enabled = True
        End If
        If Me.grvTiGia.RowCount > 1 Then
            btnSua.Enabled = True
            btnXoa.Enabled = True
        Else
            btnNgoaiTe.Enabled = True
            btnSua.Enabled = False
            btnXoa.Enabled = False
        End If
    End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        'TxtMangoaite.Text = ""
        'TxtTenngoaite.Text = ""
        'ChkMacdinh.Checked = False
    End Sub

    Sub BindData()
        Try
            Dim arrNGAY As String()
            Dim NGAY_LOC As String = New TI_GIAController().Get_TI_GIA_NT_NGAY_CUOI()
            If NGAY_LOC = "" Then
                NGAY_LOC = DTP.Value.ToString()
            Else
                DTP.Value = Format(NGAY_LOC, "Short date")
            End If
            NGAY_LOC = Format(NGAY_LOC, "Short date")
            arrNGAY = NGAY_LOC.Split("/")
            Me.grdTiGia.DataSource = New TI_GIAController().GetTI_GIA_NT_LOC_NGAY(CInt(arrNGAY(0)), CInt(arrNGAY(1)), CInt(arrNGAY(2)))

            SQL = "SELECT * FROM NGOAI_TE ORDER BY NGOAI_TE"
            dtTableTwo = New DataTable
            dtTableTwo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
            If dtTableTwo.Rows.Count = grvTiGia.RowCount Then
                btnThem.Enabled = False
            Else
                btnThem.Enabled = True
            End If
            grvTiGia.Columns("TI_GIA").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
            grvTiGia.Columns("TI_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            If grvTiGia.RowCount > 0 Then
                btnSua.Enabled = True
                btnXoa.Enabled = True
            Else
                btnSua.Enabled = False
                btnXoa.Enabled = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
    End Sub

    Sub AddTiGia()
        Dim objTIGIAInfo As New TI_GIAInfo
        Dim i As Integer
        Dim TY_GIA As Double
        Dim TY_GIA2 As Double
        If Not blnThem Then
            i = 0
            While i <= dtTableOne.Rows.Count - 1
                If Not IsDBNull(dtTableOne.Rows(i).Item("TI_GIA")) Then
                    TY_GIA = CType(dtTableOne.Rows(i).Item("TI_GIA"), Double)
                Else
                    TY_GIA = 0
                End If
                If Not IsDBNull(dtTableOne.Rows(i).Item("TI_GIA_USD")) Then
                    TY_GIA2 = CType(dtTableOne.Rows(i).Item("TI_GIA_USD"), Double)
                Else
                    TY_GIA2 = 0
                End If
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTI_GIA_NT", _
                    DTP.Text, dtTableOne.Rows(i).Item("NGOAI_TE"), TY_GIA, dtTableOne.Rows(i).Item("NGAY_NHAP"), TY_GIA2)
                i = i + 1
            End While
        Else
            i = 0
            While i <= dtTableOne.Rows.Count - 1
                If Not IsDBNull(dtTableOne.Rows(i).Item("TI_GIA")) Then
                    TY_GIA = CType(dtTableOne.Rows(i).Item("TI_GIA"), Double)
                Else
                    TY_GIA = 0
                End If
                If Not IsDBNull(dtTableOne.Rows(i).Item("TI_GIA_USD")) Then
                    TY_GIA2 = CType(dtTableOne.Rows(i).Item("TI_GIA_USD"), Double)
                Else
                    TY_GIA2 = 0
                End If
                Try
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTI_GIA_NT", _
                        dtTableOne.Rows(i).Item("NGAY"), dtTableOne.Rows(i).Item("NGOAI_TE"), TY_GIA, dtTableOne.Rows(i).Item("NGAY_NHAP"), TY_GIA2)
                Catch ex As Exception

                End Try
                i = i + 1
            End While
        End If
        Refesh()
    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        btnThem.Visible = blnVisible
        btnSua.Visible = blnVisible
        btnThoat.Visible = blnVisible
        btnXoa.Visible = blnVisible
        btnNgoaiTe.Visible = blnVisible
        btnGhi.Visible = Not blnVisible
        btnKhongGhi.Visible = Not blnVisible

    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        DTP.Enabled = blnLock
        grvTiGia.OptionsBehavior.Editable = Not blnLock
    End Sub

#End Region

    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub

    Private Sub btnNgoaiTe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNgoaiTe.Click
        Dim frmNgoaite As Report1.frmNgoaite = New Report1.frmNgoaite()
        frmNgoaite.ShowDialog()
        BindData()
    End Sub
End Class