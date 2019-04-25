using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Input;
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

        /// <summary>
        /// Gets current game window instance
        /// </summary>
        public static Window CurrentWindow { get; private set; }

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
            CurrentWindow = this;

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

            _gameWnd.Load += _gameWnd_Load;
            _gameWnd.Closing += _gameWnd_Closing;
            Keyboard.KeyboardDevice = _gameWnd.Keyboard;
            Mouse.MouseDevice = _gameWnd.Mouse;
            Mouse.MouseDevice.ButtonDown += Mouse.MouseDeviceButtonDownEvent;
            Mouse.MouseDevice.ButtonUp += Mouse.MouseDeviceButtonUpEvent;
            Mouse.MouseDevice.Move += Mouse.MouseDeviceMoveEvent;
            Mouse.MouseDevice.WheelChanged += Mouse.MouseDeviceWheelChangedEvent;

        }

        private void _gameWnd_Closing(object sender, CancelEventArgs e)
        {
            Debugging.Log(LogEntryType.Info, "Invoked Exiting event...");
            Exiting?.Invoke(this, e);
        }

        private void _gameWnd_Load(object sender, EventArgs e)
        {
            Debugging.Log(LogEntryType.Info, "Invoked Load event...");
            Load?.Invoke(this, e);
        }

        private double _fpsTime;
        private string _usedRamSuffix = "Bytes";
        private float _usedRam = 0.0f;

        private void _gameWnd_RenderFrame(object sender, FrameEventArgs e)
        {
            FPS = (int)_gameWnd.RenderFrequency;
            GLGDI.Clear();

            Render?.Invoke(this, new RenderEventArgs() { FrameHeight = WindowSize.Height, FrameWidth = WindowSize.Width, GLGDIInstance = GLGDI });
            
            if (Debugging.DrawDebug)
            {
                //if (_fpsTime >= 1.0f)
                //{
                    Debugging.FPS = FPS;

                    Debugging.FrameTime = _gameWnd.RenderTime * 1000.0f;
                    _usedRam = Debugging.RAM;
                    if (_usedRam > 1024.0f)
                    {
                        _usedRam /= 1024.0f;
                        _usedRamSuffix = "KBytes";
                        if (_usedRam > 1024.0f)
                        {
                            _usedRam /= 1024.0f;
                            _usedRamSuffix = "MBytes";
                            if (_usedRam > 1024.0f)
                            {
                                _usedRam /= 1024.0f;
                                _usedRamSuffix = "GBytes";
                            }
                        }
                    //}
                    
                    fpsData = string.Format("{0} FPS\r\n" +
                        "FrameTime: {1:F2} ms\r\n" +
                        "Frame: {9}\r\n" +
                        "~{2} RenderCalls per frame\r\n" +
                        "UpdateTime: {3:F2} ms\r\n" +
                        "FixedUpdateTime: {4:F2} ms\r\n" +
                        "LagTime: {10} ms\r\n" +
                        "Used RAM: {5:F2} {6}\r\n" +
                        "TPS: {7}\r\n" +
                        "FixedTPS: {8}", Debugging.FPS, 
                        Debugging.FrameTime,
                        Debugging.RenderCalls,
                        Debugging.UpdateTime * 1000.0f, 
                        Debugging.FixedUpdateTime * 1000.0f,
                        _usedRam, 
                        _usedRamSuffix,
                        Debugging.TPS,
                        Debugging.FixedTPS,
                        Debugging.Frame,
                        Debugging.LagTime);

                    _fpsTime = 0.0f;
                }

                Size textSize = TextRenderer.MeasureText(fpsData, fpsFont);
                fpsBounds = new Rectangle(WindowSize.Width - textSize.Width, 0, textSize.Width, textSize.Height);

                GLGDI.DrawRectangle(fpsBgColor, fpsBounds);
                GLGDI.FillRectangle(fpsBgColor, fpsBounds);

                GLGDI.DrawString(fpsData, fpsFont, fpsColor, fpsBounds, TextQuality.High);

                _fpsTime += _gameWnd.RenderTime;
            }
            
            _gameWnd.SwapBuffers();
            Debugging.Frame++;
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
        /// Occurs when close on window clicked
        /// </summary>
        public event EventHandler<CancelEventArgs> Exiting;

        /// <summary>
        /// Initializes and shows window and sets maximum framerate
        /// </summary>
        /// <param name="maxFps">Maximum framerate</param>
        public void Run(double maxFps)
        {
            _gameWnd.Run(maxFps);
        }

        /// <summary>
        /// Initializes and shows window at maximum possible framerate
        /// </summary>
        public void Run()
        {
            _gameWnd.Run();
        }

        /// <summary>
        /// Stops internal processes and closes window
        /// </summary>
        public void Close()
        {
            _gameWnd.Exit();
        }

        /// <summary>
        /// Changes window resolution to specified
        /// </summary>
        /// <param name="size">New window resolution</param>
        public void ChangeResolution(WindowSize size)
        {
            CurrentWindow._gameWnd.Height = size.Height;
            CurrentWindow._gameWnd.Width = size.Width;
            GLGDI.GLGraphics.Init();
            WindowSize = size;
        }

        /// <summary>
        /// Changes window fullscreen mode or windowed
        /// </summary>
        /// <param name="isFullscreen">true to make window fullscreen, otherwise false</param>
        public void ChangeFullscreenMode(bool isFullscreen)
        {
            IsFullscreen = isFullscreen;
            if (!IsFullscreen)
                CurrentWindow._gameWnd.WindowState = WindowState.Fullscreen;
            else CurrentWindow._gameWnd.WindowState = WindowState.Normal;
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
