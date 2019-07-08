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
    /// <summary>
    /// Represents game window. This class cannot be inherited
    /// </summary>
    public sealed class GameWindow : RenderForm
    {
        private WindowParameters wndParams;

        /// <summary>
        /// Gets or sets window parameters
        /// </summary>
        public WindowParameters WindowParameters { get { return wndParams; } internal set { ApplyWindowParams(value); } }
        /// <summary>
        /// Gets current game window instance
        /// </summary>
        public static GameWindow Current { get; internal set; }

        private GameWindow() { } // Hidden constructor

        /// <summary>
        /// Creates new <see cref="GameWindow"/> instance with specified window parameters
        /// </summary>
        /// <param name="parameters">Window parameters for window</param>
        public GameWindow(WindowParameters parameters)
        {
            ApplyWindowParams(parameters);
            ResizeRedraw = true;
            Current = this;
        }

        internal void ApplyWindowParams(WindowParameters parameters)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ApplyWndParams(parameters); }));
            }
            else ApplyWndParams(parameters);
        }

        private void ApplyWndParams(WindowParameters parameters)
        {
            if (parameters.Width == 0)
                parameters.Width = 800;
            if (parameters.Height == 0)
                parameters.Height = 600;

            wndParams = parameters;
            Text = WindowParameters.Title;
            ClientSize = new Size(WindowParameters.Width, WindowParameters.Height);
        }

        /// <summary>
        /// Called on <see cref="Form.FormClosing"/> event
        /// </summary>
        /// <param name="e">A FormClosingEventArgs that contains the event data</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (Game.IsCloseWindowExitsGame)
            {
                Game.Exit(0);
            }
            else e.Cancel = true;
        }

        /// <summary>
        /// Called on <see cref="Form.Shown"/> event
        /// </summary>
        /// <param name="e">A EventArgs that contains the event data</param>
        protected override void OnShown(EventArgs e)
        {
            Game.RaiseGameInitialized();
        }
    }
}
