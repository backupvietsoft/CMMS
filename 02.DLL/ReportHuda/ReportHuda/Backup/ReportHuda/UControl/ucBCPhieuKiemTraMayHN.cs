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
    public partial class ucBCPhieuKiemTraMayHN : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucBCPhieuKiemTraMayHN";
        public ucBCPhieuKiemTraMayHN()
        {
            InitializeComponent();
        }

        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong",
                    Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, dtTmp, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, dtTmp, "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            try
            {
                if (Commons.Modules.SQLString == "0L0ad") return;
                DataTable dtTmp = new DataTable();
                string sDDiem = "-1";
                int iHThong = -1;
                string MsLMay = "-1";
                try
                { sDDiem = cboDDiem.EditValue.ToString(); }
                catch { }
                try
                { iHThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { }
                try
                { MsLMay = cboLMay.EditValue.ToString(); }
                catch { }
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoLMNXHT", Commons.Modules.UserName,
                                        MsLMay, "-1", sDDiem, iHThong, 1, 0));
                System.Data.DataColumn cChon = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                cChon.DefaultValue = "0";
                dtTmp.Columns.Add(cChon);
                cChon.SetOrdinal(0);
                dtTmp.Columns["CHON"].ReadOnly = false;



                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, false, true, sBC);
                for (int i = 1; i < grvBC.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                grvBC.Columns["CHON"].Width = 90;
                grvBC.Columns[2].Width = 250;
                grvBC.Columns["THU_TU"].Visible = false;
                grvBC.Columns["MS_LOAI_BT"].Visible = false;
            }
            catch { }
        }

        #endregion

        private void ucBCPhieuKiemTraMayHN_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0L0ad";
            datTNgay.DateTime = DateTime.Now.Date;
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
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
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KhongCoNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }

            if (cboDDiem.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return;
            }

            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;
                dtTmp = dtTmp.Copy();
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                #region Cong Nhan
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, sBC, "msgChuaChonMay", Commons.Modules.TypeLanguage));
                    return;
                }
                #endregion


                string sBT;
                sBT = "MAY_TMP" + Commons.Modules.UserName ;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");


                DateTime TNgay, DNgay;
                TNgay = Convert.ToDateTime(datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                DNgay = TNgay.AddMonths(1).AddDays(-1);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCPhieuKiemTraMayHN", TNgay, DNgay,Commons.Modules.UserName,
                        cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue,"-1", sBT, Commons.Modules.TypeLanguage));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                int iSNgay = 31;
                iSNgay = System.DateTime.DaysInMonth(TNgay.Date.Year, TNgay.Date.Month);
                if (iSNgay < 31)
                {
                    iSNgay = 35 - (31 - iSNgay);
                    for (int i = iSNgay; i < 35; i++)
                    {
                        dtTmp.Columns.RemoveAt(iSNgay);
                    }
                    
                }

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
                grvChung.Columns["TEN_MAY"].Group();
                grvChung.OptionsView.ShowGroupPanel = true;
                grvChung.Columns["TEN_MAY"].Visible = false;

                grvChung.Columns["STT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "STT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "TEN_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_TS_GSTT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "TEN_TS_GSTT", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_DVTG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "TEN_DVTG", Commons.Modules.TypeLanguage);


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
                InDuLieu(iSNgay + 5);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "msgTaoDuLieuKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
 

        }

        private void InDuLieu(int TCot)
        {
            string sPath = "";


            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                
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

                xlApp.Cells.Font.Name = "Tahoma";
                xlApp.Cells.Font.Size = 7.5;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 22, 1, 22);
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "MAU_SO", Commons.Modules.TypeLanguage);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 22, 2, 22);
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "LAN_BH", Commons.Modules.TypeLanguage);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 22, 3, 22);
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "NGAY_BH", Commons.Modules.TypeLanguage);

                Dong = 5;
                
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong, 5);
                title.Font.Size = 15;
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "TDPhieuKiemTraMay", Commons.Modules.TypeLanguage);
                
                Dong++;
                
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, 2);
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "SO_PHIEU", Commons.Modules.TypeLanguage);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong, 5);
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "NGAY_KT", Commons.Modules.TypeLanguage) + " : " + datTNgay.DateTime.ToString("MM/yyyy");


                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, 2);
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "LOAI_MAY", Commons.Modules.TypeLanguage) + " : " + cboLMay.Text;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 5, Dong, 5);
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "DIA_DIEM", Commons.Modules.TypeLanguage) + " : " + cboDDiem.Text;

                Dong++;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong, 4);
                title.MergeCells = true;
                title.Font.Bold = true;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "GHI_CHU", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "Y_DAT", Commons.Modules.TypeLanguage) + "\n" + "                " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "N_KHONG_DAT", Commons.Modules.TypeLanguage);
                title.RowHeight = 50;
                
                
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                
                Dong++;
               
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

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 2, 1], xlWorkSheet.Cells[Dong + 2, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 95);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 2, 8, 4);
                title.RowHeight = 30;
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 0, "##", true, Dong + 2, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "##", true, Dong + 2, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 2, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 2, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 2.2, "@", true, Dong + 2, 5, TDong + Dong, TCot-1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 2, TCot, TDong + Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Formula1:="=""X"""

                Dong = TDong + Dong;
                Excel.Range range = Commons.Modules.MExcel.GetRange(xlWorkSheet, 11, 5, Dong, TCot - 1);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                ////////////var range = (Excel.Range)xlWorkSheet.Cells[11 , colNo + 1];
                //////////Excel.FormatCondition condition = (Excel.FormatCondition)
                //////////        range.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "=\"X\"", Type.Missing);
                //////////condition.Application.ActiveCell.NumberFormat = ";;;";
                //////////condition.Interior.ColorIndex = 3; // Red

                Excel.FormatConditions fcs = range.FormatConditions;
                Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "=\"X\"", Type.Missing);
                Excel.Interior interior = fc.Interior;
                interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));
                Excel.Font font = fc.Font;
                font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));

                Excel.FormatConditions fcs1 = range.FormatConditions;
                Excel.FormatCondition fc1 = (Excel.FormatCondition)fcs1.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "=\"Y\"", Type.Missing);
                Excel.Interior interior1 = fc1.Interior;
                interior1.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(196, 215, 155));


                Excel.FormatConditions fcs2 = range.FormatConditions;
                Excel.FormatCondition fc2 = (Excel.FormatCondition)fcs2.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "=\"N\"", Type.Missing);
                Excel.Interior interior2 = fc2.Interior;
                interior2.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 192, 218));



                
                Dong++;
                Dong++;
                

                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void grvChung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.Column.FieldName == "10" )
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["10"]);
                if (category == "X")
                {
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                    e.Appearance.BackColor2 = Color.LightCyan;
                }
            }
        }

        



    }
}
