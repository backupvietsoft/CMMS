using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace H2Tool
{
    public partial class frmScheduler : Form
    {

        public frmScheduler()
        {
            InitializeComponent();
        }
        private DataTable datasource = new DataTable();
        private void Init()
        {
            datasource = new DataTable();
            datasource.Columns.Add("SType", Type.GetType("System.String"));
            datasource.Columns.Add("SType1Number", Type.GetType("System.String"));
            datasource.Columns.Add("SType1Option", Type.GetType("System.String"));
            datasource.Columns.Add("SType2Hours", Type.GetType("System.String"));
            datasource.Columns.Add("SType2Minutes", Type.GetType("System.String"));
        }

        private bool SetValues()
        {
            string _SType = "1";
            string _SType1Number = "5";
            string _SType1Option = "1";
            string _SType2Hours = "18";
            string _SType2Minutes = "00";

            if (radioButton1.Checked == true)
                _SType = "1";
            else
                _SType = "2";

            if (radioButton3.Checked == true)
                _SType1Option = "1";
            else
                _SType1Option = "2";

            int tmpNumber = 0;
            if (_SType == "1") // theo Inteval
            {
                if (int.TryParse(maskedTextBox1.Text.Trim(), out tmpNumber))
                {
                    if (_SType1Option == "1")
                        if (tmpNumber <= 0 || tmpNumber >= 60)
                        {
                            MessageBox.Show("Bạn phải nhập số phút lớn hơn 0 và nhỏ hơn 60");
                            return false;
                        }
                    if (_SType1Option == "2")
                        if (tmpNumber <= 0 || tmpNumber >= 24)
                        {
                            MessageBox.Show("Bạn phải nhập số giờ lớn hơn 0 và nhỏ hơn 24");
                            return false;
                        }

                    _SType1Number = maskedTextBox1.Text.Trim();
                }
                else
                {
                    if (_SType1Option == "1")
                        MessageBox.Show("Bạn phải nhập số phút lớn hơn 0 và nhỏ hơn 60");
                    if (_SType1Option == "2")
                        MessageBox.Show("Bạn phải nhập số giờ lớn hơn 0 và nhỏ hơn 24");
                    return false;
                }
                _SType2Hours = "18";
                _SType2Minutes = "00";

            }
            else
            {
                string _tmpTime = maskedTextBox2.Text.Replace(":", "").Trim();

                if (_tmpTime == "")
                {
                    MessageBox.Show("Bạn phải nhập thời gian theo định dạnh(hh:mm)");
                    return false;
                }
                else
                {
                    string[] _tmpTimeArr = maskedTextBox2.Text.Trim().Split(':');
                    if (_tmpTimeArr.Length != 2)
                    {
                        MessageBox.Show("Bạn phải nhập thời gian theo định dạnh(hh:mm)");
                        return false;
                    }
                    int tmphour;
                    int tmpminute;
                    if (int.TryParse(_tmpTimeArr[0], out tmphour))
                    {
                        if (tmphour < 0 || tmphour >= 24)
                        {
                            MessageBox.Show("Giờ phải lớn hơn bằng 0 và nhỏ hơn 24 giờ");
                            return false;
                        }
                        _SType2Hours = "00" + tmphour.ToString();
                        _SType2Hours = _SType2Hours.Substring(_SType2Hours.Length - 2, 2);
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập thời gian theo định dạnh(hh:mm)");
                        return false;
                    }

                    if (int.TryParse(_tmpTimeArr[1], out tmpminute))
                    {
                        if (tmpminute < 0 || tmpminute >= 60)
                        {
                            MessageBox.Show("Phút phải lớn hơn bằng 0 và nhỏ hơn bằng 59 phút");
                            return false;
                        }
                        _SType2Minutes = "00" + tmpminute.ToString();
                        _SType2Minutes = _SType2Minutes.Substring(_SType2Minutes.Length - 2, 2);
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập thời gian theo định dạnh(hh:mm)");
                        return false;
                    }

                }




                _SType1Number = "5";
                _SType1Option = "1";
            }

           
            if (datasource.Rows.Count > 0)
            {
                if (_SType == "1")
                {
                    datasource.Rows[0]["SType"] = "1";
                    datasource.Rows[0]["SType1Number"] = _SType1Number;
                    datasource.Rows[0]["SType1Option"] = _SType1Option;
                }
                else
                {
                    datasource.Rows[0]["SType"] = "2";
                    datasource.Rows[0]["SType2Hours"] = _SType2Hours;
                    datasource.Rows[0]["SType2Minutes"] = _SType2Minutes;
                }
            }
            else
            {
               datasource.Rows.Add("1", "5", "1", "18", "00");
            }
            // DataSet _dsDatasource = new DataSet();
            //_dsDatasource.Tables.Add(datasource);
            //_dsDatasource.WriteXml(Application.StartupPath + "\\Scheduler.xml");

            return true;
        }
        private bool GetValues()
        {
            DataSet _dsDatasource = new DataSet();
            if (File.Exists(Application.StartupPath + "\\Scheduler.xml"))
            {
                _dsDatasource.ReadXml(Application.StartupPath + "\\Scheduler.xml");
                datasource = _dsDatasource.Tables[0];
                if (datasource.Rows.Count > 0)
                {
                    if (datasource.Rows[0]["SType"].ToString() == "1")
                    {
                        radioButton1.Checked = true;
                        maskedTextBox1.Text = datasource.Rows[0]["SType1Number"].ToString();
                        if (datasource.Rows[0]["SType1Option"].ToString() == "1")
                            radioButton3.Checked = true;
                        else
                            radioButton4.Checked = true;

                        maskedTextBox2.Text = datasource.Rows[0]["SType2Hours"].ToString() + datasource.Rows[0]["SType2Minutes"].ToString();
                    }
                    else
                    {
                        radioButton2.Checked = true;
                        maskedTextBox1.Text = datasource.Rows[0]["SType1Number"].ToString();
                        if (datasource.Rows[0]["SType1Option"].ToString() == "1")
                            radioButton3.Checked = true;
                        else
                            radioButton4.Checked = true;
                        maskedTextBox2.Text = datasource.Rows[0]["SType2Hours"].ToString() + datasource.Rows[0]["SType2Minutes"].ToString();
                    }
                }


            }
            else
                Init();

            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet _dsDatasource = new DataSet();
                if (SetValues())
                {
                    _dsDatasource.Tables.Add(datasource.Copy());
                    _dsDatasource.WriteXml(Application.StartupPath + "\\Scheduler.xml");
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduler_Load(object sender, EventArgs e)
        {
            GetValues();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
    }
}
