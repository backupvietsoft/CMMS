using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace ImportExcels
{
    public partial class frmImportTonKho : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        int iLoi = 0;

        DataTable _table = new DataTable();
        string ChuoiKT = "'";
        string ChuoiKTMa = "':*?<>|\\/";

        HSSFWorkbook wb;
        HSSFWorkbook hssfworkbook;
        Boolean mLoad = false;

        private void grvSource_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvSource.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
                int col = -1;
                col = info.Column.AbsoluteIndex;
                if (col == -1)
                    return;
                System.Data.DataRow row = grvSource.GetDataRow(info.RowHandle);
                #region Xu ly tung cell
                switch (col)
                {
                    case 0:
                        KiemData("IC_KHO", "TEN_KHO", info.RowHandle, 0, row);
                        break;
                    case 1:
                        KiemData("dbo.VI_TRI_KHO INNER JOIN dbo.IC_KHO ON dbo.VI_TRI_KHO.MS_KHO = dbo.IC_KHO.MS_KHO WHERE dbo.IC_KHO.TEN_KHO = N'" + row[0] + "' ", "TEN_VI_TRI", info.RowHandle, 1, row);
                        break;
                    case 2:
                        KiemData("IC_PHU_TUNG", "MS_PT", info.RowHandle, 2, row);
                        break;
                    case 5:
                        KiemData("NGOAI_TE", "NGOAI_TE", info.RowHandle, 5, row);
                        break;
                    case 8:
                        KiemData("KHACH_HANG", "TEN_CONG_TY", info.RowHandle, 8, row);
                        break;

                }

                #endregion
            }
            catch { }
        }

        private void KiemData(string Table, string Field, int dong, int Cot, DataRow row)
        {
            try
            {
                MyUtil obj = new MyUtil();
                frmPopUp frmPopUp = new frmPopUp();
                frmPopUp.TableSource = obj.GetList(Table);
                if (frmPopUp.ShowDialog() == DialogResult.OK)
                    row[Cot] = frmPopUp.RowSelected[Field].ToString();

            }
            catch { }
        }

        private void KiemData(DataTable Table, string Field, int dong, int Cot, DataRow row)
        {
            try
            {
                MyUtil obj = new MyUtil();
                frmPopUp frmPopUp = new frmPopUp();
                frmPopUp.TableSource = Table;
                if (frmPopUp.ShowDialog() == DialogResult.OK)
                    row[Cot] = frmPopUp.RowSelected[Field].ToString();

            }
            catch { }
        }

        public frmImportTonKho()
        {
            InitializeComponent();
        }

        private void frmImportTonKho_Load(object sender, EventArgs e)
        {
            datNgay.DateTime = DateTime.Now;
            timGio.Time = DateTime.Now;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            Commons.Modules.SQLString = "0Load";
            TaoCmb();
            Commons.Modules.SQLString = "";
            cboDangNhap_EditValueChanged(sender, e);
        }
        private void TaoCmb()
        {
            string sSql;
            sSql = "SELECT A.MS_CONG_NHAN , HO +' '+TEN AS HO_TEN " +
                        " FROM dbo.CONG_NHAN A INNER JOIN CONG_NHAN_VAI_TRO B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN  " +
                        " WHERE B.MS_VAI_TRO = 4 ORDER BY MS_CONG_NHAN";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiNhap, sSql, "MS_CONG_NHAN", "HO_TEN", "");

            sSql = "SELECT MS_DANG_NHAP, CASE " +  Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN  DANG_NHAP_VIET WHEN 1 " +
                        " THEN DANG_NHAP_ANH ELSE DANG_NHAP_HOA END AS DANG_NHAP " +
                        " FROM DANG_NHAP WHERE MS_DANG_NHAP IN(1,2,4,5) ORDER BY MS_DANG_NHAP";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDangNhap, sSql, "MS_DANG_NHAP", "DANG_NHAP", "");
            cboDangNhap.EditValue = 2;

            sSql = "SELECT MS_LY_DO_NHAP_KT, TEN_LY_DO_NHAP_KT FROM LY_DO_NHAP_KT UNION SELECT -1 , NULL ORDER BY MS_LY_DO_NHAP_KT ";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDNhapKT, sSql, "MS_LY_DO_NHAP_KT", "TEN_LY_DO_NHAP_KT", "");

        }

        private void cboDangNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            string sSql;
            try
            {
                sSql = "SELECT TOP 1 MS_LY_DO_NHAP_KT, TEN_LY_DO_NHAP_KT FROM LY_DO_NHAP_KT WHERE MS_DANG_NHAP = " + cboDangNhap.EditValue.ToString();
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                    cboDNhapKT.EditValue = int.Parse(dtTmp.Rows[0][0].ToString());
                else
                    cboDNhapKT.EditValue = -1;
            }
            catch { }




        }

        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LoadExcels();
        }
        private void btnFile_DoubleClick(object sender, EventArgs e)
        {
            if (LoadExcels()) cboSheet_EditValueChanged(sender, e);
        }



        private bool LoadExcels()
        {

            OpenFileDialog oFile = new OpenFileDialog();
            DataTable dt = new DataTable();
            String[] excelSheets = new String[dt.Rows.Count];
            oFile.Filter = "Excel Files (*.xls;*.xlsx;)|*.xls;*.xlsx;|" + "All Files (*.*)|*.*"; //"XLS Files|*.xls,*.xlsx  |XLSX Files|*.xlsx";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                if (chkGT.Checked)
                {
                    string sLoi = "";
                    if (!LoadSheet(oFile.FileName, out sLoi))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "MoFileLoi",
                            Commons.Modules.TypeLanguage) + "\n" + sLoi + "\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    OleDbConnection excelCon;
                    try
                    {
                        excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + oFile.FileName +
                            ";Extended Properties=\"Excel 12.0;HDR=YES\";");

                        try
                        {
                            excelCon.Open();
                        }
                        catch
                        {

                            try
                            {
                                excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                                "Data Source=" + oFile.FileName + "1;" +
                                                "Extended Properties=Excel 12.0 Xml");
                                excelCon.Open();
                            }
                            catch
                            {
                                excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;" +
                                    "Data Source=" + oFile.FileName + "1;" +
                                    "Extended Properties=Excel 8.0");
                            }
                        }



                        dt = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        excelSheets = new String[dt.Rows.Count];
                        int j = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[j] = row["TABLE_NAME"].ToString().Replace("'", "").Replace("$", "");
                            row["TABLE_NAME"] = row["TABLE_NAME"].ToString().Replace("'", "").Replace("$", "");

                            j++;
                        }
                        mLoad = true;
                        //lokSheet.Properties.DataSource = excelSheets;
                        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboSheet, dt, "TABLE_NAME", "TABLE_NAME", "");
                        mLoad = false;
                        excelCon.Close();
                        //btnFile.Text = "D:\\Template thu thap du lieu 2013.xls";
                        btnFile.Text = oFile.FileName;
                        if (j > 10) cboSheet.Properties.DropDownRows = 15; else cboSheet.Properties.DropDownRows = 10;
                    }
                    catch (Exception ex)
                    {
                        string sLoi = "";
                        if (!LoadSheet(oFile.FileName, out sLoi))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "MoFileLoi",
                                Commons.Modules.TypeLanguage) + "\n" + sLoi + "\n" + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else return true;
                    }
                }


                if (cboSheet.Text == "")
                {
                    cboSheet.EditValue = excelSheets[0];
                    return true;
                }
                return true;
            }
            return false;
        }

        private Boolean LoadSheet(string sPath, out string sLoi)
        {
            sLoi = "";
            try
            {
                DataTable dtTmp = new DataTable("SHEET");
                dtTmp.Columns.Add("TEN_SHEET", typeof(string));
                using (var fs = new FileStream(sPath, FileMode.Open, FileAccess.Read))
                {
                    wb = new HSSFWorkbook(fs);

                    for (int i = 0; i < wb.NumberOfSheets; i++)
                    {
                        dtTmp.Rows.Add(wb.GetSheetAt(i).SheetName);
                    }
                }
                mLoad = true;
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboSheet, dtTmp, "TEN_SHEET", "TEN_SHEET", "");
                mLoad = false;
                btnFile.Text = sPath;
                return true;
            }
            catch (Exception ex)
            {
                sLoi = "DDL" + ex.Message.ToString();
                btnFile.Text = ""; return false;
            }

        }


        //private bool LoadExcels()
        //{
        //    OpenFileDialog oFile = new OpenFileDialog();
        //    DataTable dt = new DataTable();
        //    String[] excelSheets = new String[dt.Rows.Count];
        //    oFile.Filter = "Excel Files (*.xls;*.xlsx;)|*.xls;*.xlsx;|" + "All Files (*.*)|*.*"; //"XLS Files|*.xls,*.xlsx  |XLSX Files|*.xlsx";
        //    //oFile.FileName = "D:\\Template thu thap du lieu 2013.xls";
        //    //oFile.FileName = "D:\\123.xls";

        //    if (oFile.ShowDialog() == DialogResult.OK)
        //    {

        //        OleDbConnection excelCon;
        //        try
        //        {
        //            excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + oFile.FileName + ";Extended Properties=\"Excel 12.0;HDR=YES\";");
        //            //excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "D:\\Template thu thap du lieu 2013.xls" + ";Extended Properties=\"Excel 12.0;HDR=YES\";");
        //            excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + oFile.FileName + ";Extended Properties=\"Excel 12.0;HDR=YES;\"");
        //            try
        //            {
        //                excelCon.Open();
        //            }
        //            catch
        //            {
        //                excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + oFile.FileName + ";Extended Properties=Excel 8.0");
        //                //excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Template thu thap du lieu 2013.xls;Extended Properties=Excel 8.0");
        //                excelCon.Open();
        //            }

        //            dt = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //            excelSheets = new String[dt.Rows.Count];
        //            int j = 0;
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                excelSheets[j] = row["TABLE_NAME"].ToString().Replace("'", "").Replace("$", "");
        //                j++;
        //            }

        //            cboSheet.Properties.DataSource = excelSheets;
        //            excelCon.Close();
        //            btnFile.Text = oFile.FileName;
        //            if (j > 10) cboSheet.Properties.DropDownRows = 15; else cboSheet.Properties.DropDownRows = 10;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
        //                "frmImportExcel", "MoFileLoi", Commons.Modules.TypeLanguage) + "\n"  + ex.Message  , this.Text,
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //        if (cboSheet.Text == "")
        //        {
        //            cboSheet.EditValue = excelSheets[0];
        //            return true;
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        private void cboSheet_EditValueChanged(object sender, EventArgs e)
        {
            if (mLoad) return;
            try
            {

                string sheet = cboSheet.Text;
                if (sheet == "" || sheet == "[EditValue is null]")
                {
                    String[] asss;
                    try
                    {
                        asss = (String[])cboSheet.Properties.DataSource;
                        sheet = asss[0].ToString();
                        cboSheet.EditValue = sheet;
                    }
                    catch { }
                }
                if (sheet == "" || sheet == "[EditValue is null]") return;

                _table = new DataTable();
                if (chkGT.Checked)
                {
                    
                    
                    string sLoi = "";
                    if (!GetNotExcel(sheet, out _table, out sLoi))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "DuLieuLoadSai",
                            Commons.Modules.TypeLanguage) + "\n" + sLoi, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        prbIN.Position = prbIN.Properties.Maximum;
                        return;

                    }
                    
                }
                else
                {
                    if (GetExcel(sheet, out _table) == false)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "DuLieuLoadSai",
                            Commons.Modules.TypeLanguage) + "\n" , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        prbIN.Position = prbIN.Properties.Maximum;
                        return;
                    }
                }
                _table.Columns.Add("XOA", System.Type.GetType("System.Boolean"));
                _table.Columns.Add("STT", System.Type.GetType("System.Int16"));

                _table.Columns.Add("LOI", System.Type.GetType("System.Boolean"));
                _table.Columns.Add("DU_LIEU", System.Type.GetType("System.Int16"));
            err:
                int j = 1;
                #region Status bar
                try
                {
                    prbIN.Position = 0;
                    prbIN.Properties.Step = 1;
                    prbIN.Properties.PercentView = true;
                    prbIN.Properties.Maximum = _table.Rows.Count + 3;
                    prbIN.Properties.Minimum = 0;
                }
                catch { }
                #endregion


                foreach (DataRow dr in _table.Rows)
                {
                    string str = "";
                    dr["XOA"] = 0;
                    dr["LOI"] = 0;
                    dr["STT"] = j;
                    dr["DU_LIEU"] = j;
                    for (int i = 0; i < _table.Columns.Count; i++)
                    {
                        str += dr[i].ToString();
                    }
                    if (string.IsNullOrEmpty(str))
                    {
                        _table.Rows.Remove(dr);
                        goto err;
                    }
                    j++;
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion

                }
                _table.PrimaryKey = new DataColumn[] { _table.Columns["STT"] };
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion

                if (_table.Columns.Count <= 13)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, true, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, false, true);
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion

                grvSource.Columns["STT"].Visible = false;
                grvSource.Columns["LOI"].Visible = false;
                grvSource.Columns["DU_LIEU"].Visible = false;
                //excelCon.Close();
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmImportExcel", "DuLieuLoadSai", Commons.Modules.TypeLanguage), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            prbIN.Position = prbIN.Properties.Maximum;

        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (btnFile.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name.ToString(), "msgChuaNhapFileImport", Commons.Modules.TypeLanguage));
                btnFile.Focus();
                return;
            }
            else
            {
                if (!Commons.Modules.ObjSystems.KiemFileTonTai(btnFile.Text))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name.ToString(), "msgFileImportKhongTonTai", Commons.Modules.TypeLanguage));
                    btnFile.Focus();
                    return;
                }
            }
            if (datNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name.ToString(), "msgChuaNhapNgayNhap", Commons.Modules.TypeLanguage));
                datNgay.Focus();
                return;
            }
            if (timGio.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name.ToString(), "msgChuaNhapGioNhap", Commons.Modules.TypeLanguage));
                timGio.Focus();
                return;
            }
            if (cboNguoiNhap.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name.ToString(), "msgChuaNhapNguoiNhap", Commons.Modules.TypeLanguage));
                cboNguoiNhap.Focus();
                return;
            }        
            if (cboDangNhap.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name.ToString(), "msgChuaNhapDangNhap", Commons.Modules.TypeLanguage));
                cboDangNhap.Focus();
                return;
            }
            
            DataTable dtSource = (grdSource.DataSource as DataTable);
            if (cboSheet.Text == "" || dtSource == null || dtSource.Rows.Count <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name.ToString(), "msgKhongCoDuLieuImport", Commons.Modules.TypeLanguage), this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(cboDangNhap.EditValue.ToString()) == 1)
            {
                DataTable dtTmp = new DataTable();
                dtTmp = dtSource.Copy();
                dtTmp.DefaultView.RowFilter = " ISNULL([" + grvSource.Columns[8].FieldName.ToString() + "],'') = '' ";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count > 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name.ToString(), "msgKhongCoKhachHangDangNhapMuaMoi", Commons.Modules.TypeLanguage), this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            CapNhapTonDauKy(dtSource);
        }

        #region Cap Nhap Ton Dau Ky
        private void CapNhapTonDauKy(DataTable dtSource)
        {
            int col = 0;
            MyUtil obj = new MyUtil();
            int count = grvSource.RowCount;
            #region Khai Bao Bien

            int iTEN_KHO_OK = 0;
            int iTEN_VI_TRI_KHO_OK = 0;
            int iMS_PT_OK = 0;
            int iSO_LUONG_OK = 0;
            int iDON_GIA_GOC_OK = 0;
            int iTIEN_TE_OK = 0;
            int iTY_GIA_OK = 0;
            int iTY_GIA_USD_OK = 0;
            int iKHACH_HANG_OK = 0;
            int iXUAT_XU_OK = 0;
            int iBAO_HANH_DEN_NGAY_OK = 0;
            int iCP_NHAP_KHAU_OK = 0;
            int iCP_KHAC_OK = 0;
            int iTAX_OK = 0;
            int iGHI_CHU_OK = 0;

            string sTEN_KHO = "";
            string sTEN_VI_TRI_KHO = "";
            string BTam = "IMPORT_TON" + Commons.Modules.UserName;
            #endregion

            DataTable dtTmp = new DataTable();
            #region Do du lieu tu file excel vao CSDL
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtSource, "");

            #endregion

            #region Status bar
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = dtSource.Rows.Count; 
            prbIN.Properties.Minimum = 0;
            #endregion
            foreach (DataRow dr in dtSource.Rows)
            {
                #region Kiem Tra
                dr.ClearErrors();
                #region Tên kho và vị trí kho
                try
                {
                    col = 0;
                    #region Tên kho
                    dr["XOA"] = 0;
                    sTEN_KHO = dr[col].ToString();
                    if (dr[grvSource.Columns[col].FieldName.ToString()] == DBNull.Value || dr[grvSource.Columns[col].FieldName.ToString()].ToString() == String.Empty)
                    {
                        dr.SetColumnError(grvSource.Columns[col].FieldName.ToString(), "Tên kho không được null");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        if (dr[grvSource.Columns[col + 1].FieldName.ToString()] == DBNull.Value || dr[grvSource.Columns[col + 1].FieldName.ToString()].ToString() == String.Empty)
                        {
                            dr.SetColumnError(grvSource.Columns[col + 1].FieldName.ToString(), "Tên vị trí kho không được null");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            if (KiemKyTu(sTEN_KHO, ChuoiKTMa))
                            {
                                dr.SetColumnError(grvSource.Columns[col].FieldName.ToString(), "Tên kho có chứa ký tự đặc biệt");
                                dr["XOA"] = 1;
                            }
                            else
                            {
                                dtTmp = new DataTable();
                                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                    "SELECT * FROM IC_KHO WHERE TEN_KHO = N'" + sTEN_KHO + "' "));
                                if (dtTmp.Rows.Count == 0)
                                {
                                    dr.SetColumnError(grvSource.Columns[col].FieldName.ToString(), "Tên kho không tồn tại trong cơ sở dữ liệu");
                                    dr["XOA"] = 1;
                                }
                                else
                                {
                                    sTEN_VI_TRI_KHO = dr[col + 1].ToString();
                                    if (KiemKyTu(sTEN_VI_TRI_KHO, ChuoiKT))
                                    {
                                        dr.SetColumnError(grvSource.Columns[col + 1].FieldName.ToString(), "Tên vị trí kho có chứa ký tự đặc biệt");
                                        dr["XOA"] = 1;
                                    }
                                    else
                                    {

                                        dtTmp = new DataTable();
                                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                            "SELECT * FROM VI_TRI_KHO WHERE TEN_VI_TRI = N'" + sTEN_VI_TRI_KHO + "'  "));
                                        if (dtTmp.Rows.Count == 0)
                                        {
                                            dr.SetColumnError(grvSource.Columns[col + 1].FieldName.ToString(), "Tên vị trí kho không tồn tại trong cơ sở dữ liệu");
                                            dr["XOA"] = 1;
                                        }
                                        else
                                        {
                                            iTEN_KHO_OK = CheckLen(dr, col, iTEN_KHO_OK, 50, "Tên kho");
                                            iTEN_VI_TRI_KHO_OK = CheckLen(dr, col + 1, iTEN_VI_TRI_KHO_OK, 255, "Tên vị trí kho");
                                        }
                                    }

                                }

                            }


                        }
                    }
                    #endregion
                }
                catch
                {
                    dr.SetColumnError(grvSource.Columns[col].FieldName.ToString(), "Tên kho lỗi");
                    dr["XOA"] = 1;
                }
                #endregion

                col = 2;
                #region MS Phụ Tùng
                if (KiemDuLieu(dr, col, "MS Phụ Tùng", true, obj, "IC_PHU_TUNG", "MS_PT")) iMS_PT_OK += 1;
                #endregion

                col = 3;
                #region Số lượng
                if (KiemDuLieuSo(dr, col, "Số lượng", 1, 0, true)) iSO_LUONG_OK += 1;
                #endregion

                col = 4;
                #region Đơn giá
                if (KiemDuLieuSo(dr, col, "Đơn giá", 0, 0, true)) iDON_GIA_GOC_OK += 1;
                #endregion

                col = 5;
                #region Mã tiền tệ
                if (KiemDuLieu(dr, col, "Tiền tệ", true, obj, "NGOAI_TE", "TEN_NGOAI_TE")) iTIEN_TE_OK += 1;
                #endregion

                col = 6;
                #region Tỷ giá
                if (KiemDuLieuSo(dr, col, "Tỉ giá vnd", 0, 0, true)) iTY_GIA_OK += 1;
                #endregion

                col = 7;
                #region Tỷ giá USD
                if (KiemDuLieuSo(dr, col, "Tỉ giá usd", 0, 0, true)) iTY_GIA_USD_OK += 1;
                #endregion

                col = 8;
                #region Tên Khách hàng
                if (KiemDuLieu(dr, col, "Tên Khách hàng", false, obj, "KHACH_HANG", "TEN_CONG_TY")) iKHACH_HANG_OK += 1;
                #endregion

                col = 9;
                #region Xuất xứ
                if (KiemDuLieu(dr, col, "Xuất xứ", false,50)) iXUAT_XU_OK += 1;
                #endregion

                col = 10;
                #region Bảo hành đến ngày
                if (KiemDuLieuNgay(dr, col, "Bảo hành đến ngày", false)) iBAO_HANH_DEN_NGAY_OK += 1;
                #endregion
                
                col = 11;
                #region Chi phí nhập khẩu
                if (KiemDuLieuSo(dr, col, "Chi phí nhập khẩu", 0, 0, false)) iCP_NHAP_KHAU_OK += 1;
                #endregion

                col = 12;
                #region Chi phí khác
                if (KiemDuLieuSo(dr, col, "Chi phí khác", 0, 0, false)) iCP_KHAC_OK += 1;
                #endregion

                col = 13;
                #region Tax
                if (KiemDuLieuSo(dr, col, "Tax", 0, 0, false)) iTAX_OK += 1;
                #endregion

                col = 14;
                #region Ghi Chú
                if (KiemDuLieu(dr, col, "Ghi Chú", false,255)) iGHI_CHU_OK += 1;
                #endregion



                #endregion
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion
            }
            #region check success

           
            if (CheckSuccess(iTEN_KHO_OK, count) && CheckSuccess(iTEN_VI_TRI_KHO_OK, count) && CheckSuccess(iMS_PT_OK, count) &&
                CheckSuccess(iSO_LUONG_OK, count) && CheckSuccess(iDON_GIA_GOC_OK, count) && CheckSuccess(iTIEN_TE_OK, count) &&
                CheckSuccess(iTY_GIA_OK, count) && CheckSuccess(iTY_GIA_USD_OK, count) && CheckSuccess(iKHACH_HANG_OK, count) &&
                CheckSuccess(iXUAT_XU_OK, count) && CheckSuccess(iBAO_HANH_DEN_NGAY_OK, count) && CheckSuccess(iCP_NHAP_KHAU_OK, count) &&
                CheckSuccess(iCP_KHAC_OK, count) && CheckSuccess(iTAX_OK, count) && CheckSuccess(iGHI_CHU_OK, count)
                )
            {
                DialogResult res = XtraMessageBox.Show("Dữ liệu sẵn sàng import vào, bạn có import không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    DoDuLieuVaoData(BTam);
                }
            }
            else
            {
                XtraMessageBox.Show("Một số dữ liệu chưa hợp lệ, bạn vui lòng kiểm tra và sửa lại trước khi import!");
            }
            #endregion
            iLoi = 0;
            Commons.Modules.ObjSystems.XoaTable(BTam);
        }

        private void DoDuLieuVaoData(string BTam)
        {
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            string sPN = "";
            string sSql = "", sBTDuLieu = "TON_TMP" + Commons.Modules.UserName;
            try
            {
                SqlInsert.BeginTransaction();
                Commons.Modules.ObjSystems.XoaTable(sBTDuLieu);
                #region " Do du lieu vao data de update lai cac ms KH, Kho, vi tri kho va tien te
                sSql = " SELECT DISTINCT CONVERT(NVARCHAR(14),NULL) AS [MS_DH_NHAP_PT], " +
                            " CONVERT(NVARCHAR(25),[" + grvSource.Columns[0].FieldName.ToString() + "]) AS [TEN_KHO], CONVERT(INT,NULL) AS MS_KHO, " +
                            " CONVERT(NVARCHAR(25),[" + grvSource.Columns[1].FieldName.ToString() + "]) AS [TEN_VI_TRI], CONVERT(INT,NULL) AS MS_VI_TRI, " +
                            " CONVERT(NVARCHAR(25),[" + grvSource.Columns[2].FieldName.ToString() + "]) AS [MS_PT], " +
                            " ROW_NUMBER() OVER(PARTITION BY [" + grvSource.Columns[2].FieldName.ToString() + "] " +
                            " ORDER BY [" + grvSource.Columns[2].FieldName.ToString() + "])  AS [ID], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[3].FieldName.ToString() + "]) AS [SO_LUONG_CTU], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[3].FieldName.ToString() + "]) AS [SL_THUC_NHAP], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[4].FieldName.ToString() + "]) AS [DON_GIA_GOC], " +
                            " CONVERT(NVARCHAR(50),[" + grvSource.Columns[5].FieldName.ToString() + "]) AS [TEN_NGOAI_TE], CONVERT(NVARCHAR(6),NULL) AS [NGOAI_TE], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[6].FieldName.ToString() + "]) AS [TY_GIA], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[7].FieldName.ToString() + "]) AS [TY_GIA_USD], " +
                            " CONVERT(NVARCHAR(255),[" + grvSource.Columns[8].FieldName.ToString() + "]) AS [TEN_CONG_TY],CONVERT(NVARCHAR(20),NULL)  AS MS_KH, " +
                            " CONVERT(NVARCHAR(25),[" + grvSource.Columns[9].FieldName.ToString() + "]) AS [XUAT_XU], " +
                            " CONVERT(DATETIME,[" + grvSource.Columns[10].FieldName.ToString() + "]) AS [BAO_HANH_DEN_NGAY], " +                                
                            " CONVERT(FLOAT,[" + grvSource.Columns[11].FieldName.ToString() + "]) AS [CP_NHAP_KHAU_VT], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[12].FieldName.ToString() + "]) AS [CP_KHAC_VT], " +
                            " CONVERT(FLOAT,[" + grvSource.Columns[13].FieldName.ToString() + "]) AS [TAX], " +
                            " CONVERT(NVARCHAR(255),[" + grvSource.Columns[14].FieldName.ToString() + "]) AS [GHI_CHU] " +                                
                            " INTO " + sBTDuLieu + " FROM " + BTam ;
                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
