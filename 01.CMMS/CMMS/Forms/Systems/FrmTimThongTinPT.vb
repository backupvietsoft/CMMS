
Imports Microsoft.ApplicationBlocks.Data
Imports System.Threading
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports DevExpress.XtraEditors

Public Class FrmTimThongTinPT
    Dim objDataTable As New DataTable
    Private Sub FrmTimThongTinPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TableLayoutPanel1.RowStyles.RemoveAt(0)
        'TableLayoutPanel1.Rowstyle(1).height = 2
        Try
            If Commons.Modules.sPrivate <> "TRUNGNGUYEN" Then
                TableLayoutPanel1.RowStyles(1).Height = 2
                optOption.SelectedIndex = 0
                optOption.Visible = False
            End If
        Catch ex As Exception

        End Try



        Try
            Commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            BindData()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindData()
        objDataTable = New DataTable

        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongTinVatTu", 0, "", 0, Commons.Modules.UserName, "", ""))
        objDataTable.Columns("TEN_PT").ReadOnly = False
        objDataTable.Columns("QUY_CACH").ReadOnly = False

        Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, objDataTable, False, False, False, False, True, Me.Name)
        TKiem()
        If grv.Columns("MS_KHO").Visible = False Then Return
        grv.Columns("MS_KHO").Visible = False
        grv.Columns("ID").Visible = False
        grv.Columns("MS_VI_TRI").Visible = False
        Try
            grv.Columns("TEN_KHO").Width = 100
            grv.Columns("QUY_CACH").Width = 150
            grv.Columns("MS_PT").Width = 85
            grv.Columns("TEN_PT").Width = 250
            grv.Columns("TEN_VI_TRI").Width = 90
            grv.Columns("MS_DH_NHAP_PT").Width = 95
            grv.Columns("SL_VT").Width = 80
            grv.Columns("MS_PT_NCC").Width = 85
            grv.Columns("MS_PT_CTY").Width = 85
            grv.Columns("BAO_HANH_DEN_NGAY").Width = 90
            grv.Columns("NGAY").Width = 90
            Me.grv.Columns("BAO_HANH_DEN_NGAY").DisplayFormat.FormatString = "dd/MM/yyyy"
            Me.grv.Columns("BAO_HANH_DEN_NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            Me.grv.Columns("BAO_HANH_DEN_NGAY").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.grv.Columns("NGAY").DisplayFormat.FormatString = "dd/MM/yyyy"
            Me.grv.Columns("NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            Me.grv.Columns("DON_GIA").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.sSoLeDG)
            Me.grv.Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            Me.grv.Columns("DON_GIA").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub TKiem()
        Dim dtTmp As New DataTable
        Try
            Dim sTKiem As String = " (1 = 1) AND "
            dtTmp = CType(grd.DataSource, DataTable)
            If optOption.SelectedIndex = 0 Then
                sTKiem = " (1 = 1)  "
            Else
                If Commons.Modules.sPrivate = "TRUNGNGUYEN" Then
                    sTKiem = " (MS_DH_NHAP_PT = 'PN-2101-0001') "
                End If
            End If
            If txtPT.Text.Length > 0 Then
                sTKiem = sTKiem + " AND  (MS_PT like '%" + txtPT.Text.Trim + "%' OR TEN_PT like '%" + txtPT.Text.Trim + "%' OR MS_PT_CTY like '%" + txtPT.Text.Trim + "%' OR MS_PT_NCC like '%" + txtPT.Text.Trim + "%' OR QUY_CACH like '%" + txtPT.Text.Trim + "%' OR TEN_VI_TRI like '%" + txtPT.Text.Trim + "%' )"

            End If
            dtTmp.DefaultView.RowFilter = sTKiem

        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub txtPT_TextChanged(sender As Object, e As EventArgs) Handles txtPT.TextChanged

        TKiem()
    End Sub


    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click
        Dim dtTmp As New DataTable()
        Try
            dtTmp = DirectCast(grd.DataSource, DataTable).Copy()
            Try
                dtTmp.Rows.Clear()
            Catch
            End Try

            GetFilteredData(grv, dtTmp)

            sPath = ""
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx")
            If sPath = "" Then
                Return
            End If

            Dim t As New Thread(New ParameterizedThreadStart(AddressOf ShowProcessBar))

            t.Start(dtTmp)
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Delegate Sub CallProcessBar(dt As Object)
    Private sPath As String = ""

    Private Sub ShowProcessBar(dt As Object)
        If prbIN.InvokeRequired Then
            prbIN.Invoke(New CallProcessBar(AddressOf ShowProcessBar), dt)
        Else
            BeginInvoke(DirectCast(Sub()
                                       prbIN.Properties.Stopped = False
                                       'EnableControl(false);
                                       btnIn.Enabled = False
                                       BtnThoat.Enabled = False
                                       Me.Cursor = Cursors.WaitCursor
                                   End Sub, Action))

            Dim t As New Thread(New ParameterizedThreadStart(AddressOf InExcel))

            t.Start(dt)
        End If
    End Sub
    Private Sub InExcel(dt As Object)
        Try
            Dim dtData As DataTable = TryCast(dt, DataTable)
            Try
                dtData.Columns.Remove("MS_VI_TRI")
                dtData.Columns.Remove("ID")
                dtData.Columns.Remove("MS_KHO")
            Catch
            End Try
            Dim fi = New System.IO.FileInfo(sPath)
            If fi.Exists Then
                fi.Delete()
            End If

            Dim pck As New ExcelPackage()
            Dim ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTimThongTinPT", "ucTimThongTinPTTieuDe", Commons.Modules.TypeLanguage))
            pck.SaveAs(fi)

            '#Region "in Thong Tin Chung"
            Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C")
            '#End Region

            '#Region "In Thong Tin Sheet 1"
            Dim iDong As Integer = 5
            ws1.Row(4).Height = 9

            Dim allCells = ws1.Cells(iDong, 1, iDong, dtData.Columns.Count)
            Commons.Modules.MExcel.MText(ws1, "frmTimThongTinPT", "ucTimThongTinPTTieuDe", iDong, 1, iDong,
                dtData.Columns.Count, True, True, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center)

            iDong += 1

            '#End Region

            Dim sCotNgay As New List(Of String)() From {
            }
            Dim WidthColumns As New List(Of List(Of [Object]))()
            Dim WidthColumnsName As New List(Of [Object])()


            iDong += 1
            ws1.Row(iDong).Height = 9
            iDong += 1
            sCotNgay = New List(Of String)() From {
                "NGAY"
            }
            WidthColumnsName = New List(Of [Object])() From {
                "QUY_CACH",
                25
            }
            WidthColumns.Add(WidthColumnsName)
            WidthColumnsName = New List(Of [Object])() From {
                "TEN_PT",
                26
            }
            WidthColumns.Add(WidthColumnsName)

            WidthColumnsName = New List(Of [Object])() From {
                "MS_PT_NCC",
                20
            }
            WidthColumns.Add(WidthColumnsName)
            WidthColumnsName = New List(Of [Object])() From {
                "TEN_LOAI_VT",
                20
            }
            WidthColumns.Add(WidthColumnsName)

            If dtData.Rows.Count > 0 Then
                ws1.Cells(iDong, 1).LoadFromDataTable(dtData, True)
            End If

            Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, "frmTimThongTinPT", sCotNgay, "dd/MM/yyyy",
                WidthColumns)
            '    #endregion


            If fi.Exists Then
                fi.Delete()
            End If

            pck.SaveAs(fi)

            System.Diagnostics.Process.Start(fi.FullName.ToString())
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTimThongTinPT", "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Try
            BeginInvoke(DirectCast(Sub()
                                       Me.Cursor = Cursors.[Default]
                                       'EnableControl(true);
                                       btnIn.Enabled = True
                                       BtnThoat.Enabled = True
                                       prbIN.Properties.Stopped = True

                                   End Sub, Action))
            sPath = ""
        Catch
        End Try
    End Sub

    Public Sub GetFilteredData(view As DevExpress.XtraGrid.Views.Base.ColumnView, ByRef dt As DataTable)
        For i As Integer = 0 To view.DataRowCount - 1
            Try
                Dim dr As DataRow = dt.NewRow()
                For j As Integer = 0 To view.Columns.Count - 1
                    dr(view.Columns(j).FieldName) = view.GetDataRow(i)(view.Columns(j).FieldName)
                Next
                dt.Rows.Add(dr)
            Catch
            End Try
        Next

    End Sub

    Private Sub optOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optOption.SelectedIndexChanged
        TKiem()
    End Sub
End Class
