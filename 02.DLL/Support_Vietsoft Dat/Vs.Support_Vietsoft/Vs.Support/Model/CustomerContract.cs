using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class CustomerContract
    {
        public Int64 ID { get; set; }
        public string ContractNo { get; set; }
        public DateTime SignedDate { get; set; }
        public int TypeID { get; set; }
        public int SoftwareProductID { get; set; }
        public int NumberofLicense { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public Int64? MainContractID { get; set; }
        public DateTime? ValidUntil { get; set; }
        public Int64 CustomerID { get; set; }
        public string Note { get; set; }
    }
}
