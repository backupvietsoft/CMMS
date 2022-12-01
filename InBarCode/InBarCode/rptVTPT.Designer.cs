namespace InBarCode
{
    partial class rptVTPT
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.panel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblKho = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMa = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTen = new DevExpress.XtraReports.UI.XRLabel();
            this.lblVitri = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMin = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNgay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 421.7708F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.ColumnSpacing = 10F;
            this.Detail.MultiColumn.ColumnWidth = 900F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            // 
            // panel1
            // 
            this.panel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.panel1.CanGrow = false;
            this.panel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblKho,
            this.lblMa,
            this.lblTen,
            this.lblVitri,
            this.lblMin,
            this.lblNgay,
            this.xrBarCode1});
            this.panel1.Dpi = 254F;
            this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 11.75926F);
            this.panel1.Name = "panel1";
            this.panel1.SizeF = new System.Drawing.SizeF(886.7709F, 392.4375F);
            // 
            // lblKho
            // 
            this.lblKho.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblKho.Dpi = 254F;
            this.lblKho.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKho.LocationFloat = new DevExpress.Utils.PointFloat(310.5833F, 310.5834F);
            this.lblKho.Multiline = true;
            this.lblKho.Name = "lblKho";
            this.lblKho.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblKho.SizeF = new System.Drawing.SizeF(564.4167F, 71.64917F);
            this.lblKho.StylePriority.UseBorders = false;
            this.lblKho.StylePriority.UseFont = false;
            this.lblKho.StylePriority.UseTextAlignment = false;
            this.lblKho.Text = "Spare part";
            this.lblKho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblMa
            // 
            this.lblMa.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblMa.Dpi = 254F;
            this.lblMa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMa.LocationFloat = new DevExpress.Utils.PointFloat(10.58333F, 310.5834F);
            this.lblMa.Multiline = true;
            this.lblMa.Name = "lblMa";
            this.lblMa.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblMa.SizeF = new System.Drawing.SizeF(300F, 71.6492F);
            this.lblMa.StylePriority.UseBorders = false;
            this.lblMa.StylePriority.UseFont = false;
            this.lblMa.StylePriority.UseTextAlignment = false;
            this.lblMa.Text = "ORI-084";
            this.lblMa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblTen
            // 
            this.lblTen.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblTen.Dpi = 254F;
            this.lblTen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTen.LocationFloat = new DevExpress.Utils.PointFloat(310.5833F, 10.58334F);
            this.lblTen.Multiline = true;
            this.lblTen.Name = "lblTen";
            this.lblTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTen.SizeF = new System.Drawing.SizeF(564.4167F, 124.74F);
            this.lblTen.StylePriority.UseBorders = false;
            this.lblTen.StylePriority.UseFont = false;
            this.lblTen.StylePriority.UseTextAlignment = false;
            this.lblTen.Text = "ORING AS568-261";
            this.lblTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblVitri
            // 
            this.lblVitri.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblVitri.Dpi = 254F;
            this.lblVitri.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblVitri.LocationFloat = new DevExpress.Utils.PointFloat(310.5833F, 252.1633F);
            this.lblVitri.Multiline = true;
            this.lblVitri.Name = "lblVitri";
            this.lblVitri.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblVitri.SizeF = new System.Drawing.SizeF(564.4166F, 58.42F);
            this.lblVitri.StylePriority.UseBorders = false;
            this.lblVitri.StylePriority.UseFont = false;
            this.lblVitri.StylePriority.UseTextAlignment = false;
            this.lblVitri.Text = "Vị trí: B101";
            this.lblVitri.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblMin
            // 
            this.lblMin.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblMin.Dpi = 254F;
            this.lblMin.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblMin.LocationFloat = new DevExpress.Utils.PointFloat(310.5833F, 193.7434F);
            this.lblMin.Multiline = true;
            this.lblMin.Name = "lblMin";
            this.lblMin.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblMin.SizeF = new System.Drawing.SizeF(564.4166F, 58.41998F);
            this.lblMin.StylePriority.UseBorders = false;
            this.lblMin.StylePriority.UseFont = false;
            this.lblMin.StylePriority.UseTextAlignment = false;
            this.lblMin.Text = "Min: 10";
            this.lblMin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblNgay
            // 
            this.lblNgay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblNgay.Dpi = 254F;
            this.lblNgay.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblNgay.LocationFloat = new DevExpress.Utils.PointFloat(310.5833F, 135.3234F);
            this.lblNgay.Multiline = true;
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblNgay.SizeF = new System.Drawing.SizeF(564.4166F, 58.42F);
            this.lblNgay.StylePriority.UseBorders = false;
            this.lblNgay.StylePriority.UseFont = false;
            this.lblNgay.StylePriority.UseTextAlignment = false;
            this.lblNgay.Text = "Ngày nhập:02/10/2017";
            this.lblNgay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(10.58334F, 10.58333F);
            this.xrBarCode1.Module = 5.08F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(300F, 300F);
            this.xrBarCode1.StylePriority.UseBorders = false;
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            this.xrBarCode1.Symbology = qrCodeGenerator1;
            this.xrBarCode1.Text = "BOM-03-05";
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 130F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Visible = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 130F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Visible = false;
            // 
            // rptVTPT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(130, 130, 130, 130);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 12;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel panel1;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel lblKho;
        private DevExpress.XtraReports.UI.XRLabel lblMa;
        private DevExpress.XtraReports.UI.XRLabel lblTen;
        private DevExpress.XtraReports.UI.XRLabel lblVitri;
        private DevExpress.XtraReports.UI.XRLabel lblMin;
        private DevExpress.XtraReports.UI.XRLabel lblNgay;
    }
}
