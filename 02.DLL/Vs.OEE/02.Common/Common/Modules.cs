using System;
using System.Collections.Generic;

namespace Commons
{
    public class Modules
    {

        private static string _ModuleName;
        private static string myHost = System.Net.Dns.GetHostName();

        public static List<string> lstControlName
        {
            get
            {
                return _lstControlName;
            }
            set
            {
                _lstControlName = value;
            }
        }

        // Private Shared _lstControlName As New List(Of String)(New String() {"LookUpEdit", "Label", "RadioButton", "CheckBox", "GroupBox", "TabPage", "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl", "Button", "SimpleButton", "RadioGroup", "CheckedListBoxControl", "XtraTabControl", "GridControl", "DataGridView", "DataGridViewNew", "DataGridViewEditor", "NavBarControl", "navBarControl", "TextEdit", "TextBox", "ComboBox", "ButtonEdit", "MemoEdit"}) '"DateEdit",

        private static List<string> _lstControlName = new List<string>(new string[] { "LookUpEdit", "RadioButton", "CheckBox", "GroupBox", "TabPage", "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl", "Button", "SimpleButton", "RadioGroup", "CheckedListBoxControl", "XtraTabControl", "GridControl", "DataGridView", "DataGridViewNew", "DataGridViewEditor", "NavBarControl", "navBarControl", "BarManager", "TextEdit", "tablePanel", "navigationFrame", "navigationPage", "LayoutControlGroup" });

        //dinh nghia ID cho cac form danh muc khi tra ve
        private static string _sId;
        public static string sId
        {
            get
            {
                return _sId;
            }
            set
            {
                _sId = value;
            }
        }


        //định nghĩa giờ làm mặc định
        private static int _iGio;
        public static int iGio
        {
            get
            {
                return _iGio;
            }
            set
            {
                _iGio = value;
            }
        }

        //định nghĩa ngày nghĩ ngày làm việc(0:không nghĩ---------- 1: nghĩ chủ nhật, 2----- nghĩ thứ 7,chủ nhật)
        private static int _iNNghi;
        public static int iNNghi
        {
            get
            {
                return _iNNghi;
            }
            set
            {
                _iNNghi = value;
            }
        }
        //dinh nghia cau store dung cho toan bo danh muc
        private static string _sPS;
        public static string sPS
        {
            get
            {
                return _sPS;
            }
            set
            {
                _sPS = value;
            }
        }
        private static Int64 _iCongNhan;
        public static Int64 iCongNhan
        {
            get
            {
                return _iCongNhan;
            }
            set
            {
                _iCongNhan = value;
            }
        }

        //dinh nghia phan quyen
        //dtTempt.Rows.Add(1, "Full access");
        //dtTempt.Rows.Add(2, "Read Only");
        private static int _iPermission;
        public static int iPermission
        {
            get
            {
                return _iPermission;
            }
            set
            {
                _iPermission = value;
            }
        }


        public static string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                _ModuleName = value;
            }
        }
        
        private static string _UserName = string.Empty;
        public static string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        private static int _TypeLanguage;
        public static int TypeLanguage
        {
            get
            {
                return _TypeLanguage;
            }
            set
            {
                _TypeLanguage = value;
            }
        }

        private static OSystems _OSystems = new OSystems();
        public static OSystems ObjSystems
        {
            get
            {
                return _OSystems;
            }
            set
            {
                _OSystems = value;
            }
        }


        private static OXtraGrid _OXtraGrid = new OXtraGrid();
        public static OXtraGrid OXtraGrid
        {
            get
            {
                return _OXtraGrid;
            }
            set
            {
                _OXtraGrid = value;
            }
        }

        private static OLanguages _OLanguages = new OLanguages();
        public static OLanguages ObjLanguages
        {
            get
            {
                return _OLanguages;
            }
            set
            {
                _OLanguages = value;
            }
        }
        
        // Xac dinh thong tin cong ty
        private static string _sPrivate;
        public static string sPrivate
        {
            get
            {
                return _sPrivate.ToUpper();
            }
            set
            {
                _sPrivate = value.ToUpper();
            }
        }

        private static int _iSoLeSL;
        public static int iSoLeSL
        {
            get
            {
                return _iSoLeSL;
            }
            set
            {
                _iSoLeSL = value;
            }
        }

        private static int _iSoLeDG;
        public static int iSoLeDG
        {
            get
            {
                return _iSoLeDG;
            }
            set
            {
                _iSoLeDG = value;
            }
        }
        
        private static int _iSoLeTT;
        public static int iSoLeTT
        {
            get
            {
                return _iSoLeTT;
            }
            set
            {
                _iSoLeTT = value;
            }
        }

        private static string _sSoLeSL;
        public static string sSoLeSL
        {
            get
            {
                return _sSoLeSL;
            }
            set
            {
                _sSoLeSL = value;
            }
        }

        private static string _sSoLeDG;
        public static string sSoLeDG
        {
            get
            {
                return _sSoLeDG;
            }
            set
            {
                _sSoLeDG = value;
            }
        }

        private static string _sSoLeTT;
        public static string sSoLeTT
        {
            get
            {
                return _sSoLeTT;
            }
            set
            {
                _sSoLeTT = value;
            }
        }
        
        private static string _sTenNhanVienMD;
        public static string sTenNhanVienMD
        {
            get
            {
                return _sTenNhanVienMD;
            }
            set
            {
                _sTenNhanVienMD = value;
            }
        }

        private static string _sMaNhanVienMD;
        public static string sMaNhanVienMD
        {
            get
            {
                return _sMaNhanVienMD;
            }
            set
            {
                _sMaNhanVienMD = value;
            }
        }
        
    }
}
