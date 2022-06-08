using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMail
{
    public partial class frmSchedules : DevExpress.XtraEditors.XtraForm
    {
        string GoiMoi = "";
        string Ngay = "";
        string Tuan = "";
        string Thang = "";
        string VaoLuc = "";
        string VaoNgay = "";
        string Moi = "";
        string TrongKhoang = "";
        string Den = "";
        string BatDau = "";

        string Gio = "";
        string Phut = "";
        string Giay = "";


        string TuanThu1 = "";
        string TuanThu2 = "";
        string TuanThu3 = "";
        string TuanThu4 = "";

        string ThuHai = "";
        string ThuBa = "";
        string ThuTu = "";
        string ThuNam = "";
        string ThuSau = "";
        string ThuBay = "";
        string ChuNhat = "";
        
        public csSchedules clsSchedules ;

        private bool KiemDuLieu()
        {
            if (optNgayKT.Checked)
            {
                if (txtNgayBD.DateTime > txtNgayKT.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmSchedules", "NgayBDLonHonNgayKT", 
                        Commons.Modules.TypeLanguage));
                    txtNgayBD.Focus();
                    return false;
                }
            }
            if (txtNgayBD.Text.Trim() =="")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmSchedules", "ChuaNhapNgayBD",
                    Commons.Modules.TypeLanguage));
                txtNgayBD.Focus();
                return false;
            }
            return true;
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDuLieu()) return;
            int IDLuu = clsSchedules._ID_SCHEDULES;

            clsSchedules.setNull();
            clsSchedules._ID_SCHEDULES = IDLuu;

            clsSchedules._TEN_SCHEDULES = Convert.ToString(txtName.Text);

            if (optNgay.Checked)
            {
                clsSchedules._LOAI_SCHEDULES = 1;
                clsSchedules._GOI_MOI = int.Parse(txtSoNgay.Text);
                
            }

            if (optTuan.Checked)
            {
                clsSchedules._LOAI_SCHEDULES = 2;
                clsSchedules._GOI_MOI = int.Parse(txtGoiMoiTuan.Text);
                if (chkThu2.Checked) clsSchedules._THU_2 = true;
                if (chkThu3.Checked) clsSchedules._THU_3 = true;
                if (chkThu4.Checked) clsSchedules._THU_4 = true;
                if (chkThu5.Checked) clsSchedules._THU_5 = true;
                if (chkThu6.Checked) clsSchedules._THU_6 = true;
                if (chkThu7.Checked) clsSchedules._THU_7 = true;
                if (chkCN.Checked) clsSchedules._THU_CN = true;
            }

            if (optThang.Checked)
            {
                clsSchedules._LOAI_SCHEDULES = 3;
                if (optVaoNgay.Checked)
                {
                    clsSchedules._LOAI_THANG = 1;
                    clsSchedules._GOI_MOI = int.Parse(txtThang.Text);
                    clsSchedules._VAO_NGAY_THANG = Convert.ToInt16(txtVaoNgayThang.Text);
                }
                if (optVao.Checked)
                {
                    clsSchedules._LOAI_THANG = 2;
                    clsSchedules._LOAI_TUAN_THANG = Convert.ToInt16(cboGiaTri.EditValue);
                    clsSchedules._THU_TUAN_THANG = Convert.ToInt16(cboThu.EditValue);
                    clsSchedules._SO_THANG_THANG = Convert.ToInt16(txtSNgayThang.EditValue);
                }
            }

            if (optGoiVaoLuc.Checked)
            {
                clsSchedules._KIEU_GOI = 1;
                clsSchedules._GIO_GOI = Convert.ToDateTime(txtGoiVaoLuc.Text);
            }
            else
            {
                clsSchedules._KIEU_GOI = 2;
                clsSchedules._SO_GIO_GOI = Convert.ToInt16(txtGoiMoi.Text);
                clsSchedules._LOAI_TIME = Convert.ToInt16(cboEvent.EditValue);
                clsSchedules._TG_BD = Convert.ToDateTime(txtBDau.Text);
                clsSchedules._TG_KT = Convert.ToDateTime(txtKThuc.Text);
            }

            clsSchedules._TG_BD_HL = Convert.ToDateTime(txtNgayBD.Text);

            if (optNgayKT.Checked)
            {
                clsSchedules._LOAI_HIEU_LUC = 1;
                clsSchedules._TG_KT_HL = Convert.ToDateTime(txtNgayKT.Text);
            }
            else
                clsSchedules._LOAI_HIEU_LUC = 2;

            clsSchedules._TEN_SCHEDULES = Convert.ToString(txtName.Text);
            if (clsSchedules._ID_SCHEDULES == Convert.ToInt16(null)) clsSchedules._ID_SCHEDULES = -1;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadData(int IDMail)
        {
            if (clsSchedules._LOAI_SCHEDULES == 0)
            {
                LoadNgay();
                return;
            }

            txtName.Text = Convert.ToString(clsSchedules._TEN_SCHEDULES);

            if (clsSchedules._LOAI_SCHEDULES == 1)
            {
                optTuan.Checked = true;
                optNgay.Checked = true;
                txtSoNgay.Text = clsSchedules._GOI_MOI.ToString();
                LoadNgay();
            }

            if (clsSchedules._LOAI_SCHEDULES == 2)
            {
                optTuan.Checked = true;
                txtGoiMoiTuan.Text = clsSchedules._GOI_MOI.ToString();

                if (clsSchedules._THU_2) chkThu2.Checked = true;
                if (clsSchedules._THU_3) chkThu3.Checked = true;
                if (clsSchedules._THU_4) chkThu4.Checked = true;
                if (clsSchedules._THU_5) chkThu5.Checked = true;
                if (clsSchedules._THU_6) chkThu6.Checked = true;
                if (clsSchedules._THU_7) chkThu7.Checked = true;
                if (clsSchedules._THU_CN) chkCN.Checked = true;


                LoadTuan();
            }

            if (clsSchedules._LOAI_SCHEDULES == 3)
            {
                optThang.Checked = true;
                LoadThang();
                if (clsSchedules._LOAI_THANG == 1)
                {
                    optVaoNgay.Checked = true;
                    txtThang.Text = clsSchedules._GOI_MOI.ToString();
                    txtVaoNgayThang.Text = clsSchedules._VAO_NGAY_THANG.ToString();
                    LockThang(true);
                }
                if (clsSchedules._LOAI_THANG == 2)
                {
                    optVao.Checked = true;                    
                    LockThang(false);
                    cboGiaTri.EditValue = clsSchedules._LOAI_TUAN_THANG;
                    cboThu.EditValue = clsSchedules._THU_TUAN_THANG;
                    txtSNgayThang.EditValue = clsSchedules._SO_THANG_THANG.ToString();
                }
            }

            if (clsSchedules._KIEU_GOI == 1)
            {
                optGoiVaoLuc.Checked = true;
                LockGoiVaoLuc(false);
                txtGoiVaoLuc.Time = clsSchedules._GIO_GOI;
            }
            else
            {
                clsSchedules._KIEU_GOI = 2;
                optGoiMoi.Checked = true;
                LockGoiVaoLuc(true);
                txtGoiMoi.Text = clsSchedules._SO_GIO_GOI.ToString();
                cboEvent.EditValue = clsSchedules._LOAI_TIME;
                txtBDau.Time = clsSchedules._TG_BD;
                txtKThuc.Time = clsSchedules._TG_KT;
            }


            txtNgayBD.DateTime = clsSchedules._TG_BD_HL;
            if (clsSchedules._LOAI_HIEU_LUC == 1)
            {
                optNgayKT.Checked = true;
                txtNgayKT.DateTime = clsSchedules._TG_KT_HL;
            }
            else
            {
                optKhongNgayKT.Checked = true;
                txtNgayKT.Enabled = false;
            }

        }

        public frmSchedules()
        {
            InitializeComponent();
        }

        
        private void frmSchedules_Load(object sender, EventArgs e)
        {

            string sql;
            Gio = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "Gio", Commons.Modules.TypeLanguage);
            Phut = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "Phut", Commons.Modules.TypeLanguage);
            Giay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "Giay", Commons.Modules.TypeLanguage);

            TuanThu1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "TuanThu1", Commons.Modules.TypeLanguage);
            TuanThu2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "TuanThu2", Commons.Modules.TypeLanguage);
            TuanThu3 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "TuanThu3", Commons.Modules.TypeLanguage);
            TuanThu4 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "TuanThu4", Commons.Modules.TypeLanguage);

            ThuHai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuHai", Commons.Modules.TypeLanguage);
            ThuBa = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuBa", Commons.Modules.TypeLanguage);
            ThuTu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuTu", Commons.Modules.TypeLanguage);
            ThuNam = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuNam", Commons.Modules.TypeLanguage);
            ThuSau = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuSau", Commons.Modules.TypeLanguage);
            ThuBay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ThuBay", Commons.Modules.TypeLanguage);
            ChuNhat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ChuNhat", Commons.Modules.TypeLanguage);


            sql = "SELECT N'" + Gio + "' AS TEN , 1 AS MA UNION SELECT N'" + Phut + "' AS TEN  , 2 AS MA " +
                        " UNION SELECT N'" + Giay + "' AS TEN , 3 AS MA ORDER BY MA";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboEvent, sql, "MA", "TEN", "");

            sql = "SELECT N'" + TuanThu1 + "' AS TEN , 1 AS MA UNION SELECT N'" + TuanThu2 + "' AS TEN  , 2 AS MA " +
                        " UNION SELECT N'" + TuanThu3 + "' AS TEN , 3 AS MA UNION SELECT N'" + TuanThu4 + "' AS TEN  , 4 AS MA ORDER BY MA";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboGiaTri, sql, "MA", "TEN", "");

            sql = "SELECT N'" + ThuHai + "' AS TEN , 1 AS MA UNION SELECT N'" + ThuBa + "' AS TEN  , 2 AS MA " +
                        " UNION SELECT N'" + ThuTu + "' AS TEN , 3 AS MA UNION SELECT N'" + ThuNam + "' AS TEN  , 4 AS MA " +
                        " UNION SELECT N'" + ThuSau + "' AS TEN , 5 AS MA UNION SELECT N'" + ThuBay + "' AS TEN  , 6 AS MA " +
                        " UNION SELECT N'" + ChuNhat + "' AS TEN , 7 AS MA ORDER BY MA";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThu, sql, "MA", "TEN", "");
            
            LockGoiVaoLuc(false);

            GoiMoi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "Goivaomoi", Commons.Modules.TypeLanguage);
            Ngay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "ngay", Commons.Modules.TypeLanguage);
            Tuan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "tuan", Commons.Modules.TypeLanguage);
            Thang  = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "thang", Commons.Modules.TypeLanguage);
            VaoLuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "vaoluc", Commons.Modules.TypeLanguage);
            VaoNgay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "VaoNgay", Commons.Modules.TypeLanguage);

            Moi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "moi", Commons.Modules.TypeLanguage);
            TrongKhoang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "trongkhoang", Commons.Modules.TypeLanguage);

            Den = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "den", Commons.Modules.TypeLanguage);

            BatDau = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmSchedules", "BatDau", Commons.Modules.TypeLanguage);

            txtNgayKT.Enabled = false;
            txtNgayBD.DateTime = DateTime.Now;
            txtNgayKT.DateTime = DateTime.Now;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
            LoadData(clsSchedules._ID_SCHEDULES);
            DocDuLieu();            
        }

        private void LockGoiVaoLuc(Boolean sLock)
        {
            txtGoiVaoLuc.Enabled = !sLock;
            txtGoiMoi.Enabled = sLock;
            cboEvent.Enabled = sLock;
            txtBDau.Enabled = sLock;
            txtKThuc.Enabled = sLock;
        }

        private void LockNgay()
        {
            if (optNgay.Checked)
            {
                grpNgay.Enabled = true;
                grpTuan.Enabled = false;
                grpThang.Enabled = false;
            }
            if (optTuan.Checked)
            {
                grpNgay.Enabled = false;
                grpTuan.Enabled = true;
                grpThang.Enabled = false;
            }
            if (optThang.Checked)
            {
                grpNgay.Enabled = false;
                grpTuan.Enabled = false;
                grpThang.Enabled = true;
            }

        }

        private void optGoiVaoLuc_CheckedChanged(object sender, EventArgs e)
        {
            LockGoiVaoLuc(false);
            DocDuLieu();
        }

        private void optGoiMoi_CheckedChanged(object sender, EventArgs e)
        {
            LockGoiVaoLuc(true);
            DocDuLieu();
        }

        private void LoadNgay()
        {
            grpTuan.Visible = false;
            grpTuan.Dock = DockStyle.None;

            grpThang.Visible = false;
            grpThang.Dock = DockStyle.None;

            grpNgay.Visible = true;
            grpNgay.Dock = DockStyle.Fill;        
        }

        private void optNgay_CheckedChanged(object sender, EventArgs e)
        {

            LoadNgay();
            DocDuLieu();

        }

        private void LoadTuan()
        {
            grpNgay.Visible = false;
            grpNgay.Dock = DockStyle.None;

            grpThang.Visible = false;
            grpThang.Dock = DockStyle.None;
            
            grpTuan.Visible = true;
            grpTuan.Dock = DockStyle.Fill;
        }

        private void optTuan_CheckedChanged(object sender, EventArgs e)
        {
            LoadTuan();
            DocDuLieu();
        }

        private void LoadThang()
        {
            LockNgay();
            grpNgay.Visible = false;
            grpNgay.Dock = DockStyle.None;

            grpTuan.Visible = false;
            grpTuan.Dock = DockStyle.None;

            grpThang.Visible = true;
            grpThang.Dock = DockStyle.Fill;
        }
        private void optThang_CheckedChanged(object sender, EventArgs e)
        {
            LoadThang();
            DocDuLieu();
        }

        private void DocDuLieu()
        {
            string sTmp;
            string sTmp1;
            string sTmp2;
            sTmp1 = "";
            sTmp2 = "";
            sTmp = "";

            if (optGoiVaoLuc.Checked)
                sTmp1 = VaoLuc.ToLower() + " " + txtGoiVaoLuc.Text;
            else
            {
                if (Convert.ToInt16(txtGoiMoi.Text) == 1)
                    sTmp1 = Moi.ToLower() + " " + cboEvent.Text.ToLower() + " " + TrongKhoang + " " + txtBDau.Text + " " + Den + " " + txtKThuc.Text;
                else
                    sTmp1 = Moi.ToLower() + " " + txtGoiMoi.Text.ToLower() + " " + cboEvent.Text.ToLower() + " " + TrongKhoang + " " + txtBDau.Text + " " + Den + " " + txtKThuc.Text;
            }
            if (optNgay.Checked)
            {
                if (Convert.ToInt16(txtSoNgay.Text) == 1)
                    sTmp = GoiMoi + " " + Ngay.ToLower() + " " + sTmp1;
                else
                    sTmp = GoiMoi + " " + txtSoNgay.Text + " " + Ngay.ToLower() + " " + sTmp1;
            }
            if (optTuan.Checked)
            {

                if (!chkThu2.Checked && !chkThu3.Checked && !chkThu4.Checked && !chkThu5.Checked && !chkThu6.Checked && !chkThu7.Checked && !chkCN.Checked) 
                    if (Convert.ToInt16(txtGoiMoiTuan.Text) == 1)
                        sTmp = GoiMoi + " " + Tuan.ToLower() + " ";
                    else
                        sTmp = GoiMoi + " " + txtGoiMoiTuan.Text + " " + Tuan.ToLower() + " " ;
                else
                    if (Convert.ToInt16(txtGoiMoiTuan.Text) == 1)
                        sTmp = GoiMoi + " " + Tuan.ToLower() + " " + VaoNgay.ToLower() + " ";
                    else
                        sTmp = GoiMoi + " " + txtGoiMoiTuan.Text + " " + Tuan.ToLower() + " " + VaoNgay.ToLower() + " ";


                
                sTmp2 = ", ";
                if (chkThu2.Checked) sTmp2 = sTmp2 + chkThu2.Text + ", ";
                if (chkThu3.Checked) sTmp2 = sTmp2 + chkThu3.Text + ", ";
                if (chkThu4.Checked) sTmp2 = sTmp2 + chkThu4.Text + ", ";
                if (chkThu5.Checked) sTmp2 = sTmp2 + chkThu5.Text + ", ";
                if (chkThu6.Checked) sTmp2 = sTmp2 + chkThu6.Text + ", ";
                if (chkThu7.Checked) sTmp2 = sTmp2 + chkThu7.Text + ", ";
                if (chkCN.Checked) sTmp2 = sTmp2 + chkCN.Text + ", ";
                if (sTmp2.Length <= 2) sTmp2 = ""; else sTmp2 = sTmp2.Substring(2, sTmp2.Length - 4);


                sTmp = sTmp + sTmp2 + " " + sTmp1;
            }

            if (optThang.Checked)
            {
                if (optVaoNgay.Checked)
                {
                    if (Convert.ToInt16(txtThang.Text) == 1)
                        sTmp = GoiMoi + " " + Thang.ToLower() + " " + VaoNgay.ToLower() + " " + txtVaoNgayThang.Text;
                    else
                        sTmp = GoiMoi + " " + txtThang.Text + " " + Thang.ToLower() + " " + VaoNgay.ToLower() + " " + txtVaoNgayThang.Text;
                }
                else
                {
                    if (Convert.ToInt16(txtSNgayThang.Text) == 1)
                        sTmp = GoiMoi + " " + cboGiaTri.Text.ToLower() + " " + VaoNgay.ToLower() + " " + cboThu.Text.ToLower() + " " + Moi.ToLower() + " "  + Thang.ToLower();
                    else
                        sTmp = GoiMoi + " " + cboGiaTri.Text.ToLower() + " " + VaoNgay.ToLower() + " " + cboThu.Text.ToLower() + " " + Moi.ToLower() + " " + txtSNgayThang.Text + " " + Thang.ToLower();
                }
                sTmp = sTmp + " " + sTmp1;
            }

            if (optNgayKT.Checked)
                sTmp = sTmp + ". " + BatDau + " " + TrongKhoang.ToLower() + " " + txtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + Den.ToLower() + " " + txtNgayKT.DateTime.ToString("dd/MM/yyyy");
            else
                sTmp = sTmp + ". " + BatDau + " " + VaoNgay.ToLower() + " " + txtNgayBD.DateTime.ToString("dd/MM/yyyy");
            txtNote.Text = sTmp;
            LockNgay();

            clsSchedules.DocDuLieu();
        }

        private void txtSoNgay_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();

        }

        private void txtGoiVaoLuc_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();

        }

        private void txtGoiMoi_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();

        }

        private void cboEvent_EditValueChanged(object sender, EventArgs e)
        {
            
            switch ( int.Parse (cboEvent.EditValue.ToString()))
            {
                case 1:
                    txtGoiMoi.Properties.MaxValue = 24;
                    break;
                case 2:
                    txtGoiMoi.Properties.MaxValue = 60;
                    break;
                case 3:
                    txtGoiMoi.Properties.MaxValue = 60;
                    break;
            }                    

            DocDuLieu();

        }

        private void txtBDau_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();

        }

        private void txtKThuc_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();

        }

        private void optNgayKT_CheckedChanged(object sender, EventArgs e)
        {
            txtNgayKT.Enabled = true;
            DocDuLieu();
        }

        private void optKhongNgayKT_CheckedChanged(object sender, EventArgs e)
        {
            txtNgayKT.Enabled = false;
            DocDuLieu();
        }

        private void txtNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();
        }

        private void txtNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            DocDuLieu();
        }

        private void chkThu2_CheckedChanged(object sender, EventArgs e)
        {
            DocDuLieu();
        }

        private void optVaoNgay_CheckedChanged(object sender, EventArgs e)
        {
            LockThang(true);
        }
        private void optThang1_CheckedChanged(object sender, EventArgs e)
        {
            LockThang(false);
        }

        private void LockThang(Boolean sLock)
        {
            txtVaoNgayThang.Enabled = sLock;
            txtThang.Enabled = sLock;

            cboGiaTri.Enabled = !sLock;
            cboThu.Enabled = !sLock;
            txtSNgayThang.Enabled = !sLock;
            DocDuLieu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        

    }
}