
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic.DateAndTime



Public Class FrmKiemSoatDiChuyenBoPhan

#Region "Events"
    Private Sub FrmKiemSoatDiChuyenBoPhan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        visibleButton(True)
        lockControl(False)
        LoadcboLoaiTB()
        Commons.Modules.ObjSystems.DinhDang()
        bind_data()
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnSua.Enabled = False
        Else
            btnSua.Enabled = True
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        grdDanhsach.ReadOnly = False
        grdDanhsach.Columns("MS_MAY").ReadOnly = True
        grdDanhsach.Columns("MS_MAY_THAY_tHE").ReadOnly = True
        grdDanhsach.Columns("MS_BO_PHAN").ReadOnly = True
        grdDanhsach.Columns("MS_BO_PHAN_THAY_THE").ReadOnly = True
        grdDanhsach.Columns("NGUOI_CHO_PHEP").ReadOnly = True
        grdDanhsach.Columns("DAI_HAN").ReadOnly = True
        grdDanhsach.Columns("NGAY_THAY").ReadOnly = True
        grdDanhsach.Columns("DEN_NGAY").ReadOnly = True
        grdDanhsach.Columns("MS_PHIEU_BAO_TRI").ReadOnly = True
        visibleButton(False)
        lockControl(True)

    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        visibleButton(True)
        lockControl(False)
        bind_data()
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        visibleButton(True)
        lockControl(False)
        Dim objController As New PHIEU_BAO_TRI_DI_CHUYEN_BPController()
        For i As Integer = 0 To grdDanhsach.Rows.Count - 1
            Dim obj As New PHIEU_BAO_TRI_DI_CHUYEN_BPInfo()
            obj.MS_PHIEU_BAO_TRI = grdDanhsach.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value
            obj.MS_BO_PHAN = grdDanhsach.Rows(i).Cells("MS_BO_PHAN").Value
            obj.MS_MAY_THAY_THE = grdDanhsach.Rows(i).Cells("MS_MAY_THAY_THE").Value
            obj.MS_BO_PHAN_THAY_THE = grdDanhsach.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value
            If grdDanhsach.Rows(i).Cells("cboNGAY_TRA_TT").Value.ToString() = "" Or grdDanhsach.Rows(i).Cells("cboNGAY_TRA_TT").Value.ToString() = "  /  /" Then
                obj.NGAY_TRA_TT = ""
            Else
                obj.NGAY_TRA_TT = Format(grdDanhsach.Rows(i).Cells("cboNGAY_TRA_TT").Value, "Short date")
            End If
            objController.Update_PHIEU_BAO_TRI_DI_CHUYEN_BP(obj)
        Next
        bind_data()
    End Sub

    Private Sub radChuatra_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radChuatra.CheckedChanged
        bind_data()
    End Sub

    Private Sub radDatra_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDatra.CheckedChanged
        bind_data()
    End Sub
#End Region

