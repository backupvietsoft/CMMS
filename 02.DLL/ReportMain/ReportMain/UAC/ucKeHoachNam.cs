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
    public partial class ucKeHoachNam : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachNam()
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
        
        private void ucKeHoachNam_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;
            LoadNXuong();
            LoadDChuyen();
            LoadLoaiMay();
            datNgay.DateTime = DateTime.Now;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam",
                    "KhongCoNam", Commons.Modules.TypeLanguage));
                cboNXuong.Focus();
                return;
            }

            if (cboNXuong.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam",
                    "KhongCoNhaXuong", Commons.Modules.TypeLanguage));
                cboNXuong.Focus();
                return;
            }
            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam",
                    "KhongCoDayChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam",
                    "KhongCoLoaiMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }
            DateTime TNgay, DNgay;
            DataTable dtTmp = new DataTable();
            TNgay = DateTime.Parse(datNgay.DateTime.Year.ToString() + "/01/01");
            DNgay = TNgay.AddYears(1).AddDays(-1);

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKeHoachNam", TNgay, DNgay, cboNXuong.EditValue,
                Commons.Modules.UserName, cboDChuyen.EditValue, cboLMay.EditValue, Commons.Modules.TypeLanguage));

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, true, true, true, "ucKeHoachNam");
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }


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
            sTmp = "";
            DataTable dtMay = new DataTable();
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdChung.DataSource;
            dtMay = dtTmp.DefaultView.ToTable(true, "TEN_MAY");

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11 + dtMay.Rows.Count;
                prbIN.Properties.Minimum = 0;


                //grdChung.ExportToXls(sPath,);
                grdChung.ExportToXls(sPath, new DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, true, true, true, true));

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelApplication.Cells.Font.Name = "Times New Roman";
                excelApplication.Cells.Font.Size = 10;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);

                int SCot;
                SCot = TCot;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "TieuDe", Commons.Modules.TypeLanguage) + " " + datNgay.DateTime.Date.Year.ToString(); ;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 18, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "BoPhan", Commons.Modules.TypeLanguage) + " : " + cboNXuong.TextValue + " ";
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 18, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2 + TDong, SCot);
                title.Borders.LineStyle = 1;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Dong + 2;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

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
                //7	14	19	20	18	30	6	9	12


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 19, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 6, "##", true, Dong, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong, 7, Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 8, Dong, 8);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 2, 1, Dong - 2, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 5, 1, Dong - 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //return;
                Dong = TDong + 10;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                Dong++;
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "GiamDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 10, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "QuanDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 3, "@", 10, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "KyThuat", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 5, "@", 10, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "NguoiLap", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 6, "@", 10, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                int iTongDong = 0;
                int iDongBD = Dong - TDong - 1;
                int iDongCuoiBP = 0;
                int iDongBDBP = Dong - TDong - 1;


                DataTable dtBPhan = new DataTable();
                

                for (int i = 0; i < dtTmp.Rows.Count; )
                {
                    sTmp = dtTmp.Rows[i]["TEN_MAY"].ToString();
                    dtMay = new DataTable();
                    dtMay = dtTmp.Copy();
                    dtMay.DefaultView.RowFilter = "TEN_MAY = '" + dtTmp.Rows[i]["TEN_MAY"].ToString() + "' ";
                    dtMay = dtMay.DefaultView.ToTable();
                    iTongDong = dtMay.Rows.Count + iDongBD - 1;
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDongBD, 1, iTongDong, 1);
                    title.Value2 = Convert.ToString(null);
                    try
                    {
                        title.MergeCells = true;
                    }
                    catch { }
                    title.Value2 = sTmp;
                    iDongBDBP = iDongBD;

                    for (int j = 0; j < dtMay.Rows.Count; )
                    {
                        sTmp = dtMay.Rows[j]["TEN_BO_PHAN"].ToString();
                        dtBPhan = new DataTable();
                        dtBPhan = dtMay.Copy();
                        dtBPhan.DefaultView.RowFilter = "TEN_BO_PHAN = '" + dtMay.Rows[j]["TEN_BO_PHAN"].ToString() + "' ";
                        dtBPhan = dtBPhan.DefaultView.ToTable();
                        iDongCuoiBP = dtBPhan.Rows.Count + iDongBDBP - 1;

                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDongBDBP, 2, iDongCuoiBP, 2);
                        title.Value2 = Convert.ToString(null);
                        try
                        {
                            title.MergeCells = true;
                        }
                        catch { }
                        title.Value2 = sTmp;
                        j = j + dtBPhan.Rows.Count;
                        iDongBDBP = iDongCuoiBP + 1;

                    }





                    i = i + dtMay.Rows.Count;
                    iDongBD = iTongDong + 1;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                excelApplication.Visible = true;
                excelWorkbook.Save();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachNam", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;
                prbIN.Position = prbIN.Properties.Maximum;
                
            }
            this.Cursor = Cursors.Default;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}