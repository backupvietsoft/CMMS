Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports System.Globalization
Public Class frmrptTheKho
    Private Sub frmrptTheKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            dtTNgay.DateTime = Date.Now.AddMonths(-1).ToString("dd/MM/yyyy")
            dtDNgay.DateTime = Date.Now.ToString("dd/MM/yyyy")

            BindDataKhO()
            If (cbxKho.SelectedValue.Equals(Nothing) Or cbxKho.SelectedValue.Equals(DBNull.Value)) Then
                BindDataVTPT("-1")
            Else
                BindDataVTPT(cbxKho.SelectedValue.ToString().Trim())
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Load Data combo Kho
    Private Sub BindDataKhO()
        Try
            Dim vTbKho As System.Data.DataTable = New System.Data.DataTable()
            vTbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 0, Commons.Modules.UserName))
            cbxKho.DataSource = vTbKho
            cbxKho.ValueMember = "MS_KHO"
            cbxKho.DisplayMember = "TEN_KHO"
        Catch ex As Exception
        End Try
    End Sub
    'Load Data combo Vat Tu Phu Tung
    Private Sub BindDataVTPT(ByVal MS_KHO As String)
        Try
            cbxVTPT.ValueMember = "MS_PT"
            cbxVTPT.DisplayMember = "TEN_PT"
            Dim vTbKho As System.Data.DataTable = New System.Data.DataTable()
            Dim str As String = " SELECT DISTINCT  dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.MS_PT + '(' + dbo.IC_PHU_TUNG.TEN_PT + ')' as TEN_PT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO" &
                                " FROM         dbo.VI_TRI_KHO_VAT_TU INNER JOIN" &
                                " dbo.IC_PHU_TUNG ON dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT" &
                                " WHERE dbo.VI_TRI_KHO_VAT_TU.MS_KHO = '" & MS_KHO & "'"
            vTbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            cbxVTPT.DataSource = vTbKho
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If dtTNgay.DateTime.Date > dtDNgay.DateTime.Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgFromDateToDate", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try


    End Sub

    Private Sub mDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)


        Try
            If dtTNgay.DateTime.Date > dtDNgay.DateTime.Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgToDateFromDate", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try



    End Sub

    Sub ReportBDL()
        Try


            Dim tbTheKho As DataTable = New DataTable()
            tbTheKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "H_GET_THE_KHO_BDL", cbxKho.SelectedValue, dtTNgay.DateTime.Date.ToString("dd/MM/yyyy"), dtDNgay.DateTime.Date.ToString("dd/MM/yyyy"), cbxVTPT.SelectedValue, Commons.Modules.TypeLanguage))
            tbTheKho.TableName = "THE_KHO"

            If tbTheKho.Rows.Count > 0 Then
                tbTheKho.Columns("TON_CUOI_KY").ReadOnly = False
                Dim vToncuoi As Double = Convert.ToDouble(tbTheKho.Rows(0)("TON_DAU"))
                For Each vRow As DataRow In tbTheKho.Rows
                    vToncuoi = vToncuoi + Convert.ToDouble(vRow("SL_NHAP")) + Convert.ToDouble(vRow("SL_CHUYEN_DEN")) + Convert.ToDouble(vRow("SL_CHENH_LECH")) - Convert.ToDouble(vRow("SL_XUAT")) - -Convert.ToDouble(vRow("SL_CHUYEN_DI"))
                    vRow("TON_CUOI_KY") = vToncuoi
                Next
                Dim vtbPT As New DataTable()
                vtbPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetPhuTungTheKhoInfo_BDL", cbxVTPT.SelectedValue, Commons.Modules.TypeLanguage))
                vtbPT.TableName = "PT_INFO"
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptTheKho_BDL"
                frmRepot.AddDataTableSource(LanguageBDL())
                frmRepot.AddDataTableSource(vtbPT)
                frmRepot.AddDataTableSource(tbTheKho)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgCanNotData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Function LanguageBDL() As DataTable
        Dim tbTitleTheKho As DataTable = New DataTable()
        For i As Integer = 0 To 31
            tbTitleTheKho.Columns.Add()
        Next
        tbTitleTheKho.Columns(0).ColumnName = "TIEU_DE"
        tbTitleTheKho.Columns(1).ColumnName = "STT"
        tbTitleTheKho.Columns(2).ColumnName = "NGAY"
        tbTitleTheKho.Columns(3).ColumnName = "CHUNG_TU"
        tbTitleTheKho.Columns(4).ColumnName = "NHAP"
        tbTitleTheKho.Columns(5).ColumnName = "XUAT"
        tbTitleTheKho.Columns(6).ColumnName = "CHUYEN_DEN"
        tbTitleTheKho.Columns(7).ColumnName = "CHUYEN_DI"
        tbTitleTheKho.Columns(8).ColumnName = "CHENH_LECH"
        tbTitleTheKho.Columns(9).ColumnName = "SO_LUONG"
        tbTitleTheKho.Columns(10).ColumnName = "DAU_KY"
        tbTitleTheKho.Columns(11).ColumnName = "CUOI_KY"
        tbTitleTheKho.Columns(12).ColumnName = "TONG"
        tbTitleTheKho.Columns(13).ColumnName = "KHO_PT"
        tbTitleTheKho.Columns(14).ColumnName = "DK_LOC"
        tbTitleTheKho.Columns(15).ColumnName = "NGUOI_LAP"
        tbTitleTheKho.Columns(16).ColumnName = "SO_CHUNG_TU"
        tbTitleTheKho.Columns(17).ColumnName = "MA_SO"
        tbTitleTheKho.Columns(18).ColumnName = "TEN_VT"
        tbTitleTheKho.Columns(19).ColumnName = "SO_HIEU"
        tbTitleTheKho.Columns(20).ColumnName = "MA_THAMKHAO"
        tbTitleTheKho.Columns(21).ColumnName = "NOI_SD"
        tbTitleTheKho.Columns(22).ColumnName = "PAGES"
        tbTitleTheKho.Columns(23).ColumnName = "DVT"
        tbTitleTheKho.Columns(24).ColumnName = "SO_KE"
        tbTitleTheKho.Columns(25).ColumnName = "MA_KHO"
        tbTitleTheKho.Columns(26).ColumnName = "TON_MIN"
        tbTitleTheKho.Columns(27).ColumnName = "TEN_KHO"
        tbTitleTheKho.Columns(28).ColumnName = "SAD"
        tbTitleTheKho.Columns(29).ColumnName = "WIK"
        tbTitleTheKho.Columns(30).ColumnName = "SO"
        tbTitleTheKho.Columns(31).ColumnName = "DIEN_GIAI"

        Dim vRowTitle As DataRow = tbTitleTheKho.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NGAY", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NGAY", Commons.Modules.TypeLanguage)
        vRowTitle("CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUNG_TU", Commons.Modules.TypeLanguage)
        vRowTitle("NHAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NHAP", Commons.Modules.TypeLanguage)
        vRowTitle("XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "XUAT", Commons.Modules.TypeLanguage)
        vRowTitle("CHUYEN_DEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DEN", Commons.Modules.TypeLanguage)
        vRowTitle("CHUYEN_DI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DI", Commons.Modules.TypeLanguage)
        vRowTitle("CHENH_LECH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHENH_LECH", Commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO_LUONG", Commons.Modules.TypeLanguage)
        vRowTitle("DAU_KY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "DAU_KY", Commons.Modules.TypeLanguage)
        vRowTitle("CUOI_KY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CUOI_KY", Commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TONG", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NGUOI_LAP", Commons.Modules.TypeLanguage)
        vRowTitle("SO_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO_CHUNG_TU", Commons.Modules.TypeLanguage)
        vRowTitle("MA_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MA_SO", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TEN_VT", Commons.Modules.TypeLanguage)
        vRowTitle("SO_HIEU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO_HIEU", Commons.Modules.TypeLanguage)
        vRowTitle("MA_THAMKHAO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MA_THAMKHAO", Commons.Modules.TypeLanguage)
        vRowTitle("NOI_SD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NOI_SD", Commons.Modules.TypeLanguage)
        vRowTitle("PAGES") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "PAGES", Commons.Modules.TypeLanguage)
        vRowTitle("DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "DVT", Commons.Modules.TypeLanguage)
        vRowTitle("SO_KE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO_KE", Commons.Modules.TypeLanguage)
        vRowTitle("MA_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MA_KHO", Commons.Modules.TypeLanguage)
        vRowTitle("TON_MIN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TON_MIN", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_KHO") = cbxKho.Text.Trim
        vRowTitle("SAD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SAD", Commons.Modules.TypeLanguage)
        vRowTitle("WIK") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "WIK", Commons.Modules.TypeLanguage)
        vRowTitle("SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO", Commons.Modules.TypeLanguage)
        vRowTitle("DIEN_GIAI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "DIEN_GIAI", Commons.Modules.TypeLanguage)


        If (Commons.Modules.TypeLanguage = 0) Then
            vRowTitle("DK_LOC") = "Từ ngày : " & dtTNgay.Text & " Đến ngày : " & dtDNgay.Text
        Else
            vRowTitle("DK_LOC") = "From date : " & dtTNgay.Text & " To date : " & dtDNgay.Text
        End If
        tbTitleTheKho.Rows.Add(vRowTitle)
        Return tbTitleTheKho
    End Function

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If (dtTNgay.Text.Equals("/  /")) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtTNgay.Focus()
            Exit Sub
        End If
        If (dtDNgay.Text.Equals("/  /")) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtDNgay.Focus()
            Exit Sub
        End If



        If Commons.Modules.sPrivate = "BDL" Then
            ReportBDL()
            Exit Sub
        Else
            Try
                Dim tbTheKho As DataTable = New DataTable()
                tbTheKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_THE_KHO", cbxKho.SelectedValue, dtTNgay.DateTime.Date.ToString("dd/MM/yyyy"), dtDNgay.DateTime.Date.ToString("dd/MM/yyyy"), cbxVTPT.SelectedValue, Commons.Modules.TypeLanguage))
                tbTheKho.TableName = "THE_KHO"
                If (tbTheKho.Rows.Count > 0) Then
                    tbTheKho.Columns("TON_CUOI_KY").ReadOnly = False
                    Dim vToncuoi As Double = Convert.ToDouble(tbTheKho.Rows(0)("TON_DAU"))
                    For Each vRow As DataRow In tbTheKho.Rows
                        vToncuoi = vToncuoi + Convert.ToDouble(vRow("SL_NHAP")) + Convert.ToDouble(vRow("SL_CHUYEN_DEN")) + Convert.ToDouble(vRow("SL_CHENH_LECH")) - Convert.ToDouble(vRow("SL_XUAT")) - Convert.ToDouble(vRow("SL_CHUYEN_DI"))
                        vRow("TON_CUOI_KY") = vToncuoi
                    Next
                    Dim frmRepot As frmXMLReport = New frmXMLReport()
                    frmRepot.rptName = "rptTheKho"
                    frmRepot.AddDataTableSource(tbTheKho)
                    Dim tbTitleTheKho As DataTable = New DataTable()
                    For i As Integer = 0 To 14
                        tbTitleTheKho.Columns.Add()
                    Next
                    tbTitleTheKho.Columns(0).ColumnName = "TIEU_DE"
                    tbTitleTheKho.Columns(1).ColumnName = "STT"
                    tbTitleTheKho.Columns(2).ColumnName = "NGAY"
                    tbTitleTheKho.Columns(3).ColumnName = "CHUNG_TU"
                    tbTitleTheKho.Columns(4).ColumnName = "NHAP"
                    tbTitleTheKho.Columns(5).ColumnName = "XUAT"
                    tbTitleTheKho.Columns(6).ColumnName = "CHUYEN_DEN"
                    tbTitleTheKho.Columns(7).ColumnName = "CHUYEN_DI"
                    tbTitleTheKho.Columns(8).ColumnName = "CHENH_LECH"
                    tbTitleTheKho.Columns(9).ColumnName = "SO_LUONG"
                    tbTitleTheKho.Columns(10).ColumnName = "DAU_KY"
                    tbTitleTheKho.Columns(11).ColumnName = "CUOI_KY"
                    tbTitleTheKho.Columns(12).ColumnName = "TONG"
                    tbTitleTheKho.Columns(13).ColumnName = "KHO_PT"
                    tbTitleTheKho.Columns(14).ColumnName = "DK_LOC"
                    Dim vRowTitle As DataRow = tbTitleTheKho.NewRow()
                    vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TIEU_DE", Commons.Modules.TypeLanguage)
                    vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "STT", Commons.Modules.TypeLanguage)
                    vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NGAY", Commons.Modules.TypeLanguage)
                    vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NGAY", Commons.Modules.TypeLanguage)
                    vRowTitle("CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUNG_TU", Commons.Modules.TypeLanguage)
                    vRowTitle("NHAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "NHAP", Commons.Modules.TypeLanguage)
                    vRowTitle("XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "XUAT", Commons.Modules.TypeLanguage)
                    vRowTitle("CHUYEN_DEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DEN", Commons.Modules.TypeLanguage)
                    vRowTitle("CHUYEN_DI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DI", Commons.Modules.TypeLanguage)
                    vRowTitle("CHENH_LECH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CHENH_LECH", Commons.Modules.TypeLanguage)
                    vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "SO_LUONG", Commons.Modules.TypeLanguage)
                    vRowTitle("DAU_KY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "DAU_KY", Commons.Modules.TypeLanguage)
                    vRowTitle("CUOI_KY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "CUOI_KY", Commons.Modules.TypeLanguage)
                    vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "TONG", Commons.Modules.TypeLanguage)
                    If (Commons.Modules.TypeLanguage = 0) Then
                        vRowTitle("KHO_PT") = "Kho : " & cbxKho.Text.Trim() & " - Phụ tùng : " & cbxVTPT.Text.Trim()
                    Else
                        vRowTitle("KHO_PT") = "Warehouse : " & cbxKho.Text.Trim() & " - Item : " & cbxVTPT.Text.Trim()
                    End If
                    If (Commons.Modules.TypeLanguage = 0) Then
                        vRowTitle("DK_LOC") = "Từ ngày : " & dtTNgay.Text.Trim() & " Đến ngày : " & dtDNgay.Text.Trim()
                    Else
                        vRowTitle("DK_LOC") = "From date : " & dtTNgay.Text & " To date : " & dtDNgay.Text.Trim()
                    End If
                    tbTitleTheKho.Rows.Add(vRowTitle)
                    frmRepot.AddDataTableSource(tbTitleTheKho)
                    frmRepot.ShowDialog()
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTheKho", "MsgCanNotData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub cbxKho_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxKho.SelectedIndexChanged
        Try
            BindDataVTPT(cbxKho.SelectedValue.ToString().Trim())
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
