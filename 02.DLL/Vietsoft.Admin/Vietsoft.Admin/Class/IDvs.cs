using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class IDvs
    {
        /// <summary>
        /// Hàm tạo mã
        /// </summary>
        public static string CREATE_ID(string strID)
        {
            try
            {                
                Sqlvs sqlID = new Sqlvs();
                string ID = String.Empty;
                DateTime ID_D = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)sqlID.ExecuteScalar(CommandType.StoredProcedure, "SP_S_CREATE_ID", strID, ID_D);
                return ID;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm tạo mã
        /// </summary>
        public static string CREATE_ID(string strID , DateTime dtID )
        {
            try
            {
                Sqlvs sqlID = new Sqlvs();
                string ID = String.Empty;
                DateTime ID_D = DateTime.ParseExact(dtID.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)sqlID.ExecuteScalar(CommandType.StoredProcedure, "SP_S_CREATE_ID", strID, ID_D);
                return ID;
            }
            catch
            {
                return null;
            }
        }
    }
}
