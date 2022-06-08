using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;
using System.Data.SqlClient;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_Xuat_Kho_End_to_CMMS
    {
        public integrate_Xuat_Kho_End_to_CMMS()
        {
        }

        public string ExecSynchronizeXUAT_KHO_To_DBCMMS()
        {
            try
            {
                SqlConnection scon = new SqlConnection(cmms_common.cmms_connection);
                scon.Open();
                SqlCommand command = scon.CreateCommand();
                command.Connection = scon;
                command.CommandTimeout = 9999;
                SqlTransaction sqlTrans = scon.BeginTransaction();
                command.Transaction = sqlTrans;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "INTEGRATION_XUAT_KHO_SYN_UPDATE_TO_CMMS";
                try
                {
                    command.ExecuteNonQuery();
                    sqlTrans.Commit();
                    scon.Close();
                }
                catch
                {
                    sqlTrans.Rollback();
                    scon.Close();
                }
                       

            }
            catch
            {
                
                return "false";
            }



            
            return "OK";
        }
   

    }
}
