using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.IO;

namespace ReportMain
{
    public partial class ucGiayPhepKhuVucGioiHan : UserControl
    {
        private string ms;
        private Int64 id;
       
        public ucGiayPhepKhuVucGioiHan(string s,Int64 idsp)
        {
            InitializeComponent();
            ms = s;
            id = idsp;
        }
        private void ucGiayPhepKhuVucGioiHan_Load(object sender, EventArgs e)
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
                txtKhuVucDiVao1.Text = dt.Rows[0][0].ToString();
                txtKhuVucGioiHan2.Text = dt.Rows[0][1].ToString();
                txtLyDo3.Text = dt.Rows[0][2].ToString();
                txtTruongNhom4.Text = dt.Rows[0][3].ToString();
                txtNguoiDuyetGP5.Text = dt.Rows[0][4].ToString();
                txtKyTen6.Text = dt.Rows[0][5].ToString();
                try
                {
                    timHours7.EditValue = dt.Rows[0][6].ToString();
                }
                catch{}
               
            }
            catch { }
        }
        public void UpdateIn(Int64 IDGP)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.GIAY_PHEP SET Col1 = N'" + txtKhuVucDiVao1.Text + "',Col2 =N'" + txtKhuVucGioiHan2.Text + "',Col3 =N'" + txtLyDo3.Text + "',Col4 =N'" + txtTruongNhom4.Text + " ',Col5 = N'" + txtNguoiDuyetGP5.Text + " ',Col6 =N'" + txtKyTen6.Text + "',Col7 =N'" + timHours7.Text + "' WHERE ID =" + IDGP + "");
            }
            catch
            {
            }
        }


        public void IN(string sFile,string ngay)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            object missing = System.Type.Missing;

            try
            {
                object fileName = Application.StartupPath + Path.DirectorySeparatorChar +@"\Templete\GP_KVGH.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);

                doc.Activate();

                Commons.Modules.ObjSystems.WordReplace(doc, "<So>", ms);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Ngay>", ngay);
                Commons.Modules.ObjSystems.WordReplace(doc, "<KhuVuc>", txtKhuVucDiVao1.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<ViTri>", txtKhuVucGioiHan2.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<LyDo>", txtLyDo3.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Ten>", txtTruongNhom4.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Duyet>", txtNguoiDuyetGP5.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<KyTen>", txtKyTen6.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Gio>", timHours7.Text);

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
