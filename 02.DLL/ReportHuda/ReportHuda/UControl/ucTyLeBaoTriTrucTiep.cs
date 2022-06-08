using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class ucTyLeBaoTriTrucTiep : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucTyLeBaoTriTrucTiep";
        public ucTyLeBaoTriTrucTiep()
        {
            InitializeComponent();
        }
        #region Load Du Lieu

        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViAll", 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, _table, "MS_DON_VI", "TEN_DON_VI", lblDonVi.Text);
            }
            catch { }
        }


        private void LoadPhongBan()
        {
            if (cboDonVi.Text == "") return;

            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanAll", 1, cboDonVi.EditValue));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhongBan, _table, "MS_PB", "TEN_PB", lblPhongBan.Text);
            }
            catch { }
        }


        private void LoadNhanVien(string MsDv, int MsPB, int MsTo)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTimNhanVien", MsTo, MsPB, MsDv,"-1"));
                System.Data.DataColumn cChon = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                cChon.DefaultValue = "0";
                dtTmp.Columns.Add(cChon);
                cChon.DefaultValue = false;
                cChon.SetOrdinal(0);
                dtTmp.Columns["CHON"].ReadOnly = false;

                dtTmp.Columns["MS_CONG_NHAN"].SetOrdinal(1);
                dtTmp.Columns["HO_TEN"].SetOrdinal(2);

                dtTmp.DefaultView.Sort = "MS_CONG_NHAN ASC"; 
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCNhan, grvCNhan, dtTmp, true, true, true, false, true, sBC);
                for (int i = 1; i < grvCNhan.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                    if (i > 2) grvCNhan.Columns[i].Visible = false;
                }
                grvCNhan.Columns["CHON"].Width = 200;
                grvCNhan.Columns["MS_CONG_NHAN"].Width = 200;
                grvCNhan.Columns["HO_TEN"].Width = grdCNhan.Width - 400;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event chuan

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhongBan();
        }

        private void cboPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDonVi.Text == "[EditValue is null]" || cboDonVi.Text == "") return;
            if (cboPhongBan.Text == "[EditValue is null]" || cboPhongBan.Text == "") return;
            LoadNhanVien(cboDonVi.EditValue.ToString(), int.Parse(cboPhongBan.EditValue.ToString()), -1);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvCNhan);

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvCNhan);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void txtTKCNhan_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdCNhan.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKCNhan.Text.Length != 0) dk = " HO_TEN LIKE '%" + txtTKCNhan.Text + "%' OR MS_CONG_NHAN LIKE '%" + txtTKCNhan.Text + "%' ";
                    dtTmp.DefaultView.RowFilter = dk;
                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
            }
            catch { }
        }


        #endregion


        private void ucTyLeBaoTriTrucTiep_Load(object sender, EventArgs e)
        {
            dtTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            dtDNgay.DateTime = dtTNgay.DateTime.AddMonths(1).AddDays(-1);

            LoadDonVi();

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdCNhan.DataSource;
                dtTmp = dtTmp.Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                #region Cong Nhan
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, sBC, "msgChuaChonCongNhan", Commons.Modules.TypeLanguage));
                    return;
                }
                #endregion


                string sCN = "TLBTTT_DC" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sCN, dtTmp, "");

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBCTyLeBaoTriTrucTiep", dtTNgay.DateTime.Date, dtDNgay.DateTime.Date,
                    cboDonVi.EditValue, cboPhongBan.EditValue, sCN, Commons.Modules.TypeLanguage));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sBC);
                InDieuDoBaoTri();

                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                            ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void InDieuDoBaoTri()
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
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 10;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.DisplayAlerts = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;
                //xlApp.Visible = true;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDeDDBT", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 3, 4, "@", 15, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 3, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 5;
                stmp = lblDonVi.Text + " : " + cboDonVi.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = lblPhongBan.Text + " : " + cboPhongBan.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                Dong++;

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
                int iCot = 1;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "#,##0", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, Dong, iCot, Dong + TDong, iCot); iCot++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0.00", true, Dong, iCot, Dong + TDong + 1, TCot);
                iCot = iCot + 2;
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0", true, Dong, iCot, Dong + TDong + 1, iCot );

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = TDong + Dong + 1;


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TongCong", Commons.Modules.TypeLanguage), Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                for (int i = 7; i < TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, i, Dong, i);
                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(9, i) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(Dong - 1, i) + ")";
                    title.Font.Bold = true;
                }
                //((F+G))/H)*100

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot - 1, Dong, TCot - 1);
                title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong, 7) + " / " +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, 9) + ") * 100";
                title.Font.Bold = true;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, TCot, Dong, TCot);
                title.Value2 = "=((" + Commons.Modules.MExcel.TimDiemExcel(Dong, 7) + " + " + Commons.Modules.MExcel.TimDiemExcel(Dong, 8) + ") / " +
                    Commons.Modules.MExcel.TimDiemExcel(Dong, 9) + ") * 100";
                title.Font.Bold = true;



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 7, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 4, 3, TCot);
                title.Font.Size = 16;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.RowHeight = 40;

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
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

    }
}
