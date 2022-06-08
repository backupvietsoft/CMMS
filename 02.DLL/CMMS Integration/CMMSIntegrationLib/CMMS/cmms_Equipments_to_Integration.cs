using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CMMSIntegrationLib.Integration;

namespace CMMSIntegrationLib.CMMS
{
    public class cmms_Equipments_to_Integration
    {
        public cmms_Equipments_to_Integration()
        {

        }
        private DataTable EquitmentTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                EquitmentTransfer = new DataTable();
                string _sqlExec = "SELECT CONVERT(NVARCHAR(10),STT) AS STT, MS_MAY, TEN_MAY, MO_TA, NHIEM_VU_THIET_BI, " +
                                    " ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE, " +
                                    " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, DA_CHUYEN, NGAY_CHUYEN" +
                                    " FROM dbo.TB_MAY WHERE (ISNULL(DA_CHUYEN,0) = CONVERT(BIT, 0))";
                EquitmentTransfer.Load(SqlHelper.ExecuteReader(cmms_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }
        public string ExecSynchronizeToDBIntegration()
        {
            try
            {
                GetDataTransfer();
                if (EquitmentTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in EquitmentTransfer.Rows)
                    {
                        if (UpdateToDBIntegration(_rowtransfer["MS_MAY"].ToString(), _rowtransfer["TEN_MAY"].ToString(), 
                                _rowtransfer["MO_TA"].ToString(), _rowtransfer["NHIEM_VU_THIET_BI"].ToString()))
                            UpdateToDBCMMS(_rowtransfer["STT"].ToString());
                    }
                }
                else
                {
                    return "khong co du lieu";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "OK";
        }

        private bool UpdateToDBIntegration(string _ms_may, string _ten_may, string _mo_ta, string _nhiem_vu)
        {
            try
            {

                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, "IT_PROC_INSERT_TB_MAY", _ms_may, _ten_may, _mo_ta, _nhiem_vu );
            }
            catch { }

            return true;
        }

        private bool UpdateToDBCMMS( string STT )
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, CommandType.Text,
                    "UPDATE TB_MAY SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   
    }
}
