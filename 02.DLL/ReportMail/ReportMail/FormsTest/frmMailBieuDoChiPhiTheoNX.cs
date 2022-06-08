using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportMail
{
    public partial class frmMailBieuDoChiPhiTheoNX : DevExpress.XtraEditors.XtraForm
    {
        public frmMailBieuDoChiPhiTheoNX()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(ucMailBieuDoChiPhiTheoNX1, "ucMailBieuDoChiPhiTheoNX");
        }

    }
}