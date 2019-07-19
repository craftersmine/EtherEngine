using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Core;
using SharpDX;
using D2D1 = SharpDX.Direct2D1;
using DXGI = SharpDX.DXGI;
using SharpDX.Direct3D;
using D3D11 = SharpDX.Direct3D11;
using DW = SharpDX.DirectWrite;
using SharpDX.Windows;
using craftersmine.EtherEngine.Exceptions;
using craftersmine.EtherEngine.Utilities;
using System.Diagnostics;

namespace craftersmine.EtherEngine.Renderer
{
    /// <summary>
    /// Represents game renderer. This class cannot be inherited
    /// </summary>
    public sealed class Renderer
    {
        private FeatureLevel[] featureLevels = new FeatureLevel[] {
            FeatureLevel.Level_11_1,
            FeatureLevel.Level_11_0,
            FeatureLevel.Level_10_1,
            FeatureLevel.Level_10_0,
            FeatureLevel.Level_9_3,
            FeatureLevel.Level_9_2,
            FeatureLevel.Level_9_1
        };

        private D2D1.DeviceContext D2DDeviceContext;            // D2D Device Context
        private D2D1.Device D2DDevice;                          // D2D Device
        private D2D1.Factory1 D2DFactory;                       // D2D Factory
        internal D2D1.RenderTarget RenderTarget;                 // D2D Main render target
        //private D2D1.BitmapRenderTarget LightingTarget; // TODO: Make lighting
        private D3D11.Device D3DDefaultDevice;                  // D3D11 Base Device
        private D3D11.Device1 D3DDevice;                        // D3D11 Device
        private D3D11.RenderTargetView RenderTargetView;        // D3D11 Main render target view
        private D3D11.Texture2D Backbuffer;                     // D3D11 Main backbuffer
        private DXGI.Device DXGIDevice;                         // DXGI Device
        private DXGI.Surface RenderTargetSurface;               // DXGI Main render target view surface
        private DXGI.SwapChain SwapChain;                       // DXGI Swap chain
        private DXGI.SwapChainDescription SwapChainDescription; // Swap chain description

        // ====== Debug drawings brushes ====== //

        private D2D1.SolidColorBrush DrawingBoundsBrush;
        private D2D1.SolidColorBrush CollisionBoxesBrush;

        // ==================================== //

        private IntPtr GameWindowHandle;
        private Stopwatch Clock;
        private int FrameCount;
        private float TotalTime;
        private RenderFrame RenderFrame;

        private Renderer() { } // Hidden contructor

        /// <summary>
        /// Gets true if window if fullscreen, otherwise false
        /// </summary>
        public bool IsFullscreen { get { return SwapChain.IsFullScreen; } private set { SwapChain.SetFullscreenState(value, null); } }

        /// <summary>
        /// Gets true if renderer currently suppresed for internal operation, otherwise false
        /// </summary>
        public bool IsRendererSuppressed { get; private set; }

        /// <summary>
        /// Gets or sets rendering interpolation mode
        /// </summary>
        public Core.InterpolationMode InterpolationMode { get; set; }

        /// <summary>
        /// Creates a new <see cref="Renderer"/> instance with specified pointer to window
        /// </summary>
        /// <param name="gameWndHandle">Renderer window pointer</param>
        public Renderer(IntPtr gameWndHandle)
        {
            GameWindowHandle = gameWndHandle;
            InterpolationMode = Core.InterpolationMode.Linear;
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            try
            {
                SwapChainDescription = new DXGI.SwapChainDescription();
                SwapChainDescription.BufferCount = 2;
                SwapChainDescription.SampleDescription = new DXGI.SampleDescription(1, 0);
                SwapChainDescription.SwapEffect = DXGI.SwapEffect.Discard;
                SwapChainDescription.Usage = DXGI.Usage.BackBuffer | DXGI.Usage.RenderTargetOutput;
                SwapChainDescription.IsWindowed = true;
                SwapChainDescription.ModeDescription = new DXGI.ModeDescription(GameWindow.Current.WindowParameters.Width, GameWindow.Current.WindowParameters.Height, new DXGI.Rational(60, 1), DXGI.Format.B8G8R8A8_UNorm);
                SwapChainDescription.OutputHandle = GameWindowHandle;

                D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.BgraSupport, featureLevels, SwapChainDescription, out D3DDefaultDevice, out SwapChain);

                DXGI.Factory factory = SwapChain.GetParent<DXGI.Factory>();
                factory.MakeWindowAssociation(GameWindowHandle, DXGI.WindowAssociationFlags.IgnoreAll);

                D3DDevice = D3DDefaultDevice.QueryInterface<D3D11.Device1>();

                Backbuffer = D3D11.Texture2D.FromSwapChain<D3D11.Texture2D>(SwapChain, 0);
                RenderTargetView = new D3D11.RenderTargetView(D3DDevice, Backbuffer);
                D3DDevice.ImmediateContext.Rasterizer.SetViewport(0, 0, GameWindow.Current.WindowParameters.Width, GameWindow.Current.WindowParameters.Height);
                D3DDevice.ImmediateContext.OutputMerger.SetTargets(RenderTargetView);

                DXGIDevice = D3DDevice.QueryInterface<DXGI.Device>();

                D2DFactory = new D2D1.Factory1(D2D1.FactoryType.MultiThreaded);
                D2DDevice = new D2D1.Device(D2DFactory, DXGIDevice);
                D2DDeviceContext = new D2D1.DeviceContext(D2DDevice, D2D1.DeviceContextOptions.None);

                RenderTargetSurface = Backbuffer.QueryInterface<DXGI.Surface>();
                RenderTarget = new D2D1.RenderTarget(D2DFactory, RenderTargetSurface, new D2D1.RenderTargetProperties(new D2D1.PixelFormat(DXGI.Format.Unknown, D2D1.AlphaMode.Premultiplied)));
                RenderTarget.AntialiasMode = D2D1.AntialiasMode.PerPrimitive;

                // Initialize debug drawings brushes
                DrawingBoundsBrush = new D2D1.SolidColorBrush(RenderTarget, new SharpDX.Color(1f, 1f, 0f));
                CollisionBoxesBrush = new D2D1.SolidColorBrush(RenderTarget, new SharpDX.Color(1f, 0f, 0f));

                RenderFrame = new RenderFrame(RenderTarget);

                Clock = Stopwatch.StartNew();
            }
            catch (Exception ex)
            {
                throw new DeviceInitializationException("Unable to initialize DirectX device!", ex);
            }
        }

