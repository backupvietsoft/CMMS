

Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports Commons

Public Class frmSearchPT

    Public vtbDsPT As DataTable = New DataTable()
    Public vEvents As String = "C"


    Private Sub frmSearchPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        radTimkiem.Checked = True
        radLoctheodieukien.Checked = False
        grpLoctheodieukien.Visible = False
        grpTimkiem.Visible = True
        loadData()
        initcboTimkiem()
        loadcboLocthietbi()
        LoadCboTenvattu()
        LoadcboLocNoisudung()
        LoadClass()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub loadData()


    End Sub

    Sub initcboTimkiem()
        Me.cboTimtheo.StoreName = "GetTimVT"
        Me.cboTimtheo.Value = "ID"
        Me.cboTimtheo.Display = "TEN"
        Me.cboTimtheo.Param = 1
        Me.cboTimtheo.Param2 = Commons.Modules.TypeLanguage
        Me.cboTimtheo.BindDataSource()
    End Sub

    Sub loadcboLocthietbi()
        Me.cboLocthietbi.StoreName = "GetLOAI_MAY_TMP"
        Me.cboLocthietbi.Value = "MS_LOAI_MAY"
        Me.cboLocthietbi.Display = "TEN_LOAI_MAY"
        Me.cboLocthietbi.Param = Commons.Modules.UserName
        Me.cboLocthietbi.BindDataSource()
    End Sub

    Sub LoadCboTenvattu()
        Me.cboLocvattu.Value = "MS_LOAI_VT"
        If Commons.Modules.TypeLanguage = 0 Then
            Me.cboLocvattu.Display = "TEN_LOAI_VT_TV"
        ElseIf Commons.Modules.TypeLanguage = 1 Then
            Me.cboLocvattu.Display = "TEN_LOAI_VT_TA"
        ElseIf Commons.Modules.TypeLanguage = 2 Then
            Me.cboLocvattu.Display = "TEN_LOAI_VT_TH"
        End If
        Me.cboLocvattu.StoreName = "GetTEN_LOAI_VTs"
        Me.cboLocvattu.BindDataSource()
    End Sub

    Sub LoadcboLocNoisudung()
        Me.cboLocNoisudung.StoreName = "Get_Loc_LOAI_PHU_TUNG"
        Me.cboLocNoisudung.Display = "TEN_LOAI_PT"
        Me.cboLocNoisudung.Value = "MS_LOAI_PT"
        Me.cboLocNoisudung.Param = Commons.Modules.UserName
        Me.cboLocNoisudung.BindDataSource()
    End Sub

    Sub LoadClass()
        Me.cbxClass.StoreName = "H_Get_Class_VT"
        Me.cbxClass.Display = "TEN_CLASS"
        Me.cbxClass.Value = "MS_CLASS"
        Me.cbxClass.Param = Commons.Modules.UserName
        Me.cbxClass.BindDataSource()

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If radTimkiem.Checked = False Then
            'Dim vtb As DataTable = New DataTable()
            vtbDsPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetIC_PHU_TUNG_FILTER_CS", Commons.Modules.UserName, cboLocvattu.SelectedValue, cboLocthietbi.SelectedValue, cboLocNoisudung.SelectedValue, cbxClass.SelectedValue))
            vEvents = "OK"
        Else
            'Dim vtb As DataTable = New DataTable()
            vtbDsPT = New Commons.VS.Classes.Catalogue.IC_PHU_TUNGController().get_IC_PHU_TUNG_SEARCH_CS(Commons.Modules.UserName, cboTimtheo.SelectedValue, txtGiatritim.Text)
            vEvents = "OK"
        End If
        Me.Close()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Private Sub radLoctheodieukien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLoctheodieukien.Click

        grpLoctheodieukien.Visible = True
        grpTimkiem.Visible = False

    End Sub

    Private Sub radTimkiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTimkiem.Click

        grpLoctheodieukien.Visible = False
        grpTimkiem.Visible = True

    End Sub

    Private Sub txtGiatritim_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGiatritim.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            'Dim vtb As DataTable = New DataTable()
            vtbDsPT = New Commons.VS.Classes.Catalogue.IC_PHU_TUNGController().get_IC_PHU_TUNG_SEARCH_CS(Commons.Modules.UserName, cboTimtheo.SelectedIndex, txtGiatritim.Text)
            vEvents = "OK"

            'frmDanhmucphutung_CS.gridDanhSach.DataSource = vtb 'New VS.Classes.Catalogue.IC_PHU_TUNGController().get_IC_PHU_TUNG_SEARCH(Commons.Modules.UserName, cboTimtheo.SelectedIndex, txtGiatritim.Text).DefaultView
            'If vtb.Rows.Count < 1 Then
            '    frmDanhmucphutung_CS.BtnSua.Visible = False
            '    frmDanhmucphutung_CS.BtnXoa.Visible = False
            '    frmDanhmucphutung_CS.btnXoa2.Visible = False
            'Else
            '    frmDanhmucphutung_CS.BtnSua.Visible = True
            '    frmDanhmucphutung_CS.BtnXoa.Visible = True
            '    frmDanhmucphutung_CS.btnXoa2.Visible = True
            'End If
            Me.Close()
        End If
    End Sub


End Class