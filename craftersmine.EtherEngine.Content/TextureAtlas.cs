using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents multi-texture atlas. This class cannot be inherited
    /// </summary>
    public sealed class TextureAtlas
    {
        /// <summary>
        /// Gets currently used texture
        /// </summary>
        public Texture Texture { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="TextureAtlas"/> from specified texture
        /// </summary>
        /// <param name="textureAtlas"></param>
        public TextureAtlas(Texture textureAtlas)
        {
            Texture = textureAtlas;
        }

        /// <summary>
        /// Cuts and returns single texture with specified rectangle bounds from atlas 
        /// </summary>
        /// <param name="cuttingBounds"><see cref="Rectangle"/> with specified cutting bounds</param>
        /// <returns></returns>
        public Texture CutFromAtlas(Rectangle cuttingBounds)
        {
            Bitmap bmp = new Bitmap(cuttingBounds.Width, cuttingBounds.Height);
            var image = Graphics.FromImage(bmp);
            image.DrawImage(Texture.BaseBitmap, new Rectangle(0, 0, cuttingBounds.Width, cuttingBounds.Height), cuttingBounds, GraphicsUnit.Pixel);
            image.Dispose();

            return new Texture(bmp);
        }

        /// <summary>
        /// Cuts and returns single texture with specified bounds from atlas 
        /// </summary>
        /// <param name="x">X position of left-upper corner of cutting bounds</param>
        /// <param name="y">Y position of left-upper corner of cutting bounds</param>
        /// <param name="height">Height of cutting texture</param>
        /// <param name="width">Width of cutting texture</param>
        /// <returns></returns>
        public Texture CutFromAtlas(int x, int y, int width, int height)
        {
            return CutFromAtlas(new Rectangle(x, y, width, height));
        }
    }
}
