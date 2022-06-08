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
    public partial class ucKeHoachBaoDuong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachBaoDuong()
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
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
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
        
        #endregion

        private void ucKeHoachBaoDuong_Load(object sender, EventArgs e)
        {
            datTNgay.DateTime = DateTime.Now.Date;
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong", "KhongCoNgay", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }


            try
            {
                DateTime TNgay, DNgay;
                string Ma, Ten, KVuc, VTri;
                Ma = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong",
                        "Ma", Commons.Modules.TypeLanguage);
                Ten = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong",
                        "Ten", Commons.Modules.TypeLanguage);
                KVuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong",
                        "KVuc", Commons.Modules.TypeLanguage);
                VTri = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong",
                        "VTri", Commons.Modules.TypeLanguage);


                TNgay = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKeHoachBTThietBi", TNgay, DNgay, cboDDiem.EditValue,
                    Commons.Modules.UserName, cboLMay.EditValue, cboDChuyen.EditValue, Ma, Ten, KVuc, VTri, Commons.Modules.TypeLanguage ));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBaoDuong",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, false, "");
                grvChung.Columns["MS_MAY"].Group();


                foreach (DataRow row in dtTmp.Rows)
                {
                    
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    col1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                    col1.AppearanceHeader.Options.UseFont = true;
                    col1.AppearanceHeader.Options.UseTextOptions = true;
                    col1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    
                    col1.Visible = true;
                    col1.Width = 109;
                    
                    
                    col1.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    col1.ColumnEdit.AutoHeight = false;
                    col1.OptionsColumn.AllowEdit = true;
                    col1.OptionsColumn.ReadOnly = false;
                    col1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    grvChung.Columns.Add(col1);
                    
                }


                grvChung.ExpandAllGroups();
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "ucKeHoachBaoDuong");
                
                InDuLieu();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  

        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = 10;// grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                xlApp.Cells.Font.Name = Commons.Modules.sFontReport;
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                if (Commons.Modules.sPrivate == "VINHHOAN")
                    Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 5, 5, 120, 45, Application.StartupPath);
                else
                    Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "TieuDe", Commons.Modules.TypeLanguage) + " - " + datTNgay.DateTime.ToString("MM/yyyy"), 2, 5, "@", 16, true,
                    (Commons.Modules.sPrivate == "VINHHOAN" ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignLeft), 
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (Commons.Modules.sPrivate == "VINHHOAN" ? TCot - 1 : TCot));


                Excel.Range title;
                string stmp = "";
                string stmp1 = "";
                Dong = 1;

                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "ucKeHoachBaoDuong", "bcMaSo", Commons.Modules.TypeLanguage);
                    stmp1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "ucKeHoachBaoDuong", "bcMaSo1", Commons.Modules.TypeLanguage);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp + " " + stmp1, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                    title.get_Characters(stmp.Length + 1, stmp1.Length + 1).Font.Bold = true;

                    Dong++;

                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "ucKeHoachBaoDuong", "bcNgayHL", Commons.Modules.TypeLanguage);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                    Dong++;

                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "ucKeHoachBaoDuong", "bcLanSX", Commons.Modules.TypeLanguage);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, TCot, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);




                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, 4);
                    title.MergeCells = true;

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 5, 3, TCot - 1);
                    title.MergeCells = true;



                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                    title.Borders.LineStyle = 1;
                    title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                }
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, 9, 2);
                try
                {
                    title.UnMerge();
                }
                catch { }
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 2, 9, 2);
                title.Value2 = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, 9, 1).Value2;

                stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "KinhGoi", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", (Commons.Modules.sPrivate == "VINHHOAN" ? "bcTruongDonVi" : "KhoiSanXuat"), Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", (Commons.Modules.sPrivate == "VINHHOAN" ? "bcGiamDoc" : "GiamDocChiNhanh"), Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);


                Dong++;
                if (Commons.Modules.sPrivate != "VINHHOAN")
                {
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "TruongNhaMay", Commons.Modules.TypeLanguage);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 13, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                Dong++;
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

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);
                


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 34, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 2, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 2, 10, TDong + Dong, 10);
                xlWorkSheet.Rows.AutoFit();

                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 3, TCot);
                    title.RowHeight = 18;
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "ChuThich", Commons.Modules.TypeLanguage) + ":" + "………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………….";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;

                stmp = "………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………………….";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                Dong++;
                if (Commons.Modules.sPrivate == "VINHHOAN")
                {

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
    "ucKeHoachBaoDuong", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 3, "@", 11, true,
    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 3);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 10, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 10);


                    Dong++;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 10, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 10);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);


                }
                else
                {


                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 3, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 3);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 10, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 10);


                    Dong++;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 3, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 3);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBaoDuong", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                }


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "AVQSX", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = stmp + " &P / &N";
                //00/30.06.2013
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "DuoiPhai", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.RightFooter = stmp;

                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBaoDuong", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

    }
}
