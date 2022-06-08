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
    public partial class UCKeHoachBT_Thang : DevExpress.XtraEditors.XtraUserControl
    {
        public UCKeHoachBT_Thang()
        {
            InitializeComponent();
        }

        private void UCKeHoachBT_Nam_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            cmbYear.DateTime = DateTime.Now;
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "btnThoat", Commons.Modules.TypeLanguage);
            LoadFactory();
            LoadLoaiCV();
            LoadDChuyen();
            Commons.Modules.SQLString = "";
            LoadLoaiMay();
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }
        private void LoadLoaiMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cmbFactory.EditValue.ToString() != "-1") sNX = cmbFactory.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHTCoAll",
                    sNX, iHThong, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadFactory()
        {
            try
            { 
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadCboTreeList(ref cmbFactory, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
             
            }
            catch { }


        }
        private void LoadLoaiCV()
        {
            DataTable _table_CV = new DataTable();
            _table_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_CV,TEN_LOAI_CV FROM LOAI_CONG_VIEC UNION SELECT -1,' < ALL > ' ORDER BY MS_LOAI_CV"));
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbKindOfWork, _table_CV, "MS_LOAI_CV", "TEN_LOAI_CV", "");
            }
            catch { }
            
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmKeHoachBTThang_TD obj = new frmKeHoachBTThang_TD(); 
            try
            {
                obj.DKLoc = lblKindOfWork.Text + ":" + cmbKindOfWork.Text;
                obj.SubTitle = lblFactory.Text + ":" + cmbFactory.TextValue;
                obj.Year = cmbYear.DateTime.Year;
                obj.Month = cmbYear.DateTime.Month;

                DateTime dTNgay, dDNgay, Ngay;
                Ngay = Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(1).AddDays(-1);

                int day = DateTime.DaysInMonth(cmbYear.DateTime.Year, cmbYear.DateTime.Month);
                obj._Table_Source = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                obj._Table_Source.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KE_HOACH_BAO_TRI_NAM_TD",
                                                      dTNgay, dDNgay,
                                                      cmbFactory.EditValue, Commons.Modules.UserName, cmbKindOfWork.EditValue, 
                                                      Commons.Modules.TypeLanguage, optLoaiBC.SelectedIndex,cboDChuyen.EditValue,cboLMay.EditValue));
                this.Cursor = Cursors.Default;
                if (obj._Table_Source.Rows.Count > 0)
                {
                    obj.ShowDialog();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTriNam_TD", "khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            this.Cursor = Cursors.Default;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
        }
    }
}
