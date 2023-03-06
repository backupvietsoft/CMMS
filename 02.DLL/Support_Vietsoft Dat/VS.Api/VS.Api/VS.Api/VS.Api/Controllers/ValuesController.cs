using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VS.Api.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    [Route("VS.Api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet]
        public List<HANG_HOA> GetMay()
        {

            List<HANG_HOA> list = new List<HANG_HOA>();
            //list.Add(new MAY{ MS_MAY = "21",TEN ="AAAA",TENANH ="BBBB"});

            list = DBUtils.ExecuteQueryList<HANG_HOA>("SELECT MS_HH,TEN_HH FROM dbo.HANG_HOA");
            return list;

        }

       

    }
    public class HANG_HOA
    {

        //[JsonProperty(PropertyName = "MS_MAY")]
        //public string MS_MAY { get; set; }

        //[JsonProperty(PropertyName = "TEN")]
        //public string TEN { get; set; }

        //[JsonProperty(PropertyName = "TENANH")]
        //public string TENANH { get; set; }

        public string MS_HH { get; set; }
        public string TEN_HH { get; set; }
    }

}
