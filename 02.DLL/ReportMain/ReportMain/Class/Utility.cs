using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace ReportMain
{
    public class Utility
    {
        private static string con = Commons.IConnections.ConnectionString;
        public static string MyConnection
        {
            get
            {
          
                return con;//
                
                
            }
            set
            {
                con = value;
            }
        }
        
        public static string ConnectionEx(string fileName)
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
        }
    }
}