#Region "Methods"
    Sub visibleButton(ByVal visible As Boolean)
        btnSua.Visible = visible
        'btnIn.Visible = visible
        btnThoat.Visible = visible
        btnGhi.Visible = Not visible
        btnKhongghi.Visible = Not visible
    End Sub

    Sub LoadcboLoaiTB()
        cboMS_ThietBi.Value = "MS_LOAI_MAY"
        cboMS_ThietBi.Display = "TEN_LOAI_MAY"
        cboMS_ThietBi.StoreName = "GetLOAI_MAYs_PQ"
        cboMS_ThietBi.Param = Commons.Modules.UserName
        cboMS_ThietBi.BindDataSource()
    End Sub

    Sub lockControl(ByVal lock As Boolean)
        grpXemtheo.Enabled = Not lock
        cboMS_ThietBi.Enabled = Not lock
    End Sub

    Sub format_grdDanhsach()
        Try
            grdDanhsach.ReadOnly = True
            With Me.grdDanhsach
                .Columns("MS_MAY").Width = 100
                .Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
                .Columns("MS_BO_PHAN").Width = 150
                .Columns("MS_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN", Commons.Modules.TypeLanguage)
                .Columns("MS_MAY_THAY_THE").Width = 100
                .Columns("MS_MAY_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("MS_BO_PHAN_THAY_THE").Width = 150
                .Columns("MS_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("NGUOI_CHO_PHEP").Width = 150
                .Columns("NGUOI_CHO_PHEP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_CHO_PHEP", Commons.Modules.TypeLanguage)
                .Columns("DAI_HAN").Width = 50
                .Columns("DAI_HAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAI_HAN", Commons.Modules.TypeLanguage)
                .Columns("DEN_NGAY").Width = 80
                .Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
                .Columns("DEN_NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("cboNGAY_TRA_TT").Width = 80
                .Columns("cboNGAY_TRA_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_TRA_TT", Commons.Modules.TypeLanguage)
                .Columns("cboNGAY_TRA_TT").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("NGAY_THAY").Width = 80
                .Columns("NGAY_THAY").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("NGAY_THAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_THAY", Commons.Modules.TypeLanguage)
                .Columns("MS_PHIEU_BAO_TRI").Width = 100
                .Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
                .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            End With
        Catch ex As Exception

        End Try

    End Sub

    Sub bind_data()
        Me.grdDanhsach.Columns.Clear()
        Dim objController As New PHIEU_BAO_TRI_DI_CHUYEN_BPController
        If Me.radChuatra.Checked Then
            Me.grdDanhsach.DataSource = objController.Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_CT(Me.cboMS_ThietBi.SelectedValue)
        Else
            Me.grdDanhsach.DataSource = objController.Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_DT(Me.cboMS_ThietBi.SelectedValue)
        End If
        Try
            grdDanhsach.Columns("NGAY_TRA_TT").Visible = False
            Dim col1 As New Commons.QLGridMaskedTextBoxColumn()
            col1.Name = "cboNGAY_TRA_TT"
            col1.DataPropertyName = "NGAY_TRA_TT"
            col1.Mask = "00/00/0000"
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            col1.DefaultCellStyle.Format = Nothing
            grdDanhsach.Columns.Insert(8, col1)
        Catch ex As Exception
        End Try
        grdDanhsach.ReadOnly = True
        format_grdDanhsach()
    End Sub

    Sub update_PHIEU_BAO_TRI_DI_CHUYEN_BP()
        Dim i As Integer
        Dim objController As New PHIEU_BAO_TRI_DI_CHUYEN_BPController
        Dim objInfo As New PHIEU_BAO_TRI_DI_CHUYEN_BPInfo
        For i = 0 To Me.grdDanhsach.RowCount - 1
            objInfo.MS_PHIEU_BAO_TRI = Me.grdDanhsach.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value
            objInfo.MS_MAY_THAY_THE = Me.grdDanhsach.Rows(i).Cells("MS_MAY_THAY_THE").Value
            objInfo.MS_BO_PHAN_THAY_THE = Me.grdDanhsach.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value
            objInfo.NGAY_TRA_TT = Me.grdDanhsach.Rows(i).Cells("NGAY_TRA_TT").Value
            ' Update 
            objController.Update_PHIEU_BAO_TRI_DI_CHUYEN_BP(objInfo)
        Next
    End Sub

    Sub delete_PHIEU_BAO_TRI_DI_CHUYEN_BP()
        Dim objController As New PHIEU_BAO_TRI_DI_CHUYEN_BPController
        Dim objInfo As New PHIEU_BAO_TRI_DI_CHUYEN_BPInfo

        objInfo.MS_PHIEU_BAO_TRI = Me.grdDanhsach.CurrentRow.Cells("MS_PHIEU_BAO_TRI").Value
        objInfo.MS_MAY_THAY_THE = Me.grdDanhsach.CurrentRow.Cells("MS_MAY_THAY_THE").Value
        objInfo.MS_BO_PHAN_THAY_THE = Me.grdDanhsach.CurrentRow.Cells("MS_BO_PHAN_THAY_THE").Value

        objController.delete_PHIEU_BAO_TRI_DI_CHUYEN_BP(objInfo)
    End Sub
#End Region

    Private Sub cboMS_ThietBi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMS_ThietBi.SelectionChangeCommitted
        bind_data()
    End Sub

    Private Sub cboMS_ThietBi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grdDanhsach_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsach.CellValidating
        If btnKhongghi.Focused() Then
            Exit Sub
        End If
        If btnGhi.Visible Then
            If grdDanhsach.Columns(e.ColumnIndex).Name = "cboNGAY_TRA_TT" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdDanhsach.Rows(e.RowIndex).ErrorText = "Error"
                        grdDanhsach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        grdDanhsach.Focus()
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Date.Parse(e.FormattedValue) > Now() Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdDanhsach.Rows(e.RowIndex).ErrorText = "Error"
                            grdDanhsach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            grdDanhsach.Focus()
                            e.Cancel = True
                            Exit Sub
                        Else
                            If Date.Parse(e.FormattedValue) < Date.Parse(Format(grdDanhsach.Rows(e.RowIndex).Cells("NGAY_THAY").Value, "Short date")) Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                grdDanhsach.Rows(e.RowIndex).ErrorText = "Error"
                                grdDanhsach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                                grdDanhsach.Focus()
                                e.Cancel = True
                                Exit Sub
                            Else
                                Dim str1 As String = ""
                                str1 = "SELECT min(NGAY_THAY) as NGAY_THAY FROM PHIEU_BAO_TRI_DI_CHUYEN_BP " & _
                                " WHERE MS_MAY_THAY_THE = N'" & grdDanhsach.Rows(e.RowIndex).Cells("MS_MAY_THAY_THE").Value & "' AND MS_BO_PHAN_THAY_THE ='" & grdDanhsach.Rows(e.RowIndex).Cells("MS_BO_PHAN_THAY_THE").Value & "' AND NGAY_TRA_TT IS NOT NULL AND  " & _
                                " NGAY_THAY > CONVERT(DATETIME, '" & grdDanhsach.Rows(e.RowIndex).Cells("NGAY_THAY").Value & "', 103)"
                                Dim objRead1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1)
                                While objRead1.Read
                                    If objRead1.Item("NGAY_THAY").ToString <> "" Then
                                        If Date.Parse(e.FormattedValue) > Date.Parse(objRead1.Item("NGAY_THAY")) Then
                                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra3", Commons.Modules.TypeLanguage) + "(" + objRead1.Item("NGAY_THAY").ToString + ")", MsgBoxStyle.Exclamation)
                                            grdDanhsach.Rows(e.RowIndex).ErrorText = "Error"
                                            grdDanhsach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                                            grdDanhsach.Focus()
                                            objRead1.Close()
                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    End If
                                End While
                                objRead1.Close()
                            End If
                        End If
                    End If
                Else
                    If radDatra.Checked Then
                        Dim str As String = ""
                        str = "SELECT PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,MS_BO_PHAN FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN PHIEU_BAO_TRI " & _
                        "ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI WHERE NGAY_TRA_TT IS NULL AND MS_MAY=N'" & grdDanhsach.Rows(e.RowIndex).Cells("MS_MAY").Value & "' AND MS_BO_PHAN='" & grdDanhsach.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                        Dim tb As New DataTable()
                        Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        While objRead.Read
                            If objRead.Item("MS_BO_PHAN").ToString <> "" Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra12", Commons.Modules.TypeLanguage) + grdDanhsach.Rows(e.RowIndex).Cells("MS_MAY").Value + ", " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra22", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                grdDanhsach.Rows(e.RowIndex).ErrorText = "Error"
                                grdDanhsach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                                grdDanhsach.Focus()
                                e.Cancel = True
                                objRead.Close()
                                Exit Sub
                            End If
                        End While
                        objRead.Close()
                    End If
                End If
            End If
            grdDanhsach.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub


End Class