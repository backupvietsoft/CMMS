using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using CMMSIntegrationLib.CMMS;
using System.Data.SqlClient;

namespace CMMSIntegrationLib.Integration
{
    public class integrate_Nhap_Kho_End_CMMS
    {
        public integrate_Nhap_Kho_End_CMMS()
        {
        }

        //private DataTable Xuat_KhoTransfer = new DataTable();
        //private void GetDataTransfer()
        //{
        //    try
        //    {
        //        Xuat_KhoTransfer = new DataTable();
        //        string _sqlExec = "SELECT STT, MS_DH_XUAT_PT,  SO_PHIEU_XN,ISNULL(CONVERT(NVARCHAR(30), GIO, 121), '') AS GIO, " +
        //        " ISNULL(ROW_ID_NHAP,0) AS ROW_ID_NHAP,  ISNULL(ROW_ID,0) AS ROW_ID , ISNULL(CONVERT(NVARCHAR(30), NGAY, 121), '') AS NGAY,  MS_KHO, '' AS TEN_KHO, " + 
        //        " MS_PT, ISNULL(SO_LUONG_CTU, 0) AS SO_LUONG_CTU,ISNULL(SO_LUONG_THUC_XUAT,0) AS SO_LUONG_THUC_XUAT,  MS_DH_NHAP_PT , " +
        //        " ISNULL(MS_VI_TRI,0) AS MS_VI_TRI , '' AS TEN_VI_TRI, MS_MAY , ISNULL(MS_DANG_XUAT, 0 ) AS MS_DANG_XUAT ,DANG_XUAT_VIET, NGUOI_NHAN,  " +
        //        " ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUNG_TU, 121), '') AS NGAY_CHUNG_TU, "+
        //        " SO_CHUNG_TU, MS_PHIEU_BAO_TRI ,  GHI_CHU, LY_DO_XUAT ,  THU_KHO, ISNULL(MS_BP_CHIU_PHI ,-1) AS MS_BP_CHIU_PHI,  NGUOI_LAP, CAN_CU , " +
        //        " ISNULL(DON_GIA,0) AS DON_GIA , ISNULL(NGOAI_TE,'VND') AS NGOAI_TE , '1' TY_GIA, ISNULL(TY_GIA_USD,CONVERT(FLOAT,'5.72E-05')) AS TY_GIA_USD , " +
        //        " ISNULL(CONVERT(NVARCHAR(30), BAO_HANH_DEN_NGAY, 121), '') AS BAO_HANH_DEN_NGAY, XUAT_XU,ISNULL(CONVERT(NVARCHAR(30), INSERT_DATE, 121), '') AS INSERT_DATE, " +
        //        " ISNULL(CONVERT(NVARCHAR(30), UPDATE_DATE, 121), '') AS UPDATE_DATE,  ISNULL(DA_CHUYEN, CONVERT(BIT, 0)) AS DA_CHUYEN, " +
        //        " ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUYEN, 121), '')  AS NGAY_CHUYEN  " +
        //        " FROM dbo.TB_PHIEU_XUAT WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0) AND MS_DH_NHAP_PT IN (SELECT DISTINCT MS_DH_NHAP_PT FROM TB_NHAP_KHO)";
        //        Xuat_KhoTransfer.Load(SqlHelper.ExecuteReader(integrate_common.cmms_connection, CommandType.Text, _sqlExec));
        //    }
        //    catch { }
        //}

        
        public string ExecSynchronizeNHAP_KHO_To_DBCMMS()
        {

            try
            {
                SqlConnection scon = new SqlConnection(cmms_common.cmms_connection);
                scon.Open();
                SqlCommand command = scon.CreateCommand();
                command.Connection = scon;
                command.CommandTimeout = 9999;
                SqlTransaction sqlTrans = scon.BeginTransaction();
                command.Transaction = sqlTrans;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "INTEGRATION_NHAP_KHO_SYN_UPDATE_TO_CMMS";
                try
                {
                    command.ExecuteNonQuery();
                    sqlTrans.Commit();
                    scon.Close();
                }
                catch
                {
                    sqlTrans.Rollback();
                    scon.Close();
                }
            }
            catch
            {
                return "false";
            }
            //try
            //{

            //    SqlConnection scon = new SqlConnection(cmms_common.cmms_connection);
            //    scon.Open();
            //    SqlTransaction sqlTrans = scon.BeginTransaction();
            //    try
            //    {

            //        SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "INTEGRATION_NHAP_KHO_SYN_UPDATE_TO_CMMS");
                       

            //        //SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_XUAT_KHO_VAT_TU_UPDATE", _item.STT, _item.MS_DH_XUAT_PT, _item.MS_PT, _item.MS_DH_NHAP_PT, _item.ROW_ID_NHAP, _item.ROW_ID, _item.SO_LUONG_CTU, _item.SO_LUONG_THUC_XUAT, _item.DON_GIA, _item.NGOAI_TE, _item.TY_GIA, _item.TY_GIA_USD, _item.MS_VI_TRI, _item.MS_KHO);

            //        sqlTrans.Commit();
            //        scon.Close();
            //    }
            //    catch (Exception e)
            //    {
            //        sqlTrans.Rollback();
            //        scon.Close();
                
            //    }


            //    //SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_NHAP_KHO_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.SO_PHIEU_XN, _item.GIO, _item.ROW_ID, _item.NGAY,
            //    //    _item.MS_KHO, _item.MS_VI_TRI, _item.MS_PT, _item.SO_LUONG_CTU,
            //    //    _item.SL_THUC_NHAP, _item.DON_GIA, _item.THANH_TIEN, _item.MS_DANG_NHAP,
            //    //    _item.DANG_NHAP_VIET, _item.NGUOI_NHAP, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU,
            //    //    _item.GHI_CHU, _item.THU_KHO, _item.MS_DDH, _item.SO_DE_XUAT, _item.NGUOI_GIAO, _item.LY_DO, _item.CAN_CU, _item.THU_KHO_KY, _item.NGUOI_LAP, _item.BAO_HANH_DEN_NGAY,
            //    //    _item.XUAT_XU, _item.TAX, _item.MS_KH, _item.TEN_VI_TRI_1, _item.TEN_VI_TRI_2, _item.TEN_VI_TRI_3,
            //    //    _item.INSERT_DATE, _item.UPDATE_DATE, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
            //}
            //catch
            //{
            //    return "false";
            //}



            //try
            //{
            //    GetDataTransfer();
            //    if (Xuat_KhoTransfer.Rows.Count > 0)
            //    {
            //        foreach (DataRow _rowtransfer in Xuat_KhoTransfer.Rows)
            //        {
            //            XUAT_KHO _item = new XUAT_KHO();
            //            _item.STT = int.Parse(_rowtransfer["STT"].ToString());
            //            _item.MS_DH_XUAT_PT = _rowtransfer["MS_DH_XUAT_PT"].ToString();
            //            _item.SO_PHIEU_XN = _rowtransfer["SO_PHIEU_XN"].ToString();
            //            _item.GIO = _rowtransfer["GIO"].ToString();
            //            _item.MS_DH_NHAP_PT = _rowtransfer["MS_DH_NHAP_PT"].ToString();
            //            _item.ROW_ID_NHAP = int.Parse(_rowtransfer["ROW_ID_NHAP"].ToString());
            //            _item.ROW_ID = int.Parse(_rowtransfer["ROW_ID"].ToString());
            //            _item.NGAY = _rowtransfer["NGAY"].ToString();
            //            _item.MS_KHO = _rowtransfer["MS_KHO"].ToString();
            //            _item.MS_VI_TRI = int.Parse(_rowtransfer["MS_VI_TRI"].ToString());
            //            _item.MS_PT = _rowtransfer["MS_PT"].ToString();
            //            _item.SO_LUONG_CTU = float.Parse(_rowtransfer["SO_LUONG_CTU"].ToString());
            //            _item.SO_LUONG_THUC_XUAT = float.Parse(_rowtransfer["SO_LUONG_THUC_XUAT"].ToString());
            //            _item.DON_GIA = float.Parse( _rowtransfer["DON_GIA"].ToString());
            //            //_item.THANH_TIEN = float.Parse(_rowtransfer["THANH_TIEN"].ToString());
            //            _item.MS_DANG_XUAT = int.Parse(_rowtransfer["MS_DANG_XUAT"].ToString());
            //            _item.DANG_XUAT_VIET = _rowtransfer["DANG_XUAT_VIET"].ToString();
            //            _item.NGUOI_NHAN = _rowtransfer["NGUOI_NHAN"].ToString();
            //            _item.NGAY_CHUNG_TU = _rowtransfer["NGAY_CHUNG_TU"].ToString();
            //            _item.SO_CHUNG_TU = _rowtransfer["SO_CHUNG_TU"].ToString();
            //            _item.GHI_CHU = _rowtransfer["GHI_CHU"].ToString();
            //            _item.THU_KHO = _rowtransfer["THU_KHO"].ToString();
            //            _item.MS_BP_CHIU_PHI = int.Parse(_rowtransfer["MS_BP_CHIU_PHI"].ToString());
            //            _item.MS_MAY = _rowtransfer["MS_MAY"].ToString();
            //            _item.MS_DH_NHAP_PT = _rowtransfer["MS_DH_NHAP_PT"].ToString();
            //            _item.MS_PHIEU_BAO_TRI = _rowtransfer["MS_PHIEU_BAO_TRI"].ToString();
            //            //_item.SO_DE_XUAT = _rowtransfer["SO_DE_XUAT"].ToString();
            //            //_item.NGUOI_GIAO = _rowtransfer["NGUOI_GIAO"].ToString();
            //            _item.LY_DO_XUAT = _rowtransfer["LY_DO_XUAT"].ToString();
            //            _item.CAN_CU = _rowtransfer["CAN_CU"].ToString();
            //            //_item.THU_KHO_KY = _rowtransfer["THU_KHO_KY"].ToString();
            //            _item.NGUOI_LAP = _rowtransfer["NGUOI_LAP"].ToString();
            //            _item.BAO_HANH_DEN_NGAY = _rowtransfer["BAO_HANH_DEN_NGAY"].ToString();
            //            //_item.TAX = float.Parse(_rowtransfer["TAX"].ToString());
            //            //_item.TEN_VI_TRI_1 = _rowtransfer["TEN_VI_TRI_1"].ToString();
            //            //_item.TEN_VI_TRI_2 = _rowtransfer["TEN_VI_TRI_2"].ToString();
            //            //_item.TEN_VI_TRI_3 = _rowtransfer["TEN_VI_TRI_3"].ToString();
            //            _item.INSERT_DATE = _rowtransfer["INSERT_DATE"].ToString();
            //            _item.UPDATE_DATE = _rowtransfer["UPDATE_DATE"].ToString();
            //            _item.DA_CHUYEN = (bool)_rowtransfer["DA_CHUYEN"];
            //            _item.NGAY_CHUYEN = _rowtransfer["NGAY_CHUYEN"].ToString();

            //            if (UpdateToDBCMMS(_item))
            //            {
            //                UpdateToDBIntegration(_item.STT.ToString());
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "khong co du lieu";
            //    }
            //}
            //catch (Exception e)
            //{
            //    return e.ToString();
            //}
            return "OK";
        }
        //private bool UpdateToDBCMMS(XUAT_KHO _item)
        //{
        //    try
        //    {

