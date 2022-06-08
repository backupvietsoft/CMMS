using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate05_IC_PHU_TUNG_to_CMMS
    {
        public integrate05_IC_PHU_TUNG_to_CMMS()
        {
        }

        private DataTable dtICPTTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtICPTTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],[MS_PT],[MS_PT_CU],[TEN_PT],[MS_PT_CTY],[TEN_PT_VIET],[QUY_CACH],[DVT], " +
                        " ISNULL([SO_NGAY_DAT_MUA_HANG],0) AS SO_NGAY_DAT_MUA_HANG, ISNULL([TON_TOI_THIEU],0) AS TON_TOI_THIEU, " +
                        " ISNULL([TON_KHO_MAX],0) AS TON_KHO_MAX, ISNULL([MS_HSX],0) AS MS_HSX, ISNULL([MS_LOAI_VT_3],'') AS MS_LOAI_VT_3,ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_IC_PHU_TUNG WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtICPTTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeIC_PHU_TUNG_To_DBCMMS()
        {
            string sLoi = "";
            IC_PHU_TUNG _item = new IC_PHU_TUNG();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtICPTTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtICPTTransfer.Rows)
                    {
                        _item = new IC_PHU_TUNG();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_PT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PT"].ToString());
                        _item.MS_PT_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PT_CU"].ToString());
                        _item.TEN_PT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_PT"].ToString());
                        _item.MS_PT_CTY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PT_CTY"].ToString());
                        _item.TEN_PT_VIET = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_PT_VIET"].ToString());
                        _item.QUY_CACH = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["QUY_CACH"].ToString());
                        _item.DVT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["DVT"].ToString());
                        _item.SO_NGAY_DAT_MUA_HANG = int.Parse(_rowtransfer["SO_NGAY_DAT_MUA_HANG"].ToString());
                        _item.TON_TOI_THIEU = float.Parse(_rowtransfer["TON_TOI_THIEU"].ToString());
                        _item.TON_KHO_MAX = float.Parse(_rowtransfer["TON_KHO_MAX"].ToString());
                        _item.MS_HSX = int.Parse(_rowtransfer["MS_HSX"].ToString());
                        _item.MS_LOAI_VT_3 = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_VT_3"].ToString());
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
                return _item.MS_PT  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";
        }
        private bool UpdateToDBCMMS(IC_PHU_TUNG _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_IC_PHU_TUNG_UPDATE",
                        _item.MS_PT,_item.MS_PT_CU, _item.TEN_PT, _item.MS_PT_CTY, _item.TEN_PT_VIET, _item.QUY_CACH, _item.DVT, _item.SO_NGAY_DAT_MUA_HANG,
                        _item.TON_TOI_THIEU, _item.TON_KHO_MAX, _item.MS_HSX, _item.MS_LOAI_VT_3, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_PT + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_IC_PHU_TUNG SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class IC_PHU_TUNG
    {
        public IC_PHU_TUNG() { }
        public int STT { get; set; }
        public string MS_PT { get; set; }
        public string MS_PT_CU { get; set; }
        public string TEN_PT { get; set; }
        public string MS_PT_CTY { get; set; }
        public string TEN_PT_VIET { get; set; }
        public string QUY_CACH { get; set; }
        public string DVT { get; set; }
        public int SO_NGAY_DAT_MUA_HANG { get; set; }
        public float TON_TOI_THIEU { get; set; }
        public float TON_KHO_MAX { get; set; }
        public int MS_HSX { get; set; }
        public string MS_LOAI_VT_3 { get; set; }
        public string STATUS { get; set; }
    }
}
