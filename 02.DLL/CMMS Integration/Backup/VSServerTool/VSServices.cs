using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.IO;
using System.Threading;
using CMMSIntegrationLib.CMMS;
using CMMSIntegrationLib.Integration;
using CMMSIntegrationLib.Common;

namespace VSServerTool
{
    public class VSServices : ServiceBase
    {

    
        public VSServices()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.ServiceName = "VSServerTool";

        }
        private static System.Timers.Timer aTimer;
        private int timeRunningCmms_to_Inte = 0;
        private int timeRunningInte_to_Cmms = 0;

        Thread threadCmms_to_inte;

        Thread threadInte_to_Cmms;

         public void DoWorkToIntegration()
         {
             while (true)
             {
                 if (cmmsScheduler._SType == "1")
                 {
                     VSIntegrateWork();
                     this.EventLog.WriteEntry("Dang lam viec theo option 1 VSIntegrateWork ");
                     if (cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte > 0)
                     {
                         Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte);
                         timeRunningCmms_to_Inte = 0;
                     }
                 }
                 if (cmmsScheduler._SType == "2")
                 {
                     if (cmmsScheduler._SType2Hours == DateTime.Now.ToString("HH", System.Globalization.CultureInfo.CurrentCulture) && cmmsScheduler._SType2Minutes == DateTime.Now.ToString("mm", System.Globalization.CultureInfo.CurrentCulture))
                     {
                         VSIntegrateWork();
                         this.EventLog.WriteEntry("Dang lam viec theo option 2 VSIntegrateWork ");
                         if (cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte > 0)
                         {
                             Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte);
                             timeRunningCmms_to_Inte = 0;
                         }
                     }
                 }
             }
         }

         public void DoWorkIntegrationToCMMS()
         {
             while (true)
             {
                 if (cmmsScheduler._SType == "1")
                 {
                     VSIntegrateWorkToCMMS();
                     this.EventLog.WriteEntry("Dang lam viec theo option 1 tu Inte to cmms VSIntegrateWorkToCMMS");
                     if (cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms > 0)
                     {
                         Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms);
                         timeRunningInte_to_Cmms = 0;
                     }
                 }
                 if (cmmsScheduler._SType == "2")
                 {
                     if (cmmsScheduler._SType2Hours == DateTime.Now.ToString("HH", System.Globalization.CultureInfo.CurrentCulture) && cmmsScheduler._SType2Minutes == DateTime.Now.ToString("mm", System.Globalization.CultureInfo.CurrentCulture))
                     {
                         VSIntegrateWorkToCMMS();
                         this.EventLog.WriteEntry("Dang lam viec theo option 2 tu Inte to cmms VSIntegrateWorkToCMMS");
                         if (cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms > 0)
                         {
                             Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms);
                             timeRunningInte_to_Cmms = 0;
                         }
                     }
                 }
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

         protected override void OnStart(string[] args)
         {
             base.OnStart(args);
             if (!tryToConnect())
             {
                 this.Stop();
             }
             try
             {
                 cmms_data_generate.generateScriptToCMMSData();
                 cmms_data_generate.UpdateDataSynInfo();
                 integrate_data_generate.generateScriptToCMMSData();

                 aTimer = new System.Timers.Timer();
                 aTimer.Interval = 1000;
                 aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
                 aTimer.Enabled = true;
                 this.EventLog.WriteEntry("Schedule " + cmmsScheduler._SType + " BD" + cmms_common.cmms_connection + "Inte" + integrate_common.cmms_connection);

                 threadCmms_to_inte = new Thread(this.DoWorkToIntegration);
                 threadCmms_to_inte.Start();

                 threadInte_to_Cmms = new Thread(this.DoWorkIntegrationToCMMS);
                 threadInte_to_Cmms.Start();
             }
             catch { }
         }

         void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
         {
             if (timeRunningCmms_to_Inte == cmmsScheduler.TimeRunning)
                 timeRunningCmms_to_Inte = 0;
             else
                 timeRunningCmms_to_Inte++;

             if (timeRunningInte_to_Cmms == cmmsScheduler.TimeRunning)
                 timeRunningInte_to_Cmms = 0;
             else
                 timeRunningInte_to_Cmms++;
         }

         protected override void OnStop()
         {
             // TODO: Add code here to perform any tear-down necessary to stop your service.
             //frm.Close();
             base.OnStop();
             try
             {
                 aTimer.Enabled = false;
                 this.EventLog.WriteEntry("Ho Ho");
                 threadCmms_to_inte.Abort();
                 threadInte_to_Cmms.Abort();
             }
             catch { }
                         
         }

    }
}
