using System.Configuration;
using System.Web.Http;

namespace ApiHardWare.Controllers
{
    public class ManagementController : ApiController
    {
        // GET api/values/5
        [HttpGet]
        public bool GetCheckProcessID()
        {
           string id = ConfigurationManager.AppSettings["id"].ToString();
            if (Commons.GetProcessorId() == Commons.GiaiMaDL(id).Remove(0,8))
                return true;
            else
                return false;
        }
        public string GetProcessID()
        {
            return Commons.GetProcessorId();
        }

      
    }
}
