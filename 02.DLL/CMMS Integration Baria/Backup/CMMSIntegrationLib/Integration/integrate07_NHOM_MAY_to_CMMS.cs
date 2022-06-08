using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate07_NHOM_MAY_to_CMMS
    {
        public integrate07_NHOM_MAY_to_CMMS()
        {
        }

        private DataTable dtNhomMayTransfer = new DataTable();
        private DataTable dtLoaiMayTransfer = new DataTable();

        private bool GetDataTransferLoaiMay(out string sLoi)
        {
            try
            {
                dtLoaiMayTransfer = new DataTable();
                //[STT],[MS_NHOM_MAY],[MS_NHOM_MAY_CU],[MS_LOAI_MAY],[TEN_NHOM_MAY],[INSERT_DATE]
                string _sqlExec = "SELECT [STT],ISNULL(MS_LOAI_MAY,'') AS MS_LOAI_MAY,ISNULL(MS_LOAI_MAY_CU,'') AS MS_LOAI_MAY_CU, " +
                       " ISNULL(TEN_LOAI_MAY,'') AS TEN_LOAI_MAY, ISNULL(STATUS,'N') AS STATUS " +
                       " FROM dbo.TB_LOAI_MAY WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                       " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtLoaiMayTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            {
                sLoi = ex.Message;
                return false;
            }
        }

        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                 dtNhomMayTransfer = new DataTable();
                //[STT],[MS_NHOM_MAY],[MS_NHOM_MAY_CU],[MS_LOAI_MAY],[TEN_NHOM_MAY],[INSERT_DATE]
                 string _sqlExec = "SELECT [STT],ISNULL(MS_NHOM_MAY,'') AS MS_NHOM_MAY,ISNULL(MS_NHOM_MAY_CU,'') AS MS_NHOM_MAY_CU, " +
                        " ISNULL(MS_LOAI_MAY,'') AS MS_LOAI_MAY, ISNULL(TEN_NHOM_MAY,'') AS TEN_NHOM_MAY, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_NHOM_MAY WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";
                dtNhomMayTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }


        public string ExecSynchronizeLOAI_MAY_To_DBCMMS()
        {
            string sLoi = "";
            LOAI_MAY _item = new LOAI_MAY();
            try
            {
                if (!GetDataTransferLoaiMay(out sLoi))
                    return sLoi;

                if (dtLoaiMayTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtLoaiMayTransfer.Rows)
                    {
                        _item = new LOAI_MAY();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_LOAI_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_MAY"].ToString());
                        _item.MS_LOAI_MAY_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_MAY_CU"].ToString());
                        _item.TEN_LOAI_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_LOAI_MAY"].ToString());
                        _item.STATUS = _rowtransfer["STATUS"].ToString();
                        if (UpdateToDBCMMSLoaiMay(_item, out sLoi))
                            UpdateToDBIntegrationLoaiMay(_item.STT.ToString());
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
                return _item.MS_LOAI_MAY.ToString() + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return ""; ;
        }


        public string ExecSynchronizeNHOM_MAY_To_DBCMMS()
        {
            string sLoi = "";
            NHOM_MAY _item = new NHOM_MAY();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtNhomMayTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtNhomMayTransfer.Rows)
                    {
                        _item = new NHOM_MAY();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_NHOM_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_NHOM_MAY"].ToString());
                        _item.MS_NHOM_MAY_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_NHOM_MAY_CU"].ToString());
                        _item.MS_LOAI_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_LOAI_MAY"].ToString());
                        _item.TEN_NHOM_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_NHOM_MAY"].ToString());
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
                return _item.MS_NHOM_MAY.ToString() + "-" + _item.MS_LOAI_MAY.ToString() + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }

        private bool UpdateToDBCMMSLoaiMay(LOAI_MAY _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_LOAI_MAY_UPDATE",
                        _item.MS_LOAI_MAY, _item.MS_LOAI_MAY_CU, _item.TEN_LOAI_MAY, _item.STATUS);

                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_LOAI_MAY.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }

        private bool UpdateToDBCMMS(NHOM_MAY _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_NHOM_MAY_UPDATE",
                        _item.MS_NHOM_MAY, _item.MS_NHOM_MAY_CU, _item.MS_LOAI_MAY, _item.TEN_NHOM_MAY, _item.STATUS);


                
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_NHOM_MAY.ToString() + "-" + _item.MS_LOAI_MAY.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }

        private bool UpdateToDBIntegrationLoaiMay(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_LOAI_MAY SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_NHOM_MAY SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class NHOM_MAY
    {
        public NHOM_MAY() { }
        public int STT { get; set; }
        public string MS_NHOM_MAY { get; set; }
        public string MS_NHOM_MAY_CU { get; set; }
        public string MS_LOAI_MAY { get; set; }
        public string TEN_NHOM_MAY { get; set; }
        public string STATUS { get; set; }

    }
    public class LOAI_MAY
    {
        public LOAI_MAY() { }
        public int STT { get; set; }
        public string MS_LOAI_MAY { get; set; }
        public string MS_LOAI_MAY_CU { get; set; }
        public string TEN_LOAI_MAY { get; set; }
        public string STATUS { get; set; }

    }}
