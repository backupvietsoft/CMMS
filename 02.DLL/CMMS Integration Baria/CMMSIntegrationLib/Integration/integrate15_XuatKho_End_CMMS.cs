using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;
using System.Data.SqlClient;


namespace CMMSIntegrationLib.Integration
{
    public class integrate15_XuatKho_End_CMMS
    {
        public integrate15_XuatKho_End_CMMS()
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
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    scon.Close();
                    return ex.Message;
                }
                       

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
   


    }
}
