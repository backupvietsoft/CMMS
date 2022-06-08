using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucBaoCaoBaoTriThietBiTuan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoBaoTriThietBiTuan()
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
        

        private void LoadLBT()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql;
                sSql = " SELECT CONVERT(BIT,0) AS CHON , dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.HINH_THUC_BAO_TRI.TEN_HT_BT, " +
                            " dbo.LOAI_BAO_TRI.HU_HONG, dbo.LOAI_BAO_TRI.THU_TU,dbo.LOAI_BAO_TRI.MS_LOAI_BT FROM dbo.LOAI_BAO_TRI INNER JOIN " +
                            " dbo.HINH_THUC_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_HT_BT = dbo.HINH_THUC_BAO_TRI.MS_HT_BT " +
                            " ORDER BY dbo.LOAI_BAO_TRI.THU_TU ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, "ucBaoCaoBaoTriThietBiTuan");
                for (int i = 1; i < grvBC.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                grvBC.Columns["CHON"].Width = 90;
                grvBC.Columns[1].Width = 250;
                grvBC.Columns["THU_TU"].Visible = false;
                grvBC.Columns["MS_LOAI_BT"].Visible = false;
            }
            catch { }
        }

        #endregion

        private void ucBaoCaoBaoTriThietBiTuan_Load(object sender, EventArgs e)
        {
            datTNgay.DateTime = DateTime.Now.Date;
            datDNgay.DateTime = DateTime.Now.Date.AddDays (7);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLBT();
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
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan", "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan", "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }

            try
            {
                string sBT;
                sBT = "LTB";
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdBC.DataSource, "");


                DateTime TNgay, DNgay;
                string Ma, Ten, KVuc, VTri;
                Ma = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan",
                        "Ma", Commons.Modules.TypeLanguage);
                Ten = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan",
                        "Ten", Commons.Modules.TypeLanguage);

                KVuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan",
                        "KVuc", Commons.Modules.TypeLanguage);
                VTri = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan",
                        "VTri", Commons.Modules.TypeLanguage);

                TNgay = datTNgay.DateTime;
                DNgay = datDNgay.DateTime;

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBaoCaoBTThietBiTuan", TNgay, DNgay,
                    cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, Commons.Modules.UserName,Commons.Modules.TypeLanguage));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoBaoTriThietBiTuan",
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, "ucBaoCaoBaoTriThietBiTuan");
                
                grvChung.Columns["TEN_LOAI_BT"].Group();
                grvChung.Columns["TEN_HE_THONG"].Group();

                grvChung.OptionsView.ShowGroupPanel = true;
                grvChung.Columns["TEN_LOAI_BT"].Visible = false;
                grvChung.Columns["TEN_HE_THONG"].Visible = false;
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
                InDuLieu();
            }
            catch { }

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
                int TCot = 13;// grvChung.Columns.Count;
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
                
                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 11;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Dong = 1;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                Excel.Range title;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "TieuDe", Commons.Modules.TypeLanguage), 2, 6, "@", 16, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 2, 6);

                string stmp = "";
                Dong = 5;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "NhaMay", Commons.Modules.TypeLanguage) + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "TuNgay", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.Date.ToShortDateString() +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "DenNgay", Commons.Modules.TypeLanguage) + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 13, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, 3);
                try
                {
                    title.UnMerge();
                }
                catch { }
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 3, 8, 3);
                title.Value2 = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, 1).Value2;




                Dong = Dong + 2;
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
                //4	12	26	20	24	20	12	30	12	14	30

                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 2, TDong + Dong, 1);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 26, "@", true, Dong + 2, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 2, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 2, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 2, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong + 2, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "#,##0.00", true, Dong + 2, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 14, "#,##0.00", true, Dong + 2, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 2, 13, TDong + Dong, 13);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong;


                Dong++;
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "PheDuyet", Commons.Modules.TypeLanguage), Dong, 5, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 5);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "KiemTra", Commons.Modules.TypeLanguage), Dong, 8, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 8);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "NguoiLap", Commons.Modules.TypeLanguage), Dong, 11, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 11);


                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "GiamDocChiNhanh", Commons.Modules.TypeLanguage), Dong, 5, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 5);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "TruongPhongCoDien", Commons.Modules.TypeLanguage), Dong, 8, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong, 8);
                //"&P"        .CenterHeader = "&N"

                //AVQSX-BM-01-BTSC
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "AVQSX", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.CenterFooter = stmp + " &P / &N";
                //00/30.06.2013
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBaoCaoBaoTriThietBiTuan", "DuoiPhai", Commons.Modules.TypeLanguage);
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
                    "ucBaoCaoBaoTriThietBiTuan", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
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
