Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data

Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports System.Data
Imports Commons.VS.Classes.Admin
Public Class frmPhanBoChiPhiAttachment

    Dim intRow As Integer = -1
    Dim intRowCP As Integer = -1
    Dim intRowPB As Integer = -1
    Private Sub frmPhanBoChiPhiAttachment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        dtTungay1.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 150)
        dtpTungay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 20)
        LoadcboLoaiTB()
        VisibleButton(True)
        VisibleButtonGhi(False)
        BindData()
        AddHandler rdTatca.CheckedChanged, AddressOf Me.rdTatca_CheckedChanged
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        Else
            EnableButton(True)
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
    End Sub
    Sub LoadcboLoaiTB()
        cboLoaiTB.Display = "TEN_LOAI_MAY"
        cboLoaiTB.Value = "MS_LOAI_MAY"
        cboLoaiTB.StoreName = "GetLOAI_MAY_ATT"
        cboLoaiTB.Param = Commons.Modules.UserName
        cboLoaiTB.BindDataSource()
    End Sub
    Sub BindData()
        Try
            grdDanhsachAttachment.Columns.Clear()
            grdChiphibaotri.Columns.Clear()
        Catch ex As Exception
        End Try
        grdDanhsachAttachment.DataSource = New clsPHAN_BO_CHI_PHI_ATTController().GetMAY_ATT(Commons.Modules.UserName, cboLoaiTB.SelectedValue)
        With grdDanhsachAttachment
            .Columns("MS_ATTACHMENT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_ATTACHMENT", commons.Modules.TypeLanguage)
            .Columns("MS_ATTACHMENT").Width = 201
        End With
        Try
            Me.grdDanhsachAttachment.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachAttachment.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub BindChiPhiBaoTri()
        Try
            grdPhanbochiphi.Columns.Clear()
        Catch ex As Exception

        End Try
        If rdTatca.Checked Then
            grdChiphibaotri.DataSource = New clsPHAN_BO_CHI_PHI_ATTController().GetCHI_PHI_BAO_TRI_ATTs(grdDanhsachAttachment.Rows(intRow).Cells("MS_ATTACHMENT").Value, Format(dtpTungay.Value, "Short date"), Format(dtDenngay.Value, "Short date"), 1)
        Else
            grdChiphibaotri.DataSource = New clsPHAN_BO_CHI_PHI_ATTController().GetCHI_PHI_BAO_TRI_ATTs(grdDanhsachAttachment.Rows(intRow).Cells("MS_ATTACHMENT").Value, Format(dtpTungay.Value, "Short date"), Format(dtDenngay.Value, "Short date"), 0)
        End If
        grdChiphibaotri.Columns("MS_ATTACHMENT").Visible = False
        grdChiphibaotri.Columns("DA_PB").Visible = False
        With grdChiphibaotri
            .Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", commons.Modules.TypeLanguage)
            .Columns("MS_PHIEU_BAO_TRI").Width = 120
            .Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY", commons.Modules.TypeLanguage)
            .Columns("NGAY").Width = 100
            .Columns("NGAY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CHI_PHI_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_BAO_TRI", commons.Modules.TypeLanguage)
            .Columns("CHI_PHI_BAO_TRI").Width = 120
            '.Columns("CHI_PHI_BAO_TRI").DefaultCellStyle.Format = "#,###.00"
            .Columns("CHI_PHI_BAO_TRI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CHI_PHI_DA_PHAN_BO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_DA_PHAN_BO", commons.Modules.TypeLanguage)
            .Columns("CHI_PHI_DA_PHAN_BO").Width = 120
            '.Columns("CHI_PHI_DA_PHAN_BO").DefaultCellStyle.Format = "#,###.00"
            .Columns("CHI_PHI_DA_PHAN_BO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CHI_PHI_CON_LAI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_CON_LAI", commons.Modules.TypeLanguage)
            .Columns("CHI_PHI_CON_LAI").Width = 120
            '.Columns("CHI_PHI_CON_LAI").DefaultCellStyle.Format = "#,###.00"
            .Columns("CHI_PHI_CON_LAI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        Try
            Me.grdChiphibaotri.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdChiphibaotri.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub BindPhanBoMay()
        If BtnGhi.Visible Then
            grdPhanbochiphi.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(intRowCP).Cells("MS_PHIEU_BAO_TRI").Value & "'").Tables(0)
        Else
            grdPhanbochiphi.DataSource = New clsPHAN_BO_CHI_PHI_ATTController().GetMAY_PHAN_BO_ATTs(grdChiphibaotri.Rows(intRowCP).Cells("MS_ATTACHMENT").Value, grdChiphibaotri.Rows(intRowCP).Cells("MS_PHIEU_BAO_TRI").Value, Format(dtTungay1.Value, "Short date"), Format(dtDenngay1.Value, "Short date"), Commons.Modules.UserName, 0)
        End If
        grdPhanbochiphi.Columns("MS_ATTACHMENT").Visible = False
        grdPhanbochiphi.Columns("MS_PHIEU_BAO_TRI").Visible = False
        grdPhanbochiphi.Columns("DA_PB").Visible = False
        grdPhanbochiphi.Columns("MS_MAY").ReadOnly = True
        grdPhanbochiphi.Columns("TEN_NHOM_MAY").ReadOnly = True
        grdPhanbochiphi.Columns("TEN_LOAI_MAY").ReadOnly = True
        If BtnGhi.Visible Then
            grdPhanbochiphi.Columns("CHI_PHI").ReadOnly = False
        Else
            grdPhanbochiphi.Columns("CHI_PHI").ReadOnly = True
        End If
        With grdPhanbochiphi
            .Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
            .Columns("MS_MAY").Width = 120
            .Columns("TEN_NHOM_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NHOM_MAY", commons.Modules.TypeLanguage)
            .Columns("TEN_NHOM_MAY").Width = 170
            .Columns("CHI_PHI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI", commons.Modules.TypeLanguage)
            .Columns("CHI_PHI").Width = 120
            .Columns("CHI_PHI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TEN_LOAI_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_MAY", commons.Modules.TypeLanguage)
            .Columns("TEN_LOAI_MAY").Width = 168

        End With
        Try
            Me.grdPhanbochiphi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdPhanbochiphi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub VisibleButton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnXoa.Visible = chon
        BtnThoat.Visible = chon
        grdDanhsachAttachment.Enabled = chon
    End Sub

    Sub VisibleButtonGhi(ByVal chon As Boolean)
        BtnGhi.Visible = chon
        BtnKhongghi.Visible = chon
        BtnPhanbodeu.Visible = chon
        dtTungay1.Enabled = Not chon
        dtDenngay1.Enabled = Not chon
        dtDenngay.Enabled = Not chon
        dtpTungay.Enabled = Not chon
        rdChuaphanbohet.Enabled = Not chon
        rdTatca.Enabled = Not chon
        cboLoaiTB.Enabled = Not chon
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub cboLoaiTB_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiTB.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub grdDanhsachAttachment_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachAttachment.RowEnter
        intRow = e.RowIndex
        BindChiPhiBaoTri()
    End Sub

    Private Sub dtpTungay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpTungay.Validating
        BindChiPhiBaoTri()
    End Sub

    Private Sub dtDenngay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtDenngay.Validating
        BindChiPhiBaoTri()
    End Sub

    Private Sub rdTatca_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles rdTatca.CheckedChanged
        BindChiPhiBaoTri()
    End Sub

    Private Sub grdChiphibaotri_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChiphibaotri.RowEnter
        intRowCP = e.RowIndex
        BindPhanBoMay()
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        VisibleButtonGhi(True)
        Dim str As String = ""
        Try
            str = "Drop table TMP_MAY_PHAN_BO" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        For i As Integer = 0 To grdChiphibaotri.Rows.Count - 1
            If i = 0 Then
                str = "SELECT * into DBO.TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " FROM (SELECT  DISTINCT   MS_ATTACHMENT,MAY.MS_MAY,TEN_NHOM_MAY,TEN_LOAI_MAY,'" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AS MS_PHIEU_BAO_TRI,0 AS CHI_PHI,0 AS DA_PB " & _
             " FROM MAY_ATTACHMENT INNER JOIN MAY ON MAY.MS_MAY=MAY_ATTACHMENT.MS_MAY INNER  JOIN " & _
             " NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
             " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY INNER JOIN  " & _
             " NHOM ON NHOM.GROUP_ID =NHOM_LOAI_MAY.GROUP_ID INNER JOIN USERS on USERS.GROUP_ID=NHOM.GROUP_ID " & _
             " WHERE     MS_ATTACHMENT ='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "' AND USERNAME='" & Commons.Modules.UserName & "' " & _
             " AND (TU_NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103) OR  " & _
             " DEN_NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103) " & _
             " OR (TU_NGAY>CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103)  AND DEN_NGAY >CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103))) " & _
             " AND MAY.MS_MAY NOT IN(SELECT MS_MAY FROM MAY_PHAN_BO_ATT WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_ATTACHMENT='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "') " & _
             " UNION SELECT MS_ATTACHMENT,MAY_PHAN_BO_ATT.MS_MAY,TEN_NHOM_MAY,TEN_LOAI_MAY,MS_PHIEU_BAO_TRI,CHI_PHI,1 AS DA_PB FROM MAY_PHAN_BO_ATT INNER JOIN " & _
             " MAY ON MAY_PHAN_BO_ATT.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY " & _
             " ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY  " & _
             " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_ATTACHMENT='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "')AS P1 "
            Else
                str = " INSERT INTO DBO.TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " SELECT *  FROM (SELECT  DISTINCT   MS_ATTACHMENT,MAY.MS_MAY,TEN_NHOM_MAY,TEN_LOAI_MAY,'" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AS MS_PHIEU_BAO_TRI,0 AS CHI_PHI,0 AS DA_PB " & _
                " FROM MAY_ATTACHMENT INNER JOIN MAY ON MAY.MS_MAY=MAY_ATTACHMENT.MS_MAY INNER  JOIN " & _
                " NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY INNER JOIN  " & _
                " NHOM ON NHOM.GROUP_ID =NHOM_LOAI_MAY.GROUP_ID INNER JOIN USERS on USERS.GROUP_ID=NHOM.GROUP_ID " & _
                " WHERE     MS_ATTACHMENT ='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "' AND USERNAME='" & Commons.Modules.UserName & "' " & _
                " AND (TU_NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103) OR  " & _
                " DEN_NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103) AND CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103) " & _
                " OR (TU_NGAY>CONVERT(DATETIME,'" & Format(dtTungay1.Value, "Short date") & "',103)  AND DEN_NGAY >CONVERT(DATETIME,'" & Format(dtDenngay1.Value, "Short date") & "',103))) " & _
                " AND MAY.MS_MAY NOT IN(SELECT MS_MAY FROM MAY_PHAN_BO_ATT WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_ATTACHMENT='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "') " & _
                " UNION SELECT MS_ATTACHMENT,MAY_PHAN_BO_ATT.MS_MAY,TEN_NHOM_MAY,TEN_LOAI_MAY,MS_PHIEU_BAO_TRI,CHI_PHI,1 AS DA_PB FROM MAY_PHAN_BO_ATT INNER JOIN " & _
                " MAY ON MAY_PHAN_BO_ATT.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY " & _
                " ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY  " & _
                " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_ATTACHMENT='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "')AS P1 "

            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        BindPhanBoMay()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdPhanbochiphi.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim traloi As String = String.Empty
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbNo Then Exit Sub
        Dim str As String = ""
        str = "Update CHI_PHI_BAO_TRI_ATT set CHI_PHI_DA_PHAN_BO=" & grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_DA_PHAN_BO").Value - grdPhanbochiphi.Rows(intRowPB).Cells("CHI_PHI").Value & " , CHI_PHI_CON_LAI=" & grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_CON_LAI").Value + grdPhanbochiphi.Rows(intRowPB).Cells("CHI_PHI").Value & " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(intRowCP).Cells("MS_PHIEU_BAO_TRI").Value & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "DELETE FROM MAY_PHAN_BO_ATT WHERE MS_MAY=N'" & grdPhanbochiphi.Rows(intRowPB).Cells("MS_MAY").Value & "' AND MS_ATTACHMENT='" & grdPhanbochiphi.Rows(intRowPB).Cells("MS_ATTACHMENT").Value & "' AND MS_PHIEU_BAO_TRI='" & grdPhanbochiphi.Rows(intRowPB).Cells("MS_PHIEU_BAO_TRI").Value & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tmp As Integer = intRowPB
        BindChiPhiBaoTri()
        If grdPhanbochiphi.Rows.Count > 0 Then
            If grdPhanbochiphi.Rows.Count = tmp Then
                grdPhanbochiphi.CurrentCell() = grdPhanbochiphi.Rows(tmp - 1).Cells("MS_MAY")
                grdPhanbochiphi.Focus()
            Else
                grdPhanbochiphi.CurrentCell() = grdPhanbochiphi.Rows(tmp).Cells("MS_MAY")
                grdPhanbochiphi.Focus()
            End If
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim str As String = ""
        Dim objReader As SqlDataReader
        For i As Integer = 0 To grdChiphibaotri.Rows.Count - 1
            str = "SELECT SUM(CHI_PHI) AS CHI_PHI FROM TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "'"
            objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                'If objReader.Item("CHI_PHI") > 0   Then
                If grdChiphibaotri.Rows(i).Cells("DA_PB").Value Then
                    str = "UPDATE CHI_PHI_BAO_TRI_ATT SET CHI_PHI_DA_PHAN_BO=" & IIf(objReader.Item("CHI_PHI").ToString = "", 0, objReader.Item("CHI_PHI")) & ",CHI_PHI_CON_LAI=" & grdChiphibaotri.Rows(i).Cells("CHI_PHI_BAO_TRI").Value - IIf(objReader.Item("CHI_PHI").ToString = "", 0, objReader.Item("CHI_PHI")) & " WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    str = "DELETE FROM MAY_PHAN_BO_ATT WHERE MS_PHIEU_BAO_TRI='" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_ATTACHMENT='" & grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Else
                    If objReader.Item("CHI_PHI").ToString <> "" Then
                        str = "INSERT INTO CHI_PHI_BAO_TRI_ATT (MS_ATTACHMENT,MS_PHIEU_BAO_TRI,NGAY,CHI_PHI_BAO_TRI,CHI_PHI_DA_PHAN_BO,CHI_PHI_CON_LAI) VALUES(N'" & _
                        grdChiphibaotri.Rows(i).Cells("MS_ATTACHMENT").Value & "','" & grdChiphibaotri.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & "',CONVERT(DATETIME,'" & grdChiphibaotri.Rows(i).Cells("NGAY").Value & _
                        "',103)," & grdChiphibaotri.Rows(i).Cells("CHI_PHI_BAO_TRI").Value & "," & IIf(objReader.Item("CHI_PHI").ToString = "", 0, objReader.Item("CHI_PHI")) & "," & grdChiphibaotri.Rows(i).Cells("CHI_PHI_BAO_TRI").Value - IIf(objReader.Item("CHI_PHI").ToString = "", 0, objReader.Item("CHI_PHI")) & ")"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    End If
                End If
            End While
        Next
        str = "INSERT INTO MAY_PHAN_BO_ATT(MS_ATTACHMENT,MS_PHIEU_BAO_TRI,MS_MAY,CHI_PHI) SELECT MS_ATTACHMENT,MS_PHIEU_BAO_TRI,MS_MAY,CHI_PHI FROM TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " WHERE CHI_PHI>0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        VisibleButton(True)
        VisibleButtonGhi(False)
        BindChiPhiBaoTri()
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        VisibleButton(True)
        VisibleButtonGhi(False)
        BindChiPhiBaoTri()
    End Sub

    Private Sub grdPhanbochiphi_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdPhanbochiphi.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        Dim cell As DataGridViewCell = Me.grdPhanbochiphi.Item(e.ColumnIndex, e.RowIndex)
        If cell.IsInEditMode Then
            If grdPhanbochiphi.Columns(e.ColumnIndex).Name = "CHI_PHI" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChiPhiAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If e.FormattedValue <= 0 Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChiPhiAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
                Dim str As String = ""
                str = "select sum(CHI_PHI) as CHI_PHI FROM TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & grdPhanbochiphi.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "' and MS_MAY <>N'" & grdPhanbochiphi.Rows(e.RowIndex).Cells("MS_MAY").Value & "'"
                Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objReader.Read
                    If (IIf(objReader.Item("CHI_PHI").ToString = "", 0, objReader.Item("CHI_PHI")) + IIf(e.FormattedValue = "", 0, e.FormattedValue)) > grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_BAO_TRI").Value Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGiaTriLonHonTongCP", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        objReader.Close()
                        e.Cancel = True
                        Exit Sub
                    Else
                        grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_CON_LAI").Value = grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_BAO_TRI").Value - (objReader.Item("CHI_PHI") + IIf(e.FormattedValue.ToString = "", 0, e.FormattedValue))
                        grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_DA_PHAN_BO").Value = objReader.Item("CHI_PHI") + IIf(e.FormattedValue.ToString = "", 0, e.FormattedValue)
                    End If
                End While
                objReader.Close()
                str = "UPDATE TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " SET CHI_PHI=" & IIf(e.FormattedValue = "", 0, e.FormattedValue) & " WHERE MS_PHIEU_BAO_TRI='" & grdPhanbochiphi.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "' and MS_MAY =N'" & grdPhanbochiphi.Rows(e.RowIndex).Cells("MS_MAY").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            End If
        End If
    End Sub

    Private Sub BtnPhanbodeu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPhanbodeu.Click
        Dim tmp As Double = 0
        tmp = grdChiphibaotri.Rows(intRowCP).Cells("CHI_PHI_BAO_TRI").Value / grdPhanbochiphi.Rows.Count
        Dim str As String = ""
        str = "UPDATE TMP_MAY_PHAN_BO" & Commons.Modules.UserName & " SET CHI_PHI=" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & grdPhanbochiphi.Rows(intRowCP).Cells("MS_PHIEU_BAO_TRI").Value & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        BindPhanBoMay()
    End Sub

    Private Sub grdPhanbochiphi_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPhanbochiphi.RowEnter
        intRowPB = e.RowIndex
    End Sub
End Class