Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue
Public Class frmChonPTDeXuat


    Private Sub frmChonPTDeXuat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Dim str As String = ""
        'str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]" & _
        '"Create table dbo.tmpChonPT" & Commons.Modules.UserName & "(MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),DVT NVARCHAR(20))"
        Try
            str = "Create table dbo.tmpChonPT" & Commons.Modules.UserName & "(MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),DVT NVARCHAR(20))"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)" & _
        " drop procedure [dbo].[InsertPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = " CREATE PROCEDURE [dbo].[InsertPT" & Commons.Modules.UserName & "] @MS_PT NVARCHAR(25),@TEN_PT NVARCHAR(255),@DVT NVARCHAR(50) AS " & _
        " INSERT INTO tmpChonPT" & Commons.Modules.UserName & " VALUES(@MS_PT,@TEN_PT,@DVT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        LoadLoaiVT()
        LoadLoaiTB()
        LoadLoaiPT()
        BindData()

        AddHandler Me.utcComboLoaiVT.SelectedIndexChanged, AddressOf Me.utcComboLoaiVT_SelectedIndexChanged
        AddHandler cboLOAI_PHU_TUNG.SelectedIndexChanged, AddressOf Me.cboLOAI_PHU_TUNG_SelectedIndexChanged
        AddHandler cboLOAI_THIET_BI.SelectedIndexChanged, AddressOf Me.cboLOAI_THIET_BI_SelectedIndexChanged

    End Sub
    Sub LoadLoaiVT()
        utcComboLoaiVT.Value = "MS_LOAI_VT"
        Select Case commons.Modules.TypeLanguage
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
    Private Sub RefeshLanguage()
        Me.grdChonPT.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        Me.grdChonPT.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        Me.grdChonPT.Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
        Me.grdChonPT.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        Try
            Me.grdChonPT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdChonPT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            grdChonPT.Columns("DVT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Catch ex As Exception
        End Try
    End Sub

    Sub BindData()
        Dim column As New DataGridViewCheckBoxColumn
        grdChonPT.Columns.Clear()
        With column
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        Dim dtTableTam As DataTable = New DataTable()
        dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_SEARCH", CreateQuery))

        grdChonPT.DataSource = dtTableTam
        If grdChonPT.RowCount > 0 Then
            grdChonPT.Rows(0).Selected = True
        End If
        Me.grdChonPT.Columns.Insert(3, column)
        RefeshLanguage()
        HienThi()
    End Sub
    Sub HienThi()
        Dim str As String = "select MS_PT FROM tmpChonPT" & Commons.Modules.UserName
        Dim tb As New DataTable
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To grdChonPT.Rows.Count - 1
            For j As Integer = 0 To tb.Rows.Count - 1
                If grdChonPT.Rows(i).Cells("MS_PT").Value = tb.Rows(j).Item("MS_PT") Then
                    grdChonPT.Rows(i).Cells("chkChon").Value = True
                    Exit For
                End If
            Next
        Next
    End Sub
    Function CreateQuery() As String
        'If utcComboLoaiVT.Value Is Nothing Then Exit Function
        Dim sql As String = "SELECT DISTINCT PT.MS_PT, PT.TEN_PT ,CASE " & commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT"
        Dim from As String = " FROM IC_PHU_TUNG PT, LOAI_VT LVT , IC_PHU_TUNG_LOAI_PHU_TUNG PTLPT,LOAI_PHU_TUNG LPT   , NHOM_LOAI_PHU_TUNG NLPT, NHOM NHM , USERS US, DON_VI_TINH  A"
        'Dim condition As String = " WHERE LVT.MS_LOAI_VT=PT.MS_LOAI_VT AND LPT.MS_LOAI_PT =PTLPT.MS_LOAI_PT AND PT.MS_PT = PTLPT.MS_PT AND LPT.MS_LOAI_PT=NLPT.MS_LOAI_PT AND NHM.GROUP_ID=NLPT.GROUP_ID AND PT.DVT=A.DVT AND NHM.GROUP_ID = US.GROUP_ID AND USERNAME='" + Commons.Modules.UserName + "' and (PT.MS_VI_TRI IS NOT NULL OR PT.MS_VI_TRI<>'') "
        Dim condition As String = " WHERE LVT.MS_LOAI_VT=PT.MS_LOAI_VT AND LPT.MS_LOAI_PT =PTLPT.MS_LOAI_PT AND PT.MS_PT = PTLPT.MS_PT AND LPT.MS_LOAI_PT=NLPT.MS_LOAI_PT AND NHM.GROUP_ID=NLPT.GROUP_ID AND PT.DVT=A.DVT AND NHM.GROUP_ID = US.GROUP_ID AND USERNAME='" + Commons.Modules.UserName + "' "

        If Not utcComboLoaiVT.SelectedValue Is Nothing Then
            If Not (Me.utcComboLoaiVT.SelectedValue.ToString.Equals("-1")) Then
                from += ""
                condition += "  AND LVT.MS_LOAI_VT='" + Me.utcComboLoaiVT.SelectedValue.ToString + "' "
            End If
        End If
        If Not cboLOAI_PHU_TUNG.SelectedValue Is Nothing Then
            If Not (Me.cboLOAI_PHU_TUNG.SelectedValue.ToString.Equals("-1")) Then
                from += " "
                condition += " AND LPT.MS_LOAI_PT=" + Me.cboLOAI_PHU_TUNG.SelectedValue.ToString
            End If
        End If

        If Not cboLOAI_THIET_BI.SelectedValue Is Nothing Then
            If Not (Me.cboLOAI_THIET_BI.SelectedValue.ToString.Equals("-1")) Then
                from += ", IC_PHU_TUNG_LOAI_MAY PTLM, LOAI_MAY LM"
                condition += " AND LM.MS_LOAI_MAY=PTLM.MS_LOAI_MAY AND PT.MS_PT=PTLM.MS_PT AND LM.MS_LOAI_MAY='" + Me.cboLOAI_THIET_BI.SelectedValue.ToString + "' "
            End If
        End If
        sql = sql + from + condition

        sql = "SELECT * FROM (" & sql & ") TMP WHERE MS_PT NOT IN (SELECT MS_PT FROM tmpChonPT" & Commons.Modules.UserName & ")"
        Return sql
    End Function
    Private Sub cboLOAI_THIET_BI_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub utcComboLoaiVT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub cboLOAI_PHU_TUNG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindData()
    End Sub
    Function Load_Phu_Tung(ByVal MS_PT As String) As IC_PHU_TUNG_Info
        Dim objPhuTung As IC_PHU_TUNG_Info = QLBusinessDataController.FillObject(Of IC_PHU_TUNG_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_PHU_TUNG", MS_PT))
        Return objPhuTung
    End Function
    Private Sub grdChonPT_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChonPT.CellClick
        If e.RowIndex >= 0 Then
            Me.grdChonPT.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub grdChonPT_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdChonPT.CellValidating
        If grdChonPT.Columns(e.ColumnIndex).Name = "chkChon" Then
            Dim cell As DataGridViewCell = grdChonPT.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                If e.FormattedValue Then
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertPT" & Commons.Modules.UserName, grdChonPT.Rows(e.RowIndex).Cells("MS_PT").Value, grdChonPT.Rows(e.RowIndex).Cells("TEN_PT").Value, grdChonPT.Rows(e.RowIndex).Cells("DVT").Value.ToString)
                Else
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM    tmpChonPT" & Commons.Modules.UserName & " WHERE MS_PT='" & grdChonPT.Rows(e.RowIndex).Cells("MS_PT").Value & "'")
                End If
            End If
        End If
    End Sub

    Private Sub btnThuchien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThuchien.Click
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)" & _
        " drop procedure [dbo].[InsertPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Me.Close()
    End Sub

    Private Sub btnTrove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrove.Click
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)" & _
        " drop procedure [dbo].[InsertPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "delete from tmpChonPT" & Commons.Modules.UserName)
        Me.Close()
    End Sub

    Dim thutu As Integer = -1
    Dim GiaTri As String = ""
    Private Sub txtTimPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimPT.KeyDown
        If e.KeyCode = 13 Then
            Dim i As Integer
            If GiaTri <> txtTimPT.Text.ToUpper.Trim Then
                GiaTri = txtTimPT.Text.ToUpper.Trim
                GoTo BatDau
            End If
            If thutu = -1 Then
BatDau:
                For i = 0 To grdChonPT.RowCount - 1
                    If grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimPT.Text.ToUpper.Trim) Or txtTimPT.Text.ToUpper.Trim.Contains(grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
                        thutu = i
                        grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("chkChon")
                        txtTimPT.Focus()
                        Exit Sub
                    Else
                        grdChonPT.Rows(i).Cells("chkChon").Selected = False
                    End If
                Next
            Else
                For i = thutu + 1 To grdChonPT.RowCount - 1
                    If grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper.Contains(txtTimPT.Text.ToUpper.Trim) Or txtTimPT.Text.ToUpper.Trim.Contains(grdChonPT.Rows(i).Cells("MS_PT").Value.ToString.ToUpper) Then
                        thutu = i
                        grdChonPT.CurrentCell() = grdChonPT.Rows(i).Cells("chkChon")
                        txtTimPT.Focus()
                        Exit Sub
                    Else
                        grdChonPT.Rows(i).Cells("chkChon").Selected = False
                    End If
                Next
                If i = grdChonPT.Rows.Count Then
                    GoTo BatDau
                End If
            End If
        End If
    End Sub
End Class