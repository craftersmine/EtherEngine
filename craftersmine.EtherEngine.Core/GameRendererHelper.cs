using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    internal sealed class GameRendererHelper
    {
        internal static int DrawCallsPerFrame { get; private set; }

        internal static void OnRender(object sender, RenderEventArgs e)
        {
            Debugging.DrawCalls = 0;
            if (SceneManager.CurrentScene != null)
            {
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                {
                    if (SceneManager.CurrentScene.GameObjects[obj].Visible)
                    {
                        if (SceneManager.CurrentScene.GameObjects[obj].Texture != null)
                        {
                            if (SceneManager.CurrentScene.GameObjects[obj].RendererX + SceneManager.CurrentScene.GameObjects[obj].Width > 0 &&
                                SceneManager.CurrentScene.GameObjects[obj].RendererX < SceneManager.CurrentScene.SceneCamera.FrameWidth &&
                                SceneManager.CurrentScene.GameObjects[obj].RendererY + SceneManager.CurrentScene.GameObjects[obj].Height > 0 &&
                                SceneManager.CurrentScene.GameObjects[obj].RendererY < SceneManager.CurrentScene.SceneCamera.FrameHeight)
                            {
                                SceneManager.CurrentScene.GameObjects[obj].IsVisibleByCamera = true;
                                e.GLGDIInstance.DrawImage(SceneManager.CurrentScene.GameObjects[obj].Texture.RenderableImage,
                                    SceneManager.CurrentScene.GameObjects[obj].RendererX,
                                    SceneManager.CurrentScene.GameObjects[obj].RendererY,
                                    SceneManager.CurrentScene.GameObjects[obj].Width,
                                    SceneManager.CurrentScene.GameObjects[obj].Height);
                                Debugging.DrawCalls++;
                            }
                            else
                                SceneManager.CurrentScene.GameObjects[obj].IsVisibleByCamera = true;
                        }
                    }
                }
            }
            if (Debugging.ShowDrawCallsPerFrameInTitle)
                Game.GameWnd.Title = Game.DefaultWindowTitle + " | " + Debugging.DrawCalls;
        }
    }
}
