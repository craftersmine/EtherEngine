namespace craftersmine.EtherEngine.Core
{
    public struct WindowParameters
    {
        public int Width { get; set; }
        public int Height { get; set; } 
        public bool Fullscreen { get; set; }
        public VSyncMode VSyncMode { get; set; }
        public string Title { get; set; }

        public WindowParameters(int width, int height, bool fullscreen, VSyncMode vsync, string title)
        {
            Width = width;
            Height = height;
            Fullscreen = fullscreen;
            VSyncMode = vsync;
            Title = title;
        }

        public WindowParameters(int width, int height, bool fullscreen, string title) : this(width, height, fullscreen, VSyncMode.Enabled, title) { }

        public WindowParameters(int width, int height, bool fullscreen) : this(width, height, fullscreen, "craftersmine EtherEngine Game Window") { }

        public WindowParameters(int width, int height) : this(width, height, false) { }
    }

    public enum VSyncMode
    {
        Disabled,
        Enabled,
        Half
    }
}