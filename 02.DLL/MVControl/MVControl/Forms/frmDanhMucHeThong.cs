using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Data.SqlClient;
using DevExpress.XtraEditors.DXErrorProvider;

namespace MVControl
{
    public partial class frmDanhMucHeThong : DevExpress.XtraEditors.XtraForm
    {
        System.Collections.Generic.List<string> arrTim = new System.Collections.Generic.List<string>();

        public frmDanhMucHeThong()
        {
            InitializeComponent();
        }

        private void frmLoaiBaoTri_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles[0].Width = 0;
            tableLayoutPanel1.ColumnStyles[tableLayoutPanel1.ColumnCount - 1].Width = 0;
            KhoaText(true);
            TaoTree(-1);
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }

        private void TaoTree(int iMS_HE_THONG)
        {
            tvwHThong.DataSource = null;
            DataTable dtTmp = new DataTable();
            tvwHThong.BeginUpdate();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHE_THONGs", Commons.Modules.UserName));
            //dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_HE_THONG"] };



            tvwHThong.KeyFieldName = "MS_HE_THONG";
            tvwHThong.ParentFieldName = "MS_CHA";
            tvwHThong.OptionsBehavior.Editable = false;
            tvwHThong.DataSource = dtTmp;

            
            tvwHThong.PopulateColumns();

            for (int i = 0; i <= tvwHThong.Columns.Count -1; i++)
            {
                tvwHThong.Columns[i].Visible = false;
            }
            string sTenHT;
            if (Commons.Modules.TypeLanguage == 0)
                sTenHT = "TEN_HE_THONG";
            else
            {
                if (Commons.Modules.TypeLanguage == 1)
                    sTenHT = "TEN_HE_THONG_ANH";
                else
                    sTenHT = "TEN_HE_THONG_HOA";
            }

            tvwHThong.Columns[sTenHT].Visible = true;
            tvwHThong.Columns[sTenHT].BestFit();
            tvwHThong.Columns[sTenHT].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "LblTenHT", Commons.Modules.TypeLanguage);

