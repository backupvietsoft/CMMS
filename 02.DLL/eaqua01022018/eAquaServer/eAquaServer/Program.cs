using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eAquaServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            if (IsAlreadyRunning())
            {
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }


        }
        private static bool IsAlreadyRunning()
        {
            System.Diagnostics.Process[] ieProcs = System.Diagnostics.Process.GetProcessesByName("eAquaServer");

            if (ieProcs.Length > 1)
                return true;
            else
                return false;
        }
    }
}
