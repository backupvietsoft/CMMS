using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class CustomerContact
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public string Position { get; set; }
        public string ContactName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