        //        SqlConnection scon = new SqlConnection(cmms_common.cmms_connection);
        //        scon.Open();
        //        SqlTransaction sqlTrans = scon.BeginTransaction();
        //        try
        //        {

        //            SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_XUAT_KHO_SYN_UPDATE", _item.STT, _item.MS_DH_XUAT_PT, _item.SO_PHIEU_XN, _item.GIO, _item.ROW_ID_NHAP , 
        //                _item.ROW_ID, _item.NGAY, _item.MS_KHO, _item.TEN_KHO , _item.MS_PT,_item.SO_LUONG_CTU,_item.SO_LUONG_THUC_XUAT,_item.MS_DH_NHAP_PT,_item.MS_VI_TRI,
        //                _item.TEN_VI_TRI,_item.MS_MAY, _item.MS_DANG_XUAT,_item.DANG_XUAT_VIET, _item.NGUOI_NHAN, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU,
        //                _item.MS_PHIEU_BAO_TRI, _item.GHI_CHU, _item.LY_DO_XUAT, _item.THU_KHO, _item.MS_BP_CHIU_PHI, _item.NGUOI_LAP,_item.CAN_CU,_item.DON_GIA,
        //                _item.NGOAI_TE,_item.TY_GIA,_item.TY_GIA_USD,_item.BAO_HANH_DEN_NGAY,_item.XUAT_XU,_item.INSERT_DATE,_item.UPDATE_DATE,_item.DA_CHUYEN,_item.NGAY_CHUYEN
        //                );

