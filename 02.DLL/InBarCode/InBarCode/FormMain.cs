using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Microsoft.ApplicationBlocks.Data;

namespace InBarCode
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1((DataTable)grdMay.DataSource, "Code39");
            report.ShowPreview();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            //load data
            //string connect = @"Data Source=.\sql2008;Initial Catalog=CMMS_REMINGTON;Persist Security Info=True;User ID=sa;PassWord =123";
            //string connect = @"Data Source=.;Initial Catalog=CMMS_REMINGTON;Persist Security Info=True;User ID=sa;PassWord =123";
            string connect = @"Data Source=192.168.2.27\SQL2017;Initial Catalog=CMMS_REMINGTON;Persist Security Info=True;User ID=sa;PassWord =123";
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(connect,CommandType.Text, " SELECT CONVERT(BIT,1) AS CHON,MS_MAY,TEN_MAY FROM dbo.MAY ORDER BY MS_MAY "));
            grdMay.DataSource = dt;
            grvMay.Columns["CHON"].Visible = false;
            grvMay.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvMay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvMay.OptionsSelection.CheckBoxSelectorField = "CHON";
        }
    }
}