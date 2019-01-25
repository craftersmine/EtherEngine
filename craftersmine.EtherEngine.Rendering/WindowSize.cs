using System;
using System.Drawing;

namespace craftersmine.EtherEngine.Rendering
{
    /// <summary>
    /// Represents window size
    /// </summary>
    [Serializable]
    public struct WindowSize
    {
        /// <summary>
        /// Window width
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Window height
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Creates a new instance of WindowSize with specified width and height
        /// </summary>
        /// <param name="width">Window width</param>
        /// <param name="height">Window height</param>
        public WindowSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Creates a new instance of WindowSize from preset
        /// </summary>
        /// <param name="preset">Window size preset</param>
        [Obsolete("This constructor does not carry any workload and will soon be removed.")]
        public WindowSize(WindowSize preset)
        {
            Width = preset.Width;
            Height = preset.Height;
        }

        /// <summary>
        /// Gets <see cref="Size"/> from WindowSize with window Width and Height
        /// </summary>
        /// <returns>Size</returns>
        public Size GetSize()
        {
            return new Size(Width, Height);
        }

        /// <summary>
        /// Returns a string representing current window size in "Width" x "Height" format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Width + "x" + Height;
        }
    }

    /// <summary>
    /// Represents window size presets according to https://en.wikipedia.org/wiki/Display_resolution#Common_display_resolutions. This class cannot be inherited
    /// </summary>
    public static class WindowSizePresets
    {
        /// <summary>
        /// FullHD size (1920x1080) (16:9)
        /// </summary>
        public static WindowSize FullHD { get; } = new WindowSize(1920, 1080);
        /// <summary>
        /// WXGA or HD size (1280x720) (16:9)
        /// </summary>
        public static WindowSize WXGAorHD { get; } = new WindowSize(1280, 720);
        /// <summary>
        /// HD size (1366x768) (~16:9)
        /// </summary>
        public static WindowSize HD { get; } = new WindowSize(1366, 768);
        /// <summary>
        /// HD+ size (1600x900) (16:9)
        /// </summary>
        public static WindowSize HDPlus { get; } = new WindowSize(1600, 900);
        /// <summary>
        /// WQHD size or 2k size (2560x1440) (16:9)
        /// </summary>
        [Obsolete("This resolution is too large and because it not recommended", false)]
        public static WindowSize WQHD { get; } = new WindowSize(2560, 1440);
        /// <summary>
        /// UHD size or 4k size (3840x2160) (16:9)
        /// </summary>
        [Obsolete("This resolution is too large and because it not recommended", false)]
        public static WindowSize UHD { get; } = new WindowSize(3840, 2160);
        /// <summary>
        /// SVGA size (800x600) (4:3)
        /// </summary>
        [Obsolete("This resolution is too old and because it not recommended", false)]
        public static WindowSize SVGA { get; } = new WindowSize(800, 600);
        /// <summary>
        /// XGA size (1024x768) (4:3)
        /// </summary>
        public static WindowSize XGA { get; } = new WindowSize(1024, 768);
        /// <summary>
        /// WXGA size (1280x768) (5:3)
        /// </summary>
        public static WindowSize WXGA { get; } = new WindowSize(1280, 768);
        /// <summary>
        /// SXGA size (1280x1024) (5:4)
        /// </summary>
        [Obsolete("This resolution is too old and because it not recommended", false)]
        public static WindowSize SXGA { get; } = new WindowSize(1280, 1024);
    }
}