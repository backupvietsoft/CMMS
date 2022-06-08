using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

namespace Vietsoft
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
                string ID = String.Empty;
                DateTime ID_D = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, "SP_S_CREATE_ID", strID, ID_D);
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
                
                string ID = String.Empty;
                DateTime ID_D = DateTime.ParseExact(dtID.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, "SP_S_CREATE_ID", strID, ID_D);
                return ID;
            }
            catch
            {
                return null;
            }
        }
    }
}
