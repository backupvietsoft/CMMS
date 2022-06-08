using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VietShape
{
    public partial class XtraChoice : DevExpress.XtraEditors.XtraForm
    {
        DataTable _TbSource;
        private Guid? _ParentId = null;
        int _Top = 10;
        int _Left = 10;
        public Guid? ParentId
        {
            set { _ParentId = value; }
        }

        public XtraChoice()
        {
            InitializeComponent();
        }
        
        private void XtraChoice_Load(object sender, EventArgs e)
        {
            _TbSource = new DataTable();
            string _Sql;
            string _ShapeLocal = Modules.IXtraShape.ShapeLocal;
            if (_ParentId == null)
            {
                if (_ShapeLocal != null)
                {
                    switch (Modules.TypeLanguage)
                    {
                        case 1:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG_A AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND N'NX-' + dbo.NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        case 2:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG_H AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND N'NX-' + dbo.NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        default:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND N'NX-' + dbo.NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                    }                    
                }
                else
                {
                    switch (Modules.TypeLanguage)
                    {
                        case 1:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG_A AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        case 2:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG_H AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        default:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code], dbo.NHA_XUONG.TEN_N_XUONG AS [Name] " +
                        " FROM dbo.USERS INNER JOIN " +
                        " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                        " dbo.NHOM_NHA_XUONG ON dbo.NHOM.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID INNER JOIN " +
                        " dbo.NHA_XUONG ON dbo.NHOM_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG " +
                        " WHERE MS_CHA IS NULL AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                    }   
                }
            }
            else
            {
                _Sql = "SELECT Code FROM dbo.Shapes WHERE Id = '" + _ParentId.ToString() + "'";
                string _ParentCode = (string)SqlHelper.ExecuteScalar(Modules.ConnectionString, CommandType.Text, _Sql);
                _ParentCode = _ParentCode.Substring(3, _ParentCode.Length - 3);
                if (_ShapeLocal != null)
                {
                    switch (Modules.TypeLanguage)
                    {
                        case 1:
                            _Sql = "SELECT N'NX-' + MS_N_XUONG AS [Code],TEN_N_XUONG_A AS [Name] FROM dbo.NHA_XUONG WHERE MS_CHA = N'" +
                               _ParentCode + "' AND N'NX-' + MS_N_XUONG NOT IN (" + _ShapeLocal + ") UNION" +
                               " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                               " FROM dbo.NHOM_MAY INNER JOIN " +
                               " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                               " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                               " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.USERS INNER JOIN " +
                               " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                               " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                               "' AND N'MY-' + dbo.MAY.MS_MAY NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";

                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],TEN_N_XUONG_A AS [Name] " +
                                " FROM         dbo.NHA_XUONG INNER JOIN " +
                                " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " +
                                " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                                " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID" +
                                " WHERE MS_CHA = N'" +
                                _ParentCode + "' AND N'NX-' + NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "' UNION" +
                                " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                                " FROM dbo.NHOM_MAY INNER JOIN " +
                                " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                                " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                                " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                " dbo.USERS INNER JOIN " +
                                " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                                " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                                "' AND N'MY-' + dbo.MAY.MS_MAY NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";

                            break;
                        case 2:
                               _Sql = "SELECT N'NX-' + MS_N_XUONG AS [Code],TEN_N_XUONG_H AS [Name] FROM dbo.NHA_XUONG WHERE MS_CHA = N'" +
                               _ParentCode + "' AND N'NX-' + MS_N_XUONG NOT IN (" + _ShapeLocal + ") UNION" +
                               " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                               " FROM dbo.NHOM_MAY INNER JOIN " +
                               " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                               " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                               " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.USERS INNER JOIN " +
                               " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                               " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                               "' AND N'MY-' + dbo.MAY.MS_MAY NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";

                               _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],TEN_N_XUONG_H AS [Name] " +
                                   " FROM         dbo.NHA_XUONG INNER JOIN " +
                                   " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " +
                                   " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                                   " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID" +
                                   " WHERE MS_CHA = N'" +
                                   _ParentCode + "' AND N'NX-' + NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "' UNION" +
                                   " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                                   " FROM dbo.NHOM_MAY INNER JOIN " +
                                   " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                                   " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                                   " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                   " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                   " dbo.USERS INNER JOIN " +
                                   " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                                   " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                                   "' AND N'MY-' + dbo.MAY.MS_MAY NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";

                            break;
                        default:
                            _Sql = "SELECT N'NX-' + dbo.NHA_XUONG.MS_N_XUONG AS [Code],TEN_N_XUONG AS [Name] " + 
                                " FROM         dbo.NHA_XUONG INNER JOIN " + 
                                " dbo.NHOM_NHA_XUONG ON dbo.NHA_XUONG.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN " + 
                                " dbo.NHOM ON dbo.NHOM_NHA_XUONG.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " +
                                " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID" +            
                                " WHERE MS_CHA = N'" +
                                _ParentCode + "' AND N'NX-' + NHA_XUONG.MS_N_XUONG NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "' UNION" +
                                " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                                " FROM dbo.NHOM_MAY INNER JOIN " +
                                " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                                " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                                " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                                " dbo.USERS INNER JOIN " +
                                " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                                " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                                "' AND N'MY-' + dbo.MAY.MS_MAY NOT IN (" + _ShapeLocal + ") AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                    }                                       
                    
                }
                else
                {
                    switch (Modules.TypeLanguage)
                    {
                        case 1:
                            _Sql = "SELECT N'NX-' + MS_N_XUONG AS [Code],TEN_N_XUONG_A AS [Name] FROM dbo.NHA_XUONG WHERE MS_CHA = N'" +
                               _ParentCode + "'  UNION" +
                               " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                               " FROM dbo.NHOM_MAY INNER JOIN " +
                               " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                               " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                               " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                               " dbo.USERS INNER JOIN " +
                               " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                               " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                               "'  AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        case 2:
                            _Sql = "SELECT N'NX-' + MS_N_XUONG AS [Code],TEN_N_XUONG_H AS [Name] FROM dbo.NHA_XUONG WHERE MS_CHA = N'" +
                            _ParentCode + "'  UNION" +
                            " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                            " FROM dbo.NHOM_MAY INNER JOIN " +
                            " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                            " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                            " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                            " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                            " dbo.USERS INNER JOIN " +
                            " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                            " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                            "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                        default:
                            _Sql = "SELECT N'NX-' + MS_N_XUONG AS [Code],TEN_N_XUONG AS [Name] FROM dbo.NHA_XUONG WHERE MS_CHA = N'" +
                            _ParentCode + "'  UNION" +
                            " SELECT  N'MY-'+ dbo.MAY.MS_MAY AS [Code], dbo.MAY.TEN_MAY AS [Name] " +
                            " FROM dbo.NHOM_MAY INNER JOIN " +
                            " dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN dbo.MAY_NHA_XUONG_NGAY_MAX ON " +
                            " dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG_NGAY_MAX.MS_MAY INNER JOIN " +
                            " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                            " dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " +
                            " dbo.USERS INNER JOIN " +
                            " dbo.NHOM ON dbo.USERS.GROUP_ID = dbo.NHOM.GROUP_ID ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM.GROUP_ID " +
                            " WHERE dbo.MAY_NHA_XUONG_NGAY_MAX.MS_N_XUONG = N'" + _ParentCode +
                            "' AND dbo.USERS.USERNAME = N'" + Modules.UserName + "'";
                            break;
                    }

                   
                }
            }
            _TbSource.Load(SqlHelper.ExecuteReader(Modules.ConnectionString, CommandType.Text, _Sql));
            listBoxControl_Source.DataSource = _TbSource;
            listBoxControl_Source.ValueMember = "Code";
            listBoxControl_Source.DisplayMember = "Name";            
        }      

        private void simpleButton_Add_Click(object sender, EventArgs e)
        {
            Label _Lable = new Label();
            _Lable.Tag = Guid.NewGuid();
            if (_TbSource.Rows.Count > 0)
            {
                _Lable.Name = ((DataRowView)listBoxControl_Source.SelectedItem)["Code"].ToString();
                _Lable.Text = ((DataRowView)listBoxControl_Source.SelectedItem)["Name"].ToString();
                _Lable.AutoSize = false;
                _Lable.Top = _Top;
                _Top = _Top + 25;
                _Lable.Left = _Left;
                _Left = _Left + 10;
                _Lable.Height = 45;
                _Lable.AccessibleDescription = "1";
                
                _Lable.Width = 85;
                _Lable.TextAlign = ContentAlignment.MiddleCenter;
                //_Lable.MouseDown += new MouseEventHandler(XtraShape.Control_MouseDown);
                _Lable.MouseClick += new System.Windows.Forms.MouseEventHandler(XtraShape.Control_MouseClick);
                _Lable.MouseMove += new System.Windows.Forms.MouseEventHandler(XtraShape.Control_MouseMove);
                _Lable.MouseDown += new System.Windows.Forms.MouseEventHandler(XtraShape.Control_MouseDown);
                _Lable.MouseUp += new System.Windows.Forms.MouseEventHandler(XtraShape.Control_MouseUp);

                _Lable.ContextMenuStrip = Modules.IXtraShape.ContextMenuStrip_TwoPopup;
                Modules.IXtraShape.Controls.Add(_Lable);
                _Lable.BringToFront();
                _TbSource.Rows.Remove(((DataRowView)listBoxControl_Source.SelectedItem).Row);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để thêm!");
            }

        }

        private void simpleButton_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}