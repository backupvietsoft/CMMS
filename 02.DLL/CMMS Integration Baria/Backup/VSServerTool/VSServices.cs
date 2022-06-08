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

        //Thread threadCmms_to_inte;

        Thread threadInte_to_Cmms;

         //public void DoWorkToIntegration()
         //{
         //    while (true)
         //    {
         //        if (cmmsScheduler._SType == "1")
         //        {
         //            VSIntegrateWork();
         //            this.EventLog.WriteEntry("Dang lam viec theo option 1 VSIntegrateWork ");
         //            if (cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte > 0)
         //            {
         //                Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte);
         //                timeRunningCmms_to_Inte = 0;
         //            }
         //        }
         //        if (cmmsScheduler._SType == "2")
         //        {
         //            if (cmmsScheduler._SType2Hours == DateTime.Now.ToString("HH", System.Globalization.CultureInfo.CurrentCulture) && cmmsScheduler._SType2Minutes == DateTime.Now.ToString("mm", System.Globalization.CultureInfo.CurrentCulture))
         //            {
         //                VSIntegrateWork();
         //                this.EventLog.WriteEntry("Dang lam viec theo option 2 VSIntegrateWork ");
         //                if (cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte > 0)
         //                {
         //                    Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningCmms_to_Inte);
         //                    timeRunningCmms_to_Inte = 0;
         //                }
         //            }
         //        }
         //    }
         //}

         public void DoWorkIntegrationToCMMS()
         {
             while (true)
             {
                 if (cmmsScheduler._SType == "1")
                 {
                     VSIntegrateWorkToCMMS();
                     this.EventLog.WriteEntry("Run option 1 form Inte to cmms VSIntegrateWorkToCMMS");
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
                         this.EventLog.WriteEntry("Run option 2 form Inte to cmms VSIntegrateWorkToCMMS");
                         if (cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms > 0)
                         {
                             Thread.Sleep(cmmsScheduler.TimeRunning - timeRunningInte_to_Cmms);
                             timeRunningInte_to_Cmms = 0;
                         }
                     }
                 }
             }
         }

         //private void VSIntegrateWork()
         //{
         //    //cmms_Equipments_to_Integration cmmstointe = new cmms_Equipments_to_Integration();
         //    //cmmstointe.ExecSynchronizeToDBIntegration();

         //    //cmms_NhapTra_to_Integration cmmsNhapTra = new cmms_NhapTra_to_Integration();
         //    //cmmsNhapTra.ExecSynchronizeToDBIntegration();

             

         //}

         private void VSIntegrateWorkToCMMS()
         {
             string sLoi = "";
             // sap xep thu tu chay 
             sLoi = "";
             #region 01 Don Vi Tinh
             integrate01_DVT_to_CMMS cmmsDVT = new integrate01_DVT_to_CMMS();
             sLoi = cmmsDVT.ExecSynchronizeDON_VI_TINH_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("DON_VI_TINH - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 02 Khach Hang
             integrate02_KH_to_CMMS cmmsKH = new integrate02_KH_to_CMMS();
             sLoi = cmmsKH.ExecSynchronizeKH_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("KHACH_HANG - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 03 Hang San Xuat
             integrate03_HANG_SAN_XUAT_to_CMMS cmmsHSX = new integrate03_HANG_SAN_XUAT_to_CMMS();
             sLoi = cmmsHSX.ExecSynchronizeHANG_SAN_XUAT_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("HANG_SAN_XUAT - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 04 Loai Vat tu
             integrate04_LOAI_VAT_TU_to_CMMS cmmsLVtu = new integrate04_LOAI_VAT_TU_to_CMMS();
             sLoi = cmmsLVtu.ExecSynchronizeLOAI_VT_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("LOAI_VT - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 05 Ic Phu Tung
             integrate05_IC_PHU_TUNG_to_CMMS cmmsICPTung = new integrate05_IC_PHU_TUNG_to_CMMS();
             sLoi = cmmsICPTung.ExecSynchronizeIC_PHU_TUNG_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("IC_PHU_TUNG - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 06 Bo phan chiu phi
             integrate06_BO_PHAN_CHIU_PHI_to_CMMS cmmsBPCP = new integrate06_BO_PHAN_CHIU_PHI_to_CMMS();
             sLoi = cmmsBPCP.ExecSynchronizeBO_PHAN_CHIU_PHI_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("BO_PHAN_CHIU_PHI - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 07 Loai May + Nhom

             integrate07_NHOM_MAY_to_CMMS cmmsLMay = new integrate07_NHOM_MAY_to_CMMS();
             sLoi = cmmsLMay.ExecSynchronizeLOAI_MAY_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("LOAI_MAY - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";

             integrate07_NHOM_MAY_to_CMMS cmmsNMay = new integrate07_NHOM_MAY_to_CMMS();
             sLoi = cmmsNMay.ExecSynchronizeNHOM_MAY_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("NHOM_MAY - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";

             #endregion

             #region 08 May
             integrate08_MAY_to_CMMS cmmsMay = new integrate08_MAY_to_CMMS();
             sLoi = cmmsMay.ExecSynchronizeMAY_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("MAY - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 09 to phong ban
             integrate09_TO_PHONG_BAN_to_CMMS cmmsToPB = new integrate09_TO_PHONG_BAN_to_CMMS();
             sLoi = cmmsToPB.ExecSynchronizeTO_PHONG_BAN_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("TO_PHONG_BAN - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 10 Cong nhan
             integrate10_CONG_NHAN_to_CMMS cmmsCNhan = new integrate10_CONG_NHAN_to_CMMS();
             sLoi = cmmsCNhan.ExecSynchronizeCONG_NHAN_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("CONG_NHAN - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 11 IC Kho
             integrate11_IC_KHO_to_CMMS cmmsICKho = new integrate11_IC_KHO_to_CMMS();
             sLoi = cmmsICKho.ExecSynchronizeIC_KHO_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("IC_KHO - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 12 GL Acount
             integrate12_TB_GL_ACCOUNT_to_CMMS cmmsGLAcount = new integrate12_TB_GL_ACCOUNT_to_CMMS();
             sLoi = cmmsGLAcount.ExecSynchronizeGL_ACCOUNT_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("GL_ACCOUNT - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             //#region 13 Tinh Gia Lai
             //integrate13_TINH_GIA_LAI_to_CMMS cmmsTinhGiaLai = new integrate13_TINH_GIA_LAI_to_CMMS();
             //sLoi = cmmsTinhGiaLai.ExecSynchronizeTINH_GIA_LAI_To_DBCMMS();
             //if (sLoi != "")
             //    this.EventLog.WriteEntry("TINH_GIA_LAI - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             //sLoi = "";
             //#endregion

             #region 14 Xuat kho
             integrate14_XuatKho_to_CMMS cmmsXKho = new integrate14_XuatKho_to_CMMS();
             sLoi = cmmsXKho.ExecSynchronizeXuatKho_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("XuatKho - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 15 Xuat kho end
             integrate15_XuatKho_End_CMMS cmmsXKhoEnd = new integrate15_XuatKho_End_CMMS();
             sLoi = cmmsXKhoEnd.ExecSynchronizeXUAT_KHO_To_DBCMMS();
             if (sLoi != "")
                 this.EventLog.WriteEntry("XuatKhoCMMS - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             sLoi = "";
             #endregion

             #region 16 cmmsNAV_REQUEST_SERVICE
             //integrate16_REQUEST_SERVICE_to_CMMS cmmsNAV_REQUEST_SERVICE = new integrate16_REQUEST_SERVICE_to_CMMS();
             //sLoi = cmmsNAV_REQUEST_SERVICE.ExecSynchronizeNAV_REQUEST_SERVICE_To_DBCMMS();
             //if (sLoi != "")
             //    this.EventLog.WriteEntry("NAV_REQUEST_SERVICE - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             //sLoi = "";
             #endregion

             #region 17 cmmsNAV_REQUEST_SERVICE End
             //integrate17_REQUEST_SERVICE_End_CMMS cmmsNAV_REQUEST_SERVICEEnd = new integrate17_REQUEST_SERVICE_End_CMMS();
             //sLoi = cmmsNAV_REQUEST_SERVICEEnd.ExecSynchronizeREQUEST_SERVICE_To_DBCMMS();
             //if (sLoi != "")
             //    this.EventLog.WriteEntry("NAV_REQUEST_SERVICE_CMMS - " + sLoi, System.Diagnostics.EventLogEntryType.Error);
             //sLoi = "";
             #endregion
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

             try
             {
                 base.OnStart(args);
                 if (!tryToConnect())
                 {
                     this.Stop();
                 }
                 cmms_data_generate.generateScriptToCMMSData();
                 cmms_data_generate.UpdateDataSynInfo();
                 integrate_data_generate.generateScriptToCMMSData();

                 aTimer = new System.Timers.Timer();
                 aTimer.Interval = 1000;
                 aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
                 aTimer.Enabled = true;
                 this.EventLog.WriteEntry("Schedule " + cmmsScheduler._SType + " BD" + cmms_common.cmms_connection + "Inte" + integrate_common.cmms_connection);

                 //threadCmms_to_inte = new Thread(this.DoWorkToIntegration);
                 //threadCmms_to_inte.Start();

                 threadInte_to_Cmms = new Thread(this.DoWorkIntegrationToCMMS);
                 threadInte_to_Cmms.Start();
             }
             catch (Exception ex)
             {
                 this.EventLog.WriteEntry(ex.Message);
             }
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
                 this.EventLog.WriteEntry("Service Stop");
                 //threadCmms_to_inte.Abort();
                 threadInte_to_Cmms.Abort();
             }
             catch (Exception ex)
             {
                 this.EventLog.WriteEntry(ex.Message);
             }
                         
         }

    }
}
