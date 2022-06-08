using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CMMSIntegrationLib.Integration;

namespace CMMSIntegrationLib.CMMS
{
    public class cmms_NhapTra_to_Integration
    {
        public cmms_NhapTra_to_Integration()
        {

        }

        private DataTable EquitmentTransfer = new DataTable();
        private void GetDataTransfer()
        {
            try
            {
                EquitmentTransfer = new DataTable();
                string _sqlExec = "SELECT [STT],[MS_DH_XUAT_PT],[SO_PHIEU_XN],ISNULL(CONVERT(NVARCHAR(30), GIO, 121), '') AS GIO, " +
                    " ISNULL([ROW_ID_NHAP],0) AS ROW_ID_NHAP ,ISNULL(ROW_ID,0) AS ROW_ID,ISNULL(CONVERT(NVARCHAR(30), NGAY, 121), '') AS NGAY, " +
                    " [MS_KHO],[TEN_KHO],[MS_PT], ISNULL(SO_LUONG_CTU, 0) AS SO_LUONG_CTU, ISNULL(SO_LUONG_THUC_TRA, 0) AS [SO_LUONG_THUC_TRA], " +
                    " [MS_DH_NHAP_PT], ISNULL(MS_VI_TRI,0) AS MS_VI_TRI,[TEN_VI_TRI],[MS_MAY],[MS_DANG_XUAT],[DANG_XUAT_VIET], " +
                    " [NGUOI_NHAN],ISNULL(CONVERT(NVARCHAR(30), NGAY_CHUNG_TU, 121), '') AS NGAY_CHUNG_TU,[SO_CHUNG_TU],[MS_PHIEU_BAO_TRI],[GHI_CHU],[LY_DO_XUAT],[THU_KHO],[MS_BP_CHIU_PHI],[NGUOI_LAP], " +
                    " [CAN_CU],[DON_GIA],[NGOAI_TE],[TY_GIA],CONVERT(FLOAT,'5.72E-05') AS TY_GIA_USD,ISNULL(CONVERT(NVARCHAR(30), BAO_HANH_DEN_NGAY, 121), '') AS BAO_HANH_DEN_NGAY,[XUAT_XU],[INSERT_DATE],[STT_SYN_XK] " +
                    " FROM [SYN_TB_TRA_KHO_CMMS] WHERE ISNULL(DA_CHUYEN,CONVERT(BIT,0)) = CONVERT(BIT, 0)  " +
                    " ORDER BY STT";
                EquitmentTransfer.Load(SqlHelper.ExecuteReader(cmms_common.cmms_connection, CommandType.Text, _sqlExec));
            }
            catch { }
        }
        public string ExecSynchronizeToDBIntegration()
        {
            try
            {
                GetDataTransfer();
                if (EquitmentTransfer.Rows.Count > 0)
                {
                    foreach (DataRow _rowtransfer in EquitmentTransfer.Rows)
                    {
                        if (UpdateToDBIntegration(int.Parse(_rowtransfer["STT"].ToString()),
                                _rowtransfer["MS_DH_XUAT_PT"].ToString(), _rowtransfer["SO_PHIEU_XN"].ToString(),
                                _rowtransfer["GIO"].ToString(),int.Parse(_rowtransfer["ROW_ID_NHAP"].ToString()),
                                int.Parse(_rowtransfer["ROW_ID"].ToString()),_rowtransfer["NGAY"].ToString(),
                                _rowtransfer["MS_KHO"].ToString(),_rowtransfer["TEN_KHO"].ToString(),
                                _rowtransfer["MS_PT"].ToString(),double.Parse(_rowtransfer["SO_LUONG_CTU"].ToString()),
                                double.Parse(_rowtransfer["SO_LUONG_THUC_TRA"].ToString()),_rowtransfer["MS_DH_NHAP_PT"].ToString(),
                                int.Parse(_rowtransfer["MS_VI_TRI"].ToString()),_rowtransfer["TEN_VI_TRI"].ToString(),
                                _rowtransfer["MS_MAY"].ToString(),int.Parse(_rowtransfer["MS_DANG_XUAT"].ToString()),
                                _rowtransfer["DANG_XUAT_VIET"].ToString(),_rowtransfer["NGUOI_NHAN"].ToString(),
                                _rowtransfer["NGAY_CHUNG_TU"].ToString(),_rowtransfer["SO_CHUNG_TU"].ToString(),
                                _rowtransfer["MS_PHIEU_BAO_TRI"].ToString(),_rowtransfer["GHI_CHU"].ToString(),
                                _rowtransfer["LY_DO_XUAT"].ToString(),_rowtransfer["THU_KHO"].ToString(),
                                int.Parse(_rowtransfer["MS_BP_CHIU_PHI"].ToString()),_rowtransfer["NGUOI_LAP"].ToString(),
                                _rowtransfer["CAN_CU"].ToString(),double.Parse(_rowtransfer["DON_GIA"].ToString()),
                                _rowtransfer["NGOAI_TE"].ToString(),double.Parse(_rowtransfer["TY_GIA"].ToString()),
                                double.Parse(_rowtransfer["TY_GIA_USD"].ToString()),_rowtransfer["BAO_HANH_DEN_NGAY"].ToString(),
                                _rowtransfer["XUAT_XU"].ToString(),int.Parse(_rowtransfer["STT_SYN_XK"].ToString()) ))
                            UpdateToDBCMMS(int.Parse(_rowtransfer["STT"].ToString()));
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



        private bool UpdateToDBIntegration(int _STT_SYN_TRA, string _MS_DH_XUAT_PT, string _SO_PHIEU_XN, string _GIO, int _ROW_ID_NHAP, int _ROW_ID, string _NGAY,
                    string _MS_KHO,string _TEN_KHO,string _MS_PT, double _SO_LUONG_CTU,double _SO_LUONG_THUC_TRA,string _MS_DH_NHAP_PT,
                    int _MS_VI_TRI,string _TEN_VI_TRI,string _MS_MAY, int _MS_DANG_XUAT,string _DANG_XUAT_VIET,string _NGUOI_NHAN,
                    string _NGAY_CHUNG_TU,string _SO_CHUNG_TU,string _MS_PHIEU_BAO_TRI, string _GHI_CHU,string _LY_DO_XUAT,
                    string _THU_KHO,int _MS_BP_CHIU_PHI,string _NGUOI_LAP,string _CAN_CU, double _DON_GIA,string _NGOAI_TE,
                    double _TY_GIA,double _TY_GIA_USD,string _BAO_HANH_DEN_NGAY,string _XUAT_XU,int _STT_SYN_XK)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(integrate_common.cmms_connection, "IT_PROC_INSERT_TB_TRA_KHO",_STT_SYN_TRA, _MS_DH_XUAT_PT,
                        _SO_PHIEU_XN, _GIO, _ROW_ID_NHAP, _ROW_ID, _NGAY, _MS_KHO, _TEN_KHO, _MS_PT,
                        _SO_LUONG_CTU, _SO_LUONG_THUC_TRA, _MS_DH_NHAP_PT, _MS_VI_TRI, _TEN_VI_TRI, _MS_MAY,
                        _MS_DANG_XUAT, _DANG_XUAT_VIET, _NGUOI_NHAN, _NGAY_CHUNG_TU, _SO_CHUNG_TU, _MS_PHIEU_BAO_TRI,
                        _GHI_CHU, _LY_DO_XUAT, _THU_KHO, _MS_BP_CHIU_PHI, _NGUOI_LAP, _CAN_CU,
                        _DON_GIA, _NGOAI_TE, _TY_GIA, _TY_GIA_USD, _BAO_HANH_DEN_NGAY, _XUAT_XU, _STT_SYN_XK);
            }
            catch { return false; }

            return true;
        }
        private bool UpdateToDBCMMS(int STT)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cmms_common.cmms_connection, CommandType.Text, "UPDATE SYN_TB_TRA_KHO_CMMS SET DA_CHUYEN  = CONVERT(BIT,1) , NGAY_CHUYEN = GETDATE() WHERE STT = '" + STT.ToString() + "'");
            }
            catch {}
            return true;
        }

    }
}


