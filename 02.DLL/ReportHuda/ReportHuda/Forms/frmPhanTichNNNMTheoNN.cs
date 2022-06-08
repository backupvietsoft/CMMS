using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraCharts;
using System.Threading;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;

namespace ReportHuda
{
    public partial class frmPhanTichNNNMTheoNN : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanTichNNNMTheoNN()
        {
            InitializeComponent();
        }



        private Boolean KgLoad = true;
        private DataTable dtData;

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
        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }
        private void LoadDayChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");

            }
            catch { }
        }
        private void LoadMay()
        {
            try
            {
                if (KgLoad) return;
                DateTime TNgay, DNgay;
                try
                { TNgay = dtTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = dtDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2050"); }


                if (TNgay > DNgay)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCTHThoiGianNgungMay", "TngayLonHonDNgay", Commons.Modules.TypeLanguage));
                    return;
                }




                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                string MsMay = "-1";
                try
                { if (cboMay.Text == "") MsMay = "-1"; else MsMay = cboDChuyen.EditValue.ToString(); }
                catch { MsMay = "-1"; }
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
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayUserAll", 1, Commons.Modules.UserName, NXuong, HThong, -1, LMay, "-1", MsMay,
                        DNgay, Commons.Modules.TypeLanguage));
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, dtMay, "MS_MAY", "TEN_MAY", "");
                Commons.Modules.SQLString = "";
                LoadDL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPhanTichNNNMTheoNN_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                dtTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                dtDNgay.DateTime = dtTNgay.DateTime.AddMonths(1).AddDays(-1);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                LoadNX();
                LoadDayChuyen();
                LoadLoaiMay();
                KgLoad = false;
                LoadMay();

                string[] strTmp = new string[4];
                strTmp[0] = "Pie";
                strTmp[1] = "Doughnut";
                strTmp[2] = "3D Pie";
                strTmp[3] = "3D Doughnut";

                cboChart.Properties.DataSource = strTmp;
                cboChart.Text = "Pie";

                strTmp = new string[7];
                strTmp[0] = "Bar";
                strTmp[1] = "Stacked Bar";
                strTmp[2] = "Full-Stacked Bar";
                strTmp[3] = "3D Bar";
                strTmp[4] = "3D Stacked Bar";
                strTmp[5] = "3D Full-Stacked Bar";
                strTmp[6] = "3D Manhattan Bar";
                cboChr.Properties.DataSource = strTmp;
                cboChr.Text = "Bar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void dtDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

     
        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboMay_EditValueChanged(object sender, EventArgs e)
        {
            if (KgLoad) return;
            if (Commons.Modules.SQLString == "0Load") return;
            LoadDL();
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDL();

            if (optBCao.SelectedIndex == 0)
            {
                lblDiaDiem.Enabled = true;
                cboDDiem.Enabled = true;

                lblLoaiMay.Enabled = true;
                cboLMay.Enabled = true;

                lblDChuyen.Enabled = true;
                cboDChuyen.Enabled = true;
                lblMay.Enabled = true;
                cboMay.Enabled = true;
                grvChung.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage);
                grvChung.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "HU_HONG", Commons.Modules.TypeLanguage);

            }
            if (optBCao.SelectedIndex == 1)
            {
                lblDiaDiem.Enabled = true;
                cboDDiem.Enabled = true;

                lblLoaiMay.Enabled = true;
                cboLMay.Enabled = true;

                lblDChuyen.Enabled = false;
                cboDChuyen.Enabled = false;

                lblMay.Enabled = false;
                cboMay.Enabled = false;

                grvChung.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "MS_N_XUONG", Commons.Modules.TypeLanguage);
                grvChung.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TEN_N_XUONG", Commons.Modules.TypeLanguage);

            }
            if (optBCao.SelectedIndex == 2)
            {
                lblDiaDiem.Enabled = true;
                cboDDiem.Enabled = true;

                lblLoaiMay.Enabled = true;
                cboLMay.Enabled = true;

                lblDChuyen.Enabled = false;
                cboDChuyen.Enabled = false;

                lblMay.Enabled = false;
                cboMay.Enabled = false;

                grvChung.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "MS_HE_THONG", Commons.Modules.TypeLanguage);
                grvChung.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TEN_HE_THONG", Commons.Modules.TypeLanguage);
            }
            if (optBCao.SelectedIndex == 3)
            {
                lblDiaDiem.Enabled = true;
                cboDDiem.Enabled = true;

                lblLoaiMay.Enabled = false;
                cboLMay.Enabled = false;

                lblDChuyen.Enabled = true;
                cboDChuyen.Enabled = true;

                lblMay.Enabled = false;
                cboMay.Enabled = false;
                grvChung.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "MS_LOAI_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TEN_LOAI_MAY", Commons.Modules.TypeLanguage);
            }
            if (optBCao.SelectedIndex == 4)
            {
                lblDiaDiem.Enabled = true;
                cboDDiem.Enabled = true;

                lblLoaiMay.Enabled = true;
                cboLMay.Enabled = true;

                lblDChuyen.Enabled = true;
                cboDChuyen.Enabled = true;

                lblMay.Enabled = false;
                cboMay.Enabled = false;
                grvChung.Columns[0].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "MS_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns[1].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TEN_MAY", Commons.Modules.TypeLanguage);
            }
        }

        private void LoadDL()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                string MsMay = "-1";
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
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }
                try
                { if (cboMay.Text == "") MsMay = "-1"; else MsMay = cboMay.EditValue.ToString(); }
                catch { MsMay = "-1"; }
                dtData = new DataTable();
                dtData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNNNMTheoNN", Commons.Modules.UserName, NXuong,
                        HThong, LMay, MsMay, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, Commons.Modules.TypeLanguage, optBCao.SelectedIndex));
                LocTheoNN();
            }
            catch { }
        }
        private void LocTheoNN()
        {
            if (optLoaiNN.SelectedIndex == 0)
            {
                dtData.DefaultView.Sort = "TG_NGUNG DESC";
            }
            else
            {
                dtData.DefaultView.Sort = "TG_SUA DESC";
            }
            dtData = dtData.DefaultView.ToTable();
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtData, false, true, false, true, true, this.Name);
            if (optLoaiNN.SelectedIndex == 0)
            {
                grvChung.Columns["TG_NGUNG"].Visible = true;
                grvChung.Columns["TG_SUA"].Visible = false;
            }
            else
            {
                grvChung.Columns["TG_NGUNG"].Visible = false;
                grvChung.Columns["TG_SUA"].Visible = true;
            }
            TaoChart();
            grvChung.OptionsView.ColumnAutoWidth = true;
            grvChung.Columns["TG_NGUNG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvChung.Columns["TG_NGUNG"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeSL.ToString() + "}";
            grvChung.Columns["TG_SUA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvChung.Columns["TG_SUA"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeSL.ToString() + "}";

        }

        private void optLoaiNN_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocTheoNN();
        }

        private void TaoChart()
        {
            try
            {

                DataTable dtTmp = dtData.Clone(); // if needed
                int max = 10;
                try
                {
                    max = int.Parse(txtTop.Text);
                }
                catch { }
                Math.Min(max, dtData.Rows.Count);
                if (dtData.Rows.Count <= max) max = dtData.Rows.Count;



                for (int i = 0; i < max; i++)
                {
                    DataRow dr = dtTmp.NewRow();
                    //dr.ItemArray = dtData.Rows[i].ItemArray;
                    dr[0] = grvChung.GetRowCellValue(i, grvChung.Columns[0]);
                    dr[1] = grvChung.GetRowCellValue(i, grvChung.Columns[1]);
                    dr[2] = Convert.ToInt64(grvChung.GetRowCellValue(i, grvChung.Columns[2]).ToString().Replace(".", ""));
                    dr[3] = Convert.ToInt64(grvChung.GetRowCellValue(i, grvChung.Columns[3]).ToString().Replace(".", ""));

                    dtTmp.Rows.Add(dr);

                }

                chartCot.Series.Clear();
                chartTron.Series.Clear();

                //strTmp[0] = "Bar";
                //strTmp[1] = "Stacked Bar";
                //strTmp[2] = "Full-Stacked Bar";
                //strTmp[3] = "3D Bar";
                //strTmp[4] = "3D Stacked Bar";
                //strTmp[5] = "3D Full-Stacked Bar";
                //strTmp[6] = "3D Manhattan Bar";                
                Series series = new Series("Series1", ViewType.Bar);
                if (cboChr.Text.ToUpper() == "Bar".ToUpper()) series = new Series("Series1", ViewType.Bar);
                if (cboChr.Text.ToUpper() == "Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.StackedBar);
                if (cboChr.Text.ToUpper() == "Full-Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.FullStackedBar);
                if (cboChr.Text.ToUpper() == "3D Bar".ToUpper()) series = new Series("Series1", ViewType.Bar3D);
                if (cboChr.Text.ToUpper() == "3D Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.StackedBar3D);
                if (cboChr.Text.ToUpper() == "3D Full-Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.FullStackedBar3D);
                if (cboChr.Text.ToUpper() == "3D Manhattan Bar".ToUpper()) series = new Series("Series1", ViewType.ManhattanBar);
                series.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                series.LegendText = "{A}{V:$0}";


                Series series1 = new Series("Series1", ViewType.Pie);

                if (cboChart.Text.ToUpper() == "Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie);
                if (cboChart.Text.ToUpper() == "Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut);
                if (cboChart.Text.ToUpper() == "3D Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie3D);
                if (cboChart.Text.ToUpper() == "3D Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut3D);
                series1.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Number;


                if (optBCao.SelectedIndex == 0)
                {
                    series.Name = grvChung.Columns[0].Caption;
                    series.DataSource = dtTmp;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = "TEN_NGUYEN_NHAN";

                    series1.Name = grvChung.Columns[0].Caption;
                    series1.DataSource = dtTmp;
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "TEN_NGUYEN_NHAN";

                }
                else
                {
                    series.Name = grvChung.Columns[0].Caption;
                    series.DataSource = dtTmp;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = "TEN";

                    series1.Name = grvChung.Columns[0].Caption;
                    series1.DataSource = dtTmp;
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "TEN";
                }
                series.ValueScaleType = ScaleType.Numerical;

                series.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                series.PointOptions.ValueNumericOptions.Precision = Commons.Modules.iSoLeSL;


                if (optLoaiNN.SelectedIndex == 0)
                    series.ValueDataMembers.AddRange(new string[] { "TG_NGUNG" });
                else
                    series.ValueDataMembers.AddRange(new string[] { "TG_SUA" });
                chartCot.Series.Add(series);








                chartCot.Legend.Visible = false;

                series1.ValueScaleType = ScaleType.Numerical;
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                series1.PointOptions.ValueNumericOptions.Precision = Commons.Modules.iSoLeSL;


                if (optLoaiNN.SelectedIndex == 0)
                    series1.ValueDataMembers.AddRange(new string[] { "TG_NGUNG" });
                else
                    series1.ValueDataMembers.AddRange(new string[] { "TG_SUA" });
                series1.DataSource = dtTmp;
                series1.LegendText = "{A}{V:$0}";

                chartTron.Series.Add(series1);


                PiePointOptions pointOpts = (PiePointOptions)chartTron.Series[0].PointOptions;
                DevExpress.XtraCharts.PiePointOptions p = new DevExpress.XtraCharts.PiePointOptions();
                p.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                pointOpts.PercentOptions.ValueAsPercent = false;
                p.ValueNumericOptions.Format = NumericFormat.Number;
                p.ValueNumericOptions.Precision = 2;
                series1.PointOptions.PointView = p.PointView;




                chartTron.Legend.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtTop_EditValueChanged(object sender, EventArgs e)
        {
            TaoChart();
        }
        private void grvChung_EndSorting(object sender, EventArgs e)
        {
            TaoChart();
        }

        private void cboChart_EditValueChanged(object sender, EventArgs e)
        {
            TaoChart();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string sPath = "";


        private void InExcel()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dtTmp = dtData.Clone();
            dtTmp.Columns[1].DataType = typeof(string);
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataRow dr = dtTmp.NewRow();
                dr[0] = grvChung.GetRowCellValue(i, grvChung.Columns[0]);
                if (optBCao.SelectedIndex == 0)
                {
                    if (Boolean.Parse(grvChung.GetRowCellValue(i, grvChung.Columns[1]).ToString()))
                        dr[1] = "þ";
                    else
                        dr[1] = "o";
                }
                else
                    dr[1] = grvChung.GetRowCellValue(i, grvChung.Columns[1]);

                if (optLoaiNN.SelectedIndex == 0)
                    dr[2] = grvChung.GetRowCellValue(i, grvChung.Columns[2]);
                else
                    dr[2] = grvChung.GetRowCellValue(i, grvChung.Columns[3]);
                dtTmp.Rows.Add(dr);
            }
            dtTmp.Columns.RemoveAt(dtTmp.Columns.Count - 1);
            dtTmp.AcceptChanges();


            GridControl grdData = new GridControl();
            GridView grvData = new GridView();
            grdData.MainView = grvData;
            grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            grvData});

            grvData.GridControl = grdData;
            grvData.Name = "grvData";
            grvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grvData.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            grvData.OptionsView.ShowGroupPanel = false;

            BeginInvoke((Action)(() =>
            {
                this.Controls.Add(grdData);
            }));

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true, true, Name);

            #region prb
            //prbIN.PerformLayout();
            //prbIN.Refresh();
            #endregion

            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application xlApp = new Excel.Application();
            try
            {
                grvData.ExportToXls(sPath);
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;

                #region "TaoSheet1"
                xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, grvChung.RowCount + 1, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);

                int TCot = dtTmp.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot + 5);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);


                if (optBCao.SelectedIndex == 0)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2 || optBCao.SelectedIndex == 3)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);
                if (optBCao.SelectedIndex == 4)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblTitle", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion
                string sTmp = "";
                sTmp = lblFromDate.Text + " : " + dtTNgay.DateTime.Date.ToShortDateString() + " " + lblToDate.Text + " : " + dtDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                sTmp = lblDiaDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                if (optBCao.SelectedIndex == 0)
                {
                    Dong++;
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = lblLoaiMay.Text + " : " + cboLMay.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = lblMay.Text + " : " + cboMay.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 14, 2, 13 + TDong, 2);
                    title.Font.Name = "Wingdings";
                    title.Font.Size = 12;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                }
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2)
                {
                    Dong++;
                    sTmp = lblLoaiMay.Text + " : " + cboLMay.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                if (optBCao.SelectedIndex == 3)
                {
                    Dong++;
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                if (optBCao.SelectedIndex == 4)
                {
                    Dong++;
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = lblLoaiMay.Text + " : " + cboLMay.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                Dong++;
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[0].Caption, Dong, 1, "@", 10, true, true, Dong, 1);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[1].Caption, Dong, 2, "@", 10, true, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[2].Caption, Dong, 3, "@", 10, true, true, Dong, 3);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion



                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion


                if (optBCao.SelectedIndex == 0)
                {
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 1, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 1, 1, TDong + Dong, 1);
                }
                else
                {
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 33, "@", true, Dong + 1, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 1, 1, TDong + Dong, 1);
                }
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "#,##0", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 7, "", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8.71, "", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 7, "", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "", true, Dong + 1, 7, TDong + Dong, 7);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "", true, Dong + 1, 10, TDong + Dong, 10);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "", true, Dong + 1, 13, TDong + Dong, 13);

                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion


                int iDongBD = 14;
                if (optBCao.SelectedIndex == 0)
                    iDongBD = 14;
                if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2 || optBCao.SelectedIndex == 3)
                    iDongBD = 12;
                if (optBCao.SelectedIndex == 4)
                    iDongBD = 13;

                int iTongDong = iDongBD + int.Parse(txtTop.Text.ToString()) - 1;
                if (grvChung.RowCount + iDongBD <= iTongDong) iTongDong = iDongBD + grvChung.RowCount - 1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 4, 5, 4);
                LoadBieuDo(xlWorkSheet, iDongBD, iTongDong, Convert.ToDouble(title.Left) + 15, Convert.ToDouble(title.Top), 386.92, 235.55);
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                #endregion


                xlApp.Visible = true;
                xlWorkBook.Save();





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
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            BeginInvoke((Action)(() =>
            {
                prbIN.Properties.Stopped = true;
            }));
            sPath = "";
            EnableControl(true);
            this.Cursor = Cursors.Default;
            grdData.Dispose();
        }


        private void InNNNgungMay(Excel.Application xlApp, Excel.Workbooks excelWorkbooks, ref Excel.Workbook xlWorkBook, DateTime tNgay, DateTime dNgay, string nnNMay, int loaiNN, object diaDiemID, object tenDiaDiem, object dayChuyenID, object tenDayChuyen, object loaiMayID, object tenLoaiMay, string sPath, int loaiBaoCao,double target, int num)
        {

            this.Cursor = Cursors.WaitCursor;

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




            DataTable dtData = new DataTable();
            dtData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNNNMTheoNNVECO", Commons.Modules.UserName, diaDiemID, dayChuyenID, loaiMayID, "-1", tNgay, dNgay, Commons.Modules.TypeLanguage, 0));



            if (optLoaiNN.SelectedIndex == 0)
                dtData.DefaultView.Sort = "TG_NGUNG DESC";
            else
                dtData.DefaultView.Sort = "TG_SUA DESC";
            dtData = dtData.DefaultView.ToTable();

            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtData, false, true, true, true, true, "frmPhanTichNNNMTheoNN");

            if (dtData.Rows.Count <= 0)
            {
                Excel.Worksheet xlWSheetRong;
                if (num == 0)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtData, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");
                    grv.ExportToXls(sPath);
                    xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                }
                else
                {
                    xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                       System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value);
                }
                xlWSheetRong = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];
                xlWSheetRong.Name = "Empty Data - " + tNgay.AddDays(10).ToString("MMMM") + "_" + (diaDiemID.ToString().Contains(',') ? tenDiaDiem : diaDiemID.ToString());
                xlWSheetRong.Activate();
                return;
            }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoDownTime", loaiNN,
                tNgay.Date, dNgay.Date, diaDiemID, dayChuyenID, loaiMayID, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            GridControl grdData = new GridControl();
            GridView grvData = new GridView();
            grdData.MainView = grvData;
            grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            grvData});
            grvData.GridControl = grdData;
            grvData.Name = "grvData";
            grvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grvData.OptionsView.ShowGroupPanel = false;
            BeginInvoke((Action)(() =>
            {
                this.Controls.Add(grdData);
            }));

            if (dtTmp.Rows.Count == 0)
            {
                Excel.Worksheet xlWSheetRong;
                if (num == 0)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");
                    grvData.ExportToXls(sPath);
                    xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                }
                else
                {
                    xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                       System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value);
                }
                xlWSheetRong = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];
                xlWSheetRong.Name = "Empty Data - " + tNgay.AddDays(10).ToString("MMMM") + "_" + (diaDiemID.ToString().Contains(',') ? tenDiaDiem : diaDiemID.ToString());

                xlWSheetRong.Activate();
                return;
            }
            this.Cursor = Cursors.WaitCursor;


            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");


            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            try
            {

                Excel.Worksheet xlWSheet2;
                Excel.Range title;
                if (num == 0)
                {
                    grvData.ExportToXls(sPath);
                    xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                }
                else
                {
                    xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                       System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value);
                }
                xlWSheet2 = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];
                xlWSheet2.Name = tNgay.AddDays(10).ToString("MMMM") + "_" + (diaDiemID.ToString().Contains(',') ? tenDiaDiem : diaDiemID.ToString());

                xlWSheet2.Activate();
                if (num > 0)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 1, grvData.RowCount + 1, dtTmp.Columns.Count);
                    Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 15, "@", true, 9, 10, 9 + grvData.RowCount, 10);

                    object[,] rawData = new object[dtTmp.Rows.Count + 1, dtTmp.Columns.Count];
                    for (int col = 0; col <= dtTmp.Columns.Count - 1; col++)
                    {
                        rawData[0, col] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", dtTmp.Columns[col].ColumnName, Commons.Modules.TypeLanguage);
                    }

                    for (int col = 0; col <= dtTmp.Columns.Count - 1; col++)
                    {
                        for (int row = 0; row <= dtTmp.Rows.Count - 1; row++)
                        {
                            if (col == 1)
                            {
                                try
                                {
                                    rawData[row + 1, col] = Convert.ToDateTime(dtTmp.Rows[row][col].ToString()).ToString("yyyy/MM/dd");
                                }
                                catch
                                {
                                    rawData[row + 1, col] = dtTmp.Rows[row][col].ToString();
                                }
                            }
                            else
                            {
                                rawData[row + 1, col] = col == 9 ? "'" + dtTmp.Rows[row][col].ToString() : dtTmp.Rows[row][col].ToString();
                            }

                        }
                    }
                    title.Value = rawData;
                }

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;


                #region "TaoSheet1"
                int TCot = dtTmp.Columns.Count - 1;
                int TDong = dtTmp.Rows.Count;
                int Dong = 1;

                Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWSheet2, 1, 5, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWSheet2, 0, 0, 110, 45, Application.StartupPath);


                string sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhanTichNNNMTheoNNVeCo", "bcTieuDeDownTimeInProduction", Commons.Modules.TypeLanguage);

                Dong = Dong + 1;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sTmp, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong = Dong + 2;




                title = Commons.Modules.MExcel.GetRange(xlWSheet2, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWSheet2.get_Range(xlWSheet2.Cells[Dong - 1, 1], xlWSheet2.Cells[Dong - 1, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWSheet2, false, true, true,
                      true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100);
                if (num == 0)
                {
                    for (int i = 0; i < dtTmp.Columns.Count - 1; i++)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWSheet2, 8, i + 1, 8, i + 1);
                        title.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "frmPhanTichNNNMTheoNNVeCo", dtTmp.Columns[i].ColumnName, Commons.Modules.TypeLanguage);
                    }
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, 8, 1, 8, grvData.Columns.Count - 1);
                    title.RowHeight = 30;
                }
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 4, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 11, "dd/MM/yyyy", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 0, "#,##0", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 11, "@", true, Dong + 1, 4, TDong + Dong, TCot);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 7, "@", true, 1, 4, 1, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 22, "@", true, 1, 5, 1, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 9, "hh:mm", true, Dong + 1, 7, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 11, "#,##0", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 15, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 20, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 30, "@", true, 1, 12, 1, 15);


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, TCot + 1, 1, TCot + 1);
                title.EntireColumn.Delete();

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 7, 1, 7, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 9, 9, TDong + Dong, 9);
                Excel.FormatCondition condition1;
                condition1 = (Excel.FormatCondition)
            (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=60", Type.Missing));
                condition1.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);


                xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                         System.Reflection.Missing.Value,
                         System.Reflection.Missing.Value);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];

                xlSheet.Name = "General-Analysis_" + (diaDiemID.ToString().Contains(',') ? tenDiaDiem : diaDiemID.ToString());

                xlSheet.Activate();
                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.DisplayAlerts = false;

                dtTmp = new DataTable();
                dtTmp = dtData.Clone();
                dtTmp.Columns[1].DataType = typeof(string);
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    try
                    {
                        DataRow dr = dtTmp.NewRow();
                        dr[0] = grv.GetRowCellValue(i, grv.Columns[0]);
                        if (loaiBaoCao == 0)
                        {
                            if (Boolean.Parse(grv.GetRowCellValue(i, grv.Columns[1]).ToString()))
                                dr[1] = "þ";
                            else
                                dr[1] = "o";
                        }
                        else
                            dr[1] = grv.GetRowCellValue(i, grv.Columns[1]);

                        if (loaiNN == 0)
                            dr[2] = grv.GetRowCellValue(i, grv.Columns[2]);
                        else
                            dr[2] = grv.GetRowCellValue(i, grv.Columns[3]);
                        dtTmp.Rows.Add(dr);
                    }
                    catch { }
                }
                dtTmp.Columns.RemoveAt(dtTmp.Columns.Count - 1);
                dtTmp.AcceptChanges();


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");

                TCot = dtTmp.Columns.Count;
                TDong = grvData.RowCount;
                Dong = 1;

                title = Commons.Modules.MExcel.GetRange(xlSheet, 1, 1, grvData.RowCount + 1, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlSheet, title);

                Dong = Commons.Modules.MExcel.TaoTTChung(xlSheet, 1, 3, 1, TCot + 5);
                Commons.Modules.MExcel.TaoLogo(xlSheet, 0, 0, 110, 45, Application.StartupPath);

                if (loaiBaoCao == 0)
                    Commons.Modules.MExcel.ThemDong(xlSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                if (loaiBaoCao == 1 || loaiBaoCao == 2 || loaiBaoCao == 3)
                    Commons.Modules.MExcel.ThemDong(xlSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);
                if (loaiBaoCao == 4)
                    Commons.Modules.MExcel.ThemDong(xlSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblTitle", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblFromDate", Commons.Modules.TypeLanguage) + " : " + tNgay.ToString("dd/MM/yyyy") + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblToDate", Commons.Modules.TypeLanguage) + " : " + dNgay.ToString("dd/MM/yyyy");
                Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 1, "@", 11, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblDiaDiem", Commons.Modules.TypeLanguage) + " : " + tenDiaDiem;
                Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                if (loaiBaoCao == 0)
                {
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblDChuyen", Commons.Modules.TypeLanguage) + " : " + tenDayChuyen;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblLoaiMay", Commons.Modules.TypeLanguage) + " : " + tenLoaiMay;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblMay", Commons.Modules.TypeLanguage) + " : " + "< ALL >";
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    title = Commons.Modules.MExcel.GetRange(xlSheet, 14, 2, 13 + TDong, 2);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                if (loaiBaoCao == 1 || loaiBaoCao == 2)
                {
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblLoaiMay", Commons.Modules.TypeLanguage) + " : " + tenLoaiMay;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                if (loaiBaoCao == 3)
                {
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblDChuyen", Commons.Modules.TypeLanguage) + " : " + tenDayChuyen;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                if (loaiBaoCao == 4)
                {
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblDChuyen", Commons.Modules.TypeLanguage) + " : " + tenDayChuyen;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhanTichNNNMTheoNNVeCo", "lblLoaiMay", Commons.Modules.TypeLanguage) + " : " + tenLoaiMay;
                    Commons.Modules.MExcel.DinhDang(xlSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                Dong++;
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlSheet, grv.Columns[0].Caption, Dong, 1, "@", 10, true, true, Dong, 1);
                Commons.Modules.MExcel.DinhDang(xlSheet, grv.Columns[1].Caption, Dong, 2, "@", 10, true, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlSheet, grv.Columns[2].Caption, Dong, 3, "@", 10, true, true, Dong, 3);

                title = Commons.Modules.MExcel.GetRange(xlSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlSheet.get_Range(xlSheet.Cells[Dong - 1, 1], xlSheet.Cells[Dong - 1, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                if (loaiBaoCao == 0)
                {
                    Commons.Modules.MExcel.ColumnWidth(xlSheet, 23, "@", true, Dong + 1, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlSheet, 23, "@", true, Dong + 1, 1, TDong + Dong, 1);
                }
                else
                {
                    Commons.Modules.MExcel.ColumnWidth(xlSheet, 33, "@", true, Dong + 1, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlSheet, 13, "@", true, Dong + 1, 1, TDong + Dong, 1);
                }

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 11, "#,##0", true, Dong + 1, 3, TDong + Dong, 3);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 7, "", true, Dong + 1, 4, TDong + Dong, 4);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 8.71, "", true, Dong + 1, 5, TDong + Dong, 5);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 7, "", true, Dong + 1, 6, TDong + Dong, 6);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 8, "", true, Dong + 1, 7, TDong + Dong, 7);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 14, "", true, Dong + 1, 8, TDong + Dong, 8);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 14, "", true, Dong + 1, 9, TDong + Dong, 9);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 13, "", true, Dong + 1, 10, TDong + Dong, 10);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 14, "", true, Dong + 1, 11, TDong + Dong, 11);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 15, "", true, Dong + 1, 12, TDong + Dong, 12);

                Commons.Modules.MExcel.ColumnWidth(xlSheet, 20, "", true, Dong + 1, 13, TDong + Dong, 13);

                int iDongBD = 14;

                if (loaiBaoCao == 0)
                    iDongBD = 14;
                if (loaiBaoCao == 1 || loaiBaoCao == 2 || loaiBaoCao == 3)
                    iDongBD = 12;
                if (loaiBaoCao == 4)
                    iDongBD = 13;

                title = Commons.Modules.MExcel.GetRange(xlSheet, 5, 4, 5, 4);
                // int iTongDong = iDongBD + int.Parse(title.Top.ToString()) - 1;
                //if (grv.RowCount + iDongBD <= iTongDong) iTongDong = iDongBD + grv.RowCount - 1;


                LoadBieuDo(xlSheet, iDongBD, grv.RowCount + iDongBD - 1, Convert.ToDouble(title.Left) + 15, Convert.ToDouble(title.Top), 386.92, 235.55);


                #endregion

                #region Downtime
                xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                     System.Reflection.Missing.Value,
                     System.Reflection.Missing.Value);

                Excel.Worksheet xlSheet3 = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];
                xlSheet3.Name = "Downtime-Ratio_" + (diaDiemID.ToString().Contains(',') ? tenDiaDiem : diaDiemID.ToString());
                xlSheet3.Activate();

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoDowntimeRatio", tNgay, dNgay, diaDiemID));

                DataTable dtTmp1 = new DataTable();
                dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spPIVOTNguyenNhanNgungMay", tNgay, dNgay, "-1", Commons.Modules.UserName));

                Excel.Range title1;



                GridControl grdData1 = new GridControl();
                GridView grvData1 = new GridView();
                grdData1.MainView = grvData1;
                grdData1.ViewCollection.Add(grvData1);
                grvData1.GridControl = grdData1;
                grvData1.Name = "grvData1";
                grvData1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                grvData1.OptionsView.ShowGroupPanel = false;

                BeginInvoke((Action)(() =>
                {
                    this.Controls.Add(grdData1);
                }));



                try
                {
                    grdData.DataSource = null;
                    grdData1.DataSource = null;
                }
                catch { }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData1, grvData1, dtTmp1, false, true, false, true, true, "frmPhanTichNNNMTheoNNVeCo");

                TCot = dtTmp.Columns.Count;
                TDong = grvData.RowCount;
                Dong = 1;

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 21, grvData.RowCount + 2, 21 + dtTmp.Columns.Count - 1);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlSheet3, title);

                title1 = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 33, grvData1.RowCount + 2, 33 + dtTmp1.Columns.Count - 1);
                Commons.Modules.MExcel.MExportExcel(dtTmp1, xlSheet3, title1);


                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlSheet3, false, true, true,
                true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;

                //fix today cột 30
                title = Commons.Modules.MExcel.GetRange(xlSheet3, 1, 30, 1, 30);
                title.Formula = "=TODAY()";
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                //thêm fix dòng đầu (3) - vì dòng sau dựa vào dòng đầu
                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 22, 3, 22);
                title.Formula = "= IF($AD$1 < U3 + 1, \" \", " + title.Value + ")";
                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 23, 3, 23);
                title.Formula = "= IF($AD$1 < U3 + 1, \" \", SUM($AH3:$AK3))";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 24, 3, 24);
                title.Formula = "= IF($AD$1 < U3 + 1, \" \", SUM($AL3:$AX3))";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 25, 3, 25);
                title.Formula = "= IF($AD$1 < U3 + 1,\" \",V3-W3-X3)";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 25, 3, 25);
                title.Formula = "= IF($AD$1<U3+1,\" \",V3-W3-X3)";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 26, 3, 26);
                title.Formula = "= IF($AD$1 < U3, \" \", 1440 * DAY(AG3))";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 27, 3, 27);
                title.Formula = "= W3";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 28, 3, 28);
                title.Formula = "= X3";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 29, 3, 29);
                title.Formula = "= Y3";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 30, 3, 30);
                title.Formula = "= IF($AD$1 < U3 + 1, \" \", IF(Z3 = AA3, \"-\", AB3 / (Z3 - AA3)))";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 31, 3, 31);
                title.Formula = "= IF($AD$1 < U3 + 1, \" \", " + target.ToString() + "%)";

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
      "frmPhanTichNNNMTheoNNVeCo", "Sum", Commons.Modules.TypeLanguage), 2, 33 + grvData1.Columns.Count, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 2, 33 + grvData1.Columns.Count);

                for (int row = 3; row <= grvData1.RowCount + 2; row++)
                {
                    for (int col = 34; col < 34 + grvData1.Columns.Count - 1; col++)
                    {
                        title1 = Commons.Modules.MExcel.GetRange(xlSheet3, row, col, row, col);
                        string diem = Commons.Modules.MExcel.TimDiemExcel(2, col);
                        string diem1 = Commons.Modules.MExcel.TimDiemExcel(row, 33);
                        title1.Formula = "= SUMIFS(" + xlWSheet2.Name + "!$I$9:$I$2880," + xlWSheet2.Name + "!$L$9:$L$2880, $" + diem.Remove(diem.Length - 1) + "$" + 2 + ", " + xlWSheet2.Name + "!$A$9:$A$2880, Day($" + diem1 + " ))";
                    }
                    title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 33 + grvData1.Columns.Count, row, 33 + grvData1.Columns.Count);
                    title.Formula = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(row, 34) + ":" + Commons.Modules.MExcel.TimDiemExcel(row, 32 + grvData1.Columns.Count) + ")";
                }

                //22   23    24     25        26        27          28          29        30       31
                //cal - SD - DT - Act. Op - Calc. Op - Shutdown - Downtime -  Act. Op - DT ratio - Target
                for (int row = 4; row <= grvData.RowCount + 2; row++)
                {
                    try
                    {
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 22, row, 22);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1, \" \", " + title.Value + ")";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 23, row, 23);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1, \" \", SUM($AH" + row.ToString() + ":$AK" + row.ToString() + "))";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 24, row, 24);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1, \" \", SUM($AL" + row.ToString() + ":$AX" + row.ToString() + "))";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 25, row, 25);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1,\" \",V" + row.ToString() + "-W" + row.ToString() + "-X" + row.ToString() + ")";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 26, row, 26);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + ", \" \", 1440 * DAY(AG" + row.ToString() + "))";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 27, row, 27);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1,\" \",W" + row.ToString() + " + AA" + (row - 1).ToString() + ")";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 28, row, 28);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1, \" \", X" + row.ToString() + " + AB" + (row - 1).ToString() + ")";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 29, row, 29);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1,\" \",Y" + row.ToString() + " + AC" + (row - 1).ToString() + ")";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 30, row, 30);
                        title.Formula = "=IF($AD$1 < U" + row.ToString() + " + 1, \" \", IF(Z" + row.ToString() + " = AA" + row.ToString() + ", \"-\", AB" + row.ToString() + " / (Z" + row.ToString() + " - AA" + row.ToString() + ")))";
                        title = Commons.Modules.MExcel.GetRange(xlSheet3, row, 31, row, 31);
                        title.Formula = "= IF($AD$1 < U" + row.ToString() + " + 1, \" \", " + target.ToString() + "%)";
                    }
                    catch
                    { }
                }
                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 21, 2, 200);
                title.RowHeight = 33;
                title.WrapText = true;
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 1, 1, 1, 200);
                title.RowHeight = 29.80;

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhanTichNNNMTheoNNVeCo", "bcDownTimeRatioTieuDe", Commons.Modules.TypeLanguage), 1, 1, "@", 20, true, true, 1, 1);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 1, 17, 1, 17);
                title.Formula = "=SUM(W3:X" + (grvData.RowCount + 1).ToString() + ")";

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 1, 18, 1, 18);
                title.Formula = "=SUM(AH3:" + Commons.Modules.MExcel.TimDiemExcel(grvData.RowCount + 1, 32 + grvData1.Columns.Count) + ")";

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmPhanTichNNNMTheoNNVeCo", "bcDownTimeRatioTieuDe", Commons.Modules.TypeLanguage) + " " + tNgay.AddDays(10).ToString("MMMM yyyy").ToUpper() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmPhanTichNNNMTheoNNVeCo", "bcDownTimeRatioTieuDe1", Commons.Modules.TypeLanguage), 1, 1, "@", 20, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 1, 15);

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
               "frmPhanTichNNNMTheoNNVeCo", "DailyValue", Commons.Modules.TypeLanguage), 1, 22, "@", 18, false, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 1, 25);

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
               "frmPhanTichNNNMTheoNNVeCo", "AccumulatedValue", Commons.Modules.TypeLanguage), 1, 26, "@", 18, false, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 1, 29);

                Commons.Modules.MExcel.DinhDang(xlSheet3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
               "frmPhanTichNNNMTheoNNVeCo", "Category", Commons.Modules.TypeLanguage), 1, 33, "@", 18, false, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 1, 32 + grvData1.Columns.Count);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 34, 100, 33 + dtTmp1.Columns.Count - 1);
                title.WrapText = true;
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 6, "@", false, 1, 1, 1, 20);
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 7, "dd-MMM", false, 2, 21, 1000, 21);
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 7, "_(* #,##0_);_(* (#,##0);_(* \" - \"_);_(@_)", false, 3, 22, 100, 29);
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 7, "0.0%", false, 3, 30, 100, 32);
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 7, "dd-MMM", false, 2, 33, 1000, 33);
                Commons.Modules.MExcel.ColumnWidth(xlSheet3, 14.15, "", false, 2, 34, 100, 33 + dtTmp1.Columns.Count - 1);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 21, grvData.RowCount + 2, 21 + dtTmp.Columns.Count - 1);
                title.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDash;
                title.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDash;

                title1 = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 33, grvData1.RowCount + 2, 33 + dtTmp1.Columns.Count);
                title1.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDash;
                title1.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDash;
                title = Commons.Modules.MExcel.GetRange(xlSheet3, 3, 1, 3, 1);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 23, grvData.RowCount + 2, 23);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(235, 241, 232));
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 24, grvData.RowCount + 2, 24);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 102));
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 25, grvData.RowCount + 2, 25);
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(51, 153, 51));

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 26, grvData.RowCount + 2, 29);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(197, 217, 241));
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 30, grvData.RowCount + 2, 31);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(191, 191, 191));
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 31, grvData.RowCount + 2, 31);
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                title = Commons.Modules.MExcel.GetRange(xlSheet3, 2, 1, 2, 100);
                title.RowHeight = 50;
                title.WrapText = true;
                LoadBieuDoDowntimRatio(xlSheet3, 3, 21 + dtTmp.Columns.Count - 1, grvData.RowCount + 2, Convert.ToDouble(title.Left) + 15, Convert.ToDouble(title.Top), 600, 300);
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbooks);
                Commons.Modules.ObjSystems.MReleaseObject(xlWSheet2);
                Commons.Modules.ObjSystems.MReleaseObject(xlSheet3);
                Commons.Modules.ObjSystems.MReleaseObject(xlSheet);
                grdData1.Dispose();
                grdData.Dispose();
                //   grd.Dispose();
            }
            catch 
            {
            }

        }
        private void LoadBieuDoDowntimRatio(Excel.Worksheet ExcelSheets, int iDongBD, int iCot, int iTongDong, double iLeft, double iTop, double iWidth, double iHeight)
        {
            try
            {
                #region prb
                //prbIN.PerformLayout(); ////prbIN.Refresh();
                #endregion
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;

                Excel.SeriesCollection xlSeriesCollection1 = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);
                Excel.Series xlSeries1 = xlSeriesCollection1.NewSeries();

                var _with11 = xlSeries1;
                xlSeries1.Name = "Actual";
                _with11.Values = ExcelSheets.get_Range("AD3", "AD" + iTongDong);
                xlChart.HasTitle = false;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                xlChart.ChartType = Excel.XlChartType.xlLineMarkers;
                xlChart.Refresh();




                Excel.Series xlSeries2 = xlSeriesCollection1.NewSeries();
                xlSeries2.Name = "Target";
                var _with12 = xlSeries2;

                _with12.Values = ExcelSheets.get_Range("AE3", "AE" + iTongDong);

                xlChart.HasTitle = false;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                xlChart.ChartType = Excel.XlChartType.xlLineMarkers;
                xlChart.Refresh();


            }
            catch
            { }
        }


        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDongBD, int iTongDong, double iLeft, double iTop, double iWidth, double iHeight)
        {
            try
            {
                #region prb
                //prbIN.PerformLayout(); //prbIN.Refresh();
                #endregion
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                #region prb
                //prbIN.PerformLayout(); //prbIN.Refresh();
                #endregion
                var _with1 = xlSeries;
                if (optBCao.SelectedIndex == 0)
                    _with1.Name = grvChung.Columns[0].Caption;
                else
                    _with1.Name = grvChung.Columns[1].Caption;

                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                _with1.Values = ExcelSheets.get_Range("C" + iDongBD.ToString(), (iTongDong > 61 ? "C61" : "C" + iTongDong.ToString()));
                if (optBCao.SelectedIndex == 0 || optBCao.SelectedIndex == 4)
                {
                    _with1.XValues = ExcelSheets.get_Range("A" + iDongBD.ToString(), (iTongDong > 61 ? "A61" : "A" + iTongDong.ToString())); //"B33");
                }
                else
                {
                    _with1.XValues = ExcelSheets.get_Range("B" + iDongBD.ToString(), (iTongDong > 61 ? "B61" : "B" + iTongDong.ToString())); //"B33");
                }
                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion
                xlChart.HasTitle = false;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;
                xlChart.Refresh();


                Excel.ChartObjects chartObjs1 = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj1 = chartObjs1.Add(iLeft, 300, iWidth, iHeight);
                Excel.Chart xlChart1 = chartObj1.Chart;
                Excel.SeriesCollection xlSeriesCollection1 = (Excel.SeriesCollection)xlChart1.SeriesCollection(Type.Missing);
                xlChart1.ChartType = Excel.XlChartType.xlPie;

                Excel.Series xlSeries1 = xlSeriesCollection1.NewSeries();
                #region prb
                //prbIN.PerformLayout(); //prbIN.Refresh();
                #endregion

                var _with11 = xlSeries1;

                _with11.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                _with11.Values = ExcelSheets.get_Range("C" + iDongBD.ToString(), (iTongDong > 61 ? "C61" : "C" + iTongDong.ToString()));

                if (optBCao.SelectedIndex == 0 || optBCao.SelectedIndex == 4)
                {
                    _with11.XValues = ExcelSheets.get_Range("A" + iDongBD.ToString(), (iTongDong > 61 ? "A61" : "A" + iTongDong.ToString()));
                }
                else
                {
                    _with11.XValues = ExcelSheets.get_Range("B" + iDongBD.ToString(), (iTongDong > 61 ? "B61" : "B" + iTongDong.ToString()));
                }

                #region prb
                //prbIN.PerformLayout();
                //prbIN.Refresh();
                #endregion

                xlChart1.HasTitle = false;
                xlChart1.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                xlChart1.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255));
                xlChart1.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart1.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart1.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart1.ChartType = Excel.XlChartType.xlPie;
                xlChart1.Refresh();
            }
            catch
            { }
        }




        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate == "VECO")
            {
                if ((dtDNgay.DateTime.Date - dtTNgay.DateTime.Date).Days > 31)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCTHThoiGianNgungMay", "MsgNhoHonMotThang", Commons.Modules.TypeLanguage));
                    return;
                }
            }
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            t.Start(true);

            // ShowProcessBar/(true);
        }

        Thread t = null;
        private delegate void CallProcessBar(object flag);

        private void ShowProcessBar(object flag)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), true);
            }
            else
            {
                //prbIN.Visible = flag;
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                }));
                EnableControl(false);
                if (Commons.Modules.sPrivate == "VECO")
                {
                    t = new Thread(new ThreadStart(InVeCo));
                    t.Start();
                }
                else
                {
                    t = new Thread(new ThreadStart(InExcel));
                    t.Start();
                }
            }
        }

        private void InVeCo()
        {

            Excel.Application xlApp1 = new Excel.Application();
            Excel.Workbooks excelWorkbooks = xlApp1.Workbooks;
            Excel.Workbook xlWorkBook = null;
            //đem theo app.conf

            DataTable dtNhaXuongIn = new DataTable();
            dtNhaXuongIn.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_N_XUONG, INVECO, [TARGET] FROM NHA_XUONG WHERE INVECO IS NOT NULL ORDER BY INVECO"));
            string WinsorGroup = "-1";

            WinsorGroup = string.Join(",", dtNhaXuongIn.Select().AsEnumerable().Where(x => x["INVECO"].ToString() == "7").Select(p => p["MS_N_XUONG"].ToString()).ToArray());

            string sSql = "SELECT CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_N_XUONG WHEN 1 THEN TEN_N_XUONG_A ELSE TEN_N_XUONG_H END AS TEN_N_XUONG, MS_N_XUONG FROM NHA_XUONG ";
            DataTable dtNhaXuong = new DataTable();
            dtNhaXuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

            try
            {
                int num = 0;
                foreach (DataRow dr in dtNhaXuongIn.Rows)
                {
                    try
                    {
                        double target = 13.2;
                        try
                        {
                            target = Convert.ToDouble(dr["TARGET"].ToString());
                        }
                        catch { }
                        if (dr["INVECO"].ToString() == "7")
                        {
                            if (WinsorGroup != "-1")
                            {

                                InNNNgungMay(xlApp1, excelWorkbooks, ref xlWorkBook, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, "-1", optLoaiNN.SelectedIndex, WinsorGroup, "Production", cboDChuyen.EditValue, cboDChuyen.TextValue, cboLMay.EditValue, cboLMay.Text, sPath, 0, target, num);
                                num++;
                                WinsorGroup = "-1"; // id = 7 là in group nên gài k in nữa
                            }
                            else continue;
                        }
                        else
                        {
                            string tenNXuong = "";
                            
                            try
                            {
                                tenNXuong = dtNhaXuong.Select().AsEnumerable().SingleOrDefault(x => x["MS_N_XUONG"].ToString() == dr["MS_N_XUONG"].ToString())["TEN_N_XUONG"].ToString();
                               
                            }
                            catch { }
                            InNNNgungMay(xlApp1, excelWorkbooks, ref xlWorkBook, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, "-1", optLoaiNN.SelectedIndex, dr["MS_N_XUONG"].ToString(), tenNXuong, cboDChuyen.EditValue, cboDChuyen.TextValue, cboLMay.EditValue, cboLMay.Text, sPath, 0, target, num);
                            num++;
                        }
                    }
                    catch  { }
                }
                Excel.Worksheet xlSheet3 = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlSheet3.Activate();
                xlApp1.Visible = true;
                xlApp1.WindowState = Excel.XlWindowState.xlMaximized;
                xlWorkBook.Save();



                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbooks);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp1);
                BeginInvoke((Action)(() =>
                {
                    // prbIN.Visible = false;
                    prbIN.Properties.Stopped = true;
                }));

            }
            catch
            {
                xlApp1.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbooks);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp1);
                BeginInvoke((Action)(() =>
                {
                    // prbIN.Visible = false;
                    prbIN.Properties.Stopped = true;
                }));
            }
            sPath = "";


            BeginInvoke((Action)(() =>
            {
                EnableControl(true);
            }));
            Cursor = Cursors.Default;
            t.Abort();

        }
        private void EnableControl(bool flag)
        {
            btnExecute.Enabled = flag;
            btnThoat.Enabled = flag;
            optBCao.Enabled = flag;
            cboChart.Enabled = flag;
            cboDChuyen.Enabled = flag;
            cboDDiem.Enabled = flag;
            cboLMay.Enabled = flag;
            cboMay.Enabled = flag;
            cboChr.Enabled = flag;
            optLoaiNN.Enabled = flag;
            dtDNgay.Enabled = flag;
            dtTNgay.Enabled = flag;
            txtTop.Enabled = flag;
        }

        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
    }

}