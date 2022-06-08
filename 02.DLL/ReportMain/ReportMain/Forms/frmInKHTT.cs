using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ReportMain
{
    public partial class frmInKHTT : DevExpress.XtraEditors.XtraForm
    {
        //iLoai = 1 In ke hoach tong the
        //iLoai = 2 In ke hoach sua chua
        //iLoai = 3 In Bien ban nghiem thu hoan thanh cong tac

        public int iLoai = 1;
        public int iKHType = 1;
        public DateTime NamThang = DateTime.Now.Date;
        public string sTenBC = "";

        public frmInKHTT()
        {
            InitializeComponent();
        }

        #region Load Du Lieu

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName,
                    "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
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

        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }

        #endregion
        #region Change du lieu

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        #endregion

        private void frmInKHTT_Load(object sender, EventArgs e)
        {
            
            datNam.DateTime = DateTime.Now;
            datThang.DateTime = DateTime.Now;
            LoadKH();
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            datNam.Visible = true;
            datThang.Visible = false;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            cboLoaiKH.EditValue =  iKHType.ToString();
            datNam.DateTime = NamThang.Date;
            datThang.DateTime = NamThang.Date;

            if (iKHType == 1)
            {
                datNam.Visible = true;
                datNam.MMonthYear = false;
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "lblNam", Commons.Modules.TypeLanguage);
                datThang.Visible = false;
            }
            else
            {
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblThang", Commons.Modules.TypeLanguage);
                datNam.Visible = false;
                datThang.Visible = true;
                datThang.MMonthYear = true;
            }


            if (iLoai == 3)
            {
                optBCao.Visible = false;
                optTienDo.Visible = false;
                this.Size = new System.Drawing.Size(559, 269);
            }
            else
            {
                if (iLoai == 2)
                {
                    this.Size = new System.Drawing.Size(666, 322);
                }
                else
                {
                    tableLayoutPanel1.Controls.Remove(optTienDo);
                    tableLayoutPanel1.Controls.Remove(optBCao);
                    tableLayoutPanel1.Controls.Add(optBCao, 1, 7);

                    this.Size = new System.Drawing.Size(606, 294);
                }
            }
            if (sTenBC != "")
                this.Text = sTenBC;
        }

        private void LoadKH()
        {
            try
            {
                
                DataTable dtTmp = new DataTable();
                dtTmp.Columns.Add("MA_SO", System.Type.GetType("System.String"));
                dtTmp.Columns.Add("TEN", System.Type.GetType("System.String"));
                dtTmp.Rows.Add(1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "KeHoachNam", Commons.Modules.TypeLanguage));
                dtTmp.Rows.Add(2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "KeHoachThang", Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiKH, dtTmp, "MA_SO", "TEN", "");
                cboLoaiKH.Properties.DropDownRows = 2;
                
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLoaiKH_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiKH.EditValue.ToString() == "1")
            {
                datNam.Visible = true;
                datNam.MMonthYear = false;
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "lblNam", Commons.Modules.TypeLanguage);
                datThang.Visible = false;
            }
            else
            {
                lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblThang", Commons.Modules.TypeLanguage);
                datNam.Visible = false;
                datThang.Visible = true;
                datThang.MMonthYear = true;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (iLoai == 1) KeHoachTongTheNamThang();
            if (iLoai == 2) KeHoachSuaChua();
            if (iLoai == 3) BienBanNghiemThu();
        }

