Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptDanhsach_VTPT
    Private SqlText As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        PrintDanhMucPhuTung()
    End Sub

    Sub PrintDanhMucPhuTung()

        Cursor = Cursors.WaitCursor
        Try
            Dim vtbData As New DataTable()
            'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_CHI_PHI_THEO_BO_PHAN_CHIU_PHI", vTuNgay, vDenNgay))
            'vtbData.TableName = "DATA_INFO"
            vtbData = GetDataDMVTPT()
            vtbData.TableName = "rptrptDANH_SACH_VTPT"

            If vtbData.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDanhsach_VTPT"
                frmRepot.AddDataTableSource(RefeshLanguageDMVTPT())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()

            Else
                Cursor = Cursors.Default
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Function RefeshLanguageDMVTPT() As DataTable
        Dim tieude, stt, Loaithietbi, noisudung, masovtpt, itemcode, partno, tenvattu, quycach, donvitinh, trang As String
        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "Loaithietbi", Commons.Modules.TypeLanguage)
        noisudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "noisudung", Commons.Modules.TypeLanguage)
        masovtpt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "masovtpt", Commons.Modules.TypeLanguage)
        itemcode = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "itemcode", Commons.Modules.TypeLanguage)
        partno = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "partno", Commons.Modules.TypeLanguage)
        tenvattu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tenvattu", Commons.Modules.TypeLanguage)
        quycach = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "quycach", Commons.Modules.TypeLanguage)
        donvitinh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "donvitinh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "trang", Commons.Modules.TypeLanguage)

        Dim vtb As New DataTable("rptDANH_SACH_VTPT_TMP")
        vtb.Columns.Add("TIEUDE_", Type.GetType("System.String"))
        vtb.Columns.Add("STT_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_TB_", Type.GetType("System.String"))
        vtb.Columns.Add("NOI_SD_", Type.GetType("System.String"))
        vtb.Columns.Add("MS_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("ITEM_CODE_", Type.GetType("System.String"))
        vtb.Columns.Add("PART_NO_", Type.GetType("System.String"))
        vtb.Columns.Add("TEN_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("QUY_CACH_", Type.GetType("System.String"))
        vtb.Columns.Add("DON_VI_TINH_", Type.GetType("System.String"))
        vtb.Columns.Add("TRANG_", Type.GetType("System.String"))
        vtb.Columns.Add("NGON_NGU_", Type.GetType("System.String"))

        Dim vrow As DataRow = vtb.NewRow()
        vrow("TIEUDE_") = tieude
        vrow("STT_") = stt
        vrow("LOAI_TB_") = Loaithietbi
        vrow("NOI_SD_") = noisudung
        vrow("MS_PT_") = masovtpt
        vrow("ITEM_CODE_") = itemcode
        vrow("PART_NO_") = partno
        vrow("TEN_PT_") = tenvattu
        vrow("QUY_CACH_") = quycach
        vrow("DON_VI_TINH_") = donvitinh
        vrow("TRANG_") = trang
        vrow("NGON_NGU_") = Commons.Modules.TypeLanguage.ToString()

        vtb.Rows.Add(vrow)
        Return vtb
    End Function

    Function GetDataDMVTPT() As DataTable
        Try
            Dim sql As String = "if exists (select * from dbo.sysobjects where [name] = 'rptrptDANH_SACH_VTPT') " & _
                "Drop table rptrptDANH_SACH_VTPT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception
        End Try

        If cboLoaiTB.SelectedIndex = 0 Then
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        Else
            If cboNoisudung.SelectedIndex = 0 Then
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "'"
            Else
                SqlText = "SELECT LOAI_MAY.MS_LOAI_MAY,LOAI_MAY.TEN_LOAI_MAY, LOAI_PHU_TUNG.MS_LOAI_PT,LOAI_PHU_TUNG.TEN_LOAI_PT, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT_NCC," & _
                "IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH.TEN_1, DON_VI_TINH.TEN_2 " & _
                "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT  " & _
                "INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT " & _
                "INNER JOIN LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY " & _
                "INNER JOIN LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT " & _
                "INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                "WHERE IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB.SelectedValue & "' AND IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = '" & cboNoisudung.SelectedValue & "'"
            End If
        End If
        SqlText += " ORDER BY IC_PHU_TUNG.MS_PT"
        Dim vtb As New DataTable()
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Return vtb
    End Function

    Private Sub frmrptDanhsach_VTPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Bind_cboLoaiTB()
        Bind_cboNoisudung()
    End Sub

    Sub Bind_cboLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)
        cboLoaiTB.DataSource = dt
        cboLoaiTB.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB.ValueMember = "MS_LOAI_MAY"
        If cboLoaiTB.Items.Count = 0 Then
            cboLoaiTB.Text = ""
        End If
    End Sub
    Sub Bind_cboNoisudung()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_PT", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)
        cboNoisudung.DataSource = dt
        cboNoisudung.DisplayMember = "TEN_LOAI_PT"
        cboNoisudung.ValueMember = "MS_LOAI_PT"
    End Sub
    'Sub Bind_cboLoaiCV()
    '    cboLoaiCV.Display = "TEN_LOAI_CV"
    '    cboLoaiCV.Value = "MS_LOAI_CV"
    '    cboLoaiCV.DropDownWidth = 200
    '    cboLoaiCV.Param = Commons.Modules.UserName
    '    cboLoaiCV.StoreName = "PermisionLOAI_CV"
    '    cboLoaiCV.BindDataSource()

    '    cboLoai_CV.Display = "TEN_LOAI_CV"
    '    cboLoai_CV.Value = "MS_LOAI_CV"
    '    cboLoai_CV.DropDownWidth = 200
    '    cboLoai_CV.Param = Commons.Modules.UserName
    '    cboLoai_CV.StoreName = "PermisionLOAI_CV"
    '    cboLoai_CV.BindDataSource()

    'End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
