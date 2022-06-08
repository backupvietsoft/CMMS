using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate02_KH_to_CMMS
    {
        public integrate02_KH_to_CMMS()
        {
        }

        private DataTable dtKHTransfer = new DataTable();
        private void GetDataTransfer(out string sLoi)
        {
            sLoi = "";
            try
            {
                dtKHTransfer = new DataTable();
                string _sqlExec = "SELECT  STT, MS_KH,MS_KH_CU, TEN_CONG_TY,  CASE ISNULL(TEN_RUT_GON,'') WHEN '' THEN TEN_CONG_TY ELSE TEN_RUT_GON END AS TEN_RUT_GON, " +
                        " ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE , ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, " +
                        " DIA_CHI, TEL, FAX, TEN_NDD, EMAIL, QUOCGIA, MS_THUE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(STATUS,'N') AS STATUS, " +
                        " ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN FROM dbo.TB_KHACH_HANG  WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0) " +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtKHTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch (Exception e)
            {
                sLoi = e.ToString();
            }
        }

        public string ExecSynchronizeKH_To_DBCMMS()
        {
            string sLoi = "";
            try
            {
                GetDataTransfer(out sLoi);
                if (dtKHTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtKHTransfer.Rows)
                    {
                        KHACH_HANG _item = new KHACH_HANG();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_KH = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_KH"].ToString());
                        _item.MS_KH_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_KH_CU"].ToString());
                        _item.TEN_CONG_TY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_CONG_TY"].ToString());
                        _item.TEN_RUT_GON =VSCommons.MConvertFont.MVni2Uni( _rowtransfer["TEN_RUT_GON"].ToString());
                        _item.DIA_CHI = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["DIA_CHI"].ToString());
                        _item.TEL =VSCommons.MConvertFont.MVni2Uni( _rowtransfer["TEL"].ToString());
                        _item.FAX = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["FAX"].ToString());
                        _item.TEN_NDD = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_NDD"].ToString());
                        _item.EMAIL = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["EMAIL"].ToString());
                        _item.QUOCGIA = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["QUOCGIA"].ToString()); 
                        _item.MS_THUE = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_THUE"].ToString());
                        _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
                        _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
                        _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();

                        if (UpdateToDBCMMS(_item,out sLoi))
                            UpdateToDBIntegration(_item.STT.ToString());
                        else
                            sLoi += "\n" + sLoi;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";
        }
        private bool UpdateToDBCMMS(KHACH_HANG _item, out string sLoi)
        {
            sLoi = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_KHACH_HANG_UPDATE", _item.STT, _item.MS_KH,_item.MS_KH_CU, _item.TEN_CONG_TY, _item.TEN_RUT_GON, _item.DIA_CHI,
                    _item.TEL, _item.FAX, _item.TEN_NDD, _item.EMAIL, _item.QUOCGIA, _item.MS_THUE, _item.STATUS);
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_KH + "-" + ex.Message;
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
        public string MS_KH_CU { get; set; }
        public string TEN_CONG_TY { get; set; }
        public string TEN_RUT_GON { get; set; }
        public string DIA_CHI { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string TEN_NDD { get; set; }
        public string EMAIL { get; set; }
        public string QUOCGIA { get; set; }
        public string MS_THUE { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public string STATUS { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
