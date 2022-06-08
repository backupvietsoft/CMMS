using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using System.IO;

namespace VietShape
{
    public partial class XtraShape : DevExpress.XtraEditors.XtraForm
    {
        private static Point ViTri;
        private static Control MControl;

        private static Shape _Shape;
        private static Guid? _ParentId = null;
        public string ShapeLocal
        {
            get
            {
                string _ShapeLocal = null;
                foreach (Control _Shape in this.Controls)
                {
                    if (_ShapeLocal == null)
                    {
                        _ShapeLocal = "N'" + _Shape.Name + "'";
                    }
                    else
                    {
                        _ShapeLocal = _ShapeLocal + ",N'" + _Shape.Name + "'";
                    }
                }
                return _ShapeLocal;
            }
        }
        public static List<Control> Selectedlist = new List<Control>();



        private static string FontToString(Font _Font)
        {
            TypeConverter _TypeConverter = TypeDescriptor.GetConverter(typeof(Font));
            return _TypeConverter.ConvertToString(_Font);
        }
        private static Font StringToFont(string _StringFont)
        {
            TypeConverter _TypeConverter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)_TypeConverter.ConvertFromString(_StringFont);
        }
        public XtraShape()
        {
            InitializeComponent();
        }
        private void XtraShape_Load(object sender, EventArgs e)
        {
            
            Modules.IXtraShape.CreateMenuHinh();

            ShowShape(null);
        }
        private static Keys ConvertToKeys(string _HkShortcut)
        {
            Keys _HkKeys = Keys.None;
            if (_HkShortcut.Length > 0)
            {
                try
                {
                    foreach (string _HkKey in _HkShortcut.Split('|'))
                    {
                        _HkKeys |= (System.Windows.Forms.Keys)Enum.Parse(typeof(Keys), _HkKey);
                    }
                }
                catch { return System.Windows.Forms.Keys.None; }
            }
            return _HkKeys;
        }
        public static Image ConvertToImage(object _HkImage)
        {
            ImageConverter _HkConverter = new ImageConverter();
            return (Image)_HkConverter.ConvertFrom(_HkImage);
        }

