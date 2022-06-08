Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue

Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class frmPhanCongBaoTri
    Private dtDsTB As New DataTable
    Private dvDsTB As New DataView
    Public dtDsCN As New DataTable
    Public dvDsCN As New DataView
    Public CongNhanMay As New Commons.clsCongNhanMay

#Region "Sub & Function"
    Private Sub HideButton(ByVal bln As Boolean)
        btnThemSua.Visible = Not bln
        btnIn.Visible = Not bln
        btnXoa.Visible = Not bln
        btnThoat.Visible = Not bln

        btnGhi.Visible = bln
        btnKhongGhi.Visible = bln
        btnChonNhanVien.Visible = bln
    End Sub
    Private Sub LockControl(ByVal bln As Boolean)
        'grdDSThietBi.ReadOnly = bln
        'txtTimMay.ReadOnly = bln
        If grdDSNhanVienBaoTri.Columns.Count = 0 Then LocCongNhan()
        grdDSNhanVienBaoTri.ReadOnly = Not bln
        grdDSNhanVienBaoTri.Columns("GHI_CHU").ReadOnly = Not bln
        grdDSNhanVienBaoTri.Columns("MS_CONG_NHAN").ReadOnly = True
        grdDSNhanVienBaoTri.Columns("HO_TEN").ReadOnly = True


    End Sub
    Private Sub LoadData()
        dtDsTB = CongNhanMay.LoadDataThietBi
        dtDsCN = CongNhanMay.LoadDataCongNhan
    End Sub
    Private Sub LocThietBi()
        Dim sFilter As String = ""
        dvDsTB = New DataSet().DefaultViewManager.CreateDataView(dtDsTB)
        If txtTimMay.Text.Length > 0 Then
            If ch_TheoTen.Checked Then
                sFilter = "TEN_MAY LIKE '%" & txtTimMay.Text & "%'"
            Else
                sFilter = "MS_MAY LIKE '%" & txtTimMay.Text & "%'"
            End If

        End If
        dvDsTB.RowFilter = sFilter
        grdDSThietBi.DataSource = dvDsTB
        If grdDSThietBi.RowCount > 0 Then
            If ch_TheoTen.Checked Then
                grdDSThietBi.Rows(0).Cells("TEN_MAY").Selected = True
            Else
                grdDSThietBi.Rows(0).Cells("MS_MAY").Selected = True
            End If


        End If

    End Sub
    Private Sub LocCongNhan()
        Dim sFilter As String = ""
        dvDsCN = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        If grdDSThietBi.RowCount > 0 Then
            sFilter = "MS_MAY='" & grdDSThietBi.CurrentRow.Cells("MS_MAY").Value & "'"
        End If
        dvDsCN.RowFilter = sFilter
        grdDSNhanVienBaoTri.DataSource = dvDsCN
        DinhDangLuoiCongNhan()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Private Sub UpdateData()
        Dim dvUpdate As New DataView
        Dim i As Integer = 0
        dvUpdate = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvUpdate.RowFilter = "THAO_TAC='A'"
        For i = 0 To dvUpdate.Count - 1
            CongNhanMay.MS_MAY = dvUpdate(i).Item("MS_MAY")
            CongNhanMay.MS_CONG_NHAN = dvUpdate(i).Item("MS_CONG_NHAN")
            CongNhanMay.GHI_CHU = dvUpdate(i).Item("GHI_CHU")
            If Not CongNhanMay.Exist Then
                CongNhanMay.Add(Me.Name)
            End If
        Next

        dvUpdate = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvUpdate.RowFilter = "THAO_TAC='U'"
        For i = 0 To dvUpdate.Count - 1
            CongNhanMay.MS_MAY = dvUpdate(i).Item("MS_MAY")
            CongNhanMay.MS_CONG_NHAN = dvUpdate(i).Item("MS_CONG_NHAN")
            CongNhanMay.GHI_CHU = dvUpdate(i).Item("GHI_CHU")
            CongNhanMay.Update(Me.Name)
        Next

        dvUpdate = New DataSet().DefaultViewManager.CreateDataView(dtDsCN)
        dvUpdate.RowFilter = "THAO_TAC='D'"
        For i = 0 To dvUpdate.Count - 1
            CongNhanMay.MS_MAY = dvUpdate(i).Item("MS_MAY")
            CongNhanMay.MS_CONG_NHAN = dvUpdate(i).Item("MS_CONG_NHAN")
            CongNhanMay.DeleteOneRow(Me.Name)
        Next
        dtDsCN = CongNhanMay.LoadDataCongNhan()
        LocCongNhan()
    End Sub
    Private Sub SelectMay()
        Try
            txtMsMay.Text = ""
            txtTenMay.Text = ""
            txtLoaiThietBi.Text = ""
            txtNhomThietBi.Text = ""
            txtViTriLapDat.Text = ""
            txtNoiLapDat.Text = ""
            grdDSNhanVienBaoTri.DataSource = Nothing
            txtMsMay.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("MS_MAY").Value), "", grdDSThietBi.CurrentRow.Cells("MS_MAY").Value)
            txtTenMay.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("TEN_MAY").Value), "", grdDSThietBi.CurrentRow.Cells("TEN_MAY").Value)
            txtLoaiThietBi.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("TEN_LOAI_MAY").Value), "", grdDSThietBi.CurrentRow.Cells("TEN_LOAI_MAY").Value)
            txtNhomThietBi.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("TEN_NHOM_MAY").Value), "", grdDSThietBi.CurrentRow.Cells("TEN_NHOM_MAY").Value)
            txtViTriLapDat.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("MO_TA").Value), "", grdDSThietBi.CurrentRow.Cells("MO_TA").Value)
            txtNoiLapDat.Text = IIf(IsDBNull(grdDSThietBi.CurrentRow.Cells("TEN_N_XUONG").Value), "", grdDSThietBi.CurrentRow.Cells("TEN_N_XUONG").Value)
            LocCongNhan()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub DinhDangLuoiThietBi()
        With grdDSThietBi
            .Columns("TEN_LOAI_MAY").Visible = False
            .Columns("TEN_NHOM_MAY").Visible = False
            .Columns("TEN_N_XUONG").Visible = False
            .Columns("MO_TA").Visible = False
            .Columns("TEN_MAY").Visible = False
            .Columns("TEN_MAY").HeaderText = "Tên máy"
            .Columns("MS_MAY").HeaderText = "Mã máy"
            .Columns("MS_MAY").ReadOnly = True
        End With
    End Sub
    Private Sub DinhDangLuoiCongNhan()
        With grdDSNhanVienBaoTri
            .Columns("MS_MAY").Visible = False
            .Columns("THAO_TAC").Visible = False

            .Columns("MS_CONG_NHAN").HeaderText = "MS Nhân viên"
            .Columns("HO_TEN").HeaderText = "Họ tên"
            .Columns("GHI_CHU").HeaderText = "Ghi chú"

            .Columns("MS_CONG_NHAN").ReadOnly = True
            .Columns("HO_TEN").ReadOnly = True
            .Columns("GHI_CHU").ReadOnly = True
        End With
    End Sub
