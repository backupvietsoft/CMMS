using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_Khach_Hang_to_CMMS
    {
        public integrate_Khach_Hang_to_CMMS()
        {
        }

        private DataTable IC_KHTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                IC_KHTransfer = new DataTable();
                string _sqlExec = "SELECT  STT, MS_KH, TEN_CONG_TY, TEN_RUT_GON, DIA_CHI, TEL, FAX, TEN_NDD, EMAIL, QUOCGIA, TAI_KHOAN_ANH, MS_THUE, TEN_NLH, CHUC_VU, DI_DONG, TEL_LH, HOME_TEL, EMAIL_LH, " + 
                        " GHI_CHU, HOME_ADD, ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE , " +
                        " ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN " +
                        " FROM dbo.TB_KHACH_HANG  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)";
                IC_KHTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        public string ExecSynchronizeKHACH_HANG_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (IC_KHTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in IC_KHTransfer.Rows)
                    {
                        KHACH_HANG _item = new KHACH_HANG();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_KH = _rowtransfer["MS_KH"].ToString();
                        _item.TEN_CONG_TY = _rowtransfer["TEN_CONG_TY"].ToString();
                        _item.TEN_RUT_GON = _rowtransfer["TEN_RUT_GON"].ToString();
                        _item.DIA_CHI = _rowtransfer["DIA_CHI"].ToString();
                        _item.TEL = _rowtransfer["TEL"].ToString();
                        _item.FAX = _rowtransfer["FAX"].ToString();
                        _item.TEN_NDD = _rowtransfer["TEN_NDD"].ToString();
                        _item.EMAIL = _rowtransfer["EMAIL"].ToString();
                        _item.QUOCGIA = _rowtransfer["QUOCGIA"].ToString();
                        _item.TAI_KHOAN_ANH = _rowtransfer["TAI_KHOAN_ANH"].ToString();
                        _item.MS_THUE = _rowtransfer["MS_THUE"].ToString();
                        _item.TEN_NLH = _rowtransfer["TEN_NLH"].ToString();
                        _item.CHUC_VU = _rowtransfer["CHUC_VU"].ToString();
                        _item.DI_DONG = _rowtransfer["DI_DONG"].ToString();
                        _item.TEL_LH = _rowtransfer["TEL_LH"].ToString();
                        _item.HOME_TEL = _rowtransfer["HOME_TEL"].ToString();
                        _item.EMAIL_LH = _rowtransfer["EMAIL_LH"].ToString();
                        _item.GHI_CHU = _rowtransfer["GHI_CHU"].ToString();
                        _item.HOME_ADD = _rowtransfer["HOME_ADD"].ToString();                       
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
        private bool UpdateToDBCMMS(KHACH_HANG _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_KHACH_HANG_UPDATE", _item.STT, _item.MS_KH, _item.TEN_CONG_TY, _item.TEN_RUT_GON, _item.DIA_CHI,
                    _item.TEL, _item.FAX, _item.TEN_NDD, _item.EMAIL,
                    _item.QUOCGIA, _item.TAI_KHOAN_ANH, _item.MS_THUE, _item.TEN_NLH,
                    _item.CHUC_VU, _item.DI_DONG, _item.TEL_LH, _item.HOME_TEL,
                    _item.EMAIL_LH, _item.GHI_CHU, _item.HOME_ADD, 
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
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_KHACH_HANG SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class KHACH_HANG
    {
        public KHACH_HANG() { }
        public int STT { get; set; }
        public string MS_KH { get; set; }
        public string TEN_CONG_TY { get; set; }
        public string TEN_RUT_GON { get; set; }
        public string DIA_CHI { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string TEN_NDD { get; set; }
        public string EMAIL { get; set; }
        public string QUOCGIA { get; set; }
        public string TAI_KHOAN_ANH { get; set; }
        public string MS_THUE { get; set; }
        public string TEN_NLH { get; set; }
        public string CHUC_VU { get; set; }
        public string DI_DONG { get; set; }
        public string TEL_LH { get; set; }
        public string HOME_TEL { get; set; }
        public string EMAIL_LH { get; set; }
        public string GHI_CHU { get; set; }
        public string HOME_ADD { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
