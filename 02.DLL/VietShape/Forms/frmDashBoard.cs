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
    public partial class frmDashBoard : DevExpress.XtraEditors.XtraForm
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }
        private DataTable dtData;
        private DateTime TuNgay;
        private DateTime DenNgay;
        private void LoadDL()
        {
           
            try
            {
                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                string MsMay = "-1";
                
                dtData = new DataTable();
                dtData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNNNMTheoNN", Commons.Modules.UserName, NXuong,
                        HThong, LMay, MsMay, TuNgay.Date, DenNgay.Date, Commons.Modules.TypeLanguage, 0));
                dtData.DefaultView.Sort = "TG_NGUNG DESC";
                TaoChart();

            }
            catch { }
        }

        private void TaoChart()
        {
            try
            {

                DataTable dtTmp = dtData.Clone(); // if needed
                int max = 5;
                Math.Min(max, dtData.Rows.Count);
                if (dtData.Rows.Count <= max) max = dtData.Rows.Count;



                for (int i = 0; i < max; i++)
                {
                    DataRow dr = dtTmp.NewRow();
                    dr[0] = dtData.Rows[i][0].ToString();
                    dr[1] = dtData.Rows[i][1].ToString();
                    dr[2] = Convert.ToInt64(dtData.Rows[i][2].ToString().Replace(".", ""));
                    dr[3] = Convert.ToInt64(dtData.Rows[i][3].ToString().Replace(".", ""));

                    dtTmp.Rows.Add(dr);

                }












                chartTron.Series.Clear();



                Series series1 = new Series("Series1", ViewType.Pie);

                


                series1 = new Series("Series1", ViewType.Pie3D);
                //if (cboChart.Text.ToUpper() == "Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie);
                //if (cboChart.Text.ToUpper() == "Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut);
                //if (cboChart.Text.ToUpper() == "3D Pie".ToUpper()) series1 = new Series("Series1", ViewType.Pie3D);
                //if (cboChart.Text.ToUpper() == "3D Doughnut".ToUpper()) series1 = new Series("Series1", ViewType.Doughnut3D);
                series1.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Number;




                    series1.Name = dtData.Columns[0].Caption;
                    series1.DataSource = dtTmp;
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "TEN_NGUYEN_NHAN";











                

                series1.ValueScaleType = ScaleType.Numerical;
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                series1.PointOptions.ValueNumericOptions.Precision = Commons.Modules.iSoLeSL;


                series1.ValueDataMembers.AddRange(new string[] { "TG_NGUNG" });
                
                series1.DataSource = dtTmp;
                series1.LegendText = "{A}"; //"{A}{V:$0}";

                ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.Inside;
                //((PieSeriesLabel)series1.Label).FillStyle= 
                chartTron.Series.Add(series1);



                PiePointOptions pointOpts = (PiePointOptions)chartTron.Series[0].PointOptions;
                DevExpress.XtraCharts.PiePointOptions p = new DevExpress.XtraCharts.PiePointOptions();

                p.PointView = DevExpress.XtraCharts.PointView.Values;
                pointOpts.PercentOptions.ValueAsPercent = false;
                p.ValueNumericOptions.Format = NumericFormat.Number;
                p.ValueNumericOptions.Precision = 2;
                series1.PointOptions.PointView = p.PointView;

                series1.LegendPointOptions.Pattern = "{A}";
                //PiePointOptions pointOpts1 = (PiePointOptions)chartTron.Series[0].PointOptions;
                //DevExpress.XtraCharts.PiePointOptions p1 = new DevExpress.XtraCharts.PiePointOptions();

                //p1.PointView = DevExpress.XtraCharts.PointView.Values;
                //pointOpts1.PercentOptions.ValueAsPercent = false;
                //p1.ValueNumericOptions.Format = NumericFormat.Number;
                //p1.ValueNumericOptions.Precision = 2;
                //series1.LegendPointOptions = pointOpts1;
                //((PiePointOptions)series1.LegendPointOptions) = pointOpts1;

                //chartTron.Legend.Visible = false;

                //this.chartTron.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Top;

                //this.chartTron.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;

                //this.chartTron.Legend.MaxVerticalPercentage = 60;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            
            //TuNgay = Convert.ToDateTime("01" + "/" + DateTime.Now.AddMonths(-12).Month.ToString() + "/" + DateTime.Now.AddMonths(-12).Year.ToString());
            DenNgay = Convert.ToDateTime("01" + "/" + DateTime.Now.AddMonths(1).Month.ToString() + "/" + DateTime.Now.AddMonths(1).Year.ToString()).AddDays(-1) ;
            TuNgay = DenNgay.AddMonths(-12);
            LoadDL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDL();
        }
    }
}

