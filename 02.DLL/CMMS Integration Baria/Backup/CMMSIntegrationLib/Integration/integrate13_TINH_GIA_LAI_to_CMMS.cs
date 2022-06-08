using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate13_TINH_GIA_LAI_to_CMMS
    {
        public integrate13_TINH_GIA_LAI_to_CMMS()
        {
        }

        private DataTable dtTinhGiaLaiTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtTinhGiaLaiTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],ISNULL(THANG_NAM,'') AS THANG_NAM,ISNULL(NGAY_KHOA_SO,'') AS NGAY_KHOA_SO, " +
                        " MS_KHO, MS_PT, ISNULL(DON_GIA,0) AS DON_GIA, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_TINH_GIA_LAI WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtTinhGiaLaiTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeTINH_GIA_LAI_To_DBCMMS()
        {
            string sLoi = "";
            TINH_GIA_LAI _item = new TINH_GIA_LAI();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtTinhGiaLaiTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtTinhGiaLaiTransfer.Rows)
                    {
                        _item = new TINH_GIA_LAI();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.THANG_NAM = DateTime.Parse(_rowtransfer["THANG_NAM"].ToString());
                        _item.NGAY_KHOA_SO = DateTime.Parse(_rowtransfer["NGAY_KHOA_SO"].ToString());
                        _item.MS_KHO = int.Parse(_rowtransfer["MS_KHO"].ToString());
                        _item.MS_PT = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_PT"].ToString());
                        _item.DON_GIA = float.Parse(_rowtransfer["DON_GIA"].ToString());
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
                return _item.NGAY_KHOA_SO.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }
        private bool UpdateToDBCMMS(TINH_GIA_LAI _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_TINH_GIA_LAI_UPDATE",
                        _item.THANG_NAM, _item.NGAY_KHOA_SO, _item.MS_KHO, _item.MS_PT, _item.DON_GIA, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.NGAY_KHOA_SO.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_TINH_GIA_LAI SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class TINH_GIA_LAI
    {
        public TINH_GIA_LAI() { }
        public int STT { get; set; }
        public DateTime THANG_NAM { get; set; }
        public DateTime NGAY_KHOA_SO { get; set; }
        public int MS_KHO { get; set; }
        public string MS_PT { get; set; }
        public float DON_GIA { get; set; }
        public string STATUS { get; set; }
    }
}