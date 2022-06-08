Imports Microsoft.ApplicationBlocks.Data
Public Class frmExportData
    Private _TPhieuNhap As DataTable = New DataTable()
    Private _TMayNhap As DataTable = New DataTable()

    Private Sub frmExportData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtTuNgay.Value = DateTime.Now.AddDays(-7)
        dtDenNgay.Value = DateTime.Now
        BinDataPhieuNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
        BinDataMayNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        grvPhieuNhap.AllowUserToAddRows = False
        grvMayNhap.AllowUserToAddRows = False

    End Sub
    Private Sub BinDataPhieuNhap(ByVal _TuNgay As DateTime, ByVal _DenNgay As DateTime)
        _TPhieuNhap = New DataTable()
        _TPhieuNhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_EXPORT_PHIEU_NHAP", dtTuNgay.Value, dtDenNgay.Value))
        For Each colum As DataColumn In _TPhieuNhap.Columns
            If colum.ColumnName = "choice" Then
                colum.ReadOnly = False
            Else
                colum.ReadOnly = True
            End If
        Next

        grvPhieuNhap.DataSource = _TPhieuNhap
        For Each Col As DataGridViewColumn In grvPhieuNhap.Columns
            Col.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Col.Name, Commons.Modules.TypeLanguage)
            Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

    End Sub
    Private Sub BinDataMayNhap(ByVal _TuNgay As DateTime, ByVal _DenNgay As DateTime)
        _TMayNhap = New DataTable()
        _TMayNhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_EXPORT_MAY_NHAP", dtTuNgay.Value, dtDenNgay.Value))
        For Each colum As DataColumn In _TMayNhap.Columns
            If colum.ColumnName = "choice" Then

                colum.ReadOnly = False
            Else
                colum.ReadOnly = True
            End If
        Next
        grvMayNhap.DataSource = _TMayNhap
        For Each Col As DataGridViewColumn In grvMayNhap.Columns
            Col.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Col.Name, Commons.Modules.TypeLanguage)
            Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If Col.Name = "TI_GIA_USD" Then
                Col.DefaultCellStyle.Format = "###,##0.######"
            End If
        Next
    End Sub

    Private Sub dtTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTuNgay.ValueChanged
        BinDataPhieuNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
        BinDataMayNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
    End Sub

    Private Sub dtDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDenNgay.ValueChanged
        BinDataPhieuNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
        BinDataMayNhap(dtTuNgay.Value.Date, dtDenNgay.Value.Date)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Validate()
        Dim Cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Tran As SqlClient.SqlTransaction = Cnn.BeginTransaction()
        Dim SQL As String = ""


        Try
            _TPhieuNhap.DefaultView.RowFilter = "choice=1"
            Dim _TPhieuNhapExport As DataTable = _TPhieuNhap.DefaultView.ToTable()
            For Each row As DataRow In _TPhieuNhapExport.Rows
                If String.IsNullOrEmpty(row("MS_KH").ToString()) = True Or String.IsNullOrEmpty(row("So_Chung_Tu").ToString()) = True Or String.IsNullOrEmpty(row("Ngay_Chung_Tu").ToString()) = True Then
                    For Each grvrow As DataGridViewRow In grvPhieuNhap.Rows
                        If grvrow.Cells("MS_DH_Nhap_PT").Value.Equals(row("MS_DH_Nhap_PT")) Then
                            grvrow.Cells("choice").Value = False
                        End If
                    Next
                Else

                    Dim _TChiTiet As DataTable = New DataTable()
                    _TChiTiet.Load(SqlHelper.ExecuteReader(Tran, "SP_GET_PHIEU_NHAP_CHI_TIET", row("MS_DH_NHAP_PT").ToString(), Commons.Modules.UserName))
                    For Each rowchitiet In _TChiTiet.Rows
                        Dim count As Object = Nothing
                        SQL = "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM SVM_TRANS_ACC WHERE IO_KEY=N''" + rowchitiet("io_key").ToString() + "'' AND STATUS = ''C'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                        'SQL = "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N''" + rowchitiet("io_key").ToString() + "'' AND STATUS = ''C'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                        count = SqlHelper.ExecuteScalar(Tran, CommandType.Text, SQL)
                        If (Not count Is Nothing) Then
                            If (CType(count, Integer) <= 0) Then
                                SQL = " SET XACT_ABORT ON;DELETE OPENQUERY([SEPHIROTH],'SELECT * FROM SVM_TRANS_ACC WHERE IO_KEY =''" + rowchitiet("io_key").ToString() + "'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                                'SQL = " SET XACT_ABORT ON;DELETE OPENQUERY([SEPHIROTH],'SELECT * FROM [SVM_TRANS_ACC] WHERE IO_KEY =''" + rowchitiet("io_key").ToString() + "'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.Text, SQL)
                                SqlHelper.ExecuteNonQuery(Tran, "Add_SEPHIROTH_SVM_TRANS_ACC_CMMS", rowchitiet("FACTORY"), rowchitiet("Slip_Div"), rowchitiet("Work_Date"), rowchitiet("Dept_CD"), rowchitiet("IO_Key"), rowchitiet("Item_DIV"), rowchitiet("Cust_CD"), rowchitiet("Invoice_No"), rowchitiet("Invoice_Date"), rowchitiet("Ship_Date"), rowchitiet("QTY"), rowchitiet("DESC_01"), rowchitiet("DESC_02"), rowchitiet("DESC_03"), rowchitiet("DESC_04"), rowchitiet("DESC_05"), rowchitiet("DESC_06"), rowchitiet("DESC_07"), rowchitiet("DESC_08"), rowchitiet("DESC_09"), rowchitiet("DESC_10"), rowchitiet("MNG_01"), rowchitiet("MNG_02"), rowchitiet("MNG_03"), rowchitiet("MNG_04"), rowchitiet("MNG_05"), rowchitiet("MNG_06"), rowchitiet("MNG_07"), rowchitiet("MNG_08"), rowchitiet("MNG_09"), rowchitiet("MNG_10"), rowchitiet("EX_rate"), rowchitiet("Amount_VND"), rowchitiet("Amount_USD"), rowchitiet("Remark_01"), rowchitiet("Remark_02"), rowchitiet("Remark_03"), rowchitiet("Remark_04"), rowchitiet("Remark_05"), rowchitiet("UPD_User"), rowchitiet("Status"), rowchitiet("Acc_SLIP_NO"), rowchitiet("Acc_User"), rowchitiet("Acc_Date"))
                            End If
                        Else
                            SqlHelper.ExecuteNonQuery(Tran, "Add_SEPHIROTH_SVM_TRANS_ACC_CMMS", rowchitiet("FACTORY"), rowchitiet("Slip_Div"), rowchitiet("Work_Date"), rowchitiet("Dept_CD"), rowchitiet("IO_Key"), rowchitiet("Item_DIV"), rowchitiet("Cust_CD"), rowchitiet("Invoice_No"), rowchitiet("Invoice_Date"), rowchitiet("Ship_Date"), rowchitiet("QTY"), rowchitiet("DESC_01"), rowchitiet("DESC_02"), rowchitiet("DESC_03"), rowchitiet("DESC_04"), rowchitiet("DESC_05"), rowchitiet("DESC_06"), rowchitiet("DESC_07"), rowchitiet("DESC_08"), rowchitiet("DESC_09"), rowchitiet("DESC_10"), rowchitiet("MNG_01"), rowchitiet("MNG_02"), rowchitiet("MNG_03"), rowchitiet("MNG_04"), rowchitiet("MNG_05"), rowchitiet("MNG_06"), rowchitiet("MNG_07"), rowchitiet("MNG_08"), rowchitiet("MNG_09"), rowchitiet("MNG_10"), rowchitiet("EX_rate"), rowchitiet("Amount_VND"), rowchitiet("Amount_USD"), rowchitiet("Remark_01"), rowchitiet("Remark_02"), rowchitiet("Remark_03"), rowchitiet("Remark_04"), rowchitiet("Remark_05"), rowchitiet("UPD_User"), rowchitiet("Status"), rowchitiet("Acc_SLIP_NO"), rowchitiet("Acc_User"), rowchitiet("Acc_Date"))
                        End If

                    Next
                End If
            Next
            _TMayNhap.DefaultView.RowFilter = "choice=1"
            Dim _TMayNhapExport As DataTable = _TMayNhap.DefaultView.ToTable()
            For Each row As DataRow In _TMayNhapExport.Rows
                If String.IsNullOrEmpty(row("MS_KH").ToString()) = True Or String.IsNullOrEmpty(row("SO_CT").ToString()) = True Or String.IsNullOrEmpty(row("NGAY_MUA").ToString()) = True Then
                    For Each grvrow As DataGridViewRow In grvMayNhap.Rows
                        If grvrow.Cells("MS_MAY").Value.Equals(row("MS_MAY")) Then
                            grvrow.Cells("choice").Value = False
                        End If
                    Next
                Else
                    Dim _TChiTiet As DataTable = New DataTable()
                    _TChiTiet.Load(SqlHelper.ExecuteReader(Tran, "SP_GET_EXPORT_MAY_NHAP_CHI_TIET", row("MS_MAY").ToString(), Commons.Modules.UserName))
                    For Each rowchitiet In _TChiTiet.Rows
                        Dim count As Object = Nothing
                        SQL = "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM SVM_TRANS_ACC WHERE IO_KEY=N''" + rowchitiet("io_key").ToString() + "'' AND STATUS = ''C'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                        'SQL = "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N'" + rowchitiet("io_key").ToString() + "' AND STATUS = 'C' AND MNG_05='" + rowchitiet("MNG_05").ToString() + "'')"
                        count = SqlHelper.ExecuteScalar(Tran, CommandType.Text, SQL)
                        If (Not count Is Nothing) Then
                            If (CType(count, Integer) <= 0) Then
                                SQL = " SET XACT_ABORT ON;DELETE OPENQUERY([SEPHIROTH],'SELECT * FROM SVM_TRANS_ACC WHERE IO_KEY =''" + rowchitiet("io_key").ToString() + "'' AND MNG_05=''" + rowchitiet("MNG_05").ToString() + "''')"
                                'SQL = " SET XACT_ABORT ON;DELETE OPENQUERY([SEPHIROTH],'SELECT * FROM [SVM_TRANS_ACC] WHERE IO_KEY ='" + rowchitiet("io_key").ToString() + "' AND MNG_05='" + rowchitiet("MNG_05").ToString() + "'')"
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.Text, SQL)
                                SqlHelper.ExecuteNonQuery(Tran, "Add_SEPHIROTH_SVM_TRANS_ACC_CMMS", rowchitiet("FACTORY"), rowchitiet("Slip_Div"), rowchitiet("Work_Date"), rowchitiet("Dept_CD"), rowchitiet("IO_Key"), rowchitiet("Item_DIV"), rowchitiet("Cust_CD"), rowchitiet("Invoice_No"), rowchitiet("Invoice_Date"), rowchitiet("Ship_Date"), rowchitiet("QTY"), rowchitiet("DESC_01"), rowchitiet("DESC_02"), rowchitiet("DESC_03"), rowchitiet("DESC_04"), rowchitiet("DESC_05"), rowchitiet("DESC_06"), rowchitiet("DESC_07"), rowchitiet("DESC_08"), rowchitiet("DESC_09"), rowchitiet("DESC_10"), rowchitiet("MNG_01"), rowchitiet("MNG_02"), rowchitiet("MNG_03"), rowchitiet("MNG_04"), rowchitiet("MNG_05"), rowchitiet("MNG_06"), rowchitiet("MNG_07"), rowchitiet("MNG_08"), rowchitiet("MNG_09"), rowchitiet("MNG_10"), rowchitiet("EX_rate"), rowchitiet("Amount_VND"), rowchitiet("Amount_USD"), rowchitiet("Remark_01"), rowchitiet("Remark_02"), rowchitiet("Remark_03"), rowchitiet("Remark_04"), rowchitiet("Remark_05"), rowchitiet("UPD_User"), rowchitiet("Status"), rowchitiet("Acc_SLIP_NO"), rowchitiet("Acc_User"), rowchitiet("Acc_Date"))
                            End If
                        Else
                            SqlHelper.ExecuteNonQuery(Tran, "Add_SEPHIROTH_SVM_TRANS_ACC_CMMS", rowchitiet("FACTORY"), rowchitiet("Slip_Div"), rowchitiet("Work_Date"), rowchitiet("Dept_CD"), rowchitiet("IO_Key"), rowchitiet("Item_DIV"), rowchitiet("Cust_CD"), rowchitiet("Invoice_No"), rowchitiet("Invoice_Date"), rowchitiet("Ship_Date"), rowchitiet("QTY"), rowchitiet("DESC_01"), rowchitiet("DESC_02"), rowchitiet("DESC_03"), rowchitiet("DESC_04"), rowchitiet("DESC_05"), rowchitiet("DESC_06"), rowchitiet("DESC_07"), rowchitiet("DESC_08"), rowchitiet("DESC_09"), rowchitiet("DESC_10"), rowchitiet("MNG_01"), rowchitiet("MNG_02"), rowchitiet("MNG_03"), rowchitiet("MNG_04"), rowchitiet("MNG_05"), rowchitiet("MNG_06"), rowchitiet("MNG_07"), rowchitiet("MNG_08"), rowchitiet("MNG_09"), rowchitiet("MNG_10"), rowchitiet("EX_rate"), rowchitiet("Amount_VND"), rowchitiet("Amount_USD"), rowchitiet("Remark_01"), rowchitiet("Remark_02"), rowchitiet("Remark_03"), rowchitiet("Remark_04"), rowchitiet("Remark_05"), rowchitiet("UPD_User"), rowchitiet("Status"), rowchitiet("Acc_SLIP_NO"), rowchitiet("Acc_User"), rowchitiet("Acc_Date"))
                        End If

                    Next
                End If
            Next
            Tran.Commit()
            Cnn.Close()
            _TPhieuNhap.DefaultView.RowFilter = ""
            _TMayNhap.DefaultView.RowFilter = ""
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgExportThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Catch ex As Exception
            Tran.Rollback()
            Cnn.Close()
            _TPhieuNhap.DefaultView.RowFilter = ""
            _TMayNhap.DefaultView.RowFilter = ""
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgExportLoi", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class