using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using DevExpress.XtraEditors;

namespace ReportMain
{
    public partial class ucGiayPhepLamViecTrenCao : UserControl
    {
        private string ms;
        private Int64 id;
        public ucGiayPhepLamViecTrenCao(string s,Int64 idsp)
        {
            InitializeComponent();
            ms = s;
            id = idsp;
        }
        private void ucGiayPhepLamViecTrenCao_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    if (item.GetType().Name.ToString() == "LabelControl")
                    {
                        item.Text = Commons.Modules.GetNNgu("frmKhuVucGioiHan", item.Name);
                    }
                }
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT Col1, Col2, Col3, Col4,Col5, Col6, Col7, Col8, Col9 FROM dbo.GIAY_PHEP WHERE ID = " + id + ""));
                if (dt.Rows.Count == 0) return;
                txtNguoiTH3.Text = dt.Rows[0][2].ToString();
                txtNhaThau4.Text = dt.Rows[0][3].ToString();
                txtMoTa5.Text = dt.Rows[0][4].ToString();
                try
                {
                    datDN2.DateTime = Convert.ToDateTime(dt.Rows[0][1]);
                }
                catch 
                {
                }
                try
                {
                    datTN1.DateTime = Convert.ToDateTime(dt.Rows[0][0]);
                }
                catch
                {
                }
               
            }
            catch
            { }
        }
        public void UpdateIn(Int64 IDGP)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.GIAY_PHEP SET Col1 = N'" + datTN1.Text + "',Col2 =N'" + datDN2.Text + "',Col3 =N'" + txtNguoiTH3.Text + " ',Col4 =N' " + txtNhaThau4.Text + " ',Col5 =N'" + txtMoTa5.Text + "' WHERE ID =" + IDGP + "");
            }
            catch
            {
            }
        }

        public void IN(string sFile)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            object missing = System.Type.Missing;

            try
            {
                object fileName = Application.StartupPath + Path.DirectorySeparatorChar + @"\Templete\GP_LVTC.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);

                doc.Activate();

                Commons.Modules.ObjSystems.WordReplace(doc, "<TGio>", datTN1.DateTime.TimeOfDay.ToString());
                Commons.Modules.ObjSystems.WordReplace(doc, "<TNgay>", datTN1.DateTime.Date.ToString("dd/MM/yyyy"));
                Commons.Modules.ObjSystems.WordReplace(doc, "<DGio>", datDN2.DateTime.TimeOfDay.ToString());
                Commons.Modules.ObjSystems.WordReplace(doc, "<DNgay>", datDN2.DateTime.Date.ToString("dd/MM/yyyy"));

                Commons.Modules.ObjSystems.WordReplace(doc, "<NThucHien>", txtNguoiTH3.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<NhaThau>", txtNhaThau4.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<MoTaCV>",txtMoTa5.Text);
                doc.SaveAs(sFile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
                System.Diagnostics.Process.Start(sFile);
            }
            catch (Exception ex)
            {
                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
