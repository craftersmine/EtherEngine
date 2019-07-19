using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Input;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    internal static class GameUpdateHandlers
    {
        public static void FixedUpdateHandler(object sender, UpdateEventArgs e)
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.OnFixedUpdate((float)e.DeltaTime.TotalMilliseconds);
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                {
                    SceneManager.CurrentScene.GameObjects[obj].InternalOnFixedUpdate();
                }
            }
        }

        public static void UpdateHandler(object sender, UpdateEventArgs e)
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.OnUpdate((float)e.DeltaTime.TotalMilliseconds);
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                {
                    SceneManager.CurrentScene.GameObjects[obj].InternalOnUpdate();
                }
            }
        }

        public static void PausedUpdateHandler(object sender, EventArgs e)
        {
            if ((Keyboard.IsKeyPressed(Key.LeftAlt) || Keyboard.IsKeyPressed(Key.RightAlt)) &&
                (Keyboard.IsKeyPressed(Key.LeftShift) || Keyboard.IsKeyPressed(Key.RightShift)) &&
                Keyboard.GetKeyState(Key.F12).IsPressed)
            {
                if (Game.IsPaused)
                    Game.Resume();
                else Game.Pause();
            }
            Game.RaisePausedUpdate();
        }
    }
}
