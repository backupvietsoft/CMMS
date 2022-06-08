using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using ReportMail.Mail;

namespace ReportMail
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }


        private void XtraForm1_Load(object sender, EventArgs e)
        {            
            ucMailNhapXuatTon myUc = new ucMailNhapXuatTon();
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

     
    }
}