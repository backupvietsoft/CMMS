using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Linq;

namespace ReportHuda.Colgate
{
    public partial class ucDuTruChiPhiVTDinhKy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDuTruChiPhiVTDinhKy()
        {
            InitializeComponent();
        }
        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private void LoadNX()
        {
            try
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadCboTreeList(ref cmbNhaXuong, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            LoadDChuyen();
        }
        private void LoadCatMachine()
        {


            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                     if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cmbNhaXuong.EditValue.ToString() != "-1") sNX = cmbNhaXuong.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHTCoAll",
                    sNX, iHThong, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCatmachine, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnThoat", Commons.Modules.TypeLanguage);
            lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuTruChiPhiVTDinhKy", "lblTuan", Commons.Modules.TypeLanguage);
        }

        private void GetData()
        {
            int day = DateTime.DaysInMonth(cmbYear.DateTime.Year, cmbYear.DateTime.Month);
            DataSet set = new DataSet();
            //"01-01-" + cmbYear.Text , "12-31-" + cmbYear.Text
            DateTime dTNgay, dDNgay, Ngay;

            if (optInTheoThangNam.SelectedIndex == 1)
            {
                Ngay = Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(1).AddDays(-1);

            }
            else if (optInTheoThangNam.SelectedIndex == 2)
            {
                Ngay = Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(11).AddDays(30);
            }
            else
            {
                //tuần - chưa làm
                Ngay = Convert.ToDateTime(cboTuan.Text.Split(' ')[2].Split('_')[0]);
                dTNgay = Ngay;
                dDNgay = Ngay.AddDays(6);
            }
            set  = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "spGetBCDuTruChiPhiDinhKyVTPT", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                                        dTNgay.Date, dDNgay.Date, cmbNhaXuong.EditValue, cboDChuyen.EditValue, cmbCatmachine.EditValue);
            if (set.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuTruChiPhiVTDinhKy", "Khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, set.Tables[1], false, true, true, true, true, this.Name);

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdTmp, grvTmp, set.Tables[0], false, true, true, true, true, this.Name);

            InDuLieu();


        }


        private void InDuLieu()
        {
            DataTable dtTmp = new DataTable();
            DataTable dtCT = new DataTable();
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                int TCot = 10;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                dtTmp = (DataTable)grdChung.DataSource;
                dtCT = (DataTable)grdTmp.DataSource;
                int TDong2 = grvTmp.RowCount;
                int TCot2 = grvTmp.Columns.Count;


                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 35 + dtTmp.Rows.Count;
                prbIN.Properties.Minimum = 0;

                grvChung.ExportToXlsx(sPath);
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "Báo cáo tổng quát";

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1,2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "bcDuTruChiPhiVTBaoTriDinhKy", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong = Dong + 2;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "#,##0", true, Dong + 1, 2, TDong + Dong, 2);

              



                Excel.Range title;
                #region Char 2

                Excel.ChartObjects chartObjs = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(250 , 100, 350, 300);
                Excel.Chart xlChart1 = chartObj.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet,Dong + 1, 1, Dong + TDong, 2);
                xlChart1.SetSourceData(title, Type.Missing);
                xlChart1.ChartType = Excel.XlChartType.xlPie;
                xlChart1.HasTitle = true;
                xlChart1.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "bcTiLeChiPhiVatTuBTDKTheoDiaDiem", Commons.Modules.TypeLanguage);
                xlChart1.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart1.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);
                #endregion


                Dong = TDong + Dong + 1;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, "Tổng :", Dong, 1, "", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, dtTmp.AsEnumerable().Sum(x => x.Field<double>(1)).ToString(), Dong, 2, "#,##0", 10, true,
                Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                //inshet 2
                xlWorkBook.Sheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value);
                Excel.Worksheet xlWSheet2 = (Excel.Worksheet)xlWorkBook.Sheets[2];
                xlWSheet2.Name = "Báo cáo chi tiết";
                xlWorkSheet.Activate();

                Dong = 1;

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, Dong, 1,TDong2,TCot2);
                Commons.Modules.MExcel.MExportExcel(dtCT, xlWSheet2,title,true,this.Name);
                title.Borders.LineStyle = 1;


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, Dong, 1,1, TCot2);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;



                Dong++;

                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 18, "@", true, Dong, 1, TDong2, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 18, "@", true, Dong, 2, TDong2, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 25, "@", true, Dong, 3, TDong2, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 13, "dd/MM/yyyy", true, Dong, 4, TDong2, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 13, "dd/MM/yyyy", true, Dong, 5, TDong2, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 18, "@", true, Dong, 6, TDong2, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 10, "0", true, Dong, 8, TDong2, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet2, 15, "#,##0", true, Dong, 9, TDong2, 10);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }    


        private void btnExcute_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private string convertDateTime(string dateofweek)
        {
            switch (dateofweek.Substring(0, 3).ToLower())
            {
                case "mon":
                    return "H";
                case "tue":
                    return "B";
                case "wed":
                    return "T";
                case "thu":
                    return "N";
                case "fri":
                    return "S";
                case "sat":
                    return "B";
                case "sun":
                    return "CN";
            }
            return "";
        }

        private void ucDuTruChiPhiVTDinhKy_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadNX();
            LoadTuan();
            Commons.Modules.SQLString = "";
            LoadCatMachine();
            optInTheoThangNam_SelectedIndexChanged(null, null);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;
            LoadCatMachine();
            Commons.Modules.SQLString = "";
        }

        private void optInTheoThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optInTheoThangNam.SelectedIndex == 0) //Tuần
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 0);
                tableLayoutPanel1.SetRow(cboTuan, 2);
                tableLayoutPanel1.SetColumn(cboTuan, 2);
                cmbYear.Visible = false;
                cboTuan.Visible = true;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuTruChiPhiVTDinhKy", "lblTuan", Commons.Modules.TypeLanguage);

            }
            else if (optInTheoThangNam.SelectedIndex == 1) //Tháng
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cboTuan, 3);
                tableLayoutPanel1.SetColumn(cboTuan, 0);
                cmbYear.Visible = true;
                cboTuan.Visible = false;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuTruChiPhiVTDinhKy", "lblNgay", Commons.Modules.TypeLanguage);

                cmbYear.Properties.DisplayFormat.FormatString = "MM/yyyy";
                cmbYear.Properties.EditMask = "MM/yyyy";
                cmbYear.Properties.EditFormat.FormatString = "MM/yyyy";
                cmbYear.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                cmbYear.MMonthYear = true;
            }
            else
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cboTuan, 3);
                tableLayoutPanel1.SetColumn(cboTuan, 0);
                cmbYear.Visible = true;
                cboTuan.Visible = false;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuTruChiPhiVTDinhKy", "lblNam", Commons.Modules.TypeLanguage);

                cmbYear.Properties.DisplayFormat.FormatString = "yyyy";
                cmbYear.Properties.EditMask = "yyyy";
                cmbYear.Properties.EditFormat.FormatString = "yyyy";
                cmbYear.DateTime = DateTime.Now;
                cmbYear.MMonthYear = false;
            }
        }

        public void LoadTuan()
        {
            DataTable tb = new DataTable();
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTUAN_TRONG_NAM", "01/01/" + DateTime.Now.Year.ToString(), "31/12/" + DateTime.Now.Year.ToString(), Commons.Modules.TypeLanguage).Tables[0];
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTuan, tb, "TUAN", "TEN_TUAN", "");
            try
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                cboTuan.EditValue = weekNum;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
    }
}
