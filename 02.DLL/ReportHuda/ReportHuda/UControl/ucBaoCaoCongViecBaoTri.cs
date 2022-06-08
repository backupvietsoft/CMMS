using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace ReportHuda
{
    public partial class ucBaoCaoCongViecBaoTri : DevExpress.XtraEditors.XtraUserControl
    {
        string sBaoTriChung = "";
        string sBC = "ucBaoCaoCongViecBaoTri";

        public ucBaoCaoCongViecBaoTri()
        {
            InitializeComponent();
        }
        #region Load Du Lieu




        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 0)
            {
                cboDonVi.Properties.ReadOnly = false;
                cboPhongBan.Properties.ReadOnly = false;

                cboDChuyen.ReadOnly = false;
                cboDDiem.ReadOnly = false;
                cboLMay.Properties.ReadOnly = false;
                cboLBTri.Properties.ReadOnly = false;
            }


            if (optBCao.SelectedIndex == 1 || optBCao.SelectedIndex == 2)
            {
                cboDonVi.Properties.ReadOnly = true;
                cboPhongBan.Properties.ReadOnly = true;

                cboDChuyen.ReadOnly = false;
                cboDDiem.ReadOnly = false;
                cboLMay.Properties.ReadOnly = false;
                cboLBTri.Properties.ReadOnly = false;
            }
            if (optBCao.SelectedIndex == 3)
            {
                cboDChuyen.ReadOnly = true;
                cboDDiem.ReadOnly = true;
                cboLMay.Properties.ReadOnly = true;
                cboLBTri.Properties.ReadOnly = true;

                cboDonVi.Properties.ReadOnly = false;
                cboPhongBan.Properties.ReadOnly = false;
            }
        }
        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
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
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 1, cboDonVi.EditValue, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhongBan, _table, "MS_PB", "TEN_PB", lblPhongBan.Text);
            }
            catch { }
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhongBan();
        }
        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");

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

        private void LoadLoaiBT()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiBaoTri"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0DD") return;
            if (Commons.Modules.SQLString == "0DC") return;
            if (Commons.Modules.SQLString == "0LM") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2000"); }
                
                
                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.TextValue == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }
                try
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();

                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetMayNXuongHThongLMay", Commons.Modules.UserName, NXuong, HThong, -1, LMay, "-1", "-1",
                        DNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "1";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);

                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, true, sBC);

                for (int i = 1; i <= grvMay.Columns.Count - 1; i++)
                {
                    grvMay.Columns[i].Visible = false;
                    dtMay.Columns[i].ReadOnly = true;
                }


                



                grvMay.Columns["MS_MAY"].Visible = true;
                grvMay.Columns["TEN_NHOM_MAY"].Visible = true;
                grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
                grvMay.Columns["TEN_HE_THONG"].Visible = true;
                grvMay.Columns["Ten_N_XUONG"].Visible = true;
                grvMay.Columns["TEN_MAY"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void ucKeHoachCongViecBaoTri_Load(object sender, EventArgs e)
        {
            //lblIconLinkVideo.ActiveLinkColor = Color.Orange;
            //lblIconElearning.VisitedLinkColor = Color.Green;
            //lblIconElearning.LinkColor = Color.RoyalBlue;
            //lblIconElearning.DisabledLinkColor = Color.Gray;
            //linkLabel1.Text = "Click here to get more info.";
            //linkLabel1.Links.Add(6, 4, "www.microsoft.com");

            sBaoTriChung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "BaoTriChung", Commons.Modules.TypeLanguage);

            Commons.Modules.SQLString = "0Load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay;
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            optTuychon.SelectedIndex = 0;
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiBT();
            Commons.Modules.SQLString = "";
            LoadMay();
            LoadDonVi();
            grdChung.Visible = false;
            grdTmp.Visible = false;
            
            //stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
            //    sBC, "bcThongTinKeHoach", Commons.Modules.TypeLanguage);
            optBCao.Properties.Items[0].Description= Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                sBC, optBCao.Properties.Items[0].Value.ToString(), Commons.Modules.TypeLanguage);

            optBCao.Properties.Items[1].Description = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                sBC, optBCao.Properties.Items[1].Value.ToString(), Commons.Modules.TypeLanguage);

        }
        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }


        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datDNgay.DateTime < datTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                datDNgay.Focus();
                return;
            }
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = ((DataTable)grdMay.DataSource).Copy();
                if (optBCao.SelectedIndex != 3)
                {
                    dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
                    if (dtTmp.DefaultView.ToTable().Rows.Count == 0 && int.Parse(cboLBTri.EditValue.ToString()) != -2)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgChuaChonMay", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
                else { 
                }
                string sBTam;
                sBTam = "MAY_CV_BT_TMP" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");

                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 999999;
                cmd.CommandText = "spBaoCaoCongViecBaoTri";
                cmd.Parameters.Add(new SqlParameter("@MayTmp", sBTam));
                cmd.Parameters.Add(new SqlParameter("@MsLBTri", cboLBTri.EditValue));
                cmd.Parameters.Add(new SqlParameter("@TenLBTri", sBaoTriChung));
                cmd.Parameters.Add(new SqlParameter("@TNgay", datTNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@DNgay", datDNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@NNgu", Commons.Modules.TypeLanguage));
                cmd.Parameters.Add(new SqlParameter("@MSDV", cboDonVi.EditValue));
                cmd.Parameters.Add(new SqlParameter("@MSTO", cboPhongBan.EditValue));
                cmd.Parameters.Add(new SqlParameter("@iLoaiBC", optBCao.SelectedIndex));
                cmd.Parameters.Add(new SqlParameter("@KHTT", optBCao.Properties.Items[1].Description));
                cmd.Parameters.Add(new SqlParameter("@PBT", optBCao.Properties.Items[2].Description));
                cmd.Parameters.Add(new SqlParameter("@CVC", optBCao.Properties.Items[3].Description));
                cmd.Parameters.Add(new SqlParameter("@iTuyChonCV", optTuychon.SelectedIndex));
                cmd.Parameters.Add(new SqlParameter("@UserName", Commons.Modules.UserName));
                try
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(cmd.ExecuteReader());
                }
                catch 
                {}

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), sBC);
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, sBC);

                DataTable dtn = dtTmp.Clone();
                //dtn.ImportRow(dtTmp.Rows[0]);

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTmp, grvTmp, dtn, false, true, true, true, true, sBC);
                this.Cursor = Cursors.WaitCursor;

                InDuLieu();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }

        }
        private void InDuLieuRE()
        {
            string sPath = "";
            string sDinhDang = "";
            if (Commons.Modules.iPBTTheoGio == 0)
                sDinhDang = "#,##0.00";
            else
                sDinhDang = "#,##0";

            DataTable dtTmp = new DataTable();
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;


            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
           
            try
            {
                int TCot = grvChung.Columns.Count - 6;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                dtTmp = (DataTable)grdChung.DataSource;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 35 + dtTmp.Rows.Count;
                prbIN.Properties.Minimum = 0;
                
                grvTmp.ExportToXlsx(sPath);


         
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "BCChiTiet";

                if (Commons.Modules.bDoiFontReport)
                    xlApp.Cells.Font.Name = Commons.Modules.sFontReport;

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, grvChung.RowCount + 2, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);
                //xlApp.Visible = true;
                
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                ((Excel.Range)xlWorkSheet.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTieuDeBaoCaoCongViecBaoTri", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                stmp = "'----o0o----";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                //'----o0o----
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                Dong++;
 
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot+6);
                //title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Format
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);



                for (int i = 1; i <= 7; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, i, Dong , i);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 8, Dong - 1, 11);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcThongTinKeHoach", Commons.Modules.TypeLanguage);
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;                
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 12, Dong - 1, 21);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcThongTinThucHien", Commons.Modules.TypeLanguage);
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 22, Dong, 22);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 23, Dong, 23);
                title.MergeCells = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 4);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 5, TDong + Dong, 6);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 40, sDinhDang, true, Dong + 1, 7, TDong + Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "0.00%", true, Dong + 1, 8, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong + 1, 8, TDong + Dong, 9);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 10, TDong + Dong, 11);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 12, TDong + Dong, 12);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 12, TDong + Dong, 12);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; 
                title.ColumnWidth = 10;
                title.NumberFormat = "@";
                title.WrapText = true;
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong + 1, 13, TDong + Dong, 14);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "@", true, Dong + 1, 15, TDong + Dong, 15);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 16, TDong + Dong, 16);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 17, TDong + Dong, 18);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 19, TDong + Dong, 25);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong + 1, 20, TDong + Dong, 20);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "0.00%", true, Dong + 1, 21, TDong + Dong, 21);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 22, TDong + Dong, 22);
                #endregion


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, TDong + Dong - 1, 1);
                
                MergeDuLieu(xlWorkSheet, title, prbIN,dtTmp);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Sum
                //xlApp.Visible = true;
                Dong = Dong + TDong +1;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                int iCotSum = 8;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 9;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                iCotSum = 13;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 14;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 20;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                iCotSum = 29;
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                    iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 28;
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                    iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - TDong, 1, Dong - TDong, TCot);
                title.RowHeight = 40;
                //xlApp.Visible = true;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, Dong, TCot);
                title.Borders.LineStyle = 1;

                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkBook.Sheets.Add(System.Reflection.Missing.Value,xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value);

                xlWorkSheet.Move(System.Reflection.Missing.Value, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);

                Excel.Worksheet xlWSheet2 = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWSheet2.Name= "BCTongHop";
                xlWSheet2.Activate();


                int iDongTH = 2;
                int iCotTH = 2;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region TieuDe
                           
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongHop", Commons.Modules.TypeLanguage);
                //Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH-1, iCotTH, "@", 12, true, 
                //    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, iDongTH, iCotTH + 2);

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH, iCotTH + 2);
                title.Value2 = stmp;
                title.MergeCells = true;


                string sSp, sSL;
                iCotTH = iCotTH + 3;
                sSp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViec", Commons.Modules.TypeLanguage);
                sSL = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoLuongCongViec", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcKeHoach", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 1);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH-1, iCotTH + 1);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(146, 208, 80));


                
                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViecKH", Commons.Modules.TypeLanguage), iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcHoanThanh", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 4);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH-1, iCotTH + 4);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 192, 218));


                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViecTT", Commons.Modules.TypeLanguage), iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                
                iCotTH++;                
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);



                iCotTH++;

                string sPTSp, sPTSL;
                sPTSp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcPTSoPhutCongViec", Commons.Modules.TypeLanguage);
                sPTSL = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcPTSoLuongCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcChuaHoanThanh", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 3);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH - 1, iCotTH + 3);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, 1, iDongTH - 1, iCotTH);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.ColumnWidth = 15;                
                title.WrapText = true;


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH , 1, iDongTH , iCotTH);
                title.RowHeight = 30;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title. WrapText = true;
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, iDongTH, 1, iDongTH, iCotTH);
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                iDongTH++;
                iCotTH = 2;
