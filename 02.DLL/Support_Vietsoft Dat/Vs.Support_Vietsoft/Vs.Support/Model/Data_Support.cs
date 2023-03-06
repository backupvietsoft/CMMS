using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class Data_Support
    {
        public Int64 iIDSRQ { get; set; }
        public Int64 CustomerID { get; set; }
        public string tenCTY { get; set; }
        public string UName { get; set; }
        public string FullName { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string zalo { get; set; }
        public string rqName { get; set; }
        public int rqTypeID { get; set; }
        public string rqTypeName { get; set; }
        public int rqPrioID { get; set; }
        public string rqPrioName { get; set; }
        public string sign { get; set; }
        public string description { get; set; }
        public string RequestContent { get; set; }
        public string duongDan { get; set; }
        public Int64? PriorIDCnt { get; set; }
        public string rqNamecnt { get; set; }
        public DateTime? sentTime { get; set; }
        public int VSStaffID { get; set; }
        public string VSStaffName { get; set; }
        public string RelContent { get; set; }
        public Boolean Finish { get; set; }
        public int Rating { get; set; }
        public int TTUpdate { get; set; }
        public string Link_TL { get; set; }
        public Int64 ContractID { get; set; }


    }
}
