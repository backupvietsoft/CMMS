using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class Customer
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public string CompanyFullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string CEO { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HDBT_DA_KY { get; set; }
        public string Ghi_Chu { get; set; }
        public Int64 CustomerID_TMP { get; set; }
    }
}