#region Tao Du Lieu
                #region Dong 1


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcBaoTriCoKH", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);



                #region Dinh Muc
                iCotTH = iCotTH + 3;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13);
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                #endregion

                #region Thuc te
                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + "-" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 13);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    //=COUNT(BCChiTiet!M14:M348)
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong, 24) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 24) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    //=G3/E3
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%"; 
                }
                catch { }
                

                iCotTH++;
                try
                {
                    //=H3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion

                #region Chua Thuc hien
                iCotTH++;
                try
                {
                    //E3-G3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 28);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong, 28) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 28) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                iCotTH++;
                try
                {
                    //=K3/E3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    //==L3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion



                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 2

                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcBaoTriNgoaiKH", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);

                #region Dinh Muc
                iCotTH = iCotTH + 3;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 9);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                #endregion

                #region Thuc te

                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + "-" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 14);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong , 25) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 25) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    //=G4/E4
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                iCotTH++;
                try
                {
                    //=H4/F4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion

                #region Chua Hoan Thanh



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 29);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong , 29) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 29) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0"; ;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0,"   + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                iCotTH++;
                try
                {
                    //=H4/F4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion


                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 3
                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, iDongTH, iCotTH + 2);


                #region Dinh muc
                iCotTH = iCotTH + 3;
                try
                {
                    //=E3+E4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0"; 
                }
                catch { }

                #endregion

                #region Thuc Te
                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0"; 
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion

                #region Chua Hoan Thanh

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                iCotTH++;
                try
                {
                    //=K3/E3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    //==L3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13)  + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 4

                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTGNgungMayDoSuCo", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);

                iCotTH = iCotTH + 3;
                
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 20);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