#End Region
#Region "Events"
    Private Sub frmPhanCongBaoTri_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        LocThietBi()
        DinhDangLuoiThietBi()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThemSua.Enabled = False
            btnXoa.Enabled = False

        End If
    End Sub
    Private Sub grdDSThietBi_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSThietBi.CellEnter
        Try
            SelectMay()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnThemSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemSua.Click
        LockControl(True)
        HideButton(True)
    End Sub
    Private Sub btnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        LockControl(False)
        HideButton(False)
        UpdateData()
    End Sub
    Private Sub btnKhongGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        HideButton(False)
        LockControl(False)
        dtDsCN = CongNhanMay.LoadDataCongNhan
        LocCongNhan()
    End Sub
    Private Sub txtTimMay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimMay.TextChanged
        LocThietBi()
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Dispose()
    End Sub
    Private Sub btnChonNhanVien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonNhanVien.Click
        frmChonNhanVienChoMayCongNhan.ShowDialog()
    End Sub
#End Region



    Private Sub ch_TheoTen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_TheoTen.CheckedChanged
        If ch_TheoTen.Checked Then
            grdDSThietBi.Columns("MS_MAY").Visible = False
            grdDSThietBi.Columns("TEN_MAY").Visible = True
        Else
            grdDSThietBi.Columns("MS_MAY").Visible = True
            grdDSThietBi.Columns("TEN_MAY").Visible = False
        End If
    End Sub

    Private Sub grdDSNhanVienBaoTri_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSNhanVienBaoTri.CellContentClick

    End Sub

    Private Sub grdDSNhanVienBaoTri_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDSNhanVienBaoTri.CellValidating
        Dim cell As DataGridViewCell = Me.grdDSNhanVienBaoTri.Item(e.ColumnIndex, e.RowIndex)
        Dim i As Integer = 0
        If cell.IsInEditMode Then
            Dim ctr As Control = Me.grdDSNhanVienBaoTri.EditingControl
            If e.RowIndex < 0 Then Exit Sub

            Select Case Me.grdDSNhanVienBaoTri.Columns(e.ColumnIndex).Name
                Case "GHI_CHU"
                    If grdDSNhanVienBaoTri.Rows(e.RowIndex).Cells("THAO_TAC").Value.ToString.Equals("N") Then
                        grdDSNhanVienBaoTri.Rows(e.RowIndex).Cells("THAO_TAC").Value = "U"
                    End If
            End Select
        End If
    End Sub

    Private Sub grdDSNhanVienBaoTri_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDSNhanVienBaoTri.UserDeletingRow
        If btnGhi.Visible Then
            e.Cancel = True
            Exit Sub
        End If
        If MsgBox("Bạn có muốn xóa dòng hiện tại không ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        CongNhanMay.MS_MAY = grdDSNhanVienBaoTri.CurrentRow.Cells("MS_MAY").Value
        CongNhanMay.MS_CONG_NHAN = grdDSNhanVienBaoTri.CurrentRow.Cells("MS_CONG_NHAN").Value
        CongNhanMay.DeleteOneRow(Me.Name)
    End Sub

    Private Sub grdDSNhanVienBaoTri_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDSNhanVienBaoTri.Validating

    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If MsgBox("Bạn có muốn xóa máy đang chọn không ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Exit Sub
        End If
        XoaMay(grdDSThietBi.CurrentRow.Cells("MS_MAY").Value)
        CongNhanMay.MS_MAY = grdDSThietBi.CurrentRow.Cells("MS_MAY").Value
        CongNhanMay.DeleteOneMS_MAY()
        dtDsCN = CongNhanMay.LoadDataCongNhan
        LocCongNhan()
    End Sub
    Private Sub XoaMay(ByVal MS_MAY As String)
        Dim sql As String = "select MS_CONG_NHAN from MAY_CONG_NHAN where MS_MAY='" & MS_MAY & "'"
        Dim vtb As New DataTable

        Try
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            For Each vr As DataRow In vtb.Rows
                Commons.Modules.SQLString = "exec UpdateMAY_CONG_NHAN_LOG '" & MS_MAY & "','" & vr("MS_CONG_NHAN").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub grdDSThietBi_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSThietBi.CellContentClick

    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        Me.Cursor = Cursors.WaitCursor
        Dim vRow As Integer = 2
        Dim vRowSum As Integer = 2
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        'Dim cander As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
        With ExcelSheets
            .Columns(1).ColumnWidth = 5
            .Columns(2).ColumnWidth = 40
            .Columns(3).ColumnWidth = 12
            .Columns(4).ColumnWidth = 12
            .Columns(5).ColumnWidth = 12
        End With
        'Thông Tin Chung
        Dim rgTTC As Excel.Range
        rgTTC = ExcelSheets.Range("A1", "D1")
        rgTTC.Merge(True)
        rgTTC.MergeCells() = True
        rgTTC.Font.Bold = True
        rgTTC.Value = "Công ty cổ phần Dược Hậu Giang"

        Dim rgDV As Excel.Range
        rgDV = ExcelSheets.Range("A2", "A2")
        rgDV.Font.Bold = True
        rgDV.Merge(True)
        rgDV.MergeCells() = True
        rgDV.Value = "Phòng cơ điện"

        'Tiêu Đề báo cáo
        Dim rangelb1 As Excel.Range
        rangelb1 = ExcelSheets.Range("A4", "E5")
        rangelb1.Merge(True)
        rangelb1.MergeCells() = True
        rangelb1.Font.Bold = True
        rangelb1.Font.Size = 14
        rangelb1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rangelb1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rangelb1.Value = "BẢNG PHÂN CÔNG BẢO TRÌ MÁY"
        'Xuất ngày In
        Dim rgNgayIn As Excel.Range
        rgNgayIn = ExcelSheets.Range("A7", "C7")
        rgNgayIn.Merge(True)
        rgNgayIn.MergeCells() = True
        rgNgayIn.Value = " Cập nhật ngày " & DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        'Xuất Tựa đề
        Dim rgSTT As Excel.Range
        rgSTT = ExcelSheets.Range("A9", "A9")
        rgSTT.Font.Bold = True
        rgSTT.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        rgSTT.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgSTT.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgSTT.Value = "STT"

        Dim rgTEN_TB As Excel.Range
        rgTEN_TB = ExcelSheets.Range("B9", "B9")
        rgTEN_TB.Font.Bold = True
        rgTEN_TB.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        rgTEN_TB.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgTEN_TB.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgTEN_TB.Value = "Tên thiết bị"

        Dim rgMA_TB As Excel.Range
        rgMA_TB = ExcelSheets.Range("C9", "C9")
        rgMA_TB.Font.Bold = True
        rgMA_TB.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        rgMA_TB.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgMA_TB.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgMA_TB.Value = "Mã số"

        Dim rgDV_SD As Excel.Range
        rgDV_SD = ExcelSheets.Range("D9", "D9")
        rgDV_SD.Font.Bold = True
        rgDV_SD.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        rgDV_SD.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgDV_SD.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgDV_SD.Value = "ĐV sử dụng "

        Dim rgPhan_Cong As Excel.Range
        rgPhan_Cong = ExcelSheets.Range("E9", "E9")
        rgPhan_Cong.Font.Bold = True
        rgPhan_Cong.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        rgPhan_Cong.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgPhan_Cong.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgPhan_Cong.Value = "Phân công"

        Dim vTbData As New Data.DataTable
        vTbData = CongNhanMay.GetDataPrint()


        Dim stt As Integer = 1
        Dim rowIndex As Integer = 10
        For Each row As DataRow In vTbData.Rows
            Dim vSTT As Excel.Range
            vSTT = ExcelSheets.Range("A" & rowIndex, "A" & rowIndex)
            vSTT.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlHairline)
            vSTT.Value = stt

            Dim vTEN_TB As Excel.Range
            vTEN_TB = ExcelSheets.Range("B" & rowIndex, "B" & rowIndex)
            vTEN_TB.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlHairline)
            vTEN_TB.Value = row("TEN_MAY")

            Dim vMA_TB As Excel.Range
            vMA_TB = ExcelSheets.Range("C" & rowIndex, "C" & rowIndex)
            vMA_TB.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlHairline)
            vMA_TB.Value = row("MS_MAY")

            Dim vDVI As Excel.Range
            vDVI = ExcelSheets.Range("D" & rowIndex, "D" & rowIndex)
            vDVI.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlHairline)
            vDVI.Value = row("TEN_N_XUONG")

            Dim vPC As Excel.Range
            vPC = ExcelSheets.Range("E" & rowIndex, "E" & rowIndex)
            vPC.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlHairline)
            vPC.Value = row("LIST_CN")

            stt = stt + 1
            rowIndex = rowIndex + 1
        Next

        Dim bdSTT As Excel.Range
        bdSTT = ExcelSheets.Range("A10", "A" & vTbData.Rows.Count + 9)
        bdSTT.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        Dim bdTen As Excel.Range
        bdTen = ExcelSheets.Range("B10", "B" & vTbData.Rows.Count + 9)
        bdTen.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        Dim bdma As Excel.Range
        bdma = ExcelSheets.Range("C10", "C" & vTbData.Rows.Count + 9)
        bdma.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        Dim bdnx As Excel.Range
        bdnx = ExcelSheets.Range("D10", "D" & vTbData.Rows.Count + 9)
        bdnx.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        Dim bdpc As Excel.Range
        bdpc = ExcelSheets.Range("E10", "E" & vTbData.Rows.Count + 9)
        bdpc.BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
        ExcelSheets.Columns.AutoFit()
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

End Class