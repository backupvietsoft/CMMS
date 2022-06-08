using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using System.Windows.Forms;

namespace Update
{
    public partial class FRM_UPDATE : Form
    {
        Boolean status = false;
        BackgroundWorker bw = new BackgroundWorker();
        BackgroundWorker bw2 = new BackgroundWorker();
        public FRM_UPDATE()
        {
            InitializeComponent();           
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {          
            lbDetail.Items.Add("Check Version");
            lbDetail.Items.Add("Download File Update");
            lbPT.Text = "0 %";
            btnDownload.Enabled = false;
            bgWorker1.RunWorkerAsync();
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sUrlToDnldFile = txtUrlUpdate.Text;

            string sFileSavePath;

            try

            {
                Uri url = new Uri(sUrlToDnldFile);               
                string _path = Application.StartupPath + @"\Update";
                if (!Directory.Exists(_path))
                {
                    try
                    {
                        lbDetail.BeginInvoke((Action)(() =>
                        {
                            lbDetail.Items.Add("Create folder [ " + _path + " ]");
                        }));
                    }
                    catch (Exception)
                    {


                    }
                    Directory.CreateDirectory(_path);
                }
                sFileSavePath = Application.StartupPath + @"\Update\Update.zip";

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();


                response.Close();

                // gets the size of the file in bytes

                long iSize = response.ContentLength;



                // keeps track of the total bytes downloaded so we can update the progress bar

                long iRunningByteTotal = 0;

                WebClient client = new WebClient();

                Stream strRemote = client.OpenRead(url);

                FileStream strLocal = new FileStream(sFileSavePath, FileMode.Create, FileAccess.Write, FileShare.None);

                int iByteSize = 0;

                byte[] byteBuffer = new byte[1024];

                while ((iByteSize = strRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)

                {

                    // write the bytes to the file system at the file path specified

                    strLocal.Write(byteBuffer, 0, iByteSize);

                    iRunningByteTotal += iByteSize;


                    // calculate the progress out of a base "100"

                    double dIndex = (double)(iRunningByteTotal);

                    double dTotal = (double)iSize;

                    double dProgressPercentage = (dIndex / dTotal);

                    int iProgressPercentage = (int)(dProgressPercentage * 100);


                    // update the progress bar

                    bgWorker1.ReportProgress(iProgressPercentage);

                }
                strLocal.Close();
                strRemote.Close();

                status = true;

            }

            catch (Exception exM)

            {

                //Show if any error Occured

                MessageBox.Show("Error: " + exM.Message);

                status = false;

            }
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage ;
                lbPT.Text = e.ProgressPercentage.ToString() + " %";
            }
            catch (Exception)
            {

                
            }
            
        }

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (status == true)
            {
                progressBar1.Visible = false;
                progressBar2.Visible = true;
                btCancel.Enabled = false;
                bw.RunWorkerAsync();
                GC.Collect();
            }
               
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            lbProgress.BeginInvoke((Action)(() =>
            {
                lbProgress.Text = "Process copy file ...";
            }));
            
            Random rd = new Random();

            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(2, 10);
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));
            
            UpdateFile();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            foreach (Process P in System.Diagnostics.Process.GetProcessesByName("CMMS"))
            {
                P.Kill();
            }
            progressBar2.Value = 100;
            lbPT.Text = progressBar2.Value.ToString() + " %";
            lbProgress.Text = "Update Finish";

            this.Hide();
            if (Directory.Exists(Application.StartupPath + @"\Version"))
            {
                //Xu ly cap nhat Version
                
            }
            else
            {
                if (MessageBox.Show("Cập nhật phiên bản mới thành công, bạn có muốn mở lại phần mềm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + "/CMMS.exe");
                }
            }
            this.Close();

        }



