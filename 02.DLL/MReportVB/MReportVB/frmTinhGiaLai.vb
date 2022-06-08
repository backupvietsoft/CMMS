Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient

Public Class frmTinhGiaLai

    Private Sub frmTinhGiaLai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtThang.DateTime = Date.Now
    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click

        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCoMuonTinhLaiGiaThang", Commons.Modules.TypeLanguage) & " " & _
                    DateSerial(Year(dtThang.DateTime.Date), Month(dtThang.DateTime.Date), 1).ToString("MM/yyyy"), _
                    Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Cancel Then Exit Sub


        Dim sSql As String
        Dim sINTConnectString As String
        Dim dTNgay, dDNgay As Date
        Dim sBTam As String = "TGLAI_TMP" + Commons.Modules.UserName

        dTNgay = DateSerial(Year(dtThang.DateTime.Date), Month(dtThang.DateTime.Date), 1)
        dDNgay = dTNgay.AddMonths(1).AddDays(-1)


        sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG"
        sINTConnectString = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)))

        If String.IsNullOrEmpty(sINTConnectString) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                        Me.Name, "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(sINTConnectString, "sp_PHU_TUNG_GT", dDNgay, Nothing))
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "CREATE TABLE [dbo].[" & sBTam & "](	[MS_PT] [nvarchar](20) NULL,[DG] [decimal](38, 20) NULL)")


        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spTinhGiaLai", dTNgay, dDNgay, sBTam)

        Commons.Modules.ObjSystems.XoaTable(sBTam)

    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Close()
    End Sub
End Class