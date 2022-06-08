using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using Spire.Xls;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace ReportMain
{
    public partial class ucKeHoachBaoTriNam : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachBaoTriNam()
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

            DataTable dtTmp = new DataTable();
            dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyen(0);

            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtTmp.Columns.Add(newColumn);
            newColumn.DefaultValue = false;
            newColumn.SetOrdinal(0);


            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, "ucKeHoachBaoTriNam");


            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }



            grvBC.Columns["CHON"].Width = 250;
            grvBC.Columns["TEN_HE_THONG"].Width = grdBC.Width - 500;
            grvBC.Columns["MS_HE_THONG"].Visible = false;

        }



        #endregion

        private void ucKeHoachBaoTriNam_Load(object sender, EventArgs e)
        {
            datTThang.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            LoadDChuyen();
            LoadNX();

        }


        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (datTThang.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam", "KhongCoNam", Commons.Modules.TypeLanguage));
                    datTThang.Focus();
                    return;
                }

                if (cboDDiem.TextValue == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                    cboDDiem.Focus();
                    return;
                }


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
                        Commons.Modules.ModuleName, "ucKeHoachBaoTriNam", "ChuaChonDayChuyen", Commons.Modules.TypeLanguage));
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                string sSql = "KHBT_NAM" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sSql, dtTmp, "");

                DateTime TNgay, DNgay;
                TNgay = Convert.ToDateTime("01/01/" + datTThang.DateTime.Year);
                DNgay = TNgay.AddYears(1).AddDays(-1);
                dtTmp = new DataTable();


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHBaoTriThietBiNam", TNgay, DNgay,
                    cboDDiem.EditValue, sSql, Commons.Modules.UserName, Commons.Modules.TypeLanguage, optBCao.SelectedIndex));


                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);


                if (optBCao.SelectedIndex == 0)
                    TaoDuLieuCT();
                else
                    TaoDuLieuTH();
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }
            this.Cursor = Cursors.Default;

        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKiem.Text.Length != 0) dk = " TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' " + dk;
                    dtTmp.DefaultView.RowFilter = dk;

                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
            }
            catch { }

        }

        private void TaoDuLieuCT()
        {
            try
            {
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                    "MS_MAY", Commons.Modules.TypeLanguage) + " ";
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "TEN_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["SERIAL_NUMBER"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "SERIAL_NUMBER", Commons.Modules.TypeLanguage);
                grvChung.Columns["Ten_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "Ten_N_XUONG", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_NHOM_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "TEN_NHOM_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_HE_THONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "TEN_HE_THONG", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "CHU_KY_TG", Commons.Modules.TypeLanguage);
                if (Commons.Modules.sPrivate == "ADC")
                {
                    InDuLieuADC();
                }
                else
                {
                    InDuLieu();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InDuLieuCT()
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                //prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "TieuDeBTN", Commons.Modules.TypeLanguage), 2, 4, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "Nam", Commons.Modules.TypeLanguage) + " : " + datTThang.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong++;
                Dong++;
                xlApp.Visible = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 9, Dong + TDong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA3, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                //5.86	12.29	33.29	19.71	27.29	19.71	19	9.57	3.57

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5.86, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12.29, "@", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 29, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.57, "@", true, Dong + 2, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 9, TDong + Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 2, 9, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void TaoDuLieuTH()
        {
            try
            {
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_NHOM_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                    "TEN_NHOM_MAY", Commons.Modules.TypeLanguage) + " ";
                grvChung.Columns["SL_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "SL_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["THUC_HIEN_BOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "THUC_HIEN_BOI", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoTriNam",
                        "CHU_KY_TG", Commons.Modules.TypeLanguage);
                if (Commons.Modules.sPrivate == "ADC")
                {
                    InDuLieuADC();
                }
                else
                {
                    InDuLieu();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InDuLieu()
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
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                xlApp.Visible = true;

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "TieuDeBTNTH", Commons.Modules.TypeLanguage), 2, 4, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "Nam", Commons.Modules.TypeLanguage) + " : " + datTThang.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong++;
                Dong++;
                //xlApp.Visible = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 9, Dong + TDong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (optBCao.SelectedIndex == 0)
                {
                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA3, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5.86, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12.29, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 29, "@", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 6, TDong + Dong, 6);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 7, TDong + Dong, 7);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.57, "@", true, Dong + 2, 8, TDong + Dong, 8);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 9, TDong + Dong, TCot);
                }
                else
                {
                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5.86, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "##", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 6, TDong + Dong, TCot);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 2, 9, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;



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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        private void InDuLieuADC()
        {
            string sPath = "";
            //sPath = @"C:\Users\HUANNGUYEN\Desktop\ahihihi.xlsx";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXlsx(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                //xlApp.Visible = true;
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                //xlApp.Visible = false;

                xlApp.Cells.Font.Name = "Arial";
                xlApp.Cells.Font.Size = 8;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                if (optBCao.SelectedIndex == 0)
                {
                    Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 17.5, 90.5, 30.9, Application.StartupPath);
                }
                else
                {
                    Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 16.5, 110.5, 30.9, Application.StartupPath);

                }
                Dong = 2;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "TieuDeBTNTH", Commons.Modules.TypeLanguage), Dong, 3, "@", 14, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 2, TCot - 6);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                   "ucKeHoachBaoTriNam", "TMP1", Commons.Modules.TypeLanguage), Dong, TCot - 5, "@", 10, false,
                   Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, TCot);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "TMP2", Commons.Modules.TypeLanguage), Dong + 1, TCot - 5, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 1, TCot);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "TMP3", Commons.Modules.TypeLanguage), Dong + 2, TCot - 5, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 2, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + 2, 2);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 3, Dong + 2, TCot - 5);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot - 5, Dong + 2, TCot);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 3, Dong + 2, TCot - 6);
                title.MergeCells = true;



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "Nam", Commons.Modules.TypeLanguage) + " : " + datTThang.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);



                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong++;
                Dong++;
                //xlApp.Visible = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 9, Dong + TDong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (optBCao.SelectedIndex == 0)
                {
                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA3, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5.86, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12.29, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 29, "@", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19.71, "@", true, Dong + 2, 6, TDong + Dong, 6);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 7, TDong + Dong, 7);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9.57, "@", true, Dong + 2, 8, TDong + Dong, 8);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 9, TDong + Dong, TCot);
                }
                else
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 2, TDong + 9, 2);
                    title.WrapText = true;
                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5.86, "##", true, Dong + 2, 1, TDong + Dong, 1);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16.29, "@", true, Dong + 2, 2, TDong + Dong, 2);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "##", true, Dong + 2, 3, TDong + Dong, 3);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 4, TDong + Dong, 4);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 2, 5, TDong + Dong, 5);
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 6, TDong + Dong, TCot);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 2, 9, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkBook.Save();
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);



                //Them image pagefooter
                //----------------------------------------------------
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(sPath);
                Worksheet sheet = workbook.Worksheets[0];

                Image image = Image.FromFile(@"reports\images\nam excel.png");
                image = resizeImage(image, 55, 1400);

                sheet.PageSetup.CenterFooterImage = image;
                sheet.PageSetup.CenterFooter = "&G";
                sheet.PageSetup.BottomMargin = 1.1;
                workbook.SaveToFile(sPath, ExcelVersion.Version2007);
                //----------------------------------------------------
                //Convert xlsx to xls
                xlApp = new Excel.Application();
                xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                string path = sPath.Split(new string[] { ".xlsx" }, StringSplitOptions.None)[0] + ".xls";

                xlWorkBook.WebOptions.Encoding = Office.MsoEncoding.msoEncodingUTF8;
                xlWorkBook.SaveAs(path, FileFormat: Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close(false, Type.Missing, Type.Missing);

                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                Process.Start(path);
                System.IO.File.Delete(sPath);
                //----------------------------------------------------



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoTriNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

    }
}
