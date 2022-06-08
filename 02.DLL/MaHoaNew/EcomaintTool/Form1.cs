using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace EcomaintTool
{
    public partial class frmEcomaintTool : Form
    {
        public frmEcomaintTool()
        {
            InitializeComponent();
        }

        private void frmEcomaintTool_Load(object sender, EventArgs e)
        {
            //new XDocument(new XElement("root", new XElement("HDD", "someValue"))).Save(Application.StartupPath + "\\foo.xml");

            new XDocument(
                            new XElement
                            ("CMMSLicense",
                                new XElement("License", "Pro"),
                                new XElement("HARDWARE", "AAAAAAAA"),
                                new XElement("BEGIN", "20171230"),
                                new XElement("EXPIRATION", "20991231"),
                                new XElement("LKEY", "dfsdfsdfs"),
                                new XElement("LICLIMIT", "ZZZZZZ")
                            )
                        ).Save(Application.StartupPath + "\\Ecomaint.xml");

        }



    }
}
