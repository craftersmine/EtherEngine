using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace craftersmine.EtherEngine.GDK.TextureEditor
{
    public sealed class FileHelper
    {
        public static Bitmap LoadImage(string fullpath)
        {
            return (Bitmap)Image.FromFile(fullpath);
        }

        public static void SaveImage(string fullpath, Bitmap bitmap)
        {
            bitmap.Save(fullpath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
