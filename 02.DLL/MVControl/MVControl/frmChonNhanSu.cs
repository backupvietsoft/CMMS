using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmChonNhanSu : DevExpress.XtraEditors.XtraForm
    {
        public List<string> lstNhanSuChon = new List<string> { };
        public DataTable dtNhanSuReturn = new DataTable();

        public void LoadDonVi()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, Commons.Modules.ObjSystems.MLoadDataDonVi(1), "MS_DON_VI", "TEN_DON_VI", "TEN_DON_VI");
        }
        public void LoadPhongBan()
        {
            cboPBan.Properties.DataSource = null;
            if (cboDonVi.EditValue == null)
                return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, Commons.Modules.ObjSystems.MLoadDataPhongBan(1, cboDonVi.EditValue.ToString()), "MS_PB", "TEN_PB", "TEN_PB");
            }
            catch
            {
            }
        }
        public void LoadTo()
        {
            cboTo.Properties.DataSource = null;
            if (cboPBan.EditValue == null)
                return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, Commons.Modules.ObjSystems.MLoadDataTo(1, cboDonVi.EditValue.ToString(), Convert.ToInt32(cboPBan.EditValue)), "MS_TO1", "TEN_TO", "TEN_TO");
            }
            catch
            {
            }
        }

        public frmChonNhanSu()
        {
            InitializeComponent();
        }

        private void frmChonNhanSu_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            LoadDonVi();
            LoadPhongBan();
            LoadTo();
            Commons.Modules.SQLString = "";
            LoadData();
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            Commons.Modules.SQLString = "0Load";
            LoadPhongBan();
            LoadTo();
            Commons.Modules.SQLString = "";
            TimKiem();
        }

        private void cboPBan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            Commons.Modules.SQLString = "0Load";
            LoadTo();
            Commons.Modules.SQLString = "";
            TimKiem();
        }

        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            TimKiem();
        }

        private void LoadData()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (cboDonVi.Properties.DataSource == null) return;
            if (cboPBan.Properties.DataSource == null) return;
            if (cboTo.Properties.DataSource == null) return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetNhanVien", Commons.Modules.UserName, cboDonVi.EditValue, cboPBan.EditValue, cboTo.EditValue, Commons.Modules.TypeLanguage));

                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "0";
                dt.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dt.Columns["CHON"].ReadOnly = false;



                if (lstNhanSuChon.Count > 0)
                    dt.AsEnumerable().Where(a => lstNhanSuChon.Contains(a.Field<string>("MS_CONG_NHAN")))
                                        .Select(b => b["CHON"] = 1)
                                        .ToList();

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanSu, grvNhanSu, dt, true, false, true, true, true, this.Name);

                for (int i = 1; i <= grvNhanSu.Columns.Count - 1; i++)
                {
                    dt.Columns[i].ReadOnly = true;
                }
                grvNhanSu.Columns["MS_TO"].Visible = false;
                grvNhanSu.Columns["MS_PHONG_BAN"].Visible = false;
                grvNhanSu.Columns["MS_DON_VI"].Visible = false;
                grvNhanSu.Columns["HO"].Visible = false;
                grvNhanSu.Columns["TEN"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }


        private void TimKiem()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            //MS_CONG_NHAN,HOTEN,TEN_DON_VI,[TEN_PHONG_BAN],TEN_TO, MS_TO,MS_PHONG_BAN,MS_DON_VI,HO,TEN
            try
            {
                if (cboDonVi.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_DON_VI = '" + cboDonVi.EditValue.ToString() + "' ) ";
            }
            catch
            { }
            try
            { if (cboPBan.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_PHONG_BAN = " + cboPBan.EditValue.ToString() + " ) "; }
            catch { }

            try
            { if (cboTo.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_TO = " + cboTo.EditValue.ToString() + " ) "; }
            catch { }


            sdkien = "( " + sdkien + ") ";
            try
            {

                dtTmp = (DataTable)grdNhanSu.DataSource;
                if (txtTKiem.Text.Length != 0) sdkien = sdkien + " AND ( " + " HOTEN LIKE '%" + txtTKiem.Text + "%' OR TEN_DON_VI LIKE '%" + txtTKiem.Text + "%' OR TEN_PHONG_BAN LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_TO LIKE '%" + txtTKiem.Text + "%' ) ";



                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
            lblTCong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TongCong", Commons.Modules.TypeLanguage) + " : " + grvNhanSu.RowCount.ToString();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            TimKiem();
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvNhanSu);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvNhanSu);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dtNhanSuReturn = new DataTable();
            dtNhanSuReturn = ((DataTable)grdNhanSu.DataSource).Copy();
            dtNhanSuReturn.DefaultView.RowFilter = "CHON = TRUE ";

            dtNhanSuReturn = dtNhanSuReturn.DefaultView.ToTable();


            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            dtNhanSuReturn = new DataTable();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void grvNhanSu_MouseDown(object sender, MouseEventArgs e)
        {

            //try
            //{
            //    GridHitInfo info = new GridHitInfo();
            //    info = grvNhanSu.CalcHitInfo(e.Location);
            //    if (info.Column.Name.ToUpper() != "colCHON".ToUpper())
            //    {
            //        ((DXMouseEventArgs)e).Handled = true;
            //    }
            //}
            //catch { }
        }
        //Private Sub gridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles gridView1.ShownEditor
        //    Dim view As GridView = TryCast(sender, GridView)
        //    Dim activeEditor As TextEdit = TryCast(view.ActiveEditor, TextEdit)
        //    If activeEditor Is Nothing Then
        //        Return
        //    End If
        //    RemoveHandler activeEditor.Spin, AddressOf activeEditor_Spin
        //    AddHandler activeEditor.Spin, AddressOf activeEditor_Spin
        //End Sub

        //Private Sub activeEditor_Spin(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.SpinEventArgs)
        //    gridView1.CloseEditor()
        //End Sub
        private void grvNhanSu_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            TextEdit activeEditor = view.ActiveEditor as TextEdit;
            if (activeEditor == null) return;
            activeEditor.Spin -= activeEditor_Spin;
            activeEditor.Spin += activeEditor_Spin;

        }
        void activeEditor_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            grvNhanSu.CloseEditor();
        }
    }

}