        private void bw2_DoWork(object sender, DoWorkEventArgs e)
        {
            string sUrlToDnldFile = Program.URL_VERSION;

            string sFileSavePath;

            try

            {

                try
                {
                    lbDetail.BeginInvoke((Action)(() =>
                    {
                        lbDetail.Items.Add("Download Version File");
                    }));
                }
                catch (Exception)
                {


                }
                Uri url = new Uri(sUrlToDnldFile);

                string _path = Application.StartupPath + @"\Update";
                if (!Directory.Exists(_path))
                {
                    try
                    {
                        lbDetail.BeginInvoke((Action)(() =>
                        {
                            lbDetail.Items.Add("Create folder [ " + _path + " ]");
                        }));
                    }
                    catch (Exception)
                    {


                    }
                    Directory.CreateDirectory(_path);
                }
                //string sFileName = "Update.zip";

                sFileSavePath = Application.StartupPath + @"\Update\Version.txt";

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();


                response.Close();

                // gets the size of the file in bytes

                long iSize = response.ContentLength;



                // keeps track of the total bytes downloaded so we can update the progress bar

                long iRunningByteTotal = 0;

                WebClient client = new WebClient();

                Stream strRemote = client.OpenRead(url);

                FileStream strLocal = new FileStream(sFileSavePath, FileMode.Create, FileAccess.Write, FileShare.None);

                int iByteSize = 0;

                byte[] byteBuffer = new byte[1024];

                while ((iByteSize = strRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)

                {

                    // write the bytes to the file system at the file path specified

                    strLocal.Write(byteBuffer, 0, iByteSize);

                    iRunningByteTotal += iByteSize;


                    // calculate the progress out of a base "100"

                    double dIndex = (double)(iRunningByteTotal);

                    double dTotal = (double)iSize;

                   

                }

                strLocal.Close();
                strRemote.Close();


                status = true;

            }

            catch (Exception exM)

            {

                //Show if any error Occured

                MessageBox.Show("Error: " + exM.Message);

                status = false;

            }
        }

        private void bw2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (CheckUpdate() == true)
            {

                this.TopMost = true;


                //if(MessageBox.Show("Đã có phiên bản CMMS mới hơn, bạn có muốn cập nhật phiên bản mới không? ","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
                //{

                if(  MessageBox.Show("Đã có phiên bản CMMS mới hơn, bạn có muốn cập nhật phiên bản mới không?", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)==DialogResult.OK)
                {
                    foreach (Process P in System.Diagnostics.Process.GetProcessesByName("CMMS"))
                    {
                        P.Kill();
                    }
                    this.Show();
                    this.WindowState = FormWindowState.Normal;

                    lbDetail.Items.Add("Download File Update");
                    lbPT.Text = "0 %";
                    btnDownload.Enabled = false;
                    bgWorker1.RunWorkerAsync();

                   
                }

                
            }
            else
            {
                
                Application.ExitThread();
                Application.Exit();
            }

        }






