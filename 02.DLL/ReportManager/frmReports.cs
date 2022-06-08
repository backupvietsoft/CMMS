using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System.IO;
using System.Collections;
using System.Reflection;

namespace ReportManager
{
    public partial class frmReports : DevExpress.XtraEditors.XtraForm
    {
        private string sUcControl = "";
        string frmName;
        string names ;
        string frmText ;
        private UserControl ucTmp;
        public class LoaiBaoCao
        {
            public static int _LoaiBC;
            public static int LoaiBC
            {
                get { return _LoaiBC; }
                set { int _LoaiBC = value; }
            }
        }
        public navBarControl navBarControl;
        private System.Windows.Forms.GroupBox grbList;
        public frmReports()
        {
            InitializeComponent();
            ImgList.ImgList1 = new System.Windows.Forms.ImageList(this.components);
            this.navBarControl = new ReportManager.navBarControl();
            this.grbList = new System.Windows.Forms.GroupBox();
            this.grbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();

            this.grbList.Controls.Add(this.navBarControl);
            this.grbList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbList.Location = new System.Drawing.Point(0, 0);
            this.grbList.Name = "grbList";
            this.grbList.Size = new System.Drawing.Size(384, 600);
            this.grbList.TabIndex = 1;
            this.grbList.TabStop = false;
            this.grbList.Text = "Danh sách báo cáo";

            this.navBarControl.ActiveGroup = null;
            this.navBarControl.AllowSelectedLink = true;
            this.navBarControl.Appearance.Item.ForeColor = System.Drawing.SystemColors.Desktop;
            this.navBarControl.Appearance.Item.Options.UseForeColor = true;
            this.navBarControl.Appearance.ItemPressed.BackColor = System.Drawing.Color.Blue;
            this.navBarControl.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarControl.Appearance.ItemPressed.ForeColor = System.Drawing.Color.Red;
            this.navBarControl.Appearance.ItemPressed.Options.UseBackColor = true;
            this.navBarControl.Appearance.ItemPressed.Options.UseFont = true;
            this.navBarControl.Appearance.ItemPressed.Options.UseForeColor = true;
            this.navBarControl.ContentButtonHint = null;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Location = new System.Drawing.Point(3, 17);
            this.navBarControl.LookAndFeel.SkinName = "Blue";
            this.navBarControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 181;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(378, 580);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "Danh sách báo cáo";
            this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            this.navBarControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDoubleClick);
            this.navBarControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.navBarControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(navBarControl_ActiveGroupChanged);
            EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
            this.Controls.Add(this.grbList);
            this.grbList.ResumeLayout(false);
        }






        public void frmReports_Load(object sender, EventArgs e)
        {
            ImgList.ImgList1.TransparentColor = System.Drawing.Color.Transparent;
            ImgList.CreateImagelists(Application.ExecutablePath + "reports\\images\\", ImgList.ImgList1);
            try
            {
                EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
            }
            catch { }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }


        public interface IControlBase
        {
            void ReloadControl();
        }

        //load usercontrol
        private void barLinkClick(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctr in splitContainerControl1.Panel2.Controls)
                {
                    DisposeControl(ctr);
                }
                splitContainerControl1.Panel2.Controls.Clear();
                 frmName = ((navBarItem)sender).Name;
                 names = ((navBarItem)sender).uc;
                 frmText = ((navBarItem)sender).Caption;

