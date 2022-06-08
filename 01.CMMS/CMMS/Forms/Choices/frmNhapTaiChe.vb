
Imports Commons
Imports Microsoft.ApplicationBlocks.Data


Public Class frmNhapTaiChe
    Private _dtTaiChe As DataTable
    Public Property dtTaiChe() As DataTable
        Get
            Return _dtTaiChe
        End Get
        Set(ByVal value As DataTable)
            _dtTaiChe = value
        End Set
    End Property


    Private Sub frmNhapTaiChe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
             For Each row As DataRow In _dtTaiChe.Rows
                If row("SL_TAICHE") = 0 
                    row("SL_TAICHE") = row("SL_TT")
                End If
             Next

            For i As Integer = 0 To _dtTaiChe.Columns.Count - 3
                _dtTaiChe.Columns(i).ReadOnly = True
            Next
            _dtTaiChe.Columns("SL_TAICHE").ReadOnly = False

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhapTaiChe, grvNhapTaiChe, _dtTaiChe, True, False, True, True, True, Me.Name)
            grvNhapTaiChe.Columns("MS_DH_NHAP_PT").Visible = False
            grvNhapTaiChe.Columns("DG_TAICHE").OptionsColumn.ReadOnly = False
            grvNhapTaiChe.Columns("SL_TAICHE").OptionsColumn.ReadOnly = False

            grvNhapTaiChe.Columns("DG_TAICHE").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG) '"#,###,###,###,##0.#00"
            grvNhapTaiChe.Columns("DG_TAICHE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            grvNhapTaiChe.Columns("DON_GIA").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG) '"#,###,###,###,##0.#00"
            grvNhapTaiChe.Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        'mỗi phiếu xuất là một phiếu nhập
        '
        Try
            'sqlTran = con.BeginTransaction()
        Catch ex As Exception
        End Try
        Try
            Dim subset As DataTable = New DataView(_dtTaiChe).ToTable(True, "MS_DH_XUAT_PT")
            For i As Integer = 0 To subset.Rows.Count - 1
                _dtTaiChe = New DataTable()
                _dtTaiChe = CType(grdNhapTaiChe.DataSource, DataTable).AsEnumerable().Where(Function(x) x.Field(Of String)("MS_DH_XUAT_PT").Equals(subset.Rows(i)(0))).CopyToDataTable()
                '' tạo bảo tạm
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "btTAISD" + Commons.Modules.UserName, _dtTaiChe, "")
                Dim idPN As String = OSystems.VSGetID("PN", DateTime.Now)
                ''hàm ex
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "AddDonhangNhapTaiChe", subset.Rows(i)(0), idPN, "btTAISD" + Commons.Modules.UserName)
            Next
            'sqlTran.Commit()
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            'sqlTran.Rollback()
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class