
Imports Microsoft.ApplicationBlocks.Data

Public Class frmAllocateChooseVTPT
    Private _MS_PHIEU_BT As String = ""
    Private _MS_MAY As String = ""
    Public Property MS_PHIEU_BT() As String
        Get
            Return _MS_PHIEU_BT
        End Get
        Set(ByVal value As String)
            _MS_PHIEU_BT = value
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

    Public Property DataAllocate() As DataTable
        Get
            Return _dataAllocate
        End Get
        Set(ByVal value As DataTable)
            _dataAllocate = value
        End Set
    End Property

    Private Sub frmAllocateChooseVTPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvListPT.AutoGenerateColumns = False
        dgvListPTChoose.AutoGenerateColumns = False
        GetData()
        CreateDataSourceForDataAllocate()

        initDataTotalAllocated()
        TongSLDuocPhanBo()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        ' btnOk.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private dataSource As New DataTable()
    Private _dataAllocate As New DataTable()

    Private Sub GetData()
        dgvListPT.Columns("clDS_MS_PT").Frozen = True
        dataSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_ALLOCATED_BY_PBT", _MS_MAY, _MS_PHIEU_BT))
        dataSource.Columns("SL_YEU_CAU").ReadOnly = False
        ' dgvListPT.DataSource = dataSource

        If _dataAllocate.Rows.Count > 0 Then
            For i As Integer = 0 To _dataAllocate.Rows.Count - 1
                For j As Integer = 0 To dataSource.Rows.Count - 1
                    If _dataAllocate.Rows(i)("MS_PT").ToString = dataSource.Rows(j)("MS_PT").ToString And _
                        _dataAllocate.Rows(i)("MS_DH_XUAT_PT").ToString = dataSource.Rows(j)("MS_DH_XUAT_PT").ToString And _
                        _dataAllocate.Rows(i)("MS_DH_NHAP_PT").ToString = dataSource.Rows(j)("MS_DH_NHAP_PT").ToString And _
                        _dataAllocate.Rows(i)("ID_XUAT").ToString = dataSource.Rows(j)("ID_XUAT").ToString And _
                        _dataAllocate.Rows(i)("ID_NHAP").ToString = dataSource.Rows(j)("ID_NHAP").ToString Then
                        dataSource.Rows(j)("SL_YEU_CAU") = _dataAllocate.Rows(i)("SL_YEU_CAU").ToString
                    End If
                Next
            Next
        End If

        Dim _dataFilter As New DataView(dataSource, "ISNULL(SL_YEU_CAU,0) = 0", "SL_YEU_CAU", DataViewRowState.CurrentRows)
        dgvListPT.DataSource = _dataFilter.ToTable().Copy()
    End Sub

    Private Sub CreateDataSourceForDataAllocate()
        Try
            If _dataAllocate.Rows.Count <= 0 Then
                ' Dim _dataChontmp As DataTable = CType(dgvListPT.DataSource, DataTable)
                Dim _dataFilter As New DataView(dataSource, "ISNULL(SL_YEU_CAU,0) <> 0", "SL_YEU_CAU", DataViewRowState.CurrentRows)
                _dataAllocate = _dataFilter.ToTable().Copy()
                'For i As Integer = 0 To _dataAllocate.Rows.Count - 1
                '    _dataAllocate.Rows(i)("SL_CANALLOCATED") = CType(_dataAllocate.Rows(i)(""), Double) + CType(_dataAllocate.Rows(i)("SL_YEU_CAU"), Double)

                'Next
                dgvListPTChoose.DataSource = _dataAllocate
            Else
                _dataAllocate.Columns("SL_YEU_CAU").ReadOnly = False
                dgvListPTChoose.DataSource = _dataAllocate
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        For i As Integer = 0 To dgvListPT.SelectedRows().Count - 1
            Dim ss As Double = Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString)
            _dataAllocate.Rows.Add(dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_XUAT_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_NHAP_PT").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_MS_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_PT").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_NCC").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_QUY_CACH").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_TEN_HSX").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_MS_KHO").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_KHO").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_TEN_MAY").Value.ToString(), _
                        Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString), _
                        Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_NHAP").Value.ToString), _
                        Boolean.Parse(dgvListPT.SelectedRows(i).Cells("clDS_VAT_TU").Value.ToString), _
                        dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_CV").Value.ToString(), _
                        dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_MAY").Value.ToString(), _
                        Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
                        0, _
                        Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_DON_GIA").Value.ToString), _
                        dgvListPT.SelectedRows(i).Cells("clDS_NGOAI_TE").Value.ToString(), _
                        Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA").Value.ToString), _
                        Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA_USD").Value.ToString))
        Next

        For i As Integer = dgvListPT.SelectedRows().Count - 1 To 0 Step -1
            dgvListPT.Rows.RemoveAt(dgvListPT.SelectedRows(i).Index)
        Next
        dgvListPT.ClearSelection()
        TongSLDuocPhanBo()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim _dtTmp As New DataTable()
        _dtTmp = CType(dgvListPT.DataSource, DataTable)

        For i As Integer = 0 To dgvListPTChoose.SelectedRows().Count - 1
            ' Dim ss As Double = Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString)
            Dim _viewTMP As New DataView(_dtTmp, "MS_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString() + _
                                         "' and MS_DH_XUAT_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString() + _
                                         "' and MS_DH_NHAP_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString() + _
                                         "' and ID_XUAT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString + _
                                         "' and ID_NHAP = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString + "' ", "", DataViewRowState.CurrentRows)
            If _viewTMP.ToTable().Rows.Count = 0 Then
                _dtTmp.Rows.Add(dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_PT").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_NCC").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_QUY_CACH").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_HSX").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_MS_KHO").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_KHO").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_MAY").Value.ToString(), _
                                     Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString), _
                                      Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString), _
                                       Boolean.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_VAT_TU").Value.ToString), _
                                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_CV").Value.ToString(), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_MAY").Value.ToString(), _
                                     Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString), _
                                     0, _
                                      Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_DON_GIA").Value.ToString), _
                                      dgvListPTChoose.SelectedRows(i).Cells("clC_NGOAI_TE").Value.ToString(), _
                                      Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA").Value.ToString), _
                                      Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA_USD").Value.ToString))
            End If

            Dim _datatmpFilter As New DataView(dataSource, "MS_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString() + _
                                               "' AND MS_DH_XUAT_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString() + _
                                               "' AND ID_XUAT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString + _
                                               "' AND MS_DH_NHAP_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString() + _
                                               "' AND ID_NHAP = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString + "'", "MS_PT", DataViewRowState.CurrentRows)
            If _datatmpFilter.ToTable().Rows.Count <= 0 Then

                dataSource.Rows.Add(dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_PT").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_NCC").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_QUY_CACH").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_HSX").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_MS_KHO").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_KHO").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_MAY").Value.ToString(), _
                                    Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString), _
                                     Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString), _
                                      Boolean.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_VAT_TU").Value.ToString), _
                                      dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_CV").Value.ToString(), _
                                    dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_MAY").Value.ToString(), _
                                    Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString), _
                                    0, _
                                     Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_DON_GIA").Value.ToString), _
                                     dgvListPTChoose.SelectedRows(i).Cells("clC_NGOAI_TE").Value.ToString(), _
                                     Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA").Value.ToString), _
                                     Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA_USD").Value.ToString))


            End If



            'Dim _isExists As 
            'For j As Integer = 0 To dataSource.Rows.Count - 1






            'Next



            '_dtTmp.Rows.Add(dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString(), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString(), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_PT").Value.ToString(), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_NCC").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_QUY_CACH").Value.ToString(), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_KHO").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_MAY").Value.ToString(), _
            '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SO_LUONG_THU_XUAT").Value.ToString()), _
            '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_ALLOCATED").Value.ToString), _
            '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString), _
            '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_YEU_CAU").Value.ToString), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_CV").Value.ToString(), _
            '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_MAY").Value.ToString(), "N", _
            '                        Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString), _
            '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_DON_GIA").Value.ToString), _
            '                        dgvListPTChoose.SelectedRows(i).Cells("clC_NGOAI_TE").Value.ToString(), _
            '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA").Value.ToString), _
            '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA_USD").Value.ToString))
        Next

        For i As Integer = dgvListPTChoose.SelectedRows().Count - 1 To 0 Step -1
            dgvListPTChoose.Rows.RemoveAt(dgvListPTChoose.SelectedRows(i).Index)
        Next
        dgvListPTChoose.ClearSelection()
        TongSLDuocPhanBo()
    End Sub

    Private Sub dgvListPT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListPT.CellContentClick

    End Sub

    'Private Sub chLocTheoMay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If (chLocTheoMay.Checked = True And chLocTheoPBT.Checked = True) Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_CV,'') <> '' AND ISNULL(MS_PT_MAY,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf (chLocTheoMay.Checked = True And chLocTheoPBT.Checked = False) Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_MAY,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf chLocTheoMay.Checked = False And chLocTheoPBT.Checked = True Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_CV,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf chLocTheoMay.Checked = False And chLocTheoPBT.Checked = False Then
    '        dgvListPT.DataSource = dataSource
    '    End If

    'End Sub

    'Private Sub chLocTheoPBT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If (chLocTheoMay.Checked = True And chLocTheoPBT.Checked = True) Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_CV,'') <> '' AND ISNULL(MS_PT_MAY,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf (chLocTheoMay.Checked = True And chLocTheoPBT.Checked = False) Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_MAY,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf chLocTheoMay.Checked = False And chLocTheoPBT.Checked = True Then
    '        Dim _dataFilter As New DataView(dataSource, "ISNULL(MS_PT_CV,'') <> ''", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '        dgvListPT.DataSource = _dataFilter.ToTable()
    '    ElseIf chLocTheoMay.Checked = False And chLocTheoPBT.Checked = False Then
    '        dgvListPT.DataSource = dataSource
    '    End If
    '    removeRowSelected()
    'End Sub

    Private Sub removeRowSelected()
        For i As Integer = dgvListPTChoose.Rows.Count - 1 To 0 Step -1
            For j As Integer = dgvListPT.Rows.Count - 1 To 0 Step -1
                If dgvListPTChoose.Rows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_DH_XUAT_PT").Value.ToString() And _
                dgvListPTChoose.Rows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_DH_NHAP_PT").Value.ToString() And _
                dgvListPTChoose.Rows(i).Cells("clC_MS_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_PT").Value.ToString() And _
                dgvListPTChoose.Rows(i).Cells("clC_ID_XUAT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_ID_XUAT").Value.ToString() And _
                dgvListPTChoose.Rows(i).Cells("clC_ID_NHAP").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_ID_NHAP").Value.ToString() Then
                    dgvListPT.Rows.RemoveAt(j)
                End If
            Next
        Next

    End Sub


    Private Sub btnAddSL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSL.Click
        For i As Integer = 0 To dgvListPT.SelectedRows().Count - 1
            Dim ss As Integer = Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString)
            _dataAllocate.Rows.Add(dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_XUAT_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_NHAP_PT").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_MS_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_PT").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_NCC").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_QUY_CACH").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_TEN_HSX").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_MS_KHO").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_KHO").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_TEN_MAY").Value.ToString(), _
                                   Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString), _
                                    Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_NHAP").Value.ToString), _
                                     Boolean.Parse(dgvListPT.SelectedRows(i).Cells("clDS_VAT_TU").Value.ToString), _
                                     dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_CV").Value.ToString(), _
                                   dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_MAY").Value.ToString(), _
                                   Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
                                   Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
                                    Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_DON_GIA").Value.ToString), _
                                    dgvListPT.SelectedRows(i).Cells("clDS_NGOAI_TE").Value.ToString(), _
                                    Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA").Value.ToString), _
                                    Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA_USD").Value.ToString))
        Next

        For i As Integer = dgvListPT.SelectedRows().Count - 1 To 0 Step -1
            dgvListPT.Rows.RemoveAt(dgvListPT.SelectedRows(i).Index)
        Next
        dgvListPT.ClearSelection()
        TongSLDuocPhanBo()
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If CheckData() = True Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        DataAllocate = CType(dgvListPTChoose.DataSource, DataTable)
    End Sub
    Private Function CheckData() As Boolean
        Dim _result As Boolean = True

        If dgvListPTChoose.Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaChonVTPT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
        'Dim _dttmp As New DataTable
        '_dttmp = CType(dgvListPTChoose.DataSource, DataTable)
        For i As Integer = 0 To dgvListPTChoose.Rows.Count - 1
            Dim _outSL_YEU_CAU As Double = 0
            Dim _slDap_ung As Double = 0
            If Double.TryParse(dgvListPTChoose.Rows(i).Cells("clC_SL_YEU_CAU").Value.ToString(), _outSL_YEU_CAU) Then
                'Sl yeu cau phai lon hon 0
                If _outSL_YEU_CAU <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_YEU_CAU_PHAI_LON_HON_0", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgvListPTChoose.CurrentCell = dgvListPTChoose.Rows(i).Cells("clC_SL_YEU_CAU")
                    Return False
                End If
                'sl yeu cau phai nho hon = sl dap ung
                Double.TryParse(dgvListPTChoose.Rows(i).Cells("clC_SL_AVAILABLE").Value.ToString(), _slDap_ung)

                If (_slDap_ung < _outSL_YEU_CAU) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_YEU_CAU_PHAI_LON_HON_SL_DAP_UNG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgvListPTChoose.CurrentCell = dgvListPTChoose.Rows(i).Cells("clC_SL_YEU_CAU")
                    Return False
                End If

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_YEU_CAU_PHAI_LON_HON_0", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dgvListPTChoose.CurrentCell = dgvListPTChoose.Rows(i).Cells("clC_SL_YEU_CAU")
                Return False
            End If
        Next

        Return _result
    End Function
    Private DataTotalAllocated As New DataTable
    Private Sub initDataTotalAllocated()
        Try
            DataTotalAllocated.Columns.Add("MS_PT", Type.GetType("System.String"))
            DataTotalAllocated.Columns.Add("TEN_PT", Type.GetType("System.String"))
            DataTotalAllocated.Columns.Add("SO_LUONG", Type.GetType("System.Double"))
            dgvListTotal.DataSource = DataTotalAllocated
        Catch ex As Exception
        End Try

    End Sub


    Private Sub TongSLDuocPhanBo()
        Try
            DataTotalAllocated.Rows.Clear()
            Dim _datatmp As New DataTable()
            _datatmp = CType(dgvListPTChoose.DataSource, DataTable)
            _datatmp.AcceptChanges()
            Dim _dtDistinct As New DataTable
            _dtDistinct = _datatmp.DefaultView.ToTable(True, "MS_PT")

            For i As Integer = 0 To _dtDistinct.Rows.Count - 1
                Dim _totalSL As Double = 0
                Dim _ten_Pt As String = ""
                For j As Integer = 0 To _datatmp.Rows.Count - 1
                    If _dtDistinct.Rows(i)("MS_PT").ToString = _datatmp.Rows(j)("MS_PT").ToString Then
                        Dim _sl As Double
                        Double.TryParse(_datatmp.Rows(j)("SL_YEU_CAU").ToString, _sl)
                        _totalSL = _totalSL + _sl
                        _ten_Pt = _datatmp.Rows(j)("TEN_PT").ToString
                    End If
                Next
                DataTotalAllocated.Rows.Add(_dtDistinct.Rows(i)("MS_PT").ToString, _ten_Pt, _totalSL)
            Next
            dgvListTotal.DataSource = DataTotalAllocated
        Catch ex As Exception
        End Try
    End Sub

    Private _slbeginEdit As Double = 0
    Private _slEndEdit As Double = 0

    Private Sub dgvListPTChoose_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvListPTChoose.CellBeginEdit
        If dgvListPTChoose.Columns(e.ColumnIndex).Name = "clC_SL_YEU_CAU" Then
            _slbeginEdit = 0
            Double.TryParse(dgvListPTChoose.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, _slbeginEdit)
        End If
    End Sub

    Private Sub dgvListPTChoose_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListPTChoose.CellEndEdit
        If dgvListPTChoose.Columns(e.ColumnIndex).Name = "clC_SL_YEU_CAU" Then
            _slEndEdit = 0
            Double.TryParse(dgvListPTChoose.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, _slEndEdit)

            If _slbeginEdit <> _slEndEdit Then
                TongSLDuocPhanBo()
            End If
        End If
    End Sub

    Dim ColumnSort As DataGridViewColumn
    Dim ColumnSortMod As System.ComponentModel.ListSortDirection
    Private Sub dgvListPT_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvListPT.Sorted
        Dim _ColumnSort As DataGridViewColumn = dgvListPT.SortedColumn
        lbTitle.Text = _ColumnSort.HeaderText.ToString
        ColumnSort = _ColumnSort
        ColumnSortMod = dgvListPT.SortOrder
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColumnSort.HeaderText.ToString <> "" Then
            Dim _dataFilter As New DataView(dataSource, "ISNULL(" + ColumnSort.DataPropertyName + ",'') like '%" + TxtSearch.Text.ToString.Trim() + "%'", "MS_PT", DataViewRowState.CurrentRows)
            dgvListPT.DataSource = _dataFilter.ToTable()

            If ColumnSortMod = System.ComponentModel.ListSortDirection.Ascending Then
                dgvListPT.Sort(ColumnSort, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvListPT.Sort(ColumnSort, System.ComponentModel.ListSortDirection.Descending)
            End If

        End If
    End Sub
End Class