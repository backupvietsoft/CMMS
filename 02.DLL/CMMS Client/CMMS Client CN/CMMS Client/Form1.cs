using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMMSClientGFLib;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.Management;
using System.Collections;


namespace CMMSClientGF
{
    public partial class Form1 : Form
    {

        //CMMSClientGFLib objClient = new CMMSClientGFLib("", "localhost", @"E:\Mashj\send files");
        CMMSClientGFLib.CMMSClientGFLib objClient = new CMMSClientGFLib.CMMSClientGFLib("", "localhost", @"E:\Mashj\send files");
        public string IPServer = "192.168.1.180";
        public Form1()
        {
            InitializeComponent();
            objClient.FileReceiveFile += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_FileReceiveFile);
            objClient.FileReceiveCompleted += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_FileReceiveCompleted);
            objClient.CopyToPath += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_CopyToPath);
            objClient.TotalFile += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_TotalFile);
            objClient.FileReceiveCount += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_FileReceiveCount);
            objClient.ErrorMsg += new CMMSClientGFLib.CMMSClientGFLib.FileSendCompletedDelegate(objClient_ErrorMsg);
            objClient.outPath = Application.StartupPath.ToString().Replace("\\", "/") + "/";
            ReadServerInfo();
            ReadVersionInfo();
        }
        public void ReadServerInfo()
        {
            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + System.IO.Path.DirectorySeparatorChar + "Server.txt");
            try
            {
                String sIP;
                sIP = sr.ReadLine();
                textBox1.Text = sIP;
            }
            catch { }
            sr.Close();
        }

        public void ReadVersionInfo()
        {
            try
            {
                //StreamReader sr = new StreamReader(Application.StartupPath.ToString() + System.IO.Path.DirectorySeparatorChar + "Version.txt");
                ////StreamReader sr = new StreamReader(@"\\server\CMMS\test\" + "Version.txt");
                //String line;
                //line = sr.ReadLine();
                ////ss = line.ToString();
                ////while ((line = sr.ReadLine()) != null)
                ////{
                ////    string ss = line.ToString();
                ////    if (line.Substring(0, 8).ToUpper() == "IPSERVER")
                ////    {
                ////        textBox1.Text = line.Substring(9, line.Length - 9);
                ////    }
                ////}
                //sr.Close();
            }
            catch { }
        }

        public int TotalFile = 0;
        public int TotalIndex = 0;

        void objClient_TotalFile()
        {
            try
            {
                TotalFile = objClient.TotalFileNeedReceive;
                if (TotalFile > 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        //bắt buộc nấc trong progress bar xuất phát từ số 0 sử dụng thuộc tính Minimum
                        prgReceiveFile.Minimum = 0;
                        //và chỉ cho phép nấc này chạy đến giá trị tối đa là 2000 sử dụng thuộc tính Maximum
                        prgReceiveFile.Maximum = TotalFile;
                        //khởi tạo giá trị ban đầu cho progress bar sử thuộc tính Value
                        prgReceiveFile.Value = 1;
                        //khoảng tăng giữa các nấc trong ProgressBar
                        prgReceiveFile.Step = 1;

                    });
                }
            }
            catch { }
        }

        void objClient_FileReceiveCount()
        {
            try
            {
                //TotalIndex = objClient.FileCount;
                try
                {
                    this.Invoke((MethodInvoker)delegate { label4.Text = objClient.FileCount.ToString() + "/" + TotalFile.ToString(); });
                }
                catch { }


                try
                {
                    this.Invoke((MethodInvoker)delegate { prgReceiveFile.PerformStep(); });
                }
                catch { }



            }
            catch { }
        }

        void objClient_CopyToPath()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { lbFilePath.Text = objClient.FilePathInfoCoping; });
            }
            catch { }
        }
        void objClient_FileReceiveFile()
        {
            try
            {
                string sFile = "";
                sFile = objClient.FileNameCoping.Replace("#", "");
                sFile = sFile.Replace("...", "");
                this.Invoke((MethodInvoker)delegate { lbFileName.Text = sFile; });
                //this.Invoke((MethodInvoker)delegate { lbFileName.Text = objClient.FileNameCoping; });
            }
            catch { }
        }

        void objClient_ErrorMsg()
        {
            try
            {
                MessageBox.Show("Can not connect to server: " + textBox1.Text.Trim() + ",please check IP server! ");
            }
            catch { }
        }
        void objClient_FileReceiveCompleted()
        {
            DialogResult result1 = MessageBox.Show("Upgrade successfully! do you want to show application ?", "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Process p = new Process();
                        p.StartInfo.WorkingDirectory = Application.StartupPath.ToString();
                        p.StartInfo.FileName = Application.StartupPath.ToString() + System.IO.Path.DirectorySeparatorChar + "CMMS.exe";
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        //p.WaitForExit();

                    });
                }
                catch { }
            }

            try
            {
                this.Invoke((MethodInvoker)delegate { this.Enabled = true; });
            }
            catch { }
            try
            {
                this.Invoke((MethodInvoker)delegate { this.Close(); });
            }
            catch { }        
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("Please input IP Server.");
                return;
            }
            this.Enabled = false;
            objClient.iPServer = textBox1.Text.Trim();
            objClient.ReceiveFileFromServer("");
            lbFileName.Text = objClient.FileNameCoping;
            lbFilePath.Text = objClient.FilePathInfoCoping;
            this.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            StreamWriter sW = new StreamWriter(Application.StartupPath.ToString() + System.IO.Path.DirectorySeparatorChar + "Server.txt");
            try
            {
                String sIP;
                sIP = textBox1.Text;
                sW.WriteLine(sIP);
            }
            catch { }
            sW.Close();
        }

        private void btnGetSerial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("Please input IP Server.");
                return;
            }
            objClient.iPServer = textBox1.Text.Trim();
            textBox2.Text = objClient.ReceiveHDDSerial(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Process[] GetPArry = Process.GetProcesses();
                foreach (Process testProcess in GetPArry)
                {
                    string ProcessName = testProcess.ProcessName;

                    ProcessName = ProcessName.ToLower();
                    if (ProcessName.CompareTo("cmms") == 0)
                        testProcess.Kill();
                }
            }
            catch { }
            btnReceive_Click(sender, e);
        }

        public bool GetDiskSerial(string Computername)
        {
            try
            {
                //ManagementScope oMs = new ManagementScope("\\\\mashilove\\root\\cimv2");
                ManagementScope scope = new ManagementScope(@"\\" + Computername + @"\root\cimv2");
                scope.Connect();
                ArrayList hdCollection;
                ManagementObjectSearcher searcher;
                if (GetDiskDrive(scope, out hdCollection, out searcher) || GetDiskSerial(scope, hdCollection, ref searcher))
                    return true;
                else 
                    return false;
            }
            catch (ManagementException)
            {
                return false;
            }

        }

        private bool GetDiskSerial(ManagementScope scope, ArrayList hdCollection, ref ManagementObjectSearcher searcher)
        {
            try
            {


                ObjectQuery query1 = new ObjectQuery("SELECT * FROM Win32_PhysicalMedia");

                searcher = new ManagementObjectSearcher(scope, query1);
                int i = 0;
                string sDiskSerial = "";
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    // get the hard drive from collection
                    // using index
                    if (i < hdCollection.Count)
                    {
                        HardDrive hd = (HardDrive)hdCollection[i];
                        if (wmi_HD["SerialNumber"] == null)
                            hd.SerialNo = "";
                        else
                            hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                    }
                    ++i;
                }
                foreach (HardDrive hd in hdCollection)
                {
                    if (!String.IsNullOrEmpty(hd.SerialNo))
                    {
                        sDiskSerial = hd.SerialNo;
                        break;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool GetDiskDrive(ManagementScope scope, out ArrayList hdCollection, out ManagementObjectSearcher searcher)
        {
            try
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
                hdCollection = new ArrayList();
                searcher = new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    HardDrive hd = new HardDrive();
                    hd.Model = wmi_HD["Model"].ToString();
                    hd.Type = wmi_HD["InterfaceType"].ToString();
                    hdCollection.Add(hd);
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                hdCollection = null;
                searcher = null;
                return false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        
            this.Enabled = false;
            
        }
    }
    class HardDrive
    {
        private string model = null;
        private string type = null;
        private string serialNo = null;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
    }
    
}
