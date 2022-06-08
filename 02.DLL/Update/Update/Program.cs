using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace Update
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string URL_UPDATE = "";// "https://www.dropbox.com/s/l9rrp5m9gfjxn5q/Update.zip?dl=0";// "https://www.dropbox.com/s/2barc7vcp6pg3um/Update.zip?dl=0";// "https://www.dropbox.com/s/n051eeswfwz12o4/Update.zip?dl=0";
        public static string URL_VERSION = "";// "https://www.dropbox.com/s/xkkzmi9921rbafs/Version.txt?dl=0";// "https://www.dropbox.com/s/17mgwsymm56g9us/Version.txt?dl=0";//"https://www.dropbox.com/s/srzbu12hnahlr18/Version.txt?dl=0";
        public static int UpdateType = 0;
        public static string URL_LAN = "";// @"\\192.168.2.22\Update"; //@"\\192.168.2.22\Update";
        public static string FILE_DELETE = "";
        public static Boolean NOCHECK = false;
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
               
                if (args.Length > 2)
                {
                    UpdateType = Convert.ToInt32(args[0].ToString());
                    URL_UPDATE = args[1].ToString();
                    URL_VERSION = args[2].ToString();
                    URL_LAN = args[3].ToString();
                    NOCHECK = Convert.ToBoolean(args[4].ToString());
                }

                URL_VERSION = URL_VERSION.Replace("?dl=0", "?dl=1");
                URL_UPDATE = URL_UPDATE.Replace("?dl=0", "?dl=1");

            }
            catch (Exception)
            {


            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (UpdateType == 2)
                {
                    if (CheckForInternetConnection() == true)
                    {
                        Application.Run(new FRM_UPDATE());
                    }
                    else
                    {
                        if (Program.URL_LAN != null)
                        {
                            if (CheckNetworkPath(Program.URL_LAN) == true)
                            {
                                Application.Run(new FRM_UPDATE_LAN());
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
                            Application.Run(new FRM_UPDATE_LAN());
                        }

                    }
                    else
                    {
                        if (CheckForInternetConnection() == true)
                        {
                            Application.Run(new FRM_UPDATE());
                        }
                    }
                }
                else if (UpdateType == 0)
                {
                    Application.ExitThread();
                    Application.Exit();
                }

            }
            catch (Exception)
            {


            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("https://www.dropbox.com/home"))
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
