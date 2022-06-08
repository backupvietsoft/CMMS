using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using Spire.Xls;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace ReportMain
{
    public partial class ucKHBDThietBi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKHBDThietBi()
        {
            InitializeComponent();
        }


        //private void datTNgay_Popup(object sender, EventArgs e)
        //{
        //    DateEdit edit = sender as DateEdit;
        //    PopupDateEditForm form = (edit as IPopupControl).PopupWindow as PopupDateEditForm;
        //    form.Calendar.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.YearsInfo;

        //    //datTNgay.CustomDrawDayNumberCell += new CustomDrawDayNumberCellEventHandler(cal_CustomDrawDayNumberCell);
        //    //datTNgay.ItemChanged += new Item(datTNgay_ItemChanged);
        //}




        //private void datTNgay_ItemChanged(object sender, ItemChangedEventHandler e)
        //{
        //DayNumberCellInfo cell = (DayNumberCellInfo)hitInfo.HitObject;

        //datTNgay.DateTime = new DateTime(((DevExpress.XtraEditors.DateEdit)(sender)).DateTime.Year, 1, 1);
        //DateTime date = new DateTime(DateTime.Year, cell.Date.Month, 1);                    
        //DateTime date = new DateTime(cell.Date.Year, 1, 1);
        //OnDateTimeCommit(date, false);


        //}

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
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHTCoAll", 
                    sNX,iHThong, Commons.Modules.UserName, Commons.Modules.TypeLanguage,1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }
        #endregion

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucKHBDThietBi_Load(object sender, EventArgs e)
        {

            Commons.Modules.SQLString = "0LOAD";
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            LoadNX();
            LoadDChuyen();
            Commons.Modules.SQLString = "";
            LoadLoaiMay();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi", "KhongCoNam", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }


            try
            {
                DateTime TNgay, DNgay;
                string Ma, Ten, KVuc, VTri;
                Ma = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "Ma", Commons.Modules.TypeLanguage);
                Ten = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "Ten", Commons.Modules.TypeLanguage);
                KVuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "KVuc", Commons.Modules.TypeLanguage);
                VTri = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "VTri", Commons.Modules.TypeLanguage);


                TNgay = Convert.ToDateTime("01/01/" + datTNgay.DateTime.Year);
                DNgay = TNgay.AddYears(1).AddDays(-1);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKeHoachBDThietBiNam", TNgay, DNgay, cboDDiem.EditValue,
                    Commons.Modules.UserName, cboLMay.EditValue, cboDChuyen.EditValue, Ma, Ten, KVuc, VTri, 
                    Commons.Modules.TypeLanguage,optLoaiBC.SelectedIndex));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, false, "");
                grvChung.Columns["MS_MAY"].Group();
                grvChung.ExpandAllGroups();

                //MS_BO_PHAN, TEN_BO_PHAN, CHU_KY, MS_DV_TG, NGAY_CUOI
                grvChung.Columns["MS_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "MS_BO_PHAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "CHU_KY_TG", Commons.Modules.TypeLanguage);
                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["NGAY_CUOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                        "NGAY_CUOI", Commons.Modules.TypeLanguage);

                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHBDThietBi",
                    "MS_MAY", Commons.Modules.TypeLanguage) + " ";

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
                    "ucKHBDThietBi", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                int TCot = grvChung.Columns.Count + 1;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXlsx(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Visible = false;

                xlApp.Cells.Font.Name = "Arial";
                xlApp.Cells.Font.Size = 8;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 1, 1);
                title.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 3, 2, 3);




                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, Convert.ToInt32(title.Left) + 10, 15.5, 105.5, 40.8, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = 2;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "TieuDe", Commons.Modules.TypeLanguage), Dong, 5, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 6);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 "ucKHBDThietBi", "TMP1", Commons.Modules.TypeLanguage), Dong, TCot - 5, "@", 10, false,
                 Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, TCot);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "TMP2", Commons.Modules.TypeLanguage), Dong + 1, TCot - 5, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 1, TCot);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "TMP3", Commons.Modules.TypeLanguage), Dong + 2, TCot - 5, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 2, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 3, Dong + 2, 4);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong + 2, TCot - 6);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot - 5, Dong + 2, TCot);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong + 2, TCot - 6);
                title.MergeCells = true;




                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "Nam", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong++;
                Dong++;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, 1);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong + TDong, TCot);
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

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, 4, 1);
                title.RowHeight = 16.5;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                //title.RowHeight = 12;

                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0.2, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "##", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 29.5, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 8, TDong + Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 2, 8, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;
                Dong++;


                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NgayThangNam", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);
                }
                else
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NgayThangNam", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);
                }
                else
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "AVQSX", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = "&G" + stmp + " &P / &N ";
                //00/30.06.2013
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "DuoiPhai", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.RightFooter = stmp;

                xlWorkBook.Save();
                xlApp.Quit();
                //xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                //Them image pagefooter
                //----------------------------------------------------
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(sPath);
                Worksheet sheet = workbook.Worksheets[0];

                Image image = Image.FromFile(@"reports\images\nam excel.png");
                image = resizeImage(image, 50, 1350);

                sheet.PageSetup.CenterFooterImage = image;
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
                    "ucKHBDThietBi", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
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
                int TCot = grvChung.Columns.Count + 1;
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

                xlApp.Cells.Font.Name = "Calibri";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 1, 1);
                title.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                //Dim DangThem As Excel.XlInsertShiftDirection
                //Dim MRange As Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, 1))
                //MRange.EntireColumn.Insert(DangThem)


                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "TieuDe", Commons.Modules.TypeLanguage), 2, 5, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "Nam", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.Year.ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                Dong++;
                Dong++;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, 1);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
                //title.BorderAround(Excel.XlBordersIndex.xlEdgeRight, Excel.XlBorderWeight.xlThin,
                //    Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);



                //Excel.Borders borders = title.Borders;
                //borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                //borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                //borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                //borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                //borders.Color = colour;
                //borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                //borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                //borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                //borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                //borders = null;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong + TDong, TCot);
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

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0.2, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "##", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 34, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 13, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3.5, "@", true, Dong + 2, 8, TDong + Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 2, 8, TDong + Dong, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;
                Dong++;


                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NgayThangNam", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);
                }
                else
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "KiemTra", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NgayThangNam", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                if (Commons.Modules.sPrivate == "VINHHOAN")
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);
                }
                else
                {
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 4, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 4);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 6, "@", 11, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6);

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHBDThietBi", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 14, "@", 11, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 14);
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "AVQSX", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = stmp + " &P / &N";
                //00/30.06.2013
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKHBDThietBi", "DuoiPhai", Commons.Modules.TypeLanguage);
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
                    "ucKHBDThietBi", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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
