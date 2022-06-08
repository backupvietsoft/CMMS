using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;


namespace CMMSIntegrationLib.Integration
{
    public class integrate11_IC_KHO_to_CMMS
    {
        public integrate11_IC_KHO_to_CMMS()
        {
        }

        private DataTable dtICKhoTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtICKhoTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],MS_KHO,MS_KHO_CU,TEN_KHO, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_IC_KHO WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtICKhoTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeIC_KHO_To_DBCMMS()
        {
            string sLoi = "";
            IC_KHO _item = new IC_KHO();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtICKhoTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtICKhoTransfer.Rows)
                    {
                        _item = new IC_KHO();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_KHO = int.Parse(_rowtransfer["MS_KHO"].ToString());
                        _item.MS_KHO_CU = int.Parse(_rowtransfer["MS_KHO_CU"].ToString());
                        _item.TEN_KHO = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_KHO"].ToString());
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
                return _item.MS_KHO.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }
        private bool UpdateToDBCMMS(IC_KHO _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_IC_KHO_UPDATE",
                    _item.MS_KHO, _item.MS_KHO_CU, _item.TEN_KHO,_item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_KHO.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_IC_KHO SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class IC_KHO
    {
        public IC_KHO() { }
        public int STT { get; set; }
        public int MS_KHO { get; set; }
        public int MS_KHO_CU { get; set; }
        public string TEN_KHO { get; set; }
        public string STATUS { get; set; }
    }
}