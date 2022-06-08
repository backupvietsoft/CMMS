Imports Microsoft.ApplicationBlocks.Data
Imports System.Linq
Imports DevExpress.XtraEditors

Public Class FrmChonCongViecBoPhan
    Dim _SO_DONG As Integer
    Dim _ATTACHMENT As Boolean, _MS_MAY As String, _MS_BO_PHAN As String
    Dim _MS_LOAI_MAY As String = Nothing
    Dim form_Name As String
    Public grd As New DataGridView
    Public Property SO_DONG() As Integer
        Get
            Return _SO_DONG
        End Get
        Set(ByVal value As Integer)
            _SO_DONG = value
        End Set
    End Property
    Public Property formName() As String
        Get
            Return form_Name
        End Get
        Set(ByVal value As String)
            form_Name = value
        End Set
    End Property

    Public Property ATTACHMENT() As Boolean
        Get
            Return _ATTACHMENT
        End Get
        Set(ByVal value As Boolean)
            _ATTACHMENT = value
        End Set
    End Property

    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property

    Public Property MS_BO_PHAN() As String
        Get
            Return _MS_BO_PHAN
        End Get
        Set(ByVal value As String)
            _MS_BO_PHAN = value
        End Set
    End Property

    Public Property MS_LOAI_MAY() As String
        Get
            Return _MS_LOAI_MAY
        End Get
        Set(ByVal value As String)
            _MS_LOAI_MAY = value
        End Set
    End Property

    Public Class CV_TMP
        Public MS_CV As String
        Public MO_TA_CV As String
        Public THOI_GIAN_DU_KIEN As String
        Public THAO_TAC As String
        Public TIEU_CHUAN_KT As String
        Public PATH_HD As String
        Public YEU_CAU_DUNG_CU As String
    End Class


    Public dtTableTam As DataTable
    Dim dtTableOne As DataTable
    Dim sql As String
    Public lstMsCV As New List(Of CV_TMP)

    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.SQLString = "0Load"
        LoadLoaiCongViec()
        Commons.Modules.SQLString = ""
        cboLoaithietbi.EditValue = _MS_LOAI_MAY
        'BindData()
        CreateMenuCV(grdCongviec)
        cboLoaiCV_EditValueChanged(Nothing, Nothing)
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Sub BindData()

        Try
            grvCongviec.Columns.Clear()
            grdCongviec.DataSource = Nothing
        Catch ex As Exception
        End Try
        Try
            Convert.ToInt32(cboLoaiCV.EditValue)
        Catch ex As Exception
            cboLoaiCV.ItemIndex = 0
        End Try

        dtTableTam = New DataTable

        dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_CV_BP", cboLoaiCV.EditValue,
                _MS_MAY, _MS_BO_PHAN, If(cboLoaithietbi.EditValue = "-98", _MS_LOAI_MAY, cboLoaithietbi.EditValue), Commons.Modules.UserName))

        dtTableTam.Columns("CHON").ReadOnly = False

        Try
            If lstMsCV.Count > 0 Then
                For Each CV In lstMsCV
                    Dim dr As DataRow = dtTableTam.Select().AsEnumerable().Where(Function(x) CV.MS_CV = x("MS_CV").ToString()).SingleOrDefault()
                    dr("CHON") = True
                Next
            End If
        Catch ex As Exception '
        End Try

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongviec, grvCongviec, dtTableTam, True, False, True, False, True, "")

        Try
            grvCongviec.Columns("MS_CV").Width = 100
        Catch ex As Exception
        End Try
        grvCongviec.Columns("CHON").OptionsColumn.ReadOnly = False
        grvCongviec.Columns("MS_CV").Visible = False
        grvCongviec.Columns("CHON").OptionsColumn.ReadOnly = False
        grvCongviec.Columns("MS_LOAI_CV").Visible = False
        grvCongviec.Columns("MO_TA_CV").Width = 250
        grvCongviec.Columns("MO_TA_CV").OptionsColumn.ReadOnly = True
        grvCongviec.Columns("KY_HIEU_CV").OptionsColumn.ReadOnly = True
        grvCongviec.Columns("THOI_GIAN_DU_KIEN").OptionsColumn.ReadOnly = True
        grvCongviec.Columns("THOI_GIAN_DU_KIEN").Width = 80
        grvCongviec.Columns("CHON").Width = 50
        grvCongviec.Columns("TEN_LOAI_CV").OptionsColumn.ReadOnly = True
        grvCongviec.Columns("TEN_LOAI_MAY").OptionsColumn.ReadOnly = True
        grvCongviec.Columns("MS_CV_TIM").Visible = False
        grvCongviec.Columns("MA_CV").Visible = False
        Try
            grvCongviec.Columns("THAO_TAC").Visible = False
            grvCongviec.Columns("TIEU_CHUAN_KT").Visible = False
            grvCongviec.Columns("YEU_CAU_NS").Visible = False
            grvCongviec.Columns("YEU_CAU_DUNG_CU").Visible = False
            grvCongviec.Columns("GHI_CHU").Visible = False
            grvCongviec.Columns("PATH_HD").Visible = False
        Catch ex As Exception
        End Try

    End Sub

    Sub LoadLoaiCongViec()
        cboLoaiCV.Properties.DataSource = Nothing
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName))
        Dim DR = dtTmp.NewRow()
        DR("MS_LOAI_CV") = "-1"
        DR("TEN_LOAI_CV") = " < ALL > "
        dtTmp.Rows.InsertAt(DR, 0)

        'dtTmp.DefaultView.Sort = "MS_LOAI_CV ASC"

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "")

        Dim dt As New DataTable
        dt = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1)
        DR = dt.NewRow()
        DR("MS_LOAI_MAY") = "-99"
        DR("TEN_LOAI_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongCoLoaiMay", Commons.Modules.TypeLanguage)
        dt.Rows.Add(DR)
        DR = dt.NewRow()
        DR("MS_LOAI_MAY") = "-98"
        DR("TEN_LOAI_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TheoLoaiMay", Commons.Modules.TypeLanguage)
        dt.Rows.Add(DR)
        dt.DefaultView.Sort = "TEN_LOAI_MAY"
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaithietbi, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        DialogResult = DialogResult.Cancel

    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < grvCongviec.RowCount
            grvCongviec.GetDataRow(i)("CHON") = True
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < grvCongviec.RowCount
            grvCongviec.GetDataRow(i)("CHON") = False
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        dtTableOne = New DataTable
        Try
            dtTableTam = CType(grdCongviec.DataSource, DataTable)
            dtTableTam.DefaultView.RowFilter = "CHON = True"
            dtTableTam = dtTableTam.DefaultView.ToTable()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        DialogResult = DialogResult.OK

    End Sub

    Private Sub btnCongViec_Click(sender As Object, e As EventArgs)
        Try
            Dim frm As New MVControl.frmDanhmuccongviec
            frm.Size = New Size(900, 600)
            frm.ShowDialog()
            BindData()
        Catch
        End Try

    End Sub


    Private Sub txtGiatri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiatri.TextChanged
        Dim dtTmp = New DataTable
        Try
            dtTmp = CType(grdCongviec.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = " MS_CV_TIM like '%" + txtGiatri.Text + "%' OR MO_TA_CV like '%" + txtGiatri.Text + "%' OR KY_HIEU_CV like '%" + txtGiatri.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub cboLoaiCV_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiCV.EditValueChanged, cboLoaithietbi.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        BindData()
    End Sub

    Private Sub ckAllCV_CheckedChanged(sender As Object, e As EventArgs)
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        BindData()
    End Sub


#Region "TaoMeNuCongViec"
    Private Sub CreateMenuCV(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)

        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"

        sStr = "SELECT COUNT(*) FROM NHOM_FORM T1 INNER JOIN dbo.USERS T2 ON T2.GROUP_ID = T1.GROUP_ID WHERE FORM_NAME = 'frmDanhmuccongviec'  AND T2.USERNAME = '" & Commons.Modules.UserName & "' AND UPPER(T1.QUYEN) = UPPER(N'Full access') "

        Dim iPQ As Int16 = 0
        Try
            iPQ = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sStr))
        Catch ex As Exception
            iPQ = 0
        End Try


        If iPQ > 0 Then
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkAddCV", Commons.Modules.TypeLanguage)
            Dim mnuAddCV As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
            mnuAddCV.Name = "mnuAddCV"
            popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec, mnuAddCV})
        Else
            popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec})
        End If


        BarManager.EndUpdate()
    End Sub

    Private Sub grvCongviec_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvCongviec.CellValueChanged
        If e.Column.FieldName = "CHON" Then
            If grvCongviec.GetFocusedDataRow()("CHON") = True Then

                lstMsCV.Add(New CV_TMP() With {
                            .MS_CV = grvCongviec.GetFocusedDataRow()("MS_CV"),
                            .MO_TA_CV = grvCongviec.GetFocusedDataRow()("MO_TA_CV"),
                            .THOI_GIAN_DU_KIEN = grvCongviec.GetFocusedDataRow()("THOI_GIAN_DU_KIEN"),
                            .PATH_HD = If(grvCongviec.GetFocusedDataRow()("PATH_HD") Is DBNull.Value Or grvCongviec.GetFocusedDataRow()("PATH_HD") Is Nothing, "", grvCongviec.GetFocusedDataRow()("PATH_HD")),
                                    .THAO_TAC = If(grvCongviec.GetFocusedDataRow()("THAO_TAC") Is DBNull.Value Or grvCongviec.GetFocusedDataRow()("THAO_TAC") Is Nothing, "", grvCongviec.GetFocusedDataRow()("THAO_TAC")),
                                    .TIEU_CHUAN_KT = If(grvCongviec.GetFocusedDataRow()("TIEU_CHUAN_KT") Is DBNull.Value Or grvCongviec.GetFocusedDataRow()("TIEU_CHUAN_KT") Is Nothing, "", grvCongviec.GetFocusedDataRow()("TIEU_CHUAN_KT")),
                                    .YEU_CAU_DUNG_CU = If(grvCongviec.GetFocusedDataRow()("YEU_CAU_DUNG_CU") Is DBNull.Value Or grvCongviec.GetFocusedDataRow()("YEU_CAU_DUNG_CU") Is Nothing, "", grvCongviec.GetFocusedDataRow()("YEU_CAU_DUNG_CU"))
                        })
            Else
                Try
                    lstMsCV.Remove(lstMsCV.Where(Function(x) x.MS_CV = grvCongviec.GetFocusedDataRow()("MS_CV")).SingleOrDefault())
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return

        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim dt As New DataTable()
        Try
            Select Case e.Item.Name.ToUpper
                Case "mnuCongViec".ToUpper
                    Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuWork' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If (dt.Rows.Count = 0) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim frmDanhmuccongviec As New MVControl.frmDanhmuccongviec
                    Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmDanhmuccongviec.Name)

                    Dim sMaSo As String

                    sMaSo = grv.GetFocusedDataRow("MS_CV").ToString()
                    frmDanhmuccongviec.MS_CVIEC = sMaSo

                    frmDanhmuccongviec.Size = New Size(900, 600)
                    frmDanhmuccongviec.ShowDialog()
                Case "mnuAddCV".ToUpper

                    Dim frm As New ReportMain.frmThemCongViec()
                    frm.sMsMay = MS_MAY
                    If frm.ShowDialog = DialogResult.Yes Then

                        lstMsCV.Add(New CV_TMP() With {
                                    .MS_CV = frm.ketQua.Split("!")(0),
                                    .MO_TA_CV = frm.ketQua.Split("!")(1),
                                    .THOI_GIAN_DU_KIEN = frm.ketQua.Split("!")(2),
                                    .PATH_HD = "",
                                    .THAO_TAC = "",
                                    .TIEU_CHUAN_KT = "",
                                    .YEU_CAU_DUNG_CU = ""
                                })
                        BindData()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Dim iMsCV As Integer = -1
#End Region





End Class