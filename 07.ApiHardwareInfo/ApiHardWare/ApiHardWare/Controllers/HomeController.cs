using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiHardWare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public string MaHoa(string chuoi)
        {
            return Commons.Encrypt(chuoi,true);
        }
        public string GiaiMa(string chuoi)
        {
            return Commons.Decrypt(chuoi.Replace(' ','+'), true);
        }
    }
}
