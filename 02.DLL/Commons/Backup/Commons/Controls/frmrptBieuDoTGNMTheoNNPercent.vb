
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBieuDoTGNMTheoNNPercent
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Private vIndex As Double = 6.5
    Dim v_all As System.Data.DataTable = New System.Data.DataTable()

    Private Sub frmrptBieuDoTGNMTheoNNPercent_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.NGUYEN_NHAN_CHON_TMP")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmrptBieuDoTGNMTheoNNPercent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date

        mtxtDenNgay.Text = vDenNgay.Date.ToString("MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        Dim sn As Integer = Date.DaysInMonth(vDenNgay.Year, vDenNgay.Month)
        vDenNgay = DateTime.ParseExact("01/" + mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddYears(-1)
        vDenNgay = vDenNgay.AddDays(Date.DaysInMonth(vDenNgay.Year, vDenNgay.Month) - 1)
        mtxtTuNgay.Text = vTuNgay.Date.ToString("MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        txtChiso.Text = vIndex.ToString("###.##")
        'LoadNhaXuong()
        LoadCity()
        LoadNguyenNhan()
        'CreatTableTMP()
    End Sub


    Sub LoadNhaXuong()
        'cboNhaXuong.Value = "MS_N_XUONG"
        'cboNhaXuong.Display = "Ten_N_XUONG"
        'cboNhaXuong.StoreName = "H_TGNM_GET_NX"
        'cboNhaXuong.BindDataSource()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cboNhaXuong.DisplayMember = "TEN_N_XUONG"
        cboNhaXuong.ValueMember = "MS_N_XUONG"
        cboNhaXuong.DataSource = _table
    End Sub

    Sub LoadNguyenNhan()
        'H_BDTGNM_THEO_NN
        Dim vtb As New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_BDTGNM_THEO_NN"))
        grdNguyenNhan.AutoGenerateColumns = False
        vtb.Columns("CHON").ReadOnly = False

        grdNguyenNhan.DataSource = vtb
        grdNguyenNhan.Columns("CHON").DataPropertyName = "CHON"
        grdNguyenNhan.Columns("MS_NGUYEN_NHAN").DataPropertyName = "MS_NGUYEN_NHAN"
        grdNguyenNhan.Columns("TEN_NGUYEN_NHAN").DataPropertyName = "TEN_NGUYEN_NHAN"
        grdNguyenNhan.Columns("HU_HONG").DataPropertyName = "HU_HONG"
        grdNguyenNhan.Columns("BTDK").DataPropertyName = "BTDK"

    End Sub

    Sub CreatTableTMP()
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.NGUYEN_NHAN_CHON_TMP")
        Catch ex As Exception
        End Try

        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "CREATE TABLE dbo.NGUYEN_NHAN_CHON_TMP (MS_NGUYEN_NHAN INT)")
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub


    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        If CheckSelectNN() = False Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "CHUA_CHON_NN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        '' LAY DU LIEU 
        CreatTableTMP()
        For Each row As DataGridViewRow In grdNguyenNhan.Rows
            If row.Cells("CHON").Value Then
                Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(MS_NGUYEN_NHAN) FROM dbo.NGUYEN_NHAN_CHON_TMP WHERE MS_NGUYEN_NHAN = '" & row.Cells("MS_NGUYEN_NHAN").Value & "'")
                If CType(OBJ, Integer) = 0 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO dbo.NGUYEN_NHAN_CHON_TMP(MS_NGUYEN_NHAN) VALUES(N'" + row.Cells("MS_NGUYEN_NHAN").Value.ToString + "')")
                End If
            End If
        Next
        v_all = New System.Data.DataTable()
        Dim vtbData As New System.Data.DataTable
        vtbData = Get_DataTable(cboNhaXuong.SelectedValue.ToString(), vTuNgay, vDenNgay, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
        'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_BDTGNM_THEO_NN_PERCENT_GET_DATA", vTuNgay, vDenNgay, cboNhaXuong.SelectedValue))
        If vtbData.Rows.Count <= 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "NoDataToPrint", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Me.Cursor = Cursors.Default

        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        With ExcelSheets
            .Range("A1", "J1").Font.Bold = True
            .Range("A1", "J1").Merge(True)
            .Range("A1", "J1").MergeCells = True
            .Range("A1", "J1").Font.Size = 16
            .Range("A1", "J1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "TD1", Commons.Modules.TypeLanguage)

            .Range("A2", "J2").Font.Bold = True
            .Range("A2", "J2").Merge(True)
            .Range("A2", "J2").MergeCells = True
            .Range("A2", "J2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "TD2", Commons.Modules.TypeLanguage)

            .Range("A3", "J4").Font.Bold = True
            .Range("A3", "J4").Merge(True)
            .Range("A3", "J4").MergeCells = True
            .Range("A3", "J4").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("A3", "J4").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A3", "J4").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "TD3", Commons.Modules.TypeLanguage)
        End With

        Dim vDong As Integer = 7
        Dim vColum As Char = "B"

        Dim vtbLine As New System.Data.DataTable
        vtbLine = vtbData.DefaultView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG")

        For Each rLine As DataRow In vtbLine.Rows
            With ExcelSheets

                .Range("A" & vDong, "A" & vDong).Merge(True)
                .Range("A" & vDong, "A" & vDong).MergeCells = True
                .Range("A" & vDong, "A" & vDong).Value = rLine("TEN_HE_THONG")
            End With
            vDong = vDong + 1
        Next

        With ExcelSheets
            .Range("A" & vDong, "A" & vDong).Merge(True)
            .Range("A" & vDong, "A" & vDong).MergeCells = True
            .Range("A" & vDong, "A" & vDong).Value = "Average"
        End With


        Dim vThang As New System.Data.DataTable
        vThang = vtbData.DefaultView.ToTable(True, "THANG")

        For Each rThang As DataRow In vThang.Rows
            Dim vdrInMonth As New DataView(vtbData, "THANG = '" & rThang("THANG").ToString & "'", "MS_HE_THONG", DataViewRowState.CurrentRows)
            vDong = 7
            With ExcelSheets
                .Range(vColum & vDong - 1, vColum & vDong - 1).Merge(True)
                .Range(vColum & vDong - 1, vColum & vDong - 1).MergeCells = True
                Dim vtg As DateTime
                vtg = rThang("THANG")
                Dim ss As String = vtg.ToString("MMM-yy", System.Globalization.CultureInfo.CurrentCulture)
                .Range(vColum & vDong - 1, vColum & vDong - 1).Value = rThang("THANG")
                .Range(vColum & vDong - 1, vColum & vDong - 1).NumberFormat = "MMM-yy"
            End With


            Dim i As Integer = 0
            For Each rDThang As DataRow In vdrInMonth.ToTable.Rows
                With ExcelSheets
                    .Range(vColum & vDong + i, vColum & vDong + i).Merge(True)
                    .Range(vColum & vDong + i, vColum & vDong + i).MergeCells = True
                    .Range(vColum & vDong + i, vColum & vDong + i).Value = 100 * rDThang("SO_GIO") / (vIndex * (IIf(rDThang("SO_LAN") = 0, 1, rDThang("SO_LAN"))))
                    .Range(vColum & vDong + i, vColum & vDong + i).NumberFormat = "0.0"
                    i = i + 1
                End With
            Next

            With ExcelSheets
                .Range(vColum & vDong + i, vColum & vDong + i).Merge(True)
                .Range(vColum & vDong + i, vColum & vDong + i).MergeCells = True
                .Range(vColum & vDong + i, vColum & vDong + i).Value = "=SUM(" & vColum & 7 & ":" & vColum & vDong + i - 1 & ")/" & vtbLine.Rows.Count
                .Range(vColum & vDong + i, vColum & vDong + i).NumberFormat = "0.0"
            End With

            vColum = Chr(Asc(vColum) + 1)
        Next



        '''''bieu do '''''
        vColum = Chr(Asc(vColum) - 1)
        vDong = vDong - 1
        Dim vLeft As Integer = 20
        Dim vTop As Integer = 100
        Dim vH As Integer = 600


        vTop = vtbLine.Rows.Count * ExcelSheets.Range("A7", "X7").Height + 100

        'vH = (vWith + 4) * ExcelSheets.Range("A7", "X7").Height

        Dim chartObjs As ChartObjects = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, 700, vH)
        Dim xlChart As Chart = chartObj.Chart


        Dim rgEqui As Excel.Range
        rgEqui = ExcelSheets.Range("A" & vDong, vColum & (vDong + vtbLine.Rows.Count) + 1)

        xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlRows)

        xlChart.ChartType = XlChartType.xlLineMarkers
        xlChart.HasDataTable = True
        xlChart.HasLegend = False
        xlChart.DataTable.Font.Size = 7.25
        With xlChart.Axes(XlAxisType.xlCategory)
            .HasMajorGridlines = True
            .MajorGridlines.Border.Color = RGB(216, 216, 216)

        End With

        With xlChart.Axes(XlAxisType.xlValue)
            .HasMajorGridlines = True
            .MajorGridlines.Border.Color = RGB(216, 216, 216)

        End With

        With chartObj
            .RoundedCorners = True
        End With

        'xlChart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary).ticklabels.Orientation = XlTickLabelOrientation.xlTickLabelOrientationAutomatic
        xlChart.HasTitle = True
        ' xlChart.ChartTitle.Text = vChartName
        'xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
        xlChart.ChartArea.Border.Color = RGB(10, 10, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(0, 255, 255)
        'xlChart.Legend.Border.Color = RGB(255, 255, 255)

        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Function CheckSelectNN() As Boolean
        For i As Integer = 0 To grdNguyenNhan.Rows.Count - 1
            If (grdNguyenNhan.Rows(i).Cells("CHON").Value = True) Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            vTuNgay = DateTime.ParseExact("01/" + mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoTGNMTheoNNPercent", "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try

    End Sub
#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try

            'cmbStreet.StoreName = "S_Duong"
            'cmbStreet.Param = cmbCity.SelectedValue.ToString()
            'If cmbDistrict.SelectedValue = Nothing Then
            'Else
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            'End If
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_BDTGNM_THEO_NN_PERCENT_GET_DATA_NEW]", tungay, denngay))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_BDTGNM_THEO_NN_PERCENT_GET_DATA_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then


            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_N_XUONG<>'' and MS_N_XUONG <> ' ' and MS_N_XUONG is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

    End Sub

    Private Sub txtChiso_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChiso.Validating

    End Sub

    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        LoadNhaXuong()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