            tvwHThong.ExpandAll();
            tvwHThong.EndUpdate();
            try
            {

                if (iMS_HE_THONG != -1)
                {
                    tvwHThong.FocusedNode = tvwHThong.FindNodeByFieldValue("MS_HE_THONG", iMS_HE_THONG);
                }
                else
                {
                    tvwHThong.FocusedNode = tvwHThong.FindNodeByFieldValue("MS_HE_THONG", dtTmp.Rows[1][0]);
                }
                if (txtMS_CHA.Text != tvwHThong.FocusedNode["MS_CHA"].ToString())
                    LoadText();
            }
            catch { TextTrong(); }

            
        }
        private void TextTrong()
        {
            txtMS_HE_THONG.Text = "";
            txtMA_HE_THONG.Text = "";
            chkNO_LINE.Checked = false;
            txtSTT.Text = "";
            txtTEN_HE_THONG.Text = "";
            txtTEN_HE_THONG_ANH.Text = "";
            txtTEN_HE_THONG_HOA.Text = "";
            txtTAI_LIEU.Text = "";
            txtGHI_CHU.Text = "";
            txtMS_CHA.Text = "";
        }
        private void LoadText()
        {
            if (tvwHThong.FocusedNode == null)
            {
                TextTrong();
                return;
            }
            if (tvwHThong.FocusedNode["MS_HE_THONG"].ToString() == "-1")
            {
                TextTrong();
            }
            else
            {
                txtMS_HE_THONG.Text = tvwHThong.FocusedNode["MS_HE_THONG"].ToString();
                txtMA_HE_THONG.Text = tvwHThong.FocusedNode["MA_HE_THONG"].ToString();
                chkNO_LINE.Checked = tvwHThong.FocusedNode["NO_LINE"].ToString() == "0" ? false : true;
                txtSTT.Text = tvwHThong.FocusedNode["STT"].ToString();
                txtTEN_HE_THONG.Text = tvwHThong.FocusedNode["TEN_HE_THONG"].ToString();
                txtTEN_HE_THONG_ANH.Text = tvwHThong.FocusedNode["TEN_HE_THONG_ANH"].ToString();
                txtTEN_HE_THONG_HOA.Text = tvwHThong.FocusedNode["TEN_HE_THONG_HOA"].ToString();
                txtTAI_LIEU.Text = tvwHThong.FocusedNode["TAI_LIEU"].ToString();
                txtGHI_CHU.Text = tvwHThong.FocusedNode["GHI_CHU"].ToString();
                txtMS_CHA.Text = tvwHThong.FocusedNode["MS_CHA"].ToString();
            }

        }
        private void KhoaText(Boolean bKhoa)
        {
            txtMS_HE_THONG.Properties.ReadOnly = bKhoa;
            txtMA_HE_THONG.Properties.ReadOnly = bKhoa;
            chkNO_LINE.Properties.ReadOnly = bKhoa;
            txtSTT.Properties.ReadOnly = bKhoa;
            txtTEN_HE_THONG.Properties.ReadOnly = bKhoa;
            txtTEN_HE_THONG_ANH.Properties.ReadOnly = bKhoa;
            txtTEN_HE_THONG_HOA.Properties.ReadOnly = bKhoa;
            //txtTAI_LIEU.Properties.ReadOnly = bKhoa;
            txtGHI_CHU.Properties.ReadOnly = bKhoa;
            txtMS_CHA.Properties.ReadOnly = bKhoa;

            tvwHThong.Enabled = bKhoa;
            btnThem.Visible = bKhoa;
            btnSua.Visible = bKhoa;
            btnXoa.Visible = bKhoa;
            btnThoat.Visible = bKhoa;
            btnGhi.Visible =! bKhoa;
            btnKhong.Visible =! bKhoa;

        }

        private void tvwHThong_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadText();
        }

        private void txtTAI_LIEU_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible)
            {

                OpenFileDialog ofdHinh = new OpenFileDialog();
                ofdHinh.ShowDialog();
                if (ofdHinh.FileName == "")
                {
                    txtTAI_LIEU.Text = "";
                    return;
                }
                else
                    txtTAI_LIEU.Text = ofdHinh.FileName;
            }
            else
            {
                Commons.Modules.ObjSystems.OpenHinh(txtTAI_LIEU.Text);
            }
        }

        string sDuongDanCu;
        
            
        private void lblNoLine_Click(object sender, EventArgs e)
        {
            if (chkNO_LINE.Properties.ReadOnly) return;
            chkNO_LINE.Checked = !chkNO_LINE.Checked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TextTrong();
            txtMS_HE_THONG.Text = "-1";
            try
            {
                txtMS_CHA.Text = tvwHThong.FocusedNode["MS_HE_THONG"].ToString();
            }
            catch { txtMS_CHA.Text = ""; }
            KhoaText(false);
            txtMA_HE_THONG.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMS_CHA.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongCoGiaTriSua", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            KhoaText(false);
            txtMA_HE_THONG.Focus();
            sDuongDanCu = txtTAI_LIEU.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMS_CHA.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tvwHThong.Nodes.Count ==0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            #region "Kiem xoa"
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM MAY_HE_THONG WHERE MS_HE_THONG = '" + txtMS_HE_THONG.Text + "'"));
            if (dtTmp.Rows.Count > 0)
            {

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMA_HE_THONG.Focus();
                return ;
            }

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM THOI_GIAN_NGUNG_MAY WHERE MS_HE_THONG = '" + txtMS_HE_THONG.Text + "'"));
            if (dtTmp.Rows.Count > 0)
            {

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTHOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTEN_HE_THONG.Focus();
                return ;
            }

            #endregion
            #region "Kiem con"
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM HE_THONG WHERE MS_CHA = '" + txtMS_HE_THONG.Text + "'"));
            if (dtTmp.Rows.Count > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgVanConDayChuyenConKhongTheXoa", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMA_HE_THONG.Focus();
                return;

            }
            #endregion

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SqlConnection oCon = new SqlConnection(Commons.IConnections.CNStr);
            oCon.Open();
            SqlTransaction oTran = oCon.BeginTransaction();

            try
            {
                SqlHelper.ExecuteNonQuery(oTran, "UPDATE_NHOM_HE_THONG_LOG", txtMS_HE_THONG.Text, this.Name, Commons.Modules.UserName, 3);
                SqlHelper.ExecuteNonQuery(oTran, "DeleteHE_THONG1", txtMS_HE_THONG.Text, Commons.Modules.UserName);
                SqlHelper.ExecuteNonQuery(oTran, "UPDATE_HE_THONG_LOG", txtMS_HE_THONG.Text, this.Name, Commons.Modules.UserName, 3);
                SqlHelper.ExecuteNonQuery(oTran, "DeleteHE_THONG", txtMS_HE_THONG.Text);
                oTran.Commit();
                DevExpress.XtraTreeList.Nodes.TreeListNode node = tvwHThong.FocusedNode;
                if (node.ParentNode != null)
                    node.ParentNode.Nodes.Remove(node);
                else
                    tvwHThong.Nodes.Remove(node);
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                XtraMessageBox.Show(ex.Message.ToString());
                return;
            }
            //TaoTree(-1);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean KiemGhi()
        {
            try
            {
                #region "Kiem NULL"
                if (txtMA_HE_THONG.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgMsHeThongNull", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMA_HE_THONG.Focus();
                    return false;
                }
                if (txtTEN_HE_THONG.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaychuyenNull", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTEN_HE_THONG.Focus();
                    return false;
                }
                #endregion

                #region "Kiem trung"
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM HE_THONG WHERE MS_HE_THONG <> " + txtMS_HE_THONG.Text + " AND MA_HE_THONG = '" + txtMA_HE_THONG.Text + "' "));
                if (dtTmp.Rows.Count > 0)
                {

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgMaSoHeThongDaTonTai", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMA_HE_THONG.Focus();
                    return false;
                }

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM HE_THONG WHERE MS_HE_THONG <> " + txtMS_HE_THONG.Text + " AND TEN_HE_THONG = '" + txtTEN_HE_THONG.Text + "' "));
                if (dtTmp.Rows.Count > 0)
                {

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTEN_HE_THONG", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTEN_HE_THONG.Focus();
                    return false;
                }

                if (txtTEN_HE_THONG_ANH.Text.Trim() != "")
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM HE_THONG WHERE MS_HE_THONG <> " + txtMS_HE_THONG.Text + " AND TEN_HE_THONG_ANH = '" + txtTEN_HE_THONG_ANH.Text + "' "));
                    if (dtTmp.Rows.Count > 0)
                    {

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenHeThongAnhTonTai", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTEN_HE_THONG_ANH.Focus();
                        return false;
                    }

                }
                if (txtTEN_HE_THONG_HOA.Text.Trim() != "")
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM HE_THONG WHERE MS_HE_THONG <> " + txtMS_HE_THONG.Text + " AND TEN_HE_THONG_HOA = '" + txtTEN_HE_THONG_HOA.Text + "' "));
                    if (dtTmp.Rows.Count > 0)
                    {

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenHeThongHoaTonTai", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTEN_HE_THONG_HOA.Focus();
                        return false;
                    }

                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {

            if (!KiemGhi()) return;
            int iMsHThong = -1;
            SqlConnection oCon = new SqlConnection(Commons.IConnections.CNStr);
            oCon.Open();
            SqlTransaction oTran = oCon.BeginTransaction();
            int iThaoTac = 1;
            if (txtMS_HE_THONG.Text == "-1") iThaoTac = 1; else iThaoTac = 2;
            try
            {
                iMsHThong = Convert.ToInt32(SqlHelper.ExecuteScalar(oTran, "AddEditHE_THONG", int.Parse(txtMS_HE_THONG.Text), txtTEN_HE_THONG.Text, txtGHI_CHU.Text, chkNO_LINE.Checked, txtMA_HE_THONG.Text, txtTEN_HE_THONG_ANH.Text, txtTEN_HE_THONG_HOA.Text, txtMS_CHA.Text, txtTAI_LIEU.Text, (txtSTT.Text == "" ? -1 : int.Parse(txtSTT.Text)), Commons.Modules.UserName));

                SqlHelper.ExecuteNonQuery(oTran, "UPDATE_NHOM_HE_THONG_LOG", txtMS_HE_THONG.Text, this.Name, Commons.Modules.UserName, iThaoTac);
                SqlHelper.ExecuteNonQuery(oTran, "UPDATE_HE_THONG_LOG", txtMS_HE_THONG.Text, this.Name, Commons.Modules.UserName, iThaoTac);
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                XtraMessageBox.Show(ex.Message.ToString());
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(txtTAI_LIEU.Text.Trim()))
                {
                    string sLuu = "";
                    string strduongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(true, "DayChuyen");
                    sLuu = strduongDanTmp + "\\" + "DC_" + txtMA_HE_THONG.Text + Commons.Modules.ObjSystems.LayDuoiFile(txtTAI_LIEU.Text);
                    Commons.Modules.ObjSystems.LuuDuongDan(txtTAI_LIEU.Text, sLuu);
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE HE_THONG SET TAI_LIEU = N'" + sLuu + "' WHERE MS_HE_THONG = " + iMsHThong.ToString());

                }
                else
                {
                    if (!string.IsNullOrEmpty(sDuongDanCu))
                    {
                        Commons.Modules.ObjSystems.Xoahinh(sDuongDanCu);
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE HE_THONG SET TAI_LIEU = NULL WHERE MS_HE_THONG = " + iMsHThong.ToString());
                    }
                }
            }
            catch { }

            TaoTree(iMsHThong);
            KhoaText(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMS_HE_THONG.Text == "-1")
                    TaoTree(int.Parse(tvwHThong.FocusedNode["MS_HE_THONG"].ToString()));
                else
                    TaoTree(int.Parse(txtMS_HE_THONG.Text));
            }
            catch { TaoTree(-1); }
            KhoaText(true);
        }

        private void txtTKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string sTenHT;
            if (Commons.Modules.TypeLanguage == 0)
                sTenHT = "TEN_HE_THONG";
            else
            {
                if (Commons.Modules.TypeLanguage == 1)
                    sTenHT = "TEN_HE_THONG_ANH";
                else
                    sTenHT = "TEN_HE_THONG_HOA";
            }
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtTKiem.Text, tvwHThong, "MS_HE_THONG", sTenHT, ref arrTim);
        }

    }
}
