using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucBieuDoTGNMayTheoMay : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBieuDoTGNMayTheoMay()
        {
            InitializeComponent();
        }
        #region Add event Close form
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("TGNM_M" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNM_M_CHON" + Commons.Modules.UserName);

        }
        #endregion

        #region Load Du Lieu

        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }

        }

        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }
        #endregion

        #region Change du lieu

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        #endregion

        private void LoadTTNMay()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK " +
                " FROM dbo.NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNNNgungMay, grvNNNgungMay, dtTmp, true, false, true, false);
            
            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["HU_HONG"].ReadOnly = true;
            dtTmp.Columns["BTDK"].ReadOnly = true;

            grvNNNgungMay.Columns["CHON"].Width = 100;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Width = 80;
            grvNNNgungMay.Columns["HU_HONG"].Width = 100;
            grvNNNgungMay.Columns["BTDK"].Width = 100;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Width = 400;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Visible = true;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }

        private void ucBieuDoTGNMayTheoMay_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;

            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay.AddMonths(-1);
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadTTNMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            try
            {
                LoadData();
            }
            catch 
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoMay", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            Commons.Modules.ObjSystems.XoaTable("TGNM_M" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("TGNM_M_CHON" + Commons.Modules.UserName);


        }

        private Boolean KiemDLieu()
        {


            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            DateTime TNgay, DNgay;
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;

            if (TNgay >= DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return false;

            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }
#region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoMay", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return false;
            }
            
