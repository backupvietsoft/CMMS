using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ReportManager
{
    public class DataMatrix
    {
        public DataMatrix(int cols) { this.cols = cols; }
        public DataMatrix(int cols, int rows)
        {
            this.cols = cols;
            for (int i = 0; i < rows; i++)
            {
                AddRow();
            }
        }

        public int GetRows() { return rows.Count; }
        public int GetCols() { return cols; }
        public string GetCell(int x, int y) { return ((string[])rows[y])[x].ToString().Trim(); }
        public int GetCellInt(int x, int y) { return System.Convert.ToInt32(((string[])rows[y])[x]); }
        public long GetCellLong(int x, int y) { return System.Convert.ToInt64(((string[])rows[y])[x]); }
        public double GetCellDouble(int x, int y) { return System.Convert.ToDouble(((string[])rows[y])[x]); }

        public int AddRow()
        {
            string[] columns = new String[cols];
            rows.Add(columns);
            return rows.Count - 1;
        }

        public void SetCell(int x, int y, string s) { ((string[])rows[y])[x] = s; }
        public void SetCell(int x, int y, int i) { ((string[])rows[y])[x] = i.ToString(); }
        public void SetCell(int x, int y, double d) { ((string[])rows[y])[x] = d.ToString(); }

        protected ArrayList rows = new ArrayList();
        protected int cols;
    }
}
