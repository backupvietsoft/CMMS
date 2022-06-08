using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate12_TB_GL_ACCOUNT_to_CMMS
    {
        public integrate12_TB_GL_ACCOUNT_to_CMMS()
        {
        }

        private DataTable dtBPCPTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtBPCPTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],MS_GL,TEN_GL,ISNULL(MS_CHA,'') AS MS_CHA, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_GL_ACCOUNT WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
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

        public string ExecSynchronizeGL_ACCOUNT_To_DBCMMS()
        {
            string sLoi = "";
            GL_ACCOUNT _item = new GL_ACCOUNT();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtBPCPTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtBPCPTransfer.Rows)
                    {
                        _item = new GL_ACCOUNT();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_GL = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_GL"].ToString());
                        _item.TEN_GL = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_GL"].ToString());
                        _item.MS_CHA = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_CHA"].ToString());
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
                return _item.MS_GL.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";
        }
        private bool UpdateToDBCMMS(GL_ACCOUNT _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_GL_ACOUNT_UPDATE",
                        _item.MS_GL, _item.TEN_GL, _item.MS_CHA, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_GL.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_GL_ACCOUNT SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }
    public class GL_ACCOUNT
    {
        public GL_ACCOUNT() { }
        public int STT { get; set; }
        public string MS_GL { get; set; }
        public string TEN_GL { get; set; }
        public string MS_CHA { get; set; }
        public string STATUS { get; set; }
    }
}