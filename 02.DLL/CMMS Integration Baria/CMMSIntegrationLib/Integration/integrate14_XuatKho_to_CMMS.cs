using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;


namespace CMMSIntegrationLib.Integration
{
    public class integrate14_XuatKho_to_CMMS
    {
        public integrate14_XuatKho_to_CMMS()
        {
        }

        private DataTable dtXKhoTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtXKhoTransfer = new DataTable();
                string _sqlExec = "SELECT     STT, MS_DH_XUAT_PT, ISNULL(CONVERT(NVARCHAR(30), NGAY, 121), '') AS NGAY, ISNULL(MS_PHIEU_BAO_TRI,'') AS MS_PHIEU_BAO_TRI, " +
                        " ISNULL(MS_MAY,'') AS MS_MAY, ISNULL(MS_KHO,-1) AS MS_KHO, ISNULL(MS_PT,'') AS MS_PT, ISNULL(MS_BP_CHIU_PHI,-1) AS MS_BP_CHIU_PHI, " +
                        " ISNULL(SO_LUONG,0) AS SO_LUONG, ISNULL(DON_GIA,0) AS DON_GIA, ISNULL([TYPE],'X') AS [TYPE], " +
                        " ISNULL(CONVERT(NVARCHAR(30), INSERT_DATE, 121), '') AS INSERT_DATE, " +
                        " ISNULL(CONVERT(NVARCHAR(30), UPDATE_DATE, 121), '') AS UPDATE_DATE, ISNULL(STATUS,'N') AS STATUS, " +
                        " ISNULL(DA_CHUYEN, CONVERT(BIT, 0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUYEN, 121), '')  AS NGAY_CHUYEN ,ISNULL([NAV Entry No],0) AS NAVEntryNo " +
                        " FROM dbo.TB_IC_DON_HANG_XUAT_VAT_TU " +
                        " WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0) AND ISNULL(TYPE,CONVERT(NVARCHAR(1),'X')) = 'X'" +
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

        public string ExecSynchronizeXuatKho_To_DBCMMS()
        {
            string sLoi = "";
            SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION _item = new SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtXKhoTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtXKhoTransfer.Rows)
                    {
                        _item = new SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_DH_XUAT_PT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_DH_XUAT_PT"].ToString());
                        _item.NGAY = _rowtransfer["NGAY"].ToString();
                        _item.MS_PHIEU_BAO_TRI = _rowtransfer["MS_PHIEU_BAO_TRI"].ToString();
                        _item.MS_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_MAY"].ToString());
                        _item.MS_KHO = int.Parse(_rowtransfer["MS_KHO"].ToString());
                        _item.MS_PT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PT"].ToString());
                        _item.MS_BP_CHIU_PHI = int.Parse(_rowtransfer["MS_BP_CHIU_PHI"].ToString());
                        _item.SO_LUONG = float.Parse(_rowtransfer["SO_LUONG"].ToString());
                        _item.DON_GIA = float.Parse(_rowtransfer["DON_GIA"].ToString());
                        _item.TYPE = _rowtransfer["TYPE"].ToString();
                        _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
                        _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
                        _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();
                        _item.NAVEntryNo =int.Parse( _rowtransfer["NAVEntryNo"].ToString());
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
        private bool UpdateToDBCMMS(SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_XUAT_KHO_UPDATE",
                        _item.STT, _item.MS_DH_XUAT_PT, _item.NGAY, _item.MS_PHIEU_BAO_TRI, _item.MS_MAY, _item.MS_KHO,
                        _item.MS_PT, _item.MS_BP_CHIU_PHI, _item.SO_LUONG, _item.DON_GIA, _item.TYPE,
                        _item.INSERT_DATE, _item.UPDATE_DATE, _item.STATUS, _item.DA_CHUYEN, _item.NGAY_CHUYEN, _item.NAVEntryNo);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_BP_CHIU_PHI.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_IC_DON_HANG_XUAT_VAT_TU SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }


    public class SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION
    {
        public SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION() { }
        public int STT { get; set; }
        public string MS_DH_XUAT_PT	{ get; set; }
        public string NGAY	{ get; set; }
        public string MS_PHIEU_BAO_TRI{ get; set; }
        public string MS_MAY{ get; set; }
        public int MS_KHO{ get; set; }
        public string MS_PT{ get; set; }
        public int MS_BP_CHIU_PHI{ get; set; }
        public float SO_LUONG{ get; set; }
        public float DON_GIA{ get; set; }
        public string TYPE { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public string STATUS { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
        public int NAVEntryNo { get; set; }
    }
}