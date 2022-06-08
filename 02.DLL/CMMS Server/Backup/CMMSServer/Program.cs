using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace CmmsServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool firstInstance;
                //using (Mutex mutex = new Mutex(true, "NuTiGiaLai", out firstInstance))
                using (Mutex mutex = new Mutex(true, "Mashj", out firstInstance))
                {
                    if (firstInstance)
                    {
                        Application.Run(new Form1());
                        //Application.Run(new frmThongTinServer());
                    }
                    //else MessageBox.Show("Ứng dụng đang chạy...", "zstar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