#endregion  

            return true;
        }

        private void LoadData()
        {
            DataTable dtTmp = new DataTable();
            DateTime TNgay, DNgay;
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBDTGNgungMayTheoMay", datTNgay.DateTime, datDNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage.ToString(), "-1",
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
            string BTam, BTamChon;
#region Lay du lieu chon in
            BTam = "TGNM_M" + Commons.Modules.UserName;
            BTamChon = "TGNM_M_CHON" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, "");
            dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNNNgungMay.DataSource).Copy () ;
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy(); 
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTamChon, dtTmp, "");
#endregion  

            string sSql;

            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;
            sSql = "";

            sSql = " SELECT A.*, SO_LAN , CASE ISNULL(THOI_GIAN_SUA_CHUA ,0) WHEN 0 THEN 0 ELSE THOI_GIAN_SUA_CHUA / SO_LAN END AS MTTR FROM " +
                        " (SELECT CONVERT(INT,NULL) AS STT, A.MS_MAY,TMAY AS TEN_MAY,MODEL,MO_TA,NHIEM_VU_THIET_BI,THOI_GIAN_SUA_CHUA,THOI_GIAN_SUA FROM " +
                        " (SELECT MS_MAY,  TMAY  , SUM(THOI_GIAN_SUA_CHUA) AS THOI_GIAN_SUA_CHUA ,SUM(THOI_GIAN_SUA) AS THOI_GIAN_SUA  " +
                        " FROM " + BTam + " A INNER JOIN " + BTamChon + " B ON A.MS_NGUYEN_NHAN = B.MS_NGUYEN_NHAN  " +
                        " GROUP BY MS_MAY ,TMAY " +
                        " ) A INNER JOIN MAY C ON A.MS_MAY = C.MS_MAY) A LEFT JOIN ( " +
                        " SELECT     MS_MAY, COUNT(DISTINCT MS_LAN) AS SO_LAN " +
                        " FROM         dbo.THOI_GIAN_NGUNG_MAY WHERE NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "'  " +
                        " GROUP BY MS_MAY " +
                        " ) C ON A.MS_MAY = C.MS_MAY ORDER BY THOI_GIAN_SUA_CHUA DESC";

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoMay", "KhongCoMay", Commons.Modules.TypeLanguage));
                return;
            }


            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucBieuDoTGNMayTheoMay");
            InDuLieu();

            Commons.Modules.ObjSystems.XoaTable(BTam);
            Commons.Modules.ObjSystems.XoaTable(BTamChon);
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            int TCot = grvChung.Columns.Count;
            int TDong = grvChung.RowCount;
            int Dong = 1;

            prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 15;// grvChung.RowCount + 11 + TCot - 4;
            prbIN.Properties.Minimum = 0;

            grdChung.ExportToXls(sPath);
            Excel.Workbooks xlWBooks = xlApp.Workbooks;
            Excel.Workbook xlWBook = xlWBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet xlWSheet = (Excel.Worksheet)xlWBook.Sheets[1];
                
            try
            {


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                int SCot;
                SCot = TCot;// (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                 
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TieuDe", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.ToString("dd/MM/yyyy") + " " + lblDNgay.Text + " : " + datDNgay.DateTime.ToString("dd/MM/yyyy");

                //Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 1, "@", 10,tr
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong++;
                stmp = lblNhomMay.Text + " : " + cboNhomMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 3, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong = Dong + 2;

                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWBook, xlWSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong - 1 , 1, Dong - 1, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 14, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 12, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 27, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 35, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 12, "#,##0", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 10, "#,##0", true, Dong + 1, 8, TDong + Dong, 8);

                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 10, Commons.Modules.sSoLeSL, true, Dong + 1, 10, TDong + Dong, 10);

                SCot = 7;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                SCot = 7;
                title = Commons.Modules.MExcel.GetRange(xlWSheet, DongBD, TCot + 2, DongBD, TCot + 2);
                string TDe;
                TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TDTGNM", Commons.Modules.TypeLanguage);
                LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 1, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "G", TDe);

                TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TGSC", Commons.Modules.TypeLanguage);
                LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 2, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "H", TDe);

                TDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "SLNM", Commons.Modules.TypeLanguage);
                LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 3, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "I", TDe);

                TDe = "MTTR";
                LoadBieuDo(xlWSheet, Dong + TDong, 10, "", 4, Convert.ToDouble(title.Left), Convert.ToDouble(title.Top), 500, 200, "J", TDe);
                

                


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                this.Cursor = Cursors.Default;
                Commons.Modules.MExcel.ExcelClose(xlApp, xlWBook, xlWSheet, true, false);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoTGNMayTheoMay", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                
                //xlApp.Visible = true;
                Commons.Modules.MExcel.ExcelClose(xlApp, xlWBook, xlWSheet, false,true);
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }

            prbIN.Position = prbIN.Properties.Maximum;
        }


        //private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan, double iLeft,
        //    double iTop, double iWidth, double iHeight)
        //{
        //    try
        //    {
                
        //        double iTmp = (iSoLan - 1);
        //        iTmp = Math.Floor(iTmp / 3);
        //        double iLan = (iSoLan - 1) % 3;
        //        iLeft = iLeft + iLan * iWidth;
        //        iTop = iTop + iHeight * iTmp;

        //        if (iSoLan == 4) iTop = iTop + 9;
        //        #region prb
        //        prbIN.PerformStep(); prbIN.Update();
        //        #endregion
        //        Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
        //        Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
        //        Excel.Chart xlChart = chartObj.Chart;
        //        Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);


        //        xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

        //        Excel.Series xlSeries = xlSeriesCollection.NewSeries();
        //        #region prb
        //        prbIN.PerformStep(); prbIN.Update();
        //        #endregion
        //        var _with1 = xlSeries;

        //        _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                
        //        if (iSoLan == 4)
        //        {
        //            _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TGSC", Commons.Modules.TypeLanguage);
        //            _with1.Values = ExcelSheets.get_Range("H14", (iDong > 34 ? "H33" : "H" + iDong.ToString())); //"B33");
        //            _with1.XValues = ExcelSheets.get_Range("B14", (iDong > 34 ? "B33" : "B" + iDong.ToString()));
        //        }
        //        else
        //        {
        //            _with1.Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TGNM", Commons.Modules.TypeLanguage);
        //            _with1.Values = ExcelSheets.get_Range("G14", (iDong > 34 ? "G33" : "G" + iDong.ToString())); //"B33");
        //            _with1.XValues = ExcelSheets.get_Range("B14", (iDong > 34 ? "B33" : "B" + iDong.ToString()));
        //        }
        //        xlChart.Refresh();
                
        //        #region prb
        //        prbIN.PerformStep();
        //        prbIN.Update();
        //        #endregion
        //        xlChart.HasTitle = true;
        //        if (iSoLan == 4)
        //            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TDTGSC", Commons.Modules.TypeLanguage);
        //        else
        //            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuDoTGNMayTheoMay", "TDTGNM", Commons.Modules.TypeLanguage);

        //        xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
        //        xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
        //        xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
        //        xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
        //        xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
        //        xlChart.Refresh();


        //    }
        //    catch
        //    { }
        //}
        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDong, int iColumKT, string sTitle, int iSoLan, double iLeft,
            double iTop, double iWidth, double iHeight, string CotDL, string TDBCao)
        {
            try
            {

                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 2);
                double iLan = (iSoLan - 1) % 2;
                iLeft = iLeft + iLan * iWidth;
                iTop = iTop + iHeight * iTmp;

                if (iSoLan > 2) iTop = iTop + 9;
                if (iSoLan == 2 || iSoLan == 4) iLeft = iLeft + 9;

                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);


                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                var _with1 = xlSeries;

                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                //_with1.Name = TDBCao;
                _with1.Values = ExcelSheets.get_Range(CotDL + "14", (iDong > 34 ? CotDL + "33" : CotDL + iDong.ToString()));
                _with1.XValues = ExcelSheets.get_Range("B14", (iDong > 34 ? "B33" : "B" + iDong.ToString()));

                xlChart.HasTitle = true;

                xlChart.ChartTitle.Text = TDBCao;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.Legend.Delete();
                xlChart.Refresh();


            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


    }
}
