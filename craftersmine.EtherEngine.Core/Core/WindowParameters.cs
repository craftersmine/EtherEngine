namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a window parameters
    /// </summary>
    public struct WindowParameters
    {
        /// <summary>
        /// Gets window width
        /// </summary>
        public int Width { get; internal set; }
        /// <summary>
        /// Gets window height
        /// </summary>
        public int Height { get; internal set; } 
        /// <summary>
        /// Gets or sets fullscreen state
        /// </summary>
        public bool IsFullscreen { get; set; }
        /// <summary>
        /// Gets or sets VSync mode
        /// </summary>
        public VSyncMode VSyncMode { get; set; }
        /// <summary>
        /// Gets window title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure
        /// </summary>
        /// <param name="width">Window width in pixels</param>
        /// <param name="height">Window height in pixels</param>
        /// <param name="fullscreen">Is window must be fullscreen</param>
        /// <param name="vsync">Renderer VSync mode</param>
        /// <param name="title">Window title</param>
        public WindowParameters(int width, int height, bool fullscreen, VSyncMode vsync, string title)
        {
            Width = width;
            Height = height;
            IsFullscreen = fullscreen;
            VSyncMode = vsync;
            Title = title;
        }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure
        /// </summary>
        /// <param name="width">Window width in pixels</param>
        /// <param name="height">Window height in pixels</param>
        /// <param name="fullscreen">Is window must be fullscreen</param>
        /// <param name="title">Window title</param>
        public WindowParameters(int width, int height, bool fullscreen, string title) : this(width, height, fullscreen, VSyncMode.Enabled, title) { }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure
        /// </summary>
        /// <param name="width">Window width in pixels</param>
        /// <param name="height">Window height in pixels</param>
        /// <param name="fullscreen">Is window must be fullscreen</param>
        public WindowParameters(int width, int height, bool fullscreen) : this(width, height, fullscreen, "craftersmine EtherEngine Game Window") { }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure
        /// </summary>
        /// <param name="width">Window width in pixels</param>
        /// <param name="height">Window height in pixels</param>
        public WindowParameters(int width, int height) : this(width, height, false) { }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure with exact properties values as passed into copy
        /// </summary>
        /// <param name="windowParameters">Exists window parameters</param>
        public WindowParameters(WindowParameters windowParameters) : this(windowParameters.Width, windowParameters.Height, windowParameters.IsFullscreen, windowParameters.VSyncMode, windowParameters.Title) { }

        /// <summary>
        /// Creates a new <see cref="WindowParameters"/> structure with exact properties values as passed into copy and sets new specified width and height
        /// </summary>
        /// <param name="windowParameters">Exists window parameters</param>
        /// <param name="newWidth">New window width in pixels</param>
        /// <param name="newHeight">New window height in pixels</param>
        public WindowParameters(WindowParameters windowParameters, int newWidth, int newHeight) : this(newWidth, newHeight, windowParameters.IsFullscreen, windowParameters.VSyncMode, windowParameters.Title) { }
    }
}