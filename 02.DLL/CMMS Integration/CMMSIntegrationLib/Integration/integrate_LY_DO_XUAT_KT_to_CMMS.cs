using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;


namespace CMMSIntegrationLib.Integration
{
    public class integrate_LY_DO_XUAT_KT_to_CMMS
    {
        public integrate_LY_DO_XUAT_KT_to_CMMS()
        {

        }

        private DataTable LY_DO_XUAT_KTTransfer = new DataTable();

        private void GetDataTransfer()
        {
            try
            {
                LY_DO_XUAT_KTTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],[MS_DANG_XUAT],ISNULL([DANG_XUAT_VIET],'-1') AS DANG_XUAT_VIET " +
                        " FROM dbo.TB_DANG_XUAT  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                LY_DO_XUAT_KTTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeLY_DO_XUAT_KT_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (LY_DO_XUAT_KTTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in LY_DO_XUAT_KTTransfer.Rows)
                    {
                        LY_DO_XUAT_KT _item = new LY_DO_XUAT_KT();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_DANG_XUAT = _rowtransfer["MS_DANG_XUAT"].ToString();
                        _item.DANG_XUAT_VIET = _rowtransfer["DANG_XUAT_VIET"].ToString();
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

        private bool UpdateToDBCMMS(LY_DO_XUAT_KT _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_LY_DO_XUAT_KT_UPDATE",
                        _item.MS_DANG_XUAT, _item.DANG_XUAT_VIET);
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
                    "UPDATE TB_DANG_XUAT SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }

    }
    public class LY_DO_XUAT_KT
    {
        public LY_DO_XUAT_KT() { }
        public int STT { get; set; }
        public string MS_DANG_XUAT { get; set; }
        public string DANG_XUAT_VIET { get; set; }
    }

}
