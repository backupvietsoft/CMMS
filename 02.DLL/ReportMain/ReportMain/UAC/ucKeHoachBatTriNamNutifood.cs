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
    public partial class ucKeHoachBatTriNamNutifood : DevExpress.XtraEditors.XtraUserControl
    {
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
        

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayKeHoachBTNam", cboDDiem.EditValue,
                cboDChuyen.EditValue,cboLMay.EditValue,Commons.Modules.UserName));



            dtTmp.Columns[0].ReadOnly = false;
            for (int i = 1; i < dtTmp.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, true, false, false);
            grvMay.Columns["CHON"].Width = 50;
            grvMay.Columns["MS_MAY"].Width = 100;
            grvMay.Columns["TEN_MAY"].Width = 200;
            grvMay.OptionsView.ColumnAutoWidth = true;
            grvMay.Columns["CHON"].Width = 50;
        }

        #endregion

        private void ucKeHoachBatTriNamNutifood_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = DateTime.Now;
            datDNgay.DateTime = datTNgay.DateTime.AddMonths(1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();

        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdMay.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false , "CHON", grvMay);
        }

        public ucKeHoachBatTriNamNutifood()
        {
            InitializeComponent();
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.DateTime.Date < DateTime.Now.Date)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBatTriNamNutifood",
                    "TuNgayKhongDuocNhoHonNgayHienTai", Commons.Modules.TypeLanguage),this.Name);
                datTNgay.Focus();
                return;

            }
            if (datDNgay.DateTime < datTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBatTriNamNutifood",
                    "DenNgayKhongDuocNhoHonTuNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return;
            }
            TaoDuLieu();

        }

        private void TaoDuLieu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grdMay.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBatTriNamNutifood",
                        "ChuaChonDuMay", Commons.Modules.TypeLanguage));
                    return;

                }
                int iTuanBD, iTuanKT;
                //System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                
                iTuanBD = Microsoft.VisualBasic.DateAndTime.DatePart("ww", datTNgay.DateTime,
                    Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);
                iTuanKT = Microsoft.VisualBasic.DateAndTime.DatePart("ww", datDNgay.DateTime,
                    Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);


                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 14 + ((iTuanKT - iTuanBD) - 7);
                prbIN.Properties.Minimum = 0;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                string sBTam,sSql;
                sBTam = "MMAY";
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKeHoachBTNam", datTNgay.DateTime, datDNgay.DateTime,
                    cboDDiem.EditValue, Commons.Modules.UserName, cboLMay.EditValue, cboDChuyen.EditValue));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.XoaTable(sBTam);

                sBTam = "S_DU_LIEU" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                sSql= "";
                for (int i = iTuanBD; i <= iTuanKT; i++)
                {
                    sSql +=  ", [" + i.ToString() + "] ";
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                

                sSql = " SELECT STT, MS_MAY, TEN_MAY, TEN_N_XUONG, TEN_LOAI_BT, MO_TA_CV, TEN_BO_PHAN " + sSql +                            
                            " FROM  " +
                            " ( " +
                            " SELECT STT, MS_MAY, TEN_MAY, TEN_N_XUONG, TEN_LOAI_BT, MO_TA_CV, TEN_BO_PHAN , TGDK , SO_TUAN " +
                            " FROM  " + sBTam + " A " +
                            " ) P  " +
                            " PIVOT  " +
                            " ( SUM(TGDK) FOR SO_TUAN IN ( " + sSql.Substring(1,sSql.Length-1) + " )) AS PVT " +
                            " ORDER BY  MS_MAY, TEN_MAY, TEN_N_XUONG, TEN_LOAI_BT, MO_TA_CV, TEN_BO_PHAN ";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text , sSql));
                Commons.Modules.ObjSystems.XoaTable(sBTam);
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachBatTriNamNutifood", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    prbIN.Position = prbIN.Properties.Maximum;
                    this.Cursor = Cursors.Default;
                    datTNgay.Focus();
                    return;
                }
                dtTmp.Columns["STT"].ReadOnly = false;
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    dtTmp.Rows[i][0] = (i + 1).ToString();
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true);
                for (int i = 0; i < 7; i++)
                {
                    grvChung.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKeHoachBTTuan", grvChung.Columns[i].FieldName, Commons.Modules.TypeLanguage);
                }
                InDuLieu();
                 
            }
            catch { }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;

        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            //sPath = "D:\\222.xls";
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;


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
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 4, 1, (TCot > 7 ? 7 : TCot));
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBatTriNamNutifood", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 7 ? 7 : TCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong++;

                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 7 ? 7 : TCot));

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);


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
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong , TCot);
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
                

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 19, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 9, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong + 1, 7, TDong + Dong, 7);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 8, TDong + Dong, 8);
                

                

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 8, Dong + TDong, TCot);
                Excel.FormatCondition condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlNotEqual, "=\"\"", Type.Missing));
                condition.Interior.Color = 65535;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.DisplayAlerts = false;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachBatTriNamNutifood", "TongCong", Commons.Modules.TypeLanguage), Dong + TDong + 1, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong + TDong + 1, 7);
                for (int i = 8; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + TDong + 1, i, Dong + TDong + 1, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong + 1, i) + ":" + 
                        Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, i) + ") / 60";
                    title.NumberFormat = "#,##0.00";
                    title.ColumnWidth = 3;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    title.Orientation = 90;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong, 8, Dong, TCot);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong , 1, Dong + TDong + 1, TCot);
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
                    "ucKeHoachBatTriNamNutifood", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

    }
}
