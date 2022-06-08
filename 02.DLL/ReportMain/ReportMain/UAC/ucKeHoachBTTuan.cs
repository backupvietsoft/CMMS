using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;

namespace ReportMain
{
    public partial class ucKeHoachBTTuan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachBTTuan()
        {
            InitializeComponent();
        }

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
        
        private void LoadBaoTri()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_LOAI_BT, TEN_LOAI_BT FROM LOAI_BAO_TRI UNION SELECT -1,' < ALL > ' ORDER BY TEN_LOAI_BT "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblBaoTri.Text);
            }
            catch { }
        }

        #endregion

        #region Change du lieu
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

        #endregion

        private void ucKeHoachBTTuan_Load(object sender, EventArgs e)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            datTNgay.DateTime = GetFirstDayOfWeek(DateTime.Now, defaultCultureInfo);
            datDNgay.DateTime = datTNgay.DateTime.AddDays(6);

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadBaoTri();

            try
            {
                for (int i = 0; i < chkTTBaotri.Items.Count ; i++)
                {
                    chkTTBaotri.Items[i].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBTTuan", chkTTBaotri.Items[i].Description, Commons.Modules.TypeLanguage);
                }
            }
            catch { }

            
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "KhongCoTuThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "KhongCoDenThang", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return;
            }



            if (!chkTTBaotri.GetItemChecked(0) && !chkTTBaotri.GetItemChecked(1) && !chkTTBaotri.GetItemChecked(2) &&
                !chkTTBaotri.GetItemChecked(3) && !chkTTBaotri.GetItemChecked(4))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "ChuaChonTinhTrangPBT", Commons.Modules.TypeLanguage));
                chkTTBaotri.Focus();
                return;
            }

            DateTime TNgay, DNgay;
            TNgay = Convert.ToDateTime(datTNgay.DateTime);
            DNgay = Convert.ToDateTime(datDNgay.DateTime);
            if (TNgay == DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "TuThangBangDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return ;
            }
            if (TNgay > DNgay)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return ;
            }
            TimeSpan Time = DNgay - TNgay;
            int TongSoNgay = Time.Days;
             
            if (TongSoNgay > 32)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "LonHon31Ngay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            string sSql = "";
            for (DateTime Ngay = TNgay; Ngay <= DNgay; )
            {
                sSql = sSql + " , [" + Ngay.ToString("dd/MM/yyyy") + "] ";
                Ngay = Ngay.AddDays(1);
            }

            DataTable dtTmp = new DataTable();
            string sBTam = "KHPBT" + Commons.Modules.UserName;
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKeHoachTuanPBT", TNgay, DNgay,
                    cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, Commons.Modules.TypeLanguage, Commons.Modules.UserName,
                    chkTTBaotri.GetItemChecked(0) ? 1 : 0, chkTTBaotri.GetItemChecked(1) ? 1 : 0, chkTTBaotri.GetItemChecked(2) ? 1 : 0,
                    chkTTBaotri.GetItemChecked(3) ? 1 : 0, chkTTBaotri.GetItemChecked(4) ? 1 : 0,cboLBTri.EditValue));
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return;
                }

                Commons.Modules.ObjSystems.XoaTable(sBTam);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                sSql = " SELECT STT, MS_MAY, TEN_MAY, MS_PHIEU_BAO_TRI, TEN_LOAI_BT, TEN_BO_PHAN, CONG_VIEC, TEN_CN, " + sSql.Substring(3, sSql.Length - 3) +
                " FROM " +
                " (SELECT STT, MS_MAY, TEN_MAY, MS_PHIEU_BAO_TRI, TEN_LOAI_BT, TEN_BO_PHAN, CONG_VIEC, TEN_CN, NGAY_HT, THOI_GIAN_DU_KIEN FROM " + sBTam + ") p " +
                " PIVOT  " +
                " (SUM (THOI_GIAN_DU_KIEN) FOR NGAY_HT IN ( " + sSql.Substring(3, sSql.Length - 3) +
                " )) AS pvt  ORDER BY MS_PHIEU_BAO_TRI,MS_MAY, TEN_MAY";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.XoaTable(sBTam);

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBTTuan", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    datTNgay.Focus();
                    return;
                }
            }
            catch { }

            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);

            for (int i = 0; i <= 7; i++)
            {
                grvChung.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBTTuan", grvChung.Columns[i].FieldName, Commons.Modules.TypeLanguage);
            }

            InDuLieu(TongSoNgay);
            Commons.Modules.ObjSystems.XoaTable(sBTam);
        }

        private void InDuLieu( int SoNgay)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9 + SoNgay;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");




                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                 
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBTTuan", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong++;

                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue ;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = lblBaoTri.Text + " : " + cboLBTri.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                Dong++;
                stmp = lblTTBaoTri.Text + " : " +
                    (chkTTBaotri.GetItemChecked(0) ? chkTTBaotri.Items[0].Description.ToString() + "; " : "").ToString() +
                    (chkTTBaotri.GetItemChecked(1) ? chkTTBaotri.Items[1].Description.ToString() + "; " : "").ToString() +
                    (chkTTBaotri.GetItemChecked(2) ? chkTTBaotri.Items[2].Description.ToString() + "; " : "").ToString() +
                    (chkTTBaotri.GetItemChecked(3) ? chkTTBaotri.Items[3].Description.ToString() + "; " : "").ToString() +
                    (chkTTBaotri.GetItemChecked(4) ? chkTTBaotri.Items[4].Description.ToString() + "; " : "").ToString();


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Excel.Range title;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong-1, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 2, 1, Dong - 2, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 8, TDong + Dong, 8);


                //xlApp.Visible = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 9, Dong + TDong, TCot);
                Excel.FormatCondition condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue , Excel.XlFormatConditionOperator.xlNotEqual, "=\"\"", Type.Missing));
                condition.Interior.Color = 65535;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DateTime TNgay, DNgay;

                TNgay = Convert.ToDateTime(datTNgay.DateTime);
                DNgay = Convert.ToDateTime(datDNgay.DateTime);
                int i = 1;
                i = 9;
                //=TEXT(I11,"ddd")
                xlApp.DisplayAlerts = false;

                for (DateTime Ngay = TNgay; Ngay <= DNgay; )
                {
                    //xlWorkSheet.Cells[Dong - 1, i] = "=TEXT(" + Commons.Modules.MExcel.TimDiemExcel(Dong, i) + ",\"ddd\")";
                    //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "General", true, Dong - 1, i, Dong-1, i);
                    //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "[$-409]d-mmm;@", true, Dong, i, Dong, i);
                    stmp = Ngay.ToString("dd-MMM");
                    //Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong-1, i);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong - 1, i, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong - 1, i);
                    stmp = Ngay.ToString("ddd");
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong , i, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong , i);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "@", true, Dong - 1, i, Dong - 1, i);

                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong + TDong + 1, i, Dong + TDong + 1, i, Dong +1,
                            i, Dong + TDong, i, 10, true, 10, "#,##0.00", Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                    Ngay = Ngay.AddDays(1);

                    if (i - 8 < 9)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, i - 8, Dong, i - 8);
                        title.MergeCells = true;
                    }
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                    i++;
                }



                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBTTuan", "TongCong", Commons.Modules.TypeLanguage), Dong + TDong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 1, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "@", true, Dong - 1, 9, Dong - 1, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong + TDong + 1, TCot);
                title.Borders.LineStyle = 1;

                xlApp.Visible = true;
                xlWorkBook.Save();

                xlApp.DisplayAlerts = false;
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
                    "ucKeHoachBTTuan", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào 
        /// với Culture mặc định là Culture hiện tại
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tuần</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }
        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào
        /// với một Culture cụ thể được truyền vào
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <param name="cultureInfo">CultureInfo quy định các thông tin về Culture 
        /// ( định dạng ngày tháng, ngày bắt đầu trong tuần , ... )
        /// </param>
        /// <returns></returns>
        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }
        /// <summary>
        /// Lấy ra ngày đầu tiên trong tuần của ngày nhập vào
        /// với 1 giá trị cụ thể của enum DayOfWeek chỉ định 
        /// ngày bắt đầu tuần là thứ mấy
        /// </summary>
        /// <param name="dayInWeek">Ngày nhập vào</param>
        /// <param name="dayOfWeek">enum chỉ định thứ bắt đầu tuần</param>
        /// <returns></returns>
        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek dayOfWeek)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != dayOfWeek)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }
    }
}
