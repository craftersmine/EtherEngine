﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Objects;
using craftersmine.EtherEngine.Utilities;
using craftersmine.EtherEngine.Input;
using craftersmine.EtherEngine.Objects.UIWidgets;
using craftersmine.EtherEngine.Core.EnginePrefabs;

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
                Debugging.DrawRays = true;

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
            SceneManager.SetScene(new DefaultScene());
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
        Tileset tileset;
        Ray ray;
        Button btn;

        public override void OnStart()
        {
            ray = new Ray(new Point(400, 200), 100.0f);
            BackgroundColor = Color.Black;
            //movable.Texture = Program.contentManager.LoadTexture("TestAnim");
            movable.Animation = Program.animation;
            movable.IsAnimated = true;
            movable.Width = 32;
            movable.Height = 32;
            movable.X = 32;
            movable.Y = 32;
            //movable.BlendingColor = Color.Red;
            movable.ObjectTransparency = .5f;

            tileset = new Tileset(32, 32, null);

            particleSystem = new ParticleSystem(new Particle(Program.contentManager.LoadTexture("TestCircle")), new ParticleBehaviour(ParticleBehaviourMethod), 180, 30, 16, true);
            particleSystem.X = 200; particleSystem.Y = 200;
            particleSystem.Collidable = true;
            particleSystem.SetCollsionBox(new CollisionBox(0, 0, 32, 32));
            particleSystem.OnUpdateAction = new ParticleOnUpdateAction(ParticleOnUpdate);

            for (int x = 0; x < SceneCamera.FrameWidth / 32; x++)
                for (int y = 0; y < SceneCamera.FrameHeight / 2 / 32 + 1; y++)
                {
                    int tileId = new Random().Next(0, 1);
                    switch (tileId)
                    {
                        case 0:
                            tileset.AddTile(new GrassTile(), x, y);
                            break;
                        case 1:
                            tileset.AddTile(new GrassTile(), x, y);
                            break;
                    }
                }

            btn = new Button();
            btn.Click += Btn_Click;

            //AddGameObjects(myObjs);
            AddGameObject(tileset);
            AddGameObject(movable);
            AddGameObject(particleSystem);
            AddUIWidget(btn);
            btn.Texture = Program.contentManager.LoadTextureAtlas("tiles").CutFromAtlas(32, 0, 32, 32);
            //particleSystem.Emit();
            audioclip = Program.contentManager.LoadAudioClip("TestAudioClip");
            CreateAudioChannel("aud", audioclip);
        }

        Random particleRandomizer = new Random();

        private void ParticleBehaviourMethod(Particle particle, float deltaTime)
        {
            particle.X += particle.HorizontalVelocity * deltaTime + particleRandomizer.Next(-15, 15);
            particle.Y += particle.VerticalVelocity * deltaTime + particleRandomizer.Next(-15, 15);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            SettingsController.IsFullscreen = !SettingsController.IsFullscreen;
        }

        private void ParticleOnUpdate(Particle particle)
        {
            float lifetimeFac = (float)particle.CurrentLifetime / (float)particle.Lifetime;
            particle.ObjectTransparency = 1.0f * lifetimeFac;
        }

        public override void OnUpdate(float deltaTime)
        {
            if (Keyboard.IsKeyDown(Key.Number1))
                SettingsController.Resolution = WindowSizePresets.SVGA;
            if (Keyboard.IsKeyDown(Key.Number2))
                SettingsController.Resolution = WindowSizePresets.HD;
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
                particleSystem.EmitOnce();
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



            if (Keyboard.IsKeyDown(Key.Up))
            {
                GameObject[] castedObjs = ray.Cast(0.0f);
            }
            if (Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Right))
                ray.Cast(45.0f);
            if (Keyboard.IsKeyDown(Key.Right))
                ray.Cast(90.0f);
            if (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Down))
                ray.Cast(135.0f);
            if (Keyboard.IsKeyDown(Key.Down))
            {
                GameObject[] castedObjs = ray.Cast(180.0f);
            }
            if (Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Left))
                ray.Cast(225.0f);
            if (Keyboard.IsKeyDown(Key.Left))
                ray.Cast(270.0f);
            if (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Up))
            {
                GameObject[] castedObjs = ray.Cast(315.0f);
            }
        }
    }

    public class GrassTile : Tile
    {
        public GrassTile()
        {
            Texture = Program.contentManager.LoadTextureAtlas("tiles").CutFromAtlas(0, 0, 32, 32);
        }
    }

    public class SandTile : Tile
    {
        public SandTile()
        {
            Texture = Program.contentManager.LoadTextureAtlas("tiles").CutFromAtlas(32, 0, 32, 32);
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
