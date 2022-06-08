using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.ServiceProcess;
using CMMSIntegrationLib.Integration;
using CMMSIntegrationLib.CMMS;
using CMMSIntegrationLib.Common;


namespace ServiceTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("VSServerTool");
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(20000);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);

                if (service.Status == ServiceControllerStatus.Running)
                {
                    _btnStart.Enabled = false;
                    _btnStop.Enabled = true;
                }
                else
                {
                    _btnStart.Enabled = true;
                    _btnStop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                service.Close();
                MessageBox.Show( ex.Message + "\n" + "Start không thành công");
            }
        }

        private void _btnPause_Click(object sender, EventArgs e)
        {

        }

        private static void StopService(ServiceController service, int timeout)
        {
            try
            {
                if (service.CanStop)
                {
                    Console.WriteLine("Stopping service '{0}' on '{1}' ...",
                        service.ServiceName, service.MachineName);

                    service.Stop();

                    if (int.MinValue != timeout)
                    {
                        TimeSpan t = TimeSpan.FromSeconds(timeout);
                        service.WaitForStatus(ServiceControllerStatus.Stopped, t);

                    }
                    else service.WaitForStatus(ServiceControllerStatus.Stopped);

                    Console.WriteLine("Stopped service '{0}' on '{1}'\r\n",
                        service.ServiceName, service.MachineName);

                }
                else
                {
                    Console.WriteLine("Can not stop service '{0}' on '{1}'",
                        service.ServiceName, service.MachineName);

                    Console.WriteLine("Service State '{0}'", service.Status.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Can not stop service '{0}' on '{1}'");
            
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {

            ServiceController service = new ServiceController("VSServerTool");
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    _btnStart.Enabled = false;
                    _btnStop.Enabled = true;
                }
                else
                {
                    _btnStart.Enabled = true;
                    _btnStop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Stop không thành công");
            }

        }

        private void LoadServerInfo()
        {
            DataTable vtb = new DataTable();
            vtb.Columns.Add("ServicesID", Type.GetType("System.String"));
            vtb.Columns.Add("ServicesName", Type.GetType("System.String"));

            vtb.Rows.Add("VSServerTool", "CMMS Integration Service");
            cbxServices.DataSource = vtb;
            cbxServices.DisplayMember = "ServicesName";
            cbxServices.ValueMember = "ServicesID";
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
            LoadServerInfo();
            try
            {
                ServiceController service = new ServiceController("VSServerTool");
                if (service.Status == ServiceControllerStatus.Running)
                {
                    _btnStart.Enabled = false;
                    _btnStop.Enabled = true;
                }
                else
                {
                    _btnStart.Enabled = true;
                    _btnStop.Enabled = false;
                }
            }
            catch { }

        }

        private void _btnSchedule_Click(object sender, EventArgs e)
        {
            frmScheduler frm = new frmScheduler();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnDBIntegrate_Click(object sender, EventArgs e)
        {
            frmConnectData frm = new frmConnectData();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            bool connect = tryToConnect();
            if (connect == false)
                MessageBox.Show("Connect Fail");
            else
                cmms_data_generate.UpdateDataSynInfo();

        }

        private void btnCMMSDB_Click(object sender, EventArgs e)
        {
            frmDataCMMS frm = new frmDataCMMS();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            bool connect = tryToConnect();
            if (connect == false)
                MessageBox.Show("Connect Fail");
            else
                cmms_data_generate.UpdateDataSynInfo();

        }



        private void label1_DoubleClick(object sender, EventArgs e)
        {

            bool connect = tryToConnect();
            if (connect == false)
                MessageBox.Show("Connect Fail");

            try
            {
                VSIntegrateWork();
                VSIntegrateWorkToCMMS();
                MessageBox.Show("Thuc hien thanh cong");
            }
            catch (Exception EX)
            {
                MessageBox.Show("Khong thanh cong" + EX.Message);
            }

        }

        private void VSIntegrateWork()
        {
            //cmms_Equipments_to_Integration cmmstointe = new cmms_Equipments_to_Integration();
            //cmmstointe.ExecSynchronizeToDBIntegration();

            //cmms_NhapTra_to_Integration cmmsNhapTra = new cmms_NhapTra_to_Integration();
            //cmmsNhapTra.ExecSynchronizeToDBIntegration();

        }

        private void VSIntegrateWorkToCMMS()
        {
            string sLoi = "";
            // sap xep thu tu chay 
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
            
            sLoi = "";
            #region 05 Ic Phu Tung
            integrate05_IC_PHU_TUNG_to_CMMS cmmsICPTung = new integrate05_IC_PHU_TUNG_to_CMMS();
            sLoi = cmmsICPTung.ExecSynchronizeIC_PHU_TUNG_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("IC_PHU_TUNG - " + sLoi);
            sLoi = "";
            #endregion

            #region 06 Bo phan chiu phi
            integrate06_BO_PHAN_CHIU_PHI_to_CMMS cmmsBPCP = new integrate06_BO_PHAN_CHIU_PHI_to_CMMS();
            sLoi = cmmsBPCP.ExecSynchronizeBO_PHAN_CHIU_PHI_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("BO_PHAN_CHIU_PHI - " + sLoi);
            sLoi = "";
            #endregion

            #region 07 Nhom + Loai May
            integrate07_NHOM_MAY_to_CMMS cmmsNMay = new integrate07_NHOM_MAY_to_CMMS();
            sLoi = cmmsNMay.ExecSynchronizeNHOM_MAY_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("NHOM_MAY - " + sLoi);
            sLoi = "";
            #endregion

            #region 08 May
            integrate08_MAY_to_CMMS cmmsMay = new integrate08_MAY_to_CMMS();
            sLoi = cmmsMay.ExecSynchronizeMAY_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("MAY - " + sLoi);
            sLoi = "";
            #endregion

            #region 09 to phong ban
            integrate09_TO_PHONG_BAN_to_CMMS cmmsToPB = new integrate09_TO_PHONG_BAN_to_CMMS();
            sLoi = cmmsToPB.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("TO_PHONG_BAN - " + sLoi);
            sLoi = "";
            #endregion

            #region 10 Cong nhan
            integrate10_CONG_NHAN_to_CMMS cmmsCNhan = new integrate10_CONG_NHAN_to_CMMS();
            sLoi = cmmsCNhan.ExecSynchronizeCONG_NHAN_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("CONG_NHAN - " + sLoi);
            sLoi = "";
            #endregion

            #region 11 IC Kho
            integrate11_IC_KHO_to_CMMS cmmsICKho = new integrate11_IC_KHO_to_CMMS();
            sLoi = cmmsICKho.ExecSynchronizeIC_KHO_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("IC_KHO - " + sLoi);
            sLoi = "";
            #endregion

            #region 12 GL Acount
            integrate12_TB_GL_ACCOUNT_to_CMMS cmmsGLAcount = new integrate12_TB_GL_ACCOUNT_to_CMMS();
            sLoi = cmmsGLAcount.ExecSynchronizeGL_ACCOUNT_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("GL_ACCOUNT - " + sLoi);
            sLoi = "";
            #endregion

            #region 13 Tinh Gia Lai
            integrate13_TINH_GIA_LAI_to_CMMS cmmsTinhGiaLai = new integrate13_TINH_GIA_LAI_to_CMMS();
            sLoi = cmmsTinhGiaLai.ExecSynchronizeTINH_GIA_LAI_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("TINH_GIA_LAI - " + sLoi);
            sLoi = "";
            #endregion

            #region 14 Xuat kho
            integrate14_XuatKho_to_CMMS cmmsXKho = new integrate14_XuatKho_to_CMMS();
            sLoi = cmmsXKho.ExecSynchronizeXuatKho_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("XuatKho - " + sLoi);
            sLoi = "";
            #endregion

            #region 15 Xuat kho end
            integrate15_XuatKho_End_CMMS cmmsXKhoEnd = new integrate15_XuatKho_End_CMMS();
            sLoi = cmmsXKhoEnd.ExecSynchronizeXUAT_KHO_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("XuatKhoCMMS - " + sLoi);
            sLoi = "";
            #endregion

            #region 16 cmmsNAV_REQUEST_SERVICE
            integrate16_REQUEST_SERVICE_to_CMMS cmmsNAV_REQUEST_SERVICE = new integrate16_REQUEST_SERVICE_to_CMMS();
            sLoi = cmmsNAV_REQUEST_SERVICE.ExecSynchronizeNAV_REQUEST_SERVICE_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("NAV_REQUEST_SERVICE - " + sLoi);
            sLoi = "";
            #endregion

            #region 17 cmmsNAV_REQUEST_SERVICE End
            integrate17_REQUEST_SERVICE_End_CMMS cmmsNAV_REQUEST_SERVICEEnd = new integrate17_REQUEST_SERVICE_End_CMMS();
            sLoi = cmmsNAV_REQUEST_SERVICEEnd.ExecSynchronizeREQUEST_SERVICE_To_DBCMMS();
            if (sLoi != "")
                MessageBox.Show("NAV_REQUEST_SERVICE_CMMS - " + sLoi);
            sLoi = "";
            #endregion
        }
    }
}
