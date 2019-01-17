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
using craftersmine.GameEngine.Input;

namespace craftersmine.EtherEngine.Rendering.Tester
{
    static class Program
    {
        //static GLGraphics paintHelper;
        //static GLGDI paintHelper;
        static Window gameWindow;
        public static Texture texture;
        static Animation animation;
        public static ContentManager contentManager;

        static void Main(string[] args)
        {
            //Logger.DefaultLog(LogEntryType.Info, "Initialize renderer tester...");
            //Application.Run(new MainForm());
            gameWindow = new Window("[RENDERER/CONTENT] craftersmine.EtherEngine", WindowSizePresets.SVGA, false);
            gameWindow.VSyncMode = VSyncMode.On;
            gameWindow.GLGDI.IsLinearFilteringEnabled = false;
            Debugging.DrawDebug = true;
            Debugging.ShowDrawCallsPerFrameInTitle = true;

            contentManager = new ContentManager("root");

            texture = contentManager.LoadTexture("TestCircle");

            animation = contentManager.LoadAnimation("Animation");

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
        GameObject movable = new GameObject();

        public override void OnStart()
        {
            BackgroundColor = Color.Green;
            movable.Texture = Program.contentManager.LoadTexture("TestAnim");
            movable.Width = 128;
            movable.Height = 32;
            movable.X = 32;
            movable.Y = 32;

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
            AddGameObject(movable);
        }

        public override void OnUpdate()
        {
            if (Keyboard.IsKeyDown(Keys.W))
            {
                movable.Y--;
                SceneCamera.MoveCamera(0, 1);
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                movable.Y++;
                SceneCamera.MoveCamera(0, -1);
            }
            if (Keyboard.IsKeyDown(Keys.A))
            {
                movable.X--;
                SceneCamera.MoveCamera(-1, 0);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                movable.X++;
                SceneCamera.MoveCamera(1, 0);
            }
        }
    }
}
