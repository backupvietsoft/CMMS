using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using ServiceInstaller;
using System.ServiceProcess;

namespace VSServerTool
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : DynamicInstaller
    {

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 
            // ProjectInstaller
            // 
            this.ServiceName = "VSServerTool";
            this.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.ProjectInstaller_AfterInstall);

        }

        private void ProjectInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {
            //using (ServiceController sc = new ServiceController(this.ServiceName))
            //{
            //    sc.Start();
            //}
        }

    }
}
