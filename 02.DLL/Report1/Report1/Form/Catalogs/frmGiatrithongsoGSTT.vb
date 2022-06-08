
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmGiatrithongsoGSTT

    ' Khai báo biến 
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private MS_KH_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader
    Private flag As Boolean

#Region "Control Event"

    Private Sub frmGiatrithongsoGSTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
        Load_cboThongSo()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)

        Try
            grdDanhsachgiatriTSGSTT.Rows(0).Cells(1).Selected = True
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
        cboTHONG_SO_GSTT.Focus()
        blnThem = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        cboTHONG_SO_GSTT.Enabled = False
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        'Check permision
        'Check empty data
        If grdDanhsachgiatriTSGSTT.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Confirm delete
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            ' Check data was used
            SQL_TMP = "SELECT * FROM GIA_TRI_TS_GSTT WHERE MS_TS_GSTT = '" & txtSoTT.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            SQL_TMP = "SELECT * FROM MAY_THONG_SO_GSTT WHERE MS_TS_GSTT = '" & txtSoTT.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read

                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            'Delete
            Dim objGiaTriThongSoGSTTController As New GIA_TRI_TS_GSTTController()
            objGiaTriThongSoGSTTController.DeleteGIA_TRI_TS_GSTT(cboTHONG_SO_GSTT.SelectedValue.ToString, CType(txtSoTT.Text, Integer))
            Refesh()
            BindData()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            AddGiaTriTSGSTT()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachgiatriTSGSTT.RowCount <> 0 Then
                ShowGiaTriTSGSTT(grdDanhsachgiatriTSGSTT.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowGiaTriTSGSTT(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Dim MS_TS_GSTT As String
        MS_TS_GSTT = ""
        Me.Close()
    End Sub

    Private Sub grdDanhsachgiatriTSGSTT_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachgiatriTSGSTT.RowHeaderMouseClick
        ShowGiaTriTSGSTT(e.RowIndex)
    End Sub

    Private Sub grdDanhsachgiatriTSGSTT_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachgiatriTSGSTT.RowEnter
        ShowGiaTriTSGSTT(e.RowIndex)
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
        Me.grdDanhsachgiatriTSGSTT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1


        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachgiatriTSGSTT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

    End Sub
    Sub Refesh()
        txtSoTT.Text = ""
        txtGiatri.Text = ""
        txtGhichu.Text = ""
        cboTHONG_SO_GSTT.Text = ""
        chkDat.Checked = False
    End Sub
    Private Sub RefeshLanguage()
        Me.LblTieudeGiatriTSGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudeGiatriTSGSTT.Name, commons.Modules.TypeLanguage)
        Me.lblGhichu.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblGhichu.Name, commons.Modules.TypeLanguage)
        Me.chkDat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, chkDat.Name, commons.Modules.TypeLanguage)
        Me.lblMaTSGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblMaTSGSTT.Name, commons.Modules.TypeLanguage)
        Me.lblgiatri.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblgiatri.Name, commons.Modules.TypeLanguage)
        Me.chkDat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, chkDat.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachTSGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachTSGSTT.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapthongsoGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapthongsoGSTT.Name, commons.Modules.TypeLanguage)
        Me.grdDanhsachgiatriTSGSTT.Columns("TEN_TS_GSTT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_TS_GSTT", commons.Modules.TypeLanguage)
        Me.grdDanhsachgiatriTSGSTT.Columns("TEN_GIA_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_GIA_TRI", commons.Modules.TypeLanguage)
        Me.grdDanhsachgiatriTSGSTT.Columns("DAT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DAT", commons.Modules.TypeLanguage)
    End Sub
    Sub ShowGiaTriTSGSTT(ByVal RowIndex As Integer)
        cboTHONG_SO_GSTT.Text = grdDanhsachgiatriTSGSTT.Rows(RowIndex).Cells("TEN_TS_GSTT").Value
        txtSoTT.Text = grdDanhsachgiatriTSGSTT.Rows(RowIndex).Cells("STT").Value
        txtGiatri.Text = grdDanhsachgiatriTSGSTT.Rows(RowIndex).Cells("TEN_GIA_TRI").Value
        chkDat.Checked = grdDanhsachgiatriTSGSTT.Rows(RowIndex).Cells("DAT").Value
        txtGhichu.Text = grdDanhsachgiatriTSGSTT.Rows(RowIndex).Cells("GHI_CHU").Value
    End Sub
    Sub Load_cboThongSo()
        cboTHONG_SO_GSTT.Value = "MS_TS_GSTT"
        cboTHONG_SO_GSTT.Display = "TEN_TS_GSTT"
        cboTHONG_SO_GSTT.StoreName = "GetTHONG_SO_GSTTs"
        cboTHONG_SO_GSTT.Param = commons.Modules.TypeLanguage
        cboTHONG_SO_GSTT.ClassName = "frmThongsoGSTT"
        cboTHONG_SO_GSTT.BindDataSource()
    End Sub
    Sub BindData()
        Me.grdDanhsachgiatriTSGSTT.DataSource = New GIA_TRI_TS_GSTTController().GetGIA_TRI_TS_GSTTs
        If flag Then
            grdDanhsachgiatriTSGSTT.Columns(0).Width = 160
            grdDanhsachgiatriTSGSTT.Columns(1).Visible = False
            grdDanhsachgiatriTSGSTT.Columns(2).Width = 140
            grdDanhsachgiatriTSGSTT.Columns(3).Width = 80
            grdDanhsachgiatriTSGSTT.Columns(4).Visible = False
            flag = False
        End If
    End Sub
    Function isValidated()
        If Not txtSoTT.IsValidated Then
            Return False
        End If
        If Not txtGiatri.IsValidated Then
            Return False
        End If
        If Not txtGhichu.IsValidated Then
            Return False
        End If
        If Not cboTHONG_SO_GSTT.IsValidated Then
            Return False
        End If
        Return True
    End Function
    Sub AddGiaTriTSGSTT()
        Dim objGiaTriThongSoController As New GIA_TRI_TS_GSTTController()
        Dim objGiaTriThongSoInfo As New GIA_TRI_TS_GSTTInfo
        objGiaTriThongSoInfo.MS_TS_GSTT = cboTHONG_SO_GSTT.SelectedValue.ToString
        objGiaTriThongSoInfo.TEN_GIA_TRI = txtGiatri.Text
        objGiaTriThongSoInfo.GHI_CHU = txtGhichu.Text
        objGiaTriThongSoInfo.DAT = chkDat.Checked

        If Not blnThem Then
            objGiaTriThongSoInfo.STT = txtSoTT.Text
            objGiaTriThongSoController.UpdateGIA_TRI_TS_GSTT(objGiaTriThongSoInfo)
        Else
            objGiaTriThongSoController.AddGIA_TRI_TS_GSTT(objGiaTriThongSoInfo)
        End If
        Refesh()
    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtGiatri.ReadOnly = blnLock
        txtGhichu.ReadOnly = blnLock
        cboTHONG_SO_GSTT.Enabled = Not blnLock
        chkDat.Enabled = Not blnLock
    End Sub
#End Region

End Class