#region "Loai = 1 Ke hoach tong the" 
        private void KeHoachTongTheNamThang()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                int iNam = -1;
                int iThang = -1;
                if (cboLoaiKH.EditValue.ToString() == "1")
                {
                    iNam = datNam.DateTime.Year;
                }
                else
                {
                    iNam = datThang.DateTime.Year;
                    iThang = datThang.DateTime.Month;
                }
                string SQL = "";
                SQL = "EXEC GetKHTTNamThang '" + cboLMay.EditValue + "','" + cboNhomMay.EditValue + "','" + Commons.Modules.UserName + "','" + cboDDiem.EditValue + "','" + cboDChuyen.EditValue + "','" + cboLoaiKH.EditValue + "','" + iNam + "','" + iThang + "','" + optBCao.SelectedIndex + "'";
                string sMSBP = txtMSBP.Text;
                if (sMSBP.Trim() == "") sMSBP = @"%%"; 

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTTNamThang", 
                    cboLMay.EditValue, cboNhomMay.EditValue,Commons.Modules.UserName, cboDDiem.EditValue,
                    cboDChuyen.EditValue, cboLoaiKH.EditValue, iNam, iThang, optBCao.SelectedIndex,sMSBP));

                dtTmp.Columns.Remove("NDCV");

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, "frmInKHTT");
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }

                InDuLieuKHTT();
            }
            catch { }
        }

        private void InDuLieuKHTT()
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count - 4;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                if (grvChung.RowCount > 1000) Dong = Convert.ToInt32(grvChung.RowCount / 20); else Dong = 0;
                prbIN.Properties.Maximum = 9 + grvChung.RowCount + Dong; //19 
                prbIN.Properties.Minimum = 0;
                Dong = 1;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                //xlApp.Visible = true;
                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (cboLoaiKH.EditValue.ToString() == "1")
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDe", Commons.Modules.TypeLanguage) + " " + datNam.DateTime.Year.ToString(), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeThang", Commons.Modules.TypeLanguage) + " " + datThang.DateTime.ToString("MM/yyyy"), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);


                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "PhanXuong", Commons.Modules.TypeLanguage) + " " + cboDDiem.Text, 7, 1, "@", 12, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 7, TCot);

                Boolean bBD = false;
                Boolean bKT = false;
                int iDBD = 1;
                int iDBDLuu = 10;
                int i = 10;

                try
                {
                    xlApp.DisplayAlerts = false;
                    for (i = 10; i <= grvChung.RowCount + 10; i++)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 14, i, 14);
                        if (int.Parse(title.Value2.ToString()) == 0)
                        {
                            bBD = true;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, 20);
                            title.Font.Bold = true;
                        }
                        else
                        {
                            bKT = true;
                            bBD = false;
                            iDBD++;
                        }
                        if (bBD && bKT)
                        {
                            iDBDLuu = i - iDBD;
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iDBDLuu, 11, iDBDLuu, 11);
                            title.Value2 = "=SUBTOTAL(9," + Commons.Modules.MExcel.TimDiemExcel(iDBDLuu + 1, 11) + ":" +
                                Commons.Modules.MExcel.TimDiemExcel(i - 1, 11) + ")";
                            title.Font.Bold = true;
                            iDBDLuu = i;
                            bKT = false;
                            bBD = false;
                            iDBD = 1;
                        }

                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                    }
                }
                catch { }

                try
                {
                    iDBDLuu = i - iDBD;
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iDBDLuu, 11, iDBDLuu, 11);
                    title.Value2 = "=SUBTOTAL(9," + Commons.Modules.MExcel.TimDiemExcel(iDBDLuu + 1, 11) + ":" +
                        Commons.Modules.MExcel.TimDiemExcel(i - 1, 11) + ")";
                    title.Font.Bold = true;
                }
                catch { }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = grvChung.RowCount + 10;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 13, Dong, 16);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TongCong", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 8, Dong, 8);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(10, 8) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 8) + ")";
                title.Font.Bold = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 9, Dong, 9);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(10, 9) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 9) + ")";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 10, Dong, 10);
                title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(10, 10) + ":" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 10) + ")";
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 11, Dong, 11);
                title.Value2 = "=SUBTOTAL(9," + Commons.Modules.MExcel.TimDiemExcel(10, 11) + ":" + Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 11) + ")";
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                DataTable dtTmp = new DataTable();
                double TongCP;
                dtTmp = (DataTable)grdChung.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "KHTT_IN" + Commons.Modules.UserName, dtTmp, "");
                stmp = "SELECT ISNULL(SUM(ISNULL(CP_VT_NN_NGOAI_DM,0)) + SUM(ISNULL(CP_THUE_NGOAI,0)) + SUM(ISNULL(CP_VT_NGOAI_DM,0)),0) FROM KHTT_IN" +
                    Commons.Modules.UserName + " WHERE MS_UU_TIEN = 1";
                TongCP = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp));

                Dong = Dong + 2;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TongUuTien1", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, TongCP.ToString(), Dong, 5, "#,##0", 10, true,
                        Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Dong +2;
                stmp = "SELECT ISNULL(SUM(ISNULL(CP_VT_NN_NGOAI_DM,0)) + SUM(ISNULL(CP_THUE_NGOAI,0)) + SUM(ISNULL(CP_VT_NGOAI_DM,0)),0) FROM KHTT_IN" +
                            Commons.Modules.UserName + " WHERE MS_UU_TIEN = 2";
                TongCP = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp));
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TongUuTien2", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, TongCP.ToString(), Dong, 5, "#,##0", 10, true,
                        Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                     Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "CongSuaChuaTamTinh", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, false,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, "1", Dong, 5, "#,##0", 10, true,
                        Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);

                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "ChiPhiNhanCong", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, false,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 6, Dong, 6);
                title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(Dong - 6, 11) + "*" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong - 1, 5);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Dong = Dong + 2;
                stmp = "SELECT ISNULL(SUM(ISNULL(CP_VT_NN_NGOAI_DM,0)) + SUM(ISNULL(CP_THUE_NGOAI,0)) + SUM(ISNULL(CP_VT_NGOAI_DM,0)),0) FROM KHTT_IN" +
                            Commons.Modules.UserName + " WHERE MS_UU_TIEN = 3";
                TongCP = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp));

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TongUuTien_3", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, TongCP.ToString(), Dong, 5, "#,##0", 10, true,
                        Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);
                Dong++;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TongChiPhi", Commons.Modules.TypeLanguage), Dong, 2, "@", 10, true,
                        Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 6, Dong, 6);
                title.Value2 = "=" + Commons.Modules.MExcel.TimDiemExcel(Dong - 9, 8) + "+" +
                    Commons.Modules.MExcel.TimDiemExcel(Dong - 9, 9) + "+" + Commons.Modules.MExcel.TimDiemExcel(Dong - 9, 10);
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong - 10, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong - 10, 1);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, 9, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[8, 1]).Interior.Color;


                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 100);

                Dong = Dong + 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Ngay", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Thang", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Nam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year.ToString() + " ";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 15, false,
                                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 12);
                Dong++;
                if (cboDDiem.EditValue.ToString() != "-1")
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "PhanXuong", Commons.Modules.TypeLanguage) + " " + cboDDiem.Text;
                else
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "PhanXuong", Commons.Modules.TypeLanguage);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 13, false,
                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 45, "@", true, 10, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, 10, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 45, "@", true, 10, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 35, "@", true, 10, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0.#0_);_(* (#,##0.#0);_(* "" - ""??_);_(@_)", true, 10, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0.#0_);_(* (#,##0.#0);_(* "" - ""??_);_(@_)", true, 10, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)", true, 10, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)", true, 10, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)", true, 10, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, @"_(* #,##0.#0_);_(* (#,##0.#0);_(* "" - ""??_);_(@_)", true, 10, 11, TDong + Dong, 11);
                 
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, 10, 9, TDong + Dong, 9);
                
                prbIN.Position = prbIN.Properties.Maximum;

                xlApp.Cells.WrapText = true;
                xlWorkBook.Save();
                xlApp.Visible = true;

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                prbIN.Position = prbIN.Properties.Maximum;
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            this.Cursor = Cursors.Default;
        }

