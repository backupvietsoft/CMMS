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
            //cmms_data_generate.UpdateDataSynInfo();

            //return;

            //integrate_DVT_to_CMMS cmmsDVT = new integrate_DVT_to_CMMS();
            //cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();

            //integrate_PhuTung_to_CMMS cmmsPHU_TUNG = new integrate_PhuTung_to_CMMS();
            //cmmsPHU_TUNG.ExecSynchronizeIC_Phu_Tung_To_DBCMMS();

            //integrate_Khach_Hang_to_CMMS cmmsKHACH_HANG = new integrate_Khach_Hang_to_CMMS();
            //cmmsKHACH_HANG.ExecSynchronizeKHACH_HANG_To_DBCMMS();

            //integrate_KHO_to_CMMS cmmsKHO = new integrate_KHO_to_CMMS();
            //cmmsKHO.ExecSynchronizeIC_Kho_To_DBCMMS();

            //integrate_TO_PHONG_BAN_to_CMMS cmmsTO_PHONG_BAN = new integrate_TO_PHONG_BAN_to_CMMS();
            //cmmsTO_PHONG_BAN.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS();


            //integrate_LY_DO_XUAT_KT_to_CMMS cmmsLY_DO_XUAT_KT = new integrate_LY_DO_XUAT_KT_to_CMMS();
            //cmmsLY_DO_XUAT_KT.ExecSynchronizeLY_DO_XUAT_KT_To_DBCMMS();
            
            //integrate_Dang_Nhap_to_CMMS cmmsDANG_NHAP = new integrate_Dang_Nhap_to_CMMS();
            //cmmsDANG_NHAP.ExecSynchronizeDANG_NHAP_To_DBCMMS();

            //integrate_Dang_Xuat_to_CMMS cmmsDANG_XUAT = new integrate_Dang_Xuat_to_CMMS();
            //cmmsDANG_XUAT.ExecSynchronizeDANG_XUAT_To_DBCMMS();

            //integrate_Nhap_Kho_to_CMMS cmmsNHAPKHO = new integrate_Nhap_Kho_to_CMMS();
            //cmmsNHAPKHO.ExecSynchronizeNHAP_KHO_To_DBCMMS();

            //integrate_Nhap_Kho_End_CMMS cmmsNHAPKHOXULY = new integrate_Nhap_Kho_End_CMMS();
            //cmmsNHAPKHOXULY.ExecSynchronizeNHAP_KHO_To_DBCMMS();


            //integrate_Xuat_Kho_to_CMMS cmmsXUATKHO = new integrate_Xuat_Kho_to_CMMS();
            //cmmsXUATKHO.ExecSynchronizeXUAT_KHO_To_DBCMMS();

            //integrate_Xuat_Kho_End_to_CMMS cmmsXUATKHOXULY = new integrate_Xuat_Kho_End_to_CMMS();
            //cmmsXUATKHOXULY.ExecSynchronizeXUAT_KHO_To_DBCMMS();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmms_data_generate.generateScriptToCMMSData();

            cmms_data_generate.generateScriptToCMMSData();
            cmms_data_generate.UpdateDataSynInfo();
            integrate_data_generate.generateScriptToCMMSData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmms_NhapTra_to_Integration cmmsNhapTra = new cmms_NhapTra_to_Integration();
            cmmsNhapTra.ExecSynchronizeToDBIntegration();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmms_Equipments_to_Integration cmmstointe = new cmms_Equipments_to_Integration();
            cmmstointe.ExecSynchronizeToDBIntegration();

            cmms_NhapTra_to_Integration cmmsNhapTra = new cmms_NhapTra_to_Integration();
            cmmsNhapTra.ExecSynchronizeToDBIntegration();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            integrate_Nhap_Kho_to_CMMS cmmsNHAPKHO = new integrate_Nhap_Kho_to_CMMS();
            cmmsNHAPKHO.ExecSynchronizeNHAP_KHO_To_DBCMMS();

            integrate_Nhap_Kho_End_CMMS cmmsNHAPKHOXULY = new integrate_Nhap_Kho_End_CMMS();
            cmmsNHAPKHOXULY.ExecSynchronizeNHAP_KHO_To_DBCMMS();

            integrate_Xuat_Kho_to_CMMS cmmsXUATKHO = new integrate_Xuat_Kho_to_CMMS();
            cmmsXUATKHO.ExecSynchronizeXUAT_KHO_To_DBCMMS();

            integrate_Xuat_Kho_End_to_CMMS cmmsXUATKHOXULY = new integrate_Xuat_Kho_End_to_CMMS();
            cmmsXUATKHOXULY.ExecSynchronizeXUAT_KHO_To_DBCMMS();
        }

        
    }
}
