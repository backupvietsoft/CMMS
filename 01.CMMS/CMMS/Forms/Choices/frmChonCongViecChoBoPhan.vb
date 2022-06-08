
Imports Commons.VS.Classes.Catalogue

Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Public Class frmChonCongViecChoBoPhan

    Private intRow As Integer = 0
    Private _MS_MAY As String

    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property
    Private Sub frmChonCongViecChoBoPhan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindData()
        lblThietBi.Text = MS_MAY
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Dim str As String = ""
        str = "select distinct MS_BO_PHAN FROM TMP_CONG_VIEC" & Commons.Modules.UserName & " WHERE (SELECT COUNT(*)  FROM TMP_MAY_BO_PHAN" & Commons.Modules.UserName & _
        " WHERE CHON=1 and TMP_MAY_BO_PHAN" & Commons.Modules.UserName & ".MS_BO_PHAN=TMP_CONG_VIEC" & Commons.Modules.UserName & ".MS_BO_PHAN)=0"
        Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tmp As Boolean = False
        While objRead.Read
            If objRead.Item("MS_BO_PHAN").ToString <> "" Then
                tmp = True
            End If
        End While
        objRead.Close()
        If tmp Then
            'Bạn chưa chọn công việc thực hiện cho bộ phận di chuyển.Nhấn Yes để đồng ý phân bổ công việc mặc định cho bộ phân di chuyển. Nhấn No đề trở lại phân bổ công việc.
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "msgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            Else
                Me.Close()
            End If
        Else
            'hỏi người dùng đã thật sự phân bố công việc cho các bộ phận chưa.Nhấn Yes để xác nhận đồng ý, Nhấn No để trở lại phân bố tiếp công việc
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "msgKT2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            Else
                Me.Close()
            End If
        End If

    End Sub

    Private Sub grdDanhsachmaybophan_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsachmaybophan.CellValidating

        If grdDanhsachmaybophan.Columns(e.ColumnIndex).Name = "CHON" Then
            Dim cell As DataGridViewCell = Me.grdDanhsachmaybophan.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                Dim str As String = ""
                If e.FormattedValue Then
                    Dim tmp As Integer = 0
                    For i As Integer = 0 To grdDanhsachmaybophan.Rows.Count - 1
                        If grdDanhsachmaybophan.Rows(i).Cells("CHON").Value And i <> e.RowIndex Then
                            tmp = tmp + 1
                            Exit For
                        End If
                    Next
                    If tmp > 0 Then
                        'XtraMessageBox.Show("Chỉ chọn duy nhất một máy và bộ phận tương ứng với công việc này.Nếu muốn chọn máy và bộ phận này thì phải bỏ máy và bộ phận đã chọn trước đó.")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChon", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    End If
                    str = "UPDATE TMP_MAY_BO_PHAN" & Commons.Modules.UserName & " SET CHON=1 , MS_CV=" & grvDSCongViec.Rows(intRow).Cells("MS_CV").Value & " WHERE MS_BO_PHAN='" & grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_MAY_TT=N'" & _
                    grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_MAY_TT").Value & "' AND MS_BO_PHAN_TT='" & grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_BO_PHAN_TT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Else
                    str = "UPDATE TMP_MAY_BO_PHAN" & Commons.Modules.UserName & " SET CHON=0 , MS_CV=NULL WHERE MS_BO_PHAN='" & grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_MAY_TT=N'" & _
                    grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_MAY_TT").Value & "' AND MS_BO_PHAN_TT='" & grdDanhsachmaybophan.Rows(e.RowIndex).Cells("MS_BO_PHAN_TT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            End If
        End If
    End Sub
    Sub BindData()
        Dim str As String = ""
        Dim tbCV As New DataTable()
        Dim tbBP As New DataTable()
        str = "SELECT DISTINCT TMP_CONG_VIEC" & Commons.Modules.UserName & ".MS_BO_PHAN,TEN_BO_PHAN,MS_CV,MO_TA_CV FROM TMP_CONG_VIEC" & Commons.Modules.UserName & " INNER join PHIEU_BAO_TRI_DI_CHUYEN_BP ON TMP_CONG_VIEC" & Commons.Modules.UserName & ".MS_BO_PHAN=PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_BO_PHAN "
        tbCV = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grvDSCongViec.DataSource = tbCV
        grvDSCongViec.Columns("MS_BO_PHAN").Visible = False
        grvDSCongViec.Columns("MS_CV").Visible = False
        grvDSCongViec.Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", commons.Modules.TypeLanguage)
        grvDSCongViec.Columns("TEN_BO_PHAN").Width = 128
        grvDSCongViec.Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MO_TA_CV", commons.Modules.TypeLanguage)
        grvDSCongViec.Columns("MO_TA_CV").Width = 130
        Try
            Me.grvDSCongViec.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grvDSCongViec.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub ShowData(ByVal intRow As Integer)
        Dim str As String = ""
        Dim tbBP As New DataTable()
        str = "SELECT * FROM TMP_MAY_BO_PHAN" & Commons.Modules.UserName & " WHERE MS_BO_PHAN='" & grvDSCongViec.Rows(intRow).Cells("MS_BO_PHAN").Value & "'"
        tbBP = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grdDanhsachmaybophan.DataSource = tbBP
        grdDanhsachmaybophan.ReadOnly = False
        grdDanhsachmaybophan.Columns("TEN_BO_PHAN_THAY_THE").ReadOnly = True
        grdDanhsachmaybophan.Columns("MS_MAY_TT").ReadOnly = True
        grdDanhsachmaybophan.Columns("MS_MAY").Visible = False
        grdDanhsachmaybophan.Columns("MS_BO_PHAN").Visible = False
        grdDanhsachmaybophan.Columns("MS_BO_PHAN_TT").Visible = False
        grdDanhsachmaybophan.Columns("TEN_BO_PHAN").Visible = False
        grdDanhsachmaybophan.Columns("MS_CV").Visible = False
        grdDanhsachmaybophan.Columns("MS_MAY_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY_TT", commons.Modules.TypeLanguage)
        grdDanhsachmaybophan.Columns("MS_MAY_TT").Width = 100
        grdDanhsachmaybophan.Columns("TEN_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN_TT", commons.Modules.TypeLanguage)
        grdDanhsachmaybophan.Columns("TEN_BO_PHAN_THAY_THE").Width = 200
        grdDanhsachmaybophan.Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
        grdDanhsachmaybophan.Columns("CHON").Width = 50
        Try
            Me.grdDanhsachmaybophan.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachmaybophan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grvDSCongViec_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvDSCongViec.RowEnter
        intRow = e.RowIndex
        ShowData(e.RowIndex)
    End Sub
End Class