#endregion
                //Global.Commons.My.Resources.Resources.Import
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                #region Format TH

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 2, iDongTH, 15);
                title.Borders.LineStyle = 1;

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                                "bcNgayThangNam", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                                "bcLapKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                try
                {
                    Dong = Dong + 4;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.sTenNhanVienMD, Dong, 6, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                }
                catch { }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //xlApp.Visible = true;
                //title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 7, 1, 7);
                //title.EntireColumn.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight);



                string sBTCoKH = "";
                string sBTNgoaiKH = "";

                iDongTH = iDongTH + 6;
                iCotTH = 7;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoPhut", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                iCotTH++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iDongTH++;
                iCotTH = 6;
                sBTCoKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "bcCongViecBaoTriSuaChuaCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH , iCotTH);


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }






                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iDongTH++;
                iCotTH = 6;
                sBTNgoaiKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcCongViecBaoTriSuaChuaNgoaiCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }







                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iDongTH++;
                iCotTH = 6;

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iDongTH++;
                iCotTH = 6;

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                //Thực tế
                //-----------

                iDongTH++;
                iCotTH = 7;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoPhut", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                iCotTH++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iDongTH++;
                iCotTH = 6;
                string sBTCoKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCongViecBaoTriSuaChuaCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKHTT, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 5);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 6);
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                //----------

                iDongTH++;
                iCotTH = 6;
                string sBTNgoaiKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCongViecBaoTriSuaChuaNgoaiCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKHTT, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 5);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 6);
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                //--------------


                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 9, 1, 9, 1);
                double iTop, iLeft;
                iTop = double.Parse(title.Top.ToString());
                iLeft = double.Parse(title.Top.ToString()) - 57.5;
                //chart.TopLeftCell = worksheet.Cells["E2"];
                //chart.BottomRightCell = worksheet.Cells["K15"];

                #region Tao Chart

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 1
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)xlWSheet2.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, 350, 300);
                Excel.Chart xlChart = chartObj.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 17, 6, 19, 8);
                xlChart.SetSourceData(title, Type.Missing);
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked100;
                xlChart.HasTitle = true;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCharTitle1", Commons.Modules.TypeLanguage);
                xlChart.ChartTitle.Text = stmp;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);
                Microsoft.Office.Interop.Excel.Axis vertAxis = (Microsoft.Office.Interop.Excel.Axis)xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                vertAxis.MinimumScaleIsAuto = false;
                vertAxis.MinimumScale = 0;
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 2

                Excel.ChartObject chartObj1 = chartObjs.Add(chartObjs.Left + chartObjs.Width, chartObjs.Top, chartObjs.Width, chartObjs.Height);
                Excel.Chart xlChart1 = chartObj1.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 13, 6, 14, 7);
                xlChart1.SetSourceData(title, Type.Missing);
                xlChart1.ChartType = Excel.XlChartType.xlPie;
                xlChart1.HasTitle = true;
                xlChart1.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcCharTitle2", Commons.Modules.TypeLanguage);
                xlChart1.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart1.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);

                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 3


                Excel.ChartObject chartObj2 = chartObjs.Add(chartObj1.Left + chartObj1.Width, chartObjs.Top, chartObjs.Width, chartObjs.Height);
                Excel.Chart xlChart2 = chartObj2.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 15, 6, 16, 7);
                xlChart2.SetSourceData(title, Type.Missing);
                xlChart2.ChartType = Excel.XlChartType.xlPie;
                xlChart2.HasTitle = true;
                xlChart2.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcCharTitle3", Commons.Modules.TypeLanguage);
                xlChart2.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart2.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 23, 1, 29);
                title.ColumnWidth = 0;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 13, 1, Dong, 24);
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 23, 14 + TDong, 23);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, 12, 1);
                title.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, 12, 1);
                title.RowHeight = 9;


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 1, 1, 1);
                title.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                if (Commons.Modules.sPrivate == "VIETROLL")
                {
                    Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 2, 1);
                    Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 sBC, "bcTieuDeBaoCaoTongCongViecBaoTri", Commons.Modules.TypeLanguage), 2, 2, "@", 16, true,
                 Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 2, 14);
                }

                if (Commons.Modules.sPrivate == "REMINGTON")
                {
                    //xlApp.Visible = true;
                    //Them cloai bao cao cho ben REL
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, 12);
                    stmp = lblLoaiBCao.Text + " : " + optBCao.Properties.Items[optBCao.SelectedIndex].Description.ToString();
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 12, 2, "@", 10, true, true, 12, 4);

                    //them logo sheet1
                    //Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, 1);
                    Dong = Commons.Modules.MExcel.TaoTTChung(xlWSheet2, 1, 3, 1, 15);
                    Commons.Modules.MExcel.TaoLogo(xlWSheet2, 0, 0, 110, 45, Application.StartupPath);


                    Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 sBC, "bcTieuDeBaoCaoTongCongViecBaoTri", Commons.Modules.TypeLanguage), 5, 2, "@", 16, true,
                 Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 5, 15);

                }
                xlWorkBook.Save();
                xlApp.Visible = true;


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
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
        }

        private void InDuLieu()
        {
            string sPath = "";
            string sDinhDang = "";
            if (Commons.Modules.iPBTTheoGio == 0)
                sDinhDang = "#,##0.00";
            else
                sDinhDang = "#,##0";

            DataTable dtTmp = new DataTable();
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;


            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
           
            try
            {
                int TCot = grvChung.Columns.Count - 6;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                dtTmp = (DataTable)grdChung.DataSource;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 35 + dtTmp.Rows.Count;
                prbIN.Properties.Minimum = 0;
                
                grvTmp.ExportToXlsx(sPath);
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "BCChiTiet";

                if (Commons.Modules.bDoiFontReport)
                    xlApp.Cells.Font.Name = Commons.Modules.sFontReport;

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, grvChung.RowCount + 2, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);
                //xlApp.Visible = true;
                
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                ((Excel.Range)xlWorkSheet.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTieuDeBaoCaoCongViecBaoTri", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                stmp = "'----o0o----";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                //'----o0o----
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = lblLBaoTri.Text + " : " + cboLBTri.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);

                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot+6);
                //title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Format
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 2, Dong, 2);
                for (int i = 1; i <= 7; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, i, Dong , i);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                }

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 8, Dong - 1, 11);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcThongTinKeHoach", Commons.Modules.TypeLanguage);
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;                
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 12, Dong - 1, 21);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcThongTinThucHien", Commons.Modules.TypeLanguage);
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 22, Dong, 22);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 23, Dong, 23);
                title.MergeCells = true;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 4);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 5, TDong + Dong, 6);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 40, sDinhDang, true, Dong + 1, 7, TDong + Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "0.00%", true, Dong + 1, 8, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong + 1, 8, TDong + Dong, 9);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong + 1, 10, TDong + Dong, 11);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 12, TDong + Dong, 12);
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 1, 12, TDong + Dong, 12);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; 
                title.ColumnWidth = 10;
                title.NumberFormat = "@";
                title.WrapText = true;
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong, 13,  Dong, 14);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "@", true, Dong , 15,  Dong, 15);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong , 16,  Dong, 16);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 11, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, Dong , 17,  Dong, 18);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong , 19,  Dong, 25);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, Dong , 20,  Dong, 20);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "0.00%", true, Dong , 21,  Dong, 21);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong , 22,  Dong, 22);

                

                #endregion


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, TDong + Dong - 1, 1);
                
                MergeDuLieu(xlWorkSheet, title, prbIN,dtTmp);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Sum
                //xlApp.Visible = true;
                Dong = Dong + TDong +1;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);

                int iCotSum = 8;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 9;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);
                iCotSum = 13;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 14;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 20;
                    Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                        iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                iCotSum = 29;
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                    iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);

                iCotSum = 28;
                Commons.Modules.MExcel.MFuntion(xlWorkSheet, "SUM", Dong, iCotSum, Dong, iCotSum, Dong - TDong,
                    iCotSum, Dong - 1, iCotSum, 10, true, 12, sDinhDang, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - TDong, 1, Dong - TDong, TCot);
                title.RowHeight = 40;
                //xlApp.Visible = true;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, Dong, TCot);
                title.Borders.LineStyle = 1;

                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkBook.Sheets.Add(System.Reflection.Missing.Value,xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value);

                xlWorkSheet.Move(System.Reflection.Missing.Value, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);

                Excel.Worksheet xlWSheet2 = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWSheet2.Name= "BCTongHop";
                xlWSheet2.Activate();


                int iDongTH = 2;
                int iCotTH = 2;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region TieuDe
                           
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongHop", Commons.Modules.TypeLanguage);
                //Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH-1, iCotTH, "@", 12, true, 
                //    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, iDongTH, iCotTH + 2);

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH, iCotTH + 2);
                title.Value2 = stmp;
                title.MergeCells = true;


                string sSp, sSL;
                iCotTH = iCotTH + 3;
                sSp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViec", Commons.Modules.TypeLanguage);
                sSL = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoLuongCongViec", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcKeHoach", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 1);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH-1, iCotTH + 1);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(146, 208, 80));


                
                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViecKH", Commons.Modules.TypeLanguage), iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcHoanThanh", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 4);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH-1, iCotTH + 4);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 192, 218));


                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcSoPhutCongViecTT", Commons.Modules.TypeLanguage), iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                
                iCotTH++;                
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);



                iCotTH++;

                string sPTSp, sPTSL;
                sPTSp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcPTSoPhutCongViec", Commons.Modules.TypeLanguage);
                sPTSL = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcPTSoLuongCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcChuaHoanThanh", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH - 1, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH - 1, iCotTH + 3);
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, iCotTH, iDongTH - 1, iCotTH + 3);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sPTSL, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH - 1, 1, iDongTH - 1, iCotTH);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.ColumnWidth = 15;                
                title.WrapText = true;


                title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH , 1, iDongTH , iCotTH);
                title.RowHeight = 30;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title. WrapText = true;
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, iDongTH, 1, iDongTH, iCotTH);
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                iDongTH++;
                iCotTH = 2;
