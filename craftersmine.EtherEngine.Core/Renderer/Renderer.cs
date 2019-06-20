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
using SharpDX.Windows;
using craftersmine.EtherEngine.Exceptions;

namespace craftersmine.EtherEngine.Renderer
{
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

        private D2D1.DeviceContext D2DDeviceContext;
        private D2D1.Device D2DDevice;
        private D2D1.Factory1 D2DFactory;
        private D2D1.RenderTarget RenderTarget;
        private D3D11.Device D3DDefaultDevice;
        private D3D11.Device1 D3DDevice;
        private D3D11.RenderTargetView RenderTargetView;
        private D3D11.Texture2D Backbuffer;
        private DXGI.Device DXGIDevice;
        private DXGI.Surface RenderTargetSurface;
        private DXGI.SwapChain SwapChain;
        private DXGI.SwapChainDescription SwapChainDescription;

        private IntPtr GameWindowHandle;

        private Renderer() { } // Hidden contructor

        internal RenderLoop RenderLoop { get; set; }

        public Renderer(IntPtr gameWndHandle)
        {
            GameWindowHandle = gameWndHandle;
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            try
            {
                SwapChainDescription = new DXGI.SwapChainDescription();
                SwapChainDescription.BufferCount = 1;
                SwapChainDescription.SampleDescription = new DXGI.SampleDescription(1, 0);
                SwapChainDescription.SwapEffect = DXGI.SwapEffect.Discard;
                SwapChainDescription.Usage = DXGI.Usage.BackBuffer | DXGI.Usage.RenderTargetOutput;
                SwapChainDescription.IsWindowed = true;
                SwapChainDescription.ModeDescription = new DXGI.ModeDescription(GameWindow.Current.WindowParameters.Width, GameWindow.Current.WindowParameters.Height, new DXGI.Rational(60, 1), DXGI.Format.B8G8R8A8_UNorm);
                SwapChainDescription.OutputHandle = GameWindowHandle;

                D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.BgraSupport, SwapChainDescription, out D3DDefaultDevice, out SwapChain);

                DXGI.Factory factory = SwapChain.GetParent<DXGI.Factory>();
                factory.MakeWindowAssociation(GameWindowHandle, DXGI.WindowAssociationFlags.IgnoreAll);

                D3DDevice = D3DDefaultDevice.QueryInterface<D3D11.Device1>();

                Backbuffer = D3D11.Texture2D.FromSwapChain<D3D11.Texture2D>(SwapChain, 0);
                RenderTargetView = new D3D11.RenderTargetView(D3DDevice, Backbuffer);
                D3DDevice.ImmediateContext.Rasterizer.SetViewport(0, 0, GameWindow.Current.WindowParameters.Width, GameWindow.Current.WindowParameters.Height);
                D3DDevice.ImmediateContext.OutputMerger.SetTargets(RenderTargetView);

                DXGIDevice = D3DDevice.QueryInterface<DXGI.Device>();

                D2DFactory = new D2D1.Factory1();
                D2DDevice = new D2D1.Device(D2DFactory, DXGIDevice);
                D2DDeviceContext = new D2D1.DeviceContext(D2DDevice, D2D1.DeviceContextOptions.None);

                RenderTargetSurface = Backbuffer.QueryInterface<DXGI.Surface>();
                RenderTarget = new D2D1.RenderTarget(D2DFactory, RenderTargetSurface, new D2D1.RenderTargetProperties(new D2D1.PixelFormat(DXGI.Format.Unknown, D2D1.AlphaMode.Premultiplied)));
                RenderTarget.AntialiasMode = D2D1.AntialiasMode.PerPrimitive;

                //RenderTargetBitmapProperties = new D2D1.BitmapProperties1(new D2D1.PixelFormat(DXGI.Format.R8G8B8A8_UNorm, D2D1.AlphaMode.Premultiplied), 96, 96, D2D1.BitmapOptions.Target | D2D1.BitmapOptions.CannotDraw);
                //RenderTarget = new D2D1.Bitmap1(D2DDeviceContext, new Size2(GameWindow.Current.WindowParameters.Width, GameWindow.Current.WindowParameters.Height), RenderTargetBitmapProperties);
                //D2DDeviceContext.Target = RenderTarget;
            }
            catch (Exception ex)
            {
                throw new DeviceInitializationException("Unable to initialize DirectX device!", ex);
            }
        }

        public void Render()
        {
            RenderTarget.BeginDraw();

            RenderTarget.Clear(SceneManager.CurrentScene.BackgroundColor.Color4);

            RenderTarget.EndDraw();

            SwapChain.Present(2, DXGI.PresentFlags.None);
        }
    }
}
