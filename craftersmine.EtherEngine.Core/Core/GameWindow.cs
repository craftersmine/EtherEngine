using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.Windows;

namespace craftersmine.EtherEngine.Core
{
    public class GameWindow : RenderForm
    {
        public WindowParameters WindowParameters { get; set; }
        public static GameWindow Current { get; internal set; }

        private GameWindow() { }

        public GameWindow(WindowParameters parameters)
        {
            if (parameters.Width == 0)
                parameters.Width = 800;
            if (parameters.Height == 0)
                parameters.Height = 600;

            //SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            ResizeRedraw = true;
            //DoubleBuffered = true;

            WindowParameters = parameters;
            Text = WindowParameters.Title;
            ClientSize = new Size(WindowParameters.Width, WindowParameters.Height);
            Current = this;
            IsFullscreen = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Current = null;
            base.OnFormClosing(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Game.Renderer != null)
                Game.Renderer.Render();
            Invalidate();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            //if (Game.Renderer != null)
            //    Game.Renderer.Resize(ClientSize.Width, ClientSize.Height);
        }
    }
}
