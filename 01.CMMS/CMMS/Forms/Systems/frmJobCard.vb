Imports System.Data.SqlClient

Imports Commons.VS.Classes.Admin
Imports Commons.VS.Classes.Catalogue

Imports Microsoft.ApplicationBlocks.Data

Imports Microsoft.VisualBasic.DateAndTime


Public Class frmJobCard

    Private rowindex As Integer = -1
    Private row_cv_index As Integer = -1
    Private row_cvp_index As Integer = -1
    Private gio As String
    Private phut As String
    Private rowcout As Integer = -1
    Private arr_tmp(50, 2) As String
    Private TU_GIO_TMP As String
    Private bThem As Boolean = False
    Private SqlText As String
#Region "Events"

    Private Sub frmJobCard_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub
    Private Sub frmJobCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        If Commons.Modules.TypeLanguage = 0 Then
            Me.gio = "Giờ"
            Me.phut = "Phút"
        Else
            Me.gio = "Hour"
            Me.phut = "minute"
        End If
        visible_Button(True)
        lock_Control(True)

        radCongviecchinh.Checked = True
        binddata_comboLoaiTB()
        refresh_Language_Form()

        loadCboTo()
        loadCboNhanVien()
        dtpTuNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 30)
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        Dim jobcardinfo As New clsJobCardInfo()
        Dim jobcardcontroller As New JOBCARD_Controller

        If Me.tabControl.SelectedIndex = 0 Then
            ' Xóa kế hoạch công nhân công việc
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa_CNCV", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                jobcardinfo.PHIEU_BT = Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString
                jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("cbo_CN").Value
                jobcardinfo.NGAY = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("NGAY").Value
                jobcardinfo.TU_GIO = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("TU_GIO_TMP").Value
                If Me.radCongviecchinh.Checked Then
                    ' Xóa kế hoạch công nhân công việc chính
                    jobcardinfo.CONG_VIEC = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value
                    jobcardinfo.BO_PHAN = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value

                    jobcardcontroller.delete_congnhancongviecchinh(jobcardinfo)
                Else
                    ' Xóa kế hoạch công nhân công việc phụ
                    jobcardinfo.STT = Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value

                    jobcardcontroller.delete_congnhancongviecphu(jobcardinfo)
                End If
            End If
        End If

        'binddata_Kehoachcongviec()
        binddata_Kehoachnhanvien()
    End Sub

    Private Sub btnThemsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua.Click
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpJOB_CARD" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.tmpJOB_CARD" & Commons.Modules.UserName & " (MS_CONG_NHAN NVARCHAR(9),TU_GIO NVARCHAR(12),TU_NGAY NVARCHAR(12),DEN_GIO NVARCHAR(12),DONG INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        bThem = True
        If grdCuasobaotri.Rows.Count > 0 Then
            btnCapnhatthoigiancongviec.Visible = True
        Else
            btnCapnhatthoigiancongviec.Visible = False
        End If
        binddata_Kehoachnhanvien()
        visible_Button(False)
        lock_Control(False)
    End Sub

    Private Sub btnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi.Click

        Dim jobcardinfo As New clsJobCardInfo()
        Dim jobcardcontroller As New JOBCARD_Controller

        If Me.tabControl.SelectedIndex = 0 Then
            ' Lưu kế hoạch nhân viên
            If Me.radCongviecchinh.Checked Then
                ' Kế hoạch nhân viên cho công việc chính
                Dim dtReader As SqlDataReader
                jobcardinfo.PHIEU_BT = Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString
                jobcardinfo.CONG_VIEC = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value
                jobcardinfo.BO_PHAN = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value
                For i As Integer = 0 To Me.grdKehoachnhanvien.RowCount - 2
                    If Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value, "Long time") <> "00:00" Or Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO_TMP").Value, "Long time") <> "00:00" Then
                        jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                        jobcardinfo.NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date")
                        jobcardinfo.TU_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value, "Long time")
                        jobcardinfo.DEN_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value, "Long time")
                        jobcardinfo.CONG_NHAN_tmp = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CN").Value
                        jobcardinfo.NGAY_tmp = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY_TMP").Value, "short date")
                        jobcardinfo.TU_GIO_tmp = Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value, "Long time")
                        jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                        jobcardcontroller.update_congnhancongviec_PBT(jobcardinfo)
                        jobcardcontroller.update_congnhancongviecchinh(jobcardinfo)
                    Else
                        If Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value = "00:00" And Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value = "00:00" Then
                            Continue For
                        End If
                        jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                        jobcardinfo.NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date")
                        jobcardinfo.TU_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value, "Long time")
                        jobcardinfo.DEN_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value, "Long time")
                        jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_PBT_CV_NS", jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, jobcardinfo.CONG_NHAN)
                        If Not dtReader.HasRows Then
                            jobcardcontroller.add_congnhancongviec_PBT(jobcardinfo)
                        End If
                        jobcardcontroller.add_congnhancongviecchinh(jobcardinfo)
                    End If

                Next
            Else
                ' Kế hoạch nhân viên cho công việc phụ
                jobcardinfo.PHIEU_BT = Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString
                jobcardinfo.STT = Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value
                For i As Integer = 0 To Me.grdKehoachnhanvien.RowCount - 2
                    If Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value, "Long time") <> "00:00:00" Or Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO_TMP").Value, "Long time") <> "00:00:00" Then
                        jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                        jobcardinfo.NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date"))
                        jobcardinfo.TU_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value)
                        jobcardinfo.DEN_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value)
                        jobcardinfo.CONG_NHAN_tmp = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CN").Value
                        jobcardinfo.NGAY_tmp = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY_TMP").Value, "short date"))
                        jobcardinfo.TU_GIO_tmp = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value)
                        jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                        jobcardcontroller.update_congnhancongviecphu(jobcardinfo)
                    Else
                        If Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value = "00:00" And Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value = "00:00" Then
                            Continue For
                        End If
                        jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                        jobcardinfo.NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date"))
                        jobcardinfo.TU_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value)
                        jobcardinfo.DEN_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value)
                        jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                        jobcardcontroller.add_congnhancongviecphu(jobcardinfo)
                    End If
                Next
            End If
        End If
        bThem = False
        visible_Button(True)
        lock_Control(True)
        binddata_Kehoachnhanvien()
        btnCapnhatthoigiancongviec.Visible = False
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpJOB_CARD" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        bThem = False
        visible_Button(True)
        lock_Control(True)
        binddata_Kehoachnhanvien()
        btnCapnhatthoigiancongviec.Visible = False
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpJOB_CARD" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub radCongviecchinh_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCongviecchinh.CheckedChanged
        visible_Control()
    End Sub

    Private Sub cboLoaithietbi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboLoaithietbi.SelectedIndexChanged
        binddata_comboNhomTB()
    End Sub

    Private Sub cboNhomthietbi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboNhomthietbi.SelectedIndexChanged
        binddata_Phieubaotri()
    End Sub

    Private Sub grdDanhsachphieubaotri_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachphieubaotri.RowEnter
        If rowindex <> e.RowIndex Then
            Me.grdCuasobaotri.DataSource = System.DBNull.Value
        End If
        rowindex = e.RowIndex
        binddata_Congviecchinh()
        binddata_CongviecPhu()


    End Sub

    Private Sub grdDanhsachphieubaotri_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachphieubaotri.RowHeaderMouseClick
        If rowindex <> e.RowIndex Then
            Me.grdCuasobaotri.DataSource = System.DBNull.Value
        End If
        rowindex = e.RowIndex
        binddata_Congviecchinh()
        binddata_CongviecPhu()
    End Sub

    Private Sub grdCongviecchinh_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecchinh.CellValidated
        If grdCongviecchinh.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If Not bCapnhat Then
                grdCongviecchinh.Rows(e.RowIndex).Cells("cboNgay").Value = DBNull.Value
                bCapnhat = True
            End If
        End If
    End Sub
    Private bCapnhat As Boolean = True
    Private Sub grdCongviecchinh_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCongviecchinh.CellValidating
        If grdCongviecchinh.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                If Not IsDate(e.FormattedValue) Then
                    'XtraMessageBox.Show("Ngày hoàn thành nhập không hợp lệ")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHoanThanh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdCongviecchinh.Rows(e.RowIndex).ErrorText = "Error"
                    grdCongviecchinh.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                    grdCongviecchinh.Focus()
                    e.Cancel = True
                    Exit Sub
                Else
                    Dim str As String = ""
                    Dim objReader As SqlDataReader
                    str = "SELECT NGAY_HOAN_THANH FROM  PHIEU_BAO_TRI_CONG_VIEC  WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                                                                  "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        If objReader.Item("NGAY_HOAN_THANH").ToString <> "" Then
                            If Format(objReader.Item("NGAY_HOAN_THANH"), "Short date") <> Format(e.FormattedValue, "Short date") Then
                                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                                                                              "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            End If
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    str = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                    "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Dim tmp As Boolean = False
                    While objReader.Read
                        If objReader.Item("MS_CONG_NHAN").ToString <> "" Then
                            tmp = True
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                                              "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    objReader.Close()
                    If Not tmp Then
                        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgghi", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                        If Traloi = vbNo Then
                            grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                            bCapnhat = False
                            Exit Sub
                        Else
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                   "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                        End If
                    End If
                End If
            Else
                Dim str As String = ""
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                    "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                btnThemsua.Enabled = True
                btnXoa.Enabled = True
            End If
        End If
        grdCongviecchinh.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub grdCongviecchinh_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecchinh.RowEnter
        row_cv_index = e.RowIndex
        If Me.radCongviecchinh.Checked Then
            binddata_Kehoachnhanvien()
            'Try
            '    If grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
            '        btnThemsua.Enabled = False
            '        btnXoa.Enabled = False
            '    Else
            '        btnThemsua.Enabled = True
            '        btnXoa.Enabled = True
            '    End If
            'Catch ex As Exception

            'End Try

        End If
    End Sub

    Private Sub grdCongviecchinh_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdCongviecchinh.RowHeaderMouseClick
        row_cv_index = e.RowIndex
        binddata_Kehoachnhanvien()
    End Sub

    Private Sub grdCongviecphu_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecphu.CellValidated
        If grdCongviecphu.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If Not bCapnhat1 Then
                grdCongviecphu.Rows(e.RowIndex).Cells("cboNgay").Value = DBNull.Value
                bCapnhat1 = True
            End If
        End If
    End Sub
    Private bCapnhat1 As Boolean = True
    Private Sub grdCongviecphu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCongviecphu.CellValidating
        If grdCongviecphu.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                If Not IsDate(e.FormattedValue) Then
                    'XtraMessageBox.Show("Ngày hoàn thành nhập không hợp lệ")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayhoanThanh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdCongviecphu.Rows(e.RowIndex).ErrorText = "Error"
                    grdCongviecphu.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                    grdCongviecphu.Focus()
                    e.Cancel = True
                    Exit Sub
                Else
                    Dim str As String = ""
                    Dim objReader As SqlDataReader
                    str = "SELECT NGAY_HOAN_THANH FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        If objReader.Item("NGAY_HOAN_THANH").ToString <> "" Then
                            If Format(objReader.Item("NGAY_HOAN_THANH"), "Short date") <> Format(e.FormattedValue, "Short date") Then
                                str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                                                "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            End If
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    objReader.Close()
                    str = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO wHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Dim tmp As Boolean = False
                    While objReader.Read
                        If objReader.Item("MS_CONG_NHAN").ToString <> "" Then
                            tmp = True
                            str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    objReader.Close()
                    If Not tmp Then
                        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgghi", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                        If Traloi = vbNo Then
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                            bCapnhat1 = False
                            Exit Sub
                        Else
                            str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                                                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                        End If
                    End If
                End If
            Else
                Dim str As String = ""
                str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" & Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & _
                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                btnThemsua.Enabled = True
                btnXoa.Enabled = True
            End If
        End If
        grdCongviecphu.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub grdCongviecphu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecphu.RowEnter
        row_cvp_index = e.RowIndex
        If Me.radCongviecphutro.Checked Then
            binddata_Kehoachnhanvien()
            Try
                If grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                Else
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub grdCongviecphu_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdCongviecphu.RowHeaderMouseClick
        row_cvp_index = e.RowIndex
        binddata_Kehoachnhanvien()
    End Sub
    Private Sub grdKehoachcongviec_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        With e.Row
            .Cells("cboNgay_KH").Value = Format(Date.Now, "short date")
        End With
    End Sub

    Private Sub grdKehoachnhanvien_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKehoachnhanvien.CellValidated
        If Me.btnKhongghi.Focused Then Exit Sub
        If Me.grdKehoachnhanvien.Rows(e.RowIndex).IsNewRow Then Exit Sub
        If btnGhi.Visible Then
            If grdKehoachnhanvien.Columns(e.ColumnIndex).Name = "cbo_CN" Then
                'If radCongviecchinh.Checked Then
                If grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CN").Value.ToString = "" Then
                    grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CN").Value = grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN").Value
                Else
                    If grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CN").Value <> grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN").Value Then
                        If Format(grdKehoachnhanvien.Rows(e.RowIndex).Cells("TU_GIO_TMP").Value, "Long time") = "00:00:00" And Format(grdKehoachnhanvien.Rows(e.RowIndex).Cells("DEN_GIO_TMP").Value, "Long time") = "00:00:00" Then
                            Dim SQL As String = "SELECT HO + ' ' + TEN AS TEN_CONG_NHAN FROM CONG_NHAN WHERE MS_CONG_NHAN = '" & grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN").Value & "'"
                            Dim dtreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                            While dtreader.Read
                                Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("TEN_CONG_NHAN").Value = dtreader.Item(0)
                            End While
                            dtreader.Close()
                            Exit Sub
                        End If
                        Dim str As String = ""
                        str = "SELECT MS_CONG_NHAN FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & _
                        Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value & "' AND MS_BO_PHAN='" & _
                        Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value & "' AND MS_CV=" & Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value & ""
                        Dim objreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        While objreader.Read
                            If objreader.Item("MS_CONG_NHAN").ToString <> "" Then
                                'XtraMessageBox.Show("Không thể thay đổi nhân viên này")
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNhanVienTonTai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                Dim SQL As String = "SELECT HO + ' ' + TEN AS TEN_CONG_NHAN FROM CONG_NHAN WHERE MS_CONG_NHAN = '" & grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CN").Value & "'"
                                Dim dtreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                                While dtreader.Read
                                    Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("TEN_CONG_NHAN").Value = dtreader.Item(0)
                                End While
                                dtreader.Close()
                                objreader.Close()
                                grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN").Value = grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CN").Value
                                Exit Sub
                            End If
                        End While

                    End If
                End If
                'End If
            End If
        End If
    End Sub

    Private Sub grdKehoachnhanvien_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdKehoachnhanvien.CellValidating
        If Me.btnKhongghi.Focused Then Exit Sub
        If Me.grdKehoachnhanvien.Rows(e.RowIndex).IsNewRow Then Exit Sub

        Dim cell As DataGridViewCell = Me.grdKehoachnhanvien.Item(e.ColumnIndex, e.RowIndex)
        If cell.IsInEditMode Then
            Dim ctr As Control = Me.grdKehoachnhanvien.EditingControl
            Select Case Me.grdKehoachnhanvien.Columns(e.ColumnIndex).Name
                Case "cbo_CN"
                    Dim SQL As String = "SELECT HO + ' ' + TEN AS TEN_CONG_NHAN FROM CONG_NHAN WHERE MS_CONG_NHAN = '" & ctr.Text & "'"
                    Dim dtreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                    While dtreader.Read
                        Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("TEN_CONG_NHAN").Value = dtreader.Item(0)
                    End While
                    dtreader.Close()
                Case "cboTu_gio"
                    If ctr.Text = "" Or ctr.Text = "  :" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(ctr.Text) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub
                        Else
                            'If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value.ToString <> "" Then
                            '    If Date.Parse(ctr.Text) >= Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value) Then
                            '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Greater", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            '        e.Cancel = True
                            '        Exit Sub
                            '    End If
                            'End If
                        End If
                    End If
                    TU_GIO_TMP = ctr.Text
                Case "cboDen_gio"
                    If ctr.Text = "" Or ctr.Text = "  :" Then
                        If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "  :" Then Exit Sub
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(ctr.Text) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub
                        Else
                            If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "  :" Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                e.Cancel = False
                                Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Selected = True
                                Exit Sub
                            Else
                                'If Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value) >= Date.Parse(ctr.Text) Then
                                '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenGioNhoHonTuGio", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                '    ctr.Text = "  :"
                                '    e.Cancel = True
                                '    Exit Sub
                                'End If
                            End If
                        End If
                    End If
                Case "cboNgay"
                    If ctr.Text = "" Or ctr.Text = "  /  /" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                        grdKehoachnhanvien.Focus()
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                            grdKehoachnhanvien.Focus()
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub grdKehoachnhanvien_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdKehoachnhanvien.DataError
        If btnKhongghi.Focused() Then
            Exit Sub
        End If
        If grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN").Value.ToString = "" Then
            'XtraMessageBox.Show("Chưa chọn nhân viên ")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNhanVienNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(e.RowIndex).Cells("cbo_CN")
            grdKehoachnhanvien.Focus()
            e.Cancel = True
            Exit Sub
        Else
            'XtraMessageBox.Show("Nhân viên này đã được phân công công việc trong khoảng thời gian này")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungKhoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grdKehoachnhanvien_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdKehoachnhanvien.DefaultValuesNeeded
        With e.Row
            .Cells("cboNgay").Value = Format(Date.Now, "short date")
            .Cells("cboTu_gio").Value = "00:00"
            .Cells("cboDen_gio").Value = "00:00"
            .Cells("TU_GIO_TMP").Value = Date.Parse("00:00:00")
            .Cells("DEN_GIO_TMP").Value = Date.Parse("00:00:00")
        End With
    End Sub

    Private Sub tabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabControl.SelectedIndexChanged
        lock_button()
    End Sub

    Private Sub btnTinhcuasobaotri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhcuasobaotri.Click
        If Me.grdDanhsachphieubaotri.RowCount = 0 Then Exit Sub

        binddata_Cuasobaotri()
        If btnGhi.Visible Then
            If grdCuasobaotri.Rows.Count > 0 Then
                btnCapnhatthoigiancongviec.Visible = True
            Else
                btnCapnhatthoigiancongviec.Visible = False
            End If
        End If

    End Sub

    Private Sub btnPhieubaotri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhieubaotri.Click
        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuBaoTri_KIDO.Name) Then
            FrmPhieuBaoTri_KIDO.Show()
        End If
    End Sub
