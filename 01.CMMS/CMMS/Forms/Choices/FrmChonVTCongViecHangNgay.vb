
Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data


Public Class FrmChonVTCongViecHangNgay
    Private vListVT As DataTable
    Private vDsVT As DataTable
    Private vVTChon As DataTable
    Public vChiTietVT As New DataTable

    Public vEvents As String = "N"
    Public vSttCV As Integer

    Private Sub FrmChonVTCongViecHangNgay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If vEvents <> "E" Then
            loadData()
            InitTable()
        Else
            InitTable()
            LoadData1()
        End If
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Sub loadData()

        vListVT = New DataTable
        vListVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_CONG_VIEC_HANG_NGAY_CHON_VT"))

        vDsVT = New DataTable
        vDsVT = vListVT.DefaultView.ToTable(True, "MS_PT", "TEN_PT", "ID", "PTID")

        grdDanhSach.AutoGenerateColumns = True
        grdDanhSach.DataSource = vDsVT
        grdDanhSach.Columns("MS_PT").DataPropertyName = "MS_PT"
        grdDanhSach.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        grdDanhSach.Columns("ID").DataPropertyName = "ID"
        grdDanhSach.Columns("PTID").DataPropertyName = "PTID"

    End Sub

    Sub LoadData1()
        RemoveHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter
        'H_CONG_VIEC_HANG_NGAY_CHON_VT_EDIT
        vListVT = New DataTable
        vListVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_CONG_VIEC_HANG_NGAY_CHON_VT_EDIT", vSttCV, Commons.Modules.UserName))

        Dim vdsDX As New DataView(vListVT, "STT_CV = " + vSttCV.ToString, "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)

        Dim vtbTMP As New DataTable
        vtbTMP = vdsDX.ToTable(True, "MS_PT", "TEN_PT", "ID", "PTID")

        Dim vdsPT As String = ""
        For Each vr As DataRow In vtbTMP.Rows
            Dim vsl As Double = 0
            For i As Integer = 0 To vdsDX.ToTable.Rows.Count - 1
                If vr("PTID") = vdsDX.ToTable.Rows(i)("PTID").ToString Then
                    vsl = vsl + vdsDX.ToTable.Rows(i)("SL_SU_DUNG")
                End If
            Next
            vVTChon.Rows.Add(vr("MS_PT"), vr("TEN_PT"), vsl, vr("ID"), vr("PTID"))
            If vdsPT = "" Then
                vdsPT = "'" + vr("PTID") + "'"
            Else
                vdsPT = vdsPT + ", '" + vr("PTID") + "'"
            End If

        Next
        If vdsPT = "" Then vdsPT = "-1"

        Dim vew As New DataView(vListVT, " (STT_CV is null or STT_CV <> " + vSttCV.ToString + " ) and PTID not in (" + vdsPT + " )", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)

        vDsVT = New DataTable
        vDsVT = vew.ToTable(True, "MS_PT", "TEN_PT", "ID", "PTID")

        grdDanhSach.AutoGenerateColumns = True
        grdDanhSach.DataSource = vDsVT
        grdDanhSach.Columns("MS_PT").DataPropertyName = "MS_PT"
        grdDanhSach.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        grdDanhSach.Columns("ID").DataPropertyName = "ID"
        grdDanhSach.Columns("PTID").DataPropertyName = "PTID"

        vdsDX = New DataView(vListVT, " PTID in (" + vdsPT + " )", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
        Try
            For Each vrow As DataRow In vdsDX.ToTable.Rows
                vChiTietVT.Rows.Add(vrow("MS_PT"), vrow("MS_DH_XUAT_PT"), vrow("MS_DH_NHAP_PT"), vrow("CHENH_LECH"),
                        vrow("DON_GIA"), vrow("NGOAI_TE"), vrow("TY_GIA"), vrow("TY_GIA_USD"), vrow("TEN_PT"),
                        vrow("SL_SU_DUNG"), vrow("DVT"), vrow("ID"), vrow("PTID"))
            Next
            vChiTietVT.AcceptChanges()
        Catch ex As Exception
        End Try


        If grdVTChon.Rows.Count > 0 Then
            grdVTChon.CurrentCell = grdVTChon.Rows(grdVTChon.Rows.Count - 1).Cells("MS_PT1")
            Dim vews As New DataView(vChiTietVT, " PTIDCT ='" + grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
            grdChiTiet.DataSource = vews.ToTable()
        End If
        AddHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter

    End Sub

    Sub InitTable()

        vVTChon = New DataTable
        vVTChon.Columns.Add("MS_PT1", Type.GetType("System.String"))
        vVTChon.Columns.Add("TEN_PT1", Type.GetType("System.String"))
        vVTChon.Columns.Add("SO_LUONG", Type.GetType("System.Double"))
        vVTChon.Columns.Add("ID", Type.GetType("System.Double"))
        vVTChon.Columns.Add("PTID", Type.GetType("System.String"))

        grdVTChon.AutoGenerateColumns = False
        grdVTChon.DataSource = vVTChon
        grdVTChon.Columns("MS_PT1").DataPropertyName = "MS_PT1"
        grdVTChon.Columns("TEN_PT1").DataPropertyName = "TEN_PT1"
        grdVTChon.Columns("SO_LUONG").DataPropertyName = "SO_LUONG"
        grdVTChon.Columns("ID").DataPropertyName = "ID"
        grdVTChon.Columns("PTID").DataPropertyName = "PTID"


        vChiTietVT = New DataTable
        vChiTietVT.Columns.Add("MS_PT", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("MS_DH_XUAT_PT", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("MS_DH_NHAP_PT", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("CHENH_LECH", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("DON_GIA", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("NGOAI_TE", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("TY_GIA", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("TY_GIA_USD", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("TEN_PT", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("SO_LUONG_XUAT", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("DVT", Type.GetType("System.String"))
        vChiTietVT.Columns.Add("IDCT", Type.GetType("System.Double"))
        vChiTietVT.Columns.Add("PTIDCT", Type.GetType("System.String"))

        grdChiTiet.AutoGenerateColumns = False
        grdChiTiet.DataSource = vChiTietVT

        grdChiTiet.Columns("MS_PT2").DataPropertyName = "MS_PT"
        grdChiTiet.Columns("MS_DH_XUAT_PT").DataPropertyName = "MS_DH_XUAT_PT"
        grdChiTiet.Columns("MS_DH_NHAP_PT").DataPropertyName = "MS_DH_NHAP_PT"
        grdChiTiet.Columns("SO_LUONG_CON").DataPropertyName = "CHENH_LECH"
        grdChiTiet.Columns("SO_LUONG_XUAT").DataPropertyName = "SO_LUONG_XUAT"
        grdChiTiet.Columns("IDCT").DataPropertyName = "IDCT"
        grdChiTiet.Columns("PTIDCT").DataPropertyName = "PTIDCT"

    End Sub

    Private Sub BtnXuatTuDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXuatTuDong.Click
        For i As Integer = 0 To grdVTChon.Rows.Count - 1
            If grdVTChon.Rows(i).Cells("SO_LUONG").Value = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_PHAI_LON_HON_KO", Commons.Modules.TypeLanguage))
                grdVTChon.CurrentCell = grdVTChon.Rows(i).Cells("SO_LUONG")
                Exit Sub
            End If
        Next

        ' Cap nhat so luong 
        Dim vi As Integer = 0
        For Each vrow As DataRow In vChiTietVT.Rows
            vChiTietVT.Rows(vi)("SO_LUONG_XUAT") = 0
            vi = vi + 1
        Next

        For i As Integer = 0 To grdVTChon.Rows.Count - 1

            Dim vTongSL As Integer = grdVTChon.Rows(i).Cells("SO_LUONG").Value

            If CheckCanTon(grdVTChon.Rows(i).Cells("PTID").Value, grdVTChon.Rows(i).Cells("SO_LUONG").Value) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_XUAT_PHAI_NHO_HON_SL_CON", Commons.Modules.TypeLanguage))
                grdVTChon.CurrentCell = grdVTChon.Rows(i).Cells("SO_LUONG")
                Exit Sub
            End If

            Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + grdVTChon.Rows(i).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)

            For Each vr As DataRow In vew.ToTable.Rows
                Dim j As Integer = 0
                For Each vrow As DataRow In vChiTietVT.Rows
                    If vrow("MS_DH_XUAT_PT") = vr("MS_DH_XUAT_PT") And vrow("MS_DH_NHAP_PT") = vr("MS_DH_NHAP_PT") And vrow("PTIDCT") = vr("PTIDCT") Then
                        If vTongSL > 0 And (vTongSL - vrow("CHENH_LECH")) > 0 Then
                            vChiTietVT.Rows(j)("SO_LUONG_XUAT") = vrow("CHENH_LECH")
                            vTongSL = vTongSL - vrow("CHENH_LECH")
                        ElseIf vTongSL > 0 And (vTongSL - vrow("CHENH_LECH")) <= 0 Then
                            vChiTietVT.Rows(j)("SO_LUONG_XUAT") = vTongSL
                            vTongSL = 0
                        End If
                    End If
                    j = j + 1
                Next
            Next

        Next

        '' View 
        If grdVTChon.Rows.Count > 0 Then
            grdVTChon.CurrentCell = grdVTChon.Rows(grdVTChon.Rows.Count - 1).Cells("MS_PT1")
            Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
            grdChiTiet.DataSource = vew.ToTable()
        End If


    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        For i As Integer = 0 To grdVTChon.Rows.Count - 1
            If grdVTChon.Rows(i).Cells("SO_LUONG").Value = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_PHAI_LON_HON_KO", Commons.Modules.TypeLanguage))
                grdVTChon.CurrentCell = grdVTChon.Rows(i).Cells("SO_LUONG")
                Exit Sub
            End If
        Next
        For i As Integer = 0 To grdVTChon.Rows.Count - 1

            If CheckCanTon(grdVTChon.Rows(i).Cells("PTID").Value, grdVTChon.Rows(i).Cells("SO_LUONG").Value) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_XUAT_PHAI_NHO_HON_SL_CON", Commons.Modules.TypeLanguage))
                grdVTChon.CurrentCell = grdVTChon.Rows(i).Cells("SO_LUONG")
                Exit Sub
            End If

            If CheckCan(grdVTChon.Rows(i).Cells("PTID").Value, grdVTChon.Rows(i).Cells("SO_LUONG").Value) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_XUAT_CHUA_CAN", Commons.Modules.TypeLanguage))
                grdVTChon.CurrentCell = grdVTChon.Rows(i).Cells("SO_LUONG")
                Exit Sub
            End If
        Next
        vEvents = "OK"
        Me.Close()


    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        vEvents = "N"
        Me.Close()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click

        RemoveHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter
        If grdDanhSach.Rows.Count > 0 Then
            Try
                vVTChon.Rows.Add(grdDanhSach.Rows(grdDanhSach.CurrentRow.Index).Cells("MS_PT").Value,
                                 grdDanhSach.Rows(grdDanhSach.CurrentRow.Index).Cells("TEN_PT").Value, 0,
                                 grdDanhSach.Rows(grdDanhSach.CurrentRow.Index).Cells("ID").Value,
                                 grdDanhSach.Rows(grdDanhSach.CurrentRow.Index).Cells("PTID").Value)
                vVTChon.AcceptChanges()
            Catch ex As Exception
            End Try

            Dim vDvTmp As New DataView(vListVT, "PTID ='" + grdDanhSach.Rows(grdDanhSach.CurrentRow.Index).Cells("PTID").Value + "'",
                                "MS_PT", DataViewRowState.CurrentRows)

            Try
                For Each vrow As DataRow In vDvTmp.ToTable.Rows
                    vChiTietVT.Rows.Add(vrow("MS_PT"), vrow("MS_DH_XUAT_PT"), vrow("MS_DH_NHAP_PT"), vrow("CHENH_LECH"), vrow("DON_GIA"),
                                        vrow("NGOAI_TE"), vrow("TY_GIA"), vrow("TY_GIA_USD"), vrow("TEN_PT"), 0, vrow("DVT"), vrow("ID"), vrow("PTID"))
                Next
                vChiTietVT.AcceptChanges()
            Catch ex As Exception
            End Try
            vDsVT.Rows.RemoveAt(grdDanhSach.CurrentRow.Index)
            Try

                '' View 
                If grdVTChon.Rows.Count > 0 Then
                    grdVTChon.CurrentCell = grdVTChon.Rows(grdVTChon.Rows.Count - 1).Cells("MS_PT1")
                    Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value + "' ", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
                    grdChiTiet.DataSource = vew.ToTable()
                End If
            Catch ex As Exception

            End Try

        End If
        AddHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        RemoveHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter
        If grdVTChon.Rows.Count > 0 Then

            Try
                vDsVT.Rows.Add(grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("MS_PT1").Value, grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("TEN_PT1").Value, grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("ID").Value, grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value)
                vDsVT.AcceptChanges()
            Catch ex As Exception
            End Try

            Dim vDvTmp1 As New DataTable
            vDvTmp1 = New DataView(vChiTietVT, "PTIDCT <> '" + grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows).ToTable()

            vChiTietVT = vDvTmp1
            vChiTietVT.AcceptChanges()
            'grdChiTiet.DataSource = vChiTietVT

            vVTChon.Rows.RemoveAt(grdVTChon.CurrentRow.Index)

            '' View 
            If grdVTChon.Rows.Count > 0 Then
                grdVTChon.CurrentCell = grdVTChon.Rows(grdVTChon.Rows.Count - 1).Cells("MS_PT1")
                Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + grdVTChon.Rows(grdVTChon.CurrentRow.Index).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
                grdChiTiet.DataSource = vew.ToTable()
            Else
                grdChiTiet.DataSource = Nothing
            End If

        End If
        AddHandler grdVTChon.RowEnter, AddressOf Me.grdVTChon_RowEnter
    End Sub

    Private Sub grdVTChon_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles grdVTChon.RowEnter
        '' View 
        grdVTChon.EndEdit()

        Try
            If grdVTChon.Rows.Count > 0 Then
                Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + grdVTChon.Rows(e.RowIndex).Cells("PTID").Value + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
                grdChiTiet.DataSource = vew.ToTable()
            Else
                grdChiTiet.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function CheckCan(ByVal vMsPT As String, ByVal vSoLuong As Integer) As Boolean

        Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + vMsPT + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
        Dim sl As Integer = 0
        For Each vrow As DataRow In vew.ToTable.Rows
            sl = sl + Integer.Parse(vrow("SO_LUONG_XUAT").ToString)
        Next
        If vSoLuong <> sl Then
            Return False
        End If

        Return True
    End Function
    Function CheckCanTon(ByVal vMsPT As String, ByVal vSoLuong As Integer) As Boolean

        Dim vew As New DataView(vChiTietVT, "PTIDCT ='" + vMsPT + "'", "MS_DH_XUAT_PT", DataViewRowState.CurrentRows)
        Dim sl As Integer = 0
        For Each vrow As DataRow In vew.ToTable.Rows
            sl = sl + Integer.Parse(vrow("CHENH_LECH").ToString)
        Next
        If vSoLuong > sl Then
            Return False
        End If

        Return True
    End Function
    Private Sub grdChiTiet_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdChiTiet.CellValidating
        Try
            If grdChiTiet.Columns(e.ColumnIndex).Name = "SO_LUONG_XUAT" Then

                If e.FormattedValue > Me.grdChiTiet.Rows(e.RowIndex).Cells("SO_LUONG_CON").Value Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_PHAI_NHO_HON_TON", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
                Dim i As Integer = 0
                For Each vrow As DataRow In vChiTietVT.Rows
                    If vrow("MS_DH_XUAT_PT") = Me.grdChiTiet.Rows(e.RowIndex).Cells("MS_DH_XUAT_PT").Value And vrow("MS_DH_NHAP_PT") = Me.grdChiTiet.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value And vrow("PTIDCT") = Me.grdChiTiet.Rows(e.RowIndex).Cells("PTIDCT").Value Then
                        vChiTietVT.Rows(i)("SO_LUONG_XUAT") = e.FormattedValue
                    End If
                    i = i + 1
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class