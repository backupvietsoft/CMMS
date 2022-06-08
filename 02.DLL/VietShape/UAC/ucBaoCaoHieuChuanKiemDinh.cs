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

namespace VietShape
{
    public partial class ucBaoCaoHieuChuanKiemDinh : DevExpress.XtraEditors.XtraUserControl
    {

        private string currentMonth = DateTime.Now.Month.ToString() + ".1";
        public ucBaoCaoHieuChuanKiemDinh()
        {
            InitializeComponent();
            optBCao.SelectedIndex = 0;
        }
        private void ucBaoCaoHieuChuanKiemDinh_Load(object sender, EventArgs e)
        {
            try
            {
                datTNam.DateTime = DateTime.Now;
                LoadNX();
                LoadDChuyen();
                LoadLoaiMay();
                //LoadMay();
                lblLMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblLMay", Commons.Modules.TypeLanguage);
                lblDChuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblDChuyen", Commons.Modules.TypeLanguage);
                lblDDiem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblDDiem", Commons.Modules.TypeLanguage);
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblNam", Commons.Modules.TypeLanguage);
                lblLoaiBCao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblLoaiBCao", Commons.Modules.TypeLanguage);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        DataTable dtMay = new DataTable();

        private void datTNam_EditValueChanged(object sender, EventArgs e)
        {
            //LoadMay();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = new DataTable();
                try
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoHieuChuanKiemDinhTheoKeHoach", datTNam.Text, Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, -1/*bpcp*/, cboLMay.EditValue, "-1"/*nhomay*/, optBCao.SelectedIndex, Commons.Modules.TypeLanguage));
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                //neu nam bang nam cua hien tai thi them cot thang hien tai vao
                if (DateTime.Now.Year == datTNam.DateTime.Year)
                {
                    System.Data.DataColumn newColumn = new System.Data.DataColumn(currentMonth, typeof(string));
                    newColumn.DefaultValue = "";
                    dtTmp.Columns.Add(newColumn);
                    foreach (DataColumn col in dtTmp.Columns)
                    {
                        if (col.ColumnName.Equals(DateTime.Now.Month.ToString()))
                        {
                            newColumn.SetOrdinal(col.Ordinal + 1);
                            break;
                        }
                    }
                    dtTmp.Columns[currentMonth].ReadOnly = false;
                }
                foreach (DataRow dr in dtTmp.Rows)
                {
                    int month = Convert.ToDateTime(dr["NGAY_HC_CUOI"].ToString(), new CultureInfo("vi-vn")).Month;
                    int monthtmp1 = Convert.ToInt32(dr["CHU_KY_TINH"].ToString()) + month;
                    while (monthtmp1 <= DateTime.Now.Month && Convert.ToInt32(dr["CHU_KY_TINH"].ToString()) != 0)
                    {
                        try
                        {
                            if (monthtmp1 == DateTime.Now.Month)
                            {
                                updateNgayHCCuoiToDataTable(ref dtTmp, dr, currentMonth, Convert.ToInt32(dr[DateTime.Now.Month.ToString()].ToString().Split(' ')[0].ToString()));
                                if (DateTime.Now.Year == datTNam.DateTime.Year)
                                {
                                    updateNgayHCCuoiToDataTable(ref dtTmp, dr, DateTime.Now.Month.ToString(), 0);
                                }
                                break;
                            }
                            monthtmp1 += Convert.ToInt32(dr["CHU_KY_TINH"].ToString());
                        }
                        catch
                        { monthtmp1 += Convert.ToInt32(dr["CHU_KY_TINH"].ToString()); }
                    }
                    updateNgayHCCuoiToDataTable(ref dtTmp, dr, month.ToString(), 1);
                    if (Convert.ToInt32(datTNam.Text) <= DateTime.Now.Year)
                    {

                        int monthTMP = month;
                        while (monthTMP > 0 && Convert.ToInt32(dr["CHU_KY_TINH"].ToString()) != 0)
                        {
                            try
                            {
                                DataTable dt = new DataTable();
                                if (string.IsNullOrEmpty(dr["DUNG_CU_DO"].ToString()))
                                {
                                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDemSoNgayHC", datTNam.Text, dr["MS_MAY"].ToString(), dr["DUNG_CU_DO"].ToString(), dr["VI_TRI"].ToString(), monthTMP, Convert.ToInt32(dr["MS_LOAI_HIEU_CHUAN"].ToString()), false));
                                }
                                else
                                {
                                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDemSoNgayHC", datTNam.Text, dr["MS_MAY"].ToString(), dr["DUNG_CU_DO"].ToString(), dr["VI_TRI"].ToString(), monthTMP, Convert.ToInt32(dr["MS_LOAI_HIEU_CHUAN"].ToString()), true));
                                }
                                foreach (DataRow dr1 in dt.Rows)
                                {
                                    //cập nhật về số âm để tô mầu
                                    updateNgayHCCuoiToDataTable(ref dtTmp, dr, dr1["THANG"].ToString(), - Convert.ToInt32(dr1["SO_LUONG"].ToString()));
                                }
                                monthTMP--;
                            }
                            catch (Exception ex)
                            { XtraMessageBox.Show(ex.ToString()); }
                        }
                    }
                }
                try
                {
                    grdChung.DataSource = null;
                    grvChung.Columns.Clear();
                }
                catch (Exception ex)
                { XtraMessageBox.Show(ex.ToString()); }
                dtTmp.Columns.Remove("CHU_KY_TINH");
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);
                grvChung.Columns["MS_DV_TG"].Visible = false;
                grvChung.Columns["MS_LOAI_HIEU_CHUAN"].Visible = false;
                grvChung.Columns["DUNG_CU_DO"].Visible = false;
                grvChung.Columns["MS_DV_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "MS_DV_TG", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "MS_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "TEN_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "DUNG_CU_DO", Commons.Modules.TypeLanguage);
                grvChung.Columns["VI_TRI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "VI_TRI", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_LOAI_HIEU_CHUAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "TEN_LOAI_HIEU_CHUAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "CHU_KY", Commons.Modules.TypeLanguage);
                grvChung.Columns["NGAY_HC_CUOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "NGAY_HC_CUOI", Commons.Modules.TypeLanguage);
                grvChung.Columns["MS_LOAI_HIEU_CHUAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "MS_LOAI_HIEU_CHUAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["1"].Caption = "1";
                grvChung.Columns["2"].Caption = "2";
                grvChung.Columns["3"].Caption = "3";
                grvChung.Columns["4"].Caption = "4";
                grvChung.Columns["5"].Caption = "5";
                grvChung.Columns["6"].Caption = "6";
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    grvChung.Columns[currentMonth].Caption = DateTime.Now.Month.ToString();
                }
                grvChung.Columns["7"].Caption = "7";
                grvChung.Columns["8"].Caption = "8";
                grvChung.Columns["9"].Caption = "9";
                grvChung.Columns["10"].Caption = "10";
                grvChung.Columns["11"].Caption = "11";
                grvChung.Columns["12"].Caption = "12";
                InDuLieu();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = true;
            Excel.Range title;

            int TCot = grvChung.Columns.Count + 1;
            int TDong = grvChung.RowCount;
            int Dong = 1;


            //prbIN.Visible = true;
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 21;
            prbIN.Properties.Minimum = 0;
            excelApplication.Visible = false;

            grdChung.ExportToXls(sPath);
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            try
            {

                excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;
                excelApplication.Cells.Font.Size = 10;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot - 3);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                TCot = TCot - 4;
                int SCot;
                SCot = TCot;

                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 2, Dong);

                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "bcTDBCHieuChuanKiemDinh", Commons.Modules.TypeLanguage) + " " + datTNam.Text
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                Dong++;


                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + 4, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, 1]).Interior.Color;
                title.RowHeight = 25;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);
                //excelApplication.Visible = true;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 7, 1, 11, 1);
                title.RowHeight = 12.75;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 1, TDong + Dong + 4, TCot);
                title.WrapText = true;

                for (int i = 1; i <= 8; i++)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, i], excelWorkSheet.Cells[Dong + 4, i]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.Font.Size = 10;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";

                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, 9], excelWorkSheet.Cells[Dong + 3, 9 + DateTime.Now.Month - 1]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcTT", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong + 3, 9, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9);
                    }
                    else
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcThucTe", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thực tế", Dong + 3, 9, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9);
                    }

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, 9 + DateTime.Now.Month], excelWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcKH", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(excelWorkSheet, "KH", Dong + 3, 9 + DateTime.Now.Month, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9 + DateTime.Now.Month);
                    }
                    else
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcKeHoach", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Kế hoạch", Dong + 3, 9 + DateTime.Now.Month, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9 + DateTime.Now.Month);
                    }

                }
                else if (DateTime.Now.Year > Convert.ToInt16(datTNam.Text))
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, 9], excelWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thực tế", Dong + 3, 9, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }
                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, 9], excelWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Kế hoạch", Dong + 3, 9, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 9);
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet,4, "@", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong, 3, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "@", true, Dong, 7, Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 8, Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", true, Dong, 9, Dong, 20);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 1, TDong + Dong + 4, TCot);
                title.WrapText = true;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Borders.LineStyle = 1;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 9 + DateTime.Now.Month, Dong + 3, 9 + DateTime.Now.Month);
                        title.WrapText = false;
                    }
                    if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 9, Dong + 3, 9);
                        title.WrapText = false;
                    }
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblDDiem.Text + ": " + cboDDiem.TextValue, 7, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 7, 3);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblDChuyen.Text + ": " + cboDChuyen.TextValue, 8, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 8, 3);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblLMay.Text + ": " + cboLMay.Text, 9, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 9, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int cot = 8;
                Dong = Dong + 5;
                Excel.FormatCondition condition;

                //Tô tháng hiện tại
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    //Tô tháng ở tương lai
                    if (DateTime.Now.Month != 12)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + DateTime.Now.Month + 1, TDong + Dong - 1, TCot);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                    }
                    else
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + DateTime.Now.Month + 1, TDong + Dong - 1, TCot);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                    }
                    //Tô tháng ở quá khứ
                    if (DateTime.Now.Month != 1)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                        Excel.FormatCondition condition1;
                        condition1 = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                        condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));

                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, cot + DateTime.Now.Month);

                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    }
                    else
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                        Excel.FormatCondition condition1;
                        condition1 = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                        condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));


                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, cot + 1);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));


                    }

                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeDaLam", Commons.Modules.TypeLanguage), 7, 10, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 7, 13);
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeChuaLam", Commons.Modules.TypeLanguage), 8, 10, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 8, 14);
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcKeHoach", Commons.Modules.TypeLanguage), 9, 10, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 9, 13);

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 7, 9, 7, 9);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8, 9, 8, 9);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 9, 9, 9);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                }
                else if (DateTime.Now.Year > Convert.ToInt16(datTNam.Text))
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                    condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    Excel.FormatCondition condition1;
                    condition1 = (Excel.FormatCondition)
                (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                    condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));



                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeDaLam", Commons.Modules.TypeLanguage), 8, 10, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 8, 13);
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeChuaLam", Commons.Modules.TypeLanguage), 9, 10, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 9, 14);
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8, 9, 8, 9);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 9, 9, 9);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                }
                else
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                    condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 12, 9, TDong + Dong - 1, TCot);
                title.NumberFormat = "0;0; ";

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 12, 4, TDong + Dong - 1, TCot);
                title.WrapText = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 10, 1, 10, 1);
                title.RowHeight = 9;
                excelApplication.Visible = true;
                excelWorkbook.Save();
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + ": " + ex.Message);
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void updateNgayHCCuoiToDataTable(ref DataTable dt, DataRow dr, string month, int value)
        {
            try
            {
                int index = dt.Rows.IndexOf(dr);
                switch (month)
                {
                    case "1":
                        dt.Columns["1"].ReadOnly = false;
                        dt.Rows[index]["1"] = value;
                        break;
                    case "2":
                        dt.Columns["2"].ReadOnly = false;
                        dt.Rows[index]["2"] = value;
                        break;
                    case "3":
                        dt.Columns["3"].ReadOnly = false;
                        dt.Rows[index]["3"] = value;
                        break;
                    case "4":
                        dt.Columns["4"].ReadOnly = false;
                        dt.Rows[index]["4"] = value;
                        break;
                    case "5":
                        dt.Columns["5"].ReadOnly = false;
                        dt.Rows[index]["5"] = value;
                        break;
                    case "6":
                        dt.Columns["6"].ReadOnly = false;
                        dt.Rows[index]["6"] = value;
                        break;
                    case "7":
                        dt.Columns["7"].ReadOnly = false;
                        dt.Rows[index]["7"] = value;
                        break;
                    case "8":
                        dt.Columns["8"].ReadOnly = false;
                        dt.Rows[index]["8"] = value;
                        break;
                    case "9":
                        dt.Columns["9"].ReadOnly = false;
                        dt.Rows[index]["9"] = value;
                        break;
                    case "10":
                        dt.Columns["10"].ReadOnly = false;
                        dt.Rows[index]["10"] = value;
                        break;
                    case "11":
                        dt.Columns["11"].ReadOnly = false;
                        dt.Rows[index]["11"] = value;
                        break;
                    case "12":
                        dt.Columns["12"].ReadOnly = false;
                        dt.Rows[index]["12"] = value;
                        break;
                    default:
                        dt.Columns[currentMonth].ReadOnly = false;
                        dt.Rows[index][currentMonth] = value;
                        break;
                }
                dt.AcceptChanges();
            }
            catch
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

    }
}