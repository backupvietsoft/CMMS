using Microsoft.VisualBasic;
using System;
using System.Management;

namespace ApiHardWare
{
    public static class Commons
    {
        public static String GetProcessorId()
        {
            //ManagementClass mc = new ManagementClass("win32_processor");
            //ManagementObjectCollection moc = mc.GetInstances();
            //foreach (ManagementObject mo in moc)
            //{
            //    Id = mo.Properties["SerialNumber"].Value.ToString();
            //    break;
            //}
            String Id = String.Empty;
            System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
            {
                Id = wmi_HD["SerialNumber"].ToString();
            }
            return Id.Trim();
        }
        public static string GiaiMaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
                sTam += Strings.ChrW((Strings.AscW(Strings.Mid(str, i, 1)) / 2) - 354).ToString();
            return sTam;
        }
    }




}