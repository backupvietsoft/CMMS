using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Vietsoft.Admin
{
    public class Menuvs : MenuStrip
    {
        /// <summary>
        /// Khai báo
        /// </summary>
        private DataTable _tbMenu = new DataTable();
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public Menuvs()
        {
            this.AllowDrop = false;
            this.AllowItemReorder = false;
            this.AllowMerge = true;
            this.AutoSize = true;
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }
        /// <summary>
        /// Kiểm tra và loại bỏ đường kẻ dư
        /// </summary>
        private void CheckRemoveLine(DataTable tbMenu)
        {
            try
            {
                for (int i = 0; i < tbMenu.Rows.Count - 1; i++)
                {
                    DataRow vRow = tbMenu.Rows[i];
                    DataRow vRowNext = tbMenu.Rows[i + 1];
                    if (Convert.ToBoolean(vRow["MENU_LINE"]) && Convert.ToBoolean(vRowNext["MENU_LINE"]))
                    {
                        tbMenu.Rows.RemoveAt(i + 1);
                        i--;

                    }
                }
                if (tbMenu.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(tbMenu.Rows[0]["MENU_LINE"]))
                    {
                        tbMenu.Rows.RemoveAt(0);
                    }
                }
                if (tbMenu.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(tbMenu.Rows[tbMenu.Rows.Count - 1]["MENU_LINE"]))
                    {
                        tbMenu.Rows.RemoveAt(tbMenu.Rows.Count - 1);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Tạo ShortcutKeys
        /// </summary>
        private Keys ShortCutKey(string strID)
        {
            try
            {
                Sqlvs sqlShort = new Sqlvs();
                System.Data.DataTable tbShort = new DataTable();
                tbShort.Load(sqlShort.ExecuteReader(CommandType.StoredProcedure, "SP_S_SHCUT_DESIGN", strID));
                switch (int.Parse(tbShort.Rows[0]["SHT_ID"].ToString()))
                {
                    case 1:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Control | Keys.D1;
                            case "2":
                                return Keys.Control | Keys.D2;
                            case "3":
                                return Keys.Control | Keys.D3;
                            case "4":
                                return Keys.Control | Keys.D4;
                            case "5":
                                return Keys.Control | Keys.D5;
                            case "6":
                                return Keys.Control | Keys.D6;
                            case "7":
                                return Keys.Control | Keys.D7;
                            case "8":
                                return Keys.Control | Keys.D8;
                            case "9":
                                return Keys.Control | Keys.D9;
                            case "10":
                                return Keys.Control | Keys.D0;
                            case "11":
                                return Keys.Control | Keys.F1;
                            case "12":
                                return Keys.Control | Keys.F2;
                            case "13":
                                return Keys.Control | Keys.F3;
                            case "14":
                                return Keys.Control | Keys.F4;
                            case "15":
                                return Keys.Control | Keys.F5;
                            case "16":
                                return Keys.Control | Keys.F6;
                            case "17":
                                return Keys.Control | Keys.F7;
                            case "18":
                                return Keys.Control | Keys.F8;
                            case "19":
                                return Keys.Control | Keys.F9;
                            case "20":
                                return Keys.Control | Keys.F10;
                            case "21":
                                return Keys.Control | Keys.F11;
                            case "22":
                                return Keys.Control | Keys.F12;
                            default:
                                return Keys.Control | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    case 2:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Alt | Keys.D1;
                            case "2":
                                return Keys.Alt | Keys.D2;
                            case "3":
                                return Keys.Alt | Keys.D3;
                            case "4":
                                return Keys.Alt | Keys.D4;
                            case "5":
                                return Keys.Alt | Keys.D5;
                            case "6":
                                return Keys.Alt | Keys.D6;
                            case "7":
                                return Keys.Alt | Keys.D7;
                            case "8":
                                return Keys.Alt | Keys.D8;
                            case "9":
                                return Keys.Alt | Keys.D9;
                            case "10":
                                return Keys.Alt | Keys.D0;
                            case "11":
                                return Keys.Alt | Keys.F1;
                            case "12":
                                return Keys.Alt | Keys.F2;
                            case "13":
                                return Keys.Alt | Keys.F3;
                            case "14":
                                return Keys.Alt | Keys.F4;
                            case "15":
                                return Keys.Alt | Keys.F5;
                            case "16":
                                return Keys.Alt | Keys.F6;
                            case "17":
                                return Keys.Alt | Keys.F7;
                            case "18":
                                return Keys.Alt | Keys.F8;
                            case "19":
                                return Keys.Alt | Keys.F9;
                            case "20":
                                return Keys.Alt | Keys.F10;
                            case "21":
                                return Keys.Alt | Keys.F11;
                            case "22":
                                return Keys.Alt | Keys.F12;
                            default:
                                return Keys.Alt | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    case 3:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Control | Keys.Alt | Keys.D1;
                            case "2":
                                return Keys.Control | Keys.Alt | Keys.D2;
                            case "3":
                                return Keys.Control | Keys.Alt | Keys.D3;
                            case "4":
                                return Keys.Control | Keys.Alt | Keys.D4;
                            case "5":
                                return Keys.Control | Keys.Alt | Keys.D5;
                            case "6":
                                return Keys.Control | Keys.Alt | Keys.D6;
                            case "7":
                                return Keys.Control | Keys.Alt | Keys.D7;
                            case "8":
                                return Keys.Control | Keys.Alt | Keys.D8;
                            case "9":
                                return Keys.Control | Keys.Alt | Keys.D9;
                            case "10":
                                return Keys.Control | Keys.Alt | Keys.D0;
                            case "11":
                                return Keys.Control | Keys.Alt | Keys.F1;
                            case "12":
                                return Keys.Control | Keys.Alt | Keys.F2;
                            case "13":
                                return Keys.Control | Keys.Alt | Keys.F3;
                            case "14":
                                return Keys.Control | Keys.Alt | Keys.F4;
                            case "15":
                                return Keys.Control | Keys.Alt | Keys.F5;
                            case "16":
                                return Keys.Control | Keys.Alt | Keys.F6;
                            case "17":
                                return Keys.Control | Keys.Alt | Keys.F7;
                            case "18":
                                return Keys.Control | Keys.Alt | Keys.F8;
                            case "19":
                                return Keys.Control | Keys.Alt | Keys.F9;
                            case "20":
                                return Keys.Control | Keys.Alt | Keys.F10;
                            case "21":
                                return Keys.Control | Keys.Alt | Keys.F11;
                            case "22":
                                return Keys.Control | Keys.Alt | Keys.F12;
                            default:
                                return Keys.Control | Keys.Alt | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    case 4:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Control | Keys.Shift | Keys.D1;
                            case "2":
                                return Keys.Control | Keys.Shift | Keys.D2;
                            case "3":
                                return Keys.Control | Keys.Shift | Keys.D3;
                            case "4":
                                return Keys.Control | Keys.Shift | Keys.D4;
                            case "5":
                                return Keys.Control | Keys.Shift | Keys.D5;
                            case "6":
                                return Keys.Control | Keys.Shift | Keys.D6;
                            case "7":
                                return Keys.Control | Keys.Shift | Keys.D7;
                            case "8":
                                return Keys.Control | Keys.Shift | Keys.D8;
                            case "9":
                                return Keys.Control | Keys.Shift | Keys.D9;
                            case "10":
                                return Keys.Control | Keys.Shift | Keys.D0;
                            case "11":
                                return Keys.Control | Keys.Shift | Keys.F1;
                            case "12":
                                return Keys.Control | Keys.Shift | Keys.F2;
                            case "13":
                                return Keys.Control | Keys.Shift | Keys.F3;
                            case "14":
                                return Keys.Control | Keys.Shift | Keys.F4;
                            case "15":
                                return Keys.Control | Keys.Shift | Keys.F5;
                            case "16":
                                return Keys.Control | Keys.Shift | Keys.F6;
                            case "17":
                                return Keys.Control | Keys.Shift | Keys.F7;
                            case "18":
                                return Keys.Control | Keys.Shift | Keys.F8;
                            case "19":
                                return Keys.Control | Keys.Shift | Keys.F9;
                            case "20":
                                return Keys.Control | Keys.Shift | Keys.F10;
                            case "21":
                                return Keys.Control | Keys.Shift | Keys.F11;
                            case "22":
                                return Keys.Control | Keys.Shift | Keys.F12;
                            default:
                                return Keys.Control | Keys.Shift | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    case 5:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Alt | Keys.Shift | Keys.D1;
                            case "2":
                                return Keys.Alt | Keys.Shift | Keys.D2;
                            case "3":
                                return Keys.Alt | Keys.Shift | Keys.D3;
                            case "4":
                                return Keys.Alt | Keys.Shift | Keys.D4;
                            case "5":
                                return Keys.Alt | Keys.Shift | Keys.D5;
                            case "6":
                                return Keys.Alt | Keys.Shift | Keys.D6;
                            case "7":
                                return Keys.Alt | Keys.Shift | Keys.D7;
                            case "8":
                                return Keys.Alt | Keys.Shift | Keys.D8;
                            case "9":
                                return Keys.Alt | Keys.Shift | Keys.D9;
                            case "10":
                                return Keys.Alt | Keys.Shift | Keys.D0;
                            case "11":
                                return Keys.Alt | Keys.Shift | Keys.F1;
                            case "12":
                                return Keys.Alt | Keys.Shift | Keys.F2;
                            case "13":
                                return Keys.Alt | Keys.Shift | Keys.F3;
                            case "14":
                                return Keys.Alt | Keys.Shift | Keys.F4;
                            case "15":
                                return Keys.Alt | Keys.Shift | Keys.F5;
                            case "16":
                                return Keys.Alt | Keys.Shift | Keys.F6;
                            case "17":
                                return Keys.Alt | Keys.Shift | Keys.F7;
                            case "18":
                                return Keys.Alt | Keys.Shift | Keys.F8;
                            case "19":
                                return Keys.Alt | Keys.Shift | Keys.F9;
                            case "20":
                                return Keys.Alt | Keys.Shift | Keys.F10;
                            case "21":
                                return Keys.Alt | Keys.Shift | Keys.F11;
                            case "22":
                                return Keys.Alt | Keys.Shift | Keys.F12;
                            default:
                                return Keys.Alt | Keys.Shift | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    case 6:
                        switch (tbShort.Rows[0]["SHT_KEY"].ToString())
                        {
                            case "1":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D1;
                            case "2":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D2;
                            case "3":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D3;
                            case "4":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D4;
                            case "5":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D5;
                            case "6":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D6;
                            case "7":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D7;
                            case "8":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D8;
                            case "9":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D9;
                            case "10":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.D0;
                            case "11":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F1;
                            case "12":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F2;
                            case "13":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F3;
                            case "14":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F4;
                            case "15":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F5;
                            case "16":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F6;
                            case "17":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F7;
                            case "18":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F8;
                            case "19":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F9;
                            case "20":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F10;
                            case "21":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F11;
                            case "22":
                                return Keys.Control | Keys.Alt | Keys.Shift | Keys.F12;
                            default:
                                return Keys.Control | Keys.Alt | Keys.Shift | (Keys)(int)tbShort.Rows[0]["SHT_KEY"].ToString()[0];
                        }
                    default:
                        return Keys.Control | Keys.F24;
                }
            }
            catch
            {
                return Keys.Control | Keys.F24;
            }

        }
        /// <summary>
        /// Tạo menu
        /// </summary>
        public void LoadMenuItem()
        {
            try
            {
                this.Items.Clear();
                Sqlvs sqlMenu = new Sqlvs();
                _tbMenu.Load(sqlMenu.ExecuteReader(CommandType.StoredProcedure, "SP_S_MENU_DESIGN", Adminvs.Language, Adminvs.UserName));
                DataColumn[] mnKey = new DataColumn[1];
                mnKey[0] = _tbMenu.Columns["ID"];
                _tbMenu.PrimaryKey = mnKey;

                DataTable tbMenuParent = new DataView(_tbMenu, "MENU_P_ID Is NULL", "MENU_INDEX", DataViewRowState.CurrentRows).ToTable();
                CheckRemoveLine(tbMenuParent);
                foreach (DataRow rMenu in tbMenuParent.Rows)
                {
                    if (!rMenu.IsNull("MENU_LINE") && Convert.ToBoolean(rMenu["MENU_LINE"]))
                    {
                        ToolStripMenuItem stMenuSeprator = new ToolStripMenuItem();
                        stMenuSeprator.Name = rMenu["MENU_ID"].ToString().Trim();
                        stMenuSeprator.Text = "|";
                        this.Items.Add(stMenuSeprator);
                    }
                    else
                    {
                        ToolStripMenuItem stMenuItem = new ToolStripMenuItem();
                        stMenuItem.Name = rMenu["MENU_ID"].ToString().Trim();
                        stMenuItem.Tag = rMenu["ID"].ToString().Trim();
                        if (!rMenu.IsNull("MENU_FONT") && !rMenu["MENU_FONT"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.Font = Fontvs.ToFont(rMenu["MENU_FONT"].ToString().Trim());
                        }
                        if (!rMenu.IsNull("MENU_F_COL") && !rMenu["MENU_F_COL"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.ForeColor = Colorvs.ToColor(rMenu["MENU_F_COL"].ToString().Trim());
                        }
                        if (!rMenu.IsNull("MENU_B_COL") && !rMenu["MENU_B_COL"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.BackColor = Colorvs.ToColor(rMenu["MENU_B_COL"].ToString().Trim());
                        }                       
                        if (rMenu.IsNull("MENU_T") || rMenu["MENU_T"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.Text = rMenu["MENU_ID"].ToString().Trim();
                        }
                        else
                        {
                            stMenuItem.Text = rMenu["MENU_T"].ToString().Trim();
                        }
                        if (!rMenu.IsNull("MENU_SHT_K") && !rMenu["MENU_SHT_K"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.ShortcutKeys = ShortCutKey(rMenu["MENU_SHT_K"].ToString());
                        }
                        this.Items.Add(stMenuItem);
                        if (!rMenu.IsNull("MENU_PROJE") && !rMenu.IsNull("MENU_CLASS") && !rMenu.IsNull("MENU_FTION"))
                        {
                            stMenuItem.Click += new System.EventHandler(Menu_Click);
                        }
                        AddMenuItem(stMenuItem);
                    }
                }
                this.ItemAdded += new ToolStripItemEventHandler(MenuInfo_ItemAdded);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Tạo menu con
        /// </summary>
        private void AddMenuItem(ToolStripMenuItem stmnItem)
        {
            try
            {
                DataTable tbMenuItem = new DataView(_tbMenu, "MENU_P_ID = '" + stmnItem.Tag.ToString().Trim() + "'", "MENU_INDEX", DataViewRowState.CurrentRows).ToTable();
                CheckRemoveLine(tbMenuItem);
                foreach (DataRow rMenu in tbMenuItem.Rows)
                {
                    if (!rMenu.IsNull("MENU_LINE") && Convert.ToBoolean(rMenu["MENU_LINE"]))
                    {
                        ToolStripSeparator stMenuSepator = new ToolStripSeparator();
                        stMenuSepator.Name = rMenu["MENU_ID"].ToString().Trim();
                        stmnItem.DropDownItems.Add(stMenuSepator);
                    }
                    else
                    {
                        ToolStripMenuItem stMenuItem = new ToolStripMenuItem();
                        stMenuItem.Name = rMenu["MENU_ID"].ToString().Trim();
                        stMenuItem.Tag = rMenu["ID"].ToString().Trim();
                        if (!rMenu.IsNull("MENU_FONT") && !rMenu["MENU_FONT"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.Font = Fontvs.ToFont(rMenu["MENU_FONT"].ToString().Trim());
                        }
                        if (!rMenu.IsNull("MENU_F_COL") && !rMenu["MENU_F_COL"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.ForeColor = Colorvs.ToColor(rMenu["MENU_F_COL"].ToString().Trim());
                        }
                        if (!rMenu.IsNull("MENU_B_COL") || !rMenu["MENU_B_COL"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.BackColor = Colorvs.ToColor(rMenu["MENU_B_COL"].ToString().Trim());
                        }                       
                        if (rMenu.IsNull("MENU_T") || rMenu["MENU_T"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.Text = rMenu["MENU_ID"].ToString().Trim();
                        }
                        else
                        {
                            stMenuItem.Text = rMenu["MENU_T"].ToString().Trim();
                        }

                        if (!rMenu.IsNull("MENU_SHT_K") && !rMenu["MENU_SHT_K"].ToString().Trim().Equals(String.Empty))
                        {
                            stMenuItem.ShortcutKeys = ShortCutKey(rMenu["MENU_SHT_K"].ToString());
                        }
                        stmnItem.DropDownItems.Add(stMenuItem);
                        if (!rMenu.IsNull("MENU_PROJE") && !rMenu.IsNull("MENU_CLASS") && !rMenu.IsNull("MENU_FTION"))
                        {
                            stMenuItem.Click += new System.EventHandler(Menu_Click);
                        }
                        AddMenuItem(stMenuItem);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Thêm mới item
        /// </summary>
        void MenuInfo_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Trim().Equals(string.Empty))
            {
                e.Item.Visible = false;
            }
        }
        /// <summary>
        /// Menu Click
        /// </summary>
        private void Menu_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow rMenu = _tbMenu.Rows.Find(((ToolStripMenuItem)sender).Tag.ToString().Trim());
                if (!rMenu.IsNull("MENU_FTION") && !rMenu["MENU_FTION"].ToString().Trim().Equals(String.Empty))
                {
                    Assembly vAssembly;
                    if (!rMenu.IsNull("MENU_DLL") && !rMenu["MENU_DLL"].ToString().Trim().Equals(String.Empty))
                    {
                        vAssembly = Assembly.LoadFrom(Application.StartupPath + @"\dll\" + rMenu["MENU_DLL"].ToString().Trim());
                        Type vType = vAssembly.GetType(rMenu["MENU_PROJE"].ToString().Trim() + "." + rMenu["MENU_CLASS"].ToString().Trim());
                        object vInstance = Activator.CreateInstance(vType, null);
                        MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["MENU_FTION"].ToString().Trim());
                        vMethod.Invoke(rMenu["MENU_FTION"].ToString().Trim(), null);
                    }
                    else
                    {
                        vAssembly = Assembly.GetExecutingAssembly();
                        try
                        {
                            Type vType = vAssembly.GetType(rMenu["MENU_PROJE"].ToString().Trim() + "." + rMenu["MENU_CLASS"].ToString().Trim());
                            object vInstance = Activator.CreateInstance(vType, null);
                            MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["MENU_FTION"].ToString().Trim());
                            vMethod.Invoke(rMenu["MENU_FTION"].ToString().Trim(), null);
                        }
                        catch
                        {
                            vAssembly = Assembly.GetEntryAssembly();
                            Type vType = vAssembly.GetType(rMenu["MENU_PROJE"].ToString().Trim() + "." + rMenu["MENU_CLASS"].ToString().Trim());
                            object vInstance = Activator.CreateInstance(vType, null);
                            MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["MENU_FTION"].ToString().Trim());
                            vMethod.Invoke(rMenu["MENU_FTION"].ToString().Trim(), null);
                        }
                    }
                }
            }
            catch
            {
                Messagevs.Show("MsgRunFunctionError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
