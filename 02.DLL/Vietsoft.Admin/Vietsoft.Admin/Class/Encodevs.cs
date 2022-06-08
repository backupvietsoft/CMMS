using System;
using System.Text;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Encodevs
    {
        /// <summary>
        /// Mã hóa chuỗi
        /// </summary>
        public static string ToEn(string strCode)
        {
            try
            {
                string strTo = "";
                for (int i = 0; i < strCode.Length; i++)
                {
                    int intChar = (int)strCode[i];
                    if (intChar != 20)
                    {
                        intChar = intChar + (512 + i);
                    }
                    strTo = strTo.Insert(0, ((char)intChar).ToString());
                }
                return strTo;
            }
            catch
            {
                return strCode;
            }
        }
        /// <summary>
        /// Giải mã chuỗi.
        /// </summary>
        public static string DeEn(string strCode)
        {
            try
            {
                string strDe = "";
                for (int i = 0; i < strCode.Length; i++)
                {
                    int intChar = (int)strCode[i];
                    if (intChar != 20)
                    {
                        intChar = intChar - (512 + (strCode.Length - i - 1));
                    }
                    strDe = strDe.Insert(0, ((char)intChar).ToString());
                }
                return strDe;
            }
            catch
            {
                return strCode;
            }
        }
    }
}