        public Font ConvertToFont(string _HkFont)
        {
            TypeConverter _HkConverter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)_HkConverter.ConvertFromString(_HkFont);
        }

        private void CreateMenuHinh()
        {
            DataTable _TbSource = new DataTable();
            string BTLic = "AAA_VS_LIC" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MGiaiMaTable(BTLic, "LIC_MENU", "MENU_ID", Commons.Modules.UserName, true);

            string _Sql = "SELECT dbo.MENU.MENU_ID, dbo.MENU.MENU_TEXT, dbo.MENU.MENU_ENGLISH, dbo.MENU.MENU_CHINESE, dbo.MENU.MENU_PARENT, dbo.MENU.MENU_INDEX, " +
                      " dbo.MENU.MENU_LINE, dbo.MENU.MENU_FONT, dbo.MENU.SHORT_KEY, dbo.MENU.MENU_IMAGE, dbo.MENU.DLL_NAME, dbo.MENU.PROJECT_NAME, " +
                      " dbo.MENU.CLASS_NAME, dbo.MENU.FUNCTION_NAME, dbo.MENU.MENU_NOTE, dbo.MENU.MENU_POSITION , dbo.MENU.MENU_TYPE " +
                      " FROM         dbo.MENU INNER JOIN " +
                      " dbo.NHOM_MENU ON dbo.MENU.MENU_ID = dbo.NHOM_MENU.MENU_ID INNER JOIN " +
                      " dbo.USERS ON dbo.NHOM_MENU.GROUP_ID = dbo.USERS.GROUP_ID " +
                      " INNER JOIN " +  BTLic + " A ON A.MENU_ID = dbo.MENU.MENU_ID " +
                      " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "' AND AN_HIEN = 1" +
                      " ORDER BY MENU_POSITION, MENU_TYPE , MENU_INDEX";

            _TbSource.Load(SqlHelper.ExecuteReader(Modules.ConnectionString, CommandType.Text, _Sql));
            _TbSource.DefaultView.RowFilter = "MENU_POSITION = 1";
            CreatePopup(_TbSource.DefaultView.ToTable(), ContextMenuStrip_OnePopup);


            _TbSource.DefaultView.RowFilter = "(MENU_POSITION = 2 OR MENU_POSITION = 1 ) AND (MENU_TYPE = 3 OR MENU_TYPE = 4 OR MENU_TYPE IS NULL) ";
            CreatePopup(_TbSource.DefaultView.ToTable(), mnuHinh);
        }

        private void CreatePopupMenu(Boolean MayNX)
        {
            DataTable _TbSource = new DataTable();
            string BTLic = "AAA_VS_LIC" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MGiaiMaTable(BTLic, "LIC_MENU", "MENU_ID", Commons.Modules.UserName, true);

            string _Sql = "SELECT dbo.MENU.MENU_ID, dbo.MENU.MENU_TEXT, dbo.MENU.MENU_ENGLISH, dbo.MENU.MENU_CHINESE, dbo.MENU.MENU_PARENT, dbo.MENU.MENU_INDEX, " +
                      " dbo.MENU.MENU_LINE, dbo.MENU.MENU_FONT, dbo.MENU.SHORT_KEY, dbo.MENU.MENU_IMAGE, dbo.MENU.DLL_NAME, dbo.MENU.PROJECT_NAME, " +
                      " dbo.MENU.CLASS_NAME, dbo.MENU.FUNCTION_NAME, dbo.MENU.MENU_NOTE, dbo.MENU.MENU_POSITION , dbo.MENU.MENU_TYPE " +
                      " FROM         dbo.MENU INNER JOIN " +
                      " dbo.NHOM_MENU ON dbo.MENU.MENU_ID = dbo.NHOM_MENU.MENU_ID INNER JOIN " +
                      " dbo.USERS ON dbo.NHOM_MENU.GROUP_ID = dbo.USERS.GROUP_ID " +
                      " INNER JOIN " + BTLic + " A ON A.MENU_ID = dbo.MENU.MENU_ID " +
                      " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'  AND AN_HIEN = 1 " +
                      " ORDER BY MENU_POSITION, MENU_INDEX";

            _TbSource.Load(SqlHelper.ExecuteReader(Modules.ConnectionString, CommandType.Text, _Sql));
            _TbSource.DefaultView.RowFilter = "MENU_POSITION = 1";
            CreatePopup(_TbSource.DefaultView.ToTable(), ContextMenuStrip_OnePopup);

            //maynx true la nx
            if (!MayNX)
            {
                _TbSource.DefaultView.RowFilter = "(MENU_POSITION = 2) AND (MENU_TYPE = 0 OR MENU_TYPE = 1 OR MENU_TYPE = 4 ) ";
                CreatePopup(_TbSource.DefaultView.ToTable(), ContextMenuStrip_TwoPopup);
            }
            else
            {
                _TbSource.DefaultView.RowFilter = "(MENU_POSITION = 2) AND (MENU_TYPE = 0 OR MENU_TYPE = 2  OR MENU_TYPE = 4) ";
                CreatePopup(_TbSource.DefaultView.ToTable(), ContextMenuStrip_TwoPopup);
                //_TbSource.DefaultView.RowFilter = "(MENU_POSITION = 2) AND (MENU_TYPE = 0 OR MENU_TYPE = 2) ";
                //CreatePopup(_TbSource.DefaultView.ToTable(), menuMay);
            }
        }
        private void CreatePopup(DataTable _TbSource, ContextMenuStrip _ContextMenuStrip)
        {
            _ContextMenuStrip.Items.Clear();
            _TbSource.DefaultView.RowFilter = "MENU_PARENT Is Null";
            DataTable _TbParent = _TbSource.DefaultView.ToTable();
            foreach (DataRow _drPopup in _TbParent.Rows)
            {
                if (!_drPopup.IsNull("MENU_LINE") && (bool)_drPopup["MENU_LINE"] == true)
                {
                    ToolStripSeparator _ToolStripSeparator = new ToolStripSeparator();
                    _ContextMenuStrip.Items.Add(_ToolStripSeparator);
                }
                ToolStripMenuItem _ToolStripMenuItem = new ToolStripMenuItem();
                _ToolStripMenuItem.Tag = _drPopup;
                _ToolStripMenuItem.Name = _drPopup["MENU_ID"].ToString();
                switch (Modules.TypeLanguage)
                {
                    case 1:
                        _ToolStripMenuItem.Text = _drPopup["MENU_ENGLISH"].ToString();
                        break;
                    case 2:
                        _ToolStripMenuItem.Text = _drPopup["MENU_CHINESE"].ToString();
                        break;
                    default:
                        _ToolStripMenuItem.Text = _drPopup["MENU_TEXT"].ToString();
                        break;
                }
                _ToolStripMenuItem.Font = ConvertToFont(_drPopup["MENU_FONT"].ToString());
                _ToolStripMenuItem.ShortcutKeys = ConvertToKeys(_drPopup["SHORT_KEY"].ToString());                

                if (!_drPopup.IsNull("MENU_IMAGE"))
                {
                    _ToolStripMenuItem.Image = ConvertToImage(_drPopup["MENU_IMAGE"]);
                }
                _ContextMenuStrip.Items.Add(_ToolStripMenuItem);
                _TbSource.DefaultView.RowFilter = "MENU_PARENT = '" + _drPopup["MENU_ID"].ToString() + "'";
                if (_TbSource.DefaultView.Count == 0)
                {
                    _ToolStripMenuItem.Click += new EventHandler(ToolStripMenuItem_Click);
                }
                else
                {
                    CreatePopupChild( _TbSource,_ToolStripMenuItem);
                }
            }
        }
        private void CreatePopupChild(DataTable _TbSource,ToolStripMenuItem _ToolStripMenuItemParent)
        {
            _TbSource.DefaultView.RowFilter = "MENU_PARENT = '" + ((DataRow)_ToolStripMenuItemParent.Tag)["MENU_ID"].ToString() + "'";
            DataTable _TbParent = _TbSource.DefaultView.ToTable();
            foreach (DataRow _drPopup in _TbParent.Rows)
            {
                if (!_drPopup.IsNull("MENU_LINE") && (bool)_drPopup["MENU_LINE"] == true)
                {
                    ToolStripSeparator _ToolStripSeparator = new ToolStripSeparator();
                    _ToolStripMenuItemParent.DropDownItems.Add(_ToolStripSeparator);
                }
                ToolStripMenuItem _ToolStripMenuItem = new ToolStripMenuItem();
                _ToolStripMenuItem.Name = _drPopup["MENU_ID"].ToString();
                switch (Modules.TypeLanguage)
                {
                    case 1:
                        _ToolStripMenuItem.Text = _drPopup["MENU_ENGLISH"].ToString();
                        break;
                    case 2:
                        _ToolStripMenuItem.Text = _drPopup["MENU_CHINESE"].ToString();
                        break;
                    default:
                        _ToolStripMenuItem.Text = _drPopup["MENU_TEXT"].ToString();
                        break;
                }
                _ToolStripMenuItem.Font = ConvertToFont(_drPopup["MENU_FONT"].ToString());
                _ToolStripMenuItem.ShortcutKeys = ConvertToKeys(_drPopup["SHORT_KEY"].ToString());
                if (!_drPopup.IsNull("MENU_IMAGE"))
                {
                    _ToolStripMenuItem.Image = ConvertToImage(_drPopup["MENU_IMAGE"]);
                }
                _ToolStripMenuItemParent.DropDownItems.Add(_ToolStripMenuItem);
                _TbSource.DefaultView.RowFilter = "MENU_PARENT = '" + _drPopup["MENU_ID"].ToString() + "'";
                if (_TbSource.DefaultView.Count == 0)
                {
                    _ToolStripMenuItem.Click += new EventHandler(ToolStripMenuItem_Click);
                }
                else
                {
                    CreatePopupChild(_TbSource, _ToolStripMenuItem);
                }
            }
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //DataRow _rowMenu = (DataRow)((ToolStripMenuItem)sender).Tag;

                DataRow _rowMenu = (DataRow)((ToolStripMenuItem)sender).Tag;
                if (!_rowMenu.IsNull("FUNCTION_NAME") && !_rowMenu["FUNCTION_NAME"].ToString().Equals(string.Empty))
                {
                    Assembly _Assembly;
                    if (!_rowMenu.IsNull("DLL_NAME") && !_rowMenu["DLL_NAME"].ToString().Equals(string.Empty))
                    {
                        _Assembly = Assembly.LoadFrom(Application.StartupPath + @"\Dll\" + _rowMenu["DLL_NAME"].ToString());
                        Type _Type = _Assembly.GetType(_rowMenu["PROJECT_NAME"].ToString() + "." + _rowMenu["CLASS_NAME"].ToString());
                        object _Instance = Activator.CreateInstance(_Type, null);
                        MethodInfo _Method = _Instance.GetType().GetMethod(_rowMenu["FUNCTION_NAME"].ToString());
                        _Method.Invoke(_rowMenu["FUNCTION_NAME"].ToString(), null);
                    }
                    else
                    {
                        _Assembly = Assembly.GetExecutingAssembly();
                        try
                        {
                            
                            Type _Type = _Assembly.GetType(_rowMenu["PROJECT_NAME"].ToString() + "." + _rowMenu["CLASS_NAME"].ToString());
                            object _Instance = Activator.CreateInstance(_Type, null);
                            MethodInfo _Method = _Instance.GetType().GetMethod(_rowMenu["FUNCTION_NAME"].ToString());
                            _Method.Invoke(_rowMenu["FUNCTION_NAME"].ToString(), null);
                        }
                        catch
                        {
                            _Assembly = Assembly.GetEntryAssembly();
                            Type _Type = _Assembly.GetType(_rowMenu["PROJECT_NAME"].ToString() + "." + _rowMenu["CLASS_NAME"].ToString());
                            object _Instance = Activator.CreateInstance(_Type, null);
                            MethodInfo _Method = _Instance.GetType().GetMethod(_rowMenu["FUNCTION_NAME"].ToString());                            
                            _Method.Invoke(_rowMenu["FUNCTION_NAME"].ToString(), null);
                        }
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Vietsoft Ecomaint");
            } 
        }

        private static void ShowShape(Guid? ParentId)
        {
            Label _Lable1 = new Label();
            _Lable1.Dock = DockStyle.Fill;
            _Lable1.TextAlign = ContentAlignment.MiddleCenter;
            _Lable1.Text = "Waiting";
            Modules.IXtraShape.Controls.Add(_Lable1);

            //return;
            Modules.IXtraShape.BackgroundImage = null;
            _Lable1.BringToFront();
            Modules.IXtraShape.Controls.Clear();
            
            _Lable1 = new Label();
            _Lable1.Dock = DockStyle.Fill;
            _Lable1.TextAlign = ContentAlignment.MiddleCenter;
            _Lable1.Text = "Waiting";
            _Lable1.BringToFront();


            Modules.IXtraShape.Controls.Add(_Lable1);

            DataTable _TbSource = new DataTable();
            string _Sql;
            string _SqlJoin = "";
            switch (Modules.TypeLanguage)
            {
                case 1:
                    _SqlJoin = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],dbo.NHA_XUONG.TEN_N_XUONG_A AS [Name] " +
                    " FROM dbo.NHA_XUONG INNER JOIN " +
                    " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " +
                    " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                    " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'" +
                    " UNION SELECT N'MY-' + dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name]" +
                    " FROM         dbo.MAY INNER JOIN " +
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " +
                    " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.USERS INNER JOIN " +
                    " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'";                                        
                    break;
                case 2:
                    _SqlJoin = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],dbo.NHA_XUONG.TEN_N_XUONG_H AS [Name] " +
                    " FROM dbo.NHA_XUONG INNER JOIN " +
                    " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " +
                    " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                    " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'" +
                    " UNION SELECT N'MY-' + dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name]" +
                    " FROM         dbo.MAY INNER JOIN " +
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " +
                    " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.USERS INNER JOIN " +
                    " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'"; 
                    break;
                default:
                    _SqlJoin = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],dbo.NHA_XUONG.TEN_N_XUONG AS [Name] " +
                    " FROM dbo.NHA_XUONG INNER JOIN " +
                    " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " +
                    " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                    " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'" +
                    " UNION SELECT N'MY-' + dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name]" +
                    " FROM         dbo.MAY INNER JOIN " +
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " +
                    " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                    " dbo.USERS INNER JOIN " +
                    " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                    " WHERE dbo.USERS.USERNAME = N'" + Modules.UserName + "'"; 
                    break;
            }            
            if (ParentId == null)
            {
                try 
                {
                    Modules.IXtraShape.BackgroundImage = Image.FromFile(Application.StartupPath + @"\root.jpg");
                }
                catch{}
                _Sql = "SELECT dbo.Shapes.[Id],dbo.Shapes.[Code],dbo.Shapes.[ParentId],tblNhaXuong.[Name]," +
                    " dbo.Shapes.[Top],dbo.Shapes.[Left],dbo.Shapes.[Height],dbo.Shapes.[Width],dbo.Shapes.[BackColor]," +
                    " dbo.Shapes.[Font],dbo.Shapes.[FontColor], HINH,ISNULL(BringToFront,0) AS BringToFront ,ISNULL(StretchImage,3) AS StretchImage  " +
                    "FROM dbo.Shapes INNER JOIN (" + _SqlJoin + ") tblNhaXuong ON dbo.Shapes.[Code] = tblNhaXuong.[Code]" +
                    " WHERE ParentId IS NULL AND HINH IS NULL ";
                _Sql = _Sql + " UNION SELECT dbo.Shapes.[Id],dbo.Shapes.[Code],dbo.Shapes.[ParentId],'' AS [Name], dbo.Shapes.[Top],dbo.Shapes.[Left], " +
                    " dbo.Shapes.[Height],dbo.Shapes.[Width],dbo.Shapes.[BackColor], dbo.Shapes.[Font],dbo.Shapes.[FontColor]," +
                    " HINH,ISNULL(BringToFront,0) AS BringToFront ,ISNULL(StretchImage,3) AS StretchImage FROM Shapes WHERE ParentId IS NULL AND HINH IS NOT NULL ";
            }
            else
            {
                try
                {
                    string _MS_N_XUONG = (SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, "Select Code From dbo.Shapes WHERE Id = '" + ParentId.ToString() + "'")).ToString();
                    object _HINH_ANH = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, "SELECT HINH_ANH FROM dbo.NHA_XUONG WHERE MS_N_XUONG = N'" + _MS_N_XUONG.Substring(3, _MS_N_XUONG.Length - 3) + "'");
                    Modules.IXtraShape.BackgroundImage = ConvertToImage(_HINH_ANH);


                    

                }
                catch { }
                _Sql = "SELECT dbo.Shapes.[Id],dbo.Shapes.[Code],dbo.Shapes.[ParentId],tblNhaXuong.[Name]," +
                    " dbo.Shapes.[Top],dbo.Shapes.[Left],dbo.Shapes.[Height],dbo.Shapes.[Width],dbo.Shapes.[BackColor]," +
                    " dbo.Shapes.[Font],dbo.Shapes.[FontColor],HINH,ISNULL(BringToFront,0) AS BringToFront ,ISNULL(StretchImage,3) AS StretchImage " +
                    " FROM dbo.Shapes INNER JOIN ( " + _SqlJoin + ") tblNhaXuong ON dbo.Shapes.[Code] = tblNhaXuong.[Code]" +
                    " WHERE ParentId = '" + ParentId.ToString() + "' AND HINH IS NULL  ";
                _Sql = _Sql + " UNION SELECT dbo.Shapes.[Id],dbo.Shapes.[Code],dbo.Shapes.[ParentId],'' AS [Name], dbo.Shapes.[Top],dbo.Shapes.[Left], " +
                    " dbo.Shapes.[Height],dbo.Shapes.[Width],dbo.Shapes.[BackColor], dbo.Shapes.[Font],dbo.Shapes.[FontColor], " +
                    " HINH,ISNULL(BringToFront,0) AS BringToFront ,ISNULL(StretchImage,3) AS StretchImage FROM Shapes " +
                    " WHERE ParentId = '" + ParentId.ToString() + "'   ";
                //AND HINH IS NOT NULL

            }

            Modules.IXtraShape.BackgroundImageLayout = ImageLayout.Stretch;
            _TbSource.Load(SqlHelper.ExecuteReader(Modules.ConnectionString, CommandType.Text, _Sql));
            _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +                    
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            _Permisstion = "Full access";
            int i = 0;
            foreach (DataRow drow in _TbSource.Rows)
            {
                if (string.IsNullOrEmpty(drow["HINH"].ToString()))
                {
                    Label _Lable = new Label();
                    _Lable.Visible = false;
                    _Lable.Tag = drow["Id"];
                    _Lable.Name = drow["Code"].ToString();
                    _Lable.Text = drow.IsNull("Name") ? drow["Code"].ToString() : drow["Name"].ToString();
                    _Lable.AutoSize = false;
                    _Lable.Top = (int)drow["Top"];
                    _Lable.Left = (int)drow["Left"];
                    _Lable.Height = (int)drow["Height"];
                    _Lable.Width = (int)drow["Width"];
                    _Lable.AllowDrop = true;
                    if (!drow.IsNull("BackColor"))
                    {
                        _Lable.BackColor = Color.FromArgb((int)drow["BackColor"]);
                    }
                    else
                    {
                        _Lable.BackColor = Color.BurlyWood;
                    }
                    if (!drow.IsNull("Font"))
                    {
                        _Lable.Font = StringToFont(drow["Font"].ToString());
                    }
                    if (!drow.IsNull("FontColor"))
                    {
                        _Lable.ForeColor = Color.FromArgb((int)drow["FontColor"]);
                    }
                    _Lable.TextAlign = ContentAlignment.MiddleCenter;
                    if (_Permisstion != null && _Permisstion.ToString() == "Full access")
                    {
                        //_Lable.MouseDown += new MouseEventHandler(Control_MouseDown);
                        _Lable.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                        _Lable.DoubleClick += new System.EventHandler(Control_DoubleClick);
                        

                        _Lable.MouseMove += new System.Windows.Forms.MouseEventHandler(Control_MouseMove);
                        _Lable.MouseDown += new System.Windows.Forms.MouseEventHandler(Control_MouseDown);
                        _Lable.MouseUp += new System.Windows.Forms.MouseEventHandler(Control_MouseUp);
                    }
                    if (i == 0)
                    {
                        //_ParentCode.Substring(3, _ParentCode.Length - 3)
                        if (drow["CODE"].ToString().Substring(0, 2) == "NX")
                        {
                            Modules.IXtraShape.CreatePopupMenu(false);
                            //_Lable.ContextMenuStrip = Modules.IXtraShape.ContextMenuStrip_TwoPopup;
                        }
                        else
                        {
                            Modules.IXtraShape.CreatePopupMenu(true);
                            //_Lable.ContextMenuStrip = Modules.IXtraShape.menuMay;
                        }
                    }


                    _Lable.ContextMenuStrip = Modules.IXtraShape.ContextMenuStrip_TwoPopup;
                    try
                    {
                        if (!(Boolean)drow["BringToFront"])
                        {
                            _Lable.SendToBack();
                            _Lable.AccessibleDescription = "0";
                        }
                        else
                        {
                            _Lable.SendToBack();
                            _Lable.AccessibleDescription = "1";
                        }
                            
                        
                    }
                    catch { _Lable.SendToBack(); _Lable.AccessibleDescription = "0"; }

                    _Lable.AccessibleName = drow["StretchImage"].ToString();

                    Modules.IXtraShape.Controls.Add(_Lable);
                    i++;

                }
                else
                {
                    PictureBox _PictureBox = new PictureBox();
                    _PictureBox.Tag = drow["Id"];
                    _PictureBox.Name = drow["Code"].ToString();
                    byte[] bImage = new byte[0];
                    bImage = (byte[])drow["HINH"];
                    MemoryStream ms = new MemoryStream(bImage);
                    _PictureBox.Image = Image.FromStream(ms);
                    _PictureBox.Visible = false;
                    _PictureBox.Top = (int)drow["Top"];
                    _PictureBox.Left = (int)drow["Left"];
                    _PictureBox.Height = (int)drow["Height"];
                    _PictureBox.Width = (int)drow["Width"];
                    _PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    _PictureBox.SendToBack();
                    _PictureBox.ContextMenuStrip = Modules.IXtraShape.mnuHinh;
                    _PictureBox.AllowDrop = true;
                    try
                    {
                        if (!(Boolean)drow["BringToFront"])
                        {
                            _PictureBox.BringToFront();
                            _PictureBox.AccessibleDescription = "1";
                        }
                        else
                        {
                            _PictureBox.SendToBack();
                            _PictureBox.AccessibleDescription = "0";
                        }
                    }
                    catch { _PictureBox.SendToBack(); _PictureBox.AccessibleDescription = "0"; }

                    _PictureBox.AccessibleName = drow["StretchImage"].ToString();
                    _PictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseClick);
                    _PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseMove);
                    //_PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseDown);
                    _PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseUp);
                    Modules.IXtraShape.Controls.Add(_PictureBox);
                
                
                }

            }
            _ParentId = ParentId;
            try
            {
                foreach (Control _Shape in Modules.IXtraShape.Controls)
                {
                    if (_Shape.GetType().Name == "Label")
                    {
                        if (_Shape.AccessibleDescription == "1")
                            _Shape.BringToFront();
                        else
                            _Shape.AccessibleDescription = "0";
                    }
                }
            }
            catch { }
            try
            {
                foreach (Control _Shape in Modules.IXtraShape.Controls)
                {
                    if (_Shape.GetType().Name == "PictureBox")
                        _Shape.SendToBack();  

                    _Lable1.BringToFront();
                    _Shape.Visible = true;
                }
            }
            catch { }


            
            Modules.IXtraShape.Controls.Remove(_Lable1);
        }
        private void XtraShape_MouseUp(object sender, MouseEventArgs e)
        {
            this.Controls.Remove(_Shape);
        }
        public static void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                Selectedlist.Add((PictureBox)sender);
            }
        }
        public static void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {

                    ((PictureBox)sender).BringToFront();
                    ((PictureBox)sender).Capture = false;
                    if (Modules.IXtraShape.Controls.Contains(_Shape))
                        Modules.IXtraShape.Controls.Remove(_Shape);
                    _Shape = new Shape(((PictureBox)sender));

                    Modules.IXtraShape.Controls.Add(_Shape);
                    _Shape.BringToFront();
                    _Shape.Draw();
                MControl = sender as Control;
                ViTri = e.Location;
                Modules.IXtraShape.Cursor = Cursors.Hand;

                }
                catch { }
            }
            else
            {
            }
            
        }
        public static void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (MControl == null || MControl != sender)
                    return;

                var location = MControl.Location;
                location.Offset(e.Location.X - ViTri.X, e.Location.Y - ViTri.Y);
                MControl.Location = location;            
            }
            catch { }

        }
        public static void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                MControl = null;
                Modules.IXtraShape.Cursor = Cursors.Default;
            }
            catch { }
        }


        public static void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                Selectedlist.Add((Label)sender);
            }
        }


        public static void Control_DoubleClick(object sender, EventArgs e)
        {

            
            if (((Label)sender).Name.Substring(0, 3) == "NX-")
            {
                ShowShape((Guid?)((Label)sender).Tag);
            }


        }
        public static void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ((Label)sender).BringToFront();
                    ((Label)sender).Capture = false;
                    if (Modules.IXtraShape.Controls.Contains(_Shape))
                        Modules.IXtraShape.Controls.Remove(_Shape);
                    _Shape = new Shape(((Label)sender));

                    Modules.IXtraShape.Controls.Add(_Shape);
                    _Shape.BringToFront();
                    _Shape.Draw();
                MControl = sender as Control;
                ViTri = e.Location;
                Modules.IXtraShape.Cursor = Cursors.Hand;                
                }
                catch 
                {}
            }
            else
            {

            }
        }
        public static void Control_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (MControl == null || MControl != sender)
                    return;

                var location = MControl.Location;
                location.Offset(e.Location.X - ViTri.X, e.Location.Y - ViTri.Y);
                MControl.Location = location;            
            }
            catch { }
        }        
        public static void Control_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                MControl = null;
                Modules.IXtraShape.Cursor = Cursors.Default;
            }
            catch { }
        }


        public static void AddNewClick()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                XtraChoice _XtraChoice = new XtraChoice();
                _XtraChoice.ParentId = _ParentId;
                _XtraChoice.ShowDialog(Modules.IXtraShape);
            }
        }

        

        public static void AddNewImage()
        {
            try
            {
                string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                        " FROM         dbo.USERS INNER JOIN " +
                        " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                        " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
                if (_Permisstion != null && _Permisstion.ToString() == "Full access")
                {
                    int _Top = 10;
                    int _Left = 10;



                    OpenFileDialog _OpenFileDialog = new OpenFileDialog();
                    _OpenFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

                    if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        PictureBox _PictureBox = new PictureBox();
                        _PictureBox.Tag = Guid.NewGuid();
                        _PictureBox.Name = "";
                        _PictureBox.Text = "";
                        _PictureBox.AutoSize = false;
                        _PictureBox.Top = _Top;
                        _Top = _Top + 25;
                        _PictureBox.Left = _Left;
                        _Left = _Left + 10;
                        _PictureBox.Height = 45;
                        _PictureBox.Width = 85;

                        
                        _PictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseClick);
                        _PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseMove);
                        _PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseDown);
                        _PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseUp);

                        _PictureBox.ContextMenuStrip = Modules.IXtraShape.mnuHinh;
                        Modules.IXtraShape.Controls.Add(_PictureBox);
                        _PictureBox.BringToFront();
                        _PictureBox.Image = Image.FromFile(_OpenFileDialog.FileName);
                        _PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        _PictureBox.Image.Tag = _OpenFileDialog.FileName;

                        _PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch { }
        }                   
        public static void GoBackClick()
        {
            if(_ParentId != null)
            {
                object _ObjScalar = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, "SELECT ParentId FROM dbo.Shapes WHERE Id = '" + _ParentId.ToString() + "'");
                if (_ObjScalar.Equals(DBNull.Value))
                {
                    ShowShape(null);
                }
                else
                {
                    ShowShape((Guid)_ObjScalar);
                }
            }
        }
        public static void RefereshClick()
        {
            //Modules.IXtraShape.Controls.Clear();
            ShowShape(_ParentId);
        }
        public static void SaveClick()
        {
            try
            {
                string _Sql;
                foreach (Control _Shape in Modules.IXtraShape.Controls)
                {
                    if (_Shape.GetType().Name == "PictureBox")
                    {
                        if (_Shape.Tag != null)
                        {
                            _Sql = "SELECT COUNT(*) FROM dbo.Shapes WHERE Id = '" + _Shape.Tag.ToString() + "'";
                            if ((int)SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql) > 0)
                            {
                                _Sql = "UPDATE dbo.Shapes SET [Top] = " + (_Shape.Top - Modules.IXtraShape.DisplayRectangle.Top) + "," +
                                    " [Height] = " + _Shape.Height + ",[Left] = " + (_Shape.Left - Modules.IXtraShape.DisplayRectangle.Left) + ",[Width] = " + _Shape.Width +
                                    " , BringToFront = " + (_Shape.AccessibleDescription == null ? 0 : int.Parse(_Shape.AccessibleDescription.ToString())) +
                                    " , StretchImage = " + (_Shape.AccessibleName == null ? 0 : int.Parse(_Shape.AccessibleName.ToString())) +
                                    " WHERE Id = '" + _Shape.Tag.ToString() + "'";
                                SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);
                            }
                            else
                            {


                                _Sql = "INSERT INTO dbo.Shapes([Id],[Code],[ParentId],[Top],[Left],[Height],[Width],[BringToFront],[StretchImage] ) VALUES('" +
                                    _Shape.Tag.ToString() + "',N'" + _Shape.Name + "'," + (_ParentId == null ? "NULL" : "'" + _ParentId.ToString() + "'") + "," +
                                    (_Shape.Top - Modules.IXtraShape.DisplayRectangle.Top) + "," + (_Shape.Left - Modules.IXtraShape.DisplayRectangle.Left) + "," +
                                    _Shape.Height + "," + _Shape.Width + ", " + (_Shape.AccessibleDescription == null ? 0 : int.Parse(_Shape.AccessibleDescription.ToString())) + ", " +
                                    (_Shape.AccessibleName == null ? 0 : int.Parse(_Shape.AccessibleName.ToString())) + " )";
                                SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);

                                _Sql = " UPDATE dbo.Shapes SET HINH = (SELECT BulkColumn FROM " +
                                            " Openrowset( Bulk N'" + ((PictureBox)_Shape).Image.Tag + "', Single_Blob) AS HINH) " +
                                            " WHERE Id = '" + _Shape.Tag.ToString() + "'";
                                SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);
                            }

                        }
                    }
                    else
                    {
                        if (_Shape.Tag != null)
                        {
                            _Sql = "SELECT COUNT(*) FROM dbo.Shapes WHERE Id = " + (_Shape.Tag == null ? "NULL" : "'" + _Shape.Tag.ToString() + "'");
                            if ((int)SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql) > 0)
                            {
                                _Sql = "UPDATE dbo.Shapes SET [Top] = " + (_Shape.Top - Modules.IXtraShape.DisplayRectangle.Top) + "," +
                                    " [Height] = " + _Shape.Height + ",[Left] = " + (_Shape.Left - Modules.IXtraShape.DisplayRectangle.Left) + ",[Width] = " + _Shape.Width +
                                    " ,[BackColor] = " + _Shape.BackColor.ToArgb() + ",[FontColor] = " + _Shape.ForeColor.ToArgb() + ",[Font] = N'" + FontToString(_Shape.Font) + "', " +
                                    " BringToFront = " + (_Shape.AccessibleDescription == null ? "NULL" : "'" + _Shape.AccessibleDescription.ToString() + "'") +
                                    " WHERE Id = " + (_Shape.Tag == null ? "NULL" : "'" + _Shape.Tag.ToString() + "'");
                            }
                            else
                            {
                                _Sql = "INSERT INTO dbo.Shapes([Id],[Code],[ParentId],[Top],[Left],[Height],[Width],[BackColor], " +
                                    " [Font],[FontColor],[BringToFront]) VALUES(" +
                                    (_Shape.Tag == null ? "NULL" : "'" + _Shape.Tag.ToString() + "'") + ",N'" + _Shape.Name + "'," + (_ParentId == null ? "NULL" : "'" + _ParentId.ToString() + "'") + "," +
                                    (_Shape.Top - Modules.IXtraShape.DisplayRectangle.Top) + "," + (_Shape.Left - Modules.IXtraShape.DisplayRectangle.Left) + "," +
                                    _Shape.Height + "," + _Shape.Width + "," + _Shape.BackColor.ToArgb() + ",N'" + FontToString(_Shape.Font) + "'," + _Shape.ForeColor.ToArgb() +
                                    " ," + (_Shape.AccessibleDescription == null ? "NULL" : "'" + _Shape.AccessibleDescription.ToString() + "'") + " )";
                            }
                            SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);
                        }
                    }

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "Vietsoft Ecomaint"); }
        }

        public static void OpenClick()
        {
            if (Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) == "NX-")
            {
                ShowShape((Guid?)Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Tag);
            }
        }
        public static void BackColorClick()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                ColorDialog _ColorDialog = new ColorDialog();
                _ColorDialog.Color = Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.BackColor;
                if (_ColorDialog.ShowDialog() == DialogResult.OK)
                {
                    Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.BackColor = _ColorDialog.Color;
                }
            }
        }
        public static void FontColorClick()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                ColorDialog _ColorDialog = new ColorDialog();
                _ColorDialog.Color = Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.ForeColor;
                if (_ColorDialog.ShowDialog() == DialogResult.OK)
                {
                    Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.ForeColor = _ColorDialog.Color;
                }
            }
        }
        public static void TransparentClick()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.BackColor = Color.Transparent;
            }
        }
        public static void FontClick()
        {
            string _Sql = " SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                FontDialog _FontDialog = new FontDialog();
                _FontDialog.Font = Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Font;
                if (_FontDialog.ShowDialog() == DialogResult.OK)
                {
                    Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Font = _FontDialog.Font;
                }
            }
        }
        public static void RemoveClick()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                try
                {
                    _Sql = "SELECT COUNT(*)  FROM Shapes WHERE ParentId = '" + Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Tag.ToString() + "'";
                    int GTri = 0;
                    GTri = (int)SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);

                    if (GTri > 0)
                    {
                        MessageBox.Show("Còn đối tượng con, Bạn không thể xóa!", "VietsoftEcomaint");
                        return;
                    }


                    if (MessageBox.Show("Bạn có chắc muốn xóa " + Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Text + "?", "VietsoftEcomaint", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            _Sql = "DELETE dbo.Shapes WHERE Id = '" + Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Tag.ToString() + "'";
                            SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);
                            Modules.IXtraShape.Controls.Remove(Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl);
                            Modules.IXtraShape.Controls.Remove(_Shape);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Vietsoft Ecomaint");
                        }

                    }
                }
                catch {
                    if (MessageBox.Show("Bạn có chắc muốn xóa ?", "VietsoftEcomaint", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            _Sql = "DELETE dbo.Shapes WHERE Id = '" + Modules.IXtraShape.mnuHinh.SourceControl.Tag.ToString() + "'";
                            SqlHelper.ExecuteNonQuery(Modules.ConnectionString, CommandType.Text, _Sql);
                            Modules.IXtraShape.Controls.Remove(Modules.IXtraShape.mnuHinh.SourceControl);
                            Modules.IXtraShape.Controls.Remove(_Shape);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Vietsoft Ecomaint");
                        }

                    }
                }
            }
        }

        public static void BringToFront1()
        {
            string _Sql = "SELECT dbo.NHOM_FORM.QUYEN " +
                    " FROM dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                try
                {
                    (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).BringToFront();
                    //SendToBack
                    (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleDescription = "1";
                }
                catch
                {
                    (Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl as Label).BringToFront();
                    //SendToBack
                    (Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl as Label).AccessibleDescription = "1";
                }
            }
            else {
                return;
            }
        }

        public static void SendToBack1()
        {
            string _Sql = "SELECT     dbo.NHOM_FORM.QUYEN " +
                    " FROM         dbo.USERS INNER JOIN " +
                    " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " +
                    " WHERE dbo.NHOM_FORM.FORM_NAME = N'" + Modules.IXtraShape.Name + "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
            object _Permisstion = SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
            if (_Permisstion != null && _Permisstion.ToString() == "Full access")
            {
                try
                {
                    (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SendToBack();
                    //SendToBack
                    (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleDescription = "0";
                }
                catch 
                {
                    (Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl as Label).SendToBack();
                    //SendToBack
                    (Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl as Label).AccessibleDescription = "0";                    
                }
            }
        }

        public static void LockImage()
        {            
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).MouseDown -= new MouseEventHandler(XtraShape.PictureBox_MouseDown);
        }
        public static void UnLockImage()
        {
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).MouseDown += new MouseEventHandler(XtraShape.PictureBox_MouseDown);
        }

        public static void AutoSize1()
        {
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SizeMode = PictureBoxSizeMode.AutoSize;
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleName = "1";
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        public static void FullScreen()
        {          
            PictureBox pic = new PictureBox();
            pic = (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox);
            int _Top;
            int _Left;
            int _Width;
            int _Height;
            pic.Dock = DockStyle.Fill;
            _Top = pic.Top;
            _Left = pic.Left;
            _Width = pic.Width;
            _Height = pic.Height;
            pic.Dock = DockStyle.None;
            pic.Top = _Top;
            pic.Left = _Left;
            pic.Width = _Width;
            pic.Height = _Height;
        }

        public static void CenterImage()
        {
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SizeMode = PictureBoxSizeMode.CenterImage;
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleName = "2";
        }

        public static void StretchImage()
        {
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            (Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleName = "3";
        }

        public static void Normal()
        {
            //(Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).SizeMode = PictureBoxSizeMode.Normal;
            //(Modules.IXtraShape.mnuHinh.SourceControl as PictureBox).AccessibleName = "4";
        }

        private void XtraShape_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (MControl != null) MControl = null;
                if (Modules.IXtraShape.Cursor != Cursors.Default) Modules.IXtraShape.Cursor = Cursors.Default;
            }
            catch { }
        }

    }


}