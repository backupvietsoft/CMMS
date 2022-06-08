using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Ionic.Zip;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace Update
{
    public partial class FRM_INTERNET : Form
    {
        DataTable tbFile = new DataTable();
        Boolean flag = false;
        Boolean _success = false;

        BackgroundWorker bw = new BackgroundWorker();
        BackgroundWorker bw2 = new BackgroundWorker();

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rd = new Random();

            progressCopy.BeginInvoke((Action)(() =>
            {
                progressCopy.Value = rd.Next(1, 15);
            }));
            UpdateFile();
        }
        private void bw2_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient webClient1 = new WebClient();
            webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient1.DownloadFileAsync(new Uri(Program.URL_VERSION.Replace("=0", "=1")), Application.StartupPath + @"\Update\Version.txt");
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {




            foreach (Process P in System.Diagnostics.Process.GetProcessesByName(Program.sProcess.ToUpper()))
            {
                P.Kill();
            }
            _success = true;
            progressDownload.Value = progressDownload.Maximum;
            progressCopy.Value = progressCopy.Maximum;
            Process.Start(Application.StartupPath + "/" + Program.sProcess.ToUpper() + ".exe");
            this.Close();


        }
        public FRM_INTERNET()
        {
            InitializeComponent();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressDownload.Value = 0;
            progressCopy.Value = 0;

        }
        private void ProgressChanged_Update(object sender, DownloadProgressChangedEventArgs e)
        {
            progressDownload.Value = e.ProgressPercentage;
            progressCopy.Value = 0;
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (CheckUpdate() == true)
            {

                this.TopMost = true;

                //if(MessageBox.Show("Đã có phiên bản CMMS mới hơn, bạn có muốn cập nhật phiên bản mới không? ","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
                //{
                foreach (Process P in System.Diagnostics.Process.GetProcessesByName(Program.sProcess.ToUpper()))
                {
                    P.Kill();
                }
                MessageBox.Show("Đã có phiên bản " + Program.sProcess.ToUpper() + " mới, Vui lòng cập nhật.", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                btnUpdate.Enabled = true;



                this.Show();
                this.WindowState = FormWindowState.Normal;
                btnUpdate.PerformClick();
            }
            else
            {
                btnUpdate.Enabled = false;
                Application.ExitThread();
                Application.Exit();
            }


        }
        private void Completed_Update(object sender, AsyncCompletedEventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
        private void UpdateFile()
        {
            _success = false;
            string file = Application.StartupPath + @"\Update\Update.zip";
            string unzipto = Application.StartupPath + @"\Update";
            unZip(file, unzipto);
            //progressCopy.Text = "50";
            if (File.Exists(Application.StartupPath + @"\Update\Update.zip"))
            {
                File.Delete(Application.StartupPath + @"\Update\Update.zip");
            }
            string destination = Application.StartupPath + @"\Update";
            string[] Dirs = Directory.GetDirectories(destination);
            foreach (string Dir in Dirs)
            {
                string[] pth = Dir.Split('\\');
                if (pth.Length > 0)
                {
                    string _path = Application.StartupPath + @"\" + pth[pth.Length - 1];
                    if (!Directory.Exists(_path))
                    {
                        Directory.CreateDirectory(_path);
                    }
                    XulyCopyFile(_path, Dir);
                }
                //Xu ly thu muc con
                string[] Dirs1 = Directory.GetDirectories(Dir);
                foreach (string Dir2 in Dirs1)
                {
                    string[] pth1 = Dir2.Split('\\');
                    if (pth1.Length > 0)
                    {
                        string _path10 = Application.StartupPath + @"\" + pth1[pth1.Length - 2] + @"\" + pth1[pth1.Length - 1];
                        if (!Directory.Exists(_path10))
                        {
                            Directory.CreateDirectory(_path10);
                        }
                        XulyCopyFile(_path10, Dir2);
                    }
                }
            }
            XulyCopyFile(Application.StartupPath, destination);
            Deletefile();
            XulyDeleteFile(destination);
        }
        private void Deletefile()
        {
            string destination = Application.StartupPath + @"\lib";
            string[] Dirs = Directory.GetFiles(destination);
            foreach (string Dir in Dirs)
            {
                string s = Path.GetFileName(Dir);
                File.Delete(Application.StartupPath + @"\" + s);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                progressCopy.Value = 0;
                if (!Directory.Exists(Application.StartupPath + @"\Update"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\Update");
                }
                if (File.Exists(Application.StartupPath + @"\Update\Version.txt"))
                {
                    File.Delete(Application.StartupPath + @"\Update\Version.txt");
                }
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(GetUrlByFileName("Version.txt")), Application.StartupPath + @"\Update\Version.txt");
            }
        }
        private void FRM_INTERNET_Load(object sender, EventArgs e)
        {
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.Hide();
            if (!Directory.Exists(Application.StartupPath + @"\Update"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Update");
            }
            if (File.Exists(Application.StartupPath + @"\Update\Version.txt"))
            {
                File.Delete(Application.StartupPath + @"\Update\Version.txt");
            }
            WebClient webClient1 = new WebClient();
            webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //webClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged2);
            webClient1.DownloadFileAsync(new Uri(Program.URL_VERSION.Replace("?dl=0", "?dl=1")), Application.StartupPath + @"\Update\Version.txt");
        }
        private void InsertRowFileInfo(string FileName, string FileSize, string Url, string Modified)
        {
            DataRow dr = tbFile.NewRow();
            dr["FileName"] = FileName;
            dr["FileSize"] = FileSize;
            dr["Url"] = Url;
            dr["Modified"] = Modified;
            tbFile.Rows.Add(dr);
        }
        private Boolean IsExists(string FileName)
        {
            try
            {
                if (FileName == "")
                    return true;
                foreach (DataRow r in tbFile.Rows)
                {
                    if (r["FileName"].ToString() == FileName)
                        return true;

                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private String GetUrlByFileName(string FileName)
        {
            try
            {
                foreach (DataRow r in tbFile.Rows)
                {
                    if (r["FileName"].ToString() == FileName)
                        return r["Url"].ToString();
                }
                return "";
            }
            catch (Exception)
            {

                return "";
            }

        }
        private String GetModifiedDateByFileName(string FileName)
        {
            try
            {
                foreach (DataRow r in tbFile.Rows)
                {
                    if (r["FileName"].ToString() == FileName)
                        return r["Modified"].ToString();
                }
                return "";
            }
            catch (Exception)
            {

                return "";
            }

        }
        private String GetFileSizeByFileName(string FileName)
        {
            try
            {
                foreach (DataRow r in tbFile.Rows)
                {
                    if (r["FileName"].ToString() == FileName)
                        return r["FileSize"].ToString();
                }
                return "";
            }
            catch (Exception)
            {

                return "";
            }

        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            progressDownload.Value = 0;
            progressCopy.Value = 0;
            if (!Directory.Exists(Application.StartupPath + @"\Update"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Update");
            }
            if (File.Exists(Application.StartupPath + @"\Update\Update.zip"))
            {
                File.Delete(Application.StartupPath + @"\Update\Update.zip");
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_Update);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged_Update);
            webClient.DownloadFileAsync(new Uri(Program.URL_UPDATE.Replace("=0", "=1")), Application.StartupPath + @"\Update\Update.zip");
        }
        private static bool unZip(string file, string unZipTo)//, bool deleteZipOnCompletion)
        {
            try
            {

                //if(ZipFile.IsZipFile(file))
                //{

                using (ZipFile zip = Ionic.Zip.ZipFile.Read(file))
                {
                    zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                    zip.ExtractAll(unZipTo);
                }
                //}


            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }
        private void CreateZipFile(List<string> items, string destination)
        {
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                // Loop through all the items
                foreach (string item in items)
                {
                    // If the item is a file
                    if (System.IO.File.Exists(item))
                    {
                        // Add the file in the root folder inside our zip file
                        zip.AddFile(item, "");
                    }
                    // if the item is a folder    
                    else if (System.IO.Directory.Exists(item))
                    {
                        // Add the folder in our zip file with the folder name as its name
                        zip.AddDirectory(item, new System.IO.DirectoryInfo(item).Name);
                    }
                }
                // Finally save the zip file to the destination we want
                zip.Save(destination);
            }
        }
        private Boolean CheckUpdate()
        {

            string oldVersion = "1.0.0.0";
            string newVersion = "1.0.0.1";
            if (File.Exists(Application.StartupPath + @"\Version.txt"))
            {
                var path = Application.StartupPath + @"\Version.txt";
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    oldVersion = streamReader.ReadToEnd();
                }
                //oldVersion = File.ReadAllText(Application.StartupPath + @"\Version.txt").Trim();
            }
            if (File.Exists(Application.StartupPath + @"\Update\Version.txt"))
            {
                var path = Application.StartupPath + @"\Update\Version.txt";
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    newVersion = streamReader.ReadToEnd();
                }
                //newVersion = File.ReadAllText(Application.StartupPath + @"\Update\Version.txt").Trim();
            }
            else
            {
                newVersion = oldVersion;
            }

            if (newVersion == "")
                newVersion = "1.0.3.1";
            lbPhienbanHT.Text = oldVersion;
            lbPhienBanCN.Text = newVersion;
            if (Program.URL_LAN == "-99")
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.StartupPath + @"\" + Program.sProcess.ToUpper() + ".exe");
                lbPhienbanHT.Text = myFileVersionInfo.FileVersion;
                var path = Application.StartupPath + @"\Update\Version.txt";
                //lấy version hiện tại ghi vào version trong update
                System.IO.File.WriteAllText(path, oldVersion);
                return true;
            }
            if (oldVersion != newVersion)
                return true;
            else
                return false;
        }
        public void XulyCopyFile(string sourcepath, string destination)
        {
            try
            {
                string[] files = Directory.GetFiles(destination);
                foreach (string file in files)
                {
                    if (System.IO.Path.GetFileName(file) != "Update.exe" && System.IO.Path.GetFileName(file) != "Ionic.Zip.dll")
                    {
                        if (System.IO.File.Exists(sourcepath + @"\" + System.IO.Path.GetFileName(file)))
                        {
                            System.IO.File.Delete(sourcepath + @"\" + System.IO.Path.GetFileName(file));
                        }
                        Random rd = new Random();
                        progressCopy.BeginInvoke((Action)(() =>
                        {
                            progressCopy.Value = rd.Next(16, 99);
                        }));
                        System.IO.File.Copy(file, sourcepath + @"\" + System.IO.Path.GetFileName(file), true);


                    }
                    else
                    {
                        if (System.IO.Path.GetFileName(file) == "Update.exe")
                        {
                            if (!Directory.Exists(Application.StartupPath + @"\Update"))
                            {
                                Directory.CreateDirectory(Application.StartupPath + @"\Update");
                            }
                            try
                            {
                                System.IO.File.Copy(file, Application.StartupPath + @"\Update" + @"\" + System.IO.Path.GetFileName(file), true);
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

            }

        }

        public void XulyDeleteFile(string sourcepath)
        {
            try
            {
                string[] Dirs = Directory.GetDirectories(sourcepath);
                foreach (string Dir in Dirs)
                {
                    string[] f = Directory.GetFiles(Dir);
                    foreach (string file in f)
                    {
                        System.IO.File.Delete(file);
                    }
                    string[] Dirs2 = Directory.GetDirectories(Dir);
                    foreach (string Dir3 in Dirs2)
                    {
                        string[] f3 = Directory.GetFiles(Dir3);
                        foreach (string file in f3)
                        {
                            System.IO.File.Delete(file);
                        }

                        Directory.Delete(Dir3);
                    }
                    Directory.Delete(Dir);
                }
                string[] files = Directory.GetFiles(sourcepath);
                foreach (string file in files)
                {

                    if (System.IO.File.Exists(sourcepath + @"\" + System.IO.Path.GetFileName(file)))
                    {
                        if (System.IO.Path.GetFileName(file) != "Update.exe")
                        {
                            System.IO.File.Delete(sourcepath + @"\" + System.IO.Path.GetFileName(file));
                        }

                    }
                }
                if (Directory.Exists(sourcepath))
                {
                    Directory.Delete(sourcepath);
                }
            }
            catch (Exception)
            {

            }

        }

        private void FRM_INTERNET_FormClosed(object sender, FormClosedEventArgs e)
        {
            string destination = Application.StartupPath + @"\Update";
            XulyDeleteFile(destination);
            if (Program.URL_LAN == "-99")
            {
                if(GetVersionFromRegistry()== false)
                {
                    Application.Exit();
                    Process.Start(Application.StartupPath + "\\dotnetfx46.exe");
                }
            }
        }
        public bool GetVersionFromRegistry()
        {
            bool resulst = false;
            using (RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = System.Convert.ToString(versionKey.GetValue("Version", ""));
                        if (name != "")
                            continue;
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = System.Convert.ToString(subKey.GetValue("Version", ""));
                            if (Convert.ToDouble(name.Substring(0, 3)) >= 4.6 || name == "4.5.51209")
                                resulst = true;
                        }
                    }
                }
                return resulst;
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
                //MessageBox.Show("Không thể kết nối tới máy chủ cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

    }
}
