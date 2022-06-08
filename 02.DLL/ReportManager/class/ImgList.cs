using System;
using System.Collections.Generic;
using System.Text;

namespace ReportManager
{
    public class ImgList
    {
        private static System.Windows.Forms.ImageList _imgList;

        public static System.Windows.Forms.ImageList ImgList1
        {
            get { return ImgList._imgList; }
            set { ImgList._imgList = value; }
        }

        private static System.Windows.Forms.ImageList _imgSmallList;

        public static System.Windows.Forms.ImageList ImgSmallList
        {
            get { return ImgList._imgSmallList; }
            set { ImgList._imgSmallList = value; }
        }

        public static void CreateImagelists(string vpathImage, System.Windows.Forms.ImageList iconImages)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(vpathImage);
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {
                    if (f.Extension == ".png" || f.Extension == ".ico" || f.Extension == ".jpg" || f.Extension == ".gif")
                    {
                        string _vpathImage = vpathImage + f.Name;
                        iconImages.Images.Add(f.Name.Replace('.', '_'), System.Drawing.Image.FromFile(_vpathImage));
                    }
                }

            }
            catch { }

        }

        public static int getImageIndestring(string _keyword, System.Windows.Forms.ImageList _iconImages)
        {
            for (int i = 0; i < _iconImages.Images.Count; i++)
            {
                if (_keyword.Replace('.', '_') == _iconImages.Images.Keys[i].ToString())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
