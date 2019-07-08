using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Core;
using SharpDX.WIC;
using D2DBitmap = SharpDX.Direct2D1.Bitmap;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents a texture. This class cannot be inherited
    /// </summary>
    public sealed class Texture
    {
        internal static ImagingFactory ImagingFactory { get; set; } = new ImagingFactory();

        internal byte[] RawData { get; set; }
        internal D2DBitmap Bitmap { get; set; }

        /// <summary>
        /// Gets texture height in pixels
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Gets texture width in pixels
        /// </summary>
        public int Width { get; private set; }

        private Texture()
        { }

        /// <summary>
        /// Creates new instance of <see cref="Texture"/>
        /// </summary>
        /// <param name="data">Byte array that conatins texture information</param>
        public Texture(byte[] data)
        {
            RawData = data;
            BitmapSource src = GetBitmapSource(RawData);
            Bitmap = D2DBitmap.FromWicBitmap(Game.Renderer.RenderTarget, src);
            Height = (int)Bitmap.Size.Height;
            Width = (int)Bitmap.Size.Width;
        }

        /// <summary>
        /// Loads <see cref="Texture"/> from file
        /// </summary>
        /// <param name="filename">Full path to texture file</param>
        /// <returns></returns>
        public static Texture FromFile(string filename)
        {
            return new Texture(File.ReadAllBytes(filename));
        }

        private static BitmapSource GetBitmapSource(byte[] data)
        {
            MemoryStream memStream = new MemoryStream(data);
            BitmapDecoder decoder = new BitmapDecoder(ImagingFactory, memStream, DecodeOptions.CacheOnDemand);
            FormatConverter formatConverter = new FormatConverter(ImagingFactory);
            formatConverter.Initialize(decoder.GetFrame(0), PixelFormat.Format32bppPRGBA, BitmapDitherType.None, null, 0.0, BitmapPaletteType.Custom);
            return formatConverter;
        }
    }
}
