using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace ReportHuda
{//public partial class ucDienBienKPI : DevExpress.XtraEditors.XtraUserControl
    public partial class ucDienBienKPI : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDienBienKPI()
        {
            InitializeComponent();
        }

        private void ucDienBienKPI_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";

            int nam = DateTime.Now.Year;
            try
            {
                 nam = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MIN(YEAR(NGAY_LAP)) + 1 FROM dbo.PHIEU_BAO_TRI"));

            }
            catch
            {
                nam = DateTime.Now.Year;
            }

            cmbFromYear.DateTime = Convert.ToDateTime("01/01/"+ nam);
            cmbToYear.DateTime = Convert.ToDateTime("01/01/" + (DateTime.Now.Year + 1));
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnThoat", Commons.Modules.TypeLanguage);
            LoadDonVi();
            Commons.Modules.SQLString = "";
        }

        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll",0, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, _table, "MS_DON_VI", "TEN_DON_VI", lblDonVi.Text);
            }
            catch { }
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            grdData.DataSource = null;
            //đổ dữ liệu vào lưới là in báo cáo
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoApi",Commons.Modules.UserName,cmbFromYear.DateTime.Year,cmbToYear.DateTime.Year,cboDonVi.EditValue,Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData,grvData,dt,false,true,false,true,true,this.Name);
            grvData.Columns["ID_Result"].Visible = false;

            this.Cursor = Cursors.WaitCursor;
            InDuLieu();
            this.Cursor = Cursors.Default;
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
                DataTable dt = (DataTable)grdData.DataSource;
                int TCot = dt.Columns.Count;
                int TDong = grvData.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvData.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdData.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown,4, Dong);



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Excel.Range title;

                List<int> rowkt = new List<int>() ;
                List<int> rowsum = new List<int>();

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 2, 4, TCot);
                title.WrapText = false;


                Dong = 6;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,this.Name, "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 35;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
             
                Dong++;
                stmp = lblFromYear.Text + " " + cmbFromYear.DateTime.Year.ToString() + " - " +lblToYear.Text +" "+ cmbToYear.DateTime.Year.ToString() +"";       
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, true,Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                if (optLoaiBC.SelectedIndex == 1)
                {
                    stmp = lblDonVi.Text + ": "+cboDonVi.Text+"";
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong + 1, 1, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, TCot);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
              

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                

                int DongDL = Dong;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                
                Dong++;
                //thêm dòng thống kê ngừng máy
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown,2,Dong);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thống kê về ngừng máy", Dong, 1, "@", 8, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                rowkt.Add(Dong);
                Dong++;
                Dong++;
                Dong++;
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thống kê về bảo trì", Dong, 1, "@", 8, true, true, Dong, 2);
                rowkt.Add(Dong);

                Dong++;
                Dong++;
                Dong++;
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Tổng số phiếu bảo trì", Dong, 1, "@", 8, true,Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter,true,Dong,1,false,true);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Phiếu", Dong, 2, "@", 8, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 2);
                rowsum.Add(Dong);

                //Dong++;
                //Dong++;
                Dong++;
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong);
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Tổng số thời gian bảo trì", Dong, 1, "@", 8, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 1, false, true);
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Giờ", Dong, 2, "@", 8, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 2);
                //rowsum.Add(Dong);
                //Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thống kê về chi phí bảo trì", Dong, 1, "@", 8,true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2, false, false);
                rowkt.Add(Dong);

                Dong++;
                Dong++;
                Dong++;
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 2, Dong);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Tổng chi phí bảo trì", Dong, 1, "@", 8, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 1, false, true);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "VNĐ", Dong, 2, "@", 8, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 2);
                rowsum.Add(Dong);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Thống kê về hàng tồn kho", Dong, 1, "@", 8, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                rowkt.Add(Dong);

                Dong++;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //insert thêm colum phần trăm
                int j = 0;
                for (int i = 4; i <= dt.Columns.Count; i++)
                {
                    TCot++;
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL, i + j, DongDL, i + j);
                    title.EntireColumn.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL, i + j - 1, DongDL, i + j);
                    title.Merge();

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL + 1, i + j - 1, DongDL + 1, i + j - 1);
                    title.Value2 = "GT";
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL + 3, i + j - 1, Dong, i + j - 1);
                    title.NumberFormat = "#,##0";


                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL + 1, i + j, DongDL + 1, i + j);
                    title.Value2 = "%";
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    for (int iDong = DongDL + 2; iDong <= Dong; iDong++)
                    {
                        if (rowkt.Count(x=>x.Equals(iDong)) == 0)
                        {
                            if (i == 4)
                            {

                                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j, iDong, i + j);
                                title.Value2 = 1;
                                title.NumberFormat = "0%";

                                if (rowsum.Count(x => x.Equals(iDong)) == 1)
                                {
                                    title.Font.Bold = true;
                                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j - 1, iDong, i + j - 1);
                                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(iDong - 2, i + j - 1) + ":" + Commons.Modules.MExcel.TimDiemExcel(iDong - 1, i + j - 1) + ")";
                                    title.Font.Bold = true;
                                }
                                //title1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j , Dong, i + j);
                                //title.AutoFill(title1,Excel.XlAutoFillType.xlFillCopy);
                            }
                            else
                            {
                                //kiểm tra cột tổng
                                if (rowsum.Count(x => x.Equals(iDong)) == 1)
                                {
                                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j - 1, iDong, i + j - 1);
                                    title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(iDong - 2, i + j - 1) + ":" + Commons.Modules.MExcel.TimDiemExcel(iDong - 1, i + j - 1) + ")";
                                    title.Font.Bold = true;


                                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j, iDong, i + j);
                                    title.Value2 = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + " = 0,0, (" + Commons.Modules.MExcel.TimDiemExcel(iDong, i + j - 1) + " - " + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + ")/ " + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + ")";
                                    title.NumberFormat = "0%";
                                    title.Font.Bold = true;
                                }
                               else
                                {
                                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j, iDong, i + j);
                                    title.Value2 = "=IF(" + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + " = 0,0, (" + Commons.Modules.MExcel.TimDiemExcel(iDong, i + j - 1) + " - " + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + ")/ " + Commons.Modules.MExcel.TimDiemExcel(iDong, 3) + ")";
                                    title.NumberFormat = "0%";
                                }    
                           


                                //title1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, i + j, Dong, i + j);
                                //title.AutoFill(title1, Excel.XlAutoFillType.xlFillCopy);
                            }
                        }
                        else
                        {
                            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDong, 1, iDong,1);
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        }    
                    } 
                        //sét giá trị cột đầu tiên là 100 %
                    j++;
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, DongDL, 1, Dong, TCot - 1);
                title.Borders.LineStyle = 1;
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 24, "@", true, 5, 1, 5, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, 5, 2, 5, 2);

                //Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                //    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

               
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelWorkbook.Save();
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                //prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void optLoaiBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optLoaiBC.SelectedIndex == 0)
            {
                cboDonVi.Enabled = false;
            }
            else
            {
                cboDonVi.Enabled = true;
            }
        }
    }
}