                Commons.Modules.SQLString = frmName;
                pictureBox2.Image = null;
                UserControl uc = GetUserControl(names);
                try
                {
                    ucTmp = uc;
                }catch { }
                string sGroup = "";
                try
                {
                    sGroup = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)(e)).Link.Group.ToString() + " - ";
                }
                catch { }
                sUcControl = sGroup + frmText + " - " + frmName + " - " + uc.ToString();
                
                splitContainerControl1.Panel2.Controls.Add(uc);

                uc.Dock = DockStyle.Fill;
                uc.Name = frmText;

                if (((navBarItem)sender).help != "")
                    txtGhiChu.Text = ((navBarItem)sender).help;
                else
                    txtGhiChu.Text = frmText;


                try
                {
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\reports\\images\\" + frmName + ".jpg");
                    splitContainerControl1.Dock = DockStyle.Top;
                    splitterControl2.Visible = true;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Visible = true;
                }
                catch
                {
                    splitContainerControl1.Dock = DockStyle.Fill;
                    pictureBox2.Visible = false;
                    splitterControl2.Visible = false;
                }
                Commons.Modules.ObjSystems.ThayDoiNN(uc, frmName);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message.ToString());
            }
            Commons.Modules.SQLString = "";
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
            try { MyFiles.Add("MVControl.dll"); } catch { }
            try { MyFiles.Add("CMMS.exe"); } catch { }
            try { MyFiles.Add("ExportExcels.dll"); } catch { }
            try { MyFiles.Add("ImportExcels.dll"); } catch { }
            try { MyFiles.Add("ReportHuda.dll"); } catch { }
            try { MyFiles.Add("CustomerInfoReport.dll"); } catch { }
            try { MyFiles.Add("WareHouse.dll"); } catch { }
            try { MyFiles.Add("ReportManager.dll"); } catch { }
            try { MyFiles.Add("ReportMail.dll"); } catch { }
            try { MyFiles.Add("ReportMain.dll"); } catch { }
            try { MyFiles.Add("MReportKH.dll"); } catch { }
            try { MyFiles.Add("ReportControls.dll"); } catch { }
            try { MyFiles.Add("Commons.dll"); } catch { }
            try { MyFiles.Add("MReportVB.dll"); } catch { }
            try { MyFiles.Add("VietShape.dll"); } catch { }


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
            foreach (Control ctr in splitContainerControl1.Panel2.Controls)
            {
                DisposeControl(ctr);
            }
            splitContainerControl1.Panel2.Controls.Clear();
        }
        private void navBarControl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
            }
            catch { }
        }

        private void navBarControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NavBarControl navBar = sender as NavBarControl;
                NavBarHitInfo hitInfo = navBar.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
                if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                    hitInfo.Group.Expanded = !hitInfo.Group.Expanded;

                try
                {
                    EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
                }
                catch { }
            }


            if (Form.ModifierKeys == Keys.Control & e.Button == MouseButtons.Right)
            {
                try
                {
                    VietShape.frmNNgu frm = new VietShape.frmNNgu();
                    frm.sForm = frmName;
                    frm.ShowDialog();
                    Commons.Modules.ObjSystems.ThayDoiNN(ucTmp, frmName);
                }
                catch { }

            }

        }


        private void frmReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("AAA_MANAGER_1REPORT_LIC" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("AAA_MANAGER_REPORT" + Commons.Modules.UserName);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(sUcControl);
            }
            catch { Clipboard.SetText("loi"); }
        }

        public void ReNNReport()
        {
            try
            {
                grbList.Controls.Remove(navBarControl);
                this.navBarControl = new ReportManager.navBarControl();
                ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
                grbList.Controls.Add(navBarControl);
                this.navBarControl.ActiveGroup = null;
                this.navBarControl.AllowSelectedLink = true;
                this.navBarControl.Appearance.Item.ForeColor = System.Drawing.SystemColors.Desktop;
                this.navBarControl.Appearance.Item.Options.UseForeColor = true;
                this.navBarControl.Appearance.ItemPressed.BackColor = System.Drawing.Color.Blue;
                this.navBarControl.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.navBarControl.Appearance.ItemPressed.ForeColor = System.Drawing.Color.Red;
                this.navBarControl.Appearance.ItemPressed.Options.UseBackColor = true;
                this.navBarControl.Appearance.ItemPressed.Options.UseFont = true;
                this.navBarControl.Appearance.ItemPressed.Options.UseForeColor = true;
                this.navBarControl.ContentButtonHint = null;
                this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.navBarControl.Location = new System.Drawing.Point(3, 17);
                this.navBarControl.LookAndFeel.SkinName = "Blue";
                this.navBarControl.LookAndFeel.UseDefaultLookAndFeel = false;
                this.navBarControl.Name = "navBarControl";
                this.navBarControl.OptionsNavPane.ExpandedWidth = 181;
                this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
                this.navBarControl.Size = new System.Drawing.Size(378, 580);
                this.navBarControl.TabIndex = 0;
                this.navBarControl.Text = "Danh sách báo cáo";
                this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
                this.navBarControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDoubleClick);
                this.navBarControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDown);
                ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
                this.navBarControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(navBarControl_ActiveGroupChanged);
                EventCollection.Add("barLinkClick", new NavBarLinkEventHandler(barLinkClick));
                this.grbList.ResumeLayout(false);
            }
            catch { }

        }


    }
}