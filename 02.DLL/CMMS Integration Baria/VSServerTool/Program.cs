using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System;
using System.Windows.Forms;
using System.Threading;


namespace VSServerTool
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //

            //string sss = System.IO.Path.g
            ServicesToRun = new ServiceBase[] { new VSServices() };
            
            ServiceBase.Run(ServicesToRun);
            
        }

        //public Thread m_thread;
        //public ManualResetEvent m_shutdownEvent;
        //public TimeSpan m_delay;
        public static void ServiceMain()
        {
            
        }
    }
}
