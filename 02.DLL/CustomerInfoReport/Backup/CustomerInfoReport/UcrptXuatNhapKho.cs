using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace CustomerInfoReport
{
    public partial class UcrptXuatNhapKho : UserControl
    {
        public UcrptXuatNhapKho()
        {
            InitializeComponent();
        }
        private string Conn
        {
            get
            {
                string s = Vietsoft.Information.ConnectionString;
                //s = @"Data Source=Lenovo-pc\sqlexpress;Initial Catalog=CMMS;User ID=sa;Pwd=123";
                return s;
            }
        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            ListStockReport obj = new ListStockReport();
            if (!string.IsNullOrEmpty(Convert.ToString(cmbStock.SelectedValue)))
            {
                if (Convert.ToDateTime(dtToDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtFromDate.Value.ToShortDateString()))
                {
                    obj.stockid = Convert.ToInt32(cmbStock.SelectedValue);
                    obj.fromdate = dtFromDate.Value;
                    obj.todate = dtToDate.Value;
                    obj.stockName = cmbStock.Text;
                    obj.date = lblFromDate.Text + " " + dtFromDate.Text  + " " + lblToDate.Text + " " + dtToDate.Text ;
                    obj.kho = lblStock.Text + " " + cmbStock.Text;
                    obj.ShowDialog();
                }
                else
                {
                    MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListStockReport", "DateError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtToDate.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListStockReport", "StockIdnovalid", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStock.Focus();
                return;
            }
           
        }
        
        private void UcrptXuatNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select ms_kho,ten_kho from ic_kho union select -1,'All'";
                dt.Load(SqlHelper.ExecuteReader(Conn,CommandType.Text,sql));
                cmbStock.DataSource = dt;
                cmbStock.DisplayMember = "TEN_KHO";
                cmbStock.ValueMember = "MS_KHO";

                dtFromDate.Text = "01/01/" + DateTime.Now.Year;
                dtToDate.Text = "31/12/" + DateTime.Now.Year;
            }
            catch {
            
            }

        }
    }
}
