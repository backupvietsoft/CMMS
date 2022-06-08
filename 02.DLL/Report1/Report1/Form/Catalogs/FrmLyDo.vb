Imports Commons.VS.Classes.Admin
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class FrmLyDo
#Region " Member "
    Private obj_LY_DO_Controller As New cls_LY_DO_SUA_CHUA_Controller
    Private obj_LY_DO_Info As New cls_LY_DO_SUA_CHUA_Info
    Private bln_them As Boolean = False
#End Region

#Region " Events "
    Private Sub FrmLyDo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        refresh_Control()
        visible_Button(True)
        lock_Control(True)

        bind_Data()
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem.Enabled = False
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        End If


    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        bln_them = True
        refresh_Control()
        Me.txtTEN_BP_GSTT_TV.Focus()
        visible_Button(False)
        lock_Control(False)

    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        visible_Button(False)
        Me.txtTEN_BP_GSTT_TV.SelectAll()
        lock_Control(False)

    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa01", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim sql_str As String = ""
        Dim dtReader As SqlDataReader

        ' Kiểm tra lý do sửa chữa đang xóa có đang được sử dụng trong Kế hoạch tổng thể không?
        sql_str = "select * from KE_HOACH_TONG_THE where LY_DO_SC = '" & Me.Txt_STT.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_str)
        While dtReader.Read
            ' Lý do sửa chửa này đang được sử dụng trong Kế hoạch tổng thể, bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa02", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        ' Kiểm tra lý do sửa chữa đang xóa có đang được sử dụng trong EOR không ?
        sql_str = "select * from EOR_LY_DO_SUA_CHUA where MS_LY_DO = '" & Me.Txt_STT.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_str)
        While dtReader.Read
            ' Lý do sửa chữa này đang được sử dụng trong EOR, bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa03", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        delete_Data()
        refresh_Control()
        bind_Data()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click

        If Me.txtTEN_BP_GSTT_TV.Text.ToString = "" Then
            ' Tên Lý do sửa chữa không được rỗng, bạn vui lòng nhập lý do sửa chữa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGhi01", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Me.txtTEN_BP_GSTT_TV.Focus()
            Exit Sub
        End If

        Dim str_tmp As String = Me.txtTEN_BP_GSTT_TV.Text.ToString
        If bln_them Then
            add_Data()
        Else
            update_Data()
        End If

        bind_Data()
        visible_Button(True)
        lock_Control(True)

        For i As Integer = 0 To Me.GrdDanhsachlydosuachua.RowCount - 1
            If Me.GrdDanhsachlydosuachua.Rows(i).Cells("TEN_LY_DO_VIET").Value.ToString = str_tmp Then
                Me.GrdDanhsachlydosuachua.Rows(i).Cells("TEN_LY_DO_VIET").Selected = True
                Exit For
            End If
        Next

        bln_them = False
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        refresh_Control()

        If Me.GrdDanhsachlydosuachua.RowCount > 0 Then
            show_Data(Me.GrdDanhsachlydosuachua.CurrentRow.Cells("MS_LY_DO").RowIndex)
        End If
        visible_Button(True)
        lock_Control(True)
        bln_them = False
    End Sub

    Private Sub GrdDanhsachlydosuachua_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachlydosuachua.RowEnter
        show_Data(e.RowIndex)
    End Sub

    Private Sub GrdDanhsachlydosuachua_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachlydosuachua.RowHeaderMouseClick
        show_Data(e.RowIndex)
    End Sub
#End Region

