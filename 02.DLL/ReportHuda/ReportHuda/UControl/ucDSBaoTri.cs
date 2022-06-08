using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using Spire.Xls;

namespace ReportHuda.UControl
{
    public partial class ucDSBaoTri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDSBaoTri()
        {
            InitializeComponent();
        }

        private void ucDSBaoTri_Load(object sender, EventArgs e)
        {
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            datTNgay.DateTime = Ngay.AddMonths(-6);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiBT();
            if (System.Environment.MachineName.ToUpper() == "MASHIMARO")
                grpMay.Visible = true;
            else grpMay.Visible = false;
            
        }
        #region Load Du Lieu
      
        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");

            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_MAY "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, _table, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadLoaiBT()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLoaiBaoTri"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text);                
            }
            catch { }
        }

        #endregion

        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) // at least one time
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

     

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private Boolean KiemDLieu()
        {
            try
            {

                if (datTNgay.Text == "")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return false;
                }
                if (datDNgay.Text == "")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                    datDNgay.Focus();
                    return false;
                }
                DateTime TNgay, DNgay;
                TNgay = datTNgay.DateTime;
                DNgay = datDNgay.DateTime;

                if (TNgay >= DNgay)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return false;

                }


                if (cboDDiem.TextValue == "")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                    cboDDiem.Focus();
                    return false;
                }

                if (cboDChuyen.TextValue == "")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                    cboDChuyen.Focus();
                    return false;
                }

                if (cboLMay.Text == "")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "KhongCoLMay", Commons.Modules.TypeLanguage));
                    cboLMay.Focus();
                    return false;
                }
                return true;
            }
            catch { return false; }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            string sSql, sBT;
            sSql = "SELECT DISTINCT * FROM TINH_TRANG_PBT WHERE 1 = 0 ";
            if (chkTTBT.GetItemChecked(0))
                sSql = sSql + " OR STT = 1 ";
            if (chkTTBT.GetItemChecked(1))
                sSql = sSql + " OR STT = 2 ";
            if (chkTTBT.GetItemChecked(2))
                sSql = sSql + " OR STT = 3 ";
            if (chkTTBT.GetItemChecked(3))
                sSql = sSql + " OR STT = 4 ";
            if (chkTTBT.GetItemChecked(4))
                sSql = sSql + " OR STT = 5 ";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "ChuaChonTTBT", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            sBT = "TTBT";
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            dtTmp = new DataTable();

            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            if(conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            //0 La hinh thuc bao tri, khac 0 where binh thuong
            DataRowView _rW = cboLBTri.Properties.GetDataSourceRowByKeyValue(cboLBTri.EditValue) as DataRowView;
            String LoaiHinhThucBaoTri = "1";
            try
            {
                LoaiHinhThucBaoTri = _rW["LOAI"].ToString();
            }
            catch { }
            //@LoaiHinhThucBaoTri = 0 where theo hinh thuc nguoc lai la all hay theo dung loai bao tri
            //@LoaiHinhThucBaoTri = 1 where theo Loai Bao Tri
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 999999;
            cmd.CommandText = "MGetDSBaoTri";
            cmd.Parameters.Add(new SqlParameter("@TNGAY", datTNgay.DateTime));
            cmd.Parameters.Add(new SqlParameter("@DNGAY", datDNgay.DateTime));

            cmd.Parameters.Add(new SqlParameter("@MSNX", cboDDiem.EditValue));
            cmd.Parameters.Add(new SqlParameter("@MSHT", cboDChuyen.EditValue));
            cmd.Parameters.Add(new SqlParameter("@MSLMAY", cboLMay.EditValue));
            cmd.Parameters.Add(new SqlParameter("@MSLBT", cboLBTri.EditValue));
            cmd.Parameters.Add(new SqlParameter("@USERNAME", Commons.Modules.UserName));
            cmd.Parameters.Add(new SqlParameter("@NGON_NGU", Commons.Modules.TypeLanguage));
            cmd.Parameters.Add(new SqlParameter("@LoaiHinhThucBaoTri", LoaiHinhThucBaoTri));
            try
            {
                dtTmp.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
            
            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDSBaoTri", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }



            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, false, true, "ucDSBaoTri");

            InDuLieu(dtTmp);
        }
        private void ExcelDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
        private void InDuLieu(DataTable dtTmp)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            try
            {
                //int TCot = grvChung.Columns.Count;
                //int TDong = grvChung.RowCount;
                int TCot = dtTmp.Columns.Count;
                int TDong = dtTmp.Rows.Count;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;
                grdChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 8;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                //Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);



                int SCot;

                SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                Dong++;
                stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong++;
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, TDong + Dong, TCot);
                title.WrapText = true;
                title.NumberFormat = "@";

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, TDong + Dong, 3);
                title.ColumnWidth = 15;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 2, TDong + Dong, 2);
                title.ColumnWidth = 24;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 4, TDong + Dong, 4);
                title.ColumnWidth = 20;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 5, TDong + Dong, 8);
                title.ColumnWidth = 13;

                title.NumberFormat = "dd/MM/yyyy hh:mm";
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 9, TDong + Dong, 11);
                title.ColumnWidth = 30;
                title.NumberFormat = "@";
                title.WrapText = true;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 10, TDong + Dong, 10);
                title.ColumnWidth = 22;
                if(Commons.Modules.sPrivate == "VIFON")
                {
                    title.NumberFormat = "dd/MM/yyyy";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 12, TDong + Dong, 13);
                title.ColumnWidth = 14.71;
                title.NumberFormat = "dd/MM/yyyy";

                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 14, TDong + Dong, 14);
                title.ColumnWidth = 15;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 15, TDong + Dong, 16);
                title.ColumnWidth = 20;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

            }
            catch (Exception ex)
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }

        //private void InDuLieu(DataTable dtTmp)
        //{
        //    string sPath = "";
        //    sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
        //    if (sPath == "") return;


        //    this.Cursor = Cursors.WaitCursor;
        //    Excel.Application excelApplication = new Excel.Application();

        //    try
        //    {
        //        //int TCot = grvChung.Columns.Count;
        //        //int TDong = grvChung.RowCount;
        //        int TCot = dtTmp.Columns.Count;
        //        int TDong = dtTmp.Rows.Count;
        //        int Dong = 1;

        //        prbIN.Visible = true;
        //        prbIN.Position = 0;
        //        prbIN.Properties.Step = 1;
        //        prbIN.Properties.PercentView = true;
        //        prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
        //        prbIN.Properties.Minimum = 0;



        //        grdChung.ExportToXls(sPath);

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion

        //        System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        //        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //        Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
        //        Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
        //        Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


        //        excelApplication.Cells.Font.Name = "Tahoma";
        //        excelApplication.Cells.Font.Size = 8;

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
        //        Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
        //        Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

        //        int SCot;

        //        SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong++;

        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "TieuDe", Commons.Modules.TypeLanguage)
        //            , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
        //            Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong++;
        //        string stmp = "";
        //        stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");
        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong++;
        //        stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong++;
        //        stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        Dong++;
        //        stmp = lblLMay.Text + " : " + cboLMay.Text;
        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

        //        Dong++;
        //        stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
        //        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

        //        int DongBD;
        //        DongBD = Dong + 3;
        //        Excel.Range title;
        //        Dong++;
        //        Dong++;

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
        //        title.Borders.LineStyle = 1;
        //        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //        title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
        //        title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
        //        title.Font.Bold = true;
        //        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion

        //        Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
        //        title.RowHeight = 9;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
        //        title.RowHeight = 9;

        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, TDong + Dong, TCot);
        //        title.WrapText = true;
        //        title.NumberFormat = "@";

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, TDong + Dong, 3);
        //        title.ColumnWidth = 15;
        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 2, TDong + Dong, 2);
        //        title.ColumnWidth = 24;
        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 4, TDong + Dong, 4);
        //        title.ColumnWidth = 20;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 5, TDong + Dong, 8);
        //        title.ColumnWidth = 13;


        //        title.NumberFormat = "dd/MM/yyyy hh:mm";
        //        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 9, TDong + Dong, 11);
        //        title.ColumnWidth = 30;
        //        title.NumberFormat = "@";
        //        title.WrapText = true;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 10, TDong + Dong, 10);
        //        title.ColumnWidth = 22;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 12, TDong + Dong, 13);
        //        title.ColumnWidth = 14.71;
        //        title.NumberFormat = "dd/MM/yyyy";
        //        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 14, TDong + Dong, 14);
        //        title.ColumnWidth = 15;

        //        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 15, TDong + Dong, 16);
        //        title.ColumnWidth = 20;
        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion


        //        excelWorkbook.Save();
        //        excelApplication.Visible = true;
        //        Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
        //        Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
        //        Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

        //    }
        //    catch (Exception ex)
        //    {
        //        excelApplication.Visible = true;
        //        excelApplication.DisplayAlerts = false;
        //        excelApplication.Quit();
        //        Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
        //        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
        //            "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
        //            ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    prbIN.Position = prbIN.Properties.Maximum;
        //    this.Cursor = Cursors.Default;


        //}



    }
}
