using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate03_HANG_SAN_XUAT_to_CMMS
    {
        public integrate03_HANG_SAN_XUAT_to_CMMS()
        {
        }

        private DataTable dtHSXTransfer = new DataTable();
        private void GetDataTransfer(out string sLoi)
        {
            sLoi = "";
            try
            {
                dtHSXTransfer = new DataTable();
                string _sqlExec = "SELECT STT, MS_HSX,MS_HSX_CU, TEN_HSX,ISNULL(STATUS,'N') AS STATUS " +                        
                        " FROM dbo.TB_HANG_SAN_XUAT WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtHSXTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch (Exception e)
            {
                sLoi = e.ToString();
            }
        }

        public string ExecSynchronizeHANG_SAN_XUAT_To_DBCMMS()
        {
            string sLoi = "";
            try
            {
                GetDataTransfer(out sLoi);
                if (dtHSXTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtHSXTransfer.Rows)
                    {
                        HANG_SAN_XUAT _item = new HANG_SAN_XUAT();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_HSX = int.Parse(_rowtransfer["MS_HSX"].ToString());
                        _item.MS_HSX_CU = int.Parse(_rowtransfer["MS_HSX_CU"].ToString());
                        _item.TEN_HSX = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_HSX"].ToString());
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
        private bool UpdateToDBCMMS(HANG_SAN_XUAT _item, out string sLoi)
        {
            sLoi = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_HANG_SAN_XUAT_UPDATE", _item.MS_HSX,_item.MS_HSX_CU, _item.TEN_HSX, _item.STATUS);
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_HSX + "-" + ex.Message;
                return false;
            }
            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_HANG_SAN_XUAT SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class HANG_SAN_XUAT
    {
        public HANG_SAN_XUAT() { }
        public int STT { get; set; }
        public int MS_HSX { get; set; }
        public int MS_HSX_CU { get; set; }
        public string TEN_HSX { get; set; }
        public string STATUS { get; set; }
    }
}
