
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAllocateVTPTForBPCP

    Private _DSPX As New DataTable
    Private _BPCP As Integer = -1
    Private _KHO As Integer = -1
    Private _FROMDATE As DateTime
    Private _TODATE As DateTime

    Private Sub LoadDataPXForBPCP()
        Try
            _BPCP = cbBPCPtab1.SelectedValue
            _KHO = cbKhoTab1.SelectedValue
            _FROMDATE = dtpFromdatetab1.Value
            _TODATE = dtpTodateTab1.Value

            _DSPX = New DataTable()
            _DSPX.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_PB_PBCP_GETDATA", _BPCP, _KHO, _FROMDATE, _TODATE))
            dgvListPXTab1.DataSource = _DSPX
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadSourceBPCP()
        Dim _dataBPCP As New DataTable
        _dataBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI"))
        cbxBPCP.DataSource = _dataBPCP
        cbxBPCP.DisplayMember = "TEN_BP_CHIU_PHI"
        cbxBPCP.ValueMember = "MS_BP_CHIU_PHI"
    End Sub
    Private Sub LoadSourceKhoTab1()
        Dim _dataKho As New DataTable
        _dataKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT '-1' AS MS_KHO , 'ALL' AS TEN_KHO UNION  SELECT MS_KHO , TEN_KHO FROM IC_KHO ORDER BY MS_KHO"))
        cbKhoTab1.DataSource = _dataKho
        cbKhoTab1.DisplayMember = "TEN_KHO"
        cbKhoTab1.ValueMember = "MS_KHO"
    End Sub
    Private Sub LoadSourceBPCPTab1()
        Dim _dataPBCPTab1 As New DataTable
        _dataPBCPTab1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT '-1' AS MS_BP_CHIU_PHI , 'ALL' AS TEN_BP_CHIU_PHI UNION  SELECT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI ORDER BY MS_BP_CHIU_PHI"))
        cbBPCPtab1.DataSource = _dataPBCPTab1
        cbBPCPtab1.DisplayMember = "TEN_BP_CHIU_PHI"
        cbBPCPtab1.ValueMember = "MS_BP_CHIU_PHI"

    End Sub

    Private Sub frmAllocateVTPTForBPCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemoveHandler cbBPCPtab1.SelectedIndexChanged, AddressOf cbBPCPtab1_SelectedIndexChanged
        RemoveHandler cbKhoTab1.SelectedIndexChanged, AddressOf cbKhoTab1_SelectedIndexChanged
        RemoveHandler dtpFromdatetab1.ValueChanged, AddressOf dtpFromdatetab1_ValueChanged
        RemoveHandler dtpTodateTab1.ValueChanged, AddressOf dtpTodateTab1_ValueChanged

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnXoa.Enabled = False
            btnThem.Enabled = False
            btnSua.Enabled = False
            btnGhi.Enabled = False
            btnKhongGhi.Enabled = False
        End If

        _FROMDATE = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date
        dtpFromdatetab1.Value = _FROMDATE
        _TODATE = DateTime.Now.Date

        LoadSourceBPCPTab1()
        LoadSourceKhoTab1()
        LoadSourceBPCP()
        LoadDataPXForBPCP()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        AddHandler cbBPCPtab1.SelectedIndexChanged, AddressOf cbBPCPtab1_SelectedIndexChanged
        AddHandler cbKhoTab1.SelectedIndexChanged, AddressOf cbKhoTab1_SelectedIndexChanged
        AddHandler dtpFromdatetab1.ValueChanged, AddressOf dtpFromdatetab1_ValueChanged
        AddHandler dtpTodateTab1.ValueChanged, AddressOf dtpTodateTab1_ValueChanged



        'dgvListPT.AutoGenerateColumns = False
        'dgvListPTChoose.AutoGenerateColumns = False
        'GetData()
        'CreateDataSourceForDataAllocate()

        'initDataTotalAllocated()
        'TongSLDuocPhanBo()
        ' btnOk.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    'Private dataSource As New DataTable()
    'Private _dataAllocate As New DataTable()

    'Private Sub GetData()

    '    'dgvListPT.Columns("clDS_MS_PT").Frozen = True
    '    dataSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_ALLOCATED_BY_PBT", _MS_MAY, _MS_PHIEU_BT))
    '    dataSource.Columns("SL_YEU_CAU").ReadOnly = False
    '    ' dgvListPT.DataSource = dataSource

    '    If _dataAllocate.Rows.Count > 0 Then
    '        For i As Integer = 0 To _dataAllocate.Rows.Count - 1
    '            For j As Integer = 0 To dataSource.Rows.Count - 1
    '                If _dataAllocate.Rows(i)("MS_PT").ToString = dataSource.Rows(j)("MS_PT").ToString And _
    '                _dataAllocate.Rows(i)("MS_DH_XUAT_PT").ToString = dataSource.Rows(j)("MS_DH_XUAT_PT").ToString And _
    '                _dataAllocate.Rows(i)("MS_DH_NHAP_PT").ToString = dataSource.Rows(j)("MS_DH_NHAP_PT").ToString And _
    '                 _dataAllocate.Rows(i)("ID_XUAT").ToString = dataSource.Rows(j)("ID_XUAT").ToString And _
    '                 _dataAllocate.Rows(i)("ID_NHAP").ToString = dataSource.Rows(j)("ID_NHAP").ToString Then
    '                    dataSource.Rows(j)("SL_YEU_CAU") = _dataAllocate.Rows(i)("SL_YEU_CAU").ToString
    '                End If

    '            Next
    '        Next
    '    End If


    '    Dim _dataFilter As New DataView(dataSource, "ISNULL(SL_YEU_CAU,0) = 0", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '    'dgvListPT.DataSource = _dataFilter.ToTable().Copy()



    'End Sub

    'Private Sub CreateDataSourceForDataAllocate()
    '    Try
    '        If _dataAllocate.Rows.Count <= 0 Then
    '            ' Dim _dataChontmp As DataTable = CType(dgvListPT.DataSource, DataTable)
    '            Dim _dataFilter As New DataView(dataSource, "ISNULL(SL_YEU_CAU,0) <> 0", "SL_YEU_CAU", DataViewRowState.CurrentRows)
    '            _dataAllocate = _dataFilter.ToTable().Copy()
    '            'For i As Integer = 0 To _dataAllocate.Rows.Count - 1
    '            '    _dataAllocate.Rows(i)("SL_CANALLOCATED") = CType(_dataAllocate.Rows(i)(""), Double) + CType(_dataAllocate.Rows(i)("SL_YEU_CAU"), Double)

    '            'Next
    '            dgvListPTChoose.DataSource = _dataAllocate
    '        Else
    '            _dataAllocate.Columns("SL_YEU_CAU").ReadOnly = False
    '            dgvListPTChoose.DataSource = _dataAllocate
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'For i As Integer = 0 To dgvListPT.SelectedRows().Count - 1
        '    Dim ss As Double = Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString)
        '    _dataAllocate.Rows.Add(dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_XUAT_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_NHAP_PT").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_MS_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_PT").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_NCC").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_QUY_CACH").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_TEN_HSX").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_MS_KHO").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_KHO").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_TEN_MAY").Value.ToString(), _
        '                          Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString), _
        '                           Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_NHAP").Value.ToString), _
        '                            Boolean.Parse(dgvListPT.SelectedRows(i).Cells("clDS_VAT_TU").Value.ToString), _
        '                            dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_CV").Value.ToString(), _
        '                          dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_MAY").Value.ToString(), _
        '                          Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
        '                          0, _
        '                           Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_DON_GIA").Value.ToString), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_NGOAI_TE").Value.ToString(), _
        '                           Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA").Value.ToString), _
        '                           Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA_USD").Value.ToString))

        '    '_dataAllocate.Rows.Add(dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_XUAT_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_NHAP_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_NCC").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_QUY_CACH").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_KHO").Value.ToString(), _
        '    '                       dgvListPT.SelectedRows(i).Cells("clDS_TEN_MAY").Value.ToString(), Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SO_LUONG_THU_XUAT").Value.ToString()), Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_ALLOCATED").Value.ToString), Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
        '    '                       Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_YEU_CAU").Value.ToString), dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_CV").Value.ToString(), _
        '    '                       dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_MAY").Value.ToString(), "Y", _
        '    '                       Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString()), _
        '    '                       Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_DON_GIA").Value.ToString()), _
        '    '                       dgvListPT.SelectedRows(i).Cells("clDS_NGOAI_TE").Value.ToString(), _
        '    '                       Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA").Value.ToString()), _
        '    '                       Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA_USD").Value.ToString()))

        'Next

        'For i As Integer = dgvListPT.SelectedRows().Count - 1 To 0 Step -1
        '    dgvListPT.Rows.RemoveAt(dgvListPT.SelectedRows(i).Index)
        'Next
        'dgvListPT.ClearSelection()
        'TongSLDuocPhanBo()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim _dtTmp As New DataTable()
        '_dtTmp = CType(dgvListPT.DataSource, DataTable)

        'For i As Integer = 0 To dgvListPTChoose.SelectedRows().Count - 1
        '    ' Dim ss As Double = Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString)
        '    Dim _viewTMP As New DataView(_dtTmp, "MS_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString() + _
        '                                 "' and MS_DH_XUAT_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString() + _
        '                                 "' and MS_DH_NHAP_PT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString() + _
        '                                 "' and ID_XUAT = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString + _
        '                                 "' and ID_NHAP = '" + dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString + "' ", "", DataViewRowState.CurrentRows)
        '    If _viewTMP.ToTable().Rows.Count = 0 Then
        '        _dtTmp.Rows.Add(dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_PT").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_NCC").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_QUY_CACH").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_HSX").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_MS_KHO").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_KHO").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_MAY").Value.ToString(), _
        '                             Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString), _
        '                              Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_NHAP").Value.ToString), _
        '                               Boolean.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_VAT_TU").Value.ToString), _
        '                               dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_CV").Value.ToString(), _
        '                             dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_MAY").Value.ToString(), _
        '                             Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString), _
        '                             0, _
        '                              Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_DON_GIA").Value.ToString), _
        '                              dgvListPTChoose.SelectedRows(i).Cells("clC_NGOAI_TE").Value.ToString(), _
        '                              Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA").Value.ToString), _
        '                              Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA_USD").Value.ToString))
        '    End If
        '    '_dtTmp.Rows.Add(dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString(), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString(), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_PT").Value.ToString(), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_NCC").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_QUY_CACH").Value.ToString(), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_KHO").Value.ToString(), dgvListPTChoose.SelectedRows(i).Cells("clC_TEN_MAY").Value.ToString(), _
        '    '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SO_LUONG_THU_XUAT").Value.ToString()), _
        '    '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_ALLOCATED").Value.ToString), _
        '    '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_AVAILABLE").Value.ToString), _
        '    '                       Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_SL_YEU_CAU").Value.ToString), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_CV").Value.ToString(), _
        '    '                       dgvListPTChoose.SelectedRows(i).Cells("clC_MS_PT_MAY").Value.ToString(), "N", _
        '    '                        Integer.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_ID_XUAT").Value.ToString), _
        '    '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_DON_GIA").Value.ToString), _
        '    '                        dgvListPTChoose.SelectedRows(i).Cells("clC_NGOAI_TE").Value.ToString(), _
        '    '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA").Value.ToString), _
        '    '                        Double.Parse(dgvListPTChoose.SelectedRows(i).Cells("clC_TY_GIA_USD").Value.ToString))
        'Next

        'For i As Integer = dgvListPTChoose.SelectedRows().Count - 1 To 0 Step -1
        '    dgvListPTChoose.Rows.RemoveAt(dgvListPTChoose.SelectedRows(i).Index)
        'Next
        'dgvListPTChoose.ClearSelection()
        'TongSLDuocPhanBo()
    End Sub

    Private Sub dgvListPT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

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
        'For i As Integer = dgvListPTChoose.Rows.Count - 1 To 0 Step -1
        '    For j As Integer = dgvListPT.Rows.Count - 1 To 0 Step -1
        '        If dgvListPTChoose.Rows(i).Cells("clC_MS_DH_XUAT_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_DH_XUAT_PT").Value.ToString() And _
        '        dgvListPTChoose.Rows(i).Cells("clC_MS_DH_NHAP_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_DH_NHAP_PT").Value.ToString() And _
        '        dgvListPTChoose.Rows(i).Cells("clC_MS_PT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_MS_PT").Value.ToString() And _
        '        dgvListPTChoose.Rows(i).Cells("clC_ID_XUAT").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_ID_XUAT").Value.ToString() And _
        '        dgvListPTChoose.Rows(i).Cells("clC_ID_NHAP").Value.ToString() = dgvListPT.Rows(j).Cells("clDS_ID_NHAP").Value.ToString() Then
        '            dgvListPT.Rows.RemoveAt(j)
        '        End If
        '    Next
        'Next

    End Sub


    Private Sub btnAddSL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For i As Integer = 0 To dgvListPT.SelectedRows().Count - 1
        '    Dim ss As Integer = Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString)
        '    _dataAllocate.Rows.Add(dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_XUAT_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_MS_DH_NHAP_PT").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_MS_PT").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_PT").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_NCC").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_QUY_CACH").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_TEN_HSX").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_MS_KHO").Value.ToString(), dgvListPT.SelectedRows(i).Cells("clDS_TEN_KHO").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_TEN_MAY").Value.ToString(), _
        '                           Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_XUAT").Value.ToString), _
        '                            Integer.Parse(dgvListPT.SelectedRows(i).Cells("clDS_ID_NHAP").Value.ToString), _
        '                             Boolean.Parse(dgvListPT.SelectedRows(i).Cells("clDS_VAT_TU").Value.ToString), _
        '                             dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_CV").Value.ToString(), _
        '                           dgvListPT.SelectedRows(i).Cells("clDS_MS_PT_MAY").Value.ToString(), _
        '                           Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
        '                           Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_SL_AVAILABLE").Value.ToString), _
        '                            Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_DON_GIA").Value.ToString), _
        '                            dgvListPT.SelectedRows(i).Cells("clDS_NGOAI_TE").Value.ToString(), _
        '                            Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA").Value.ToString), _
        '                            Double.Parse(dgvListPT.SelectedRows(i).Cells("clDS_TY_GIA_USD").Value.ToString))
        'Next

        'For i As Integer = dgvListPT.SelectedRows().Count - 1 To 0 Step -1
        '    dgvListPT.Rows.RemoveAt(dgvListPT.SelectedRows(i).Index)
        'Next
        'dgvListPT.ClearSelection()
        'TongSLDuocPhanBo()
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If CheckData() = True Then
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'End If
        'DataAllocate = CType(dgvListPTChoose.DataSource, DataTable)
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
        'Try
        '    DataTotalAllocated.Columns.Add("MS_PT", Type.GetType("System.String"))
        '    DataTotalAllocated.Columns.Add("TEN_PT", Type.GetType("System.String"))
        '    DataTotalAllocated.Columns.Add("SO_LUONG", Type.GetType("System.Double"))
        '    dgvListTotal.DataSource = DataTotalAllocated

        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub TongSLDuocPhanBo()
        'Try
        '    DataTotalAllocated.Rows.Clear()

        '    Dim _datatmp As New DataTable()
        '    _datatmp = CType(dgvListPTChoose.DataSource, DataTable)
        '    _datatmp.AcceptChanges()
        '    Dim _dtDistinct As New DataTable
        '    _dtDistinct = _datatmp.DefaultView.ToTable(True, "MS_PT")

        '    For i As Integer = 0 To _dtDistinct.Rows.Count - 1
        '        Dim _totalSL As Double = 0
        '        Dim _ten_Pt As String = ""
        '        For j As Integer = 0 To _datatmp.Rows.Count - 1
        '            If _dtDistinct.Rows(i)("MS_PT").ToString = _datatmp.Rows(j)("MS_PT").ToString Then
        '                Dim _sl As Double
        '                Double.TryParse(_datatmp.Rows(j)("SL_YEU_CAU").ToString, _sl)
        '                _totalSL = _totalSL + _sl
        '                _ten_Pt = _datatmp.Rows(j)("TEN_PT").ToString
        '            End If
        '        Next
        '        DataTotalAllocated.Rows.Add(_dtDistinct.Rows(i)("MS_PT").ToString, _ten_Pt, _totalSL)
        '    Next
        '    dgvListTotal.DataSource = DataTotalAllocated
        'Catch ex As Exception
        'End Try
    End Sub

    Private _slbeginEdit As Double = 0
    Private _slEndEdit As Double = 0

    Private Sub dgvListPTChoose_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If dgvListPTChoose.Columns(e.ColumnIndex).Name = "clC_SL_YEU_CAU" Then
            _slbeginEdit = 0
            Double.TryParse(dgvListPTChoose.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, _slbeginEdit)
        End If
    End Sub

    Private Sub dgvListPTChoose_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvListPTChoose.Columns(e.ColumnIndex).Name = "clC_SL_YEU_CAU" Then
            _slEndEdit = 0
            Double.TryParse(dgvListPTChoose.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, _slEndEdit)

            If _slbeginEdit <> _slEndEdit Then
                TongSLDuocPhanBo()
            End If
        End If
    End Sub

    Private Sub cbBPCPtab1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBPCPtab1.SelectedIndexChanged
        LoadDataPXForBPCP()
    End Sub

    Private Sub cbKhoTab1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKhoTab1.SelectedIndexChanged
        LoadDataPXForBPCP()
    End Sub

    Private Sub dtpFromdatetab1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromdatetab1.ValueChanged
        LoadDataPXForBPCP()
    End Sub

    Private Sub dtpTodateTab1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTodateTab1.ValueChanged
        LoadDataPXForBPCP()
    End Sub

