namespace VietShape
{
    partial class frmDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PiePointOptions piePointOptions2 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartTron = new DevExpress.XtraCharts.ChartControl();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.45622F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.54378F));
            this.tableLayoutPanel1.Controls.Add(this.chartTron, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 633);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartTron
            // 
            this.chartTron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTron.Location = new System.Drawing.Point(3, 3);
            this.chartTron.Name = "chartTron";
            this.chartTron.PaletteName = "Flow";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            pieSeriesLabel1.LineVisible = true;
            pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
            series1.Label = pieSeriesLabel1;
            piePointOptions1.PercentOptions.ValueAsPercent = false;
            piePointOptions1.PointView = DevExpress.XtraCharts.PointView.SeriesName;
            piePointOptions1.ValueNumericOptions.Precision = 0;
            series1.LegendPointOptions = piePointOptions1;
            series1.Name = "Series 1";
            piePointOptions2.PercentOptions.ValueAsPercent = false;
            piePointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            piePointOptions2.ValueNumericOptions.Precision = 0;
            series1.PointOptions = piePointOptions2;
            series1.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Ascending;
            series1.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1;
            series1.SynchronizePointOptions = false;
            pieSeriesView1.RuntimeExploding = false;
            series1.View = pieSeriesView1;
            this.chartTron.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            pieSeriesLabel2.LineVisible = true;
            this.chartTron.SeriesTemplate.Label = pieSeriesLabel2;
            pieSeriesView2.RuntimeExploding = false;
            this.chartTron.SeriesTemplate.View = pieSeriesView2;
            this.chartTron.Size = new System.Drawing.Size(573, 310);
            this.chartTron.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDashBoard";
            this.Text = "frmDashBoard";
            this.Load += new System.EventHandler(this.frmDashBoard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTron)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraCharts.ChartControl chartTron;
        private System.Windows.Forms.Button button1;
    }
}