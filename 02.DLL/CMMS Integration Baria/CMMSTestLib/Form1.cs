using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMMSIntegrationLib.CMMS;
using CMMSIntegrationLib.Common;
using CMMSIntegrationLib.Integration;

namespace CMMSTestLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool tryToConnect()
        {
            if (!cmms_common.GetDBInfo())
                return false;
            if (!integrate_common.GetDBInfo())
                return false;
            if (!cmmsScheduler.GetRunTimeInfo())
                return false;
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool connect =   tryToConnect();
            if (connect == false)
                MessageBox.Show("Connect Fail");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmms_data_generate.UpdateDataSynInfo();


            //return;
            #region 01 Don Vi Tinh
            //integrate01_DVT_to_CMMS cmmsDVT = new integrate01_DVT_to_CMMS();
            //cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();
            #endregion

            #region 02 Khach Hang
            //integrate02_KH_to_CMMS cmmsKH = new integrate02_KH_to_CMMS();
            //cmmsKH.ExecSynchronizeKH_To_DBCMMS();
            #endregion

            #region 03 Hang San Xuat
            //integrate03_HANG_SAN_XUAT_to_CMMS cmmsHSX = new integrate03_HANG_SAN_XUAT_to_CMMS();
            //cmmsHSX.ExecSynchronizeHANG_SAN_XUAT_To_DBCMMS();
            #endregion

            #region 04 Loai Vat tu
            integrate04_LOAI_VAT_TU_to_CMMS cmmsLVtu = new integrate04_LOAI_VAT_TU_to_CMMS();
            cmmsLVtu.ExecSynchronizeLOAI_VT_To_DBCMMS();
            #endregion

            #region 05 Ic Phu Tung
            //integrate05_IC_PHU_TUNG_to_CMMS cmmsICPTung = new integrate05_IC_PHU_TUNG_to_CMMS();
            //MessageBox.Show(cmmsICPTung.ExecSynchronizeIC_PHU_TUNG_To_DBCMMS());
            #endregion

            #region 06 Bo phan chiu phi
            //integrate06_BO_PHAN_CHIU_PHI_to_CMMS cmmsBPCP = new integrate06_BO_PHAN_CHIU_PHI_to_CMMS();
            //MessageBox.Show(cmmsBPCP.ExecSynchronizeBO_PHAN_CHIU_PHI_To_DBCMMS());
            #endregion

            #region 07 Nhom + Loai May
            //integrate07_NHOM_MAY_to_CMMS cmmsLMay = new integrate07_NHOM_MAY_to_CMMS();
            //MessageBox.Show(cmmsLMay.ExecSynchronizeLOAI_MAY_To_DBCMMS());

            //integrate07_NHOM_MAY_to_CMMS cmmsNMay = new integrate07_NHOM_MAY_to_CMMS();
            //MessageBox.Show(cmmsNMay.ExecSynchronizeNHOM_MAY_To_DBCMMS());


            #endregion

            #region 08 May
            //integrate08_MAY_to_CMMS cmmsMay = new integrate08_MAY_to_CMMS();
            //MessageBox.Show(cmmsMay.ExecSynchronizeMAY_To_DBCMMS());
            #endregion

            #region 09 to phong ban
            //integrate09_TO_PHONG_BAN_to_CMMS cmmsToPB = new integrate09_TO_PHONG_BAN_to_CMMS();
            //MessageBox.Show(cmmsToPB.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS());
            #endregion

            #region 10 Cong nhan
            //integrate10_CONG_NHAN_to_CMMS cmmsCNhan = new integrate10_CONG_NHAN_to_CMMS();
            //MessageBox.Show(cmmsCNhan.ExecSynchronizeCONG_NHAN_To_DBCMMS());
            #endregion

            #region 11 IC Kho
            //integrate11_IC_KHO_to_CMMS cmmsICKho = new integrate11_IC_KHO_to_CMMS();
            //MessageBox.Show(cmmsICKho.ExecSynchronizeIC_KHO_To_DBCMMS());
            #endregion

            #region 12 GL Acount
            //integrate12_TB_GL_ACCOUNT_to_CMMS cmmsGLAcount = new integrate12_TB_GL_ACCOUNT_to_CMMS();
            //MessageBox.Show(cmmsGLAcount.ExecSynchronizeGL_ACCOUNT_To_DBCMMS());
            #endregion

            #region 13 Tinh Gia Lai
            //integrate13_TINH_GIA_LAI_to_CMMS cmmsTinhGiaLai = new integrate13_TINH_GIA_LAI_to_CMMS();
            //MessageBox.Show(cmmsTinhGiaLai.ExecSynchronizeTINH_GIA_LAI_To_DBCMMS());
            #endregion

            #region 14 Xuat kho
            integrate14_XuatKho_to_CMMS cmmsXKho = new integrate14_XuatKho_to_CMMS();
            MessageBox.Show(cmmsXKho.ExecSynchronizeXuatKho_To_DBCMMS());
            #endregion

            #region 15 Xuat kho end
            integrate15_XuatKho_End_CMMS cmmsXKhoEnd = new integrate15_XuatKho_End_CMMS();
            MessageBox.Show(cmmsXKhoEnd.ExecSynchronizeXUAT_KHO_To_DBCMMS());
            #endregion

            #region 16 cmmsNAV_REQUEST_SERVICE
            //integrate16_REQUEST_SERVICE_to_CMMS cmmsNAV_REQUEST_SERVICE = new integrate16_REQUEST_SERVICE_to_CMMS();
            //MessageBox.Show(cmmsNAV_REQUEST_SERVICE.ExecSynchronizeNAV_REQUEST_SERVICE_To_DBCMMS());
            #endregion

            #region 17 cmmsNAV_REQUEST_SERVICE End
            //integrate17_REQUEST_SERVICE_End_CMMS cmmsNAV_REQUEST_SERVICEEnd = new integrate17_REQUEST_SERVICE_End_CMMS();
            //MessageBox.Show(cmmsNAV_REQUEST_SERVICEEnd.ExecSynchronizeREQUEST_SERVICE_To_DBCMMS());
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmms_data_generate.UpdateDataSynInfo();


            //return;
            #region 01 Don Vi Tinh
            integrate01_DVT_to_CMMS cmmsDVT = new integrate01_DVT_to_CMMS();
            cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();
            #endregion

            #region 02 Khach Hang
            integrate02_KH_to_CMMS cmmsKH = new integrate02_KH_to_CMMS();
            cmmsKH.ExecSynchronizeKH_To_DBCMMS();
            #endregion

            #region 03 Hang San Xuat
            integrate03_HANG_SAN_XUAT_to_CMMS cmmsHSX = new integrate03_HANG_SAN_XUAT_to_CMMS();
            cmmsHSX.ExecSynchronizeHANG_SAN_XUAT_To_DBCMMS();
            #endregion

            #region 04 Loai Vat tu
            integrate04_LOAI_VAT_TU_to_CMMS cmmsLVtu = new integrate04_LOAI_VAT_TU_to_CMMS();
            cmmsLVtu.ExecSynchronizeLOAI_VT_To_DBCMMS();
            #endregion

            #region 05 Ic Phu Tung
            integrate05_IC_PHU_TUNG_to_CMMS cmmsICPTung = new integrate05_IC_PHU_TUNG_to_CMMS();
            MessageBox.Show(cmmsICPTung.ExecSynchronizeIC_PHU_TUNG_To_DBCMMS());
            #endregion

            #region 06 Bo phan chiu phi
            integrate06_BO_PHAN_CHIU_PHI_to_CMMS cmmsBPCP = new integrate06_BO_PHAN_CHIU_PHI_to_CMMS();
            MessageBox.Show(cmmsBPCP.ExecSynchronizeBO_PHAN_CHIU_PHI_To_DBCMMS());
            #endregion

            #region 07 Nhom + Loai May
            integrate07_NHOM_MAY_to_CMMS cmmsLMay = new integrate07_NHOM_MAY_to_CMMS();
            MessageBox.Show(cmmsLMay.ExecSynchronizeLOAI_MAY_To_DBCMMS());

            integrate07_NHOM_MAY_to_CMMS cmmsNMay = new integrate07_NHOM_MAY_to_CMMS();
            MessageBox.Show(cmmsNMay.ExecSynchronizeNHOM_MAY_To_DBCMMS());


            #endregion

            #region 08 May
            integrate08_MAY_to_CMMS cmmsMay = new integrate08_MAY_to_CMMS();
            MessageBox.Show(cmmsMay.ExecSynchronizeMAY_To_DBCMMS());
            #endregion

            #region 09 to phong ban
            integrate09_TO_PHONG_BAN_to_CMMS cmmsToPB = new integrate09_TO_PHONG_BAN_to_CMMS();
            MessageBox.Show(cmmsToPB.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS());
            #endregion

            #region 10 Cong nhan
            integrate10_CONG_NHAN_to_CMMS cmmsCNhan = new integrate10_CONG_NHAN_to_CMMS();
            MessageBox.Show(cmmsCNhan.ExecSynchronizeCONG_NHAN_To_DBCMMS());
            #endregion

            #region 11 IC Kho
            integrate11_IC_KHO_to_CMMS cmmsICKho = new integrate11_IC_KHO_to_CMMS();
            MessageBox.Show(cmmsICKho.ExecSynchronizeIC_KHO_To_DBCMMS());
            #endregion

            #region 12 GL Acount
            integrate12_TB_GL_ACCOUNT_to_CMMS cmmsGLAcount = new integrate12_TB_GL_ACCOUNT_to_CMMS();
            MessageBox.Show(cmmsGLAcount.ExecSynchronizeGL_ACCOUNT_To_DBCMMS());
            #endregion

            #region 13 Tinh Gia Lai
            integrate13_TINH_GIA_LAI_to_CMMS cmmsTinhGiaLai = new integrate13_TINH_GIA_LAI_to_CMMS();
            MessageBox.Show(cmmsTinhGiaLai.ExecSynchronizeTINH_GIA_LAI_To_DBCMMS());
            #endregion

            #region 14 Xuat kho
            integrate14_XuatKho_to_CMMS cmmsXKho = new integrate14_XuatKho_to_CMMS();
            MessageBox.Show(cmmsXKho.ExecSynchronizeXuatKho_To_DBCMMS());
            #endregion

            #region 15 Xuat kho end
            integrate15_XuatKho_End_CMMS cmmsXKhoEnd = new integrate15_XuatKho_End_CMMS();
            MessageBox.Show(cmmsXKhoEnd.ExecSynchronizeXUAT_KHO_To_DBCMMS());
            #endregion

            #region 16 cmmsNAV_REQUEST_SERVICE
            integrate16_REQUEST_SERVICE_to_CMMS cmmsNAV_REQUEST_SERVICE = new integrate16_REQUEST_SERVICE_to_CMMS();
            MessageBox.Show(cmmsNAV_REQUEST_SERVICE.ExecSynchronizeNAV_REQUEST_SERVICE_To_DBCMMS());
            #endregion

            #region 17 cmmsNAV_REQUEST_SERVICE End
            integrate17_REQUEST_SERVICE_End_CMMS cmmsNAV_REQUEST_SERVICEEnd = new integrate17_REQUEST_SERVICE_End_CMMS();
            MessageBox.Show(cmmsNAV_REQUEST_SERVICEEnd.ExecSynchronizeREQUEST_SERVICE_To_DBCMMS());
            #endregion
        }



        private void button3_Click(object sender, EventArgs e)
        {
            integrate01_DVT_to_CMMS cmmsDVT = new integrate01_DVT_to_CMMS();
            cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmms_data_generate.UpdateDataSynInfo();


            #region 02 Khach Hang
            integrate02_KH_to_CMMS cmmsKH = new integrate02_KH_to_CMMS();
            cmmsKH.ExecSynchronizeKH_To_DBCMMS();
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region 14 Xuat kho
            integrate14_XuatKho_to_CMMS cmmsXKho = new integrate14_XuatKho_to_CMMS();
            MessageBox.Show(cmmsXKho.ExecSynchronizeXuatKho_To_DBCMMS());
            #endregion

            #region 15 Xuat kho end
            integrate15_XuatKho_End_CMMS cmmsXKhoEnd = new integrate15_XuatKho_End_CMMS();
            MessageBox.Show(cmmsXKhoEnd.ExecSynchronizeXUAT_KHO_To_DBCMMS());
            #endregion
        }
    }
}
