using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class frmTinhHinhTonKho : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtLuoi;
        

        public frmTinhHinhTonKho()
        {
            InitializeComponent();
        }

        private void frmTinhHinhTonKho_Load(object sender, EventArgs e)
        {
            try
            {

                Commons.Modules.ObjSystems.ThayDoiNN(this);
                Commons.Modules.SQLString = "0Load";
                DataTable dtTmp = new DataTable();
                #region Load Kho
                if (Commons.Modules.sPrivate == "CS")
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUser", 1, Commons.Modules.UserName));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKho", 1));

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", lblKho.Text);
                #endregion

                #region Load LoaiVT
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiVT", Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVTu, dtTmp, "MS_LOAI_VT", "TEN_LVT", lblLVTu.Text);
                #endregion

                #region Load Class
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetClassVT", 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboClass, dtTmp, "MS_CLASS", "TEN_CLASS", lblClass.Text);
                #endregion
                Commons.Modules.SQLString = "";
                LoadData();


                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "frmTinhHinhTonKho");
                grvChung.Columns["MS_PT"].Width = 100;
                grvChung.Columns["MS_PT_CTY"].Width = 150;
                grvChung.Columns["TEN_PT"].Width = 150;
                grvChung.Columns["TEN_PT_VIET"].Width = 150;
                grvChung.Columns["MS_PT_NCC"].Width = 100;
                grvChung.Columns["QUY_CACH"].Width = 200;
                grvChung.Columns["TEN_CLASS"].Width = 80;
                grvChung.Columns["TON_TOI_THIEU"].Width = 80;
                grvChung.Columns["TON_KHO_MAX"].Width = 80;
                grvChung.Columns["TON_TT"].Width = 80;
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].Width = 60;
                grvChung.Columns["DVT"].Width = 60;
                grvChung.Columns["TINH_TRANG"].Width = 90;
                grvChung.Columns["TT"].Visible = false;

                grvChung.Columns["TON_TOI_THIEU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_TOI_THIEU"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["TON_KHO_MAX"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_KHO_MAX"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["TON_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_TT"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].DisplayFormat.FormatString = "{0:N0}";
                grvChung.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            catch { }

        }

        private void LoadData()
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                string Het, Thieu, VuaDu, Du,All0;
                Het = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "HET", Commons.Modules.TypeLanguage);
                Thieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "Thieu", Commons.Modules.TypeLanguage);
                VuaDu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "VuaDu", Commons.Modules.TypeLanguage);
                Du = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "Du", Commons.Modules.TypeLanguage);
                All0 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "All0", Commons.Modules.TypeLanguage);
                dtLuoi = new DataTable();
                if (Commons.Modules.sPrivate == "CS")
                    dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTinhHinhTonKhoCS", cboKho.EditValue,
                        cboLVTu.EditValue, cboClass.EditValue, Commons.Modules.TypeLanguage, Het, Thieu, VuaDu, Du, All0, Commons.Modules.UserName));
                else
                    dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetTinhHinhTonKho", cboKho.EditValue,
                        cboLVTu.EditValue, cboClass.EditValue, Commons.Modules.TypeLanguage, Het, Thieu, VuaDu, Du, All0));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtLuoi, false, false, false, false);
                Commons.Modules.SQLString = "0Load";
                chkHet.Checked = true;
                chkThieu.Checked = true;
                chkVuaDu.Checked = true;
                chkDu.Checked = true;
                Commons.Modules.SQLString = "";
                try
                {
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTinhHinhTonKho", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvChung.RowCount.ToString() + "   ";
                }
                catch { lblTVT.Text = ""; }
            }
            catch { }
            Commons.Modules.SQLString = "";
            LocDK();
        }

        private void cboKho_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboLVTu_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboClass_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grvChung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                {
                    if (col.Name == "colTT")
                    {
                        if (e.RowHandle >= 0)
                        {
                            int TT;
                            TT = int.Parse(view.GetRowCellDisplayText(e.RowHandle, col));
                            switch (TT)
                            {
                                case 0:
                                    e.Appearance.BackColor = Color.Tomato;
                                    break;
                                case 1:
                                    e.Appearance.BackColor = Color.Yellow;
                                    if (view.FocusedRowHandle == e.RowHandle)
                                        e.Appearance.ForeColor = Color.Black;               //BackColor = Color.Brown;
                                    break;
                                case 2:
                                    e.Appearance.BackColor = Color.FromArgb(0, 176, 80);
                                    break;
                                case 3:
                                    e.Appearance.BackColor = Color.FromArgb(155, 187, 89);
                                    break;
                                case 4:
                                    e.Appearance.BackColor = Color.LightSkyBlue;
                                    break;
                            }                            
                        }
                    }

                }
            }
            catch { }
        }

        private void chkHet_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkThieu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkVuaDu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkDu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void LocDK()
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;

                string sql = "";
                try
                {
                    if (chkHet.Checked)
                    {
                        sql += " OR TT = 0 ";
                    }
                    if (chkThieu.Checked)
                    {
                        sql += " OR TT = 1 ";
                    }
                    if (chkVuaDu.Checked)
                    {
                        sql += " OR TT = 2 ";
                    }
                    if (chkDu.Checked)
                    {
                        sql += " OR TT = 3 ";
                    }
                    if (chkTonMinMax0.Checked)
                    {
                        sql += " OR TT = 4 ";
                    }
                    if (sql == "")
                        sql = " TT = -1";
                    else
                        sql = sql.Substring(4, sql.Length - 4);

                    sql = "( " + sql + ")";

                    string dk = "";


                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_CTY LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (dk.Length > 0) dk = "( " + dk.Substring(5, dk.Length - 5) + ")";



                    //if (sql.Length > 0 && dk.Length <= 0)
                    //    sql = sql;

                    if (sql.Length <= 0 && dk.Length > 0)
                        sql = dk;

                    if (sql.Length > 0 && dk.Length > 0)
                        sql = sql + " AND " + dk;

                    if (sql.Length <= 0 && dk.Length <= 0)
                        sql = "";

                    //if (txtTKiem.Text != "") sql += " 
                }
                catch { sql = ""; }
                dtLuoi.DefaultView.RowFilter = sql;
                try
                {
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTinhHinhTonKho", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvChung.RowCount.ToString() + "   ";
                }
                catch { lblTVT.Text = ""; }
            }
            catch { }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDK();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            InDuLieu();
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        
        private Boolean KiemDLieu()
        {

            if (cboKho.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return false;
            }

            if (cboLVTu.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoLoaiVatTu", Commons.Modules.TypeLanguage));
                cboLVTu.Focus();
                return false;
            }
            if (cboClass.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoClass", Commons.Modules.TypeLanguage));
                cboClass.Focus();
                return false;
            }
            if (grvChung.RowCount ==0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return false;
            }
            return true;
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count-1;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                int SCot;

                SCot = 7;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : SCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                string stmp = "";
                stmp = lblKho.Text + " : " + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblLVTu.Text + " : " + cboLVTu.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = lblClass.Text + " : " + cboClass.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong++;
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //13	30	20	20	30	14	9	9	9	9	8	15


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "#,##0.00", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "#,##0.00", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "#,##0.00", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "#,##0", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 12, TDong + Dong, 12);
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                excelWorkbook.Save();
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnThayThe_Click(object sender, EventArgs e)
        {
            if (grvChung.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoPhuTung", Commons.Modules.TypeLanguage));
                return;
            }
            if (grvChung.GetFocusedDataRow()["MS_PT"].ToString() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "KhongCoPhuTung", Commons.Modules.TypeLanguage));
                return;
            }
            frmTinhHinhTonKhoThayThe frm = new frmTinhHinhTonKhoThayThe();
            frm._sMsPT = grvChung.GetFocusedDataRow()["MS_PT"].ToString();
            frm.ShowDialog();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }


        

    }
}