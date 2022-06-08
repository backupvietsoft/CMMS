using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Vietsoft
{
    public class MenuEditor : MenuStrip
    {
        /// <summary>
        /// Khai báo
        /// </summary>
        private DataTable _TbMenu = new DataTable();
        /// <summary>
        /// MenuEditor
        /// </summary>
        public MenuEditor()
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
        /// CheckRemoveLine
        /// </summary>
        private void CheckRemoveLine(DataTable TbMenu)
        {
            try
            {
                for (int i = 0; i < TbMenu.Rows.Count - 1; i++)
                {
                    DataRow rMenu = TbMenu.Rows[i];
                    DataRow rMenuNext = TbMenu.Rows[i + 1];
                    if (rMenu["LINE"].Equals(true) && rMenuNext["LINE"].Equals (true))
                    {
                        TbMenu.Rows.RemoveAt(i + 1);
                        i--;

                    }
                }
                if (TbMenu.Rows.Count > 0)
                {
                    if (TbMenu.Rows[0]["LINE"].Equals (true ))
                    {
                        TbMenu.Rows.RemoveAt(0);
                    }
                }
                if (TbMenu.Rows.Count > 0)
                {
                    if (TbMenu.Rows[TbMenu.Rows.Count - 1]["LINE"].Equals (true))
                    {
                        TbMenu.Rows.RemoveAt(TbMenu.Rows.Count - 1);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// ShortcutKeys
        /// </summary>
        private Shortcut ShortCutKey(string Shortcut)
        {
            switch (Shortcut)
            {
                case "Alt0":
                    return System.Windows.Forms.Shortcut.Alt0;
                case "Alt1":
                    return System.Windows.Forms.Shortcut.Alt1;
                case "Alt2":
                    return System.Windows.Forms.Shortcut.Alt2;
                case "Alt3":
                    return System.Windows.Forms.Shortcut.Alt3;
                case "Alt4":
                    return System.Windows.Forms.Shortcut.Alt4;
                case "Alt5":
                    return System.Windows.Forms.Shortcut.Alt5;
                case "Alt6":
                    return System.Windows.Forms.Shortcut.Alt6;
                case "Alt7":
                    return System.Windows.Forms.Shortcut.Alt7;
                case "Alt8":
                    return System.Windows.Forms.Shortcut.Alt8;
                case "Alt9":
                    return System.Windows.Forms.Shortcut.Alt9;
                case "AltBksp":
                    return System.Windows.Forms.Shortcut.AltBksp;
                case "AltDownArrow":
                    return System.Windows.Forms.Shortcut.AltDownArrow;
                case "AltF1":
                    return System.Windows.Forms.Shortcut.AltF1;
                case "AltF10":
                    return System.Windows.Forms.Shortcut.AltF10;
                case "AltF11":
                    return System.Windows.Forms.Shortcut.AltF11;
                case "AltF12":
                    return System.Windows.Forms.Shortcut.AltF12;
                case "AltF2":
                    return System.Windows.Forms.Shortcut.AltF2;
                case "AltF3":
                    return System.Windows.Forms.Shortcut.AltF3;
                case "AltF4":
                    return System.Windows.Forms.Shortcut.AltF4;
                case "AltF5":
                    return System.Windows.Forms.Shortcut.AltF5;
                case "AltF6":
                    return System.Windows.Forms.Shortcut.AltF6;
                case "AltF7":
                    return System.Windows.Forms.Shortcut.AltF7;
                case "AltF8":
                    return System.Windows.Forms.Shortcut.AltF8;
                case "AltF9":
                    return System.Windows.Forms.Shortcut.AltF9;
                case "AltLeftArrow":
                    return System.Windows.Forms.Shortcut.AltLeftArrow;
                case "AltRightArrow":
                    return System.Windows.Forms.Shortcut.AltRightArrow;
                case "AltUpArrow":
                    return System.Windows.Forms.Shortcut.AltUpArrow;
                case "Ctrl0":
                    return System.Windows.Forms.Shortcut.Ctrl0;
                case "Ctrl1":
                    return System.Windows.Forms.Shortcut.Ctrl1;
                case "Ctrl2":
                    return System.Windows.Forms.Shortcut.Ctrl2;
                case "Ctrl3":
                    return System.Windows.Forms.Shortcut.Ctrl3;
                case "Ctrl4":
                    return System.Windows.Forms.Shortcut.Ctrl4;
                case "Ctrl5":
                    return System.Windows.Forms.Shortcut.Ctrl5;
                case "Ctrl6":
                    return System.Windows.Forms.Shortcut.Ctrl6;
                case "Ctrl7":
                    return System.Windows.Forms.Shortcut.Ctrl7;
                case "Ctrl8":
                    return System.Windows.Forms.Shortcut.Ctrl8;
                case "Ctrl9":
                    return System.Windows.Forms.Shortcut.Ctrl9;
                case "CtrlA":
                    return System.Windows.Forms.Shortcut.CtrlA;
                case "CtrlB":
                    return System.Windows.Forms.Shortcut.CtrlB;
                case "CtrlC":
                    return System.Windows.Forms.Shortcut.CtrlC;
                case "CtrlD":
                    return System.Windows.Forms.Shortcut.CtrlD;
                case "CtrlDel":
                    return System.Windows.Forms.Shortcut.CtrlDel;
                case "CtrlE":
                    return System.Windows.Forms.Shortcut.CtrlE;
                case "CtrlF":                                    
                    return System.Windows.Forms.Shortcut.CtrlF;
                case "CtrlF1":
                    return System.Windows.Forms.Shortcut.CtrlF1;
                case "CtrlF10":
                    return System.Windows.Forms.Shortcut.CtrlF10;
                case "CtrlF11":
                    return System.Windows.Forms.Shortcut.CtrlF11;
                case "CtrlF12":
                    return System.Windows.Forms.Shortcut.CtrlF12;
                case "CtrlF2":
                    return System.Windows.Forms.Shortcut.CtrlF2;
                case "CtrlF3":
                    return System.Windows.Forms.Shortcut.CtrlF3;
                case "CtrlF4":
                    return System.Windows.Forms.Shortcut.CtrlF4;
                case "CtrlF5":
                    return System.Windows.Forms.Shortcut.CtrlF5;
                case "CtrlF6":
                    return System.Windows.Forms.Shortcut.CtrlF6;
                case "CtrlF7":
                    return System.Windows.Forms.Shortcut.CtrlF7;
                case "CtrlF8":
                    return System.Windows.Forms.Shortcut.CtrlF8;
                case "CtrlF9":
                    return System.Windows.Forms.Shortcut.CtrlF9;
                case "CtrlG":
                    return System.Windows.Forms.Shortcut.CtrlG;
                case "CtrlH":
                    return System.Windows.Forms.Shortcut.CtrlH;
                case "CtrlI":
                    return System.Windows.Forms.Shortcut.CtrlI;
                case "CtrlIns":
                    return System.Windows.Forms.Shortcut.CtrlIns;
                case "CtrlJ":
                    return System.Windows.Forms.Shortcut.CtrlJ;
                case "CtrlK":
                    return System.Windows.Forms.Shortcut.CtrlK;
                case "CtrlL":
                    return System.Windows.Forms.Shortcut.CtrlL;
                case "CtrlM":
                    return System.Windows.Forms.Shortcut.CtrlM;
                case "CtrlN":
                    return System.Windows.Forms.Shortcut.CtrlN;
                case "CtrlO":
                    return System.Windows.Forms.Shortcut.CtrlO;
                case "CtrlP":
                    return System.Windows.Forms.Shortcut.CtrlP;
                case "CtrlQ":
                    return System.Windows.Forms.Shortcut.CtrlQ;
                case "CtrlR":
                    return System.Windows.Forms.Shortcut.CtrlR;
                case "CtrlS":
                    return System.Windows.Forms.Shortcut.CtrlS;
                case "CtrlShift0":
                    return System.Windows.Forms.Shortcut.CtrlShift0;
                case "CtrlShift1":
                    return System.Windows.Forms.Shortcut.CtrlShift1;
                case "CtrlShift2":
                    return System.Windows.Forms.Shortcut.CtrlShift2;
                case "CtrlShift3":
                    return System.Windows.Forms.Shortcut.CtrlShift3;
                case "CtrlShift4":
                    return System.Windows.Forms.Shortcut.CtrlShift4;
                case "CtrlShift5":
                    return System.Windows.Forms.Shortcut.CtrlShift5;
                case "CtrlShift6":
                    return System.Windows.Forms.Shortcut.CtrlShift6;
                case "CtrlShift7":
                    return System.Windows.Forms.Shortcut.CtrlShift7;
                case "CtrlShift8":
                    return System.Windows.Forms.Shortcut.CtrlShift8;
                case "CtrlShift9":
                    return System.Windows.Forms.Shortcut.CtrlShift9;
                case "CtrlShiftA":
                    return System.Windows.Forms.Shortcut.CtrlShiftA;
                case "CtrlShiftB":
                    return System.Windows.Forms.Shortcut.CtrlShiftB;
                case "CtrlShiftC":
                    return System.Windows.Forms.Shortcut.CtrlShiftC;
                case "CtrlShiftD":
                    return System.Windows.Forms.Shortcut.CtrlShiftD;
                case "CtrlShiftE":
                    return System.Windows.Forms.Shortcut.CtrlShiftE;
                case "CtrlShiftF":
                    return System.Windows.Forms.Shortcut.CtrlShiftF;
                case "CtrlShiftF1":
                    return System.Windows.Forms.Shortcut.CtrlShiftF1;
                case "CtrlShiftF10":
                    return System.Windows.Forms.Shortcut.CtrlShiftF10;
                case "CtrlShiftF11":
                    return System.Windows.Forms.Shortcut.CtrlShiftF11;
                case "CtrlShiftF12":
                    return System.Windows.Forms.Shortcut.CtrlShiftF12;
                case "CtrlShiftF2":
                    return System.Windows.Forms.Shortcut.CtrlShiftF2;
                case "CtrlShiftF3":
                    return System.Windows.Forms.Shortcut.CtrlShiftF3;
                case "CtrlShiftF4":
                    return System.Windows.Forms.Shortcut.CtrlShiftF4;
                case "CtrlShiftF5":
                    return System.Windows.Forms.Shortcut.CtrlShiftF5;
                case "CtrlShiftF6":
                    return System.Windows.Forms.Shortcut.CtrlShiftF6;
                case "CtrlShiftF7":
                    return System.Windows.Forms.Shortcut.CtrlShiftF7;
                case "CtrlShiftF8":
                    return System.Windows.Forms.Shortcut.CtrlShiftF8;
                case "CtrlShiftF9":
                    return System.Windows.Forms.Shortcut.CtrlShiftF9;
                case "CtrlShiftG":
                    return System.Windows.Forms.Shortcut.CtrlShiftG;
                case "CtrlShiftH":
                    return System.Windows.Forms.Shortcut.CtrlShiftH;
                case "CtrlShiftI":
                    return System.Windows.Forms.Shortcut.CtrlShiftI;
                case "CtrlShiftJ":
                    return System.Windows.Forms.Shortcut.CtrlShiftJ;
                case "CtrlShiftK":
                    return System.Windows.Forms.Shortcut.CtrlShiftK;
                case "CtrlShiftL":
                    return System.Windows.Forms.Shortcut.CtrlShiftL;
                case "CtrlShiftM":
                    return System.Windows.Forms.Shortcut.CtrlShiftM;
                case "CtrlShiftN":
                    return System.Windows.Forms.Shortcut.CtrlShiftN;
                case "CtrlShiftO":
                    return System.Windows.Forms.Shortcut.CtrlShiftO;
                case "CtrlShiftP":
                    return System.Windows.Forms.Shortcut.CtrlShiftP;
                case "CtrlShiftQ":
                    return System.Windows.Forms.Shortcut.CtrlShiftQ;
                case "CtrlShiftR":
                    return System.Windows.Forms.Shortcut.CtrlShiftR;
                case "CtrlShiftS":
                    return System.Windows.Forms.Shortcut.CtrlShiftS;
                case "CtrlShiftT":
                    return System.Windows.Forms.Shortcut.CtrlShiftT;
                case "CtrlShiftU":
                    return System.Windows.Forms.Shortcut.CtrlShiftU;
                case "CtrlShiftV":
                    return System.Windows.Forms.Shortcut.CtrlShiftV;
                case "CtrlShiftW":
                    return System.Windows.Forms.Shortcut.CtrlShiftW;
                case "CtrlShiftX":
                    return System.Windows.Forms.Shortcut.CtrlShiftX;
                case "CtrlShiftY":
                    return System.Windows.Forms.Shortcut.CtrlShiftY;
                case "CtrlShiftZ":
                    return System.Windows.Forms.Shortcut.CtrlShiftZ;
                case "CtrlT":
                    return System.Windows.Forms.Shortcut.CtrlT;
                case "CtrlU":
                    return System.Windows.Forms.Shortcut.CtrlU;
                case "CtrlV":
                    return System.Windows.Forms.Shortcut.CtrlV;
                case "CtrlW":
                    return System.Windows.Forms.Shortcut.CtrlW;
                case "CtrlX":
                    return System.Windows.Forms.Shortcut.CtrlX;
                case "CtrlY":
                    return System.Windows.Forms.Shortcut.CtrlY;
                case "CtrlZ":
                    return System.Windows.Forms.Shortcut.CtrlZ;
                case "Del":
                    return System.Windows.Forms.Shortcut.Del;
                case "F1":
                    return System.Windows.Forms.Shortcut.F1;
                case "F10":
                    return System.Windows.Forms.Shortcut.F10;
                case "F11":
                    return System.Windows.Forms.Shortcut.F11;
                case "F12":
                    return System.Windows.Forms.Shortcut.F12;
                case "F2":
                    return System.Windows.Forms.Shortcut.F2;
                case "F3":
                    return System.Windows.Forms.Shortcut.F3;
                case "F4":
                    return System.Windows.Forms.Shortcut.F4;
                case "F5":
                    return System.Windows.Forms.Shortcut.F5;
                case "F6":
                    return System.Windows.Forms.Shortcut.F6;
                case "F7":
                    return System.Windows.Forms.Shortcut.F7;
                case "F8":
                    return System.Windows.Forms.Shortcut.F8;
                case "F9":
                    return System.Windows.Forms.Shortcut.F9;
                case "Ins":
                    return System.Windows.Forms.Shortcut.Ins;
                case "ShiftDel":
                    return System.Windows.Forms.Shortcut.ShiftDel;
                case "ShiftF1":
                    return System.Windows.Forms.Shortcut.ShiftF1;
                case "ShiftF10":
                    return System.Windows.Forms.Shortcut.ShiftF10;
                case "ShiftF11":
                    return System.Windows.Forms.Shortcut.ShiftF11;
                case "ShiftF12":
                    return System.Windows.Forms.Shortcut.ShiftF12;
                case "ShiftF2":
                    return System.Windows.Forms.Shortcut.ShiftF2;          
                case "ShiftF3":
                    return System.Windows.Forms.Shortcut.ShiftF3;
                case "ShiftF4":
                    return System.Windows.Forms.Shortcut.ShiftF4;
                case "ShiftF5":
                    return System.Windows.Forms.Shortcut.ShiftF5;
                case "ShiftF6":
                    return System.Windows.Forms.Shortcut.ShiftF6;
                case "ShiftF7":
                    return System.Windows.Forms.Shortcut.ShiftF7;
                case "ShiftF8":
                    return System.Windows.Forms.Shortcut.ShiftF8;
                case "ShiftF9":
                    return System.Windows.Forms.Shortcut.ShiftF9;
                case "ShiftIns":
                    return System.Windows.Forms.Shortcut.ShiftIns;
                default:
                    return System.Windows.Forms.Shortcut.None;
            }                                    
        }
        /// <summary>
        /// InitializeMenuEditor
        /// </summary>
        public void InitializeMenuEditor()
        {
            this.Items.Clear();
            SqlInfo sqlMenu = new SqlInfo(Information.ConnectionString);
            _TbMenu.Load(sqlMenu.ExecuteReader("SELECT [ID],[NAME],[TEXT],[SHCUT],[INDEX],[LINE],[ICON],[DLL],[PROJECT],[CLASS],[FUNCTION],[NOTE],PID FROM TsMN"));
            DataColumn[] Mnkey = new DataColumn[1];
            Mnkey[0] = _TbMenu.Columns["ID"];
            _TbMenu.PrimaryKey = Mnkey;
            DataTable TbMenuParent = new DataView(_TbMenu, "PID IS NULL", "INDEX", DataViewRowState.CurrentRows).ToTable();
            CheckRemoveLine(TbMenuParent);
            foreach (DataRow rMenu in TbMenuParent.Rows)
            {
                if (!rMenu.IsNull("LINE") && rMenu["LINE"].Equals(true))
                {
                    ToolStripMenuItem stMenuSeprator = new ToolStripMenuItem();
                    stMenuSeprator.Name = rMenu["NAME"].ToString().Trim();
                    stMenuSeprator.Text = "|";
                    this.Items.Add(stMenuSeprator);
                }
                else
                {
                    ToolStripMenuItem stMenuItem = new ToolStripMenuItem();
                    stMenuItem.Name = rMenu["NAME"].ToString().Trim();
                    stMenuItem.Tag = rMenu["ID"].ToString().Trim();
                    if (rMenu.IsNull("TEXT") || rMenu["TEXT"].ToString().Trim().Trim().Equals(String.Empty))
                    {
                        stMenuItem.Text = rMenu["NAME"].ToString().Trim();
                    }
                    else
                    {
                        stMenuItem.Text = rMenu["TEXT"].ToString().Trim();
                    }
                    if (!rMenu.IsNull("SHCUT") && !rMenu["SHCUT"].ToString().Trim().Equals(String.Empty))
                    {
                        stMenuItem.ShortcutKeys = (Keys)ShortCutKey(rMenu["SHCUT"].ToString());
                    }
                    if (!rMenu.IsNull("ICON"))
                    {
                        ImageConverter ImageConver = new ImageConverter();
                        stMenuItem.Image = (Image)ImageConver.ConvertFrom(rMenu["ICON"]);                         
                    }
                    this.Items.Add(stMenuItem);
                    if (!rMenu.IsNull("PROJECT") && !rMenu.IsNull("CLASS") && !rMenu.IsNull("FUNCTION"))
                    {
                        stMenuItem.Click += new System.EventHandler(Menu_Click);
                    }
                    AddMenuItem(stMenuItem);
                }
            }
            this.ItemAdded += new ToolStripItemEventHandler(MenuInfo_ItemAdded);
        }
        /// <summary>
        /// AddMenuItem
        /// </summary>
        private void AddMenuItem(ToolStripMenuItem stmnItem)
        {
            DataTable TbMenuItem = new DataView(_TbMenu, "PID = '" + stmnItem.Tag.ToString().Trim() + "'", "INDEX", DataViewRowState.CurrentRows).ToTable();
            CheckRemoveLine(TbMenuItem);
            foreach (DataRow rMenu in TbMenuItem.Rows)
            {
                if (!rMenu.IsNull("LINE") && rMenu["LINE"].Equals(true))
                {
                    ToolStripSeparator stMenuSepator = new ToolStripSeparator();
                    stMenuSepator.Name = rMenu["NAME"].ToString().Trim();
                    stmnItem.DropDownItems.Add(stMenuSepator);
                }
                else
                {
                    ToolStripMenuItem stMenuItem = new ToolStripMenuItem();
                    stMenuItem.Name = rMenu["NAME"].ToString().Trim();
                    stMenuItem.Tag = rMenu["ID"].ToString().Trim();
                    if (rMenu.IsNull("TEXT") || rMenu["TEXT"].ToString().Trim().Equals(String.Empty))
                    {
                        stMenuItem.Text = rMenu["NAME"].ToString().Trim();
                    }
                    else
                    {
                        stMenuItem.Text = rMenu["TEXT"].ToString().Trim();
                    }

                    if (!rMenu.IsNull("SHCUT") && !rMenu["SHCUT"].ToString().Trim().Equals(String.Empty))
                    {
                        stMenuItem.ShortcutKeys = (Keys)ShortCutKey(rMenu["SHCUT"].ToString());
                    }
                    if (!rMenu.IsNull("ICON"))
                    {
                        ImageConverter ImageConver = new ImageConverter();
                        stMenuItem.Image = (Image)ImageConver.ConvertFrom(rMenu["ICON"]);
                    }
                    stmnItem.DropDownItems.Add(stMenuItem);
                    if (!rMenu.IsNull("PROJECT") && !rMenu.IsNull("CLASS") && !rMenu.IsNull("FUNCTION"))
                    {
                        stMenuItem.Click += new System.EventHandler(Menu_Click);
                    }
                    AddMenuItem(stMenuItem);
                }
            }
        }
        /// <summary>
        /// MenuInfo_ItemAdded
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
                DataRow rMenu = _TbMenu.Rows.Find(((ToolStripMenuItem)sender).Tag.ToString().Trim());
                if (!rMenu.IsNull("FUNCTION") && !rMenu["FUNCTION"].ToString().Trim().Equals(String.Empty))
                {
                    Assembly vAssembly;
                    if (!rMenu.IsNull("DLL") && !rMenu["DLL"].ToString().Trim().Equals(String.Empty))
                    {
                        vAssembly = Assembly.LoadFrom(Application.StartupPath + @"\DLL\" + rMenu["DLL"].ToString().Trim());
                        Type vType = vAssembly.GetType(rMenu["PROJECT"].ToString().Trim() + "." + rMenu["CLASS"].ToString().Trim());
                        object vInstance = Activator.CreateInstance(vType, null);
                        MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["FUNCTION"].ToString().Trim());
                        vMethod.Invoke(rMenu["FUNCTION"].ToString().Trim(), null);
                    }
                    else
                    {
                        vAssembly = Assembly.GetExecutingAssembly();
                        try
                        {
                            Type vType = vAssembly.GetType(rMenu["PROJECT"].ToString().Trim() + "." + rMenu["CLASS"].ToString().Trim());
                            object vInstance = Activator.CreateInstance(vType, null);
                            MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["FUNCTION"].ToString().Trim());
                            vMethod.Invoke(rMenu["FUNCTION"].ToString().Trim(), null);
                        }
                        catch
                        {
                            vAssembly = Assembly.GetEntryAssembly();
                            Type vType = vAssembly.GetType(rMenu["PROJECT"].ToString().Trim() + "." + rMenu["CLASS"].ToString().Trim());
                            object vInstance = Activator.CreateInstance(vType, null);
                            MethodInfo vMethod = vInstance.GetType().GetMethod(rMenu["FUNCTION"].ToString().Trim());
                            vMethod.Invoke(rMenu["FUNCTION"].ToString().Trim(), null);
                        }
                    }
                }
            }
            catch
            {
                //Information.MsgBox("MsgRunError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
