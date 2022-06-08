using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using System.IO;
using System.Reflection;
using System.Collections;

namespace ReportManager
{
    public partial class frmReports1 : Form
    {

        public class LoaiBaoCao
        {
            public static int _LoaiBC;
            public static int LoaiBC
            {
                get { return _LoaiBC; }
                set { int _LoaiBC = value; }
            }
        }
 

        public frmReports1()
        {           
            InitializeComponent();
            ImgList.ImgList1 = new System.Windows.Forms.ImageList(this.components);
            this.navBarControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(navBarControl_ActiveGroupChanged);
            EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
            
        }

        private void frmReports_Load(object sender, EventArgs e)
        {                                     
            
            ImgList.ImgList1.TransparentColor = System.Drawing.Color.Transparent;
            ImgList.CreateImagelists(Application.ExecutablePath+"reports\\images\\", ImgList.ImgList1);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        //load usercontrol
        private void barLinkClick(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctr in splitContainer1.Panel2.Controls)
                {
                    DisposeControl(ctr);
                }
                splitContainer1.Panel2.Controls.Clear();
                string frmName = ((navBarItem)sender).Name;
                string names = ((navBarItem)sender).uc;
                string frmText = ((navBarItem)sender).Caption;
                txtHelp.Text = frmText;               

                UserControl uc = GetUserControl(names);
               
                splitContainer1.Panel2.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.Name = frmText;
                txtHelp.Text = ((navBarItem)sender).help;
                try
                {
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\reports\\images\\" + frmName + ".jpg");
                    splitContainer1.Dock = DockStyle.Top;
                    pictureBox2.Visible = true;
                }
                catch
                {
                    splitContainer1.Dock = DockStyle.Fill;
                    pictureBox2.Visible = false;
                }
                Commons.Modules.ObjSystems.ThayDoiNN(uc, frmName);
            }
            catch
            { }
        }
        private void DisposeControl(Control crl)
        {
            try
            {
                foreach (Control ctr in crl.Controls)
                {
                    DisposeControl(ctr);
                    crl.Controls.Remove(ctr);
                    ctr.Controls.Clear();
                    ctr.Dispose();
                }
                crl.Dispose();
            }
            catch { }
        }
        public static UserControl GetUserControl(string control)
        {            
            string exeName = Application.ExecutablePath;
            string folder = Path.Combine(Path.GetDirectoryName(exeName), "");
            ArrayList MyFiles = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(folder);
            MyFiles.Add("CMMS.exe");
            MyFiles.Add("ExportExcels.dll");
            MyFiles.Add("ImportExcels.dll");
            MyFiles.Add("ReportHuda.dll");
            MyFiles.Add("CustomerInfoReport.dll");
            MyFiles.Add("WareHouse.dll");
            MyFiles.Add("ReportManager.dll");
            //MyFiles.Add("Modules.User.dll");               
            MyFiles.Add("ReportMail.dll");
            MyFiles.Add("ReportMain.dll");
            MyFiles.Add("ReportKH.dll");
            

            UserControl baseUS = null;
            
            try
            {
                foreach (string file in MyFiles)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(folder + "\\" + file);
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (!type.IsClass || type.IsNotPublic) continue;
                            Type[] interfaces = type.GetInterfaces();
                            if (type.Name.ToLower().Equals(control.Trim().ToLower()))
                            {
                                baseUS = new UserControl();
                                baseUS = (UserControl)Activator.CreateInstance(type);
                                return baseUS;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch
            {                
                return null;
            }
            return baseUS;
        }

        private void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            foreach (Control ctr in splitContainer1.Panel2.Controls)
            {
                DisposeControl(ctr); 
            }
            splitContainer1.Panel2.Controls.Clear();
        }
    }
}
