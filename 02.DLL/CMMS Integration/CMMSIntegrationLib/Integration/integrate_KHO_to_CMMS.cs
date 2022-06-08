using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_KHO_to_CMMS
    {
        public integrate_KHO_to_CMMS()
        {
        }

        private DataTable IC_KHOTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                IC_KHOTransfer = new DataTable();
                string _sqlExec = "SELECT STT, MS_KHO, TEN_KHO, DIA_CHI, SO_DO, ISNULL(ISIT,CONVERT(BIT,0)) AS ISIT, MS_CONG_NHAN, " +
               " ISNULL(CONVERT(NVARCHAR(30),NGAY_LOCK,121),'') AS NGAY_LOCK, ISNULL(CONVERT(NVARCHAR(30),GIO_LOCK,121),'') AS GIO_LOCK,UNAME, " +
               " ISNULL(SN_CANH_BAO,0) AS SN_CANH_BAO, ISNULL(KHO_DD,CONVERT(BIT,0)) AS KHO_DD, ISNULL(MS_KHO_CHINH,0) AS MS_KHO_CHINH, MS_DON_VI, ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE, " +
               " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN " +
               " FROM dbo.TB_IC_KHO WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                IC_KHOTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeIC_Kho_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (IC_KHOTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in IC_KHOTransfer.Rows)
                    {
                        IC_KHO _item = new IC_KHO();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_KHO = _rowtransfer["MS_KHO"].ToString();
                        _item.TEN_KHO = _rowtransfer["TEN_KHO"].ToString();
                        _item.DIA_CHI = _rowtransfer["DIA_CHI"].ToString();
                        _item.SO_DO = _rowtransfer["SO_DO"].ToString();
                        _item.ISIT = (bool)_rowtransfer["ISIT"];
                        _item.MS_CONG_NHAN = _rowtransfer["MS_CONG_NHAN"].ToString();
                        _item.NGAY_LOCK = _rowtransfer["NGAY_LOCK"].ToString();
                        _item.GIO_LOCK = _rowtransfer["GIO_LOCK"].ToString();
                        _item.UNAME = _rowtransfer["UNAME"].ToString();
                        _item.SN_CANH_BAO = int.Parse(_rowtransfer["SN_CANH_BAO"].ToString());
                        _item.KHO_DD = (bool)_rowtransfer["KHO_DD"];
                        _item.MS_KHO_CHINH = int.Parse(_rowtransfer["MS_KHO_CHINH"].ToString());
                        _item.MS_DON_VI = _rowtransfer["MS_DON_VI"].ToString();
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

        private bool UpdateToDBCMMS(IC_KHO _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_IC_KHO_UPDATE", _item.STT, _item.MS_KHO, _item.TEN_KHO, _item.DIA_CHI, _item.SO_DO,
                    _item.ISIT, _item.MS_CONG_NHAN, _item.NGAY_LOCK, _item.GIO_LOCK, _item.UNAME, _item.SN_CANH_BAO, _item.KHO_DD, _item.MS_KHO_CHINH, _item.MS_DON_VI,
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
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_IC_KHO SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class IC_KHO
    {
        public IC_KHO() { }
        public int STT { get; set; }
        public string MS_KHO { get; set; }
        public string TEN_KHO { get; set; }
        public string DIA_CHI { get; set; }
        public string SO_DO { get; set; }
        public bool ISIT { get; set; }
        public string MS_CONG_NHAN { get; set; }
        public string NGAY_LOCK { get; set; }
        public string GIO_LOCK { get; set; }
        public string UNAME { get; set; }
        public int SN_CANH_BAO { get; set; }

        public bool KHO_DD { get; set; }
        public int MS_KHO_CHINH { get; set; }
        public string MS_DON_VI { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
