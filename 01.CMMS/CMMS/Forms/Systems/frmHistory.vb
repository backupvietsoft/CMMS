
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmHistory
    Dim _sMS_MAY As String

    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property

    Private Sub frmHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowTreeRoot(_sMS_MAY)
        FormatGrid()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub


#Region "BoPhan"

    Dim OldNode As TreeNode                             'Lưu dữ giá trị của node hiện tại lúc không lưu dữ liệu
    Dim PrevOldNode As TreeNode                         'Lưu dữ giá trị của node trước trong trường hợp xóa
    Dim sTrangThaiTabThietbi As String = String.Empty   'Ghi nhận trạng thái là thêm hay sửa
    Dim sMA_BP_OLD As String = String.Empty
    Dim sTEN_BP_OLD As String = String.Empty
    ' <summary>
    ' Thủ tục nạp dữ liệu lên Treeview theo mã máy
    ' </summary>
    ' <remarks></remarks>
    Sub ShowTreeRoot(ByVal sMS_MAY As String)

        'TVw.CheckBoxes = True
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVw.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVw.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA=N'" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMaBP, oChildNode)
        Next

        TVw.ExpandAll()
        TVw.Focus()
        Try
            TVw.SelectedNode = TVw.Nodes(0)
        Catch ex As Exception

        End Try

    End Sub

    Sub ShowTreeNode(ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = N'" & _sMS_MAY & "'"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("TEN_BO_PHAN").ToString()

            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

            Call ShowTreeNode(sMaBP, oChildNode)
        Next
    End Sub

    Private Sub tvw_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TVw.AfterSelect
        ShowHistory()
    End Sub

    Sub ShowHistory()
        Dim dtTable As New DataTable
        If txtTuNgay.Text = "  /  /" Or txtDenNgay.Text = "  /  /" Then Exit Sub
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHistory", DateValue(txtTuNgay.Text), DateValue(txtDenNgay.Text), _sMS_MAY, TVw.SelectedNode.Name))
        grdDSBoPhan.DataSource = dtTable
        If grdDSBoPhan.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT3", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
        End If
    End Sub

#End Region

    Private Sub txtTuNgay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTuNgay.KeyDown
        Dim dtTable As New DataTable
        If e.KeyCode = Keys.Enter Then
            If txtTuNgay.Text = "  /  /" Then Exit Sub
            If IsDate(txtTuNgay.Text) = False Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
                txtTuNgay.Focus()
                Exit Sub
            End If
            If txtDenNgay.Text = "  /  /" Then Exit Sub
            If DateValue(txtTuNgay.Text) > DateValue(txtDenNgay.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT4", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
                Exit Sub
            End If
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHistory", DateValue(txtTuNgay.Text), DateValue(txtDenNgay.Text), _sMS_MAY, TVw.SelectedNode.Name))
            grdDSBoPhan.DataSource = dtTable
            If grdDSBoPhan.RowCount <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT3", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            End If
        End If
    End Sub

    Sub FormatGrid()
        grdDSBoPhan.Columns.Clear()

        Dim txtNGAY_THAY As New DataGridViewTextBoxColumn
        txtNGAY_THAY.Name = "txtNGAY_THAY"
        txtNGAY_THAY.DataPropertyName = "NGAY_THAY"
        txtNGAY_THAY.DefaultCellStyle.Format = "dd/MM/yyyy"
        txtNGAY_THAY.Width = 100
        grdDSBoPhan.Columns.Add(txtNGAY_THAY)

        Dim txtNGAY_TRA_TT As New DataGridViewTextBoxColumn
        txtNGAY_TRA_TT.Name = "txtNGAY_TRA_TT"
        txtNGAY_TRA_TT.DataPropertyName = "NGAY_TRA_TT"
        txtNGAY_TRA_TT.DefaultCellStyle.Format = "dd/MM/yyyy"
        txtNGAY_TRA_TT.Width = 100
        grdDSBoPhan.Columns.Add(txtNGAY_TRA_TT)

        Dim txtMS_PHIEU_BAO_TRI As New DataGridViewTextBoxColumn
        txtMS_PHIEU_BAO_TRI.Name = "txtMS_PHIEU_BAO_TRI"
        txtMS_PHIEU_BAO_TRI.DataPropertyName = "MS_PHIEU_BAO_TRI"
        txtMS_PHIEU_BAO_TRI.Width = 150
        grdDSBoPhan.Columns.Add(txtMS_PHIEU_BAO_TRI)

        Dim txtMS_MAY_THAY_THE As New DataGridViewTextBoxColumn
        txtMS_MAY_THAY_THE.Name = "txtMS_MAY_THAY_THE"
        txtMS_MAY_THAY_THE.DataPropertyName = "MS_MAY_THAY_THE"
        txtMS_MAY_THAY_THE.Width = 150
        grdDSBoPhan.Columns.Add(txtMS_MAY_THAY_THE)

        Dim txtMS_BO_PHAN_THAY_THE As New DataGridViewTextBoxColumn
        txtMS_BO_PHAN_THAY_THE.Name = "txtMS_BO_PHAN_THAY_THE"
        txtMS_BO_PHAN_THAY_THE.DataPropertyName = "MS_BO_PHAN_THAY_THE"
        txtMS_BO_PHAN_THAY_THE.Width = 150
        grdDSBoPhan.Columns.Add(txtMS_BO_PHAN_THAY_THE)

        Dim txtTEN_BO_PHAN_THAY_THE As New DataGridViewTextBoxColumn
        txtTEN_BO_PHAN_THAY_THE.Name = "txtTEN_BO_PHAN_THAY_THE"
        txtTEN_BO_PHAN_THAY_THE.DataPropertyName = "TEN_BO_PHAN_THAY_THE"
        txtTEN_BO_PHAN_THAY_THE.Width = 250
        grdDSBoPhan.Columns.Add(txtTEN_BO_PHAN_THAY_THE)

        Try
            Me.grdDSBoPhan.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDSBoPhan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try

        Try
            grdDSBoPhan.Columns("txtNGAY_THAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_THAY", commons.Modules.TypeLanguage)
            grdDSBoPhan.Columns("txtNGAY_TRA_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_TRA_TT", commons.Modules.TypeLanguage)
            grdDSBoPhan.Columns("txtMS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", commons.Modules.TypeLanguage)
            grdDSBoPhan.Columns("txtMS_MAY_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY_THAY_THE", commons.Modules.TypeLanguage)
            grdDSBoPhan.Columns("txtMS_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN_THAY_THE", commons.Modules.TypeLanguage)
            grdDSBoPhan.Columns("txtTEN_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN_THAY_THE", commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTuNgay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTuNgay.Validating
        If txtTuNgay.Text = "  /  /" Then Exit Sub
        If IsDate(txtTuNgay.Text) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            e.Cancel = True
        End If
        If txtDenNgay.Text = "  /  /" Then Exit Sub
        If DateValue(txtTuNgay.Text) > DateValue(txtDenNgay.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT4", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDenNgay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDenNgay.KeyDown
        Dim dtTable As New DataTable
        If e.KeyCode = Keys.Enter Then
            If txtDenNgay.Text = "  /  /" Then Exit Sub
            If IsDate(txtDenNgay.Text) = False Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
                txtDenNgay.Focus()
                Exit Sub
            End If

            If txtTuNgay.Text = "  /  /" Then Exit Sub
            If DateValue(txtDenNgay.Text) < DateValue(txtTuNgay.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT4", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
                Exit Sub
            End If
            Try
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHistory", DateValue(txtTuNgay.Text), DateValue(txtDenNgay.Text), _sMS_MAY, TVw.SelectedNode.Name))
                grdDSBoPhan.DataSource = dtTable
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT2", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
                TVw.Focus()
                Exit Sub
            End Try

            If grdDSBoPhan.RowCount <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT3", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            End If
        End If
    End Sub

    Private Sub txtDenNgay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDenNgay.Validating
        If txtDenNgay.Text = "  /  /" Then Exit Sub
        If IsDate(txtDenNgay.Text) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            e.Cancel = True
        End If

        If txtTuNgay.Text = "  /  /" Then Exit Sub
        If DateValue(txtDenNgay.Text) < DateValue(txtTuNgay.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage("ECOMAIN", Me.Name, "msgKT4", commons.Modules.TypeLanguage), MsgBoxStyle.Information, "Thông báo")
            e.Cancel = True
        End If

    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

End Class