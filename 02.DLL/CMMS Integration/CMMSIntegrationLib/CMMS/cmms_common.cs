using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using CMMSIntegrationLib;

namespace CMMSIntegrationLib.CMMS
{
    public class cmms_common
    {
        public static string cmms_connection = "";
        public static bool GetDBInfo()
        {
            if (File.Exists(Application.StartupPath + "\\CMMSInfo.xml"))
            {
                DataSet _dsDatasource = new DataSet();
                _dsDatasource.ReadXml(Application.StartupPath + "\\CMMSInfo.xml");
                DataTable datasource = _dsDatasource.Tables[0];
                if (datasource.Rows.Count > 0)
                {
                    cmms_connection = "Server=" + datasource.Rows[0]["Server"].ToString() + ";Database=" + datasource.Rows[0]["Database"].ToString() + ";User Id=" + datasource.Rows[0]["User"].ToString() + ";Password=" + clsCommon.VSDecode(datasource.Rows[0]["Pass"].ToString()) + " ;Connection Timeout=99999";
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}