        private void FRM_UPDATE_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            txtUrlUpdate.Text = Program.URL_UPDATE;

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            bw2.DoWork += new DoWorkEventHandler(bw2_DoWork);
            bw2.ProgressChanged += new ProgressChangedEventHandler(bw2_ProgressChanged);
            bw2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw2_RunWorkerCompleted);
            bw2.RunWorkerAsync();
            
        }

        private Boolean CheckUpdate()
        {
            if (Program.NOCHECK) return true;

            try
            {
                try
                {
                    lbDetail.BeginInvoke((Action)(() =>
                    {
                        lbDetail.Items.Add("Check Version");
                    }));
                }
                catch (Exception)
                {


                }
                string oldVersion = "201910080001";
                string newVersion = "201610080001";
                if (File.Exists(Application.StartupPath + @"\Version.txt"))
                {
                    if (File.Exists(Application.StartupPath + @"\Version1.txt"))
                    {
                        File.Delete(Application.StartupPath + @"\Version1.txt");
                    }
                    File.Copy(Application.StartupPath + @"\Version.txt", Application.StartupPath + @"\Version1.txt");

                    var path = Application.StartupPath + @"\Version1.txt";
                    var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        oldVersion = streamReader.ReadToEnd();
                        try
                        {
                            streamReader.Close();
                            streamReader.Dispose();
                        }
                        catch (Exception)
                        {


                        }

                    }
                    //oldVersion = File.ReadAllText(Application.StartupPath + @"\Version.txt").Trim();
                    File.Delete(Application.StartupPath + @"\Version1.txt");

                }
                if (File.Exists(Application.StartupPath + @"\Update\Version.txt"))
                {
                    if (File.Exists(Application.StartupPath + @"\Update\Version1.txt"))
                    {
                        File.Delete(Application.StartupPath + @"\Update\Version1.txt");
                    }
                    File.Copy(Application.StartupPath + @"\Update\Version.txt", Application.StartupPath + @"\Update\Version1.txt");

                    var path = Application.StartupPath + @"\Update\Version1.txt";
                    var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        newVersion = streamReader.ReadToEnd();
                        try
                        {
                            streamReader.Close();
                            streamReader.Dispose();
                        }
                        catch (Exception)
                        {


                        }
                    }
                    //newVersion = File.ReadAllText(Application.StartupPath + @"\Update\Version.txt").Trim();
                    File.Delete(Application.StartupPath + @"\Update\Version1.txt");
                }
                else
                {
                    newVersion = oldVersion;
                }
                if (newVersion == "")
                    newVersion = "201910080001";

                if (Convert.ToInt64(oldVersion) < Convert.ToInt64(newVersion))
                {
                    try
                    {
                        lbDetail.BeginInvoke((Action)(() =>
                        {
                            lbDetail.Items.Add("Update from Version [ " + oldVersion + "] to Version [ " + newVersion + " ]");
                        }));
                    }
                    catch (Exception)
                    {


                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }


        private void UpdateFile()
        {
            string file = Application.StartupPath + @"\Update\Update.zip";
            string unzipto = Application.StartupPath + @"\Update";
            try
            {
                lbDetail.BeginInvoke((Action)(() =>
                {
                    lbDetail.Items.Add("Unzip file [ " + file + "] to [ " + unzipto+" ]");
                }));
            }
            catch (Exception)
            {


            }
            
            unZip(file, unzipto);
            Random rd = new Random();
            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(11, 20);
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));
            //progressCopy.Text = "50";
            if (File.Exists(Application.StartupPath + @"\Update\Update.zip"))
            {
                //try
                //{
                //    listBox1.BeginInvoke((Action)(() =>
                //    {
                //        listBox1.Items.Add("Delete file [ " + Application.StartupPath + @"\Update\Update.zip" + " ]");
                //    }));
                //}
                //catch (Exception)
                //{


                //}
                
                File.Delete(Application.StartupPath + @"\Update\Update.zip");
            }
            string destination = Application.StartupPath + @"\Update";

            try
            {

                Program.FILE_DELETE = "";
                var fileStream = new FileStream(destination + @"\delete.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    Program.FILE_DELETE = streamReader.ReadToEnd();
                }
                if (Program.FILE_DELETE.Length > 0)
                {
                    DeleteFile();
                }
            }
            catch (Exception)
            {


            }

            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(21, 40);
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));
            string[] Dirs = Directory.GetDirectories(destination);
            foreach (string Dir in Dirs)
            {
                string[] pth = Dir.Split('\\');
                if (pth.Length > 0)
                {
                    string _path = Application.StartupPath + @"\" + pth[pth.Length - 1];
                    if (!Directory.Exists(_path))
                    {
                        try
                        {
                            lbDetail.BeginInvoke((Action)(() =>
                            {
                                lbDetail.Items.Add("Create folder [ " + _path + " ]");
                            }));
                        }
                        catch (Exception)
                        {


                        }

                        Directory.CreateDirectory(_path);
                    }
                    XulyCopyFile(_path, Dir);
                }

                progressBar2.BeginInvoke((Action)(() =>
                {
                    progressBar2.Value = rd.Next(41, 50);
                }));
                lbPT.BeginInvoke((Action)(() =>
                {
                    lbPT.Text = progressBar2.Value.ToString() + " %";
                }));
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
                            try
                            {
                                lbDetail.BeginInvoke((Action)(() =>
                                {
                                    lbDetail.Items.Add("Create folder [ " + _path10 + " ]");
                                }));
                            }
                            catch (Exception)
                            {


                            }
                            
                            Directory.CreateDirectory(_path10);
                        }
                        XulyCopyFile(_path10, Dir2);
                    }

                }

            }
            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(51, 60);
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));
            XulyCopyFile(Application.StartupPath, destination);
            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(71, 80); 
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));
            XulyDeleteFile(destination);
            progressBar2.BeginInvoke((Action)(() =>
            {
                progressBar2.Value = rd.Next(81, 99); ;
            }));
            lbPT.BeginInvoke((Action)(() =>
            {
                lbPT.Text = progressBar2.Value.ToString() + " %";
            }));

           
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
        public void XulyCopyFile(string sourcepath, string destination)
        {
            try
            {
                Random rd = new Random();
                progressBar2.BeginInvoke((Action)(() =>
                {
                    progressBar2.Value = rd.Next(61, 70);
                }));
                lbPT.BeginInvoke((Action)(() =>
                {
                    lbPT.Text = progressBar2.Value.ToString() + " %";
                }));
                string[] files = Directory.GetFiles(destination);
                foreach (string file in files)
                {

                    if (System.IO.Path.GetFileName(file) != "Update.exe" && System.IO.Path.GetFileName(file) != "Ionic.Zip.dll" && System.IO.Path.GetFileName(file) != "delete.txt")
                    {

                        if (System.IO.File.Exists(sourcepath + @"\" + System.IO.Path.GetFileName(file)))
                        {
                            //try
                            //{
                            //    listBox1.BeginInvoke((Action)(() =>
                            //    {
                            //        listBox1.Items.Add("Delete file [ " + sourcepath + @"\" + System.IO.Path.GetFileName(file) + " ]");
                            //    }));
                            //}
                            //catch (Exception)
                            //{


                            //}
                            
                            System.IO.File.Delete(sourcepath + @"\" + System.IO.Path.GetFileName(file));
                        }

                        try
                        {
                            lbDetail.BeginInvoke((Action)(() =>
                            {
                                lbDetail.Items.Add("Copy file [ " + file + "] to [ " + sourcepath + @"\" + System.IO.Path.GetFileName(file) + " ]");
                            }));
                        }
                        catch (Exception)
                        {

                           
                        }
                        
                        System.IO.File.Copy(file, sourcepath + @"\" + System.IO.Path.GetFileName(file), true);


                    }
                    else
                    {
                        if (System.IO.Path.GetFileName(file) == "Update.exe")
                        {
                            if (!Directory.Exists(Application.StartupPath + @"\Update"))
                            {
                                try
                                {
                                    lbDetail.BeginInvoke((Action)(() =>
                                    {
                                        lbDetail.Items.Add("Create folder [ " + Application.StartupPath + @"\Update" + " ]");
                                    }));
                                }
                                catch (Exception)
                                {


                                }

                                Directory.CreateDirectory(Application.StartupPath + @"\Update");
                            }
                            try
                            {
                                lbDetail.BeginInvoke((Action)(() =>
                                {
                                    lbDetail.Items.Add("Copy file [ " + file + "] to [ " + Application.StartupPath + @"\Update" + @"\" + System.IO.Path.GetFileName(file) + " ]");
                                }));
                            }
                            catch (Exception)
                            {

                                
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
                        try
                        {
                            lbDetail.BeginInvoke((Action)(() =>
                            {
                                lbDetail.Items.Add("Delete file [ " + file + " ]");
                            }));
                        }
                        catch (Exception)
                        {


                        }
                        
                        System.IO.File.Delete(file);
                    }
                    string[] Dirs2 = Directory.GetDirectories(Dir);
                    foreach (string Dir3 in Dirs2)
                    {
                        string[] f3 = Directory.GetFiles(Dir3);
                        foreach (string file in f3)
                        {
                            try
                            {
                                lbDetail.BeginInvoke((Action)(() =>
                                {
                                    lbDetail.Items.Add("Delete file [ " + file + " ]");
                                }));
                            }
                            catch (Exception)
                            {


                            }
                            
                            System.IO.File.Delete(file);
                        }
                        try
                        {
                            lbDetail.BeginInvoke((Action)(() =>
                            {
                                lbDetail.Items.Add("Delete folder [ " + Dir3 + " ]");
                            }));
                        }
                        catch (Exception)
                        {


                        }
                        
                        Directory.Delete(Dir3);
                    }
                    try
                    {
                        lbDetail.BeginInvoke((Action)(() =>
                        {
                            lbDetail.Items.Add("Delete folder [ " + Dir + " ]");
                        }));
                    }
                    catch (Exception)
                    {


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
                            try
                            {
                                lbDetail.BeginInvoke((Action)(() =>
                                {
                                    lbDetail.Items.Add("Delete file [ " + sourcepath + @"\" + System.IO.Path.GetFileName(file) + " ]");
                                }));
                            }
                            catch (Exception)
                            {


                            }
                            
                            System.IO.File.Delete(sourcepath + @"\" + System.IO.Path.GetFileName(file));
                        }

                    }
                }
                if (Directory.Exists(sourcepath))
                {
                    try
                    {
                        lbDetail.BeginInvoke((Action)(() =>
                        {
                            lbDetail.Items.Add("Delete folder [ " + sourcepath + " ]");
                        }));
                    }
                    catch (Exception)
                    {


                    }
                    
                    Directory.Delete(sourcepath);
                }
            }
            catch (Exception)
            {

            }

        }
        private void DeleteFile()
        {
            string destination = Application.StartupPath;
            string[] f50 = Directory.GetFiles(destination);
            foreach (string file50 in f50)
            {
                if (ExistsFile(file50) == true)
                {
                    try
                    {
                        //try
                        //{
                        //    listBox1.BeginInvoke((Action)(() =>
                        //    {
                        //        listBox1.Items.Add("Delete file [ " + file50 + " ]");
                        //    }));
                        //}
                        //catch (Exception)
                        //{


                        //}
                        
                        System.IO.File.Delete(file50);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

            }

            string[] Dirs = Directory.GetDirectories(destination);
            foreach (string Dir in Dirs)
            {

                string[] f = Directory.GetFiles(Dir);
                foreach (string file in f)
                {
                    if (ExistsFile(file) == true)
                    {
                        //try
                        //{
                        //    listBox1.BeginInvoke((Action)(() =>
                        //    {
                        //        listBox1.Items.Add("Delete file [ " + file + " ]");
                        //    }));
                        //}
                        //catch (Exception)
                        //{


                        //}
                        
                        System.IO.File.Delete(file);
                    }
                        
                }

                string[] pth = Dir.Split('\\');
                if (pth.Length > 0)
                {
                    string _path = Application.StartupPath + @"\" + pth[pth.Length - 1];
                    if (!Directory.Exists(_path))
                    {
                        string[] f1 = Directory.GetFiles(_path);
                        foreach (string file1 in f1)
                        {
                            if (ExistsFile(file1) == true)
                            {
                                //try
                                //{
                                //    listBox1.BeginInvoke((Action)(() =>
                                //    {
                                //        listBox1.Items.Add("Delete file [ " + file1 + " ]");
                                //    }));
                                //}
                                //catch (Exception)
                                //{


                                //}
                                
                                System.IO.File.Delete(file1);
                            }
                        }
                    }

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
                            string[] f10 = Directory.GetFiles(_path10);
                            foreach (string file10 in f10)
                            {
                                if (ExistsFile(file10) == true)
                                {
                                    //try
                                    //{
                                    //    listBox1.BeginInvoke((Action)(() =>
                                    //    {
                                    //        listBox1.Items.Add("Delete file [ " + file10 + " ]");
                                    //    }));
                                    //}
                                    //catch (Exception)
                                    //{


                                    //}
                                    
                                    System.IO.File.Delete(file10);
                                }
                            }
                        }

                    }

                }

            }
        }
        private Boolean ExistsFile(string filename)
        {
            try
            {
                string[] s = Program.FILE_DELETE.Split(';');
                if (s.Length > 0)
                {
                    for (Int32 i = 0; i < s.Length - 1; i++)
                    {
                        if (s[i].Trim() == System.IO.Path.GetFileName(filename))
                            return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private void FRM_UPDATE_FormClosed(object sender, FormClosedEventArgs e)
        {
            string destination = Application.StartupPath + @"\Update";
            XulyDeleteFile(destination);
            try
            {

                Program.FILE_DELETE = "";
                var fileStream = new FileStream(destination + @"\delete.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    Program.FILE_DELETE = streamReader.ReadToEnd();
                }
                if (Program.FILE_DELETE.Length > 0)
                {
                    DeleteFile();
                }
            }
            catch (Exception)
            {


            }
            if (File.Exists(destination + @"\delete.txt"))
            {
                File.Delete(destination + @"\delete.txt");
            }
        }

        private void btDetail_Click(object sender, EventArgs e)
        {
            txtUrlUpdate.Visible = false;
            if (lbDetail.Visible)
            {
                lbDetail.Visible = false;
                btDetail.Location = new Point(btDetail.Location.X, btDetail.Location.Y - 100);
                btnDownload .Location = new Point(btnDownload.Location.X, btnDownload.Location.Y - 100);
                btCancel.Location = new Point(btCancel.Location.X, btCancel.Location.Y - 100);
                this.Height = this.Height - 90;
            }
            else
            {
                lbDetail.Visible =true;
                btDetail.Location = new Point(btDetail.Location.X, btDetail.Location.Y + 100);
                btnDownload.Location = new Point(btnDownload.Location.X, btnDownload.Location.Y + 100);
                btCancel.Location = new Point(btCancel.Location.X, btCancel.Location.Y + 100);
                this.Height = this.Height + 90;
            }
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
