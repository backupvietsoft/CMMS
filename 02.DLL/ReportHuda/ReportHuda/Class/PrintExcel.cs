using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace ReportHuda.Class
{
    public class PrintExcel
    {
        public PrintExcel()
        {

        }
        public static void GetImage(byte[] Logo)
        {
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }

        //Prints_PBT_KIDO ("WO-201001002", 1 ,2)
        public static void Prints_PBT_KIDO(string ms_phieu_bt, int kho, int status)
        {
            SaveFileDialog f = new SaveFileDialog();
            string path = "";
            f.Filter = "Excel file (*.xls)|*.xls";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.OK))
                {
                    path = f.FileName;

                }
                else
                    return;
            }
            catch
            {

            }
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
            DataTable vtbPBT = new DataTable();
            vtbPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_PHIEU_BAO_TRI", ms_phieu_bt, Commons.Modules.TypeLanguage));
            DataTable vtbCongViec = new DataTable();
            vtbCongViec.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_VIEC_BAO_TRI", ms_phieu_bt));
            DataTable vtbCongNhan = new DataTable();
            vtbCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_NHAN_BAO_TRI", ms_phieu_bt));
            DataTable vtbDichVu = new DataTable();
            vtbDichVu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_DICH_VU_THUE_NGOAI", ms_phieu_bt));
            DataTable vtbVatTu = new DataTable();
            vtbVatTu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_PHIEU_BAO_TRI", ms_phieu_bt, status, Commons.Modules.TypeLanguage));
            DataTable vtbPhuTung = new DataTable();
            vtbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHU_TUNG_PHIEU_BAO_TRI", ms_phieu_bt, status, Commons.Modules.TypeLanguage, kho));
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook;
            object missValue = System.Reflection.Missing.Value;
            excelWorkbook = excelApplication.Workbooks.Add(missValue);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int rows = 1;
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows+1, "E"]);
            CurCell.MergeCells = true ;
            //CurCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            CurCell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 90, 25);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            CurCell.Font.Bold = true;
            CurCell.Font.Size = 12;
            CurCell.Value2 ="                                   " +  dtTmp.Rows[0]["TEN_CTY"];

            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            a3.Font.Size = 12;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_IN", Commons.Modules.TypeLanguage);
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Font.Size = 12;
            a3.Value2 =" " + vtbPBT.Rows[0]["NGAY_LAP"].ToString().Substring(0,10);
            
            rows = 4;
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Font.Size = "16";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TIEU_DE", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            ///
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.Font.Size = "12";
            a3.Font.Bold = false;
            a3.ColumnWidth = 34;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "MS_MAY", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.Merge(true);
            a3.Font.Bold = true;

            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Value2 =" " + vtbPBT.Rows[0]["MS_MAY"];
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);

         
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHIEU_BAO_TRI", Commons.Modules.TypeLanguage);
            ///
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Value2 =" " + vtbPBT.Rows[0]["SO_PHIEU_BAO_TRI"];
            rows++;
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            //a3.ColumnWidth =34;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TEN_MAY", Commons.Modules.TypeLanguage);

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
         
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Value2 =" " + vtbPBT.Rows[0]["TEN_MAY"];
            ///
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);

            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_LAP", Commons.Modules.TypeLanguage);
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);

            a3.Value2 = DateTime.Now.ToString("dd/MM/yyyy");// vtbPBT.Rows[0]["NGAY_LAP"];
            /////
            rows++;
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);

            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TINH_TRANG", Commons.Modules.TypeLanguage);
            //////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Value2 =" " + vtbPBT.Rows[0]["TEN_TINH_TRANG"];
            /////
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);

            a3.Font.Bold = true;
            a3.Font.Underline = true;
            a3.Value2 = "I." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "MO_TA", Commons.Modules.TypeLanguage);
            ////
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "HINH_THUC_BT", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            a3.Value2 =" " + vtbPBT.Rows[0]["TEN_HT_BT"];
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);

            a3.Merge(true);
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "LOAI_BT", Commons.Modules.TypeLanguage) + "    " + vtbPBT.Rows[0]["TEN_LOAI_BT"];
            ////
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DIA_DIEM", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            a3.Value2 =" " + vtbPBT.Rows[0]["DIA_DIEM"];
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TINH_TRANG_MAY", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            a3.Value2 =" " + vtbPBT.Rows[0]["TEN_LOAI_BT"];
            //
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);

            a3.Font.Bold = true;
            a3.Font.Underline = true;
            a3.Value2 = "II." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "KE_HOACH", Commons.Modules.TypeLanguage);
            ////
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_BD", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.Value = " " + Convert.ToDateTime(vtbPBT.Rows[0]["NGAY_BD_KH"]).ToString("dd/MM/yyyy");
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);

            a3.Merge(true);
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_KT", Commons.Modules.TypeLanguage) + "    " + Convert.ToDateTime(vtbPBT.Rows[0]["NGAY_KT_KH"]).ToString("dd/MM/yyyy");
            ////
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "BO_PHAN_CP", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            a3.Value2 = vtbPBT.Rows[0]["BO_PHAN"];
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);

            a3.Merge(true);
            a3.Value2 = "    " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "LY_DO_BT", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);

            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            a3.Value2 = vtbPBT.Rows[0]["LY_DO_BT"];
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Font.Underline = true;
            a3.Value2 = "III." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DANH_SACH_CV", Commons.Modules.TypeLanguage);
            rows++;
            int _start_cv = rows;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.ColumnWidth = 34;
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_CONG_VIEC", Commons.Modules.TypeLanguage);
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "B"]);

            a3.ColumnWidth = 14;
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TS_CHUAN", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "C"]);

            a3.Font.Bold = true;
            a3.ColumnWidth = 14;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TS_TT", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "D"]);

            a3.Font.Bold = true;
            a3.ColumnWidth = 20;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DANH_GIA", Commons.Modules.TypeLanguage);
            ////

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);

            a3.Font.Bold = true;
            a3.ColumnWidth = 20;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DANH_GIA_SAU_NGHIEM_THU", Commons.Modules.TypeLanguage);
            ////
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
            a3.ColumnWidth = 14;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
            a3.ColumnWidth = 10;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
           
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TH", Commons.Modules.TypeLanguage);
            excelApplication.ActiveWindow.DisplayGridlines = true;
            
            foreach (DataRow dr in vtbCongViec.Rows)
            {
                rows++;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                a3.WrapText = true;
                a3.Value2 = dr["MO_TA_CV"];
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "D"]);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "\u2686 Đạt     \u2686 Không đạt";
               
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "\u2686 Đạt     \u2686 Không đạt";
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
                a3.Merge(true);
            }
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.WrapText = true;
            a3.Value2 = "Tổng Thời Gian";
            a3.Font.Bold = true;

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_cv, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Borders.LineStyle = 1;
            rows+=2;
           
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.Font.Underline = true;
                a3.Value2 = "IV." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DS_NV", Commons.Modules.TypeLanguage);
                rows++;
                _start_cv = rows;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);

                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_HO_TEN", Commons.Modules.TypeLanguage);
                /////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "C"]);

                a3.Merge(true);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TO_PB", Commons.Modules.TypeLanguage);
                ////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "D"]);

                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TU_NGAY", Commons.Modules.TypeLanguage);
                ////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);

                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DEN_NGAY", Commons.Modules.TypeLanguage);
                ////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);

                a3.Merge(true);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_LOAI_VN", Commons.Modules.TypeLanguage);
                foreach (DataRow dr in vtbCongNhan.Rows)
                {
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                    a3.Value2 = dr["HO_TEN"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "C"]);
                    a3.Merge(true);
                    a3.Value2 = dr["BAN_TO"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Value =" " + Convert.ToDateTime(dr["TU_NGAY"]).ToString("dd/MM/yyyy HH:MM");
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                    a3.Value = " " + Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy HH:MM");
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "G"]);
                    a3.Merge(true);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.Value2 = dr["CHINH_PHU"];
                }
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_cv, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Borders.LineStyle = 1;
            
            rows+=2;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Font.Bold = true;
            a3.Merge(true);
            a3.Font.Underline = true;
            a3.Value2 = "V." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DS_DC", Commons.Modules.TypeLanguage);
            rows += 4;
          
              
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.Font.Underline = true;
                a3.Value2 = "VI." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DS_PT", Commons.Modules.TypeLanguage);
                rows++;
                _start_cv = rows;
                /////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PT", Commons.Modules.TypeLanguage);
                ////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PT", Commons.Modules.TypeLanguage);
                ////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_KH", Commons.Modules.TypeLanguage);
                ///////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
                a3.Font.Bold = true;

                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "QUY_CACH", Commons.Modules.TypeLanguage);
                ///////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;

                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DVT", Commons.Modules.TypeLanguage);
                foreach (DataRow dr in vtbPhuTung.Rows)
                {
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                    a3.Value2 = dr["MS_PT"].ToString();
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Value2 = dr["TEN_PT"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                    a3.Value2 = dr["SL_KH"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
                    a3.WrapText = true;
                    a3.Value2 = dr["QUY_CACH"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
                    a3.Value2 = dr["DVT"];
                }
                rows += 3;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_cv, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Borders.LineStyle = 1;
         /////
                rows+=2;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.Font.Underline = true;
                a3.Value2 = "VII." + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DS_VT", Commons.Modules.TypeLanguage);
                rows++;
                _start_cv = rows;
                /////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PT", Commons.Modules.TypeLanguage);
                ////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PT", Commons.Modules.TypeLanguage);
                ////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                a3.Font.Bold = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_KH", Commons.Modules.TypeLanguage);
                ///////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
                a3.Font.Bold = true;

                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "QUY_CACH", Commons.Modules.TypeLanguage);
                ///////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;

                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DVT", Commons.Modules.TypeLanguage);
                foreach (DataRow dr in vtbVatTu.Rows)
                {
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                    a3.Value2 = dr["MS_PT"].ToString();
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Value2 = dr["TEN_PT"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                    a3.Value2 = dr["SL_KH"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "F"], excelWorkSheet.Cells[rows, "F"]);
                    a3.WrapText = true;
                    a3.Value2 = dr["QUY_CACH"];
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "G"], excelWorkSheet.Cells[rows, "G"]);
                    a3.Value2 = dr["DVT"];
                }
                rows += 3;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_cv, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Borders.LineStyle = 1;
           
            ////////////

                rows += 2;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
                a3.Font.Bold = true;
                a3.Merge(true);
                a3.Font.Underline = true;
                a3.RowHeight = 24;
                //excelApplication.Visible = true;

                //a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                a3.Value2 = "VIII: KPI";

                rows += 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);                
                a3.Merge(true);
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Tổng số công việc có kế hoạch đã thực hiện" + "\r\n" + "Number of Planned Work Orders Executed";
                a3.get_Characters(1, ("Tổng số công việc có kế hoạch đã thực hiện").Length).Font.Bold = true ;
                
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.Merge(true);
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Tổng số công việc theo có kế hoạch" + "\r\n" + "Number of Work Orders Planned";
                a3.get_Characters(1, ("Tổng số công việc theo có kế hoạch").Length).Font.Bold = true;
                
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);                
                a3.Merge(true);
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "% Tuân thủ bảo trì có kế hoạch" + "\r\n" + "Maintenance Plan Adherence (%)";
                a3.get_Characters(1, ("% Tuân thủ bảo trì có kế hoạch").Length).Font.Bold = true;
                rows += 1;
                //excelWorkSheet.Range[excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows + 1, 1]].Merge();
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, 1], excelWorkSheet.Cells[rows+1, 1]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 1, "D"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                

                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 1, "G"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                

            ///
                rows += 2;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);                
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Thời gian hoàn thành công việc có kế hoạch" + "\r\n" + "Hours on All Completed Planned Work Orders";
                a3.get_Characters(1, ("Thời gian hoàn thành công việc có kế hoạch").Length).Font.Bold = true;

                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Thời gian hoàn thành công việc có" + "\r\n" + "kế hoạch và không có kế hoạch" + "\r\n" + "Hours on All Completed Work Orders (Planned + Unplanned)";
                a3.get_Characters(1, ("Thời gian hoàn thành công việc có" + "\r\n" + "kế hoạch và không có kế hoạch").Length).Font.Bold = true;
                

                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "% Hiệu quả bảo trì có kế hoạch" + "\r\n" + "Planned Maintenance Effectiveness (%)";
                a3.get_Characters(1, ("% Hiệu quả bảo trì có kế hoạch").Length).Font.Bold = true;

            rows += 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows + 1, "A"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 1, "D"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 1, "G"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                ///
                rows += 2;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Chi phí bảo trì phòng ngừa" + "\r\n" + "Planned Maintenance Cost ($)";
                a3.get_Characters(1, ("Chi phí bảo trì phòng ngừa").Length).Font.Bold = true;



                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Tổng chi phí bảo trì" + "\r\n" + "Total Maintenance Cost ($)";
                a3.get_Characters(1, ("Tổng chi phí bảo trì").Length).Font.Bold = true;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "% Chi phí bảo trì phòng ngừa" + "\r\n" + "Preventive Maintenance Relative Cost (%)";
                a3.get_Characters(1, ("% Chi phí bảo trì phòng ngừa").Length).Font.Bold = true;

                rows += 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows + 1, "A"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 1, "D"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 1, "G"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                ///

                ///
                rows += 2;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Số giờ lao động thực tế theo" + "\r\n" + "kế hoạch và không theo kế hoạch" + "\r\n" + "Actual Labor Hours on Work Orders (Planned + Unplanned)";
                a3.get_Characters(1, ("Số giờ lao động thực tế theo" + "\r\n" + "kế hoạch và không theo kế hoạch").Length).Font.Bold = true;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "Số giờ lao động bảo trì dự kiến" + "\r\n" + "Maintenance Labor Hours for Period";
                a3.get_Characters(1, ("Số giờ lao động bảo trì dự kiến").Length).Font.Bold = true;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                a3.Value2 = "% Hiệu quả lao động bảo trì" + "\r\n" + "Maintenance Labor Effectiveness (%)";
                a3.get_Characters(1, ("% Hiệu quả lao động bảo trì").Length).Font.Bold = true;

                rows += 1;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows + 1, "A"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 1, "D"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 1, "G"]);
                a3.Font.Bold = true;
                a3.MergeCells = true;
                a3.WrapText = true;
                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                ///
            //////////////
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows - 10, "A"], excelWorkSheet.Cells[rows+1, "G"]);
                a3.Borders.LineStyle = 1;

            //////
            rows+=4;
            







            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.Font.Bold = true;
            a3.Value2 =Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DE_XUAT_CUA_NGUOI_BT", Commons.Modules.TypeLanguage);
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Value2 = ".......................................................................................................................................................................................................................................................";
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Value2 = ".......................................................................................................................................................................................................................................................";
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Value2 = ".......................................................................................................................................................................................................................................................";
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Value2 = ".......................................................................................................................................................................................................................................................";
            rows+=2;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = "*********************************************************************************";
                rows++;
                

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "ngay", Commons.Modules.TypeLanguage) + " ...."
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "thang", Commons.Modules.TypeLanguage) + " .... "
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "nam", Commons.Modules.TypeLanguage) + " ....";


            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Merge(true);
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "ngay", Commons.Modules.TypeLanguage) + " ...."
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "thang", Commons.Modules.TypeLanguage) + " .... "
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "nam", Commons.Modules.TypeLanguage) + " ....";

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "ngay", Commons.Modules.TypeLanguage) + " ...."
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "thang", Commons.Modules.TypeLanguage) + " .... "
                        + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "nam", Commons.Modules.TypeLanguage) + " ....";

            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.Value2 = "" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_DANH_GIA", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Merge(true);
            a3.Value2 =Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_XAC_NHAN", Commons.Modules.TypeLanguage);
            //a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
            //a3.Merge(true);
            //a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "ngay", Commons.Modules.TypeLanguage) + " ...."
            //            + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "thang", Commons.Modules.TypeLanguage) + " .... "
            //            + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "nam", Commons.Modules.TypeLanguage) + " ....";
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TRUONG_PHONG_BT", Commons.Modules.TypeLanguage);

            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "A"]);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Value2 = "" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "BO_PHAN_BT", Commons.Modules.TypeLanguage);

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.Merge(true);
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_DUOC_BT", Commons.Modules.TypeLanguage);
            
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Font.Size = 12;
            a3.Font.Name = "Times New Roman";
            excelApplication.ActiveWindow.DisplayGridlines = true;


            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            excelWorkSheet.PageSetup.LeftMargin = 0.7;
            excelWorkSheet.PageSetup.RightMargin = 0.7;
            excelWorkSheet.PageSetup.BottomMargin = 0.75;
            excelWorkSheet.PageSetup.TopMargin = 0.75;
            excelWorkSheet.PageSetup.FooterMargin = 0.3;
            excelWorkSheet.PageSetup.HeaderMargin = 0.3;
            excelWorkSheet.PageSetup.Zoom = 75;
            excelWorkbook.SaveAs( f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue,
                                     missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive,
                                     missValue, missValue, missValue, missValue);
            excelApplication.Visible = true;
        }
        public static void  Prints(string ms_phieu_bt,string ms_may,int lang)
        {
            SaveFileDialog f = new SaveFileDialog();
            string path = "";
            f.Filter = "Excel file (*.xls)|*.xls";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.OK))
                {
                    path = f.FileName;

                }
                else
                    return;
            }
            catch
            {

            }
            DataTable dtTitle = new DataTable();
            dtTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_TITLE_BT_TB_HUDA", ms_phieu_bt));
            
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG",lang));       

            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook;
            object missValue = System.Reflection.Missing.Value;
            excelWorkbook = excelApplication.Workbooks.Add(missValue);

            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int rows = 1;
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows+3, "B"]);
            CurCell.MergeCells = true;
            GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 180, 50);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Value2 =Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
            rows++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "G"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Value2 ="Email : "  + dtTmp.Rows[0]["EMAIL"];
            

            rows++; 
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Font.Size = "14";
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "noidungbaotrisuachuathietbi", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "thoigianthuchien", Commons.Modules.TypeLanguage) + " : " + Convert.ToDateTime(dtTitle.Rows[0]["NGAY_BD_KH"]).ToShortDateString();
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "MS_MAY", Commons.Modules.TypeLanguage) + " : " + dtTitle.Rows[0]["MS_MAY"];
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage) + " : " + dtTitle.Rows[0]["MS_PHIEU_BAO_TRI"];
            rows++;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "TEN_MAY", Commons.Modules.TypeLanguage) + " : " + dtTitle.Rows[0]["TEN_MAY"];
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "LOAI_BAO_TRI", Commons.Modules.TypeLanguage) + " : " + dtTitle.Rows[0]["TEN_LOAI_BT"];
            rows += 2;
            int _start_border = rows;
            //STT
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "A"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "STT", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "5";
            //NOI DUNG CONG VIEC
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "B"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "NOIDUNGCONVIEC", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "30";
            //VAT TU PHU TUNG
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "PHUTUNGVATTU", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "30";
            //SO LUONG
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "SOLUONG", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "10";
            //DON VI TINH
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "DVT", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "10";
            //NGUOI THUC HIEN
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "NGUOITHUCHIEN", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "30";
            //CHECK
            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "G"];
            a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "CHECK", Commons.Modules.TypeLanguage);
            a3.Font.Bold = true;
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3.ColumnWidth = "10";
            DataTable _table_value = new DataTable();
            _table_value.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_VTPT_BY_ID", ms_phieu_bt, ms_may, lang));
            DataTable _table_bo_phan = new DataTable();
            _table_bo_phan=_table_value.DefaultView.ToTable("BO_PHAN", true, "MS_BO_PHAN", "TEN_BO_PHAN");
            string ms_bp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "MS_BO_PHAN", Commons.Modules.TypeLanguage); 
            string ten_bp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "TEN_BO_PHAN", Commons.Modules.TypeLanguage); 
            string ms_bp_value,ten_bp_value;
            DataTable _table_cv,_table_vt_pt,_table_ns;
            string ms_cv, ten_cv,ten_cn="";
            int _start_row = 0;
            foreach (DataRow _row_bp in _table_bo_phan.Rows)
            {
                rows++;
                ten_cn = "";
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                a3.Merge(true);
                ms_bp_value=_row_bp["MS_BO_PHAN"].ToString();
                ten_bp_value=_row_bp["TEN_BO_PHAN"].ToString();
                a3.Value2 = ten_bp + " : " + ten_bp_value;
                a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "G"]);
                a3.Merge(true);
                a3.Value2=ms_bp + " : " + ms_bp_value;
                _table_cv = new DataTable();
                _table_value.DefaultView.RowFilter = "MS_BO_PHAN='" + ms_bp_value + "'";
                _table_cv = _table_value.DefaultView.ToTable(true,"MS_CV","MO_TA_CV");
                
                int i=0;
                foreach (DataRow  _row_cv in _table_cv.Rows)
                {
                    rows++;
                    _start_row = rows;
                    i++;
                    ms_cv = _row_cv["MS_CV"].ToString();
                    ten_cv = _row_cv["MO_TA_CV"].ToString();
                   
                  
                    _table_vt_pt = new DataTable();
                    _table_value.DefaultView.RowFilter = "MS_BO_PHAN='" + ms_bp_value + "' AND MS_CV='" + ms_cv  + "'";
                    _table_vt_pt = _table_value.DefaultView.ToTable(true,"MS_PT","TEN_PT","SL_KH","DVT");
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                    a3.WrapText = true;
                    a3.Value2 = _table_vt_pt.Rows[0]["TEN_PT"];
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.Value2 = _table_vt_pt.Rows[0]["SL_KH"];
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.Value2 = _table_vt_pt.Rows[0]["DVT"];
                    _table_ns = new DataTable();
                    _table_value.DefaultView.RowFilter = "MS_BO_PHAN='" + ms_bp_value + "' AND MS_CV='" + ms_cv + "'";
                    _table_ns = _table_value.DefaultView.ToTable(true,"TEN_CN"); 
                    ten_cn = "";
                    foreach (DataRow _row in _table_ns.Rows)
                    {
                      
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                        if (!string.IsNullOrEmpty(ten_cn))
                            ten_cn = ten_cn + ";" + Convert.ToString(_row["TEN_CN"]);
                        else
                        {
                            if(!string.IsNullOrEmpty(Convert.ToString(_row["TEN_CN"])))
                                ten_cn = Convert.ToString(_row["TEN_CN"]);
                        }
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3.WrapText = true;
                        a3.Value2 = ten_cn;
                    }
                   
                    for (int j = 1; j < _table_vt_pt.Rows.Count; j++)
                    {
                        ten_cn = "";
                        rows++;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                        a3.WrapText = true;
                        a3.Value2 = _table_vt_pt.Rows[j]["TEN_PT"];
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3.Value2 = _table_vt_pt.Rows[j]["SL_KH"];
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3.Value2 = _table_vt_pt.Rows[j]["DVT"];
                        _table_value.DefaultView.RowFilter = "MS_BO_PHAN='" + ms_bp_value + "' AND MS_CV='" + ms_cv + "'";
                        _table_ns = _table_value.DefaultView.ToTable(true,"TEN_CN");
                        foreach (DataRow _row in _table_ns.Rows)
                        {
                            a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                            if (!string.IsNullOrEmpty(ten_cn))
                                ten_cn = ten_cn + ";" + Convert.ToString(_row["TEN_CN"]);
                            else
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(_row["TEN_CN"])))
                                    ten_cn = Convert.ToString(_row["TEN_CN"]);
                            }
                            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            a3.WrapText = true;
                            a3.Value2 = ten_cn;
                        }
                    }
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "A"], excelWorkSheet.Cells[rows, "A"]);
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.MergeCells=true;
                    a3.Value2 = i;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "B"], excelWorkSheet.Cells[rows, "B"]);
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.MergeCells=true;
                    a3.WrapText = true;
                    a3.Value2 = ten_cv;
                  
                }
                
            }
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_border, "A"], excelWorkSheet.Cells[rows, "G"]);
            a3.Borders.LineStyle = 1;
            rows += 3;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "C"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "Duyet", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "F"]);
            a3.Merge(true);
            a3.Font.Bold = true;
            a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "NguoiLap", Commons.Modules.TypeLanguage);
            a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[rows, "G"]);
            a3.Font.Size = 12;
           // excelWorkSheet.Rows.AutoFit();
            //excelWorkSheet.Columns.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;
            excelWorkbook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue,
                                     missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive,
                                     missValue, missValue, missValue, missValue);
            excelApplication.Visible = true;

        }
    }
}