#Region " Methods "
    Sub refresh_Control()
        Me.Txt_STT.Text = ""
        Me.txtTEN_BP_GSTT_TA.Text = ""
        Me.txtTEN_BP_GSTT_TH.Text = ""
        Me.txtTEN_BP_GSTT_TV.Text = ""
    End Sub

    Sub visible_Button(ByVal flag As Boolean)
        Me.BtnThem.Visible = flag
        Me.BtnSua.Visible = flag
        Me.BtnXoa.Visible = flag
        Me.BtnThoat.Visible = flag

        Me.BtnGhi.Visible = Not flag
        Me.BtnKhongghi.Visible = Not flag
    End Sub

    Sub lock_Control(ByVal flag As Boolean)
        Me.txtTEN_BP_GSTT_TV.ReadOnly = flag
        Me.txtTEN_BP_GSTT_TA.ReadOnly = flag
        Me.txtTEN_BP_GSTT_TH.ReadOnly = flag

        Me.GrdDanhsachlydosuachua.Enabled = flag
    End Sub

    Sub bind_Data()
        Me.GrdDanhsachlydosuachua.DataSource = System.DBNull.Value
        Me.GrdDanhsachlydosuachua.Columns.Clear()
        Me.GrdDanhsachlydosuachua.DataSource = obj_LY_DO_Controller.Get_LY_DO()
        If Me.GrdDanhsachlydosuachua.RowCount = 0 Then
            Me.BtnSua.Enabled = False
            Me.BtnXoa.Enabled = False
        Else
            Me.BtnSua.Enabled = True
            Me.BtnXoa.Enabled = True
            Me.GrdDanhsachlydosuachua.Rows(0).Cells("TEN_LY_DO_VIET").Selected = True
        End If

        format_grid()
    End Sub

    Sub show_Data(ByVal row_index As Integer)
        Me.Txt_STT.Text = Me.GrdDanhsachlydosuachua.Rows(row_index).Cells("MS_LY_DO").Value.ToString
        Me.txtTEN_BP_GSTT_TV.Text = Me.GrdDanhsachlydosuachua.Rows(row_index).Cells("TEN_LY_DO_VIET").Value.ToString
        Me.txtTEN_BP_GSTT_TA.Text = Me.GrdDanhsachlydosuachua.Rows(row_index).Cells("TEN_LY_DO_ANH").Value.ToString
        Me.txtTEN_BP_GSTT_TH.Text = Me.GrdDanhsachlydosuachua.Rows(row_index).Cells("TEN_LY_DO_HOA").Value.ToString
    End Sub

    Sub format_grid()
        With Me.GrdDanhsachlydosuachua
            Try
                .Columns("MS_LY_DO").Visible = False
                .Columns("TEN_LY_DO_VIET").Width = 250
                .Columns("TEN_LY_DO_ANH").Width = 250
                .Columns("TEN_LY_DO_HOA").Width = 250

                .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception

            End Try
        End With
        refresh_language()
    End Sub

    Sub refresh_language()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Me.GrdDanhsachlydosuachua.Columns("TEN_LY_DO_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LY_DO_VIET", commons.Modules.TypeLanguage)
        Me.GrdDanhsachlydosuachua.Columns("TEN_LY_DO_ANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LY_DO_ANH", commons.Modules.TypeLanguage)
        Me.GrdDanhsachlydosuachua.Columns("TEN_LY_DO_HOA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LY_DO_HOA", commons.Modules.TypeLanguage)
    End Sub

    Sub add_Data()
        obj_LY_DO_Info.TEN_LY_DO_VIET = Me.txtTEN_BP_GSTT_TV.Text
        obj_LY_DO_Info.TEN_LY_DO_ANH = Me.txtTEN_BP_GSTT_TA.Text
        obj_LY_DO_Info.TEN_LY_DO_HOA = Me.txtTEN_BP_GSTT_TH.Text

        obj_LY_DO_Controller.add_LY_DO(obj_LY_DO_Info)
    End Sub

    Sub update_Data()
        obj_LY_DO_Info.STT = Me.Txt_STT.Text
        obj_LY_DO_Info.TEN_LY_DO_VIET = Me.txtTEN_BP_GSTT_TV.Text
        obj_LY_DO_Info.TEN_LY_DO_ANH = Me.txtTEN_BP_GSTT_TA.Text
        obj_LY_DO_Info.TEN_LY_DO_HOA = Me.txtTEN_BP_GSTT_TH.Text

        obj_LY_DO_Controller.update_LY_DO(obj_LY_DO_Info)
    End Sub

    Sub delete_Data()
        obj_LY_DO_Controller.delete_LY_DO(Integer.Parse(Me.Txt_STT.Text))
    End Sub

#End Region
End Class