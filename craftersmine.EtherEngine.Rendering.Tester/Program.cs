using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Objects;
using craftersmine.EtherEngine.Utilities;
using craftersmine.EtherEngine.Input;

namespace craftersmine.EtherEngine.Rendering.Tester
{
    static class Program
    {
        //static GLGraphics paintHelper;
        //static GLGDI paintHelper;
        static Window gameWindow;
        public static Texture texture;
        public static Animation animation;
        public static ContentManager contentManager;

        static void Main(string[] args)
        {
            try
            {
                //Logger.DefaultLog(LogEntryType.Info, "Initialize renderer tester...");
                //Application.Run(new MainForm());
                gameWindow = new Window("[RENDERER/CONTENT] craftersmine.EtherEngine", WindowSizePresets.SVGA, false);
                gameWindow.VSyncMode = VSyncMode.On;
                gameWindow.GLGDI.IsLinearFilteringEnabled = false;
                Debugging.DrawDebug = true;
                Debugging.ShowDrawCallsPerFrameInTitle = true;
                Debugging.DrawBounds = true;

                contentManager = new ContentManager("root");

                texture = contentManager.LoadTexture("TestCircle");

                animation = contentManager.LoadAnimation("Animation");

                Game.GameStarted += Game_GameStarted;

                Game.Run(gameWindow);
            }
            catch (Exception ex)
            {
                CrashHandler.Handle(ex);
            }
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
        List<GameObject> myObjs = new List<GameObject>();
        Movable movable = new Movable();
        ParticleSystem particleSystem;
        AudioClip audioclip;

        public override void OnStart()
        {
            BackgroundColor = Color.Green;
            //movable.Texture = Program.contentManager.LoadTexture("TestAnim");
            movable.Animation = Program.animation;
            movable.IsAnimated = true;
            movable.Width = 32;
            movable.Height = 32;
            movable.X = 32;
            movable.Y = 32;
            //movable.BlendingColor = Color.Red;
            movable.ObjectTransparency = .5f;

            particleSystem = new ParticleSystem(new Particle(Program.contentManager.LoadTexture("TestCircle")), 180, 30, 1.0f, 0.3f, 16, true);
            particleSystem.X = 200; particleSystem.Y = 200;
            particleSystem.Collidable = true;
            particleSystem.SetCollsionBox(new CollisionBox(0, 0, 32, 32));
            particleSystem.OnUpdateAction = new ParticleOnUpdateAction(ParticleOnUpdate);

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

            //AddGameObjects(myObjs);
            AddGameObject(movable);
            AddGameObject(particleSystem);
            //particleSystem.Emit();
            audioclip = Program.contentManager.LoadAudioClip("TestAudioClip");
            CreateAudioChannel("aud", audioclip);
        }

        private void ParticleOnUpdate(Particle particle)
        {
            float lifetimeFac = (float)particle.CurrentLifetime / (float)particle.Lifetime;
            particle.ObjectTransparency = 1.0f * lifetimeFac;
        }

        public override void OnUpdate()
        {

            DPad DPad = Gamepad.GetDPad(Player.First);
            Buttons Buttons = Gamepad.GetButtons(Player.First);
            if (Keyboard.IsKeyDown(Key.W) || DPad.Up)
            {
                movable.Y--;
                SceneCamera.MoveCamera(0, 1);
            }
            if (Keyboard.IsKeyDown(Key.S) || DPad.Down)
            {
                movable.Y++;
                SceneCamera.MoveCamera(0, -1);
            }
            if (Keyboard.IsKeyDown(Key.A) || DPad.Left)
            {
                movable.X--;
                SceneCamera.MoveCamera(-1, 0);
            }
            if (Keyboard.IsKeyDown(Key.D) || DPad.Right)
            {
                movable.X++;
                SceneCamera.MoveCamera(1, 0);
            }
            if (Keyboard.IsKeyDown(Key.P) || Buttons.A)
                particleSystem.Emit();
            if (Keyboard.IsKeyDown(Key.Q))
                movable.Transform.Rotate(-0.5f);
            if (Keyboard.IsKeyDown(Key.E))
                movable.Transform.Rotate(0.5f);
            if (Keyboard.IsKeyDown(Key.R))
                movable.Transform.RotationAngle = 0.0f;
            if (Keyboard.IsKeyDown(Key.C))
                GetAudioChannel("aud").Play();
            if (Keyboard.IsKeyDown(Key.KeypadPlus))
                movable.ObjectTransparency += .05f;
            if (Keyboard.IsKeyDown(Key.KeypadMinus))
                movable.ObjectTransparency -= .05f;
        }
    }

    public class Movable : GameObject
    {
        public override void OnStart()
        {
            base.OnStart();
            SetCollsionBox(new CollisionBox(0, 0, 32, 32));
            Collidable = true;
        }

        public override void OnCollide(GameObject gameObject)
        {
            base.OnCollide(gameObject);
            if (gameObject.GetType() == typeof(ParticleSystem))
                SceneManager.CurrentScene.RemoveGameObject(this);
        }

        public override void OnMouseDown(int mouseX, int mouseY, bool mouseLeftButton, bool mouseMiddleButton, bool mouseRightButton)
        {
            base.OnMouseDown(mouseX, mouseY, mouseLeftButton, mouseMiddleButton, mouseRightButton);
            Debugging.Log(LogEntryType.Debug, "MX: " + mouseX + " MY: " + mouseY + " MLB: " + mouseLeftButton + " MMB: " + mouseMiddleButton + " MRB: " + mouseRightButton);
        }

        public override void OnRender(GLGDI renderer)
        {
            base.OnRender(renderer);
        }
    }
}
