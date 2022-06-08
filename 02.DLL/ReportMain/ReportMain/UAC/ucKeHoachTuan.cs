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
    public partial class ucKeHoachTuan : DevExpress.XtraEditors.XtraUserControl
    {

        public ucKeHoachTuan()
        {
            InitializeComponent();
        }
        private void LoadNXuong()
        {
            Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");


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
        
        private void ucKeHoachTuan_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;
            LoadNXuong();
            LoadDChuyen();
            LoadLoaiMay();
            datNgay.DateTime = DateTime.Now;
            MGetTuan(datNgay.DateTime);
        }

        private void MGetTuan(DateTime Ngay)
        {
            int SNgay;
            txtTuan.Text = Convert.ToString(Microsoft.VisualBasic.DateAndTime.DatePart("ww", Ngay,
                Microsoft.VisualBasic.FirstDayOfWeek.Monday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFourDays) +
                " / " + Ngay.Year.ToString())  ;

            SNgay = 0;
            switch (Ngay.DayOfWeek.ToString().ToUpper())
            {
                case "MONDAY":
                    SNgay = 0;
                    break;
                case "TUESDAY":
                    SNgay = 1;
                    break;
                case "WEDNESDAY":
                    SNgay = 2;
                    break;
                case "THURSDAY":
                    SNgay = 3;
                    break;
                case "FRIDAY":
                    SNgay = 4;
                    break;
                case "SATURDAY":
                    SNgay = 5;
                    break;
                case "SUNDAY":
                    SNgay = 6;
                    break;
            }
            datTNgay.DateTime = Ngay.AddDays(-SNgay);
            datDNgay.DateTime = Ngay.AddDays(-SNgay).AddDays(6);
            

        }

        private void datNgay_EditValueChanged(object sender, EventArgs e)
        {
            MGetTuan(datNgay.DateTime);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboNXuong.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", 
                    "KhongCoNhaXuong", Commons.Modules.TypeLanguage), this.Name);
                cboNXuong.Focus();
                return;
            }
            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan",
                    "KhongCoDayChuyen", Commons.Modules.TypeLanguage), this.Name);
                cboDChuyen.Focus();
                return;
            }  
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan",
                    "KhongCoLoaiMay", Commons.Modules.TypeLanguage), this.Name);
                cboLMay.Focus();
                return;
            }
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKeHoachTuan", datTNgay.DateTime.Date, datDNgay.DateTime.Date,
                cboNXuong.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, Commons.Modules.TypeLanguage, Commons.Modules.UserName));

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }

            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }
            //grvChung.OptionsView.AllowCellMerge = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, false, true, true, true, "ucKeHoachTuan");
            
            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvChung.Columns)
            //    {
            //        if (col.Name != "colTEN_MAY")
            //            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            //    }

            InDuLieu();
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            Excel.Range title;
            string sTmp;
            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11 ;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;


                //grdChung.ExportToXls(sPath,);
                grdChung.ExportToXls(sPath, new DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, true, true, true, true));

                //System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                

                excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                excelApplication.Visible = false;

                excelApplication.Cells.Font.Name = "Times New Roman";
                excelApplication.Cells.Font.Size = 10;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                sTmp = "SELECT TOP 1  CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TENCT FROM THONG_TIN_CHUNG ";
                sTmp = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sTmp));

                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);

                int SCot;
                SCot = TCot;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = 1;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 12, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "PhieuTheoDoiBaoTriTuan", Commons.Modules.TypeLanguage) + " " + txtTuan.Text + " ";
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 6, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Dong++;
                
                sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "BoPhan", Commons.Modules.TypeLanguage) + " : " + cboNXuong.TextValue + " ";
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 12, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                sTmp = lblTNgay.Text + " " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text.ToLower() + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 6, "@", 14, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                for (int Cot = 1; Cot <= 5; Cot++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, Cot, Dong + 1, Cot);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                }

                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "KeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 6, "@", 10, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);


                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "ThucHien", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 9, "@", 10, false,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 3, 1, Dong + 1 + TDong, SCot);
                title.Borders.LineStyle = 1;

                 
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, 2, 5);
                title.BorderAround(Excel.XlLineStyle.xlContinuous,Excel.XlBorderWeight.xlThin,Excel.XlColorIndex.xlColorIndexNone,
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 6, 2, SCot);
                title.BorderAround(Excel.XlLineStyle.xlContinuous,Excel.XlBorderWeight.xlThin,Excel.XlColorIndex.xlColorIndexNone,
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong+1, SCot);
                title.Font.Bold = true;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 2, 1], excelWorkSheet.Cells[Dong - 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 4.5, "@", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.75, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 22, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 6, Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 10, Dong, SCot);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong, 8, Dong, 8);


                //return;
                Dong = TDong+6;


                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "QuanDocXuong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", "ToTruong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 10, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                DataTable dtTmp = new DataTable();
                DataTable dtMay = new DataTable();
                dtTmp = (DataTable)grdChung.DataSource;
                //foreach (DataRow drRow in dtTmp.Rows)
                //{
                
                
                //}
                int iTongDong = 0;
                int iDongBD = 5;

                for (int i = 0; i < dtTmp.Rows.Count; )
                {
                    sTmp = dtTmp.Rows[i]["TEN_MAY"].ToString();
                    dtMay = new DataTable();
                    dtMay = dtTmp.Copy();
                    dtMay.DefaultView.RowFilter = "TEN_MAY = '" + dtTmp.Rows[i]["TEN_MAY"].ToString() + "' ";
                    dtMay = dtMay.DefaultView.ToTable();
                    iTongDong = dtMay.Rows.Count + iDongBD - 1;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDongBD, 2, iTongDong, 2);
                    title.Value2 = Convert.ToString(null); 
                    title.MergeCells = true;

                    title.Value2 = sTmp;
                    i = i + dtMay.Rows.Count;
                    iDongBD = iTongDong + 1;
                }

                excelApplication.Visible = true;
                excelWorkbook.Save();
            }
            catch 
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachTuan", 
                    "InKhongThanhCong", Commons.Modules.TypeLanguage), this.Name);
                excelApplication.Visible = true;
                

            }

            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void ucKeHoachTuan_Leave(object sender, EventArgs e)
        {

        }

    }
}
