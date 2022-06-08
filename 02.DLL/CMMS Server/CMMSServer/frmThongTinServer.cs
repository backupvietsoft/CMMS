using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

namespace CmmsServer
{
    public partial class frmThongTinServer : Form
    {
        public frmThongTinServer()
        {
            InitializeComponent();
        }
        private void frmThongTinServer_Load(object sender, EventArgs e)
        {

            if (File.Exists(Application.StartupPath + @"\VSConfig.ini"))
            {
                StreamReader sFileInclude = System.IO.File.OpenText(Application.StartupPath + "\\VSConfig.ini");
                string sRowStream = "";
                sRowStream = sFileInclude.ReadToEnd();
                sRowStream = GiaiMaDL(sRowStream);
                string[] sArr = sRowStream.Split(new Char[] { '!' });
                Commons.IConnections.Server = sArr.GetValue(0).ToString();
                Commons.IConnections.Database = sArr.GetValue(1).ToString();
                Commons.IConnections.Username = sArr.GetValue(2).ToString();
                Commons.IConnections.Password = sArr.GetValue(3).ToString();
            }
            else
            {
                MessageBox.Show("Failed to connect to server!");
            }
            LoadDuLieu();


        }
        private static string GiaiMaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
            {
                sTam += Microsoft.VisualBasic.Strings.ChrW((Microsoft.VisualBasic.Strings.AscW(Microsoft.VisualBasic.Strings.Mid(str, i, 1)) / 2) - 354).ToString();
            }
            return sTam;
        }
        private void LoadDuLieu()
        {
            string Sql = "";
            Sql = "SELECT ISNULL([SERVER_NAME],''),ISNULL([LOGIN_NAME],''),ISNULL([PASS_NAME],''),ISNULL([TIMER1],1), " +
                             " ISNULL([TIMER2],1), ISNULL([DATA_NAME],'')  FROM THONG_TIN_CHUNG";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            txtSer.Text = dtTmp.Rows[0][0].ToString();
            txtLog.Text = dtTmp.Rows[0][1].ToString();
            txtPass.Text = dtTmp.Rows[0][2].ToString();
            txtTimer1.Text = dtTmp.Rows[0][3].ToString();
            txtTimer2.Text = dtTmp.Rows[0][4].ToString();
            txtData.Text = dtTmp.Rows[0][5].ToString();
        }
        private void GhiDuLieu()
        {
            try
            {
                string Sql = "";
                Sql = " UPDATE THONG_TIN_CHUNG SET SERVER_NAME = N'" + txtSer.Text + "' , LOGIN_NAME = N'" + txtLog.Text + "' , PASS_NAME = N'" + txtPass.Text + "' , " +
                            " DATA_NAME = N'" + txtData.Text + "' , TIMER1 = " + (txtTimer1.Text.Trim() == "" ? "1" : txtTimer1.Text) + " , TIMER2 = " + (txtTimer2.Text.Trim() == "" ? "1" : txtTimer2.Text);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!TestData()) return;
            GhiDuLieu();
        }

        private bool TestData()
        {
            if (txtSer.Text.Trim() == "")
            {
                MessageBox.Show("Please input server name");
                return false;
            }
            if (txtLog.Text.Trim() == "")
            {
                MessageBox.Show("Please input login name");
                return false;
            }
            if (txtData.Text.Trim() == "")
            {
                MessageBox.Show("Please input databases name");
                return false;
            }
            
            return true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!TestData()) return;
            string myConnString = "";
            myConnString = "Server=" + txtSer.Text + ";database=" + txtData.Text + ";uid=" + txtLog.Text + ";pwd=" + txtPass.Text + ";Connect Timeout=0;";

            System.Data.SqlClient.SqlConnection myConnection = new System.Data.SqlClient.SqlConnection(myConnString);
            try
            {
                myConnection.Open();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                myConnection.Dispose();
                return;
            }
            myConnection.Dispose();
            MessageBox.Show("TESTS COMPLETED SUCCESSFULLY!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
