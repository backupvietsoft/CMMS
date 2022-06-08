using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Fontvs
    {
        /// <summary>
        /// Convet from string
        /// </summary>
        public static Font ToFont(string strID)
        {
            try
            {
                Sqlvs sqlFont = new Sqlvs();
                System.Data.DataTable tbFont = new System.Data.DataTable();
                tbFont.Load(sqlFont.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_S_FONT_DESIGN", strID));
                switch (int.Parse(tbFont.Rows[0]["FONT_STYLE"].ToString()))
                {
                    case 2:
                        return new Font(tbFont.Rows[0]["FONT_NAME"].ToString(), float.Parse(tbFont.Rows[0]["FONT_SIZE"].ToString()), FontStyle.Bold);
                    case 3:
                        return new Font(tbFont.Rows[0]["FONT_NAME"].ToString(), float.Parse(tbFont.Rows[0]["FONT_SIZE"].ToString()), FontStyle.Italic);
                    case 4:
                        return new Font(tbFont.Rows[0]["FONT_NAME"].ToString(), float.Parse(tbFont.Rows[0]["FONT_SIZE"].ToString()), FontStyle.Bold | FontStyle.Italic);
                    default:
                        return new Font(tbFont.Rows[0]["FONT_NAME"].ToString(), float.Parse(tbFont.Rows[0]["FONT_SIZE"].ToString()), FontStyle.Regular);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
