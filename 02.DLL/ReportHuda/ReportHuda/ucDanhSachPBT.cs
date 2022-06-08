using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace ReportHuda
{
    public partial class ucDanhSachPBT : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucDanhSachPBT";

        public ucDanhSachPBT()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }

        private void LoadNhomMay(string sLMay)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, sLMay), "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
            }
            catch { }
        }

        private void LoadNhanVien()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_CONG_NHAN,HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN WHERE 1 = -1 ORDER BY TEN"));
                DataRow drRow = dtTmp.NewRow();
                drRow["MS_CONG_NHAN"] = "-1";
                drRow["HO_TEN"] = " < ALL > ";
                dtTmp.Rows.Add(drRow);
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_CONG_NHAN,HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN ORDER BY TEN"));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboNVien, dtTmp, "MS_CONG_NHAN", "HO_TEN", "");
            }
            catch { }
        }

        private void LoadLoaiBT()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiBTTreeListAll", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboLBTri, dt, "MS_CHA", "MS_LOAI_BT", "TEN_LOAI_BT");
            }
            catch { }
        }



        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0DD") return;
            if (Commons.Modules.SQLString == "0DC") return;
            if (Commons.Modules.SQLString == "0LM") return;
            //this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2000"); }


                string NXuong = "-1";
                string LMay = "-1";
                string NhomMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.TextValue == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }

                try
                { if (cboNMay.Text == "") NhomMay = "-1"; else NhomMay = cboNMay.EditValue.ToString(); }
                catch { NhomMay = "-1"; }

                try
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetMayNXuongHThongLMay", Commons.Modules.UserName, NXuong, HThong, -1, LMay, NhomMay, "-1",
                        DNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "1";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, false, "");

                for (int i = 1; i <= grvMay.Columns.Count - 1; i++)
                {
                    grvMay.Columns[i].Visible = false;
                    dtMay.Columns[i].ReadOnly = true;
                }
                grvMay.Columns["MS_MAY"].Visible = true;
                grvMay.Columns["TEN_NHOM_MAY"].Visible = true;
                grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
                grvMay.Columns["TEN_HE_THONG"].Visible = true;
                grvMay.Columns["Ten_N_XUONG"].Visible = true;
                grvMay.Columns["TEN_MAY"].Visible = true;
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvMay, sBC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Cursor = Cursors.Default;
        }

        #endregion
        private void ucDanhSachPBT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            LoadNhanVien();
            LoadLoaiBT();
            Commons.Modules.SQLString = "";
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {

            if (Commons.Modules.SQLString == "0Load") return;
            if (cboLMay.Text == "") return;
            string sLMay = "-1";
            try
            {
                sLMay = cboLMay.EditValue.ToString();
            }
            catch { sLMay = "-1"; }
            Commons.Modules.SQLString = "0LM";
            LoadNhomMay(sLMay);
            Commons.Modules.SQLString = "";
            LoadMay();
        }
        private void cboNMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }
        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {

            DataTable dtTmp = new DataTable();
            string sBTMay = "TMP_MAY_DSPBT" + Commons.Modules.UserName;
            string sBTTTBT = "TMP_TTBT_DSPBT" + Commons.Modules.UserName;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (datDNgay.DateTime < datTNgay.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    datDNgay.Focus();
                    this.Cursor = Cursors.Default;
                    return;
                }
                dtTmp = ((DataTable)grdMay.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
                if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgChuaChonMay", Commons.Modules.TypeLanguage));
                    this.Cursor = Cursors.Default;
                    return;
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTMay, dtTmp, "");
                string sSql = "-1";
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
                if (sSql == "-1")
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgChuaChonTinhTrang", Commons.Modules.TypeLanguage));
                    this.Cursor = Cursors.Default;
                    return;
                }
                sSql = sSql.Replace("-1", "");
                sSql = "SELECT DISTINCT * FROM TINH_TRANG_PBT WHERE 1 = 0 " + sSql;
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count <= 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "ChuaChonTTBT", Commons.Modules.TypeLanguage));
                    cboDChuyen.Focus();
                    Commons.Modules.ObjSystems.XoaTable(sBTMay);
                    this.Cursor = Cursors.Default;
                    return;
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTTTBT, dtTmp, "");

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCDanhSachPBT", datTNgay.DateTime.Date, datDNgay.DateTime.Date, cboNVien.EditValue, cboLBTri.EditValue,Commons.Modules.UserName, Commons.Modules.TypeLanguage, sBTMay, sBTTTBT));
                if (dtTmp.Rows.Count == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                    this.Cursor = Cursors.Default;
                    return;
                }
                //Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
                //Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, sBC);


                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;


                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start(dtTmp);



                //InExcel(dtTmp);
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }



            Commons.Modules.ObjSystems.XoaTable(sBTMay);
            Commons.Modules.ObjSystems.XoaTable(sBTTTBT);
            this.Cursor = Cursors.Default;
        }        
        private void InDuLieu(object dt)
        {

            //this.Cursor = Cursors.WaitCursor;
            DataTable dtData = dt as DataTable;
            GridControl grd = new GridControl();
            GridView grv = new GridView();
            grd.MainView = grv;
            grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            grv});
            grv.GridControl = grd;
            grv.Name = "grv";
            grv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grv.OptionsView.ShowGroupPanel = false;
            BeginInvoke((Action)(() =>
            {
                this.Controls.Add(grd);
            }));

            
            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtData, false, true, false, false, true, sBC);


            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grv.Columns.Count;
                int TDong = grv.RowCount;
                int Dong = 1;
                

                grd.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
             
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;

                SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
              
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sTieuDeDanhSachPBT", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

               
                Dong++;
                string stmp = "";
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString(oldCultureInfo.DateTimeFormat.ShortDatePattern) + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString(oldCultureInfo.DateTimeFormat.ShortDatePattern);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                        Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

               
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);


                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, SCot);

                
                Dong++;

                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblNhomMay.Text + " : " + cboNMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, SCot);


              
                Dong++;

                stmp = lblNhanVien.Text + " : " + cboNVien.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                stmp = lblLBaoTri.Text + " : " + cboLBTri.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, SCot);

                Dong++;

                stmp = "";
                if (chkTTBT.GetItemChecked(0))
                    stmp = stmp + " - " + chkTTBT.GetItemText(0);
                if (chkTTBT.GetItemChecked(1))
                    stmp = stmp + " - " + chkTTBT.GetItemText(1);
                if (chkTTBT.GetItemChecked(2))
                    stmp = stmp + " - " + chkTTBT.GetItemText(2);
                if (chkTTBT.GetItemChecked(3))
                    stmp = stmp + " - " + chkTTBT.GetItemText(3);
                if (chkTTBT.GetItemChecked(4))
                    stmp = stmp + " - " + chkTTBT.GetItemText(4);

                stmp = lblTTBaoTri.Text + " : " + stmp.Substring(3, stmp.Length - 3);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);


                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong++;
                Dong++;

            
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            

                //Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;



                //5	14	16	25	20	20	20	20	20	25	18	10	10	14	25	30
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, Dong + 1, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 2, Dong + 1, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 1, 3, Dong + 1, 3);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 4, Dong + 1, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, Dong + 1, 9);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 10, Dong + 1, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 11, Dong + 1, 12);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 1, 13, Dong + 1, 13);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong, 14, Dong + 1, 20);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong + 1, 16, Dong + 1 + 1, 16);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong + 1, 19, Dong + 1 + 1, 19);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 21, Dong + 1, 21);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 22, Dong + 1, 23);
                

                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            BeginInvoke((Action)(() =>
            {
                prbIN.Properties.Stopped = true;
            }));
            BeginInvoke((Action)(() =>
            {
                EnableControl(true);
            }));
            Cursor = Cursors.Default;
            t.Abort();

            
        }
        private void InExcel(object dt)
        {
            try
            {
                DataTable dtData = dt as DataTable;
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcDSPBT", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C");
                #endregion

                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];

                Commons.Modules.MExcel.MText(ws1, sBC, "sTieuDeDanhSachPBT", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblTNgay.Text + " " + datTNgay.Text + " " + lblDNgay.Text + " " + datDNgay.Text, iDong, 3, true);


                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblDDiem.Name, iDong, 3, true);
                Commons.Modules.MExcel.MText(ws1, "", cboDDiem.TextValue, iDong, 4, true);

                Commons.Modules.MExcel.MText(ws1, sBC, lblDChuyen.Name, iDong, 5, true);
                Commons.Modules.MExcel.MText(ws1, "", cboDChuyen.TextValue, iDong, 6, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblLMay.Name, iDong, 3, true);
                Commons.Modules.MExcel.MText(ws1, "", cboLMay.Text, iDong, 4, true);

                Commons.Modules.MExcel.MText(ws1, sBC, lblNhomMay.Name, iDong, 5, true);
                Commons.Modules.MExcel.MText(ws1, "", cboNMay.Text, iDong, 6, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblNhanVien.Name, iDong, 3, true);
                Commons.Modules.MExcel.MText(ws1, "", cboNVien.Text, iDong, 4, true);

                Commons.Modules.MExcel.MText(ws1, sBC, lblLBaoTri.Name, iDong, 5, true);
                Commons.Modules.MExcel.MText(ws1, "", cboLBTri.TextValue, iDong, 6, true);

                string stmp = "";
                if (chkTTBT.GetItemChecked(0))
                    stmp = stmp + " - " + chkTTBT.GetItemText(0);
                if (chkTTBT.GetItemChecked(1))
                    stmp = stmp + " - " + chkTTBT.GetItemText(1);
                if (chkTTBT.GetItemChecked(2))
                    stmp = stmp + " - " + chkTTBT.GetItemText(2);
                if (chkTTBT.GetItemChecked(3))
                    stmp = stmp + " - " + chkTTBT.GetItemText(3);
                if (chkTTBT.GetItemChecked(4))
                    stmp = stmp + " - " + chkTTBT.GetItemText(4);

                stmp = lblTTBaoTri.Text + " : " + stmp.Substring(3, stmp.Length - 3);
                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblTTBaoTri.Name, iDong, 3, true);
                Commons.Modules.MExcel.MText(ws1, "", stmp, iDong, 4, iDong, 6, true, true);

                List<string> sCotNgay = new List<string>() { };
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
                sCotNgay = new List<string>()
                    {
                            "NGAY_BD_KH","NGAY_KT_KH","NGAY_BD_TT","NGAY_KT_TT","NGAY_NGHIEM_THU"
                    };


                WidthColumnsName = new List<Object>()
                    {"STT",5};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_PHIEU_BAO_TRI",20};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_MAY",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_MAY",40};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_LOAI_MAY",25};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_NHOM_MAY",25};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_N_XUONG",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_HE_THONG",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_LOAI_BT",25};
                WidthColumns.Add(WidthColumnsName);


                WidthColumnsName = new List<Object>()
                    {"LY_DO_BT",30};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"NOI_DUNG_CV",40};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"VTPT",40};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"CONG_NHAN",35};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TT_SAU_BT",35};
                WidthColumns.Add(WidthColumnsName);

                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, sBC, sCotNgay, "dd/MM/yyyy", WidthColumns); //FORMAT
                #endregion


                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);


                System.Diagnostics.Process.Start(fi.FullName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    prbIN.Properties.Stopped = true;
                    EnableControl(true);
                }));
                sPath = "";
            }
            catch { }
        }        

        Thread t = null;
        private delegate void CallProcessBar(object flag);
        string sPath = "";

        private void ShowProcessBar(object dt)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), dt);
            }
            else
            {
                //prbIN.Visible = flag;
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                    EnableControl(false);
                    this.Cursor = Cursors.WaitCursor;
                }));
                

                t = new Thread(new ParameterizedThreadStart(InExcel));
                t.Start(dt);
                
            }
        }        
        private void EnableControl(bool flag)
        {

            datTNgay.Enabled = flag;
            datDNgay.Enabled = flag;
            cboDDiem.Enabled = flag;
            cboDChuyen.Enabled = flag;            
            cboLMay.Enabled = flag;
            cboNMay.Enabled = flag;
            cboNVien.Enabled = flag;
            cboLBTri.Enabled = flag;
            chkTTBT.Enabled = flag;

            btnExecute.Enabled = flag;
            btnThoat.Enabled = flag;
            btnALL.Enabled = flag;
            btnNotALL.Enabled = flag;
        }


    }

}
