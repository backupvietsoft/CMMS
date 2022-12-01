using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Update
{

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string URL_UPDATE = "https://www.dropbox.com/s/dczzc802ht7c8nz/Update.zip?dl=0";
        public static string URL_VERSION = "https://www.dropbox.com/s/d43u0654cr26tdx/Version.txt?dl=0";
        public static int UpdateType = 2;
        public static string URL_LAN = @"\\192.168.2.5\Public\TruongCongHuong\Update";//@"\\192.168.2.22\Update";
        public static string sProcess = @"VS_HRM";

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 3)
            {
                UpdateType = Convert.ToInt32(args[0].ToString());
                URL_UPDATE = args[1].ToString();
                URL_VERSION = args[2].ToString();
                URL_LAN = args[3].ToString();
                try
                {sProcess = args[4].ToString();}catch { sProcess = @"CMMS"; }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (UpdateType == 2)
                {
                    if (CheckForInternetConnection() == true)
                    {
                        Application.Run(new FRM_INTERNET());
                    }
                    else
                    {
                        if (Program.URL_LAN != null)
                        {
                            if (CheckNetworkPath(Program.URL_LAN) == true)
                            {
                                Application.Run(new FRM_SHAREFOLDER());
                            }

                        }

                    }

                }
                else if (UpdateType == 1)
                {
                    if (Program.URL_LAN != null)
                    {
                        if (CheckNetworkPath(Program.URL_LAN) == true)
                        {
                            Application.Run(new FRM_SHAREFOLDER());
                        }

                    }
                    else
                    {
                        if (CheckForInternetConnection() == true)
                        {
                            Application.Run(new FRM_INTERNET());
                        }
                    }
                }
                else if (UpdateType == 0)
                {
                    Application.ExitThread();
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {}

        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("https://www.google.com/?hl=vi"))
                {
                    return true;
                }
            }
            catch
            {
                //MessageBox.Show("Không thể kết nối tới máy chủ cập nhật!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }
        [DllImport("WININET", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(ref int lpdwFlags, int dwReserved);

        public static bool Connected
        {
            get
            {
                int flags = 0;
                return InternetGetConnectedState(ref flags, 0);
            }
        }
        public static bool CheckNetworkPath(string path)
        {
            try
            {
                if (new Uri(path, UriKind.Absolute).IsUnc && !Connected)
                    return false;
                return System.IO.Directory.Exists(path);
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
