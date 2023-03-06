using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Support.Model
{
    class VietsoftStaff
    {
        public Int64 ID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Zalo { get; set; }
        public int? VSDeptID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean InActive { get; set; }
        public Boolean MainService { get; set; }
    }
}
