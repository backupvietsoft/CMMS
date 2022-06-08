using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReportManager
{
    public partial class frmDanhmucBaocao : Form
    {
        public frmDanhmucBaocao()
        {
            InitializeComponent();
        }

        private void frmDanhmucBaocao_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
    }
}
