using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLGDIPlus;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents a texture. This class cannot be inherited
    /// </summary>
    public sealed class Texture
    {
        /// <summary>
        /// Gets renderable image object
        /// </summary>
        internal GLImage RenderableImage { get; private set; }
        /// <summary>
        /// Gets base texture bitmap
        /// </summary>
        public Bitmap BaseBitmap { get; private set; }
        /// <summary>
        /// Gets width of texture
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Gets height of texture
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Texture"/> from specified <see cref="Bitmap"/>
        /// </summary>
        /// <param name="bitmap">Texture base bitmap</param>
        public Texture(Bitmap bitmap)
        {
            RenderableImage = new GLImage();
            BaseBitmap = bitmap;
            Width = BaseBitmap.Width;
            Height = BaseBitmap.Height;
            RenderableImage.FromBitmap(BaseBitmap);
        }

        /// <summary>
        /// Loads texture from bitmap file
        /// </summary>
        /// <param name="filename">Bitmap filepath</param>
        /// <returns>Loaded <see cref="Texture"/></returns>
        public static Texture FromFile(string filename)
        {
            Bitmap bmp = (Bitmap)Image.FromFile(filename);
            return new Texture(bmp);
        }

        /// <summary>
        /// Gets specified pixel color
        /// </summary>
        /// <param name="x">X pixel</param>
        /// <param name="y">Y pixel</param>
        /// <returns><see cref="Color"/> of pixel[x,y]</returns>
        public Color GetPixelColor(int x, int y)
        {
            return BaseBitmap.GetPixel(x, y);
        }
    }
}
