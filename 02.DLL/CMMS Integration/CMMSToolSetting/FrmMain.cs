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


namespace H2Tool
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
            catch
            {
                MessageBox.Show("Start không thành công");
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
            catch { }
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
            catch
            {
                MessageBox.Show("Stop không thành công");
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
        }

        private void btnCMMSDB_Click(object sender, EventArgs e)
        {
            frmDataCMMS frm = new frmDataCMMS();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }



        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (_btnStart.Enabled) return;
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
            cmms_Equipments_to_Integration cmmstointe = new cmms_Equipments_to_Integration();
            cmmstointe.ExecSynchronizeToDBIntegration();

            cmms_NhapTra_to_Integration cmmsNhapTra = new cmms_NhapTra_to_Integration();
            cmmsNhapTra.ExecSynchronizeToDBIntegration();

        }

        private void VSIntegrateWorkToCMMS()
        {
            // sap xep thu tu chay 
            integrate_DVT_to_CMMS cmmsDVT = new integrate_DVT_to_CMMS();
            cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();

            integrate_PhuTung_to_CMMS cmmsPHU_TUNG = new integrate_PhuTung_to_CMMS();
            cmmsPHU_TUNG.ExecSynchronizeIC_Phu_Tung_To_DBCMMS();

            integrate_Khach_Hang_to_CMMS cmmsKHACH_HANG = new integrate_Khach_Hang_to_CMMS();
            cmmsKHACH_HANG.ExecSynchronizeKHACH_HANG_To_DBCMMS();

            integrate_KHO_to_CMMS cmmsKHO = new integrate_KHO_to_CMMS();
            cmmsKHO.ExecSynchronizeIC_Kho_To_DBCMMS();

            integrate_TO_PHONG_BAN_to_CMMS cmmsTO_PHONG_BAN = new integrate_TO_PHONG_BAN_to_CMMS();
            cmmsTO_PHONG_BAN.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS();

            integrate_LY_DO_XUAT_KT_to_CMMS cmmsLY_DO_XUAT_KT = new integrate_LY_DO_XUAT_KT_to_CMMS();
            cmmsLY_DO_XUAT_KT.ExecSynchronizeLY_DO_XUAT_KT_To_DBCMMS();

            //integrate_Dang_Nhap_to_CMMS cmmsDANG_NHAP = new integrate_Dang_Nhap_to_CMMS();
            //cmmsDANG_NHAP.ExecSynchronizeDANG_NHAP_To_DBCMMS();

            //integrate_Dang_Xuat_to_CMMS cmmsDANG_XUAT = new integrate_Dang_Xuat_to_CMMS();
            //cmmsDANG_XUAT.ExecSynchronizeDANG_XUAT_To_DBCMMS();

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
