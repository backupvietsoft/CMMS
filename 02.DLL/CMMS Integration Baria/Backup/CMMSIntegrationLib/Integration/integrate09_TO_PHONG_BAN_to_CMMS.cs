using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate09_TO_PHONG_BAN_to_CMMS
    {
        public integrate09_TO_PHONG_BAN_to_CMMS()
        {
        }

        private DataTable dtToPBTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtToPBTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],MS_TO,MS_TO_CU,ISNULL(TEN_TO,'') AS TEN_TO, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_PHONG_BAN WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtToPBTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeTO_PHONG_BAN_To_DBCMMS()
        {
            string sLoi = "";
            TO_PHONG_BAN _item = new TO_PHONG_BAN();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtToPBTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtToPBTransfer.Rows)
                    {
                        _item = new TO_PHONG_BAN();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_TO = int.Parse(_rowtransfer["MS_TO"].ToString());
                        _item.MS_TO_CU = int.Parse(_rowtransfer["MS_TO_CU"].ToString());
                        _item.TEN_TO = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_TO"].ToString());
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
                return _item.MS_TO.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }
        private bool UpdateToDBCMMS(TO_PHONG_BAN _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_TO_PHONG_BAN_UPDATE",
                        _item.MS_TO,_item.MS_TO_CU, _item.TEN_TO,_item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_TO.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_PHONG_BAN SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class TO_PHONG_BAN
    {
        public TO_PHONG_BAN() { }
        public int STT { get; set; }
        public int MS_TO { get; set; }
        public int MS_TO_CU { get; set; }
        public string TEN_TO { get; set; }
        public string STATUS { get; set; }
    }
}
