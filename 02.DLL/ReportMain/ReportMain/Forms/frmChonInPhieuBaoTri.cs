using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using ImportExcels;
using Microsoft.ApplicationBlocks.Data;
using Spire.Xls;

namespace ReportMain
{
    public partial class frmChonInPhieuBaoTri : DevExpress.XtraEditors.XtraForm
    {
        //iLoaiIP=0 là In nhieu phieu bao tri
        //iLoaiIP=1 là import phụ tùng CHO TRUNG NGUYEN
        //iLoaiIP=2 là import PHIEU XUAT CHO TRUNG NGUYEN
        //iLoaiIP=3 là so sanh vat tu voi file ton (Load file ton them 2 cot vtpt va chon de so sanh)
        public int iLoaiIP = 0;
        string fileName = null;
        string sSql = "";
        private DataTable dtPBT;
        int idem = 0;

        public DataTable dtPhieuBaoTri { get { return dtPBT; } set { dtPBT = value; } }
        private string sNLap;
        public string sNguoiLap { get { return sNLap; } set { sNLap = value; } }

        private string sLDo;
        public string sLyDo { get { return sLDo; } set { sLDo = value; } }

        private string sNgayL;
        public string sNgayLap { get { return sNgayL; } set { sNgayL = value; } }

        private string sDDiem;
        public string ssDiaDiem { get { return sDDiem; } set { sDDiem = value; } }

        private string sDChuyen;
        public string sDayChuyen { get { return sDChuyen; } set { sDChuyen = value; } }


        public frmChonInPhieuBaoTri()
        {
            InitializeComponent();
        }

