using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ExportExcels
{
    public partial class frmHinh : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource _bdSP;
        public BindingSource bdSP
        {
            get
            {
                return _bdSP;
            }
            set
            {
                _bdSP = value;
            }
        }
        private DataTable _table = new DataTable();
        public DataTable _TableSource
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }
        public frmHinh()
        {
            InitializeComponent();
        }

        private void frmHinh_Load(object sender, EventArgs e)
        {
            imgHinh.DataBindings.Clear();
            imgHinh.DataBindings.Add("Image", bdSP, "HINH", true);

        }

    }
}