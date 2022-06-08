Public Class cls_MayThamDinhHieuNang
    Public Function CreateDataTable() As DataTable
        Dim table As DataTable
        table = New DataTable
        table.Columns.Add(New DataColumn("Mã máy", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("Ngày thẩm định", Type.GetType("System.DateTime")))
        table.Columns.Add(New DataColumn("Người thẩm định", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("Sản phẩm thẩm định", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("Số lô", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("Ghi chú", Type.GetType("System.String")))
        Return table
    End Function
End Class