        private void frmChonInPhieuBaoTri_Load(object sender, EventArgs e)
        {

            if (iLoaiIP == 0)
            {
                LoadChonPBT();
            }
            else
            {
                if (iLoaiIP == 1) CreateMenuDVTLoaiVT();
                btnALL.Visible = !btnALL.Visible;
                btnNotALL.Name = "btnChonFile";

            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if(iLoaiIP == 1)
            {
                this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "frmImportPhuTung", Commons.Modules.TypeLanguage);
            }
            if (iLoaiIP == 2)
            {
                this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "frmImportPhieuNhap", Commons.Modules.TypeLanguage);
            }
            if (iLoaiIP == 3)
            {
                btnExportTemplate.Visible = false;
                string sSql = "SELECT CONVERT(BIT,0) AS CHON, T1.VTPT AS [Mã VTPT],T2.MS_PT AS MS_PT_CMMS,  T1.TEN_VTPT AS [Tên VTPT],T1.DVT AS ĐVT ,T1.SL_TON AS [Số Lượng tồn] ,T1.GIA_TRI_TON AS [Giá trị tồn], CONVERT(BIT,0) AS XOA  FROM(SELECT * FROM dbo.VTPT_TON T1 WHERE NGAY = (SELECT MAX(NGAY) FROM dbo.VTPT_TON)) T1 LEFT JOIN dbo.IC_PHU_TUNG T2 ON T1.MS_PT = T2.MS_PT   ORDER BY T1.VTPT";
                DataTable dtemp = new DataTable();
                dtemp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtemp.Columns["CHON"].ReadOnly = false;
                dtemp.Columns["XOA"].ReadOnly = false;
                if (dtemp.Columns.Count <= 6)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtemp, true, true, true, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtemp, true, true, false, true);
                try
                {
                    grvBC.Columns["LOI"].Visible = false;
                    grvBC.Columns["DU_LIEU"].Visible = false;
                }
                catch { }
                grvBC.Columns["CHON"].Caption = "Chọn";
                grvBC.Columns["MS_PT_CMMS"].Caption = "MSPT CMMS";
                grvBC.Columns[1].Caption = "MSPT ERP";
                btnNotALL.Visible = false;
            }
        }




        #region Hàm load excelra datatable
        private DataTable MGetData2xls(String Path)
        {
            HSSFWorkbook wb;
            HSSFSheet sh;
            try
            {

                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    wb = new HSSFWorkbook(fs);
                    fs.Close();
                }
                DataTable DT = new DataTable();
                DT.Rows.Clear();
                DT.Columns.Clear();
                System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
                sh = (HSSFSheet)wb.GetSheetAt(0);
                #region Status bar
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = sh.LastRowNum + 10;
                prbIN.Properties.Minimum = 0;
                #endregion

                HSSFFormulaEvaluator formula = new HSSFFormulaEvaluator(wb);
                formula.EvaluateAll();
                int i = 0;
                int j1 = 0;
                try
                {
                    for (j1 = 0; j1 < sh.GetRow(i).Cells.Count; j1++)
                    {
                        var cell = sh.GetRow(i).GetCell(j1);
                        if (cell != null)
                        {

                            try
                            {
                                DT.Columns.Add(sh.GetRow(i).GetCell(j1).StringCellValue, typeof(string));
                            }
                            catch
                            { DT.Columns.Add(sh.GetRow(i).GetCell(j1).StringCellValue + "F" + j1.ToString(), typeof(string)); }
                        }
                        else
                        {
                            DT.Columns.Add("NULL" + j1.ToString(), typeof(string));
                        }
                    }
                }
                catch (Exception ex12)
                {

                    XtraMessageBox.Show(ex12.Message.ToString());
                    return null;
                }
                int iTongCot = sh.GetRow(i).Cells.Count;
                i = 1;
                int j;
                while (sh.GetRow(i) != null)
                {
                    DT.Rows.Add();
                    // write row value
                    for (j = 0; j < iTongCot; j++)
                    {
                        var cell = sh.GetRow(i).GetCell(j);

                        if (cell != null)
                        {

                            try
                            {
                                formula.EvaluateInCell(cell);
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
                                                    DT.Rows[i - 1][j] = dtNgay;
                                                }
                                                catch
                                                {
                                                    DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                                }
                                            }
                                            else
                                            {
                                                double dGTi = 0;
                                                sFormat = "0.000000";
                                                int index = sFormat.IndexOf(".");
                                                if (index > 0)
                                                    dGTi = Math.Round(sh.GetRow(i).GetCell(j).NumericCellValue, sFormat.Substring(index).Length);
                                                else
                                                    dGTi = sh.GetRow(i).GetCell(j).NumericCellValue;

                                                DT.Rows[i - 1][j] = dGTi;
                                            }


                                        }
                                        catch { DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue; }

                                        break;
                                    case NPOI.SS.UserModel.CellType.Boolean:
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).BooleanCellValue.ToString();
                                        break;

                                    default:
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                        break;
                                }

                            }
                            catch (Exception ex1)
                            {

                                XtraMessageBox.Show(ex1.Message.ToString() + "\n " + " row : " + i.ToString() + " col : " + j.ToString());
                                return null;
                            }
                        }
                    }

                    i++;
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion
                }
                sh.CloneSheet(wb);
                wb.Close();
                return DT;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        private DataTable MGetData2xlsx(String Path)
        {
            XSSFWorkbook wb;
            XSSFSheet sh;
            int i = 0;
            try
            {
                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    wb = new XSSFWorkbook(fs);
                    fs.Close();
                }

                DataTable DT = new DataTable();
                DT.Rows.Clear();
                DT.Columns.Clear();
                System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
                // get sheet
                sh = (XSSFSheet)wb.GetSheetAt(0);
                #region Status bar
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = sh.LastRowNum + 10;
                prbIN.Properties.Minimum = 0;
                #endregion
                i = 0;

                for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                {
                    var cell = sh.GetRow(i).GetCell(j);
                    try
                    {
                        if (sh.GetRow(i).GetCell(j).StringCellValue.ToString().ToUpper() == "STT")
                        { DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue, typeof(float)); }
                        else
                        {
                            DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue, typeof(string));
                        }
                    }
                    catch
                    { DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue + "F" + j.ToString(), typeof(string)); }
                }
                int iTongCot = sh.GetRow(i).Cells.Count;

                i = 1;
                while (sh.GetRow(i) != null)
                {
                    DT.Rows.Add();
                    // write row value
                    for (int j = 0; j < iTongCot; j++)
                    {
                        //if (i == 1828)
                        //    i = i;

                        var cell = sh.GetRow(i).GetCell(j);

                        if (cell != null)
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
                                                DT.Rows[i - 1][j] = dtNgay;
                                            }
                                            catch
                                            {
                                                DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                            }
                                        }
                                        else
                                        {
                                            double dGTi = 0;
                                            sFormat = "0.000000";
                                            int index = sFormat.IndexOf(".");
                                            if (index > 0)
                                                dGTi = Math.Round(sh.GetRow(i).GetCell(j).NumericCellValue, sFormat.Substring(index).Length);
                                            else
                                                dGTi = sh.GetRow(i).GetCell(j).NumericCellValue;

                                            DT.Rows[i - 1][j] = dGTi;
                                        }


                                    }
                                    catch { DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue; }

                                    break;
                                case NPOI.SS.UserModel.CellType.Boolean:
                                    DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).BooleanCellValue.ToString();
                                    break;

                                default:
                                    try
                                    {
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                    }
                                    catch { }
                                    break;
                            }

                        }
                    }

                    i++;
                    #region prb
                    try
                    {
                        prbIN.PerformStep();
                        prbIN.Update();
                    }
                    catch { }
                    #endregion
                }
                wb.Close();
                return DT;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " - ROW : " + i.ToString());
                return null;
            }
        }

        private void MLoadExcel()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "All Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" + "All Files (*.*)|*.*";
                if (oFile.ShowDialog() != DialogResult.OK) return;


                fileName = oFile.FileName;
                if (!System.IO.File.Exists(fileName)) return;


                this.Cursor = Cursors.WaitCursor;
                var FileExt = Path.GetExtension(fileName);
                DataTable _table = new DataTable();


                if (FileExt.ToLower() == ".xls")
                    _table = MGetData2xls(fileName);
                else if (FileExt.ToLower() == ".xlsx")
                    _table = MGetData2xlsx(fileName);



                prbIN.Position = prbIN.Properties.Maximum;
                DataTable dtemp = new DataTable();
                dtemp = _table;
                this.grdBC.DataSource = null;
                grvBC.Columns.Clear();
                if (_table != null)
                {
                    try
                    {
                        dtemp.Columns.Add("XOA", System.Type.GetType("System.Boolean"));
                    }
                    catch { }



                    try
                    {
                        dtemp.DefaultView.Sort = "[" + dtemp.Columns[0].ColumnName.ToString() + "]";
                    }
                    catch { }


                    if (iLoaiIP == 3)
                    {
                        try { dtemp.Columns.Add("CHON", typeof(Boolean)).SetOrdinal(0); } catch { }
                        try { dtemp.Columns.Add("MS_PT_CMMS", typeof(String)).SetOrdinal(2); } catch { }

                        string sBT = "IPTKho" + Commons.Modules.UserName;
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtemp, "");

                        sBT = "UPDATE " + sBT + " SET CHON = 0, MS_PT_CMMS = T2.MS_PT FROM " + sBT + " T1 LEFT	 JOIN dbo.IC_PHU_TUNG T2 ON T1.[Mã VTPT] = T2.MS_PT_CTY";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sBT);

                        sBT = "SELECT * FROM IPTKho" + Commons.Modules.UserName ;
                        dtemp = new DataTable();
                        dtemp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sBT));

                        try
                        {
                            dtemp.DefaultView.Sort = "[" + dtemp.Columns[1].ColumnName.ToString() + "]";
                        }
                        catch { }
                    }


                    if (dtemp.Columns.Count <= 6)
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtemp, true, true, true, true);
                    else
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtemp, true, true, false, true);
                    try
                    {
                        grvBC.Columns["LOI"].Visible = false;
                        grvBC.Columns["DU_LIEU"].Visible = false;
                    }
                    catch { }

                    if (iLoaiIP == 3)
                    {
                        grvBC.Columns["CHON"].Caption = "Chọn";
                        grvBC.Columns["MS_PT_CMMS"].Caption = "MSPT CMMS";
                        grvBC.Columns[1].Caption = "MSPT ERP";
                        //grvBC.Columns["XOA"].Visible = false;

                    }
                    this.Cursor = Cursors.Default;
                }

                else
                {
                    grdBC.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Hàm chọn phiếu bảo trì
        private void LoadChonPBT()
        {
            try
            {
                if (dtPBT.Columns[0].ColumnName.ToUpper() != "CHON")
                {
                    System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                    newColumn.DefaultValue = "0";
                    dtPBT.Columns.Add(newColumn);

                    newColumn.DefaultValue = false;
                    newColumn.SetOrdinal(0);
                }
            }
            catch { }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtPBT, true, true, false, true);
            if (dtPBT == null) return;
            for (int i = 1; i <= dtPBT.Columns.Count - 1;)
            {
                dtPBT.Columns[i].ReadOnly = true;
                grvBC.Columns[i].OptionsColumn.ReadOnly = true;
                i++;
            }
            try
            {
                grvBC.Columns["MS_N_XUONG"].Visible = false;
                grvBC.Columns["MS_LOAI_MAY"].Visible = false;
                grvBC.Columns["MS_NHOM_MAY"].Visible = false;
                grvBC.Columns["MS_LOAI_BT"].Visible = false;
                grvBC.Columns["GIO_LAP"].Visible = false;
                grvBC.Columns["MS_UU_TIEN"].Visible = false;
                grvBC.Columns["NGUOI_LAP"].Visible = false;
                grvBC.Columns["USERNAME_NGUOI_LAP"].Visible = false;
                grvBC.Columns["HO_TEN"].Visible = false;
                grvBC.Columns["NGUOI_GIAM_SAT"].Visible = false;
                grvBC.Columns["NGAY_KT_KH"].Visible = false;
                grvBC.Columns["GIO_HONG"].Visible = false;
                grvBC.Columns["NGAY_HONG"].Visible = false;
                grvBC.Columns["MS_NGUYEN_NHAN"].Visible = false;
                grvBC.Columns["TINH_TRANG_PBT"].Visible = false;
                grvBC.Columns["LY_DO_BT"].Visible = false;
                grvBC.Columns["MS_HT"].Visible = false;
                grvBC.Columns["CHON"].Width = 60;
                grvBC.Columns["TEN_N_XUONG"].Width = 170;
                grvBC.Columns["MS_PHIEU_BAO_TRI"].Width = 120;
                grvBC.Columns["SO_PHIEU_BAO_TRI"].Width = 120;
                grvBC.Columns["MS_MAY"].Width = 90;
                grvBC.Columns["TEN_TINH_TRANG"].Width = 110;
                grvBC.Columns["TEN_LOAI_BT"].Width = 100;
                grvBC.Columns["NGAY_LAP"].Width = 85;
                grvBC.Columns["TEN_UU_TIEN"].Width = 120;
                grvBC.Columns["NGAY_BD_KH"].Width = 85;
                grvBC.Columns["DHX"].Width = 140;
            }
            catch
            { }

        }
        private void ThucHienBT()
        {
            try
            {
                DataTable dtTmp1 = new DataTable();
                DataTable dtTmp = new DataTable();
                dtTmp = new DataTable();

                dtTmp1 = (DataTable)grdBC.DataSource;
                dtTmp = dtTmp1.Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                    return;
                }
                if (Commons.Modules.sPrivate.ToUpper() == "VECO")
                {
                    dtPBT = new DataTable();
                    dtPBT = dtTmp;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string sSql = "PBT_IN";
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

                    dtTmp = new DataTable();
                    DataSet dtSet = new DataSet();
                    if (Commons.Modules.sPrivate.ToUpper() == "VIFON")
                    {
                        dtSet = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(
                            Commons.IConnections.ConnectionString, "GetBCPBTVF", Commons.Modules.TypeLanguage);

                    }
                    else
                    {
                        dtSet = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(
                            Commons.IConnections.ConnectionString, "GetBCPBT", Commons.Modules.TypeLanguage);
                    }



                    frmReport frmPBT = new frmReport();
                    if (Commons.Modules.sPrivate.ToUpper() == "PILMICO")
                        frmPBT.rptName = "rptInAllPBTPIL";
                    else
                    {
                        frmPBT.rptName = "rptInAllPBT";
                    }



                    dtTmp = new DataTable();
                    dtTmp = dtSet.Tables[0];
                    dtTmp.TableName = "NHAN_VIEN_THUC_HIEN";
                    frmPBT.AddDataTableSource(dtTmp);


                    dtTmp = new DataTable();
                    dtTmp = dtSet.Tables[1];
                    dtTmp.TableName = "DANH_SACH_CONG_VIEC";
                    frmPBT.AddDataTableSource(dtTmp);

                    dtTmp = new DataTable();
                    dtTmp = dtSet.Tables[2];
                    dtTmp.TableName = "PHU_TUNG_SU_DUNG";
                    frmPBT.AddDataTableSource(dtTmp);

                    if (dtSet.Tables[0].Rows.Count == 0 && dtSet.Tables[1].Rows.Count == 0 && dtSet.Tables[2].Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                        return;
                    }
                    DataTable TbTieuDe = new DataTable();
                    TbTieuDe = TieuDe();
                    frmPBT.AddDataTableSource(TbTieuDe);
                    frmPBT.ShowDialog(this);
                }
                if (Commons.Modules.sPrivate == "VECO")
                    DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return;

            }
        }
        #endregion 

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            if (iLoaiIP == 0)
            {
                Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
            }
            else
            {
                MLoadExcel();
            }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (grdBC.DataSource == null) return;

            DataTable dtPBT = new DataTable();
            dtPBT = (DataTable)grdBC.DataSource;
            if (iLoaiIP == 0)
            {
                try
                {
                    string dk = "";
                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  SO_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtPBT.DefaultView.RowFilter = dk;
                }
                catch { dtPBT.DefaultView.RowFilter = ""; }
                return;
            }
            else
            {
                try
                {

                    string dk = "";
                    for (int j = 0; j < dtPBT.Columns.Count; j++)
                    {
                        string sDataType = dtPBT.Columns[j].DataType.ToString().ToLower();
                        if (sDataType == "system.string")
                        {
                            if (txtTKiem.Text.Length != 0) dk = " OR  [" + dtPBT.Columns[j].ColumnName + "] LIKE '%" + txtTKiem.Text + "%' " + dk;
                        }
                    }


                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtPBT.DefaultView.RowFilter = dk;
                }
                catch { dtPBT.DefaultView.RowFilter = ""; }
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            switch (iLoaiIP)
            {
                case 1:
                    {
                        if (grvBC.RowCount == 0)
                        {
                            XtraMessageBox.Show("Chưa có dữ liệu để import"); return;
                        }
                        DanhMucVatTu((DataTable)grdBC.DataSource);
                        break;
                    }
                case 2:
                    {
                        if (grvBC.RowCount == 0)
                        {
                            XtraMessageBox.Show("Chưa có dữ liệu để import"); return;
                        }
                        PXK((DataTable)grdBC.DataSource);
                        break;
                    }
                case 3:
                    {
                        DataTable dt = new DataTable();
                        dt = ((DataTable)grdBC.DataSource).Copy();
                        dt.DefaultView.RowFilter = "CHON = 1";
                        if ((dt.DefaultView.ToTable().Rows.Count == 0))
                        {
                            XtraMessageBox.Show("Chưa có dữ liệu để import"); return;
                        }
                        try
                        {
                            Commons.Modules.SQLString = dt.DefaultView.ToTable().Rows.Count.ToString();
                        }
                        catch { Commons.Modules.SQLString = "0"; }
                        DanhMucVatTu((DataTable)grdBC.DataSource);
                        break;
                    }
                default:
                    ThucHienBT();
                    break;
            }
        }

        private DataTable TieuDe()
        {

            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("NGUOI_LAP");
            TbTieuDe.Columns.Add("NGAY_LAP");
            TbTieuDe.Columns.Add("DIA_DIEM");
            TbTieuDe.Columns.Add("DAY_CHUYEN");
            TbTieuDe.Columns.Add("NHAN_VIEN_THUC_HIEN");
            TbTieuDe.Columns.Add("HO_TEN");
            TbTieuDe.Columns.Add("CHUYEN_MON");
            TbTieuDe.Columns.Add("TRINH_DO");
            TbTieuDe.Columns.Add("BAC_THO");
            TbTieuDe.Columns.Add("DS_CONG_VIEC");
            TbTieuDe.Columns.Add("PHIEU_BAO_TRI");
            TbTieuDe.Columns.Add("BAT_DAU");
            TbTieuDe.Columns.Add("KET_THUC");
            TbTieuDe.Columns.Add("MS_THIET_BI");
            TbTieuDe.Columns.Add("TEN_THIET_BI");
            TbTieuDe.Columns.Add("BO_PHAN");
            TbTieuDe.Columns.Add("CONG_VIEC");
            TbTieuDe.Columns.Add("THUC_HIEN");
            TbTieuDe.Columns.Add("VAT_TU");
            TbTieuDe.Columns.Add("DANH_GIA");
            TbTieuDe.Columns.Add("CN_YCSDCT");
            TbTieuDe.Columns.Add("PHU_TUNG_SU_DUNG");
            TbTieuDe.Columns.Add("MSTB");
            TbTieuDe.Columns.Add("BO_PHAN_TB");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("DON_VI_TINH");
            TbTieuDe.Columns.Add("Y_KIEN_NNT");
            TbTieuDe.Columns.Add("NGHIEM_THU");
            TbTieuDe.Columns.Add("KIEM_TRA");
            TbTieuDe.Columns.Add("NGUOI_THUC_HIEN");
            TbTieuDe.Columns.Add("TGNT");
            TbTieuDe.Columns.Add("TRANG");
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("YCNSDCT");
            TbTieuDe.Columns.Add("LYDO");
            TbTieuDe.Columns.Add("TMP0");
            TbTieuDe.Columns.Add("TMP1");
            TbTieuDe.Columns.Add("TMP2");
            TbTieuDe.Columns.Add("TMP3");
            TbTieuDe.Columns.Add("TMP4");
            TbTieuDe.Columns.Add("TMP5");
            TbTieuDe.Columns.Add("TMP6");
            TbTieuDe.Columns.Add("TMP7");
            TbTieuDe.Columns.Add("TMP8");
            TbTieuDe.Columns.Add("TMP9");

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "NGUOI_LAP", Commons.Modules.TypeLanguage) + " : " + sNLap;
            rTitle["NGAY_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "NGAY_LAP", Commons.Modules.TypeLanguage) + " : " + sNgayL;
            rTitle["DIA_DIEM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "DIA_DIEM", Commons.Modules.TypeLanguage) + " : " + sDDiem;
            rTitle["DAY_CHUYEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "DAY_CHUYEN", Commons.Modules.TypeLanguage) + " : " + sDChuyen;
            rTitle["NHAN_VIEN_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "NHAN_VIEN_THUC_HIEN", Commons.Modules.TypeLanguage);
            rTitle["HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "HO_TEN", Commons.Modules.TypeLanguage);
            rTitle["CHUYEN_MON"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "CHUYEN_MON", Commons.Modules.TypeLanguage);
            rTitle["TRINH_DO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TRINH_DO", Commons.Modules.TypeLanguage);
            rTitle["BAC_THO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "BAC_THO", Commons.Modules.TypeLanguage);
            rTitle["DS_CONG_VIEC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "DS_CONG_VIEC", Commons.Modules.TypeLanguage);
            rTitle["PHIEU_BAO_TRI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "PHIEU_BAO_TRI", Commons.Modules.TypeLanguage);
            rTitle["BAT_DAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "BAT_DAU", Commons.Modules.TypeLanguage);
            rTitle["KET_THUC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "KET_THUC", Commons.Modules.TypeLanguage);
            rTitle["MS_THIET_BI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "MS_THIET_BI", Commons.Modules.TypeLanguage);
            rTitle["TEN_THIET_BI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TEN_THIET_BI", Commons.Modules.TypeLanguage);
            rTitle["BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "BO_PHAN", Commons.Modules.TypeLanguage);
            rTitle["CONG_VIEC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "CONG_VIEC", Commons.Modules.TypeLanguage);
            rTitle["THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "THUC_HIEN", Commons.Modules.TypeLanguage);
            rTitle["VAT_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "VAT_TU", Commons.Modules.TypeLanguage);
            rTitle["DANH_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "DANH_GIA", Commons.Modules.TypeLanguage);
            rTitle["CN_YCSDCT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "CN_YCSDCT", Commons.Modules.TypeLanguage);
            rTitle["PHU_TUNG_SU_DUNG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "PHU_TUNG_SU_DUNG", Commons.Modules.TypeLanguage);
            rTitle["MSTB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "MSTB", Commons.Modules.TypeLanguage);
            rTitle["BO_PHAN_TB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "BO_PHAN_TB", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["DON_VI_TINH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "DON_VI_TINH", Commons.Modules.TypeLanguage);
            rTitle["Y_KIEN_NNT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "Y_KIEN_NNT", Commons.Modules.TypeLanguage);
            rTitle["NGHIEM_THU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "NGHIEM_THU", Commons.Modules.TypeLanguage);
            rTitle["KIEM_TRA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "KIEM_TRA", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "NGUOI_THUC_HIEN", Commons.Modules.TypeLanguage);
            rTitle["TGNT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TGNT", Commons.Modules.TypeLanguage);
            rTitle["TRANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TRANG", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["YCNSDCT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "YCNSDCT", Commons.Modules.TypeLanguage);
            rTitle["LYDO"] = sLDo;

            rTitle["TMP0"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP0", Commons.Modules.TypeLanguage);
            rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP1", Commons.Modules.TypeLanguage);
            rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP2", Commons.Modules.TypeLanguage);
            rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP3", Commons.Modules.TypeLanguage);
            rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP4", Commons.Modules.TypeLanguage);
            rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP5", Commons.Modules.TypeLanguage);
            rTitle["TMP6"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP7", Commons.Modules.TypeLanguage);
            rTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP8", Commons.Modules.TypeLanguage);
            rTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP9", Commons.Modules.TypeLanguage);
            rTitle["TMP9"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonInPhieuBaoTri", "TMP9", Commons.Modules.TypeLanguage);
            TbTieuDe.TableName = "TD_IN_PBT";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }
        
        #region 1. Import IC_Phụ tùng
        private void DanhMucVatTu(DataTable dtSource)
        {

            MyUtil obj = new MyUtil();
            string sKiemTra = "";
            int count = grvBC.RowCount;
            Boolean bChon = true;
            if (iLoaiIP == 3) count = int.Parse(Commons.Modules.SQLString);
            
            int col = 0;
            string sBt = "KIEM_MSVT" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBt, dtSource, "");

            #region declare varian
            int ItemOK = 0;
            int TenVTOK = 0;
            int LoaiVTOK = 0;
            int MsVTuOK = 0;
            int DVTOK = 0;
            #endregion

            #region Status bar
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = count;
            prbIN.Properties.Minimum = 0;
            #endregion

            #region kiem tra Danh Muc Vat tu
            foreach (DataRow dr in dtSource.Rows)
            {
                try // chi kiem các vtpt có chon import
                {if (iLoaiIP == 1) bChon = true; else bChon = Boolean.Parse(dr["CHON"].ToString());}
                catch { bChon = true; }

                if (bChon)
                {
                    dr["XOA"] = 0;
                    #region Kiem Tra
                    dr.ClearErrors();
                    col = 0;
                    #region Item code MS_PT_CTY
                    if (iLoaiIP == 1) col = 0; else col = 1;
                    sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                    if (string.IsNullOrEmpty(sKiemTra))
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Item code không được để trống!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        if (obj.KiemGetTonTai("IC_PHU_TUNG", "MS_PT_CTY", sKiemTra) != "")
                        {
                            dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Item code này đã tồn tại trong cơ sở dữ liệu!");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            string sSQl;
                            sSQl = "SELECT * FROM KIEM_MSVT" + Commons.Modules.UserName + " WHERE [" + grvBC.Columns[col].FieldName.ToString() + "] = N'" +
                                sKiemTra + "'";
                            DataTable dtTmp = new DataTable();
                            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSQl));
                            if (dtTmp.Rows.Count > 1)
                            {
                                dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Item code này đã tồn tại trong file!");
                                dr["XOA"] = 1;
                            }
                            else
                                ItemOK = CheckLen(dr, col, ItemOK, 25, "Item code");
                        }
                    }
                    #endregion
                    col = 1;

                    #region Tên vật tư
                    if (iLoaiIP == 1) col = 1; else col = 3;
                    sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                    if (string.IsNullOrEmpty(sKiemTra))
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên vật tư phụ tùng không được để trống!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        if (obj.KiemGetTonTai("IC_PHU_TUNG", "TEN_PT", sKiemTra) != "")
                        {
                            dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên vật tư phụ tùng này đã tồn tại trong cơ sở dữ liệu!");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            string sSQl;
                            sSQl = "SELECT * FROM KIEM_MSVT" + Commons.Modules.UserName + " WHERE [" + grvBC.Columns[col].FieldName.ToString() + "] = N'" +
                                sKiemTra + "'";
                            DataTable dtTmp = new DataTable();
                            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSQl));
                            if (dtTmp.Rows.Count > 1)
                            {
                                dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên vật tư phụ tùng này đã tồn tại trong file!");
                                dr["XOA"] = 1;
                            }
                            else
                                TenVTOK = CheckLen(dr, col, TenVTOK, 100, "Tên vật tư phụ tùng");
                        }
                    }
                    #endregion

                    col = 2;
                    #region Loại vật tư phụ tùng


                    //kiểm tra loại vật tư nếu không có thì insert vào
                    //sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();

                    if (iLoaiIP == 1)
                    {
                        sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                        if (string.IsNullOrEmpty(sKiemTra))
                        {
                            dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên loại vật tư không được để trống!");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            if (CheckLen(dr, col, LoaiVTOK, 50, "Tên loại vật tư") != LoaiVTOK)
                            {
                                if (obj.KiemGetTonTai("LOAI_VT", "TEN_LOAI_VT_TV", sKiemTra) == "")
                                {
                                    //tồn tại thì thêm vào
                                    //sSql = "INSERT INTO dbo.LOAI_VT( MS_LOAI_VT, TEN_LOAI_VT_TV, TEN_LOAI_VT_TA,TEN_LOAI_VT_TH, VAT_TU )VALUES(((SELECT  MAX(CONVERT(INT,MS_LOAI_VT))  FROM dbo.LOAI_VT WHERE  ISNUMERIC(MS_LOAI_VT) = 1) + 1),N'" + sKiemTra + "',N'" + sKiemTra + "',N'" + sKiemTra + "',0)";
                                    //SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Loại vật tư không có trong CSDL!");
                                    dr["XOA"] = 1;
                                }
                                else LoaiVTOK += 1;
                            }

                        }

                    }
                    else LoaiVTOK += 1;

                    #endregion

                    col = 4;
                    #region Mã vật tư CMMS
                    if (iLoaiIP == 1) col = 4; else col = 2;

                    sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                    if (string.IsNullOrEmpty(sKiemTra))
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã vật tư phụ tùng không được để trống!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        if (obj.KiemGetTonTai("IC_PHU_TUNG", "MS_PT", sKiemTra) != "")
                        {
                            dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã vật tư phụ tùng này đã tồn tại trong cơ sở dữ liệu!");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            string sSQl;
                            sSQl = "SELECT * FROM KIEM_MSVT" + Commons.Modules.UserName + " WHERE [" + grvBC.Columns[col].FieldName.ToString() + "] = N'" +
                                sKiemTra + "'";
                            DataTable dtTmp = new DataTable();
                            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSQl));
                            if (dtTmp.Rows.Count > 1)
                            {
                                dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã vật tư phụ tùng này đã tồn tại trong file!");
                                dr["XOA"] = 1;
                            }
                            else
                                MsVTuOK = CheckLen(dr, col, MsVTuOK, 25, "Mã vật tư phụ tùng");
                        }
                    }
                    #endregion

                    col = 3;
                    #region Đơn vị tính
                    //kiểm Đơn vị tính vật tư
                    if (iLoaiIP == 1) col = 3; else col = 4;
                    sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                    if (string.IsNullOrEmpty(sKiemTra))
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Đơn vị tính vật tư không được để trống!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        if (CheckLen(dr, col, DVTOK, 20, "Đơn vị tính") != DVTOK)
                        {
                            if (obj.KiemGetTonTai("DON_VI_TINH", "TEN_1", sKiemTra) == "")
                            {
                                ////tồn tại thì thêm vào
                                //sSql = "INSERT INTO	 dbo.DON_VI_TINH ( DVT, TEN_1, TEN_2, TEN_3, GHI_CHU )VALUES(((SELECT  MAX(CONVERT(INT, DVT))  FROM dbo.DON_VI_TINH WHERE  ISNUMERIC(DVT) = 1) + 1),N'" + sKiemTra + "',N'" + sKiemTra + "',N'" + sKiemTra + "',N'từ import file excel')";
                                //SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                                dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Đơn vị tính không có trong CSDL!");
                                dr["XOA"] = 1;
                            }
                            else DVTOK += 1;
                        }

                    }
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
            }

            #endregion

            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            #region check success
            if (CheckSuccess(MsVTuOK, count) && CheckSuccess(ItemOK, count) && CheckSuccess(TenVTOK, count) && CheckSuccess(LoaiVTOK, count) && CheckSuccess(DVTOK, count))
            {
                DialogResult res = XtraMessageBox.Show("Dữ liệu sẵn sàng import vào, bạn có import không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        int sColMSPTCty, sColMSPT, sColTenPT, sColDVT;
                        if (iLoaiIP == 1) sColMSPT = 4; else sColMSPT = 2;
                        if (iLoaiIP == 1) sColTenPT = 1; else sColTenPT = 3;
                        if (iLoaiIP == 1) sColDVT = 3; else sColDVT = 4;
                        if (iLoaiIP == 1) sColMSPTCty = 0; else sColMSPTCty = 1;
                        string sTenLVT = "";
                        if (iLoaiIP == 1)
                        {
                            sTenLVT = "(SELECT TOP 1 MS_LOAI_VT FROM dbo.LOAI_VT WHERE TEN_LOAI_VT_TV = A.[" + grvBC.Columns[2].FieldName.ToString() + "])";

                        }
                        else
                        { sTenLVT = "(SELECT TOP 1 MS_LOAI_VT FROM dbo.LOAI_VT WHERE TEN_LOAI_VT_TV = 'Chung' )"; }
                        

                        SqlInsert.BeginTransaction();
                        //insert Phụ tùng
                        sSql = "INSERT INTO dbo.IC_PHU_TUNG ( MS_PT,MS_PT_CTY,TEN_PT,MS_LOAI_VT, DVT, DUNG_CU_DO,MS_CACH_DAT_HANG, SO_NGAY_DAT_MUA_HANG,TON_TOI_THIEU,  TON_KHO_MAX,TEN_PT_VIET, THEO_KHO,ACTIVE_PT, USER_INSERT_PT, NGAY_INSERT_PT,KY_PB,TEN_PT_OLD, TEN_PT_ANH, TEN_PT_HOA, VAT_TU_PT, NO_ACTIVE )SELECT DISTINCT A.[" + grvBC.Columns[sColMSPT].FieldName.ToString() + "],A.[" + grvBC.Columns[sColMSPTCty].FieldName.ToString() + "],A.[" + grvBC.Columns[sColTenPT].FieldName.ToString() + "]," + sTenLVT + ",(SELECT TOP 1 DVT FROM dbo.DON_VI_TINH WHERE TEN_1 = A.[" + grvBC.Columns[sColDVT].FieldName.ToString() + "]),0,10,0,0,0,A.[" + grvBC.Columns[sColTenPT].FieldName.ToString() + "],0,1,'" + Commons.Modules.UserName + "',GETDATE(),0,A.[" + grvBC.Columns[sColTenPT].FieldName.ToString() + "],A.[" + grvBC.Columns[sColTenPT].FieldName.ToString() + "],A.[" + grvBC.Columns[sColTenPT].FieldName.ToString() + "],1,0 FROM KIEM_MSVT" + Commons.Modules.UserName + " A";
                        if (iLoaiIP == 3) sSql = sSql + "   WHERE CHON = 1";

                             //////////////sSql = "INSERT INTO dbo.IC_PHU_TUNG ( MS_PT,MS_PT_CTY,TEN_PT,MS_LOAI_VT, DVT, DUNG_CU_DO,MS_CACH_DAT_HANG, SO_NGAY_DAT_MUA_HANG,TON_TOI_THIEU,  TON_KHO_MAX,TEN_PT_VIET, THEO_KHO,ACTIVE_PT, USER_INSERT_PT, NGAY_INSERT_PT,KY_PB,TEN_PT_OLD, TEN_PT_ANH, TEN_PT_HOA, VAT_TU_PT, NO_ACTIVE )SELECT DISTINCT A.[" + grvBC.Columns[4].FieldName.ToString() + "],A.[" + grvBC.Columns[0].FieldName.ToString() + "],A.[" + grvBC.Columns[1].FieldName.ToString() + "],(SELECT TOP 1 MS_LOAI_VT FROM dbo.LOAI_VT WHERE TEN_LOAI_VT_TV = A.[" + grvBC.Columns[2].FieldName.ToString() + "]),(SELECT TOP 1 DVT FROM dbo.DON_VI_TINH WHERE TEN_1 = A.[" + grvBC.Columns[3].FieldName.ToString() + "]),0,10,0,0,0,A.[" + grvBC.Columns[1].FieldName.ToString() + "],0,1,'" + Commons.Modules.UserName + "',GETDATE(),0,A.[" + grvBC.Columns[1].FieldName.ToString() + "],A.[" + grvBC.Columns[1].FieldName.ToString() + "],A.[" + grvBC.Columns[1].FieldName.ToString() + "],1,0 FROM KIEM_MSVT" + Commons.Modules.UserName + " A";

                             SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                        //insert Kho Chung nếu chưa có
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "IF (SELECT COUNT(*) FROM dbo.IC_KHO WHERE	TEN_KHO =N'Chung') = 0 BEGIN INSERT INTO dbo.IC_KHO(TEN_KHO) VALUES('Chung') INSERT INTO dbo.VI_TRI_KHO(MS_KHO, TEN_VI_TRI, GHI_CHU)VALUES((SELECT TOP 1 MS_KHO FROM dbo.IC_KHO WHERE TEN_KHO = N'Chung'), N'N/A', N'tạo từ Import IC_PT') END");

                        //insert IC_PHU_TUNG_KHO
                        sSql = "INSERT INTO	dbo.IC_PHU_TUNG_KHO ( MS_PT, MS_KHO, MS_VI_TRI, TON_TOI_THIEU,TON_KHO_MAX, GHI_CHU, SO_NGAY_DAT_MUA_HANG) SELECT A.[" + grvBC.Columns[sColMSPT].FieldName.ToString() + "],(SELECT TOP 1  MS_KHO FROM dbo.IC_KHO WHERE TEN_KHO ='Chung'),(SELECT TOP 1  MS_VI_TRI FROM dbo.VI_TRI_KHO WHERE MS_KHO = (SELECT TOP 1  MS_KHO FROM dbo.IC_KHO WHERE TEN_KHO = 'Chung') AND TEN_VI_TRI = N'N/A'),0,5, N'Import phụ tùng',0 FROM dbo.KIEM_MSVT" + Commons.Modules.UserName + " A ";
                        if (iLoaiIP == 3) sSql = sSql + "   WHERE CHON = 1";
                        SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);

                        foreach (DataRow dtrow in dtSource.Rows)
                        {
                            try
                            {
                                if (iLoaiIP == 1) bChon = true; else bChon = Boolean.Parse(dtrow[0].ToString());
                            }
                            catch { bChon = false; }
                            if (bChon)
                            {

                                //insert IC_PHU_TUNG_LOAI_MAY
                                sSql = " INSERT INTO IC_PHU_TUNG_LOAI_MAY([MS_PT],[MS_LOAI_MAY]) " +
                                        " SELECT  T.MS_PT, T.MS_LOAI_MAY FROM (SELECT N'" + dtrow[sColMSPT].ToString() + "' AS MS_PT, MS_LOAI_MAY FROM LOAI_MAY) T " +
                                        " WHERE NOT EXISTS (SELECT * FROM IC_PHU_TUNG_LOAI_MAY WHERE T.MS_PT = MS_PT AND T.MS_LOAI_MAY = MS_LOAI_MAY)";
                                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                                //insert IC_PHU_TUNG_LOAI_PHU_TUNG
                                sSql = " INSERT INTO IC_PHU_TUNG_LOAI_PHU_TUNG([MS_PT],[MS_LOAI_PT]) " +
                                        " SELECT  T.MS_PT, T.MS_LOAI_PT FROM (SELECT N'" + dtrow[sColMSPT].ToString() + "' AS MS_PT, MS_LOAI_PT FROM LOAI_PHU_TUNG) T " +
                                        " WHERE NOT EXISTS (SELECT * FROM IC_PHU_TUNG_LOAI_PHU_TUNG WHERE T.MS_PT = MS_PT AND T.MS_LOAI_PT = MS_LOAI_PT) ";
                                SqlInsert.ExecuteNonQuery(CommandType.Text, sSql);
                            }
                        }
                        DialogResult = DialogResult.OK;
                        XtraMessageBox.Show("Import dữ liệu thành công", "Thông báo");
                        SqlInsert.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        SqlInsert.RollbackTransaction();
                        XtraMessageBox.Show("Không thể Import dữ liệu này " + ex.ToString() + "", "Thông báo");
                    }

                }
            }
            #endregion
            else
            {
                XtraMessageBox.Show("Một số dữ liệu chưa hợp lệ, bạn vui lòng kiểm tra và sửa lại trước khi import!");
            }
            Commons.Modules.ObjSystems.XoaTable("KIEM_MSVT" + Commons.Modules.UserName);
        }
        #endregion

        #region 1. Import phieu xuat kho
        private void PXK(DataTable dtSource)
        {
            MyUtil obj = new MyUtil();
            string sKiemTra = "";
            int count = grvBC.RowCount;
            int col = 0;
            string sBt = "BT_PXK" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBt, dtSource, "");
            #region declare varian
            int SOPXOK = 0;
            int NGAYOK = 0;
            int MSKHOOK = 0;
            //int TenKhoOK = 0;
            int MSPTCTYOK = 0;
            int TENPTOK = 0;
            int SOLUONGOK = 0;
            int TENDVTOK = 0;
            int TONGTIENOK = 0;
            int SOPHIEUBTOK = 0;
            int TRUNGKHOOK = 0;
            int TRUNGNGAYOK = 0;
            int TRUNGPBTOK = 0;
            int TRUNGMAYOK = 0;

            #endregion

            #region Status bar
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = dtSource.Rows.Count;
            prbIN.Properties.Minimum = 0;
            #endregion

            #region kiem tra import xuất vật tư
            foreach (DataRow dr in dtSource.Rows)
            {
                dr["XOA"] = 0;
                #region Kiem Tra
                dr.ClearErrors();
                col = 0;
                #region Số phiếu xuất
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã số không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại ms kho
                    sSql = "SELECT COUNT(*) FROM dbo.IC_DON_HANG_XUAT WHERE SO_PHIEU_XN = N'" + sKiemTra + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem > 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Số phiếu xuất này đã tồn tại trong CSDL!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        SOPXOK = CheckLen(dr, col, SOPXOK, 20, "Số phiếu xuất");
                    }
                }
                #endregion

                col = 1;
                #region Ngày
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Ngày không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    try
                    {
                        DateTime dt = Convert.ToDateTime(sKiemTra);
                        NGAYOK++;
                    }
                    catch (Exception)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Kiểu ngày không hợp lệ!");
                        dr["XOA"] = 1;
                    }
                }
                #endregion

                col = 2;
                #region MSKHO
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã số không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại ms kho
                    sSql = "SELECT COUNT(*) FROM dbo.IC_KHO WHERE MS_KHO_INT = N'" + sKiemTra + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã số kho chưa có trong data!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        MSKHOOK++;
                    }
                }
                #endregion
                //col = 3;
                //#region TENKHO
                //sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                //if (string.IsNullOrEmpty(sKiemTra))
                //{
                //    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên kho không được để trống!");
                //}
                //else
                //{
                //    //kiểm tra tồn tại tên kho
                //    sSql = "SELECT COUNT(*) FROM dbo.IC_KHO WHERE TEN_KHO = N'" + sKiemTra.Trim() + "'";
                //    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                //    if (idem == 0)
                //    {
                //        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên kho không tồn tại!");
                //        dr["XOA"] = 1;
                //    }
                //    else
                //    {
                //        TenKhoOK++;
                //    }
                //}
                //#endregion
                col = 3;
                #region MS_PT_CTY
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã số PT không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại tên kho
                    sSql = "SELECT COUNT(*) FROM dbo.IC_PHU_TUNG WHERE MS_PT_CTY = N'" + sKiemTra.Trim() + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Mã số PT không tồn tại!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        MSPTCTYOK++;
                    }
                }
                #endregion

                col = 4;
                #region TEN_PT
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên PT không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại tên kho
                    sSql = "SELECT COUNT(*) FROM dbo.IC_PHU_TUNG WHERE TEN_PT = N'" + sKiemTra.Trim() + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên PT không tồn tại!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        TENPTOK++;
                    }

                }
                #endregion
                //kiểm tên phụ tùng với mã phụ tùng công ty phải giống nhau

                col = 5;
                #region SO_LUONG_THUC_XUAT
                try
                {
                    if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
                    if (KiemDuLieuSo(dr, col, "", 0, 0, true))
                    {
                        if (Convert.ToInt32(dr[col]) == 0)
                        {
                            dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Số lượng phải lớn hơn 0!");
                            dr["XOA"] = 1;


                        }
                        else
                        {
                            SOLUONGOK++;
                        }
                    }
                }
                catch
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Phải là số integer!");
                    dr["XOA"] = 1;

                }
                #endregion

                col = 6;
                #region TEN_DVT
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên DVT không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại tên kho
                    sSql = "SELECT COUNT(*) FROM dbo.DON_VI_TINH WHERE TEN_1 = N'" + sKiemTra.Trim() + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Tên DVT không tồn tại!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        TENDVTOK++;
                    }
                }



                #endregion


                col = 7;
                #region TONG_TIEN
                try
                {
                    if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
                    if (KiemDuLieuSo(dr, col, "", 0, 0, true))
                    {
                        TONGTIENOK++;
                    }
                }
                catch
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Phải là số integer");
                    dr["XOA"] = 1;
                }
                #endregion
                col = 8;
                #region Số phiếu bảo trì
                sKiemTra = dr[grvBC.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Số phiếu bảo trì không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại tên kho
                    sSql = "SELECT COUNT(*) FROM dbo.PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = '" + sKiemTra.Trim() + "'";
                    int idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), "Số phiếu bảo trì không tồn tại!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        SOPHIEUBTOK++;
                    }
                }
                //kiểm tra số phiếu không tồn tại trên 2 kho
                idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM (SELECT DISTINCT [" + grvBC.Columns[0].FieldName.ToString() + "],[" + grvBC.Columns[2].FieldName.ToString() + "] FROM " + sBt + " WHERE [" + grvBC.Columns[0].FieldName.ToString() + "] ='" + dr[grvBC.Columns[0].FieldName.ToString()].ToString() + "')A"));
                if (idem > 1)
                {
                    dr.SetColumnError(grvBC.Columns[0].FieldName.ToString(), "Một số phiếu chỉ có được một Kho!");
                    dr.SetColumnError(grvBC.Columns[2].FieldName.ToString(), "Một số phiếu chỉ có được một Kho!");
                    dr["XOA"] = 1;
                }
                else
                {
                   TRUNGKHOOK++;
                }
                //kiểm tra TRÙNG NGÀY
                idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM (SELECT DISTINCT [" + grvBC.Columns[0].FieldName.ToString() + "],[" + grvBC.Columns[1].FieldName.ToString() + "] FROM " + sBt + " WHERE [" + grvBC.Columns[0].FieldName.ToString() + "] ='" + dr[grvBC.Columns[0].FieldName.ToString()].ToString() + "')A"));
                if (idem > 1)
                {
                    dr.SetColumnError(grvBC.Columns[0].FieldName.ToString(), "Một số phiếu chỉ có được một ngày!");
                    dr.SetColumnError(grvBC.Columns[1].FieldName.ToString(), "Một số phiếu chỉ có được một ngày!");
                    dr["XOA"] = 1;
                }
                else
                {
                    TRUNGNGAYOK++;
                }
                //kiểm tra số phiếu không tồn tại trên 2 phiếu bảo trì
                idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM (SELECT DISTINCT [" + grvBC.Columns[0].FieldName.ToString() + "],[" + grvBC.Columns[8].FieldName.ToString() + "] FROM " + sBt + " WHERE [" + grvBC.Columns[0].FieldName.ToString() + "] ='" + dr[grvBC.Columns[0].FieldName.ToString()].ToString() + "')A"));
                if (idem > 1)
                {
                    dr.SetColumnError(grvBC.Columns[0].FieldName.ToString(), "Một số phiếu chỉ có được một bảo trì!");
                    dr.SetColumnError(grvBC.Columns[8].FieldName.ToString(), "Một số phiếu chỉ có được một bảo trì!");
                    dr["XOA"] = 1;
                }
                else
                {
                    TRUNGPBTOK++;
                }
                //kiểm tra trung vật tư
                idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM " + sBt + " WHERE [" + grvBC.Columns[0].FieldName.ToString() + "] ='" + dr[grvBC.Columns[0].FieldName.ToString()].ToString() + "' AND [" + grvBC.Columns[3].FieldName.ToString() + "] ='" + dr[grvBC.Columns[3].FieldName.ToString()].ToString() + "'"));
                if (idem > 1)
                {
                    dr.SetColumnError(grvBC.Columns[3].FieldName.ToString(), "Trùng vật tư!");
                    dr.SetColumnError(grvBC.Columns[4].FieldName.ToString(), "Trùng vật tư!");
                    dr["XOA"] = 1;
                }
                else
                {
                    TRUNGMAYOK++;
                }
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
            #endregion
            //int SOPXOK = 0;
            //int NGAYOK = 1;
            //int MSKHOOK = 2;
            //int MSPTCTYOK = 3;
            //int TENPTOK = 4;
            //int SOLUONGOK = 5;
            //int TENDVTOK = 6;
            //int TONGTIENOK = 7;
            //int SOPHIEUBTOK = 8;
            #region check success
            if (CheckSuccess(SOPXOK, count) && CheckSuccess(NGAYOK, count) && CheckSuccess(MSKHOOK, count) && CheckSuccess(MSPTCTYOK, count) && CheckSuccess(TENPTOK, count) && CheckSuccess(SOLUONGOK, count) && CheckSuccess(TENDVTOK, count) && CheckSuccess(TONGTIENOK, count) && CheckSuccess(SOPHIEUBTOK, count) && CheckSuccess(TRUNGKHOOK, count) && CheckSuccess(TRUNGPBTOK, count) && CheckSuccess(TRUNGMAYOK, count))
            {
                DialogResult res = XtraMessageBox.Show("Dữ liệu sẵn sàng import vào, bạn có import không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        sSql = "INSERT INTO #APXVT ( ID, SO_PHIEU_XN, NGAY, MS_PBT, MS_KHO, MS_VI_TRI, MS_PT, SL, TT, DG, PN, PX ) SELECT ROW_NUMBER() OVER(PARTITION BY MS_PT ORDER BY T1.SO_PHIEU_XN, T1.NGAY, T1.MS_PBT, T1.MS_KHO, T1.MS_PT,T1.DG) ID,T1.SO_PHIEU_XN, REPLACE(T1.NGAY, SUBSTRING(T1.NGAY, 1, 5), SUBSTRING(T1.NGAY, 4, 2) + '/' + SUBSTRING(T1.NGAY, 1, 2)) AS NGAY, T1.MS_PBT, T1.MS_KHO,MS_VI_TRI, T1.MS_PT, SUM(CAST(T1.SL as FLOAT)) AS SL, SUM(CAST(T1.TT as FLOAT)) AS TT, ROUND(SUM(CAST(T1.TT as FLOAT)) / SUM(CAST(T1.SL as FLOAT)), 0) AS DG, NULL, NULL FROM(SELECT T1.[" + grvBC.Columns[0].FieldName.ToString() + "] as SO_PHIEU_XN, T1.[" + grvBC.Columns[1].FieldName.ToString() + "] as NGAY, T1.[" + grvBC.Columns[8].FieldName.ToString() + "] AS MS_PBT,(SELECT TOP 1 T2.MS_KHO FROM dbo.IC_KHO T2 WHERE T1.[" + grvBC.Columns[2].FieldName.ToString() + "] = T2.MS_KHO_INT) AS MS_KHO, (SELECT TOP 1 MS_VI_TRI FROM dbo.VI_TRI_KHO WHERE MS_KHO = (SELECT TOP 1 T2.MS_KHO FROM dbo.IC_KHO T2 WHERE T1.[" + grvBC.Columns[2].FieldName.ToString() + "] = T2.MS_KHO_INT ) ) AS MS_VI_TRI,(SELECT TOP 1 T3.MS_PT FROM dbo.IC_PHU_TUNG T3 WHERE T1.[" + grvBC.Columns[3].FieldName.ToString() + "] = T3.MS_PT_CTY) AS MS_PT,T1.[" + grvBC.Columns[5].FieldName.ToString() + "] AS SL, T1.[" + grvBC.Columns[7].FieldName.ToString() + "] AS TT,ROUND(CONVERT(FLOAT, T1.[" + grvBC.Columns[7].FieldName.ToString() + "]) / CONVERT(FLOAT, T1.[" + grvBC.Columns[5].FieldName.ToString() + "]), 0) AS DG FROM " + sBt+" T1) T1 GROUP BY T1.SO_PHIEU_XN, T1.NGAY, T1.MS_PBT, T1.MS_KHO,T1.MS_VI_TRI, T1.MS_PT,T1.DG ORDER BY T1.SO_PHIEU_XN, T1.NGAY, T1.MS_PBT, T1.MS_KHO, T1.MS_PT,T1.DG";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spImportPXK_TN", Commons.Modules.UserName, sBt,sSql);
                        XtraMessageBox.Show("Import dữ liệu thành công!","Thông báo");
                        //import xuất kho cho phiếu bảo trì
                        DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể Import dữ liệu này " + ex.ToString() + "", "Thông báo");
                    }

                }
            }
            #endregion
            else
            {
                XtraMessageBox.Show("Một số dữ liệu chưa hợp lệ, bạn vui lòng kiểm tra và sửa lại trước khi import!");
            }
            Commons.Modules.ObjSystems.XoaTable("KIEM_MSVT" + Commons.Modules.UserName);
        }
        #endregion

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
                if (dr[grvBC.Columns[col].FieldName.ToString()] == DBNull.Value || dr[grvBC.Columns[col].FieldName.ToString()].ToString() == String.Empty)
                { giatri += 1; }
                else
                    if (dr[grvBC.Columns[col].FieldName.ToString()].ToString().Length > chieudai)
                {
                    dr.SetColumnError(grvBC.Columns[col].FieldName.ToString(), thongbao + " dài hơn " + chieudai + " ký tự." + "(" + dr[grvBC.Columns[col].FieldName.ToString()].ToString().Length.ToString() + ")");
                    dr["XOA"] = 1;
                    dr["LOI"] = 1;
                }
                else
                    giatri += 1;
                return giatri;
            }
            catch { return giatri; }
        }

        private void grvBC_KeyDown(object sender, KeyEventArgs e)
        {
            if (iLoaiIP == 0) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Bạn có chắc xóa dòng dữ liệu này ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                //GridView view = sender as GridView;
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                //view.DeleteRow(view.FocusedRowHandle);
                if (view.SelectedRowsCount != 0)
                {
                    view.GridControl.BeginUpdate();
                    List<int> selectedLogItems = new List<int>(view.GetSelectedRows());
                    for (int i = selectedLogItems.Count - 1; i >= 0; i--)
                    {
                        view.DeleteRow(selectedLogItems[i]);
                    }
                    view.GridControl.EndUpdate();
                }
                else if (view.FocusedRowHandle != GridControl.InvalidRowHandle)
                {
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
        }

        private void btnExportTemplate_Click(object sender, EventArgs e)
        {
            string sPath = "";
            sPath = "";
            //sPath = Commons.Modules.MExcel.SaveFiles("Excel Files (*.xlsx;)|*.xlsx;|" + "All Files (*.*)|*.*");
            sPath = Commons.Modules.MExcel.SaveFiles("Excel Files (*.xls;)|*.xls;|Excel Files (*.Xlsx;)|*.Xlsx;|" + "All Files (*.*)|*.*");
            if (sPath == "") return;
            //bLoaiExport = false xuat template
            Boolean bLoaiExport = false;
            //ifXtraMessageBox.Show("Bạn muốn export dữ liệu hiện tại hay template","",Xtrab)
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn muốn export dữ liệu hiện tại(Y) hay export template(N)?", "Thông báo",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel) return;
            if (dr == DialogResult.Yes)
            {
                bLoaiExport = true;
            }

            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            DataTable dtTmp = new DataTable();

            try
            {
                dtTmp = new DataTable();
                if (bLoaiExport)
                    dtTmp = (DataTable)grdBC.DataSource;
                else
                {
                    if (iLoaiIP == 1)
                    {
                        sSql = "SELECT TOP 10 MS_PT_CTY AS [Material],TEN_PT AS [Material Description],T2.TEN_LOAI_VT_TV [Material Type],T3.TEN_1 AS [Base Unit of Measure], T1.MS_PT AS [Material Ecomaint] FROM dbo.IC_PHU_TUNG T1 INNER JOIN dbo.LOAI_VT T2 ON	T1.MS_LOAI_VT = T2.MS_LOAI_VT INNER JOIN dbo.DON_VI_TINH T3 ON T1.DVT =T3.DVT ORDER BY [Material]";
                    }
                    else
                    {
                        sSql = "SELECT TOP 10 T1.SO_PHIEU_XN AS [Material Document], T1.NGAY AS [Posting Date], T1.MS_KHO AS [Storage Location], T4.MS_PT_NCC AS [Material], T4.TEN_PT AS [Material Description], SUM(T2.SO_LUONG_THUC_XUAT) AS [Quantity], T5.TEN_1 AS [Base Unit of Measure], 0 AS [Amount in LC], T1.MS_PHIEU_BAO_TRI FROM dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN dbo.IC_KHO AS T3 ON T1.MS_KHO = T3.MS_KHO INNER JOIN dbo.IC_PHU_TUNG AS T4 ON T2.MS_PT = T4.MS_PT INNER JOIN dbo.DON_VI_TINH AS T5 ON T4.DVT = T5.DVT WHERE ISNULL(T1.MS_PHIEU_BAO_TRI,'') <> '' GROUP BY T1.SO_PHIEU_XN, T1.NGAY, T1.MS_KHO, T3.TEN_KHO, T4.MS_PT_NCC, T4.TEN_PT, T5.TEN_1, T1.MS_PHIEU_BAO_TRI ORDER BY T1.NGAY DESC ";
                    }
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                }


                //export datatable to excel
                sheet.DefaultColumnWidth = 20;
                sheet.Range[1, 1, dtTmp.Rows.Count + 1, dtTmp.Columns.Count].Style.WrapText = true;

                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.VerticalAlignment = VerticalAlignType.Center;
                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.HorizontalAlignment = HorizontalAlignType.Center;
                if (dtTmp.Rows.Count > 0)
                {
                    sheet.Range[2, 1, dtTmp.Rows.Count + 1, dtTmp.Columns.Count].Style.VerticalAlignment = VerticalAlignType.Center;
                    sheet.Range[2, 1, dtTmp.Rows.Count + 1, dtTmp.Columns.Count].Style.HorizontalAlignment = HorizontalAlignType.Left;
                }

                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.Font.IsBold = true;

                sheet.InsertDataTable(dtTmp, true, 1, 1);
                book.SaveToFile(sPath);
                System.Diagnostics.Process.Start(sPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                      "ucTongHopTinhHinhBaoTri", "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                      ex.Message);
            }
        }


        DevExpress.XtraBars.BarManager bar;
        #region  Tao menu chuot trai
        private void CreateMenuDVTLoaiVT()
        {
            try
            {
                foreach (Control control in grdBC.Controls)
                {
                    if (control is DevExpress.XtraBars.BarDockControl)
                    {
                        return;
                    }
                }
            }
            catch
            {
            }
            bar = new DevExpress.XtraBars.BarManager();
            bar.Form = grdBC;
            bar.ItemClick += Bar_ItemClick;
            bar.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(bar);
            bar.SetPopupContextMenu(grdBC, popup);

            DevExpress.XtraBars.BarButtonItem mnuDVT = new DevExpress.XtraBars.BarButtonItem(bar, "Thêm đơn vị tính");
            DevExpress.XtraBars.BarButtonItem mnuLoaiVTPT = new DevExpress.XtraBars.BarButtonItem(bar, "Thêm loại vật tư phụ tùng");

            mnuDVT.Name = "mnuDVT";
            mnuLoaiVTPT.Name = "mnuLoaiVTPT";

            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuDVT, mnuLoaiVTPT });
            bar.EndUpdate();
        }

        private bool KiemDuLieuSo(DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull)
        {
            string sDLKiem;
            sDLKiem = dr[grvBC.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvBC.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(dr[grvBC.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvBC.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvBC.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvBC.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();

                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvBC.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(dr[grvBC.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvBC.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvBC.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvBC.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();
                        }

                    }
                }


            }



            return true;
        }


        private void Bar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mnThemALLCV
            if (grvBC.RowCount == 0)
            {
                XtraMessageBox.Show("Không có dữ liệu");
                return;
            }
            string sText = "";
            grvBC.PostEditor();
            grvBC.UpdateCurrentRow();
            switch (e.Item.Name.ToString().ToLower())
            {
                #region Thêm đơn vị tính
                case "mnudvt":
                    {
                        sText = Convert.ToString(Commons.XtraInputBox.Show("Nhập tên đơn vị tính cần thêm.", this.Text, grvBC.GetFocusedDataRow()[3].ToString(), false));
                        if (string.IsNullOrEmpty(sText)) return;

                        sSql = "IF NOT EXISTS(SELECT TEN_1 FROM DON_VI_TINH WHERE TEN_1 = N'" + sText + "') INSERT INTO	 dbo.DON_VI_TINH ( DVT, TEN_1, TEN_2, TEN_3, GHI_CHU )VALUES(((SELECT  MAX(CONVERT(INT, DVT))  FROM dbo.DON_VI_TINH WHERE  ISNUMERIC(DVT) = 1) + 1),N'" + sText + "',N'" + sText + "',N'" + sText + "',N'từ import file excel')";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                        break;
                    }
                #endregion
                #region Thêm loại VTPT
                case "mnuloaivtpt":
                    {
                        sText = Convert.ToString(Commons.XtraInputBox.Show("Nhập tên loại công việc cần thêm.", this.Text, grvBC.GetFocusedDataRow()[2].ToString(), false));
                        if (string.IsNullOrEmpty(sText)) return;
                        //tồn tại thì thêm vào
                        sSql = "IF NOT EXISTS(SELECT TEN_LOAI_VT_TV FROM LOAI_VT WHERE TEN_LOAI_VT_TV = N'" + sText + "') INSERT INTO dbo.LOAI_VT( MS_LOAI_VT, TEN_LOAI_VT_TV, TEN_LOAI_VT_TA,TEN_LOAI_VT_TH, VAT_TU )VALUES(((SELECT  MAX(CONVERT(INT,MS_LOAI_VT))  FROM dbo.LOAI_VT WHERE  ISNUMERIC(MS_LOAI_VT) = 1) + 1),N'" + sText + "',N'" + sText + "',N'" + sText + "',0)";

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                        break;
                    }
                    #endregion
            }
        }
        #endregion
    }
}