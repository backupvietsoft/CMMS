using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportMail.FormsTest
{
    public partial class frmMailChuaCoHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public frmMailChuaCoHoaDon()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(ucMailChuaCoHoaDon1, "ucMailChuaCoHoaDon");
        }
    }
}