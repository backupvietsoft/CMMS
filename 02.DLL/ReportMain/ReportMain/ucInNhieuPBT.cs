using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
using DevExpress.XtraEditors.Repository;
using System.Linq;

namespace ReportMain
{
    public partial class frmInNhieuPBT : DevExpress.XtraEditors.XtraForm
    {
        private bool flag = true;
        public DataTable dtTmp = new DataTable();
        public frmInNhieuPBT(string tuNgay, string denNgay)
        {
            InitializeComponent();
            dateTNgay.Text = tuNgay;
            dateDNgay.Text = denNgay;
            if (Commons.Modules.sPrivate == "BARIA")
            {
                Commons.Modules.ObjSystems.MRemoveRow(tableLayoutPanel1, 4);
            }
            else
            {
                Commons.Modules.ObjSystems.MRemoveRow(tableLayoutPanel1, 5);
            }
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN) - 1].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN) - 1].Height = 100;
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN)].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN)].Height = 25;
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN) + 1].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[tableLayoutPanel1.GetRow(prbIN) + 1].Height = 42;
        }

        private void ucInNhieuPBT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNX();
                LoadDChuyen();
                LoadLoaiMay();
                LoadTTCT();
                lblLMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "lblLMay", Commons.Modules.TypeLanguage);
                lblDChuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "lblDChuyen", Commons.Modules.TypeLanguage);
                lblDDiem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "lblDDiem", Commons.Modules.TypeLanguage);
                lblTNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "lblNam", Commons.Modules.TypeLanguage);
                lblNMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "lblNMay", Commons.Modules.TypeLanguage);
                BindPBT();
                flag = false;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch
            { }
        }
        private void BindPBT()
        {
            try
            {
                DataTable dtPBT = new DataTable();
                dtPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spPhieuBaoTri_GET_ALL", Commons.Modules.UserName, Convert.ToDateTime(dateTNgay.EditValue, new CultureInfo("vi-vn")),
                        Convert.ToDateTime(dateDNgay.EditValue, new CultureInfo("vi-vn")), cboLMay.EditValue, cboNMay.EditValue, "-1", cboDDiem.EditValue,
                        cboDChuyen.EditValue, Commons.Modules.TypeLanguage));

                dtPBT.Columns[0].ReadOnly = false;
                for (int i = 1; i < dtPBT.Columns.Count; i++)
                {
                    dtPBT.Columns[i].ReadOnly = true;
                }
                dtPBT.AcceptChanges();

                if (grvPBT.Columns.Count > 0)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPBT, grvPBT, dtPBT, true, false, false, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPBT, grvPBT, dtPBT, true, true, true, true);

                if (Commons.Modules.sPrivate == "BARIA")
                {
                    grvPBT.Columns["TEN_TIENG_VIET"].Visible = true;
                }
                else
                {
                    grvPBT.Columns["TEN_TIENG_VIET"].Visible = false;
                }
                grvPBT.Columns["MS_TT_CT"].Visible = false;


                grvPBT.Columns["SO_PHIEU_BAO_TRI"].Visible = false;
                grvPBT.Columns["MS_NHOM_MAY"].Visible = false;
                grvPBT.Columns["MS_LOAI_MAY"].Visible = false;
                grvPBT.Columns["MS_UU_TIEN"].Visible = false;
                grvPBT.Columns["MS_LOAI_BT"].Visible = false;
                grvPBT.Columns["TEN_LOAI_BT"].Visible = false;
                grvPBT.Columns["DHX"].Visible = false;
                grvPBT.Columns["TINH_TRANG_PBT"].Visible = false;
                grvPBT.Columns["MS_LOAI_BT"].Visible = false;
                grvPBT.Columns["GIO_LAP"].Visible = false;
                grvPBT.Columns["LY_DO_BT"].Visible = false;
                grvPBT.Columns["MS_UU_TIEN"].Visible = false;
                grvPBT.Columns["NGAY_KT_KH"].Visible = false;
                grvPBT.Columns["USERNAME_NGUOI_LAP"].Visible = false;
                grvPBT.Columns["NGUOI_GIAM_SAT"].Visible = false;
                grvPBT.Columns["GIO_HONG"].Visible = false;
                grvPBT.Columns["NGAY_HONG"].Visible = false;
                grvPBT.Columns["DEN_GIO_HONG"].Visible = false;
                grvPBT.Columns["DEN_NGAY_HONG"].Visible = false;
                grvPBT.Columns["NGUOI_LAP"].Visible = false;
                grvPBT.Columns["HO_TEN"].Visible = false;
                grvPBT.Columns["MS_N_XUONG"].Visible = false;
                grvPBT.Columns["MS_LOAI_MAY"].Visible = false;
                grvPBT.Columns["MS_NHOM_MAY"].Visible = false;
                grvPBT.Columns["TINH_TRANG_PBT"].Visible = false;
                grvPBT.Columns["MS_HT"].Visible = false;
                grvPBT.Columns["MS_NGUYEN_NHAN"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }
        private void LoadTTCT()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spTinhTrangPBTCT_GET", Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCheckedComboBoxEdit(cboTThai, dtTmp, "MS_TT_CT", "TEN_TRANG_THAI");
            }
            catch
            {
            }
        }
        DataTable dtMay = new DataTable();
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {



                dtTmp = ((DataTable)(grdPBT.DataSource)).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    return;
                }
                int count = 0;
                if (Commons.Modules.sPrivate != "BARIA")
                {
                    sSql = "";
                    if (chkTTBT.GetItemChecked(0))
                        sSql = sSql + " OR STT = 1 ";
                    if (chkTTBT.GetItemChecked(1))
                        sSql = sSql + " OR STT = 2 ";
                    if (chkTTBT.GetItemChecked(2))
                        sSql = sSql + " OR STT = 3 ";
                    if (chkTTBT.GetItemChecked(3))
                        sSql = sSql + " OR STT = 4 ";
                    if (chkTTBT.GetItemChecked(4))
                        sSql = sSql + " OR STT = 5 ";
                    if (string.IsNullOrEmpty(sSql))
                    {
                        dtTmp.DefaultView.RowFilter = "";
                        dtTmp = dtTmp.DefaultView.ToTable();
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                        return;
                    }
                    sSql = sSql.Remove(0, 3);

                    foreach (DataRow row in dtTmp.Rows)
                    {
                        if (chkTTBT.GetItemChecked(0))
                        {
                            if (row["TINH_TRANG_PBT"].ToString().Equals("1"))
                            {
                                count = 0;

                                break;
                            }
                        }
                        if (chkTTBT.GetItemChecked(1))
                        {
                            if (row["TINH_TRANG_PBT"].ToString().Equals("2"))
                            {
                                count = 0;

                                break;
                            }
                        }
                        if (chkTTBT.GetItemChecked(2))
                        {
                            if (row["TINH_TRANG_PBT"].ToString().Equals("3"))
                            {
                                count = 0;

                                break;
                            }
                        }
                        if (chkTTBT.GetItemChecked(3))
                        {
                            if (row["TINH_TRANG_PBT"].ToString().Equals("4"))
                            {
                                count = 0;
                                break;
                            }
                        }
                        if (chkTTBT.GetItemChecked(4))
                        {
                            if (row["TINH_TRANG_PBT"].ToString().Equals("5"))
                            {
                                count = 0;
                                break;
                            }
                        }
                        count++;
                    }

                }
                else
                {
                    sSql = "";
                    List<string> myList = cboTThai.EditValue.ToString().Split(',').ToList();
                    sSql = Commons.Modules.ObjSystems.SplitString(cboTThai.EditValue.ToString());
                    sSql = "*" + sSql.Replace(", ", "*,*") + "*";

                    foreach (DataRow row in dtTmp.Rows)
                    {
                        if (myList.Any(x => x.First().ToString().Trim().Equals(row["MS_TT_CT"].ToString())))
                        {
                            count = 0;
                            break;
                        }
                        count++;
                    }
                }

                if (count > 0)
                {
                    dtTmp.DefaultView.RowFilter = "";
                    dtTmp = dtTmp.DefaultView.ToTable();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucInNhieuPBT", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    return;
                }
                dtTmp = ((DataTable)(grdPBT.DataSource)).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }
        private void InDuLieu()
        {


        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTmp1 = new DataTable();
                dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_NHOM_MAYs", cboLMay.EditValue));

                DataRow drRow = dtTmp1.NewRow();
                drRow["MS_NHOM_MAY"] = "-1";
                drRow["TEN_NHOM_MAY"] = " < ALL > ";
                drRow["MS_LOAI_MAY"] = "-1";
                dtTmp1.Rows.Add(drRow);
                dtTmp1.DefaultView.Sort = "TEN_NHOM_MAY";
                dtTmp1 = dtTmp1.DefaultView.ToTable();

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, dtTmp1, "MS_NHOM_MAY", "TEN_NHOM_MAY", "");

            }
            catch { }
        }


        public string sSql = "";

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvPBT);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvPBT);
        }
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }

        private void dateTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) return;
            BindPBT();
        }

        private void dateDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) return;
            BindPBT();

        }

        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (flag == true) return;
            BindPBT();

        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (flag == true) return;
            BindPBT();

        }

        private void cboNMay_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) return;
            BindPBT();

        }
        //private void chkTTBT_SelectedValueChanged(object sender, EventArgs e)
        //{
        //          try
        //    {
        //        sSql = "";
        //        if (chkTTBT.GetItemChecked(0))
        //            sSql = sSql + " OR STT = 1 ";
        //        if (chkTTBT.GetItemChecked(1))
        //            sSql = sSql + " OR STT = 2 ";
        //        if (chkTTBT.GetItemChecked(2))
        //            sSql = sSql + " OR STT = 3 ";
        //        if (chkTTBT.GetItemChecked(3))
        //            sSql = sSql + " OR STT = 4 ";
        //        if (chkTTBT.GetItemChecked(4))
        //            sSql = sSql + " OR STT = 5 ";

        //        sSql = sSql.Remove(0, 3);

        //        LoadTTCT();
        //    }
        //    catch
        //    {  }
        //}
    }
}