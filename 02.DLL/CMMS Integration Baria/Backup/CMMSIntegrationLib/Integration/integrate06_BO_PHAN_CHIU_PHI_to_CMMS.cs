using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate06_BO_PHAN_CHIU_PHI_to_CMMS
    {
        public integrate06_BO_PHAN_CHIU_PHI_to_CMMS()
        {
        }

        private DataTable dtBPCPTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtBPCPTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],MS_BP_CHIU_PHI,MS_BP_CHIU_PHI_CU,TEN_BP_CHIU_PHI, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_BO_PHAN_CHIU_PHI WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtBPCPTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeBO_PHAN_CHIU_PHI_To_DBCMMS()
        {
            string sLoi = "";
            BO_PHAN_CHIU_PHI _item = new BO_PHAN_CHIU_PHI();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtBPCPTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtBPCPTransfer.Rows)
                    {
                        _item = new BO_PHAN_CHIU_PHI();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_BP_CHIU_PHI = int.Parse(_rowtransfer["MS_BP_CHIU_PHI"].ToString());
                        _item.MS_BP_CHIU_PHI_CU = int.Parse(_rowtransfer["MS_BP_CHIU_PHI_CU"].ToString());
                        _item.TEN_BP_CHIU_PHI = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_BP_CHIU_PHI"].ToString());
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        if (UpdateToDBCMMS(_item, out sLoi))
                            UpdateToDBIntegration(_item.STT.ToString());
                        else
                            sLoi += "\n" +  sLoi;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return _item.MS_BP_CHIU_PHI.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";
        }
        private bool UpdateToDBCMMS(BO_PHAN_CHIU_PHI _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_BO_PHAN_CHIU_PHI_UPDATE",
                        _item.MS_BP_CHIU_PHI, _item.MS_BP_CHIU_PHI_CU, _item.TEN_BP_CHIU_PHI, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_BP_CHIU_PHI.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_BO_PHAN_CHIU_PHI SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class BO_PHAN_CHIU_PHI
    {
        public BO_PHAN_CHIU_PHI() { }
        public int STT { get; set; }
        public int MS_BP_CHIU_PHI { get; set; }
        public int MS_BP_CHIU_PHI_CU { get; set; }
        public string TEN_BP_CHIU_PHI { get; set; }
        public string STATUS { get; set; }
    }
}