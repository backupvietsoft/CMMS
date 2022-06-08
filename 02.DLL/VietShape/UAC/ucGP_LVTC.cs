using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace VietShape
{
    
    public partial class ucGP_LVTC : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGP_LVTC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Doc file (*.doc)|*.doc","AT");

            if (sPath == "") return;
            //InCatHan(sPath);
            //InGioiHan(sPath);
            //InTrenCao(sPath);
            InKVGH(sPath);
        }
        private void InCatHan(string sFile)
        {
            this.Cursor = Cursors.WaitCursor;


            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            object missing = System.Type.Missing;

            try
            {
                object fileName = @"D:\01.Code\02.DLL\VietShape\bin\Debug\Templete\GP_CH.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);

                doc.Activate();
                WordReplace(doc, "<So>", "Số");
                WordReplace(doc, "<Ngay>", @"Ngày");
                WordReplace(doc, "<KhuVuc>", @"Khu vực");
                WordReplace(doc, "<Tang>", @"Tầng");

                WordReplace(doc, "<LoaiCV>", @"Loại công việc");


                WordReplace(doc, "<NguoiChoPhep>", @"Người cho phép ký tên");
                WordReplace(doc, "<BatDau>", @"bắt đầu");
                WordReplace(doc, "<KetThuc>", @"kết thúc");

                WordReplace(doc, "<NVKT>", @"Nhân viên kiểm tra:");





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

            this.Cursor = Cursors.Default;
            

        }
        private void InKVGH(string sFile)
        {
            this.Cursor = Cursors.WaitCursor;


            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            object missing = System.Type.Missing;

            try
            {
                object fileName = @"D:\01.Code\02.DLL\VietShape\bin\Debug\Templete\GP_KVGH.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);

                doc.Activate();

                WordReplace(doc, "<So>", @"So");
                WordReplace(doc, "<Ngay>", @"Ngay");
                WordReplace(doc, "<KhuVuc>", @"KhuVuc");
                WordReplace(doc, "<ViTri>", @"ViTri");

                WordReplace(doc, "<LyDo>", @"LyDo");
                WordReplace(doc, "<Ten>", @"Ten");

                WordReplace(doc, "<Duyet>", @"Duyet");

                WordReplace(doc, "<KyTen>", @"KyTen");
                WordReplace(doc, "<Gio>", @"Gio");




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

            this.Cursor = Cursors.Default;


        }
        private void InTrenCao(string sFile)
        {
            this.Cursor = Cursors.WaitCursor;


            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            object missing = System.Type.Missing;

            try
            {
                object fileName = @"D:\01.Code\02.DLL\VietShape\bin\Debug\Templete\GP_LVTC.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);

                doc.Activate();

                WordReplace(doc, "<TGio>", @"TGio1");
                WordReplace(doc, "<TNgay>", @"TNgay2");
                WordReplace(doc, "<DGio>", @"DGio3");
                WordReplace(doc, "<DNgay>", @"DNgay4");   

                WordReplace(doc, "<NThucHien>", @"NThucHien5");
                WordReplace(doc, "<NhaThau>", @"NhaThau6");

                WordReplace(doc, "<MoTaCV>", @"MoTaCV7");





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

            this.Cursor = Cursors.Default;


        }
        private void WordReplace (Microsoft.Office.Interop.Word.Document doc,string sFindText, string sReplaceText)
        {
            object missing = System.Type.Missing;
            foreach (Microsoft.Office.Interop.Word.Range tmpRange in doc.StoryRanges)
            {
                tmpRange.Find.Text = sFindText;
                tmpRange.Find.Replacement.Text = sReplaceText;
                tmpRange.Find.Replacement.ParagraphFormat.Alignment =
                 Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref replaceAll,
                 ref missing, ref missing, ref missing, ref missing);
            }

        }
        
    }
}
