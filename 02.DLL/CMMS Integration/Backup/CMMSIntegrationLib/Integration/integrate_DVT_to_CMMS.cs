using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_DVT_to_CMMS
    {
        public integrate_DVT_to_CMMS()
        {
        }

        private DataTable IC_DVTTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                IC_DVTTransfer = new DataTable();
                string _sqlExec = "SELECT STT, DVT, TEN_1, TEN_2, TEN_3, GHI_CHU, ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE , " +
                        " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN " +
                        " FROM dbo.TB_DON_VI_TINH  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                IC_DVTTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeDON_VI_TINH_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (IC_DVTTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in IC_DVTTransfer.Rows)
                    {
                        DON_VI_TINH _item = new DON_VI_TINH();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.DVT = _rowtransfer["DVT"].ToString();
                        _item.TEN_1 = _rowtransfer["TEN_1"].ToString();
                        _item.TEN_2 = _rowtransfer["TEN_2"].ToString();
                        _item.TEN_3 = _rowtransfer["TEN_3"].ToString();
                        _item.GHI_CHU = _rowtransfer["GHI_CHU"].ToString();
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
        private bool UpdateToDBCMMS(DON_VI_TINH _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_DON_VI_TINH_UPDATE", _item.STT, _item.DVT, _item.TEN_1, _item.TEN_2, _item.TEN_3,
                    _item.GHI_CHU,_item.INSERT_DATE, _item.UPDATE_DATE, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
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
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_DON_VI_TINH SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class DON_VI_TINH
    {
        public DON_VI_TINH() { }
        public int STT { get; set; }
        public string DVT { get; set; }
        public string TEN_1 { get; set; }
        public string TEN_2 { get; set; }
        public string TEN_3 { get; set; }
        public string GHI_CHU { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
