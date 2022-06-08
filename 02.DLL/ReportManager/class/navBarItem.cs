using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraNavBar;

namespace ReportManager
{
    public class navBarItem : NavBarItem
    {
        public navBarItem() { }

        public navBarItem(string name, int id, string caption, string clickEvent, string selectEvent, string help, string img, string uc, string snamespace)
        {
            this.Name = name;
            this.clickEvent = clickEvent;
            this.selectEvent = selectEvent;
            this.help = help;
            this.img = img;
            this.uc = uc;
        }

        public string name;
        public int id;
        public string caption;
        public string clickEvent;
        public string selectEvent;
        public string help;
        public string img;
        public string uc;
    }

}
