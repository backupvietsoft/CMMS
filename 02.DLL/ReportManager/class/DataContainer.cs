using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace ReportManager
{
    public class DataContainer
    {
        public DataContainer()
        {
            list = new SortedList();
        }

        public void Get(string key, ref bool val) { val = System.Convert.ToBoolean(ParseKeyGetter(key)); }
        public void Get(string key, ref int val) { val = System.Convert.ToInt32(ParseKeyGetter(key)); }
        public void Get(string key, ref double val) { val = System.Convert.ToDouble(ParseKeyGetter(key)); }
        public void Get(string key, ref DataMatrix val) { val = (DataMatrix)ParseKeyGetter(key); }

        public bool GetBool(string key) { return System.Convert.ToBoolean(ParseKeyGetter(key)); }
        public int GetInt(string key) { return System.Convert.ToInt32(ParseKeyGetter(key)); }
        public double GetDouble(string key) { return System.Convert.ToDouble(ParseKeyGetter(key)); }
        public DataMatrix GetMatrix(string key) { return (DataMatrix)ParseKeyGetter(key); }

        public void Set(string key, Object val) { ParseKeySetter(key, val); }
        public string this[string index]
        {
            get { return ParseKeyGetter(index).ToString(); }
            set { ParseKeySetter(index, value); }
        }

        // Replace all {<var>} with <value>

        // For example, the key "{n}" would be replaced with the value of n
        // The key "list(0, 1)" would be replaced with the value of the cell (0, 1) of the matrix list
        // The key "list(0, {n})" would be replaced with the value of the cell (0, n') of the matrix list, where n' is the value of n
        // The getter function assumes that the entire variable name is enclosed in {}, and only the variable name is passed in here.
        protected virtual object ParseKeyGetter(string key)
        {
            string var = key;
            int i = var.IndexOf('{');
            while (i != -1)
            {
                int j = var.IndexOf('}');
                if (j != -1)
                {
                    string subVar = var.Substring(i + 1, j - i - 1);
                    string val = this[subVar];
                    var = var.Remove(i, j - i + 1);
                    var = var.Insert(i, val);
                    i = var.IndexOf('{');
                }
            }
            int n = var.IndexOf('(');
            if (n != -1)
            {
                DataMatrix dm = GetMatrix(var.Substring(0, n));
                int m = var.IndexOf(',');
                int x = System.Convert.ToInt32(var.Substring(n + 1, m - n - 1));
                n = var.IndexOf(')');
                Debug.Assert(n != -1, "Missing closing ')'");
                int y = System.Convert.ToInt32(var.Substring(m + 1, n - m - 1));
                var = dm.GetCell(x, y);
                return var;
            }
            return list[var];
        }

        // The setter assumes that any matrix variable that is passed in should have its cell set to the string value of the object.			
        protected virtual void ParseKeySetter(string key, object obj)
        {
            string var = key;
            int i = var.IndexOf('{');
            while (i != -1)
            {
                int j = var.IndexOf('}');
                if (j != -1)
                {
                    string subVar = var.Substring(i + 1, j - i - 1);
                    string val = this[subVar];
                    var = var.Remove(i, j - i + 1);
                    var = var.Insert(i, val);
                    i = var.IndexOf('{');
                }
            }
            int n = var.IndexOf('(');
            if (n != -1)
            {
                DataMatrix dm = GetMatrix(var.Substring(0, n));
                int m = var.IndexOf(',');
                int x = System.Convert.ToInt32(var.Substring(n + 1, m - n - 1));
                n = var.IndexOf(')');
                int y = System.Convert.ToInt32(var.Substring(m + 1, n - m - 1));
                dm.SetCell(x, y, obj.ToString());
            }
            list[var] = obj;
        }

        protected SortedList list;
    }
}