#endregion

#region "Loai = 2 Ke hoach sua chua"
        private void KeHoachSuaChua()
        {
            DataTable dtTmp = new DataTable();
            int iNam = -1;
            int iThang = -1;
            if (cboLoaiKH.EditValue.ToString() == "1")
            {
                iNam = datNam.DateTime.Year;
            }
            else
            {
                iNam = datThang.DateTime.Year;
                iThang = datThang.DateTime.Month;
            }
            string sMSBP = txtMSBP.Text;
            if (sMSBP.Trim() == "") sMSBP = @"%%"; 

            
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKeHoachSuaChuaThangNam",
                cboLMay.EditValue, cboNhomMay.EditValue, Commons.Modules.UserName, cboDDiem.EditValue,
                cboDChuyen.EditValue, cboLoaiKH.EditValue, iNam, iThang, optBCao.SelectedIndex, 
                Commons.Modules.TypeLanguage, sMSBP, optTienDo.SelectedIndex,
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KH", Commons.Modules.TypeLanguage),
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "PS", Commons.Modules.TypeLanguage)));
            if (dtTmp.Rows.Count == 2)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            //Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, "frmInKHTT");
            InDuLieuKHSC(dtTmp);
        }



        private void InDuLieuKHSC(DataTable dtTmp1)
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            try
            {
                int TCot = dtTmp1.Columns.Count - 4;
                int TDong = dtTmp1.Rows.Count;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                if (dtTmp1.Rows.Count > 1000) Dong = Convert.ToInt32(dtTmp1.Rows.Count / 20); else Dong = 0;
                prbIN.Properties.Maximum = 9 + dtTmp1.Rows.Count + Dong;
                prbIN.Properties.Minimum = 0;


                Dong = 1;
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, dtTmp1.Rows.Count + 1, dtTmp1.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp1, xlWorkSheet, title);

                //xlApp.Visible = true;




                //Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                //Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];




                xlWorkSheet.Outline.SummaryRow = Excel.XlSummaryRow.xlSummaryAbove;
                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (cboLoaiKH.EditValue.ToString() == "1")
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeKeHoachSuaChuaNam", Commons.Modules.TypeLanguage), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeKeHoachSuaChuaThang", Commons.Modules.TypeLanguage), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = dtTmp1.Rows.Count + 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int iBD = 0;
                int iPS = 0;
                int i3 = 0;
                int i1 = 0;
                int iGB = 0;
                string sTmp1 = "";

                try
                {
                    xlApp.DisplayAlerts = false;
                    for (int i = 9; i < dtTmp1.Rows.Count + 9; i++)
                    {

                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 16, i, 16);
                        if (int.Parse(title.Value2.ToString()) == 0)
                        {
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                            title.Font.Bold = true;

                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot - 1);
                            title.MergeCells = true;
                        }
                        else
                        {
                            if (int.Parse(title.Value2.ToString()) == 2)
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                                title.Font.Bold = true;

                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot - 1);
                                title.MergeCells = true;
                                iPS = i;
                            }
                        }
                        
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 13, i, 13);
                        
                        
                        if (int.Parse(title.Value2.ToString()) == 1)
                        {
                            if (i1 == 0) i1 = i;    
                            if (iPS != 0)
                            {
                                if (iBD > 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                                    title.Font.Bold = true;

                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 2, i, TCot - 1);
                                    title.MergeCells = true;

                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD + 1, 1, i - 2, 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }
                                iBD = i;
                            
                            }
                            else
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                                title.Font.Bold = true;

                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 2, i, TCot - 1);
                                title.MergeCells = true;
                                if (iBD > 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD + 1, 1, i - 1, 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }
                                iBD = i;
                                
                            }
                        }
                        else
                            if (int.Parse(title.Value2.ToString()) == 2)
                            {

                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                                title.Font.Bold = true;
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, TCot);
                                title.MergeCells = true;

                            }
                            else
                            {
                                if (int.Parse(title.Value2.ToString()) == 3)
                                {
                                    try
                                    {
                                        //sTmp1 = "33";
                                        if (!string.IsNullOrEmpty(Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Value2.ToString()))
                                            if (sTmp1 != Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Value2.ToString())
                                            {
                                                sTmp1 = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Value2.ToString();
                                                Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Font.Bold = true;
                                                iGB = i;
                                            }
                                            else
                                            {
                                                if (sTmp1 == Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Value2.ToString())
                                                {
                                                    Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 3, i, 3).Value2 = "";
                                                }
                                                else
                                                {
                                                    if (sTmp1 == Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 1, 3, i + 1, 3).Value2.ToString())
                                                    {
                                                        Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 1, 3, i + 1, 3).Value2 = "";
                                                    }
                                                }
                                            }
                                    }
                                    catch { }
                                }                        
                            }
                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                        i3 = i;
                    }



                }
                catch { }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (i3 == iPS) i3 = 0;
                

                if (iBD > 0)
                {
                    if (i3 == iPS)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD + 1, 1, i3-1, 1);
                        title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                    else
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD + 1, 1, i3, 1);
                        title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    
                    }
                }
                if (iPS > 10)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 10, 1, iPS - 1, 1);
                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                if (i3 > iPS)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iPS + 1, 1, i3, 1);
                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, Dong - 1, TCot - 1);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 1, 8, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[7, 1], xlWorkSheet.Cells[7, 1]).Interior.Color;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 12, Dong, 16);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

                for (int i = 1; i < TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, i, 8, i);
                    title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, title.Value2.ToString(), Commons.Modules.TypeLanguage);

                }


                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 76);
                //xlApp.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, 9, 1,  Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 2,  Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 3,  Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", true, 9, 4,  Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0", true, 9, 5,  Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, 9, 6,  Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "@", true, 9, 7, Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 10,  Dong, 11);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "DongNai", Commons.Modules.TypeLanguage) + ", " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Ngay", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Thang", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Nam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year.ToString() + " ";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, false,
                                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 12);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "Duyet", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "DonViLapKeHoach", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 12);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Dong + 3;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "NoiNhan", Commons.Modules.TypeLanguage) + " : ";
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong + 3, 1, Dong + 3, 1);
                title.Value2 = stmp;
                title.Font.Italic = true;


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "DuoiTraiKHSC", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.RightFooter = stmp + " &P / &N";


                

                prbIN.Position = prbIN.Properties.Maximum;
                xlApp.Cells.WrapText = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 11, 1, 11);
                title.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftDown);



                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TD_DANH_GIA", Commons.Modules.TypeLanguage) ;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 8, 11, 8, 11);
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlApp.Visible = true;
                xlWorkBook.Save();


                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                prbIN.Position = prbIN.Properties.Maximum;
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            this.Cursor = Cursors.Default;
        }

