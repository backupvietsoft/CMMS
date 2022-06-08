using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace ExportExcels
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        private DataSet dsReportsource = new DataSet ();
        public string rptName = String.Empty ;
        private static DataTable tbrptHeader = new DataTable ();

        public frmReport()
        {
            InitializeComponent();
        }
        
        //Add Datatable vào dataset
        public void AddDataTableSource(DataTable tbSource)
        {
            try 
            {
               try 
               {
                    dsReportsource.Tables.Remove(tbSource.TableName);
               }
               catch  {}
                dsReportsource.Tables.Add(tbSource.Copy());
            }
            catch {}
        }

        public void RemoveDataTableSource()
        {
            dsReportsource.Tables.Clear();
        }

        //Lấy thông tin chung cho report 
        private void AddInformaitionCompany()
        {
            tbrptHeader = new DataTable();
            string vSelect = string.Empty;
            if (Vietsoft.Information.Language == 0 )
            {
                vSelect = "SELECT TEN_CTY_TIENG_VIET AS THONG_TIN_CTY ,DIA_CHI_VIET AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," + 
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , '" +  Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "PRINT_DATE", Vietsoft.Information.Language) + "' as NGAY_IN , '" + Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "PAGE", Vietsoft.Information.Language) + "' AS PAGE , '" + Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "OF", Vietsoft.Information.Language) + "' AS OFPAGE FROM THONG_TIN_CHUNG ";
                
            }
            else 
            {
                vSelect = "SELECT TEN_CTY_TIENG_ANH AS THONG_TIN_CTY , DIA_CHI_ANH AS DIA_CHI_CTY , Phone AS DIEN_THOAI ," +
                "Fax , LOGO ,LE_PHAI_LOGO AS LE_TRAI_LOGO , LE_TREN_LOGO , WIDTH , HEIGHT , '" + Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "PRINT_DATE", Vietsoft.Information.Language) + "' as NGAY_IN , '" + Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "PAGE", Vietsoft.Information.Language) + "' AS PAGE , '" + Commons.Modules.ObjLanguages.GetLanguage(Vietsoft.Information.ModuleName, rptName, "OF", Vietsoft.Information.Language) + "' AS OFPAGE FROM THONG_TIN_CHUNG ";
            }
            //tbrptHeader.Load(SqlReport.ExecuteReader(CommandType.Text, vSelect));
            tbrptHeader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vSelect));
            tbrptHeader.TableName = "rptTitlereport";
            if( tbrptHeader.Rows.Count > 0 )
            {
                tbrptHeader.Columns["THONG_TIN_CTY"].MaxLength = 1000;
                tbrptHeader.Rows[0]["THONG_TIN_CTY"] = tbrptHeader.Rows[0]["THONG_TIN_CTY"].ToString().Trim() + "\n" + tbrptHeader.Rows[0]["DIA_CHI_CTY"].ToString().Trim() + "\n" + "Telephone: " + tbrptHeader.Rows[0]["DIEN_THOAI"].ToString().Trim() + "  Fax: " + tbrptHeader.Rows[0]["Fax"].ToString().Trim();
                tbrptHeader.Columns["NGAY_IN"].ReadOnly = false;
                tbrptHeader.Columns["NGAY_IN"].MaxLength = 128;
                tbrptHeader.Rows[0]["NGAY_IN"] = tbrptHeader.Rows[0]["NGAY_IN"].ToString().Trim() + System.DateTime.Now.ToString("dd/MM/yyyy");
            }
            tbrptHeader.Columns.Remove(tbrptHeader.Columns["DIA_CHI_CTY"]);
            tbrptHeader.Columns.Remove(tbrptHeader.Columns["DIEN_THOAI"]);
            tbrptHeader.Columns.Remove(tbrptHeader.Columns["Fax"]);
            try 
            {
                dsReportsource.Tables.Remove(tbrptHeader);
            }
            catch {}        
            dsReportsource.Tables.Add(tbrptHeader.Copy());
        }    

        //Set ngôn ngữ cho report 
        private void SetLanguageReport(CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument)
        {
            DataTable tbrptLanguage = new DataTable();
            string vSelect = String.Empty ;
            if (Vietsoft.Information.Language == 0) 
            {
                vSelect = "SELECT KEYWORD, VIETNAM AS CAPTION FROM LANGUAGES WHERE FORM = '" + rptName + "' AND FORM_HAY_REPORT = 1";
            }
            else 
            {
                vSelect = "SELECT KEYWORD, ENGLISH AS CAPTION FROM LANGUAGES WHERE FORM = '" + rptName + "' AND FORM_HAY_REPORT = 1";
            }
            //tbrptLanguage.Load(SqlReport.ExecuteReader(CommandType.Text, vSelect));
            tbrptLanguage.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vSelect));
            if (tbrptLanguage.Rows.Count > 0) 
            {
                foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptObject in rptDocument.ReportDefinition.ReportObjects )
                {
                    if (rptObject.Kind == CrystalDecisions.Shared.ReportObjectKind.TextObject)
                    {
                        int flag = 0;
                        foreach (DataRow rLanguage in tbrptLanguage.Rows)
                        {
                            if (rptObject.Name.ToUpper().Trim().Equals(rLanguage["KEYWORD"].ToString().ToUpper().Trim()))
                            {
                                ((CrystalDecisions.CrystalReports.Engine.TextObject)rptObject).Text = rLanguage["CAPTION"].ToString().Trim();
                                flag = 1;
                            }
                        }
                        if (flag == 0 && ((CrystalDecisions.CrystalReports.Engine.TextObject)rptObject).Text.Length > 1)
                        {
                            //SqlReport.ExecuteNonQuery("INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[FORM_HAY_REPORT]) VALUES('" + Vietsoft.Information.ModuleName + "','" + rptName + "','" + rptObject.Name + "',N'" + ((CrystalDecisions.CrystalReports.Engine.TextObject)rptObject).Text + "',N'@" + rptObject.Name + "@',1)");
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, 
                                "INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[FORM_HAY_REPORT]) VALUES('" + Vietsoft.Information.ModuleName + "','" + rptName + "','" + rptObject.Name + "',N'" + ((CrystalDecisions.CrystalReports.Engine.TextObject)rptObject).Text + "',N'@" + rptObject.Name + "@',1)");
                        }                    
                    }
                }
            }
        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }       

        private void CrystalReportViewer_maint_Load(object sender, EventArgs e)
        {
            try 
            {
            CrystalReportViewer_maint.DisplayGroupTree = false;
            AddInformaitionCompany();
            //dsReportsource.WriteXml(System.Windows.Forms.Application.StartupPath + "\\XML\\" + rptName.Trim() + ".xml", XmlWriteMode.WriteSchema);
            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rptDocument.Load(System.Windows.Forms.Application.StartupPath + "\\reports\\" + rptName.Trim() + ".rpt");
            rptDocument.SetDataSource(dsReportsource);
            //DesignerReport(rptDocument);
            if (Commons.Modules.bDoiFontReport)
                Commons.Modules.ObjSystems.MDoiFontCrystalReports(rptDocument);
            SetLanguageReport(rptDocument);

            CrystalReportViewer_maint.ReportSource = rptDocument;
            if (rptName.Equals("rptDeXuatMuaHangNew_KKTL"))
                CrystalReportViewer_maint.ShowExportButton = false;
       
            }
            catch {}        
        }     
        //Định dạng report 
        public static void DesignerReport(CrystalDecisions.CrystalReports.Engine.ReportDocument rptMain)
        {
            foreach(CrystalDecisions.CrystalReports.Engine.ReportObject rptObjectMain in rptMain.ReportDefinition.ReportObjects)
            {
                if (rptObjectMain.Name.Length >= 5 && rptObjectMain.Kind == CrystalDecisions.Shared.ReportObjectKind.SubreportObject )
                {
                    if (rptObjectMain.Name.Trim().ToUpper().Substring(0, 5).Equals("TITLE"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument= new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDocument = rptMain.Subreports["rptTitle.rpt"];                     
                        if (tbrptHeader.Rows.Count > 0)
                        {
                            foreach (CrystalDecisions.CrystalReports.Engine.ReportObject rptObject in rptDocument.ReportDefinition.ReportObjects)
                            {
                                if (rptObject.Name.Length >= 4)
                                {
                                    if (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO")) 
                                    {
                                        rptObject.Left = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]);
                                        rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                        rptObject.Width = Convert.ToInt32(tbrptHeader.Rows[0]["WIDTH"]);
                                        rptObject.Height = Convert.ToInt32(tbrptHeader.Rows[0]["HEIGHT"]);
                                    }
                                }
                                if (rptObject.Name.Length >= 8 )
                                {
                                    if (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE"))
                                    {
                                        rptObject.Left = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]) + Convert.ToInt32(tbrptHeader.Rows[0]["WIDTH"]) + 200;
                                        rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                        rptObject.Height = 700;
                                        rptObject.Width = 5000;
                                    }
                                }
                                if( rptObject.Name.Length >= 6 )
                                {
                                    if (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) 
                                    {
                                        rptObject.Width = 2500;
                                        rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                        try
                                        {
                                            rptObject.Left = rptObjectMain.Width - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]);
                                        }
                                        catch {}                                        
                                        rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
                                    }
                                }
                            }
                        }
                    }
                }
                else 
                {                    
                    if (tbrptHeader.Rows.Count > 0)
                    {
                        foreach(CrystalDecisions.CrystalReports.Engine.ReportObject rptObject in rptMain.ReportDefinition.ReportObjects )
                        {
                            if (rptObject.Name.Length >= 4 )
                            {
                                if (rptObject.Name.Trim().ToUpper().Substring(0, 4).Equals("LOGO"))
                                {
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]);
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                    rptObject.Width = Convert.ToInt32(tbrptHeader.Rows[0]["WIDTH"]);
                                    rptObject.Height = Convert.ToInt32(tbrptHeader.Rows[0]["HEIGHT"]);
                                }
                            }
                            if( rptObject.Name.Length >= 8 )
                            {
                                if (rptObject.Name.Trim().ToUpper().Substring(0, 8).Equals("RPTTITLE"))
                                {
                                    rptObject.Left = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]) + Convert.ToInt32(tbrptHeader.Rows[0]["WIDTH"]) + 200;
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                    rptObject.Height = 700;
                                    rptObject.Width = 5000;
                                }
                            }
                            if(rptObject.Name.Length >= 6 )
                            {
                                if (rptObject.Name.Trim().ToUpper().Substring(0, 6).Equals("NGAYIN")) 
                                {
                                    rptObject.Width = 2500;
                                    rptObject.Top = Convert.ToInt32(tbrptHeader.Rows[0]["LE_TREN_LOGO"]);
                                    try
                                    {
                                        rptObject.Left = rptMain.PrintOptions.PageContentWidth - rptObject.Width - Convert.ToInt32(tbrptHeader.Rows[0]["LE_TRAI_LOGO"]);
                                    }
                                    catch {}                                    
                                    rptObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}