#region Tao Du Lieu
                #region Dong 1


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcBaoTriCoKH", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);



                #region Dinh Muc
                iCotTH = iCotTH + 3;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13);
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                #endregion

                #region Thuc te
                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + "-" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 13);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    //=COUNT(BCChiTiet!M14:M348)
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong, 24) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 24) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    //=G3/E3
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%"; 
                }
                catch { }
                

                iCotTH++;
                try
                {
                    //=H3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion

                #region Chua Thuc hien
                iCotTH++;
                try
                {
                    //E3-G3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 28);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong, 28) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 28) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                iCotTH++;
                try
                {
                    //=K3/E3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    //==L3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion



                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 2

                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcBaoTriNgoaiKH", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);

                #region Dinh Muc
                iCotTH = iCotTH + 3;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 9);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                #endregion

                #region Thuc te

                iCotTH++;
                try
                {
                    //=BCChiTiet!M349
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + "-" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 14);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong , 25) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 25) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0";
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    //=G4/E4
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                iCotTH++;
                try
                {
                    //=H4/F4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ">0, " + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion

                #region Chua Hoan Thanh



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 29);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=COUNT(" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong - TDong , 29) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 29) + ")";
                    title.Value2 = stmp;
                    title.NumberFormat = "#,##0"; ;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0,"   + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                iCotTH++;
                try
                {
                    //=H4/F4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";                    
                    title.Value2 = stmp;
                    title.NumberFormat = "0.00%";
                }
                catch { }
                #endregion


                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 3
                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTongCong", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, iDongTH, iCotTH + 2);


                #region Dinh muc
                iCotTH = iCotTH + 3;
                try
                {
                    //=E3+E4
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0"; 
                }
                catch { }

                #endregion

                #region Thuc Te
                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }



                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0"; 
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 8) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 9) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion

                #region Chua Hoan Thanh

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 2, iCotTH) + "+" + Commons.Modules.MExcel.TimDiemExcel(iDongTH - 1, iCotTH) + "";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "#,##0";
                }
                catch { }

                iCotTH++;
                try
                {
                    //=K3/E3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 12) + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 5) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }

                iCotTH++;
                try
                {
                    //==L3/F3
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + " > 0," + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 13)  + "/" + Commons.Modules.MExcel.TimDiemExcel(iDongTH, 6) + ",0)";
                    title.Value2 = stmp;
                    title.Font.Bold = true;
                    title.NumberFormat = "0.00%";
                }
                catch { }


                #endregion
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Dong 4

                iDongTH++;
                iCotTH = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcTGNgungMayDoSuCo", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH + 2);

                iCotTH = iCotTH + 3;
                
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    stmp = "=" + xlWorkSheet.Name.ToString() + "!" + Commons.Modules.MExcel.TimDiemExcel(Dong, 20);
                    title.Value2 = stmp;
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