//Cap nhap ms kho, ms vi tri, va ms kh
                sSql = " UPDATE " + sBTDuLieu + " SET MS_KHO = B.MS_KHO " +
                            " FROM " + sBTDuLieu + " A INNER JOIN IC_KHO B ON A.TEN_KHO = B.TEN_KHO ";
                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);

                sSql = " UPDATE " + sBTDuLieu + " SET MS_VI_TRI = B.MS_VI_TRI " +
                            " FROM " + sBTDuLieu + " A INNER JOIN VI_TRI_KHO B ON A.MS_KHO = B.MS_KHO " +
                            " AND A.TEN_VI_TRI = B.TEN_VI_TRI ";
                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);

                sSql = " UPDATE " + sBTDuLieu + " SET MS_KH = B.MS_KH " +
                            " FROM " + sBTDuLieu + " A INNER JOIN KHACH_HANG B ON A.TEN_CONG_TY = B.TEN_CONG_TY ";
                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);

                sSql = "UPDATE TON_TMP" +  Commons.Modules.UserName  + " SET NGOAI_TE = B.NGOAI_TE " +
                            " FROM TON_TMP" +  Commons.Modules.UserName  + " A INNER JOIN NGOAI_TE B ON A.TEN_NGOAI_TE = B.TEN_NGOAI_TE";
                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                #endregion

                #region Mo du lieu da cap nhap theo Kho va khach hang de tao tung phieu nhap
                sSql = "SELECT MS_KHO,MS_KH,TEN_KHO,TEN_CONG_TY FROM " + sBTDuLieu + 
                            " GROUP BY TEN_KHO,TEN_CONG_TY,MS_KHO,MS_KH ORDER BY TEN_CONG_TY";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlInsert.ExecuteReader(CommandType.Text, sSql));

                #region Status bar
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = dtTmp.Rows.Count * 3;
                prbIN.Properties.Minimum = 0;
                #endregion
                #region Chay vong for de tu dong insert vao csdl theo kho va kh
                foreach (DataRow row in dtTmp.Rows)
                {
                    #region Tinh tong chi phi theo KH va kho
                    DataTable dtChiPhi = new DataTable();
                    sSql = " SELECT ISNULL(SUM(CONVERT(FLOAT,[CP_NHAP_KHAU_VT])),0) AS CP_NHAP_KHAU_VT, " +
                                " ISNULL(SUM(CONVERT(FLOAT,[CP_KHAC_VT])),0) AS CP_KHAC_VT " +
                                " FROM " + sBTDuLieu + " A WHERE [MS_KHO] = N'" + row["MS_KHO"] + "' " +
                                " AND ISNULL([MS_KH],'') = '" + row["MS_KH"] + "'";
                    dtChiPhi.Load(SqlInsert.ExecuteReader(CommandType.Text, sSql));
                    Double dCPNK = 0, dCPK = 0;
                    if (dtChiPhi.Rows.Count > 0)
                    {
                        dCPNK = Double.Parse(dtChiPhi.Rows[0][0].ToString());
                        dCPK = Double.Parse(dtChiPhi.Rows[0][1].ToString());
                    }
                    #endregion

                    sPN = GetID("PN", datNgay.DateTime.Date, SqlInsert);
                    #region Tao PN tu dong va insert vao table IC_DON_HANG_NHAP
                    sSql = " INSERT INTO [IC_DON_HANG_NHAP] ([MS_DH_NHAP_PT],[SO_PHIEU_XN],[GIO],[NGAY], " +
                                " [MS_KHO],[MS_DANG_NHAP],[NGUOI_NHAP],[GHI_CHU],[LOCK],[LY_DO],[NGUOI_LAP], " +
                                " [MS_LY_DO_NHAP_KT],[CP_NHAP_KHAU],[CP_KHAC]) " +
                                " SELECT N'" + sPN + "' AS [MS_DH_NHAP_PT], N'" + sPN + "' AS [SO_PHIEU_XN], " +
                                " CONVERT(DATETIME,'" + timGio.Time.ToString("MM/dd/yyyy HH:mm:ss") + "') AS [GIO], " +
                                " CONVERT(DATETIME,'" + datNgay.DateTime.Date.ToString("MM/dd/yyyy") + "') AS [NGAY], " +
                                " CONVERT(INT, " + row["MS_KHO"].ToString() + ") AS MS_KHO, CONVERT(INT, " + cboDangNhap.EditValue.ToString() + ") AS [MS_DANG_NHAP], " +
                                " CONVERT(NVARCHAR(20), N'" + (string.IsNullOrEmpty(row["MS_KH"].ToString()) ? cboNguoiNhap.EditValue.ToString() : row["MS_KH"].ToString()) + "') AS [NGUOI_NHAP],  " +
                                " CONVERT(NVARCHAR(255), N'" + txtGhiChu.Text + "') AS GHI_CHU,1 AS [LOCK],  CONVERT(NVARCHAR(255), N'" + txtLyDoNhap.Text + "') AS [LY_DO] ,  " +
                                " CONVERT(NVARCHAR(255), N'" + cboNguoiNhap.Text + "') AS [NGUOI_LAP], " +
                                " CONVERT(NVARCHAR(255), N'" + (cboDNhapKT.Text == "" ? "NULL" : cboDNhapKT.EditValue) + "') AS [MS_LY_DO_NHAP_KT], " +
                                " CONVERT(FLOAT," + dCPNK.ToString() + ") AS [CP_NHAP_KHAU], CONVERT(FLOAT," + dCPNK.ToString() + ") AS [CP_KHAC] ";
                    SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                    #endregion
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion

                    #region Insert vao IC_DON_HANG_NHAP_VAT_TU 
                    sSql = "INSERT INTO [dbo].[IC_DON_HANG_NHAP_VAT_TU]([MS_DH_NHAP_PT],[MS_PT],[ID],[SO_LUONG_CTU],[SL_THUC_NHAP], " +
                                " [DON_GIA],[NGOAI_TE],[TY_GIA],[TY_GIA_USD],[BAO_HANH_DEN_NGAY],[XUAT_XU],[THANH_TIEN], " +
                                " [GHI_CHU],[TAX],[MS_DH_NHAP_PT_GOC],[ID_GOC],[TT_TAX],[DON_GIA_GOC], " +
                                " [CP_NHAP_KHAU_VT],[CP_KHAC_VT],[TONG_CP_NHAP_KHAU_VT],[TONG_CP_KHAC_VT])   " +
                                " SELECT DISTINCT N'" + sPN + "' AS MS_DH_NHAP_PT, MS_PT, ID, SO_LUONG_CTU, SL_THUC_NHAP,    " +
                                " ISNULL(DON_GIA_GOC, 0) + ISNULL(CP_NHAP_KHAU_VT, 0) + ISNULL(CP_KHAC_VT, 0) AS DON_GIA,    " +
                                " NGOAI_TE, TY_GIA,  TY_GIA_USD, BAO_HANH_DEN_NGAY, XUAT_XU,    " +
                                " (ISNULL(DON_GIA_GOC, 0) + ISNULL(CP_NHAP_KHAU_VT, 0) + ISNULL(CP_KHAC_VT, 0)) * ISNULL(SL_THUC_NHAP, 0) AS THANH_TIEN, " +
                                " GHI_CHU,   TAX, N'" + sPN + "' AS MS_DH_NHAP_PT_GOC, ID AS ID_GOC,   " +
                                " CASE ISNULL(TAX, 0) WHEN 0 THEN NULL ELSE  ((ISNULL(DON_GIA_GOC, 0) + ISNULL(CP_NHAP_KHAU_VT, 0) +  " +
                                " ISNULL(CP_KHAC_VT, 0)) * ISNULL(SL_THUC_NHAP, 0)) / TAX END AS TT_TAX,  DON_GIA_GOC,  " +
                                " CP_NHAP_KHAU_VT, CP_KHAC_VT, " +
                                " ISNULL(CONVERT(FLOAT, CP_NHAP_KHAU_VT),0) * CONVERT(FLOAT, SL_THUC_NHAP) AS TONG_CP_NHAP_KHAU_VT,   " +
                                " ISNULL(CONVERT(FLOAT, CP_KHAC_VT),0) * CONVERT(FLOAT, SL_THUC_NHAP) AS TONG_CP_KHAC_VT   " +
                                " FROM " + sBTDuLieu + " WHERE [MS_KHO] = N'" + row["MS_KHO"] + "' " +
                                " AND ISNULL([MS_KH],'') = '" + row["MS_KH"] + "'";
                    SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);

                    sSql = " UPDATE IC_DON_HANG_NHAP SET CP_NHAP_KHAU = B.CPNK , CP_KHAC = B.CPK FROM IC_DON_HANG_NHAP A " +
                                " INNER JOIN (SELECT MS_DH_NHAP_PT, SUM(TONG_CP_KHAC_VT) CPK, SUM(TONG_CP_NHAP_KHAU_VT) CPNK  " +
                                " FROM IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT = N'" + sPN + "' GROUP BY MS_DH_NHAP_PT) B ON " +
                                " A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT WHERE A.MS_DH_NHAP_PT = N'" + sPN + "' ";
                    SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                    #endregion
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion

                    #region Insert vao IC_DON_HANG_NHAP_VAT_TU_CHI_TIET
                    sSql = "INSERT INTO [IC_DON_HANG_NHAP_VAT_TU_CHI_TIET]([MS_DH_NHAP_PT],[MS_PT],[MS_VI_TRI],[ID],[SL_VT]) " +
                                " SELECT DISTINCT N'" + sPN + "' AS [MS_DH_NHAP_PT], " +
                                " MS_PT, MS_VI_TRI, ID, SL_THUC_NHAP FROM " + sBTDuLieu + " WHERE [MS_KHO] = N'" + row["MS_KHO"] + "' " +
                                " AND ISNULL([MS_KH],'') = '" + row["MS_KH"] + "'";
                    SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                    #endregion
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion


                }
                SqlInsert.CommitTransaction();
                MessageBox.Show("Import dữ liệu thành công", "Thông báo");
                #endregion
                #endregion
            }
            catch 
            {
                SqlInsert.RollbackTransaction();
                MessageBox.Show("Import không thành công. Bạn vui lòng kiểm tra lại dữ liệu !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Commons.Modules.ObjSystems.XoaTable(sBTDuLieu);
            prbIN.Position = prbIN.Properties.Maximum;
        }

        public static string GetID(string Hkey, DateTime Hdate, Vietsoft.SqlInfo SqlInsert)
        {
            try
            {
                string ID = String.Empty;
                Hdate = DateTime.ParseExact("01/" + Hdate.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)SqlInsert.ExecuteScalar(CommandType.StoredProcedure, "sp_get_id", Hkey, Hdate);
                return ID;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLoi_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSource = (grdSource.DataSource as DataTable);
                if (iLoi == dtSource.Rows.Count) iLoi = 0;

                for (int i = iLoi; i < dtSource.Rows.Count; i++)
                {
                    if (Boolean.Parse(dtSource.Rows[i]["XOA"].ToString()))
                    {
                        grvSource.FocusedRowHandle = iLoi;
                        grvSource.SelectRow(iLoi);
                        iLoi++;
                        return;
                    }
                    iLoi++;
                }
            }
            catch { iLoi = 0; }
        }
        #region Kiem Du Lieu

        private bool CheckSuccess(int item, int count)
        {
            if (item == count)
                return true;
            return false;
        }

        private int CheckLen(DataRow dr, int col, int giatri, int chieudai, string thongbao)
        {
            try
            {
                if (dr[grvSource.Columns[col].FieldName.ToString()] == DBNull.Value || dr[grvSource.Columns[col].FieldName.ToString()].ToString() == String.Empty)
                { giatri += 1; }
                else
                    if (dr[grvSource.Columns[col].FieldName.ToString()].ToString().Length > chieudai)
                    {
                        dr.SetColumnError(grvSource.Columns[col].FieldName.ToString(), thongbao + " dài hơn " + chieudai + " ký tự");
                        dr["LOI"] = 1;
                    }
                    else
                        giatri += 1;
                return giatri;
            }
            catch { return giatri; }
        }

        private bool KiemKyTu(string strInput, string strChuoi)
        {
            if (strChuoi == "") strChuoi = ChuoiKT;

            for (int i = 0; i < strInput.Length; i++)
            {
                for (int j = 0; j < strChuoi.Length; j++)
                {
                    if (strInput[i] == strChuoi[j])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private bool KiemDuLieu(DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull, int iDoDaiKiem)
        {
            string sDLKiem;
            try
            {
                sDLKiem = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (KiemKyTu(sDLKiem, ChuoiKT))  //KiemKyTu
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " có chứa ký tự đặc biệt !");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem))
                    {
                        if (KiemKyTu(sDLKiem, ChuoiKT))  //KiemKyTu
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " có chứa ký tự đặc biệt !");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                if (iDoDaiKiem != 0)
                {
                    if (sDLKiem.Length > iDoDaiKiem)
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " dài hơn " + iDoDaiKiem.ToString() + " ký tự");
                        dr["XOA"] = 1;
                        return false;
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " lỗi!");
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        private bool KiemDuLieu(DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull, MyUtil obj, string sTableKT, string sCotKT)
        {
            string sChuoiKT;
            try
            {
                sChuoiKT = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sChuoiKT))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {

                        if (obj.KiemGetTonTai(sTableKT, sCotKT, sChuoiKT) == "")
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " này chưa có! bạn có thể double click để chọn");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sChuoiKT))
                    {
                        if (obj.KiemGetTonTai(sTableKT, sCotKT, sChuoiKT) == "")
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " này chưa có! bạn có thể double click để chọn");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " lỗi!");
                dr["XOA"] = 1;
                return false;
            }

            return true;   
        }

        private bool KiemDuLieu(DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull, MyUtil obj, string sTableKT, string sCotKT, int iDoDaiKiem)
        {
            string sChuoiKT;
            try
            {
                sChuoiKT = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sChuoiKT))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {

                        if (obj.KiemGetTonTai(sTableKT, sCotKT, sChuoiKT) == "")
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " này chưa có! bạn có thể double click để chọn");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sChuoiKT))
                    {
                        if (obj.KiemGetTonTai(sTableKT, sCotKT, sChuoiKT) == "")
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " này chưa có! bạn có thể double click để chọn");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                if (iDoDaiKiem != 0)
                {
                    if (sChuoiKT.Length > iDoDaiKiem)
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " dài hơn " + iDoDaiKiem.ToString() + " ký tự");
                        dr["XOA"] = 1;
                        return false;
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " lỗi!");
                dr["XOA"] = 1;
                return false;
            }
            return true;   
        }
        
        private bool KiemDuLieuNgay(DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull)
        {
            string sDLKiem;
            sDLKiem = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
            DateTime DLKiem;

            try
            {
                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem.ToString()))
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        private bool KiemDuLieuNgay(DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull, string GTSoSanh, int iKieuSS)
        {
            // iKieuSS = 1 la so sanh = 
            // iKieuSS = 2 la so sanh nho hon giá trị so sanh
            // iKieuSS = 3 la so sanh nho hon hoac bang
            // iKieuSS = 4 la so sanh lon hon
            // iKieuSS = 5 la so sanh lon hon hoac bang
            try
            {
                string sDLKiem;
                sDLKiem = DateTime.Parse(dr[grvSource.Columns[iCot].FieldName.ToString()].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                DateTime DLKiem;
                DateTime DLSSanh;
                DateTime.TryParse(GTSoSanh, out DLSSanh);

                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }
                        else
                        {
                            if (DateTime.Parse(GTSoSanh) != DateTime.Parse("01/01/1900"))
                            {
                                #region Giá trị so sánh
                                //iKieuSS = 1 la so sanh = 
                                if (iKieuSS == 1)
                                {
                                    if (DLKiem == DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 2 la so sanh nho hon giá trị so sanh
                                if (iKieuSS == 2)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 3 la so sanh nho hon hoac bang
                                if (iKieuSS == 3)
                                {
                                    if (DLKiem <= DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 4 la so sanh lon hon
                                if (iKieuSS == 4)
                                {
                                    if (DLKiem > DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 5 la so sanh lon hon hoac bang
                                if (iKieuSS >= 5)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem))
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }
                        else
                        {
                            if (GTSoSanh != "01/01/1900")
                            {
                                #region Giá trị so sánh
                                //iKieuSS = 1 la so sanh = 
                                if (iKieuSS == 1)
                                {
                                    if (DLKiem == DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 2 la so sanh nho hon giá trị so sanh
                                if (iKieuSS == 2)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 3 la so sanh nho hon hoac bang
                                if (iKieuSS == 3)
                                {
                                    if (DLKiem <= DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 4 la so sanh lon hon
                                if (iKieuSS == 4)
                                {
                                    if (DLKiem > DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 5 la so sanh lon hon hoac bang
                                if (iKieuSS >= 5)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            catch 
            { 
                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        private bool KiemDuLieuSo(DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull)
        {
            string sDLKiem;
            sDLKiem = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(dr[grvSource.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvSource.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();

                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvSource.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(dr[grvSource.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvSource.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();
                        }

                    }
                }

            
            }

            

            return true;
        }

        private bool KiemDuLieuSo(DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull, double GTTKhoang)
        {
            string sDLKiem;
            sDLKiem = dr[grvSource.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;

            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(sDLKiem, out DLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh || DLKiem > GTTKhoang)
                            {
                                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + 
                                    GTSoSanh.ToString() + " và lớn hơn " + GTTKhoang.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvSource.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(sDLKiem, out DLKiem))
                    {
                        dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh || DLKiem > GTTKhoang)
                            {
                                dr.SetColumnError(grvSource.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " +
                                    GTSoSanh.ToString() + " và lớn hơn " + GTTKhoang.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }
                        }
                    }
                }


            }



            return true;
        }

        #endregion

        private void grvSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                GridView view = sender as GridView;
                view.DeleteSelectedRows();
                _table = ((DataView)view.DataSource).ToTable();
                _table.PrimaryKey = new DataColumn[] { _table.Columns["STT"] };

                if (_table.Columns.Count <= 13)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, true, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, false, true);
                grvSource.Columns["STT"].Visible = false;
                grvSource.Columns["LOI"].Visible = false;
                grvSource.Columns["DU_LIEU"].Visible = false;
                iLoi = 0;
            }

        }

        private Boolean GetExcel(string sSheet, out DataTable dtExcel)
        {
            dtExcel = new DataTable();
            

            OleDbConnection excelCon;
            excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + btnFile.Text + ";Extended Properties=\"Excel 12.0;HDR=YES\";");
            try
            {
                excelCon.Open();
            }
            catch
            {
                excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + btnFile.Text + ";Extended Properties=Excel 8.0");
                try
                {
                    excelCon.Open();
                }
                catch { return false; }
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand("select * from [" + sSheet + "$]", excelCon);
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "general");

                dtExcel = ds.Tables["general"];
            }
            catch { return false; }
            excelCon.Close();
            return true;
        }

        void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }

        //void ConvertToDataTable()
        private Boolean GetNotExcel(string sSheet, out DataTable dtTmp, out string sLoi)
        {
            int iSDong = 0;
            int i = 0;
            System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
            DataTable dt = new DataTable();
            try
            {
                InitializeWorkbook(btnFile.Text);
                ISheet sheet = hssfworkbook.GetSheet(sSheet);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                rows.MoveNext();
                rows.MoveNext();
                IRow row1Cot = (HSSFRow)rows.Current;
                rows.Reset();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    if (iSDong == 43)
                    { 
                    
                    }
                    if (iSDong == 0)
                    {

                        for (int j = 0; j < row.LastCellNum; j++)
                        {
                            string sTenCot;
                            ICell cell1 = row.GetCell(j);
                            ICell cellCot = row1Cot.GetCell(j);

                            //string sTenCot = "";
                            try
                            {
                                sTenCot = cell1.ToString().Trim();
                            }
                            catch { sTenCot = ""; }
                            if (sTenCot == "")
                                sTenCot = "A" + j;
                            try
                            {
                                if (cellCot == null)
                                    dt.Columns.Add(sTenCot, typeof(string));
                                else
                                {
                                    switch (cellCot.CellType)
                                    {
                                        case NPOI.SS.UserModel.CellType.Numeric:
                                            string sFormat = cellCot.CellStyle.GetDataFormatString().ToUpper();
                                            if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                            {
                                                dt.Columns.Add(sTenCot, typeof(DateTime));
                                            }
                                            else
                                            {
                                                dt.Columns.Add(sTenCot, typeof(float));
                                            }
                                            break;
                                        case NPOI.SS.UserModel.CellType.Boolean:
                                            dt.Columns.Add(sTenCot, typeof(bool));
                                            break;
                                        default:
                                            dt.Columns.Add(sTenCot, typeof(string));
                                            break;
                                    }
                                }
                            }
                            catch { dt.Columns.Add(sTenCot, typeof(string)); }
                        }


                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        i = 0;
                        for (i = 0; i < row.LastCellNum; i++)
                        {
                            if (i == 3)
                            {

                            }
                            ICell cell = row.GetCell(i);
                            if (cell != null)
                            {
                                //dr[i] = cell.ToString();

                                try
                                {

                                    switch (cell.CellType)
                                    {
                                        case NPOI.SS.UserModel.CellType.Numeric:

                                            try
                                            {
                                                string sFormat = cell.CellStyle.GetDataFormatString().ToUpper();
                                                if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                                {
                                                    DateTime dtNgay;
                                                    try
                                                    {
                                                        dtNgay = DateTime.Parse(cell.DateCellValue.ToString(), dtF, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                    }
                                                    catch { DateTime.TryParse(cell.DateCellValue.ToString(), out dtNgay); }

                                                    try
                                                    {
                                                        dr[i] = dtNgay;
                                                    }
                                                    catch
                                                    {
                                                        dr[i] = cell.NumericCellValue;
                                                    }
                                                }
                                                else
                                                {
                                                    double dGTi = 0;
                                                    if (sFormat.Contains("GENERAL"))
                                                    {
                                                        dr[i] = cell.NumericCellValue;
                                                    }
                                                    else
                                                    {

                                                        sFormat = "0.000000";
                                                        int index = sFormat.IndexOf(".");
                                                        if (index > 0)
                                                            dGTi = Math.Round(cell.NumericCellValue, sFormat.Substring(index).Length);
                                                        else
                                                            dGTi = cell.NumericCellValue;

                                                        dr[i] = dGTi;
                                                    }
                                                }
                                            }
                                            catch { dr[i] = cell.NumericCellValue; }

                                            break;
                                        case NPOI.SS.UserModel.CellType.Boolean:
                                            dr[i] = cell.BooleanCellValue.ToString();
                                            break;
                                        case NPOI.SS.UserModel.CellType.Blank:
                                            //dr[i] = null;
                                            break;
                                        default:
                                            dr[i] = cell.ToString();
                                            break;
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        dr[i] = cell.ToString();
                                    }
                                    catch { }
                                    //dt.Columns.Add(sTenCot, typeof(string)); }
                                }
                            }

                        }
                        dt.Rows.Add(dr);
                    }
                    iSDong++;
                }

            }
            catch (Exception ex)
            {

                sLoi = "GNE : " + iSDong.ToString() + "-" + i.ToString() + "\n" + ex.Message;
                dtTmp = null;
                return false;
            }
            //dataSet1.Tables.Add(dt);
            dtTmp = dt;
            sLoi = "";
            return true;
        }

        private void chkGT_CheckedChanged(object sender, EventArgs e)
        {
            cboSheet_EditValueChanged(sender, e);
        }

    }
}