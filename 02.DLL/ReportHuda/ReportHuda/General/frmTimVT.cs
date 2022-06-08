using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.General
{
    public partial class frmTimVT : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtData;
        public frmTimVT()
        {
            InitializeComponent();
        }

        private void frmTimVT_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.SQLString = "0loadPT";
                DateTime Ngay;
                Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                datTNgay.DateTime = Ngay.AddMonths(-6);
                datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
                TaoData();
                Commons.Modules.SQLString = "";
                LocData();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }            
            catch { }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            Excel.Application excelApplication = new Excel.Application();
            try
            {
                string sPath = "-1";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
                if (sPath == "") return;

                this.Cursor = Cursors.WaitCursor;
                grvTim.ExportToXls(sPath);
                
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                //excelApplication.Visible = true;
                

                int TCot = grvTim.Columns.Count - 1;
                int TDong = excelWorkSheet.Rows.CurrentRegion.Rows.Count; 
                int Dong = 1;

                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 1]);

                excelApplication.ActiveWindow.DisplayGridlines = true;
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, 1);


                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "MaSo", Commons.Modules.TypeLanguage), Dong, TCot - 2, "@", 10, false, true, Dong, TCot);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "LanBH", Commons.Modules.TypeLanguage), Dong, TCot - 2, "@", 10, false, true, Dong, TCot);
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "NgayBH", Commons.Modules.TypeLanguage), Dong, TCot - 2, "@", 10, false, true, Dong, TCot);

                Dong++;
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 14, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                string TN;
                TN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "TN", Commons.Modules.TypeLanguage) + datTNgay.Text + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "DN", Commons.Modules.TypeLanguage) + datDNgay.Text;

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "TN", Commons.Modules.TypeLanguage) + " " + datTNgay.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "DN", Commons.Modules.TypeLanguage) + " " + datDNgay.Text, Dong, 1, "@", 10, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "DiaDiem", Commons.Modules.TypeLanguage) + " " + cboKho.Text, Dong, 1, "@", 10, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, false,
                    false, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);

                excelWorkSheet.Columns.AutoFit();
                excelWorkSheet.Rows.AutoFit();

                int Cot = 0;
                int CRong = 0;

                for (int i = 0; i < TCot; i++)
                {
                    Cot = TimCot(excelWorkSheet, grvTim.Columns[i].Caption.ToString(), TCot);
                    if (Cot != 0)
                    {
                        CRong = TimDoRong(excelWorkSheet, grvTim.Columns[i].Name, TCot);

                        if (grvTim.Columns[i].Name == "colSL_DE_XUAT" || grvTim.Columns[i].Name == "colSL_THUC_NHAP")
                            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, CRong, "#,##0.00", true, 10, Cot, TDong + 11, Cot);
                        else
                            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, CRong, "@", true, 10, Cot, TDong + 11, Cot);
                    }
                }






                string str = "";

                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 20, 0, 100, 40, Application.StartupPath);
                DataTable dtTmp = new DataTable();
                try
                {
                    dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                       " SELECT LOGO,TEN_CTY_TIENG_VIET,TEN_CTY_TIENG_ANH FROM THONG_TIN_CHUNG"));


                    if (Commons.Modules.TypeLanguage == 0)
                        str = dtTmp.Rows[0]["TEN_CTY_TIENG_VIET"].ToString();
                    else
                        str = dtTmp.Rows[0]["TEN_CTY_TIENG_ANH"].ToString();
                }
                catch { }

                //Excel.Shape textBox = excelWorkSheet.Shapes.AddTextbox(
                            //Office.MsoTextOrientation.msoTextOrientationHorizontal, 10, 50, 85, 20);
                //textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Font.Bold = true;
                //textBox.TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //textBox.TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Text
                //    = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BieuMau", Commons.Modules.TypeLanguage);
                //textBox.Line.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //textBox.Line.Style = Office.MsoLineStyle.msoLineSingle;
                //textBox.Line.Weight = 2;


                str = str + Environment.NewLine + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "So", Commons.Modules.TypeLanguage);

                Excel.Shape textBox = excelWorkSheet.Shapes.AddTextbox(
                            Office.MsoTextOrientation.msoTextOrientationHorizontal, 120, 0, 150, 48);
                textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Font.Bold = true;
                textBox.TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                textBox.TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                textBox.TextFrame.Characters(System.Type.Missing, System.Type.Missing).Text = str;
                textBox.Line.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));

                textBox.Line.Weight = 0;


                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[TDong + 9, 1], excelWorkSheet.Cells[TDong + 9, TCot]);
                a1.EntireRow.Delete(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "TongSo", Commons.Modules.TypeLanguage) + " ", TDong + 9, 1, "@", 10, true, Excel.XlHAlign.xlHAlignRight,
                    Excel.XlVAlign.xlVAlignCenter, true, TDong + 9, 1);


                a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[TDong + 9, TCot]);

                a1.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //a1.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                a1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                a1.Font.Bold = true;

                a1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, TDong + 9, 1, TDong + 11, TCot);
                a1.Font.Bold = true;





                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch
            {
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }
        private int TimCot(Excel.Worksheet excelWorkSheet, string TenCot, int TCot)
        {
            int sCot;
            sCot = 0;
            for (int i = 1; i <= TCot; i++)
            {
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, i], excelWorkSheet.Cells[9, i]);
                if (!(Boolean)a1.MergeCells)
                {
                    if (a1.Value2.ToString().ToUpper() == TenCot.ToString().ToUpper())
                    {
                        return i;
                    }
                }
                else
                {
                    //i++;
                    a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, i+1], excelWorkSheet.Cells[9, i+1]);
                    if (!(Boolean)a1.MergeCells)
                    {
                        a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, i - sCot], excelWorkSheet.Cells[9, i - sCot]);
                        if (a1.Value2.ToString().ToUpper() == TenCot.ToString().ToUpper())
                        {
                            return i;
                        }

                    }
                    else sCot++;

                }
            }

            return 0;
        }
        private int TimDoRong(Excel.Worksheet excelWorkSheet, string TenCot, int TCot)
        {
            switch (TenCot.ToUpper())
            {
                case "COLTEN_PT":
                    return 25;
                case "COLQUY_CACH":
                    return 22;
                case "COLMS_PT":
                    return 13;
                case "COLMS_DE_XUAT":
                    return 13;
                case "COLTEN_TO":
                    return 15;
                case "COLTEN_KHO":
                    return 15;
                case "COLSL_DE_XUAT":
                    return 8;
                case "COLSL_THUC_NHAP":
                    return 8;
                case "COLTEN_1":
                    return 9;
                case "COLGHI_CHU":
                    return 20;
            }
            return 0;
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "##", true, 10, 4, TDong + 9, 4);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "##", true, 10, 5, TDong + 9, 5);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "##", true, 10, 6, TDong + 9, 6);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "##", true, 10, 7, TDong + 9, 7);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "#,##0.00", true, 10, 8, TDong + 9, 8);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "##", true, 10, 9, TDong + 9, 9);
            //Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 23, "##", true, 10, 10, TDong + 9, 10);
            
        }
        private void TaoData()
        {
            try
            {
                dtData = new DataTable();
                dtData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MTimVatTuDX",
                    datTNgay.DateTime, datDNgay.DateTime));
                dtData.DefaultView.Sort = "TEN_KHO,TEN_PT,QUY_CACH,MS_PT";

                DataTable dtKho = new DataTable();
                dtKho = dtData.Copy().DefaultView.ToTable(true, "MS_KHO", "TEN_KHO");
                dtKho.Columns["TEN_KHO"].ReadOnly = false;

                string sKhoNull = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhoNULL", Commons.Modules.TypeLanguage);

                if (dtKho.Rows.Count > 0)
                {
                    foreach (DataRow _row in dtKho.Rows)
                    {
                        if (_row["TEN_KHO"].ToString().Equals(""))
                        {
                            _row["TEN_KHO"] = sKhoNull;
                            break;
                        }

                    }
                }
                dtKho.Columns["TEN_KHO"].ReadOnly = true;                 
                 
                DataRow rowTTB = dtKho.NewRow();
                rowTTB["MS_KHO"] = "-1";
                rowTTB["TEN_KHO"] = "< ALL >";
                dtKho.Rows.Add(rowTTB);
                dtKho.DefaultView.Sort = "MS_KHO";

                cboKho.Properties.DataSource = dtKho;
                cboKho.Properties.ValueMember = "MS_KHO";
                cboKho.Properties.DisplayMember = "TEN_KHO";
                cboKho.Properties.Columns.Clear();
                cboKho.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_KHO"));

                cboKho.EditValue = -1;
                LocData();

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTim, grvTim, dtData, false, false, true, false);
                

                grvTim.Columns["SL_DE_XUAT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvTim.Columns["SL_DE_XUAT"].SummaryItem.DisplayFormat = "{0:N2}";

                grvTim.Columns["SL_DE_XUAT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTim.Columns["SL_DE_XUAT"].DisplayFormat.FormatString = "{0:N2}";

                grvTim.Columns["SL_THUC_NHAP"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvTim.Columns["SL_THUC_NHAP"].SummaryItem.DisplayFormat = "{0:N2}";

                grvTim.Columns["SL_THUC_NHAP"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTim.Columns["SL_THUC_NHAP"].DisplayFormat.FormatString = "{0:N2}";


                grvTim.Columns["MS_DE_XUAT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvTim.Columns["MS_DE_XUAT"].SummaryItem.DisplayFormat = "{0:N0}";

                grvTim.Columns["MS_DE_XUAT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTim.Columns["MS_DE_XUAT"].DisplayFormat.FormatString = "{0:N0}";

                grvTim.Columns["MS_DH_NHAP_PT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvTim.Columns["MS_DH_NHAP_PT"].SummaryItem.DisplayFormat = "{0:N0}";

                grvTim.Columns["MS_DH_NHAP_PT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTim.Columns["MS_DH_NHAP_PT"].DisplayFormat.FormatString = "{0:N0}";

                try
                {
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TongVT", Commons.Modules.TypeLanguage) +
                        " " + grvTim.RowCount + "  ";
                }
                catch { }


                if (!grvTim.Columns["MS_KHO"].Visible) return;
                grvTim.Columns["MS_KHO"].Visible = false;             
                grvTim.Columns["TEN_PT"].Width = 260;
                grvTim.Columns["QUY_CACH"].Width = 260;
                grvTim.Columns["MS_DE_XUAT"].Width = 110;
                grvTim.Columns["TEN_TO"].Width = 110;
                grvTim.Columns["TEN_KHO"].Width = 100;
                grvTim.Columns["SL_DE_XUAT"].Width = 70;
                grvTim.Columns["TEN_1"].Width = 100;
                grvTim.Columns["GHI_CHU"].Width = 250;
                grvTim.Columns["MS_PT"].Width = 150;
            }
            catch { }
        }

        private void LocData()
        {
            if (Commons.Modules.SQLString == "0loadPT") return;

            string sTim = "";
            try
            {
                string dk = "";

                if ((int)cboKho.EditValue != -1) sTim = "     (MS_KHO = " + cboKho.EditValue.ToString() + ") ";
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_DE_XUAT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_TO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_DH_NHAP_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_CONG_TY LIKE '%" + txtTKiem.Text + "%' " + dk;


                //(TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                if(dk.Length>0) dk = " AND (" + dk.Substring(4, dk.Length - 4) + ")      ";
                sTim = (sTim.Length > 0 ? sTim +  dk : dk);
                if (sTim.Length > 5) sTim = sTim.Substring( 4, sTim.Length - 4);
                dtData.DefaultView.RowFilter = sTim;
            }
            catch 
            { dtData.DefaultView.RowFilter = ""; }
            try
            {
                lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TongVT", Commons.Modules.TypeLanguage) +
                    " " + grvTim.RowCount + "  "; 
            }
            catch {
                lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TongVT", Commons.Modules.TypeLanguage) +
                 " 0 ";
            }


        }

        private void cboKho_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void txtMaVT_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void txtTenVT_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            TaoData();
        } 

        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            TaoData();
        }

        private void datTNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (datDNgay.DateTime.ToString() == "01/01/0001 00:00:00") return;
                if (!KiemNgay((DateTime)e.NewValue, datDNgay.DateTime)) e.Cancel = true;
            }
            catch { }
        }


        private Boolean KiemNgay(DateTime TNgay, DateTime DNgay)
        {
            try
            {
                if (TNgay > DNgay)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TNgayNhoHonDNgay", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch { return false; }
            return true;
        }

        private void datDNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {

                if (datTNgay.DateTime.ToString() == "01/01/0001 00:00:00") return;
                if (!KiemNgay(datTNgay.DateTime, (DateTime)e.NewValue)) e.Cancel = true;
            }
            catch { }
        }

        private void radTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocData();
        }
    }
}