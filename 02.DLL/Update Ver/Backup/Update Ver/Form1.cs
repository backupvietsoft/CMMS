using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Update_Ver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        public string LayDuLieu( string sFile)
        {
            string sText = "";
            StreamReader sr;
            try 
            {
                sText = Application.StartupPath.ToString() + "\\" + sFile;
                sr = new StreamReader(sText);
                sText = "";
                sText = sr.ReadLine();
                sr.Close();
            }
            catch { sText = ""; }
            return sText ;
        }

        private void SetDuLieu(string sFile, string sGhi)
        {
            StreamWriter sW;
            string sText = "";
            try
            {
                sText = Application.StartupPath.ToString() + "\\" + sFile;
                sW = new StreamWriter(sText);
                sW.WriteLine(sGhi);
                sW.Close();
            }
            catch {}
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = LayDuLieu("Version.txt");
            textBox2.Text = LayDuLieu("Server.txt");
            FileInfo fInfo = new FileInfo(Application.StartupPath.ToString() + "\\CMMS.exe");
            if (!fInfo.Exists)
                return;

            string sText = "";
            sText = fInfo.LastWriteTime.ToString("yyyyMMddHHmm");
            textBox3.Text = sText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fInfo = new FileInfo(Application.StartupPath.ToString() + "\\CMMS.exe");
                string sText = "";
                textBox3.Text = "";
                if (!fInfo.Exists)
                {
                    MessageBox.Show("File does not exist");
                    return;
                }
                sText = fInfo.LastWriteTime.ToString("yyyyMMddHHmm");
                textBox3.Text = sText;
                SetDuLieu("Version.txt", sText);
                textBox1.Text = LayDuLieu("Version.txt");
                MessageBox.Show("Update Version ok");
            }
            catch { MessageBox.Show("Update Version error"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Please input IP Server");
                    return;
                }
                SetDuLieu("Server.txt", textBox2.Text);
                MessageBox.Show("Update IP Server ok");
            }
            catch { MessageBox.Show("Update IP Server error"); }
        }
    }
}
