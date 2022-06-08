using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate10_CONG_NHAN_to_CMMS
    {
        public integrate10_CONG_NHAN_to_CMMS()
        {
        }

        private DataTable dtBPCPTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtBPCPTransfer = new DataTable();
                string _sqlExec = " SELECT STT, MS_CONG_NHAN,MS_CONG_NHAN_CU, ISNULL(HO, '') AS HO, ISNULL(TEN, '') AS TEN, ISNULL(NGAY_SINH, '') AS NGAY_SINH, ISNULL(NOI_SINH, '') AS NOI_SINH, ISNULL(PHAI, 0) AS PHAI, " +
                        " ISNULL(DIA_CHI_THUONG_TRU, '') AS DIA_CHI_THUONG_TRU, ISNULL(SO_CMND, '') AS SO_CMND, ISNULL(MS_TO, '') AS MS_TO,  " +
                        " ISNULL(NGAY_VAO_LAM, '') AS NGAY_VAO_LAM, ISNULL(BO_VIEC, 0) AS BO_VIEC, ISNULL(NGAY_NGHI_VIEC, '')  AS NGAY_NGHI_VIEC, ISNULL(STATUS,'N') AS STATUS  " +
                        " FROM dbo.TB_CONG_NHAN WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtBPCPTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeCONG_NHAN_To_DBCMMS()
        {
            string sLoi = "";
            CONG_NHAN _item = new CONG_NHAN();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtBPCPTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtBPCPTransfer.Rows)
                    {
                        _item = new CONG_NHAN();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_CONG_NHAN = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_CONG_NHAN"].ToString());
                        _item.MS_CONG_NHAN_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_CONG_NHAN_CU"].ToString());
                        _item.HO = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["HO"].ToString());
                        _item.TEN = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN"].ToString());
                        _item.NGAY_SINH = DateTime.Parse(_rowtransfer["NGAY_SINH"].ToString());
                        _item.NOI_SINH =VSCommons.MConvertFont.MVni2Uni( _rowtransfer["NOI_SINH"].ToString());
                        _item.PHAI = bool.Parse(_rowtransfer["PHAI"].ToString());
                        _item.DIA_CHI_THUONG_TRU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["DIA_CHI_THUONG_TRU"].ToString());
                        _item.SO_CMND = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["SO_CMND"].ToString());
                        _item.MS_TO = int.Parse(_rowtransfer["MS_TO"].ToString());
                        _item.NGAY_VAO_LAM = DateTime.Parse(_rowtransfer["NGAY_VAO_LAM"].ToString());
                        _item.BO_VIEC = bool.Parse(_rowtransfer["BO_VIEC"].ToString());
                        _item.NGAY_NGHI_VIEC = DateTime.Parse(_rowtransfer["NGAY_NGHI_VIEC"].ToString());
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
                return _item.MS_CONG_NHAN.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }
        private bool UpdateToDBCMMS(CONG_NHAN _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_CONG_NHAN_UPDATE",_item.MS_CONG_NHAN,
                        _item.MS_CONG_NHAN_CU, _item.HO, _item.TEN, _item.NGAY_SINH, _item.NOI_SINH, _item.PHAI, _item.DIA_CHI_THUONG_TRU, 
                        _item.SO_CMND,_item.MS_TO, _item.NGAY_VAO_LAM, _item.BO_VIEC, _item.NGAY_NGHI_VIEC, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_CONG_NHAN.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_CONG_NHAN SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class CONG_NHAN
    {
        public CONG_NHAN() { }
        public int STT { get; set; }
        public string MS_CONG_NHAN { get; set; }
        public string MS_CONG_NHAN_CU { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public DateTime NGAY_SINH { get; set; }
        public string NOI_SINH { get; set; }
        public bool PHAI { get; set; }
        public string DIA_CHI_THUONG_TRU { get; set; }
        public string SO_CMND { get; set; }
        public int MS_TO { get; set; }
        public DateTime NGAY_VAO_LAM { get; set; }
        public bool BO_VIEC { get; set; }
        public DateTime NGAY_NGHI_VIEC { get; set; }
        public string STATUS { get; set; }
    }
}