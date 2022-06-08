using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace CMMSIntegrationLib.Common
{
   public class cmmsScheduler
    {
       public static string _SType = string.Empty;
       public static string _SType1Number = string.Empty;
       public static string _SType1Option = string.Empty;
       public static string _SType2Hours = string.Empty;
       public static string _SType2Minutes = string.Empty;
       public static int TimeRunning = 60000;

       public static bool GetRunTimeInfo()
       {
           try
           {
               if (File.Exists(Application.StartupPath + "\\Scheduler.xml"))
               {
                   DataSet _dsDatasource = new DataSet();
                   _dsDatasource.ReadXml(Application.StartupPath + "\\Scheduler.xml");
                   DataTable datasource = _dsDatasource.Tables[0];
                   if (datasource.Rows.Count > 0)
                   {
                       _SType = datasource.Rows[0]["SType"].ToString();
                       _SType1Number = datasource.Rows[0]["SType1Number"].ToString();
                       _SType1Option = datasource.Rows[0]["SType1Option"].ToString();
                       _SType2Hours = datasource.Rows[0]["SType2Hours"].ToString();
                       _SType2Minutes = datasource.Rows[0]["SType2Minutes"].ToString();

                       if (_SType == "1")
                       {
                           if (_SType1Option == "1") // theo phut
                           {
                               TimeRunning = int.Parse(_SType1Number) * 60 * 1000;
                           }
                           else if (_SType1Option == "2") // theo gio
                           {
                               TimeRunning = int.Parse(_SType1Number) * 60 * 60 * 1000;
                           }

                       }
                       if (_SType == "2")
                       {

                           TimeRunning = 24 * 60 * 60 * 1000;
                       }

                       return true;
                   }
                   else
                       return false;
               }
               else
                   return false;
           }
           catch
           {
               return true;
           }
       }

    }
}