#Region "TabAllocated"

#End Region
    Private _PXSelected As String = ""
    Private _Status As String = "V"
    Private _DataAllocatedVTPT As New DataTable()
    Private _DataPhieuXuat As New DataTable()

    Private Sub GetPhieuXuatSelect()
        If dgvListPXTab1.SelectedRows().Count > 0 Then
            _PXSelected = dgvListPXTab1.SelectedRows(0).Cells("clMS_DH_XUAT_PT").Value.ToString
        Else
            _PXSelected = ""
        End If

        _DataAllocatedVTPT = New DataTable()
        _DataAllocatedVTPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_ALLOCATED_FOR_PBT", "", _PXSelected))
        dgvListPTChoose.DataSource = _DataAllocatedVTPT


        _DataPhieuXuat = New DataTable()
        _DataPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_DH_XUAT_PT, MS_KHO, MS_BP_CHIU_PHI FROM dbo.IC_DON_HANG_XUAT WHERE MS_DH_XUAT_PT = '" + _PXSelected + "'"))

        If _DataPhieuXuat.Rows.Count > 0 Then
            cbxBPCP.SelectedValue = _DataPhieuXuat.Rows(0)("MS_BP_CHIU_PHI")
            txtPhieuXuat.Text = _DataPhieuXuat.Rows(0)("MS_DH_XUAT_PT").ToString
        End If

        ' cbxBPCP.DataBindings(

    End Sub
    Private Sub LockAllocated()
        If _Status = "V" Then
            If _PXSelected.Trim.ToString() = "" Then
                btnSua.Enabled = False
            Else
                btnSua.Enabled = True
            End If
            cbxBPCP.Enabled = False
            btnThem.Enabled = True
            btnGhi.Enabled = False
            btnKhongGhi.Enabled = False
            btnChonVTPT.Enabled = False

        ElseIf _Status = "A" Or _Status = "E" Then

            cbxBPCP.Enabled = True
            btnThem.Enabled = False
            btnSua.Enabled = False
            btnGhi.Enabled = True
            btnKhongGhi.Enabled = True
            btnChonVTPT.Enabled = True
        End If
    End Sub
    Private Function ISCreatePieuNHAP_auto() As Boolean
        Dim _dataOld As New DataTable()
        _dataOld.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_TO_CHECK_ALLOCATED_VTPT_PBT", _PXSelected))
        Dim _equal As Boolean = False

        If _DataAllocatedVTPT.Rows.Count <> _dataOld.Rows.Count Then
            Return True
        End If

        For i As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
            _equal = False
            For j As Integer = 0 To _dataOld.Rows.Count - 1
                If _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString = _dataOld.Rows(j)("MS_DH_XUAT_PT").ToString And _
                _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString = _dataOld.Rows(j)("MS_DH_NHAP_PT").ToString And _
                _DataAllocatedVTPT.Rows(i)("ID_NHAP").ToString = _dataOld.Rows(j)("ROW_ID_NHAP").ToString And _
                _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString = _dataOld.Rows(j)("ROW_ID_XUAT").ToString And _
                _DataAllocatedVTPT.Rows(i)("MS_PT").ToString = _dataOld.Rows(j)("MS_PT").ToString And _
                _DataAllocatedVTPT.Rows(i)("SL_YEU_CAU").ToString = _dataOld.Rows(j)("SL_VT").ToString Then
                    _equal = True
                End If
            Next
            If _equal = False Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub TabPB_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabPB.Selected
        If e.TabPage.Name = "TabPB_BPCP" Then
            GetPhieuXuatSelect()
            LockAllocated()
        End If
    End Sub

    Private Sub TabPB_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabPB.Selecting
        If _Status = "A" Or _Status = "E" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        _Status = "A"
        cbxBPCP.Enabled = True
        _DataAllocatedVTPT.Rows.Clear()
        txtPhieuXuat.Text = ""
        LockAllocated()
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        _Status = "E"
        LockAllocated()
    End Sub


    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click

        If _Status = "A" Then
            _PXSelected = "PXAllocatedTMP" + Commons.Modules.UserName
        ElseIf _Status = "E" Then
            _PXSelected = txtPhieuXuat.Text.Trim
        End If
        If ISCreatePieuNHAP_auto() = True Then

            Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
            scon.Open()
            Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
            Try

                'xoa du lieu cu 

                Dim commanddel As SqlCommand = scon.CreateCommand()
                commanddel.Connection = scon
                commanddel.CommandTimeout = 9999
                commanddel.Transaction = sqlTrans
                commanddel.CommandType = CommandType.Text
                commanddel.CommandText = "Delete SYN_TB_ALLOCATION_VTPT_FOR_PBT where MS_PHIEU_BT = '" + _PXSelected + "'"
                commanddel.ExecuteNonQuery()

                Dim commandDeletePX As SqlCommand = scon.CreateCommand()
                commandDeletePX.Connection = scon
                commandDeletePX.CommandTimeout = 9999
                commandDeletePX.Transaction = sqlTrans
                commandDeletePX.CommandType = CommandType.StoredProcedure
                commandDeletePX.CommandText = "INTEGRATION_DELETE_XUAT_PB_BPCP"
                commandDeletePX.Parameters.Add("@MS_DH_XUAT_PT", SqlDbType.NVarChar)
                commandDeletePX.Parameters("@MS_DH_XUAT_PT").Value = _PXSelected
                commandDeletePX.ExecuteNonQuery()


                'Them du lieu vao Allocated
                For i As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
                    Dim command As SqlCommand = scon.CreateCommand()
                    command.Connection = scon
                    command.CommandTimeout = 9999
                    command.Transaction = sqlTrans
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandText = "INTEGRATION_SYN_TB_ALLOCATION_VTPT_FOR_PBT_INSERT"

                    command.Parameters.Add("@MS_DH_XUAT_PT", SqlDbType.NVarChar)
                    command.Parameters("@MS_DH_XUAT_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString()

                    command.Parameters.Add("@ROW_ID_XUAT", SqlDbType.BigInt)
                    command.Parameters("@ROW_ID_XUAT").Value = _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString()

                    command.Parameters.Add("@MS_PT", SqlDbType.NVarChar)
                    command.Parameters("@MS_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_PT").ToString()

                    command.Parameters.Add("@MS_DH_NHAP_PT", SqlDbType.NVarChar)
                    command.Parameters("@MS_DH_NHAP_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString()

                    command.Parameters.Add("@ROW_ID_NHAP", SqlDbType.BigInt)
                    command.Parameters("@ROW_ID_NHAP").Value = _DataAllocatedVTPT.Rows(i)("ID_NHAP").ToString()

                    command.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
                    command.Parameters("@MS_PHIEU_BT").Value = _PXSelected

                    command.Parameters.Add("@SO_LUONG_PHAN_BO", SqlDbType.Float)
                    command.Parameters("@SO_LUONG_PHAN_BO").Value = _DataAllocatedVTPT.Rows(i)("SL_YEU_CAU").ToString()
                    command.ExecuteNonQuery()
                Next

                'sqlTrans.Commit()
                'scon.Close()
                'Exit Sub

                'Ktra so luong
                Dim commandcheck As SqlCommand = scon.CreateCommand()
                commandcheck.Connection = scon
                commandcheck.CommandTimeout = 9999
                commandcheck.Transaction = sqlTrans
                commandcheck.CommandType = CommandType.StoredProcedure
                commandcheck.CommandText = "INTEGRATION_CHECK_SO_LUONG_ALLOCATED_PBT"
                'commandcheck.ExecuteNonQuery()
                commandcheck.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
                commandcheck.Parameters("@MS_PHIEU_BT").Value = _PXSelected

                Dim da As New SqlDataAdapter(commandcheck)
                Dim ds As New DataSet()
                da.Fill(ds)

                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DA_PB_DU_SL_KTRA_LAI", Commons.Modules.TypeLanguage))
                    sqlTrans.Rollback()
                    scon.Close()
                    Exit Sub
                End If

                'Tao phieu nhap phieu xuat

                Dim commandCreateNX As SqlCommand = scon.CreateCommand()
                commandCreateNX.Connection = scon
                commandCreateNX.CommandTimeout = 9999
                commandCreateNX.Transaction = sqlTrans
                commandCreateNX.CommandType = CommandType.StoredProcedure
                commandCreateNX.CommandText = "INTEGRATION_CREATE_PHIEU_NHAP_XUAT_FOR_BPCP_AUTO"
                commandCreateNX.Parameters.Add("@MS_PHIEU_XUAT", SqlDbType.NVarChar)
                commandCreateNX.Parameters("@MS_PHIEU_XUAT").Value = _PXSelected
                commandCreateNX.Parameters.Add("@MS_BP_CHIU_PHI", SqlDbType.Int)
                commandCreateNX.Parameters("@MS_BP_CHIU_PHI").Value = cbxBPCP.SelectedValue.ToString

                commandCreateNX.ExecuteNonQuery()

                sqlTrans.Commit()
                scon.Close()
            Catch
                sqlTrans.Rollback()
                scon.Close()
            End Try


            _Status = "V"
            LockAllocated()
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_CONG", Commons.Modules.TypeLanguage))

            cbBPCPtab1.SelectedValue = cbxBPCP.SelectedValue
            dtpTodateTab1.Value = Now
            LoadDataPXForBPCP()
            TabPB.SelectedIndex = 0
        Else
            _Status = "V"
            LockAllocated()
        End If

    End Sub

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        If _Status = "A" Then
            GetPhieuXuatSelect()
        End If
        If _Status = "E" Then
            GetPhieuXuatSelect()
        End If

        _Status = "V"
        LockAllocated()
    End Sub

    Private Sub btnChonVTPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonVTPT.Click
        Dim frm As New frmAllocateChooseVTPT
        frm.DataAllocate = _DataAllocatedVTPT
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _DataAllocatedVTPT = frm.DataAllocate
            dgvListPTChoose.DataSource = _DataAllocatedVTPT
            'XoaSL_Allocated_PT_notin_DTAllocated()
            'AllocatePTAfterChoose()
            '' CreateDataGridViewVTAllocated()
            'AllocateVTAfterChoose()
        End If
    End Sub

    Private Sub btnThoat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat2.Click
        Me.Close()
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click

        If dgvListPXTab1.SelectedRows().Count <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_PHIEU_DE_XOA", Commons.Modules.TypeLanguage))
            Exit Sub
        Else
            _PXSelected = dgvListPXTab1.SelectedRows()(0).Cells("clMS_DH_XUAT_PT").Value
        End If


        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHAC_MUON_XOAT_KO", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
            scon.Open()
            Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
            Try
                Dim commandDeletePX As SqlCommand = scon.CreateCommand()
                commandDeletePX.Connection = scon
                commandDeletePX.CommandTimeout = 9999
                commandDeletePX.Transaction = sqlTrans
                commandDeletePX.CommandType = CommandType.StoredProcedure
                commandDeletePX.CommandText = "INTEGRATION_DELETE_XUAT_PB_BPCP"
                commandDeletePX.Parameters.Add("@MS_DH_XUAT_PT", SqlDbType.NVarChar)
                commandDeletePX.Parameters("@MS_DH_XUAT_PT").Value = _PXSelected
                commandDeletePX.ExecuteNonQuery()
                sqlTrans.Commit()
                scon.Close()

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XOA_THANH_CONG", Commons.Modules.TypeLanguage))
                LoadDataPXForBPCP()
            Catch ex As Exception
                sqlTrans.Rollback()
                scon.Close()
            End Try
        End If
    End Sub

    Private Sub btnThoat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat1.Click
        Me.Close()
    End Sub
End Class