Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons.VS.Classes.Admin
Public Class frmThoiGianTrongCuaThietBi

    Private Sub frmThoiGianTrongCuaThietBi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        dtTuNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 15)
        LoadcboLoaiTB()
        LoadcboThietBi()
        BindData()
    End Sub
    Sub LoadcboLoaiTB()
        cboLoaiTB.Display = "TEN_LOAI_MAY"
        cboLoaiTB.Value = "MS_LOAI_MAY"
        cboLoaiTB.StoreName = "PermisionLOAI_MAY"
        cboLoaiTB.Param = Commons.Modules.UserName
        cboLoaiTB.BindDataSource()
    End Sub
    Sub LoadcboThietBi()
        Dim str As String = ""
        If cboLoaiTB.SelectedValue Is Nothing Then
            Exit Sub
        Else
            str = "SELECT MAY.MS_MAY, MAY.MS_MAY AS TEN_MAY FROM MAY INNER JOIN " & _
            " NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
            " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
            " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID WHERE USERS.USERNAME = '" & Commons.Modules.UserName & "'"
            If cboLoaiTB.SelectedValue <> "-1" Then
                str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiTB.SelectedValue & "'"
            End If
        End If
        cboThietBi.Value = "MS_MAY"
        cboThietBi.Display = "TEN_MAY"
        cboThietBi.StoreName = "QL_SEARCH"
        cboThietBi.Param = str
        cboThietBi.BindDataSource()
    End Sub
    Sub BindData()
        Try
            grdDanhsachthoigiantrong.Columns.Clear()
        Catch ex As Exception
        End Try
        If cboThietBi.SelectedValue Is Nothing Or cboLoaiTB.SelectedValue Is Nothing Then
            Exit Sub
        End If
        grdDanhsachthoigiantrong.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetThoigianTrongCuaThietBi", cboLoaiTB.SelectedValue, cboThietBi.SelectedValue, Format(dtTuNgay.Value, "Short date"), Format(dtDenNgay.Value, "Short date")).Tables(0)
        grdDanhsachthoigiantrong.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
        grdDanhsachthoigiantrong.Columns("THU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THU", commons.Modules.TypeLanguage)
        grdDanhsachthoigiantrong.Columns("THU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDanhsachthoigiantrong.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY", commons.Modules.TypeLanguage)
        grdDanhsachthoigiantrong.Columns("NGAY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDanhsachthoigiantrong.Columns("FROM_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TU_GIO", commons.Modules.TypeLanguage)
        grdDanhsachthoigiantrong.Columns("FROM_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDanhsachthoigiantrong.Columns("TO_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DEN_GIO", commons.Modules.TypeLanguage)
        grdDanhsachthoigiantrong.Columns("TO_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Try
            Me.grdDanhsachthoigiantrong.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachthoigiantrong.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboLoaiTB_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiTB.SelectionChangeCommitted
        LoadcboThietBi()
        BindData()
    End Sub

    Private Sub dtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtTuNgay.Validating
        BindData()
    End Sub

    Private Sub dtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtDenNgay.Validating
        BindData()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub cboThietBi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThietBi.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub cboLoaiTB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboLoaiTB.Validating
        If cboLoaiTB.SelectedValue Is Nothing Then
            e.Cancel = True
        Else
            LoadcboThietBi()
            BindData()
        End If
    End Sub

    Private Sub cboThietBi_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboThietBi.Validating

        BindData()

    End Sub

    Private Sub dtTuNgay_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTuNgay.CloseUp
        BindData()
    End Sub

    Private Sub dtDenNgay_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDenNgay.CloseUp
        BindData()
    End Sub
    Sub CreatrptTieuDeThoiGianTrong()
        Dim NgayIn, TrangIn, TieuDe, ThoiGian, BoPhan, ThietBi, Thu, Ngay, TuGio, DenGio As String
        NgayIn = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "NgayIn", commons.Modules.TypeLanguage)
        TrangIn = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "TrangIn", commons.Modules.TypeLanguage)
        TieuDe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "TieuDe", commons.Modules.TypeLanguage)
        ThietBi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "ThietBi", commons.Modules.TypeLanguage)
        Thu = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "Thu", commons.Modules.TypeLanguage)
        Ngay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "Ngay", commons.Modules.TypeLanguage)
        TuGio = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "TuGio", commons.Modules.TypeLanguage)
        DenGio = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThoiGianTrongCuaThietBi", "DenGio", commons.Modules.TypeLanguage)
        If cboLoaiTB.SelectedValue <> "-1" Then
            BoPhan = lblBoPhan.Text + " " + cboLoaiTB.Text
        Else
            BoPhan = ""
        End If
        ThoiGian = lblTuNgay.Text + " " + Format(dtTuNgay.Value, "Short date") + " " + lblDenNgay.Text + " " + Format(dtDenNgay.Value, "Short date")
        Dim str As String = ""
        Try
            str = "Drop table rptTieuDeThoiGianTrong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "Create table dbo.rptTieuDeThoiGianTrong (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(50),TrangIn nvarchar(50)," & _
        " ThoiGian nvarchar(100),BoPhan nvarchar(250),ThietBi nvarchar(50),sNgay nvarchar(30),sThu nvarchar(30),TuGio nvarchar(50),DenGio nvarchar(50))" & _
        " Insert into dbo.rptTieuDeThoiGianTrong values(" & commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & ThoiGian & "',N'" & BoPhan & "',N'" & ThietBi & "',N'" & _
        Ngay & "',N'" & Thu & "',N'" & TuGio & "',N'" & DenGio & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Private Sub btnIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIN.Click
        If grdDanhsachthoigiantrong.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CreatrptTieuDeThoiGianTrong()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptThoigianTrongCuaThietBi", cboLoaiTB.SelectedValue, cboThietBi.SelectedValue, Format(dtTuNgay.Value, "Short date"), Format(dtDenNgay.Value, "Short date"))
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select COUNT(*) AS TONG from rptThoiGianTrongCuaThietBi")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                objReader.Close()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                GoTo KetThuc
            End If
        End While
        Commons.mdShowReport.ReportPreview("reports/rptThoiGianTrongCuaThietBi.rpt")
KetThuc:
        Me.Cursor = Cursors.Default
        Dim str As String
        Try
            str = "Drop table rptTieuDeThoiGianTrong"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "Drop table rptThoigianTrongCuaThietBi"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub
End Class