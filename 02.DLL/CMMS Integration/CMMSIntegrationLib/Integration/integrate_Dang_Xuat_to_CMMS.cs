using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_Dang_Xuat_to_CMMS
    {
        public integrate_Dang_Xuat_to_CMMS()
        {
        }

        private DataTable IC_DXuatTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                IC_DXuatTransfer = new DataTable();
                string _sqlExec = "SELECT  STT, MS_DANG_XUAT, DANG_XUAT_VIET, DANG_XUAT_ANH, DANG_XUAT_HOA, ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE , " +
                        " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN " +
                        " FROM dbo.TB_DANG_XUAT  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                IC_DXuatTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeDANG_XUAT_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (IC_DXuatTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in IC_DXuatTransfer.Rows)
                    {
                        DANG_XUAT _item = new DANG_XUAT();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_DANG_XUAT = int.Parse(_rowtransfer["MS_DANG_XUAT"].ToString());
                        _item.DANG_XUAT_VIET = _rowtransfer["DANG_XUAT_VIET"].ToString();
                        _item.DANG_XUAT_ANH = _rowtransfer["DANG_XUAT_ANH"].ToString();
                        _item.DANG_XUAT_HOA = _rowtransfer["DANG_XUAT_HOA"].ToString();
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
        private bool UpdateToDBCMMS(DANG_XUAT _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_DANG_XUAT_UPDATE", _item.STT, _item.MS_DANG_XUAT, _item.DANG_XUAT_VIET, _item.DANG_XUAT_ANH, _item.DANG_XUAT_HOA,
                    _item.INSERT_DATE, _item.UPDATE_DATE, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
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
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_DANG_XUAT SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class DANG_XUAT
    {
        public DANG_XUAT() { }
        public int STT { get; set; }
        public int MS_DANG_XUAT { get; set; }
        public string DANG_XUAT_VIET { get; set; }
        public string DANG_XUAT_ANH { get; set; }
        public string DANG_XUAT_HOA { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
