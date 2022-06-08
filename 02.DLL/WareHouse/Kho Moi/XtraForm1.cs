using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace WareHouse.Forms
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spInLichSuThietBi", "-1", "01/01/2000", "01/01/2022"));

            ucInLSTB myUc = new ucInLSTB(DateTime.Parse("01/01/2000"), DateTime.Parse("01/01/2002"), "-1","ten may", dt);
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            myUc.InReport();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        
    }
}