using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Utilities;
using GLGDIPlus;
//using craftersmine.EtherEngine.Utilities;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace craftersmine.EtherEngine.Rendering.Tester
{
    static class Program
    {
        //static GLGraphics paintHelper;
        //static GLGDI paintHelper;
        static Window gameWindow;
        public static Texture texture;
        static Animation animation;

        static void Main(string[] args)
        {
            //Logger.DefaultLog(LogEntryType.Info, "Initialize renderer tester...");
            //Application.Run(new MainForm());
            gameWindow = new Window("[RENDERER/CONTENT] craftersmine.EtherEngine", WindowSizePresets.SVGA, false);
            gameWindow.VSyncMode = VSyncMode.On;
            gameWindow.GLGDI.IsLinearFilteringEnabled = false;
            Debugging.DrawFPS = true;
            Debugging.ShowDrawCallsPerFrameInTitle = true;

            ContentManager mgr = new ContentManager("root");

            texture = mgr.LoadTexture("TestCircle");

            animation = mgr.LoadAnimation("Animation");

            Game.GameStarted += Game_GameStarted;

            Game.Run(gameWindow);
        }

        private static void Game_GameStarted(object sender, EventArgs e)
        {
            SceneManager.SetScene(new BaseScene());
        }

        static int drawCallsPerFrame = 0;

        private static void GameWindow_Render(object sender, RenderEventArgs e)
        {
            e.GLGDIInstance.DrawRectangle(Color.Black, new Rectangle(4, 4, 100, 50));
            gameWindow.Title = "FPS: " + gameWindow.FPS + " | DCPS: " + drawCallsPerFrame;
            drawCallsPerFrame = 0;
        }
    }

    public sealed class BaseScene : Scene
    {
        int coordCount = 0;

        List<GameObject> myObjs = new List<GameObject>();

        public override void OnStart()
        {
            BackgroundColor = Color.Green;
            for (int x = 0; x < SceneCamera.FrameWidth / 2 / 32 + 1; x++)
                for (int y = 0; y < SceneCamera.FrameHeight / 2 / 32 + 1; y++)
                {
                    int xCoord = x * 32;
                    int yCoord = y * 32;

                    GameObject obj = new GameObject();

                    obj.X = xCoord;
                    obj.Y = yCoord;
                    obj.Texture = Program.texture;
                    obj.Width = obj.Texture.Width;
                    obj.Height = obj.Texture.Height;

                    myObjs.Add(obj);
                }

            AddGameObjects(myObjs);
        }

        public override void OnUpdate()
        {
            foreach (var obj in myObjs)
            {
                obj.X++;
                obj.Y++;
            }
        }
    }
}
