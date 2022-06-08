using System;
using System.Windows.Forms;
using System.Collections;
using System.Management;


namespace HDD_Serial
{
    public partial class frmHDDSerial : Form
    {
        public frmHDDSerial()
        {
            InitializeComponent();
        }

        private void frmHDDSerial_Load(object sender, EventArgs e)
        {
            //try
            //{
            textBox1.Text = Commons.Modules.ObjSystems.GetSerial();

            //    ArrayList hdCollection = new ArrayList();

            //    ManagementObjectSearcher searcher = new
            //        ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            //    foreach (ManagementObject wmi_HD in searcher.Get())
            //    {
            //        HardDrive hd = new HardDrive();
            //        hd.Model = wmi_HD["Model"].ToString();
            //        hd.Type = wmi_HD["InterfaceType"].ToString();

            //        hdCollection.Add(hd);
            //    }

            //    searcher = new
            //        ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            //    int i = 0;
            //    foreach (ManagementObject wmi_HD in searcher.Get())
            //    {
            //        // get the hard drive from collection
            //        // using index
            //        HardDrive hd = (HardDrive)hdCollection[0];

            //        // get the hardware serial no.
            //        if (wmi_HD["SerialNumber"] == null)
            //            hd.SerialNo = "None";
            //        else
            //        {
            //            hd.SerialNo = wmi_HD["SerialNumber"].ToString();
            //            //textBox1.Text = hd.SerialNo;
            //        }
            //        break;
            //    }

            //    foreach (HardDrive hd in hdCollection)
            //    {
            //        textBox1.Text = hd.SerialNo.TrimStart().TrimEnd().Trim() ;
            //        return;
            //    }

                
            //}
            //catch { textBox1.Text = ""; }
        }

        private string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            
            foreach (System.Management.ManagementObject mo in moc)
            {

                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }

            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
