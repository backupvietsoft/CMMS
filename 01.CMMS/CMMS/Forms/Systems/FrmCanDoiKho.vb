Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data

Imports Commons.VS.Classes.Admin

Public Class FrmCanDoiKho

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub FrmCanDoiKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPBT()
        gvCanDoiXuat.ColumnHeadersDefaultCellStyle.Font = New Font(gvCanDoiXuat.ColumnHeadersDefaultCellStyle.Font.Name, gvCanDoiXuat.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub LoadPBT()
        Dim Tb_PBT As DataTable = New DataTable()
        Tb_PBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PBT_TH"))
        cboPBT.ValueMember = "MS_PBT"
        cboPBT.DisplayMember = "MS_PBT"
        cboPBT.DataSource = Tb_PBT
    End Sub
    Private Sub cboPBT_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPBT.SelectionChangeCommitted
        TaoDuLieu()
    End Sub

    Private Sub TaoDuLieu()
        Dim Tb_DHX As DataTable = New DataTable()
        Try
            Tb_DHX.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_DHX_PBT", cboPBT.SelectedValue))
        Catch ex As Exception
            Tb_DHX.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_DHX_PBT", String.Empty))
        End Try
        gvCanDoiXuat.AutoGenerateColumns = False
        gvCanDoiXuat.DataSource = Tb_DHX
        gvCanDoiXuat.Columns("MS_DHX").DataPropertyName = "MS_DH_XUAT_PT"
        gvCanDoiXuat.Columns("MS_PBT").DataPropertyName = "MS_PHIEU_BAO_TRI"
        gvCanDoiXuat.Columns("MS_KHO").DataPropertyName = "MS_KHO"
        gvCanDoiXuat.Columns("MS_DHN").DataPropertyName = "MS_DH_NHAP_PT"
        gvCanDoiXuat.Columns("MS_PT").DataPropertyName = "MS_PT"
        gvCanDoiXuat.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        gvCanDoiXuat.Columns("VT").DataPropertyName = "MS_VI_TRI"
        gvCanDoiXuat.Columns("TEN_VI_TRI").DataPropertyName = "TEN_VI_TRI"
        gvCanDoiXuat.Columns("SL_VT").DataPropertyName = "SL_VT"
        gvCanDoiXuat.Columns("STT").DataPropertyName = "STT"
        gvCanDoiXuat.Columns("SL_XUAT").DataPropertyName = "SL_XUAT"
        gvCanDoiXuat.Columns("ID_XUAT").DataPropertyName = "ID_XUAT"
        gvCanDoiXuat.Columns("ID_XUAT").Visible = False
    End Sub
    Private Sub gvCanDoiXuat_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gvCanDoiXuat.CellValidating
        If (gvCanDoiXuat.Columns(e.ColumnIndex).Name.Equals("SL_XUAT")) Then
            If Not btExit.Focused Then
                Try
                    If (Double.Parse(e.FormattedValue) > Double.Parse(gvCanDoiXuat.Rows(e.RowIndex).Cells("SL_VT").Value.ToString())) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDL_Error", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                        e.Cancel = True
                    Else
                        If Double.Parse(e.FormattedValue) = 0 Then
                            Dim COUNT As Integer = -1
                            Try
                                COUNT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "SP_KIEM_TRA_TON_TAI_PX_PBT", gvCanDoiXuat.Rows(e.RowIndex).Cells("MS_PBT").Value, gvCanDoiXuat.Rows(e.RowIndex).Cells("MS_DHX").Value, gvCanDoiXuat.Rows(e.RowIndex).Cells("MS_DHN").Value, gvCanDoiXuat.Rows(e.RowIndex).Cells("MS_PT").Value))
                            Catch ex As Exception
                            End Try
                            If (COUNT > 0) Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPT_DA_CO_TREN_PBT", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                                e.Cancel = True
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDL_Error", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                End Try
            End If
        End If
    End Sub

    Private Sub btEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEdit.Click
        Dim sqlCnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString())
        If (sqlCnn.State = ConnectionState.Closed) Then
            sqlCnn.Open()
        End If
        gvCanDoiXuat.EndEdit()
        Dim sqlTran As SqlTransaction = sqlCnn.BeginTransaction()
        Try
            For Each gvRow As DataGridViewRow In gvCanDoiXuat.Rows
                SqlHelper.ExecuteNonQuery(sqlTran, "SP_UPDATE_DON_HANG_XUAT_CT", gvRow.Cells("MS_DHX").Value, _
                    gvRow.Cells("MS_PT").Value, gvRow.Cells("STT").Value, gvRow.Cells("MS_DHN").Value, _
                    gvRow.Cells("VT").Value, gvRow.Cells("SL_XUAT").Value, gvRow.Cells("ID_XUAT").Value)

                SqlHelper.ExecuteNonQuery(sqlTran, "SP_UPDATE_VI_TRI_KHO_VAT_TU", gvRow.Cells("MS_PT").Value, _
                    gvRow.Cells("MS_KHO").Value, gvRow.Cells("MS_DHN").Value, gvRow.Cells("VT").Value, _
                    Double.Parse(gvRow.Cells("SL_VT").Value.ToString()) - _
                    Double.Parse(gvRow.Cells("SL_XUAT").Value.ToString()), gvRow.Cells("ID_XUAT").Value)
            Next
            SqlHelper.ExecuteNonQuery(sqlTran, "SP_UPDATE_DH_XUAT_VAT_TU")
            SqlHelper.ExecuteNonQuery(sqlTran, "SP_DELETE_IC_DON_HANG_XUAT_VAT_TU_CHI_TIET")
            SqlHelper.ExecuteNonQuery(sqlTran, "SP_DELETE_IC_DON_HANG_XUAT_VAT_TU")
            SqlHelper.ExecuteNonQuery(sqlTran, "SP_DELETE_IC_DON_HANG_XUAT")
            sqlTran.Commit()
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, _
                "MsgUpdate_Error", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            sqlTran.Rollback()
            Exit Sub
        End Try
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, _
                "MsgUpdate_Sec", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
        sqlCnn.Close()
        TaoDuLieu()
    End Sub
End Class