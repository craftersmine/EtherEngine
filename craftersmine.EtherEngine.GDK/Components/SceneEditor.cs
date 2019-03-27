using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Utilities;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Core;
using OpenTK.Graphics.OpenGL;
using craftersmine.EtherEngine.GDK.GameBaseComponents;

namespace craftersmine.EtherEngine.GDK.Components
{
    public partial class SceneEditor : EditorBase
    {
        private AccurateTimer renderUpdater;
        private Action swapBuffersAction;
        private Action frameRenderAction;
        
        [Browsable(true)]
        [Description("Occurs when frame being rendered")]
        public event EventHandler<SceneEditorRenderEventArgs> Render;

        public SceneEditor()
        {
            frameRenderAction = new Action(() => {
                openGLWindow.Invalidate();
            });
            renderUpdater = new AccurateTimer(frameRenderAction, 16);
            InitializeComponent();

            openGLWindow.Render += OpenGLWindow_Render;
        }

        private void OpenGLWindow_Render(object sender, SceneEditorRenderEventArgs e)
        {
            if (e.GLGDIInstance != null)
            {
                e.GLGDIInstance.ClearColor = StaticData.EditingScene.BackgroundColor;
                Render?.Invoke(this, e);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            StaticData.RenderFrame = this.ClientRectangle;
            if (StaticData.EditingScene != null)
                StaticData.EditingScene.SceneCamera?.ResizeFrame(StaticData.RenderFrame.Width, StaticData.RenderFrame.Height);
        }

        public void StartRender()
        {
            renderUpdater.Start();
            openGLWindow.Initiate();
        }

        public void StopRender()
        {
            renderUpdater.Stop();
        }

        public void SwapBuffers()
        {
            openGLWindow.SwapBuffers();
        }

        public void MakeCurrent()
        {
            openGLWindow.MakeCurrent();
        }

        public override void OnSave()
        {
            base.OnSave();
        }
    }
    
    public sealed class SceneEditorRenderEventArgs : EventArgs
    {
        public GLGDI GLGDIInstance { get; set; }
    }
}
