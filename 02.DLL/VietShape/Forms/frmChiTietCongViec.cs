using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmChiTietCongViec : DevExpress.XtraEditors.XtraForm
    {
        public string sTenCV { get; set; }
        public string sThaoTac { get; set; }
        public string sTieuChuan { get; set; }
        public string sYeuCauNS { get; set; }
        public string sYeuCauDC { get; set; }        
        public string sTaiLieu { get; set; }
        public Boolean bView { get; set; } = false;

        public frmChiTietCongViec()
        {
            InitializeComponent();
        }

        private void frmChiTietCongViec_Load(object sender, EventArgs e)
        {            
            txtThaoTac.Text = sThaoTac;
            txtTieuChuan.Text = sTieuChuan;
            txtYeuCauNS.Text = sYeuCauNS;
            txtYeuCauDC.Text = sYeuCauDC;
            txtTaiLieu.Text = sTaiLieu;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblTenCV.Text = sTenCV;
            if (bView)
            {
                tableLayoutPanel1.Controls.Remove(btnUpDate); //Controls.Remove(btnUpDate);
                txtThaoTac.Properties.ReadOnly = true;
                txtTieuChuan.Properties.ReadOnly = true;
                txtYeuCauNS.Properties.ReadOnly = true;
                txtYeuCauDC.Properties.ReadOnly = true;
                txtTaiLieu.Properties.ReadOnly = true;
            }

        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            sThaoTac = txtThaoTac.Text;
            sTieuChuan = txtTieuChuan.Text;
            sYeuCauNS = txtYeuCauNS.Text;
            sYeuCauDC = txtYeuCauDC.Text;
            sTaiLieu = txtTaiLieu.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtTaiLieu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (bView)
                {
                    if (txtTaiLieu.Text == "") return;
                    System.Diagnostics.Process.Start(txtTaiLieu.Text);
                }
                else
                {
                    OpenFileDialog opendialog = new OpenFileDialog();
                    opendialog.Multiselect = false;
                    if (opendialog.ShowDialog() != DialogResult.OK) return;
                    txtTaiLieu.Text = opendialog.FileName;
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
