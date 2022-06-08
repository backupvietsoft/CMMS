Imports Commons.VS.Classes.Catalogue

Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime

Public Class frmBackLog
    Public MS_PHIEU_BAO_TRI As String = String.Empty
    Private Sub frmBackLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TB_PBT_HM As DataTable = New DataTable()
        TB_PBT_HM.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PBT_HANG_MUC", MS_PHIEU_BAO_TRI))
        grdHangMuc.DataSource = TB_PBT_HM
        grvHangMuc.OptionsBehavior.Editable = False
        grvHangMuc.Columns("MS_MAY").OptionsColumn.ReadOnly = True
        grvHangMuc.Columns("MS_MAY").Width = 150
        grvHangMuc.Columns("HANG_MUC_ID").Visible = False
        grvHangMuc.Columns("TEN_HANG_MUC").OptionsColumn.ReadOnly = True
        grvHangMuc.Columns("TEN_HANG_MUC").Width = 200
        grvHangMuc.Columns("NGAY").OptionsColumn.ReadOnly = True
        grvHangMuc.Columns("NGAY").DisplayFormat.FormatString = "dd/MM/yyyy"
        grvHangMuc.Columns("NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        grvHangMuc.Columns("NGAY").Width = 120
        grvHangMuc.Columns("NGAY_DK_HT").OptionsColumn.ReadOnly = True
        grvHangMuc.Columns("NGAY_DK_HT").DisplayFormat.FormatString = "dd/MM/yyyy"
        grvHangMuc.Columns("NGAY_DK_HT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        grvHangMuc.Columns("NGAY_DK_HT").Width = 120
        Dim TB_PBT_CV As DataTable = New DataTable()

        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            TB_PBT_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PBT_CV_BACKLOG", MS_PHIEU_BAO_TRI, Commons.Modules.TypeLanguage, True))
        Else
            TB_PBT_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PBT_CV_BACKLOG", MS_PHIEU_BAO_TRI, Commons.Modules.TypeLanguage, False))
        End If

        TB_PBT_CV.Columns("CHON").ReadOnly = False
        grdCongViec.DataSource = TB_PBT_CV
        grvCongViec.Columns("MS_PHIEU_BAO_TRI").OptionsColumn.ReadOnly = True
        grvCongViec.Columns("MS_PHIEU_BAO_TRI").Width = 150
        grvCongViec.Columns("MS_CV").Visible = False
        grvCongViec.Columns("MS_BO_PHAN").Visible = False
        grvCongViec.Columns("MO_TA_CV").OptionsColumn.ReadOnly = True
        grvCongViec.Columns("MO_TA_CV").Width = 200
        grvCongViec.Columns("TEN_BO_PHAN").OptionsColumn.ReadOnly = True
        grvCongViec.Columns("TEN_BO_PHAN").Width = 200
        grvCongViec.Columns("CHON").VisibleIndex = 0
        grvCongViec.Columns("CHON").Width = 75
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBacklog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBacklog.Click
        If (grvHangMuc.FocusedRowHandle >= 0) Then
            Dim Flag As Boolean = False
            Dim dtTmp As New DataTable
            Dim sSql As String
            Dim sqlUpdate As DataVietsoft.Sqlvs = New DataVietsoft.Sqlvs(Commons.IConnections.ConnectionString())
            If (sqlUpdate.OpenConnecTion()) Then
                sqlUpdate.BeginTransacTion()
                Try
                    For i As Integer = 0 To grvCongViec.RowCount - 1
                        If (Not grvCongViec.GetRowCellValue(i, "CHON") Is DBNull.Value And Not grvCongViec.GetRowCellValue(i, "CHON") Is Nothing) Then
                            If (Convert.ToBoolean(grvCongViec.GetRowCellValue(i, "CHON"))) Then

                                sSql = " UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI = NULL, SNGUOI = B.SO_NGUOI, YCAU_NS = B.YEU_CAU_NS, " & _
                                            " 		YCAU_DC = B.YEU_CAU_DUNG_CU, THOI_GIAN_DU_KIEN = B.SO_GIO_KH " & _
                                            " FROM KE_HOACH_TONG_CONG_VIEC A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " & _
                                            " 		AND A.MS_BO_PHAN = B.MS_BO_PHAN AND A.MS_CV = B.MS_CV AND A.HANG_MUC_ID = B.HANG_MUC_ID  " & _
                                            " WHERE MS_MAY = (SELECT TOP 1 MS_MAY FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "') " & _
                                            " AND A.HANG_MUC_ID = " & grvHangMuc.GetRowCellValue(grvHangMuc.FocusedRowHandle, "HANG_MUC_ID").ToString() & _
                                            " AND A.MS_CV = " & grvCongViec.GetRowCellValue(i, "MS_CV").ToString & _
                                            " AND A.MS_BO_PHAN = '" & grvCongViec.GetRowCellValue(i, "MS_BO_PHAN").ToString() & "' " & _
                                            " AND A.MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "'"
                                sqlUpdate.ExecuteNonQuery(CommandType.Text, sSql)
                                Flag = True
                                Try
                                    sqlUpdate.ExecuteNonQuery(CommandType.StoredProcedure, "SP_UPDATE_HANG_MUC_FROM_PBT", grvHangMuc.GetRowCellValue(grvHangMuc.FocusedRowHandle, "HANG_MUC_ID"), MS_PHIEU_BAO_TRI, grvCongViec.GetRowCellValue(i, "MS_CV"), grvCongViec.GetRowCellValue(i, "MS_BO_PHAN"))
                                Catch ex As Exception
                                    sSql = " UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI = NULL WHERE MS_MAY = '" & grvHangMuc.GetRowCellValue(grvHangMuc.FocusedRowHandle, "MS_MAY") & "' " & _
                                            " AND HANG_MUC_ID = " & grvHangMuc.GetRowCellValue(grvHangMuc.FocusedRowHandle, "HANG_MUC_ID") & _
                                            " AND MS_CV = " & grvCongViec.GetRowCellValue(i, "MS_CV") & _
                                            " AND MS_BO_PHAN = '" & grvCongViec.GetRowCellValue(i, "MS_BO_PHAN") & "' " & _
                                            " AND MS_PHIEU_BAO_TRI = '" & MS_PHIEU_BAO_TRI & "'"
                                    sqlUpdate.ExecuteNonQuery(CommandType.Text, sSql)
                                End Try
                            End If
                        End If
                    Next
                    sqlUpdate.CommitTransacTion()
                Catch ex As Exception
                    sqlUpdate.RollbackTransacTion()
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CANNOT_BACKLOG", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                    Exit Sub
                End Try
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOT_OPEN_CONNEC", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                Exit Sub
            End If
            If (Flag) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_CONG_VIEC", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                Exit Sub
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_HANG_MUC", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
            Exit Sub
        End If

    End Sub
End Class