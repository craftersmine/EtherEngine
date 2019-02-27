using System;
using System.Collections.Generic;
using System.Drawing;
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
                            if (SceneManager.CurrentScene.GameObjects[obj].Transform.RendererX + SceneManager.CurrentScene.GameObjects[obj].Width > 0 &&
                                SceneManager.CurrentScene.GameObjects[obj].Transform.RendererX < SceneManager.CurrentScene.SceneCamera.FrameWidth &&
                                SceneManager.CurrentScene.GameObjects[obj].Transform.RendererY + SceneManager.CurrentScene.GameObjects[obj].Height > 0 &&
                                SceneManager.CurrentScene.GameObjects[obj].Transform.RendererY < SceneManager.CurrentScene.SceneCamera.FrameHeight)
                            {
                                SceneManager.CurrentScene.GameObjects[obj].IsVisibleByCamera = true;
                                e.GLGDIInstance.Rotate(SceneManager.CurrentScene.GameObjects[obj].Transform.RotationAngle, SceneManager.CurrentScene.GameObjects[obj].Transform.Width / 2, SceneManager.CurrentScene.GameObjects[obj].Transform.Height / 2);
                                SceneManager.CurrentScene.GameObjects[obj].OnRender(e.GLGDIInstance);
                                Debugging.DrawCalls++;
                            }
                            else
                                SceneManager.CurrentScene.GameObjects[obj].IsVisibleByCamera = false;
                        }
                    }
                }
                if (Debugging.DrawBounds)
                {
                    for (int i = 0; i < SceneManager.CurrentScene.GameObjects.Count; i++)
                    {
                        Game.GLGDIInstance.DrawRectangle(
                            Color.Yellow,
                            (int)SceneManager.CurrentScene.GameObjects[i].Transform.RendererX,
                            (int)SceneManager.CurrentScene.GameObjects[i].Transform.RendererY,
                            SceneManager.CurrentScene.GameObjects[i].Width,
                            SceneManager.CurrentScene.GameObjects[i].Height);
                        if (SceneManager.CurrentScene.GameObjects[i].CollisionBox != null)
                        {
                            int x = SceneManager.CurrentScene.GameObjects[i].CollisionBox.CollisionBoxBounds.X + SceneManager.CurrentScene.GameObjects[i].Transform.RendererX;
                            int y = SceneManager.CurrentScene.GameObjects[i].CollisionBox.CollisionBoxBounds.Y + SceneManager.CurrentScene.GameObjects[i].Transform.RendererY;
                            Game.GLGDIInstance.DrawRectangle(Color.Red, x, y, SceneManager.CurrentScene.GameObjects[i].CollisionBox.CollisionBoxBounds.Width, SceneManager.CurrentScene.GameObjects[i].CollisionBox.CollisionBoxBounds.Height);
                        }
                    }
                }
            }
            if (Debugging.ShowDrawCallsPerFrameInTitle)
                Game.GameWnd.Title = Game.DefaultWindowTitle + " | " + Debugging.DrawCalls + " DrawCalls/s";
        }
    }
}
