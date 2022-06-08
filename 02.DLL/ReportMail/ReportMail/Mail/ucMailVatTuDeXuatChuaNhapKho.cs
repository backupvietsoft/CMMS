using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMail.Mail
{
    public partial class ucMailVatTuDeXuatChuaNhapKho : DevExpress.XtraEditors.XtraUserControl
    {
        csSchedules clsSchedules = new csSchedules();
        private string TenMBaoCao = "ucMailVatTuDeXuatChuaNhapKho";
        private string DK_BAOCAO;


        public ucMailVatTuDeXuatChuaNhapKho()
        {
            InitializeComponent();
        }
        private void ucMailVatTuDeXuatChuaNhapKho_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            TaoLuoi();
            LockControl(true);
            clsSchedules.LoadDuLieu(-1, TenMBaoCao, grdData, grvData);
            
        }

#region Control chuan form

        private void LockControl(Boolean Locked)
        {
            btnThem.Visible = Locked;
            btnSua.Visible = Locked;
            btnXoa.Visible = Locked;
            btnThoat.Visible = Locked;
            btnGhi.Visible = !Locked;
            btnKhong.Visible = !Locked;
            btnSchedules.Visible = !Locked;

            chkSau.Properties.ReadOnly = Locked;    //Enabled = !Locked;
            txtSNgay.Properties.ReadOnly = Locked;
            ucSentTo1.LockUnLock(!Locked);
            grdData.Enabled = Locked;
            cboPBan.Properties.ReadOnly = Locked;// Enabled = !Locked;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdBC.DataSource;
                dtTmp.Columns[0].ReadOnly = Locked;
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            ucSentTo1.MSetNew();


            txtID.Text = "-1";
            clsSchedules.setNull();
            cboPBan.EditValue = -1;
            txtSNgay.Text = "1";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (grvData.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongCoGiaTriSua", Commons.Modules.TypeLanguage));
                return;
            }
            txtID.Text = grvData.GetFocusedDataRow()["ID"].ToString();
            LockControl(false);
            if (grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() == "")
            {
                clsSchedules.setNull();
                return;
            }
            else
                clsSchedules._ID_SCHEDULES = Convert.ToInt16(grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString());

            clsSchedules.GetGTClass(clsSchedules._ID_SCHEDULES);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "CoMuonXoa",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (!clsSchedules.XoaSchedules(int.Parse(grvData.GetFocusedDataRow()["ID"].ToString()),
                int.Parse((grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() == "" ? "-1" :
                grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString())), TenMBaoCao))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "XoaKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }
            clsSchedules.LoadDuLieu(int.Parse(grvData.GetFocusedDataRow()["ID"].ToString()), TenMBaoCao, grdData, grvData);


        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            #region "KiemGhi"
            if (!ucSentTo1.KiemDL(int.Parse(txtID.Text))) return;
            if (txtSNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVatTuDeXuatChuaNhapKho", "ChuaNhapSoNgay", Commons.Modules.TypeLanguage));
                txtSNgay.Focus();
                return;
            }

            if (int.Parse(txtSNgay.Text) > 365)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVatTuDeXuatChuaNhapKho", "LonHonMotNam", Commons.Modules.TypeLanguage));
                txtSNgay.Focus();
                return;
            }
            #endregion

            int ID, iTongChon;
            string sLuoiChon;
            sLuoiChon = "";
            iTongChon = 0;
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdBC.DataSource).Copy();
            iTongChon = dtTmp.Rows.Count;
            dtTmp.DefaultView.RowFilter = " CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            if (iTongChon != dtTmp.Rows.Count)
            {
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    sLuoiChon += dtTmp.Rows[i][1].ToString() + "@";

                }
            }
            else sLuoiChon = "ALL";

            DK_BAOCAO = "";

            try
            {
                DK_BAOCAO = (chkSau.Checked ? "1," : "0,") + (txtSNgay.Text == "" ? "0" : txtSNgay.Text) + "," +
                    (cboPBan.EditValue.ToString() == "" ? "" : cboPBan.EditValue.ToString()) + ",";

            }
            catch { DK_BAOCAO = ""; }
            DK_BAOCAO = DK_BAOCAO + sLuoiChon;

            ID = Convert.ToInt32(txtID.Text);
            if (!clsSchedules.CapNhapSchedules(TenMBaoCao, ucSentTo1, DK_BAOCAO, ref ID))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));
                return;
            }
            clsSchedules.LoadDuLieu(ID, TenMBaoCao, grdData, grvData);
            LockControl(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            LoadText();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void LoadText()
        {
            try
            {

                if (grvData.RowCount <= 0)
                {
                    ucSentTo1.MSetNew();
                    txtID.Text = "-1";

                }
                else
                {
                    ucSentTo1.MGetData(grvData);
                    txtID.Text = grvData.GetFocusedDataRow()["ID"].ToString();
                    if (grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString() != "")
                    {
                        clsSchedules.GetGTClass(int.Parse(grvData.GetFocusedDataRow()["ID_SCHEDULES"].ToString()));
                        ucSentTo1.sSchedules = clsSchedules.DocDuLieu();
                    }
                    if (grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString() != "")
                    {
                        string sStmp;
                        sStmp = Convert.ToString(grvData.GetFocusedDataRow()["DK_BAOCAO"].ToString());
                        string[] chuoi_tach = sStmp.Split(new Char[] { ',' });


                        //
                        
                        if (chuoi_tach.GetValue(0).ToString().Trim() == "0") chkSau.Checked = false; else chkSau.Checked = true;
                        txtSNgay.Text = chuoi_tach.GetValue(1).ToString();
                        cboPBan.EditValue = chuoi_tach.GetValue(2).ToString();
                        sStmp = chuoi_tach.GetValue(3).ToString();

                        //TaoLuoi(sStmp);

                        DataTable dtTmp = new DataTable();
                        dtTmp = (DataTable)grdBC.DataSource;
                        dtTmp.Columns.Remove("CHON");
                        DataColumn cChon = new DataColumn("CHON");
                        cChon.DataType = System.Type.GetType("System.Boolean");
                        cChon.DefaultValue = 1;
                        dtTmp.Columns.Add(cChon);
                        cChon.SetOrdinal(0);

                        if (sStmp != "ALL")
                        {

                            DataRow[] drTmp = dtTmp.Select(" MS_KHO NOT IN ( " + sStmp.Replace("@", ",") + " ) ");
                            try
                            {
                                foreach (DataRow row in drTmp)
                                {
                                    row.SetField("CHON", "false");
                                }
                            }
                            catch { }

                        }
                        if (btnGhi.Visible) dtTmp.Columns[0].ReadOnly = false; else dtTmp.Columns[0].ReadOnly = true;
                        grdBC.DataSource = dtTmp;
                    }
                    else
                    {
                        chkSau.Checked = false;
                        txtSNgay.Text = "1";
                        cboPBan.EditValue = -1;
                    }
                }
            }
            catch
            {}
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedules frm = new frmSchedules();
            clsSchedules._Test = 1;
            try
            {
                frm.clsSchedules = clsSchedules;
            }
            catch { }
            DialogResult res = frm.ShowDialog();

            if (res.Equals(DialogResult.OK))
            {
                clsSchedules = frm.clsSchedules;
                ucSentTo1.sSchedules = clsSchedules.DocDuLieu();
            }
            else
            {
                clsSchedules._ID_SCHEDULES = Convert.ToInt16(clsSchedules._ID_SCHEDULES);
                return;
            }

        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText();
        }

        #endregion

        private void LoadPhongBan()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT DISTINCT PHONG_BAN AS MS , PHONG_BAN AS TEN FROM DE_XUAT_MUA_HANG " +
                        " UNION SELECT '-1' , ' < ALL > ' ORDER BY PHONG_BAN"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, dtTmp, "MS", "TEN", lblPBan.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaoLuoi()
        {

            DataTable dtTmp = new DataTable();
            string sSql;
            sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucVatTuDeXuatChuaNhapKho", "KhongTheoKho", Commons.Modules.TypeLanguage);

            sSql = " SELECT CONVERT(BIT,0) AS CHON, MS_KHO , TEN_KHO , CONVERT(NVARCHAR(100),MS_KHO) AS MS_KHO_TIM , TEN_KHO AS TEN_KHO_TIM " +
                        " FROM IC_KHO UNION SELECT CONVERT(BIT,0), -1 , '" + sSql + "', '' , 'ZZZZZZ' ORDER BY TEN_KHO_TIM ";

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, true, true, true);
            for (int i = 1; i < grvBC.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvBC.Columns["MS_KHO_TIM"].Visible = false;
            grvBC.Columns["TEN_KHO_TIM"].Visible = false;
            grvBC.Columns["MS_KHO"].Width = 200;
            grvBC.Columns["CHON"].Width = 100;

        }



    }
}
