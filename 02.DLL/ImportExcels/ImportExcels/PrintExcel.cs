using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImportExcels
{
    public class MashjExcel
    {
        public static string MashjSaveFiles(string MashjFilter)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = MashjFilter;
            try
            {DialogResult res = f.ShowDialog();}
            catch
            {}
            return f.FileName;
        }
        public static void MashjTaoLogo(Excel.Worksheet MashjWorksheet, int MashjLeft, int MashjTop,
            int MashjWidth, int MashjHeight)
        {
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(
                    Commons.IConnections.ConnectionString, System.Data.CommandType.Text,
                    " SELECT LOGO FROM THONG_TIN_CHUNG"));
                System.Data.DataView dv = new System.Data.DataView(dtTmp);

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
                string strPath = Application.StartupPath + "\\logo.bmp";
                System.IO.MemoryStream stream = new System.IO.MemoryStream((byte[])dv[0]["LOGO"]);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                img.Save(strPath);

                MashjWorksheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse,
                    Office.MsoTriState.msoCTrue, MashjLeft, MashjTop, MashjWidth, MashjHeight);

                System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            }
            catch { }
        }

        public static void MashjThemDong(Excel.Worksheet MashjWorksheet, 
            Excel.Constants DangThem, int SoDongThem, int Dong, int Cot)
        {
            try
            {
                Excel.Range a1 = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, 1], MashjWorksheet.Cells[Dong, Cot]);
                for (int i = 1; i <= SoDongThem; i++)
                {
                    a1.EntireRow.Insert(DangThem);
                }
            }
            catch { }
        }
        public static void MashjDong(Excel.Application MashjApplication, Excel.Workbooks MashjWorkbooks,
            Excel.Workbook MashjWorkbook, Excel.Worksheet MashjWorksheet,Boolean MashjVisible,
            Boolean MashjDisplayGridlines,Boolean RowAutoFit,Boolean ColumnsAutoFit, Excel.XlPaperSize MashjXlPaperSize,
            Excel.XlPageOrientation MashjXlPageOrientation,
            double MashjTopMargin, double MashjBottomMargin, double MashjLeftMargin,double MashjRightMargin,
            double MashjHeaderMargin, double MashjFooterMargin, double MashjZoom)
        {
            try
            {
                MashjWorkbook.Save();
                if (ColumnsAutoFit == true) MashjWorksheet.Columns.AutoFit();
                if (RowAutoFit == true) MashjWorksheet.Rows.AutoFit();
                MashjApplication.ActiveWindow.DisplayGridlines = MashjDisplayGridlines;
                MashjWorksheet.PageSetup.PaperSize = MashjXlPaperSize;
                MashjWorksheet.PageSetup.Orientation = MashjXlPageOrientation;

                
                if (MashjTopMargin != 0) MashjWorksheet.PageSetup.TopMargin = MashjTopMargin;
                if (MashjBottomMargin != 0) MashjWorksheet.PageSetup.BottomMargin = MashjBottomMargin;
                if (MashjLeftMargin != 0) MashjWorksheet.PageSetup.LeftMargin = MashjLeftMargin;
                if (MashjRightMargin != 0) MashjWorksheet.PageSetup.RightMargin = MashjRightMargin;
                if (MashjHeaderMargin != 0) MashjWorksheet.PageSetup.HeaderMargin = MashjHeaderMargin;
                if (MashjFooterMargin != 0) MashjWorksheet.PageSetup.FooterMargin = MashjFooterMargin;
                if (MashjZoom != 0) MashjWorksheet.PageSetup.Zoom = MashjZoom;
                MashjApplication.Visible = MashjVisible;
            }
            catch { }
        }

        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet, string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[Dong, Cot]);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                Mashj.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;

            }
            catch { }
        }

        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet,string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat,
            Excel.XlHAlign MashjHorizontalAlignment,
            Excel.XlVAlign MashjVerticalAlignment)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[Dong, Cot]);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                Mashj.HorizontalAlignment = MashjHorizontalAlignment;
                Mashj.VerticalAlignment = MashjVerticalAlignment;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;

            }
            catch { }
        }
        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet, string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat, Boolean MashjMerge,
            int MashjDongMerge, int MashjCotMerge)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[MashjDongMerge, MashjCotMerge]);
                Mashj.Merge(MashjMerge);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;
            }
            catch { }
        }
        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet, string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat, Boolean MashjMerge,
            int MashjDongMerge, int MashjCotMerge,
            Excel.XlHAlign MashjHorizontalAlignment)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[MashjDongMerge, MashjCotMerge]);
                Mashj.Merge(MashjMerge);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                Mashj.HorizontalAlignment = MashjHorizontalAlignment;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;

            }
            catch { }
        }
        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet, string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat, Boolean MashjMerge,
            int MashjDongMerge, int MashjCotMerge,
            Excel.XlVAlign MashjVerticalAlignment)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[MashjDongMerge, MashjCotMerge]);
                Mashj.Merge(MashjMerge);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                Mashj.VerticalAlignment = MashjVerticalAlignment;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;
            }
            catch { }
        }

        public static void MashjDinhDang(Excel.Worksheet MashjWorksheet, string NoiDung, int Dong, int Cot,
            int MashjSize, Boolean MashjBold, String MashjNumberFormat, Boolean MashjMerge,
            int MashjDongMerge, int MashjCotMerge,
            Excel.XlHAlign MashjHorizontalAlignment,
            Excel.XlVAlign MashjVerticalAlignment)
        {
            try
            {
                Excel.Range Mashj = MashjWorksheet.get_Range(MashjWorksheet.Cells[Dong, Cot], MashjWorksheet.Cells[MashjDongMerge, MashjCotMerge]);
                Mashj.Merge(MashjMerge);
                if (MashjSize > 0) Mashj.Font.Size = MashjSize;
                Mashj.Font.Bold = MashjBold;
                if (MashjNumberFormat != "") Mashj.NumberFormat = MashjNumberFormat;
                Mashj.HorizontalAlignment = MashjHorizontalAlignment;
                Mashj.VerticalAlignment = MashjVerticalAlignment;
                if (NoiDung != "") MashjWorksheet.Cells[Dong, Cot] = NoiDung;
            }
            catch { }
        }
   }
}
