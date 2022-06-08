using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VietShape
{
    public static class Modules
    {
        private static XtraShape _XtraShape = new XtraShape();
        public static XtraShape IXtraShape
        {
            get { return _XtraShape; }
            set { _XtraShape = value; }
        }

        private static string _ConnectionString = "Data Source=" + Commons.IConnections.Server + ";Initial Catalog=" + Commons.IConnections.Database + ";User ID=" + Commons.IConnections.Username + ";Password=" + Commons.IConnections.Password + "";
        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private static int _TypeLange = Commons.Modules.TypeLanguage;
        public static int TypeLanguage
        {
            get { return _TypeLange; }
            set { _TypeLange = value; }
        }

        private static string _UserName = Commons.Modules.UserName;
        public static string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }
}
