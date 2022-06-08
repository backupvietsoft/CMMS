
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Convert
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons

Public Class FrmChonTaiLieu
    Private _MS_MAY As String
    Private intRowNSD As Integer = 0, intRowGSTT As Integer = 0
    Private bCo As Boolean = True, bCo1 As Boolean = True
    Private intRowYC As Integer = 0, intRowGS As Integer = 0


    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

    Private Sub FrmChonTaiLieu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Commons.Modules.ObjSystems.DinhDang()
        dtTungay_nsd.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 14)
        dtTungay_gstt.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 14)
        BindData()
        BindData1()
        RefeshLanguage()
    End Sub

    Sub BindData()
        grdDanhsachtailieunsd.DataSource = System.DBNull.Value
        grdDanhsachyeucau.DataSource = New clsCHON_CONG_VIEC_CHO_PBTController().GetYEU_CAU_NSD_Cho_PBTs(Format(dtTungay_nsd.Value, "Short date"), Format(dtDenngay_nsd.Value, "Short date"), MS_MAY)
        grdDanhsachyeucau.Columns("MS_MAY").Visible = False
        grdDanhsachyeucau.Columns("STT_VAN_DE").Visible = False
        Try
            Me.grdDanhsachyeucau.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachyeucau.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub BindData1()
        grdDanhsachtailieugiamsat.DataSource = System.DBNull.Value
        grdDanhsachgiamsattinhtrang.DataSource = New clsCHON_CONG_VIEC_CHO_PBTController().GetGIAM_SAT_TINH_TRANG_Cho_PBTs(Format(dtTungay_gstt.Value, "Short date"), Format(dtDenngay_gstt.Value, "Short date"), MS_MAY)
        grdDanhsachgiamsattinhtrang.Columns("MS_MAY").Visible = False
        Try
            Me.grdDanhsachgiamsattinhtrang.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachgiamsattinhtrang.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguage()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Me.grdDanhsachyeucau.Columns("NGUOI_YEU_CAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_YEU_CAU", Commons.Modules.TypeLanguage)
        Me.grdDanhsachyeucau.Columns("STT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "STT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachyeucau.Columns("MO_TA_TINH_TRANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_TINH_TRANG", Commons.Modules.TypeLanguage)
        Me.grdDanhsachgiamsattinhtrang.Columns("STT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "STT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachgiamsattinhtrang.Columns("HO_TEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HO_TEN", Commons.Modules.TypeLanguage)
        Me.grdDanhsachgiamsattinhtrang.Columns("MS_TS_GSTT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_TS_GSTT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachgiamsattinhtrang.Columns("KET_QUA_GS").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KET_QUA_GS", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub RefeshLanguage1()
        Me.grdDanhsachtailieunsd.Columns("DUONG_DAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DUONG_DAN", Commons.Modules.TypeLanguage)
        Me.grdDanhsachtailieunsd.Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
        Me.grdDanhsachtailieunsd.Columns("CHON").Width = 60
    End Sub

    Private Sub RefeshLanguage2()
        Me.grdDanhsachtailieugiamsat.Columns("DUONG_DAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DUONG_DAN", Commons.Modules.TypeLanguage)

        Me.grdDanhsachtailieugiamsat.Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
        Me.grdDanhsachtailieugiamsat.Columns("CHON").Width = 60
    End Sub

    Sub CreatechkGiatri()
        Dim chkGiatri As New DataGridViewCheckBoxColumn()
        chkGiatri.Name = "CHON"
        grdDanhsachtailieunsd.Columns.Insert(0, chkGiatri)
    End Sub

    Sub CreatechkGiatri1()
        Dim chkGiatri As New DataGridViewCheckBoxColumn()
        chkGiatri.Name = "CHON"
        grdDanhsachtailieugiamsat.Columns.Insert(0, chkGiatri)
    End Sub

    Sub ShowData()
        grdDanhsachtailieunsd.DataSource = New clsChonTaiLieuChoEORController().GetYEU_CAU_NSD_CHI_TIET_HINHs_EOR(grdDanhsachyeucau.Rows(intRowNSD).Cells("STT").Value, grdDanhsachyeucau.Rows(intRowNSD).Cells("MS_MAY").Value, grdDanhsachyeucau.Rows(intRowNSD).Cells("STT_VAN_DE").Value)
        grdDanhsachtailieunsd.Columns("STT_HINH").Visible = False
        If bCo Then
            CreatechkGiatri()
            bCo = False
        End If
        Dim str As String = ""
        Dim tb As New DataTable()
        str = "SELECT STT_YC_NSD AS STT_HINH FROM TAM12" & Commons.Modules.UserName & " WHERE STT_YC_NSD>0"
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tb.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachtailieunsd.Rows.Count - 1
                If grdDanhsachtailieunsd.Rows(j).Cells("STT_HINH").Value = tb.Rows(i).Item("STT_HINH") Then
                    grdDanhsachtailieunsd.Rows(j).Cells("CHON").Value = True
                    Exit For
                End If
            Next
        Next
        Try
            Me.grdDanhsachtailieunsd.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachtailieunsd.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        RefeshLanguage1()
    End Sub

    Sub ShowData1()
        grdDanhsachtailieugiamsat.DataSource = New clsChonTaiLieuChoEORController().GetGIAM_SAT_TINH_TRANG_HINHs_EOR(grdDanhsachgiamsattinhtrang.Rows(intRowGSTT).Cells("STT").Value, grdDanhsachgiamsattinhtrang.Rows(intRowGSTT).Cells("MS_MAY").Value, grdDanhsachgiamsattinhtrang.Rows(intRowGSTT).Cells("MS_TS_GSTT").Value)
        grdDanhsachtailieugiamsat.Columns("STT_HINH").Visible = False
        If bCo1 Then
            CreatechkGiatri1()
            bCo1 = False
        End If
        Dim str As String = ""
        Dim tb As New DataTable()
        str = "SELECT STT_GSTT AS STT_HINH FROM TAM12" & Commons.Modules.UserName & " WHERE  STT_GSTT>0"
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tb.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachtailieugiamsat.Rows.Count - 1
                If grdDanhsachtailieugiamsat.Rows(j).Cells("STT_HINH").Value = tb.Rows(i).Item("STT_HINH") Then
                    grdDanhsachtailieugiamsat.Rows(j).Cells("CHON").Value = True
                    Exit For
                End If
            Next
        Next
        Try
            Me.grdDanhsachtailieugiamsat.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachtailieugiamsat.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        RefeshLanguage2()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachgiamsattinhtrang_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachgiamsattinhtrang.RowEnter
        intRowGSTT = e.RowIndex
        ShowData1()
    End Sub

    Private Sub grdDanhsachgiamsattinhtrang_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachgiamsattinhtrang.RowHeaderMouseClick
        intRowGSTT = e.RowIndex
        ShowData1()
    End Sub

    Private Sub grdDanhsachyeucau_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachyeucau.RowEnter
        intRowNSD = e.RowIndex
        ShowData()
    End Sub

    Private Sub grdDanhsachyeucau_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachyeucau.RowHeaderMouseClick
        intRowNSD = e.RowIndex
        ShowData()
    End Sub

    Private Sub BtnThoat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat2.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachtailieunsd_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachtailieunsd.CellEndEdit
        If e.ColumnIndex = 0 Then
            Dim str As String = ""
            If grdDanhsachtailieunsd.Rows(e.RowIndex).Cells("CHON").Value Then
                str = "INSERT INTO TAM12" & Commons.Modules.UserName & " (DUONG_DAN,STT_YC_NSD,STT_GSTT ) VALUES(N'" & grdDanhsachtailieunsd.Rows(e.RowIndex).Cells("DUONG_DAN").Value & "'," & grdDanhsachtailieunsd.Rows(e.RowIndex).Cells("STT_HINH").Value & "," & 0 & ")"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Exit Sub
            Else
                str = "DELETE FROM TAM12" & Commons.Modules.UserName & " WHERE STT_YC_NSD=" & grdDanhsachtailieunsd.Rows(intRowNSD).Cells("STT_HINH").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub grdDanhsachtailieugiamsat_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachtailieugiamsat.CellEndEdit
        If e.ColumnIndex = 0 Then
            Dim str As String = ""
            If grdDanhsachtailieugiamsat.Rows(e.RowIndex).Cells("CHON").Value Then
                str = "INSERT INTO TAM12" & Commons.Modules.UserName & " (DUONG_DAN,STT_GSTT,STT_YC_NSD) VALUES(N'" & grdDanhsachtailieugiamsat.Rows(e.RowIndex).Cells("DUONG_DAN").Value & "'," & grdDanhsachtailieugiamsat.Rows(e.RowIndex).Cells("STT_HINH").Value & "," & 0 & ")"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Exit Sub
            Else
                str = "DELETE FROM TAM12" & Commons.Modules.UserName & " WHERE STT_GSTT=" & grdDanhsachtailieugiamsat.Rows(intRowNSD).Cells("STT_HINH").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnThuchien2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThuchien2.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnXemTL1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemTL1.Click
        If grdDanhsachtailieunsd.Rows.Count = 0 Then
            Exit Sub
        End If
        Try
            System.Diagnostics.Process.Start(grdDanhsachtailieunsd.Rows(intRowYC).Cells("DUONG_DAN").Value)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
        End Try
    End Sub

    Private Sub grdDanhsachtailieunsd_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachtailieunsd.RowEnter
        intRowYC = e.RowIndex
    End Sub

    Private Sub grdDanhsachtailieunsd_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachtailieunsd.RowHeaderMouseClick
        intRowYC = e.RowIndex
    End Sub

    Private Sub grdDanhsachtailieugiamsat_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachtailieugiamsat.RowEnter
        intRowGS = e.RowIndex
    End Sub

    Private Sub grdDanhsachtailieugiamsat_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachtailieugiamsat.RowHeaderMouseClick
        intRowGS = e.RowIndex
    End Sub

    Private Sub BtnXemTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemTL.Click
        If grdDanhsachtailieugiamsat.Rows.Count = 0 Then
            Exit Sub
        End If
        Try
            System.Diagnostics.Process.Start(grdDanhsachtailieugiamsat.Rows(intRowGS).Cells("DUONG_DAN").Value)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
        End Try
    End Sub

    Private Sub dtTungay_nsd_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtTungay_nsd.CloseUp
        BindData()
    End Sub

    Private Sub dtDenngay_nsd_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDenngay_nsd.CloseUp
        BindData()
    End Sub

    Private Sub dtDenngay_gstt_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDenngay_gstt.CloseUp
        BindData1()
    End Sub

    Private Sub dtTungay_gstt_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtTungay_gstt.CloseUp
        BindData1()
    End Sub


End Class