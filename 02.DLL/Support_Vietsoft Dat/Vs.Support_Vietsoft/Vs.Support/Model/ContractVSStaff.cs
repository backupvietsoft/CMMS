using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class ContractVSStaff
    {
        public Int64 ID { get; set; }
        public Int64 ContractID { get; set; }
        public int iID1 { get; set; } // iID VSSTaff kiem tra trung
        public int VSStaffID { get; set; } // ID them moi
        public Boolean Valid { get; set; }
        public string Note { get; set; }
    }
}
