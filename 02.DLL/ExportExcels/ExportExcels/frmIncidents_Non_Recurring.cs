using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Microsoft.ApplicationBlocks.Data;

namespace ExportExcels
{
    public partial class frmIncidents_Non_Recurring : DevExpress.XtraEditors.XtraForm
    {
        GridControl grid = new GridControl();
        DataTable _table = new DataTable();
        DataTable _table1 = new DataTable();
        public DateTime _tu_ngay, _den_ngay;
        public string _cat,_group;
        public string _date;
        public string tinh, quan, nha_xuong, loai_may, nhom_may;


        public string MsTinh, MsQuan, MsNX;

        DataTable _tableTemp = new DataTable();
        public frmIncidents_Non_Recurring()
        {
            InitializeComponent();
        }
        public DataTable _TableSource
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }
     
        private void LoadData()
        {
          
            //DataTable _table = new DataTable();
            DataTable _table_amount = new DataTable();
            grid.Dock = DockStyle.Fill;
            grid.Visible = true;
            tableLayoutPanel1.Controls.Add(grid, 1, 0);
            tableLayoutPanel1.SetColumnSpan(grid, 4);
            //this.Controls.Add(grid);
            grid.Visible = true;  
           
            DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
             gridView.BeginInit();
             grid.MainView = gridView;
         
             gridView.OptionsBehavior.Editable = false;
            grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            
            gridView.Columns.Clear();
           
            DataTable _tableNM = new DataTable();
            DataTable _tableNN = new DataTable();
            DataTable _tableSL = new DataTable();
            
            _tableTemp = _tableTemp.DefaultView.ToTable();
            _tableTemp.Columns.Add("NO",typeof(int));
            //_tableTemp.Columns["NO"].AutoIncrement = true;
            //_tableTemp.Columns["NO"].AutoIncrementSeed  = 1;
            //_tableTemp.Columns["NO"].AutoIncrementStep  = 1;
            _tableTemp.Columns.Add("TenLoaiMay");            
            _tableTemp.Columns.Add("TenNhomMay");
            _tableTemp.Columns.Add("NguyenNhan");

            for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
            {
                //_tableTemp.Columns.Add("SL_May" + t.Month + "" + t.Year, System.Type.GetType("System.Int32"));
                //_tableTemp.Columns.Add("SL_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Int32")); 
                //_tableTemp.Columns.Add("TI_LE_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Double"));


                
                _tableTemp.Columns.Add("TI_LE_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Double")); 
                _tableTemp.Columns.Add("SL_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Int32"));
                _tableTemp.Columns.Add("SL_May" + t.Month + "" + t.Year, System.Type.GetType("System.Int32"));

                
                t = t.AddMonths(1);
            }
            _tableTemp.Columns.Add("TI_LE_SU_CO_CA_NAM", System.Type.GetType("System.Double"));
            _tableTemp.Columns.Add("SL_SU_CO_CA_NAM", System.Type.GetType("System.Int32"));
            _tableTemp.Columns.Add("SL_May_CA_NAM", System.Type.GetType("System.Int32"));

            DataTable tblLoaiMay = new DataTable();
            tblLoaiMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LOAI_MAY",_cat));
            foreach (DataRow _rowLM in tblLoaiMay.Rows)
            {
                DataRow row = _tableTemp.NewRow();
                row["TenLoaiMay"] = _rowLM["Ten_Loai_May"];
                _tableTemp.Rows.Add(row);
                _tableNM = new DataTable();
                _tableNM.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_GROUP_MACHINE_REPORT", _rowLM["MS_LOAI_MAY"],_group));
              
               int i = 1;
               //int J = 1;
               int slcn = 0;
               int slsccn = 0;
               foreach (DataRow _rowNM in _tableNM.Rows)
               {
                   if (i == 1)
                   {
                       int J = 1;
                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TenNhomMay"] = _rowNM["TEN_NHOM_MAY"];
                       row["TenLoaiMay"] = _rowLM["Ten_Loai_May"];
                       //_tableTemp.Rows[_tableTemp.Rows.Count - 1]["Ten_Loai_May"] = _rowNM["Ten_Loai_May"];
                       _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND  MS_NHOM_MAY='" + _rowNM["MS_NHOM_MAY"] + "' ";
                       _tableNN = _table.DefaultView.ToTable(true, "TEN_NGUYEN_NHAN");
                       foreach (DataRow _rowNN in _tableNN.Rows)
                       {
                           if (J == 1)
                           {   
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["NguyenNhan"] = _rowNN["TEN_NGUYEN_NHAN"];
                               slcn = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                   "SP_NHU_Y_GET_AMOUNT_INCIDENT", _den_ngay.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                   MsTinh,MsQuan,MsNX));

                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_May_CA_NAM"] = slcn;
                               _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND  MS_NHOM_MAY='" + _rowNM["MS_NHOM_MAY"] +
                                   "' AND TEN_NGUYEN_NHAN = '" + _rowNN["TEN_NGUYEN_NHAN"] + "' ";
                               _tableSL = _table.DefaultView.ToTable();
                               int sl = 0;
                               for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
                               {
                                   sl = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                       "SP_NHU_Y_GET_AMOUNT_INCIDENT", t.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                        MsTinh,MsQuan,MsNX));

                                   _tableSL.DefaultView.RowFilter =  " M=" + t.Month + " and Y=" + t.Year;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_MAY" + t.Month + "" + t.Year] = sl;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = 0;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = 0;
                                   foreach (DataRow row2 in _tableSL.DefaultView.ToTable().Rows)
                                   {
                                       
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = Convert.ToInt16(row2["SL_SU_CO"]);
                                       slsccn += Convert.ToInt16(row2["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = Math.Round(Convert.ToDouble(row2["SL_SU_CO"]) / sl * 100, 2);
                                   }
                                   
                                   t = t.AddMonths(1);
                               }
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO_CA_NAM"] = slsccn;
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO_CA_NAM"] = Math.Round((double)slsccn / sl * 100, 2);
                           }
                           else
                           {
                               DataRow row2 = _tableTemp.NewRow();
                               row2["TenNhomMay"] = _rowNM["TEN_NHOM_MAY"];
                               row2["NguyenNhan"] = _rowNN["TEN_NGUYEN_NHAN"];
                               row2["TenLoaiMay"] = _rowLM["Ten_Loai_May"];
                               _tableTemp.Rows.Add(row2);

                               _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND  MS_NHOM_MAY='" + _rowNM["MS_NHOM_MAY"] +
                                   "' AND TEN_NGUYEN_NHAN = '" + _rowNN["TEN_NGUYEN_NHAN"] + "' ";
                               _tableSL = _table.DefaultView.ToTable();
                               int sl = 0;
                               slcn = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                   "SP_NHU_Y_GET_AMOUNT_INCIDENT", _den_ngay.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                   MsTinh,MsQuan,MsNX));
                               for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
                               {
                                   sl = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                       "SP_NHU_Y_GET_AMOUNT_INCIDENT", t.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                        MsTinh,MsQuan,MsNX));
                                  
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_May_CA_NAM"] = slcn;
                                   _tableSL.DefaultView.RowFilter = " M=" + t.Month + " and Y=" + t.Year;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_MAY" + t.Month + "" + t.Year] = sl;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = 0;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = 0;
                                   foreach (DataRow rowSL in _tableSL.DefaultView.ToTable().Rows)
                                   {
                                       slsccn += Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = Math.Round(Convert.ToDouble(rowSL["SL_SU_CO"]) / sl * 100, 2);
                                   }
                                  
                                   t = t.AddMonths(1);
                               } 
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO_CA_NAM"] = slsccn;
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO_CA_NAM"] = Math.Round((double)slsccn / sl * 100, 2);
                           }
                           J++;
                           slsccn = 0;
                       }
                   }
                   else {
                       DataRow row1 = _tableTemp.NewRow();
                  
                       row1["TenNhomMay"] = _rowNM["TEN_NHOM_MAY"];
                       row1["TenLoaiMay"] = _rowLM["Ten_Loai_May"];
                       _tableTemp.Rows.Add(row1);

                       int J = 1;
                       _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND MS_NHOM_MAY= '" + _rowNM["MS_NHOM_MAY"] + "' ";
                       _tableNN = _table.DefaultView.ToTable(true, "TEN_NGUYEN_NHAN");
                       foreach (DataRow _rowNN in _tableNN.Rows)
                       {
                           if (J == 1)
                           {
                               _tableTemp.Rows[_tableTemp.Rows.Count-1]["NguyenNhan"] = _rowNN["TEN_NGUYEN_NHAN"];
                               slcn = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                   "SP_NHU_Y_GET_AMOUNT_INCIDENT", _den_ngay.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                   MsTinh,MsQuan,MsNX));

                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_May_CA_NAM"] = slcn;

                               _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND  MS_NHOM_MAY='" + _rowNM["MS_NHOM_MAY"] +
                                   "' AND TEN_NGUYEN_NHAN = '" + _rowNN["TEN_NGUYEN_NHAN"] + "' ";
                               _tableSL = _table.DefaultView.ToTable();
                               int sl = 0; 
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_May_CA_NAM"] = slcn;
                               for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
                               {
                                   sl = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                       "SP_NHU_Y_GET_AMOUNT_INCIDENT", t.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                        MsTinh,MsQuan,MsNX));
                                  
                                   _tableSL.DefaultView.RowFilter = " M=" + t.Month + " and Y=" + t.Year;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_MAY" + t.Month + "" + t.Year] = sl;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = 0;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = 0;
                                   foreach (DataRow rowSL in _tableSL.DefaultView.ToTable().Rows)
                                   {
                                       slsccn += Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = Math.Round(Convert.ToDouble(rowSL["SL_SU_CO"]) / sl * 100, 2);
                                   }
                                 
                                   t = t.AddMonths(1);
                               }
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO_CA_NAM"] = slsccn;
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO_CA_NAM"] = Math.Round((double)slsccn / sl * 100, 2);
                           }
                           else
                           {
                               DataRow row2 = _tableTemp.NewRow();
                               row2["NguyenNhan"] = _rowNN["TEN_NGUYEN_NHAN"];
                               row2["TenNhomMay"] = _rowNM["TEN_NHOM_MAY"];
                               row2["TenLoaiMay"] = _rowLM["Ten_Loai_May"];
                               _tableTemp.Rows.Add(row2);

                               _table.DefaultView.RowFilter = "MS_LOAI_MAY = '" + _rowLM["MS_LOAI_MAY"] + "'  AND  MS_NHOM_MAY='" + _rowNM["MS_NHOM_MAY"] +
                                                                  "' AND TEN_NGUYEN_NHAN = '" + _rowNN["TEN_NGUYEN_NHAN"] + "' ";
                               _tableSL = _table.DefaultView.ToTable();
                               int sl = 0;
                               slcn = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                   "SP_NHU_Y_GET_AMOUNT_INCIDENT", _den_ngay.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                   MsTinh,MsQuan,MsNX));

                               for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
                               {
                                   _tableSL.DefaultView.RowFilter = " M=" + t.Month + " and Y=" + t.Year;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = 0;
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = 0;
                                   sl = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                       "SP_NHU_Y_GET_AMOUNT_INCIDENT", t.AddMonths(1).AddDays(-1), _rowNM["MS_NHOM_MAY"],
                                        MsTinh,MsQuan,MsNX));

                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_MAY" + t.Month + "" + t.Year] = sl;
                                   
                                   _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_May_CA_NAM"] = slcn;
                                   foreach (DataRow rowSL in _tableSL.DefaultView.ToTable().Rows)
                                   {
                                       slsccn += Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO" + t.Month + "" + t.Year] = Convert.ToInt16(rowSL["SL_SU_CO"]);
                                       _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO" + t.Month + "" + t.Year] = Math.Round(Convert.ToDouble(rowSL["SL_SU_CO"]) / sl * 100, 2);
                                   }
                                  
                                   t = t.AddMonths(1);
                               } 
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["SL_SU_CO_CA_NAM"] = slsccn;
                               _tableTemp.Rows[_tableTemp.Rows.Count - 1]["TI_LE_SU_CO_CA_NAM"] = Math.Round((double)slsccn/ sl * 100, 2);
                           }
                           J++;
                           slsccn = 0;
                       }
                   }
                   i += 1;
               }
            }
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });
            
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand2 });

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand3 });

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand4 });

            for (int i = 3; i >= 0; i--)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                bandedGridColumn.Name = "band" + i;
                bandedGridColumn.OptionsColumn.AllowMove = false;
                bandedGridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bandedGridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                bandedGridColumn.AppearanceHeader.Options.UseTextOptions = true;

                bandedGridColumn.FieldName = _tableTemp.Columns[i].Caption;
                bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", bandedGridColumn.FieldName, Commons.Modules.TypeLanguage);
                bandedGridColumn.Visible = true;
                if (i == 3)
                    gridBand4.Columns.Add(bandedGridColumn);
                else if (i==2)
                    gridBand3.Columns.Add(bandedGridColumn);
                else if (i ==1)
                    gridBand2.Columns.Add(bandedGridColumn);
                else
                    gridBand1.Columns.Add(bandedGridColumn);


            }
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.Caption = _tu_ngay.Month + "/" + _tu_ngay.Year;
            _tu_ngay = _tu_ngay.AddMonths(1);
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand }); 

            for (int i = 4; i < _tableTemp.Columns.Count; i++)
            {
                if (i % 3 == 1)
                {
                    if (i > 4)
                    {
                        gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gridBand.AppearanceHeader.Options.UseTextOptions = true;
                        gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand });
                        if (_tu_ngay > _den_ngay)
                            gridBand.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "Canam", Commons.Modules.TypeLanguage);
                        else
                        {
                            gridBand.Caption = _tu_ngay.Month + "/" + _tu_ngay.Year;
                            _tu_ngay = _tu_ngay.AddMonths(1);
                        }
                        
                      
                    }
                }
                gridBand.Name = "gridBand" + i;
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                bandedGridColumn.Name = "band" + i;
                bandedGridColumn.OptionsColumn.AllowMove = false;
                bandedGridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bandedGridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                bandedGridColumn.AppearanceHeader.Options.UseTextOptions = true;


                if (i % 3 == 0)
                    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "SLTu", Commons.Modules.TypeLanguage);
                else if (i % 3 == 1)
                    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "TI_LE_SU_CO", Commons.Modules.TypeLanguage);
                else
                    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "SL_SU_CO", Commons.Modules.TypeLanguage);

                //if (i % 3 == 0)
                //    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "TI_LE_SU_CO", Commons.Modules.TypeLanguage);
                //else if (i % 3 == 1)
                //    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "SL_SU_CO", Commons.Modules.TypeLanguage);
                //else
                //    bandedGridColumn.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "SLTu", Commons.Modules.TypeLanguage);




                bandedGridColumn.FieldName = _tableTemp.Columns[i].Caption;

                bandedGridColumn.Visible = true;
             
                gridBand.Columns.Add(bandedGridColumn);
                
             
            }
            _tableTemp.DefaultView.RowFilter = "NguyenNhan <> ''";
            _tableTemp = _tableTemp.DefaultView.ToTable();
            for (int i = 0; i < _tableTemp.Rows.Count; i++)
                _tableTemp.Rows[i]["NO"] = i + 1;
            grid.DataSource = _tableTemp;
           
             

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            string path = "";
            f.Filter = "Excel file (*.xls)|*.xls";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.OK))
                {
                    path = f.FileName;

                }
                else
                    return;
            }
            catch
            {

            }
            this.Cursor = Cursors.WaitCursor;
            grid.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count_column = _tableTemp.Columns.Count;
            int count_row = _tableTemp.Rows.Count;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);

            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xl;
            excelWorkSheet.Cells[1, 1] = lblTitle.Text;


            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range _dateFrom = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            _dateFrom.Merge(true);
            _dateFrom.Font.Bold = true;
          
            excelWorkSheet.Cells[2, 1] = _date;
            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range factory = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            factory.Merge(true);
            factory.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = nha_xuong;
            factory.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] = loai_may ;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = nhom_may ;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] = tinh ;
            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[7, 1] = quan;


            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[9, 1]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 2], excelWorkSheet.Cells[9, 2]);
            a1.MergeCells = true;
           
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 3], excelWorkSheet.Cells[9, 3]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 4], excelWorkSheet.Cells[9, 4]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIncidents_Non_Recurring_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            LoadData();
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "btnExit", Commons.Modules.TypeLanguage);
        }

      
    }
}
