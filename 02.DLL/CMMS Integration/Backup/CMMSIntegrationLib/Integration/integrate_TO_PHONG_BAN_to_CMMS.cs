using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_TO_PHONG_BAN_to_CMMS
    {
        public integrate_TO_PHONG_BAN_to_CMMS()
        {

        }

        private DataTable TO_PHONG_BANTransfer = new DataTable();

        private void GetDataTransfer()
        {
            try
            {
                TO_PHONG_BANTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],[MS_TO],ISNULL([TEN_TO],'-1') AS TEN_TO,ISNULL([MS_DON_VI],'-1') AS MS_DON_VI,[TEN_DON_VI], " +
                        " ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE , " +
                        " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, " +
                        " ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') AS NGAY_CHUYEN " +
                        " FROM dbo.TB_TO_PHONG_BAN  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                TO_PHONG_BANTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeTO_PHONG_BAN_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (TO_PHONG_BANTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in TO_PHONG_BANTransfer.Rows)
                    {
                        TO_PHONG_BAN _item = new TO_PHONG_BAN();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_TO = _rowtransfer["MS_TO"].ToString();
                        _item.TEN_TO = _rowtransfer["TEN_TO"].ToString();
                        _item.MS_DON_VI = _rowtransfer["MS_DON_VI"].ToString();
                        _item.TEN_DON_VI = _rowtransfer["TEN_DON_VI"].ToString();
                        _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
                        _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
                        _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
                        _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();

                        if (UpdateToDBCMMS(_item))
                        {
                            UpdateToDBIntegration(_item.STT.ToString());
                        }

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

        private bool UpdateToDBCMMS(TO_PHONG_BAN _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_TO_PHONG_BAN_UPDATE",
                    _item.MS_TO, _item.TEN_TO, _item.MS_DON_VI, _item.TEN_DON_VI);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                    "UPDATE TB_TO_PHONG_BAN SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }

    }
    public class TO_PHONG_BAN
    {
        public TO_PHONG_BAN() { }
        public int STT { get; set; }
        public string MS_TO { get; set; }
        public string TEN_TO { get; set; }
        public string MS_DON_VI { get; set; }
        public string TEN_DON_VI { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }

}


