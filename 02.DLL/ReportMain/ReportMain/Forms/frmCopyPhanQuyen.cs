using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;


namespace ReportMain
{
    public partial class frmCopyPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        Point ptNhom;
        GridView viewNhom;
        //iLoai = 1 Copy Phan Quyen Menu [NHOM_MENU]
        //iLoai = 2 Copy Phan Quyen Nhom form [NHOM_FORM]
        //iLoai = 3 Copy Phan Quyen Nhom nha xuong [NHOM_NHA_XUONG]
        //iLoai = 4 Copy Phan Quyen Nhom he thong [NHOM_HE_THONG]
        //iLoai = 5 Copy Phan Quyen Nhom loai may [NHOM_LOAI_MAY]
        //iLoai = 6 Copy Phan Quyen Nhom loai cong viec [NHOM_LOAI_CONG_VIEC]
        //iLoai = 7 Copy Phan Quyen Nhom loai phu tung [NHOM_LOAI_PHU_TUNG]
        //iLoai = 8 Copy Phan Quyen Nhom kho [NHOM_KHO]
        //iLoai = 9 Copy Phan Quyen Nhom to phong ban [NHOM_TO_PHONG_BAN]
        //iLoai = 10 Copy chuc nang cua user [USER_CHUC_NANG]
        //iLoai = 11 Copy Phan Quyen Nhom report [NHOM_REPORT]
        //iLoai = 12 Chuyen nhom cua user
        //iLoai = 13 Copy Phan Quyen Nhom to phong ban [NHOM_BO_PHAN_CHIU_PHI]
        public int iLoai = 1;

        //sDataGoc Du Lieu copy qua
        public string sDataGoc = "1";

        public frmCopyPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmCopyPhanQuyen_Load(object sender, EventArgs e)
        {
            GetNhomCopy();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void GetNhomCopy()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhomCopy",iLoai, sDataGoc));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhom, grvNhom, dtTmp, true, true, true, true);
            for (int i = 0; i < grvNhom.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
                grvNhom.Columns[i].OptionsColumn.ReadOnly = true;
            }
            if (iLoai != 10)
            {
                grvNhom.Columns["GROUP_ID"].Visible = false;
                grvNhom.Columns["TYPE_LIC"].Visible = false;
            }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ThucHien();
        }

        private void ThucHien()
        {
            try
            {
                //Chuyen user wa nhom khac
                if (iLoai == 12)
                {
                    string sSql;
                    try
                    {
                        sSql = " SELECT B.GROUP_NAME FROM USERS A INNER JOIN NHOM B ON A.GROUP_ID = B.GROUP_ID WHERE USERNAME = '" + sDataGoc.ToString() + "' ";
                        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    }
                    catch { sSql = ""; }

                    DialogResult result = (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "msgCoMuonChuyenChucNangCuaUserNayTuNhom", Commons.Modules.TypeLanguage) + " " + sSql + " " +
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgsang", Commons.Modules.TypeLanguage) + " " + grvNhom.GetFocusedRowCellValue("GROUP_NAME"),
                            this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question));
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.Yes)
                    {
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,
                            "CopyPhanQuyen", iLoai, sDataGoc + "0", grvNhom.GetFocusedRowCellValue("GROUP_ID"));
                    }
                    if (result == DialogResult.No)
                    {
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,
                            "CopyPhanQuyen", iLoai, sDataGoc + "1", grvNhom.GetFocusedRowCellValue("GROUP_ID"));
                    }


                }
                else
                {
                    // Copy Chuc nang user
                    if (iLoai == 10)
                    {
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "msgCoChacCopyDuLieuTuUser", Commons.Modules.TypeLanguage) + " " + sDataGoc + " " +
                                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                "msgsang", Commons.Modules.TypeLanguage) + " " + grvNhom.GetFocusedRowCellValue("USERNAME"),
                                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No) return;

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,
                            "CopyPhanQuyen", iLoai, sDataGoc, grvNhom.GetFocusedRowCellValue("USERNAME"));
                    }
                    // Copy phan quyen du lieu
                    else
                    {
                        string sSql;
                        try
                        {
                            sSql = " SELECT TOP 1 GROUP_NAME FROM NHOM WHERE GROUP_ID = " + sDataGoc.ToString();
                            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                        }
                        catch { sSql = ""; }

                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "msgCoChacCopyDuLieuTuNhom", Commons.Modules.TypeLanguage) + " " + grvNhom.GetFocusedRowCellValue("GROUP_NAME") + " " +
                                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                "msgsang", Commons.Modules.TypeLanguage) + " " + sSql,
                                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No) return;
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString,
                            "CopyPhanQuyen", iLoai, sDataGoc, grvNhom.GetFocusedRowCellValue("GROUP_ID"));

                    }

                }
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgCopyThanhCong", Commons.Modules.TypeLanguage),
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgCopyKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtDuLieu = new DataTable();
            dtDuLieu = (DataTable)grdNhom.DataSource;

            try
            {
                string dk = "";
                if (iLoai == 10 )
                {
                    if (txtTKiem.Text.Length != 0) dk = " OR  USERNAME LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  FULL_NAME LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  DESCRIPTION LIKE '%" + txtTKiem.Text + "%' " + dk;
                }
                else
                {
                    if (txtTKiem.Text.Length != 0) dk = " OR  GROUP_NAME LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  DESCRIPTION LIKE '%" + txtTKiem.Text + "%' " + dk;
                }
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtDuLieu.DefaultView.RowFilter = dk;
            }
            catch { dtDuLieu.DefaultView.RowFilter = ""; }

        }
        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewNhom, ptNhom);
            grvNhom.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (grvNhom.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
            {
                try
                {
                    ThucHien();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grvNhom_ShownEditor(object sender, EventArgs e)
        {
            viewNhom = (GridView)sender;
            ptNhom = viewNhom.GridControl.PointToClient(Control.MousePosition);
            viewNhom.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}