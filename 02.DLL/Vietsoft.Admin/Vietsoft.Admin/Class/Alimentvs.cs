using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms ;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Alimentvs
    {
        /// <summary>
        /// Canh lề cho control kiểu HorizontalAlignment
        /// </summary>
        public static HorizontalAlignment HoriAliment(string strID)
        {
            try
            {
                Sqlvs sqlAliment = new Sqlvs();
                switch (Convert.ToInt32(sqlAliment.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_HALIMENT_DESIGN", strID)))
                {                    
                    case 3:
                        return HorizontalAlignment.Center;
                    case 4:
                        return HorizontalAlignment.Right;
                    default:
                        return HorizontalAlignment.Left;
                }
            }
            catch
            {
                return HorizontalAlignment.Left;
            }
        }
        /// <summary>
        /// Canh lề cho control kiểu ContentAlignment
        /// </summary>
        public static ContentAlignment ContentAliment(string strID)
        {
            try
            {
                Sqlvs sqlAliment = new Sqlvs();
                switch (Convert.ToInt32(sqlAliment.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_CALIMENT_DESIGN", strID)))
                {
                    case 1:
                        return ContentAlignment.TopLeft;
                    case 2:
                        return ContentAlignment.TopCenter;
                    case 3:
                        return ContentAlignment.TopRight;
                    case 5:
                        return ContentAlignment.MiddleCenter;
                    case 6:
                        return ContentAlignment.MiddleRight;
                    case 7:
                        return ContentAlignment.BottomLeft;
                    case 8:
                        return ContentAlignment.BottomCenter;
                    case 9:
                        return ContentAlignment.BottomRight;
                    default:
                        return ContentAlignment.MiddleLeft;
                }
            }
            catch
            {
                return ContentAlignment.MiddleLeft;
            }
        }
        /// <summary>
        /// Canh lề cho control kiểu ContentAlignment
        /// </summary>
        public static DataGridViewContentAlignment DataGridViewContentAliment(string strID)
        {
            try
            {
                Sqlvs sqlAliment = new Sqlvs();
                switch (Convert.ToInt32(sqlAliment.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_CALIMENT_DESIGN", strID)))
                {
                    case 1:
                        return DataGridViewContentAlignment.TopLeft;
                    case 2:
                        return DataGridViewContentAlignment.TopCenter;
                    case 3:
                        return DataGridViewContentAlignment.TopRight;
                    case 5:
                        return DataGridViewContentAlignment.MiddleCenter;
                    case 6:
                        return DataGridViewContentAlignment.MiddleRight;
                    case 7:
                        return DataGridViewContentAlignment.BottomLeft;
                    case 8:
                        return DataGridViewContentAlignment.BottomCenter;
                    case 9:
                        return DataGridViewContentAlignment.BottomRight;
                    default:
                        return DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch
            {
                return DataGridViewContentAlignment.MiddleLeft;
            }
        }
    }
}
