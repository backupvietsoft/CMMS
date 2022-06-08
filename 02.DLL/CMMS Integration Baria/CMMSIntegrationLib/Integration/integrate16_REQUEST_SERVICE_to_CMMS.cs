using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate16_REQUEST_SERVICE_to_CMMS
    {
        public integrate16_REQUEST_SERVICE_to_CMMS()
        {
        }
        #region Chuyen du lieu tu NAV ve CSDL CMMS
        private DataTable dtXKhoTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtXKhoTransfer = new DataTable();
                string _sqlExec = "SELECT  STT, ISNULL(MS_YEU_CAU,'') AS MS_YEU_CAU, ISNULL(GL_ACC,'') AS GL_ACC, ISNULL(MO_TA_SERVICE,'') AS MO_TA_SERVICE, " +
                        " ISNULL(SER_GROUP_CODE,'') AS SER_GROUP_CODE, ISNULL(SO_LUONG,0) AS SO_LUONG, ISNULL(MS_CONG_NHAN,'') AS MS_CONG_NHAN,  " +
                        " ISNULL(CONVERT(NVARCHAR(30), NGAY_YEU_CAU, 121), '')  AS NGAY_YEU_CAU, ISNULL(MS_PHIEU_BAO_TRI,'') AS MS_PHIEU_BAO_TRI,  " +
                        " ISNULL(MS_BP_CHIU_PHI,'-1') AS MS_BP_CHIU_PHI, ISNULL(AMOUNT,'-1') AS AMOUNT, ISNULL(VENDOR_CODE,'-1') AS VENDOR_CODE,  " +
                        " ISNULL(CONVERT(NVARCHAR(30), INSERT_DATE, 121), '') AS INSERT_DATE, " +
                        " ISNULL(CONVERT(NVARCHAR(30), UPDATE_DATE, 121), '') AS UPDATE_DATE, ISNULL(STATUS,'E') AS STATUS, " +
                        " ISNULL(DA_CHUYEN, CONVERT(BIT, 0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUYEN, 121), '')  AS NGAY_CHUYEN  " +
                        " FROM dbo.NAV_REQUEST_SERVICE " +
                        " WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0) AND ISNULL(STATUS,'E') = 'E' " +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtXKhoTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeNAV_REQUEST_SERVICE_To_DBCMMS()
        {
            string sLoi = "";
            SYN_NAV_REQUEST_SERVICE_INTEGRATION _item = new SYN_NAV_REQUEST_SERVICE_INTEGRATION();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtXKhoTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtXKhoTransfer.Rows)
                    {
                        _item = new SYN_NAV_REQUEST_SERVICE_INTEGRATION();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());

                        _item.MS_YEU_CAU = _rowtransfer["MS_YEU_CAU"].ToString();
                        _item.GL_ACC = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["GL_ACC"].ToString());
                        _item.MO_TA_SERVICE = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MO_TA_SERVICE"].ToString());
                        _item.SER_GROUP_CODE = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["SER_GROUP_CODE"].ToString());
                        _item.SO_LUONG = float.Parse(_rowtransfer["SO_LUONG"].ToString());
                        _item.MS_CONG_NHAN = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_CONG_NHAN"].ToString());
                        _item.NGAY_YEU_CAU = _rowtransfer["NGAY_YEU_CAU"].ToString();
                        _item.MS_PHIEU_BAO_TRI = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PHIEU_BAO_TRI"].ToString());
                        _item.MS_BP_CHIU_PHI = int.Parse(_rowtransfer["MS_BP_CHIU_PHI"].ToString());
                        _item.AMOUNT = float.Parse(_rowtransfer["AMOUNT"].ToString());
                        _item.VENDOR_CODE = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["VENDOR_CODE"].ToString());
                        _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
                        _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
                        _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();
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
        private bool UpdateToDBCMMS(SYN_NAV_REQUEST_SERVICE_INTEGRATION _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_NAV_REQUEST_SERVICE_UPDATE",
                        _item.STT, _item.MS_YEU_CAU,_item.GL_ACC,_item.MO_TA_SERVICE,_item.SER_GROUP_CODE,_item.SO_LUONG,_item.MS_CONG_NHAN,
                        _item.NGAY_YEU_CAU,_item.MS_PHIEU_BAO_TRI,_item.MS_BP_CHIU_PHI,_item.AMOUNT,_item.VENDOR_CODE,
                        _item.INSERT_DATE, _item.UPDATE_DATE, _item.STATUS, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_YEU_CAU.ToString() + "-" + "-" + _item.GL_ACC + "-" + _item.SER_GROUP_CODE + "\n" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE NAV_REQUEST_SERVICE SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
        #endregion
    }


    public class SYN_NAV_REQUEST_SERVICE_INTEGRATION
    {
        public SYN_NAV_REQUEST_SERVICE_INTEGRATION() { }
        public int STT { get; set; }
        public string MS_YEU_CAU { get; set; }
        public string GL_ACC { get; set; }
        public string MO_TA_SERVICE { get; set; }
        public string SER_GROUP_CODE { get; set; }
        public float SO_LUONG { get; set; }
        public string MS_CONG_NHAN { get; set; }
        public string NGAY_YEU_CAU { get; set; }
        public string MS_PHIEU_BAO_TRI { get; set; }
        public int MS_BP_CHIU_PHI { get; set; }
        public float AMOUNT { get; set; }
        public string VENDOR_CODE { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public string STATUS { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}