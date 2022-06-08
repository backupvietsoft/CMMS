using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.NMN_TD
{
    public partial class UCKeHoachBT_Nam : UserControl
    {
        public UCKeHoachBT_Nam()
        {
            InitializeComponent();
        }

        private void UCKeHoachBT_Nam_Load(object sender, EventArgs e)
        {

            cmbYear.DateTime = DateTime.Now;
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnThoat", Commons.Modules.TypeLanguage);
            LoadFactory();
            LoadLoaiCV();
        }
        private void LoadFactory()
        {
            try
            {
                DataTable _table_Factory = new DataTable();
                _table_Factory.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbFactory, _table_Factory, "MS_N_XUONG", "TEN_N_XUONG", "");
            }
            catch { }

        }
        private void LoadLoaiCV()
        {
            DataTable _table_CV = new DataTable();
            _table_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_CV,TEN_LOAI_CV FROM LOAI_CONG_VIEC UNION SELECT -1,'All' ORDER BY MS_LOAI_CV"));
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbKindOfWork, _table_CV, "MS_LOAI_CV", "TEN_LOAI_CV", "");
            }
            catch { }

        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmKeHoachBTNam_TD obj = new frmKeHoachBTNam_TD(); 
            try
            {
                obj.DKLoc = lblKindOfWork.Text + ":" + cmbKindOfWork.Text;
                obj.SubTitle = lblFactory.Text + ":" + cmbFactory.Text;
                obj.Year = lblYear.Text + " " + cmbYear.Text;
                if (Convert.ToInt32(cmbYear.Text) <= 1900)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "namkhonghople", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                obj._Table_Source = new DataTable();
                obj._Table_Source.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KE_HOACH_BAO_TRI_NAM_TD",
                                                      "01-01-" + cmbYear.Text , "12-31-" + cmbYear.Text , cmbFactory.EditValue, Commons.Modules.UserName, cmbKindOfWork.EditValue, Commons.Modules.TypeLanguage));
                DataView _view = new DataView(obj._Table_Source);
                _view.Sort = "TEN_MAY,TEN_BO_PHAN,CHU_KY";
                obj._Table_Source = _view.ToTable();
                if (obj._Table_Source.Rows.Count > 0)
                {
                    obj.ShowDialog();
                }
                else
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "namkhonghople", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
