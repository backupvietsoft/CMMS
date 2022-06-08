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

namespace ReportHuda
{
    public partial class frmPhanTichNNNMTheoNN : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanTichNNNMTheoNN()
        {
            InitializeComponent();
        }

        public class ContactList : System.Collections.CollectionBase
        {
            public Contact this[int index]
            {
                get { return (Contact)(List[index]); }
                set { List[index] = value; }
            }

            public int Add(Contact value)
            {
                return List.Add(value);
            }
            //...
        }


        public class Contact
        {
            private string name;
            public Contact(string _name)
            {
                name = _name;
            }
            
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            //...
        }

        private Boolean KgLoad = true;
        private DataTable dtData;

        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1"),"MS_N_XUONG", "TEN_N_XUONG", "");
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", "");
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
                    if (cboDDiem.Text == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }
                try
                { if (cboDChuyen.Text == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }
                //if (optBCao.SelectedIndex == 1)
                //{
                //    HThong = -1;
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 2)
                //{
                //    HThong = -1;
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 3)
                //{

                //    LMay = "-1";
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 4)
                //{
                //    MsMay = "-1";
                //}
                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayUserAll",1, Commons.Modules.UserName, NXuong, HThong, -1, LMay, "-1", MsMay,
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
            try
            {
                dtTNgay.DateTime = DateTime.Now.AddYears(-1);
                dtDNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year).AddMonths(1).AddDays(-1);
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

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
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

        private void LoadDL ()
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
                    if (cboDDiem.Text == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }
                try
                { if (cboDChuyen.Text == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }
                try
                { if (cboMay.Text == "") MsMay = "-1"; else MsMay = cboMay.EditValue.ToString(); }
                catch { MsMay = "-1"; }



                //if (optBCao.SelectedIndex == 1)
                //{
                //    HThong = -1;
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 2)
                //{
                //    HThong = -1;
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 3)
                //{

                //    LMay = "-1";
                //    MsMay = "-1";
                //}
                //if (optBCao.SelectedIndex == 4)
                //{
                //    MsMay = "-1";
                //}

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
                    dr[2] = grvChung.GetRowCellValue(i, grvChung.Columns[2]);
                    dr[3] = grvChung.GetRowCellValue(i, grvChung.Columns[3]);

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
                if (cboChr.Text.ToUpper() == "Bar".ToUpper()) series = new Series("Series1", ViewType.Bar );
                if (cboChr.Text.ToUpper() == "Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.StackedBar);
                if (cboChr.Text.ToUpper() == "Full-Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.FullStackedBar);
                if (cboChr.Text.ToUpper() == "3D Bar".ToUpper()) series = new Series("Series1", ViewType.Bar3D);
                if (cboChr.Text.ToUpper() == "3D Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.StackedBar3D);
                if (cboChr.Text.ToUpper() == "3D Full-Stacked Bar".ToUpper()) series = new Series("Series1", ViewType.FullStackedBar3D);
                if (cboChr.Text.ToUpper() == "3D Manhattan Bar".ToUpper()) series = new Series("Series1", ViewType.ManhattanBar);
                


                Series series1 = new Series("Series1", ViewType.Pie);

                if (cboChart.Text.ToUpper() == "Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie);
                if (cboChart.Text.ToUpper() == "Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut);
                if (cboChart.Text.ToUpper() == "3D Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie3D);
                if (cboChart.Text.ToUpper() == "3D Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut3D);


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
                if (optLoaiNN.SelectedIndex == 0)
                    series.ValueDataMembers.AddRange(new string[] { "TG_NGUNG" });
                else
                    series.ValueDataMembers.AddRange(new string[] { "TG_SUA" });
                chartCot.Series.Add(series);
                chartCot.Legend.Visible = false;

                series1.ValueScaleType = ScaleType.Numerical;
                if (optLoaiNN.SelectedIndex == 0)
                    series1.ValueDataMembers.AddRange(new string[] { "TG_NGUNG" });
                else
                    series1.ValueDataMembers.AddRange(new string[] { "TG_SUA" });
                series1.DataSource = dtTmp;
                chartTron.Series.Add(series1);


                PiePointOptions pointOpts = (PiePointOptions)chartTron.Series[0].PointOptions;
                pointOpts.PercentOptions.ValueAsPercent = false;
                DevExpress.XtraCharts.PiePointOptions p = new DevExpress.XtraCharts.PiePointOptions();
                p.PercentOptions.ValueAsPercent = false;
                p.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                p.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                p.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                series1.PointOptions.PointView = p.PointView;
                chartTron.Legend.Visible = false;

            }
            catch { }

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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;

            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 12;
                //+ grvChung.RowCount;
            prbIN.Properties.Minimum = 0;

            DataTable dtTmp = dtData.Clone(); // if needed
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

                if(optLoaiNN.SelectedIndex == 0)
                    dr[2] = grvChung.GetRowCellValue(i, grvChung.Columns[2]);
                else
                    dr[2] = grvChung.GetRowCellValue(i, grvChung.Columns[3]);
                dtTmp.Rows.Add(dr);
            }
            dtTmp.Columns.RemoveAt(dtTmp.Columns.Count - 1);
            dtTmp.AcceptChanges();

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTmp, false, true, false, true);

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
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
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;


                xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, grvChung.RowCount + 1, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);

                int TCot = dtTmp.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot+5);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);

                //xlApp.Visible = true;
                if (optBCao.SelectedIndex == 0)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2 || optBCao.SelectedIndex == 3)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);
                if (optBCao.SelectedIndex == 4)
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, lblTitle.Text, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string sTmp = "";
                sTmp = lblFromDate.Text + " : " + dtTNgay.DateTime.Date.ToShortDateString() + " " + lblToDate.Text + " : " + dtDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                sTmp = lblDiaDiem.Text + " : " + cboDDiem.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot );
                if (optBCao.SelectedIndex == 0)
                {
                    Dong++;
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
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
                prbIN.PerformStep();
                prbIN.Update();
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
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                } 
                if (optBCao.SelectedIndex == 4)
                {
                    Dong++;
                    sTmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                    Dong++;
                    sTmp = lblLoaiMay.Text + " : " + cboLMay.Text;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, sTmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                }
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[0].Caption, Dong, 1, "@", 10, true, true, Dong,1);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[1].Caption, Dong, 2, "@", 10, true, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, grvChung.Columns[2].Caption, Dong, 3, "@", 10, true, true, Dong, 3);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
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
                prbIN.PerformStep();
                prbIN.Update();
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
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                int iDongBD = 14;
                if (optBCao.SelectedIndex == 0)
                    iDongBD = 14;
                if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2 || optBCao.SelectedIndex == 3)
                    iDongBD = 12;
                if (optBCao.SelectedIndex == 4)
                    iDongBD = 13;

                int iTongDong = iDongBD + int.Parse(txtTop.Text.ToString()) -1; 
                if (grvChung.RowCount + iDongBD <= iTongDong) iTongDong = iDongBD + grvChung.RowCount -1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 4, 5, 4);
                LoadBieuDo(xlWorkSheet, iDongBD, iTongDong, Convert.ToDouble(title.Left) + 15, Convert.ToDouble(title.Top), 386.92, 235.55);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
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
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }


        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int iDongBD, int iTongDong, double iLeft, double iTop, double iWidth, double iHeight)
        {
            try
            {
                #region prb
                prbIN.PerformStep(); prbIN.Update();
                #endregion
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);                
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked;

                Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                #region prb
                prbIN.PerformStep(); prbIN.Update();
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
                prbIN.PerformStep();
                prbIN.Update();
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
                prbIN.PerformStep(); prbIN.Update();
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
                prbIN.PerformStep();
                prbIN.Update();
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


    }
    
}