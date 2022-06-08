Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons

Public Class frmCompareSLXuat

    Public _MS_PHIEU_BAO_TRI As String = String.Empty

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub frmCompareSLXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadData()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadData()
        Try
            Dim TB_SL_XUAT As DataTable = New DataTable()
            TB_SL_XUAT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PT_XUAT_PTSD", _MS_PHIEU_BAO_TRI))
            Try
                grdCompare.DataSource = Nothing
                grvCompare.Columns.Clear()
            Catch ex As Exception
            End Try
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCompare, grvCompare, TB_SL_XUAT, False, True, True, False, True, "")
            grvCompare.Columns("ID_XUAT").Visible = False
            grvCompare.Columns("MS_PT").Visible = False
            grvCompare.Columns("TEN_PT_SD").Visible = False
            grvCompare.Columns("ID").Visible = False
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprint.Click
        Dim TB_SL_XUAT As DataTable = New DataTable()
        TB_SL_XUAT.TableName = "DS_PT"
        '  TB_SL_XUAT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PT_XUAT_PTSD", _MS_PHIEU_BAO_TRI))
        TB_SL_XUAT = CType(grdCompare.DataSource, DataTable)
        If TB_SL_XUAT.Rows.Count > 0 Then
            Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
            frmRepot.rptName = "rptCOMPARE_SO_LUONG_XUAT"
            frmRepot.AddDataTableSource(refeshLanguage())
            frmRepot.AddDataTableSource(TB_SL_XUAT)
            frmRepot.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End If
    End Sub

    Function refeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 13
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "MS_CV"
        vtbTitle.Columns(1).ColumnName = "MS_BO_PHAN"
        vtbTitle.Columns(2).ColumnName = "MO_TA_CV"
        vtbTitle.Columns(3).ColumnName = "TEN_BO_PHAN"
        vtbTitle.Columns(4).ColumnName = "PT_GOC"
        vtbTitle.Columns(5).ColumnName = "TEN_PT"
        vtbTitle.Columns(6).ColumnName = "MS_PT"
        vtbTitle.Columns(7).ColumnName = "TEN_PT_SD"
        vtbTitle.Columns(8).ColumnName = "MS_DH_XUAT_PT"
        vtbTitle.Columns(9).ColumnName = "MS_DH_NHAP_PT"
        vtbTitle.Columns(10).ColumnName = "SL_TT"
        vtbTitle.Columns(11).ColumnName = "SL_VT"
        vtbTitle.Columns(12).ColumnName = "XUAT_KHO"
        vtbTitle.Columns(13).ColumnName = "TIEU_DE"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("MS_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MS_CV", Commons.Modules.TypeLanguage)
        vRowTitle("MS_BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MS_BO_PHAN", Commons.Modules.TypeLanguage)
        vRowTitle("MO_TA_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MO_TA_CV", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        vRowTitle("PT_GOC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "PT_GOC", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "TEN_PT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT_SD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "TEN_PT_SD", Commons.Modules.TypeLanguage)
        vRowTitle("MS_DH_XUAT_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MS_DH_XUAT_PT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_DH_NHAP_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        vRowTitle("SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "SL_TT", Commons.Modules.TypeLanguage)
        vRowTitle("SL_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "SL_VT", Commons.Modules.TypeLanguage)
        vRowTitle("XUAT_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "XUAT_KHO", Commons.Modules.TypeLanguage)
        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCOMPARE_SO_LUONG_XUAT", "TIEU_DE", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle

    End Function


End Class