        //            //SqlHelper.ExecuteNonQuery(sqlTrans, "INTEGRATION_XUAT_KHO_VAT_TU_UPDATE", _item.STT, _item.MS_DH_XUAT_PT, _item.MS_PT, _item.MS_DH_NHAP_PT, _item.ROW_ID_NHAP, _item.ROW_ID, _item.SO_LUONG_CTU, _item.SO_LUONG_THUC_XUAT, _item.DON_GIA, _item.NGOAI_TE, _item.TY_GIA, _item.TY_GIA_USD, _item.MS_VI_TRI, _item.MS_KHO);
                    
        //            sqlTrans.Commit();
        //            scon.Close();
        //        }
        //        catch (Exception e){ 
        //            sqlTrans.Rollback();
        //            scon.Close();
        //            return false;
        //        }

               
        //        //SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, "INTEGRATION_NHAP_KHO_UPDATE", _item.STT, _item.MS_DH_NHAP_PT, _item.SO_PHIEU_XN, _item.GIO, _item.ROW_ID, _item.NGAY,
        //        //    _item.MS_KHO, _item.MS_VI_TRI, _item.MS_PT, _item.SO_LUONG_CTU,
        //        //    _item.SL_THUC_NHAP, _item.DON_GIA, _item.THANH_TIEN, _item.MS_DANG_NHAP,
        //        //    _item.DANG_NHAP_VIET, _item.NGUOI_NHAP, _item.NGAY_CHUNG_TU, _item.SO_CHUNG_TU,
        //        //    _item.GHI_CHU, _item.THU_KHO, _item.MS_DDH, _item.SO_DE_XUAT, _item.NGUOI_GIAO, _item.LY_DO, _item.CAN_CU, _item.THU_KHO_KY, _item.NGUOI_LAP, _item.BAO_HANH_DEN_NGAY,
        //        //    _item.XUAT_XU, _item.TAX, _item.MS_KH, _item.TEN_VI_TRI_1, _item.TEN_VI_TRI_2, _item.TEN_VI_TRI_3,
        //        //    _item.INSERT_DATE, _item.UPDATE_DATE, _item.DA_CHUYEN, _item.NGAY_CHUYEN);
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //private bool UpdateToDBIntegration(string STT)
        //{
        //    try
        //    {
        //        SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, CommandType.Text, "UPDATE TB_PHIEU_XUAT SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
        //    }
        //    catch { }
        //    return true;
        //}
   

    }
    //public class XUAT_KHO
    //{
    //    public XUAT_KHO() { }
    //    public int STT { get; set; }
    //    public string MS_DH_XUAT_PT { get; set; }
    //    public string SO_PHIEU_XN { get; set; }
    //    public string GIO { get; set; }
    //    //
    //    public int ROW_ID_NHAP { get; set; }
    //    public int ROW_ID { get; set; }
    //    public string NGAY { get; set; }
    //    public string MS_KHO { get; set; }
    //    public string TEN_KHO { get; set; }
       
