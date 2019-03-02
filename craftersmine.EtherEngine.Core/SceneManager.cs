using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Core.Exceptions;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Provides static methods to manage scenes
    /// </summary>
    public sealed class SceneManager
    {
        /// <summary>
        /// Gets current shown scene
        /// </summary>
        public static Scene CurrentScene { get; internal set; }
        internal static Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();

        /// <summary>
        /// Sets current scene with specified
        /// </summary>
        /// <param name="scene">Scene to set</param>
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

        /// <summary>
        /// Sets current scene with early loaded scene by it ID
        /// </summary>
        /// <param name="id"></param>
        public static void SetScene(int id)
        {
            if (Contains(id))
            {
                SetScene(_scenes[id]);
            }
            else throw new SceneManagerException("No loaded scene with " + id + " id!");
        }

        /// <summary>
        /// Returns true if a specified scene ID is loaded and ID is exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Contains(int id)
        {
            if (_scenes.ContainsKey(id))
                return true;
            else return false;
        }

        /// <summary>
        /// Loads scene into a memory under specified ID and stores it
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="id"></param>
        public static void LoadScene(Scene scene, int id)
        {
            if (!_scenes.ContainsKey(id))
                _scenes.Add(id, scene);
            else throw new SceneManagerException("Scene with " + id + " id already loaded!");
        }

        /// <summary>
        /// Unloads early loaded scene from memory with specified ID, but not switches it to other if it shown to user
        /// </summary>
        /// <param name="id"></param>
        public static void UnloadScene(int id)
        {
            if (_scenes.ContainsKey(id))
                _scenes.Remove(id);
            else throw new SceneManagerException("Unable to unload scene with " + id + " id! There is no scene with this id");
        }
    }
}
