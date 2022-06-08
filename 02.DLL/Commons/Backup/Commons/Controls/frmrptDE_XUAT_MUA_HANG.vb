
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDE_XUAT_MUA_HANG
    Private SqlText As String = String.Empty

    Private Sub frmrptDE_XUAT_MUA_HANG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If radChuaTH.Checked = True Then
            CreateData20()
            Printpreview20()
        Else
            CreateData19()
            Printpreview19()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Sub CreateData20()

        'RefeshHeaderReport()
        'RefeshLanguageReport18()
        Commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

        SqlText = "SELECT     DE_XUAT_MUA_HANG.SO_DE_XUAT, DON_VI.TEN_DON_VI, DE_XUAT_MUA_HANG.NGAY, DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, " & _
        "IC_PHU_TUNG.TEN_PT, DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG, DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU " & _
        "INTO [dbo].rptDE_XUAT_MUA_HANG_DA_HT " & _
        "FROM         DE_XUAT_MUA_HANG INNER JOIN " & _
        "DE_XUAT_MUA_HANG_CHI_TIET ON DE_XUAT_MUA_HANG.SO_DE_XUAT = DE_XUAT_MUA_HANG_CHI_TIET.SO_DE_XUAT INNER JOIN " & _
        "IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
        "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
        "DON_VI ON DE_XUAT_MUA_HANG.MS_DON_VI = DON_VI.MS_DON_VI " & _
        "WHERE DUYET=0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub Printpreview20()

        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT * FROM dbo.rptDE_XUAT_MUA_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDE_XUAT_MUA_HANG", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDeXuatMuaHangChuaHT.rpt")
        Cursor = Cursors.Default
KetThuc:
        Commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

    End Sub


    Sub CreateData19()

        'RefeshHeaderReport()
        'RefeshLanguageReport18()
        Commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

        SqlText = "SELECT     DE_XUAT_MUA_HANG.SO_DE_XUAT, DON_VI.TEN_DON_VI, DE_XUAT_MUA_HANG.NGAY, DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, " & _
        "IC_PHU_TUNG.TEN_PT, DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG, DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU " & _
        "INTO [dbo].rptDE_XUAT_MUA_HANG_DA_HT " & _
        "FROM         DE_XUAT_MUA_HANG INNER JOIN " & _
        "DE_XUAT_MUA_HANG_CHI_TIET ON DE_XUAT_MUA_HANG.SO_DE_XUAT = DE_XUAT_MUA_HANG_CHI_TIET.SO_DE_XUAT INNER JOIN " & _
        "IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
        "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
        "DON_VI ON DE_XUAT_MUA_HANG.MS_DON_VI = DON_VI.MS_DON_VI " & _
        "WHERE DUYET=1"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub Printpreview19()

        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT * FROM dbo.rptDE_XUAT_MUA_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            'Cursor = Cursors.Default
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDE_XUAT_MUA_HANG", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDeXuatMuaHangDaHT.rpt")
        'Cursor = Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDE_XUAT_MUA_HANG_DA_HT")

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
