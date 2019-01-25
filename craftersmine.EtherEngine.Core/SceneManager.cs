using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Core.Exceptions;

namespace craftersmine.EtherEngine.Core
{
    public sealed class SceneManager
    {
        internal static Scene CurrentScene { get; set; }
        internal static Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();

        public static void SetScene(Scene scene)
        {
            if (CurrentScene != null)
            {
                CurrentScene.OnUnload();
                CurrentScene = null;
            }
            CurrentScene = scene;
            CurrentScene.InternalCreate();
            if (Game.GameWnd != null)
                Game.GameWnd.GLGDI.ClearColor = CurrentScene.BackgroundColor;
        }

        public static void SetScene(int id)
        {
            if (Contains(id))
            {
                SetScene(_scenes[id]);
            }
            else throw new SceneManagerException("No loaded scene with " + id + " id!");
        }

        public static bool Contains(int id)
        {
            if (_scenes.ContainsKey(id))
                return true;
            else return false;
        }

        public static void LoadScene(Scene scene, int id)
        {
            if (!_scenes.ContainsKey(id))
                _scenes.Add(id, scene);
            else throw new SceneManagerException("Scene with " + id + " id already loaded!");
        }

        public static void UnloadScene(int id)
        {
            if (_scenes.ContainsKey(id))
                _scenes.Remove(id);
            else throw new SceneManagerException("Unable to unload scene with " + id + " id! There is no scene with this id");
        }
    }
}
