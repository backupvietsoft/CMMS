using DevExpress.XtraCharts;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmDDChart : DevExpress.XtraEditors.XtraForm
    {
        public frmDDChart()
        {
            InitializeComponent();
        }

        private void frmDDChart_Load(object sender, EventArgs e)
        {
            TaoBieuDo();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TaoBieuDo();
            }catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TaoBieuDo()
        {
            chaNgay.Series.Clear();
            charTuan.Series.Clear();
            charThang.Series.Clear();

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetNgayLVDD", int.Parse(txtID.Text), Commons.Modules.UserName));

            DataTable dtTmp1 = new DataTable();
            if (optBCao.SelectedIndex == 0)
                dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetSoPhutDDTheoNgayDD",int.Parse(txtID.Text), Commons.Modules.UserName));
            else
                dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetSoPhutDD", int.Parse(txtID.Text), Commons.Modules.UserName));

            #region "Ngay"
            Series series1 = new Series("Số phút KH", ViewType.Bar);

            if (optBCao.SelectedIndex == 0)
                series1 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,"sSoPhutDieuDo", Commons.Modules.TypeLanguage), ViewType.Bar);
            else
                series1 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,"sSoPhutKeHoach", Commons.Modules.TypeLanguage), ViewType.Bar);


            chaNgay.Series.Add(series1);
            DataView dt1 = new DataView(dtTmp1, "LOAI=1", "ORD1", DataViewRowState.CurrentRows);
            series1.DataSource = dt1.ToTable();
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series1.ArgumentDataMember = "DATA";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "S_PHUT" });

            Series series = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoCong", Commons.Modules.TypeLanguage), ViewType.Point);
            chaNgay.Series.Add(series);

            DataView dt = new DataView(dtTmp, "LOAI=1", "ORD1", DataViewRowState.CurrentRows);
            series.DataSource = dt.ToTable();
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = "DATA";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "S_PHUT" });
            #endregion

            #region "Tuan"
            Series series3 = new Series("Số phút KH", ViewType.Bar);
            if (optBCao.SelectedIndex == 0)
                series3 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoPhutDieuDo", Commons.Modules.TypeLanguage), ViewType.Bar);
            else
                series3 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoPhutKeHoach", Commons.Modules.TypeLanguage), ViewType.Bar);

            charTuan.Series.Add(series3);

            DataView dt2 = new DataView(dtTmp1, "LOAI=2", "ORD1", DataViewRowState.CurrentRows);
            series3.DataSource = dt2.ToTable();
            series3.ArgumentScaleType = ScaleType.Qualitative;
            series3.ArgumentDataMember = "DATA";
            series3.ValueScaleType = ScaleType.Numerical;
            series3.ValueDataMembers.AddRange(new string[] { "S_PHUT" });

            Series series4 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoCong", Commons.Modules.TypeLanguage), ViewType.Point);
            charTuan.Series.Add(series4);

            DataView dt3 = new DataView(dtTmp, "LOAI=2", "ORD1", DataViewRowState.CurrentRows);
            series4.DataSource = dt3.ToTable();
            series4.ArgumentScaleType = ScaleType.Qualitative;
            series4.ArgumentDataMember = "DATA";
            series4.ValueScaleType = ScaleType.Numerical;
            series4.ValueDataMembers.AddRange(new string[] { "S_PHUT" });
            #endregion

            #region "Thang"
            Series series5 = new Series("Số phút KH", ViewType.Bar);
            if (optBCao.SelectedIndex == 0)
                series5 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoPhutDieuDo", Commons.Modules.TypeLanguage), ViewType.Bar);
            else
                series5 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoPhutKeHoach", Commons.Modules.TypeLanguage), ViewType.Bar);
            charThang.Series.Add(series5);
            DataView dt4 = new DataView(dtTmp1, "LOAI=3", "ORD1", DataViewRowState.CurrentRows);
            series5.DataSource = dt4.ToTable();
            series5.ArgumentScaleType = ScaleType.Qualitative;
            series5.ArgumentDataMember = "DATA";
            series5.ValueScaleType = ScaleType.Numerical;
            series5.ValueDataMembers.AddRange(new string[] { "S_PHUT" });

            Series series6 = new Series(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoCong", Commons.Modules.TypeLanguage), ViewType.Point);
            charThang.Series.Add(series6);
            DataView dt5 = new DataView(dtTmp, "LOAI=3", "ORD1", DataViewRowState.CurrentRows);
            series6.DataSource = dt5.ToTable();
            series6.ArgumentScaleType = ScaleType.Qualitative;
            series6.ArgumentDataMember = "DATA";
            series6.ValueScaleType = ScaleType.Numerical;
            series6.ValueDataMembers.AddRange(new string[] { "S_PHUT" });
            #endregion

            Series seriesDays = new Series("", ViewType.Bar);
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