#End Region

#Region "Methods"
    Sub Enable_Button(ByVal bln As Boolean)
        Me.btnCapnhatgioNV.Enabled = bln
        Me.btnThemsua.Enabled = bln
        Me.btnXoa.Enabled = bln
        Me.btnTinhcuasobaotri.Enabled = bln
        Me.btnCapnhatthoigiancongviec.Enabled = bln
        Me.btnPhieubaotri.Enabled = bln
    End Sub

    Sub visible_Button(ByVal bln As Boolean)
        btnThemsua.Visible = bln
        btnXoa.Visible = bln
        btnIn.Visible = bln
        btnThoat.Visible = bln
        btnGhi.Visible = Not bln
        btnKhongghi.Visible = Not bln
    End Sub

    Sub lock_button()
        Me.btnThemsua.Enabled = True
        Me.btnIn.Enabled = False
        If Me.tabControl.SelectedIndex = 0 Then
            If Me.radCongviecchinh.Checked Then
                If Me.grdCongviecchinh.RowCount > 0 Then
                    If grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                        Me.btnThemsua.Enabled = False
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                    If Me.grdKehoachnhanvien.RowCount > 0 Then
                        Me.btnXoa.Enabled = True
                        Exit Sub
                    Else
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                Else
                    Me.btnThemsua.Enabled = False
                    Me.btnXoa.Enabled = False
                    Exit Sub
                End If
            Else
                If Me.grdCongviecphu.RowCount > 0 Then
                    If grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                        Me.btnThemsua.Enabled = False
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                    If Me.grdKehoachnhanvien.RowCount > 0 Then
                        Me.btnXoa.Enabled = True
                        Exit Sub
                    Else
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                Else
                    Me.btnThemsua.Enabled = False
                    Me.btnXoa.Enabled = False
                    Exit Sub
                End If
            End If
        Else
            Me.btnXoa.Enabled = False
            Me.btnThemsua.Enabled = False
            Me.btnIn.Enabled = True
        End If
    End Sub

    Sub lock_Control(ByVal lock As Boolean)
        Me.cboLoaithietbi.Enabled = lock
        Me.cboNhomthietbi.Enabled = lock

        Me.radCongviecchinh.Enabled = lock
        Me.radCongviecphutro.Enabled = lock

        Me.grdCongviecchinh.Enabled = lock
        Me.grdCongviecphu.Enabled = lock
        Me.grdDanhsachphieubaotri.Enabled = lock
        Me.grdKehoachnhanvien.ReadOnly = lock

        Try
            Me.grdKehoachnhanvien.Columns("TEN_CONG_NHAN").ReadOnly = True
        Catch ex As Exception
        End Try

        If Me.tabControl.SelectedIndex = 0 Then
            Me.grdKehoachnhanvien.AllowUserToAddRows = Not lock
        End If
    End Sub

    Sub visible_Control()
        If Me.radCongviecchinh.Checked Then
            Me.grpCongviecchinh.Visible = True
            Me.grpCongviecphu.Visible = False
        Else
            Me.grpCongviecchinh.Visible = False
            Me.grpCongviecphu.Visible = True
        End If

        'binddata_Kehoachcongviec()
        binddata_Kehoachnhanvien()
    End Sub

    Sub binddata_comboLoaiTB()
        RemoveHandler cboLoaithietbi.SelectedIndexChanged, AddressOf Me.cboLoaithietbi_SelectedIndexChanged
        cboLoaithietbi.SelectedIndex = -1
        cboLoaithietbi.Param = Commons.Modules.UserName
        cboLoaithietbi.BindDataSource()

        If Me.cboLoaithietbi.Items.Count > 0 Then
            cboLoaithietbi.SelectedIndex = -1
            AddHandler cboLoaithietbi.SelectedIndexChanged, AddressOf Me.cboLoaithietbi_SelectedIndexChanged
            cboLoaithietbi.SelectedIndex = 0
        Else
            AddHandler cboLoaithietbi.SelectedIndexChanged, AddressOf Me.cboLoaithietbi_SelectedIndexChanged
        End If
    End Sub

    Sub binddata_comboNhomTB()
        RemoveHandler cboNhomthietbi.SelectedIndexChanged, AddressOf Me.cboNhomthietbi_SelectedIndexChanged
        cboNhomthietbi.SelectedIndex = -1
        cboNhomthietbi.Param = Me.cboLoaithietbi.SelectedValue.ToString
        cboNhomthietbi.BindDataSource()

        If Me.cboNhomthietbi.Items.Count > 0 Then
            cboNhomthietbi.SelectedIndex = -1
            AddHandler cboNhomthietbi.SelectedIndexChanged, AddressOf Me.cboNhomthietbi_SelectedIndexChanged
            cboNhomthietbi.SelectedIndex = 0
        Else
            binddata_Phieubaotri()
        End If
    End Sub

    Sub binddata_Phieubaotri()
        Dim objController As New JOBCARD_Controller
        Me.grdDanhsachphieubaotri.DataSource = objController.Get_Danhsachphieubaotri(cboLoaithietbi.SelectedValue, cboNhomthietbi.SelectedValue)
        formatGrid_Phieubaotri()

        If Me.grdDanhsachphieubaotri.RowCount > 0 Then
            rowindex = 0
            If Me.radCongviecchinh.Checked Then
                binddata_Congviecchinh()
            Else
                binddata_CongviecPhu()
            End If
        Else
            rowindex = -1
            Me.grdCuasobaotri.DataSource = System.DBNull.Value
            Me.grdCongviecchinh.DataSource = System.DBNull.Value
            Me.grdCongviecphu.DataSource = System.DBNull.Value
            Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            btnThemsua.Enabled = False
            btnXoa.Enabled = False
        End If
    End Sub

    Sub binddata_Cuasobaotri()
        Dim objController As New JOBCARD_Controller
        Me.grdCuasobaotri.DataSource = objController.get_Cuasobaotri(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_MAY").Value.ToString, Format(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("NGAY_BD_KH").Value, "short date"), Format(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("NGAY_KT_KH").Value, "short date"))

        formatGrid_Cuasobaotri()
    End Sub

    Sub binddata_Congviecchinh()
        Try
            grdCongviecchinh.Columns.Clear()
        Catch ex As Exception

        End Try
        Dim objController As New JOBCARD_Controller
        Me.grdCongviecchinh.DataSource = objController.get_Congviecchinh(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value, Commons.Modules.UserName)
        formatGrid_Congviecchinh()

        If Me.grdCongviecchinh.RowCount > 0 Then
            Me.row_cv_index = 0
            If Me.radCongviecchinh.Checked Then
                'binddata_Kehoachcongviec()
                binddata_Kehoachnhanvien()
            End If
        Else
            Me.row_cv_index = -1
            Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Me.btnThemsua.Enabled = False
            Me.btnXoa.Enabled = False
        End If
    End Sub

    Sub binddata_CongviecPhu()
        Try
            grdCongviecphu.Columns.Clear()
        Catch ex As Exception

        End Try
        Dim objController As New JOBCARD_Controller
        Me.grdCongviecphu.DataSource = objController.get_Congviecphu(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value)
        formatGrid_Congviecphu()

        If Me.grdCongviecphu.RowCount > 0 Then
            Me.row_cvp_index = 0
            If Me.radCongviecphutro.Checked Then
                'binddata_Kehoachcongviec()
                binddata_Kehoachnhanvien()
            End If
        Else
            Me.row_cvp_index = -1
            Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Me.btnThemsua.Enabled = False
            Me.btnXoa.Enabled = False
        End If
    End Sub
    Dim TBNhanVien As New DataTable()
    Sub binddata_Kehoachnhanvien()
        Dim objcontroller As New JOBCARD_Controller
        Try
            Me.grdKehoachnhanvien.Columns.Clear()
        Catch ex As Exception
        End Try

        If Me.radCongviecchinh.Checked Then
            If (Me.rowindex = -1) Or (Me.row_cv_index = -1) Then
                Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Else
                If bThem Then
                    TBNhanVien = objcontroller.get_Kehoachnhanvien(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value.ToString, 1)
                Else
                    TBNhanVien = objcontroller.get_Kehoachnhanvien(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value.ToString, 0)
                End If

                TBNhanVien.Columns("TEN_CONG_NHAN").ReadOnly = False
                TBNhanVien.Columns("TU_GIO").ReadOnly = False
                TBNhanVien.Columns("DEN_GIO").ReadOnly = False
                TBNhanVien.Columns("TU_GIO_TMP").AllowDBNull = True
                TBNhanVien.Columns("DEN_GIO_TMP").AllowDBNull = True
                Dim priCol(2) As DataColumn
                priCol(0) = TBNhanVien.Columns("MS_CONG_NHAN")
                priCol(1) = TBNhanVien.Columns("NGAY")
                priCol(2) = TBNhanVien.Columns("TU_GIO")
                TBNhanVien.PrimaryKey = priCol
                Me.grdKehoachnhanvien.DataSource = TBNhanVien
                formatGrid_Kehoachnhanvien()
            End If
        Else
            If (Me.rowindex = -1) Or (Me.row_cvp_index = -1) Then
                Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Else
                If bThem Then
                    TBNhanVien = objcontroller.get_Kehoachnhanvienphu(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString, Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value, 1)
                Else
                    TBNhanVien = objcontroller.get_Kehoachnhanvienphu(Me.grdDanhsachphieubaotri.Rows(rowindex).Cells("MS_PHIEU_BAO_TRI").Value.ToString, Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value, 0)
                End If
                TBNhanVien.Columns("TEN_CONG_NHAN").ReadOnly = False
                TBNhanVien.Columns("TU_GIO").ReadOnly = False
                TBNhanVien.Columns("DEN_GIO").ReadOnly = False
                TBNhanVien.Columns("TU_GIO_TMP").AllowDBNull = True
                TBNhanVien.Columns("DEN_GIO_TMP").AllowDBNull = True
                Dim priCol1(2) As DataColumn
                priCol1(0) = TBNhanVien.Columns("MS_CONG_NHAN")
                priCol1(1) = TBNhanVien.Columns("NGAY")
                priCol1(2) = TBNhanVien.Columns("TU_GIO")
                TBNhanVien.PrimaryKey = priCol1
                Me.grdKehoachnhanvien.DataSource = TBNhanVien
                formatGrid_Kehoachnhanvien()
            End If
        End If
        If Me.grdKehoachnhanvien.RowCount > 0 Then
            Me.grdKehoachnhanvien.Rows(0).Cells("cbo_CN").Selected = True
        End If
        lock_button()

        If radCongviecchinh.Checked Then
            Try
                If grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" And grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "  /  /" Then
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                Else
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" And grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "  /  /" Then
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                Else
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub formatGrid_Phieubaotri()
        With Me.grdDanhsachphieubaotri
            .Columns("MS_MAY").Width = 100
            .Columns("MS_PHIEU_BAO_TRI").Width = 100
            .Columns("TEN_UU_TIEN").Width = 80
            .Columns("TG_KH").Width = 100

            .Columns("TEN_UU_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TG_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            refresh_Language_PBT()
        End With
    End Sub

    Sub refresh_Language_PBT()
        With Me.grdDanhsachphieubaotri
            .Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
            .Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
            .Columns("TEN_UU_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_UU_TIEN", Commons.Modules.TypeLanguage)
            .Columns("TG_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TG_KH", Commons.Modules.TypeLanguage)
            .Columns("NGAY_BD_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_BD_KH", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub formatGrid_Cuasobaotri()
        With Me.grdCuasobaotri
            .Columns("THU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FROM_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TO_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_CSBT()
    End Sub

    Sub refresh_Language_CSBT()
        With Me.grdCuasobaotri
            .Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            .Columns("THU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THU", Commons.Modules.TypeLanguage)
            .Columns("FROM_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            .Columns("TO_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub formatGrid_Congviecchinh()
        Dim col As New Commons.QLGridMaskedTextBoxColumn()
        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY_HOAN_THANH"
        col.Mask = "00/00/0000"
        Me.grdCongviecchinh.Columns.Insert(4, col)
        With Me.grdCongviecchinh
            .Columns("MS_CV").Visible = False
            .Columns("MS_BO_PHAN").Visible = False
            .Columns("NGAY_HOAN_THANH").Visible = False
            .Columns("MO_TA_CV").Width = 300
            .Columns("SO_GIO_KH").Width = 80
            .Columns("TEN_LOAI_CV").Width = 150
            .Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With

        refresh_Language_CVC()
    End Sub

    Sub refresh_Language_CVC()
        With Me.grdCongviecchinh
            .Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
            .Columns("MO_TA_CV").ReadOnly = True
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            .Columns("SO_GIO_KH").ReadOnly = True
            .Columns("TEN_LOAI_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_LOAI_CV", Commons.Modules.TypeLanguage)
            .Columns("TEN_LOAI_CV").ReadOnly = True
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").ReadOnly = False
        End With
    End Sub

    Sub formatGrid_Congviecphu()
        Dim col As New Commons.QLGridMaskedTextBoxColumn()
        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY_HOAN_THANH"
        col.Mask = "00/00/0000"
        Me.grdCongviecphu.Columns.Insert(3, col)
        With Me.grdCongviecphu
            .Columns("STT").Visible = False
            .Columns("NGAY_HOAN_THANH").Visible = False
            .Columns("TEN_CONG_VIEC").Width = 300
            .Columns("SO_GIO_KH").Width = 90
            .Columns("cboNgay").Width = 80
            .Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_CVP()
    End Sub

    Sub refresh_Language_CVP()
        With Me.grdCongviecphu
            .Columns("TEN_CONG_VIEC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_VIEC", Commons.Modules.TypeLanguage)
            .Columns("TEN_CONG_VIEC").ReadOnly = True
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            .Columns("SO_GIO_KH").ReadOnly = True
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").ReadOnly = False
        End With
    End Sub

    Sub refresh_Language_KHCV()
        'With Me.grdKehoachcongviec
        '    .Columns("cboNgay_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY", commons.Modules.TypeLanguage)
        '    .Columns("cboTu_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TU_GIO", commons.Modules.TypeLanguage)
        '    .Columns("cboDen_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DEN_GIO", commons.Modules.TypeLanguage)
        '    .Columns("SO_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_GIO", commons.Modules.TypeLanguage)
        'End With
    End Sub

    Sub formatGrid_Kehoachnhanvien()
        loadcbo_CN()
        With Me.grdKehoachnhanvien
            .Columns("MS_CONG_NHAN").Visible = False
            .Columns("NGAY").Visible = False
            .Columns("TU_GIO").Visible = False
            .Columns("DEN_GIO").Visible = False
            .Columns("TU_GIO_TMP").Visible = False
            .Columns("DEN_GIO_TMP").Visible = False
            .Columns("NGAY_TMP").Visible = False
            .Columns("MS_CN").Visible = False
            .Columns("cbo_CN").Width = 100
            .Columns("TEN_CONG_NHAN").Width = 150
            .Columns("cboNgay").Width = 80
            .Columns("cboTu_gio").Width = 60
            .Columns("cboDen_gio").Width = 60

            .Columns("TU_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DEN_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_KHNV()
    End Sub

    Sub loadcbo_CN()
        Dim cbo_CN As New DataGridViewComboBoxColumn

        cbo_CN.Name = "cbo_CN"
        cbo_CN.ValueMember = "MS_CONG_NHAN"
        cbo_CN.DisplayMember = "MS_CONG_NHAN"
        cbo_CN.DataPropertyName = "MS_CONG_NHAN"
        cbo_CN.DataSource = New JOBCARD_Controller().Get_CONG_NHAN()
        Me.grdKehoachnhanvien.Columns.Insert(0, cbo_CN)

        Dim col As New Commons.QLGridMaskedTextBoxColumn()

        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY"
        col.Mask = "00/00/0000"
        Me.grdKehoachnhanvien.Columns.Insert(4, col)

        Dim col1 As New Commons.QLGridMaskedTextBoxColumn
        col1.Name = "cboTu_gio"
        col1.DataPropertyName = "TU_GIO"
        col1.Mask = "00:00"
        col1.DefaultCellStyle.Format = "HH:mm"
        col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grdKehoachnhanvien.Columns.Insert(5, col1)

        Dim col2 As New Commons.QLGridMaskedTextBoxColumn
        col2.Name = "cboDen_gio"
        col2.DataPropertyName = "DEN_GIO"
        col2.Mask = "00:00"
        col2.DefaultCellStyle.Format = "HH:mm"
        col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grdKehoachnhanvien.Columns.Insert(7, col2)
    End Sub

    Sub refresh_Language_KHNV()
        With Me.grdKehoachnhanvien
            .Columns("cbo_CN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cbo_CN", Commons.Modules.TypeLanguage)
            .Columns("TEN_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_NHAN", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            .Columns("cboTu_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            .Columns("cboDen_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
            .Columns("HOAN_THANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOAN_THANH", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub refresh_Language_Form()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.lblMS_ThietBi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblMS_ThietBi", Commons.Modules.TypeLanguage)
        Me.lblNhomthietbi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNhomthietbi", Commons.Modules.TypeLanguage)
        Me.lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTieude", Commons.Modules.TypeLanguage)
        Me.radCongviecchinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "radCongviecchinh", Commons.Modules.TypeLanguage)
        Me.radCongviecphutro.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "radCongviecphutro", Commons.Modules.TypeLanguage)
        Me.btnThemsua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnThemsua", Commons.Modules.TypeLanguage)
        Me.btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnGhi", Commons.Modules.TypeLanguage)
        Me.btnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnKhongghi", Commons.Modules.TypeLanguage)
        Me.btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnXoa", Commons.Modules.TypeLanguage)
        Me.btnIn.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnIn", Commons.Modules.TypeLanguage)
        Me.btnPhieubaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnPhieubaotri", Commons.Modules.TypeLanguage)
        Me.btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnThoat", Commons.Modules.TypeLanguage)
        Me.btnTinhcuasobaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnTinhcuasobaotri", Commons.Modules.TypeLanguage)
        Me.btnCapnhatgioNV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCapnhatgioNV", Commons.Modules.TypeLanguage)
        Me.btnCapnhatthoigiancongviec.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCapnhatthoigiancongviec", Commons.Modules.TypeLanguage)

        Me.grpCongviecchinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCongviecchinh", Commons.Modules.TypeLanguage)
        Me.grpCongviecphu.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCongviecphu", Commons.Modules.TypeLanguage)
        Me.grpCuasobaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCuasobaotri", Commons.Modules.TypeLanguage)
        Me.grpDanhsachphieubaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpDanhsachphieubaotri", Commons.Modules.TypeLanguage)
        Me.tabBaocao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "tabBaocao", Commons.Modules.TypeLanguage)
        'Me.tabCongviec.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "tabCongviec", commons.Modules.TypeLanguage)
        Me.tabNhanvien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "tabNhanvien", Commons.Modules.TypeLanguage)

        Me.lblDanhsachbaocao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblDanhsachbaocao", Commons.Modules.TypeLanguage)

        Me.lblTungay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTungay", Commons.Modules.TypeLanguage)
        Me.lblDenngay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblDenngay", Commons.Modules.TypeLanguage)
        Me.lblTo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTo", Commons.Modules.TypeLanguage)
        Me.lblNhanvien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNhanvien", Commons.Modules.TypeLanguage)
        Me.lblTonggio.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTonggio", Commons.Modules.TypeLanguage)
    End Sub
#End Region
    Private intRowCN As Integer = 0
    Dim cboCN As ComboBox
    Private Sub grdKehoachnhanvien_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdKehoachnhanvien.EditingControlShowing
        If Me.grdKehoachnhanvien.CurrentCellAddress.X = 0 Then
            cboCN = e.Control

            'Try
            '    RemoveHandler cboCN.SelectionChangeCommitted, AddressOf Me.cboCN_SelectedIndexChanged
            'Catch ex As Exception

            'End Try

            RemoveHandler cboCN.SelectionChangeCommitted, AddressOf Me.cboCN_SelectedIndexChanged
            AddHandler cboCN.SelectionChangeCommitted, AddressOf Me.cboCN_SelectedIndexChanged

        End If
    End Sub
    Private Sub grdKehoachnhanvien_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKehoachnhanvien.RowEnter
        intRowCN = e.RowIndex
    End Sub

    Private Sub grdKehoachnhanvien_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdKehoachnhanvien.RowValidating
        If btnKhongghi.Focused() Then
            Exit Sub
        End If
        If btnCapnhatthoigiancongviec.Focused() Then
            Exit Sub
        End If
        If btnGhi.Visible Then
            If e.RowIndex < grdKehoachnhanvien.Rows.Count - 1 Then
                If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value <> Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value Then
                    If Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value) >= Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioNhoHonTuGio", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio")
                        Me.grdKehoachnhanvien.Focus()
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value And Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value <> "00:00" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioNhoHonTuGio", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio")
                        Me.grdKehoachnhanvien.Focus()
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                Dim str As String = ""
                str = "DELETE FROM tmpJOB_CARD" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                For i As Integer = 0 To grdKehoachnhanvien.Rows.Count - 2
                    If Not grdKehoachnhanvien.Rows(i).Cells("cbo_CN").Value Is Nothing Then
                        str = "INSERT INTO tmpJOB_CARD" & Commons.Modules.UserName & " (MS_CONG_NHAN,TU_GIO,TU_NGAY,DEN_GIO,DONG) VALUES(N'" & _
                        grdKehoachnhanvien.Rows(i).Cells("cbo_CN").Value & "',N'" & grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value & "',N'" & _
                        grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value & "',N'" & grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value & "'," & i & ")"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    End If
                Next
                Dim tb As New DataTable()
                str = "SELECT MS_CONG_NHAN,CONVERT(DATETIME,TU_GIO,114)AS TU_GIO,CONVERT(DATETIME,TU_NGAY,103) AS TU_NGAY,CONVERT (DATETIME,DEN_GIO,114)AS DEN_GIO,DONG FROM  tmpJOB_CARD" & Commons.Modules.UserName & " ORDER BY TU_NGAY,TU_GIO"
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
                For i As Integer = 0 To tb.Rows.Count - 2
                    For j As Integer = i + 1 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("MS_CONG_NHAN") = tb.Rows(j).Item("MS_CONG_NHAN") Then
                            If Date.Parse(Format(tb.Rows(j).Item("TU_NGAY"), "Short date") + " " + Format(tb.Rows(j).Item("TU_GIO"), "Long time")) < Date.Parse(Format(tb.Rows(i).Item("TU_NGAY"), "Short date") + " " + Format(tb.Rows(i).Item("DEN_GIO"), "Long time")) Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGian", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                'XtraMessageBox.Show("Nhân viên này đã được phân công trong khoảng thời gian này. Vui lòng nhập lại khoảng thời gian khác")
                                grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio")
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private intRowCuaBT As Integer = 0
    Private Sub grdCuasobaotri_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCuasobaotri.RowEnter
        intRowCuaBT = e.RowIndex
    End Sub

    Private Sub btnCapnhatthoigiancongviec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhatthoigiancongviec.Click
        If btnGhi.Visible Then
            For i As Integer = 0 To grdKehoachnhanvien.Rows.Count - 2
                If i <> intRowCN Then
                    If grdKehoachnhanvien.Rows(intRowCN).Cells("cbo_CN").Value = grdKehoachnhanvien.Rows(i).Cells("cbo_CN").Value Then
                        If Format(grdCuasobaotri.Rows(intRowCuaBT).Cells("NGAY").Value, "Short date") = Format(grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value, "Short date") And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("FROM_HOUR").Value Then
                            'XtraMessageBox.Show("Không thể cập nhật thời gian này vì đã tồn tại. Vui lòng chọn thời gian khác")
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGian1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            grdKehoachnhanvien.Rows(intRowCN).Cells("cboDen_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("TO_HOUR").Value
            grdKehoachnhanvien.Rows(intRowCN).Cells("cboTu_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("FROM_HOUR").Value
            grdKehoachnhanvien.Rows(intRowCN).Cells("cboNgay").Value = Format(grdCuasobaotri.Rows(intRowCuaBT).Cells("NGAY").Value, "Short date")

        End If
    End Sub
    Private Sub cboCN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(cboCN.Text) Then Exit Sub
        If cboCN.Text = "" Then Exit Sub
        Try
            Me.grdKehoachnhanvien.CurrentRow.Cells("cbo_CN").Value = cboCN.SelectedValue
            Dim str As String = ""
            str = "SELECT HO+' '+TEN AS HO_TEN FROM CONG_NHAN WHERE MS_CONG_NHAN='" & cboCN.SelectedValue & "'"
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                Me.grdKehoachnhanvien.CurrentRow.Cells("TEN_CONG_NHAN").Value = objReader.Item("HO_TEN").ToString
            End While
            objReader.Close()

        Catch ex As Exception

        End Try

    End Sub



    Private Sub RefeshLanguageReport()
        Dim str As String = ""
        Try
            str = "drop table rptTieuDeJobCard"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "STT", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", " CongViec", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim NgayPV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Ngay", Commons.Modules.TypeLanguage)
        Dim TuGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TuGio", Commons.Modules.TypeLanguage)
        Dim DenGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "DenGio", Commons.Modules.TypeLanguage)
        Dim ThoiGianLv As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "ThoiGianLV", Commons.Modules.TypeLanguage)
        Dim Vict_TG As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Vict_TG", Commons.Modules.TypeLanguage)
        Dim Vendor_TG As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Vendor_TG", Commons.Modules.TypeLanguage)
        Dim CongNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "NhanCong", Commons.Modules.TypeLanguage)
        Dim Remark As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Remark", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Tong", Commons.Modules.TypeLanguage)
        Dim TenTo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TenTo", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblTungay.Text + " " + Format(dtpTuNgay.Value, "Short date") + " " + lblDenngay.Text + " " + Format(dtpDenNgay.Value, "Short date")
        str = "Create table dbo.rptTieuDeJobCard(TypeLanguage int,NgayIn nvarchar(50),TrangIn nvarchar(50),TieuDe nvarchar(255),DieuKienLoc nvarchar(255)," & _
        " TenTo nvarchar(50),PhieuBaoTri nvarchar(30),STT nvarchar(5),CongViec nvarchar(50),ThoiGian nvarchar(30),NgayPC nvarchar(30),TuGio nvarchar(30), " & _
        " DenGio nvarchar(30),ThoiGianLV nvarchar(50), Vict_TG nvarchar(30),Vendor_TG nvarchar(30),CongNhan nvarchar(50),Remark nvarchar(20),Tong nvarchar(20)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "INSERT INTO dbo.rptTieuDeJobCard values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & DieuKienLoc & "',N'" & TenTo & _
        "',N'" & PhieuBaoTri & "',N'" & STT & "',N'" & CongViec & "',N'" & ThoiGian & "',N'" & NgayPV & "',N'" & TuGio & "',N'" & DenGio & "',N'" & _
        ThoiGianLv & "',N'" & Vict_TG & "',N'" & Vendor_TG & "',N'" & CongNhan & "',N'" & Remark & "',N'" & Tong & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub
    Sub CreateData()
        If cboNhanVien.Text = "" Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        RefeshLanguageReport()
        Dim str As String = ""
        Try
            str = "drop table rptJOB_CARD"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT CONG_NHAN.MS_TO,[TO].TEN_TO, PBT.MS_PHIEU_BAO_TRI,MO_TA_CV,PBT3.NGAY,PBT3.TU_GIO,PBT3.DEN_GIO,PBT3.MS_CONG_NHAN+'_'+HO+' '+TEN AS HO_TEN " & _
        " ,case  DON_VI.THUE_NGOAI when 1 then CONVERT(FLOAT,DATEDIFF(MINUTE,TU_GIO,DEN_GIO))/60 else null end AS VICT  " & _
        " ,case  DON_VI.THUE_NGOAI when 0 then CONVERT(FLOAT,DATEDIFF(MINUTE,TU_GIO,DEN_GIO))/60 else null end AS VENDOR  " & _
        " INTO DBO.rptJOB_CARD  " & _
        " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET PBT3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU PBT2 ON  " & _
        " PBT3.MS_PHIEU_BAO_TRI = PBT2.MS_PHIEU_BAO_TRI AND PBT3.MS_CV = PBT2.MS_CV AND  " & _
        " PBT3.MS_BO_PHAN = PBT2.MS_BO_PHAN AND PBT3.MS_CONG_NHAN = PBT2.MS_CONG_NHAN INNER JOIN " & _
        " PHIEU_BAO_TRI_CONG_VIEC PBT1 ON PBT2.MS_PHIEU_BAO_TRI = PBT1.MS_PHIEU_BAO_TRI AND  " & _
        " PBT2.MS_CV = PBT1.MS_CV AND PBT2.MS_BO_PHAN = PBT1.MS_BO_PHAN INNER JOIN " & _
        " PHIEU_BAO_TRI PBT ON PBT1.MS_PHIEU_BAO_TRI = PBT.MS_PHIEU_BAO_TRI INNER JOIN CONG_NHAN ON PBT3.MS_CONG_NHAN = CONG_NHAN.MS_CONG_NHAN INNER JOIN " & _
        " [TO] ON CONG_NHAN.MS_TO = [TO].MS_TO1 INNER JOIN TO_PHONG_BAN ON [TO].MS_TO = TO_PHONG_BAN.MS_TO INNER JOIN " & _
        " DON_VI ON TO_PHONG_BAN.MS_DON_VI = DON_VI.MS_DON_VI INNER JOIN CONG_VIEC ON PBT1.MS_CV=CONG_VIEC.MS_CV INNER JOIN LOAI_CONG_VIEC  " & _
        " ON CONG_VIEC.MS_LOAI_CV =LOAI_CONG_VIEC.MS_LOAI_CV INNER JOIN NHOM_LOAI_CONG_VIEC " & _
        " ON LOAI_CONG_VIEC.MS_LOAI_CV=NHOM_LOAI_CONG_VIEC.MS_LOAI_CV INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_CONG_VIEC.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'" & _
        " AND PBT3.NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) and convert(datetime,'" & Format(dtpDenNgay.Value, "Short date") & "',103)"
        If cboNhanVien.SelectedValue <> "-1" Then
            str = str + " AND PBT3.MS_CONG_NHAN='" & cboNhanVien.SelectedValue & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Commons.mdShowReport.ReportPreview("reports/rptDAILY_SUMMARY_DMS.rpt")
        Me.Cursor = Cursors.Default
        Try
            str = "drop table rptJOB_CARD"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "drop table rptTieuDeJobCard"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadCboNhanVien()
        If cboTo.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MS_CONG_NHAN,HO+''+ TEN AS HOTEN FROM CONG_NHAN where MS_TO=" & cboTo.SelectedValue
        cboNhanVien.Display = "HOTEN"
        cboNhanVien.Value = "MS_CONG_NHAN"
        cboNhanVien.Param = str
        cboNhanVien.StoreName = "QL_SEARCH"
        cboNhanVien.BindDataSource()
        If cboNhanVien.Items.Count = 0 Then
            cboNhanVien.Text = ""
        End If
    End Sub

    Private Sub loadCboTo()
        Dim dt, dtLast As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM [TO]"))
        cboTo.DataSource = dt
        cboTo.DisplayMember = "TEN_TO"
        cboTo.ValueMember = "MS_TO1"
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        CreateData()

    End Sub

    Private Sub cboTo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTo.SelectionChangeCommitted
        loadCboNhanVien()
    End Sub
End Class