#endregion
                //Global.Commons.My.Resources.Resources.Import
                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                #region Format TH

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 2, iDongTH, 15);
                title.Borders.LineStyle = 1;

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                                "bcNgayThangNam", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                                "bcLapKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                try
                {
                    Dong = Dong + 4;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.sTenNhanVienMD, Dong, 6, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                }
                catch { }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //xlApp.Visible = true;
                //title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 7, 1, 7);
                //title.EntireColumn.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight);



                string sBTCoKH = "";
                string sBTNgoaiKH = "";

                iDongTH = iDongTH + 6;
                iCotTH = 7;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoPhut", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                iCotTH++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iDongTH++;
                iCotTH = 6;
                sBTCoKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "bcCongViecBaoTriSuaChuaCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH , iCotTH);


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }






                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iDongTH++;
                iCotTH = 6;
                sBTNgoaiKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "bcCongViecBaoTriSuaChuaNgoaiCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 8);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }







                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iDongTH++;
                iCotTH = 6;

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                iDongTH++;
                iCotTH = 6;

                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKH, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 9);
                    title.NumberFormat = sDinhDang;
                }
                catch { }

                //Thực tế
                //-----------

                iDongTH++;
                iCotTH = 7;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoPhut", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                iCotTH++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            sBC, "sTheoSoCongViec", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, stmp, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);


                iDongTH++;
                iCotTH = 6;
                string sBTCoKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCongViecBaoTriSuaChuaCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTCoKHTT, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);
                                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 5);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(3, 6);
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                //----------

                iDongTH++;
                iCotTH = 6;
                string sBTNgoaiKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCongViecBaoTriSuaChuaNgoaiCoKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWSheet2, sBTNgoaiKHTT, iDongTH, iCotTH, "@", 11, true,
                    Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, false, iDongTH, iCotTH);

                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 5);
                    title.NumberFormat = sDinhDang;
                }
                catch { }


                iCotTH++;
                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, iDongTH, iCotTH, iDongTH, iCotTH);
                    title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(4, 6);
                    title.NumberFormat = sDinhDang;
                }
                catch { }
                //--------------


                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 9, 1, 9, 1);
                double iTop, iLeft;
                iTop = double.Parse(title.Top.ToString());
                iLeft = double.Parse(title.Top.ToString()) - 57.5;
                //chart.TopLeftCell = worksheet.Cells["E2"];
                //chart.BottomRightCell = worksheet.Cells["K15"];

                #region Tao Chart

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 1
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)xlWSheet2.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, 350, 300);
                Excel.Chart xlChart = chartObj.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 17, 6, 19, 8);
                xlChart.SetSourceData(title, Type.Missing);
                xlChart.ChartType = Excel.XlChartType.xlColumnStacked100;
                xlChart.HasTitle = true;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                       sBC, "bcCharTitle1", Commons.Modules.TypeLanguage);
                xlChart.ChartTitle.Text = stmp;
                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);
                Microsoft.Office.Interop.Excel.Axis vertAxis = (Microsoft.Office.Interop.Excel.Axis)xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                vertAxis.MinimumScaleIsAuto = false;
                vertAxis.MinimumScale = 0;
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 2

                Excel.ChartObject chartObj1 = chartObjs.Add(chartObjs.Left + chartObjs.Width, chartObjs.Top, chartObjs.Width, chartObjs.Height);
                Excel.Chart xlChart1 = chartObj1.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 13, 6, 14, 7);
                xlChart1.SetSourceData(title, Type.Missing);
                xlChart1.ChartType = Excel.XlChartType.xlPie;
                xlChart1.HasTitle = true;
                xlChart1.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
       sBC, "bcCharTitle2", Commons.Modules.TypeLanguage);
                xlChart1.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart1.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);

                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #region Char 3


                Excel.ChartObject chartObj2 = chartObjs.Add(chartObj1.Left + chartObj1.Width, chartObjs.Top, chartObjs.Width, chartObjs.Height);
                Excel.Chart xlChart2 = chartObj2.Chart;
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 15, 6, 16, 7);
                xlChart2.SetSourceData(title, Type.Missing);
                xlChart2.ChartType = Excel.XlChartType.xlPie;
                xlChart2.HasTitle = true;
                xlChart2.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "bcCharTitle3", Commons.Modules.TypeLanguage);
                xlChart2.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                xlChart2.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false);
                #endregion

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 23, 1, 29);
                title.ColumnWidth = 0;


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 13, 1, Dong, 24);
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 23, 14 + TDong, 23);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, 12, 1);
                title.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 1, 12, 1);
                title.RowHeight = 9;

                
                title = Commons.Modules.MExcel.GetRange(xlWSheet2, 1, 1, 1, 1);
                title.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                if (Commons.Modules.sPrivate == "VIETROLL")
                {

                    Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 2, 1);
                    Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 sBC, "bcTieuDeBaoCaoTongCongViecBaoTri", Commons.Modules.TypeLanguage), 2, 2, "@", 16, true,
                 Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 2, 14);
                }
                if (Commons.Modules.sPrivate == "REMINGTON")
                {
                    //xlApp.Visible = true;
                    //Them cloai bao cao cho ben REL
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, 12);
                    stmp = lblLoaiBCao.Text + " : " + optBCao.Properties.Items[optBCao.SelectedIndex].Description.ToString();
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, 12, 2, "@", 10, true, true, 12, 4);

                    //them logo sheet1
                    //Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, 1);
                    Dong = Commons.Modules.MExcel.TaoTTChung(xlWSheet2, 1, 3, 1, 15);
                    Commons.Modules.MExcel.TaoLogo(xlWSheet2, 0, 0, 110, 45, Application.StartupPath);


                    Commons.Modules.MExcel.DinhDang(xlWSheet2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 sBC, "bcTieuDeBaoCaoTongCongViecBaoTri", Commons.Modules.TypeLanguage), 5, 2, "@", 16, true,
                 Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 5, 15);

                    Commons.Modules.MExcel.ThemDong(xlWSheet2, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, 6);
                    title = Commons.Modules.MExcel.GetRange(xlWSheet2, 6, 1, 6, 1);
                    title.RowHeight = 9;
                }
                xlWorkBook.Save();
                xlApp.Visible = true;
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
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
        }

        private void MergeDuLieu(Excel.Worksheet xlWorkSheet, Excel.Range title, DevExpress.XtraEditors.ProgressBarControl prbIN, DataTable dtIn)
        {

            int i;
            try
            {
                for (i = 14; i <= title.Rows.Count - 1 + 13; i++)
                {
                    string sDL1 = "";
                    try
                    {
                        sDL1 = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 23, i, 23).Value2.ToString().ToUpper();
                    }
                    catch { sDL1 = "1"; }
                    if (int.Parse(sDL1) == 1)
                    {
                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion  
                    }
                    else
                    {

                        Excel.Range Rng;
                        DataTable dtTmp = new DataTable();
                        dtTmp = dtIn.Copy();
                        try
                        {
                            sDL1 = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 15, i, 15).Value2.ToString().ToUpper();
                            //if (sDL1 == "WO-201604000428")
                            //{ sDL1 = sDL1; }
                        }
                        catch { sDL1 = "1"; }
                        try
                        {
                            dtTmp.DefaultView.RowFilter = "MS_PBT = '" + sDL1 + "' ";
                            sDL1 = dtTmp.DefaultView.ToTable().Rows.Count.ToString();
                        }
                        catch { sDL1 = "1"; }
                        
                        for (int k = 10; k <= 22; k++)
                        {
                            Rng = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, k], xlWorkSheet.Cells[i + int.Parse(sDL1) - 1, k]);
                            Rng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            Rng.MergeCells = true;
                        }
                        //for (int k = 28; k <= 29; k++)
                        //{
                        //    Rng = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, k], xlWorkSheet.Cells[i + int.Parse(sDL1) - 1, k]);
                        //    Rng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        //    Rng.MergeCells = true;
                        //}
                        prbIN.Position = prbIN.Position + int.Parse(sDL1);

                        i = i + int.Parse(sDL1) - 1;

                    }





                    //if (iDongLuu == -1) iDongLuu = i;


                    //try
                    //{
                    //    string sDL1, sDL2;
                    //    sDL1 = sDL2 = "";
                    //    try
                    //    {
                    //        sDL1 = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, iCotMerge, i, iCotMerge).Value2.ToString().ToUpper();
                    //    }
                    //    catch { sDL1 = ""; }
                    //    try
                    //    {
                    //        sDL2 = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 1, iCotMerge, i + 1, iCotMerge).Value2.ToString().ToUpper();
                    //    }
                    //    catch { sDL2 = ""; }

                    //    if (sDL1 != sDL2 && sDL1 != "" && sDL2 != "")
                    //    {
                    //        Excel.Range Rng;

                    //        for (int k = 14; k <= 21; k++)
                    //        {
                    //            Rng = xlWorkSheet.get_Range(xlWorkSheet.Cells[iDongLuu, k], xlWorkSheet.Cells[i, k]);
                    //            Rng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //            Rng.MergeCells = true;
                    //        }


                    //        for (int k = 10; k <= 12; k++)
                    //        {
                    //            Rng = xlWorkSheet.get_Range(xlWorkSheet.Cells[iDongLuu, k], xlWorkSheet.Cells[i, k]);
                    //            Rng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //            Rng.MergeCells = true;
                    //        } iDongLuu = i + 1;
                    //    }
                    //    else
                    //        if (sDL1 == "" && sDL2 != "") iDongLuu = i + 1;
                    //}
                    //catch 
                    //{
                    //    iDongLuu = i + 1;
                    //}
                  
                }

            }
            catch 
            {
               // MessageBox.Show(ex.Message);
            }
        }

    }
}