using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace H2Tool
{
    public partial class frmConnectData : Form
    {
        public frmConnectData()
        {
            InitializeComponent();
        }
        private bool checkField()
        {
            if (txtServer.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập thông tin server");
                return false;
            }
            if (txtUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập thông tin user");
                return false;
            }
            if (txtpass.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập thông tin pass");
                return false;
            }
            if (txtDatabase.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập thông tin database name");
                return false;
            }
            return true;
        }

        private DataTable datasource = new DataTable();
        private void Init()
        {
            datasource = new DataTable();
            datasource.Columns.Add("Server", Type.GetType("System.String"));
            datasource.Columns.Add("User", Type.GetType("System.String"));
            datasource.Columns.Add("Pass", Type.GetType("System.String"));
            datasource.Columns.Add("Database", Type.GetType("System.String"));
        }


        private void LoadInfo()
        {
            if (File.Exists(Application.StartupPath + "\\IntegrationInfo.xml"))
            {
                DataSet _dsDatasource = new DataSet();
                _dsDatasource.ReadXml(Application.StartupPath + "\\IntegrationInfo.xml");
                datasource = _dsDatasource.Tables[0];
                if (datasource.Rows.Count > 0)
                {
                    txtServer.Text = datasource.Rows[0]["Server"].ToString();
                    txtUser.Text = datasource.Rows[0]["User"].ToString();
                    txtpass.Text = clsCommon.VSDecode(datasource.Rows[0]["Pass"].ToString());
                    txtDatabase.Text = datasource.Rows[0]["Database"].ToString();
                }
                else
                {
                    txtServer.Text = "";
                    txtUser.Text = "";
                    txtpass.Text = "";
                    txtDatabase.Text = "";
                }
            }
            else
            {
                txtServer.Text = "";
                txtUser.Text = "";
                txtpass.Text = "";
                txtDatabase.Text = "";
            }
        }
        private bool WriteInfo()
        {
            Init();

            datasource.Rows.Clear();
            datasource.Rows.Add(txtServer.Text.Trim(), txtUser.Text.Trim(),clsCommon.VSEncode( txtpass.Text.Trim()), txtDatabase.Text.Trim());

            DataSet _dsDatasource = new DataSet();
            _dsDatasource.Tables.Add(datasource.Copy());
            _dsDatasource.WriteXml(Application.StartupPath + "\\IntegrationInfo.xml");

            return true;
        }

        private bool CheckConnection()
        {
            string connectionString = "Server=" + txtServer.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";User Id=" + txtUser.Text.Trim() + ";Password=" + txtpass.Text.Trim() + "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    // not really necessary
                    connection.Close();
                }
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (checkField())
            {
                if (CheckConnection())
                {
                    MessageBox.Show("Kết nối thành công");
                }
                else
                {
                    MessageBox.Show("Kết nối không thành công");
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkField())
            {
                if (CheckConnection())
                {
                    if (WriteInfo())
                        this.Close();
                    else
                        MessageBox.Show("Có lỗi trong quá trình ghi file. vui long kiểm tra lại phần quyền của window");
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConnectData_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }
    }
}
