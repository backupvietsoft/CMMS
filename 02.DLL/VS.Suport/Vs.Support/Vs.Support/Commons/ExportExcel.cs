using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Vs.Support.Commons
{
    public static class ExportExcel
    {
        public static string SaveFiles(string MFilter)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static Excel.Range GetRange(Excel.Worksheet MWsheet, int DongBD, int CotBD, int DongKT, int CotKT)
        {
            try
            {
                // Dim allCells = MWsheet.Cells[DongBD, CotBD, DongKT, CotKT]
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                return MRange;
            }
            catch (Exception)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public static void MReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public static void ColumnWidth(Excel.Worksheet MWsheet, float MColumnWidth, string MNumberFormat, bool MWrapText, int DongBD, int CotBD, int DongKT, int CotKT)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                MRange.ColumnWidth = MColumnWidth;
                if (MNumberFormat != "")
                    MRange.NumberFormat = MNumberFormat;
                MRange.WrapText = MWrapText;
            }
            catch (Exception)
            {
            }
        }
        public static void DinhDang(Excel.Worksheet MWsheet, string NoiDung, int Dong, int Cot, String MNumberFormat, float MFontSize, bool MFontBold, Excel.XlHAlign MHAlign, Excel.XlVAlign MVAlign, bool MMerge, int MDongMerge, int MCotMerge, int MRowHeight)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[Dong, Cot], MWsheet.Cells[MDongMerge, MCotMerge]];
                MRange.Merge(MMerge);
                if (MFontSize > 0)
                    MRange.Font.Size = MFontSize;

                MRange.Font.Bold = MFontBold;
                MRange.HorizontalAlignment = MHAlign;
                MRange.VerticalAlignment = MVAlign;
                MRange.RowHeight = MRowHeight;

                if (MNumberFormat != "")
                    MRange.NumberFormat = MNumberFormat;
                if (NoiDung != "")
                    MWsheet.Cells[Dong, Cot] = NoiDung;
                MRange.Borders.LineStyle = 0;
            }
            catch
            {
            }
        }

        public static void MExportExcel(DataTable dtTmp, Excel.Worksheet ExcelSheets, Excel.Range sRange, bool bheader)
        {
            if (bheader)
            {
                object[,] rawData = new object[dtTmp.Rows.Count + 1, dtTmp.Columns.Count - 1 + 1];
                for (var col = 0; col <= dtTmp.Columns.Count - 1; col++)
                    rawData[0, col] = dtTmp.Columns[col].ColumnName;
                for (var col = 0; col <= dtTmp.Columns.Count - 1; col++)
                {
                    for (var row = 0; row <= dtTmp.Rows.Count - 1; row++)
                        rawData[row + 1, col] = dtTmp.Rows[row][col].ToString();
                }
                sRange.Value = rawData;
         
            }
            else
            {
                object[,] rawData = new object[dtTmp.Rows.Count, dtTmp.Columns.Count];
                for (var col = 0; col <= dtTmp.Columns.Count - 1; col++)
                {
                    for (var row = 0; row <= dtTmp.Rows.Count - 1; row++)
                        rawData[row, col] = dtTmp.Rows[row][col].ToString();
                }
                sRange.Value = rawData;
            }
        }
    }
}
