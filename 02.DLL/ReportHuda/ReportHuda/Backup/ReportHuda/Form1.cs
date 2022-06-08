using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportHuda
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReportHuda.NMN_TD.UCXuatNhapTon_TD myUc = new ReportHuda.NMN_TD.UCXuatNhapTon_TD();
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s= Commons.Modules.MMail.MSendEmailNotAttachment("mashinhat@gmail.com;nvhien@vietsoft.com.vn", Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, "asa", "asdas",
                    Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort);
            }
            catch { }
        }

        

      

    }
}