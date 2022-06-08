Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue
Imports DevExpress.XtraEditors

Public Class frmChonPT

    Private callback As QLCallBackEvent

    Public Sub New(ByVal callback As QLCallBackEvent)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.callback = callback
    End Sub

    Private Sub frmChonPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        LoadLoaiVT()
        LoadLoaiTB()
        LoadLoaiPT()
        BindData()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        AddHandler Me.utcComboLoaiVT.SelectedIndexChanged, AddressOf Me.utcComboLoaiVT_SelectedIndexChanged
        AddHandler cboLOAI_PHU_TUNG.SelectedIndexChanged, AddressOf Me.cboLOAI_PHU_TUNG_SelectedIndexChanged
        AddHandler cboLOAI_THIET_BI.SelectedIndexChanged, AddressOf Me.cboLOAI_THIET_BI_SelectedIndexChanged
    End Sub

    Function CreateQuery() As String
        Dim sql As String = "SELECT DISTINCT PT.MS_PT, PT.MS_PT_NCC AS PARTNO, PT.MS_PT_CTY AS ITEMCODE, PT.TEN_PT,  LVT.TEN_LOAI_VT_TV , LVT.TEN_LOAI_VT_TA , PT.ANH_PT , VI_TRI_KHO.MS_KHO, dbo.IC_KHO.TEN_KHO "
        Dim from As String = " FROM IC_PHU_TUNG PT INNER JOIN VI_TRI_KHO ON PT.MS_VI_TRI=VI_TRI_KHO.MS_VI_TRI INNER JOIN dbo.IC_KHO ON dbo.IC_KHO.MS_KHO = VI_TRI_KHO.MS_KHO , LOAI_VT LVT , IC_PHU_TUNG_LOAI_PHU_TUNG PTLPT,LOAI_PHU_TUNG LPT   , NHOM_LOAI_PHU_TUNG NLPT, NHOM NHM , USERS US "
        'Dim condition As String = " WHERE LVT.MS_LOAI_VT=PT.MS_LOAI_VT AND LPT.MS_LOAI_PT =PTLPT.MS_LOAI_PT AND PT.MS_PT = PTLPT.MS_PT AND LPT.MS_LOAI_PT=NLPT.MS_LOAI_PT AND NHM.GROUP_ID=NLPT.GROUP_ID AND NHM.GROUP_ID = US.GROUP_ID AND USERNAME='" + Commons.Modules.UserName + "' AND (PT.MS_VI_TRI IS NOT NULL OR PT.MS_VI_TRI<>'') AND VI_TRI_KHO.MS_KHO=" & FrmPhieuNhapKhoVatTu.cboKHO.SelectedValue
        Dim condition As String = " WHERE LVT.MS_LOAI_VT=PT.MS_LOAI_VT AND LPT.MS_LOAI_PT =PTLPT.MS_LOAI_PT AND PT.MS_PT = PTLPT.MS_PT AND LPT.MS_LOAI_PT=NLPT.MS_LOAI_PT AND NHM.GROUP_ID=NLPT.GROUP_ID AND NHM.GROUP_ID = US.GROUP_ID AND USERNAME='" + Commons.Modules.UserName + "'"

        'Dim sql As String = "SELECT DISTINCT PT.MS_PT, PT.MS_PT_NCC AS PARTNO, PT.MS_PT_CTY AS ITEMCODE, PT.TEN_PT,  LVT.TEN_LOAI_VT_TV , LVT.TEN_LOAI_VT_TA , PT.ANH_PT"
        'Dim from As String = " FROM dbo.LOAI_PHU_TUNG LPT INNER JOIN dbo.IC_PHU_TUNG_LOAI_PHU_TUNG PTLPT ON LPT.MS_LOAI_PT = PTLPT.MS_LOAI_PT INNER JOIN dbo.IC_PHU_TUNG PT INNER JOIN dbo.LOAI_VT LVT ON PT.MS_LOAI_VT = LVT.MS_LOAI_VT ON PTLPT.MS_PT = PT.MS_PT INNER JOIN dbo.NHOM_LOAI_PHU_TUNG NLPT ON LPT.MS_LOAI_PT = NLPT.MS_LOAI_PT INNER JOIN dbo.NHOM NHM ON NLPT.GROUP_ID = NHM.GROUP_ID INNER JOIN dbo.USERS US ON NHM.GROUP_ID = US.GROUP_ID "
        'Dim condition As String = " WHERE LVT.MS_LOAI_VT=PT.MS_LOAI_VT AND LPT.MS_LOAI_PT =PTLPT.MS_LOAI_PT AND PT.MS_PT = PTLPT.MS_PT AND LPT.MS_LOAI_PT=NLPT.MS_LOAI_PT AND NHM.GROUP_ID=NLPT.GROUP_ID AND NHM.GROUP_ID = US.GROUP_ID AND USERNAME='" + Commons.Modules.UserName + "'"
        If Not (Me.utcComboLoaiVT.SelectedValue.ToString.Equals("-1")) Then
            from += ""
            condition += "  AND LVT.MS_LOAI_VT='" + Me.utcComboLoaiVT.SelectedValue.ToString + "' "
        End If


        If Not (Me.cboLOAI_PHU_TUNG.SelectedValue.ToString.Equals("-1")) Then
            from += " "
            condition += " AND LPT.MS_LOAI_PT=" + Me.cboLOAI_PHU_TUNG.SelectedValue.ToString
        End If

        If Not (Me.cboLOAI_THIET_BI.SelectedValue.ToString.Equals("-1")) Then
            from += ", IC_PHU_TUNG_LOAI_MAY PTLM, LOAI_MAY LM"
            condition += " AND LM.MS_LOAI_MAY=PTLM.MS_LOAI_MAY AND PT.MS_PT=PTLM.MS_PT AND LM.MS_LOAI_MAY='" + Me.cboLOAI_THIET_BI.SelectedValue.ToString + "' "
        End If
        sql = sql + from + condition
        Return sql
    End Function

    Sub BindData()
        'Dim column As New DataGridViewCheckBoxColumn
        'grdChonPT.Columns.Clear()
        'With column
        '    .Name = "chkChon"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .FlatStyle = FlatStyle.Standard
        '    .CellTemplate = New DataGridViewCheckBoxCell()
        '    .CellTemplate.Style.BackColor = Color.Beige
        'End With

        Dim dtTableTam As DataTable = New DataTable()
        dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_SEARCH", CreateQuery))
        grdChonPT.AutoGenerateColumns = False
        Dim PKey(1) As DataColumn
        PKey(0) = dtTableTam.Columns("MS_PT")
        dtTableTam.PrimaryKey = PKey
        For i As Integer = 0 To FrmPhieuNhapKhoVatTu.grdNhapkhoPTCT.Rows.Count - 1
            Try
                dtTableTam.Rows.Remove(dtTableTam.Rows.Find(FrmPhieuNhapKhoVatTu.grdNhapkhoPTCT.Rows(i).Cells("MS_PT").Value))
            Catch ex As Exception

            End Try
        Next

        grdChonPT.DataSource = dtTableTam

        With grdChonPT
            .Columns("MS_PT").DataPropertyName = "MS_PT"
            .Columns("ITEMCODE").DataPropertyName = "ITEMCODE"
            .Columns("PARTNO").DataPropertyName = "PARTNO"
            .Columns("TEN_PT").DataPropertyName = "TEN_PT"
            .Columns("TEN_LOAI_VT_TV").DataPropertyName = "TEN_LOAI_VT_TV"
            .Columns("MS_KHO").DataPropertyName = "MS_KHO"
            .Columns("TEN_KHO").DataPropertyName = "TEN_KHO"
            .Columns("chkChon").Visible = True
        End With


        If grdChonPT.RowCount > 0 Then
            grdChonPT.Rows(0).Selected = True
        End If
        'Me.grdChonPT.Columns.Insert(0, column)
        Call FormatGrid()
        RefeshLanguage()

    End Sub

    Sub FormatGrid()
        'With grdChonPT
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        '    .Columns("MS_PT").Width = 120
        '    .Columns("MS_PT").ReadOnly = True
        '    .Columns("ITEMCODE").Width = 100
        '    .Columns("ITEMCODE").ReadOnly = True
        '    .Columns("PARTNO").Width = 100
        '    .Columns("PARTNO").ReadOnly = True
        '    .Columns("TEN_PT").Width = 250
        '    .Columns("TEN_PT").ReadOnly = True
        '    '.Columns("TEN_LOAI_VT_TV").Width = 100
        '    .Columns("TEN_LOAI_VT_TV").ReadOnly = True
        '    .Columns("TEN_LOAI_VT_TV").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    '.Columns("TEN_LOAI_VT_TA").Width = 100
        '    .Columns("TEN_LOAI_VT_TA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    .Columns("TEN_LOAI_VT_TA").ReadOnly = True
        '    .Columns("ANH_PT").Visible = False
        '    '.Columns("MS_KHO").Visible = False
        '    .Columns("chkChon").Width = 60
        '    .Columns("chkChon").Visible = True
        '    .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        '    .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        'End With

    End Sub

    Private Sub RefeshLanguage()
        'Me.grdChonPT.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("ITEMCODE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "ITEMCODE", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("PARTNO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "PARTNO", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("TEN_LOAI_VT_TV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_VT_TV", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("TEN_LOAI_VT_TA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_VT_TA", commons.Modules.TypeLanguage)
        'Me.grdChonPT.Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
        'If commons.Modules.TypeLanguage = 1 Then
        '    Me.grdChonPT.Columns("TEN_LOAI_VT_TV").Visible = False
        'Else
        '    Me.grdChonPT.Columns("TEN_LOAI_VT_TA").Visible = False
        'End If

    End Sub

    Sub LoadLoaiVT()
        utcComboLoaiVT.Value = "MS_LOAI_VT"
        Select Case Commons.Modules.TypeLanguage
            Case 0
                utcComboLoaiVT.Display = "TEN_LOAI_VT_TV"
                Exit Select
            Case 1
                utcComboLoaiVT.Display = "TEN_LOAI_VT_TA"
                Exit Select
            Case 2
                utcComboLoaiVT.Display = "TEN_LOAI_VT_TH"
                Exit Select

        End Select
        utcComboLoaiVT.StoreName = "QL_LOAD_LIST_LOAI_VAT_TU"
        utcComboLoaiVT.BindDataSource()
    End Sub

    Sub LoadLoaiPT()
        cboLOAI_PHU_TUNG.Value = "MS_LOAI_PT"
        cboLOAI_PHU_TUNG.Display = "TEN_LOAI_PT"
        cboLOAI_PHU_TUNG.StoreName = "QL_LOAD_LIST_LOAI_PHU_TUNG"
        cboLOAI_PHU_TUNG.Param = Commons.Modules.UserName
        cboLOAI_PHU_TUNG.BindDataSource()
    End Sub

    Sub LoadLoaiTB()
        cboLOAI_THIET_BI.Value = "MS_LOAI_MAY"
        cboLOAI_THIET_BI.Display = "TEN_LOAI_MAY"
        cboLOAI_THIET_BI.StoreName = "QL_LOAD_LIST_LOAI_MAY"
        cboLOAI_THIET_BI.Param = Commons.Modules.UserName
        cboLOAI_THIET_BI.BindDataSource()
    End Sub

    Function CheckStatus() As Boolean
        Dim lFlag As Boolean = False
        Dim i As Integer
        For i = 0 To grdChonPT.Rows.Count - 1
            If grdChonPT.Rows(i).Cells("chkChon").Value = True Then
                lFlag = True
                Exit For
            End If
        Next
        Return lFlag
    End Function

    Private Sub btnTrove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrove.Click
        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon.Click
        Dim i As Integer
        While i < grdChonPT.RowCount
            grdChonPT.Rows(i).Cells("chkChon").Value = True
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChon.Click
        Dim i As Integer
        While i < grdChonPT.RowCount
            grdChonPT.Rows(i).Cells("chkChon").Value = False
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThuchien.Click
        For k As Integer = 0 To Me.grdChonPT.RowCount - 1
            If Me.grdChonPT.Rows(k).Cells("chkChon").Value = True Then
                If Not Me.grdChonPT.Rows(k).Cells("MS_KHO").Value.Equals(FrmPhieuNhapKhoVatTu.cboKHO.SelectedValue) Then
                    If (XtraMessageBox.Show("Vật tư " & grdChonPT.Rows(k).Cells("MS_PT").Value.ToString().Trim() & " không cùng kho với kho đã chọn bạn có muốn tiếp tục không?", "Vietsoft", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then
                        grdChonPT.CurrentCell = grdChonPT.Rows(k).Cells(0)
                        Exit Sub
                    End If
                End If
            End If
        Next
        Commons.Modules.HasTableVT.Clear()
        Dim counter As Integer = 0
        For i As Integer = 0 To Me.grdChonPT.RowCount - 1
            If Me.grdChonPT.Rows(i).Cells("chkChon").Value = True Then
                Commons.Modules.HasTableVT.Add(counter, Me.grdChonPT.Rows(i).Cells("MS_PT").Value)
                counter += 1
            End If
        Next
        If Commons.Modules.HasTableVT.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SELECT_VAT_TU", Commons.Modules.TypeLanguage))
            Return
        End If
        Me.callback.Called(Commons.Modules.HasTableVT)
        Me.Close()
    End Sub

    Private Sub cboLOAI_THIET_BI_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub utcComboLoaiVT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub cboLOAI_PHU_TUNG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub grdChonPT_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChonPT.CellClick
        If e.RowIndex >= 0 Then Me.grdChonPT.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub btnViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewImage.Click

        If Me.grdChonPT.RowCount < 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VAT_TU_CAN_XEM_HINH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If
        Try
            Dim objPTUNG As IC_PHU_TUNG_Info = Me.Load_Phu_Tung(Me.grdChonPT.CurrentRow.Cells("MS_PT").Value.ToString)
            If objPTUNG.ANH_PT Is Nothing Or objPTUNG.ANH_PT = "" Then
                MsgBox(objPTUNG.MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CO_DUONG_DAN_HINH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
                Return
            End If
            System.Diagnostics.Process.Start(objPTUNG.ANH_PT)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgINVALID_PATH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
        End Try
    End Sub

    Function Load_Phu_Tung(ByVal MS_PT As String) As IC_PHU_TUNG_Info
        Dim objPhuTung As IC_PHU_TUNG_Info = QLBusinessDataController.FillObject(Of IC_PHU_TUNG_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_PHU_TUNG", MS_PT))
        Return objPhuTung
    End Function
    Dim thutu As Integer = -1
    Dim GiaTri As String = ""
    Private Sub txtTimPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimPT.KeyDown
        '        If e.KeyCode = 13 Then
        '            Dim i As Integer
        '            If GiaTri <> txtTimPT.Text.ToUpper.Trim Then
        '                GiaTri = txtTimPT.Text.ToUpper.Trim
        '                GoTo BatDau
        '            End If
        '            If thutu = -1 Then
        'BatDau:
        '                For i = 0 To grdChonPT.RowCount - 1
        '                    If grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimPT.Text.ToUpper.Trim) Or txtTimPT.Text.ToUpper.Trim.Contains(grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
        '                        thutu = i
        '                        grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("chkChon")
        '                        txtTimPT.Focus()
        '                        Exit Sub
        '                    Else
        '                        grdChonPT.Rows(i).Cells("chkChon").Selected = False
        '                    End If
        '                Next
        '            Else
        '                For i = thutu + 1 To grdChonPT.RowCount - 1
        '                    If grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimPT.Text.ToUpper.Trim) Or txtTimPT.Text.ToUpper.Trim.Contains(grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
        '                        thutu = i
        '                        grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("chkChon")
        '                        txtTimPT.Focus()
        '                        Exit Sub
        '                    Else
        '                        grdChonPT.Rows(i).Cells("chkChon").Selected = False
        '                    End If
        '                Next
        '                If i = grdChonPT.Rows.Count Then
        '                    GoTo BatDau
        '                End If
        '            End If
        '        End If
    End Sub


    Private Sub txtTenVT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTenVT.KeyPress
        Try
            If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
                Dim i As Integer
                If GiaTri <> txtTenVT.Text.ToUpper.Trim Then
                    GiaTri = txtTenVT.Text.ToUpper.Trim
                    GoTo BatDau
                End If
                If thutu = -1 Then
BatDau:
                    For i = 0 To grdChonPT.RowCount - 1

                        If String.Compare(txtTenVT.Text.ToUpper.Trim, 0, grdChonPT.Rows(i).Cells("TEN_PT").Value.ToString, 0, txtTenVT.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("MS_PT")
                            grdChonPT.Rows(i).Selected = True
                            txtTenVT.Focus()
                            Exit Sub
                        End If
                    Next
                Else
                    For i = 0 To grdChonPT.RowCount - 1

                        If String.Compare(txtTenVT.Text.ToUpper.Trim, 0, grdChonPT.Rows(i).Cells("TEN_PT").Value.ToString, 0, txtTenVT.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("MS_PT")
                            grdChonPT.Rows(i).Selected = True
                            txtTenVT.Focus()
                            Exit Sub
                        End If
                    Next

                    If i = grdChonPT.Rows.Count Then
                        GoTo BatDau
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTimPT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimPT.KeyPress
        Try
            If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
                Dim i As Integer
                If GiaTri <> txtTimPT.Text.ToUpper.Trim Then
                    GiaTri = txtTimPT.Text.ToUpper.Trim
                    GoTo BatDau
                End If
                If thutu = -1 Then
BatDau:
                    For i = 0 To grdChonPT.RowCount - 1

                        If String.Compare(txtTimPT.Text.ToUpper.Trim, 0, grdChonPT.Rows(i).Cells("MS_PT").Value.ToString, 0, txtTimPT.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("MS_PT")
                            grdChonPT.Rows(i).Selected = True
                            txtTimPT.Focus()
                            Exit Sub
                        End If
                    Next
                Else
                    For i = 0 To grdChonPT.RowCount - 1

                        If String.Compare(txtTimPT.Text.ToUpper.Trim, 0, grdChonPT.Rows(i).Cells("MS_PT").Value.ToString, 0, txtTimPT.Text.ToUpper.Trim.Length) = 0 Then
                            thutu = i
                            grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("MS_PT")
                            grdChonPT.Rows(i).Selected = True
                            txtTimPT.Focus()
                            Exit Sub
                        End If
                    Next

                    If i = grdChonPT.Rows.Count Then
                        GoTo BatDau
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class