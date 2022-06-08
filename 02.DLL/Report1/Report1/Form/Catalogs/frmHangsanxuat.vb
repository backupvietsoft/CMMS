
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmHangsanxuat

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader

#Region "Control Event"

    Private Sub frmHangsanxuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        InitForm()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            grdDanhsachHSX.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtTenHSX.Focus()
        txtMasoHSX.Visible = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTenHSX.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        
        If grdDanhsachHSX.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY không.
            SQL_TMP = "SELECT * FROM MAY WHERE MS_HSX = '" & txtMasoHSX.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            ' Xóa đơn vị đo

            Dim objHangSXController As New HANG_SAN_XUATController()
            objHangSXController.DeleteHANG_SAN_XUAT(txtMasoHSX.Text)

            ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If grdDanhsachHSX.Rows.Count > 0 Then
                If grdDanhsachHSX.Rows.Count = tmp Then
                    grdDanhsachHSX.CurrentCell() = grdDanhsachHSX.Rows(tmp - 1).Cells(1)
                    grdDanhsachHSX.Focus()
                Else
                    grdDanhsachHSX.CurrentCell() = grdDanhsachHSX.Rows(tmp).Cells(1)
                    grdDanhsachHSX.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim str As String = ""
        If isValidated() Then
            str = AddHangSX()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)

            For i As Integer = 0 To grdDanhsachHSX.Rows.Count - 1
                If grdDanhsachHSX.Rows(i).Cells("MS_HSX").Value = Val(str) Then
                    'grdDanhsachHSX.Rows(i).Selected = True ' .SelectedRows(i).Cells("MS_HSX").Selected = True
                    grdDanhsachHSX.Rows(i).Cells("TEN_HSX").Selected = True
                    grdDanhsachHSX.CurrentCell = grdDanhsachHSX.Rows(i).Cells("TEN_HSX")
                    grdDanhsachHSX.Focus()
                    Exit For
                Else
                    grdDanhsachHSX.Rows(i).Cells("MS_HSX").Selected = False
                End If
            Next
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachHSX.RowCount <> 0 Then
                ShowHangSX(grdDanhsachHSX.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowHangSX(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachHSX.RowHeaderMouseClick
        ShowHangSX(e.RowIndex)
    End Sub
    Dim intRow As Integer
    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachHSX.RowEnter
        ShowHangSX(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"
    Sub InitForm()



        Commons.Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Commons.Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Commons.Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachHSX.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1

        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachHSX.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

    End Sub

    Sub Refesh()
        txtTenHSX.Text = ""
        txtDiachi.Text = ""
        txtWebsite.Text = ""
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTenHSX.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTenHSX.Name, commons.Modules.TypeLanguage)
        Me.lblDiachi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblDiachi.Name, commons.Modules.TypeLanguage)
        Me.lblWebsite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblWebsite.Name, commons.Modules.TypeLanguage)
        Me.lblTieudeHangSX.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTieudeHangSX.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.grpDanhsachHSX.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhsachHSX.Name, commons.Modules.TypeLanguage)
        Me.grpNhaptenHSX.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNhaptenHSX.Name, commons.Modules.TypeLanguage)
        Me.grdDanhsachHSX.Columns("TEN_HSX").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_HSX", commons.Modules.TypeLanguage)
        Me.grdDanhsachHSX.Columns("DIA_CHI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DIA_CHI", commons.Modules.TypeLanguage)
    End Sub
    Sub ShowHangSX(ByVal RowIndex As Integer)
        txtMasoHSX.Text = grdDanhsachHSX.Rows(RowIndex).Cells("MS_HSX").Value
        txtTenHSX.Text = grdDanhsachHSX.Rows(RowIndex).Cells("TEN_HSX").Value
        txtDiachi.Text = IIf(IsDBNull(grdDanhsachHSX.Rows(RowIndex).Cells("DIA_CHI").Value), Nothing, grdDanhsachHSX.Rows(RowIndex).Cells("DIA_CHI").Value)
        txtWebsite.Text = IIf(IsDBNull(grdDanhsachHSX.Rows(RowIndex).Cells("WEBSITE").Value), Nothing, grdDanhsachHSX.Rows(RowIndex).Cells("WEBSITE").Value)
    End Sub
    Sub BindData()
        Me.grdDanhsachHSX.DataSource = New HANG_SAN_XUATController().GetHANG_SAN_XUATs
        Try
            grdDanhsachHSX.Columns(3).Visible = False
            grdDanhsachHSX.Columns(0).Visible = False
            grdDanhsachHSX.Columns(1).Width = 100
            grdDanhsachHSX.Columns(2).Width = 280

        Catch ex As Exception

        End Try
        If Me.grdDanhsachHSX.RowCount > 0 Then
            Me.BtnSua.Enabled = True
            Me.BtnXoa.Enabled = True
        Else
            Me.BtnSua.Enabled = False
            Me.BtnXoa.Enabled = False
        End If

    End Sub
    Function isValidated()
        If Not txtDiachi.IsValidated Then
            Return False
        End If
        If Not txtTenHSX.IsValidated Then
            Return False
        End If
        If Not txtWebsite.IsValidated Then
            Return False
        End If
        Return True
    End Function
    Function AddHangSX() As Integer
        Dim objHangSXInfo As New HANG_SAN_XUATInfo
        objHangSXInfo.TEN_HSX = txtTenHSX.Text
        objHangSXInfo.DIA_CHI = txtDiachi.Text
        objHangSXInfo.WEBSITE = txtWebsite.Text
        If Not blnThem Then
            Dim objHangSXController As New HANG_SAN_XUATController()
            objHangSXInfo.MS_HSX = txtMasoHSX.Text
            objHangSXController.UpdateHANG_SAN_XUAT(objHangSXInfo)
        Else
            objHangSXInfo.MS_HSX = New HANG_SAN_XUATController().AddHANG_SAN_XUAT(objHangSXInfo)

        End If
        AddHangSX = objHangSXInfo.MS_HSX
        Refesh()
    End Function
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtTenHSX.ReadOnly = blnLock
        txtDiachi.ReadOnly = blnLock
        txtWebsite.ReadOnly = blnLock
    End Sub

#End Region

End Class