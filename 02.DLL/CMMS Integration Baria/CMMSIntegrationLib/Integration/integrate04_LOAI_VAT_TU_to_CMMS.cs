using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate04_LOAI_VAT_TU_to_CMMS
    {
        public integrate04_LOAI_VAT_TU_to_CMMS()
        {
        }

        private DataTable dtLVTTransfer = new DataTable();
        private void GetDataTransfer(out string sLoi)
        {
            sLoi = "";
            try
            {
                dtLVTTransfer = new DataTable();
                string _sqlExec = "SELECT STT, MS_LOAI_VT_1, MS_LOAI_VT_CHA,TEN_LOAI_VT_TV_1,ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_LOAI_VT_L1 WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtLVTTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch (Exception e)
            {
                sLoi = e.ToString();
            }
        }

        public string ExecSynchronizeLOAI_VT_To_DBCMMS()
        {
            string sLoi = "";
            try
            {
                GetDataTransfer(out sLoi);
                if (dtLVTTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtLVTTransfer.Rows)
                    {
                        LOAI_VT _item = new LOAI_VT();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_LOAI_VT_1 = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_VT_1"].ToString());
                        _item.MS_LOAI_VT_CHA = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_VT_CHA"].ToString());
                        _item.TEN_LOAI_VT_TV_1 = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_LOAI_VT_TV_1"].ToString());
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        if (UpdateToDBCMMS(_item, out sLoi))
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
        private bool UpdateToDBCMMS(LOAI_VT _item, out string sLoi)
        {
            sLoi = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_LOAI_VT_UPDATE", 
                        _item.MS_LOAI_VT_1, _item.MS_LOAI_VT_CHA, _item.TEN_LOAI_VT_TV_1, _item.STATUS);
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_LOAI_VT_1 + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_LOAI_VT_L1 SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class LOAI_VT
    {
        public LOAI_VT() { }
        public int STT { get; set; }
        public string MS_LOAI_VT_1 { get; set; }
        public string MS_LOAI_VT_CHA { get; set; }
        public string TEN_LOAI_VT_TV_1 { get; set; }
        public string STATUS { get; set; }
    }
}