#endregion

#region "Loai = 3 Bien ban nghiem thu hoan thanh cong tac"
        private void BienBanNghiemThu()
        {
            //DataTable dtTmp = new DataTable();
            int iNam = -1;
            int iThang = -1;
            if (cboLoaiKH.EditValue.ToString() == "1")
            {
                iNam = datNam.DateTime.Year;
            }
            else
            {
                iNam = datThang.DateTime.Year;
                iThang = datThang.DateTime.Month;
            }
            string sMSBP = txtMSBP.Text;
            if (sMSBP.Trim() == "") sMSBP = @"%%";
            DataTable dtTmp = new DataTable();

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBienBanNghiemThuHoanThanhCongTac",
                cboLMay.EditValue, cboNhomMay.EditValue, Commons.Modules.UserName, cboDDiem.EditValue,
                cboDChuyen.EditValue, cboLoaiKH.EditValue, iNam, iThang, optBCao.SelectedIndex ,
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,"CongTacKeHoach", Commons.Modules.TypeLanguage),
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CongTacDotXuat", Commons.Modules.TypeLanguage), sMSBP,
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgoaiKeHoach", Commons.Modules.TypeLanguage)));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, "frmInKHTT");
            if (dtTmp.Rows.Count <=2)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            InDuLieuBBNThu();
        }
        private void InDuLieuBBNThu()
        {
            string sPath = "";
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count - 2;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 19 + grvChung.RowCount ;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //xlApp.Visible = true;

                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                
                xlApp.Cells.Font.Name = "Times New Roman";
                xlApp.Cells.Font.Size = 10;
                xlApp.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                
                xlWorkSheet.Outline.SummaryRow = Excel.XlSummaryRow.xlSummaryAbove;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 1;
                Excel.Range title;

                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 130.5, 56, Application.StartupPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (cboLoaiKH.EditValue.ToString() == "1")
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeBienBanNghiemThuNam", Commons.Modules.TypeLanguage) + " " + datNam.DateTime.Year.ToString(), 6, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeBienBanNghiemThuThang", Commons.Modules.TypeLanguage) + " " + datThang.DateTime.Month.ToString() + " " +
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblNam", Commons.Modules.TypeLanguage) + " " + datThang.DateTime.Year.ToString(), 
                        6, 1, "@", 16, true,Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 6, TCot);

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "DonVi", Commons.Modules.TypeLanguage) + " : " + cboDDiem.Text, 7, 1, "@", 12, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, 7, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong = grvChung.RowCount + 10;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, Dong - 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 9, 1, 9, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[8, 1]).Interior.Color;

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 75);
                //xlApp.Visible = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int iBD1 = 0;
                int iBD2 = 0;
                try
                {
                    xlApp.DisplayAlerts = false;
                    for (int i = 10; i <= grvChung.RowCount + 10; i++)
                    {
                        int iTD = 0;
                        int iGt = 0;
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, 1);
                        iTD = int.Parse(title.Value2.ToString());
                        if (iTD == 0)
                        {
                            title.Value2 = "";
                        }
                        
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 13, i, 13);
                        iGt = int.Parse(title.Value2.ToString());


                        if (iTD == 0)
                        {
                            title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i + 1, 13, i + 1, 13);
                            int iKT = 0;
                            try
                            {
                                iKT = int.Parse(title.Value2.ToString());
                            }
                            catch { }
                            if (iGt != iKT - 1)
                            {
                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, 13);
                                title.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                                i = i - 1;
                                Dong = Dong - 1;
                                if (iGt == 2 && iBD1 != 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD1 + 1, 1, i, 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }

                                if (iGt == 4 && iBD1 != 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD1 + 1, 1, i , 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }
                                if (iGt == 4) iBD2 = -1; else iBD2 = 0;
                                iBD1 = 0;
                            }
                            else
                            {

                                if (iGt == 2 && iBD1 != 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD1 + 1, 1, i - 1, 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }

                                if (iGt == 4 && iBD1 != 0)
                                {
                                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD1 + 1, 1, i - 1, 1);
                                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                                }
                                iBD1 = i;

                                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, i, 1, i, TCot);
                                title.Font.Bold = true;
                                title.Font.Size = 12;
                                title.RowHeight = 18;
                                title.MergeCells = true;
                            }
                            
                        }
                        #region prb
                        prbIN.PerformStep();
                        prbIN.Update();
                        #endregion
                    }
                }
                catch { }


                if (iBD1 != TDong && iBD2 != -1)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iBD1 + 1, 1, Dong - 1, 1);
                    title.Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }

                try
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 13, Dong - 1, 13);
                    if (int.Parse(title.Value2.ToString()) == 0 )
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 13);
                        title.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        Dong = Dong - 1;
                    }
                    if (int.Parse(title.Value2.ToString()) == 2)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 13);
                        title.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        Dong = Dong - 1;
                    }
                    if (int.Parse(title.Value2.ToString()) == 4)
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 13);
                        title.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        Dong = Dong - 1;
                    }
                }
                catch { }
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 12, Dong, 13);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 4, "@", true, 9, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 23, "@", true, 9, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, 9, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, oldCultureInfo.DateTimeFormat.ShortDatePattern, true, 9, 5, Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 32, "@", true, 9, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, 9, 7, Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "#,##0", true, 9, 8, Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 18, "@", true, 9, 10, Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, 9, 11, Dong, 11);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Ngay", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Day.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Thang", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Month.ToString() + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "Nam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year.ToString() + " ";
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, false,
                                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 11);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "Duyet", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "DonViSuaChua", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 3, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 5);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "DonViNghiemThu", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "LapBieu", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true,
                                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 11);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "DuoiTraiBBNT", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.LeftFooter = stmp;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "Trang", Commons.Modules.TypeLanguage);
                xlWorkSheet.PageSetup.RightFooter = stmp + " &P / &N";


                xlApp.Cells.WrapText = true;
                xlWorkBook.Save();
                xlApp.Visible = true;

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

#endregion

    }
}