using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_PhuTung_to_CMMS
    {
        public integrate_PhuTung_to_CMMS()
        {
        }

        private DataTable IC_PhuTungTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                IC_PhuTungTransfer = new DataTable();
                string _sqlExec = "SELECT CONVERT(NVARCHAR(10),STT) AS STT , MS_PT, MS_PT_NCC, MS_PT_CTY, TEN_PT, TEN_PT_VIET, QUY_CACH, DVT, TEN_DVT_V, " +
                " TEN_DVT_A, ISNULL(DUNG_CU_DO,CONVERT(BIT,0)) AS DUNG_CU_DO, ISNULL(SO_NGAY_DAT_MUA_HANG,0) AS SO_NGAY_DAT_MUA_HANG , ISNULL(TON_TOI_THIEU,0) AS TON_TOI_THIEU, ISNULL(TON_KHO_MAX,0) AS TON_KHO_MAX, " +
                " ISNULL(MS_CLASS,0) AS MS_CLASS, ISNULL(HANG_NGOAI,CONVERT(BIT,0)) AS HANG_NGOAI, ISNULL(THEO_KHO, CONVERT(BIT,0)) AS THEO_KHO, ISNULL(MS_VI_TRI,0) AS MS_VI_TRI, TEN_VI_TRI, ISNULL(MS_KHO,0) AS MS_KHO, TEN_KHO, ISNULL(MS_HSX,0) AS MS_HSX, TEN_HSX, MS_KH, TEN_CONG_TY, TEN_RUT_GON, DIA_CHI, TEL, FAX, TEN_NDD, EMAIL, " +
                " TAI_KHOAN_ANH, MS_THUE, MS_LOAI_VT, TEN_LOAI_VT_TV, ISNULL(CONVERT(NVARCHAR(30),INSERT_DATE,121),'') AS INSERT_DATE, ISNULL(CONVERT(NVARCHAR(30),UPDATE_DATE,121),'') AS UPDATE_DATE, ISNULL(DA_CHUYEN , CONVERT(BIT,0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30),NGAY_CHUYEN,121),'') as NGAY_CHUYEN " +
                " FROM dbo.TB_IC_PHU_TUNG WHERE (DA_CHUYEN = CONVERT(BIT, 0))";
                IC_PhuTungTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }
        public string ExecSynchronizeIC_Phu_Tung_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (IC_PhuTungTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in IC_PhuTungTransfer.Rows)
                    {
                        IC_Phu_Tung _item = new IC_Phu_Tung();
                        _item.STT = _rowtransfer["STT"].ToString();
                        _item.MS_PT = _rowtransfer["MS_PT"].ToString();
                        _item.MS_PT_NCC = _rowtransfer["MS_PT_NCC"].ToString();
                        _item.MS_PT_CTY = _rowtransfer["MS_PT_CTY"].ToString();
                        _item.TEN_PT = _rowtransfer["TEN_PT"].ToString();
                        _item.TEN_PT_VIET = _rowtransfer["TEN_PT_VIET"].ToString();
                        _item.QUY_CACH = _rowtransfer["QUY_CACH"].ToString();
                        _item.DVT = _rowtransfer["DVT"].ToString();
                        _item.TEN_DVT_V = _rowtransfer["TEN_DVT_V"].ToString();
                        _item.TEN_DVT_A = _rowtransfer["TEN_DVT_A"].ToString();
                        _item.DUNG_CU_DO = (bool)_rowtransfer["DUNG_CU_DO"];
                        _item.SO_NGAY_DAT_MUA_HANG = int.Parse(_rowtransfer["SO_NGAY_DAT_MUA_HANG"].ToString());
                        _item.TON_TOI_THIEU = float.Parse(_rowtransfer["TON_TOI_THIEU"].ToString());
                        _item.TON_KHO_MAX = float.Parse(_rowtransfer["TON_KHO_MAX"].ToString());
                        _item.MS_CLASS = int.Parse(_rowtransfer["MS_CLASS"].ToString());
                        _item.HANG_NGOAI = (bool)_rowtransfer["HANG_NGOAI"]; //false;//_rowtransfer["HANG_NGOAI"].ToString();
                        _item.THEO_KHO = (bool)_rowtransfer["THEO_KHO"]; //false; // _rowtransfer["THEO_KHO"].ToString();
                        _item.MS_VI_TRI = int.Parse(_rowtransfer["MS_VI_TRI"].ToString());
                        _item.TEN_VI_TRI = _rowtransfer["TEN_VI_TRI"].ToString();
                        _item.MS_KHO = int.Parse(_rowtransfer["MS_KHO"].ToString());
                        _item.TEN_KHO = _rowtransfer["TEN_KHO"].ToString();
                        _item.MS_HSX = int.Parse(_rowtransfer["MS_HSX"].ToString());
                        _item.TEN_HSX = _rowtransfer["TEN_HSX"].ToString();
                        _item.MS_KH = _rowtransfer["MS_KH"].ToString();
                        _item.TEN_CONG_TY = _rowtransfer["TEN_CONG_TY"].ToString();
                        _item.TEN_RUT_GON = _rowtransfer["TEN_RUT_GON"].ToString();
                        _item.DIA_CHI = _rowtransfer["DIA_CHI"].ToString();
                        _item.TEL = _rowtransfer["TEL"].ToString();
                        _item.FAX = _rowtransfer["FAX"].ToString();
                        _item.TEN_NDD = _rowtransfer["TEN_NDD"].ToString();
                        _item.EMAIL = _rowtransfer["EMAIL"].ToString();
                        _item.TAI_KHOAN_ANH = _rowtransfer["TAI_KHOAN_ANH"].ToString();
                        _item.MS_THUE = _rowtransfer["MS_THUE"].ToString();
                        _item.MS_LOAI_VT = _rowtransfer["MS_LOAI_VT"].ToString();
                        _item.TEN_LOAI_VT_TV = _rowtransfer["TEN_LOAI_VT_TV"].ToString();
                        _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
                        _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
                        _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
                        _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();

                        if (UpdateToDBCMMS(_item))
                        {
                            UpdateToDBIntegration(_item.STT.ToString());
                        }
                      
                    }
                }
                else
                {
                    return "khong co du lieu";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "OK";
        }
        private bool UpdateToDBCMMS(IC_Phu_Tung _item)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_IC_PHU_TUNG_UPDATE", _item.MS_PT ,_item.MS_PT_NCC, _item.MS_PT_CTY , _item.TEN_PT,_item.TEN_PT_VIET, 
                    _item.QUY_CACH , _item.DVT , _item.TEN_DVT_V , _item.TEN_DVT_A,_item.DUNG_CU_DO,_item.SO_NGAY_DAT_MUA_HANG,_item.TON_TOI_THIEU,_item.TON_KHO_MAX,_item.MS_CLASS,
                    _item.HANG_NGOAI,_item.THEO_KHO,_item.MS_VI_TRI,_item.TEN_VI_TRI,_item.MS_KHO,_item.TEN_KHO, _item.MS_HSX,_item.TEN_HSX,_item.MS_KH,_item.TEN_CONG_TY,
                    _item.TEN_RUT_GON,_item.DIA_CHI,_item.TEL,_item.FAX,_item.TEN_NDD,_item.EMAIL,_item.TAI_KHOAN_ANH,_item.MS_THUE,_item.MS_LOAI_VT,_item.TEN_LOAI_VT_TV,
                    _item.INSERT_DATE,_item.UPDATE_DATE,_item.DA_CHUYEN,_item.NGAY_CHUYEN);
            }
            catch {
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_IC_PHU_TUNG SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   
    }

    public class IC_Phu_Tung
    {
        public IC_Phu_Tung() { }
        public string STT { get; set; }
        public  string MS_PT  {get; set;}
        public  string MS_PT_NCC  {get; set;}
        public  string MS_PT_CTY  {get; set;}
        public  string TEN_PT  {get; set;}
        public  string TEN_PT_VIET  {get; set;}
        public  string QUY_CACH  {get; set;}
        public  string DVT  {get; set;}
        public  string TEN_DVT_V  {get; set;}
        public  string TEN_DVT_A  {get; set;}
        public  bool DUNG_CU_DO  {get; set;}
        public  int SO_NGAY_DAT_MUA_HANG  {get; set;}
        public  float TON_TOI_THIEU  {get; set;}
        public  float TON_KHO_MAX  {get; set;}
        public  int MS_CLASS  {get; set;}
        public  bool HANG_NGOAI  {get; set;}
        public  bool THEO_KHO  {get; set;}
        public  int MS_VI_TRI  {get; set;}
        public  string TEN_VI_TRI  {get; set;}
        public  int MS_KHO  {get; set;}
        public  string TEN_KHO  {get; set;}
        public  int MS_HSX  {get; set;}
        public  string TEN_HSX  {get; set;}
        public  string MS_KH  {get; set;}
        public  string TEN_CONG_TY  {get; set;}
        public  string TEN_RUT_GON  {get; set;}
        public  string DIA_CHI   {get; set;}
        public  string TEL  {get; set;}
        public  string FAX  {get; set;}
        public  string TEN_NDD  {get; set;}
        public  string EMAIL   {get; set;}
        public  string TAI_KHOAN_ANH  {get; set;}
        public  string MS_THUE  {get; set;}
        public  string MS_LOAI_VT  {get; set;}
        public  string TEN_LOAI_VT_TV  {get; set;}
        public  string INSERT_DATE   {get; set;}
        public  string UPDATE_DATE   {get; set;}
        public  bool DA_CHUYEN { get; set; }
        public  string NGAY_CHUYEN  {get; set;}



    }
}
