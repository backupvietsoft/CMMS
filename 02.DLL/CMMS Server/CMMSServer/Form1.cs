using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CmmsServerLib;
using System.Net;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CmmsServer
{
    public partial class Form1 : Form
    {
        Boolean Mashj = false;

        public Form1()
        {
            InitializeComponent();
        }
        
        CmmsServerDll servObj = new CmmsServerDll();
        private void btnStartSV_Click(object sender, EventArgs e)
        {
            StartSV();
        }

        private void StartSV()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPath.Text.ToString()))
                {
                    MessageBox.Show("Please choise path.");
                    return;
                }
                if (string.IsNullOrEmpty(txtIP.Text.ToString()))
                {
                    MessageBox.Show("Please input IP Server.");
                    return;
                }

                servObj._Path = txtPath.Text;
                servObj.PathUp = txtPath.Text;
                servObj.iPServer = txtIP.Text;
                servObj.outPath = txtPath.Text.ToString();

                servObj.StartServer();
                lbmgs.Text = servObj.currentStatus;
                btnStartSV.Enabled = false;
                txtPath.ReadOnly = true;
                txtIP.ReadOnly = true;
                button2.Enabled = false;
                button3.Enabled = false;

                startToolStripMenuItem.Enabled = false;
                exitToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            servObj.StopServer();
            lbmgs.Text = servObj.currentStatus;
            btnStartSV.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            //stopToolStripMenuItem.Enabled = true; 
            exitToolStripMenuItem.Enabled = true;
            txtPath.ReadOnly= false;
            txtIP.ReadOnly = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //servObj.StopServer();
         }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == WindowState)
            //    Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void GetThongSo()
        {

            try
            {
                string user = Environment.UserDomainName + "\\" + Environment.UserName;
                RegistrySecurity rs = new RegistrySecurity();
                rs.AddAccessRule(new RegistryAccessRule(user,
                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                    InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));

                RegistryKey rk = null;
                rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ECOMAINT\ECOMAINTKEY",
                                               RegistryKeyPermissionCheck.Default, rs);

                if (Convert.ToString(rk.GetValue("IPServer")).Equals(""))
                {
                    string hostName = Dns.GetHostName();
                    IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);
                    IPAddress[] iPAddress = ipHostEntry.AddressList;
                    txtIP.Text = iPAddress[2].ToString();
                    rk.SetValue("IPServer", iPAddress[2].ToString());
                }
                else
                {
                    txtIP.Text = Convert.ToString(rk.GetValue("IPServer"));
                }

                if (!Convert.ToString(rk.GetValue("PathUp")).Equals(""))
                {
                    txtPath.Text = Convert.ToString(rk.GetValue("PathUp"));
                }
                servObj._Path = txtPath.Text.ToString();
                servObj.StopServer();
                lbmgs.Text = servObj.currentStatus;
                rk.Close();

                rk = null;
                rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                               RegistryKeyPermissionCheck.Default, rs);
                try
                {
                    if (rk.GetValue("CMMS Server") == null)
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Hide();
                //GetThongSo();
                txtHDDSerial.Text = Commons.Modules.ObjSystems.GetSerial();
                if (checkBox1.Checked) StartSV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtIP_Validated(object sender, EventArgs e)
        {
            try
            {
                RegistryKey vRegInfo = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ECOMAINT\ECOMAINTKEY");
                if (!Convert.ToString(vRegInfo.GetValue("IPServer")).Equals(txtIP.Text))
                {
                    if (MessageBox.Show("Update new IP server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    vRegInfo.SetValue("IPServer", txtIP.Text);
                }
                vRegInfo.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                string user = Environment.UserDomainName + "\\" + Environment.UserName;

                RegistrySecurity rs = new RegistrySecurity();

                rs.AddAccessRule(new RegistryAccessRule(user,
                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                    InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));

                RegistryKey rk = null;
                rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                               RegistryKeyPermissionCheck.Default, rs);

                if (checkBox1.Checked)
                {

                    rk.SetValue("CMMS Server", Application.ExecutablePath);
                }
                else
                {
                    rk.DeleteValue("CMMS Server", false);
                }

                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mashj = true;
            try
            {
                servObj.StopServer();
                this.Close();
            }
            catch { }
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Mashj)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog f = new FolderBrowserDialog();
            string path = "";
            RegistryKey vRegInfo = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ECOMAINT\ECOMAINTKEY");
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.OK))
                {
                    path = f.SelectedPath;

                }
                else
                    return;
                txtPath.Text = path;
                vRegInfo.SetValue("PathUp", path);
            }
            catch
            {
                txtPath.Text = "";
            }
            vRegInfo.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Load current IP server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            RegistryKey vRegInfo = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ECOMAINT\ECOMAINTKEY");
            try
            {
                string vIP = "";
                IPHostEntry ip = new IPHostEntry();
                string hostname = Dns.GetHostName();
                ip = Dns.GetHostByName(hostname);

                foreach (IPAddress listip in ip.AddressList)
                {
                    vIP = listip.ToString();
                }

                txtIP.Text = vIP;
                vRegInfo.SetValue("IPServer", vIP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            vRegInfo.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtHDDSerial.Text = Commons.Modules.ObjSystems.GetSerial();
        }

        private void configServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinServer frm = new frmThongTinServer();
            frm.ShowDialog();
            
        }
    }
}
