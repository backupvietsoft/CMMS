using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
namespace Vietsoft.Admin
{
    public static class Colorvs
    {
        /// <summary>
        /// Convet from string
        /// </summary>
        public static Color ToColor(string strID)
        {
            try
            {
                Sqlvs sqlColor = new Sqlvs();
                return Color.FromName(sqlColor.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_COLOR_DESIGN", strID).ToString());
            }
            catch
            {
                return Color.Empty;
            }
        }
    }
}
