Imports Microsoft.ApplicationBlocks.Data

Public Class frmPhuTungMay
    'bLoai = 1 Phu tung
    'bLoai = 2 Cong Viec
    Public iLoai As Integer = 1
    Public MsPT As String
    Dim iLoad As Integer
    Dim frmThongtin As frmThongtinthietbi
    Dim frmMain As frmMain
    Public btnCtruc As DevExpress.XtraEditors.SimpleButton

    Private Sub frmPhuTungMay(ByVal frm As frmThongtinthietbi, ByVal frm1 As frmMain)
        frmThongtin = frm
        frmMain = frm1
    End Sub

    Private Sub frmPhuTungMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Try
            grvMay.Columns("MS_MAY").Width = 100
            grvMay.Columns("TEN_MAY").Width = 200
            grvMay.Columns("MO_TA").Width = 200
            grvMay.Columns("MODEL").Width = 100
            grvMay.Columns("SERIAL_NUMBER").Width = 130
            grvMay.Columns("SO_THE").Width = 100
            grvMay.Columns("TEN_NHOM_MAY").Width = 130
            grvMay.Columns("TEN_LOAI_MAY").Width = 130
            grvMay.Columns("Ten_N_XUONG").Width = 120
            grvMay.Columns("TEN_HE_THONG").Width = 120

            grvMay.Columns("MS_MAY").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            grvBPhan.Columns("MS_BO_PHAN").Width = 160
            grvBPhan.Columns("TEN_BO_PHAN").Width = 400
            If iLoai = 1 Then
                grvBPhan.Columns("MS_VI_TRI_PT").Width = 160
                grvBPhan.Columns("SO_LUONG").Width = 100
            Else
                grvBPhan.Columns("GHI_CHU").Width = 280

            End If
        Catch ex As Exception

        End Try
        CreateMenuCTTB(grdBPhan)
    End Sub

    Private Sub CreateMenuCTTB(ByVal grd As DevExpress.XtraGrid.GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCTTB", Commons.Modules.TypeLanguage)
        Dim mnuCTTB As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCTTB.Name = "mnuCTTB"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCTTB})
        BarManager.EndUpdate()
    End Sub



    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
            Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
            If Not subMenu Is Nothing Then Return

            Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
            Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)


            Dim dt As New DataTable()
            Try

                Select Case e.Item.Name.ToUpper
#Region "mnumnuCTTB"
                    Case "mnuCTTB".ToUpper
                        ShowMay()
#End Region
                End Select
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try

    End Sub


    Private Sub LoadData()
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoPTung", MsPT, iLoai))
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, 0, 0, 0, 1)
    End Sub

    Private Sub grvMay_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvMay.FocusedRowChanged
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBoPhanTheoMayPTung",
                        MsPT, grvMay.GetFocusedRowCellValue("MS_MAY").ToString, iLoai))
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPhan, grvBPhan, dtTmp, 0, 0, 0, 0)
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        ShowMay()
    End Sub

    Private Function GetParentForm(parent As Control) As Form
        Dim form As Form = TryCast(parent, Form)
        If form IsNot Nothing Then
            If form.Name = "frmMain" Then
                Return form
            End If
        End If
        If parent IsNot Nothing Then
            Return GetParentForm(parent.Parent)
        End If
        Return Nothing
    End Function


    Private Sub ShowMay()
        If grvMay.RowCount = 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongCoMay", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim frmThongtin As New frmThongtinthietbi
        Try
            Dim frmMain = GetParentForm(btnCtruc.Parent) '
            Try
                For Each frmChild As Form In frmMain.MdiChildren
                    If (frmThongtin.Name.Trim().Equals(frmChild.Name.Trim())) Then
                        frmChild.Close()
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try
            frmThongtin.MdiParent = frmMain
            frmThongtin.WindowState = FormWindowState.Maximized
            frmThongtin.MS_MAY_CHOICE = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            frmThongtin.TAB_INDEX_CHOICE = 1
            frmThongtin.MSBP = grvBPhan.GetFocusedRowCellValue("MS_BO_PHAN").ToString()
            If iLoai = 1 Then
                frmThongtin.MSPTVT = MsPT & grvBPhan.GetFocusedRowCellValue("MS_VI_TRI_PT").ToString()
            Else
                frmThongtin.MSCV = MsPT
            End If
            frmThongtin.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub grvMay_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grvMay.DoubleClick, grvMay.DoubleClick
        If iLoad = 1 Then
            iLoad = 0
            Exit Sub
        End If
        ShowMay()
        iLoad = iLoad + 1
    End Sub

    Private Sub grvBPhan_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvBPhan.DoubleClick
        ShowMay()
    End Sub
End Class