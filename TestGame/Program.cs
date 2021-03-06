﻿using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Input;
using craftersmine.EtherEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new GameWindow(new WindowParameters(800, 600));
            Game.GameInitialized += Game_GameInitialized;
            Game.GamePausedUpdate += Game_GamePausedUpdate;
            Game.Run(GameWindow.Current);
        }

        private static void Game_GamePausedUpdate(object sender, EventArgs e)
        {
            if (Keyboard.GetKeyState(Key.P).IsPressed)
            {
                if (!Game.IsPaused)
                    Game.Pause();
                else Game.Resume();
            }
        }

        private static void Game_GameInitialized(object sender, EventArgs e)
        {
            SceneManager.LoadScene(new FirstScene());
        }
    }

    class FirstScene : Scene
    {
        public FirstScene() : base()
        {
            BackgroundColor = new Color(0.5f, 0.5f, 0f);
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Debugging.Log(LogEntryType.Info, "FirstScene.OnCreate called!");
            GameObject test1 = new GameObject();
            Material mat = new Material(Texture.FromFile(@"D:\Desktop\tiling.png"));
            test1.Transform.Width = mat.Texture.Width;
            test1.Transform.Height = mat.Texture.Height;
            test1.Transform.X = 10;
            test1.Transform.Y = 10;
            test1.GetComponent<SpriteRenderer>().Material = mat;
            test1.CollisionBox.Height = 10f;
            test1.CollisionBox.Width = 10f;
            test1.CollisionBox.OffsetX = 5f;
            test1.CollisionBox.OffsetY = 5f;
            this.AddGameObject(test1);
        }

        private int count;

        public override void OnFixedUpdate(float deltaTime)
        {
            base.OnFixedUpdate(deltaTime);
            //count++;
            //if (count == 600)
            //    SceneManager.LoadScene(new SecondScene());
        }

        public float velocity = 1f;

        public override void OnUpdate(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Key.W))
            {
                Debugging.Log(LogEntryType.Debug, "W pressed");
                Camera.Y -= velocity * Time.DeltaTime;
            }
            if (Keyboard.IsKeyPressed(Key.A))
            {
                Debugging.Log(LogEntryType.Debug, "A pressed");
                Camera.X -= velocity * Time.DeltaTime;
            }
            if (Keyboard.IsKeyPressed(Key.S))
            {
                Debugging.Log(LogEntryType.Debug, "S pressed");
                Camera.Y += velocity * Time.DeltaTime;
            }
            if (Keyboard.IsKeyPressed(Key.D))
            {
                Debugging.Log(LogEntryType.Debug, "D pressed");
                Camera.X += velocity * Time.DeltaTime;
            }
        }
    }

    class SecondScene : Scene
    {
        public SecondScene() : base()
        {
            BackgroundColor = new Color(0f, .5f, .5f);
        }
    }
}
