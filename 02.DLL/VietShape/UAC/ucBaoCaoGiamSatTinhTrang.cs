using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
namespace VietShape
{
    public partial class ucBaoCaoGiamSatTinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        private string currentMonth = DateTime.Now.Month.ToString() + ".1";
        public ucBaoCaoGiamSatTinhTrang()
        {
            InitializeComponent();
            optLoaiTS.SelectedIndex = 0;
        }
        private void ucBaoCaoGiamSatTinhTrang_Load(object sender, EventArgs e)
        {
            try
            {
                datTNam.DateTime = DateTime.Now;
                Commons.Modules.SQLString = "0LOAD";
                LoadNX();
                LoadDChuyen();
                Commons.Modules.SQLString = "";
                LoadLoaiMay();
                LoadLoaiCV();
                LoadNhomMay();
                //LoadMay();
                lblLMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblLMay", Commons.Modules.TypeLanguage);
                lblDChuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblDChuyen", Commons.Modules.TypeLanguage);
                lblDDiem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblDDiem", Commons.Modules.TypeLanguage);
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblNam", Commons.Modules.TypeLanguage);
                lblLoaiBCao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "lblLoaiBCao", Commons.Modules.TypeLanguage);
            }
            catch(Exception ex){ XtraMessageBox.Show(ex.ToString()); }
        }
        private void LoadLoaiMay()
        {
            //if (Commons.Modules.SQLString == "0LOAD") return;
            //try
            //{
            //    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            //    //DataTable dt = new DataTable();
            //    //dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayAll", 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            //    //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            //}
            //catch { }

            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHTCoAll",
                    sNX, iHThong, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }
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
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private void LoadLoaiCV()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = " SELECT T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 ON  T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID  WHERE USERNAME = 'admin'  UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'.Chưa phân loại'  ORDER BY TEN_LOAI_CV";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());

            }
        }
        public void LoadNhomMay()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = Commons.Modules.ObjSystems.MLoadDataNhomMay(1,cboLMay.EditValue.ToString());
            }
            catch
            {
                dtTmp = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1");
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNhomThietBiBTDK, dtTmp, "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
        }
        DataTable dtMay = new DataTable();
        public int getLoaiTs()
        {
            int kq = 0;
            switch (optLoaiTS.SelectedIndex)
            {
                case 0: kq = -1; break;
                case 1: kq = 1; break;
                case 2: kq = 0; break;
                default:
                    break;
            }
            return kq;
        }
        private void updateGSTTToDataTable(ref DataTable dt, DataRow dr, string month, int value)
        {
            try
            {
                //thang co .1 = thang hien tai - value
                //thang hien tai = value
                string chuoi = month + ".1";
                int index = dt.Rows.IndexOf(dr);
                dt.Columns["" + chuoi + ""].ReadOnly = false;
                dt.Rows[index]["" + chuoi + ""] = Convert.ToInt32(dr["" + month + ""]) - value;
                dt.Columns["" + month + ""].ReadOnly = false;
                dt.Rows[index]["" + month + ""] = value;

                dt.AcceptChanges();
            }
            catch
            {
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = new DataTable();    
                try
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoGiamSatTinhTrang", datTNam.Text, Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, -1, cboLMay.EditValue,CboNhomThietBiBTDK.EditValue,cboLoaiCV.EditValue, getLoaiTs(), Commons.Modules.TypeLanguage));
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                
                if (DateTime.Now.Year >= datTNam.DateTime.Year)
                {
                    if (DateTime.Now.Year == datTNam.DateTime.Year)
                    {//nếu là năm hiện tại thì them cọt tháng giao nhau
                        System.Data.DataColumn newColumn = new System.Data.DataColumn(currentMonth, typeof(string));
                        newColumn.DefaultValue = "";
                        dtTmp.Columns.Add(newColumn);
                        foreach (DataColumn col in dtTmp.Columns)
                        {
                            if (col.ColumnName.Equals(DateTime.Now.Month.ToString()))
                            {
                                newColumn.SetOrdinal(col.Ordinal + 1);
                                break;
                            }
                        }
                        dtTmp.Columns[currentMonth].ReadOnly = false;
                    }

                    //c2 tao bang tam
                    Commons.Modules.ObjSystems.XoaTable("GSTT" + Commons.Modules.ObjSystems);
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "GSTT" + Commons.Modules.UserName, dtTmp, "");
                    // cập nhật vào tháng
                    try
                    {
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spCapNhatBaoCaoGiamSatTinhTrang", datTNam.Text, Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, -1, "-1", "GSTT" + Commons.Modules.UserName);
                        dtTmp.Clear();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM  GSTT" + Commons.Modules.UserName + " ORDER BY STT"));
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }

                }
                try
                {
                    grdChung.DataSource = null;
                    grvChung.Columns.Clear();
                }
                catch (Exception ex){ XtraMessageBox.Show(ex.ToString()); }
                dtTmp.Columns.Remove("MS_BO_PHAN");
                dtTmp.Columns.Remove("MS_TS_GSTT");
                dtTmp.Columns.Remove("MS_TT");

            
                DataTable dt = new DataTable();
                dt = dtTmp.Clone();
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, false, true, true, true, false, this.Name);


                grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "MS_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "TEN_MAY", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_TS_GSTT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "TEN_TS_GSTT", Commons.Modules.TypeLanguage);
                grvChung.Columns["LOAI_TS"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "LOAI_TS", Commons.Modules.TypeLanguage);
                grvChung.Columns["CHU_KY_DO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "CHU_KY_DO", Commons.Modules.TypeLanguage);
                grvChung.Columns["TEN_DV_TG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "TEN_DV_TG", Commons.Modules.TypeLanguage);
                grvChung.Columns["NGAY_CUOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoGiamSatTinhTrang", "NGAY_CUOI", Commons.Modules.TypeLanguage);
                grvChung.Columns["1"].Caption = "1";
                grvChung.Columns["2"].Caption = "2";
                grvChung.Columns["3"].Caption = "3";
                grvChung.Columns["4"].Caption = "4";
                grvChung.Columns["5"].Caption = "5";
                grvChung.Columns["6"].Caption = "6";
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    grvChung.Columns[currentMonth].Caption = DateTime.Now.Month.ToString();
                }
                grvChung.Columns["7"].Caption = "7";
                grvChung.Columns["8"].Caption = "8";
                grvChung.Columns["9"].Caption = "9";
                grvChung.Columns["10"].Caption = "10";
                grvChung.Columns["11"].Caption = "11";
                grvChung.Columns["12"].Caption = "12";

                InDuLieu(dtTmp);

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }

        }
        private void InDuLieu(DataTable dtTmp)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = true;
            Excel.Range title;

            //int TCot = grvChung.Columns.Count + 1;//26 cột
            int TCot = dtTmp.Columns.Count + 3;
            int TDong = dtTmp.Rows.Count;
            int Dong = 1;

            //prbIN.Visible = true;

            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = 28;
            prbIN.Properties.Minimum = 0;
            excelApplication.Visible = false;

            grdChung.ExportToXlsx(sPath);


            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            try
            {

                excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;
                excelApplication.Cells.Font.Size = 10;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, TDong, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);
                ((Excel.Range)xlWorkSheet.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot - 3);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                TCot = TCot - 3;
                int SCot;
                SCot = TCot;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 2, Dong);

                Dong++;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblTitleNamgs", Commons.Modules.TypeLanguage) + " " + datTNam.Text
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                Dong++;

                
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 4, 1, Dong + 4, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;
                title.RowHeight = 25;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 1, 11, 1);
                title.RowHeight = 12.75;

                if (Commons.Modules.bDoiFontReport)
                    excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;


                for (int i = 1; i <= 9; i++)
                {
                    title = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 3, i], xlWorkSheet.Cells[Dong + 4, i]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.Font.Size = 10;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";

                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    title = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 3, 10], xlWorkSheet.Cells[Dong + 3, 10 + DateTime.Now.Month - 1]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcTT", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong + 3, 10, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10);
                    }
                    else
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcThucTe", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(xlWorkSheet, "Thực tế", Dong + 3, 10, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10);
                    }

                    title = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 3, 10 + DateTime.Now.Month], xlWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcKH", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(xlWorkSheet, "KH", Dong + 3, 10 + DateTime.Now.Month, "@",10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10 + DateTime.Now.Month);
                    }
                    else
                    {
                        stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "bcKeHoach", Commons.Modules.TypeLanguage);
                        Commons.Modules.MExcel.DinhDang(xlWorkSheet, "Kế hoạch", Dong + 3, 10 + DateTime.Now.Month, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10 + DateTime.Now.Month);
                    }
                }

                else if (DateTime.Now.Year > Convert.ToInt16(datTNam.Text))
                {
                    title = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 3, 10], xlWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, "Thực tế", Dong + 3, 10, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }
                else
                {
                    title = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 3, 10], xlWorkSheet.Cells[Dong + 3, TCot]);
                    title.MergeCells = true;
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, "Kế hoạch", Dong + 3, 10, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 10);
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong, 3, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "@", true, Dong, 7, Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong, 8, Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 2.5, "@", true, Dong, 10, Dong, 20);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 3, 1, TDong + Dong+2, TCot);
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Borders.LineStyle = 1;
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    if (DateTime.Now.Month == 10 || DateTime.Now.Month == 11 || DateTime.Now.Month == 12)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 3, 10 + DateTime.Now.Month, Dong + 3, 10 + DateTime.Now.Month);
                        title.WrapText = false;
                    }
                    if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 3, 10, Dong + 3, 10);
                        title.WrapText = false;
                    }
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, lblDDiem.Text + ": " + cboDDiem.TextValue, 7, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 7, 4);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, lblDChuyen.Text + ": " + cboDChuyen.TextValue, 8, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 8, 4);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, lblLMay.Text + ": " + cboLMay.Text, 9, 3, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 9, 4);
                //Thêm Nhóm với loại công việc
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, labLoaiCV.Text + ": " + cboLMay.Text, 7, 5, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 7, 8);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, LblNhomThietBiBTDK.Text + ": " + cboLMay.Text, 8, 5, "@", 10, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, 8, 8);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int cot = 9;
                Dong = Dong + 5;
                Excel.FormatCondition condition;

                //Tô tháng hiện tại
                if (DateTime.Now.Year.ToString().Equals(datTNam.Text))
                {
                    //Tô tháng ở tương lai
                    if (DateTime.Now.Month != 12)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + DateTime.Now.Month + 1, TDong + Dong - 1, TCot);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                    }
                    else
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + DateTime.Now.Month + 1, TDong + Dong - 1, TCot);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual,"=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                    }
                    //Tô tháng ở quá khứ
                    if (DateTime.Now.Month != 1)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                        Excel.FormatCondition condition1;
                        condition1 = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                        condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));

                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, cot + DateTime.Now.Month);

                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    }
                    else
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                        Excel.FormatCondition condition1;
                        condition1 = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                        condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));

                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, cot + 1);
                        condition = (Excel.FormatCondition)
                        (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                        condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));


                    }

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeDaLam", Commons.Modules.TypeLanguage), 7, 11, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 7, 14);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeChuaLam", Commons.Modules.TypeLanguage), 8, 11, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 8, 14);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcKeHoach", Commons.Modules.TypeLanguage), 9, 11, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 9, 14);

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 7, 10, 7, 10);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 10, 8, 10);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 10, 9, 10);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                }
                else if (DateTime.Now.Year > Convert.ToInt16(datTNam.Text))
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                    condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    Excel.FormatCondition condition1;
                    condition1 = (Excel.FormatCondition)
                (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, "=0", Type.Missing));
                    condition1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));



                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeDaLam", Commons.Modules.TypeLanguage), 8, 11, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 8, 14);
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCHieuChuanKiemDinh", "bcThucTeChuaLam", Commons.Modules.TypeLanguage), 9, 11, "@", 10, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, 9, 14);
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 10, 8, 10);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#20b2aa"));
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 10, 9, 10);
                    title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#FFC000"));
                }
                else
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, cot + 1, TDong + Dong - 1, TCot);
                    condition = (Excel.FormatCondition)
                    (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreaterEqual, "=1", Type.Missing));
                    condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#00B050"));
                }
                

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 10, TDong + Dong - 1, 9);
                //title.NumberFormat = "@";
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 12, 10, TDong + Dong - 1, TCot);
                title.NumberFormat = "0;0; ";


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                if (TDong <= 500)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 13, 10, TDong + Dong - 1, TCot);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 10, 1, 10, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelApplication.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelWorkbook.Save();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "InKhongThanhCong", Commons.Modules.TypeLanguage) + ": " + ex.Message);
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDChuyen_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

    }
}