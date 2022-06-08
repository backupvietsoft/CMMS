﻿Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports System.Globalization
Public Class frmrptTheKho

    Private Sub frmrptTheKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mTuNgay.Text = Date.Now.AddMonths(-1).ToString("dd/MM/yyyy")
            mDenNgay.Text = Date.Now.ToString("dd/MM/yyyy")
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
            Dim str As String = " SELECT DISTINCT  dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.MS_PT + '(' + dbo.IC_PHU_TUNG.TEN_PT + ')' as TEN_PT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO" & _
                                " FROM         dbo.VI_TRI_KHO_VAT_TU INNER JOIN" & _
                                " dbo.IC_PHU_TUNG ON dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT" & _
                                " WHERE dbo.VI_TRI_KHO_VAT_TU.MS_KHO = '" & MS_KHO & "'"
            vTbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            cbxVTPT.DataSource = vTbKho
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mTuNgay.Validating

        Try
            DateTime.ParseExact(mTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        If (Not mDenNgay.Text.Trim().Equals("/  /")) Then
            Try
                If DateTime.ParseExact(mTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) > DateTime.ParseExact(mDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgFromDateToDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                e.Cancel = True
            End Try
        End If

    End Sub

    Private Sub mDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mDenNgay.Validating

        Try
            DateTime.ParseExact(mDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        If (Not mTuNgay.Text.Trim().Equals("/  /")) Then
            Try
                If DateTime.ParseExact(mTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) > DateTime.ParseExact(mDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgToDateFromDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNotFormatDate", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                e.Cancel = True
            End Try
        End If

    End Sub

    Sub ReportBDL()
        Try


            Dim tbTheKho As DataTable = New DataTable()
            tbTheKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "H_GET_THE_KHO_BDL", cbxKho.SelectedValue, DateTime.ParseExact(mTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture), DateTime.ParseExact(mDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture), cbxVTPT.SelectedValue, commons.Modules.TypeLanguage))
            tbTheKho.TableName = "THE_KHO"

            If tbTheKho.Rows.Count > 0 Then
                tbTheKho.Columns("TON_CUOI_KY").ReadOnly = False
                Dim vToncuoi As Double = Convert.ToDouble(tbTheKho.Rows(0)("TON_DAU"))
                For Each vRow As DataRow In tbTheKho.Rows
                    vToncuoi = vToncuoi + Convert.ToDouble(vRow("SL_NHAP")) + Convert.ToDouble(vRow("SL_CHUYEN_DEN")) + Convert.ToDouble(vRow("SL_CHENH_LECH")) - Convert.ToDouble(vRow("SL_XUAT")) - -Convert.ToDouble(vRow("SL_CHUYEN_DI"))
                    vRow("TON_CUOI_KY") = vToncuoi
                Next
                Dim vtbPT As New DataTable()
                vtbPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetPhuTungTheKhoInfo_BDL", cbxVTPT.SelectedValue, commons.Modules.TypeLanguage))
                vtbPT.TableName = "PT_INFO"
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptTheKho_BDL"
                frmRepot.AddDataTableSource(LanguageBDL())
                frmRepot.AddDataTableSource(vtbPT)
                frmRepot.AddDataTableSource(tbTheKho)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgCanNotData", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "STT", commons.Modules.TypeLanguage)
        vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NGAY", commons.Modules.TypeLanguage)
        vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NGAY", commons.Modules.TypeLanguage)
        vRowTitle("CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUNG_TU", commons.Modules.TypeLanguage)
        vRowTitle("NHAP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NHAP", commons.Modules.TypeLanguage)
        vRowTitle("XUAT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "XUAT", commons.Modules.TypeLanguage)
        vRowTitle("CHUYEN_DEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DEN", commons.Modules.TypeLanguage)
        vRowTitle("CHUYEN_DI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DI", commons.Modules.TypeLanguage)
        vRowTitle("CHENH_LECH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHENH_LECH", commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO_LUONG", commons.Modules.TypeLanguage)
        vRowTitle("DAU_KY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "DAU_KY", commons.Modules.TypeLanguage)
        vRowTitle("CUOI_KY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CUOI_KY", commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TONG", commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NGUOI_LAP", commons.Modules.TypeLanguage)
        vRowTitle("SO_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO_CHUNG_TU", commons.Modules.TypeLanguage)
        vRowTitle("MA_SO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MA_SO", commons.Modules.TypeLanguage)
        vRowTitle("TEN_VT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TEN_VT", commons.Modules.TypeLanguage)
        vRowTitle("SO_HIEU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO_HIEU", commons.Modules.TypeLanguage)
        vRowTitle("MA_THAMKHAO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MA_THAMKHAO", commons.Modules.TypeLanguage)
        vRowTitle("NOI_SD") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NOI_SD", commons.Modules.TypeLanguage)
        vRowTitle("PAGES") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "PAGES", commons.Modules.TypeLanguage)
        vRowTitle("DVT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "DVT", commons.Modules.TypeLanguage)
        vRowTitle("SO_KE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO_KE", commons.Modules.TypeLanguage)
        vRowTitle("MA_KHO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MA_KHO", commons.Modules.TypeLanguage)
        vRowTitle("TON_MIN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TON_MIN", commons.Modules.TypeLanguage)
        vRowTitle("TEN_KHO") = cbxKho.Text.Trim
        vRowTitle("SAD") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SAD", commons.Modules.TypeLanguage)
        vRowTitle("WIK") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "WIK", commons.Modules.TypeLanguage)
        vRowTitle("SO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO", commons.Modules.TypeLanguage)
        vRowTitle("DIEN_GIAI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "DIEN_GIAI", commons.Modules.TypeLanguage)


        If (commons.Modules.TypeLanguage = 0) Then
            vRowTitle("DK_LOC") = "Từ ngày : " & mTuNgay.Text.Trim() & " Đến ngày : " & mDenNgay.Text.Trim()
        Else
            vRowTitle("DK_LOC") = "From date : " & mTuNgay.Text.Trim() & " To date : " & mDenNgay.Text.Trim()
        End If
        tbTitleTheKho.Rows.Add(vRowTitle)
        Return tbTitleTheKho
    End Function

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If (mTuNgay.Text.Trim().Equals("/  /")) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNhapTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            mTuNgay.Focus()
            Exit Sub
        End If
        If (mDenNgay.Text.Trim().Equals("/  /")) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgNhapDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            mDenNgay.Focus()
            Exit Sub
        End If


        Dim vtbInfo As New DataTable()
        vtbInfo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG"))
        Dim BDL As String = ""
        Try
            BDL = vtbInfo.Rows(0)("PRIVATE").ToString
        Catch ex As Exception
        End Try
        If BDL = "BDL" Then
            ReportBDL()
            Exit Sub
        Else
            Try
                Dim tbTheKho As DataTable = New DataTable()
                tbTheKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_THE_KHO", cbxKho.SelectedValue, DateTime.ParseExact(mTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture), DateTime.ParseExact(mDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture), cbxVTPT.SelectedValue, commons.Modules.TypeLanguage))
                tbTheKho.TableName = "THE_KHO"
                If (tbTheKho.Rows.Count > 0) Then
                    tbTheKho.Columns("TON_CUOI_KY").ReadOnly = False
                    Dim vToncuoi As Double = Convert.ToDouble(tbTheKho.Rows(0)("TON_DAU"))
                    For Each vRow As DataRow In tbTheKho.Rows
                        vToncuoi = vToncuoi + Convert.ToDouble(vRow("SL_NHAP")) + Convert.ToDouble(vRow("SL_CHUYEN_DEN")) - Convert.ToDouble(vRow("SL_CHENH_LECH")) - Convert.ToDouble(vRow("SL_XUAT")) - Convert.ToDouble(vRow("SL_CHUYEN_DI"))
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
                    vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TIEU_DE", commons.Modules.TypeLanguage)
                    vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "STT", commons.Modules.TypeLanguage)
                    vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NGAY", commons.Modules.TypeLanguage)
                    vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NGAY", commons.Modules.TypeLanguage)
                    vRowTitle("CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUNG_TU", commons.Modules.TypeLanguage)
                    vRowTitle("NHAP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "NHAP", commons.Modules.TypeLanguage)
                    vRowTitle("XUAT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "XUAT", commons.Modules.TypeLanguage)
                    vRowTitle("CHUYEN_DEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DEN", commons.Modules.TypeLanguage)
                    vRowTitle("CHUYEN_DI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHUYEN_DI", commons.Modules.TypeLanguage)
                    vRowTitle("CHENH_LECH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CHENH_LECH", commons.Modules.TypeLanguage)
                    vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "SO_LUONG", commons.Modules.TypeLanguage)
                    vRowTitle("DAU_KY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "DAU_KY", commons.Modules.TypeLanguage)
                    vRowTitle("CUOI_KY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "CUOI_KY", commons.Modules.TypeLanguage)
                    vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "TONG", commons.Modules.TypeLanguage)
                    If (commons.Modules.TypeLanguage = 0) Then
                        vRowTitle("KHO_PT") = "Kho : " & cbxKho.Text.Trim() & " - Phụ tùng : " & cbxVTPT.Text.Trim()
                    Else
                        vRowTitle("KHO_PT") = "Warehouse : " & cbxKho.Text.Trim() & " - Item : " & cbxVTPT.Text.Trim()
                    End If
                    If (commons.Modules.TypeLanguage = 0) Then
                        vRowTitle("DK_LOC") = "Từ ngày : " & mTuNgay.Text.Trim() & " Đến ngày : " & mDenNgay.Text.Trim()
                    Else
                        vRowTitle("DK_LOC") = "From date : " & mTuNgay.Text.Trim() & " To date : " & mDenNgay.Text.Trim()
                    End If
                    tbTitleTheKho.Rows.Add(vRowTitle)
                    frmRepot.AddDataTableSource(tbTitleTheKho)
                    frmRepot.ShowDialog()
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTheKho", "MsgCanNotData", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
