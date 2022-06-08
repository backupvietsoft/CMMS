using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmCapNhatNgayHoanThanh : XtraForm
    {
        public DataTable dt;
        public DateTime msNgayHoanThanh;
        public int check = 0; //0 current, 1 update cái nào NULL, 2 all
        public int iNgayCuoi = 0; //0 Khong Cap nhat vao ngay cuoi, = 1 Cap nhat vao ngay cuoi
        public frmCapNhatNgayHoanThanh()
        {
            InitializeComponent();

    
        }


        private void RadioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioGroup2.SelectedIndex == 0)
            {
                this.Controls.Remove(this.dpDateTime);
                this.Controls.Add(this.cboDateTime);
            }
            else
            {
                this.Controls.Remove(this.cboDateTime);
                this.Controls.Add(this.dpDateTime);
                dpDateTime.DateTime = DateTime.Now;
            }

        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {

            if (RadioGroup2.SelectedIndex == 0)
            {
                if (dt.Rows.Count == 0)
                {
                    msNgayHoanThanh = Convert.ToDateTime("1900/01/01");
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "msgChuaNhapThoiGianNhanSu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else msNgayHoanThanh = Convert.ToDateTime(cboDateTime.EditValue);
            }

            else
            {
                msNgayHoanThanh = dpDateTime.DateTime.Date;
            }
            check = RadioGroup1.SelectedIndex == 0 ? 0 : RadioGroup1.SelectedIndex == 1 ? 1 : 2;
            iNgayCuoi = lblNgayCNBDKH.Checked == true ? 1 : 0;
            this.DialogResult = DialogResult.OK;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            msNgayHoanThanh = Convert.ToDateTime("1900/01/01");
            this.DialogResult = DialogResult.No;
        }

        private void frmCapNhatNgayHoanThanh_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDateTime, dt, "DEN_NGAY", "DEN_NGAY", "");
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch { }
        }
    }
}
