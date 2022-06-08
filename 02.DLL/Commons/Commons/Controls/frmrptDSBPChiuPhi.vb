
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptDSBPChiuPhi
    Private SqlText As String = String.Empty
    Dim v_all As DataTable = New DataTable()
    Dim vtbValue As DataTable = New DataTable()
    Dim vtbHeader As DataTable = New DataTable("rptTieuDeDSBPChiuPhi")
    Dim vtbThongtinchung As DataTable = New DataTable("rptTHONG_TIN_CHUNG_TMP")
    Private Sub frmrptDSBPChiuPhi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadNhaxuong()

    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Private Sub RefeshThongTin()
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
    End Sub
    Sub LoadNhaxuong()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cboNhaxuong.DisplayMember = "TEN_N_XUONG"
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DataSource = _table
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Cursor = Cursors.WaitCursor
        Call CreateData12()
        Dim frmRP As frmXMLReport = New frmXMLReport()
        frmRP.rptName = "rptDSBPChiuPhi"
        Cursor = Cursors.Default
        If vtbValue.Rows.Count > 0 Then
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtbHeader)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
    End Sub

    Sub CreateData12()


        RefeshLanguageReport12()
        RefeshThongTin()
        v_all = New DataTable()
        vtbValue = New DataTable("rptDSBPChiuPhi_TMP")
        vtbValue = Get_DataTable(cboNhaxuong.SelectedValue.ToString(), "-1", "-1", "-1")
        vtbValue.TableName = "rptDSBPChiuPhi_TMP"
        WriteXML()

    End Sub
    Sub WriteXML()
        Dim source As DataSet = New DataSet()
        source.Tables.Add(vtbValue)
        source.Tables.Add(vtbThongtinchung)
        source.Tables.Add(vtbHeader)
        source.WriteXml(Application.StartupPath + "\rptDSBPChiuPhi.xml", XmlWriteMode.WriteSchema)
    End Sub

    Private Sub RefeshLanguageReport12()

        vtbHeader = New DataTable("rptTieuDeDSBPChiuPhi")
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "ThietBi", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "SoThe", Commons.Modules.TypeLanguage)
        Dim LoaiThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "LoaiThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "Ngay", Commons.Modules.TypeLanguage)
        Dim BoPhanCP As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "BoPhanCP", Commons.Modules.TypeLanguage)
        Dim TenNhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSBPChiuPhi", "TenNhaXuong", Commons.Modules.TypeLanguage)

        'str = "Create Table [dbo].rptTieuDeDSBPChiuPhi(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        '"STT nvarchar(5),ThietBi nvarchar(50),SoThe nvarchar(30),LoaiThietBi nvarchar(50),NgayLap nvarchar(30),BoPhanCP nvarchar(50),TenNhaXuong nvarchar(100)) "
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'str = "Insert into [dbo].rptTieuDeDSBPChiuPhi values(" & commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        'STT & "',N'" & ThietBi & "',N'" & SoThe & "',N'" & LoaiThietBi & "',N'" & NgayLap & "',N'" & BoPhanCP & "',N'" & TenNhaXuong & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        vtbHeader.Columns.Add("commons.Modules.TypeLanguage")
        vtbHeader.Columns.Add("NgayIn")
        vtbHeader.Columns.Add("TrangIn")
        vtbHeader.Columns.Add("TieuDe")
        vtbHeader.Columns.Add("STT")
        vtbHeader.Columns.Add("ThietBi")
        vtbHeader.Columns.Add("SoThe")
        vtbHeader.Columns.Add("LoaiThietBi")
        vtbHeader.Columns.Add("NgayLap")
        vtbHeader.Columns.Add("BoPhanCP")
        vtbHeader.Columns.Add("TenNhaXuong")

        vtbHeader.Rows.Add(Commons.Modules.TypeLanguage, NgayIn, TrangIn, TieuDe, STT, ThietBi, SoThe, LoaiThietBi, NgayLap, BoPhanCP, TenNhaXuong)


    End Sub
#Region "Nhu Y"
    
    Function Get_DataTable(ByVal MS_N_Xuong As String) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_BPCP]"))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"))
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
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_BPCP]"))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong)
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
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