    //    public string MS_PT { get; set; }
    //    public float SO_LUONG_CTU { get; set; }
    //    public float SO_LUONG_THUC_XUAT { get; set; }
    //    public string MS_DH_NHAP_PT { get; set; }
    //    //public float THANH_TIEN { get; set; }
    //    public int MS_VI_TRI { get; set; }
    //    public string TEN_VI_TRI { get; set; }
    //    public string MS_MAY { get; set; }
    //    public int MS_DANG_XUAT { get; set; }
    //    public string DANG_XUAT_VIET { get; set; }
    //    public string NGUOI_NHAN { get; set; }
    //    public string NGAY_CHUNG_TU { get; set; }
    //    public string SO_CHUNG_TU { get; set; }
    //    public string MS_PHIEU_BAO_TRI { get; set; }
    //    public string GHI_CHU { get; set; }
    //    public string LY_DO_XUAT { get; set; }
    //    public string THU_KHO { get; set; }
    //    //public string MS_DDH { get; set; }
    //    public int MS_BP_CHIU_PHI { get; set; }
    //    public string NGUOI_LAP { get; set; }
       
    //    public string CAN_CU { get; set; }
    //    //public string THU_KHO_KY { get; set; }

    //    public float DON_GIA { get; set; }
    //    public string NGOAI_TE  { get; set; }
    //    public float TY_GIA { get; set; }
    //    public float TY_GIA_USD { get; set; }
    //    public string BAO_HANH_DEN_NGAY { get; set; }
    //    public string XUAT_XU { get; set; }
       
    //    public string INSERT_DATE { get; set; }
    //    public string UPDATE_DATE { get; set; }
    //    public bool DA_CHUYEN { get; set; }
    //    public string NGAY_CHUYEN { get; set; }
    //}
}
