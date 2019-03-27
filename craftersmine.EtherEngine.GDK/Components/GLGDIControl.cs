using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Rendering;
using OpenTK;

namespace craftersmine.EtherEngine.GDK.Components
{
    public sealed class GLGDIControl : GLControl
    {
        public GLGDI GLGDIInstance { get; set; }

        public event EventHandler<SceneEditorRenderEventArgs> Render;

        public GLGDIControl()
        {
            
        }

        public void Initiate()
        {
            GLGDIInstance = new GLGDI();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode)
            {
                e.Graphics.Clear(Color.LightBlue);
                e.Graphics.Flush();
                return;
            }

            MakeCurrent();

            Render?.Invoke(this, new SceneEditorRenderEventArgs() { GLGDIInstance = this.GLGDIInstance });

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
}
