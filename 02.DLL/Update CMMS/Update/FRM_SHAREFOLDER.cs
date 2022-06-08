using Update;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Update
{
    public partial class FRM_SHAREFOLDER : Form
    {
        private bool is_Extract = false;
        string destination = Application.StartupPath + "/Update";
        BackgroundWorker bw = new BackgroundWorker();
        public FRM_SHAREFOLDER()
        {
            InitializeComponent();
        }
        


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Random rd = new Random();
            ProgressBarControl2.BeginInvoke((Action)(() =>
            {
                ProgressBarControl2.Value = rd.Next(1, 10);
            }));
            if (ExtractFile() == true)
            {
                is_Extract = true;
            }
           
            UpdateFile();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (Directory.Exists(destination))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(destination);
                try
                {

                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (file.Name != "Update.exe")
                               file.Delete();
                    }

                }
                catch (Exception)
                {
                }
                try
                {
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                }
                catch (Exception)
                {
                }
                try
                {
                    Directory.Delete(destination);
                }
                catch (Exception)
                {

                    
                }

                try
                {
                    if (File.Exists(Application.StartupPath + "/Update.zip"))
                    {
                        File.Delete(Application.StartupPath + "/Update.zip");
                    }
                }
                catch (Exception)
                {

                    
                }
               
            }
            ProgressBarControl2.Value = 0;
            foreach (Process P in System.Diagnostics.Process.GetProcessesByName(Program.sProcess.ToUpper()))
            {
                P.Kill();
            }
            Process.Start(Application.StartupPath + "/" + Program.sProcess.ToUpper() + ".exe");
            this.Close();

        }
        private void FRM_SHAREFOLDER_Load(object sender, EventArgs e)
        {
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            
            if (Directory.Exists(destination))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(destination);
                try
                {

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();

                    }

                }
                catch (Exception)
                {
                }
                try
                {
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                }
                catch (Exception)
                {
                }

                Directory.Delete(destination);
                if (File.Exists(Application.StartupPath + "/Update.zip"))
                {
                    File.Delete(Application.StartupPath + "/Update.zip");
                }
            }

            if (DownloadFileVersion() == true)
            {
                if (CheckUpdateVersion() == true)
                {
                    this.TopMost = true;
                     foreach (Process P in System.Diagnostics.Process.GetProcessesByName(Program.sProcess.ToUpper()))
                        {
                            P.Kill();
                        }
                    //if (MessageBox.Show("Đã có phiên bản CMMS mới hơn, bạn có muốn cập nhật phiên bản mới không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{
                    MessageBox.Show("Đã có phiên bản " + Program.sProcess.ToUpper() + " mới, Vui lòng cập nhật. ", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    //}
                    //else
                    //{
                    //    this.TopMost = false;
                    //    Application.ExitThread();
                    //    Application.Exit();
                    //}

                    btnChon.PerformClick();
                }
                else
                {

                    Application.ExitThread();
                    Application.Exit();
                }
            }

            btnChon.Focus();
        }
        private Boolean DownloadFileVersion()
        {

            try
            {

                string source = Program.URL_LAN + @"\Version.txt";
                if (System.IO.File.Exists(Program.URL_LAN + @"\Version.txt"))
                {
                    source = Program.URL_LAN + @"\Version.txt";
                }

                ////'Dim source As String = "\\PMP-ECOMAIN\Data$\Data\Tailieumay\UpdateCMMS\Version.txt"
                if (!System.IO.File.Exists(source))
                {
                    return false;
                }
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                System.IO.File.Copy(source, destination + @"\Version.txt", true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private Boolean CheckUpdateVersion()
        {
            string client_vs = "";
            string server_vs = "";
            bool flag = false;
            string[] pth = destination.Split('/');
            if (System.IO.File.Exists(Application.StartupPath + "/Version.txt"))
            {
                var fileStream = new FileStream(Application.StartupPath + "/Version.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    client_vs = streamReader.ReadToEnd();
                }

                //client_vs = System.IO.File.ReadAllText(Application.StartupPath + "/Version.txt");
                lbPhienbanHT.Text = client_vs;
                flag = false;
            }
            else
            {
                lbPhienbanHT.Text = "";
                flag = true;
            }

            if (System.IO.File.Exists(Application.StartupPath + "/" + pth[pth.Length - 1] + "/Version.txt"))
            {

                var fileStream = new FileStream(Application.StartupPath + "/" + pth[pth.Length - 1] + "/Version.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    server_vs = streamReader.ReadToEnd();
                }
                //server_vs = System.IO.File.ReadAllText(Application.StartupPath + "/" + pth[pth.Length - 1] + "/Version.txt");
                lbPhienBanCN.Text = server_vs;
                if (flag == true)
                {
                    
                    
                    return true;
                }
            }
            else
            {
                lbPhienBanCN.Text = "";
                return false;
            }

            if (server_vs.Trim() != client_vs.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean ExtractFile()
        {
            try
            {

                if (DownloadFileUpdate() == true)
                {
                    if (Directory.Exists(destination))
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(destination);
                        try
                        {
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                            }

                        }
                        catch (Exception)
                        {
                        }

                        Directory.Delete(destination);

                    }


                    
                    string source = Application.StartupPath + "/Update.zip";

                    if (File.Exists(source))
                    {
                       
                        
                        try
                        {
                            ZipFile zip = ZipFile.Read(source);
                            using (zip)
                            {
                                zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                                zip.ExtractAll(destination);
                                ProgressBarControl2.BeginInvoke((Action)(() =>
                                {
                                    ProgressBarControl2.Value = 0;
                                }));
                            }


                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, "Lỗi giải nén source cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private Boolean DownloadFileUpdate()
        {

            try
            {
                string source = Program.URL_LAN + @"\Update.zip";
                System.IO.File.Copy(source, Application.StartupPath + "\\Update.zip", true);
                //FileInfo f = new FileInfo(Application.StartupPath + "\\Update.zip");
                //lbDungluong.Text = Math.Round(Convert.ToDouble(f.Length) / 1024, 0).ToString() + " KB";
                Random rd = new Random();
                ProgressBarControl2.BeginInvoke((Action)(() =>
                {
                    ProgressBarControl2.Value = rd.Next(40, 65);
                }));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void UpdateFile()
        {
            // If the directory doesn't exist, create it.

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            try
            {
                
                if (is_Extract == false)
                {
                    if (ExtractFile() == true)
                    {
                        
                        
                        XulyCopyFile(Application.StartupPath, destination);
                        string[] Dirs = Directory.GetDirectories(destination);
                        foreach (string Dir in Dirs)
                        {
                            string[] pth = Dir.Split('\\');
                            if (pth.Length > 0)
                            {
                                string _path = Application.StartupPath + "/" + pth[pth.Length - 1];
                                if (!Directory.Exists(_path))
                                {
                                    Directory.CreateDirectory(_path);
                                }
                                XulyCopyFile(_path, Dir);

                                string[] Dirs1 = Directory.GetDirectories(Dir);
                                foreach (string Dir2 in Dirs1)
                                {
                                    string[] pth1 = Dir2.Split('\\');
                                    if (pth1.Length > 0)
                                    {
                                        string _path10 = Application.StartupPath + "/" + pth1[pth1.Length - 2] + "/" + pth1[pth1.Length - 1];
                                        if (!Directory.Exists(_path10))
                                        {
                                            Directory.CreateDirectory(_path10);
                                        }
                                        XulyCopyFile(_path10, Dir2);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                   
                    XulyCopyFile(Application.StartupPath, destination);
                    string[] Dirs = Directory.GetDirectories(destination);
                    foreach (string Dir in Dirs)
                    {
                        string[] pth = Dir.Split('\\');
                        if (pth.Length > 0)
                        {
                            string _path = Application.StartupPath + "/" + pth[pth.Length - 1];
                            if (!Directory.Exists(_path))
                            {
                                Directory.CreateDirectory(_path);
                            }
                            XulyCopyFile(_path, Dir);
                            string[] Dirs1 = Directory.GetDirectories(Dir);
                            foreach (string Dir2 in Dirs1)
                            {
                                string[] pth1 = Dir2.Split('\\');
                                if (pth1.Length > 0)
                                {
                                    string _path10 = Application.StartupPath + "/" + pth1[pth1.Length - 2] + "/" + pth1[pth1.Length - 1];
                                    if (!Directory.Exists(_path10))
                                    {
                                        Directory.CreateDirectory(_path10);
                                    }
                                    XulyCopyFile(_path10, Dir2);
                                }
                            }

                        }
                    }
                }
            }
            catch (System.Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void XulyCopyFile(string sourcepath, string destination)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(destination);
                foreach (string file in files)
                {
                    if (System.IO.Path.GetFileName(file) != "Update.exe" && System.IO.Path.GetFileName(file) != "Ionic.Zip.dll")
                    {

                        if (System.IO.File.Exists(sourcepath + "/" + System.IO.Path.GetFileName(file)))
                        {
                            System.IO.File.Delete(sourcepath + "/" + System.IO.Path.GetFileName(file));
                        }
                        Random rd = new Random();
                        ProgressBarControl2.BeginInvoke((Action)(() =>
                        {
                            ProgressBarControl2.Value = rd.Next(16, 99);
                        }));
                        System.IO.File.Copy(file, sourcepath + "/" + System.IO.Path.GetFileName(file), true);
                        ProgressBarControl2.BeginInvoke((Action)(() =>
                        {
                            ProgressBarControl2.Value = 0;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            btnChon.Enabled = false;
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }

        }

        private void FRM_SHAREFOLDER_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(destination))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(destination);
                try
                {

                    foreach (FileInfo file in di.GetFiles())
                    {
                        if(file.Name !="Update.exe")
                             file.Delete();

                    }

                }
                catch (Exception)
                {
                }
                try
                {
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                }
                catch (Exception)
                {
                }

                try
                {
                    Directory.Delete(destination);
                }
                catch (Exception)
                {

                    
                }
                
                if (File.Exists(Application.StartupPath + "/Update"))
                {
                    File.Delete(Application.StartupPath + "/Update");
                }
            }
        }

    }
}
