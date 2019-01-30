using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;
using OpenTK;

namespace craftersmine.EtherEngine.Rendering
{
    /// <summary>
    /// Represents game window. This class cannot be inherited
    /// </summary>
    public sealed class Window
    {
        private string title;

        private GameWindow _gameWnd;

        private Color fpsColor = Color.Gold;
        private Color fpsBgColor = Color.FromArgb(127, Color.Black);
        private Font fpsFont = new Font(new FontFamily("Consolas"), 8.25f, FontStyle.Regular);
        private Rectangle fpsBounds;
        private string fpsData = "";
        private AccurateTimer fpsUpdater;

        /// <summary>
        /// Gets current window size
        /// </summary>
        public WindowSize WindowSize { get; private set; }
        /// <summary>
        /// Gets current GLGDI+ wrapper instance
        /// </summary>
        public GLGDI GLGDI { get; private set; }

        /// <summary>
        /// Gets or sets VSync Mode
        /// </summary>
        public VSyncMode VSyncMode { get { return (VSyncMode)_gameWnd.VSync; } set { _gameWnd.VSync = (OpenTK.VSyncMode)value; } }

        /// <summary>
        /// Gets true if window in fullscreen mode, else false
        /// </summary>
        public bool IsFullscreen { get; private set; }

        /// <summary>
        /// Gets current FPS (Frames Per Second)
        /// </summary>
        public int FPS { get; private set; }
        /// <summary>
        /// Gets or sets window title
        /// </summary>
        public string Title { get { return title; } set { title = value; _gameWnd.Title = title; } }

        /// <summary>
        /// Creates a new instance of game window and makes it current
        /// </summary>
        /// <param name="title">Window title</param>
        /// <param name="windowSize">Window size</param>
        /// <param name="isFullscreen">Is fullscreen</param>
        public Window(string title, WindowSize windowSize, bool isFullscreen)
        {
            this.title = title;
            WindowSize = windowSize;
            IsFullscreen = isFullscreen;

            if (IsFullscreen)
                _gameWnd = new GameWindow(WindowSize.Width, WindowSize.Height, OpenTK.Graphics.GraphicsMode.Default, title, GameWindowFlags.Fullscreen);
            else
                _gameWnd = new GameWindow(WindowSize.Width, WindowSize.Height, OpenTK.Graphics.GraphicsMode.Default, title, GameWindowFlags.Default);

            _gameWnd.WindowBorder = WindowBorder.Fixed;

            _gameWnd.MakeCurrent();

            GLGDI = new GLGDI();

            _gameWnd.RenderFrame += _gameWnd_RenderFrame;

            GLGDI.ClearColor = Color.LightBlue;
            fpsBounds = new Rectangle(WindowSize.Width - 30, 0, 30, 30);

            _gameWnd.Load += _gameWnd_Load;
        }

        private void _gameWnd_Load(object sender, EventArgs e)
        {
            Load?.Invoke(this, e);
        }

        private void _gameWnd_RenderFrame(object sender, FrameEventArgs e)
        {
            FPS = (int)_gameWnd.RenderFrequency;
            GLGDI.Clear();

            Render?.Invoke(this, new RenderEventArgs() { FrameHeight = WindowSize.Height, FrameWidth = WindowSize.Width, GLGDIInstance = GLGDI });
            
            if (Debugging.DrawDebug)
            {
                GLGDI.DrawRectangle(fpsBgColor, fpsBounds);
                GLGDI.FillRectangle(fpsBgColor, fpsBounds);
                GLGDI.DrawString(fpsData, fpsFont, fpsColor, fpsBounds, TextQuality.High);
            }

            _gameWnd.SwapBuffers();
        }

        /// <summary>
        /// Occurs when new frame being rendered. Used by engine renderer
        /// </summary>
        public event EventHandler<RenderEventArgs> Render;

        /// <summary>
        /// Occurs before window being shown. Used by engine renderer
        /// </summary>
        public event EventHandler Load;

        /// <summary>
        /// Initializes and shows window and sets maximum framerate
        /// </summary>
        /// <param name="maxFps">Maximum framerate</param>
        public void Run(double maxFps)
        {
            preRun();
            _gameWnd.Run(maxFps);
        }

        /// <summary>
        /// Initializes and shows window at maximum possible framerate
        /// </summary>
        public void Run()
        {
            preRun();
            _gameWnd.Run();
        }

        private void preRun()
        {
            if (Debugging.DrawDebug)
            {
                fpsUpdater = new AccurateTimer(new Action(() => {
                    Debugging.FPS = FPS;
                    Debugging.FrameTime = _gameWnd.RenderPeriod * 1000;
                    fpsData = string.Format("{0} FPS\r\nFrameTime: {1:F2} ms\r\n~{2} DrawCalls per frame\r\n{3} TPS\r\n{4} CUpdates/s", Debugging.FPS, Debugging.FrameTime, Debugging.DrawCalls, Debugging.TPS, Debugging.CollisionsUpdatesPerSecond);
                    fpsBounds.Width = 0;
                    fpsBounds.Height = 0;
                    int lastLength = 0;
                    foreach (var ln in fpsData.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        if (lastLength < ln.Length)
                        {
                            lastLength = ln.Length;
                        }
                        fpsBounds.Width = 0;
                        for (int i = 0; i < lastLength; i++)
                        {
                            fpsBounds.Width += 7;
                            fpsBounds.X = WindowSize.Width - fpsBounds.Width;
                        }
                        fpsBounds.Height += 15;
                    }
                }), 1000);
                fpsUpdater.Start();
            }
        }

        /// <summary>
        /// Stops internal processes and closes window
        /// </summary>
        public void Close()
        {
            fpsUpdater?.Stop();
            _gameWnd.Exit();
        }
    }

    /// <summary>
    /// Defines arguments for rendering frame
    /// </summary>
    public sealed class RenderEventArgs : EventArgs
    {
        /// <summary>
        /// Gets current GLGDI wrapper instance
        /// </summary>
        public GLGDI GLGDIInstance { get; internal set; }
        /// <summary>
        /// Gets current frame width
        /// </summary>
        public int FrameWidth { get; internal set; }
        /// <summary>
        /// Gets current frame height
        /// </summary>
        public int FrameHeight { get; internal set; }
    }
}