        /// <summary>
        /// Toggles fullscreen mode
        /// </summary>
        public void ToggleFullscreen()
        {
            IsFullscreen = !IsFullscreen;
        }

        /// <summary>
        /// Resizes buffers and target to a new parameters
        /// </summary>
        /// <param name="windowParameters">Window parameters</param>
        // FIX: ResizeTarget doesn't cleanup memory on switch sizes
        public void ResizeTarget(WindowParameters windowParameters)
        {
            GameWindow.Current.WindowParameters = windowParameters;
            IsRendererSuppressed = true;
            ReleaseDevices();
            InitializeDevices();
            Clock.Restart();
            IsRendererSuppressed = false;
        }

        internal void ReleaseDevices()
        {
            IsRendererSuppressed = true;
            RenderTarget.Dispose();
            Backbuffer.Dispose();
            RenderTargetSurface.Dispose();
            RenderTargetView.Dispose();
            D2DDeviceContext.Dispose();
            D2DDevice.Dispose();
            D2DFactory.Dispose();
            DXGIDevice.Dispose();
            D3DDevice.Dispose();
            D3DDefaultDevice.Dispose();
            SwapChain.Dispose();
            SwapChain = null;
            RenderTarget = null;
            RenderTargetSurface = null;
            Backbuffer = null;
            RenderTargetView = null;
            D2DDeviceContext = null;
            D2DFactory = null;
            D2DDevice = null;
            DXGIDevice = null;
            D3DDevice = null;
            D3DDefaultDevice = null;
        }

        /// <summary>
        /// Sets fullscreen mode state
        /// </summary>
        /// <param name="state">true for fullscreen, false for windowed</param>
        public void SetFullscreenState(bool state)
        {
            IsFullscreen = state;
        }

        internal void Render()
        {
            if (!IsRendererSuppressed)
            {
                if (RenderTarget != null)
                {
                    if (!RenderTarget.IsDisposed)
                    {
                        CountFPS(); // === Start count frame time

                        RenderTarget.BeginDraw();

                        RenderTarget.Clear(SceneManager.CurrentScene.BackgroundColor.RawColor);
                        
                        for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                        {
                            SceneManager.CurrentScene.GameObjects[obj].GetComponent<IRenderable>().OnRender(RenderFrame);
                            RenderTarget.Transform = Matrix3x2.Identity;
                        }

                        if (Debugging.DrawBounds)
                        {
                            for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                            {
                                RenderTarget.DrawRectangle(SceneManager.CurrentScene.GameObjects[obj].Transform.DrawingBoundings.RawRectangle, DrawingBoundsBrush);
                                RenderTarget.DrawRectangle(SceneManager.CurrentScene.GameObjects[obj].CollisionBox.ColliderBounds, CollisionBoxesBrush);
                                RenderTarget.Transform = Matrix3x2.Identity;
                            }
                        }

                        RenderTarget.Transform = Matrix3x2.Identity;

                        RenderTarget.EndDraw();

                        switch (GameWindow.Current.WindowParameters.VSyncMode)
                        {
                            case VSyncMode.Off:
                                SwapChain.Present(0, DXGI.PresentFlags.None);
                                break;
                            case VSyncMode.On:
                                SwapChain.Present(1, DXGI.PresentFlags.None);
                                break;
                            case VSyncMode.Half:
                                SwapChain.Present(2, DXGI.PresentFlags.None);
                                break;
                        }

                        Clock.Restart(); // === End count frame time
                    }
                }
            }
        }

        private void CountFPS()
        {
            FrameCount++;
            Debugging.FrameTime = (float)Clock.ElapsedTicks / Stopwatch.Frequency;
            TotalTime += Debugging.FrameTime;
            if (TotalTime >= 1.0f)
            {
                Debugging.FPS = (float)FrameCount / TotalTime;

                FrameCount = 0;
                TotalTime = 0;
            }
        }
    }
}
