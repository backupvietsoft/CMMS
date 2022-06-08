using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.ApplicationBlocks.Data;

namespace PhucHoiDLKho
{
    public class clsConnect
    {
        //private static string _connectionString = "Data Source=HUYHOE-PC\\VIETSOFT;Initial Catalog=DONG_HUNG;Integrated Security=SSPI;";
        private static string _connectionString = "Data Source=moonkute\\VIETSOFT;Initial Catalog=dong_hung;user =sa;pwd =tranchuyennhat;";
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

    } 

}
