using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;
using System.Data.SqlClient;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_Nhap_Kho_to_CMMS
    {
        public integrate_Nhap_Kho_to_CMMS()
        {
        }

        private DataTable Nhap_KhoTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                Nhap_KhoTransfer = new DataTable();
                string _sqlExec = "SELECT STT, MS_DH_NHAP_PT,  SO_PHIEU_XN,ISNULL(CONVERT(NVARCHAR(30), GIO, 121), '') AS GIO, ISNULL(ROW_ID,0) AS ROW_ID , ISNULL(CONVERT(NVARCHAR(30), NGAY, 121), '') AS NGAY, " +
                                " MS_KHO, ISNULL(MS_VI_TRI,0) AS MS_VI_TRI, MS_PT, ISNULL(SO_LUONG_CTU, 0) AS SO_LUONG_CTU, ISNULL(SL_THUC_NHAP,0) AS SL_THUC_NHAP, " +
                                " ISNULL(DON_GIA,0) AS DON_GIA , N'VND' AS NGOAI_TE , '1' TY_GIA, CONVERT(FLOAT,'5.72E-05') AS TY_GIA_USD , ISNULL(THANH_TIEN,0) AS THANH_TIEN, ISNULL(MS_DANG_NHAP, 0 ) AS MS_DANG_NHAP ,DANG_NHAP_VIET, NGUOI_NHAP, " +
                                " ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUNG_TU, 121), '') AS NGAY_CHUNG_TU, SO_CHUNG_TU, GHI_CHU, THU_KHO, MS_DDH, SO_DE_XUAT, NGUOI_GIAO, " +
                                " LY_DO, CAN_CU, THU_KHO_KY, NGUOI_LAP, ISNULL(CONVERT(NVARCHAR(30), BAO_HANH_DEN_NGAY, 121), '') AS BAO_HANH_DEN_NGAY, XUAT_XU, TAX, MS_KH, TEN_VI_TRI_1, TEN_VI_TRI_2, TEN_VI_TRI_3, " +
                                " ISNULL(CONVERT(NVARCHAR(30), INSERT_DATE, 121), '') AS INSERT_DATE,ISNULL(CONVERT(NVARCHAR(30), UPDATE_DATE, 121), '') AS UPDATE_DATE, " +
                                " ISNULL(DA_CHUYEN, CONVERT(BIT, 0)) AS DA_CHUYEN, ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUYEN, 121), '')  AS NGAY_CHUYEN " +
                                " FROM dbo.TB_NHAP_KHO WHERE ISNULL(DA_CHUYEN, CONVERT(BIT, 0)) = 0 " +
                                " ORDER BY STT";
                Nhap_KhoTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }

        
        public string ExecSynchronizeNHAP_KHO_To_DBCMMS()
        {
            try
            {
                GetDataTransfer();
                if (Nhap_KhoTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in Nhap_KhoTransfer.Rows)
                    {
                        NHAP_KHO _item = new NHAP_KHO();
                        _item.STT = int.Parse(_rowtransfer["STT"].ToString());
                        _item.MS_DH_NHAP_PT = _rowtransfer["MS_DH_NHAP_PT"].ToString();
                        _item.SO_PHIEU_XN = _rowtransfer["SO_PHIEU_XN"].ToString();
                        _item.GIO = _rowtransfer["GIO"].ToString();
                        _item.ROW_ID = int.Parse(_rowtransfer["ROW_ID"].ToString());
                        _item.NGAY = _rowtransfer["NGAY"].ToString();
                        _item.MS_KHO = _rowtransfer["MS_KHO"].ToString();
                        _item.MS_VI_TRI = int.Parse(_rowtransfer["MS_VI_TRI"].ToString());
                        _item.MS_PT = _rowtransfer["MS_PT"].ToString();
                        _item.SO_LUONG_CTU = float.Parse(_rowtransfer["SO_LUONG_CTU"].ToString());
                        _item.SL_THUC_NHAP = float.Parse(_rowtransfer["SL_THUC_NHAP"].ToString());
                        _item.DON_GIA = float.Parse( _rowtransfer["DON_GIA"].ToString());
                        _item.THANH_TIEN = float.Parse(_rowtransfer["THANH_TIEN"].ToString());
                        _item.MS_DANG_NHAP = int.Parse(_rowtransfer["MS_DANG_NHAP"].ToString());
                        _item.DANG_NHAP_VIET = _rowtransfer["DANG_NHAP_VIET"].ToString();
                        _item.NGUOI_NHAP = _rowtransfer["NGUOI_NHAP"].ToString();
                        _item.NGAY_CHUNG_TU = _rowtransfer["NGAY_CHUNG_TU"].ToString();
                        _item.SO_CHUNG_TU = _rowtransfer["SO_CHUNG_TU"].ToString();
                        _item.GHI_CHU = _rowtransfer["GHI_CHU"].ToString();
                        _item.THU_KHO = _rowtransfer["THU_KHO"].ToString();
                        _item.MS_DDH = _rowtransfer["MS_DDH"].ToString();
                        _item.SO_DE_XUAT = _rowtransfer["SO_DE_XUAT"].ToString();
                        _item.NGUOI_GIAO = _rowtransfer["NGUOI_GIAO"].ToString();
                        _item.LY_DO = _rowtransfer["LY_DO"].ToString();
                        _item.CAN_CU = _rowtransfer["CAN_CU"].ToString();
                        _item.THU_KHO_KY = _rowtransfer["THU_KHO_KY"].ToString();
                        _item.NGUOI_LAP = _rowtransfer["NGUOI_LAP"].ToString();
                        _item.BAO_HANH_DEN_NGAY = _rowtransfer["BAO_HANH_DEN_NGAY"].ToString();
                        _item.TAX = float.Parse(_rowtransfer["TAX"].ToString());
                        _item.NGOAI_TE = _rowtransfer["NGOAI_TE"].ToString();
                        _item.TY_GIA = float.Parse(_rowtransfer["TY_GIA"].ToString());
                        _item.TY_GIA_USD = float.Parse(_rowtransfer["TY_GIA_USD"].ToString());
                        _item.TEN_VI_TRI_1 = _rowtransfer["TEN_VI_TRI_1"].ToString();
                        _item.TEN_VI_TRI_2 = _rowtransfer["TEN_VI_TRI_2"].ToString();
                        _item.TEN_VI_TRI_3 = _rowtransfer["TEN_VI_TRI_3"].ToString();
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
        private bool UpdateToDBCMMS(NHAP_KHO _item)
        {
            try
            {

                SqlConnection scon = new SqlConnection(cmms_common.cmms_connection);
                scon.Open();
                SqlTransaction sqlTrans = scon.BeginTransaction();
                try
                {

                    //SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_NHAP_KHO_HEADER_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.SO_PHIEU_XN, _item.GIO, _item.NGAY,
                    //    _item.MS_KHO, _item.MS_DANG_NHAP, _item.NGUOI_NHAP, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU, _item.GHI_CHU, _item.THU_KHO, _item.MS_DDH, _item.SO_DE_XUAT, _item.THU_KHO_KY, _item.NGUOI_LAP);
                    //SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_NHAP_KHO_VAT_TU_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.MS_PT, _item.ROW_ID, _item.SO_LUONG_CTU, _item.SL_THUC_NHAP, _item.DON_GIA,_item.NGOAI_TE,_item.TY_GIA, _item.TY_GIA_USD, _item.THANH_TIEN, _item.TAX, _item.MS_VI_TRI,_item.MS_KHO);


                    SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_NHAP_KHO_SYN_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.SO_PHIEU_XN, _item.GIO, _item.ROW_ID, _item.NGAY,
                        _item.MS_KHO, _item.MS_VI_TRI ,_item.MS_PT,_item.SO_LUONG_CTU, _item.SL_THUC_NHAP,_item.DON_GIA,_item.THANH_TIEN, _item.MS_DANG_NHAP,_item.DANG_NHAP_VIET ,
                        _item.NGUOI_NHAP, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU, _item.GHI_CHU, _item.THU_KHO, _item.MS_DDH, _item.SO_DE_XUAT , _item.NGUOI_GIAO,_item.LY_DO,
                        _item.CAN_CU, _item.THU_KHO_KY, _item.NGUOI_LAP,_item.BAO_HANH_DEN_NGAY,_item.XUAT_XU,_item.TAX,_item.MS_KH,_item.TEN_VI_TRI_1,_item.TEN_VI_TRI_2,_item.TEN_VI_TRI_3,
                        _item.INSERT_DATE,_item.UPDATE_DATE,_item.DA_CHUYEN,_item.NGAY_CHUYEN);

                    sqlTrans.Commit();
                    scon.Close();
                }
                catch { 
                    sqlTrans.Rollback();
                    scon.Close();
                }

               
                //SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_NHAP_KHO_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.SO_PHIEU_XN, _item.GIO, _item.ROW_ID, _item.NGAY,
                //    _item.MS_KHO, _item.MS_VI_TRI, _item.MS_PT, _item.SO_LUONG_CTU,
                //    _item.SL_THUC_NHAP, _item.DON_GIA, _item.THANH_TIEN, _item.MS_DANG_NHAP,
                //    _item.DANG_NHAP_VIET, _item.NGUOI_NHAP, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU,
                //    _item.GHI_CHU, _item.THU_KHO, _item.MS_DDH, _item.SO_DE_XUAT, _item.NGUOI_GIAO, _item.LY_DO, _item.CAN_CU, _item.THU_KHO_KY, _item.NGUOI_LAP, _item.BAO_HANH_DEN_NGAY,
                //    _item.XUAT_XU, _item.TAX, _item.MS_KH, _item.TEN_VI_TRI_1, _item.TEN_VI_TRI_2, _item.TEN_VI_TRI_3,
                //    _item.INSERT_DATE, _item.UPDATE_DATE, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
            }
            catch
            {
                return false;
            }

            return true;
        }
        private bool UpdateToDBIntegration(string STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_NHAP_KHO SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch { }
            return true;
        }
   

    }
    public class NHAP_KHO
    {
        public NHAP_KHO() { }
        public int STT { get; set; }
        public string MS_DH_NHAP_PT { get; set; }
        public string SO_PHIEU_XN { get; set; }
        public string GIO { get; set; }
        public int ROW_ID { get; set; }
        public string NGAY { get; set; }
        public string MS_KHO { get; set; }
        public int MS_VI_TRI { get; set; }
        public string MS_PT { get; set; }
        public float SO_LUONG_CTU { get; set; }
        public float SL_THUC_NHAP { get; set; }
        public float DON_GIA { get; set; }
        public float THANH_TIEN { get; set; }
        public int MS_DANG_NHAP { get; set; }
        public string DANG_NHAP_VIET { get; set; }
        public string NGUOI_NHAP { get; set; }
        public string NGAY_CHUNG_TU { get; set; }
        public string SO_CHUNG_TU { get; set; }
        public string GHI_CHU { get; set; }
        public string THU_KHO { get; set; }
        public string MS_DDH { get; set; }
        public string SO_DE_XUAT { get; set; }
        public string NGUOI_GIAO { get; set; }
        public string LY_DO { get; set; }
        public string CAN_CU { get; set; }
        public string THU_KHO_KY { get; set; }
        public string NGUOI_LAP { get; set; }
        public string BAO_HANH_DEN_NGAY { get; set; }
        public string XUAT_XU { get; set; }
        public float TAX { get; set; }
        public string MS_KH { get; set; }
        public string NGOAI_TE { get; set; }
        public float TY_GIA {get;set;}
        public float TY_GIA_USD { get; set; }
        public string TEN_VI_TRI_1 { get; set; }
        public string TEN_VI_TRI_2 { get; set; }
        public string TEN_VI_TRI_3 { get; set; }
        public string INSERT_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
        public bool DA_CHUYEN { get; set; }
        public string NGAY_CHUYEN { get; set; }
    }
}
