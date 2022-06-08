using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmTinhTrangPBTCT : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public static bool close = false;
        enum Actions
        { insert, update, nothing }
        Actions action = new Actions();
        bool flag = false;

        public frmTinhTrangPBTCT()
        {
            InitializeComponent();
        }
        private void VisibleButton(bool check)
        {
            btnSua.Visible = check;
            btnXoa.Visible = check;
            btnThoat.Visible = check;
            btnThem.Visible = check;
            btnGhi.Visible = !check;
            btnKhongGhi.Visible = !check;
        }
        private void EnableControl(bool check)
        {
            txtTinhTrangCT_Viet.Enabled = check;
            txtMaSo.Enabled = check;
            txtTinhTrangCT_Hoa.Enabled = check;
            txtTinhTrangCT_Viet.Enabled = check;
            txtTinhTrangCT_Anh.Enabled = check;
            txtGhiChu.Enabled = check;
            cboTinhTrangPBT.Enabled = check;
            chkMacDinh.Enabled = check;
        }
        private void ResetControl()
        {
            txtTinhTrangCT_Viet.Text = "";
            txtMaSo.Text = "";
            txtTinhTrangCT_Hoa.Text = "";
            txtTinhTrangCT_Viet.Text = "";
            txtTinhTrangCT_Anh.Text = "";
            txtGhiChu.Text = "";
            chkMacDinh.Checked = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                action = Actions.insert;
                EnableControl(true);
                ResetControl();
                VisibleButton(false);
                grdTinhTrangPBTCT.Enabled = false;
            }
            catch
            { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                action = Actions.update;
                EnableControl(true);
                VisibleButton(false);
                grdTinhTrangPBTCT.Enabled = false;
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTinhTrangPBTCT.GetFocusedDataRow()["MS_TT_CT"].ToString() != "")
                {
                    if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaTT_PBT_CT", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    {
                        string str = "DELETE FROM TINH_TRANG_PBT_CT WHERE MS_TT_CT = " + grvTinhTrangPBTCT.GetFocusedDataRow()["MS_TT_CT"];
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        grvTinhTrangPBTCT.DeleteRow(grvTinhTrangPBTCT.FocusedRowHandle);
                        try
                        {
                            ShowData(grvTinhTrangPBTCT.FocusedRowHandle);
                        }
                        catch { }

                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTinhTrangCT_Viet.Text.Trim()))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTinhTrangVietRong", Commons.Modules.TypeLanguage));
                    txtTinhTrangCT_Viet.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMaSo.Text.Trim()))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMaSoRong", Commons.Modules.TypeLanguage));
                    txtMaSo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTinhTrangCT_Anh.Text.Trim()))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTinhTrangAnhRong", Commons.Modules.TypeLanguage));
                    txtTinhTrangCT_Anh.Focus();
                    return;
                }

                if (cboTinhTrangPBT.ItemIndex == -1)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTinhTrangPBTRong", Commons.Modules.TypeLanguage));
                    return;
                }
                if(flag == false && chkMacDinh.Checked == true && Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spCHECK_MAC_DINH_TINH_TRANG_PBT_CT", cboTinhTrangPBT.EditValue)) == true)
                {
                    if(MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMacDinhTonTai", Commons.Modules.TypeLanguage),"", MessageBoxButtons.YesNo , MessageBoxIcon.Question )== DialogResult.No)
                        return;
                }

                if (action == Actions.insert)
                {
                
                    int MS_TT_CT = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spINSERT_TINH_TRANG_PBT_CT", txtTinhTrangCT_Viet.Text.Trim(), txtTinhTrangCT_Anh.Text.Trim(), txtTinhTrangCT_Hoa.Text.Trim(), txtMaSo.Text.Trim(), cboTinhTrangPBT.EditValue, txtGhiChu.Text.Trim(), chkMacDinh.Checked));
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThemTT_CT_ThanhCong", Commons.Modules.TypeLanguage));                   
                }
                else
                {

                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spUPDATE_TINH_TRANG_PBT_CT", 
                        txtTinhTrangCT_Viet.Text.Trim(), txtTinhTrangCT_Anh.Text.Trim(), txtTinhTrangCT_Hoa.Text.Trim(), 
                        txtMaSo.Text.Trim(), cboTinhTrangPBT.EditValue, txtGhiChu.Text.Trim(), 
                        Convert.ToInt16(grvTinhTrangPBTCT.GetFocusedDataRow()["MS_TT_CT"].ToString()), 
                        chkMacDinh.Checked);


                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName
                        , this.Name, "MsgSuaTT_CT_ThanhCong", Commons.Modules.TypeLanguage));

                }
                close = true;
                action = Actions.nothing;
                grdTinhTrangPBTCT.Enabled = true;
                EnableControl(false);
                VisibleButton(true);
                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {                                
                EnableControl(false);
                VisibleButton(true);
                ShowData(focusRow);
                grdTinhTrangPBTCT.Enabled = true;
                action = Actions.nothing;
            }
            catch
            { }
        }

        private void frmTinhTrangPBTCT_Load(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGET_TINH_TRANG_PBT", Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinhTrangPBT, dtTmp, "STT", "TEN_TINH_TRANG", lblTinhTrangPBT.Text);

                BindData();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch
            { }
        }
        private void BindData()
        {
            try
            {
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGET_ALL_TINH_TRANG_PBT_CT", Commons.Modules.TypeLanguage));
                if (grvTinhTrangPBTCT.Columns.Count == 0)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTinhTrangPBTCT, grvTinhTrangPBTCT, dt, false, true, true, true);
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTinhTrangPBTCT, grvTinhTrangPBTCT, dt, false, false, true, true);
                }
                grvTinhTrangPBTCT.Columns["MS_TT_CT"].Visible = false;
                grvTinhTrangPBTCT.Columns["STT"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int focusRow = 0;
        private void ShowData(int focusRow)
        {
            try
            {
                txtTinhTrangCT_Viet.Text = grvTinhTrangPBTCT.GetDataRow(focusRow)["TEN_TIENG_VIET"].ToString();
                txtTinhTrangCT_Anh.Text = grvTinhTrangPBTCT.GetDataRow(focusRow)["TEN_TIENG_ANH"].ToString();
                txtTinhTrangCT_Hoa.Text = grvTinhTrangPBTCT.GetDataRow(focusRow)["TEN_TIENG_HOA"].ToString();
                txtMaSo.Text = grvTinhTrangPBTCT.GetDataRow(focusRow)["MA_SO"].ToString();
                txtGhiChu.Text = grvTinhTrangPBTCT.GetDataRow(focusRow)["GHI_CHU"].ToString();
                cboTinhTrangPBT.EditValue = Convert.ToInt32(grvTinhTrangPBTCT.GetDataRow(focusRow)["STT"].ToString());
                chkMacDinh.Checked = Convert.ToBoolean(grvTinhTrangPBTCT.GetDataRow(focusRow)["MAC_DINH"].ToString());
                flag = Convert.ToBoolean(grvTinhTrangPBTCT.GetDataRow(focusRow)["MAC_DINH"].ToString());
            }
            catch { }
        }
        private void grvTinhTrangPBTCT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ShowData(e.FocusedRowHandle);
                focusRow = e.FocusedRowHandle;
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

     

        private void chkMacDinh_Click(object sender, EventArgs e)
        {
             try
            {
               if(action == Actions.update)
                {
                    if(flag == true)
                    {
                        chkMacDinh.Checked = true;
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemTraMacDinh", Commons.Modules.TypeLanguage));
                        return;
                    }
                }
            }
            catch
            { }
        }
    }
}
