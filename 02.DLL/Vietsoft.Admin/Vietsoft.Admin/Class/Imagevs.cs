using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Imagevs
    {
        /// <summary>
        /// Convet Image to byte array
        /// </summary>
        public static byte[] ToByte(System.Drawing.Image vImage)
        {
            try
            {
                ImageConverter ImageConver = new ImageConverter();
                return (byte[])ImageConver.ConvertTo(vImage, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Convet byte array to image 
        /// </summary>
        public static Image ToImage(object value)
        {
            try
            {
                ImageConverter ImageConver = new ImageConverter();
                return (Image)ImageConver.ConvertFrom(value);
            }
            catch
            {
                return null;
            }
        }       
    }
}
