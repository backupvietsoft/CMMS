using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;

namespace ApiHardWare.Controllers
{
    public class ManagementController : ApiController
    {
        public string GetProcessID()
        {
            string sHDD = "";
            try
            {
                System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
                {
                    sHDD = wmi_HD["SerialNumber"].ToString().Trim();
                }
            }
            catch { sHDD = ""; }

            if (sHDD == "")
            {
                System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                try
                {
                    foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
                    {
                        sHDD = wmi_HD["SerialNumber"].ToString();
                    }
                }
                catch { sHDD = ""; }
            }
            return sHDD;
        }
        //public string GetLince()
        //{
        //    string id = ConfigurationManager.AppSettings["id"].ToString();
        //    return Commons.Encrypt(Commons.Decrypt(id, true).Split('!')[1], true);
        //}
        //public string GetProcessID()
        //{
        //    return Commons.GetProcessorId();
        //}

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public string getAPI(string sAPI)
        {
            string Resulst = "";
            switch (sAPI.ToUpper())
            {
                case "HDD":
                    Resulst=CheckHDD() + "!" + LicCom();
                    break;
                case "LIC":
                    Resulst = LicNumber();
                    break;
                case "LICCOM":
                    Resulst = LicCom();
                    break;
                case "HDDLIC":
                    Resulst = CheckHDD() + "!" + LicNumber();
                    break;
                case "LICW":
                    Resulst  = CheckHDD() + "!" + LicNumberWeb();
                    break;
                default:
                    Resulst = "FALSE";
                    break;
            }
            return Commons.Encrypt(Resulst, true);
        }

        private string CheckHDD()
        {
            try
            {
                string sHDD = "";
                try
                {
                    System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                    foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
                    {
                        sHDD = wmi_HD["SerialNumber"].ToString().Trim();
                    }
                }
                catch { sHDD = ""; }

                if (sHDD == "")
                {
                    System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                    try
                    {
                        foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
                        {
                            sHDD = wmi_HD["SerialNumber"].ToString();
                        }
                    }
                    catch { sHDD = ""; }
                }

                XDocument document = XDocument.Load(HttpContext.Current.Server.MapPath("~/Resource/config.xml"));
                var LKEY = from r in document.Descendants("VietsoftCMMS")
                           select r.Element("LKEY").Value;
                string sXML = "";
                string sDNgay = "";

                foreach (var r in LKEY)
                {
                    sXML = r.ToString();
                }
                sXML = Commons.Decrypt(sXML, true);
                sXML = sXML.Substring(2);
                sDNgay = sXML;
                sXML = sXML.Substring(0, sXML.Length - 10);
                sDNgay = sDNgay.Substring(sHDD.Length, sDNgay.Length - sHDD.Length - 2);
                if (sXML == sHDD)
                    return "TRUE!" + sDNgay;
                else return "FALSE!" + sDNgay;
            }
            catch
            {
                return "FALSE!19000101";
            }

        }
        private string LicNumber()
        {
            try
            {
                XDocument document = XDocument.Load(HttpContext.Current.Server.MapPath("~/Resource/config.xml"));
                var LICLIMIT = from r in document.Descendants("VietsoftCMMS")
                               select r.Element("LICLIMIT").Value;
                string sXML = "";
                string sDNgay = "";
                foreach (var r in LICLIMIT)
                {
                    sXML = r.ToString();
                }
                sXML = Commons.Decrypt(sXML, true);
                sDNgay = sXML;
                sXML = sXML.Substring(13);
                sXML = sXML.Substring(0, sXML.Length - 5);
                sDNgay = sDNgay.Substring(5).Substring(0, 8);
                return sXML + "!" + sDNgay;
            }
            catch (Exception ex)
            {
                return "0!19000101";
            }
        }
        private string LicNumberWeb()
        {
            try
            {
                XDocument document = XDocument.Load(HttpContext.Current.Server.MapPath("~/Resource/config.xml"));
                var LICLIMIT = from r in document.Descendants("VietsoftCMMS")
                               select r.Element("LW").Value;
                string sXML = "";
                foreach (var r in LICLIMIT)
                {
                    sXML = r.ToString();
                }
                string[] sArr = sXML.Split('|');
                return sArr[0] + "!" + sArr[1];
            }
            catch (Exception ex)
            {
                return "Demo!0";
            }
        }
        private string LicCom()
        {
            try
            {
                XDocument document = XDocument.Load(HttpContext.Current.Server.MapPath("~/Resource/config.xml"));
                var LICLIMIT = from r in document.Descendants("VietsoftCMMS")
                               select r.Element("LIC").Value;
                string sXML = "";
                foreach (var r in LICLIMIT)
                {
                    sXML = r.ToString();
                }
                sXML = Commons.Decrypt(sXML, true);
                return sXML;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}
