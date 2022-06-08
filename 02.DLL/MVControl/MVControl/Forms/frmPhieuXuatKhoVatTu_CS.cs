using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl.Forms
{
    public partial class frmPhieuXuatKhoVatTu_CS : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuXuatKhoVatTu_CS()
        {
            InitializeComponent();
        }
        #region load form
        private void frmPhieuXuatKhoVatTu_CS_Load(object sender, EventArgs e)
        {

        }
        private void EnableControl(bool chon)
        {
            txtGHI_CHU.Enabled = chon;
            dtpNGAY_CHUNG_TU.Enabled = chon;
            txtNGAY_CHUNG_TU.Enabled = chon;
            cboDANG_XUAT.Enabled = chon;
            cboLDXKT.Enabled = chon;
            txtSO_CHUNG_TU.Enabled = chon;
            cboNguoiNhan.Enabled = chon;
            btnNNhan.Enabled = chon;
            btnDVNhan.Enabled = chon;
            cboPhieuBaoTri.Enabled = chon;
            NONNbtnTimPBT.Enabled = chon;
            NONNbtnTimMay.Enabled = chon;
            txtSO_PHIEU_XUAT.Enabled = chon;
            txtGIO_NHAP.Enabled = false;
            dtpNGAY_NHAP.Enabled = false;
            txtLydoxuat.Enabled = chon;
            cbxCostCenter.Enabled = chon;
            txtCCu.Enabled = chon;
            txtTKho.Enabled = chon;
            txtNLap.Enabled = chon;
            cboKHO.Enabled = chon;
            cboMay.Enabled = chon;
            cboKHO_CHINH.Enabled = chon;
            cboDVNhan.Enabled = chon;
        }

        private void SetVisibleButton(bool Flag)
        {
            BtnTHEM.Visible = Flag;
            btnSUA.Visible = Flag;
            btnXOA.Visible = Flag;
            BtnIN.Visible = Flag;

            if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED" || Commons.Modules.sPrivate.ToUpper() == "VINHHOAN")
            {
                btnInDN.Visible = Flag;
            }

            else
            {
                btnInDN.Visible = false;
            }
        btnChon_Vat_Tu.Enabled = Not Flag And actionButton
        btnTHOAT_CT.Visible = Flag
        btnChon_Vat_Tu.Visible = Not Flag
        btnLockPhieuXuat.Visible = Flag
        btnGHI.Visible = Not Flag
        btnKHONG_GHI.Visible = Not Flag
        Panel1.Visible = False
        grdXuatkhoPTCT.ReadOnly = Flag
        txtFilter.Visible = Flag
        }
        #endregion

    }
}
