Imports Microsoft.ApplicationBlocks.Data
Imports Spire.Xls
Public Class XtraForm1
    Private sql As String
    Private data As New DataTable
    Private Sub XtraForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim myUc As New frmp
        'myUc.Location = New Point(0, 0)
        'myUc.Dock = DockStyle.Fill
        ''myUc.LoadDataTSGSTT()
        ''myUc.dtTBi = dt
        ''myUc.ShowMAY()
        'Me.Controls.Add(myUc)
        'Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub

    Private Sub cmbThang_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '        Workbook workbook = New Workbook();
        'workbook.LoadFromFile(@"1.xlsx");
        'Worksheet sheet = workbook.Worksheets[0];
        'DataTable dt = sheet.ExportDataTable(sheet.AllocatedRange, False, True);
        'this.dataGridView1.DataSource = dt;

        Dim wb As New Workbook
        wb.LoadFromFile("D:\Import Phieu Nhap.xlsx")
        Dim ws As Worksheet = wb.Worksheets(0)
        Dim dt As New DataTable
        dt = ws.ExportDataTable(ws.AllocatedRange, False, True)
        dgv.DataSource = Nothing
        dgv.DataSource = dt

    End Sub
End Class