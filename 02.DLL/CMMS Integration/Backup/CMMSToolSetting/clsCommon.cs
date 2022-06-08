using System;
using System.Collections.Generic;
using System.Text;

namespace H2Tool
{
    public class clsCommon
    {
        public clsCommon() { }

        private const int _CODE = 354;

        public static string VSDecode(string str)
        {
            double dLen = str.Length;
            string sTam = "";

            for (int i = 1; i <= dLen; i++)
            {

                sTam += Microsoft.VisualBasic.Strings.ChrW((Microsoft.VisualBasic.Strings.AscW(Microsoft.VisualBasic.Strings.Mid(str, i, 1)) / 2) - _CODE).ToString();
            }

            return sTam;
        }

        public static string VSEncode(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
            {
                sTam += Microsoft.VisualBasic.Strings.ChrW((Microsoft.VisualBasic.Strings.AscW(Microsoft.VisualBasic.Strings.Mid(str, i, 1)) + _CODE) * 2).ToString();
            }

            return sTam;
        }
       

    }
}
