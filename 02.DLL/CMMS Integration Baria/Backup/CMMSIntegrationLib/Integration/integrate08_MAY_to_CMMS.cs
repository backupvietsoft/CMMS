using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;
using System.Data.SqlClient;

namespace CMMSIntegrationLib.Integration
{
    public class integrate08_MAY_to_CMMS
    {
        public integrate08_MAY_to_CMMS()
        {
        }

        private DataTable dtMayTransfer = new DataTable();
        private bool GetDataTransfer(out string sLoi)
        {
            try
            {
                dtMayTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],[MS_MAY],[MS_MAY_CU],ISNULL([TEN_MAY],'') AS TEN_MAY, ISNULL([MS_NHOM_MAY],'') AS MS_NHOM_MAY,ISNULL([MS_KH],'') AS MS_KH," +
                        " ISNULL([SO_THANG_KHAU_HAO],0) AS SO_THANG_KHAU_HAO,ISNULL([SERIAL_NUMBER],'') AS SERIAL_NUMBER,ISNULL([NGAY_DUA_VAO_SD],'') AS NGAY_DUA_VAO_SD," +
                        " ISNULL([GIA_MUA],0) AS GIA_MUA,ISNULL([SO_CT],'') AS SO_CT, ISNULL([TI_GIA_VND],1) AS TI_GIA_VND, ISNULL(STATUS,'N') AS STATUS " +
                        " FROM dbo.TB_MAY WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) ";

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(integrate_common.cmms_connection);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlDataAdapter da = new SqlDataAdapter(_sqlExec, con);
                da.ReturnProviderSpecificTypes = true;

                DataSet ds = new DataSet();

                da.Fill(ds);
//                string _sqlExec = "SELECT [STT],[MS_MAY],[MS_MAY_CU],[TEN_MAY] AS TEN_MAY, [MS_NHOM_MAY] AS MS_NHOM_MAY,[MS_KH] AS MS_KH," +
//                        " [SO_THANG_KHAU_HAO] AS SO_THANG_KHAU_HAO,[SERIAL_NUMBER] SERIAL_NUMBER,[NGAY_DUA_VAO_SD] AS NGAY_DUA_VAO_SD," +
//                        " [GIA_MUA] AS GIA_MUA,[SO_CT] AS SO_CT, [TI_GIA_VND] AS TI_GIA_VND,ISNULL (STATUS,'N') AS STATUS " +
//                        " FROM dbo.TB_MAY WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)" +
//                        " ORDER BY ISNULL(INSERT_DATE, GETDATE()), ISNULL(UPDATE_DATE, GETDATE()) "; 
//dtMayTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
                dtMayTransfer = ds.Tables[0];
                sLoi = "";
                return true;
            }
            catch (Exception ex)
            { 
                sLoi = ex.Message;
                return false;
            }
        }

        public string ExecSynchronizeMAY_To_DBCMMS()
        {
            string sLoi = "";
            MAY _item = new MAY();
            try
            {
                if (!GetDataTransfer(out sLoi))
                    return sLoi;

                if (dtMayTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in dtMayTransfer.Rows)
                    {
                        _item = new MAY();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_MAY"].ToString());
                        _item.MS_MAY_CU = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_MAY_CU"].ToString());
                        _item.TEN_MAY = (_rowtransfer["TEN_MAY"].ToString() == "" ? null : VSCommons.MConvertFont.MVni2Uni(_rowtransfer["TEN_MAY"].ToString()));
                        _item.MS_NHOM_MAY = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_NHOM_MAY"].ToString());
                        _item.MS_KH = VSCommons.MConvertFont.MVni2Uni(_rowtransfer["MS_KH"].ToString());
                        _item.SO_THANG_KHAU_HAO = int.Parse(_rowtransfer["SO_THANG_KHAU_HAO"].ToString());
                        _item.SERIAL_NUMBER = (_rowtransfer["SERIAL_NUMBER"].ToString() == "" ? null : VSCommons.MConvertFont.MVni2Uni(_rowtransfer["SERIAL_NUMBER"].ToString()));
                        _item.NGAY_DUA_VAO_SD = DateTime.Parse(_rowtransfer["NGAY_DUA_VAO_SD"].ToString());
                        _item.GIA_MUA = float.Parse(_rowtransfer["GIA_MUA"].ToString());
                        _item.SO_CT = (_rowtransfer["SO_CT"].ToString() == "" ? null : VSCommons.MConvertFont.MVni2Uni(_rowtransfer["SO_CT"].ToString()));
                        _item.TI_GIA_VND = float.Parse(_rowtransfer["TI_GIA_VND"].ToString());
                        _item.STATUS = (_rowtransfer["STATUS"].ToString() == "" ? null : _rowtransfer["STATUS"].ToString());
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
                return _item.MS_MAY.ToString()  + "-" + e.ToString();
            }
            if (sLoi.Length > 0) return sLoi; else return "";;
        }
        private bool UpdateToDBCMMS(MAY _item, out string sLoi)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_MAY_UPDATE",
                        _item.MS_MAY, _item.MS_MAY_CU, _item.TEN_MAY, _item.MS_NHOM_MAY, _item.MS_KH, _item.SO_THANG_KHAU_HAO,
                        _item.SERIAL_NUMBER, _item.NGAY_DUA_VAO_SD, _item.GIA_MUA, _item.SO_CT, _item.TI_GIA_VND, _item.STATUS);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = _item.MS_MAY.ToString() + "-" + ex.Message;
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text,
                        "UPDATE TB_MAY SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
    }

    public class MAY
    {
        public MAY() { }
        public int STT { get; set; }
        public string MS_MAY { get; set; }
        public string MS_MAY_CU { get; set; }
        public string TEN_MAY { get; set; }
        public string MS_NHOM_MAY { get; set; }
        public string MS_KH { get; set; }
        public int SO_THANG_KHAU_HAO { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public DateTime NGAY_DUA_VAO_SD { get; set; }
        public float GIA_MUA { get; set; }
        public string SO_CT { get; set; }
        public float TI_GIA_VND { get; set; }
        public string STATUS { get; set; }
    }
}