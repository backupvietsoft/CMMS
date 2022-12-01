using System.Data;

namespace InBarCode
{
    public partial class rptVTPT : DevExpress.XtraReports.UI.XtraReport
    {
        //private enum BarCodeTypes
        //{
        //    Codabar, Code11, Code39, Code39Extended, Code93, Code93Extended, Code128, EAN8, EAN13,
        //    GS1128, GS1DataBar, DataMatrix, DataMatrixGS1, Industrial2of5, IntelligentMail,
        //    IntelligentMailPackage, Interleaved2of5, Matrix2of5, CodeMSI, PDF417, PostNet, QRCode, UPCA,
        //    UPCE0, UPCE1, UPCSupplemental2, UPCSupplemental5, UPCShippingContainer
        //};

        public rptVTPT(DataTable tb)
        {
            InitializeComponent();
            this.DataSource = tb;
            xrBarCode1.DataBindings.Add("Text", this.DataSource, "MS_PT");
            lblNgay.DataBindings.Add("Text", this.DataSource, "NGAY","Ngày nhập: {0:dd/MM/yyyy}");
            lblMin.DataBindings.Add("Text", this.DataSource, "MIN","MIN: {0}");
            lblVitri.DataBindings.Add("Text", this.DataSource, "TEN_VI_TRI","Vị trí: {0}");
            lblMa.DataBindings.Add("Text", this.DataSource, "MS_PT");
            lblTen.DataBindings.Add("Text", this.DataSource, "TEN_PT");
            lblKho.DataBindings.Add("Text", this.DataSource, "TEN_KHO");
            //if (loaicode == 0)
            //{
            //    DevExpress.XtraPrinting.BarCode.Code39Generator Code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            //    xrBarCode1.Symbology = Code39Generator1;

            //}
            //else if (loaicode == 1)
            //{
            //    DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            //    code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            //    xrBarCode1.Symbology = code128Generator1;
            //}
            //else
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator QRCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            xrBarCode1.Symbology = QRCodeGenerator1;
            xrBarCode1.Symbology.CalcCheckSum = false;
        }

        private void QRCode()
        {
            //DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator QRCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            xrBarCode1.Symbology = QRCodeGenerator1;
            //this.Detail.Dpi = 254F;
            //this.Detail.HeightF = 555.7918F;
            //this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            //this.Detail.MultiColumn.ColumnCount = 3;
            //this.Detail.MultiColumn.ColumnSpacing = 5F;
            //this.Detail.MultiColumn.ColumnWidth = 500F;
            //this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            //this.Detail.Name = "Detail";


            //this.panel1.Dpi = 254F;
            //this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            //this.panel1.SizeF = new System.Drawing.SizeF(606.3333F, 550.7918F);


            //this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.58333F, 451.7224F);
            //this.xrLabel1.SizeF = new System.Drawing.SizeF(583.8752F, 90.99998F);

            //this.xrBarCode1.Dpi = 254F;
            //this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(10.58333F, 75.02551F);
            //this.xrBarCode1.Module = 5.08F;
            //this.xrBarCode1.SizeF = new System.Drawing.SizeF(583.8752F, 375.6969F);

        }

    }
}
